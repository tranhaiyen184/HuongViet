using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HuongViet.GUI
{
    public partial class FrmBestSellingReport
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Label lblTitle;
        private GroupBox gbReportType;
        private RadioButton rdoDaily;
        private RadioButton rdoWeekly;
        private RadioButton rdoMonthly;
        private Button btnRefresh;
		private Button btnExport;
        private Button btnApply;
        private Panel pnlDateRange;
		private Label lblDate;
		private DateTimePicker dtpDate;

        private Panel pnlMain;
        private SplitContainer splitContainer;
        private GroupBox gbRevenueChart;
        private Chart chartRevenue;
        private GroupBox gbBestSellingList;
        private DataGridView dgvBestSelling;
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.pnlDateRange = new System.Windows.Forms.Panel();
			this.lblDate = new System.Windows.Forms.Label();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.gbReportType = new System.Windows.Forms.GroupBox();
			this.rdoDaily = new System.Windows.Forms.RadioButton();
			this.rdoWeekly = new System.Windows.Forms.RadioButton();
			this.rdoMonthly = new System.Windows.Forms.RadioButton();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.gbRevenueChart = new System.Windows.Forms.GroupBox();
			this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.gbBestSellingList = new System.Windows.Forms.GroupBox();
			this.dgvBestSelling = new System.Windows.Forms.DataGridView();
			this.lblLastUpdate = new System.Windows.Forms.Label();
			this.pnlTop.SuspendLayout();
			this.pnlDateRange.SuspendLayout();
			this.gbReportType.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.gbRevenueChart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
			this.gbBestSellingList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.White;
			this.pnlTop.Controls.Add(this.pnlDateRange);
			this.pnlTop.Controls.Add(this.lblTitle);
			this.pnlTop.Controls.Add(this.gbReportType);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
			this.pnlTop.Size = new System.Drawing.Size(1600, 150);
			this.pnlTop.TabIndex = 0;
			// 
			// pnlDateRange
			// 
			this.pnlDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDateRange.Controls.Add(this.lblDate);
			this.pnlDateRange.Controls.Add(this.dtpDate);
			this.pnlDateRange.Controls.Add(this.btnExport);
			this.pnlDateRange.Controls.Add(this.btnRefresh);
			this.pnlDateRange.Controls.Add(this.btnApply);
			this.pnlDateRange.Location = new System.Drawing.Point(544, 52);
			this.pnlDateRange.Name = "pnlDateRange";
			this.pnlDateRange.Size = new System.Drawing.Size(954, 80);
			this.pnlDateRange.TabIndex = 3;
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(12, 24);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(67, 28);
			this.lblDate.TabIndex = 0;
			this.lblDate.Text = "Ngày:";
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "dd/MM/yyyy";
			this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.Location = new System.Drawing.Point(151, 21);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(205, 34);
			this.dtpDate.TabIndex = 1;
			this.dtpDate.ValueChanged += new System.EventHandler(this.DateRange_ValueChanged);
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
			this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExport.ForeColor = System.Drawing.Color.White;
			this.btnExport.Location = new System.Drawing.Point(740, 17);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(184, 43);
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
			this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.ForeColor = System.Drawing.Color.White;
			this.btnRefresh.Location = new System.Drawing.Point(560, 17);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(160, 43);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
			// 
			// btnApply
			// 
			this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnApply.ForeColor = System.Drawing.Color.White;
			this.btnApply.Location = new System.Drawing.Point(380, 17);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(160, 44);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Áp dụng";
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
			this.lblTitle.Location = new System.Drawing.Point(27, 10);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(290, 41);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Sản phẩm bán chạy";
			// 
			// gbReportType
			// 
			this.gbReportType.Controls.Add(this.rdoDaily);
			this.gbReportType.Controls.Add(this.rdoWeekly);
			this.gbReportType.Controls.Add(this.rdoMonthly);
			this.gbReportType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
			this.rdoDaily.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoDaily.Location = new System.Drawing.Point(27, 31);
			this.rdoDaily.Name = "rdoDaily";
			this.rdoDaily.Size = new System.Drawing.Size(111, 27);
			this.rdoDaily.TabIndex = 0;
			this.rdoDaily.TabStop = true;
			this.rdoDaily.Text = "Theo ngày";
			this.rdoDaily.UseVisualStyleBackColor = true;
			this.rdoDaily.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// rdoWeekly
			// 
			this.rdoWeekly.AutoSize = true;
			this.rdoWeekly.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoWeekly.Location = new System.Drawing.Point(183, 31);
			this.rdoWeekly.Name = "rdoWeekly";
			this.rdoWeekly.Size = new System.Drawing.Size(119, 27);
			this.rdoWeekly.TabIndex = 1;
			this.rdoWeekly.Text = "Theo tháng";
			this.rdoWeekly.UseVisualStyleBackColor = true;
			this.rdoWeekly.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// rdoMonthly
			// 
			this.rdoMonthly.AutoSize = true;
			this.rdoMonthly.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoMonthly.Location = new System.Drawing.Point(343, 31);
			this.rdoMonthly.Name = "rdoMonthly";
			this.rdoMonthly.Size = new System.Drawing.Size(108, 27);
			this.rdoMonthly.TabIndex = 2;
			this.rdoMonthly.Text = "Theo năm";
			this.rdoMonthly.UseVisualStyleBackColor = true;
			this.rdoMonthly.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.pnlMain.Controls.Add(this.splitContainer);
			this.pnlMain.Controls.Add(this.lblLastUpdate);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 150);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
			this.pnlMain.Size = new System.Drawing.Size(1600, 750);
			this.pnlMain.TabIndex = 1;
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(20, 16);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.gbRevenueChart);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.gbBestSellingList);
			this.splitContainer.Size = new System.Drawing.Size(1560, 694);
			this.splitContainer.SplitterDistance = 624;
			this.splitContainer.TabIndex = 0;
			// 
			// gbRevenueChart
			// 
			this.gbRevenueChart.Controls.Add(this.chartRevenue);
			this.gbRevenueChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbRevenueChart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbRevenueChart.Location = new System.Drawing.Point(0, 0);
			this.gbRevenueChart.Name = "gbRevenueChart";
			this.gbRevenueChart.Size = new System.Drawing.Size(624, 694);
			this.gbRevenueChart.TabIndex = 0;
			this.gbRevenueChart.TabStop = false;
			this.gbRevenueChart.Text = "Top 10 sản phẩm bán chạy";
			// 
			// chartRevenue
			// 
			chartArea1.Name = "RevenueArea";
			this.chartRevenue.ChartAreas.Add(chartArea1);
			this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend";
			this.chartRevenue.Legends.Add(legend1);
			this.chartRevenue.Location = new System.Drawing.Point(3, 26);
			this.chartRevenue.Name = "chartRevenue";
			this.chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series1.ChartArea = "RevenueArea";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
			series1.Legend = "Legend";
			series1.Name = "Số lượng bán";
			this.chartRevenue.Series.Add(series1);
			this.chartRevenue.Size = new System.Drawing.Size(618, 665);
			this.chartRevenue.TabIndex = 0;
			this.chartRevenue.Text = "chartRevenue";
			// 
			// gbBestSellingList
			// 
			this.gbBestSellingList.Controls.Add(this.dgvBestSelling);
			this.gbBestSellingList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbBestSellingList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbBestSellingList.Location = new System.Drawing.Point(0, 0);
			this.gbBestSellingList.Name = "gbBestSellingList";
			this.gbBestSellingList.Size = new System.Drawing.Size(932, 694);
			this.gbBestSellingList.TabIndex = 0;
			this.gbBestSellingList.TabStop = false;
			this.gbBestSellingList.Text = "Danh sách sản phẩm bán chạy";
			// 
			// dgvBestSelling
			// 
			this.dgvBestSelling.AllowUserToAddRows = false;
			this.dgvBestSelling.AllowUserToDeleteRows = false;
			this.dgvBestSelling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBestSelling.BackgroundColor = System.Drawing.Color.White;
			this.dgvBestSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBestSelling.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBestSelling.Location = new System.Drawing.Point(3, 26);
			this.dgvBestSelling.MultiSelect = false;
			this.dgvBestSelling.Name = "dgvBestSelling";
			this.dgvBestSelling.ReadOnly = true;
			this.dgvBestSelling.RowHeadersVisible = false;
			this.dgvBestSelling.RowHeadersWidth = 51;
			this.dgvBestSelling.RowTemplate.Height = 24;
			this.dgvBestSelling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvBestSelling.Size = new System.Drawing.Size(926, 665);
			this.dgvBestSelling.TabIndex = 0;
			// 
			// lblLastUpdate
			// 
			this.lblLastUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblLastUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastUpdate.ForeColor = System.Drawing.Color.Gray;
			this.lblLastUpdate.Location = new System.Drawing.Point(20, 710);
			this.lblLastUpdate.Name = "lblLastUpdate";
			this.lblLastUpdate.Size = new System.Drawing.Size(1560, 24);
			this.lblLastUpdate.TabIndex = 1;
			this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FrmBestSellingReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1600, 900);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlTop);
			this.Name = "FrmBestSellingReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo sản phẩm bán chạy";
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.pnlDateRange.ResumeLayout(false);
			this.pnlDateRange.PerformLayout();
			this.gbReportType.ResumeLayout(false);
			this.gbReportType.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.gbRevenueChart.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
			this.gbBestSellingList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).EndInit();
			this.ResumeLayout(false);

        }
    }
}
