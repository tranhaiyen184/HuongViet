using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmBestSellingReport : Form
    {
        private readonly ReportBLL reportBLL = new ReportBLL();
        private ReportBLL.ReportType currentReportType = ReportBLL.ReportType.Daily;
        private List<ReportingBestSellingItem> currentItems = new List<ReportingBestSellingItem>();

        public FrmBestSellingReport()
        {
            Text = "Báo cáo sản phẩm bán chạy";
            Width = 1600;
            Height = 900;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeLogic();
            LoadReport();
        }

        private void InitializeLogic()
        {
            dtpDate.Value = DateTime.Now.Date;
            pnlDateRange.Visible = true;

            ConfigureGrid();

        }

        private void ReportType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDaily.Checked)
            {
                currentReportType = ReportBLL.ReportType.Daily;
                pnlDateRange.Visible = true;
                ConfigureDatePickerForDay();
                lblDate.Text = "Ngày:";
            }
            else if (rdoWeekly.Checked)
            {
                currentReportType = ReportBLL.ReportType.Monthly;
                pnlDateRange.Visible = true;
                ConfigureDatePickerForMonth();
                lblDate.Text = "Tháng:";
            }
            else if (rdoMonthly.Checked)
            {
                currentReportType = ReportBLL.ReportType.Yearly;
                pnlDateRange.Visible = true;
                ConfigureDatePickerForYear();
                lblDate.Text = "Năm:";
            }
            LoadReport();
        }

        private void DateRange_ValueChanged(object sender, EventArgs e)
        {
            // Removed date clamping logic
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (currentReportType == ReportBLL.ReportType.Daily)
            {
                dtpDate.Value = DateTime.Now.Date;
            }
            LoadReport();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReportingBestSellingItem> bestSellingItems;
                DateTime selectedDate = dtpDate.Value.Date;

                if (currentReportType == ReportBLL.ReportType.Daily)
                {
                    bestSellingItems = reportBLL.GetBestSalerItems(selectedDate, selectedDate);
                }
                else if (currentReportType == ReportBLL.ReportType.Monthly)
                {
                    var monthStart = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                    var monthEnd = monthStart.AddMonths(1).AddTicks(-1);
                    bestSellingItems = reportBLL.GetBestSalerItems(monthStart, monthEnd);
                }
                else if (currentReportType == ReportBLL.ReportType.Yearly)
                {
                    var yearStart = new DateTime(selectedDate.Year, 1, 1);
                    var yearEnd = yearStart.AddYears(1).AddTicks(-1);
                    bestSellingItems = reportBLL.GetBestSalerItems(yearStart, yearEnd);
                }
                else
                {
                    bestSellingItems = reportBLL.GetBestSalerItems(currentReportType);
                }

                currentItems = bestSellingItems ?? new List<ReportingBestSellingItem>();

                dgvBestSelling.DataSource = null;
                dgvBestSelling.DataSource = currentItems;

                LoadTopSellingChart(currentItems);

                lblLastUpdate.Text = "Cập nhật lúc: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ConfigureGrid()
        {
            dgvBestSelling.AutoGenerateColumns = false;
            dgvBestSelling.Columns.Clear();

            dgvBestSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colItemId",
                HeaderText = "Mã sản phẩm",
                DataPropertyName = "ItemID",
                FillWeight = 20,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvBestSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colItemName",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "ItemName",
                FillWeight = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvBestSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Số lượng bán ra",
                DataPropertyName = "TotalQuantitySold",
                FillWeight = 20,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvBestSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRevenue",
                HeaderText = "Tổng doanh thu",
                DataPropertyName = "TotalRevenue",
                FillWeight = 20,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Format = "N0" }
            });
        }

        private void ConfigureDatePickerForDay()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.ShowUpDown = false;
        }

        private void ConfigureDatePickerForMonth()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/yyyy";
            dtpDate.ShowUpDown = true;
        }

        private void ConfigureDatePickerForYear()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "yyyy";
            dtpDate.ShowUpDown = true;
        }

        private void LoadTopSellingChart(List<ReportingBestSellingItem> bestSellingItems)
        {
            // Show top 10 items by quantity on a pie chart
            var chartArea = chartRevenue.ChartAreas["RevenueArea"];
            chartArea.AxisX.Title = string.Empty;
            chartArea.AxisY.Title = string.Empty;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = 0;

            chartRevenue.Series.Clear();
            var series = new Series("Số lượng bán")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P1}",
                LegendText = "#VALX ( #VALY )",
                Color = Color.FromArgb(52, 152, 219)
            };

            foreach (var item in bestSellingItems.OrderByDescending(x => x.TotalQuantitySold).Take(10))
            {
                series.Points.AddXY(item.ItemName, item.TotalQuantitySold);
            }

            chartRevenue.Series.Add(series);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (!EnsurePrinterAvailable())
            {
                MessageBox.Show("Máy in Microsoft Print to PDF không khả dụng. Vui lòng kiểm tra lại cấu hình in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rows = BuildCurrentRows(out int totalQuantity, out decimal totalRevenue);
            if (rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "PDF (*.pdf)|*.pdf";
                dialog.FileName = $"{DateTime.Now:ddMMyy}BCSanPhamBanChay.pdf";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ExportToPdf(dialog.FileName, rows, totalQuantity, totalRevenue);
                    MessageBox.Show("Xuất báo cáo thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xuất báo cáo thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<(string ItemName, int Quantity, decimal Revenue)> BuildCurrentRows(out int totalQuantity, out decimal totalRevenue)
        {
            totalQuantity = 0;
            totalRevenue = 0;
            var rows = new List<(string ItemName, int Quantity, decimal Revenue)>();

            foreach (var item in currentItems.OrderByDescending(x => x.TotalQuantitySold))
            {
                rows.Add(($"{item.ItemID} - {item.ItemName}", item.TotalQuantitySold, item.TotalRevenue));
                totalQuantity += item.TotalQuantitySold;
                totalRevenue += item.TotalRevenue;
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

        private void ExportToPdf(string filePath, List<(string ItemName, int Quantity, decimal Revenue)> rows, int totalQuantity, decimal totalRevenue)
        {
            using (var printDoc = new PrintDocument())
            {
                printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDoc.PrinterSettings.PrintToFile = true;
                printDoc.PrinterSettings.PrintFileName = filePath;
                printDoc.DefaultPageSettings.Landscape = false; // A4 portrait
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(80, 118, 80, 118);
                printDoc.OriginAtMargins = true;

                int currentRow = 0;
                bool headerPrinted = false;

                printDoc.PrintPage += (s, e) =>
                {
                    float y = e.MarginBounds.Top;
                    float left = e.MarginBounds.Left;
                    float width = e.MarginBounds.Width;
                    var titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
                    var headerFont = new Font("Segoe UI", 16, FontStyle.Bold);
                    var normalFont = new Font("Segoe UI", 11, FontStyle.Regular);
                    var boldFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    var smallFont = new Font("Segoe UI", 9, FontStyle.Regular);

                    var fmtCenter = new StringFormat { Alignment = StringAlignment.Center };
                    var fmtRight = new StringFormat { Alignment = StringAlignment.Far };
                    var fmtLeft = new StringFormat { Alignment = StringAlignment.Near };

                    float lineHeightTitle = titleFont.GetHeight(e.Graphics);
                    float lineHeightHeader = headerFont.GetHeight(e.Graphics);
                    float lineHeightNormal = normalFont.GetHeight(e.Graphics);

                    float tableWidth = width * 0.9f;
                    float colNameWidth = tableWidth * 0.55f;
                    float colQtyWidth = tableWidth * 0.15f;
                    float colRevenueWidth = tableWidth * 0.3f;
                    float tableLeft = left;
                    float rowHeight = lineHeightNormal + 4;

                    string rangeLine;
                    if (currentReportType == ReportBLL.ReportType.Daily)
                    {
                        rangeLine = $"Ngày {dtpDate.Value:dd/MM/yyyy}";
                    }
                    else if (currentReportType == ReportBLL.ReportType.Monthly)
                    {
                        rangeLine = $"Tháng {dtpDate.Value:MM/yyyy}";
                    }
                    else
                    {
                        rangeLine = $"Năm {dtpDate.Value:yyyy}";
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
                        e.Graphics.DrawString("BÁO CÁO SẢN PHẨM BÁN CHẠY", titleFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightTitle), fmtCenter);
                        centerBlockTop += lineHeightTitle + 4;
                        e.Graphics.DrawString("NHÀ HÀNG HƯƠNG VIỆT", headerFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightHeader), fmtCenter);
                        centerBlockTop += lineHeightHeader + 6;
                        e.Graphics.DrawString(rangeLine, boldFont, Brushes.Black, new RectangleF(tableLeft, centerBlockTop, tableWidth, lineHeightNormal), fmtCenter);
                        centerBlockTop += lineHeightNormal + 10;

                        y = Math.Max(topInfoY, centerBlockTop);

                        headerPrinted = true;
                    }

                    e.Graphics.DrawString("Sản phẩm", boldFont, Brushes.Black, new RectangleF(left, y, colNameWidth, lineHeightNormal), fmtLeft);
                    e.Graphics.DrawString("Số lượng", boldFont, Brushes.Black, new RectangleF(left + colNameWidth, y, colQtyWidth, lineHeightNormal), fmtRight);
                    e.Graphics.DrawString("Doanh thu", boldFont, Brushes.Black, new RectangleF(left + colNameWidth + colQtyWidth, y, colRevenueWidth, lineHeightNormal), fmtRight);
                    y += lineHeightNormal;
                    e.Graphics.DrawLine(Pens.Black, left, y, left + tableWidth, y);
                    y += 4;

                    while (currentRow < rows.Count)
                    {
                        var row = rows[currentRow];
                        e.Graphics.DrawString(row.ItemName, normalFont, Brushes.Black, new RectangleF(left, y, colNameWidth, rowHeight), fmtLeft);
                        e.Graphics.DrawString(row.Quantity.ToString("N0"), normalFont, Brushes.Black, new RectangleF(left + colNameWidth, y, colQtyWidth, rowHeight), fmtRight);
                        e.Graphics.DrawString(row.Revenue.ToString("N0"), normalFont, Brushes.Black, new RectangleF(left + colNameWidth + colQtyWidth, y, colRevenueWidth, rowHeight), fmtRight);
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
                    e.Graphics.DrawString("Tổng", boldFont, Brushes.Black, new RectangleF(left, y, colNameWidth, lineHeightNormal), fmtLeft);
                    e.Graphics.DrawString(totalQuantity.ToString("N0"), boldFont, Brushes.Black, new RectangleF(left + colNameWidth, y, colQtyWidth, lineHeightNormal), fmtRight);
                    e.Graphics.DrawString(totalRevenue.ToString("N0"), boldFont, Brushes.Black, new RectangleF(left + colNameWidth + colQtyWidth, y, colRevenueWidth, lineHeightNormal), fmtRight);
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
