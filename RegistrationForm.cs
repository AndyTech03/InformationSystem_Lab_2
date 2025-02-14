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
		public event Action<string, string> UserRegistration;
		private PasswordGeneratorForm GeneratorForm;
		public RegistrationForm()
		{
			InitializeComponent();
			GeneratorForm = new PasswordGeneratorForm();
			GeneratorForm.GeneratedPasswordAccepted += GeneratorForm_GeneratedPasswordAccepted;
			GeneratedPTB.ReadOnly = true;
		}

		private void GeneratorForm_GeneratedPasswordAccepted(string password)
		{
			GeneratedPTB.Password = password;
		}

		private void GeneratePasswordB_Click(object sender, EventArgs e)
		{
			if (LoginTB.Text.Length == 0)
			{
				MessageBox.Show("Введите логин!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			GeneratorForm.ShowGeneratePasswordDialog(LoginTB.Text);
		}

		private void SubmitB_Click(object sender, EventArgs e)
		{
			if (LoginTB.Text.Length == 0 || GeneratedPTB.Password.Length == 0)
			{
				MessageBox.Show("Введите логин и сгенерируйте пароль!", "Заполните форму", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (GeneratedPTB.Password != ConfirmedPTB.Password)
			{
				ConfirmedPTB.Password = "";
				MessageBox.Show("Пароли не совпадают!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			UserRegistration?.Invoke(LoginTB.Text, GeneratedPTB.Password);
		}

		private void LoginTB_TextChanged(object sender, EventArgs e)
		{
			GeneratedPTB.Password = "";
		}
	}
}
