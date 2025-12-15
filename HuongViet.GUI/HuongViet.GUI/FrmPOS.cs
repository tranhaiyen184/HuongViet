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
        private readonly CategoryBLL categoryBLL;
        
        private List<Area> areas;
        private List<Table> tables;
        private List<Item> items;
        private List<Item> allItems;
        private List<Category> categories;
        private List<OrderDetail> currentOrderDetails;
        private Table selectedTable;
        private string currentStaffId;
        private Voucher currentVoucher;
        private string currentTakeawayOrderId;

        public FrmPOS()
        {
            InitializeComponent();
            posBLL = new POSBLL();
            authBLL = new AuthBLL();
            voucherBLL = new VoucherBLL();
            categoryBLL = new CategoryBLL();
            currentOrderDetails = new List<OrderDetail>();
            currentTakeawayOrderId = null;
            
            InitializeForm();
            LoadAreas();
            LoadTables();
            LoadCategories();
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
            cmbFormOfService.SelectedIndexChanged += CmbFormOfService_SelectedIndexChanged;
            cmbCategoryFilter.SelectedIndexChanged += (s, e) => ApplyItemFilters();
            txtSearchItem.TextChanged += (s, e) => ApplyItemFilters();
            
            this.Resize += FrmPOS_Resize;
            this.Load += FrmPOS_Load;
            
            // Setup voucher and payment textbox events
            txbVoucher.Leave += TxbVoucher_Leave;
            txbCustomerMoney.TextChanged += TxbCustomerMoney_TextChanged;
            txbCustomerMoney.ReadOnly = true; // nhập tiền khách gửi trong modal thanh toán
            txbVoucher.ReadOnly = true;      // nhập mã voucher trong modal thanh toán
            
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblTotalAmount.Text = "0";
            lblTableInfo.Text = "Chưa chọn bàn";
            lblFormOfService.Visible = true;
            
            // Initialize form of service ComboBox
            cmbFormOfService.Items.Clear();
            cmbFormOfService.Items.Add("Tại chỗ");
            cmbFormOfService.Items.Add("Mang đi");
            cmbFormOfService.SelectedIndex = 0; // Default to "Tại chỗ" (DineIn)
            cmbFormOfService.Enabled = true;

            // Hide service type dropdown; flow controlled via buttons instead
            cmbFormOfService.Visible = false;
            lblFormOfService.Visible = false;

            UpdateFormOfServiceUI();
            
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
            int desiredLeftWidth = (int)(formWidth * 0.6); // 60% for menu
            int minLeftWidth = splitContainerMain.Panel1MinSize;
            int minRightWidth = splitContainerMain.Panel2MinSize;

            int maxLeftWidth = formWidth - minRightWidth;
            if (maxLeftWidth < minLeftWidth)
            {
                maxLeftWidth = minLeftWidth;
            }

            splitContainerMain.SplitterDistance = Math.Max(minLeftWidth, Math.Min(desiredLeftWidth, maxLeftWidth));
        }

        private void UpdateFormOfServiceUI()
        {
            bool isDineIn = cmbFormOfService.SelectedIndex == 0;

            if (isDineIn)
            {
                btnDineIn.BackColor = Color.LightBlue;
                btnTakeaway.BackColor = SystemColors.Control;
                currentTakeawayOrderId = null;
                if (selectedTable == null)
                {
                    lblTableInfo.Text = "Chưa chọn bàn";
                    tabControlMain.SelectedTab = tabPageTablesMain;
                }
            }
            else
            {
                btnDineIn.BackColor = SystemColors.Control;
                btnTakeaway.BackColor = Color.LightBlue;
                selectedTable = null;
                lblTableInfo.Text = "Mang về - không chọn bàn";
                HighlightSelectedTable();
                tabControlMain.SelectedTab = tabPageMenuMain;
            }
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
                Width = 250,
                ReadOnly = true
            });
            
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "SL",
                Width = 40
            });
            
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 90,
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
                Width = 90,
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
                            tabControlMain.SelectedTab = tabPageMenuMain;
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
                allItems = posBLL.GetAllItems(null)
                    .Where(i => i.ItemType == ItemType.ThucAn || i.ItemType == ItemType.NuocUong)
                    .ToList();

                ApplyItemFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                categories = categoryBLL.GetAll();
                cmbCategoryFilter.Items.Clear();
                cmbCategoryFilter.Items.Add("Tất cả");
                foreach (var cat in categories)
                {
                    cmbCategoryFilter.Items.Add(cat.CateName);
                }
                cmbCategoryFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyItemFilters()
        {
            if (allItems == null) return;

            var filtered = allItems.AsEnumerable();

            if (cmbCategoryFilter.SelectedIndex > 0 && categories != null && categories.Count >= cmbCategoryFilter.SelectedIndex)
            {
                var selectedCat = categories[cmbCategoryFilter.SelectedIndex - 1];
                filtered = filtered.Where(i => i.CateID == selectedCat.CateID);
            }

            var search = txtSearchItem.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(search))
            {
                filtered = filtered.Where(i => (i.ItemName ?? string.Empty).ToLowerInvariant().Contains(search));
            }

            items = filtered.ToList();
            DisplayItemsAsCards();
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

        private void CmbFormOfService_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormOfServiceUI();
        }

        private void BtnDineIn_Click(object sender, EventArgs e)
        {
            cmbFormOfService.SelectedIndex = 0;
            UpdateFormOfServiceUI();
        }

        private void BtnTakeaway_Click(object sender, EventArgs e)
        {
            cmbFormOfService.SelectedIndex = 1;
            UpdateFormOfServiceUI();
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

                // After choosing a table, focus on menu tab for ordering
                tabControlMain.SelectedTab = tabPageMenuMain;
                UpdateFormOfServiceUI();
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
            
            bool isTakeaway = cmbFormOfService.SelectedIndex == 1;
            if (!isTakeaway && selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedTab = tabPageTablesMain;
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
            FormOfService selectedFormOfService = cmbFormOfService.SelectedIndex == 0 
                ? FormOfService.DineIn 
                : FormOfService.Takeaway;

            if (selectedFormOfService == FormOfService.DineIn && selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedTab = tabPageTablesMain;
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
                
                string tableId = selectedFormOfService == FormOfService.DineIn ? selectedTable?.TableID : null;

                // Ensure order details have OrderID when editing existing dine-in order
                string orderId = selectedTable?.CurrentOrderID;
                if (selectedFormOfService == FormOfService.DineIn && string.IsNullOrWhiteSpace(orderId))
                {
                    orderId = new OrderBLL().GenerateNewOrderID();
                }

                foreach (var detail in currentOrderDetails)
                {
                    detail.OrderID = orderId;
                }
                
                var order = posBLL.CreateOrUpdateTableOrder(
                    tableId,
                    customerName,
                    customerPhone,
                    currentStaffId,
                    currentOrderDetails,
                    customer?.CustomerID,
                    selectedFormOfService
                );

                if (selectedFormOfService == FormOfService.Takeaway)
                {
                    currentTakeawayOrderId = order.OrderID;
                }
                
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
            bool isDineIn = cmbFormOfService.SelectedIndex == 0;
            if (isDineIn)
            {
                if (selectedTable == null || string.IsNullOrWhiteSpace(selectedTable.CurrentOrderID))
                {
                    MessageBox.Show("Không có đơn hàng để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(currentTakeawayOrderId))
                {
                    MessageBox.Show("Không có đơn hàng mang về để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            try
            {
                var selectedMethod = ShowPaymentModal();
                if (selectedMethod.HasValue)
                {
                    string orderId = isDineIn ? selectedTable.CurrentOrderID : currentTakeawayOrderId;
                    
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

                        if (!isDineIn)
                        {
                            currentTakeawayOrderId = null;
                            currentOrderDetails.Clear();
                            RefreshOrderDisplay();
                        }
                        
                        LoadTables();
                        
                        if (isDineIn)
                        {
                            LoadTableOrder();
                        }
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

        private PaymentMethod? ShowPaymentModal()
        {
            decimal subtotal = GetSubtotalAmount();
            string tableText = lblTableInfo.Text;
            string existingVoucherCode = txbVoucher.Text.Trim();
            Voucher tempVoucher = currentVoucher;

            var modal = new Form
            {
                Text = "Thanh toán",
                Size = new Size(480, 520),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblTitle = new Label
            {
                Text = "Xác nhận thanh toán",
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
            };

            var panelContent = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 0,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(16),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(16, 12, 16, 16)
            };
            panelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            panelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelContent.RowStyles.Clear();
            for (int i = 0; i < 8; i++)
            {
                panelContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            }

            panelContent.Controls.Add(new Label { Text = "Bàn / hình thức:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 0);
            panelContent.Controls.Add(new Label { Text = tableText, Anchor = AnchorStyles.Right, AutoSize = false, Width = 200, Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight }, 1, 0);
            panelContent.Controls.Add(new Label { Text = "Thành tiền:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 1);
            panelContent.Controls.Add(new Label { Text = FormatCurrency(subtotal), Anchor = AnchorStyles.Right, AutoSize = false, Width = 200, Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight }, 1, 1);
            panelContent.Controls.Add(new Label { Text = "Mã voucher:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 2);

            var txtVoucherModal = new TextBox
            {
                Anchor = AnchorStyles.Right,
                Width = 200,
                Font = new Font("Microsoft Sans Serif", 11F),
                Text = existingVoucherCode,
                TextAlign = HorizontalAlignment.Right
            };
            panelContent.Controls.Add(txtVoucherModal, 1, 2);

            panelContent.Controls.Add(new Label { Text = "Giảm (%):", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 3);
            var lblDiscountPercent = new Label
            {
                Text = tempVoucher != null ? $"-{tempVoucher.Percentage:N0}%" : "-0%",
                Anchor = AnchorStyles.Right,
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleRight
            };
            panelContent.Controls.Add(lblDiscountPercent, 1, 3);

            panelContent.Controls.Add(new Label { Text = "Giảm (đ):", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 4);
            var lblDiscountModal = new Label
            {
                Text = lblDiscountAmount.Text.Split('(')[0].Trim(),
                Anchor = AnchorStyles.Right,
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleRight
            };
            panelContent.Controls.Add(lblDiscountModal, 1, 4);

            panelContent.Controls.Add(new Label { Text = "Cần thu:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) }, 0, 5);
            var lblGrandTotalModal = new Label
            {
                Text = FormatCurrency(GetGrandTotalAmount()),
                Anchor = AnchorStyles.Right,
                AutoSize = false,
                Width = 200,
                Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                TextAlign = ContentAlignment.MiddleRight
            };
            panelContent.Controls.Add(lblGrandTotalModal, 1, 5);

            var lblCustomerMoneyTitle = new Label { Text = "Khách gửi:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) };
            panelContent.Controls.Add(lblCustomerMoneyTitle, 0, 6);

            var txtCustomerMoneyModal = new TextBox
            {
                Anchor = AnchorStyles.Right,
                Width = 200,
                Font = new Font("Microsoft Sans Serif", 11F),
                Text = txbCustomerMoney.Text,
                TextAlign = HorizontalAlignment.Right
            };
            panelContent.Controls.Add(txtCustomerMoneyModal, 1, 6);

            var lblChangeTitle = new Label { Text = "Tiền thừa:", Anchor = AnchorStyles.Left, AutoSize = true, Font = new Font("Microsoft Sans Serif", 10F) };
            panelContent.Controls.Add(lblChangeTitle, 0, 7);
            var lblChangeModal = new Label
            {
                Text = FormatCurrency(ParseMoney(lblChangeAmount.Text)),
                Anchor = AnchorStyles.Right,
                AutoSize = false,
                Width = 200,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                ForeColor = Color.MediumBlue,
                TextAlign = ContentAlignment.MiddleRight
            };
            panelContent.Controls.Add(lblChangeModal, 1, 7);

            var panelButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 110,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(16)
            };

            PaymentMethod? selected = null;
            bool cashFieldsVisible = false;

            void ToggleCashFields(bool visible)
            {
                cashFieldsVisible = visible;
                lblCustomerMoneyTitle.Visible = visible;
                txtCustomerMoneyModal.Visible = visible;
                lblChangeTitle.Visible = visible;
                lblChangeModal.Visible = visible;
                if (panelContent.RowStyles.Count > 7)
                {
                    panelContent.RowStyles[6].Height = visible ? 28 : 0; // Khách gửi
                    panelContent.RowStyles[6].SizeType = SizeType.Absolute;
                    panelContent.RowStyles[7].Height = visible ? 28 : 0; // Tiền thừa
                    panelContent.RowStyles[7].SizeType = SizeType.Absolute;
                }
            }

            void RecalcSummary()
            {
                decimal customerMoney = ParseMoney(txtCustomerMoneyModal.Text);
                decimal discount = 0;
                decimal grandTotal = subtotal;

                if (tempVoucher != null && voucherBLL.IsVoucherValid(tempVoucher))
                {
                    discount = voucherBLL.CalculateDiscount(tempVoucher, subtotal);
                    lblDiscountModal.Text = FormatCurrency(discount);
                    lblDiscountPercent.Text = $"-{tempVoucher.Percentage:N0}%";
                }
                else
                {
                    lblDiscountModal.Text = FormatCurrency(0);
                    lblDiscountPercent.Text = "-0%";
                }

                grandTotal = subtotal - discount;
                lblGrandTotalModal.Text = FormatCurrency(grandTotal);

                decimal change = customerMoney - grandTotal;
                lblChangeModal.Text = change >= 0 ? FormatCurrency(change) : FormatCurrency(0);
            }

            void ApplyVoucherInModal()
            {
                string code = txtVoucherModal.Text.Trim();
                if (string.IsNullOrWhiteSpace(code))
                {
                    tempVoucher = null;
                    lblDiscountModal.Text = FormatCurrency(0);
                    lblDiscountPercent.Text = "-0%";
                    RecalcSummary();
                    return;
                }

                try
                {
                    var found = voucherBLL.GetByCode(code);
                    if (found == null || !voucherBLL.IsVoucherValid(found))
                    {
                        MessageBox.Show("Voucher không hợp lệ hoặc đã hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempVoucher = null;
                        txtVoucherModal.Text = "";
                        lblDiscountPercent.Text = "-0%";
                    }
                    else
                    {
                        tempVoucher = found;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RecalcSummary();
            }

            txtCustomerMoneyModal.TextChanged += (s, e) => RecalcSummary();
            txtVoucherModal.Leave += (s, e) => ApplyVoucherInModal();
            txtVoucherModal.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ApplyVoucherInModal();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            bool ShowBankTransferModal(decimal amount)
            {
                string bankCode = "mbbank";
                string accountNumber = "200803180403";
                string addInfo = "thanh toán cho nhà hàng Hương Việt";
                string qrUrl = $"https://img.vietqr.io/image/{bankCode}-{accountNumber}-qr_only.png?amount={(int)Math.Round(amount)}&addInfo={Uri.EscapeDataString(addInfo)}";

                var qrForm = new Form
                {
                    Text = "QR chuyển khoản",
                    Size = new Size(520, 720),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var headerPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    ColumnCount = 1,
                    RowCount = 2,
                    Padding = new Padding(16, 14, 16, 6)
                };
                headerPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                headerPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                headerPanel.Controls.Add(new Label
                {
                    Text = "Quét mã QR để thanh toán",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(139, 90, 43),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    MaximumSize = new Size(480, 0)
                }, 0, 0);

                headerPanel.Controls.Add(new Label
                {
                    Text = "VIETQR",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 1);

                var footerPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    AutoSize = true,
                    ColumnCount = 1,
                    RowCount = 5,
                    Padding = new Padding(16, 6, 16, 12)
                };
                footerPanel.RowStyles.Clear();
                for (int i = 0; i < 5; i++)
                {
                    footerPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                footerPanel.Controls.Add(new Label
                {
                    Text = "napas 247 - MB Bank",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(80, 80, 80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 0);

                footerPanel.Controls.Add(new Label
                {
                    Text = "NHÀ HÀNG HƯƠNG VIỆT",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 1);

                footerPanel.Controls.Add(new Label
                {
                    Text = accountNumber,
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 2);

                footerPanel.Controls.Add(new Label
                {
                    Text = $"Số tiền: {amount:N0} VND",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(199, 99, 0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 3);

                footerPanel.Controls.Add(new Label
                {
                    Text = "Nội dung: Thanh toán cho nhà hàng Hương Việt",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(90, 90, 90),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    MaximumSize = new Size(480, 0)
                }, 0, 4);

                var picQr = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.White,
                    Margin = new Padding(20)
                };

                var mainPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 3,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0)
                };
                mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                mainPanel.Controls.Add(headerPanel, 0, 0);
                mainPanel.Controls.Add(picQr, 0, 1);
                mainPanel.Controls.Add(footerPanel, 0, 2);

                try
                {
                    picQr.Load(qrUrl);
                }
                catch
                {
                    MessageBox.Show("Không tải được mã QR. Kiểm tra kết nối mạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var btnClose = new Button
                {
                    Text = "Đã chuyển khoản",
                    DialogResult = DialogResult.OK,
                    Width = 160,
                    Height = 36,
                    Anchor = AnchorStyles.Right,
                    Margin = new Padding(8, 12, 0, 12)
                };

                var btnBack = new Button
                {
                    Text = "Quay lại",
                    DialogResult = DialogResult.Cancel,
                    Width = 120,
                    Height = 36,
                    Anchor = AnchorStyles.Left,
                    Margin = new Padding(0, 12, 8, 12)
                };

                var bottomPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    FlowDirection = FlowDirection.RightToLeft,
                    Padding = new Padding(16),
                    AutoSize = true
                };
                bottomPanel.Controls.Add(btnClose);
                bottomPanel.Controls.Add(btnBack);

                qrForm.Controls.Add(mainPanel);
                qrForm.Controls.Add(bottomPanel);

                qrForm.AcceptButton = btnClose;

                var qrResult = qrForm.ShowDialog(modal);
                return qrResult == DialogResult.OK;
            }

            // Hide cash-only fields until chọn tiền mặt
            ToggleCashFields(false);
            // Initial calculation
            RecalcSummary();

            var btnBank = new Button
            {
                Text = "Chuyển khoản",
                Width = 120,
                Height = 35
            };
            btnBank.Click += (s, e) =>
            {
                decimal amountToPay = ParseMoney(lblGrandTotalModal.Text);
                bool confirmed = ShowBankTransferModal(amountToPay);
                if (!confirmed)
                {
                    return; // user backed out; keep order unchanged
                }

                selected = PaymentMethod.BankTransfer;
                modal.DialogResult = DialogResult.OK;
                modal.Close();
            };

            var btnCash = new Button
            {
                Text = "Tiền mặt",
                Width = 100,
                Height = 35
            };
            btnCash.Click += (s, e) =>
            {
                if (!cashFieldsVisible)
                {
                    ToggleCashFields(true);
                    txtCustomerMoneyModal.Focus();
                    return;
                }

                selected = PaymentMethod.Cash;
                modal.DialogResult = DialogResult.OK;
                modal.Close();
            };

            panelButtons.Controls.Add(btnBank);
            panelButtons.Controls.Add(btnCash);

            modal.Controls.Add(panelButtons);
            modal.Controls.Add(panelContent);
            modal.Controls.Add(lblTitle);

            var result = modal.ShowDialog();
            if (result == DialogResult.OK && selected.HasValue)
            {
                // Commit modal values back to main UI
                currentVoucher = tempVoucher;
                txbVoucher.Text = tempVoucher?.Code ?? "";
                UpdateVoucherCalculations();

                txbCustomerMoney.Text = txtCustomerMoneyModal.Text;
                UpdateChange();

                return selected;
            }

            return null;
        }

        private decimal GetGrandTotalAmount()
        {
            return ParseMoney(lblGrandTotalAmount.Text);
        }

        private decimal ParseMoney(string input)
        {
            // Keep only digits and optional leading minus; strip currency symbols ("đ") and separators
            string raw = (input ?? string.Empty).Trim();
            string filtered = new string(raw.Where((ch, idx) => char.IsDigit(ch) || (ch == '-' && idx == 0)).ToArray());
            if (string.IsNullOrWhiteSpace(filtered)) return 0;
            if (decimal.TryParse(filtered, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }
            return 0;
        }

        private string FormatCurrency(decimal value)
        {
            return value.ToString("N0") + " đ";
        }

        private decimal GetSubtotalAmount()
        {
            return ParseMoney(lblTotalAmount.Text);
        }
    }
}
