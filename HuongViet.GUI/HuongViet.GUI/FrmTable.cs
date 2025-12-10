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
            // Event handlers will be added as needed
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

                // Hiển thị tất cả khu vực, bao gồm cả khu vực chưa có bàn
                foreach (var area in areas)
                {
                    var areaNode = new TreeNode(area.AreaName);
                    areaNode.Tag = area;
                    areaNode.NodeFont = new Font("Times New Roman", 14F, FontStyle.Bold);
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

        // Area Management Event Handlers (to be implemented)
        private void btnAreaAdd_Click(object sender, EventArgs e) { }
        private void btnAreaEdit_Click(object sender, EventArgs e) { }
        private void btnAreaDelete_Click(object sender, EventArgs e) { }
        private void btnAreaSave_Click(object sender, EventArgs e) { }
        private void btnAreaCancel_Click(object sender, EventArgs e) { }

        // Table Management Event Handlers (to be implemented)
        private void btnTableAdd_Click(object sender, EventArgs e) { }
        private void btnTableEdit_Click(object sender, EventArgs e) { }
        private void btnTableDelete_Click(object sender, EventArgs e) { }
        private void btnTableSave_Click(object sender, EventArgs e) { }
        private void btnTableCancel_Click(object sender, EventArgs e) { }
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