using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    partial class FrmTable
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
			this.pnlMain = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnRefresh = new FontAwesome.Sharp.IconButton();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.lblTreeTitle = new System.Windows.Forms.Label();
			this.flpAreas = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlCenter = new System.Windows.Forms.Panel();
			this.grpAreaInfo = new System.Windows.Forms.GroupBox();
			this.pnlAreaButtons = new System.Windows.Forms.Panel();
			this.btnAreaAdd = new FontAwesome.Sharp.IconButton();
			this.btnAreaEdit = new FontAwesome.Sharp.IconButton();
			this.btnAreaDelete = new FontAwesome.Sharp.IconButton();
			this.txtAreaName = new System.Windows.Forms.TextBox();
			this.lblAreaName = new System.Windows.Forms.Label();
			this.btnAreaCancel = new FontAwesome.Sharp.IconButton();
			this.btnAreaSave = new FontAwesome.Sharp.IconButton();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.grpTableInfo = new System.Windows.Forms.GroupBox();
			this.pnlTableButtons = new System.Windows.Forms.Panel();
			this.btnTableAdd = new FontAwesome.Sharp.IconButton();
			this.btnTableEdit = new FontAwesome.Sharp.IconButton();
			this.btnTableDelete = new FontAwesome.Sharp.IconButton();
			this.cmbTableStatus = new System.Windows.Forms.ComboBox();
			this.lblTableStatus = new System.Windows.Forms.Label();
			this.btnTableSave = new FontAwesome.Sharp.IconButton();
			this.nudCapacity = new System.Windows.Forms.NumericUpDown();
			this.btnTableCancel = new FontAwesome.Sharp.IconButton();
			this.lblCapacity = new System.Windows.Forms.Label();
			this.cmbFloor = new System.Windows.Forms.ComboBox();
			this.lblFloor = new System.Windows.Forms.Label();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.lblTableName = new System.Windows.Forms.Label();
			this.pnlMain.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlCenter.SuspendLayout();
			this.grpAreaInfo.SuspendLayout();
			this.pnlAreaButtons.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.grpTableInfo.SuspendLayout();
			this.pnlTableButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.lblTitle);
			this.pnlMain.Controls.Add(this.btnRefresh);
			this.pnlMain.Controls.Add(this.pnlLeft);
			this.pnlMain.Controls.Add(this.pnlCenter);
			this.pnlMain.Controls.Add(this.pnlRight);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1924, 999);
			this.pnlMain.TabIndex = 0;
			this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(20, 12);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(197, 38);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý bàn";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
			this.btnRefresh.IconColor = System.Drawing.Color.Black;
			this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRefresh.IconSize = 20;
			this.btnRefresh.Location = new System.Drawing.Point(1707, 15);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnRefresh.Size = new System.Drawing.Size(202, 56);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.lblTreeTitle);
			this.pnlLeft.Controls.Add(this.flpAreas);
			this.pnlLeft.Location = new System.Drawing.Point(20, 80);
			this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(1004, 900);
			this.pnlLeft.TabIndex = 2;
			// 
			// lblTreeTitle
			// 
			this.lblTreeTitle.AutoSize = true;
			this.lblTreeTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTreeTitle.Location = new System.Drawing.Point(3, 1);
			this.lblTreeTitle.Name = "lblTreeTitle";
			this.lblTreeTitle.Size = new System.Drawing.Size(99, 26);
			this.lblTreeTitle.TabIndex = 0;
			this.lblTreeTitle.Text = "Khu vực";
			// 
			// flpAreas
			// 
			this.flpAreas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpAreas.AutoScroll = true;
			this.flpAreas.BackColor = System.Drawing.Color.White;
			this.flpAreas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpAreas.Location = new System.Drawing.Point(0, 34);
			this.flpAreas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flpAreas.Name = "flpAreas";
			this.flpAreas.Padding = new System.Windows.Forms.Padding(4);
			this.flpAreas.Size = new System.Drawing.Size(1000, 860);
			this.flpAreas.TabIndex = 1;
			this.flpAreas.WrapContents = false;
			// 
			// pnlCenter
			// 
			this.pnlCenter.Controls.Add(this.grpAreaInfo);
			this.pnlCenter.Location = new System.Drawing.Point(1030, 81);
			this.pnlCenter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlCenter.Name = "pnlCenter";
			this.pnlCenter.Size = new System.Drawing.Size(879, 338);
			this.pnlCenter.TabIndex = 3;
			// 
			// grpAreaInfo
			// 
			this.grpAreaInfo.Controls.Add(this.pnlAreaButtons);
			this.grpAreaInfo.Controls.Add(this.txtAreaName);
			this.grpAreaInfo.Controls.Add(this.lblAreaName);
			this.grpAreaInfo.Controls.Add(this.btnAreaCancel);
			this.grpAreaInfo.Controls.Add(this.btnAreaSave);
			this.grpAreaInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
			this.grpAreaInfo.Location = new System.Drawing.Point(6, 2);
			this.grpAreaInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.grpAreaInfo.Name = "grpAreaInfo";
			this.grpAreaInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.grpAreaInfo.Size = new System.Drawing.Size(873, 335);
			this.grpAreaInfo.TabIndex = 0;
			this.grpAreaInfo.TabStop = false;
			this.grpAreaInfo.Text = "Thông tin khu vực";
			// 
			// pnlAreaButtons
			// 
			this.pnlAreaButtons.Controls.Add(this.btnAreaAdd);
			this.pnlAreaButtons.Controls.Add(this.btnAreaEdit);
			this.pnlAreaButtons.Controls.Add(this.btnAreaDelete);
			this.pnlAreaButtons.Location = new System.Drawing.Point(44, 104);
			this.pnlAreaButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlAreaButtons.Name = "pnlAreaButtons";
			this.pnlAreaButtons.Size = new System.Drawing.Size(812, 98);
			this.pnlAreaButtons.TabIndex = 2;
			// 
			// btnAreaAdd
			// 
			this.btnAreaAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.btnAreaAdd.IconColor = System.Drawing.Color.Black;
			this.btnAreaAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAreaAdd.IconSize = 18;
			this.btnAreaAdd.Location = new System.Drawing.Point(148, 29);
			this.btnAreaAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAreaAdd.Name = "btnAreaAdd";
			this.btnAreaAdd.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAreaAdd.Size = new System.Drawing.Size(149, 46);
			this.btnAreaAdd.TabIndex = 0;
			this.btnAreaAdd.Text = "Thêm";
			this.btnAreaAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAreaAdd.UseVisualStyleBackColor = true;
			// 
			// btnAreaEdit
			// 
			this.btnAreaEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnAreaEdit.IconColor = System.Drawing.Color.Black;
			this.btnAreaEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAreaEdit.IconSize = 18;
			this.btnAreaEdit.Location = new System.Drawing.Point(324, 29);
			this.btnAreaEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAreaEdit.Name = "btnAreaEdit";
			this.btnAreaEdit.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAreaEdit.Size = new System.Drawing.Size(149, 46);
			this.btnAreaEdit.TabIndex = 1;
			this.btnAreaEdit.Text = "Sửa";
			this.btnAreaEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAreaEdit.UseVisualStyleBackColor = true;
			// 
			// btnAreaDelete
			// 
			this.btnAreaDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
			this.btnAreaDelete.IconColor = System.Drawing.Color.Black;
			this.btnAreaDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAreaDelete.IconSize = 18;
			this.btnAreaDelete.Location = new System.Drawing.Point(505, 29);
			this.btnAreaDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAreaDelete.Name = "btnAreaDelete";
			this.btnAreaDelete.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAreaDelete.Size = new System.Drawing.Size(149, 46);
			this.btnAreaDelete.TabIndex = 2;
			this.btnAreaDelete.Text = "Xóa";
			this.btnAreaDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAreaDelete.UseVisualStyleBackColor = true;
			// 
			// txtAreaName
			// 
			this.txtAreaName.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.txtAreaName.Location = new System.Drawing.Point(177, 45);
			this.txtAreaName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtAreaName.Name = "txtAreaName";
			this.txtAreaName.Size = new System.Drawing.Size(354, 38);
			this.txtAreaName.TabIndex = 1;
			// 
			// lblAreaName
			// 
			this.lblAreaName.AutoSize = true;
			this.lblAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblAreaName.Location = new System.Drawing.Point(20, 51);
			this.lblAreaName.Name = "lblAreaName";
			this.lblAreaName.Size = new System.Drawing.Size(113, 22);
			this.lblAreaName.TabIndex = 0;
			this.lblAreaName.Text = "Tên khu vực:";
			// 
			// btnAreaCancel
			// 
			this.btnAreaCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnAreaCancel.IconColor = System.Drawing.Color.Black;
			this.btnAreaCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAreaCancel.IconSize = 18;
			this.btnAreaCancel.Location = new System.Drawing.Point(713, 43);
			this.btnAreaCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAreaCancel.Name = "btnAreaCancel";
			this.btnAreaCancel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAreaCancel.Size = new System.Drawing.Size(123, 46);
			this.btnAreaCancel.TabIndex = 4;
			this.btnAreaCancel.Text = "Hủy";
			this.btnAreaCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAreaCancel.UseVisualStyleBackColor = true;
			// 
			// btnAreaSave
			// 
			this.btnAreaSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnAreaSave.IconColor = System.Drawing.Color.Black;
			this.btnAreaSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAreaSave.IconSize = 18;
			this.btnAreaSave.Location = new System.Drawing.Point(565, 43);
			this.btnAreaSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAreaSave.Name = "btnAreaSave";
			this.btnAreaSave.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAreaSave.Size = new System.Drawing.Size(123, 46);
			this.btnAreaSave.TabIndex = 3;
			this.btnAreaSave.Text = "Lưu";
			this.btnAreaSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAreaSave.UseVisualStyleBackColor = true;
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.grpTableInfo);
			this.pnlRight.Location = new System.Drawing.Point(1030, 423);
			this.pnlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Size = new System.Drawing.Size(879, 526);
			this.pnlRight.TabIndex = 4;
			// 
			// grpTableInfo
			// 
			this.grpTableInfo.Controls.Add(this.pnlTableButtons);
			this.grpTableInfo.Controls.Add(this.cmbTableStatus);
			this.grpTableInfo.Controls.Add(this.lblTableStatus);
			this.grpTableInfo.Controls.Add(this.btnTableSave);
			this.grpTableInfo.Controls.Add(this.nudCapacity);
			this.grpTableInfo.Controls.Add(this.btnTableCancel);
			this.grpTableInfo.Controls.Add(this.lblCapacity);
			this.grpTableInfo.Controls.Add(this.cmbFloor);
			this.grpTableInfo.Controls.Add(this.lblFloor);
			this.grpTableInfo.Controls.Add(this.txtTableName);
			this.grpTableInfo.Controls.Add(this.lblTableName);
			this.grpTableInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
			this.grpTableInfo.Location = new System.Drawing.Point(3, 25);
			this.grpTableInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.grpTableInfo.Name = "grpTableInfo";
			this.grpTableInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.grpTableInfo.Size = new System.Drawing.Size(873, 470);
			this.grpTableInfo.TabIndex = 0;
			this.grpTableInfo.TabStop = false;
			this.grpTableInfo.Text = "Thông tin bàn";
			// 
			// pnlTableButtons
			// 
			this.pnlTableButtons.Controls.Add(this.btnTableAdd);
			this.pnlTableButtons.Controls.Add(this.btnTableEdit);
			this.pnlTableButtons.Controls.Add(this.btnTableDelete);
			this.pnlTableButtons.Location = new System.Drawing.Point(20, 286);
			this.pnlTableButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlTableButtons.Name = "pnlTableButtons";
			this.pnlTableButtons.Size = new System.Drawing.Size(847, 102);
			this.pnlTableButtons.TabIndex = 8;
			// 
			// btnTableAdd
			// 
			this.btnTableAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.btnTableAdd.IconColor = System.Drawing.Color.Black;
			this.btnTableAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTableAdd.IconSize = 18;
			this.btnTableAdd.Location = new System.Drawing.Point(148, 23);
			this.btnTableAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTableAdd.Name = "btnTableAdd";
			this.btnTableAdd.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnTableAdd.Size = new System.Drawing.Size(149, 46);
			this.btnTableAdd.TabIndex = 0;
			this.btnTableAdd.Text = "Thêm";
			this.btnTableAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTableAdd.UseVisualStyleBackColor = true;
			// 
			// btnTableEdit
			// 
			this.btnTableEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnTableEdit.IconColor = System.Drawing.Color.Black;
			this.btnTableEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTableEdit.IconSize = 18;
			this.btnTableEdit.Location = new System.Drawing.Point(324, 23);
			this.btnTableEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTableEdit.Name = "btnTableEdit";
			this.btnTableEdit.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnTableEdit.Size = new System.Drawing.Size(149, 46);
			this.btnTableEdit.TabIndex = 1;
			this.btnTableEdit.Text = "Sửa";
			this.btnTableEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTableEdit.UseVisualStyleBackColor = true;
			// 
			// btnTableDelete
			// 
			this.btnTableDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
			this.btnTableDelete.IconColor = System.Drawing.Color.Black;
			this.btnTableDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTableDelete.IconSize = 18;
			this.btnTableDelete.Location = new System.Drawing.Point(505, 23);
			this.btnTableDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTableDelete.Name = "btnTableDelete";
			this.btnTableDelete.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnTableDelete.Size = new System.Drawing.Size(149, 46);
			this.btnTableDelete.TabIndex = 2;
			this.btnTableDelete.Text = "Xóa";
			this.btnTableDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTableDelete.UseVisualStyleBackColor = true;
			// 
			// cmbTableStatus
			// 
			this.cmbTableStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTableStatus.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.cmbTableStatus.FormattingEnabled = true;
			this.cmbTableStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang sử dụng",
            "Đang dọn dẹp",
            "Không khả dụng"});
			this.cmbTableStatus.Location = new System.Drawing.Point(140, 206);
			this.cmbTableStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbTableStatus.Name = "cmbTableStatus";
			this.cmbTableStatus.Size = new System.Drawing.Size(394, 34);
			this.cmbTableStatus.TabIndex = 7;
			// 
			// lblTableStatus
			// 
			this.lblTableStatus.AutoSize = true;
			this.lblTableStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblTableStatus.Location = new System.Drawing.Point(20, 209);
			this.lblTableStatus.Name = "lblTableStatus";
			this.lblTableStatus.Size = new System.Drawing.Size(95, 22);
			this.lblTableStatus.TabIndex = 6;
			this.lblTableStatus.Text = "Trạng thái:";
			// 
			// btnTableSave
			// 
			this.btnTableSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnTableSave.IconColor = System.Drawing.Color.Black;
			this.btnTableSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTableSave.IconSize = 18;
			this.btnTableSave.Location = new System.Drawing.Point(571, 200);
			this.btnTableSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTableSave.Name = "btnTableSave";
			this.btnTableSave.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnTableSave.Size = new System.Drawing.Size(123, 46);
			this.btnTableSave.TabIndex = 3;
			this.btnTableSave.Text = "Lưu";
			this.btnTableSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTableSave.UseVisualStyleBackColor = true;
			// 
			// nudCapacity
			// 
			this.nudCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.nudCapacity.Location = new System.Drawing.Point(140, 155);
			this.nudCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.nudCapacity.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudCapacity.Name = "nudCapacity";
			this.nudCapacity.Size = new System.Drawing.Size(120, 30);
			this.nudCapacity.TabIndex = 5;
			this.nudCapacity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// btnTableCancel
			// 
			this.btnTableCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnTableCancel.IconColor = System.Drawing.Color.Black;
			this.btnTableCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTableCancel.IconSize = 18;
			this.btnTableCancel.Location = new System.Drawing.Point(716, 201);
			this.btnTableCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTableCancel.Name = "btnTableCancel";
			this.btnTableCancel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnTableCancel.Size = new System.Drawing.Size(123, 46);
			this.btnTableCancel.TabIndex = 4;
			this.btnTableCancel.Text = "Hủy";
			this.btnTableCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTableCancel.UseVisualStyleBackColor = true;
			// 
			// lblCapacity
			// 
			this.lblCapacity.AutoSize = true;
			this.lblCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblCapacity.Location = new System.Drawing.Point(20, 156);
			this.lblCapacity.Name = "lblCapacity";
			this.lblCapacity.Size = new System.Drawing.Size(90, 22);
			this.lblCapacity.TabIndex = 4;
			this.lblCapacity.Text = "Sức chứa:";
			// 
			// cmbFloor
			// 
			this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFloor.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.cmbFloor.FormattingEnabled = true;
			this.cmbFloor.Location = new System.Drawing.Point(140, 100);
			this.cmbFloor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbFloor.Name = "cmbFloor";
			this.cmbFloor.Size = new System.Drawing.Size(394, 34);
			this.cmbFloor.TabIndex = 3;
			// 
			// lblFloor
			// 
			this.lblFloor.AutoSize = true;
			this.lblFloor.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblFloor.Location = new System.Drawing.Point(20, 103);
			this.lblFloor.Name = "lblFloor";
			this.lblFloor.Size = new System.Drawing.Size(83, 22);
			this.lblFloor.TabIndex = 2;
			this.lblFloor.Text = "Khu vực:";
			// 
			// txtTableName
			// 
			this.txtTableName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.txtTableName.Location = new System.Drawing.Point(140, 45);
			this.txtTableName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(394, 34);
			this.txtTableName.TabIndex = 1;
			// 
			// lblTableName
			// 
			this.lblTableName.AutoSize = true;
			this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblTableName.Location = new System.Drawing.Point(20, 50);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(79, 22);
			this.lblTableName.TabIndex = 0;
			this.lblTableName.Text = "Tên bàn:";
			// 
			// FrmTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1924, 999);
			this.Controls.Add(this.pnlMain);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmTable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý bàn";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmTable_Load);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.pnlLeft.ResumeLayout(false);
			this.pnlLeft.PerformLayout();
			this.pnlCenter.ResumeLayout(false);
			this.grpAreaInfo.ResumeLayout(false);
			this.grpAreaInfo.PerformLayout();
			this.pnlAreaButtons.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.grpTableInfo.ResumeLayout(false);
			this.grpTableInfo.PerformLayout();
			this.pnlTableButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Label lblTitle;
		private FontAwesome.Sharp.IconButton btnRefresh;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Label lblTreeTitle;
		private System.Windows.Forms.FlowLayoutPanel flpAreas;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.GroupBox grpAreaInfo;
        private System.Windows.Forms.Panel pnlAreaButtons;
		private FontAwesome.Sharp.IconButton btnAreaCancel;
		private FontAwesome.Sharp.IconButton btnAreaSave;
		private FontAwesome.Sharp.IconButton btnAreaDelete;
		private FontAwesome.Sharp.IconButton btnAreaEdit;
		private FontAwesome.Sharp.IconButton btnAreaAdd;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpTableInfo;
        private System.Windows.Forms.Panel pnlTableButtons;
		private FontAwesome.Sharp.IconButton btnTableCancel;
		private FontAwesome.Sharp.IconButton btnTableSave;
		private FontAwesome.Sharp.IconButton btnTableDelete;
		private FontAwesome.Sharp.IconButton btnTableEdit;
		private FontAwesome.Sharp.IconButton btnTableAdd;
        private System.Windows.Forms.ComboBox cmbTableStatus;
        private System.Windows.Forms.Label lblTableStatus;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
    }
}