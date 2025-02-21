namespace InformationSystem_Lab_2
{
	partial class JournalForm
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
			this.JournalDS = new System.Data.DataSet();
			this.LogEvents = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.JournalDGV = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ZipTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.UnZipTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.RefreshTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.SearchTypeTSCB = new System.Windows.Forms.ToolStripComboBox();
			this.SearchTSTB = new System.Windows.Forms.ToolStripTextBox();
			this.SearchTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.InvertSearchTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseGzipTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.TotalRowsTSL = new System.Windows.Forms.ToolStripStatusLabel();
			this.LoadingTSPG = new System.Windows.Forms.ToolStripProgressBar();
			this.ArchiveOpenDialog = new System.Windows.Forms.OpenFileDialog();
			this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userUuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userIpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventDetailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.JournalDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LogEvents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.JournalDGV)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// JournalDS
			// 
			this.JournalDS.DataSetName = "NewDataSet";
			this.JournalDS.Tables.AddRange(new System.Data.DataTable[] {
            this.LogEvents});
			// 
			// LogEvents
			// 
			this.LogEvents.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
			this.LogEvents.TableName = "Events";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "DateTime";
			this.dataColumn1.ColumnName = "dateTime";
			this.dataColumn1.DataType = typeof(System.DateTime);
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "EventType";
			this.dataColumn2.ColumnName = "eventType";
			// 
			// dataColumn3
			// 
			this.dataColumn3.Caption = "UserUuid";
			this.dataColumn3.ColumnName = "userUuid";
			this.dataColumn3.DataType = typeof(System.Guid);
			// 
			// dataColumn4
			// 
			this.dataColumn4.Caption = "UserIp";
			this.dataColumn4.ColumnName = "userIp";
			// 
			// dataColumn5
			// 
			this.dataColumn5.Caption = "EventDetail";
			this.dataColumn5.ColumnName = "eventDetail";
			// 
			// JournalDGV
			// 
			this.JournalDGV.AllowUserToAddRows = false;
			this.JournalDGV.AllowUserToDeleteRows = false;
			this.JournalDGV.AutoGenerateColumns = false;
			this.JournalDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.JournalDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateTimeDataGridViewTextBoxColumn,
            this.eventTypeDataGridViewTextBoxColumn,
            this.userUuidDataGridViewTextBoxColumn,
            this.userIpDataGridViewTextBoxColumn,
            this.eventDetailDataGridViewTextBoxColumn});
			this.JournalDGV.DataMember = "Events";
			this.JournalDGV.DataSource = this.JournalDS;
			this.JournalDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.JournalDGV.Location = new System.Drawing.Point(0, 32);
			this.JournalDGV.Name = "JournalDGV";
			this.JournalDGV.ReadOnly = true;
			this.JournalDGV.RowHeadersWidth = 51;
			this.JournalDGV.RowTemplate.Height = 24;
			this.JournalDGV.Size = new System.Drawing.Size(1262, 613);
			this.JournalDGV.TabIndex = 0;
			this.JournalDGV.Click += new System.EventHandler(this.JournalDGV_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZipTSM,
            this.UnZipTSM,
            this.RefreshTSM,
            this.SearchTypeTSCB,
            this.SearchTSTB,
            this.SearchTSMI,
            this.InvertSearchTSMI,
            this.CloseGzipTSMI});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1262, 32);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ZipTSM
			// 
			this.ZipTSM.Name = "ZipTSM";
			this.ZipTSM.Size = new System.Drawing.Size(123, 28);
			this.ZipTSM.Text = "Архивировать";
			this.ZipTSM.Click += new System.EventHandler(this.ZipTSM_Click);
			// 
			// UnZipTSM
			// 
			this.UnZipTSM.Name = "UnZipTSM";
			this.UnZipTSM.Size = new System.Drawing.Size(144, 28);
			this.UnZipTSM.Text = "Разархивировать";
			this.UnZipTSM.Click += new System.EventHandler(this.UnZipTSM_Click);
			// 
			// RefreshTSM
			// 
			this.RefreshTSM.Name = "RefreshTSM";
			this.RefreshTSM.Size = new System.Drawing.Size(92, 28);
			this.RefreshTSM.Text = "Обновить";
			this.RefreshTSM.Click += new System.EventHandler(this.RefreshTSM_Click);
			// 
			// SearchTypeTSCB
			// 
			this.SearchTypeTSCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SearchTypeTSCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SearchTypeTSCB.Items.AddRange(new object[] {
            "Поиск по дате",
            "Поиск по типу",
            "Поиск по uuid",
            "Поиск по ip",
            "Поиск по detail"});
			this.SearchTypeTSCB.Name = "SearchTypeTSCB";
			this.SearchTypeTSCB.Size = new System.Drawing.Size(140, 28);
			// 
			// SearchTSTB
			// 
			this.SearchTSTB.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.SearchTSTB.Name = "SearchTSTB";
			this.SearchTSTB.Size = new System.Drawing.Size(200, 28);
			// 
			// SearchTSMI
			// 
			this.SearchTSMI.Name = "SearchTSMI";
			this.SearchTSMI.Size = new System.Drawing.Size(66, 28);
			this.SearchTSMI.Text = "Поиск";
			this.SearchTSMI.Click += new System.EventHandler(this.SearchTSMI_Click);
			// 
			// InvertSearchTSMI
			// 
			this.InvertSearchTSMI.Name = "InvertSearchTSMI";
			this.InvertSearchTSMI.Size = new System.Drawing.Size(140, 28);
			this.InvertSearchTSMI.Text = "Обратный поиск";
			this.InvertSearchTSMI.Click += new System.EventHandler(this.InvertSearchTSMI_Click);
			// 
			// CloseGzipTSMI
			// 
			this.CloseGzipTSMI.Name = "CloseGzipTSMI";
			this.CloseGzipTSMI.Size = new System.Drawing.Size(125, 28);
			this.CloseGzipTSMI.Text = "Закрыть архив";
			this.CloseGzipTSMI.Click += new System.EventHandler(this.CloseGzipTSMI_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TotalRowsTSL,
            this.LoadingTSPG});
			this.statusStrip1.Location = new System.Drawing.Point(0, 645);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1262, 28);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// TotalRowsTSL
			// 
			this.TotalRowsTSL.Name = "TotalRowsTSL";
			this.TotalRowsTSL.Size = new System.Drawing.Size(77, 22);
			this.TotalRowsTSL.Text = "TotalRows";
			// 
			// LoadingTSPG
			// 
			this.LoadingTSPG.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.LoadingTSPG.MarqueeAnimationSpeed = 1;
			this.LoadingTSPG.Maximum = 1000;
			this.LoadingTSPG.Name = "LoadingTSPG";
			this.LoadingTSPG.RightToLeftLayout = true;
			this.LoadingTSPG.Size = new System.Drawing.Size(800, 20);
			// 
			// ArchiveOpenDialog
			// 
			this.ArchiveOpenDialog.Filter = "Gzip files|*.gz";
			this.ArchiveOpenDialog.Multiselect = true;
			this.ArchiveOpenDialog.RestoreDirectory = true;
			// 
			// dateTimeDataGridViewTextBoxColumn
			// 
			this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "dateTime";
			this.dateTimeDataGridViewTextBoxColumn.HeaderText = "dateTime";
			this.dateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
			this.dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.dateTimeDataGridViewTextBoxColumn.Width = 200;
			// 
			// eventTypeDataGridViewTextBoxColumn
			// 
			this.eventTypeDataGridViewTextBoxColumn.DataPropertyName = "eventType";
			this.eventTypeDataGridViewTextBoxColumn.HeaderText = "eventType";
			this.eventTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.eventTypeDataGridViewTextBoxColumn.Name = "eventTypeDataGridViewTextBoxColumn";
			this.eventTypeDataGridViewTextBoxColumn.ReadOnly = true;
			this.eventTypeDataGridViewTextBoxColumn.Width = 200;
			// 
			// userUuidDataGridViewTextBoxColumn
			// 
			this.userUuidDataGridViewTextBoxColumn.DataPropertyName = "userUuid";
			this.userUuidDataGridViewTextBoxColumn.HeaderText = "userUuid";
			this.userUuidDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.userUuidDataGridViewTextBoxColumn.Name = "userUuidDataGridViewTextBoxColumn";
			this.userUuidDataGridViewTextBoxColumn.ReadOnly = true;
			this.userUuidDataGridViewTextBoxColumn.Width = 400;
			// 
			// userIpDataGridViewTextBoxColumn
			// 
			this.userIpDataGridViewTextBoxColumn.DataPropertyName = "userIp";
			this.userIpDataGridViewTextBoxColumn.HeaderText = "userIp";
			this.userIpDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.userIpDataGridViewTextBoxColumn.Name = "userIpDataGridViewTextBoxColumn";
			this.userIpDataGridViewTextBoxColumn.ReadOnly = true;
			this.userIpDataGridViewTextBoxColumn.Width = 180;
			// 
			// eventDetailDataGridViewTextBoxColumn
			// 
			this.eventDetailDataGridViewTextBoxColumn.DataPropertyName = "eventDetail";
			this.eventDetailDataGridViewTextBoxColumn.HeaderText = "eventDetail";
			this.eventDetailDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.eventDetailDataGridViewTextBoxColumn.Name = "eventDetailDataGridViewTextBoxColumn";
			this.eventDetailDataGridViewTextBoxColumn.ReadOnly = true;
			this.eventDetailDataGridViewTextBoxColumn.Width = 200;
			// 
			// JournalForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.JournalDGV);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "JournalForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Журнал";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JournalForm_FormClosing);
			this.Shown += new System.EventHandler(this.JournalForm_Shown);
			this.VisibleChanged += new System.EventHandler(this.JournalForm_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.JournalDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LogEvents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.JournalDGV)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Data.DataSet JournalDS;
		private System.Data.DataTable LogEvents;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Windows.Forms.DataGridView JournalDGV;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ZipTSM;
		private System.Windows.Forms.ToolStripMenuItem UnZipTSM;
		private System.Windows.Forms.ToolStripMenuItem RefreshTSM;
		private System.Windows.Forms.ToolStripComboBox SearchTypeTSCB;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel TotalRowsTSL;
		private System.Windows.Forms.ToolStripTextBox SearchTSTB;
		private System.Windows.Forms.ToolStripMenuItem SearchTSMI;
		private System.Windows.Forms.ToolStripProgressBar LoadingTSPG;
		private System.Windows.Forms.ToolStripMenuItem InvertSearchTSMI;
		private System.Windows.Forms.OpenFileDialog ArchiveOpenDialog;
		private System.Windows.Forms.ToolStripMenuItem CloseGzipTSMI;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn userUuidDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn userIpDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn eventDetailDataGridViewTextBoxColumn;
	}
}