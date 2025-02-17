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
	public partial class RegistrationForm : Form
	{
		public event Action<Guid> SuccessfulRegistration;
		private FileDataSet _fileDataSet;
		private PasswordGeneratorForm GeneratorForm;
		public RegistrationForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			GeneratorForm = new PasswordGeneratorForm();
			GeneratorForm.GeneratedPasswordAccepted += GeneratorForm_GeneratedPasswordAccepted;
			GeneratedPTB.ReadOnly = true;
			_fileDataSet = fileDataSet;
		}

		private void GeneratorForm_GeneratedPasswordAccepted(string password)
		{
			GeneratedPTB.Password = password;
		}

		private void GeneratePasswordB_Click(object sender, EventArgs e)
		{
			string login = LoginTB.Text;
			if (login.Trim().Length != login.Length)
			{
				MessageBox.Show("Логин не должен содержать пробелов!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (login.Length == 0)
			{
				MessageBox.Show("Введите логин!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			GeneratorForm.ShowGeneratePasswordDialog(login);
		}

		private void SubmitB_Click(object sender, EventArgs e)
		{
			string login = LoginTB.Text;
			string password = GeneratedPTB.Password;
			if (login.Length == 0 || password.Length == 0)
			{
				MessageBox.Show("Введите логин и сгенерируйте пароль!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (password != ConfirmedPTB.Password)
			{
				ConfirmedPTB.Password = "";
				MessageBox.Show("Пароли не совпадают!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			bool result = _fileDataSet.TryRegister(login, password);
			if (result == false)
			{
				MessageBox.Show("Логин не подходит, укажите другой!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Guid uuid = _fileDataSet.Login(login, password);
			if (uuid == Guid.Empty)
			{
				MessageBox.Show("Что то пошло не так...", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			SuccessfulRegistration?.Invoke(uuid);
			DialogResult = DialogResult.OK;
		}

		private void LoginTB_TextChanged(object sender, EventArgs e)
		{
			GeneratedPTB.Password = "";
		}
	}
}
