using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmVoucher : Form
    {
        private readonly VoucherBLL voucherBLL;
        private List<Voucher> vouchers;
        private Voucher selectedVoucher;
        private bool isEditing = false;

        public FrmVoucher()
        {
            InitializeComponent();
            voucherBLL = new VoucherBLL();
            InitializeForm();
            LoadVouchers();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            SetupDateTimePickers();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvVouchers.RowHeadersVisible = false;
            dgvVouchers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVouchers.MultiSelect = false;
            dgvVouchers.AllowUserToAddRows = false;
            dgvVouchers.AllowUserToDeleteRows = false;
            dgvVouchers.ReadOnly = true;
            dgvVouchers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvVouchers.EnableHeadersVisualStyles = false;
            dgvVouchers.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dgvVouchers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvVouchers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvVouchers.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvVouchers.RowTemplate.Height = 30;
            dgvVouchers.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvVouchers.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvVouchers.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void SetupDateTimePickers()
        {
            dtpStartAt.Format = DateTimePickerFormat.Custom;
            dtpStartAt.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStartAt.ShowUpDown = true;
            dtpStartAt.Checked = false;

            dtpEndAt.Format = DateTimePickerFormat.Custom;
            dtpEndAt.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEndAt.ShowUpDown = true;
            dtpEndAt.Checked = false;
        }

        private void LoadVouchers()
        {
            try
            {
                vouchers = voucherBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách voucher: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvVouchers.DataSource = null;
            
            if (vouchers != null && vouchers.Count > 0)
            {
                var displayData = vouchers.Select(v => new
                {
                    Id = v.Id,
                    Code = v.Code,
                    Percentage = v.Percentage,
                    Description = v.Description ?? "",
                    StartAt = v.StartAt.HasValue ? v.StartAt.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    EndAt = v.EndAt.HasValue ? v.EndAt.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    UsageLimit = v.UsageLimit.HasValue ? v.UsageLimit.Value.ToString() : "Không giới hạn",
                    UsageCount = v.UsageCount,
                    Active = v.Active ? "Có" : "Không",
                    CreatedAt = v.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvVouchers.DataSource = displayData;
                
                if (dgvVouchers.Columns.Count > 0)
                {
                    dgvVouchers.Columns["Id"].Visible = false;
                    dgvVouchers.Columns["Code"].HeaderText = "Mã voucher";
                    dgvVouchers.Columns["Percentage"].HeaderText = "Giảm giá (%)";
                    dgvVouchers.Columns["Description"].HeaderText = "Mô tả";
                    dgvVouchers.Columns["StartAt"].HeaderText = "Bắt đầu";
                    dgvVouchers.Columns["EndAt"].HeaderText = "Kết thúc";
                    dgvVouchers.Columns["UsageLimit"].HeaderText = "Giới hạn";
                    dgvVouchers.Columns["UsageCount"].HeaderText = "Đã dùng";
                    dgvVouchers.Columns["Active"].HeaderText = "Kích hoạt";
                    dgvVouchers.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    
                    dgvVouchers.Columns["Code"].FillWeight = 15;
                    dgvVouchers.Columns["Percentage"].FillWeight = 10;
                    dgvVouchers.Columns["Description"].FillWeight = 20;
                    dgvVouchers.Columns["StartAt"].FillWeight = 12;
                    dgvVouchers.Columns["EndAt"].FillWeight = 12;
                    dgvVouchers.Columns["UsageLimit"].FillWeight = 10;
                    dgvVouchers.Columns["UsageCount"].FillWeight = 8;
                    dgvVouchers.Columns["Active"].FillWeight = 8;
                    dgvVouchers.Columns["CreatedAt"].FillWeight = 12;
                }
            }
        }

        private void ClearForm()
        {
            txtCode.Clear();
            nudPercentage.Value = 10;
            txtDescription.Clear();
            dtpStartAt.Checked = false;
            dtpEndAt.Checked = false;
            nudUsageLimit.Value = 0; // 0 means unlimited
            chkActive.Checked = true;
            
            selectedVoucher = null;
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
            txtCode.ReadOnly = !enable;
            nudPercentage.Enabled = enable;
            txtDescription.ReadOnly = !enable;
            dtpStartAt.Enabled = enable;
            dtpEndAt.Enabled = enable;
            nudUsageLimit.Enabled = enable;
            chkActive.Enabled = enable;
            
            txtCode.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtDescription.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedVoucher != null;
            btnDelete.Enabled = !enable && selectedVoucher != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvVouchers.Enabled = !enable;
        }

        private void dgvVouchers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVouchers.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvVouchers.SelectedRows[0];
                string voucherId = row.Cells["Id"].Value.ToString();
                
                selectedVoucher = vouchers.FirstOrDefault(v => v.Id == voucherId);
                
                if (selectedVoucher != null)
                {
                    LoadVoucherToForm(selectedVoucher);
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else if (!isEditing)
            {
                ClearForm();
            }
        }

        private void LoadVoucherToForm(Voucher voucher)
        {
            txtCode.Text = voucher.Code;
            nudPercentage.Value = voucher.Percentage;
            txtDescription.Text = voucher.Description ?? string.Empty;
            
            if (voucher.StartAt.HasValue)
            {
                dtpStartAt.Value = voucher.StartAt.Value;
                dtpStartAt.Checked = true;
            }
            else
            {
                dtpStartAt.Checked = false;
            }
            
            if (voucher.EndAt.HasValue)
            {
                dtpEndAt.Value = voucher.EndAt.Value;
                dtpEndAt.Checked = true;
            }
            else
            {
                dtpEndAt.Checked = false;
            }
            
            if (voucher.UsageLimit.HasValue)
            {
                nudUsageLimit.Value = voucher.UsageLimit.Value;
            }
            else
            {
                nudUsageLimit.Value = 0; // 0 means unlimited
            }
            
            chkActive.Checked = voucher.Active;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedVoucher = null;
            ClearForm();
            isEditing = true;
            EnableEditMode(true);
            btnSave.Enabled = true;
            txtCode.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedVoucher != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtCode.Focus();
                txtCode.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVoucher == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa voucher '{selectedVoucher.Code}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = voucherBLL.Delete(selectedVoucher.Id);
                    if (success)
                    {
                        MessageBox.Show("Xóa voucher thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVouchers();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa voucher!", "Lỗi", 
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
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã voucher!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                if (nudPercentage.Value <= 0 || nudPercentage.Value > 100)
                {
                    MessageBox.Show("Phần trăm giảm giá phải từ 0.01 đến 100!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPercentage.Focus();
                    return;
                }

                // Validate date range
                if (dtpStartAt.Checked && dtpEndAt.Checked)
                {
                    if (dtpStartAt.Value >= dtpEndAt.Value)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Lỗi nhập liệu", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtpStartAt.Focus();
                        return;
                    }
                }

                Voucher voucher = selectedVoucher ?? new Voucher
                {
                    Id = voucherBLL.GenerateVoucherID(),
                    UsageCount = 0,
                    CreatedAt = DateTime.Now
                };
                
                voucher.Code = txtCode.Text.Trim().ToUpper();
                voucher.Percentage = nudPercentage.Value;
                voucher.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
                voucher.StartAt = dtpStartAt.Checked ? (DateTime?)dtpStartAt.Value : null;
                voucher.EndAt = dtpEndAt.Checked ? (DateTime?)dtpEndAt.Value : null;
                voucher.UsageLimit = nudUsageLimit.Value > 0 ? (int?)nudUsageLimit.Value : null; // 0 means unlimited (null)
                voucher.Active = chkActive.Checked;
                voucher.UpdatedAt = DateTime.Now;

                bool success;
                string message;

                if (selectedVoucher == null) // Add new
                {
                    success = voucherBLL.Insert(voucher);
                    message = success ? "Thêm voucher thành công!" : "Không thể thêm voucher!";
                }
                else // Update existing
                {
                    success = voucherBLL.Update(voucher);
                    message = success ? "Cập nhật voucher thành công!" : "Không thể cập nhật voucher!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVouchers();
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
            if (selectedVoucher != null)
            {
                LoadVoucherToForm(selectedVoucher);
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    LoadVouchers();
                    return;
                }

                var criteria = new SearchCriteria
                {
                    SearchTerm = txtSearch.Text.Trim(),
                    PageNumber = 1,
                    PageSize = 1000
                };

                var result = voucherBLL.SearchVouchers(criteria);
                vouchers = result.Data;
                BindDataGridView();
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
            LoadVouchers();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
