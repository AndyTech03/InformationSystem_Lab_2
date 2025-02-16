namespace InformationSystem_Lab_2
{
	partial class LoginForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.LoginTB = new System.Windows.Forms.TextBox();
			this.PasswordPTB = new InformationSystem_Lab_2.PasswordTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SubmitB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.LoginTB, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.PasswordPTB, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.SubmitB, 1, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 303);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(139, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Введите логин";
			// 
			// LoginTB
			// 
			this.LoginTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.LoginTB.Location = new System.Drawing.Point(31, 73);
			this.LoginTB.Name = "LoginTB";
			this.LoginTB.Size = new System.Drawing.Size(370, 34);
			this.LoginTB.TabIndex = 1;
			// 
			// PasswordPTB
			// 
			this.PasswordPTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PasswordPTB.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PasswordPTB.Location = new System.Drawing.Point(32, 185);
			this.PasswordPTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.PasswordPTB.Name = "PasswordPTB";
			this.PasswordPTB.Password = "";
			this.PasswordPTB.ReadOnly = false;
			this.PasswordPTB.Size = new System.Drawing.Size(368, 50);
			this.PasswordPTB.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(134, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 26);
			this.label2.TabIndex = 5;
			this.label2.Text = "Введите пароль";
			// 
			// SubmitB
			// 
			this.SubmitB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SubmitB.AutoSize = true;
			this.SubmitB.Location = new System.Drawing.Point(166, 251);
			this.SubmitB.Name = "SubmitB";
			this.SubmitB.Size = new System.Drawing.Size(100, 40);
			this.SubmitB.TabIndex = 3;
			this.SubmitB.Text = "Войти";
			this.SubmitB.UseVisualStyleBackColor = true;
			this.SubmitB.Click += new System.EventHandler(this.SubmitB_Click);
			// 
			// LoginForm
			// 
			this.AcceptButton = this.SubmitB;
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 303);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Вход";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox LoginTB;
		private PasswordTextBox PasswordPTB;
		private System.Windows.Forms.Button SubmitB;
		private System.Windows.Forms.Label label2;
	}
}