using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmPOS : Form
    {
        private readonly POSBLL posBLL;
        private readonly AuthBLL authBLL;
        private readonly VoucherBLL voucherBLL;
        
        private List<Area> areas;
        private List<Table> tables;
        private List<Item> items;
        private List<OrderDetail> currentOrderDetails;
        private Table selectedTable;
        private string currentStaffId;
        private Voucher currentVoucher;

        public FrmPOS()
        {
            InitializeComponent();
            posBLL = new POSBLL();
            authBLL = new AuthBLL();
            voucherBLL = new VoucherBLL();
            currentOrderDetails = new List<OrderDetail>();
            
            InitializeForm();
            LoadAreas();
            LoadTables();
            LoadItems();
        }

        private void InitializeForm()
        {
            currentStaffId = SessionManager.CurrentUserID;
            
            if (string.IsNullOrEmpty(currentStaffId))
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên. Vui lòng đăng nhập lại.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                currentStaffId = "USER001";
            }
            
            SetupTablesDataGridView();
            SetupItemsGrid();
            SetupOrderDataGridView();
            
            tabControlTables.SelectedIndexChanged += TabControlTables_SelectedIndexChanged;
            tabControlMenu.SelectedIndexChanged += TabControlMenu_SelectedIndexChanged;
            
            this.Resize += FrmPOS_Resize;
            this.Load += FrmPOS_Load;
            
            // Setup voucher and payment textbox events
            txbVoucher.Leave += TxbVoucher_Leave;
            txbCustomerMoney.TextChanged += TxbCustomerMoney_TextChanged;
            
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblTotalAmount.Text = "0";
            lblTableInfo.Text = "Chưa chọn bàn";
            lblFormOfService.Visible = true;
            
            // Initialize form of service ComboBox
            cmbFormOfService.Items.Clear();
            cmbFormOfService.Items.Add("Tại chỗ");
            cmbFormOfService.Items.Add("Mang đi");
            cmbFormOfService.SelectedIndex = 0; // Default to "Tại chỗ" (DineIn)
            cmbFormOfService.Enabled = false; // Disabled until table is selected
            
            // Initialize voucher and payment fields
            currentVoucher = null;
            lblDiscountAmount.Text = "0.000 (-0%)";
            lblGrandTotalAmount.Text = "0.000";
            lblChangeAmount.Text = "0.000";
            
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timer.Start();
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void FrmPOS_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            splitContainerMain.Size = new Size(formWidth, formHeight);
            splitContainerMain.SplitterDistance = formHeight / 2; 

            int panel1Height = splitContainerMain.Panel1.Height;
            
            pnlLeft.Size = new Size(400, panel1Height);
            
            int rightWidth = formWidth - 400;
            pnlRight.Location = new Point(400, 0);
            pnlRight.Size = new Size(rightWidth, panel1Height);
            
            tabControlTables.Size = new Size(400, panel1Height);
            
            tabControlMenu.Size = new Size(rightWidth, panel1Height);

            int panel2Height = splitContainerMain.Panel2.Height;
            
            pnlOrderHeader.Size = new Size(formWidth, 40);
            
            dgvOrder.Size = new Size(formWidth, panel2Height - 100); 
            
            pnlOrderFooter.Location = new Point(0, panel2Height - 60);
            pnlOrderFooter.Size = new Size(formWidth, 60);
            
            lblDateTime.Location = new Point(formWidth - 150, 10);
            
            btnPayment.Location = new Point(formWidth - 200, 10);
            btnSaveOrder.Location = new Point(formWidth - 400, 10);
        }

        private void SetupTablesDataGridView()
        {
            dgvTables.AutoGenerateColumns = false;
            dgvTables.AllowUserToAddRows = false;
            dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTables.MultiSelect = false;
            dgvTables.ReadOnly = true;
            
            dgvTables.Columns.Clear();
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TableName",
                HeaderText = "Tên bàn",
                DataPropertyName = "TableName",
                Width = 150
            });
            
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AreaName",
                HeaderText = "Khu vực",
                DataPropertyName = null, 
                Width = 150
            });
            
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                DataPropertyName = "TableStatus",
                Width = 120
            });
            
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Capacity",
                HeaderText = "Sức chứa",
                DataPropertyName = "Capacity",
                Width = 100
            });
            
            dgvTables.CellFormatting += DgvTables_CellFormatting;
            dgvTables.CellDoubleClick += DgvTables_CellDoubleClick;
            dgvTables.SelectionChanged += DgvTables_SelectionChanged;
        }

        private void SetupItemsGrid()
        {
            flowLayoutItems.AutoScroll = true;
            flowLayoutItems.WrapContents = true;
            flowLayoutItems.FlowDirection = FlowDirection.LeftToRight;
        }

        private void SetupOrderDataGridView()
        {
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrder.ReadOnly = false;
            
            dgvOrder.Columns.Clear();
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemName",
                HeaderText = "Tên món",
                Width = 200,
                ReadOnly = true
            });
            
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "SL",
                Width = 60
            });
            
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });
            
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Thành tiền",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });
            
            dgvOrder.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 60
            });
            
            dgvOrder.CellValueChanged += DgvOrder_CellValueChanged;
            dgvOrder.CellContentClick += DgvOrder_CellContentClick;
        }

        private void LoadAreas()
        {
            try
            {
                areas = posBLL.GetAllAreas();
                
                cmbAreaFilter.Items.Clear();
                cmbAreaFilter.Items.Add("Tất cả");
                foreach (var area in areas)
                {
                    cmbAreaFilter.Items.Add(area.AreaName);
                }
                cmbAreaFilter.SelectedIndex = 0;
                cmbAreaFilter.SelectedIndexChanged += CmbAreaFilter_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khu vực: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
            try
            {
                string areaId = null;
                if (cmbAreaFilter.SelectedIndex > 0 && areas != null)
                {
                    areaId = areas[cmbAreaFilter.SelectedIndex - 1].AreaID;
                }
                tables = posBLL.GetAllTables(areaId);

                DisplayTablesAsCards();

                try { dgvTables.DataSource = tables; } catch { }

                lblTableCount.Text = $"{tables.Count} bàn";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTablesAsCards()
        {
            try
            {
                if (flowLayoutTables == null)
                {
                    return;
                }

                flowLayoutTables.Controls.Clear();

                if (tables == null || tables.Count == 0)
                {
                    return;
                }

                int btnWidth = 100;
                int btnHeight = 70;
                int margin = 8;

                foreach (var table in tables)
                {
                    Button btn = new Button
                    {
                        Width = btnWidth,
                        Height = btnHeight,
                        Text = table.TableName,
                        Tag = table,
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(margin),
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    };

                    SetTableButtonColor(btn, table);

                    btn.MouseEnter += (s, e) => { ((Button)s).FlatAppearance.BorderSize = 2; };
                    btn.MouseLeave += (s, e) => { ((Button)s).FlatAppearance.BorderSize = 1; };

                    btn.Click += (s, e) =>
                    {
                        var clickedTable = (s as Button)?.Tag as Table;
                        if (clickedTable != null)
                        {
                            selectedTable = clickedTable;
                            LoadTableOrder();
                            HighlightSelectedTable();
                        }
                    };

                    flowLayoutTables.Controls.Add(btn);
                }
               
                HighlightSelectedTable();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error displaying table cards: {ex.Message}");
            }
        }

        private void SetTableButtonColor(Button btn, Table table)
        {
            bool isSelected = selectedTable != null && selectedTable.TableID == table.TableID;
            
            bool hasOrder = !string.IsNullOrWhiteSpace(table.CurrentOrderID);
            
            if (isSelected)
            {
                btn.BackColor = Color.FromArgb(0x4A, 0x90, 0xE2); 
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 3;
                btn.FlatAppearance.BorderColor = Color.DarkBlue;
            }
            else if (hasOrder)
            {
                btn.BackColor = Color.FromArgb(0xFF, 0xB3, 0x47); 
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = Color.DarkOrange;
            }
            else if (table.TableStatus == TableStatus.Available)
            {
                btn.BackColor = Color.FromArgb(0xE6, 0xEE, 0xD8); 
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }
            else
            {
                btn.BackColor = Color.FromArgb(0xF8, 0xD7, 0xD4);
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }
        }

        private void HighlightSelectedTable()
        {
            if (flowLayoutTables == null) return;
            
            foreach (Control control in flowLayoutTables.Controls)
            {
                if (control is Button btn && btn.Tag is Table table)
                {
                    SetTableButtonColor(btn, table);
                }
            }
        }

        private void LoadItems()
        {
            try
            {
                var allItems = posBLL.GetAllItems(null);
                items = allItems.Where(i => i.ItemType == ItemType.ThucAn || i.ItemType == ItemType.NuocUong).ToList();
                
                DisplayItemsAsCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayItemsAsCards()
        {
            flowLayoutItems.Controls.Clear();
            
            if (items == null || items.Count == 0)
            {
                return;
            }
            
            int cardWidth = 180;
            int cardHeight = 200;
            int spacing = 10;
            
            foreach (var item in items)
            {
                Panel cardPanel = new Panel
                {
                    Width = cardWidth,
                    Height = cardHeight,
                    Margin = new Padding(spacing),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Cursor = Cursors.Hand
                };
                
                cardPanel.MouseEnter += (s, e) => 
                {
                    cardPanel.BackColor = Color.LightBlue;
                    cardPanel.BorderStyle = BorderStyle.Fixed3D;
                };
                cardPanel.MouseLeave += (s, e) => 
                {
                    cardPanel.BackColor = Color.White;
                    cardPanel.BorderStyle = BorderStyle.FixedSingle;
                };
                
                EventHandler addItemHandler = (s, e) => AddItemToOrder(item);
                
                cardPanel.Click += addItemHandler;
                
                PictureBox picItem = new PictureBox
                {
                    Width = cardWidth - 20,
                    Height = 120,
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };
                
                picItem.Click += addItemHandler;
                
                if (!string.IsNullOrWhiteSpace(item.ItemImage))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(item.ItemImage);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            var tempImage = Image.FromStream(ms);
                            picItem.Image = new Bitmap(tempImage);
                        }
                    }
                    catch
                    {
                        picItem.BackColor = Color.LightGray;
                    }
                }
                else
                {
                    picItem.BackColor = Color.LightGray;
                }
                
                Label lblItemName = new Label
                {
                    Text = item.ItemName,
                    Location = new Point(5, 135),
                    Width = cardWidth - 10,
                    Height = 30,
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopCenter,
                    Cursor = Cursors.Hand
                };
                
                if (item.ItemName.Length > 20)
                {
                    lblItemName.Text = item.ItemName.Substring(0, 17) + "...";
                }
                
                lblItemName.Click += addItemHandler;
                
                Label lblPrice = new Label
                {
                    Text = item.ItemPrice.ToString("N0") + " đ",
                    Location = new Point(5, 165),
                    Width = cardWidth - 10,
                    Height = 25,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                    ForeColor = Color.Red,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };
                
                lblPrice.Click += addItemHandler;
                
                cardPanel.Controls.Add(picItem);
                cardPanel.Controls.Add(lblItemName);
                cardPanel.Controls.Add(lblPrice);
                
                flowLayoutItems.Controls.Add(cardPanel);
            }
        }

        private void RefreshOrderDisplay()
        {
            dgvOrder.Rows.Clear();
            
            foreach (var detail in currentOrderDetails)
            {
                var item = items?.FirstOrDefault(i => i.ItemID == detail.ItemID);
                int rowIndex = dgvOrder.Rows.Add(
                    item?.ItemName ?? detail.ItemID,
                    detail.Quantity,
                    detail.UnitPrice,
                    detail.TotalAmount
                );
                
                dgvOrder.Rows[rowIndex].Tag = detail;
            }
            
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = currentOrderDetails.Sum(d => d.TotalAmount);
            lblTotalAmount.Text = total.ToString("N0");
            UpdateVoucherCalculations();
        }

        private void UpdateVoucherCalculations()
        {
            decimal total = currentOrderDetails.Sum(d => d.TotalAmount);
            decimal discountAmount = 0;
            decimal discountPercentage = 0;

            if (currentVoucher != null && voucherBLL.IsVoucherValid(currentVoucher))
            {
                discountAmount = voucherBLL.CalculateDiscount(currentVoucher, total);
                discountPercentage = currentVoucher.Percentage;
            }

            decimal grandTotal = total - discountAmount;

            // Update discount label: format as "discount amount (- percentage %)"
            lblDiscountAmount.Text = $"{discountAmount:N0} (-{discountPercentage:N0}%)";

            // Update grand total
            lblGrandTotalAmount.Text = grandTotal.ToString("N0");

            // Update change if customer money is entered
            UpdateChange();
        }

        private void UpdateChange()
        {
            // Handle Vietnamese number format: dots are thousand separators, commas are decimal separators
            string customerMoneyText = txbCustomerMoney.Text.Trim();
            // Remove dots (thousand separators) and replace comma with dot for decimal parsing
            customerMoneyText = customerMoneyText.Replace(".", "").Replace(",", ".");
            
            if (decimal.TryParse(customerMoneyText, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, out decimal customerMoney))
            {
                decimal total = currentOrderDetails.Sum(d => d.TotalAmount);
                decimal discountAmount = 0;

                if (currentVoucher != null && voucherBLL.IsVoucherValid(currentVoucher))
                {
                    discountAmount = voucherBLL.CalculateDiscount(currentVoucher, total);
                }

                decimal grandTotal = total - discountAmount;
                decimal change = customerMoney - grandTotal;
                lblChangeAmount.Text = change >= 0 ? change.ToString("N0") : "0";
            }
            else
            {
                lblChangeAmount.Text = "0.000";
            }
        }

        private void TxbVoucher_Leave(object sender, EventArgs e)
        {
            string voucherCode = txbVoucher.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(voucherCode))
            {
                currentVoucher = null;
                UpdateVoucherCalculations();
                return;
            }

            try
            {
                currentVoucher = voucherBLL.GetByCode(voucherCode);
                
                if (currentVoucher == null)
                {
                    MessageBox.Show("Không tìm thấy voucher với mã này.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbVoucher.Text = "";
                    currentVoucher = null;
                    UpdateVoucherCalculations();
                    return;
                }

                if (!voucherBLL.IsVoucherValid(currentVoucher))
                {
                    MessageBox.Show("Voucher không hợp lệ hoặc đã hết hạn.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbVoucher.Text = "";
                    currentVoucher = null;
                    UpdateVoucherCalculations();
                    return;
                }

                UpdateVoucherCalculations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm voucher: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbVoucher.Text = "";
                currentVoucher = null;
                UpdateVoucherCalculations();
            }
        }

        private void TxbCustomerMoney_TextChanged(object sender, EventArgs e)
        {
            UpdateChange();
        }

        private void CmbAreaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void TabControlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TabControlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DgvTables_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTables.Rows[e.RowIndex].DataBoundItem is Table table)
            {
                if (dgvTables.Columns[e.ColumnIndex].Name == "Status")
                {
                    e.Value = table.TableStatus == TableStatus.Available ? "Trống" : "Đang sử dụng";
                    e.CellStyle.BackColor = table.TableStatus == TableStatus.Available ? Color.LightGreen : Color.LightCoral;
                }
                else if (dgvTables.Columns[e.ColumnIndex].Name == "AreaName")
                {
                    e.Value = table.Area?.AreaName ?? "";
                }
            }
        }

        private void DgvTables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedTable = dgvTables.Rows[e.RowIndex].DataBoundItem as Table;
                LoadTableOrder();
            }
        }

        private void DgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count > 0)
            {
                selectedTable = dgvTables.SelectedRows[0].DataBoundItem as Table;
                LoadTableOrder();
            }
        }

        private void LoadTableOrder()
        {
            if (selectedTable == null) return;
            
            try
            {
                var tableInfo = posBLL.GetTableInfo(selectedTable.TableID);
                
                selectedTable = tableInfo.Table;
                
                lblTableInfo.Text = $"Bàn: {selectedTable.TableName} - {selectedTable.Area?.AreaName ?? ""}";
                cmbFormOfService.Enabled = true; // Enable when table is selected
                
                if (tableInfo.CurrentOrder != null)
                {
                    currentOrderDetails = tableInfo.OrderDetails.ToList();
                    
                    // Update form of service ComboBox
                    if (tableInfo.CurrentOrder.FormOfService == FormOfService.DineIn)
                    {
                        cmbFormOfService.SelectedIndex = 0; // "Tại chỗ"
                    }
                    else
                    {
                        cmbFormOfService.SelectedIndex = 1; // "Mang đi"
                    }
                    
                    if (tableInfo.CurrentOrder.Customer != null)
                    {
                        txtCustomerName.Text = tableInfo.CurrentOrder.Customer.CustomerName ?? "";
                        txtCustomerPhone.Text = tableInfo.CurrentOrder.Customer.CustomerPhoneNum ?? "";
                    }
                    else
                    {
                        txtCustomerName.Text = tableInfo.CurrentOrder.CustomerName ?? "";
                        txtCustomerPhone.Text = tableInfo.CurrentOrder.CustomerPhone ?? "";
                    }
                    
                    RefreshOrderDisplay();
                }
                else
                {
                    currentOrderDetails.Clear();
                    txtCustomerName.Text = "";
                    txtCustomerPhone.Text = "";
                    currentVoucher = null;
                    txbVoucher.Text = "";
                    txbCustomerMoney.Text = "";
                    cmbFormOfService.SelectedIndex = 0; // Reset to default "Tại chỗ"
                    RefreshOrderDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddItemToOrder(Item item)
        {
            if (item == null)
            {
                return;
            }
            
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var existingDetail = currentOrderDetails.FirstOrDefault(d => d.ItemID == item.ItemID);
            
            if (existingDetail != null)
            {
                existingDetail.Quantity++;
                existingDetail.TotalAmount = existingDetail.UnitPrice * existingDetail.Quantity;
            }
            else
            {
                var detail = new OrderDetail
                {
                    ItemID = item.ItemID,
                    Quantity = 1,
                    UnitPrice = item.ItemPrice,
                    TotalAmount = item.ItemPrice,
                    Discount = 0
                };
                currentOrderDetails.Add(detail);
            }
            
            RefreshOrderDisplay();
        }

        private void DgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrder.Columns["Quantity"].Index)
            {
                var row = dgvOrder.Rows[e.RowIndex];
                var detail = row.Tag as OrderDetail;
                
                if (detail != null)
                {
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int quantity))
                    {
                        if (quantity > 0)
                        {
                            detail.Quantity = quantity;
                            detail.TotalAmount = detail.UnitPrice * quantity;
                            row.Cells["TotalAmount"].Value = detail.TotalAmount;
                            CalculateTotal();
                        }
                        else
                        {
                            MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            row.Cells["Quantity"].Value = detail.Quantity;
                        }
                    }
                }
            }
        }

        private void DgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrder.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var detail = dgvOrder.Rows[e.RowIndex].Tag as OrderDetail;
                if (detail != null)
                {
                    currentOrderDetails.Remove(detail);
                    RefreshOrderDisplay();
                }
            }
        }


        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            string searchTerm = txtCustomerPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = txtCustomerName.Text.Trim();
            }
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                try
                {
                    var customer = posBLL.SearchCustomer(searchTerm);
                    if (customer != null)
                    {
                        txtCustomerName.Text = customer.CustomerName;
                        txtCustomerPhone.Text = customer.CustomerPhoneNum;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveOrder_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (currentOrderDetails.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm món vào đơn hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string customerName = txtCustomerName.Text.Trim();
                string customerPhone = txtCustomerPhone.Text.Trim();
                
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    customerName = "Khách vãng lai";
                }
                
                if (string.IsNullOrWhiteSpace(customerPhone))
                {
                    customerPhone = "0900000000";
                }
                
              
                Customer customer = null;
                if (!string.IsNullOrWhiteSpace(customerPhone) && customerPhone != "0900000000")
                {
                    customer = posBLL.SearchCustomer(customerPhone);
                    if (customer == null)
                    {
                        customer = posBLL.SearchCustomer(customerPhone); 
                        if (customer == null && !string.IsNullOrWhiteSpace(customerName))
                        {
                            customer = new CustomerBLL().CreateQuickCustomer(customerName, customerPhone);
                        }
                    }
                }
                
                string orderId = selectedTable.CurrentOrderID;
                if (string.IsNullOrWhiteSpace(orderId))
                {
                    orderId = new OrderBLL().GenerateNewOrderID();
                }
                
                foreach (var detail in currentOrderDetails)
                {
                    detail.OrderID = orderId;
                }
                
                // Get selected form of service from ComboBox
                FormOfService selectedFormOfService = cmbFormOfService.SelectedIndex == 0 
                    ? FormOfService.DineIn 
                    : FormOfService.Takeaway;
                
                var order = posBLL.CreateOrUpdateTableOrder(
                    selectedTable.TableID,
                    customerName,
                    customerPhone,
                    currentStaffId,
                    currentOrderDetails,
                    customer?.CustomerID,
                    selectedFormOfService
                );
                
                MessageBox.Show("Lưu đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadTables();
                
                LoadTableOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            if (selectedTable == null || string.IsNullOrWhiteSpace(selectedTable.CurrentOrderID))
            {
                MessageBox.Show("Không có đơn hàng để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                var paymentForm = new Form
                {
                    Text = "Chọn phương thức thanh toán",
                    Size = new Size(300, 150),
                    StartPosition = FormStartPosition.CenterParent
                };
                
                var btnCash = new Button
                {
                    Text = "Tiền mặt",
                    Dock = DockStyle.Top,
                    Height = 50
                };
                
                var btnBank = new Button
                {
                    Text = "Chuyển khoản",
                    Dock = DockStyle.Top,
                    Height = 50
                };
                
                PaymentMethod? selectedMethod = null;
                
                btnCash.Click += (s, e2) =>
                {
                    selectedMethod = PaymentMethod.Cash;
                    paymentForm.DialogResult = DialogResult.OK;
                    paymentForm.Close();
                };
                
                btnBank.Click += (s, e2) =>
                {
                    selectedMethod = PaymentMethod.BankTransfer;
                    paymentForm.DialogResult = DialogResult.OK;
                    paymentForm.Close();
                };
                
                paymentForm.Controls.Add(btnBank);
                paymentForm.Controls.Add(btnCash);
                
                if (paymentForm.ShowDialog() == DialogResult.OK && selectedMethod.HasValue)
                {
                    string orderId = selectedTable.CurrentOrderID;
                    
                    // Apply voucher discount if voucher exists and is valid
                    if (currentVoucher != null && voucherBLL.IsVoucherValid(currentVoucher))
                    {
                        try
                        {
                            // Apply discount percentage to order
                            posBLL.ApplyVoucherDiscount(orderId, currentVoucher.Percentage);
                            
                            // Use the voucher (increment usage count)
                            voucherBLL.UseVoucher(currentVoucher.Code);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi áp dụng voucher: {ex.Message}", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Continue with payment even if voucher fails
                        }
                    }
                    else
                    {
                        // Even without voucher, ensure order TotalAmount is correct (sum of order details)
                        try
                        {
                            posBLL.UpdateOrderTotalAmount(orderId);
                        }
                        catch (Exception ex)
                        {
                            // Log but don't block payment
                            System.Diagnostics.Debug.WriteLine($"Error updating order total: {ex.Message}");
                        }
                    }
                    
                    if (posBLL.ProcessPayment(orderId, selectedMethod.Value, currentStaffId))
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Get the order with details for receipt
                        var orderBLL = new OrderBLL();
                        var completedOrder = orderBLL.GetById(orderId, true);
                        
                        if (completedOrder != null)
                        {
                            // Show receipt preview
                            using (var receiptForm = new FrmReceipt(completedOrder))
                            {
                                receiptForm.ShowPreview();
                            }
                        }
                        
                        // Clear voucher and customer money fields
                        currentVoucher = null;
                        txbVoucher.Text = "";
                        txbCustomerMoney.Text = "";
                        
                        LoadTables();
                        
                        LoadTableOrder();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var createCustomerForm = new FrmCreateCustomer())
                {
                    if (createCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        if (createCustomerForm.CreatedCustomer != null)
                        {
                            var customer = createCustomerForm.CreatedCustomer;
                            txtCustomerName.Text = customer.CustomerName;
                            txtCustomerPhone.Text = customer.CustomerPhoneNum;
                            
                            MessageBox.Show($"Đã tạo khách hàng mới: {customer.CustomerName}", "Thành công", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo khách hàng mới: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelTotalAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
