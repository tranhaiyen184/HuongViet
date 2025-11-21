namespace HuongViet.GUI
{
    partial class FrmUser
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.cmbUserStatus = new System.Windows.Forms.ComboBox();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cmbFilterPosition = new System.Windows.Forms.ComboBox();
            this.lblFilterPosition = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlPaging.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.grpUserInfo.SuspendLayout();
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
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1000, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvUsers);
            this.pnlContent.Controls.Add(this.pnlPaging);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 140);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(680, 450);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 10);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(680, 380);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
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
            this.pnlPaging.Location = new System.Drawing.Point(0, 390);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(680, 60);
            this.pnlPaging.TabIndex = 1;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFirstPage.Location = new System.Drawing.Point(15, 12);
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
            this.btnPrevPage.Location = new System.Drawing.Point(65, 12);
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
            this.btnNextPage.Location = new System.Drawing.Point(115, 12);
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
            this.btnLastPage.Location = new System.Drawing.Point(165, 12);
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
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageInfo.Location = new System.Drawing.Point(380, 20);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(220, 20);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1 / 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.cmbPageSize.Location = new System.Drawing.Point(605, 18);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(70, 23);
            this.cmbPageSize.TabIndex = 5;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSize.Location = new System.Drawing.Point(500, 21);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(87, 15);
            this.lblPageSize.TabIndex = 4;
            this.lblPageSize.Text = "Số dòng/trang:";
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.grpUserInfo);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlForm.Location = new System.Drawing.Point(690, 140);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.pnlForm.Size = new System.Drawing.Size(300, 450);
            this.pnlForm.TabIndex = 1;
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.cmbUserStatus);
            this.grpUserInfo.Controls.Add(this.lblUserStatus);
            this.grpUserInfo.Controls.Add(this.cmbRole);
            this.grpUserInfo.Controls.Add(this.lblRole);
            this.grpUserInfo.Controls.Add(this.cmbPosition);
            this.grpUserInfo.Controls.Add(this.lblPosition);
            this.grpUserInfo.Controls.Add(this.txtPassword);
            this.grpUserInfo.Controls.Add(this.lblPassword);
            this.grpUserInfo.Controls.Add(this.txtUserName);
            this.grpUserInfo.Controls.Add(this.lblUserName);
            this.grpUserInfo.Controls.Add(this.txtPhoneNumber);
            this.grpUserInfo.Controls.Add(this.lblPhoneNumber);
            this.grpUserInfo.Controls.Add(this.txtFirstName);
            this.grpUserInfo.Controls.Add(this.lblFirstName);
            this.grpUserInfo.Controls.Add(this.txtLastName);
            this.grpUserInfo.Controls.Add(this.lblLastName);
            this.grpUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpUserInfo.Location = new System.Drawing.Point(10, 10);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Padding = new System.Windows.Forms.Padding(15);
            this.grpUserInfo.Size = new System.Drawing.Size(290, 340);
            this.grpUserInfo.TabIndex = 1;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Thông tin nhân viên";
            // 
            // cmbUserStatus
            // 
            this.cmbUserStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUserStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUserStatus.FormattingEnabled = true;
            this.cmbUserStatus.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.cmbUserStatus.Location = new System.Drawing.Point(18, 315);
            this.cmbUserStatus.Name = "cmbUserStatus";
            this.cmbUserStatus.Size = new System.Drawing.Size(254, 23);
            this.cmbUserStatus.TabIndex = 16;
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.AutoSize = true;
            this.lblUserStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserStatus.Location = new System.Drawing.Point(18, 295);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(66, 15);
            this.lblUserStatus.TabIndex = 15;
            this.lblUserStatus.Text = "Trạng thái:";
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(18, 270);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(254, 23);
            this.cmbRole.TabIndex = 14;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRole.Location = new System.Drawing.Point(18, 250);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(54, 15);
            this.lblRole.TabIndex = 13;
            this.lblRole.Text = "Vai trò:";
            // 
            // cmbPosition
            // 
            this.cmbPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(18, 225);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(254, 23);
            this.cmbPosition.TabIndex = 12;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPosition.Location = new System.Drawing.Point(18, 205);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(43, 15);
            this.lblPosition.TabIndex = 11;
            this.lblPosition.Text = "Vị trí:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(18, 180);
            this.txtPassword.MaxLength = 255;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(254, 23);
            this.txtPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.Location = new System.Drawing.Point(18, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 15);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserName.Location = new System.Drawing.Point(18, 135);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(254, 23);
            this.txtUserName.TabIndex = 8;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserName.Location = new System.Drawing.Point(18, 115);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 15);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Tên đăng nhập:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(18, 90);
            this.txtPhoneNumber.MaxLength = 15;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(254, 23);
            this.txtPhoneNumber.TabIndex = 6;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhoneNumber.Location = new System.Drawing.Point(18, 70);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(87, 15);
            this.lblPhoneNumber.TabIndex = 5;
            this.lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(18, 45);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(120, 23);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirstName.Location = new System.Drawing.Point(18, 25);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(32, 15);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "Tên:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLastName.Location = new System.Drawing.Point(148, 45);
            this.txtLastName.MaxLength = 20;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(124, 23);
            this.txtLastName.TabIndex = 4;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastName.Location = new System.Drawing.Point(130, 25);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(29, 15);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Họ:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(10, 350);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlButtons.Size = new System.Drawing.Size(290, 100);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(150, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(10, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.Location = new System.Drawing.Point(195, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(100, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
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
            this.pnlHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 130);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(3, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(104, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Tổng số nhân viên: 0";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.cmbFilterStatus);
            this.pnlSearch.Controls.Add(this.lblFilterStatus);
            this.pnlSearch.Controls.Add(this.cmbFilterPosition);
            this.pnlSearch.Controls.Add(this.lblFilterPosition);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(450, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(530, 95);
            this.pnlSearch.TabIndex = 1;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(410, 48);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(120, 23);
            this.cmbFilterStatus.TabIndex = 7;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterStatus.Location = new System.Drawing.Point(410, 30);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(66, 15);
            this.lblFilterStatus.TabIndex = 6;
            this.lblFilterStatus.Text = "Trạng thái:";
            // 
            // cmbFilterPosition
            // 
            this.cmbFilterPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterPosition.FormattingEnabled = true;
            this.cmbFilterPosition.Location = new System.Drawing.Point(270, 48);
            this.cmbFilterPosition.Name = "cmbFilterPosition";
            this.cmbFilterPosition.Size = new System.Drawing.Size(130, 23);
            this.cmbFilterPosition.TabIndex = 5;
            this.cmbFilterPosition.SelectedIndexChanged += new System.EventHandler(this.cmbFilterPosition_SelectedIndexChanged);
            // 
            // lblFilterPosition
            // 
            this.lblFilterPosition.AutoSize = true;
            this.lblFilterPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterPosition.Location = new System.Drawing.Point(270, 30);
            this.lblFilterPosition.Name = "lblFilterPosition";
            this.lblFilterPosition.Size = new System.Drawing.Size(43, 15);
            this.lblFilterPosition.TabIndex = 4;
            this.lblFilterPosition.Text = "Vị trí:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(420, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 25);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.Location = new System.Drawing.Point(300, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(0, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Location = new System.Drawing.Point(0, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(58, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Từ khóa:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý nhân viên";
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlMain);
            this.KeyPreview = true;
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên";
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.ComboBox cmbUserStatus;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterPosition;
        private System.Windows.Forms.Label lblFilterPosition;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
    }
}

