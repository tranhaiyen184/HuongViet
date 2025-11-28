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
    public partial class FrmItem : Form
    {
        private readonly ItemBLL itemBLL;
        private readonly CategoryBLL categoryBLL;
        private readonly UnitBLL unitBLL;
        private List<Item> items;
        private List<Category> categories;
        private List<Unit> units;
        private Item selectedItem;
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
        private ItemType? currentItemType = null;
        private decimal? currentPriceFrom = null;
        private decimal? currentPriceTo = null;

        public FrmItem()
        {
            InitializeComponent();
            itemBLL = new ItemBLL();
            categoryBLL = new CategoryBLL();
            unitBLL = new UnitBLL();
            InitializeForm();
            LoadCategories();
            LoadUnits();
            LoadItems();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            SetupPriceHistoryDataGridView();
            SetupPagination();
            SetupFilters();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.ReadOnly = true;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvItems.RowTemplate.Height = 30;
            dgvItems.DefaultCellStyle.Font = new Font("Times New Roman", 10F);
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.Black;
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

        private void SetupFilters()
        {
            // Filter setup - removed ItemType filter to match Service form design
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

        private void LoadItems()
        {
            try
            {
                // Mặc định load nước uống và thức ăn (không load dịch vụ)
                currentItemType = null; // Tất cả khi filter = "Tất cả"
                LoadItemsWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemsWithPaging()
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

                var result = itemBLL.SearchItems(criteria, currentCategoryId, currentItemType, currentPriceFrom, currentPriceTo);
                items = result.Data ?? new List<Item>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                items = new List<Item>();
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
            dgvItems.DataSource = null;
            
            if (items != null && items.Count > 0)
            {
                var displayData = items.Select(i => new
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemPrice = i.ItemPrice.ToString("N0"),
                    CateName = i.Category?.CateName ?? "",
                    UnitName = i.Unit?.UnitName ?? "",
                    ItemType = GetItemTypeString(i.ItemType),
                    IsActive = i.IsActive ? "Có" : "Không"
                }).ToList();

                dgvItems.DataSource = displayData;
                
                if (dgvItems.Columns.Count > 0)
                {
                    dgvItems.Columns["ItemID"].HeaderText = "Mã món";
                    dgvItems.Columns["ItemName"].HeaderText = "Tên món";
                    dgvItems.Columns["ItemPrice"].HeaderText = "Giá";
                    dgvItems.Columns["CateName"].HeaderText = "Thể loại";
                    dgvItems.Columns["UnitName"].HeaderText = "Đơn vị";
                    dgvItems.Columns["ItemType"].HeaderText = "Loại món";
                    dgvItems.Columns["IsActive"].HeaderText = "Hoạt động";
                    
                    dgvItems.Columns["ItemID"].FillWeight = 15;
                    dgvItems.Columns["ItemName"].FillWeight = 25;
                    dgvItems.Columns["ItemPrice"].FillWeight = 15;
                    dgvItems.Columns["CateName"].FillWeight = 15;
                    dgvItems.Columns["UnitName"].FillWeight = 10;
                    dgvItems.Columns["ItemType"].FillWeight = 12;
                    dgvItems.Columns["IsActive"].FillWeight = 8;
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

        private string GetItemTypeString(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.ThucAn:
                    return "Thức ăn";
                case ItemType.NuocUong:
                    return "Nước uống";
                case ItemType.DichVu:
                    return "Dịch vụ";
                default:
                    return "Thức ăn";
            }
        }

        private ItemType GetItemTypeFromString(string itemTypeStr)
        {
            switch (itemTypeStr)
            {
                case "Thức ăn":
                    return ItemType.ThucAn;
                case "Nước uống":
                    return ItemType.NuocUong;
                case "Dịch vụ":
                    return ItemType.DichVu;
                default:
                    return ItemType.ThucAn;
            }
        }

        private void ClearForm()
        {
            txtItemName.Clear();
            txtItemPrice.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbUnit.Items.Count > 0) cmbUnit.SelectedIndex = 0;
            if (cmbItemType.Items.Count > 0) cmbItemType.SelectedIndex = 0;
            picItemImage.Image = null;
            currentImageBase64 = null;
            selectedItem = null;
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
            txtItemName.ReadOnly = !enable;
            txtItemPrice.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            cmbCategory.Enabled = enable;
            cmbUnit.Enabled = enable;
            cmbItemType.Enabled = enable;
            chkIsActive.Enabled = enable;
            btnSelectImage.Enabled = enable;
            btnClearImage.Enabled = enable;
            
            txtItemName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtItemPrice.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtDescription.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedItem != null;
            btnDelete.Enabled = !enable && selectedItem != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvItems.Enabled = !enable;
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvItems.SelectedRows[0];
                string itemId = row.Cells["ItemID"].Value.ToString();
                
                selectedItem = items.FirstOrDefault(i => i.ItemID == itemId);
                
                if (selectedItem != null)
                {
                    txtItemName.Text = selectedItem.ItemName;
                    txtItemPrice.Text = selectedItem.ItemPrice.ToString();
                    txtDescription.Text = selectedItem.ItemDescription ?? string.Empty;
                    chkIsActive.Checked = selectedItem.IsActive;
                    
                    // Set category
                    if (!string.IsNullOrEmpty(selectedItem.CateID))
                    {
                        cmbCategory.SelectedValue = selectedItem.CateID;
                    }
                    
                    // Set unit
                    if (!string.IsNullOrEmpty(selectedItem.UnitID))
                    {
                        cmbUnit.SelectedValue = selectedItem.UnitID;
                    }
                    
                    // Set item type
                    cmbItemType.SelectedItem = GetItemTypeString(selectedItem.ItemType);
                    
                    // Load image
                    LoadItemImage(selectedItem.ItemImage);
                    
                    // Load price history
                    LoadPriceHistory(selectedItem.ItemID);
                    
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
            selectedItem = null;
            isEditing = true; // Then set isEditing
            EnableEditMode(true);
            btnSave.Enabled = true; // Enable Save button immediately
            txtItemName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtItemName.Focus();
                txtItemName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa món '{selectedItem.ItemName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = itemBLL.Delete(selectedItem.ItemID);
                    if (success)
                    {
                        MessageBox.Show("Xóa món thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItemsWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa món!", "Lỗi", 
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
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtItemPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá món!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemPrice.Focus();
                    return;
                }

                decimal price;
                if (!decimal.TryParse(txtItemPrice.Text, out price) || price < 0)
                {
                    MessageBox.Show("Giá món không hợp lệ!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemPrice.Focus();
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

                Item item = selectedItem ?? new Item
                {
                    ItemID = itemBLL.GenerateNewItemID()
                };
                
                item.ItemName = txtItemName.Text.Trim();
                item.ItemPrice = price;
                item.ItemDescription = txtDescription.Text.Trim();
                item.CateID = cmbCategory.SelectedValue.ToString();
                item.UnitID = cmbUnit.SelectedValue.ToString();
                item.ItemType = GetItemTypeFromString(cmbItemType.SelectedItem.ToString());
                item.IsActive = chkIsActive.Checked;
                item.ItemImage = currentImageBase64;

                bool success;
                string message;

                if (selectedItem == null) // Add new
                {
                    success = itemBLL.Insert(item);
                    message = success ? "Thêm món thành công!" : "Không thể thêm món!";
                }
                else // Update existing
                {
                    success = itemBLL.Update(item);
                    message = success ? "Cập nhật món thành công!" : "Không thể cập nhật món!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadItemsWithPaging();
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
            if (selectedItem != null)
            {
                // Restore values
                dgvItems_SelectionChanged(null, null);
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

        private void txtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
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
                currentSearchTerm = txtSearchItem.Text.Trim();
                
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
                LoadItemsWithPaging();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFilters()
        {
            txtSearchItem.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            txtPriceFrom.Clear();
            txtPriceTo.Clear();
            
            currentSearchTerm = string.Empty;
            currentCategoryId = null;
            currentItemType = null;
            currentPriceFrom = null;
            currentPriceTo = null;
            
            currentPage = 1;
            LoadItemsWithPaging();
            ClearForm();
        }

        #endregion

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadItemsWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadItemsWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadItemsWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadItemsWithPaging();
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
                    LoadItemsWithPaging();
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
                openFileDialog.Title = "Chọn ảnh món ăn";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load image to PictureBox
                        Image img = Image.FromFile(openFileDialog.FileName);
                        picItemImage.Image = img;

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
            picItemImage.Image = null;
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

        private void LoadItemImage(string base64String)
        {
            try
            {
                if (string.IsNullOrEmpty(base64String))
                {
                    picItemImage.Image = null;
                    currentImageBase64 = null;
                    return;
                }

                Image img = null;

                // Try as base64 string
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Create a copy to avoid stream disposal issues
                        img = new Bitmap(Image.FromStream(ms));
                    }
                }
                catch
                {
                    // If not valid base64, ignore
                    img = null;
                }

                if (img != null)
                {
                    // Dispose previous image safely
                    var old = picItemImage.Image;
                    picItemImage.Image = img;
                    old?.Dispose();
                    currentImageBase64 = base64String;
                }
                else
                {
                    picItemImage.Image = null;
                    currentImageBase64 = null;
                }
            }
            catch (Exception)
            {
                picItemImage.Image = null;
                currentImageBase64 = null;
            }
        }

        #endregion

        #region Price History

        private void LoadPriceHistory(string itemId)
        {
            try
            {
                var priceHistory = itemBLL.GetPriceHistory(itemId);
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
            if (selectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món cần khôi phục giá!", "Thông báo", 
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
                    $"Bạn có chắc chắn muốn khôi phục giá {selectedPrice:N0} VNĐ cho món '{selectedItem.ItemName}'?",
                    "Xác nhận khôi phục giá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = itemBLL.UpdatePrice(selectedItem.ItemID, selectedPrice);
                    if (success)
                    {
                        MessageBox.Show("Khôi phục giá thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reload data
                        LoadItemsWithPaging();
                        
                        // Reload item details
                        selectedItem = itemBLL.GetById(selectedItem.ItemID);
                        if (selectedItem != null)
                        {
                            txtItemPrice.Text = selectedItem.ItemPrice.ToString();
                            LoadPriceHistory(selectedItem.ItemID);
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

        private void lblSearchItem_Click(object sender, EventArgs e)
        {

        }

        private void lblPriceFrom_Click(object sender, EventArgs e)
        {

        }

        private void lblPriceTo_Click(object sender, EventArgs e)
        {

        }

        private void lblFilterCategory_Click(object sender, EventArgs e)
        {

        }

        private void txtPriceFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlPriceHistoryHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
