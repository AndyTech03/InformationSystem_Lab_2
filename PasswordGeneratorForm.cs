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
	public partial class PasswordGeneratorForm : Form, IDialogForm
	{
		public event Action<string> GeneratedPasswordAccepted;
		public event Action UserAction;

		private int _loginLenght;
		private Random _random;
		public PasswordGeneratorForm()
		{
			InitializeComponent();
			_random = new Random();

			MouseMove += (object _, MouseEventArgs __) => UserAction?.Invoke();
			Click += (object _, EventArgs __) => UserAction?.Invoke();
			foreach (Control control in Controls)
				control.Click += (object _, EventArgs __) => UserAction?.Invoke();
			PasswordsLB.Click += (object _, EventArgs __) => UserAction?.Invoke();
			KeyDown += (object _, KeyEventArgs __) => UserAction?.Invoke();
			KeyPreview = true;
		}

		public DialogResult ShowGeneratePasswordDialog(string login)
		{
			_loginLenght = login.Length;
			generatePasswords();
			return ShowDialog();
		}

		private void PasswordsLB_DrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox list = (ListBox)sender;
			if (e.Index > -1)
			{
				object item = list.Items[e.Index];
				e.DrawBackground();
				e.DrawFocusRectangle();
				Brush brush = new SolidBrush(e.ForeColor);
				SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
				e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
			}
		}

		private void AcceptB_Click(object sender, EventArgs e)
		{
			string password = PasswordsLB.SelectedItem.ToString();
			GeneratedPasswordAccepted?.Invoke(password);
		}

		private void RetryB_Click(object sender, EventArgs e)
		{
			generatePasswords();
		}

		private void PasswordsLB_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox list = (ListBox)sender;
			if (list.SelectedIndex == -1)
			{
				AcceptB.Enabled = false;
				return;
			}
			AcceptB.Enabled = true;
		}

		private void generatePasswords()
		{
			PasswordsLB.Items.Clear();
			PasswordsLB.ClearSelected();
			AcceptB.Enabled = false;
			int qlenght = _loginLenght % 8;
			for (int i = 0; i < 10; i++)
				PasswordsLB.Items.Add(generatePassword(qlenght));
		}

		private string generatePassword(int qLenght)
		{
			const int lenght= 11;
			int counter = 0;
			string password = "";

			for (int i = 0; i < 2; i++, counter++)
				password += generateNumber();

			for (int i = 0; i < qLenght; i++, counter++)
				password += generateLetter();

			for (int i = 0; counter < lenght; i++, counter++)
				password += generateSymbol();

			return password;
		}

		private string generateNumber()
		{
			return _random.Next(10).ToString();
		}

		private string generateLetter()
		{
			char letter = (char)_random.Next('а', 'я' + 1);
			return letter.ToString();
		}

		private string generateSymbol()
		{
			char symbol = (char)_random.Next('!', '*' + 1);
			return symbol.ToString();
		}
	}
}
