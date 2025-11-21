using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmPermissionSelection : Form
    {
        private readonly RoleBLL roleBLL;
        private List<Permission> allPermissions;
        private List<Permission> initialSelectedPermissions;

        public List<Permission> SelectedPermissions { get; private set; }

        public FrmPermissionSelection(List<Permission> selectedPermissions = null)
        {
            InitializeComponent();
            roleBLL = new RoleBLL();
            initialSelectedPermissions = selectedPermissions ?? new List<Permission>();
            SelectedPermissions = new List<Permission>(initialSelectedPermissions);
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                allPermissions = roleBLL.GetAllPermissions();
                BindCheckBoxList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách quyền: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allPermissions = new List<Permission>();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BindCheckBoxList()
        {
            flpPermissions.Controls.Clear();

            if (allPermissions != null && allPermissions.Count > 0)
            {
                foreach (var permission in allPermissions.OrderBy(p => p.PermissionName))
                {
                    var chkPermission = new CheckBox
                    {
                        Text = $"{permission.PermissionName} ({permission.PermissionCode})",
                        Tag = permission,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Segoe UI", 9F),
                        Margin = new Padding(5, 5, 5, 5)
                    };

                    // Check if this permission is in the selected list
                    chkPermission.Checked = SelectedPermissions.Any(p => p.PermissionID == permission.PermissionID);
                    chkPermission.CheckedChanged += ChkPermission_CheckedChanged;

                    flpPermissions.Controls.Add(chkPermission);
                }
            }
            else
            {
                var lblNoData = new Label
                {
                    Text = "Không có quyền nào",
                    Font = new System.Drawing.Font("Segoe UI", 9F),
                    ForeColor = System.Drawing.Color.Gray
                };
                flpPermissions.Controls.Add(lblNoData);
            }

            UpdateSelectedCount();
        }

        private void ChkPermission_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk != null && chk.Tag is Permission permission)
            {
                if (chk.Checked)
                {
                    if (!SelectedPermissions.Any(p => p.PermissionID == permission.PermissionID))
                    {
                        SelectedPermissions.Add(permission);
                    }
                }
                else
                {
                    SelectedPermissions.RemoveAll(p => p.PermissionID == permission.PermissionID);
                }
                UpdateSelectedCount();
            }
        }

        private void UpdateSelectedCount()
        {
            lblSelectedCount.Text = $"Đã chọn: {SelectedPermissions.Count} / {allPermissions?.Count ?? 0} quyền";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in flpPermissions.Controls)
            {
                if (control is CheckBox chk && chk.Tag is Permission)
                {
                    chk.Checked = true;
                }
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in flpPermissions.Controls)
            {
                if (control is CheckBox chk && chk.Tag is Permission)
                {
                    chk.Checked = false;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Restore initial selection
            SelectedPermissions = new List<Permission>(initialSelectedPermissions);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            
            foreach (Control control in flpPermissions.Controls)
            {
                if (control is CheckBox chk && chk.Tag is Permission permission)
                {
                    bool visible = string.IsNullOrEmpty(searchTerm) ||
                        permission.PermissionName.ToLower().Contains(searchTerm) ||
                        permission.PermissionCode.ToLower().Contains(searchTerm);
                    chk.Visible = visible;
                }
            }
        }
    }
}

