using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public partial class MainForm : Form
	{
		private readonly RegistrationForm RegistrationDialog;
		private readonly LoginForm LoginDialog;
		private readonly BlockForm BlockDialog;
		private readonly ConfigsForm ConfigsDialog;
		private readonly JournalForm JournalDialog;
		private readonly FileDataSet DataSet;
		private Guid _user_uuid = Guid.NewGuid(); // Чтобы первый `UserUuid = Guid.Empty;` вызвал очистку формы.
		private Guid UserUuid
		{
			get => _user_uuid;
			set
			{
				if (_user_uuid == value)
					return;
				_user_uuid = value;
				if (value == Guid.Empty)
				{
					UserGB.Text = "Гость";
					LoginL.Text = "НЕТ ДАННЫХ";
					UsersGB.Visible = JournalGB.Visible = false;
				}
				else
				{
					bool isAdmin = DataSet.IsAdmin(value);
					UsersGB.Visible = JournalGB.Visible = isAdmin;
					UserGB.Text = isAdmin ? "Администратор" : "Пользователь";
				}
				AuthB.Enabled = value == Guid.Empty;
				ReAuthB.Enabled = DeAuthB.Enabled = value != Guid.Empty;
			}
		}
		private readonly IDialogForm[] Dialogs;
		public MainForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			UserUuid = Guid.Empty;
			DataSet = fileDataSet;
			RegistrationDialog = new RegistrationForm(fileDataSet);
			RegistrationDialog.SuccessfulRegistration += RegistrationForm_SuccessfulRegistration;
			LoginDialog = new LoginForm(fileDataSet);
			LoginDialog.SuccessfulLogin += LoginForm_SuccessfulLogin;
			BlockDialog = new BlockForm(fileDataSet);
			ConfigsDialog = new ConfigsForm(fileDataSet);
			JournalDialog = new JournalForm(fileDataSet);
			Dialogs = new IDialogForm[] {
				RegistrationDialog,
				BlockDialog,
				ConfigsDialog,
				JournalDialog,
			};
			foreach (IDialogForm dialog in Dialogs)
			{
				dialog.UserAction += OnUserAction;
			}

			MouseMove += (object _, MouseEventArgs __) => OnUserAction();
			Click += (object _, EventArgs __) => OnUserAction();
			foreach (Control control in Controls)
				control.Click += (object _, EventArgs __) => OnUserAction();
			KeyDown += (object _, KeyEventArgs __) => OnUserAction();
			KeyPreview = true;
		}
		private void CloseAllDialogs()
		{
			foreach (IDialogForm dialog in Dialogs)
			{
				dialog.Hide();
			}
		}
		private void RegistrationForm_SuccessfulRegistration(Guid uuid, string login, string password)
		{
			MessageBox.Show(
				$"uuid: {uuid}\nЛогин: {login}\nПароль: {password}", "Пользователь зарегистрирован", 
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void LoginForm_SuccessfulLogin(Guid uuid, string login)
		{
			if (uuid == Guid.Empty)
			{
				var result = MessageBox.Show(
					"Вы не авторизованы в системе!", "Пройдите авторизацию!",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
				if (result == DialogResult.OK)
				{
					Login();
				}
				return;
			}
			if (UserUuid == uuid)
			{
				MessageBox.Show("Вы уже авторизованы под этой записью.");
				return;
			}
			
			if (UserUuid != Guid.Empty)
			{
				DataSet.ReLogIn(UserUuid, uuid);
				//MessageBox.Show($"Вы сменили учётную запись.");
			}
			else
			{
				DataSet.LogIn(uuid);
				//MessageBox.Show($"Вы успешно авторизовались.");
			}
			UserUuid = uuid;
			LoginL.Text = login;
			SetAfkInterval();
			AfkTimer.Start();
			AfkUpdateTimer.Start();
			Select();
		}

		private void Login()
		{
			AfkTimer.Stop();
			AfkUpdateTimer.Stop();
			LoginDialog.Show();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			Login();
		}

		private void AuthB_Click(object sender, EventArgs e)
		{
			Login();
		}

		private void ReAuthB_Click(object sender, EventArgs e)
		{
			Login();
		}

		private void DeAuthB_Click(object sender, EventArgs e)
		{
			LogOut();
		}

		private void RegisterB_Click(object sender, EventArgs e)
		{
			RegistrationDialog.BeginRegistration(UserUuid);
		}

		private void BlockB_Click(object sender, EventArgs e)
		{
			BlockDialog.BeginBlockDialog(UserUuid);
		}

		private void UnblockB_Click(object sender, EventArgs e)
		{
			BlockDialog.BeginBlockDialog(UserUuid);
		}

		private void UsersConfigB_Click(object sender, EventArgs e)
		{
			ConfigsDialog.BeginConfigDialog(UserUuid);
		}

		private void AfkTimer_Tick(object sender, EventArgs e)
		{
			LogOut(true);
		}
		private void OnUserAction()
		{
			AfkTimer.Stop();
			if (UserUuid != Guid.Empty)
				AfkTimer.Start();
		}

		private void LogOut(bool afk = false)
		{
			DataSet.LogOut(UserUuid, afk);
			UserUuid = Guid.Empty;
			AfkTimer.Stop();
			AfkUpdateTimer.Stop();
			CloseAllDialogs();
			if (afk)
				MessageBox.Show("Вы были отключены из-за бездействия.");
			else
				MessageBox.Show("Вы вышли из учётной записи.");
			Login();
		}

		private void SearchB_Click(object sender, EventArgs e)
		{
			JournalDialog.BeginDialog(UserUuid);
		}

		private void ArchiveB_Click(object sender, EventArgs e)
		{
			JournalDialog.BeginDialog(UserUuid);
		}

		private void DearchiveB_Click(object sender, EventArgs e)
		{
			JournalDialog.BeginDialog(UserUuid);
		}

		private void JournalConfigB_Click(object sender, EventArgs e)
		{
			ConfigsDialog.BeginConfigDialog(UserUuid);
		}

		private void AfkUpdateTimer_Tick(object sender, EventArgs e)
		{
			SetAfkInterval();
		}

		private void SetAfkInterval()
		{
			string afkDelay = DataSet.GetConfig(FileDataSet.AfkDelay);
			int timeLimit = int.Parse(afkDelay.Substring(0, afkDelay.Length - 1));
			int oldInterval = AfkTimer.Interval;
			int newInterval = 1000;
			char last = afkDelay.Last();
			switch (last)
			{
				case 'с':
					newInterval = timeLimit * 1000;
					break;
				case 'м':
					newInterval = timeLimit * 1000 * 60;
					break;
				case 'ч':
					newInterval = timeLimit * 1000 * 60 * 60;
					break;
			}
			if (oldInterval != newInterval)
			{
				AfkTimer.Interval = newInterval;
			}
		}
	}
}
