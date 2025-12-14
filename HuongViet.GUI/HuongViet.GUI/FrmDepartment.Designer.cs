using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    partial class FrmDepartment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvDepartments = new System.Windows.Forms.DataGridView();
			this.pnlPaging = new System.Windows.Forms.Panel();
			this.btnFirstPage = new System.Windows.Forms.Button();
			this.btnPrevPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.lblPageInfo = new System.Windows.Forms.Label();
			this.cmbPageSize = new System.Windows.Forms.ComboBox();
			this.lblPageSize = new System.Windows.Forms.Label();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpDepartmentInfo = new System.Windows.Forms.GroupBox();
			this.btnCancel = new FontAwesome.Sharp.IconButton();
			this.btnSave = new FontAwesome.Sharp.IconButton();
			this.txtDepartmentName = new System.Windows.Forms.TextBox();
			this.lblDepartmentName = new System.Windows.Forms.Label();
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
			((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
			this.pnlPaging.SuspendLayout();
			this.pnlForm.SuspendLayout();
			this.grpDepartmentInfo.SuspendLayout();
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
			this.pnlContent.Controls.Add(this.dgvDepartments);
			this.pnlContent.Controls.Add(this.pnlPaging);
			this.pnlContent.Location = new System.Drawing.Point(13, 105);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(1328, 963);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvDepartments
			// 
			this.dgvDepartments.AllowUserToAddRows = false;
			this.dgvDepartments.AllowUserToDeleteRows = false;
			this.dgvDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDepartments.BackgroundColor = System.Drawing.Color.White;
			this.dgvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvDepartments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDepartments.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDepartments.Location = new System.Drawing.Point(4, 4);
			this.dgvDepartments.Margin = new System.Windows.Forms.Padding(4);
			this.dgvDepartments.MultiSelect = false;
			this.dgvDepartments.Name = "dgvDepartments";
			this.dgvDepartments.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDepartments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDepartments.RowHeadersVisible = false;
			this.dgvDepartments.RowHeadersWidth = 51;
			this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDepartments.Size = new System.Drawing.Size(1321, 741);
			this.dgvDepartments.TabIndex = 0;
			this.dgvDepartments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellContentClick);
			this.dgvDepartments.SelectionChanged += new System.EventHandler(this.dgvDepartments_SelectionChanged);
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
			this.pnlPaging.Location = new System.Drawing.Point(4, 763);
			this.pnlPaging.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPaging.Name = "pnlPaging";
			this.pnlPaging.Size = new System.Drawing.Size(1324, 61);
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
			this.lblPageInfo.AutoSize = true;
			this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageInfo.Location = new System.Drawing.Point(553, 17);
			this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
			this.cmbPageSize.Location = new System.Drawing.Point(1258, 14);
			this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4);
			this.cmbPageSize.Name = "cmbPageSize";
			this.cmbPageSize.Size = new System.Drawing.Size(60, 30);
			this.cmbPageSize.TabIndex = 5;
			this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
			// 
			// lblPageSize
			// 
			this.lblPageSize.AutoSize = true;
			this.lblPageSize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageSize.Location = new System.Drawing.Point(1091, 17);
			this.lblPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(140, 22);
			this.lblPageSize.TabIndex = 4;
			this.lblPageSize.Text = "Số dòng/trang:   ";
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpDepartmentInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Location = new System.Drawing.Point(1348, 105);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Size = new System.Drawing.Size(558, 938);
			this.pnlForm.TabIndex = 1;
			// 
			// grpDepartmentInfo
			// 
			this.grpDepartmentInfo.Controls.Add(this.btnCancel);
			this.grpDepartmentInfo.Controls.Add(this.btnSave);
			this.grpDepartmentInfo.Controls.Add(this.txtDepartmentName);
			this.grpDepartmentInfo.Controls.Add(this.lblDepartmentName);
			this.grpDepartmentInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpDepartmentInfo.Location = new System.Drawing.Point(13, 4);
			this.grpDepartmentInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpDepartmentInfo.Name = "grpDepartmentInfo";
			this.grpDepartmentInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpDepartmentInfo.Size = new System.Drawing.Size(527, 263);
			this.grpDepartmentInfo.TabIndex = 1;
			this.grpDepartmentInfo.TabStop = false;
			this.grpDepartmentInfo.Text = "Thông tin phòng ban";
			// 
			// btnCancel
			// 
			this.btnCancel.Enabled = false;
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnCancel.IconColor = System.Drawing.Color.Black;
			this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCancel.IconSize = 22;
			this.btnCancel.Location = new System.Drawing.Point(146, 176);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(167, 49);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnSave.IconColor = System.Drawing.Color.Black;
			this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSave.IconSize = 22;
			this.btnSave.Location = new System.Drawing.Point(337, 176);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(167, 49);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtDepartmentName
			// 
			this.txtDepartmentName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDepartmentName.Location = new System.Drawing.Point(24, 110);
			this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(4);
			this.txtDepartmentName.MaxLength = 30;
			this.txtDepartmentName.Name = "txtDepartmentName";
			this.txtDepartmentName.Size = new System.Drawing.Size(479, 38);
			this.txtDepartmentName.TabIndex = 1;
			this.txtDepartmentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepartmentName_KeyPress);
			// 
			// lblDepartmentName
			// 
			this.lblDepartmentName.AutoSize = true;
			this.lblDepartmentName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblDepartmentName.Location = new System.Drawing.Point(24, 57);
			this.lblDepartmentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDepartmentName.Name = "lblDepartmentName";
			this.lblDepartmentName.Size = new System.Drawing.Size(161, 27);
			this.lblDepartmentName.TabIndex = 0;
			this.lblDepartmentName.Text = "Tên phòng ban:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Location = new System.Drawing.Point(13, 300);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(527, 95);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
			this.btnDelete.IconColor = System.Drawing.Color.Black;
			this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnDelete.IconSize = 22;
			this.btnDelete.Location = new System.Drawing.Point(356, 14);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(167, 46);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Enabled = false;
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnEdit.IconColor = System.Drawing.Color.Black;
			this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnEdit.IconSize = 22;
			this.btnEdit.Location = new System.Drawing.Point(180, 14);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(167, 46);
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
			this.btnAdd.IconSize = 22;
			this.btnAdd.Location = new System.Drawing.Point(4, 14);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(167, 46);
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
			this.pnlHeader.Size = new System.Drawing.Size(1893, 85);
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
			this.pnlSearch.Size = new System.Drawing.Size(1893, 82);
			this.pnlSearch.TabIndex = 1;
			this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblSearch.Location = new System.Drawing.Point(20, 31);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(109, 27);
			this.lblSearch.TabIndex = 4;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Sync;
			this.btnRefresh.IconColor = System.Drawing.Color.Black;
			this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRefresh.IconSize = 24;
			this.btnRefresh.Location = new System.Drawing.Point(1625, 18);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(196, 53);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
			this.btnSearch.IconColor = System.Drawing.Color.Black;
			this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSearch.IconSize = 24;
			this.btnSearch.Location = new System.Drawing.Point(1406, 15);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(196, 53);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 16F);
			this.txtSearch.Location = new System.Drawing.Point(165, 25);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(1163, 43);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// FrmDepartment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1920, 1055);
			this.Controls.Add(this.pnlMain);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmDepartment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý phòng ban";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmDepartment_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDepartment_KeyDown);
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
			this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.pnlForm.ResumeLayout(false);
			this.grpDepartmentInfo.ResumeLayout(false);
			this.grpDepartmentInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlSearch;
		private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpDepartmentInfo;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Panel pnlButtons;
		private FontAwesome.Sharp.IconButton btnCancel;
		private FontAwesome.Sharp.IconButton btnSave;
		private FontAwesome.Sharp.IconButton btnDelete;
		private FontAwesome.Sharp.IconButton btnEdit;
		private FontAwesome.Sharp.IconButton btnAdd;
		private FontAwesome.Sharp.IconButton btnRefresh;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
		private System.Windows.Forms.Label lblPageSize;
	}
}
