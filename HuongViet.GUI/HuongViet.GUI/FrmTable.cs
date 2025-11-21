using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    // Helper class for ComboBox display
    public class FloorDisplayItem
    {
        public string FloorID { get; set; }
        public string DisplayText { get; set; }
        
        public FloorDisplayItem(string floorId, string displayText)
        {
            FloorID = floorId;
            DisplayText = displayText;
        }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }

    public partial class FrmTable : Form
    {
        private readonly TableBLL tableBLL;
        private readonly FloorBLL floorBLL;
        private readonly RoomBLL roomBLL;
        private List<Table> tables;
        private List<Floor> floors;
        private Table selectedTable;
        private bool isEditing = false;
        
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;
        private string currentFloorFilter = null;
        private TableStatus? currentStatusFilter = null;

        public FrmTable()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            floorBLL = new FloorBLL();
            roomBLL = new RoomBLL();
            InitializeForm();
            LoadFloors();
            LoadTables();
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
            dgvTables.RowHeadersVisible = false;
            dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTables.MultiSelect = false;
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.ReadOnly = true;
            dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupPagination()
        {
            cmbPageSize.SelectedIndex = 1; // Default to 20
            pageSize = 20;
        }

        private void SetupFilters()
        {
            // Setup Floor filter - will be populated in LoadFloors()
            cmbFilterFloor.DisplayMember = "DisplayText";
            cmbFilterFloor.ValueMember = "FloorID";
            
            // Setup Status filter
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả", "Available", "Occupied", "Cleaning", "Unavailable" });
            cmbFilterStatus.SelectedIndex = 0;
        }

        private void LoadFloors()
        {
            try
            {
                floors = tableBLL.GetAllFloors();
                
                // Setup Floor filter ComboBox
                cmbFilterFloor.DataSource = null;
                cmbFilterFloor.Items.Clear();
                
                // Create list with "Tất cả" option and all floors
                var floorFilterList = new List<FloorDisplayItem>();
                floorFilterList.Add(new FloorDisplayItem("", "Tất cả"));
                
                foreach (var floor in floors)
                {
                    floorFilterList.Add(new FloorDisplayItem(floor.FloorID, $"Tầng {floor.FloorNumber}"));
                }
                
                cmbFilterFloor.DataSource = floorFilterList;
                cmbFilterFloor.DisplayMember = "DisplayText";
                cmbFilterFloor.ValueMember = "FloorID";
                cmbFilterFloor.SelectedIndex = 0;
                
                // Setup Floor ComboBox in form
                cmbFloor.DataSource = null;
                cmbFloor.DisplayMember = "DisplayText";
                cmbFloor.ValueMember = "FloorID";
                
                var floorFormList = new List<FloorDisplayItem>();
                foreach (var floor in floors)
                {
                    floorFormList.Add(new FloorDisplayItem(floor.FloorID, $"Tầng {floor.FloorNumber}"));
                }
                
                cmbFloor.DataSource = floorFormList;
                cmbFloor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tầng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
            try
            {
                LoadTablesWithPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTablesWithPaging()
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

                string floorId = currentFloorFilter;
                if (floorId == "")
                    floorId = null;

                var result = tableBLL.SearchTables(criteria, floorId, currentStatusFilter);
                tables = result.Data ?? new List<Table>();
                totalRecords = result.TotalRecords;
                totalPages = result.TotalPages;

                BindDataGridView();
                UpdatePaginationInfo();
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                tables = new List<Table>();
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
            dgvTables.DataSource = null;
            
            if (tables != null && tables.Count > 0)
            {
                var displayData = tables.Select(t => new
                {
                    TableID = t.TableID,
                    TableName = t.TableName,
                    FloorNumber = t.Floor?.FloorNumber ?? 0,
                    FloorDisplay = t.Floor != null ? $"Tầng {t.Floor.FloorNumber}" : "Chưa xác định",
                    TableStatus = GetStatusDisplayText(t.TableStatus),
                    Capacity = t.Capacity,
                    CurrentOrderID = t.CurrentOrderID ?? "",
                    CreatedAt = t.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dgvTables.DataSource = displayData;
                
                if (dgvTables.Columns.Count > 0)
                {
                    dgvTables.Columns["TableID"].Visible = false;
                    dgvTables.Columns["FloorNumber"].Visible = false;
                    dgvTables.Columns["TableName"].HeaderText = "Tên bàn";
                    dgvTables.Columns["FloorDisplay"].HeaderText = "Tầng";
                    dgvTables.Columns["TableStatus"].HeaderText = "Trạng thái";
                    dgvTables.Columns["Capacity"].HeaderText = "Sức chứa";
                    dgvTables.Columns["CurrentOrderID"].HeaderText = "Order hiện tại";
                    dgvTables.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                    
                    dgvTables.Columns["TableName"].FillWeight = 20;
                    dgvTables.Columns["FloorDisplay"].FillWeight = 15;
                    dgvTables.Columns["TableStatus"].FillWeight = 15;
                    dgvTables.Columns["Capacity"].FillWeight = 10;
                    dgvTables.Columns["CurrentOrderID"].FillWeight = 20;
                    dgvTables.Columns["CreatedAt"].FillWeight = 20;
                }
            }
        }

        private string GetStatusDisplayText(TableStatus status)
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

        private TableStatus GetStatusFromDisplayText(string displayText)
        {
            switch (displayText)
            {
                case "Trống":
                    return TableStatus.Available;
                case "Đang sử dụng":
                    return TableStatus.Occupied;
                case "Đang dọn dẹp":
                    return TableStatus.Cleaning;
                case "Không khả dụng":
                    return TableStatus.Unavailable;
                default:
                    return (TableStatus)Enum.Parse(typeof(TableStatus), displayText);
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";
            lblStatus.Text = $"Hiển thị {tables?.Count ?? 0} / {totalRecords} bàn";
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
            txtTableName.Clear();
            cmbFloor.SelectedIndex = -1;
            nudCapacity.Value = 1;
            cmbTableStatus.SelectedIndex = 0; // Default to Available
            selectedTable = null;
            isEditing = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            EnableEditMode(false);
        }

        private void EnableEditMode(bool enable)
        {
            txtTableName.ReadOnly = !enable;
            txtTableName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            cmbFloor.Enabled = enable;
            nudCapacity.Enabled = enable;
            cmbTableStatus.Enabled = enable;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedTable != null;
            btnDelete.Enabled = !enable && selectedTable != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvTables.Enabled = !enable;
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvTables.SelectedRows[0];
                string tableId = row.Cells["TableID"].Value.ToString();
                
                selectedTable = tables.FirstOrDefault(t => t.TableID == tableId);
                
                if (selectedTable != null)
                {
                    txtTableName.Text = selectedTable.TableName;
                    
                    if (!string.IsNullOrEmpty(selectedTable.FloorID))
                        cmbFloor.SelectedValue = selectedTable.FloorID;
                    else
                        cmbFloor.SelectedIndex = -1;
                    
                    nudCapacity.Value = selectedTable.Capacity;
                    
                    // Set status
                    int statusIndex = 0;
                    switch (selectedTable.TableStatus)
                    {
                        case TableStatus.Available:
                            statusIndex = 0;
                            break;
                        case TableStatus.Occupied:
                            statusIndex = 1;
                            break;
                        case TableStatus.Cleaning:
                            statusIndex = 2;
                            break;
                        case TableStatus.Unavailable:
                            statusIndex = 3;
                            break;
                    }
                    cmbTableStatus.SelectedIndex = statusIndex;
                    
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
            selectedTable = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            txtTableName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtTableName.Focus();
                txtTableName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTable == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bàn '{selectedTable.TableName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = tableBLL.DeleteTable(selectedTable.TableID);
                    if (success)
                    {
                        MessageBox.Show("Xóa bàn thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTablesWithPaging();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa bàn!", "Lỗi", 
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
                    txtTableName.Focus();
                    return;
                }

                Table table = selectedTable ?? new Table();
                table.TableName = txtTableName.Text.Trim();
                table.FloorID = cmbFloor.SelectedValue?.ToString();
                table.Capacity = (int)nudCapacity.Value;
                
                // Get status from combo box
                string statusText = cmbTableStatus.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(statusText))
                {
                    table.TableStatus = GetStatusFromDisplayText(statusText);
                }

                bool success;
                string message;

                if (selectedTable == null) // Add new
                {
                    success = tableBLL.AddTable(table);
                    message = success ? "Thêm bàn thành công!" : "Không thể thêm bàn!";
                }
                else // Update existing
                {
                    success = tableBLL.UpdateTable(table);
                    message = success ? "Cập nhật bàn thành công!" : "Không thể cập nhật bàn!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTablesWithPaging();
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
            if (selectedTable != null)
            {
                txtTableName.Text = selectedTable.TableName;
                
                if (!string.IsNullOrEmpty(selectedTable.FloorID))
                    cmbFloor.SelectedValue = selectedTable.FloorID;
                else
                    cmbFloor.SelectedIndex = -1;
                
                nudCapacity.Value = selectedTable.Capacity;
                
                // Set status
                int statusIndex = 0;
                switch (selectedTable.TableStatus)
                {
                    case TableStatus.Available:
                        statusIndex = 0;
                        break;
                    case TableStatus.Occupied:
                        statusIndex = 1;
                        break;
                    case TableStatus.Cleaning:
                        statusIndex = 2;
                        break;
                    case TableStatus.Unavailable:
                        statusIndex = 3;
                        break;
                }
                cmbTableStatus.SelectedIndex = statusIndex;
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
            SearchTables();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchTables();
                e.Handled = true;
            }
        }

        private void SearchTables()
        {
            try
            {
                currentSearchTerm = txtSearch.Text.Trim();
                currentPage = 1;
                
                // Get filter values
                if (cmbFilterFloor.SelectedItem is FloorDisplayItem selectedItem)
                {
                    if (string.IsNullOrEmpty(selectedItem.FloorID))
                    {
                        currentFloorFilter = null; // "Tất cả"
                    }
                    else
                    {
                        currentFloorFilter = selectedItem.FloorID;
                    }
                }
                else
                {
                    currentFloorFilter = null;
                }
                
                if (cmbFilterStatus.SelectedIndex == 0)
                    currentStatusFilter = null;
                else
                {
                    string statusText = cmbFilterStatus.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(statusText))
                    {
                        currentStatusFilter = GetStatusFromDisplayText(statusText);
                    }
                }
                
                LoadTablesWithPaging();
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
            cmbFilterFloor.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            currentSearchTerm = string.Empty;
            currentFloorFilter = null;
            currentStatusFilter = null;
            currentPage = 1;
            LoadTables();
            ClearForm();
        }

        private void cmbFilterFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterFloor.SelectedIndex >= 0)
            {
                SearchTables();
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterStatus.SelectedIndex >= 0)
            {
                SearchTables();
            }
        }

        #region Pagination Event Handlers

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadTablesWithPaging();
                ClearForm();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadTablesWithPaging();
                ClearForm();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadTablesWithPaging();
                ClearForm();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages && totalPages > 0)
            {
                currentPage = totalPages;
                LoadTablesWithPaging();
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
                    LoadTablesWithPaging();
                    ClearForm();
                }
            }
        }

        #endregion

        #region Validation

        private string ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
                return "Vui lòng nhập tên bàn!";

            if (txtTableName.Text.Trim().Length > 20)
                return "Tên bàn không được vượt quá 20 ký tự!";

            if (cmbFloor.SelectedIndex < 0)
                return "Vui lòng chọn tầng!";

            if (nudCapacity.Value <= 0)
                return "Sức chứa phải lớn hơn 0!";

            return null;
        }

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (tableBLL != null)
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

        #region Floor Management

        private void btnManageFloors_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new FrmFloorManagement())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadFloors(); // Reload floors after changes
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý tầng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Room Management

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new FrmRoomManagement())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Optionally reload data if needed
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý phòng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}

