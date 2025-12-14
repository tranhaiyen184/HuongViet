using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    partial class FrmRole
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvRoles = new System.Windows.Forms.DataGridView();
			this.pnlPaging = new System.Windows.Forms.Panel();
			this.btnFirstPage = new System.Windows.Forms.Button();
			this.btnPrevPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.lblPageInfo = new System.Windows.Forms.Label();
			this.cmbPageSize = new System.Windows.Forms.ComboBox();
			this.lblPageSize = new System.Windows.Forms.Label();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpRoleInfo = new System.Windows.Forms.GroupBox();
			this.btnCancel = new FontAwesome.Sharp.IconButton();
			this.btnSave = new FontAwesome.Sharp.IconButton();
			this.lblPermissionCount = new System.Windows.Forms.Label();
			this.btnSelectPermissions = new System.Windows.Forms.Button();
			this.txtRoleCode = new System.Windows.Forms.TextBox();
			this.lblRoleCode = new System.Windows.Forms.Label();
			this.txtRoleName = new System.Windows.Forms.TextBox();
			this.lblRoleName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnDelete = new FontAwesome.Sharp.IconButton();
			this.btnEdit = new FontAwesome.Sharp.IconButton();
			this.btnAdd = new FontAwesome.Sharp.IconButton();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.lblSearch = new System.Windows.Forms.Label();
			this.btnRefresh = new FontAwesome.Sharp.IconButton();
			this.btnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
			this.pnlPaging.SuspendLayout();
			this.pnlForm.SuspendLayout();
			this.grpRoleInfo.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlContent);
			this.pnlMain.Controls.Add(this.pnlForm);
			this.pnlMain.Controls.Add(this.pnlHeader);
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1920, 1081);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.dgvRoles);
			this.pnlContent.Controls.Add(this.pnlPaging);
			this.pnlContent.Location = new System.Drawing.Point(13, 130);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(1314, 938);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvRoles
			// 
			this.dgvRoles.AllowUserToAddRows = false;
			this.dgvRoles.AllowUserToDeleteRows = false;
			this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvRoles.BackgroundColor = System.Drawing.Color.White;
			this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRoles.Location = new System.Drawing.Point(0, 0);
			this.dgvRoles.Margin = new System.Windows.Forms.Padding(4);
			this.dgvRoles.MultiSelect = false;
			this.dgvRoles.Name = "dgvRoles";
			this.dgvRoles.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvRoles.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvRoles.RowHeadersVisible = false;
			this.dgvRoles.RowHeadersWidth = 51;
			this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvRoles.Size = new System.Drawing.Size(1307, 761);
			this.dgvRoles.TabIndex = 0;
			this.dgvRoles.SelectionChanged += new System.EventHandler(this.dgvRoles_SelectionChanged);
			// 
			// pnlPaging
			// 
			this.pnlPaging.Controls.Add(this.btnFirstPage);
			this.pnlPaging.Controls.Add(this.btnPrevPage);
			this.pnlPaging.Controls.Add(this.btnNextPage);
			this.pnlPaging.Controls.Add(this.btnLastPage);
			this.pnlPaging.Controls.Add(this.lblPageInfo);
			this.pnlPaging.Controls.Add(this.cmbPageSize);
			this.pnlPaging.Controls.Add(this.lblPageSize);
			this.pnlPaging.Location = new System.Drawing.Point(4, 769);
			this.pnlPaging.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPaging.Name = "pnlPaging";
			this.pnlPaging.Size = new System.Drawing.Size(1314, 52);
			this.pnlPaging.TabIndex = 1;
			// 
			// btnFirstPage
			// 
			this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnFirstPage.Location = new System.Drawing.Point(15, 7);
			this.btnFirstPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnFirstPage.Name = "btnFirstPage";
			this.btnFirstPage.Size = new System.Drawing.Size(45, 36);
			this.btnFirstPage.TabIndex = 0;
			this.btnFirstPage.Text = "<<";
			this.btnFirstPage.UseVisualStyleBackColor = true;
			this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
			// 
			// btnPrevPage
			// 
			this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnPrevPage.Location = new System.Drawing.Point(65, 7);
			this.btnPrevPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnPrevPage.Name = "btnPrevPage";
			this.btnPrevPage.Size = new System.Drawing.Size(45, 36);
			this.btnPrevPage.TabIndex = 1;
			this.btnPrevPage.Text = "<";
			this.btnPrevPage.UseVisualStyleBackColor = true;
			this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnNextPage.Location = new System.Drawing.Point(115, 7);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(45, 36);
			this.btnNextPage.TabIndex = 2;
			this.btnNextPage.Text = ">";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// btnLastPage
			// 
			this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnLastPage.Location = new System.Drawing.Point(165, 7);
			this.btnLastPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new System.Drawing.Size(45, 36);
			this.btnLastPage.TabIndex = 3;
			this.btnLastPage.Text = ">>";
			this.btnLastPage.UseVisualStyleBackColor = true;
			this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
			// 
			// lblPageInfo
			// 
			this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPageInfo.AutoSize = true;
			this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageInfo.Location = new System.Drawing.Point(558, 16);
			this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageInfo.Name = "lblPageInfo";
			this.lblPageInfo.Size = new System.Drawing.Size(181, 22);
			this.lblPageInfo.TabIndex = 6;
			this.lblPageInfo.Text = "Trang 1 / 1  (Tổng: 0)";
			this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbPageSize
			// 
			this.cmbPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPageSize.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.cmbPageSize.FormattingEnabled = true;
			this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
			this.cmbPageSize.Location = new System.Drawing.Point(1250, 8);
			this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4);
			this.cmbPageSize.Name = "cmbPageSize";
			this.cmbPageSize.Size = new System.Drawing.Size(60, 30);
			this.cmbPageSize.TabIndex = 5;
			this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
			// 
			// lblPageSize
			// 
			this.lblPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPageSize.AutoSize = true;
			this.lblPageSize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageSize.Location = new System.Drawing.Point(1086, 11);
			this.lblPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(140, 22);
			this.lblPageSize.TabIndex = 4;
			this.lblPageSize.Text = "Số dòng/trang:   ";
			this.lblPageSize.Click += new System.EventHandler(this.lblPageSize_Click);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpRoleInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Location = new System.Drawing.Point(1335, 130);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Size = new System.Drawing.Size(572, 938);
			this.pnlForm.TabIndex = 1;
			// 
			// grpRoleInfo
			// 
			this.grpRoleInfo.Controls.Add(this.btnCancel);
			this.grpRoleInfo.Controls.Add(this.btnSave);
			this.grpRoleInfo.Controls.Add(this.lblPermissionCount);
			this.grpRoleInfo.Controls.Add(this.btnSelectPermissions);
			this.grpRoleInfo.Controls.Add(this.txtRoleCode);
			this.grpRoleInfo.Controls.Add(this.lblRoleCode);
			this.grpRoleInfo.Controls.Add(this.txtRoleName);
			this.grpRoleInfo.Controls.Add(this.lblRoleName);
			this.grpRoleInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpRoleInfo.Location = new System.Drawing.Point(13, 12);
			this.grpRoleInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpRoleInfo.Name = "grpRoleInfo";
			this.grpRoleInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpRoleInfo.Size = new System.Drawing.Size(541, 433);
			this.grpRoleInfo.TabIndex = 1;
			this.grpRoleInfo.TabStop = false;
			this.grpRoleInfo.Text = "Thông tin vai trò";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnCancel.IconColor = System.Drawing.Color.Black;
			this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCancel.IconSize = 26;
			this.btnCancel.Location = new System.Drawing.Point(168, 368);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(168, 52);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnSave.IconColor = System.Drawing.Color.Black;
			this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSave.IconSize = 26;
			this.btnSave.Location = new System.Drawing.Point(363, 368);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(168, 52);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblPermissionCount
			// 
			this.lblPermissionCount.AutoSize = true;
			this.lblPermissionCount.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblPermissionCount.ForeColor = System.Drawing.Color.Gray;
			this.lblPermissionCount.Location = new System.Drawing.Point(25, 248);
			this.lblPermissionCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPermissionCount.Name = "lblPermissionCount";
			this.lblPermissionCount.Size = new System.Drawing.Size(178, 22);
			this.lblPermissionCount.TabIndex = 5;
			this.lblPermissionCount.Text = "Chưa chọn quyền nào";
			// 
			// btnSelectPermissions
			// 
			this.btnSelectPermissions.BackColor = System.Drawing.Color.IndianRed;
			this.btnSelectPermissions.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnSelectPermissions.Location = new System.Drawing.Point(168, 286);
			this.btnSelectPermissions.Margin = new System.Windows.Forms.Padding(4);
			this.btnSelectPermissions.Name = "btnSelectPermissions";
			this.btnSelectPermissions.Size = new System.Drawing.Size(217, 61);
			this.btnSelectPermissions.TabIndex = 4;
			this.btnSelectPermissions.Text = "Chọn quyền";
			this.btnSelectPermissions.UseVisualStyleBackColor = false;
			this.btnSelectPermissions.Click += new System.EventHandler(this.btnSelectPermissions_Click);
			// 
			// txtRoleCode
			// 
			this.txtRoleCode.BackColor = System.Drawing.SystemColors.Control;
			this.txtRoleCode.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRoleCode.Location = new System.Drawing.Point(24, 188);
			this.txtRoleCode.Margin = new System.Windows.Forms.Padding(4);
			this.txtRoleCode.MaxLength = 50;
			this.txtRoleCode.Name = "txtRoleCode";
			this.txtRoleCode.ReadOnly = true;
			this.txtRoleCode.Size = new System.Drawing.Size(493, 38);
			this.txtRoleCode.TabIndex = 3;
			// 
			// lblRoleCode
			// 
			this.lblRoleCode.AutoSize = true;
			this.lblRoleCode.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblRoleCode.Location = new System.Drawing.Point(27, 144);
			this.lblRoleCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblRoleCode.Name = "lblRoleCode";
			this.lblRoleCode.Size = new System.Drawing.Size(118, 27);
			this.lblRoleCode.TabIndex = 2;
			this.lblRoleCode.Text = "Mã vai trò:";
			// 
			// txtRoleName
			// 
			this.txtRoleName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRoleName.Location = new System.Drawing.Point(24, 87);
			this.txtRoleName.Margin = new System.Windows.Forms.Padding(4);
			this.txtRoleName.MaxLength = 50;
			this.txtRoleName.Name = "txtRoleName";
			this.txtRoleName.Size = new System.Drawing.Size(493, 38);
			this.txtRoleName.TabIndex = 1;
			this.txtRoleName.TextChanged += new System.EventHandler(this.txtRoleName_TextChanged);
			// 
			// lblRoleName
			// 
			this.lblRoleName.AutoSize = true;
			this.lblRoleName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblRoleName.Location = new System.Drawing.Point(24, 45);
			this.lblRoleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblRoleName.Name = "lblRoleName";
			this.lblRoleName.Size = new System.Drawing.Size(123, 27);
			this.lblRoleName.TabIndex = 0;
			this.lblRoleName.Text = "Tên vai trò:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Location = new System.Drawing.Point(13, 453);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(541, 111);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
			this.btnDelete.IconColor = System.Drawing.Color.Black;
			this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnDelete.IconSize = 26;
			this.btnDelete.Location = new System.Drawing.Point(375, 14);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(156, 51);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnEdit.IconColor = System.Drawing.Color.Black;
			this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnEdit.IconSize = 26;
			this.btnEdit.Location = new System.Drawing.Point(196, 14);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(156, 51);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
			this.btnAdd.IconColor = System.Drawing.Color.Black;
			this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAdd.IconSize = 26;
			this.btnAdd.Location = new System.Drawing.Point(17, 14);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(156, 51);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1893, 106);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.lblSearch);
			this.pnlSearch.Controls.Add(this.btnRefresh);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.txtSearch);
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1893, 106);
			this.pnlSearch.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblSearch.Location = new System.Drawing.Point(20, 34);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(109, 27);
			this.lblSearch.TabIndex = 4;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
			this.btnRefresh.IconColor = System.Drawing.Color.Black;
			this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRefresh.IconSize = 24;
			this.btnRefresh.Location = new System.Drawing.Point(1617, 28);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(192, 47);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
			this.btnSearch.IconColor = System.Drawing.Color.Black;
			this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSearch.IconSize = 24;
			this.btnSearch.Location = new System.Drawing.Point(1397, 28);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(192, 47);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 16F);
			this.txtSearch.Location = new System.Drawing.Point(184, 34);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(1123, 43);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// FrmRole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1920, 1055);
			this.Controls.Add(this.pnlMain);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmRole";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý vai trò";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
			this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.pnlForm.ResumeLayout(false);
			this.grpRoleInfo.ResumeLayout(false);
			this.grpRoleInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpRoleInfo;
        private System.Windows.Forms.Label lblPermissionCount;
        private System.Windows.Forms.Button btnSelectPermissions;
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.Label lblRoleCode;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Panel pnlButtons;
		private FontAwesome.Sharp.IconButton btnCancel;
		private FontAwesome.Sharp.IconButton btnSave;
		private FontAwesome.Sharp.IconButton btnDelete;
		private FontAwesome.Sharp.IconButton btnEdit;
		private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
		private FontAwesome.Sharp.IconButton btnRefresh;
		private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}

