using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public partial class PasswordTextBox : UserControl
	{
		private bool PasswordVisibility
		{
			set
			{
				PasswordTB.UseSystemPasswordChar = !value;
				VisibilityB.BackgroundImage = value ? Properties.Resources.shown : Properties.Resources.hidden;
			}
			get
			{
				return !PasswordTB.UseSystemPasswordChar;
			}
		}

		public string Password
		{
			set
			{
				//PasswordVisibility = false;
				PasswordTB.Text = value;
			}
			get
			{
				return PasswordTB.Text;
			}
		}

		public bool ReadOnly
		{
			set
			{
				PasswordTB.ReadOnly = value;
			}
			get
			{
				return PasswordTB.ReadOnly;
			}
		}

		public PasswordTextBox()
		{
			InitializeComponent();
			PasswordVisibility = true;
		}

		private void VisibilityB_MouseDown(object sender, MouseEventArgs e)
		{
			PasswordVisibility = true;
		}

		private void VisibilityB_MouseUp(object sender, MouseEventArgs e)
		{
			PasswordVisibility = false;
		}

		private void VisibilityB_MouseEnter(object sender, EventArgs e)
		{
			PasswordVisibility = true;
		}

		private void VisibilityB_MouseLeave(object sender, EventArgs e)
		{
			PasswordVisibility = false;
		}
	}
}
