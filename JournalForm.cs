using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public partial class JournalForm : Form
	{
		private readonly FileDataSet DataSet;
		private Guid _adminUuid;
		private bool _archiveMode;
		private bool ArchiveMode
		{
			get => _archiveMode;
			set
			{
				_archiveMode = value;
				CloseGzipTSMI.Visible = value;
				Text = value ? "Архивный журнал событий" : "Журнал событий";
			}
		}
		private EventLogData[] _archiveLogs;
		public JournalForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			DataSet = fileDataSet;
			_adminUuid = Guid.Empty;
			ArchiveMode = false;
			_archiveLogs = new EventLogData[0];
		}

		public DialogResult BeginDialog(Guid adminUuid)
		{
			if (IsAdmin(adminUuid))
			{
				_adminUuid = adminUuid;
				return ShowDialog();
			}
			return DialogResult;
		}

		private void JournalForm_Shown(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void JournalForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_adminUuid = Guid.Empty;
		}

		private void UpdateData(Predicate<EventLogData> searchPredicate = null)
		{
			LoadingTSPG.Value = 0;
			JournalDS.Clear();
			if (IsAdmin(_adminUuid) == false)
				return;
			new Thread(new ParameterizedThreadStart(AsyncUpdate)).Start(searchPredicate);
		}

		private void AsyncUpdate(object args)
		{
			Thread.Sleep(100);
			Predicate<EventLogData> searchPredicate = args as Predicate<EventLogData>;
			IEnumerable<EventLogData> logsEnumerable = null;
			if (ArchiveMode)
			{
				logsEnumerable = _archiveLogs;
			}
			else
			{
				logsEnumerable = DataSet.GetEventsLogs(_adminUuid, out bool denied);
				if (denied)
				{
					OnDenied();
					return;
				}
			}
			EventLogData[] logs = logsEnumerable
				.Where(log => searchPredicate == null || searchPredicate(log))
				.ToArray();
			int totalCount = logs.Length;
			int count = 0;
			int maxValue = LoadingTSPG.Maximum;
			int step = LoadingTSPG.Step;
			int progress = 0;
			List<DataRow> rows = new List<DataRow>();
			Invoke((MethodInvoker)(() =>
			{
				TotalRowsTSL.Text = $"{(ArchiveMode ? "Архив" : "Журнал")}: {totalCount}";
			}));
			var eventsTable = JournalDS.Tables["Events"];
			foreach (EventLogData eventLog in logs)
			{
				if (searchPredicate != null && searchPredicate(eventLog) == false)
					continue;
				DataRow row = eventsTable.NewRow();
				row.ItemArray = new object[]
				{
					eventLog.eventDateTime,
					eventLog.eventType,
					eventLog.userUuid,
					eventLog.userIp,
					eventLog.eventDetail,
				};
				rows.Add(row);
				count++;
				int next = (int)((double)count / totalCount * maxValue);
				if (next - progress >= step)
				{
					progress = next / step * step;
					Invoke((MethodInvoker)(() =>
					{
						LoadingTSPG.Value = progress;
						foreach (DataRow drawingRaw in rows)
							eventsTable.Rows.Add(drawingRaw);
						rows.Clear();
					}));
				}
			}
			Invoke((MethodInvoker)(() =>
			{
				foreach (DataRow drawingRaw in rows)
					eventsTable.Rows.Add(drawingRaw);
				JournalDGV.ClearSelection();
			}));
			Thread.Sleep(1000);
			Invoke((MethodInvoker)(() =>
			{
				LoadingTSPG.Value = 0;
			}));
		}

		private void OnDenied()
		{
			MessageBox.Show(
				"Что то пошло не так, попробуйте ещё раз.", "Доступ запрещён!",
				MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		private bool IsAdmin(Guid adminUuid)
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show(
					"Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return false;
			}
			return true;
		}

		private void RefreshTSM_Click(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void SearchTSMI_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void InvertSearchTSMI_Click(object sender, EventArgs e)
		{
			Search(true);
		}

		private void Search(bool invert = false)
		{
			//Поиск по дате		0
			//Поиск по типу		1
			//Поиск по uuid		2
			//Поиск по ip		3
			//Поиск по detail	4
			if (SearchTypeTSCB.SelectedIndex == -1)
			{
				MessageBox.Show($"Вы не выбрали тип поиска!");
				return;
			}
			Predicate<EventLogData> searchPredicate = null;
			string value = SearchTSTB.Text.ToLower();
			if (value.Trim().Length == 0)
			{
				MessageBox.Show($"Вы не заполнили строку поиска!");
				return;
			}
			switch (SearchTypeTSCB.SelectedIndex)
			{
				case 0:
					searchPredicate = log => log.eventDateTime.ToString().ToLower().Contains(value);
					break;
				case 1:
					searchPredicate = log => log.eventType.ToString().ToLower().Contains(value);
					break;
				case 2:
					if (Guid.TryParse(value, out Guid _) == false)
					{
						MessageBox.Show($"Значение `{value}` является не верным UUID!");
						return;
					}
					searchPredicate = log => log.userUuid == Guid.Parse(value);
					break;
				case 3:
					searchPredicate = log => log.userIp.ToString().ToLower().Contains(value);
					break;
				case 4:
					searchPredicate = log => log.eventDetail.ToLower().Contains(value);
					break;
				case -1:
				default:
					return;
			}
			if (invert)
			{
				UpdateData(log => searchPredicate(log) == false);
			}
			else
			{
				UpdateData(searchPredicate);
			}
		}

		private void ZipTSM_Click(object sender, EventArgs e)
		{
			if (ArchiveMode)
			{
				MessageBox.Show("Вы находитесь в режиме просмотра архива!");
				return;
			}
			MessageBox.Show(DataSet.GzipLogs(_adminUuid));
			UpdateData();
		}

		private void UnZipTSM_Click(object sender, EventArgs e)
		{
			if (ArchiveOpenDialog.ShowDialog() == DialogResult.OK)
			{
				_archiveLogs = DataSet.UnGzipLogs(_adminUuid, ArchiveOpenDialog.FileName).ToArray();
				ArchiveMode = true;
				UpdateData();
				MessageBox.Show("Архив загружен");
			}
		}

		private void CloseGzipTSMI_Click(object sender, EventArgs e)
		{
			ArchiveMode = false;
			UpdateData();
		}
	}
}
