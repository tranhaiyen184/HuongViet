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
    public partial class FrmCreateReservation : Form
    {
        private readonly ReservationBLL reservationBLL;
        private readonly CustomerBLL customerBLL;
        private readonly TableBLL tableBLL;
        private readonly RoomBLL roomBLL;
        private List<Customer> customers;
        private List<Table> tables;
        private List<Room> rooms;

        public FrmCreateReservation()
        {
            InitializeComponent();
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
            SetupDefaultValues();
        }

        private void SetupDefaultValues()
        {
            // Set default date to today
            dtpReservationDate.Value = DateTime.Now;
            
            // Set default time to current time
            dtpReservationTime.Value = DateTime.Now;
            
            // Set default status to Pending
            cmbReservationStatus.SelectedIndex = 0;
            
            // Set default number of guests to 1
            nudNumberOfGuests.Value = 1;
            
            // Set default duration to 2 hours
            nudDuration.Value = 2;
            
            // Set default deposit to 0
            nudDepositAmount.Value = 0;
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
                cmbCustomer.SelectedIndex = 0;
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
                
                foreach (var table in tables.Where(t => t.TableStatus == TableStatus.Available))
                {
                    string areaName = table.Area != null ? table.Area.AreaName : "";
                    tableList.Add(new TableDisplayItem(table.TableID, $"{table.TableName} ({areaName}) - {table.Capacity} người"));
                }
                
                cmbTable.DataSource = tableList;
                cmbTable.DisplayMember = "DisplayText";
                cmbTable.ValueMember = "TableID";
                cmbTable.SelectedIndex = 0;
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
                
                foreach (var room in rooms.Where(r => r.RoomStatus == RoomStatus.Available))
                {
                    string areaName = room.Area != null ? room.Area.AreaName : "";
                    roomList.Add(new RoomDisplayItem(room.RoomID, $"{room.RoomName} ({areaName}) - {room.Capacity} người"));
                }
                
                cmbRoom.DataSource = roomList;
                cmbRoom.DisplayMember = "DisplayText";
                cmbRoom.ValueMember = "RoomID";
                cmbRoom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                Reservation reservation = new Reservation
                {
                    ReservationID = reservationBLL.GenerateNewReservationID(),
                    CustomerName = txtCustomerName.Text.Trim(),
                    ContactPhone = txtContactPhone.Text.Trim(),
                    ReservationDate = dtpReservationDate.Value.Date,
                    ReservationTime = dtpReservationTime.Value.TimeOfDay,
                    NumberOfGuests = (int)nudNumberOfGuests.Value,
                    Duration = (int)nudDuration.Value,
                    ReservationStatus = GetReservationStatusFromComboBox(),
                    SpecialRequests = string.IsNullOrWhiteSpace(txtSpecialRequests.Text) ? null : txtSpecialRequests.Text.Trim(),
                    DepositAmount = nudDepositAmount.Value > 0 ? (decimal?)nudDepositAmount.Value : null
                };

                // Set CustomerID if selected
                if (cmbCustomer.SelectedItem is CustomerDisplayItem selectedCustomer && !string.IsNullOrEmpty(selectedCustomer.CustomerID))
                {
                    reservation.CustomerID = selectedCustomer.CustomerID;
                }

                // Set TableID if selected
                if (cmbTable.SelectedItem is TableDisplayItem selectedTable && !string.IsNullOrEmpty(selectedTable.TableID))
                {
                    reservation.TableID = selectedTable.TableID;
                }

                // Set RoomID if selected
                if (cmbRoom.SelectedItem is RoomDisplayItem selectedRoom && !string.IsNullOrEmpty(selectedRoom.RoomID))
                {
                    reservation.RoomID = selectedRoom.RoomID;
                }

                bool success = reservationBLL.Insert(reservation);
                
                if (success)
                {
                    MessageBox.Show("Tạo đặt bàn thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo đặt bàn!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đặt bàn: {ex.Message}", "Lỗi", 
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

            if (dtpReservationDate.Value < DateTime.Now.Date)
                return "Ngày đặt không được nhỏ hơn ngày hiện tại!";

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

    // Helper classes for ComboBox display
    public class CustomerDisplayItem
    {
        public string CustomerID { get; set; }
        public string DisplayText { get; set; }
        
        public CustomerDisplayItem(string customerId, string displayText)
        {
            CustomerID = customerId;
            DisplayText = displayText;
        }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }

    public class TableDisplayItem
    {
        public string TableID { get; set; }
        public string DisplayText { get; set; }
        
        public TableDisplayItem(string tableId, string displayText)
        {
            TableID = tableId;
            DisplayText = displayText;
        }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }

    public class RoomDisplayItem
    {
        public string RoomID { get; set; }
        public string DisplayText { get; set; }
        
        public RoomDisplayItem(string roomId, string displayText)
        {
            RoomID = roomId;
            DisplayText = displayText;
        }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
