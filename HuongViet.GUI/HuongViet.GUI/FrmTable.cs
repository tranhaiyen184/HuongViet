using HuongViet.BLL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HuongViet.GUI
{
    public partial class FrmTable : Form
    {
        private readonly TableBLL tableBLL;
        private readonly AreaBLL areaBLL;
        private List<Table> tables;
        private List<Area> areas;
        private Table selectedTable;
        private Area selectedArea;
        private bool isEditing = false;
        private bool isAreaEditing = false;

        public FrmTable()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            areaBLL = new AreaBLL();
            InitializeForm();
            LoadAreas();
            LoadTables();
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
            // Area management events
            btnAreaAdd.Click += btnAreaAdd_Click;
            btnAreaEdit.Click += btnAreaEdit_Click;
            btnAreaDelete.Click += btnAreaDelete_Click;
            btnAreaSave.Click += btnAreaSave_Click;
            btnAreaCancel.Click += btnAreaCancel_Click;
            
            // Table management events
            btnTableAdd.Click += btnTableAdd_Click;
            btnTableEdit.Click += btnTableEdit_Click;
            btnTableDelete.Click += btnTableDelete_Click;
            btnTableSave.Click += btnTableSave_Click;
            btnTableCancel.Click += btnTableCancel_Click;
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
                tables = tableBLL.GetAllTables();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


		private void BindDataGridView()
        {
            try
            {
                treeViewTables.Nodes.Clear();

                if (areas == null || areas.Count == 0)
                {
                    MessageBox.Show("Chưa có khu vực nào. Vui lòng thêm khu vực trước.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                foreach (var area in areas)
                {
					
					var areaNode = new TreeNode(area.AreaName);
                    areaNode.Tag = area;
                    areaNode.NodeFont = new Font("SEGOE UI", 12F, FontStyle.Bold);
                    areaNode.ForeColor = Color.DarkBlue;

                    // Tìm các bàn thuộc khu vực này
                    var tablesInArea = tables?.Where(t => t.AreaID == area.AreaID).OrderBy(t => t.TableName).ToList() ?? new List<Table>();

                    if (tablesInArea.Any())
                    {
                        // Thêm các bàn vào node khu vực
                        foreach (var table in tablesInArea)
                        {
                            var tableNode = new TreeNode($"{table.TableName} - {GetStatusText(table.TableStatus)} - Sức chứa: {table.Capacity}");
                            tableNode.Tag = table;

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
                        // Khu vực chưa có bàn
                        var emptyNode = new TreeNode("(Chưa có bàn)");
                        emptyNode.ForeColor = Color.Gray;
                        emptyNode.NodeFont = new Font("Times New Roman", 12F, FontStyle.Italic);
                        areaNode.Nodes.Add(emptyNode);
                    }

                    treeViewTables.Nodes.Add(areaNode);
                }

                // Mở rộng tất cả nodes
                treeViewTables.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusText(TableStatus status)
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
                    return "Không xác định";
            }
        }

        private void ClearForm()
        {
            ClearTableForm();
            ClearAreaForm();
        }

        private void ClearTableForm()
        {
            selectedTable = null;
            txtTableName.Clear();
            cmbFloor.SelectedIndex = -1;
            nudCapacity.Value = 4;
            cmbTableStatus.SelectedIndex = 0;
            SetTableButtonStates(false);
        }

        private void ClearAreaForm()
        {
            selectedArea = null;
            txtAreaName.Clear();
            SetAreaButtonStates(false);
        }

        private void treeViewTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && !isEditing)
            {
                if (e.Node.Tag is Table table)
                {
                    selectedTable = table;

                    txtTableName.Text = selectedTable.TableName;

                    if (!string.IsNullOrEmpty(selectedTable.AreaID))
                        cmbFloor.SelectedValue = selectedTable.AreaID;
                    else
                        cmbFloor.SelectedIndex = -1;

                    nudCapacity.Value = selectedTable.Capacity;

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

                    SetTableButtonStates(false);
                }
                else if (e.Node.Tag is Area area)
                {
                    selectedArea = area;
                    txtAreaName.Text = area.AreaName;
                    SetAreaButtonStates(false);

                    if (!isEditing)
                    {
                        ClearTableForm();
                        cmbFloor.SelectedValue = area.AreaID;
                    }
                }
                else
                {
                    if (!isEditing)
                    {
                        ClearTableForm();
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAreas();
            LoadTables();
            BindDataGridView();
            ClearForm();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            // Form load event
        }

        // Area Management Event Handlers
        private void btnAreaAdd_Click(object sender, EventArgs e)
        {
            ClearAreaForm();
            SetAreaButtonStates(true);
            txtAreaName.Focus();
        }

        private void btnAreaEdit_Click(object sender, EventArgs e)
        {
            if (selectedArea != null)
            {
                SetAreaButtonStates(true);
                txtAreaName.Focus();
            }
        }

        private void btnAreaDelete_Click(object sender, EventArgs e)
        {
            if (selectedArea != null)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khu vực '{selectedArea.AreaName}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = areaBLL.DeleteArea(selectedArea.AreaID);
                        if (success)
                        {
                            MessageBox.Show("Xóa khu vực thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAreas();
                            LoadTables();
                            BindDataGridView();
                            ClearAreaForm();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa khu vực!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa khu vực: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAreaSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAreaName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaName.Focus();
                return;
            }

            try
            {
                bool success = false;
                
                if (selectedArea == null) // Add new
                {
                    var newArea = new Area
                    {
                        AreaID = Guid.NewGuid().ToString(),
                        AreaName = txtAreaName.Text.Trim()
                    };
                    
                    success = areaBLL.AddArea(newArea);
                    
                    if (success)
                    {
                        MessageBox.Show("Thêm khu vực thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Edit existing
                {
                    selectedArea.AreaName = txtAreaName.Text.Trim();
                    success = areaBLL.UpdateArea(selectedArea);
                    
                    if (success)
                    {
                        MessageBox.Show("Cập nhật khu vực thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                if (success)
                {
                    LoadAreas();
                    LoadTables();
                    BindDataGridView();
                    SetAreaButtonStates(false);
                }
                else
                {
                    MessageBox.Show("Không thể lưu khu vực!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu khu vực: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAreaCancel_Click(object sender, EventArgs e)
        {
            SetAreaButtonStates(false);
            if (selectedArea != null)
            {
                txtAreaName.Text = selectedArea.AreaName;
            }
            else
            {
                ClearAreaForm();
            }
        }

        // Table Management Event Handlers
        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            ClearTableForm();
            SetTableButtonStates(true);
            txtTableName.Focus();
        }

        private void btnTableEdit_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                SetTableButtonStates(true);
                txtTableName.Focus();
            }
        }

        private void btnTableDelete_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa bàn '{selectedTable.TableName}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = tableBLL.DeleteTable(selectedTable.TableID);
                        if (success)
                        {
                            MessageBox.Show("Xóa bàn thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTables();
                            BindDataGridView();
                            ClearTableForm();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa bàn!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa bàn: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTableSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTableName.Focus();
                return;
            }

            if (cmbFloor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFloor.Focus();
                return;
            }

            try
            {
                bool success = false;
                TableStatus status = (TableStatus)cmbTableStatus.SelectedIndex;
                
                if (selectedTable == null) // Add new
                {
                    var newTable = new Table
                    {
                        TableID = Guid.NewGuid().ToString(),
                        TableName = txtTableName.Text.Trim(),
                        AreaID = cmbFloor.SelectedValue.ToString(),
                        Capacity = (int)nudCapacity.Value,
                        TableStatus = status
                    };
                    
                    success = tableBLL.AddTable(newTable);
                    
                    if (success)
                    {
                        MessageBox.Show("Thêm bàn thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Edit existing
                {
                    selectedTable.TableName = txtTableName.Text.Trim();
                    selectedTable.AreaID = cmbFloor.SelectedValue.ToString();
                    selectedTable.Capacity = (int)nudCapacity.Value;
                    selectedTable.TableStatus = status;
                    
                    success = tableBLL.UpdateTable(selectedTable);
                    
                    if (success)
                    {
                        MessageBox.Show("Cập nhật bàn thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                if (success)
                {
                    LoadTables();
                    BindDataGridView();
                    SetTableButtonStates(false);
                }
                else
                {
                    MessageBox.Show("Không thể lưu bàn!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu bàn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTableCancel_Click(object sender, EventArgs e)
        {
            SetTableButtonStates(false);
            if (selectedTable != null)
            {
                txtTableName.Text = selectedTable.TableName;
                cmbFloor.SelectedValue = selectedTable.AreaID;
                nudCapacity.Value = selectedTable.Capacity;
                cmbTableStatus.SelectedIndex = (int)selectedTable.TableStatus;
            }
            else
            {
                ClearTableForm();
            }
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
    }
}