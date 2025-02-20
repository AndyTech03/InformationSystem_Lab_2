namespace InformationSystem_Lab_2
{
	partial class ConfigsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigsForm));
			this.ConfigsDS = new System.Data.DataSet();
			this.Configs = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.ConfigsDGV = new System.Windows.Forms.DataGridView();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigsBN = new System.Windows.Forms.BindingNavigator(this.components);
			this.ConfigsBS = new System.Windows.Forms.BindingSource(this.components);
			this.ResetB = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RefreshB = new System.Windows.Forms.ToolStripButton();
			this.SaveB = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Configs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsBN)).BeginInit();
			this.ConfigsBN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsBS)).BeginInit();
			this.SuspendLayout();
			// 
			// ConfigsDS
			// 
			this.ConfigsDS.DataSetName = "NewDataSet";
			this.ConfigsDS.Tables.AddRange(new System.Data.DataTable[] {
            this.Configs});
			// 
			// Configs
			// 
			this.Configs.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
			this.Configs.TableName = "Configs";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "Name";
			this.dataColumn1.ColumnName = "name";
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "Value";
			this.dataColumn2.ColumnName = "value";
			// 
			// ConfigsDGV
			// 
			this.ConfigsDGV.AllowUserToAddRows = false;
			this.ConfigsDGV.AllowUserToDeleteRows = false;
			this.ConfigsDGV.AutoGenerateColumns = false;
			this.ConfigsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ConfigsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
			this.ConfigsDGV.DataMember = "Configs";
			this.ConfigsDGV.DataSource = this.ConfigsDS;
			this.ConfigsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfigsDGV.Location = new System.Drawing.Point(0, 31);
			this.ConfigsDGV.Name = "ConfigsDGV";
			this.ConfigsDGV.RowHeadersWidth = 51;
			this.ConfigsDGV.RowTemplate.Height = 24;
			this.ConfigsDGV.Size = new System.Drawing.Size(782, 522);
			this.ConfigsDGV.TabIndex = 0;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "name";
			this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn.Width = 300;
			// 
			// valueDataGridViewTextBoxColumn
			// 
			this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
			this.valueDataGridViewTextBoxColumn.HeaderText = "value";
			this.valueDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
			this.valueDataGridViewTextBoxColumn.Width = 300;
			// 
			// ConfigsBN
			// 
			this.ConfigsBN.AddNewItem = null;
			this.ConfigsBN.BindingSource = this.ConfigsBS;
			this.ConfigsBN.CountItem = null;
			this.ConfigsBN.DeleteItem = null;
			this.ConfigsBN.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ConfigsBN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetB,
            this.bindingNavigatorSeparator1,
            this.RefreshB,
            this.SaveB});
			this.ConfigsBN.Location = new System.Drawing.Point(0, 0);
			this.ConfigsBN.MoveFirstItem = null;
			this.ConfigsBN.MoveLastItem = null;
			this.ConfigsBN.MoveNextItem = null;
			this.ConfigsBN.MovePreviousItem = null;
			this.ConfigsBN.Name = "ConfigsBN";
			this.ConfigsBN.PositionItem = null;
			this.ConfigsBN.Size = new System.Drawing.Size(782, 31);
			this.ConfigsBN.TabIndex = 1;
			this.ConfigsBN.Text = "bindingNavigator1";
			// 
			// ConfigsBS
			// 
			this.ConfigsBS.DataMember = "Configs";
			this.ConfigsBS.DataSource = this.ConfigsDS;
			// 
			// ResetB
			// 
			this.ResetB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ResetB.Image = ((System.Drawing.Image)(resources.GetObject("ResetB.Image")));
			this.ResetB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ResetB.Name = "ResetB";
			this.ResetB.Size = new System.Drawing.Size(79, 28);
			this.ResetB.Text = "Сбросить";
			this.ResetB.Click += new System.EventHandler(this.ResetB_Click);
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// RefreshB
			// 
			this.RefreshB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RefreshB.Image = ((System.Drawing.Image)(resources.GetObject("RefreshB.Image")));
			this.RefreshB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RefreshB.Name = "RefreshB";
			this.RefreshB.Size = new System.Drawing.Size(82, 28);
			this.RefreshB.Text = "Обновить";
			this.RefreshB.ToolTipText = "Обновить";
			this.RefreshB.Click += new System.EventHandler(this.RefreshB_Click);
			// 
			// SaveB
			// 
			this.SaveB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SaveB.Image = ((System.Drawing.Image)(resources.GetObject("SaveB.Image")));
			this.SaveB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveB.Name = "SaveB";
			this.SaveB.Size = new System.Drawing.Size(87, 28);
			this.SaveB.Text = "Сохранить";
			this.SaveB.Click += new System.EventHandler(this.SaveB_Click);
			// 
			// ConfigsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 553);
			this.Controls.Add(this.ConfigsDGV);
			this.Controls.Add(this.ConfigsBN);
			this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "ConfigsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Конфигурации";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigsForm_FormClosing);
			this.Shown += new System.EventHandler(this.ConfigsForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.ConfigsDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Configs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsBN)).EndInit();
			this.ConfigsBN.ResumeLayout(false);
			this.ConfigsBN.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConfigsBS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Data.DataSet ConfigsDS;
		private System.Windows.Forms.DataGridView ConfigsDGV;
		private System.Windows.Forms.BindingNavigator ConfigsBN;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton RefreshB;
		private System.Windows.Forms.ToolStripButton SaveB;
		private System.Windows.Forms.BindingSource ConfigsBS;
		private System.Data.DataTable Configs;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Windows.Forms.ToolStripButton ResetB;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
	}
}