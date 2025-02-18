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
	public partial class MainForm : Form
	{
		private readonly RegistrationForm RegistrationDialog;
		private readonly LoginForm LoginDialog;
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
		public MainForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			UserUuid = Guid.Empty;
			DataSet = fileDataSet;
			RegistrationDialog = new RegistrationForm(fileDataSet);
			RegistrationDialog.SuccessfulRegistration += RegistrationForm_SuccessfulRegistration;
			LoginDialog = new LoginForm(fileDataSet);
			LoginDialog.SuccessfulLogin += LoginForm_SuccessfulLogin;
		}

		private void RegistrationForm_SuccessfulRegistration(Guid uuid, string login, string password)
		{
			MessageBox.Show($"uuid: {uuid}\nЛогин: {login}\nПароль: {password}", "Пользователь зарегистрирован");
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
			DataSet.LogOut(UserUuid);
			UserUuid = Guid.Empty;
			//MessageBox.Show("Вы вышли из учётной записи!");
		}

		private void RegisterB_Click(object sender, EventArgs e)
		{
			RegistrationDialog.BeginRegistration(UserUuid);
		}
	}
}
