namespace InformationSystem_Lab_2
{
	partial class PasswordGeneratorForm
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
			this.PasswordsLB = new System.Windows.Forms.ListBox();
			this.RetryB = new System.Windows.Forms.Button();
			this.AcceptB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.PasswordsLB, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.RetryB, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.AcceptB, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.41218F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.58782F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 464);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
			this.label1.Location = new System.Drawing.Point(181, 21);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(382, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выберите один из предложенных паролей";
			// 
			// PasswordsLB
			// 
			this.PasswordsLB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel1.SetColumnSpan(this.PasswordsLB, 2);
			this.PasswordsLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.PasswordsLB.FormattingEnabled = true;
			this.PasswordsLB.ItemHeight = 27;
			this.PasswordsLB.Items.AddRange(new object[] {
            "WWWWWWWWWWW",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.PasswordsLB.Location = new System.Drawing.Point(222, 83);
			this.PasswordsLB.Name = "PasswordsLB";
			this.PasswordsLB.Size = new System.Drawing.Size(300, 274);
			this.PasswordsLB.TabIndex = 1;
			this.PasswordsLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PasswordsLB_DrawItem);
			this.PasswordsLB.SelectedIndexChanged += new System.EventHandler(this.PasswordsLB_SelectedIndexChanged);
			// 
			// RetryB
			// 
			this.RetryB.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.RetryB.Location = new System.Drawing.Point(125, 396);
			this.RetryB.Name = "RetryB";
			this.RetryB.Size = new System.Drawing.Size(150, 50);
			this.RetryB.TabIndex = 2;
			this.RetryB.Text = "Повторить";
			this.RetryB.UseVisualStyleBackColor = true;
			this.RetryB.Click += new System.EventHandler(this.RetryB_Click);
			// 
			// AcceptB
			// 
			this.AcceptB.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.AcceptB.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.AcceptB.Enabled = false;
			this.AcceptB.Location = new System.Drawing.Point(469, 396);
			this.AcceptB.Name = "AcceptB";
			this.AcceptB.Size = new System.Drawing.Size(150, 50);
			this.AcceptB.TabIndex = 3;
			this.AcceptB.Text = "Применить";
			this.AcceptB.UseVisualStyleBackColor = true;
			this.AcceptB.Click += new System.EventHandler(this.AcceptB_Click);
			// 
			// PasswordGeneratorForm
			// 
			this.AcceptButton = this.AcceptB;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 464);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "PasswordGeneratorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Генератор паролей";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox PasswordsLB;
		private System.Windows.Forms.Button RetryB;
		private System.Windows.Forms.Button AcceptB;
	}
}