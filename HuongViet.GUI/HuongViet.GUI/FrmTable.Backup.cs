using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmTable : Form
    {
        private readonly TableBLL tableBLL;
        private readonly AreaBLL areaBLL;
        private readonly RoomBLL roomBLL;
        private List<Table> tables;
        private List<Area> areas;
        private Table selectedTable;
        private Area selectedArea;
        private bool isEditing = false;
        private bool isAreaEditing = false;
        
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchTerm = string.Empty;
        private string currentAreaFilter = null;
        private TableStatus? currentStatusFilter = null;

        public FrmTable()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            areaBLL = new AreaBLL();
            roomBLL = new RoomBLL();
            InitializeForm();
            LoadAreas();
            LoadTables();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeForm()
        {
            SetupControls();
            SetupEventHandlers();
            ClearForm();
        }

        private void SetupControls()
        {
            // Setup default values
            cmbTableStatus.SelectedIndex = 0;
            nudCapacity.Value = 4;
            
            // Set initial button states
            SetAreaButtonStates(false);
            SetTableButtonStates(false);
        }
        
        private void SetupEventHandlers()
        {
            // Area management events will be added here
            // Table management events will be added here
        }
        
        private void SetAreaButtonStates(bool editing)
        {
            isAreaEditing = editing;
            btnAreaAdd.Enabled = !editing;
            btnAreaEdit.Enabled = !editing && selectedArea != null;
            btnAreaDelete.Enabled = !editing && selectedArea != null;
            btnAreaSave.Enabled = editing;
            btnAreaCancel.Enabled = editing;
            txtAreaName.ReadOnly = !editing;
        }
        
        private void SetTableButtonStates(bool editing)
        {
            isEditing = editing;
            btnTableAdd.Enabled = !editing;
            btnTableEdit.Enabled = !editing && selectedTable != null;
            btnTableDelete.Enabled = !editing && selectedTable != null;
            btnTableSave.Enabled = editing;
            btnTableCancel.Enabled = editing;
            
            txtTableName.ReadOnly = !editing;
            cmbFloor.Enabled = editing;
            nudCapacity.ReadOnly = !editing;
            cmbTableStatus.Enabled = editing;
        }



        private void LoadAreas()
        {
            try
            {
                areas = tableBLL.GetAllAreas();
                
                // Setup Area ComboBox in form
                cmbFloor.DataSource = null;
                cmbFloor.DisplayMember = "DisplayText";
                cmbFloor.ValueMember = "AreaID";
                
                var areaFormList = new List<AreaDisplayItem>();
                foreach (var area in areas)
                {
                    areaFormList.Add(new AreaDisplayItem(area.AreaID, area.AreaName));
                }
                
                cmbFloor.DataSource = areaFormList;
                cmbFloor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khu vực: {ex.Message}", 
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

                string areaId = currentAreaFilter;
                if (areaId == "")
                    areaId = null;

                var result = tableBLL.SearchTables(criteria, areaId, currentStatusFilter);
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
            treeViewTables.BeginUpdate();
            treeViewTables.Nodes.Clear();
            
            // Hiển thị tất cả khu vực, kể cả khu vực chưa có bàn
            if (areas != null && areas.Count > 0)
            {
                foreach (var area in areas.OrderBy(a => a.AreaName))
                {
                    // Tạo node cho khu vực (tầng)
                    TreeNode areaNode = new TreeNode(area.AreaName);
                    areaNode.Tag = area; // Lưu Area vào Tag để phân biệt với Table
                    areaNode.NodeFont = new Font("Times New Roman", 14F, FontStyle.Bold);
                    areaNode.ForeColor = Color.DarkBlue;

                    // Tìm các bàn thuộc khu vực này
                    var tablesInArea = tables?.Where(t => t.AreaID == area.AreaID).OrderBy(t => t.TableName).ToList() ?? new List<Table>();

                    if (tablesInArea.Any())
                    {
                        // Thêm các bàn vào node khu vực
                        foreach (var table in tablesInArea)
                        {
                            string statusText = GetStatusDisplayText(table.TableStatus);
                            string tableInfo = $"{table.TableName} - {statusText} - Sức chứa: {table.Capacity}";
                            
                            if (!string.IsNullOrEmpty(table.CurrentOrderID))
                            {
                                tableInfo += $" - Đơn: {table.CurrentOrderID}";
                            }

                            TreeNode tableNode = new TreeNode(tableInfo);
                            tableNode.Tag = table; // Lưu đối tượng Table vào Tag
                            tableNode.NodeFont = new Font("Times New Roman", 13F, FontStyle.Regular);
                            
                            // Màu sắc theo trạng thái
                            switch (table.TableStatus)
                            {
                                case TableStatus.Available:
                                    tableNode.ForeColor = Color.Green;
                                    break;
                                case TableStatus.Occupied:
                                    tableNode.ForeColor = Color.Red;
                                    break;
                                case TableStatus.Cleaning:
                                    tableNode.ForeColor = Color.Orange;
                                    break;
                                case TableStatus.Unavailable:
                                    tableNode.ForeColor = Color.Gray;
                                    break;
                            }

                            areaNode.Nodes.Add(tableNode);
                        }
                    }
                    else
                    {
                        // Khu vực chưa có bàn nào
                        TreeNode emptyNode = new TreeNode("(Chưa có bàn)");
                        emptyNode.Tag = null;
                        emptyNode.NodeFont = new Font("Times New Roman", 12F, FontStyle.Italic);
                        emptyNode.ForeColor = Color.Gray;
                        areaNode.Nodes.Add(emptyNode);
                    }

                    treeViewTables.Nodes.Add(areaNode);
                    areaNode.Expand(); // Mở rộng node để hiện các bàn
                }
            }
            
            treeViewTables.EndUpdate();
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
            
            treeViewTables.Enabled = !enable;
        }

        private void treeViewTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && !isEditing)
            {
                // Kiểm tra xem node được chọn có phải là node bàn không (có Tag là Table)
                if (e.Node.Tag is Table table)
                {
                    selectedTable = table;
                    
                    txtTableName.Text = selectedTable.TableName;
                    
                    if (!string.IsNullOrEmpty(selectedTable.AreaID))
                        cmbFloor.SelectedValue = selectedTable.AreaID;
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
                else if (e.Node.Tag is Area area)
                {
                    // Nếu chọn node khu vực, có thể pre-select khu vực đó cho form thêm mới
                    if (!isEditing)
                    {
                        ClearForm();
                        cmbFloor.SelectedValue = area.AreaID; // Pre-select khu vực
                    }
                }
                else
                {
                    // Node trống hoặc node khác, xóa form
                    if (!isEditing)
                    {
                        ClearForm();
                    }
                }
            }
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            // Giữ lại để tránh lỗi nếu có event cũ
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
                table.AreaID = cmbFloor.SelectedValue?.ToString();
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
                
                if (!string.IsNullOrEmpty(selectedTable.AreaID))
                    cmbFloor.SelectedValue = selectedTable.AreaID;
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
                if (cmbFilterFloor.SelectedItem is AreaDisplayItem selectedItem)
                {
                    if (string.IsNullOrEmpty(selectedItem.AreaID))
                    {
                        currentAreaFilter = null; // "Tất cả"
                    }
                    else
                    {
                        currentAreaFilter = selectedItem.AreaID;
                    }
                }
                else
                {
                    currentAreaFilter = null;
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
            currentAreaFilter = null;
            currentStatusFilter = null;
            currentPage = 1;
            LoadAreas(); // Reload areas in case they changed
            LoadTables();
            BindDataGridView(); // Refresh TreeView
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
                return "Vui lòng chọn khu vực!";

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

        #region Area Management

        private void btnManageFloors_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new FrmAreaManagement())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAreas(); // Reload areas after changes
                        LoadTables(); // Reload tables to get updated data
                        BindDataGridView(); // Refresh TreeView to show new areas
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý khu vực: {ex.Message}", 
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

		private void FrmTable_Load(object sender, EventArgs e)
		{

		}

		private void dgvTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}

	// Helper class for ComboBox display
	public class AreaDisplayItem
    {
        public string AreaID { get; set; }
        public string DisplayText { get; set; }
        
        public AreaDisplayItem(string areaId, string displayText)
        {
            AreaID = areaId;
            DisplayText = displayText;
        }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
