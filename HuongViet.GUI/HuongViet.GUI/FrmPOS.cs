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
        private ItemType? currentItemTypeFilter;
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
            // Set current staff (you may get this from login session)
            // For now, using a default or getting from auth
            currentStaffId = "USER001"; // TODO: Get from current session
            
            // Setup DataGridViews
            SetupTablesDataGridView();
            SetupItemsDataGridView();
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
                DataPropertyName = "Area.AreaName",
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

        private void SetupItemsDataGridView()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ReadOnly = true;
            
            // Add columns
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemName",
                HeaderText = "Tên món",
                DataPropertyName = "ItemName",
                Width = 250
            });
            
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemType",
                HeaderText = "Loại",
                DataPropertyName = "ItemType",
                Width = 100
            });
            
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemPrice",
                HeaderText = "Giá",
                DataPropertyName = "ItemPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });
            
            dgvItems.CellFormatting += DgvItems_CellFormatting;
            dgvItems.CellDoubleClick += DgvItems_CellDoubleClick;
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
                dgvTables.DataSource = tables;
                
                // Update label
                lblTableCount.Text = $"{tables.Count} bàn";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItems()
        {
            try
            {
                items = posBLL.GetAllItems(currentItemTypeFilter);
                dgvItems.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else if (dgvTables.Columns[e.ColumnIndex].Name == "AreaName" && table.Area != null)
                {
                    e.Value = table.Area.AreaName;
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
                
                lblTableInfo.Text = $"Bàn: {selectedTable.TableName} - {selectedTable.Area?.AreaName ?? ""}";
                
                if (tableInfo.CurrentOrder != null)
                {
                    currentOrderDetails = tableInfo.OrderDetails.ToList();
                    RefreshOrderDisplay();
                }
                else
                {
                    currentOrderDetails.Clear();
                    RefreshOrderDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvItems.Rows[e.RowIndex].DataBoundItem is Item item)
            {
                if (dgvItems.Columns[e.ColumnIndex].Name == "ItemType")
                {
                    switch (item.ItemType)
                    {
                        case ItemType.ThucAn:
                            e.Value = "Thức ăn";
                            break;
                        case ItemType.NuocUong:
                            e.Value = "Nước uống";
                            break;
                        case ItemType.DichVu:
                            e.Value = "Dịch vụ";
                            break;
                    }
                }
            }
        }

        private void DgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = dgvItems.Rows[e.RowIndex].DataBoundItem as Item;
                if (item != null)
                {
                    AddItemToOrder(item);
                }
            }
        }

        private void AddItemToOrder(Item item)
        {
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

        private void BtnFilterItemType_Click(object sender, EventArgs e)
        {
            // Toggle item type filter
            if (currentItemTypeFilter == null)
            {
                currentItemTypeFilter = ItemType.ThucAn;
                btnFilterItemType.Text = "Thức ăn";
            }
            else if (currentItemTypeFilter == ItemType.ThucAn)
            {
                currentItemTypeFilter = ItemType.NuocUong;
                btnFilterItemType.Text = "Nước uống";
            }
            else if (currentItemTypeFilter == ItemType.NuocUong)
            {
                currentItemTypeFilter = ItemType.DichVu;
                btnFilterItemType.Text = "Dịch vụ";
            }
            else
            {
                currentItemTypeFilter = null;
                btnFilterItemType.Text = "Tất cả";
            }
            
            LoadItems();
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
    }
}
