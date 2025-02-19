namespace InformationSystem_Lab_2
{
	partial class BlockForm
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
			this.BlockOneB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.UnBlockAllB = new System.Windows.Forms.Button();
			this.UnBlockOneB = new System.Windows.Forms.Button();
			this.BlockAllB = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BlockedUsersDS = new System.Data.DataSet();
			this.NotBlockedUsers = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.BlockedUsers = new System.Data.DataTable();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.dataColumn7 = new System.Data.DataColumn();
			this.dataColumn9 = new System.Data.DataColumn();
			this.NotBlockedDGV = new System.Windows.Forms.DataGridView();
			this.uuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isAdminDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.BlockedDGV = new System.Windows.Forms.DataGridView();
			this.uuidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.loginDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isAdminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.blockedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BlockedUsersDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NotBlockedUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockedUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NotBlockedDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockedDGV)).BeginInit();
			this.SuspendLayout();
			// 
			// BlockOneB
			// 
			this.BlockOneB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.BlockOneB.Location = new System.Drawing.Point(10, 7);
			this.BlockOneB.Name = "BlockOneB";
			this.BlockOneB.Size = new System.Drawing.Size(100, 40);
			this.BlockOneB.TabIndex = 2;
			this.BlockOneB.Text = "==>";
			this.BlockOneB.UseVisualStyleBackColor = true;
			this.BlockOneB.Click += new System.EventHandler(this.BlockOneB_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.UnBlockAllB, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.UnBlockOneB, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.BlockAllB, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.BlockOneB, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(452, 250);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 223);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// UnBlockAllB
			// 
			this.UnBlockAllB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.UnBlockAllB.Location = new System.Drawing.Point(10, 174);
			this.UnBlockAllB.Name = "UnBlockAllB";
			this.UnBlockAllB.Size = new System.Drawing.Size(100, 40);
			this.UnBlockAllB.TabIndex = 5;
			this.UnBlockAllB.Text = "<<=";
			this.UnBlockAllB.UseVisualStyleBackColor = true;
			this.UnBlockAllB.Click += new System.EventHandler(this.UnBlockAllB_Click);
			// 
			// UnBlockOneB
			// 
			this.UnBlockOneB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.UnBlockOneB.Location = new System.Drawing.Point(10, 117);
			this.UnBlockOneB.Name = "UnBlockOneB";
			this.UnBlockOneB.Size = new System.Drawing.Size(100, 40);
			this.UnBlockOneB.TabIndex = 4;
			this.UnBlockOneB.Text = "<==";
			this.UnBlockOneB.UseVisualStyleBackColor = true;
			this.UnBlockOneB.Click += new System.EventHandler(this.UnBlockOneB_Click);
			// 
			// BlockAllB
			// 
			this.BlockAllB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.BlockAllB.Location = new System.Drawing.Point(10, 62);
			this.BlockAllB.Name = "BlockAllB";
			this.BlockAllB.Size = new System.Drawing.Size(100, 40);
			this.BlockAllB.TabIndex = 3;
			this.BlockAllB.Text = "=>>";
			this.BlockAllB.UseVisualStyleBackColor = true;
			this.BlockAllB.Click += new System.EventHandler(this.BlockAllB_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(389, 26);
			this.label1.TabIndex = 4;
			this.label1.Text = "Не заблокированные пользователи";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(730, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(356, 26);
			this.label2.TabIndex = 5;
			this.label2.Text = "Заблокированные пользователи";
			// 
			// BlockedUsersDS
			// 
			this.BlockedUsersDS.DataSetName = "NewDataSet";
			this.BlockedUsersDS.Tables.AddRange(new System.Data.DataTable[] {
            this.NotBlockedUsers,
            this.BlockedUsers});
			// 
			// NotBlockedUsers
			// 
			this.NotBlockedUsers.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
			this.NotBlockedUsers.TableName = "NotBlockedUsers";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "Uuid";
			this.dataColumn1.ColumnName = "uuid";
			this.dataColumn1.DataType = typeof(System.Guid);
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "Login";
			this.dataColumn2.ColumnName = "login";
			// 
			// dataColumn3
			// 
			this.dataColumn3.Caption = "IsAdmin";
			this.dataColumn3.ColumnName = "isAdmin";
			this.dataColumn3.DataType = typeof(bool);
			// 
			// BlockedUsers
			// 
			this.BlockedUsers.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn9});
			this.BlockedUsers.TableName = "BlockedUsers";
			// 
			// dataColumn4
			// 
			this.dataColumn4.Caption = "Uuid";
			this.dataColumn4.ColumnName = "uuid";
			this.dataColumn4.DataType = typeof(System.Guid);
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "login";
			// 
			// dataColumn6
			// 
			this.dataColumn6.Caption = "IsAdmin";
			this.dataColumn6.ColumnName = "isAdmin";
			this.dataColumn6.DataType = typeof(bool);
			// 
			// dataColumn7
			// 
			this.dataColumn7.ColumnName = "blockedAt";
			this.dataColumn7.DataType = typeof(System.DateTime);
			// 
			// dataColumn9
			// 
			this.dataColumn9.Caption = "Reason";
			this.dataColumn9.ColumnName = "reason";
			// 
			// NotBlockedDGV
			// 
			this.NotBlockedDGV.AllowUserToAddRows = false;
			this.NotBlockedDGV.AllowUserToDeleteRows = false;
			this.NotBlockedDGV.AutoGenerateColumns = false;
			this.NotBlockedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.NotBlockedDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uuidDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.isAdminDataGridViewCheckBoxColumn1});
			this.NotBlockedDGV.DataMember = "NotBlockedUsers";
			this.NotBlockedDGV.DataSource = this.BlockedUsersDS;
			this.NotBlockedDGV.Location = new System.Drawing.Point(17, 64);
			this.NotBlockedDGV.Name = "NotBlockedDGV";
			this.NotBlockedDGV.ReadOnly = true;
			this.NotBlockedDGV.RowHeadersWidth = 51;
			this.NotBlockedDGV.RowTemplate.Height = 24;
			this.NotBlockedDGV.Size = new System.Drawing.Size(429, 597);
			this.NotBlockedDGV.TabIndex = 8;
			// 
			// uuidDataGridViewTextBoxColumn
			// 
			this.uuidDataGridViewTextBoxColumn.DataPropertyName = "uuid";
			this.uuidDataGridViewTextBoxColumn.HeaderText = "uuid";
			this.uuidDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.uuidDataGridViewTextBoxColumn.Name = "uuidDataGridViewTextBoxColumn";
			this.uuidDataGridViewTextBoxColumn.ReadOnly = true;
			this.uuidDataGridViewTextBoxColumn.Width = 125;
			// 
			// loginDataGridViewTextBoxColumn
			// 
			this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
			this.loginDataGridViewTextBoxColumn.HeaderText = "login";
			this.loginDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
			this.loginDataGridViewTextBoxColumn.ReadOnly = true;
			this.loginDataGridViewTextBoxColumn.Width = 125;
			// 
			// isAdminDataGridViewCheckBoxColumn1
			// 
			this.isAdminDataGridViewCheckBoxColumn1.DataPropertyName = "isAdmin";
			this.isAdminDataGridViewCheckBoxColumn1.HeaderText = "isAdmin";
			this.isAdminDataGridViewCheckBoxColumn1.MinimumWidth = 6;
			this.isAdminDataGridViewCheckBoxColumn1.Name = "isAdminDataGridViewCheckBoxColumn1";
			this.isAdminDataGridViewCheckBoxColumn1.ReadOnly = true;
			this.isAdminDataGridViewCheckBoxColumn1.Width = 125;
			// 
			// BlockedDGV
			// 
			this.BlockedDGV.AllowUserToAddRows = false;
			this.BlockedDGV.AllowUserToDeleteRows = false;
			this.BlockedDGV.AutoGenerateColumns = false;
			this.BlockedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BlockedDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uuidDataGridViewTextBoxColumn1,
            this.loginDataGridViewTextBoxColumn1,
            this.isAdminDataGridViewCheckBoxColumn,
            this.blockedAtDataGridViewTextBoxColumn,
            this.reasonDataGridViewTextBoxColumn});
			this.BlockedDGV.DataMember = "BlockedUsers";
			this.BlockedDGV.DataSource = this.BlockedUsersDS;
			this.BlockedDGV.Location = new System.Drawing.Point(578, 64);
			this.BlockedDGV.Name = "BlockedDGV";
			this.BlockedDGV.ReadOnly = true;
			this.BlockedDGV.RowHeadersWidth = 51;
			this.BlockedDGV.RowTemplate.Height = 24;
			this.BlockedDGV.Size = new System.Drawing.Size(672, 597);
			this.BlockedDGV.TabIndex = 9;
			this.BlockedDGV.Click += new System.EventHandler(this.BlockedDGV_Click);
			// 
			// uuidDataGridViewTextBoxColumn1
			// 
			this.uuidDataGridViewTextBoxColumn1.DataPropertyName = "uuid";
			this.uuidDataGridViewTextBoxColumn1.HeaderText = "uuid";
			this.uuidDataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.uuidDataGridViewTextBoxColumn1.Name = "uuidDataGridViewTextBoxColumn1";
			this.uuidDataGridViewTextBoxColumn1.ReadOnly = true;
			this.uuidDataGridViewTextBoxColumn1.Width = 125;
			// 
			// loginDataGridViewTextBoxColumn1
			// 
			this.loginDataGridViewTextBoxColumn1.DataPropertyName = "login";
			this.loginDataGridViewTextBoxColumn1.HeaderText = "login";
			this.loginDataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.loginDataGridViewTextBoxColumn1.Name = "loginDataGridViewTextBoxColumn1";
			this.loginDataGridViewTextBoxColumn1.ReadOnly = true;
			this.loginDataGridViewTextBoxColumn1.Width = 125;
			// 
			// isAdminDataGridViewCheckBoxColumn
			// 
			this.isAdminDataGridViewCheckBoxColumn.DataPropertyName = "isAdmin";
			this.isAdminDataGridViewCheckBoxColumn.HeaderText = "isAdmin";
			this.isAdminDataGridViewCheckBoxColumn.MinimumWidth = 6;
			this.isAdminDataGridViewCheckBoxColumn.Name = "isAdminDataGridViewCheckBoxColumn";
			this.isAdminDataGridViewCheckBoxColumn.ReadOnly = true;
			this.isAdminDataGridViewCheckBoxColumn.Width = 125;
			// 
			// blockedAtDataGridViewTextBoxColumn
			// 
			this.blockedAtDataGridViewTextBoxColumn.DataPropertyName = "blockedAt";
			this.blockedAtDataGridViewTextBoxColumn.HeaderText = "blockedAt";
			this.blockedAtDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.blockedAtDataGridViewTextBoxColumn.Name = "blockedAtDataGridViewTextBoxColumn";
			this.blockedAtDataGridViewTextBoxColumn.ReadOnly = true;
			this.blockedAtDataGridViewTextBoxColumn.Width = 125;
			// 
			// reasonDataGridViewTextBoxColumn
			// 
			this.reasonDataGridViewTextBoxColumn.DataPropertyName = "reason";
			this.reasonDataGridViewTextBoxColumn.HeaderText = "reason";
			this.reasonDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.reasonDataGridViewTextBoxColumn.Name = "reasonDataGridViewTextBoxColumn";
			this.reasonDataGridViewTextBoxColumn.ReadOnly = true;
			this.reasonDataGridViewTextBoxColumn.Width = 125;
			// 
			// BlockForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.BlockedDGV);
			this.Controls.Add(this.NotBlockedDGV);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "BlockForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Управление пользователями";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlockForm_FormClosing);
			this.Shown += new System.EventHandler(this.BlockForm_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BlockedUsersDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NotBlockedUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockedUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NotBlockedDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockedDGV)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BlockOneB;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button UnBlockAllB;
		private System.Windows.Forms.Button UnBlockOneB;
		private System.Windows.Forms.Button BlockAllB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Data.DataSet BlockedUsersDS;
		private System.Data.DataTable NotBlockedUsers;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataTable BlockedUsers;
		private System.Windows.Forms.DataGridView NotBlockedDGV;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn9;
		private System.Windows.Forms.DataGridView BlockedDGV;
		private System.Windows.Forms.DataGridViewTextBoxColumn uuidDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isAdminDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn blockedAtDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn reasonDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uuidDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isAdminDataGridViewCheckBoxColumn1;
	}
}