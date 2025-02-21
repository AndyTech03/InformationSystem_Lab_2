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
	public partial class RegistrationForm : Form, IDialogForm
	{
		public event Action<Guid, string, string> SuccessfulRegistration;
		public event Action UserAction;

		private readonly FileDataSet DataSet;
		private readonly PasswordGeneratorForm PasswordGeneratorDialog;
		private Guid adminUuid;

		public RegistrationForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			adminUuid = Guid.Empty;
			PasswordGeneratorDialog = new PasswordGeneratorForm();
			PasswordGeneratorDialog.GeneratedPasswordAccepted += GeneratorForm_GeneratedPasswordAccepted;
			GeneratedPTB.ReadOnly = true;
			DataSet = fileDataSet;

			PasswordGeneratorDialog.UserAction += () => UserAction?.Invoke();
			MouseMove += (object _, MouseEventArgs __) => UserAction?.Invoke();
			Click += (object _, EventArgs __) => UserAction?.Invoke();
			foreach (Control control in Controls)
				control.Click += (object _, EventArgs __) => UserAction?.Invoke();
			KeyDown += (object _, KeyEventArgs __) => UserAction?.Invoke();
			KeyPreview = true;
		}

		public DialogResult BeginRegistration(Guid uuid)
		{
			if (DataSet.IsAdmin(uuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return DialogResult.Ignore;
			}
			adminUuid = uuid;
			return ShowDialog();
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
			PasswordGeneratorDialog.ShowGeneratePasswordDialog(login);
		}

		private void SubmitB_Click(object sender, EventArgs e)
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return;
			}

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

			Guid uuid = DataSet.TryRegister(login, password, adminUuid, out bool result, out bool denied);
			if (denied)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return;
			}
			if (result == false)
			{
				MessageBox.Show("Логин не подходит, укажите другой!", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (uuid == Guid.Empty)
			{
				MessageBox.Show("Что то пошло не так...", "Попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			SuccessfulRegistration?.Invoke(uuid, login, password);
			DialogResult = DialogResult.OK;
		}

		private void LoginTB_TextChanged(object sender, EventArgs e)
		{
			GeneratedPTB.Password = "";
		}

		private void RegistrationForm_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == false)
			{
				adminUuid = Guid.Empty;
				PasswordGeneratorDialog.DialogResult = DialogResult.Ignore;
				PasswordGeneratorDialog.Hide();
			}
		}
	}
}
