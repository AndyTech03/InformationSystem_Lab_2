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
		private RegistrationForm _registrationForm;
		private LoginForm _loginForm;
		public MainForm()
		{
			InitializeComponent();
			_registrationForm = new RegistrationForm();
			_loginForm = new LoginForm();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			_registrationForm.ShowDialog();
			_loginForm.ShowDialog();
		}
	}
}
