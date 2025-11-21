using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmFloorManagement : Form
    {
        private readonly FloorBLL floorBLL;
        private List<Floor> floors;
        private Floor selectedFloor;
        private bool isEditing = false;

        public FrmFloorManagement()
        {
            InitializeComponent();
            floorBLL = new FloorBLL();
            InitializeForm();
            LoadFloors();
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvFloors.RowHeadersVisible = false;
            dgvFloors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFloors.MultiSelect = false;
            dgvFloors.AllowUserToAddRows = false;
            dgvFloors.AllowUserToDeleteRows = false;
            dgvFloors.ReadOnly = true;
            dgvFloors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadFloors()
        {
            try
            {
                floors = floorBLL.GetAllFloors();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tầng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvFloors.DataSource = null;
            
            if (floors != null && floors.Count > 0)
            {
                var displayData = floors.Select(f => new
                {
                    FloorID = f.FloorID,
                    FloorNumber = f.FloorNumber,
                    CreatedAt = f.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    UpdatedAt = f.UpdatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvFloors.DataSource = displayData;
                
                if (dgvFloors.Columns.Count > 0)
                {
                    dgvFloors.Columns["FloorID"].Visible = false;
                    dgvFloors.Columns["FloorNumber"].HeaderText = "Số tầng";
                    dgvFloors.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    dgvFloors.Columns["UpdatedAt"].HeaderText = "Ngày cập nhật";
                }
            }
        }

        private void ClearForm()
        {
            nudFloorNumber.Value = 0;
            selectedFloor = null;
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
            nudFloorNumber.Enabled = enable;
            nudFloorNumber.BackColor = enable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedFloor != null;
            btnDelete.Enabled = !enable && selectedFloor != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvFloors.Enabled = !enable;
        }

        private void dgvFloors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFloors.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvFloors.SelectedRows[0];
                string floorId = row.Cells["FloorID"].Value.ToString();
                
                selectedFloor = floors.FirstOrDefault(f => f.FloorID == floorId);
                
                if (selectedFloor != null)
                {
                    nudFloorNumber.Value = selectedFloor.FloorNumber;
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
            selectedFloor = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            nudFloorNumber.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedFloor != null)
            {
                isEditing = true;
                EnableEditMode(true);
                nudFloorNumber.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedFloor == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tầng {selectedFloor.FloorNumber}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = floorBLL.DeleteFloor(selectedFloor.FloorID);
                    if (success)
                    {
                        MessageBox.Show("Xóa tầng thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFloors();
                        ClearForm();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa tầng!", "Lỗi", 
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
                if (nudFloorNumber.Value < 0)
                {
                    MessageBox.Show("Số tầng phải lớn hơn hoặc bằng 0!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudFloorNumber.Focus();
                    return;
                }

                Floor floor = selectedFloor ?? new Floor();
                floor.FloorNumber = (int)nudFloorNumber.Value;

                bool success;
                string message;

                if (selectedFloor == null) // Add new
                {
                    success = floorBLL.AddFloor(floor);
                    message = success ? "Thêm tầng thành công!" : "Không thể thêm tầng!";
                }
                else // Update existing
                {
                    success = floorBLL.UpdateFloor(floor);
                    message = success ? "Cập nhật tầng thành công!" : "Không thể cập nhật tầng!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFloors();
                    ClearForm();
                    EnableEditMode(false);
                    this.DialogResult = DialogResult.OK;
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
            if (selectedFloor != null)
            {
                nudFloorNumber.Value = selectedFloor.FloorNumber;
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }
    }
}

