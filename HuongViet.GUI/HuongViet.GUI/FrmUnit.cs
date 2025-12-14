using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmUnit : Form
    {
        private readonly UnitBLL unitBLL;
        private List<Unit> units;
        private Unit selectedUnit;
        private bool isEditing = false;

        public FrmUnit()
        {
            InitializeComponent();
            unitBLL = new UnitBLL();
            InitializeForm();
            LoadUnits();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }


        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvUnits.RowHeadersVisible = false;
            dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnits.MultiSelect = false;
            dgvUnits.AllowUserToAddRows = false;
            dgvUnits.AllowUserToDeleteRows = false;
            dgvUnits.ReadOnly = true;
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvUnits.EnableHeadersVisualStyles = false;
            dgvUnits.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dgvUnits.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvUnits.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUnits.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvUnits.RowTemplate.Height = 30;
            dgvUnits.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvUnits.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvUnits.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadUnits()
        {
            try
            {
                units = unitBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn vị tính: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvUnits.DataSource = null;
            
            if (units != null && units.Count > 0)
            {
                var displayData = units.Select(u => new
                {
                    UnitID = u.UnitID,
                    UnitName = u.UnitName
                }).ToList();

                dgvUnits.DataSource = displayData;
                
                if (dgvUnits.Columns.Count > 0)
                {
                    dgvUnits.Columns["UnitID"].HeaderText = "Mã đơn vị";
                    dgvUnits.Columns["UnitName"].HeaderText = "Tên đơn vị tính";
                    
                    dgvUnits.Columns["UnitID"].FillWeight = 30;
                    dgvUnits.Columns["UnitName"].FillWeight = 70;
                }
            }
        }

        private void ClearForm()
        {
            txtUnitName.Clear();
            selectedUnit = null;
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
            txtUnitName.ReadOnly = !enable;
            txtUnitName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedUnit != null;
            btnDelete.Enabled = !enable && selectedUnit != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvUnits.Enabled = !enable;
        }

        private void dgvUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUnits.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvUnits.SelectedRows[0];
                string unitId = row.Cells["UnitID"].Value.ToString();
                
                selectedUnit = units.FirstOrDefault(u => u.UnitID == unitId);
                
                if (selectedUnit != null)
                {
                    txtUnitName.Text = selectedUnit.UnitName;
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
            selectedUnit = null;
            ClearForm();
            isEditing = true; // Set sau khi ClearForm để không bị reset
            EnableEditMode(true);
            btnSave.Enabled = true; // Enable nút Lưu ngay khi bấm Thêm
            txtUnitName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUnit != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtUnitName.Focus();
                txtUnitName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUnit == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đơn vị tính '{selectedUnit.UnitName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = unitBLL.Delete(selectedUnit.UnitID);
                    if (success)
                    {
                        MessageBox.Show("Xóa đơn vị tính thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUnits();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa đơn vị tính!", "Lỗi", 
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
                if (string.IsNullOrWhiteSpace(txtUnitName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đơn vị tính!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitName.Focus();
                    return;
                }

                Unit unit = selectedUnit ?? new Unit
                {
                    UnitID = unitBLL.GenerateNewUnitID()
                };
                
                unit.UnitName = txtUnitName.Text.Trim();

                bool success;
                string message;

                if (selectedUnit == null) // Add new
                {
                    success = unitBLL.Insert(unit);
                    message = success ? "Thêm đơn vị tính thành công!" : "Không thể thêm đơn vị tính!";
                }
                else // Update existing
                {
                    success = unitBLL.Update(unit);
                    message = success ? "Cập nhật đơn vị tính thành công!" : "Không thể cập nhật đơn vị tính!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUnits();
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
            if (selectedUnit != null)
            {
                txtUnitName.Text = selectedUnit.UnitName;
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
                string term = txtSearch.Text.Trim();

                // Always start from the full list, then filter in-memory for simplicity
                units = unitBLL.GetAll();

                if (!string.IsNullOrEmpty(term))
                {
                    units = units
                        .Where(u =>
                            (!string.IsNullOrEmpty(u.UnitID) && u.UnitID.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(u.UnitName) && u.UnitName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0))
                        .ToList();
                }

                BindDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm đơn vị tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUnits();
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

