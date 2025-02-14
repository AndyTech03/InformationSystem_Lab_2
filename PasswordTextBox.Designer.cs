namespace InformationSystem_Lab_2
{
	partial class PasswordTextBox
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.PasswordTB = new System.Windows.Forms.TextBox();
			this.VisibilityB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PasswordTB
			// 
			this.PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.PasswordTB.Location = new System.Drawing.Point(4, 33);
			this.PasswordTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.PasswordTB.Name = "PasswordTB";
			this.PasswordTB.Size = new System.Drawing.Size(442, 34);
			this.PasswordTB.TabIndex = 0;
			this.PasswordTB.UseSystemPasswordChar = true;
			// 
			// VisibilityB
			// 
			this.VisibilityB.BackgroundImage = global::InformationSystem_Lab_2.Properties.Resources.hidden;
			this.VisibilityB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.VisibilityB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VisibilityB.Location = new System.Drawing.Point(453, 28);
			this.VisibilityB.Name = "VisibilityB";
			this.VisibilityB.Size = new System.Drawing.Size(44, 44);
			this.VisibilityB.TabIndex = 1;
			this.VisibilityB.UseVisualStyleBackColor = true;
			this.VisibilityB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VisibilityB_MouseDown);
			this.VisibilityB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VisibilityB_MouseUp);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Controls.Add(this.VisibilityB, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.PasswordTB, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 100);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// PasswordTextBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "PasswordTextBox";
			this.Size = new System.Drawing.Size(500, 100);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox PasswordTB;
		private System.Windows.Forms.Button VisibilityB;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
