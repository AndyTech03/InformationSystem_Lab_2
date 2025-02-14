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
			bool result = _fileDataSet.VerifyPassword(login, password);
			if (result == false)
			{
				int maxLoginAttempts = _fileDataSet.GetConfig("MaxLoginAttempts");
				int loginAttempts = _fileDataSet.GetLoginAttempts(login);
				if (loginAttempts >= maxLoginAttempts) 
				{
					MessageBox.Show("Вы превысили число неудачных попыток авторизации!\nПопробуйте позже или свяжитесь с администратором.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				_fileDataSet.AddLoginAttempt(login);
				MessageBox.Show("Неверный логин и/или пароль!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			string uuid = _fileDataSet.Login(login, password);
			if (uuid == null) 
			{
				MessageBox.Show("Что то пошло не так...", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			SuccessfulLogin?.Invoke(uuid);
		}
	}
}
