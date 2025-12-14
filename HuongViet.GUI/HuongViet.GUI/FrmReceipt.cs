using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmReceipt : Form
    {
        private Order order;
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public FrmReceipt(Order order)
        {
            InitializeComponent();
            this.order = order;
            InitializePrintDocument();
        }

        private void InitializePrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            
            // Set paper size for receipt (80mm thermal paper or A4)
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 300, 800);
            printDocument.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float width = e.MarginBounds.Width;
            
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font normalFont = new Font("Arial", 9, FontStyle.Regular);
            Font smallFont = new Font("Arial", 8, FontStyle.Regular);
            
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far };
            
            // Title
            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", titleFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width, titleFont.GetHeight()), centerFormat);
            yPos += titleFont.GetHeight() + 10;
            
            // Line
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 10;
            
            // Order Info
            e.Graphics.DrawString($"Mã đơn: {order.OrderID}", normalFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
            yPos += normalFont.GetHeight() + 3;
            
            e.Graphics.DrawString($"Ngày: {order.OrderDate:dd/MM/yyyy HH:mm}", normalFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
            yPos += normalFont.GetHeight() + 3;
            
            if (!string.IsNullOrEmpty(order.TableID) && order.Table != null)
            {
                e.Graphics.DrawString($"Bàn: {order.Table.TableName}", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
                yPos += normalFont.GetHeight() + 3;
            }
            
            // Customer Info
            if (!string.IsNullOrEmpty(order.CustomerName))
            {
                e.Graphics.DrawString($"Khách hàng: {order.CustomerName}", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
                yPos += normalFont.GetHeight() + 3;
            }
            
            if (!string.IsNullOrEmpty(order.CustomerPhone))
            {
                e.Graphics.DrawString($"SĐT: {order.CustomerPhone}", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
                yPos += normalFont.GetHeight() + 3;
            }
            
            yPos += 5;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 10;
            
            // Order Details Header
            e.Graphics.DrawString("Tên món", headerFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width * 0.4f, headerFont.GetHeight()), leftFormat);
            e.Graphics.DrawString("SL", headerFont, Brushes.Black, 
                new RectangleF(leftMargin + width * 0.4f, yPos, width * 0.15f, headerFont.GetHeight()), centerFormat);
            e.Graphics.DrawString("Đơn giá", headerFont, Brushes.Black, 
                new RectangleF(leftMargin + width * 0.55f, yPos, width * 0.2f, headerFont.GetHeight()), rightFormat);
            e.Graphics.DrawString("Thành tiền", headerFont, Brushes.Black, 
                new RectangleF(leftMargin + width * 0.75f, yPos, width * 0.25f, headerFont.GetHeight()), rightFormat);
            yPos += headerFont.GetHeight() + 5;
            
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 5;
            
            // Order Details
            decimal subtotal = 0;
            decimal totalDiscount = 0;
            
            if (order.OrderDetails != null)
            {
                foreach (var detail in order.OrderDetails)
                {
                    string itemName = detail.Item?.ItemName ?? detail.ItemID;
                    if (itemName.Length > 20)
                        itemName = itemName.Substring(0, 17) + "...";
                    
                    // Item name (may wrap to multiple lines)
                    RectangleF nameRect = new RectangleF(leftMargin, yPos, width * 0.4f, normalFont.GetHeight() * 2);
                    e.Graphics.DrawString(itemName, normalFont, Brushes.Black, nameRect, leftFormat);
                    
                    e.Graphics.DrawString(detail.Quantity.ToString(), normalFont, Brushes.Black, 
                        new RectangleF(leftMargin + width * 0.4f, yPos, width * 0.15f, normalFont.GetHeight()), centerFormat);
                    
                    e.Graphics.DrawString(detail.UnitPrice.ToString("N0"), normalFont, Brushes.Black, 
                        new RectangleF(leftMargin + width * 0.55f, yPos, width * 0.2f, normalFont.GetHeight()), rightFormat);
                    
                    e.Graphics.DrawString(detail.TotalAmount.ToString("N0"), normalFont, Brushes.Black, 
                        new RectangleF(leftMargin + width * 0.75f, yPos, width * 0.25f, normalFont.GetHeight()), rightFormat);
                    
                    decimal itemSubtotal = detail.UnitPrice * detail.Quantity;
                    subtotal += itemSubtotal;
                    totalDiscount += itemSubtotal - detail.TotalAmount;
                    
                    yPos += normalFont.GetHeight() + 2;
                    
                    // Show discount if applied
                    if (detail.Discount > 0)
                    {
                        e.Graphics.DrawString($"  Giảm {detail.Discount:N0}%", smallFont, Brushes.Black, 
                            new RectangleF(leftMargin + width * 0.4f, yPos, width * 0.6f, smallFont.GetHeight()), leftFormat);
                        yPos += smallFont.GetHeight() + 2;
                    }
                }
            }
            
            yPos += 5;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 10;
            
            // Totals
            e.Graphics.DrawString("Tạm tính:", normalFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width * 0.7f, normalFont.GetHeight()), leftFormat);
            e.Graphics.DrawString(subtotal.ToString("N0"), normalFont, Brushes.Black, 
                new RectangleF(leftMargin + width * 0.7f, yPos, width * 0.3f, normalFont.GetHeight()), rightFormat);
            yPos += normalFont.GetHeight() + 3;
            
            if (totalDiscount > 0)
            {
                e.Graphics.DrawString("Giảm giá:", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin, yPos, width * 0.7f, normalFont.GetHeight()), leftFormat);
                e.Graphics.DrawString($"-{totalDiscount:N0}", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin + width * 0.7f, yPos, width * 0.3f, normalFont.GetHeight()), rightFormat);
                yPos += normalFont.GetHeight() + 3;
            }
            
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 5;
            
            e.Graphics.DrawString("TỔNG CỘNG:", headerFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width * 0.7f, headerFont.GetHeight()), leftFormat);
            e.Graphics.DrawString(order.TotalAmount.ToString("N0") + " đ", headerFont, Brushes.Black, 
                new RectangleF(leftMargin + width * 0.7f, yPos, width * 0.3f, headerFont.GetHeight()), rightFormat);
            yPos += headerFont.GetHeight() + 10;
            
            // Payment Method
            if (order.PaymentMethod.HasValue)
            {
                string paymentMethod = order.PaymentMethod.Value == PaymentMethod.Cash ? "Tiền mặt" : "Chuyển khoản";
                e.Graphics.DrawString($"Phương thức: {paymentMethod}", normalFont, Brushes.Black, 
                    new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), leftFormat);
                yPos += normalFont.GetHeight() + 5;
            }
            
            yPos += 5;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + width, yPos);
            yPos += 10;
            
            // Footer
            e.Graphics.DrawString("Cảm ơn quý khách!", normalFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width, normalFont.GetHeight()), centerFormat);
            yPos += normalFont.GetHeight() + 3;
            
            e.Graphics.DrawString("Hẹn gặp lại!", smallFont, Brushes.Black, 
                new RectangleF(leftMargin, yPos, width, smallFont.GetHeight()), centerFormat);
        }

        public void ShowPreview()
        {
            printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                WindowState = FormWindowState.Maximized
            };
            printPreviewDialog.ShowDialog();
        }

        public void Print()
        {
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };
            
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}

