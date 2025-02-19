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

		[StructLayout(LayoutKind.Sequential)]
		public struct LASTINPUTINFO
		{
			public uint cbSize;
			public uint dwTime;
		}
		[DllImport("user32.dll")]
		static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

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
		}

		private static TimeSpan? GetInactiveTime()
		{
			LASTINPUTINFO info = new LASTINPUTINFO();
			info.cbSize = (uint)Marshal.SizeOf(info);
			if (GetLastInputInfo(ref info))
				return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
			else
				return null;
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
				Login();
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
		}

		private void Login()
		{
			while (LoginDialog.ShowDialog() != DialogResult.OK && UserUuid == Guid.Empty)
			{
				if (MessageBox.Show(
					"Вы не авторизованы в системе!", "Пройдите авторизацию!",
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					return;
				}
			}
			AfkTimer.Start();
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
			var timeValue = GetInactiveTime();
			if (timeValue == null)
				return;
			var afkTime = timeValue.Value;
			string afkDelay = DataSet.GetConfig(FileDataSet.AfkDelay);
			int timeLimit = int.Parse(afkDelay.Substring(0, afkDelay.Length - 1));
			bool isAfk = false;
			switch (afkDelay.Last())
			{
				case 'с':
					isAfk = afkTime.TotalSeconds >= timeLimit;
					break;
				case 'м':
					isAfk = afkTime.TotalMinutes >= timeLimit;
					break;
				case 'ч':
					isAfk = afkTime.TotalHours >= timeLimit;
					break;
			}
			if (isAfk)
			{
				LogOut(true);
			}
		}

		private void LogOut(bool afk = false)
		{
			DataSet.LogOut(UserUuid, afk);
			UserUuid = Guid.Empty;
			AfkTimer.Stop();
			if (afk)
				MessageBox.Show("Вы были отключены из-за бездействия.");
			else
				MessageBox.Show("Вы вышли из учётной записи.");
			Login();
		}
	}
}
