namespace InformationSystem_Lab_2
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.AuthB = new System.Windows.Forms.Button();
			this.ReAuthB = new System.Windows.Forms.Button();
			this.MainRTB = new System.Windows.Forms.RichTextBox();
			this.DeAuthB = new System.Windows.Forms.Button();
			this.UserGB = new System.Windows.Forms.GroupBox();
			this.LoginL = new System.Windows.Forms.Label();
			this.UsersGB = new System.Windows.Forms.GroupBox();
			this.UsersConfigB = new System.Windows.Forms.Button();
			this.BlockB = new System.Windows.Forms.Button();
			this.RegisterB = new System.Windows.Forms.Button();
			this.UnblockB = new System.Windows.Forms.Button();
			this.JournalGB = new System.Windows.Forms.GroupBox();
			this.JournalConfigB = new System.Windows.Forms.Button();
			this.ArchiveB = new System.Windows.Forms.Button();
			this.SearchB = new System.Windows.Forms.Button();
			this.DearchiveB = new System.Windows.Forms.Button();
			this.AfkTimer = new System.Windows.Forms.Timer(this.components);
			this.UserGB.SuspendLayout();
			this.UsersGB.SuspendLayout();
			this.JournalGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// AuthB
			// 
			this.AuthB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AuthB.Location = new System.Drawing.Point(10, 70);
			this.AuthB.Margin = new System.Windows.Forms.Padding(5);
			this.AuthB.Name = "AuthB";
			this.AuthB.Size = new System.Drawing.Size(200, 40);
			this.AuthB.TabIndex = 0;
			this.AuthB.Text = "Авторизоваться";
			this.AuthB.UseVisualStyleBackColor = true;
			this.AuthB.Click += new System.EventHandler(this.AuthB_Click);
			// 
			// ReAuthB
			// 
			this.ReAuthB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ReAuthB.Location = new System.Drawing.Point(10, 110);
			this.ReAuthB.Margin = new System.Windows.Forms.Padding(5);
			this.ReAuthB.Name = "ReAuthB";
			this.ReAuthB.Size = new System.Drawing.Size(200, 40);
			this.ReAuthB.TabIndex = 1;
			this.ReAuthB.Text = "Сменить Аккаунт";
			this.ReAuthB.UseVisualStyleBackColor = true;
			this.ReAuthB.Click += new System.EventHandler(this.ReAuthB_Click);
			// 
			// MainRTB
			// 
			this.MainRTB.Location = new System.Drawing.Point(240, 25);
			this.MainRTB.Margin = new System.Windows.Forms.Padding(5);
			this.MainRTB.Name = "MainRTB";
			this.MainRTB.Size = new System.Drawing.Size(915, 600);
			this.MainRTB.TabIndex = 2;
			this.MainRTB.Text = "";
			// 
			// DeAuthB
			// 
			this.DeAuthB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DeAuthB.Location = new System.Drawing.Point(10, 150);
			this.DeAuthB.Margin = new System.Windows.Forms.Padding(5);
			this.DeAuthB.Name = "DeAuthB";
			this.DeAuthB.Size = new System.Drawing.Size(200, 40);
			this.DeAuthB.TabIndex = 3;
			this.DeAuthB.Text = "Выйти";
			this.DeAuthB.UseVisualStyleBackColor = true;
			this.DeAuthB.Click += new System.EventHandler(this.DeAuthB_Click);
			// 
			// UserGB
			// 
			this.UserGB.Controls.Add(this.AuthB);
			this.UserGB.Controls.Add(this.DeAuthB);
			this.UserGB.Controls.Add(this.ReAuthB);
			this.UserGB.Controls.Add(this.LoginL);
			this.UserGB.Location = new System.Drawing.Point(12, 12);
			this.UserGB.Name = "UserGB";
			this.UserGB.Size = new System.Drawing.Size(220, 200);
			this.UserGB.TabIndex = 5;
			this.UserGB.TabStop = false;
			this.UserGB.Text = "Пользователь";
			// 
			// LoginL
			// 
			this.LoginL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.LoginL.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginL.Location = new System.Drawing.Point(9, 35);
			this.LoginL.Name = "LoginL";
			this.LoginL.Size = new System.Drawing.Size(202, 30);
			this.LoginL.TabIndex = 0;
			this.LoginL.Text = "LoginL";
			this.LoginL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UsersGB
			// 
			this.UsersGB.Controls.Add(this.UsersConfigB);
			this.UsersGB.Controls.Add(this.BlockB);
			this.UsersGB.Controls.Add(this.RegisterB);
			this.UsersGB.Controls.Add(this.UnblockB);
			this.UsersGB.Location = new System.Drawing.Point(12, 220);
			this.UsersGB.Name = "UsersGB";
			this.UsersGB.Size = new System.Drawing.Size(220, 200);
			this.UsersGB.TabIndex = 6;
			this.UsersGB.TabStop = false;
			this.UsersGB.Text = "Пользователи";
			// 
			// UsersConfigB
			// 
			this.UsersConfigB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UsersConfigB.Location = new System.Drawing.Point(10, 150);
			this.UsersConfigB.Margin = new System.Windows.Forms.Padding(5);
			this.UsersConfigB.Name = "UsersConfigB";
			this.UsersConfigB.Size = new System.Drawing.Size(200, 40);
			this.UsersConfigB.TabIndex = 4;
			this.UsersConfigB.Text = "Конфигурировать";
			this.UsersConfigB.UseVisualStyleBackColor = true;
			this.UsersConfigB.Click += new System.EventHandler(this.UsersConfigB_Click);
			// 
			// BlockB
			// 
			this.BlockB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BlockB.Location = new System.Drawing.Point(10, 70);
			this.BlockB.Margin = new System.Windows.Forms.Padding(5);
			this.BlockB.Name = "BlockB";
			this.BlockB.Size = new System.Drawing.Size(200, 40);
			this.BlockB.TabIndex = 0;
			this.BlockB.Text = "Заблокировать";
			this.BlockB.UseVisualStyleBackColor = true;
			this.BlockB.Click += new System.EventHandler(this.BlockB_Click);
			// 
			// RegisterB
			// 
			this.RegisterB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RegisterB.Location = new System.Drawing.Point(10, 30);
			this.RegisterB.Margin = new System.Windows.Forms.Padding(5);
			this.RegisterB.Name = "RegisterB";
			this.RegisterB.Size = new System.Drawing.Size(200, 40);
			this.RegisterB.TabIndex = 3;
			this.RegisterB.Text = "Зарегистрировать";
			this.RegisterB.UseVisualStyleBackColor = true;
			this.RegisterB.Click += new System.EventHandler(this.RegisterB_Click);
			// 
			// UnblockB
			// 
			this.UnblockB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UnblockB.Location = new System.Drawing.Point(10, 110);
			this.UnblockB.Margin = new System.Windows.Forms.Padding(5);
			this.UnblockB.Name = "UnblockB";
			this.UnblockB.Size = new System.Drawing.Size(200, 40);
			this.UnblockB.TabIndex = 1;
			this.UnblockB.Text = "Разблокировать";
			this.UnblockB.UseVisualStyleBackColor = true;
			this.UnblockB.Click += new System.EventHandler(this.UnblockB_Click);
			// 
			// JournalGB
			// 
			this.JournalGB.Controls.Add(this.JournalConfigB);
			this.JournalGB.Controls.Add(this.ArchiveB);
			this.JournalGB.Controls.Add(this.SearchB);
			this.JournalGB.Controls.Add(this.DearchiveB);
			this.JournalGB.Location = new System.Drawing.Point(12, 425);
			this.JournalGB.Name = "JournalGB";
			this.JournalGB.Size = new System.Drawing.Size(220, 200);
			this.JournalGB.TabIndex = 7;
			this.JournalGB.TabStop = false;
			this.JournalGB.Text = "Журнал";
			// 
			// JournalConfigB
			// 
			this.JournalConfigB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.JournalConfigB.Location = new System.Drawing.Point(10, 150);
			this.JournalConfigB.Margin = new System.Windows.Forms.Padding(5);
			this.JournalConfigB.Name = "JournalConfigB";
			this.JournalConfigB.Size = new System.Drawing.Size(200, 40);
			this.JournalConfigB.TabIndex = 4;
			this.JournalConfigB.Text = "Конфигурировать";
			this.JournalConfigB.UseVisualStyleBackColor = true;
			// 
			// ArchiveB
			// 
			this.ArchiveB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ArchiveB.Location = new System.Drawing.Point(10, 70);
			this.ArchiveB.Margin = new System.Windows.Forms.Padding(5);
			this.ArchiveB.Name = "ArchiveB";
			this.ArchiveB.Size = new System.Drawing.Size(200, 40);
			this.ArchiveB.TabIndex = 0;
			this.ArchiveB.Text = "Разархивировать";
			this.ArchiveB.UseVisualStyleBackColor = true;
			// 
			// SearchB
			// 
			this.SearchB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchB.Location = new System.Drawing.Point(10, 30);
			this.SearchB.Margin = new System.Windows.Forms.Padding(5);
			this.SearchB.Name = "SearchB";
			this.SearchB.Size = new System.Drawing.Size(200, 40);
			this.SearchB.TabIndex = 3;
			this.SearchB.Text = "Поиск";
			this.SearchB.UseVisualStyleBackColor = true;
			// 
			// DearchiveB
			// 
			this.DearchiveB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DearchiveB.Location = new System.Drawing.Point(10, 110);
			this.DearchiveB.Margin = new System.Windows.Forms.Padding(5);
			this.DearchiveB.Name = "DearchiveB";
			this.DearchiveB.Size = new System.Drawing.Size(200, 40);
			this.DearchiveB.TabIndex = 1;
			this.DearchiveB.Text = "Архивировать";
			this.DearchiveB.UseVisualStyleBackColor = true;
			// 
			// AfkTimer
			// 
			this.AfkTimer.Interval = 1000;
			this.AfkTimer.Tick += new System.EventHandler(this.AfkTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1172, 648);
			this.Controls.Add(this.JournalGB);
			this.Controls.Add(this.UsersGB);
			this.Controls.Add(this.UserGB);
			this.Controls.Add(this.MainRTB);
			this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Информационная система";
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.UserGB.ResumeLayout(false);
			this.UsersGB.ResumeLayout(false);
			this.JournalGB.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button AuthB;
		private System.Windows.Forms.Button ReAuthB;
		private System.Windows.Forms.RichTextBox MainRTB;
		private System.Windows.Forms.Button DeAuthB;
		private System.Windows.Forms.GroupBox UserGB;
		private System.Windows.Forms.Label LoginL;
		private System.Windows.Forms.GroupBox UsersGB;
		private System.Windows.Forms.Button BlockB;
		private System.Windows.Forms.Button RegisterB;
		private System.Windows.Forms.Button UnblockB;
		private System.Windows.Forms.Button UsersConfigB;
		private System.Windows.Forms.GroupBox JournalGB;
		private System.Windows.Forms.Button JournalConfigB;
		private System.Windows.Forms.Button ArchiveB;
		private System.Windows.Forms.Button SearchB;
		private System.Windows.Forms.Button DearchiveB;
		private System.Windows.Forms.Timer AfkTimer;
	}
}