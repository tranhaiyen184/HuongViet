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
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.treeViewTables = new System.Windows.Forms.TreeView();
			this.lblTreeTitle = new System.Windows.Forms.Label();
			this.pnlCenter = new System.Windows.Forms.Panel();
			this.grpAreaInfo = new System.Windows.Forms.GroupBox();
			this.pnlAreaButtons = new System.Windows.Forms.Panel();
			this.btnAreaCancel = new System.Windows.Forms.Button();
			this.btnAreaSave = new System.Windows.Forms.Button();
			this.btnAreaDelete = new System.Windows.Forms.Button();
			this.btnAreaEdit = new System.Windows.Forms.Button();
			this.btnAreaAdd = new System.Windows.Forms.Button();
			this.txtAreaName = new System.Windows.Forms.TextBox();
			this.lblAreaName = new System.Windows.Forms.Label();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.grpTableInfo = new System.Windows.Forms.GroupBox();
			this.pnlTableButtons = new System.Windows.Forms.Panel();
			this.btnTableCancel = new System.Windows.Forms.Button();
			this.btnTableSave = new System.Windows.Forms.Button();
			this.btnTableDelete = new System.Windows.Forms.Button();
			this.btnTableEdit = new System.Windows.Forms.Button();
			this.btnTableAdd = new System.Windows.Forms.Button();
			this.cmbTableStatus = new System.Windows.Forms.ComboBox();
			this.lblTableStatus = new System.Windows.Forms.Label();
			this.nudCapacity = new System.Windows.Forms.NumericUpDown();
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
			this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1628, 1081);
			this.pnlMain.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(20, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(186, 38);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý bàn";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.Location = new System.Drawing.Point(1450, 20);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(150, 40);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.lblTreeTitle);
			this.pnlLeft.Controls.Add(this.treeViewTables);
			this.pnlLeft.Location = new System.Drawing.Point(20, 80);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(400, 980);
			this.pnlLeft.TabIndex = 2;
			// 
			// lblTreeTitle
			// 
			this.lblTreeTitle.AutoSize = true;
			this.lblTreeTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
			this.lblTreeTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTreeTitle.Name = "lblTreeTitle";
			this.lblTreeTitle.Size = new System.Drawing.Size(126, 31);
			this.lblTreeTitle.TabIndex = 0;
			this.lblTreeTitle.Text = "Khu vực";
			// 
			// treeViewTables
			// 
			this.treeViewTables.BackColor = System.Drawing.Color.White;
			this.treeViewTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeViewTables.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.treeViewTables.FullRowSelect = true;
			this.treeViewTables.HideSelection = false;
			this.treeViewTables.ItemHeight = 30;
			this.treeViewTables.Location = new System.Drawing.Point(0, 40);
			this.treeViewTables.Name = "treeViewTables";
			this.treeViewTables.ShowLines = true;
			this.treeViewTables.ShowPlusMinus = true;
			this.treeViewTables.ShowRootLines = true;
			this.treeViewTables.Size = new System.Drawing.Size(400, 940);
			this.treeViewTables.TabIndex = 1;
			this.treeViewTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTables_AfterSelect);
			// 
			// pnlCenter
			// 
			this.pnlCenter.Controls.Add(this.grpAreaInfo);
			this.pnlCenter.Location = new System.Drawing.Point(440, 80);
			this.pnlCenter.Name = "pnlCenter";
			this.pnlCenter.Size = new System.Drawing.Size(400, 980);
			this.pnlCenter.TabIndex = 3;
			// 
			// grpAreaInfo
			// 
			this.grpAreaInfo.Controls.Add(this.pnlAreaButtons);
			this.grpAreaInfo.Controls.Add(this.txtAreaName);
			this.grpAreaInfo.Controls.Add(this.lblAreaName);
			this.grpAreaInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
			this.grpAreaInfo.Location = new System.Drawing.Point(0, 0);
			this.grpAreaInfo.Name = "grpAreaInfo";
			this.grpAreaInfo.Size = new System.Drawing.Size(400, 200);
			this.grpAreaInfo.TabIndex = 0;
			this.grpAreaInfo.TabStop = false;
			this.grpAreaInfo.Text = "Quản lý khu vực";
			// 
			// lblAreaName
			// 
			this.lblAreaName.AutoSize = true;
			this.lblAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblAreaName.Location = new System.Drawing.Point(20, 40);
			this.lblAreaName.Name = "lblAreaName";
			this.lblAreaName.Size = new System.Drawing.Size(103, 22);
			this.lblAreaName.TabIndex = 0;
			this.lblAreaName.Text = "Tên khu vực:";
			// 
			// txtAreaName
			// 
			this.txtAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.txtAreaName.Location = new System.Drawing.Point(20, 70);
			this.txtAreaName.Name = "txtAreaName";
			this.txtAreaName.Size = new System.Drawing.Size(360, 30);
			this.txtAreaName.TabIndex = 1;
			// 
			// pnlAreaButtons
			// 
			this.pnlAreaButtons.Controls.Add(this.btnAreaAdd);
			this.pnlAreaButtons.Controls.Add(this.btnAreaEdit);
			this.pnlAreaButtons.Controls.Add(this.btnAreaDelete);
			this.pnlAreaButtons.Controls.Add(this.btnAreaSave);
			this.pnlAreaButtons.Controls.Add(this.btnAreaCancel);
			this.pnlAreaButtons.Location = new System.Drawing.Point(20, 120);
			this.pnlAreaButtons.Name = "pnlAreaButtons";
			this.pnlAreaButtons.Size = new System.Drawing.Size(360, 60);
			this.pnlAreaButtons.TabIndex = 2;
			// 
			// btnAreaAdd
			// 
			this.btnAreaAdd.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.btnAreaAdd.Location = new System.Drawing.Point(0, 0);
			this.btnAreaAdd.Name = "btnAreaAdd";
			this.btnAreaAdd.Size = new System.Drawing.Size(60, 30);
			this.btnAreaAdd.TabIndex = 0;
			this.btnAreaAdd.Text = "Thêm";
			this.btnAreaAdd.UseVisualStyleBackColor = true;
			// 
			// btnAreaEdit
			// 
			this.btnAreaEdit.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.btnAreaEdit.Location = new System.Drawing.Point(70, 0);
			this.btnAreaEdit.Name = "btnAreaEdit";
			this.btnAreaEdit.Size = new System.Drawing.Size(60, 30);
			this.btnAreaEdit.TabIndex = 1;
			this.btnAreaEdit.Text = "Sửa";
			this.btnAreaEdit.UseVisualStyleBackColor = true;
			// 
			// btnAreaDelete
			// 
			this.btnAreaDelete.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.btnAreaDelete.Location = new System.Drawing.Point(140, 0);
			this.btnAreaDelete.Name = "btnAreaDelete";
			this.btnAreaDelete.Size = new System.Drawing.Size(60, 30);
			this.btnAreaDelete.TabIndex = 2;
			this.btnAreaDelete.Text = "Xóa";
			this.btnAreaDelete.UseVisualStyleBackColor = true;
			// 
			// btnPrevPage
			// 
			this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnPrevPage.Location = new System.Drawing.Point(90, 10);
			this.btnPrevPage.Margin = new System.Windows.Forms.Padding(0);
			this.btnPrevPage.Name = "btnPrevPage";
			this.btnPrevPage.Size = new System.Drawing.Size(61, 50);
			this.btnPrevPage.TabIndex = 1;
			this.btnPrevPage.Text = "<";
			this.btnPrevPage.UseVisualStyleBackColor = true;
			this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnNextPage.Location = new System.Drawing.Point(159, 10);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(0);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(61, 50);
			this.btnNextPage.TabIndex = 2;
			this.btnNextPage.Text = ">";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// btnLastPage
			// 
			this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnLastPage.Location = new System.Drawing.Point(226, 10);
			this.btnLastPage.Margin = new System.Windows.Forms.Padding(0);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new System.Drawing.Size(61, 50);
			this.btnLastPage.TabIndex = 3;
			this.btnLastPage.Text = ">>";
			this.btnLastPage.UseVisualStyleBackColor = true;
			this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
			// 
			// lblPageInfo
			// 
			this.lblPageInfo.AutoSize = true;
			this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageInfo.Location = new System.Drawing.Point(316, 22);
			this.lblPageInfo.Margin = new System.Windows.Forms.Padding(0);
			this.lblPageInfo.Name = "lblPageInfo";
			this.lblPageInfo.Size = new System.Drawing.Size(181, 22);
			this.lblPageInfo.TabIndex = 6;
			this.lblPageInfo.Text = "Trang 1 / 1  (Tổng: 0)";
			this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbPageSize
			// 
			this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPageSize.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.cmbPageSize.FormattingEnabled = true;
			this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
			this.cmbPageSize.Location = new System.Drawing.Point(825, 19);
			this.cmbPageSize.Margin = new System.Windows.Forms.Padding(0);
			this.cmbPageSize.Name = "cmbPageSize";
			this.cmbPageSize.Size = new System.Drawing.Size(81, 30);
			this.cmbPageSize.TabIndex = 5;
			this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
			// 
			// lblPageSize
			// 
			this.lblPageSize.AutoSize = true;
			this.lblPageSize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageSize.Location = new System.Drawing.Point(646, 22);
			this.lblPageSize.Margin = new System.Windows.Forms.Padding(0);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(140, 22);
			this.lblPageSize.TabIndex = 4;
			this.lblPageSize.Text = "Số dòng/trang:   ";
			// 
			// cmbFilterFloor
			// 
			this.cmbFilterFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFilterFloor.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbFilterFloor.FormattingEnabled = true;
			this.cmbFilterFloor.Location = new System.Drawing.Point(779, 129);
			this.cmbFilterFloor.Margin = new System.Windows.Forms.Padding(0);
			this.cmbFilterFloor.Name = "cmbFilterFloor";
			this.cmbFilterFloor.Size = new System.Drawing.Size(205, 34);
			this.cmbFilterFloor.TabIndex = 5;
			this.cmbFilterFloor.SelectedIndexChanged += new System.EventHandler(this.cmbFilterFloor_SelectedIndexChanged);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpTableInfo);
			this.pnlForm.Location = new System.Drawing.Point(1133, 181);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(0);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Size = new System.Drawing.Size(489, 879);
			this.pnlForm.TabIndex = 1;
			// 
			// grpTableInfo
			// 
			this.grpTableInfo.Controls.Add(this.pnlButtons);
			this.grpTableInfo.Controls.Add(this.cmbTableStatus);
			this.grpTableInfo.Controls.Add(this.lblTableStatus);
			this.grpTableInfo.Controls.Add(this.nudCapacity);
			this.grpTableInfo.Controls.Add(this.lblCapacity);
			this.grpTableInfo.Controls.Add(this.cmbFloor);
			this.grpTableInfo.Controls.Add(this.lblFloor);
			this.grpTableInfo.Controls.Add(this.txtTableName);
			this.grpTableInfo.Controls.Add(this.lblTableName);
			this.grpTableInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpTableInfo.Location = new System.Drawing.Point(17, 7);
			this.grpTableInfo.Margin = new System.Windows.Forms.Padding(6);
			this.grpTableInfo.Name = "grpTableInfo";
			this.grpTableInfo.Padding = new System.Windows.Forms.Padding(28, 25, 28, 25);
			this.grpTableInfo.Size = new System.Drawing.Size(432, 871);
			this.grpTableInfo.TabIndex = 1;
			this.grpTableInfo.TabStop = false;
			this.grpTableInfo.Text = "Thông tin bàn";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnSave);
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Location = new System.Drawing.Point(10, 446);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(6);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(388, 158);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnCancel.Location = new System.Drawing.Point(212, 87);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(109, 49);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnSave.Location = new System.Drawing.Point(55, 87);
			this.btnSave.Margin = new System.Windows.Forms.Padding(6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(109, 49);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnDelete.Location = new System.Drawing.Point(253, 29);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(99, 46);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnEdit.Location = new System.Drawing.Point(138, 29);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(6);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(99, 46);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(16, 29);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(99, 46);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// cmbTableStatus
			// 
			this.cmbTableStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTableStatus.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbTableStatus.FormattingEnabled = true;
			this.cmbTableStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang sử dụng",
            "Đang dọn dẹp",
            "Không khả dụng"});
			this.cmbTableStatus.Location = new System.Drawing.Point(33, 381);
			this.cmbTableStatus.Margin = new System.Windows.Forms.Padding(6);
			this.cmbTableStatus.Name = "cmbTableStatus";
			this.cmbTableStatus.Size = new System.Drawing.Size(347, 39);
			this.cmbTableStatus.TabIndex = 6;
			// 
			// lblTableStatus
			// 
			this.lblTableStatus.AutoSize = true;
			this.lblTableStatus.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblTableStatus.Location = new System.Drawing.Point(33, 341);
			this.lblTableStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblTableStatus.Name = "lblTableStatus";
			this.lblTableStatus.Size = new System.Drawing.Size(115, 27);
			this.lblTableStatus.TabIndex = 5;
			this.lblTableStatus.Text = "Trạng thái:";
			// 
			// nudCapacity
			// 
			this.nudCapacity.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudCapacity.Location = new System.Drawing.Point(33, 284);
			this.nudCapacity.Margin = new System.Windows.Forms.Padding(6);
			this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudCapacity.Name = "nudCapacity";
			this.nudCapacity.Size = new System.Drawing.Size(349, 38);
			this.nudCapacity.TabIndex = 4;
			this.nudCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblCapacity
			// 
			this.lblCapacity.AutoSize = true;
			this.lblCapacity.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblCapacity.Location = new System.Drawing.Point(33, 244);
			this.lblCapacity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblCapacity.Name = "lblCapacity";
			this.lblCapacity.Size = new System.Drawing.Size(107, 27);
			this.lblCapacity.TabIndex = 3;
			this.lblCapacity.Text = "Sức chứa:";
			// 
			// cmbFloor
			// 
			this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFloor.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbFloor.FormattingEnabled = true;
			this.cmbFloor.Location = new System.Drawing.Point(33, 186);
			this.cmbFloor.Margin = new System.Windows.Forms.Padding(6);
			this.cmbFloor.Name = "cmbFloor";
			this.cmbFloor.Size = new System.Drawing.Size(347, 39);
			this.cmbFloor.TabIndex = 2;
			// 
			// lblFloor
			// 
			this.lblFloor.AutoSize = true;
			this.lblFloor.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblFloor.Location = new System.Drawing.Point(33, 147);
			this.lblFloor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblFloor.Name = "lblFloor";
			this.lblFloor.Size = new System.Drawing.Size(101, 27);
			this.lblFloor.TabIndex = 1;
			this.lblFloor.Text = "Khu vực:";
			// 
			// txtTableName
			// 
			this.txtTableName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTableName.Location = new System.Drawing.Point(33, 89);
			this.txtTableName.Margin = new System.Windows.Forms.Padding(6);
			this.txtTableName.MaxLength = 20;
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(347, 38);
			this.txtTableName.TabIndex = 0;
			// 
			// lblTableName
			// 
			this.lblTableName.AutoSize = true;
			this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblTableName.Location = new System.Drawing.Point(33, 50);
			this.lblTableName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(96, 27);
			this.lblTableName.TabIndex = 0;
			this.lblTableName.Text = "Tên bàn:";
			// 
			// lblFilterFloor
			// 
			this.lblFilterFloor.AutoSize = true;
			this.lblFilterFloor.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblFilterFloor.Location = new System.Drawing.Point(1018, 132);
			this.lblFilterFloor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblFilterFloor.Name = "lblFilterFloor";
			this.lblFilterFloor.Size = new System.Drawing.Size(101, 27);
			this.lblFilterFloor.TabIndex = 4;
			this.lblFilterFloor.Text = "Khu vực:";
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Location = new System.Drawing.Point(17, 16);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(6);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1605, 86);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlSearch
			// 
			this.pnlSearch.AutoSize = true;
			this.pnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlSearch.Controls.Add(this.btnManageRooms);
			this.pnlSearch.Controls.Add(this.btnManageFloors);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(6);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1605, 86);
			this.pnlSearch.TabIndex = 1;
			// 
			// btnManageRooms
			// 
			this.btnManageRooms.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnManageRooms.Location = new System.Drawing.Point(585, 21);
			this.btnManageRooms.Margin = new System.Windows.Forms.Padding(6);
			this.btnManageRooms.Name = "btnManageRooms";
			this.btnManageRooms.Size = new System.Drawing.Size(497, 49);
			this.btnManageRooms.TabIndex = 4;
			this.btnManageRooms.Text = "Quản lý phòng";
			this.btnManageRooms.UseVisualStyleBackColor = true;
			this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
			// 
			// btnManageFloors
			// 
			this.btnManageFloors.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnManageFloors.Location = new System.Drawing.Point(42, 21);
			this.btnManageFloors.Margin = new System.Windows.Forms.Padding(6);
			this.btnManageFloors.Name = "btnManageFloors";
			this.btnManageFloors.Size = new System.Drawing.Size(497, 49);
			this.btnManageFloors.TabIndex = 3;
			this.btnManageFloors.Text = "Quản lý khu vực";
			this.btnManageFloors.UseVisualStyleBackColor = true;
			this.btnManageFloors.Click += new System.EventHandler(this.btnManageFloors_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(28, 25);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(171, 35);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý bàn";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F);
			this.txtSearch.Location = new System.Drawing.Point(139, 130);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(6);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(484, 34);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblSearch.Location = new System.Drawing.Point(18, 136);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(109, 27);
			this.lblSearch.TabIndex = 0;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// FrmTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1625, 1034);
			this.Controls.Add(this.pnlMain);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "FrmTable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý bàn";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmTable_Load);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.pnlContent.ResumeLayout(false);

			this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.pnlForm.ResumeLayout(false);
			this.grpTableInfo.ResumeLayout(false);
			this.grpTableInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.pnlForm.ResumeLayout(false);
			this.grpTableInfo.ResumeLayout(false);
			this.grpTableInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlSearch.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TreeView treeViewTables;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpTableInfo;
        private System.Windows.Forms.ComboBox cmbTableStatus;
        private System.Windows.Forms.Label lblTableStatus;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterFloor;
        private System.Windows.Forms.Label lblFilterFloor;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnManageFloors;
        private System.Windows.Forms.Button btnManageRooms;
    }
}

