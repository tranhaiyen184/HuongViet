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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvDepartments = new System.Windows.Forms.DataGridView();
			this.pnlPaging = new System.Windows.Forms.Panel();
			this.lblPageSize = new System.Windows.Forms.Label();
			this.cmbPageSize = new System.Windows.Forms.ComboBox();
			this.lblPageInfo = new System.Windows.Forms.Label();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.btnPrevPage = new System.Windows.Forms.Button();
			this.btnFirstPage = new System.Windows.Forms.Button();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpDepartmentInfo = new System.Windows.Forms.GroupBox();
			this.txtDepartmentName = new System.Windows.Forms.TextBox();
			this.lblDepartmentName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.lblTitleDepart = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
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
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlMain.Size = new System.Drawing.Size(1333, 738);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.dgvDepartments);
			this.pnlContent.Controls.Add(this.pnlPaging);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(13, 117);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.pnlContent.Size = new System.Drawing.Size(920, 609);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvDepartments
			// 
			this.dgvDepartments.AllowUserToAddRows = false;
			this.dgvDepartments.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvDepartments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDepartments.BackgroundColor = System.Drawing.Color.White;
			this.dgvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvDepartments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDepartments.ColumnHeadersHeight = 40;
			this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvDepartments.EnableHeadersVisualStyles = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDepartments.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDepartments.Location = new System.Drawing.Point(0, 12);
			this.dgvDepartments.Margin = new System.Windows.Forms.Padding(4);
			this.dgvDepartments.MultiSelect = false;
			this.dgvDepartments.Name = "dgvDepartments";
			this.dgvDepartments.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDepartments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvDepartments.RowHeadersVisible = false;
			this.dgvDepartments.RowHeadersWidth = 51;
			this.dgvDepartments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvDepartments.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvDepartments.RowTemplate.Height = 35;
			this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDepartments.Size = new System.Drawing.Size(920, 545);
			this.dgvDepartments.TabIndex = 0;
			this.dgvDepartments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellContentClick);
			this.dgvDepartments.SelectionChanged += new System.EventHandler(this.dgvDepartments_SelectionChanged);
			// 
			// pnlPaging
			// 
			this.pnlPaging.Controls.Add(this.lblPageSize);
			this.pnlPaging.Controls.Add(this.cmbPageSize);
			this.pnlPaging.Controls.Add(this.lblPageInfo);
			this.pnlPaging.Controls.Add(this.btnLastPage);
			this.pnlPaging.Controls.Add(this.btnNextPage);
			this.pnlPaging.Controls.Add(this.btnPrevPage);
			this.pnlPaging.Controls.Add(this.btnFirstPage);
			this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlPaging.Location = new System.Drawing.Point(0, 557);
			this.pnlPaging.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPaging.Name = "pnlPaging";
			this.pnlPaging.Size = new System.Drawing.Size(920, 52);
			this.pnlPaging.TabIndex = 1;
			// 
			// lblPageSize
			// 
			this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPageSize.AutoSize = true;
			this.lblPageSize.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageSize.Location = new System.Drawing.Point(713, 16);
			this.lblPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(113, 20);
			this.lblPageSize.TabIndex = 5;
			this.lblPageSize.Text = "Số dòng/trang:";
			// 
			// cmbPageSize
			// 
			this.cmbPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPageSize.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPageSize.FormattingEnabled = true;
			this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
			this.cmbPageSize.Location = new System.Drawing.Point(828, 13);
			this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4);
			this.cmbPageSize.Name = "cmbPageSize";
			this.cmbPageSize.Size = new System.Drawing.Size(70, 28);
			this.cmbPageSize.TabIndex = 6;
			this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
			// 
			// lblPageInfo
			// 
			this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPageInfo.AutoSize = true;
			this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageInfo.Location = new System.Drawing.Point(540, 16);
			this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageInfo.Name = "lblPageInfo";
			this.lblPageInfo.Size = new System.Drawing.Size(162, 20);
			this.lblPageInfo.TabIndex = 4;
			this.lblPageInfo.Text = "Trang 1 / 1 (Tổng: 0)";
			this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnLastPage
			// 
			this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnLastPage.Location = new System.Drawing.Point(165, 8);
			this.btnLastPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new System.Drawing.Size(45, 36);
			this.btnLastPage.TabIndex = 3;
			this.btnLastPage.Text = ">>";
			this.btnLastPage.UseVisualStyleBackColor = true;
			this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnNextPage.Location = new System.Drawing.Point(115, 8);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(45, 36);
			this.btnNextPage.TabIndex = 2;
			this.btnNextPage.Text = ">";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// btnPrevPage
			// 
			this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnPrevPage.Location = new System.Drawing.Point(65, 8);
			this.btnPrevPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnPrevPage.Name = "btnPrevPage";
			this.btnPrevPage.Size = new System.Drawing.Size(45, 36);
			this.btnPrevPage.TabIndex = 1;
			this.btnPrevPage.Text = "<";
			this.btnPrevPage.UseVisualStyleBackColor = true;
			this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
			// 
			// btnFirstPage
			// 
			this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnFirstPage.Location = new System.Drawing.Point(15, 8);
			this.btnFirstPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnFirstPage.Name = "btnFirstPage";
			this.btnFirstPage.Size = new System.Drawing.Size(45, 36);
			this.btnFirstPage.TabIndex = 0;
			this.btnFirstPage.Text = "<<";
			this.btnFirstPage.UseVisualStyleBackColor = true;
			this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpDepartmentInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlForm.Location = new System.Drawing.Point(933, 117);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Padding = new System.Windows.Forms.Padding(13, 12, 0, 0);
			this.pnlForm.Size = new System.Drawing.Size(387, 609);
			this.pnlForm.TabIndex = 1;
			// 
			// grpDepartmentInfo
			// 
			this.grpDepartmentInfo.Controls.Add(this.txtDepartmentName);
			this.grpDepartmentInfo.Controls.Add(this.lblDepartmentName);
			this.grpDepartmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpDepartmentInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpDepartmentInfo.Location = new System.Drawing.Point(13, 12);
			this.grpDepartmentInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpDepartmentInfo.Name = "grpDepartmentInfo";
			this.grpDepartmentInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpDepartmentInfo.Size = new System.Drawing.Size(374, 474);
			this.grpDepartmentInfo.TabIndex = 1;
			this.grpDepartmentInfo.TabStop = false;
			this.grpDepartmentInfo.Text = "Thông tin phòng ban";
			// 
			// txtDepartmentName
			// 
			this.txtDepartmentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDepartmentName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDepartmentName.Location = new System.Drawing.Point(24, 75);
			this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(4);
			this.txtDepartmentName.MaxLength = 30;
			this.txtDepartmentName.Name = "txtDepartmentName";
			this.txtDepartmentName.ReadOnly = true;
			this.txtDepartmentName.Size = new System.Drawing.Size(326, 34);
			this.txtDepartmentName.TabIndex = 1;
			this.txtDepartmentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepartmentName_KeyPress);
			// 
			// lblDepartmentName
			// 
			this.lblDepartmentName.AutoSize = true;
			this.lblDepartmentName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblDepartmentName.Location = new System.Drawing.Point(24, 43);
			this.lblDepartmentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDepartmentName.Name = "lblDepartmentName";
			this.lblDepartmentName.Size = new System.Drawing.Size(131, 22);
			this.lblDepartmentName.TabIndex = 0;
			this.lblDepartmentName.Text = "Tên phòng ban:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnSave);
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtons.Location = new System.Drawing.Point(13, 486);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlButtons.Size = new System.Drawing.Size(374, 123);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Enabled = false;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnCancel.Location = new System.Drawing.Point(193, 61);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(135, 40);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnSave.Location = new System.Drawing.Point(50, 61);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(135, 40);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnDelete.Location = new System.Drawing.Point(248, 13);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 40);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Enabled = false;
			this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnEdit.Location = new System.Drawing.Point(146, 13);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(85, 40);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnAdd.Location = new System.Drawing.Point(44, 13);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(85, 40);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lblStatus);
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1307, 105);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.lblStatus.ForeColor = System.Drawing.Color.Gray;
			this.lblStatus.Location = new System.Drawing.Point(4, 77);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(153, 19);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "Tổng số phòng ban: 0";
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.lblTitleDepart);
			this.pnlSearch.Controls.Add(this.btnRefresh);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.txtSearch);
			this.pnlSearch.Controls.Add(this.lblSearch);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1307, 105);
			this.pnlSearch.TabIndex = 1;
			this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
			// 
			// lblTitleDepart
			// 
			this.lblTitleDepart.AutoSize = true;
			this.lblTitleDepart.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitleDepart.Location = new System.Drawing.Point(536, -4);
			this.lblTitleDepart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitleDepart.Name = "lblTitleDepart";
			this.lblTitleDepart.Size = new System.Drawing.Size(320, 32);
			this.lblTitleDepart.TabIndex = 4;
			this.lblTitleDepart.Text = "QUẢN LÝ PHÒNG BAN";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnRefresh.Location = new System.Drawing.Point(1151, 32);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(147, 47);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnSearch.Location = new System.Drawing.Point(983, 31);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(147, 47);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.txtSearch.Location = new System.Drawing.Point(3, 39);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(917, 30);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblSearch.Location = new System.Drawing.Point(4, 10);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(91, 22);
			this.lblSearch.TabIndex = 0;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(559, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(0, 32);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
			// 
			// FrmDepartment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1333, 738);
			this.Controls.Add(this.pnlMain);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmDepartment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý phòng ban";
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
			this.pnlHeader.PerformLayout();
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpDepartmentInfo;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
		private System.Windows.Forms.Label lblTitleDepart;
	}
}
