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
    // Helper class for ComboBox display
    public class PositionDisplayItem
    {
        public string PositionID { get; set; }
        public string PositionName { get; set; }
        
        public PositionDisplayItem(string positionId, string positionName)
        {
            PositionID = positionId;
            PositionName = positionName;
        }
        
        public override string ToString()
        {
            return PositionName;
        }
    }

    public partial class FrmUser : Form
    {
        private readonly UserBLL userBLL;
        private List<User> users;
        private List<Position> positions;
        private List<Role> roles;
        private User selectedUser;
        private bool isEditing = false;
        
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;
        private string currentPositionFilter = null;
        private UserStatus? currentStatusFilter = null;

        public FrmUser()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            InitializeForm();
            LoadPositions();
            LoadRoles();
            LoadUsers();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            SetupPagination();
            SetupFilters();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupPagination()
        {
            cmbPageSize.SelectedIndex = 1; // Default to 20
            pageSize = 20;
        }

        private void SetupFilters()
        {
            // Setup Position filter - will be populated in LoadPositions()
            cmbFilterPosition.DisplayMember = "PositionName";
            cmbFilterPosition.ValueMember = "PositionID";
            
            // Setup Status filter
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả", "Hoạt động", "Không hoạt động" });
            cmbFilterStatus.SelectedIndex = 0;
        }

        private void LoadPositions()
        {
            try
            {
                positions = userBLL.GetAllPositions();
                
                // Setup Position filter ComboBox
                cmbFilterPosition.DataSource = null;
                cmbFilterPosition.Items.Clear();
                
                // Create list with "Tất cả" option and all positions
                var positionFilterList = new List<PositionDisplayItem>();
                positionFilterList.Add(new PositionDisplayItem("", "Tất cả"));
                
                foreach (var position in positions)
                {
                    positionFilterList.Add(new PositionDisplayItem(position.PositionID, position.PositionName));
                }
                
                cmbFilterPosition.DataSource = positionFilterList;
                cmbFilterPosition.DisplayMember = "PositionName";
                cmbFilterPosition.ValueMember = "PositionID";
                cmbFilterPosition.SelectedIndex = 0;
                
                // Setup Position ComboBox in form
                cmbPosition.DataSource = null;
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.ValueMember = "PositionID";
                cmbPosition.DataSource = positions;
                cmbPosition.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vị trí: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            try
            {
                roles = userBLL.GetAllRoles();
                
                cmbRole.DataSource = null;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
                cmbRole.DataSource = roles;
                cmbRole.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vai trò: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                LoadUsersWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsersWithPaging()
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

                string positionId = currentPositionFilter;
                if (positionId == "")
                    positionId = null;

                var result = userBLL.GetUsersWithPaging(criteria, positionId, currentStatusFilter);
                users = result.Data ?? new List<User>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                users = new List<User>();
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
            dgvUsers.DataSource = null;
            
            if (users != null && users.Count > 0)
            {
                var displayData = users.Select(u => new
                {
                    UserID = u.UserID,
                    LastName = u.LastName,
                    FirstName = u.FirstName,
                    FullName = $"{u.LastName} {u.FirstName}",
                    UserName = u.UserName,
                    PhoneNumber = u.PhoneNumber ?? "",
                    PositionName = u.Position?.PositionName ?? "Chưa xác định",
                    RoleName = u.Role?.RoleName ?? "Chưa xác định",
                    Status = u.Status == UserStatus.active ? "Hoạt động" : "Không hoạt động",
                    CreatedAt = u.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvUsers.DataSource = displayData;
                
                if (dgvUsers.Columns.Count > 0)
                {
                    dgvUsers.Columns["UserID"].Visible = false;
                    dgvUsers.Columns["LastName"].Visible = false;
                    dgvUsers.Columns["FirstName"].Visible = false;
                    dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";
                    dgvUsers.Columns["UserName"].HeaderText = "Tên đăng nhập";
                    dgvUsers.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
                    dgvUsers.Columns["PositionName"].HeaderText = "Vị trí";
                    dgvUsers.Columns["RoleName"].HeaderText = "Vai trò";
                    dgvUsers.Columns["Status"].HeaderText = "Trạng thái";
                    dgvUsers.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    
                    dgvUsers.Columns["FullName"].FillWeight = 20;
                    dgvUsers.Columns["UserName"].FillWeight = 15;
                    dgvUsers.Columns["PhoneNumber"].FillWeight = 12;
                    dgvUsers.Columns["PositionName"].FillWeight = 15;
                    dgvUsers.Columns["RoleName"].FillWeight = 15;
                    dgvUsers.Columns["Status"].FillWeight = 10;
                    dgvUsers.Columns["CreatedAt"].FillWeight = 13;
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
            lblStatus.Text = $"Hiển thị {users?.Count ?? 0} / {totalRecords} nhân viên";
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
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhoneNumber.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cmbPosition.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
            cmbUserStatus.SelectedIndex = 0; // Default to active
            selectedUser = null;
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
            txtLastName.ReadOnly = !enable;
            txtLastName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtFirstName.ReadOnly = !enable;
            txtFirstName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtPhoneNumber.ReadOnly = !enable;
            txtPhoneNumber.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtUserName.ReadOnly = !enable;
            txtUserName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtPassword.ReadOnly = !enable;
            txtPassword.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtPassword.UseSystemPasswordChar = enable;
            cmbPosition.Enabled = enable;
            cmbRole.Enabled = enable;
            cmbUserStatus.Enabled = enable;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedUser != null;
            btnDelete.Enabled = !enable && selectedUser != null;
            btnSave.Enabled = false; // Không enable ngay, chỉ enable khi form hợp lệ
            btnCancel.Enabled = enable;
            
            dgvUsers.Enabled = !enable;
            
            // Thêm event handlers để validate real-time khi enable
            if (enable)
            {
                txtLastName.TextChanged += ValidateForm_TextChanged;
                txtFirstName.TextChanged += ValidateForm_TextChanged;
                txtUserName.TextChanged += ValidateForm_TextChanged;
                txtPassword.TextChanged += ValidateForm_TextChanged;
                cmbRole.SelectedIndexChanged += ValidateForm_SelectionChanged;
            }
            else
            {
                txtLastName.TextChanged -= ValidateForm_TextChanged;
                txtFirstName.TextChanged -= ValidateForm_TextChanged;
                txtUserName.TextChanged -= ValidateForm_TextChanged;
                txtPassword.TextChanged -= ValidateForm_TextChanged;
                cmbRole.SelectedIndexChanged -= ValidateForm_SelectionChanged;
            }
        }
        
        private void ValidateForm_TextChanged(object sender, EventArgs e)
        {
            ValidateFormAndEnableSave();
        }
        
        private void ValidateForm_SelectionChanged(object sender, EventArgs e)
        {
            ValidateFormAndEnableSave();
        }
        
        private void ValidateFormAndEnableSave()
        {
            if (!isEditing)
            {
                btnSave.Enabled = false;
                return;
            }
            
            // Kiểm tra các trường bắt buộc
            bool isValid = !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                          !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                          !string.IsNullOrWhiteSpace(txtUserName.Text) &&
                          txtUserName.Text.Trim().Length >= 3 &&
                          !string.IsNullOrWhiteSpace(txtPassword.Text) &&
                          txtPassword.Text.Trim().Length >= 3 &&
                          cmbRole.SelectedValue != null;
            
            btnSave.Enabled = isValid;
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvUsers.SelectedRows[0];
                string userId = row.Cells["UserID"].Value.ToString();
                
                selectedUser = users.FirstOrDefault(u => u.UserID == userId);
                
                if (selectedUser != null)
                {
                    txtLastName.Text = selectedUser.LastName;
                    txtFirstName.Text = selectedUser.FirstName;
                    txtPhoneNumber.Text = selectedUser.PhoneNumber ?? "";
                    txtUserName.Text = selectedUser.UserName;
                    txtPassword.Text = selectedUser.Password;
                    txtPassword.UseSystemPasswordChar = false;
                    
                    if (!string.IsNullOrEmpty(selectedUser.PositionID))
                        cmbPosition.SelectedValue = selectedUser.PositionID;
                    else
                        cmbPosition.SelectedIndex = -1;
                    
                    if (!string.IsNullOrEmpty(selectedUser.RoleID))
                        cmbRole.SelectedValue = selectedUser.RoleID;
                    else
                        cmbRole.SelectedIndex = -1;
                    
                    cmbUserStatus.SelectedIndex = selectedUser.Status == UserStatus.active ? 0 : 1;
                    
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
            selectedUser = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            ValidateFormAndEnableSave(); // Validate sau khi enable
            txtLastName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                isEditing = true;
                EnableEditMode(true);
                ValidateFormAndEnableSave(); // Validate sau khi enable
                txtLastName.Focus();
                txtLastName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUser == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên '{selectedUser.LastName} {selectedUser.FirstName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = userBLL.DeleteUser(selectedUser.UserID);
                    if (success)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsersWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên!", "Lỗi", 
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
                    txtLastName.Focus();
                    return;
                }

                User user = selectedUser ?? new User();
                user.LastName = txtLastName.Text.Trim();
                user.FirstName = txtFirstName.Text.Trim();
                user.PhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? null : txtPhoneNumber.Text.Trim();
                user.UserName = txtUserName.Text.Trim();
                user.Password = txtPassword.Text.Trim();
                user.PositionID = cmbPosition.SelectedValue?.ToString();
                user.RoleID = cmbRole.SelectedValue?.ToString();
                user.Status = cmbUserStatus.SelectedIndex == 0 ? UserStatus.active : UserStatus.inactive;

                bool success;
                string message;

                if (selectedUser == null) // Add new
                {
                    success = userBLL.AddUser(user);
                    message = success ? "Thêm nhân viên thành công!" : "Không thể thêm nhân viên!";
                }
                else // Update existing
                {
                    success = userBLL.UpdateUser(user);
                    message = success ? "Cập nhật nhân viên thành công!" : "Không thể cập nhật nhân viên!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsersWithPaging();
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
            if (selectedUser != null)
            {
                txtLastName.Text = selectedUser.LastName;
                txtFirstName.Text = selectedUser.FirstName;
                txtPhoneNumber.Text = selectedUser.PhoneNumber ?? "";
                txtUserName.Text = selectedUser.UserName;
                txtPassword.Text = selectedUser.Password;
                
                if (!string.IsNullOrEmpty(selectedUser.PositionID))
                    cmbPosition.SelectedValue = selectedUser.PositionID;
                else
                    cmbPosition.SelectedIndex = -1;
                
                if (!string.IsNullOrEmpty(selectedUser.RoleID))
                    cmbRole.SelectedValue = selectedUser.RoleID;
                else
                    cmbRole.SelectedIndex = -1;
                
                cmbUserStatus.SelectedIndex = selectedUser.Status == UserStatus.active ? 0 : 1;
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchUsers();
                e.Handled = true;
            }
        }

        private void SearchUsers()
        {
            try
            {
                currentSearchTerm = txtSearch.Text.Trim();
                currentPage = 1;
                
                // Get filter values
                if (cmbFilterPosition.SelectedItem is PositionDisplayItem selectedItem)
                {
                    if (string.IsNullOrEmpty(selectedItem.PositionID))
                    {
                        currentPositionFilter = null; // "Tất cả"
                    }
                    else
                    {
                        currentPositionFilter = selectedItem.PositionID;
                    }
                }
                else
                {
                    currentPositionFilter = null;
                }
                
                if (cmbFilterStatus.SelectedIndex == 0)
                    currentStatusFilter = null;
                else if (cmbFilterStatus.SelectedIndex == 1)
                    currentStatusFilter = UserStatus.active;
                else
                    currentStatusFilter = UserStatus.inactive;
                
                LoadUsersWithPaging();
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
            cmbFilterPosition.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            currentSearchTerm = string.Empty;
            currentPositionFilter = null;
            currentStatusFilter = null;
            currentPage = 1;
            LoadUsers();
            ClearForm();
        }

        private void cmbFilterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterPosition.SelectedIndex >= 0)
            {
                SearchUsers();
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterStatus.SelectedIndex >= 0)
            {
                SearchUsers();
            }
        }

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadUsersWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadUsersWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadUsersWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadUsersWithPaging();
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
                    LoadUsersWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Validation

        private string ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                return "Vui lòng nhập họ!";

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                return "Vui lòng nhập tên!";

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
                return "Vui lòng nhập tên đăng nhập!";

            if (txtUserName.Text.Trim().Length < 3)
                return "Tên đăng nhập phải có ít nhất 3 ký tự!";

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                return "Vui lòng nhập mật khẩu!";

            if (txtPassword.Text.Trim().Length < 3)
                return "Mật khẩu phải có ít nhất 3 ký tự!";

            if (cmbRole.SelectedValue == null)
                return "Vui lòng chọn vai trò!";

            return null;
        }

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (userBLL != null)
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

