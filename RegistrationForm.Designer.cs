﻿namespace InformationSystem_Lab_2
{
	partial class RegistrationForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.LoginTB = new System.Windows.Forms.TextBox();
			this.GeneratedPTB = new InformationSystem_Lab_2.PasswordTextBox();
			this.ConfirmedPTB = new InformationSystem_Lab_2.PasswordTextBox();
			this.GeneratePasswordB = new System.Windows.Forms.Button();
			this.SubmitB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.LoginTB, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.GeneratedPTB, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.ConfirmedPTB, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.GeneratePasswordB, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.SubmitB, 1, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 403);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(133, 32);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Введите логин";
			// 
			// LoginTB
			// 
			this.LoginTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.LoginTB.Location = new System.Drawing.Point(37, 70);
			this.LoginTB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.LoginTB.Name = "LoginTB";
			this.LoginTB.Size = new System.Drawing.Size(358, 34);
			this.LoginTB.TabIndex = 1;
			this.LoginTB.TextChanged += new System.EventHandler(this.LoginTB_TextChanged);
			// 
			// GeneratedPTB
			// 
			this.GeneratedPTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GeneratedPTB.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GeneratedPTB.Location = new System.Drawing.Point(38, 179);
			this.GeneratedPTB.Margin = new System.Windows.Forms.Padding(5);
			this.GeneratedPTB.Name = "GeneratedPTB";
			this.GeneratedPTB.Password = "";
			this.GeneratedPTB.ReadOnly = false;
			this.GeneratedPTB.Size = new System.Drawing.Size(356, 48);
			this.GeneratedPTB.TabIndex = 0;
			this.GeneratedPTB.TabStop = false;
			// 
			// ConfirmedPTB
			// 
			this.ConfirmedPTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfirmedPTB.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ConfirmedPTB.Location = new System.Drawing.Point(38, 237);
			this.ConfirmedPTB.Margin = new System.Windows.Forms.Padding(5);
			this.ConfirmedPTB.Name = "ConfirmedPTB";
			this.ConfirmedPTB.Password = "";
			this.ConfirmedPTB.ReadOnly = false;
			this.ConfirmedPTB.Size = new System.Drawing.Size(356, 48);
			this.ConfirmedPTB.TabIndex = 3;
			// 
			// GeneratePasswordB
			// 
			this.GeneratePasswordB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.GeneratePasswordB.AutoSize = true;
			this.GeneratePasswordB.Location = new System.Drawing.Point(61, 125);
			this.GeneratePasswordB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.GeneratePasswordB.Name = "GeneratePasswordB";
			this.GeneratePasswordB.Size = new System.Drawing.Size(310, 40);
			this.GeneratePasswordB.TabIndex = 2;
			this.GeneratePasswordB.Text = "Сгенерировать пароль";
			this.GeneratePasswordB.UseVisualStyleBackColor = true;
			this.GeneratePasswordB.Click += new System.EventHandler(this.GeneratePasswordB_Click);
			// 
			// SubmitB
			// 
			this.SubmitB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SubmitB.AutoSize = true;
			this.SubmitB.Location = new System.Drawing.Point(61, 326);
			this.SubmitB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SubmitB.Name = "SubmitB";
			this.SubmitB.Size = new System.Drawing.Size(310, 40);
			this.SubmitB.TabIndex = 4;
			this.SubmitB.Text = "Подтвердить регистрацию";
			this.SubmitB.UseVisualStyleBackColor = true;
			this.SubmitB.Click += new System.EventHandler(this.SubmitB_Click);
			// 
			// RegistrationForm
			// 
			this.AcceptButton = this.SubmitB;
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 403);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "RegistrationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Регистрация";
			this.VisibleChanged += new System.EventHandler(this.RegistrationForm_VisibleChanged);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox LoginTB;
		private PasswordTextBox GeneratedPTB;
		private PasswordTextBox ConfirmedPTB;
		private System.Windows.Forms.Button GeneratePasswordB;
		private System.Windows.Forms.Button SubmitB;
	}
}

