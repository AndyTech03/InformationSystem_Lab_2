using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public partial class ConfigsForm : Form, IDialogForm
	{
		private readonly FileDataSet DataSet;
		private Guid adminUuid;
		private const string RESET_TEXT = "DEFAULT";

		public event Action UserAction;

		public ConfigsForm(FileDataSet dataSet)
		{
			InitializeComponent();
			DataSet = dataSet;
			adminUuid = Guid.Empty;

			MouseMove += (object _, MouseEventArgs __) => UserAction?.Invoke();
			Click += (object _, EventArgs __) => UserAction?.Invoke();
			foreach (Control control in Controls)
				control.Click += (object _, EventArgs __) => UserAction?.Invoke();
			KeyDown += (object _, KeyEventArgs __) => UserAction?.Invoke();
			KeyPreview = true;
		}

		private void RefreshB_Click(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void SaveB_Click(object sender, EventArgs e)
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
				MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return;
			}
			var configsTable = ConfigsDS.Tables["Configs"];
			foreach (DataGridViewRow row in ConfigsDGV.Rows)
			{
				string name = row.Cells[0].Value.ToString();
				string data = row.Cells[1].Value.ToString();
				if (data == RESET_TEXT)
					data = null;
				DataSet.SetConfig(name, data, adminUuid, out string result, out bool denied);
				if (denied)
				{
					MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DialogResult = DialogResult.Ignore;
					return;
				}
				if (result != null)
				{
					MessageBox.Show(result);
				}
			}
			UpdateData();
		}

		public DialogResult BeginConfigDialog(Guid adminUuid)
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
				MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return DialogResult;
			}
			this.adminUuid = adminUuid;
			return ShowDialog();
		}

		private void ConfigsForm_Shown(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void UpdateData()
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
				MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return;
			}
			ConfigData[] configs = DataSet.GetConfigs();
			ConfigsDS.Clear();
			var configsTable = ConfigsDS.Tables["Configs"];
			foreach (ConfigData config in configs)
			{
				DataRow userRow = configsTable.NewRow();
				userRow.ItemArray = new object[] {
					config.name, config.data
				};
				configsTable.Rows.Add(userRow);
			}
			ConfigsDGV.ClearSelection();
		}

		private void ConfigsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			adminUuid = Guid.Empty;
		}

		private void ResetB_Click(object sender, EventArgs e)
		{
			HashSet<int> rows = new HashSet<int>();
			if (ConfigsDGV.SelectedCells.Count == 0)
			{
				MessageBox.Show(
					"Выберите одну или несколько строк в таблице!", "Нет данных",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			foreach (DataGridViewCell c in ConfigsDGV.SelectedCells) 
			{ 
				rows.Add(c.RowIndex); 
			}
			foreach (int index in rows)
			{
				var row = ConfigsDGV.Rows[index];
				row.Cells[1].Value = RESET_TEXT;
			}
		}
	}
}
