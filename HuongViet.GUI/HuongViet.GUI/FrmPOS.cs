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
        
        private List<Area> areas;
        private List<Table> tables;
        private List<Item> items;
        private List<OrderDetail> currentOrderDetails;
        private Table selectedTable;
        private string currentAreaFilter;
        private string currentStaffId;

        public FrmPOS()
        {
            InitializeComponent();
            posBLL = new POSBLL();
            authBLL = new AuthBLL();
            currentOrderDetails = new List<OrderDetail>();
            
            InitializeForm();
            LoadAreas();
            LoadTables();
            LoadItems();
        }

        private void InitializeForm()
        {
            // Get current staff ID from session
            currentStaffId = SessionManager.CurrentUserID;
            
            // If no user logged in, show warning
            if (string.IsNullOrEmpty(currentStaffId))
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên. Vui lòng đăng nhập lại.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                currentStaffId = "USER001"; // Fallback
            }
            
            // Setup DataGridViews
            SetupTablesDataGridView();
            SetupItemsGrid();
            SetupOrderDataGridView();
            
            // Setup event handlers
            tabControlTables.SelectedIndexChanged += TabControlTables_SelectedIndexChanged;
            tabControlMenu.SelectedIndexChanged += TabControlMenu_SelectedIndexChanged;
            
            // Initialize labels
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblTotalAmount.Text = "0";
            lblTableInfo.Text = "Chưa chọn bàn";
            
            // Timer to update datetime
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timer.Start();
        }

        private void SetupTablesDataGridView()
        {
            dgvTables.AutoGenerateColumns = false;
            dgvTables.AllowUserToAddRows = false;
            dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTables.MultiSelect = false;
            dgvTables.ReadOnly = true;
            
            // Add columns
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
                DataPropertyName = null, // Will be handled in CellFormatting
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
            
            // Add columns
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
                
                // Add "Tất cả" option
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

                // Display as cards in flowLayoutTables
                DisplayTablesAsCards();

                // Fallback: keep grid data source but hidden by default
                try { dgvTables.DataSource = tables; } catch { }

                // Update label
                lblTableCount.Text = $"{tables.Count} bàn";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTablesAsCards()
        {
            // Use flowLayoutTables (added to designer) to show table buttons/cards
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

                    // Color by status
                    SetTableButtonColor(btn, table);

                    // Hover effect
                    btn.MouseEnter += (s, e) => { ((Button)s).FlatAppearance.BorderSize = 2; };
                    btn.MouseLeave += (s, e) => { ((Button)s).FlatAppearance.BorderSize = 1; };

                    btn.Click += (s, e) =>
                    {
                        var clickedTable = (s as Button)?.Tag as Table;
                        if (clickedTable != null)
                        {
                            // Cập nhật bàn được chọn
                            selectedTable = clickedTable;
                            
                            // Load hóa đơn hiện tại của bàn (nếu có)
                            LoadTableOrder();
                            
                            // Highlight bàn được chọn
                            HighlightSelectedTable();
                        }
                    };

                    flowLayoutTables.Controls.Add(btn);
                }
                
                // Highlight bàn hiện tại nếu có
                HighlightSelectedTable();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error displaying table cards: {ex.Message}");
            }
        }

        private void SetTableButtonColor(Button btn, Table table)
        {
            // Kiểm tra nếu đây là bàn được chọn
            bool isSelected = selectedTable != null && selectedTable.TableID == table.TableID;
            
            if (isSelected)
            {
                // Màu highlight cho bàn được chọn
                btn.BackColor = Color.FromArgb(0x4A, 0x90, 0xE2); // blue
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 3;
                btn.FlatAppearance.BorderColor = Color.DarkBlue;
            }
            else if (table.TableStatus == TableStatus.Available)
            {
                btn.BackColor = Color.FromArgb(0xE6, 0xEE, 0xD8); // light green
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }
            else
            {
                btn.BackColor = Color.FromArgb(0xF8, 0xD7, 0xD4); // light red
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }
        }

        private void HighlightSelectedTable()
        {
            if (flowLayoutTables == null) return;
            
            // Cập nhật màu sắc cho tất cả các button bàn
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
                // Load tất cả thức ăn và nước uống (không load dịch vụ)
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
                // Create card panel
                Panel cardPanel = new Panel
                {
                    Width = cardWidth,
                    Height = cardHeight,
                    Margin = new Padding(spacing),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Cursor = Cursors.Hand
                };
                
                // Add hover effect
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
                
                // Click event handler - add item to order
                EventHandler addItemHandler = (s, e) => AddItemToOrder(item);
                
                // Add click event to card panel
                cardPanel.Click += addItemHandler;
                
                // Item image
                PictureBox picItem = new PictureBox
                {
                    Width = cardWidth - 20,
                    Height = 120,
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };
                
                // Add click event to picture box
                picItem.Click += addItemHandler;
                
                // Load image if available - handle base64
                if (!string.IsNullOrWhiteSpace(item.ItemImage))
                {
                    try
                    {
                        // Try to load as base64 string
                        byte[] imageBytes = Convert.FromBase64String(item.ItemImage);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            var tempImage = Image.FromStream(ms);
                            picItem.Image = new Bitmap(tempImage); // Clone to avoid disposal issues
                        }
                    }
                    catch
                    {
                        // If base64 fails, show placeholder
                        picItem.BackColor = Color.LightGray;
                    }
                }
                else
                {
                    picItem.BackColor = Color.LightGray;
                }
                
                // Item name label
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
                
                // Auto wrap text if too long
                if (item.ItemName.Length > 20)
                {
                    lblItemName.Text = item.ItemName.Substring(0, 17) + "...";
                }
                
                // Add click event to label
                lblItemName.Click += addItemHandler;
                
                // Price label
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
                
                // Add click event to price label
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
        }

        // Event Handlers
        private void CmbAreaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void TabControlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle tab change if needed
        }

        private void TabControlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle tab change if needed
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
                // Lấy thông tin mới nhất của bàn từ database
                var tableInfo = posBLL.GetTableInfo(selectedTable.TableID);
                
                // Cập nhật thông tin bàn hiện tại
                selectedTable = tableInfo.Table;
                
                lblTableInfo.Text = $"Bàn: {selectedTable.TableName} - {selectedTable.Area?.AreaName ?? ""}";
                
                if (tableInfo.CurrentOrder != null)
                {
                    // Load hóa đơn hiện tại của bàn
                    currentOrderDetails = tableInfo.OrderDetails.ToList();
                    
                    // Hiển thị thông tin khách hàng nếu có
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
                    // Bàn trống - xóa thông tin đơn hàng và khách hàng
                    currentOrderDetails.Clear();
                    txtCustomerName.Text = "";
                    txtCustomerPhone.Text = "";
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
            
            // Check if table is selected
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check if item already exists in order
            var existingDetail = currentOrderDetails.FirstOrDefault(d => d.ItemID == item.ItemID);
            
            if (existingDetail != null)
            {
                // Increase quantity
                existingDetail.Quantity++;
                existingDetail.TotalAmount = existingDetail.UnitPrice * existingDetail.Quantity;
            }
            else
            {
                // Add new item
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
                
                // Search or create customer
                Customer customer = null;
                if (!string.IsNullOrWhiteSpace(customerPhone))
                {
                    customer = posBLL.SearchCustomer(customerPhone);
                    if (customer == null)
                    {
                        // Create quick customer
                        customer = posBLL.SearchCustomer(customerPhone); // Try again
                        if (customer == null && !string.IsNullOrWhiteSpace(customerName))
                        {
                            customer = new CustomerBLL().CreateQuickCustomer(customerName, customerPhone);
                        }
                    }
                }
                
                // Set OrderID for all details
                string orderId = selectedTable.CurrentOrderID;
                if (string.IsNullOrWhiteSpace(orderId))
                {
                    orderId = new OrderBLL().GenerateNewOrderID();
                }
                
                foreach (var detail in currentOrderDetails)
                {
                    detail.OrderID = orderId;
                }
                
                var order = posBLL.CreateOrUpdateTableOrder(
                    selectedTable.TableID,
                    customerName,
                    customerPhone,
                    currentStaffId,
                    currentOrderDetails,
                    customer?.CustomerID
                );
                
                MessageBox.Show("Lưu đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Cập nhật lại danh sách bàn để hiển thị trạng thái mới
                LoadTables();
                
                // Load lại thông tin đơn hàng của bàn hiện tại
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
                // Show payment method selection
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
                    if (posBLL.ProcessPayment(selectedTable.CurrentOrderID, selectedMethod.Value, currentStaffId))
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Cập nhật lại danh sách bàn để hiển thị trạng thái mới
                        LoadTables();
                        
                        // Load lại thông tin bàn sau thanh toán (bàn sẽ trở về trạng thái trống)
                        LoadTableOrder();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
