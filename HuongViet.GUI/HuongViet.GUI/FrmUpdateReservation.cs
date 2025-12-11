using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;
using HuongViet.DAL;

namespace HuongViet.GUI
{
    public partial class FrmUpdateReservation : Form
    {
        private readonly ReservationBLL reservationBLL;
        private readonly CustomerBLL customerBLL;
        private readonly TableBLL tableBLL;
        private readonly RoomBLL roomBLL;
        private Reservation reservation;
        private List<Customer> customers;
        private List<Table> tables;
        private List<Room> rooms;

        public FrmUpdateReservation(Reservation reservation)
        {
            InitializeComponent();
            this.reservation = reservation;
            reservationBLL = new ReservationBLL();
            customerBLL = new CustomerBLL();
            tableBLL = new TableBLL();
            roomBLL = new RoomBLL();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadCustomers();
            LoadTables();
            LoadRooms();
            LoadReservationData();
        }

        private void LoadCustomers()
        {
            try
            {
                customers = customerBLL.GetAll();
                
                cmbCustomer.DataSource = null;
                cmbCustomer.Items.Clear();
                
                // Add empty option
                var customerList = new List<CustomerDisplayItem>();
                customerList.Add(new CustomerDisplayItem("", "Không chọn"));
                
                foreach (var customer in customers)
                {
                    customerList.Add(new CustomerDisplayItem(customer.CustomerID, $"{customer.CustomerName} - {customer.CustomerPhoneNum}"));
                }
                
                cmbCustomer.DataSource = customerList;
                cmbCustomer.DisplayMember = "DisplayText";
                cmbCustomer.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khách hàng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
            try
            {
                tables = tableBLL.GetAllTables();
                
                cmbTable.DataSource = null;
                cmbTable.Items.Clear();
                
                // Add empty option
                var tableList = new List<TableDisplayItem>();
                tableList.Add(new TableDisplayItem("", "Không chọn"));
                
                // Include all tables (not just available) for update form
                foreach (var table in tables)
                {
                    string areaName = table.Area != null ? table.Area.AreaName : "";
                    string statusText = table.TableStatus == TableStatus.Available ? "" : $" ({GetTableStatusText(table.TableStatus)})";
                    tableList.Add(new TableDisplayItem(table.TableID, $"{table.TableName} ({areaName}) - {table.Capacity} người{statusText}"));
                }
                
                cmbTable.DataSource = tableList;
                cmbTable.DisplayMember = "DisplayText";
                cmbTable.ValueMember = "TableID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                rooms = roomBLL.GetAllRooms();
                
                cmbRoom.DataSource = null;
                cmbRoom.Items.Clear();
                
                // Add empty option
                var roomList = new List<RoomDisplayItem>();
                roomList.Add(new RoomDisplayItem("", "Không chọn"));
                
                // Include all rooms (not just available) for update form
                foreach (var room in rooms)
                {
                    string areaName = room.Area != null ? room.Area.AreaName : "";
                    string statusText = room.RoomStatus == RoomStatus.Available ? "" : $" ({GetRoomStatusText(room.RoomStatus)})";
                    roomList.Add(new RoomDisplayItem(room.RoomID, $"{room.RoomName} ({areaName}) - {room.Capacity} người{statusText}"));
                }
                
                cmbRoom.DataSource = roomList;
                cmbRoom.DisplayMember = "DisplayText";
                cmbRoom.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTableStatusText(TableStatus status)
        {
            switch (status)
            {
                case TableStatus.Available:
                    return "Trống";
                case TableStatus.Occupied:
                    return "Đang sử dụng";
                case TableStatus.Cleaning:
                    return "Đang dọn dẹp";
                case TableStatus.Unavailable:
                    return "Không khả dụng";
                default:
                    return status.ToString();
            }
        }

        private string GetRoomStatusText(RoomStatus status)
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

        private void LoadReservationData()
        {
            if (reservation == null)
            {
                MessageBox.Show("Không tìm thấy thông tin đặt bàn!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                // Populate basic fields
                txtCustomerName.Text = reservation.CustomerName ?? "";
                txtContactPhone.Text = reservation.ContactPhone ?? "";
                
                // Set date and time
                dtpReservationDate.Value = reservation.ReservationDate;
                dtpReservationTime.Value = DateTime.Today.Add(reservation.ReservationTime);
                
                // Set number of guests
                nudNumberOfGuests.Value = reservation.NumberOfGuests;
                
                // Set duration
                if (reservation.Duration.HasValue)
                {
                    nudDuration.Value = reservation.Duration.Value;
                }
                
                // Set deposit amount
                if (reservation.DepositAmount.HasValue)
                {
                    nudDepositAmount.Value = reservation.DepositAmount.Value;
                }
                
                // Set special requests
                txtSpecialRequests.Text = reservation.SpecialRequests ?? "";
                
                // Set customer if exists
                if (!string.IsNullOrEmpty(reservation.CustomerID))
                {
                    var customerItem = cmbCustomer.Items.Cast<CustomerDisplayItem>()
                        .FirstOrDefault(c => c.CustomerID == reservation.CustomerID);
                    if (customerItem != null)
                    {
                        cmbCustomer.SelectedItem = customerItem;
                    }
                }
                else
                {
                    cmbCustomer.SelectedIndex = 0; // "Không chọn"
                }
                
                // Set table if exists
                if (!string.IsNullOrEmpty(reservation.TableID))
                {
                    var tableItem = cmbTable.Items.Cast<TableDisplayItem>()
                        .FirstOrDefault(t => t.TableID == reservation.TableID);
                    if (tableItem != null)
                    {
                        cmbTable.SelectedItem = tableItem;
                    }
                }
                else
                {
                    cmbTable.SelectedIndex = 0; // "Không chọn"
                }
                
                // Set room if exists
                if (!string.IsNullOrEmpty(reservation.RoomID))
                {
                    var roomItem = cmbRoom.Items.Cast<RoomDisplayItem>()
                        .FirstOrDefault(r => r.RoomID == reservation.RoomID);
                    if (roomItem != null)
                    {
                        cmbRoom.SelectedItem = roomItem;
                    }
                }
                else
                {
                    cmbRoom.SelectedIndex = 0; // "Không chọn"
                }
                
                // Set status
                switch (reservation.ReservationStatus)
                {
                    case ReservationStatus.Pending:
                        cmbReservationStatus.SelectedIndex = 0;
                        break;
                    case ReservationStatus.Confirmed:
                        cmbReservationStatus.SelectedIndex = 1;
                        break;
                    case ReservationStatus.Cancelled:
                        cmbReservationStatus.SelectedIndex = 2;
                        break;
                    default:
                        cmbReservationStatus.SelectedIndex = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đặt bàn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    return;
                }

                // Update reservation object with form data
                reservation.CustomerName = txtCustomerName.Text.Trim();
                reservation.ContactPhone = txtContactPhone.Text.Trim();
                reservation.ReservationDate = dtpReservationDate.Value.Date;
                reservation.ReservationTime = dtpReservationTime.Value.TimeOfDay;
                reservation.NumberOfGuests = (int)nudNumberOfGuests.Value;
                reservation.Duration = (int)nudDuration.Value;
                reservation.ReservationStatus = GetReservationStatusFromComboBox();
                reservation.SpecialRequests = string.IsNullOrWhiteSpace(txtSpecialRequests.Text) ? null : txtSpecialRequests.Text.Trim();
                reservation.DepositAmount = nudDepositAmount.Value > 0 ? (decimal?)nudDepositAmount.Value : null;

                // Set CustomerID if selected
                if (cmbCustomer.SelectedItem is CustomerDisplayItem selectedCustomer && !string.IsNullOrEmpty(selectedCustomer.CustomerID))
                {
                    reservation.CustomerID = selectedCustomer.CustomerID;
                }
                else
                {
                    reservation.CustomerID = null;
                }

                // Set TableID if selected
                if (cmbTable.SelectedItem is TableDisplayItem selectedTable && !string.IsNullOrEmpty(selectedTable.TableID))
                {
                    reservation.TableID = selectedTable.TableID;
                }
                else
                {
                    reservation.TableID = null;
                }

                // Set RoomID if selected
                if (cmbRoom.SelectedItem is RoomDisplayItem selectedRoom && !string.IsNullOrEmpty(selectedRoom.RoomID))
                {
                    reservation.RoomID = selectedRoom.RoomID;
                }
                else
                {
                    reservation.RoomID = null;
                }

                bool success = reservationBLL.Update(reservation);
                
                if (success)
                {
                    MessageBox.Show("Cập nhật đặt bàn thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật đặt bàn!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đặt bàn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                return "Vui lòng nhập tên khách hàng!";

            if (txtCustomerName.Text.Trim().Length > 50)
                return "Tên khách hàng không được vượt quá 50 ký tự!";

            if (string.IsNullOrWhiteSpace(txtContactPhone.Text))
                return "Vui lòng nhập số điện thoại!";

            if (txtContactPhone.Text.Trim().Length > 15)
                return "Số điện thoại không được vượt quá 15 ký tự!";

            if (nudNumberOfGuests.Value < 1)
                return "Số khách phải lớn hơn 0!";

            // Check if both table and room are selected
            bool tableSelected = cmbTable.SelectedItem is TableDisplayItem tableItem && !string.IsNullOrEmpty(tableItem.TableID);
            bool roomSelected = cmbRoom.SelectedItem is RoomDisplayItem roomItem && !string.IsNullOrEmpty(roomItem.RoomID);
            
            if (!tableSelected && !roomSelected)
                return "Vui lòng chọn ít nhất một bàn hoặc một phòng!";

            if (tableSelected && roomSelected)
                return "Chỉ có thể chọn một bàn hoặc một phòng, không thể chọn cả hai!";

            return null;
        }

        private ReservationStatus GetReservationStatusFromComboBox()
        {
            switch (cmbReservationStatus.SelectedIndex)
            {
                case 0: // "Chờ xác nhận"
                    return ReservationStatus.Pending;
                case 1: // "Đã xác nhận"
                    return ReservationStatus.Confirmed;
                case 2: // "Đã hủy"
                    return ReservationStatus.Cancelled;
                default:
                    return ReservationStatus.Pending;
            }
        }
    }
}
