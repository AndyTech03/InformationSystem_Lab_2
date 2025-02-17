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
		public event Action<Guid> SuccessfulLogin;
		private FileDataSet _fileDataSet;
		public LoginForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			_fileDataSet = fileDataSet;
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
			bool blocked = _fileDataSet.GetLoginBlock(login);

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
				if (loginAttempts < maxLoginAttempts && blocked == false)
				{
					MessageBox.Show("Неверный логин и/или пароль!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			if (loginAttempts >= maxLoginAttempts) 
			{
				_fileDataSet.BlockIfNot(login, "Превышен лимит попыток входа!");
				MessageBox.Show("Вы превысили лимит неудачных попыток авторизации!\nСвяжитесь с администратором и попробуйте позже.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (blocked)
			{
				MessageBox.Show("Ваш аккаунт заблокирован!\nСвяжитесь с администратором и попробуйте позже.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Guid uuid = _fileDataSet.Login(login, password);
			if (uuid == Guid.Empty) 
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
