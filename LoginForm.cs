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
	public partial class LoginForm : Form
	{
		public event Action<string> SuccessfulLogin;
		private FileDataSet _fileDataSet;
		public LoginForm()
		{
			InitializeComponent();
			_fileDataSet = new FileDataSet();
		}

		private void SubmitB_Click(object sender, EventArgs e)
		{
			string login = LoginTB.Text;
			string password = PasswordPTB.Password;
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) 
			{
				MessageBox.Show("Введите логин и пароль!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			bool result = _fileDataSet.VerifyPassword(login, password);
			int maxLoginAttempts = int.Parse(_fileDataSet.GetConfig("MaxLoginAttempts"));
			int loginAttempts = _fileDataSet.GetLoginAttempts(login);
			
			if (result == false)
			{
				if (loginAttempts == 0)
				{
					_fileDataSet.FirstLoginAttempt(login);
				}
				else
				{
					_fileDataSet.AddLoginAttempt(login);
				}
				loginAttempts++;
				if (loginAttempts < maxLoginAttempts)
				{
					MessageBox.Show("Неверный логин и/или пароль!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			if (loginAttempts >= maxLoginAttempts) 
			{
				MessageBox.Show("Вы превысили лимит неудачных попыток авторизации!\nСвяжитесь с администратором и попробуйте позже.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			string uuid = _fileDataSet.Login(login, password);
			if (uuid == null) 
			{
				MessageBox.Show("Что то пошло не так...", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			SuccessfulLogin?.Invoke(uuid);
			DialogResult = DialogResult.OK;
			MessageBox.Show($"Добро пожаловать!");
		}
	}
}
