using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;
using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    public partial class FrmPosition : Form
    {
        private readonly PositionBLL positionBLL;
        private List<Position> positions;
        private List<Department> departments;
        private Position selectedPosition;
        private bool isEditing = false;
        
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;

        public FrmPosition()
        {
            InitializeComponent();
            positionBLL = new PositionBLL();
            InitializeForm();
            LoadDepartments();
            LoadPositions();
        }

        protected override void SetVisibleCore(bool value)
        {
            // Ensure form is properly visible when embedded
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            // Setup DataGridView
            SetupDataGridView();
            
            // Setup pagination
            SetupPagination();
            
            // Clear form
            ClearForm();
        }

        private void SetupDataGridView()
        {
            // Base settings
            dgvPositions.RowHeadersVisible = false;
            dgvPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPositions.MultiSelect = false;
            dgvPositions.AllowUserToAddRows = false;
            dgvPositions.AllowUserToDeleteRows = false;
            dgvPositions.ReadOnly = true;
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvPositions.EnableHeadersVisualStyles = false;
            dgvPositions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvPositions.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvPositions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPositions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPositions.ColumnHeadersHeight = 40;
            dgvPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Row styles
            dgvPositions.RowTemplate.Height = 35;
            dgvPositions.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvPositions.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvPositions.DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        private void SetupPagination()
        {
            // Initialize page size combo box
            cmbPageSize.SelectedIndex = 1; // Default to 20
            pageSize = 20;
        }

        private void LoadDepartments()
        {
            try
            {
                departments = positionBLL.GetAllDepartments();
                
                // Setup department ComboBox
                cmbDepartment.DataSource = null;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.DataSource = departments;
                cmbDepartment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng ban: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositions()
        {
            try
            {
                LoadPositionsWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vị trí: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositionsWithPaging()
        {
            try
            {
                // Show loading cursor
                this.Cursor = Cursors.WaitCursor;

                var criteria = new SearchCriteria
                {
                    SearchTerm = currentSearchTerm,
                    PageNumber = currentPage,
                    PageSize = pageSize
                };

                var result = positionBLL.GetPositionsWithPaging(criteria);
                positions = result.Data ?? new List<Position>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vị trí: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Reset to safe state on error
                positions = new List<Position>();
                totalRecords = 0;
                totalPages = 0;
                currentPage = 1;
                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            finally
            {
                // Restore normal cursor
                this.Cursor = Cursors.Default;
            }
        }

        private void BindDataGridView()
        {
            dgvPositions.DataSource = null;
            
            if (positions != null && positions.Count > 0)
            {
                var displayData = positions.Select(p => new
                {
                    PositionID = p.PositionID,
                    PositionName = p.PositionName,
                    DepartmentName = p.Department?.DepartmentName ?? "Chưa xác định",
                    CreatedAt = p.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    UpdatedAt = p.UpdatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvPositions.DataSource = displayData;
                
                // Set column headers
                if (dgvPositions.Columns.Count > 0)
                {
                    dgvPositions.Columns["PositionID"].HeaderText = "Mã vị trí";
                    dgvPositions.Columns["PositionName"].HeaderText = "Tên vị trí";
                    dgvPositions.Columns["DepartmentName"].HeaderText = "Phòng ban";
                    dgvPositions.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    dgvPositions.Columns["UpdatedAt"].HeaderText = "Ngày cập nhật";
                    
                    // Set column widths
                    dgvPositions.Columns["PositionID"].FillWeight = 15;
                    dgvPositions.Columns["PositionName"].FillWeight = 25;
                    dgvPositions.Columns["DepartmentName"].FillWeight = 25;
                    dgvPositions.Columns["CreatedAt"].FillWeight = 17.5f;
                    dgvPositions.Columns["UpdatedAt"].FillWeight = 17.5f;
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
            lblStatus.Text = $"Hiển thị {positions?.Count ?? 0} / {totalRecords} vị trí";
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
            txtPositionName.Clear();
            cmbDepartment.SelectedIndex = -1;
            selectedPosition = null;
            isEditing = false;
            
            // Update button states
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            txtPositionName.ReadOnly = true;
            txtPositionName.BackColor = SystemColors.Control;
            cmbDepartment.Enabled = false;
        }

        private void EnableEditMode(bool enable)
        {
            txtPositionName.ReadOnly = !enable;
            txtPositionName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            cmbDepartment.Enabled = enable;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedPosition != null;
            btnDelete.Enabled = !enable && selectedPosition != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvPositions.Enabled = !enable;
        }

        private void dgvPositions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvPositions.SelectedRows[0];
                string positionId = row.Cells["PositionID"].Value.ToString();
                
                selectedPosition = positions.FirstOrDefault(p => p.PositionID == positionId);
                
                if (selectedPosition != null)
                {
                    txtPositionName.Text = selectedPosition.PositionName;
                    
                    // Set department in ComboBox
                    if (!string.IsNullOrEmpty(selectedPosition.DepartmentID))
                    {
                        cmbDepartment.SelectedValue = selectedPosition.DepartmentID;
                    }
                    else
                    {
                        cmbDepartment.SelectedIndex = -1;
                    }
                    
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
            selectedPosition = null;
            isEditing = true;
            txtPositionName.Clear();
            cmbDepartment.SelectedIndex = -1;
            EnableEditMode(true);
            txtPositionName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedPosition != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtPositionName.Focus();
                txtPositionName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPosition == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vị trí '{selectedPosition.PositionName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = positionBLL.DeletePosition(selectedPosition.PositionID);
                    if (success)
                    {
                        MessageBox.Show("Xóa vị trí thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPositionsWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vị trí!", "Lỗi", 
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
                // Client-side validation
                string validationError = ValidateInput();
                if (!string.IsNullOrEmpty(validationError))
                {
                    MessageBox.Show(validationError, "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPositionName.Focus();
                    return;
                }

                Position position = selectedPosition ?? new Position();
                position.PositionName = txtPositionName.Text.Trim();
                position.DepartmentID = cmbDepartment.SelectedValue?.ToString();

                bool success;
                string message;

                if (selectedPosition == null) // Add new
                {
                    success = positionBLL.AddPosition(position);
                    message = success ? "Thêm vị trí thành công!" : "Không thể thêm vị trí!";
                }
                else // Update existing
                {
                    success = positionBLL.UpdatePosition(position);
                    message = success ? "Cập nhật vị trí thành công!" : "Không thể cập nhật vị trí!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPositionsWithPaging();
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
            if (selectedPosition != null)
            {
                txtPositionName.Text = selectedPosition.PositionName;
                cmbDepartment.SelectedValue = selectedPosition.DepartmentID;
            }
            else
            {
                txtPositionName.Clear();
                cmbDepartment.SelectedIndex = -1;
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPositions();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchPositions();
                e.Handled = true;
            }
        }

        private void txtPositionName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent leading spaces
            if (e.KeyChar == ' ' && txtPositionName.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            // Handle Enter key to save
            if (e.KeyChar == (char)Keys.Enter && btnSave.Enabled)
            {
                btnSave_Click(sender, e);
                e.Handled = true;
            }
        }

        private void SearchPositions()
        {
            try
            {
                currentSearchTerm = txtSearch.Text.Trim();
                currentPage = 1; // Reset to first page when searching
                LoadPositionsWithPaging();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            currentSearchTerm = string.Empty;
            currentPage = 1;
            LoadPositions();
            ClearForm();
        }

        private void FrmPosition_Load(object sender, EventArgs e)
        {
            // Form is already initialized in constructor
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Clean up resources when form is closed
            try
            {
                if (positionBLL != null)
                {
                    // Dispose any resources if needed
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
            finally
            {
                base.OnFormClosed(e);
            }
        }

        private void FrmPosition_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle keyboard shortcuts
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N: // Ctrl+N for New
                        if (btnAdd.Enabled) btnAdd_Click(sender, e);
                        break;
                    case Keys.E: // Ctrl+E for Edit
                        if (btnEdit.Enabled) btnEdit_Click(sender, e);
                        break;
                    case Keys.D: // Ctrl+D for Delete
                        if (btnDelete.Enabled) btnDelete_Click(sender, e);
                        break;
                    case Keys.S: // Ctrl+S for Save
                        if (btnSave.Enabled) btnSave_Click(sender, e);
                        break;
                    case Keys.F: // Ctrl+F for Find
                        txtSearch.Focus();
                        break;
                    case Keys.R: // Ctrl+R for Refresh
                        btnRefresh_Click(sender, e);
                        break;
                }
            }
            else if (e.KeyCode == Keys.Escape && btnCancel.Enabled)
            {
                btnCancel_Click(sender, e);
            }
        }

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadPositionsWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPositionsWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPositionsWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadPositionsWithPaging();
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
                    currentPage = 1; // Reset to first page when changing page size
                    LoadPositionsWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Validation

        private string ValidateInput()
        {
            string positionName = txtPositionName.Text.Trim();

            if (string.IsNullOrWhiteSpace(positionName))
            {
                return "Vui lòng nhập tên vị trí!";
            }

            if (positionName.Length < 2)
            {
                return "Tên vị trí phải có ít nhất 2 ký tự!";
            }

            if (positionName.Length > 50)
            {
                return "Tên vị trí không được vượt quá 50 ký tự!";
            }

            if (cmbDepartment.SelectedValue == null)
            {
                return "Vui lòng chọn phòng ban!";
            }

            // Check for invalid characters (optional - you can customize this)
            if (positionName.Contains("  ")) // Double spaces
            {
                return "Tên vị trí không được chứa khoảng trắng liên tiếp!";
            }

            return null; // Valid
        }

        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
