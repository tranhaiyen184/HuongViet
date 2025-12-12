using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HuongViet.GUI
{
    public partial class FrmRevenueReport
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlRevenueCard;
        private Label lblTotalRevenue;
        private Label lblRevenueLabel;
        private GroupBox gbReportType;
        private RadioButton rdoDaily;
        private RadioButton rdoWeekly;
        private RadioButton rdoMonthly;
		private Button btnRefresh;
		private Button btnExport;
        private Panel pnlDateRange;
		private Label lblStartDate;
		private Label lblEndDate;
		private DateTimePicker dtpStartDate;
		private DateTimePicker dtpEndDate;
		private Label lblYearCount;
		private NumericUpDown nudYearCount;
		private Button btnApply;

        private Panel pnlMain;
		private TableLayoutPanel tblRevenueLayout;
		private GroupBox gbRevenueChart;
		private GroupBox gbRevenueTable;
		private DataGridView dgvRevenue;
		private Chart chartRevenue;
        private Label lblLastUpdate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.gbReportType = new System.Windows.Forms.GroupBox();
			this.rdoDaily = new System.Windows.Forms.RadioButton();
			this.rdoWeekly = new System.Windows.Forms.RadioButton();
			this.rdoMonthly = new System.Windows.Forms.RadioButton();
			this.pnlDateRange = new System.Windows.Forms.Panel();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.lblEndDate = new System.Windows.Forms.Label();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.lblYearCount = new System.Windows.Forms.Label();
			this.nudYearCount = new System.Windows.Forms.NumericUpDown();
			this.pnlRevenueCard = new System.Windows.Forms.Panel();
			this.lblRevenueLabel = new System.Windows.Forms.Label();
			this.lblTotalRevenue = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.tblRevenueLayout = new System.Windows.Forms.TableLayoutPanel();
			this.gbRevenueChart = new System.Windows.Forms.GroupBox();
			this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.gbRevenueTable = new System.Windows.Forms.GroupBox();
			this.dgvRevenue = new System.Windows.Forms.DataGridView();
			this.lblLastUpdate = new System.Windows.Forms.Label();
			this.pnlTop.SuspendLayout();
			this.gbReportType.SuspendLayout();
			this.pnlDateRange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudYearCount)).BeginInit();
			this.pnlRevenueCard.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.tblRevenueLayout.SuspendLayout();
			this.gbRevenueChart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
			this.gbRevenueTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.White;
			this.pnlTop.Controls.Add(this.lblTitle);
			this.pnlTop.Controls.Add(this.gbReportType);
			this.pnlTop.Controls.Add(this.pnlDateRange);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
			this.pnlTop.Size = new System.Drawing.Size(1924, 150);
			this.pnlTop.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
			this.lblTitle.Location = new System.Drawing.Point(27, 7);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(303, 41);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Thống kê doanh thu";
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnApply.ForeColor = System.Drawing.Color.White;
			this.btnApply.Location = new System.Drawing.Point(372, 49);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(170, 48);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Áp dụng";
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
			this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExport.ForeColor = System.Drawing.Color.White;
			this.btnExport.Location = new System.Drawing.Point(981, 49);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(204, 48);
			this.btnExport.TabIndex = 5;
			this.btnExport.Text = "Xuất báo cáo";
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.ForeColor = System.Drawing.Color.White;
			this.btnRefresh.Location = new System.Drawing.Point(578, 49);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(170, 48);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
			// 
			// gbReportType
			// 
			this.gbReportType.Controls.Add(this.rdoDaily);
			this.gbReportType.Controls.Add(this.rdoWeekly);
			this.gbReportType.Controls.Add(this.rdoMonthly);
			this.gbReportType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbReportType.Location = new System.Drawing.Point(31, 58);
			this.gbReportType.Name = "gbReportType";
			this.gbReportType.Size = new System.Drawing.Size(507, 74);
			this.gbReportType.TabIndex = 2;
			this.gbReportType.TabStop = false;
			this.gbReportType.Text = "Loại thống kê";
			// 
			// rdoDaily
			// 
			this.rdoDaily.AutoSize = true;
			this.rdoDaily.Checked = true;
			this.rdoDaily.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoDaily.Location = new System.Drawing.Point(27, 31);
			this.rdoDaily.Name = "rdoDaily";
			this.rdoDaily.Size = new System.Drawing.Size(99, 24);
			this.rdoDaily.TabIndex = 0;
			this.rdoDaily.TabStop = true;
			this.rdoDaily.Text = "Theo ngày";
			this.rdoDaily.UseVisualStyleBackColor = true;
			this.rdoDaily.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// rdoWeekly
			// 
			this.rdoWeekly.AutoSize = true;
			this.rdoWeekly.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoWeekly.Location = new System.Drawing.Point(188, 31);
			this.rdoWeekly.Name = "rdoWeekly";
			this.rdoWeekly.Size = new System.Drawing.Size(105, 24);
			this.rdoWeekly.TabIndex = 1;
			this.rdoWeekly.Text = "Theo tháng";
			this.rdoWeekly.UseVisualStyleBackColor = true;
			this.rdoWeekly.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// rdoMonthly
			// 
			this.rdoMonthly.AutoSize = true;
			this.rdoMonthly.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoMonthly.Location = new System.Drawing.Point(347, 31);
			this.rdoMonthly.Name = "rdoMonthly";
			this.rdoMonthly.Size = new System.Drawing.Size(96, 24);
			this.rdoMonthly.TabIndex = 2;
			this.rdoMonthly.Text = "Theo năm";
			this.rdoMonthly.UseVisualStyleBackColor = true;
			this.rdoMonthly.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// pnlDateRange
			// 
			this.pnlDateRange.Controls.Add(this.lblStartDate);
			this.pnlDateRange.Controls.Add(this.btnExport);
			this.pnlDateRange.Controls.Add(this.btnApply);
			this.pnlDateRange.Controls.Add(this.btnRefresh);
			this.pnlDateRange.Controls.Add(this.dtpStartDate);
			this.pnlDateRange.Controls.Add(this.lblEndDate);
			this.pnlDateRange.Controls.Add(this.dtpEndDate);
			this.pnlDateRange.Controls.Add(this.lblYearCount);
			this.pnlDateRange.Controls.Add(this.nudYearCount);
			this.pnlDateRange.Location = new System.Drawing.Point(593, 40);
			this.pnlDateRange.Name = "pnlDateRange";
			this.pnlDateRange.Size = new System.Drawing.Size(1244, 107);
			this.pnlDateRange.TabIndex = 3;
			// 
			// lblStartDate
			// 
			this.lblStartDate.AutoSize = true;
			this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStartDate.Location = new System.Drawing.Point(3, 20);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(53, 23);
			this.lblStartDate.TabIndex = 0;
			this.lblStartDate.Text = "Năm:";
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
			this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point(125, 16);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.ShowUpDown = false;
			this.dtpStartDate.Size = new System.Drawing.Size(203, 34);
			this.dtpStartDate.TabIndex = 1;
			this.dtpStartDate.ValueChanged += new System.EventHandler(this.DateRange_ValueChanged);
			// 
			// lblEndDate
			// 
			this.lblEndDate.AutoSize = true;
			this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEndDate.Location = new System.Drawing.Point(3, 62);
			this.lblEndDate.Name = "lblEndDate";
			this.lblEndDate.Size = new System.Drawing.Size(91, 23);
			this.lblEndDate.TabIndex = 2;
			this.lblEndDate.Text = "Đến ngày:";
			this.lblEndDate.Visible = false;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
			this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(125, 58);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(203, 34);
			this.dtpEndDate.TabIndex = 3;
			this.dtpEndDate.Visible = false;
			this.dtpEndDate.ValueChanged += new System.EventHandler(this.DateRange_ValueChanged);
			// 
			// lblYearCount
			// 
			this.lblYearCount.AutoSize = true;
			this.lblYearCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYearCount.Location = new System.Drawing.Point(4, 40);
			this.lblYearCount.Name = "lblYearCount";
			this.lblYearCount.Size = new System.Drawing.Size(70, 23);
			this.lblYearCount.TabIndex = 4;
			this.lblYearCount.Text = "Số năm";
			this.lblYearCount.Visible = false;
			// 
			// nudYearCount
			// 
			this.nudYearCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudYearCount.Location = new System.Drawing.Point(125, 40);
			this.nudYearCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudYearCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudYearCount.Name = "nudYearCount";
			this.nudYearCount.Size = new System.Drawing.Size(120, 34);
			this.nudYearCount.TabIndex = 5;
			this.nudYearCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudYearCount.Visible = false;
			this.nudYearCount.ValueChanged += new System.EventHandler(this.NudYearCount_ValueChanged);
			// 
			// pnlRevenueCard
			// 
			this.pnlRevenueCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlRevenueCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
			this.pnlRevenueCard.Controls.Add(this.lblRevenueLabel);
			this.pnlRevenueCard.Controls.Add(this.lblTotalRevenue);
			this.pnlRevenueCard.Location = new System.Drawing.Point(1000, 28);
			this.pnlRevenueCard.Name = "pnlRevenueCard";
			this.pnlRevenueCard.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.pnlRevenueCard.Size = new System.Drawing.Size(360, 123);
			this.pnlRevenueCard.TabIndex = 4;
			// 
			// lblRevenueLabel
			// 
			this.lblRevenueLabel.AutoSize = true;
			this.lblRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRevenueLabel.ForeColor = System.Drawing.Color.White;
			this.lblRevenueLabel.Location = new System.Drawing.Point(20, 20);
			this.lblRevenueLabel.Name = "lblRevenueLabel";
			this.lblRevenueLabel.Size = new System.Drawing.Size(197, 28);
			this.lblRevenueLabel.TabIndex = 0;
			this.lblRevenueLabel.Text = "TỔNG DOANH THU";
			// 
			// lblTotalRevenue
			// 
			this.lblTotalRevenue.AutoSize = true;
			this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
			this.lblTotalRevenue.Location = new System.Drawing.Point(20, 60);
			this.lblTotalRevenue.Name = "lblTotalRevenue";
			this.lblTotalRevenue.Size = new System.Drawing.Size(109, 41);
			this.lblTotalRevenue.TabIndex = 1;
			this.lblTotalRevenue.Text = "0 VNĐ";
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.pnlMain.Controls.Add(this.tblRevenueLayout);
			this.pnlMain.Controls.Add(this.lblLastUpdate);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 150);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
			this.pnlMain.Size = new System.Drawing.Size(1924, 630);
			this.pnlMain.TabIndex = 1;
			// 
			// tblRevenueLayout
			// 
			this.tblRevenueLayout.ColumnCount = 2;
			this.tblRevenueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tblRevenueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tblRevenueLayout.Controls.Add(this.gbRevenueChart, 0, 0);
			this.tblRevenueLayout.Controls.Add(this.gbRevenueTable, 1, 0);
			this.tblRevenueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblRevenueLayout.Location = new System.Drawing.Point(20, 16);
			this.tblRevenueLayout.Name = "tblRevenueLayout";
			this.tblRevenueLayout.RowCount = 1;
			this.tblRevenueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblRevenueLayout.Size = new System.Drawing.Size(1884, 574);
			this.tblRevenueLayout.TabIndex = 2;
			// 
			// gbRevenueChart
			// 
			this.gbRevenueChart.Controls.Add(this.chartRevenue);
			this.gbRevenueChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbRevenueChart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbRevenueChart.Location = new System.Drawing.Point(3, 3);
			this.gbRevenueChart.Name = "gbRevenueChart";
			this.gbRevenueChart.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
			this.gbRevenueChart.Size = new System.Drawing.Size(1218, 568);
			this.gbRevenueChart.TabIndex = 0;
			this.gbRevenueChart.TabStop = false;
			this.gbRevenueChart.Text = "Biểu đồ doanh thu";
			// 
			// chartRevenue
			// 
			chartArea2.Name = "RevenueArea";
			this.chartRevenue.ChartAreas.Add(chartArea2);
			this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend";
			this.chartRevenue.Legends.Add(legend2);
			this.chartRevenue.Location = new System.Drawing.Point(10, 31);
			this.chartRevenue.Name = "chartRevenue";
			this.chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series2.BorderWidth = 3;
			series2.ChartArea = "RevenueArea";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
			series2.Legend = "Legend";
			series2.MarkerSize = 8;
			series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series2.Name = "Doanh thu";
			this.chartRevenue.Series.Add(series2);
			this.chartRevenue.Size = new System.Drawing.Size(1198, 529);
			this.chartRevenue.TabIndex = 0;
			this.chartRevenue.Text = "chartRevenue";
			// 
			// gbRevenueTable
			// 
			this.gbRevenueTable.Controls.Add(this.dgvRevenue);
			this.gbRevenueTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbRevenueTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbRevenueTable.Location = new System.Drawing.Point(1227, 3);
			this.gbRevenueTable.Name = "gbRevenueTable";
			this.gbRevenueTable.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
			this.gbRevenueTable.Size = new System.Drawing.Size(654, 568);
			this.gbRevenueTable.TabIndex = 1;
			this.gbRevenueTable.TabStop = false;
			this.gbRevenueTable.Text = "Bảng tổng doanh thu";
			// 
			// dgvRevenue
			// 
			this.dgvRevenue.AllowUserToAddRows = false;
			this.dgvRevenue.AllowUserToDeleteRows = false;
			this.dgvRevenue.AllowUserToResizeRows = false;
			this.dgvRevenue.BackgroundColor = System.Drawing.Color.White;
			this.dgvRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvRevenue.ColumnHeadersHeight = 29;
			this.dgvRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvRevenue.Location = new System.Drawing.Point(10, 31);
			this.dgvRevenue.MultiSelect = false;
			this.dgvRevenue.Name = "dgvRevenue";
			this.dgvRevenue.ReadOnly = true;
			this.dgvRevenue.RowHeadersVisible = false;
			this.dgvRevenue.RowHeadersWidth = 51;
			this.dgvRevenue.RowTemplate.Height = 24;
			this.dgvRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvRevenue.Size = new System.Drawing.Size(634, 529);
			this.dgvRevenue.TabIndex = 0;
			// 
			// lblLastUpdate
			// 
			this.lblLastUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblLastUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastUpdate.ForeColor = System.Drawing.Color.Gray;
			this.lblLastUpdate.Location = new System.Drawing.Point(20, 590);
			this.lblLastUpdate.Name = "lblLastUpdate";
			this.lblLastUpdate.Size = new System.Drawing.Size(1884, 24);
			this.lblLastUpdate.TabIndex = 1;
			this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FrmRevenueReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 780);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlTop);
			this.Name = "FrmRevenueReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thống kê doanh thu";
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.gbReportType.ResumeLayout(false);
			this.gbReportType.PerformLayout();
			this.pnlDateRange.ResumeLayout(false);
			this.pnlDateRange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudYearCount)).EndInit();
			this.pnlRevenueCard.ResumeLayout(false);
			this.pnlRevenueCard.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.tblRevenueLayout.ResumeLayout(false);
			this.gbRevenueChart.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
			this.gbRevenueTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
			this.ResumeLayout(false);

        }
    }
}
