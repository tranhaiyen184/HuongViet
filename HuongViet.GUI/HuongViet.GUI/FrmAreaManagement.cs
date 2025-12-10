using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmAreaManagement : Form
    {
        private readonly AreaBLL areaBLL;
        private List<Area> areas;
        private Area selectedArea;
        private bool isEditing = false;

        public FrmAreaManagement()
        {
            InitializeComponent();
            areaBLL = new AreaBLL();
            InitializeForm();
            LoadAreas();
            
            // Thêm event click vào form để bỏ chọn
            this.Click += FrmAreaManagement_Click;
        }
        
        private void FrmAreaManagement_Click(object sender, EventArgs e)
        {
            // Bỏ chọn tất cả và quay về trạng thái sẵn sàng thêm mới
            dgvAreas.ClearSelection();
            selectedArea = null;
            ClearForm();
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvAreas.RowHeadersVisible = false;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.MultiSelect = false;
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.ReadOnly = true;
            dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAreas()
        {
            try
            {
                areas = areaBLL.GetAllAreas();
                BindDataGridView();
                // Bỏ chọn tất cả để form ở trạng thái sẵn sàng thêm mới
                dgvAreas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khu vực: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvAreas.DataSource = null;
            
            if (areas != null && areas.Count > 0)
            {
                var displayData = areas.Select(a => new
                {
                    AreaID = a.AreaID,
                    AreaName = a.AreaName
                }).ToList();

                dgvAreas.DataSource = displayData;
                
                if (dgvAreas.Columns.Count > 0)
                {
                    dgvAreas.Columns["AreaID"].Visible = false;
                    dgvAreas.Columns["AreaName"].HeaderText = "Tên khu vực";
                }
            }
        }

        private void ClearForm()
        {
            txtAreaName.Clear();
            selectedArea = null;
            isEditing = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true; // Cho phép lưu ngay để thêm mới
            btnCancel.Enabled = false;
            
            EnableEditMode(true); // Cho phép nhập liệu ngay
        }

        private void EnableEditMode(bool enable)
        {
            txtAreaName.ReadOnly = !enable;
            txtAreaName.BackColor = enable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            
            // Khi ở chế độ mặc định (không chọn gì), vẫn cho phép thêm mới
            if (selectedArea == null)
            {
                btnAdd.Enabled = false; // Ẩn nút thêm vì đã sẵn sàng thêm
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true; // Cho phép lưu để thêm mới
                btnCancel.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = !enable;
                btnEdit.Enabled = !enable;
                btnDelete.Enabled = !enable;
                btnSave.Enabled = enable;
                btnCancel.Enabled = enable;
            }
            
            dgvAreas.Enabled = true; // Luôn cho phép chọn từ danh sách
        }

        private void dgvAreas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count > 0)
            {
                var row = dgvAreas.SelectedRows[0];
                string areaId = row.Cells["AreaID"].Value.ToString();
                
                selectedArea = areas.FirstOrDefault(a => a.AreaID == areaId);
                
                if (selectedArea != null)
                {
                    txtAreaName.Text = selectedArea.AreaName;
                    txtAreaName.ReadOnly = true;
                    txtAreaName.BackColor = System.Drawing.SystemColors.Control;
                    
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    isEditing = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedArea = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            txtAreaName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedArea != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtAreaName.Focus();
                txtAreaName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedArea == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khu vực '{selectedArea.AreaName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = areaBLL.DeleteArea(selectedArea.AreaID);
                    if (success)
                    {
                        MessageBox.Show("Xóa khu vực thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAreas();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khu vực!", "Lỗi", 
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
                if (string.IsNullOrWhiteSpace(txtAreaName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khu vực!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAreaName.Focus();
                    return;
                }

                if (txtAreaName.Text.Trim().Length > 30)
                {
                    MessageBox.Show("Tên khu vực không được vượt quá 30 ký tự!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAreaName.Focus();
                    return;
                }

                Area area = selectedArea ?? new Area();
                area.AreaName = txtAreaName.Text.Trim();

                bool success;
                string message;

                if (selectedArea == null) // Add new
                {
                    success = areaBLL.AddArea(area);
                    message = success ? "Thêm khu vực thành công!" : "Không thể thêm khu vực!";
                }
                else // Update existing
                {
                    success = areaBLL.UpdateArea(area);
                    message = success ? "Cập nhật khu vực thành công!" : "Không thể cập nhật khu vực!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAreas();
                    // Sau khi lưu thành công, quay về trạng thái sẵn sàng thêm mới
                    selectedArea = null;
                    ClearForm();
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
            dgvAreas.ClearSelection();
            selectedArea = null;
            ClearForm();
        }

		private void lblTitle_Click(object sender, EventArgs e)
		{

		}
	}
}

