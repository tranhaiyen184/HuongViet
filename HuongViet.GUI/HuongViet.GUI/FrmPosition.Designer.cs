namespace HuongViet.GUI
{
    partial class FrmPosition
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
			this.dgvPositions = new System.Windows.Forms.DataGridView();
			this.pnlPaging = new System.Windows.Forms.Panel();
			this.btnFirstPage = new System.Windows.Forms.Button();
			this.btnPrevPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.lblPageInfo = new System.Windows.Forms.Label();
			this.cmbPageSize = new System.Windows.Forms.ComboBox();
			this.lblPageSize = new System.Windows.Forms.Label();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpPositionInfo = new System.Windows.Forms.GroupBox();
			this.cmbDepartment = new System.Windows.Forms.ComboBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.txtPositionName = new System.Windows.Forms.TextBox();
			this.lblPositionName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.lblSearch = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
			this.pnlPaging.SuspendLayout();
			this.pnlForm.SuspendLayout();
			this.grpPositionInfo.SuspendLayout();
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
			this.pnlContent.Controls.Add(this.dgvPositions);
			this.pnlContent.Controls.Add(this.pnlPaging);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(13, 118);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.pnlContent.Size = new System.Drawing.Size(920, 608);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvPositions
			// 
			this.dgvPositions.AllowUserToAddRows = false;
			this.dgvPositions.AllowUserToDeleteRows = false;
			this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvPositions.BackgroundColor = System.Drawing.Color.White;
			this.dgvPositions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvPositions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPositions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPositions.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPositions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPositions.Location = new System.Drawing.Point(0, 12);
			this.dgvPositions.Margin = new System.Windows.Forms.Padding(4);
			this.dgvPositions.MultiSelect = false;
			this.dgvPositions.Name = "dgvPositions";
			this.dgvPositions.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPositions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPositions.RowHeadersVisible = false;
			this.dgvPositions.RowHeadersWidth = 51;
			this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPositions.Size = new System.Drawing.Size(920, 544);
			this.dgvPositions.TabIndex = 0;
			this.dgvPositions.SelectionChanged += new System.EventHandler(this.dgvPositions_SelectionChanged);
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
			this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlPaging.Location = new System.Drawing.Point(0, 556);
			this.pnlPaging.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPaging.Name = "pnlPaging";
			this.pnlPaging.Size = new System.Drawing.Size(920, 52);
			this.pnlPaging.TabIndex = 1;
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
			// lblPageInfo
			// 
			this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPageInfo.AutoSize = true;
			this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPageInfo.Location = new System.Drawing.Point(537, 16);
			this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageInfo.Name = "lblPageInfo";
			this.lblPageInfo.Size = new System.Drawing.Size(162, 20);
			this.lblPageInfo.TabIndex = 6;
			this.lblPageInfo.Text = "Trang 1 / 1 (Tổng: 0)";
			this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbPageSize
			// 
			this.cmbPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPageSize.Font = new System.Drawing.Font("Times New Roman", 10.8F);
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
			this.cmbPageSize.TabIndex = 5;
			this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
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
			this.lblPageSize.TabIndex = 4;
			this.lblPageSize.Text = "Số dòng/trang:";
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpPositionInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlForm.Location = new System.Drawing.Point(933, 118);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Padding = new System.Windows.Forms.Padding(13, 12, 0, 0);
			this.pnlForm.Size = new System.Drawing.Size(387, 608);
			this.pnlForm.TabIndex = 1;
			// 
			// grpPositionInfo
			// 
			this.grpPositionInfo.Controls.Add(this.cmbDepartment);
			this.grpPositionInfo.Controls.Add(this.lblDepartment);
			this.grpPositionInfo.Controls.Add(this.txtPositionName);
			this.grpPositionInfo.Controls.Add(this.lblPositionName);
			this.grpPositionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpPositionInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpPositionInfo.Location = new System.Drawing.Point(13, 12);
			this.grpPositionInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpPositionInfo.Name = "grpPositionInfo";
			this.grpPositionInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpPositionInfo.Size = new System.Drawing.Size(374, 473);
			this.grpPositionInfo.TabIndex = 1;
			this.grpPositionInfo.TabStop = false;
			this.grpPositionInfo.Text = "Thông tin vị trí";
			// 
			// cmbDepartment
			// 
			this.cmbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDepartment.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbDepartment.FormattingEnabled = true;
			this.cmbDepartment.Location = new System.Drawing.Point(24, 155);
			this.cmbDepartment.Margin = new System.Windows.Forms.Padding(4);
			this.cmbDepartment.Name = "cmbDepartment";
			this.cmbDepartment.Size = new System.Drawing.Size(326, 34);
			this.cmbDepartment.TabIndex = 3;
			this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblDepartment.Location = new System.Drawing.Point(24, 123);
			this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(97, 22);
			this.lblDepartment.TabIndex = 2;
			this.lblDepartment.Text = "Phòng ban:";
			// 
			// txtPositionName
			// 
			this.txtPositionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPositionName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPositionName.Location = new System.Drawing.Point(24, 73);
			this.txtPositionName.Margin = new System.Windows.Forms.Padding(4);
			this.txtPositionName.MaxLength = 50;
			this.txtPositionName.Name = "txtPositionName";
			this.txtPositionName.Size = new System.Drawing.Size(326, 34);
			this.txtPositionName.TabIndex = 1;
			this.txtPositionName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPositionName_KeyPress);
			// 
			// lblPositionName
			// 
			this.lblPositionName.AutoSize = true;
			this.lblPositionName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblPositionName.Location = new System.Drawing.Point(24, 43);
			this.lblPositionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPositionName.Name = "lblPositionName";
			this.lblPositionName.Size = new System.Drawing.Size(90, 22);
			this.lblPositionName.TabIndex = 0;
			this.lblPositionName.Text = "Tên vị trí:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnSave);
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtons.Location = new System.Drawing.Point(13, 485);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlButtons.Size = new System.Drawing.Size(374, 123);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnCancel.Location = new System.Drawing.Point(193, 60);
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
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnSave.Location = new System.Drawing.Point(47, 60);
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
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnDelete.Location = new System.Drawing.Point(246, 13);
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
			this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnEdit.Location = new System.Drawing.Point(145, 13);
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
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1307, 106);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(557, 2);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(233, 32);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "QUẢN LÝ VỊ TRÍ";
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.lblSearch);
			this.pnlSearch.Controls.Add(this.btnRefresh);
			this.pnlSearch.Controls.Add(this.lblStatus);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.txtSearch);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1307, 106);
			this.pnlSearch.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblSearch.Location = new System.Drawing.Point(4, 10);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(91, 22);
			this.lblSearch.TabIndex = 4;
			this.lblSearch.Text = "Tìm kiếm:";
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
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.lblStatus.ForeColor = System.Drawing.Color.Gray;
			this.lblStatus.Location = new System.Drawing.Point(4, 77);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(117, 19);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "Tổng số vị trí: 0";
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
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.txtSearch.Location = new System.Drawing.Point(3, 39);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(916, 32);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// FrmPosition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1333, 738);
			this.Controls.Add(this.pnlMain);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmPosition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý vị trí";
			this.Load += new System.EventHandler(this.FrmPosition_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPosition_KeyDown);
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
			this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.pnlForm.ResumeLayout(false);
			this.grpPositionInfo.ResumeLayout(false);
			this.grpPositionInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.GroupBox grpPositionInfo;
		private System.Windows.Forms.ComboBox cmbDepartment;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.TextBox txtPositionName;
		private System.Windows.Forms.Label lblPositionName;
	}
}
