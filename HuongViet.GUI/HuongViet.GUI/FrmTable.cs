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
            btnAreaAdd.Click += btnAreaAdd_Click;
            btnAreaEdit.Click += btnAreaEdit_Click;
            btnAreaDelete.Click += btnAreaDelete_Click;
            btnAreaSave.Click += btnAreaSave_Click;
            btnAreaCancel.Click += btnAreaCancel_Click;

            btnTableAdd.Click += btnTableAdd_Click;
            btnTableEdit.Click += btnTableEdit_Click;
            btnTableDelete.Click += btnTableDelete_Click;
            btnTableSave.Click += btnTableSave_Click;
            btnTableCancel.Click += btnTableCancel_Click;

            btnRefresh.Click += btnRefresh_Click;
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
                RenderAreasAndTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderAreasAndTables()
        {
            try
            {
                flpAreas.SuspendLayout();
                flpAreas.Controls.Clear();

                if (areas == null || areas.Count == 0)
                {
                    var notice = new Label
                    {
                        Text = "Chưa có khu vực nào. Vui lòng thêm khu vực trước.",
                        AutoSize = true,
                        ForeColor = Color.DarkRed,
                        Font = new Font("Times New Roman", 12F, FontStyle.Italic),
                        Padding = new Padding(8)
                    };
                    flpAreas.Controls.Add(notice);
                    return;
                }

                int areaWidth = flpAreas.ClientSize.Width - 12;

                foreach (var area in areas)
                {
                    var areaPanel = new Panel
                    {
                        Width = areaWidth > 0 ? areaWidth : 820,
                        Margin = new Padding(4, 6, 4, 6),
                        Padding = new Padding(8, 6, 8, 8),
                        BackColor = Color.WhiteSmoke,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = area,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink
                    };

                    var header = new Label
                    {
                        Text = area.AreaName,
                        Font = new Font("Times New Roman", 14F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(33, 79, 129),
                        AutoSize = true,
                        Location = new Point(8, 6),
                        Cursor = Cursors.Hand,
                        Tag = area
                    };
                    header.Click += AreaHeader_Click;

                    var tablesFlow = new FlowLayoutPanel
                    {
                        Location = new Point(8, 32),
                        Width = areaPanel.Width - 16,
                        Height = 56,
                        AutoScroll = true,
                        WrapContents = false,
                        FlowDirection = FlowDirection.LeftToRight,
                        Tag = area
                    };

                    var tablesInArea = tables?.Where(t => t.AreaID == area.AreaID).OrderBy(t => t.TableName).ToList() ?? new List<Table>();
                    if (tablesInArea.Any())
                    {
                        foreach (var table in tablesInArea)
                        {
                            tablesFlow.Controls.Add(CreateTableButton(table));
                        }
                    }
                    else
                    {
                        var empty = new Label
                        {
                            Text = "(Chưa có bàn)",
                            AutoSize = true,
                            ForeColor = Color.Gray,
                            Font = new Font("Times New Roman", 12F, FontStyle.Italic),
                            Padding = new Padding(4)
                        };
                        tablesFlow.Controls.Add(empty);
                    }

                    areaPanel.Controls.Add(header);
                    areaPanel.Controls.Add(tablesFlow);
                    flpAreas.Controls.Add(areaPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpAreas.ResumeLayout();
            }
        }

        private Button CreateTableButton(Table table)
        {
            var btn = new Button
            {
                Width = 120,
                Height = 42,
                Margin = new Padding(4),
                Tag = table,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Times New Roman", 12F, FontStyle.Regular)
            };

            btn.Text = table.TableName;

            switch (table.TableStatus)
            {
                case TableStatus.Available:
                    btn.BackColor = Color.Honeydew;
                    btn.ForeColor = Color.DarkGreen;
                    break;
                case TableStatus.Occupied:
                    btn.BackColor = Color.MistyRose;
                    btn.ForeColor = Color.DarkRed;
                    break;
                case TableStatus.Cleaning:
                    btn.BackColor = Color.LemonChiffon;
                    btn.ForeColor = Color.Peru;
                    break;
                case TableStatus.Unavailable:
                    btn.BackColor = Color.Gainsboro;
                    btn.ForeColor = Color.DimGray;
                    break;
            }

            btn.Click += TableButton_Click;
            return btn;
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

        private void TableButton_Click(object sender, EventArgs e)
        {
            if (isEditing || isAreaEditing)
                return;

            if (sender is Button btn && btn.Tag is Table table)
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
        }

        private void AreaHeader_Click(object sender, EventArgs e)
        {
            if (isEditing)
                return;

            if (sender is Control ctrl && ctrl.Tag is Area area)
            {
                selectedArea = area;
                txtAreaName.Text = area.AreaName;
                SetAreaButtonStates(false);

                ClearTableForm();
                cmbFloor.SelectedValue = area.AreaID;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAreas();
            LoadTables();
            ClearForm();
            RenderAreasAndTables();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            // Form load event
        }

        // Area Management Event Handlers
        private void btnAreaAdd_Click(object sender, EventArgs e)
        {
            selectedArea = null;
            txtAreaName.Clear();
            SetAreaButtonStates(true);
            txtAreaName.Focus();
        }

        private void btnAreaEdit_Click(object sender, EventArgs e)
        {
            if (selectedArea == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetAreaButtonStates(true);
            txtAreaName.Focus();
            txtAreaName.SelectAll();
        }

        private void btnAreaDelete_Click(object sender, EventArgs e)
        {
            if (selectedArea == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tablesInArea = tableBLL.GetTablesByArea(selectedArea.AreaID) ?? new List<Table>();
            string message = tablesInArea.Count > 0
                ? $"Khu vực đang có {tablesInArea.Count} bàn. Bạn có chắc chắn muốn xóa?"
                : "Bạn có chắc chắn muốn xóa khu vực này?";

            var confirm = MessageBox.Show(message, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (areaBLL.DeleteArea(selectedArea.AreaID))
                {
                    MessageBox.Show("Xóa khu vực thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAreas();
                    LoadTables();
                    RenderAreasAndTables();
                    ClearAreaForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khu vực: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAreaSave_Click(object sender, EventArgs e)
        {
            string areaName = txtAreaName.Text.Trim();
            if (string.IsNullOrWhiteSpace(areaName))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaName.Focus();
                return;
            }

            try
            {
                if (selectedArea == null)
                {
                    var newArea = new Area
                    {
                        AreaName = areaName
                    };
                    areaBLL.AddArea(newArea);
                    MessageBox.Show("Thêm khu vực thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    selectedArea.AreaName = areaName;
                    areaBLL.UpdateArea(selectedArea);
                    MessageBox.Show("Cập nhật khu vực thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadAreas();
                LoadTables();
                RenderAreasAndTables();
                ClearAreaForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu khu vực: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAreaCancel_Click(object sender, EventArgs e)
        {
            ClearAreaForm();
        }

        // Table Management Event Handlers (to be implemented)
        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            selectedTable = null;
            txtTableName.Clear();
            cmbFloor.SelectedIndex = -1;
            nudCapacity.Value = 4;
            cmbTableStatus.SelectedIndex = 0;
            SetTableButtonStates(true);
            txtTableName.Focus();
        }

        private void btnTableEdit_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetTableButtonStates(true);
            txtTableName.Focus();
            txtTableName.SelectAll();
        }

        private void btnTableDelete_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bàn '{selectedTable.TableName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (tableBLL.DeleteTable(selectedTable.TableID))
                {
                    MessageBox.Show("Xóa bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables();
                    ClearTableForm();
                    RenderAreasAndTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTableSave_Click(object sender, EventArgs e)
        {
            string validationError = ValidateTableInput();
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTableName.Focus();
                return;
            }

            try
            {
                Table table = selectedTable ?? new Table();
                table.TableName = txtTableName.Text.Trim();
                table.AreaID = cmbFloor.SelectedValue?.ToString();
                table.Capacity = (int)nudCapacity.Value;

                TableStatus status = TableStatus.Available;
                switch (cmbTableStatus.SelectedIndex)
                {
                    case 1:
                        status = TableStatus.Occupied;
                        break;
                    case 2:
                        status = TableStatus.Cleaning;
                        break;
                    case 3:
                        status = TableStatus.Unavailable;
                        break;
                }
                table.TableStatus = status;

                bool success;
                string message;

                if (selectedTable == null)
                {
                    success = tableBLL.AddTable(table);
                    message = success ? "Thêm bàn thành công!" : "Không thể thêm bàn!";
                }
                else
                {
                    table.TableID = selectedTable.TableID;
                    success = tableBLL.UpdateTable(table);
                    message = success ? "Cập nhật bàn thành công!" : "Không thể cập nhật bàn!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables();
                    RenderAreasAndTables();
                    ClearTableForm();
                    SetTableButtonStates(false);
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

        private void btnTableCancel_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                txtTableName.Text = selectedTable.TableName;

                if (!string.IsNullOrEmpty(selectedTable.AreaID))
                    cmbFloor.SelectedValue = selectedTable.AreaID;
                else
                    cmbFloor.SelectedIndex = -1;

                nudCapacity.Value = selectedTable.Capacity;

                int statusIndex = 0;
                switch (selectedTable.TableStatus)
                {
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
                ClearTableForm();
            }

            SetTableButtonStates(false);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private string ValidateTableInput()
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
                return "Vui lòng nhập tên bàn!";

            if (txtTableName.Text.Trim().Length > 20)
                return "Tên bàn không được vượt quá 20 ký tự!";

            if (cmbFloor.SelectedValue == null)
                return "Vui lòng chọn khu vực!";

            if (nudCapacity.Value <= 0)
                return "Sức chứa phải lớn hơn 0!";

            return null;
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