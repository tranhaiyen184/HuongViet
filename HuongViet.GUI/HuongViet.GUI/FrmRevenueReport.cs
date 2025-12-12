using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;

namespace HuongViet.GUI
{
    public partial class FrmRevenueReport : Form
    {
        private readonly ReportBLL reportBLL = new ReportBLL();
        private ReportBLL.ReportType currentReportType = ReportBLL.ReportType.Daily;
        private bool isInitializing;

        private DateTime dailyStart;
        private DateTime dailyEnd;
        private int monthlyYear;
        private int yearlyCount;

        private bool ValidateFilters()
        {
            if (currentReportType == ReportBLL.ReportType.Daily)
            {
                var start = dtpStartDate.Value.Date;
                var end = dtpEndDate.Value.Date;
                if (start > end)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Cho phép tối đa 31 ngày (để phủ hết tháng dài nhất)
                if ((end - start).TotalDays >= 31)
                {
                    MessageBox.Show("Khoảng thời gian không được quá 31 ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public FrmRevenueReport()
        {
            Text = "Thống kê doanh thu";
            Width = 1600;
            Height = 900;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeLogic();
            LoadReport();
        }

        private void InitializeLogic()
        {
            isInitializing = true;
            var today = DateTime.Now.Date;
            var monthEnd = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            var monthStart = new DateTime(today.Year, today.Month, 1);

            dtpEndDate.MaxDate = monthEnd;
            dtpStartDate.MaxDate = monthEnd;

            // Daily default: toàn bộ tháng hiện hành
            dtpStartDate.Value = monthStart;
            dtpEndDate.Value = monthEnd;

            // store defaults per mode
            dailyStart = monthStart;
            dailyEnd = monthEnd;
            monthlyYear = today.Year;
            yearlyCount = 5;

            // Monthly default: current year (set when switching mode)
            // Yearly default: last 5 years (handled via numeric up-down)
            pnlDateRange.Visible = true;
            ConfigureDatePickerForDay();
            ApplyVisibilityForReportType(ReportBLL.ReportType.Daily);
            isInitializing = false;
        }

        private void ReportType_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing)
                return;
            if (rdoDaily.Checked)
            {
                currentReportType = ReportBLL.ReportType.Daily;
                ConfigureDatePickerForDay();
                ApplyVisibilityForReportType(currentReportType);
                lblStartDate.Text = "Từ ngày:";
                lblEndDate.Text = "Đến ngày:";

                // restore last daily selection
                dtpStartDate.Value = dailyStart;
                dtpEndDate.Value = dailyEnd;
            }
            else if (rdoWeekly.Checked)
            {
                currentReportType = ReportBLL.ReportType.Monthly;
                ConfigureDatePickerForYear();
                ApplyVisibilityForReportType(currentReportType);
                lblStartDate.Text = "Năm:";
                dtpStartDate.Value = new DateTime(monthlyYear, 1, 1);
            }
            else if (rdoMonthly.Checked)
            {
                currentReportType = ReportBLL.ReportType.Yearly;
                ApplyVisibilityForReportType(currentReportType);
                lblStartDate.Text = "Từ ngày:";
                nudYearCount.Value = yearlyCount;
            }
            if (ValidateFilters())
            {
                LoadReport();
            }
        }

        private void DateRange_ValueChanged(object sender, EventArgs e)
        {
            if (isInitializing)
                return;
            if (currentReportType == ReportBLL.ReportType.Daily)
            {
            }
        }

        private void NudYearCount_ValueChanged(object sender, EventArgs e)
        {
            if (isInitializing)
                return;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (isInitializing)
                return;
            var today = DateTime.Now.Date;

            if (currentReportType == ReportBLL.ReportType.Daily)
            {
                var monthEnd = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                var monthStart = new DateTime(today.Year, today.Month, 1);
                dtpEndDate.MaxDate = monthEnd;
                dtpStartDate.MaxDate = monthEnd;
                dtpStartDate.Value = monthStart;
                dtpEndDate.Value = monthEnd;
                ConfigureDatePickerForDay();
                dailyStart = monthStart;
                dailyEnd = monthEnd;
            }
            else if (currentReportType == ReportBLL.ReportType.Monthly)
            {
                dtpStartDate.Value = new DateTime(today.Year, 1, 1);
                ConfigureDatePickerForYear();
                monthlyYear = today.Year;
            }
            else if (currentReportType == ReportBLL.ReportType.Yearly)
            {
                nudYearCount.Value = 5;
                yearlyCount = 5;
            }
            if (ValidateFilters())
            {
                LoadReport();
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (isInitializing)
                return;
            if (ValidateFilters())
            {
                // store per mode after user apply
                if (currentReportType == ReportBLL.ReportType.Daily)
                {
                    dailyStart = dtpStartDate.Value.Date;
                    dailyEnd = dtpEndDate.Value.Date;
                }
                else if (currentReportType == ReportBLL.ReportType.Monthly)
                {
                    monthlyYear = dtpStartDate.Value.Year;
                }
                else if (currentReportType == ReportBLL.ReportType.Yearly)
                {
                    yearlyCount = (int)nudYearCount.Value;
                }
                LoadReport();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (isInitializing)
                return;

            if (!ValidateFilters())
                return;

            if (!EnsurePrinterAvailable())
            {
                MessageBox.Show("Máy in Microsoft Print to PDF không khả dụng. Vui lòng kiểm tra lại cấu hình in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rows = BuildCurrentRows(out int totalRevenue);
            if (rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "PDF (*.pdf)|*.pdf";
                dialog.FileName = $"{DateTime.Now:ddMMyy}BCDoanhThu.pdf";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ExportToPdf(dialog.FileName, rows, totalRevenue);
                    MessageBox.Show("Xuất báo cáo thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xuất báo cáo thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadReport()
        {
            if (isInitializing)
                return;
            try
            {
                Cursor = Cursors.WaitCursor;

                // Total revenue
                int totalRevenue;

                if (currentReportType == ReportBLL.ReportType.Daily)
                {
                    var startDate = dtpStartDate.Value.Date;
                    var endDate = dtpEndDate.Value.Date;
                    totalRevenue = reportBLL.GetTotalRevenue(startDate, endDate);
                }
                else if (currentReportType == ReportBLL.ReportType.Monthly)
                {
                    var monthlyTotals = reportBLL.GetMonthlyRevenueTotals(dtpStartDate.Value.Year);
                    totalRevenue = monthlyTotals.Sum();
                }
                else // Yearly
                {
                    int yearCount = (int)nudYearCount.Value;
                    int endYear = DateTime.Now.Year;
                    int startYear = endYear - yearCount + 1;
                    var yearlyTotals = reportBLL.GetYearlyRevenueTotals(startYear, yearCount);
                    totalRevenue = yearlyTotals.Sum();
                }
                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VNĐ";

                // Chart
                LoadRevenueChart();

                // Grid
                LoadRevenueGrid();

                lblLastUpdate.Text = "Cập nhật lúc: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadRevenueChart()
        {
            chartRevenue.Series["Doanh thu"].Points.Clear();
            var series = chartRevenue.Series["Doanh thu"];
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            if (currentReportType == ReportBLL.ReportType.Daily)
            {
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                var dailyRevenue = reportBLL.GetDailyRevenue(startDate, endDate);
                for (int i = 0; i < dailyRevenue.Count; i++)
                {
                    series.Points.AddXY(startDate.AddDays(i).ToString("dd/MM"), dailyRevenue[i]);
                }
                chartRevenue.ChartAreas["RevenueArea"].AxisX.Title = "Ngày";
            }
            else if (currentReportType == ReportBLL.ReportType.Monthly)
            {
                var monthlyRevenue = reportBLL.GetMonthlyRevenueTotals(dtpStartDate.Value.Year);
                for (int i = 0; i < monthlyRevenue.Count; i++)
                {
                    series.Points.AddXY($"Th{i + 1}", monthlyRevenue[i]);
                }
                chartRevenue.ChartAreas["RevenueArea"].AxisX.Title = "Tháng";
            }
            else if (currentReportType == ReportBLL.ReportType.Yearly)
            {
                int yearCount = (int)nudYearCount.Value;
                int endYear = DateTime.Now.Year;
                int startYear = endYear - yearCount + 1;
                var yearlyRevenue = reportBLL.GetYearlyRevenueTotals(startYear, yearCount);
                for (int i = 0; i < yearlyRevenue.Count; i++)
                {
                    series.Points.AddXY((startYear + i).ToString(), yearlyRevenue[i]);
                }
                chartRevenue.ChartAreas["RevenueArea"].AxisX.Title = "Năm";
            }
            else
            {
                chartRevenue.ChartAreas["RevenueArea"].AxisX.Title = string.Empty;
            }
        }

        private void LoadRevenueGrid()
        {
            if (dgvRevenue.Columns.Count == 0)
            {
                dgvRevenue.AutoGenerateColumns = false;
                dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Period",
                    HeaderText = "Kỳ",
                    DataPropertyName = "Period",
                    FillWeight = 40
                });
                dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Revenue",
                    HeaderText = "Doanh thu",
                    DataPropertyName = "Revenue",
                    FillWeight = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
                });
            }

            dgvRevenue.Rows.Clear();
            var rows = BuildCurrentRows(out _);

            foreach (var row in rows)
            {
                dgvRevenue.Rows.Add(row.Period, row.Revenue);
            }
        }

        private void ConfigureDatePickerForDay()
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.ShowUpDown = false;
        }

        private void ConfigureDatePickerForMonth()
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "MM/yyyy";
            dtpStartDate.ShowUpDown = true;
        }

        private void ConfigureDatePickerForYear()
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "yyyy";
            dtpStartDate.ShowUpDown = true;
        }

        private void ApplyVisibilityForReportType(ReportBLL.ReportType type)
        {
            if (type == ReportBLL.ReportType.Daily)
            {
                lblStartDate.Visible = true;
                dtpStartDate.Visible = true;
                lblEndDate.Visible = true;
                dtpEndDate.Visible = true;
                lblEndDate.Text = "Đến ngày:";
                nudYearCount.Visible = false;
                lblYearCount.Visible = false;
            }
            else if (type == ReportBLL.ReportType.Monthly)
            {
                lblStartDate.Visible = true;
                dtpStartDate.Visible = true;
                lblEndDate.Visible = false;
                dtpEndDate.Visible = false;
                nudYearCount.Visible = false;
                lblYearCount.Visible = false;
            }
            else if (type == ReportBLL.ReportType.Yearly)
            {
                lblStartDate.Visible = false;
                dtpStartDate.Visible = false;
                lblEndDate.Visible = false;
                dtpEndDate.Visible = false;
                nudYearCount.Visible = true;
                lblYearCount.Visible = true;
            }
        }

        private List<(string Period, int Revenue)> BuildCurrentRows(out int totalRevenue)
        {
            totalRevenue = 0;
            var rows = new List<(string Period, int Revenue)>();

            if (currentReportType == ReportBLL.ReportType.Daily)
            {
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                var dailyRevenue = reportBLL.GetDailyRevenue(startDate, endDate);
                for (int i = 0; i < dailyRevenue.Count; i++)
                {
                    rows.Add((startDate.AddDays(i).ToString("dd/MM"), dailyRevenue[i]));
                    totalRevenue += dailyRevenue[i];
                }
            }
            else if (currentReportType == ReportBLL.ReportType.Monthly)
            {
                var monthlyRevenue = reportBLL.GetMonthlyRevenueTotals(dtpStartDate.Value.Year);
                for (int i = 0; i < monthlyRevenue.Count; i++)
                {
                    rows.Add(($"Tháng {i + 1}", monthlyRevenue[i]));
                    totalRevenue += monthlyRevenue[i];
                }
            }
            else if (currentReportType == ReportBLL.ReportType.Yearly)
            {
                int yearCount = (int)nudYearCount.Value;
                int endYear = DateTime.Now.Year;
                int startYear = endYear - yearCount + 1;
                var yearlyRevenue = reportBLL.GetYearlyRevenueTotals(startYear, yearCount);
                for (int i = 0; i < yearlyRevenue.Count; i++)
                {
                    rows.Add(((startYear + i).ToString(), yearlyRevenue[i]));
                    totalRevenue += yearlyRevenue[i];
                }
            }

            return rows;
        }

        private bool EnsurePrinterAvailable()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void ExportToPdf(string filePath, List<(string Period, int Revenue)> rows, int totalRevenue)
        {
            using (var printDoc = new PrintDocument())
            {
                printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDoc.PrinterSettings.PrintToFile = true;
                printDoc.PrinterSettings.PrintFileName = filePath;
                printDoc.DefaultPageSettings.Landscape = false; // A4 portrait
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                printDoc.DefaultPageSettings.Margins = new Margins(80, 118, 80, 118); // L/T ~2cm, R/B 3cm
                printDoc.OriginAtMargins = true;

                int currentRow = 0;
                bool headerPrinted = false;

                printDoc.PrintPage += (s, e) =>
                {
                    float y = e.MarginBounds.Top;
                    float left = e.MarginBounds.Left;
                    float width = e.MarginBounds.Width;
                    var headerFont = new Font("Segoe UI", 16, FontStyle.Bold);
                    var titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
                    var normalFont = new Font("Segoe UI", 11, FontStyle.Regular);
                    var boldFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    var smallFont = new Font("Segoe UI", 9, FontStyle.Regular);

                    var fmtCenter = new StringFormat { Alignment = StringAlignment.Center };
                    var fmtRight = new StringFormat { Alignment = StringAlignment.Far };
                    var fmtLeft = new StringFormat { Alignment = StringAlignment.Near };

                    float lineHeightTitle = titleFont.GetHeight(e.Graphics);
                    float lineHeightHeader = headerFont.GetHeight(e.Graphics);
                    float lineHeightNormal = normalFont.GetHeight(e.Graphics);

                    float tableWidth = width * 0.72f;
                    float colPeriodWidth = tableWidth * 0.55f;
                    float colValueWidth = tableWidth * 0.45f;
                    float tableLeft = left;
                    float rowHeight = lineHeightNormal + 4;

                    string rangeLine;
                    if (currentReportType == ReportBLL.ReportType.Daily)
                    {
                        rangeLine = $"Từ ngày {dtpStartDate.Value:dd/MM/yyyy} đến ngày {dtpEndDate.Value:dd/MM/yyyy}";
                    }
                    else if (currentReportType == ReportBLL.ReportType.Monthly)
                    {
                        rangeLine = $"Từ tháng 01/{dtpStartDate.Value:yyyy} đến tháng 12/{dtpStartDate.Value:yyyy}";
                    }
                    else
                    {
                        int yearCount = (int)nudYearCount.Value;
                        int endYear = DateTime.Now.Year;
                        int startYear = endYear - yearCount + 1;
                        rangeLine = $"Từ năm {startYear} đến năm {endYear}";
                    }

                    if (!headerPrinted)
                    {
                        float infoLeft = left - 10;
                        float topInfoY = e.MarginBounds.Top - smallFont.GetHeight(e.Graphics) * 0.3f;
                        e.Graphics.DrawString("Nhà hàng Hương Việt", smallFont, Brushes.Black, new RectangleF(infoLeft, topInfoY, width * 0.5f, smallFont.GetHeight(e.Graphics)), fmtLeft);
                        topInfoY += smallFont.GetHeight(e.Graphics) + 2;
                        e.Graphics.DrawString("Địa chỉ: 73 Lê Văn Việt, Thủ Đức, TP Hồ Chí Minh", smallFont, Brushes.Black, new RectangleF(infoLeft, topInfoY, width * 0.6f, smallFont.GetHeight(e.Graphics)), fmtLeft);
                        topInfoY += smallFont.GetHeight(e.Graphics) + 2;
                        e.Graphics.DrawString("Hotline: 0365129405", smallFont, Brushes.Black, new RectangleF(infoLeft, topInfoY, width * 0.5f, smallFont.GetHeight(e.Graphics)), fmtLeft);

                        float centerBlockTop = topInfoY + smallFont.GetHeight(e.Graphics) * 3 + 10;
                        e.Graphics.DrawString("BÁO CÁO DOANH THU", titleFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightTitle), fmtCenter);
                        centerBlockTop += lineHeightTitle + 4;
                        e.Graphics.DrawString("NHÀ HÀNG HƯƠNG VIỆT", headerFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightHeader), fmtCenter);
                        centerBlockTop += lineHeightHeader + 6;
                        e.Graphics.DrawString(rangeLine, boldFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightNormal), fmtCenter);
                        centerBlockTop += lineHeightNormal + 10;

                        y = Math.Max(topInfoY, centerBlockTop);

                        headerPrinted = true;
                    }

                    e.Graphics.DrawString("Kỳ", boldFont, Brushes.Black, new RectangleF(left, y, colPeriodWidth, lineHeightNormal), fmtLeft);
                    e.Graphics.DrawString("Doanh thu", boldFont, Brushes.Black, new RectangleF(left + colPeriodWidth, y, colValueWidth, lineHeightNormal), fmtRight);
                    y += lineHeightNormal;
                    e.Graphics.DrawLine(Pens.Black, left, y, left + tableWidth, y);
                    y += 4;

                    while (currentRow < rows.Count)
                    {
                        var row = rows[currentRow];
                        e.Graphics.DrawString(row.Period, normalFont, Brushes.Black, new RectangleF(left, y, colPeriodWidth, rowHeight), fmtLeft);
                        e.Graphics.DrawString(row.Revenue.ToString("N0"), normalFont, Brushes.Black, new RectangleF(left + colPeriodWidth, y, colValueWidth, rowHeight), fmtRight);
                        y += rowHeight;
                        currentRow++;

                        if (y > e.MarginBounds.Bottom - 100 && currentRow < rows.Count)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }

                    y += 6;
                    e.Graphics.DrawLine(Pens.Black, left, y, left + tableWidth, y);
                    y += 6;
                    e.Graphics.DrawString("Tổng", boldFont, Brushes.Black, new RectangleF(left, y, colPeriodWidth, lineHeightNormal), fmtLeft);
                    e.Graphics.DrawString(totalRevenue.ToString("N0"), boldFont, Brushes.Black, new RectangleF(left + colPeriodWidth, y, colValueWidth, lineHeightNormal), fmtRight);
                    y += lineHeightNormal + 12;

                    float footerWidth = width * 0.45f;
                    float footerLeft = left + width - footerWidth - width * 0.1f;
                    e.Graphics.DrawString($"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}", normalFont, Brushes.Black, new RectangleF(footerLeft, y, footerWidth, lineHeightNormal), fmtRight);
                    y += lineHeightNormal + 2;
                    e.Graphics.DrawString("Người xuất báo cáo", normalFont, Brushes.Black, new RectangleF(footerLeft, y, footerWidth, lineHeightNormal), fmtRight);
                    y += lineHeightNormal * 3;
                    e.Graphics.DrawString(SessionManager.CurrentUserFullName, boldFont, Brushes.Black, new RectangleF(footerLeft, y, footerWidth, lineHeightNormal), fmtRight);

                    e.HasMorePages = false;
                };

                printDoc.Print();
            }
        }
    }
}
