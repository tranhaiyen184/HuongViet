using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmRoomManagement : Form
    {
        private readonly RoomBLL roomBLL;
        private List<Room> rooms;
        private List<Floor> floors;
        private Room selectedRoom;
        private bool isEditing = false;

        public FrmRoomManagement()
        {
            InitializeComponent();
            roomBLL = new RoomBLL();
            InitializeForm();
            LoadFloors();
            LoadRooms();
        }

        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.ReadOnly = true;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadFloors()
        {
            try
            {
                floors = roomBLL.GetAllFloors();
                
                cmbFloor.DataSource = null;
                var floorList = new List<FloorDisplayItem>();
                foreach (var floor in floors)
                {
                    floorList.Add(new FloorDisplayItem(floor.FloorID, $"Tầng {floor.FloorNumber}"));
                }
                
                cmbFloor.DataSource = floorList;
                cmbFloor.DisplayMember = "DisplayText";
                cmbFloor.ValueMember = "FloorID";
                cmbFloor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tầng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                rooms = roomBLL.GetAllRooms();
                // Load Floor information for each room
                foreach (var room in rooms)
                {
                    if (!string.IsNullOrEmpty(room.FloorID))
                    {
                        var floor = floors?.FirstOrDefault(f => f.FloorID == room.FloorID);
                        if (floor != null)
                        {
                            room.Floor = floor;
                        }
                    }
                }
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvRooms.DataSource = null;
            
            if (rooms != null && rooms.Count > 0)
            {
                var displayData = rooms.Select(r => new
                {
                    RoomID = r.RoomID,
                    RoomName = r.RoomName,
                    FloorDisplay = r.Floor != null ? $"Tầng {r.Floor.FloorNumber}" : "Chưa xác định",
                    RoomType = GetRoomTypeDisplayText(r.RoomType),
                    RoomStatus = GetRoomStatusDisplayText(r.RoomStatus),
                    PricePerHour = r.PricePerHour,
                    Capacity = r.Capacity,
                    CreatedAt = r.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvRooms.DataSource = displayData;
                
                if (dgvRooms.Columns.Count > 0)
                {
                    dgvRooms.Columns["RoomID"].Visible = false;
                    dgvRooms.Columns["RoomName"].HeaderText = "Tên phòng";
                    dgvRooms.Columns["FloorDisplay"].HeaderText = "Tầng";
                    dgvRooms.Columns["RoomType"].HeaderText = "Loại phòng";
                    dgvRooms.Columns["RoomStatus"].HeaderText = "Trạng thái";
                    dgvRooms.Columns["PricePerHour"].HeaderText = "Giá/giờ";
                    dgvRooms.Columns["Capacity"].HeaderText = "Sức chứa";
                    dgvRooms.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                }
            }
        }

        private string GetRoomTypeDisplayText(RoomType type)
        {
            switch (type)
            {
                case RoomType.Karaoke:
                    return "Karaoke";
                case RoomType.VIP:
                    return "VIP";
                case RoomType.MeetingRoom:
                    return "Phòng họp";
                case RoomType.Private:
                    return "Phòng riêng";
                default:
                    return type.ToString();
            }
        }

        private string GetRoomStatusDisplayText(RoomStatus status)
        {
            switch (status)
            {
                case RoomStatus.Available:
                    return "Trống";
                case RoomStatus.InUse:
                    return "Đang sử dụng";
                case RoomStatus.Maintenance:
                    return "Bảo trì";
                case RoomStatus.Closed:
                    return "Đóng";
                default:
                    return status.ToString();
            }
        }

        private void ClearForm()
        {
            txtRoomName.Clear();
            cmbFloor.SelectedIndex = -1;
            cmbRoomType.SelectedIndex = 0;
            cmbRoomStatus.SelectedIndex = 0;
            nudPricePerHour.Value = 0;
            nudCapacity.Value = 1;
            selectedRoom = null;
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
            txtRoomName.ReadOnly = !enable;
            txtRoomName.BackColor = enable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            cmbFloor.Enabled = enable;
            cmbRoomType.Enabled = enable;
            cmbRoomStatus.Enabled = enable;
            nudPricePerHour.Enabled = enable;
            nudCapacity.Enabled = enable;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedRoom != null;
            btnDelete.Enabled = !enable && selectedRoom != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvRooms.Enabled = !enable;
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvRooms.SelectedRows[0];
                string roomId = row.Cells["RoomID"].Value.ToString();
                
                selectedRoom = rooms.FirstOrDefault(r => r.RoomID == roomId);
                
                if (selectedRoom != null)
                {
                    txtRoomName.Text = selectedRoom.RoomName;
                    
                    if (!string.IsNullOrEmpty(selectedRoom.FloorID))
                        cmbFloor.SelectedValue = selectedRoom.FloorID;
                    else
                        cmbFloor.SelectedIndex = -1;
                    
                    // Map RoomType enum to ComboBox index
                    cmbRoomType.SelectedIndex = (int)selectedRoom.RoomType;
                    
                    // Map RoomStatus enum to ComboBox index
                    int statusIndex = 0;
                    switch (selectedRoom.RoomStatus)
                    {
                        case RoomStatus.Available:
                            statusIndex = 0;
                            break;
                        case RoomStatus.InUse:
                            statusIndex = 1;
                            break;
                        case RoomStatus.Maintenance:
                            statusIndex = 2;
                            break;
                        case RoomStatus.Closed:
                            statusIndex = 3;
                            break;
                    }
                    cmbRoomStatus.SelectedIndex = statusIndex;
                    
                    nudPricePerHour.Value = selectedRoom.PricePerHour;
                    nudCapacity.Value = selectedRoom.Capacity;
                    
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
            selectedRoom = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            txtRoomName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRoom != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtRoomName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoom == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng '{selectedRoom.RoomName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = roomBLL.DeleteRoom(selectedRoom.RoomID);
                    if (success)
                    {
                        MessageBox.Show("Xóa phòng thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms();
                        ClearForm();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa phòng!", "Lỗi", 
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
                    txtRoomName.Focus();
                    return;
                }

                Room room = selectedRoom ?? new Room();
                room.RoomName = txtRoomName.Text.Trim();
                room.FloorID = cmbFloor.SelectedValue?.ToString();
                room.RoomType = (RoomType)cmbRoomType.SelectedIndex;
                
                // Map ComboBox index to RoomStatus enum
                RoomStatus status = RoomStatus.Available;
                switch (cmbRoomStatus.SelectedIndex)
                {
                    case 0:
                        status = RoomStatus.Available;
                        break;
                    case 1:
                        status = RoomStatus.InUse;
                        break;
                    case 2:
                        status = RoomStatus.Maintenance;
                        break;
                    case 3:
                        status = RoomStatus.Closed;
                        break;
                }
                room.RoomStatus = status;
                
                room.PricePerHour = nudPricePerHour.Value;
                room.Capacity = (int)nudCapacity.Value;

                bool success;
                string message;

                if (selectedRoom == null) // Add new
                {
                    success = roomBLL.AddRoom(room);
                    message = success ? "Thêm phòng thành công!" : "Không thể thêm phòng!";
                }
                else // Update existing
                {
                    success = roomBLL.UpdateRoom(room);
                    message = success ? "Cập nhật phòng thành công!" : "Không thể cập nhật phòng!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
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
            if (selectedRoom != null)
            {
                txtRoomName.Text = selectedRoom.RoomName;
                
                if (!string.IsNullOrEmpty(selectedRoom.FloorID))
                    cmbFloor.SelectedValue = selectedRoom.FloorID;
                else
                    cmbFloor.SelectedIndex = -1;
                
                cmbRoomType.SelectedIndex = (int)selectedRoom.RoomType;
                
                // Map RoomStatus enum to ComboBox index
                int statusIndex = 0;
                switch (selectedRoom.RoomStatus)
                {
                    case RoomStatus.Available:
                        statusIndex = 0;
                        break;
                    case RoomStatus.InUse:
                        statusIndex = 1;
                        break;
                    case RoomStatus.Maintenance:
                        statusIndex = 2;
                        break;
                    case RoomStatus.Closed:
                        statusIndex = 3;
                        break;
                }
                cmbRoomStatus.SelectedIndex = statusIndex;
                
                nudPricePerHour.Value = selectedRoom.PricePerHour;
                nudCapacity.Value = selectedRoom.Capacity;
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        private string ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
                return "Vui lòng nhập tên phòng!";

            if (txtRoomName.Text.Trim().Length > 30)
                return "Tên phòng không được vượt quá 30 ký tự!";

            if (cmbFloor.SelectedValue == null)
                return "Vui lòng chọn tầng!";

            if (nudPricePerHour.Value < 0)
                return "Giá mỗi giờ phải lớn hơn hoặc bằng 0!";

            if (nudCapacity.Value <= 0)
                return "Sức chứa phải lớn hơn 0!";

            return null;
        }
    }
}

