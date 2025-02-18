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
		public event Action<Guid, string> SuccessfulLogin;
		private readonly FileDataSet DataSet;
		public LoginForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			DataSet = fileDataSet;
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

			Guid uuid = DataSet.VerifyPassword(
				login, password, out bool result, 
				out bool blocked, out int loginAttempts);
			int maxLoginAttempts = int.Parse(DataSet.GetConfig("MaxLoginAttempts"));

			if (result == false)
			{
				if (loginAttempts == 0)
					DataSet.FirstLoginAttempt(uuid);
				else
					DataSet.AddLoginAttempt(uuid);
				loginAttempts++;
				if (loginAttempts < maxLoginAttempts && blocked == false)
				{
					MessageBox.Show("Неверный логин и/или пароль!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			if (loginAttempts >= maxLoginAttempts) 
			{
				DataSet.BlockIfNot(uuid, "Превышен лимит попыток входа!");
				MessageBox.Show("Вы превысили лимит неудачных попыток авторизации!\nСвяжитесь с администратором и попробуйте позже.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (blocked)
			{
				MessageBox.Show("Ваш аккаунт заблокирован!\nСвяжитесь с администратором и попробуйте позже.", "Временная блокировка аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (uuid == Guid.Empty) 
			{
				MessageBox.Show("Что то пошло не так...", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			SuccessfulLogin?.Invoke(uuid, login);
			DialogResult = DialogResult.OK;
		}
	}
}
