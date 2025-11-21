using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmRole : Form
    {
        private readonly RoleBLL roleBLL;
        private List<Role> roles;
        private List<Permission> selectedPermissions;
        private Role selectedRole;
        private bool isEditing = false;

        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;

        public FrmRole()
        {
            InitializeComponent();
            roleBLL = new RoleBLL();
            InitializeForm();
            LoadRoles();
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            SetupPagination();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.MultiSelect = false;
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.ReadOnly = true;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupPagination()
        {
            cmbPageSize.SelectedIndex = 1; // Default to 20
            pageSize = 20;
        }

        private void LoadRoles()
        {
            try
            {
                LoadRolesWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vai trò: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolesWithPaging()
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

                var result = roleBLL.SearchRoles(criteria);
                roles = result.Data ?? new List<Role>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vai trò: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                roles = new List<Role>();
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
            dgvRoles.DataSource = null;

            if (roles != null && roles.Count > 0)
            {
                var displayData = roles.Select(r => new
                {
                    RoleID = r.RoleID,
                    RoleCode = r.RoleCode,
                    RoleName = r.RoleName,
                    PermissionCount = r.Permissions?.Count ?? 0,
                    CreatedAt = r.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvRoles.DataSource = displayData;

                if (dgvRoles.Columns.Count > 0)
                {
                    dgvRoles.Columns["RoleID"].Visible = false;
                    dgvRoles.Columns["RoleCode"].HeaderText = "Mã vai trò";
                    dgvRoles.Columns["RoleName"].HeaderText = "Tên vai trò";
                    dgvRoles.Columns["PermissionCount"].HeaderText = "Số quyền";
                    dgvRoles.Columns["CreatedAt"].HeaderText = "Ngày tạo";

                    dgvRoles.Columns["RoleCode"].FillWeight = 25;
                    dgvRoles.Columns["RoleName"].FillWeight = 35;
                    dgvRoles.Columns["PermissionCount"].FillWeight = 15;
                    dgvRoles.Columns["CreatedAt"].FillWeight = 25;
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
            lblStatus.Text = $"Hiển thị {roles?.Count ?? 0} / {totalRecords} vai trò";
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
            txtRoleName.Clear();
            txtRoleCode.Clear();
            selectedPermissions = new List<Permission>();
            UpdatePermissionDisplay();
            selectedRole = null;
            isEditing = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            EnableEditMode(false);
        }

        private void EnableEditMode(bool enable)
        {
            txtRoleName.ReadOnly = !enable;
            txtRoleName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtRoleCode.ReadOnly = true; // Always read-only, auto-generated
            txtRoleCode.BackColor = SystemColors.Control;
            btnSelectPermissions.Enabled = enable;
            dgvRoles.Enabled = !enable;
            
            // Thêm event handler để validate real-time khi enable
            if (enable)
            {
                txtRoleName.TextChanged += ValidateRoleForm_TextChanged;
            }
            else
            {
                txtRoleName.TextChanged -= ValidateRoleForm_TextChanged;
            }
        }
        
        private void ValidateRoleForm_TextChanged(object sender, EventArgs e)
        {
            ValidateRoleFormAndEnableSave();
        }
        
        private void ValidateRoleFormAndEnableSave()
        {
            if (!isEditing)
            {
                btnSave.Enabled = false;
                return;
            }
            
            // Kiểm tra trường bắt buộc
            bool isValid = !string.IsNullOrWhiteSpace(txtRoleName.Text) &&
                          txtRoleName.Text.Trim().Length <= 50;
            
            btnSave.Enabled = isValid;
        }

        private void UpdatePermissionDisplay()
        {
            if (selectedPermissions != null && selectedPermissions.Count > 0)
            {
                lblPermissionCount.Text = $"Đã chọn: {selectedPermissions.Count} quyền";
                lblPermissionCount.ForeColor = Color.Green;
            }
            else
            {
                lblPermissionCount.Text = "Chưa chọn quyền nào";
                lblPermissionCount.ForeColor = Color.Gray;
            }
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvRoles.SelectedRows[0];
                string roleId = row.Cells["RoleID"].Value.ToString();

                selectedRole = roles.FirstOrDefault(r => r.RoleID == roleId);

                if (selectedRole != null)
                {
                    txtRoleName.Text = selectedRole.RoleName;
                    txtRoleCode.Text = selectedRole.RoleCode;

                    // Load permissions for this role
                    selectedPermissions = roleBLL.GetRolePermissions(selectedRole.RoleID);
                    UpdatePermissionDisplay();

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
            selectedRole = null;
            isEditing = true;
            selectedPermissions = new List<Permission>();
            ClearForm();
            EnableEditMode(true);
            ValidateRoleFormAndEnableSave(); // Validate sau khi enable
            txtRoleName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRole != null)
            {
                isEditing = true;
                EnableEditMode(true);
                ValidateRoleFormAndEnableSave(); // Validate sau khi enable
                txtRoleName.Focus();
                txtRoleName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRole == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vai trò '{selectedRole.RoleName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = roleBLL.DeleteRole(selectedRole.RoleID);
                    if (success)
                    {
                        MessageBox.Show("Xóa vai trò thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRolesWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vai trò!", "Lỗi",
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
                string validationError = ValidateInput();
                if (!string.IsNullOrEmpty(validationError))
                {
                    MessageBox.Show(validationError, "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRoleName.Focus();
                    return;
                }

                Role role = selectedRole ?? new Role();
                role.RoleName = txtRoleName.Text.Trim();
                // RoleCode will be auto-generated in BLL if empty

                List<string> permissionIds = selectedPermissions?.Select(p => p.PermissionID).ToList();

                bool success;
                string message;

                if (selectedRole == null) // Add new
                {
                    success = roleBLL.AddRole(role, permissionIds);
                    message = success ? "Thêm vai trò thành công!" : "Không thể thêm vai trò!";
                }
                else // Update existing
                {
                    success = roleBLL.UpdateRole(role, permissionIds);
                    message = success ? "Cập nhật vai trò thành công!" : "Không thể cập nhật vai trò!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRolesWithPaging();
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
            if (selectedRole != null)
            {
                txtRoleName.Text = selectedRole.RoleName;
                txtRoleCode.Text = selectedRole.RoleCode;
                selectedPermissions = roleBLL.GetRolePermissions(selectedRole.RoleID);
                UpdatePermissionDisplay();
            }
            else
            {
                ClearForm();
            }

            isEditing = false;
            EnableEditMode(false);
        }

        private void btnSelectPermissions_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frmPermissionSelection = new FrmPermissionSelection(selectedPermissions))
                {
                    if (frmPermissionSelection.ShowDialog() == DialogResult.OK)
                    {
                        selectedPermissions = frmPermissionSelection.SelectedPermissions;
                        UpdatePermissionDisplay();
                        ValidateRoleFormAndEnableSave(); // Validate lại sau khi chọn permissions
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chọn quyền: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRoles();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchRoles();
                e.Handled = true;
            }
        }

        private void SearchRoles()
        {
            try
            {
                currentSearchTerm = txtSearch.Text.Trim();
                currentPage = 1;
                LoadRolesWithPaging();
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
            LoadRoles();
            ClearForm();
        }

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadRolesWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadRolesWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadRolesWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadRolesWithPaging();
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
                    LoadRolesWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Validation

        private string ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
                return "Vui lòng nhập tên vai trò!";

            if (txtRoleName.Text.Trim().Length > 50)
                return "Tên vai trò không được vượt quá 50 ký tự!";

            return null;
        }

        #endregion

        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {
            // Auto-generate RoleCode preview when RoleName changes
            if (isEditing && !string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                // Use the same logic as in RoleBLL
                string roleCode = GenerateRoleCodePreview(txtRoleName.Text.Trim());
                txtRoleCode.Text = roleCode;
            }
        }

        private string GenerateRoleCodePreview(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return string.Empty;

            // Simple preview - convert Vietnamese characters to ASCII equivalents
            string normalized = roleName.Trim();
            
            // Replace spaces and special characters with underscore
            normalized = System.Text.RegularExpressions.Regex.Replace(normalized, @"[^a-zA-Z0-9À-ỹ\s]+", "");
            normalized = System.Text.RegularExpressions.Regex.Replace(normalized, @"\s+", "_");
            
            // Remove diacritics (simple approach for preview)
            normalized = RemoveDiacriticsSimple(normalized);
            
            // Convert to uppercase and clean up
            normalized = normalized.ToUpperInvariant();
            normalized = normalized.Trim('_');
            normalized = System.Text.RegularExpressions.Regex.Replace(normalized, @"_+", "_");

            return normalized;
        }

        private string RemoveDiacriticsSimple(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // Simple Vietnamese diacritics removal
            var map = new Dictionary<char, char>
            {
                {'à', 'a'}, {'á', 'a'}, {'ạ', 'a'}, {'ả', 'a'}, {'ã', 'a'}, {'â', 'a'}, {'ầ', 'a'}, {'ấ', 'a'}, {'ậ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'}, {'ă', 'a'}, {'ằ', 'a'}, {'ắ', 'a'}, {'ặ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'},
                {'è', 'e'}, {'é', 'e'}, {'ẹ', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'}, {'ê', 'e'}, {'ề', 'e'}, {'ế', 'e'}, {'ệ', 'e'}, {'ể', 'e'}, {'ễ', 'e'},
                {'ì', 'i'}, {'í', 'i'}, {'ị', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'},
                {'ò', 'o'}, {'ó', 'o'}, {'ọ', 'o'}, {'ỏ', 'o'}, {'õ', 'o'}, {'ô', 'o'}, {'ồ', 'o'}, {'ố', 'o'}, {'ộ', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'}, {'ơ', 'o'}, {'ờ', 'o'}, {'ớ', 'o'}, {'ợ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'},
                {'ù', 'u'}, {'ú', 'u'}, {'ụ', 'u'}, {'ủ', 'u'}, {'ũ', 'u'}, {'ư', 'u'}, {'ừ', 'u'}, {'ứ', 'u'}, {'ự', 'u'}, {'ử', 'u'}, {'ữ', 'u'},
                {'ỳ', 'y'}, {'ý', 'y'}, {'ỵ', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'},
                {'đ', 'd'},
                {'À', 'A'}, {'Á', 'A'}, {'Ạ', 'A'}, {'Ả', 'A'}, {'Ã', 'A'}, {'Â', 'A'}, {'Ầ', 'A'}, {'Ấ', 'A'}, {'Ậ', 'A'}, {'Ẩ', 'A'}, {'Ẫ', 'A'}, {'Ă', 'A'}, {'Ằ', 'A'}, {'Ắ', 'A'}, {'Ặ', 'A'}, {'Ẳ', 'A'}, {'Ẵ', 'A'},
                {'È', 'E'}, {'É', 'E'}, {'Ẹ', 'E'}, {'Ẻ', 'E'}, {'Ẽ', 'E'}, {'Ê', 'E'}, {'Ề', 'E'}, {'Ế', 'E'}, {'Ệ', 'E'}, {'Ể', 'E'}, {'Ễ', 'E'},
                {'Ì', 'I'}, {'Í', 'I'}, {'Ị', 'I'}, {'Ỉ', 'I'}, {'Ĩ', 'I'},
                {'Ò', 'O'}, {'Ó', 'O'}, {'Ọ', 'O'}, {'Ỏ', 'O'}, {'Õ', 'O'}, {'Ô', 'O'}, {'Ồ', 'O'}, {'Ố', 'O'}, {'Ộ', 'O'}, {'Ổ', 'O'}, {'Ỗ', 'O'}, {'Ơ', 'O'}, {'Ờ', 'O'}, {'Ớ', 'O'}, {'Ợ', 'O'}, {'Ở', 'O'}, {'Ỡ', 'O'},
                {'Ù', 'U'}, {'Ú', 'U'}, {'Ụ', 'U'}, {'Ủ', 'U'}, {'Ũ', 'U'}, {'Ư', 'U'}, {'Ừ', 'U'}, {'Ứ', 'U'}, {'Ự', 'U'}, {'Ử', 'U'}, {'Ữ', 'U'},
                {'Ỳ', 'Y'}, {'Ý', 'Y'}, {'Ỵ', 'Y'}, {'Ỷ', 'Y'}, {'Ỹ', 'Y'},
                {'Đ', 'D'}
            };

            var result = new System.Text.StringBuilder();
            foreach (char c in text)
            {
                if (map.ContainsKey(c))
                    result.Append(map[c]);
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (roleBLL != null)
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
    }
}

