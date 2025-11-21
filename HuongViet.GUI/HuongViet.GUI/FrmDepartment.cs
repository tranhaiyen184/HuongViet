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
    public partial class FrmDepartment : Form
    {
        private readonly DepartmentBLL departmentBLL;
        private List<Department> departments;
        private Department selectedDepartment;
        private bool isEditing = false;
        
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;

        public FrmDepartment()
        {
            InitializeComponent();
            departmentBLL = new DepartmentBLL();
            InitializeForm();
            LoadDepartments();
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
            dgvDepartments.RowHeadersVisible = false;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.MultiSelect = false;
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;
            dgvDepartments.ReadOnly = true;
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Force refresh to apply styles
            dgvDepartments.SuspendLayout();
            
            // Header styles
            dgvDepartments.EnableHeadersVisualStyles = false;
            dgvDepartments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDepartments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDepartments.ColumnHeadersHeight = 40;
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Row styles
            dgvDepartments.RowTemplate.Height = 35;
            dgvDepartments.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvDepartments.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvDepartments.DefaultCellStyle.SelectionForeColor = Color.Black;
            
            dgvDepartments.ResumeLayout(true);
            dgvDepartments.Refresh();
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
                LoadDepartmentsWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng ban: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartmentsWithPaging()
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

                var result = departmentBLL.GetDepartmentsWithPaging(criteria);
                departments = result.Data ?? new List<Department>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng ban: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Reset to safe state on error
                departments = new List<Department>();
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
            dgvDepartments.DataSource = null;
            
            if (departments != null && departments.Count > 0)
            {
                var displayData = departments.Select(d => new
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                    CreatedAt = d.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    UpdatedAt = d.UpdatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvDepartments.DataSource = displayData;
                
                // Set column headers
                if (dgvDepartments.Columns.Count > 0)
                {
                    dgvDepartments.Columns["DepartmentID"].HeaderText = "Mã phòng ban";
                    dgvDepartments.Columns["DepartmentName"].HeaderText = "Tên phòng ban";
                    dgvDepartments.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    dgvDepartments.Columns["UpdatedAt"].HeaderText = "Ngày cập nhật";
                    
                    // Set column widths
                    dgvDepartments.Columns["DepartmentID"].FillWeight = 20;
                    dgvDepartments.Columns["DepartmentName"].FillWeight = 40;
                    dgvDepartments.Columns["CreatedAt"].FillWeight = 20;
                    dgvDepartments.Columns["UpdatedAt"].FillWeight = 20;
                }
            }
        }

        private void UpdateStatusLabel()
        {
            int count = departments?.Count ?? 0;
            lblStatus.Text = $"Tổng số phòng ban: {totalRecords}";
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
            lblStatus.Text = $"Hiển thị {departments?.Count ?? 0} / {totalRecords} phòng ban";
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
            txtDepartmentName.Clear();
            selectedDepartment = null;
            isEditing = false;
            
            // Update button states
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            txtDepartmentName.ReadOnly = true;
            txtDepartmentName.BackColor = SystemColors.Control;
        }

        private void EnableEditMode(bool enable)
        {
            txtDepartmentName.ReadOnly = !enable;
            txtDepartmentName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedDepartment != null;
            btnDelete.Enabled = !enable && selectedDepartment != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvDepartments.Enabled = !enable;
        }

        private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvDepartments.SelectedRows[0];
                string departmentId = row.Cells["DepartmentID"].Value.ToString();
                
                selectedDepartment = departments.FirstOrDefault(d => d.DepartmentID == departmentId);
                
                if (selectedDepartment != null)
                {
                    txtDepartmentName.Text = selectedDepartment.DepartmentName;
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
            selectedDepartment = null;
            isEditing = true;
            txtDepartmentName.Clear();
            EnableEditMode(true);
            txtDepartmentName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedDepartment != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtDepartmentName.Focus();
                txtDepartmentName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDepartment == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng ban '{selectedDepartment.DepartmentName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = departmentBLL.DeleteDepartment(selectedDepartment.DepartmentID);
                if (success)
                {
                    MessageBox.Show("Xóa phòng ban thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartmentsWithPaging();
                    ClearForm();
                }
                    else
                    {
                        MessageBox.Show("Không thể xóa phòng ban!", "Lỗi", 
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
                    txtDepartmentName.Focus();
                    return;
                }

                Department department = selectedDepartment ?? new Department();
                department.DepartmentName = txtDepartmentName.Text.Trim();

                bool success;
                string message;

                if (selectedDepartment == null) // Add new
                {
                    success = departmentBLL.AddDepartment(department);
                    message = success ? "Thêm phòng ban thành công!" : "Không thể thêm phòng ban!";
                }
                else // Update existing
                {
                    success = departmentBLL.UpdateDepartment(department);
                    message = success ? "Cập nhật phòng ban thành công!" : "Không thể cập nhật phòng ban!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartmentsWithPaging();
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
            if (selectedDepartment != null)
            {
                txtDepartmentName.Text = selectedDepartment.DepartmentName;
            }
            else
            {
                txtDepartmentName.Clear();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDepartments();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchDepartments();
                e.Handled = true;
            }
        }

        private void txtDepartmentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent leading spaces
            if (e.KeyChar == ' ' && txtDepartmentName.Text.Length == 0)
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

        private void SearchDepartments()
        {
            try
            {
                currentSearchTerm = txtSearch.Text.Trim();
                currentPage = 1; // Reset to first page when searching
                LoadDepartmentsWithPaging();
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
            LoadDepartments();
            ClearForm();
        }

        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            // Ensure DataGridView styling is applied
            SetupDataGridView();
            
            // Refresh to ensure proper display
            if (dgvDepartments.DataSource != null)
            {
                dgvDepartments.Refresh();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Clean up resources when form is closed
            try
            {
                if (departmentBLL != null)
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

        private void FrmDepartment_KeyDown(object sender, KeyEventArgs e)
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
                LoadDepartmentsWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDepartmentsWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadDepartmentsWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadDepartmentsWithPaging();
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
                    LoadDepartmentsWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Validation

        private string ValidateInput()
        {
            string departmentName = txtDepartmentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(departmentName))
            {
                return "Vui lòng nhập tên phòng ban!";
            }

            if (departmentName.Length < 2)
            {
                return "Tên phòng ban phải có ít nhất 2 ký tự!";
            }

            if (departmentName.Length > 30)
            {
                return "Tên phòng ban không được vượt quá 30 ký tự!";
            }

            // Check for invalid characters (optional - you can customize this)
            if (departmentName.Contains("  ")) // Double spaces
            {
                return "Tên phòng ban không được chứa khoảng trắng liên tiếp!";
            }

            return null; // Valid
        }

        #endregion

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {

        }

		private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void lblTitle_Click(object sender, EventArgs e)
		{

		}
	}
}
