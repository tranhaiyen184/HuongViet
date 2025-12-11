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
using HuongViet.DAL;
using HuongViet.Models;


namespace HuongViet.GUI
{
    public partial class FrmReservation : Form
    {
        private readonly ReservationBLL reservationBLL;
        private readonly TableDAL tableDAL;
        private List<Reservation> reservations;
        private Reservation selectedReservation;

        public FrmReservation()
        {
            InitializeComponent();
            reservationBLL = new ReservationBLL();
            tableDAL = new TableDAL();
            InitializeForm();
            LoadReservations();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.ReadOnly = true;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvReservations.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservations.ColumnHeadersHeight = 40;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Row styles
            dgvReservations.RowTemplate.Height = 35;
            dgvReservations.DefaultCellStyle.Font = new Font("Times New Roman", 12F);
            dgvReservations.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvReservations.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadReservations()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                reservations = reservationBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đặt bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reservations = new List<Reservation>();
                BindDataGridView();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BindDataGridView()
        {
            dgvReservations.DataSource = null;
            
            if (reservations != null && reservations.Count > 0)
            {
                var displayData = reservations.Select(r => new
                {
                    ReservationID = r.ReservationID,
                    CustomerName = r.CustomerName ?? "",
                    ContactPhone = r.ContactPhone ?? "",
                    ReservationDate = r.ReservationDate.ToString("dd/MM/yyyy"),
                    ReservationTime = r.ReservationTime.ToString(@"hh\:mm"),
                    NumberOfGuests = r.NumberOfGuests,
                    TableName = GetTableName(r.TableID),
                    RoomName = GetRoomName(r.RoomID),
                    Status = GetStatusDisplayText(r.ReservationStatus),
                    DepositAmount = r.DepositAmount.HasValue ? r.DepositAmount.Value.ToString("N0") : "0"
                }).ToList();

                dgvReservations.DataSource = displayData;
                
                if (dgvReservations.Columns.Count > 0)
                {
                    dgvReservations.Columns["ReservationID"].Visible = false;
                    dgvReservations.Columns["CustomerName"].HeaderText = "Tên khách hàng";
                    dgvReservations.Columns["ContactPhone"].HeaderText = "Số điện thoại";
                    dgvReservations.Columns["ReservationDate"].HeaderText = "Ngày đặt";
                    dgvReservations.Columns["ReservationTime"].HeaderText = "Giờ đặt";
                    dgvReservations.Columns["NumberOfGuests"].HeaderText = "Số khách";
                    dgvReservations.Columns["TableName"].HeaderText = "Bàn";
                    dgvReservations.Columns["RoomName"].HeaderText = "Phòng";
                    dgvReservations.Columns["Status"].HeaderText = "Trạng thái";
                    dgvReservations.Columns["DepositAmount"].HeaderText = "Tiền cọc";
                    
                    dgvReservations.Columns["CustomerName"].FillWeight = 15;
                    dgvReservations.Columns["ContactPhone"].FillWeight = 12;
                    dgvReservations.Columns["ReservationDate"].FillWeight = 10;
                    dgvReservations.Columns["ReservationTime"].FillWeight = 8;
                    dgvReservations.Columns["NumberOfGuests"].FillWeight = 8;
                    dgvReservations.Columns["TableName"].FillWeight = 10;
                    dgvReservations.Columns["RoomName"].FillWeight = 10;
                    dgvReservations.Columns["Status"].FillWeight = 12;
                    dgvReservations.Columns["DepositAmount"].FillWeight = 10;
                }
            }
        }

        private string GetTableName(string tableId)
        {
            if (string.IsNullOrEmpty(tableId))
                return "";
            
            try
            {
                var table = tableDAL.GetById(tableId);
                return table?.TableName ?? "";
            }
            catch
            {
                return "";
            }
        }

        private string GetRoomName(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
                return "";
            
            try
            {
                var roomDAL = new RoomDAL();
                var room = roomDAL.GetById(roomId);
                return room?.RoomName ?? "";
            }
            catch
            {
                return "";
            }
        }

        private string GetStatusDisplayText(ReservationStatus status)
        {
            switch (status)
            {
                case ReservationStatus.Pending:
                    return "Chờ xác nhận";
                case ReservationStatus.Confirmed:
                    return "Đã xác nhận";
                case ReservationStatus.Cancelled:
                    return "Đã hủy";
                default:
                    return status.ToString();
            }
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var row = dgvReservations.SelectedRows[0];
                string reservationId = row.Cells["ReservationID"].Value.ToString();
                
                selectedReservation = reservations.FirstOrDefault(r => r.ReservationID == reservationId);
                
                if (selectedReservation != null)
                {
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                selectedReservation = null;
                btnUpdate.Enabled = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new FrmCreateReservation())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadReservations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form tạo đặt bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedReservation == null)
            {
                MessageBox.Show("Vui lòng chọn đặt bàn cần cập nhật!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var form = new FrmUpdateReservation(selectedReservation))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadReservations();
                        selectedReservation = null;
                        btnUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form cập nhật đặt bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
            selectedReservation = null;
            btnUpdate.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (reservationBLL != null)
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
