using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmService : Form
    {
        private readonly ItemBLL itemBLL;
        private readonly CategoryBLL categoryBLL;
        private readonly UnitBLL unitBLL;
        private List<Item> services;
        private List<Category> categories;
        private List<Unit> units;
        private Item selectedService;
        private bool isEditing = false;
        private string currentImageBase64 = null;

        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;

        // Filter properties
        private string currentSearchTerm = string.Empty;
        private string currentCategoryId = null;
        private decimal? currentPriceFrom = null;
        private decimal? currentPriceTo = null;

        public FrmService()
        {
            InitializeComponent();
            itemBLL = new ItemBLL();
            categoryBLL = new CategoryBLL();
            unitBLL = new UnitBLL();
            this.Resize += FrmService_Resize;
            InitializeForm();
            LoadCategories();
            LoadUnits();
            LoadServices();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void FrmService_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            // Resize pnlMain to fill form
            pnlMain.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            
            // Resize pnlHeader
            pnlHeader.Width = this.ClientSize.Width - 20;
            pnlFilter.Width = pnlHeader.Width;
            
            // Resize pnlContent
            pnlContent.Width = this.ClientSize.Width - 320; // Leave space for form panel
            pnlContent.Height = this.ClientSize.Height - 116; // Header height + margins
            
            // Resize dgvServices
            dgvServices.Width = pnlContent.Width;
            dgvServices.Height = pnlContent.Height - 196; // Price history + paging height
            
            // Resize pnlPriceHistory
            pnlPriceHistory.Width = pnlContent.Width;
            pnlPriceHistory.Location = new Point(0, dgvServices.Height);
            pnlPriceHistoryHeader.Width = pnlPriceHistory.Width;
            dgvPriceHistory.Width = pnlPriceHistory.Width;
            btnRestorePrice.Location = new Point(pnlPriceHistory.Width - 110, 4);
            
            // Resize pnlPaging
            pnlPaging.Width = pnlContent.Width;
            pnlPaging.Location = new Point(0, pnlContent.Height - 42);
            
            // Resize pnlForm
            pnlForm.Location = new Point(this.ClientSize.Width - 310, 106);
            pnlForm.Height = this.ClientSize.Height - 116;
            
            // Resize grpServiceInfo
            grpServiceInfo.Width = pnlForm.Width - 20;
            grpServiceInfo.Height = pnlForm.Height - 100;
            
            // Resize pnlButtons
            pnlButtons.Location = new Point(10, pnlForm.Height - 90);
            pnlButtons.Width = pnlForm.Width - 20;
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            SetupPriceHistoryDataGridView();
            SetupPagination();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvServices.RowHeadersVisible = false;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.MultiSelect = false;
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.ReadOnly = true;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvServices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServices.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvServices.RowTemplate.Height = 30;
            dgvServices.DefaultCellStyle.Font = new Font("Times New Roman", 10F);
            dgvServices.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvServices.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void SetupPriceHistoryDataGridView()
        {
            dgvPriceHistory.RowHeadersVisible = false;
            dgvPriceHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPriceHistory.MultiSelect = false;
            dgvPriceHistory.AllowUserToAddRows = false;
            dgvPriceHistory.AllowUserToDeleteRows = false;
            dgvPriceHistory.ReadOnly = true;
            dgvPriceHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvPriceHistory.EnableHeadersVisualStyles = false;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPriceHistory.ColumnHeadersHeight = 30;
            
            // Row styles
            dgvPriceHistory.RowTemplate.Height = 25;
            dgvPriceHistory.DefaultCellStyle.Font = new Font("Times New Roman", 10F);
            dgvPriceHistory.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvPriceHistory.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void SetupPagination()
        {
            cmbPageSize.SelectedIndex = 1; // Default to 20
            pageSize = 20;
        }

        private void LoadCategories()
        {
            try
            {
                categories = categoryBLL.GetAll();
                
                // ComboBox cho form thêm/sửa
                cmbCategory.DataSource = null;
                cmbCategory.DisplayMember = "CateName";
                cmbCategory.ValueMember = "CateID";
                cmbCategory.DataSource = categories;

                // ComboBox cho filter
                var filterCategories = new List<Category>();
                filterCategories.Add(new Category { CateID = null, CateName = "Tất cả" });
                filterCategories.AddRange(categories);
                
                cmbFilterCategory.DataSource = null;
                cmbFilterCategory.DisplayMember = "CateName";
                cmbFilterCategory.ValueMember = "CateID";
                cmbFilterCategory.DataSource = filterCategories;
                cmbFilterCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thể loại: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUnits()
        {
            try
            {
                units = unitBLL.GetAll();
                cmbUnit.DataSource = null;
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.ValueMember = "UnitID";
                cmbUnit.DataSource = units;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn vị tính: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            try
            {
                // Load only services (DichVu)
                LoadServicesWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách dịch vụ: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServicesWithPaging()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var criteria = new SearchCriteria
                {
                    SearchTerm = currentSearchTerm,
                    PageNumber = currentPage,
                    PageSize = pageSize
                };

                // Always filter by ItemType.DichVu
                var result = itemBLL.SearchItems(criteria, currentCategoryId, ItemType.DichVu, currentPriceFrom, currentPriceTo);
                services = result.Data ?? new List<Item>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách dịch vụ: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                services = new List<Item>();
                totalRecords = 0;
                totalPages = 0;
                currentPage = 1;
                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BindDataGridView()
        {
            dgvServices.DataSource = null;
            
            if (services != null && services.Count > 0)
            {
                var displayData = services.Select(i => new
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemPrice = i.ItemPrice.ToString("N0"),
                    CateName = i.Category?.CateName ?? "",
                    UnitName = i.Unit?.UnitName ?? "",
                    IsActive = i.IsActive ? "Có" : "Không"
                }).ToList();

                dgvServices.DataSource = displayData;
                
                if (dgvServices.Columns.Count > 0)
                {
                    dgvServices.Columns["ItemID"].HeaderText = "Mã dịch vụ";
                    dgvServices.Columns["ItemName"].HeaderText = "Tên dịch vụ";
                    dgvServices.Columns["ItemPrice"].HeaderText = "Giá";
                    dgvServices.Columns["CateName"].HeaderText = "Thể loại";
                    dgvServices.Columns["UnitName"].HeaderText = "Đơn vị";
                    dgvServices.Columns["IsActive"].HeaderText = "Hoạt động";
                    
                    dgvServices.Columns["ItemID"].FillWeight = 15;
                    dgvServices.Columns["ItemName"].FillWeight = 30;
                    dgvServices.Columns["ItemPrice"].FillWeight = 15;
                    dgvServices.Columns["CateName"].FillWeight = 20;
                    dgvServices.Columns["UnitName"].FillWeight = 12;
                    dgvServices.Columns["IsActive"].FillWeight = 8;
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
        }

        private void UpdatePaginationButtons()
        {
            bool canGoBack = currentPage > 1;
            bool canGoForward = currentPage < totalPages;
            
            btnFirstPage.Enabled = canGoBack;
            btnPrevPage.Enabled = canGoBack;
            btnNextPage.Enabled = canGoForward;
            btnLastPage.Enabled = canGoForward;
        }

        private void ClearForm()
        {
            txtServiceName.Clear();
            txtServicePrice.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbUnit.Items.Count > 0) cmbUnit.SelectedIndex = 0;
            picServiceImage.Image = null;
            currentImageBase64 = null;
            selectedService = null;
            isEditing = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            EnableEditMode(false);
            ClearPriceHistory();
        }

        private void EnableEditMode(bool enable)
        {
            txtServiceName.ReadOnly = !enable;
            txtServicePrice.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            cmbCategory.Enabled = enable;
            cmbUnit.Enabled = enable;
            chkIsActive.Enabled = enable;
            btnSelectImage.Enabled = enable;
            btnClearImage.Enabled = enable;
            
            txtServiceName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtServicePrice.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtDescription.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedService != null;
            btnDelete.Enabled = !enable && selectedService != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvServices.Enabled = !enable;
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvServices.SelectedRows[0];
                string serviceId = row.Cells["ItemID"].Value.ToString();
                
                selectedService = services.FirstOrDefault(i => i.ItemID == serviceId);
                
                if (selectedService != null)
                {
                    txtServiceName.Text = selectedService.ItemName;
                    txtServicePrice.Text = selectedService.ItemPrice.ToString();
                    txtDescription.Text = selectedService.ItemDescription ?? string.Empty;
                    chkIsActive.Checked = selectedService.IsActive;
                    
                    // Set category
                    if (!string.IsNullOrEmpty(selectedService.CateID))
                    {
                        cmbCategory.SelectedValue = selectedService.CateID;
                    }
                    
                    // Set unit
                    if (!string.IsNullOrEmpty(selectedService.UnitID))
                    {
                        cmbUnit.SelectedValue = selectedService.UnitID;
                    }
                    
                    // Load image
                    LoadServiceImage(selectedService.ItemImage);
                    
                    // Load price history
                    LoadPriceHistory(selectedService.ItemID);
                    
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else if (!isEditing)
            {
                ClearForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm(); // Clear form first
            selectedService = null;
            isEditing = true; // Then set isEditing
            EnableEditMode(true);
            btnSave.Enabled = true; // Enable Save button immediately
            txtServiceName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedService != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtServiceName.Focus();
                txtServiceName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedService == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa dịch vụ '{selectedService.ItemName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = itemBLL.Delete(selectedService.ItemID);
                    if (success)
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadServicesWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dịch vụ!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtServiceName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtServicePrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá dịch vụ!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServicePrice.Focus();
                    return;
                }

                decimal price;
                if (!decimal.TryParse(txtServicePrice.Text, out price) || price < 0)
                {
                    MessageBox.Show("Giá dịch vụ không hợp lệ!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServicePrice.Focus();
                    return;
                }

                if (cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn thể loại!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbUnit.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị tính!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Item service = selectedService ?? new Item
                {
                    ItemID = itemBLL.GenerateNewItemID()
                };
                
                service.ItemName = txtServiceName.Text.Trim();
                service.ItemPrice = price;
                service.ItemDescription = txtDescription.Text.Trim();
                service.CateID = cmbCategory.SelectedValue.ToString();
                service.UnitID = cmbUnit.SelectedValue.ToString();
                service.ItemType = ItemType.DichVu; // Always set to DichVu
                service.IsActive = chkIsActive.Checked;
                service.ItemImage = currentImageBase64;

                bool success;
                string message;

                if (selectedService == null) // Add new
                {
                    success = itemBLL.Insert(service);
                    message = success ? "Thêm dịch vụ thành công!" : "Không thể thêm dịch vụ!";
                }
                else // Update existing
                {
                    success = itemBLL.Update(service);
                    message = success ? "Cập nhật dịch vụ thành công!" : "Không thể cập nhật dịch vụ!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServicesWithPaging();
                    ClearForm();
                    EnableEditMode(false);
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedService != null)
            {
                // Restore values
                dgvServices_SelectionChanged(null, null);
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        #region Filter Event Handlers

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void txtSearchService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void ApplyFilters()
        {
            try
            {
                // Lấy giá trị filter
                currentSearchTerm = txtSearchService.Text.Trim();
                
                // Filter category
                if (cmbFilterCategory.SelectedValue != null && !string.IsNullOrEmpty(cmbFilterCategory.SelectedValue.ToString()))
                {
                    currentCategoryId = cmbFilterCategory.SelectedValue.ToString();
                }
                else
                {
                    currentCategoryId = null;
                }

                // Filter price from
                if (!string.IsNullOrWhiteSpace(txtPriceFrom.Text))
                {
                    if (decimal.TryParse(txtPriceFrom.Text, out decimal priceFrom) && priceFrom >= 0)
                    {
                        currentPriceFrom = priceFrom;
                    }
                    else
                    {
                        MessageBox.Show("Giá từ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPriceFrom.Focus();
                        return;
                    }
                }
                else
                {
                    currentPriceFrom = null;
                }

                // Filter price to
                if (!string.IsNullOrWhiteSpace(txtPriceTo.Text))
                {
                    if (decimal.TryParse(txtPriceTo.Text, out decimal priceTo) && priceTo >= 0)
                    {
                        currentPriceTo = priceTo;
                    }
                    else
                    {
                        MessageBox.Show("Giá đến không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPriceTo.Focus();
                        return;
                    }
                }
                else
                {
                    currentPriceTo = null;
                }

                // Validate price range
                if (currentPriceFrom.HasValue && currentPriceTo.HasValue && currentPriceFrom.Value > currentPriceTo.Value)
                {
                    MessageBox.Show("Giá từ không được lớn hơn giá đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentPage = 1; // Reset to first page when filtering
                LoadServicesWithPaging();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFilters()
        {
            txtSearchService.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            txtPriceFrom.Clear();
            txtPriceTo.Clear();
            
            currentSearchTerm = string.Empty;
            currentCategoryId = null;
            currentPriceFrom = null;
            currentPriceTo = null;
            
            currentPage = 1;
            LoadServicesWithPaging();
            ClearForm();
        }

        #endregion

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadServicesWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadServicesWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadServicesWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadServicesWithPaging();
                ClearForm();
            }
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPageSize.SelectedItem != null)
            {
                int newPageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                if (newPageSize != pageSize)
                {
                    pageSize = newPageSize;
                    currentPage = 1;
                    LoadServicesWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Image Handling

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh dịch vụ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load image to PictureBox
                        Image img = Image.FromFile(openFileDialog.FileName);
                        picServiceImage.Image = img;

                        // Convert to Base64
                        currentImageBase64 = ConvertImageToBase64(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picServiceImage.Image = null;
            currentImageBase64 = null;
        }

        private string ConvertImageToBase64(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi chuyển đổi ảnh: {ex.Message}");
            }
        }

        private void LoadServiceImage(string base64String)
        {
            try
            {
                if (string.IsNullOrEmpty(base64String))
                {
                    picServiceImage.Image = null;
                    currentImageBase64 = null;
                    return;
                }

                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    picServiceImage.Image = Image.FromStream(ms);
                }
                currentImageBase64 = base64String;
            }
            catch (Exception)
            {
                picServiceImage.Image = null;
                currentImageBase64 = null;
            }
        }

        #endregion

        #region Price History

        private void LoadPriceHistory(string serviceId)
        {
            try
            {
                var priceHistory = itemBLL.GetPriceHistory(serviceId);
                BindPriceHistoryDataGridView(priceHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử giá: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearPriceHistory();
            }
        }

        private void BindPriceHistoryDataGridView(List<ItemPrice> priceHistory)
        {
            dgvPriceHistory.DataSource = null;
            
            if (priceHistory != null && priceHistory.Count > 0)
            {
                var displayData = priceHistory.Select(p => new
                {
                    PriceUpdateDate = p.PriceUpdateDate.ToString("dd/MM/yyyy HH:mm:ss"),
                    Price = p.Price.ToString("N0"),
                    CreatedAt = p.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")
                }).ToList();

                dgvPriceHistory.DataSource = displayData;
                
                if (dgvPriceHistory.Columns.Count > 0)
                {
                    dgvPriceHistory.Columns["PriceUpdateDate"].HeaderText = "Ngày cập nhật";
                    dgvPriceHistory.Columns["Price"].HeaderText = "Giá";
                    dgvPriceHistory.Columns["CreatedAt"].HeaderText = "Ngày tạo bản ghi";
                    
                    dgvPriceHistory.Columns["PriceUpdateDate"].FillWeight = 35;
                    dgvPriceHistory.Columns["Price"].FillWeight = 30;
                    dgvPriceHistory.Columns["CreatedAt"].FillWeight = 35;
                }
            }
        }

        private void ClearPriceHistory()
        {
            dgvPriceHistory.DataSource = null;
        }

        private void btnRestorePrice_Click(object sender, EventArgs e)
        {
            if (selectedService == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần khôi phục giá!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPriceHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn giá cần khôi phục!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgvPriceHistory.SelectedRows[0];
                string priceStr = selectedRow.Cells["Price"].Value.ToString().Replace(",", "");
                decimal selectedPrice = decimal.Parse(priceStr);

                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn khôi phục giá {selectedPrice:N0} VNĐ cho dịch vụ '{selectedService.ItemName}'?",
                    "Xác nhận khôi phục giá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = itemBLL.UpdatePrice(selectedService.ItemID, selectedPrice);
                    if (success)
                    {
                        MessageBox.Show("Khôi phục giá thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reload data
                        LoadServicesWithPaging();
                        
                        // Reload service details
                        selectedService = itemBLL.GetById(selectedService.ItemID);
                        if (selectedService != null)
                        {
                            txtServicePrice.Text = selectedService.ItemPrice.ToString();
                            LoadPriceHistory(selectedService.ItemID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể khôi phục giá!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khôi phục giá: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSearchService_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblFilterCategory_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchService_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPriceFrom_Click(object sender, EventArgs e)
        {

        }

        private void txtPriceFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPriceTo_Click(object sender, EventArgs e)
        {

        }

        private void txtPriceTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlPriceHistoryHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

