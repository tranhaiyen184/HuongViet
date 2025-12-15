 namespace HuongViet.GUI
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.headerPanel = new System.Windows.Forms.Panel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.userPanel = new System.Windows.Forms.Panel();
			this.userContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProfile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPassword = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.btnUserMenu = new FontAwesome.Sharp.IconButton();
			this.lblUserRole = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.avatarPictureBox = new System.Windows.Forms.PictureBox();
			this.btnToggleSidebar = new FontAwesome.Sharp.IconButton();
			this.sidebarPanel = new System.Windows.Forms.Panel();
			this.navContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.btnReport = new FontAwesome.Sharp.IconButton();
			this.btnTables = new FontAwesome.Sharp.IconButton();
			this.btnMenu = new FontAwesome.Sharp.IconButton();
			this.btnOrders = new FontAwesome.Sharp.IconButton();
			this.btnReservations = new FontAwesome.Sharp.IconButton();
			this.btnVouchers = new FontAwesome.Sharp.IconButton();
			this.btnBackup = new FontAwesome.Sharp.IconButton();
			this.btnStaff = new FontAwesome.Sharp.IconButton();
			this.btnPosition = new FontAwesome.Sharp.IconButton();
			this.btnCombo = new FontAwesome.Sharp.IconButton();
			this.btnInvoices = new FontAwesome.Sharp.IconButton();
			this.btnCustomers = new FontAwesome.Sharp.IconButton();
			this.btnSettings = new FontAwesome.Sharp.IconButton();
			this.btnRestaurant = new FontAwesome.Sharp.IconButton();
			this.contentPanel = new System.Windows.Forms.Panel();
			this.placeholderPanel = new System.Windows.Forms.Panel();
			this.lblPlaceholderHint = new System.Windows.Forms.Label();
			this.lblPlaceholderTitle = new System.Windows.Forms.Label();
			this.headerPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.userPanel.SuspendLayout();
			this.userContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
			this.sidebarPanel.SuspendLayout();
			this.navContainer.SuspendLayout();
			this.contentPanel.SuspendLayout();
			this.placeholderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.logoPictureBox);
			this.headerPanel.Controls.Add(this.userPanel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(32, 20, 32, 20);
			this.headerPanel.Size = new System.Drawing.Size(1365, 130);
			this.headerPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.Location = new System.Drawing.Point(-16, -11);
			this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.Size = new System.Drawing.Size(436, 153);
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logoPictureBox.TabIndex = 5;
			this.logoPictureBox.TabStop = false;
			// 
			// userPanel
			// 
			this.userPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.userPanel.ContextMenuStrip = this.userContextMenu;
			this.userPanel.Controls.Add(this.btnUserMenu);
			this.userPanel.Controls.Add(this.lblUserRole);
			this.userPanel.Controls.Add(this.lblUserName);
			this.userPanel.Controls.Add(this.avatarPictureBox);
			this.userPanel.Location = new System.Drawing.Point(954, 22);
			this.userPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.userPanel.Name = "userPanel";
			this.userPanel.Size = new System.Drawing.Size(395, 86);
			this.userPanel.TabIndex = 4;
			this.userPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userPanel_Paint);
			// 
			// userContextMenu
			// 
			this.userContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.userContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProfile,
            this.menuItemPassword,
            this.menuItemLogout});
			this.userContextMenu.Name = "userContextMenu";
			this.userContextMenu.Size = new System.Drawing.Size(203, 76);
			// 
			// menuItemProfile
			// 
			this.menuItemProfile.Name = "menuItemProfile";
			this.menuItemProfile.Size = new System.Drawing.Size(202, 24);
			this.menuItemProfile.Text = "Thông tin cơ bản";
			this.menuItemProfile.Click += new System.EventHandler(this.menuItemProfile_Click);
			// 
			// menuItemPassword
			// 
			this.menuItemPassword.Name = "menuItemPassword";
			this.menuItemPassword.Size = new System.Drawing.Size(202, 24);
			this.menuItemPassword.Text = "Cập nhật mật khẩu";
			this.menuItemPassword.Click += new System.EventHandler(this.menuItemPassword_Click);
			// 
			// menuItemLogout
			// 
			this.menuItemLogout.Name = "menuItemLogout";
			this.menuItemLogout.Size = new System.Drawing.Size(202, 24);
			this.menuItemLogout.Text = "Đăng xuất";
			this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
			// 
			// btnUserMenu
			// 
			this.btnUserMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUserMenu.FlatAppearance.BorderSize = 0;
			this.btnUserMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUserMenu.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
			this.btnUserMenu.IconColor = System.Drawing.Color.DimGray;
			this.btnUserMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnUserMenu.IconSize = 20;
			this.btnUserMenu.Location = new System.Drawing.Point(248, 12);
			this.btnUserMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnUserMenu.Name = "btnUserMenu";
			this.btnUserMenu.Size = new System.Drawing.Size(40, 32);
			this.btnUserMenu.TabIndex = 3;
			this.btnUserMenu.UseVisualStyleBackColor = true;
			this.btnUserMenu.Click += new System.EventHandler(this.btnUserMenu_Click);
			// 
			// lblUserRole
			// 
			this.lblUserRole.AutoSize = true;
			this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserRole.ForeColor = System.Drawing.Color.Gray;
			this.lblUserRole.Location = new System.Drawing.Point(94, 36);
			this.lblUserRole.Name = "lblUserRole";
			this.lblUserRole.Size = new System.Drawing.Size(125, 20);
			this.lblUserRole.TabIndex = 2;
			this.lblUserRole.Text = "Quản trị hệ thống";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserName.ForeColor = System.Drawing.Color.Black;
			this.lblUserName.Location = new System.Drawing.Point(91, 9);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(113, 23);
			this.lblUserName.TabIndex = 1;
			this.lblUserName.Text = "Hồ Ánh Hòa*";
			this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
			// 
			// avatarPictureBox
			// 
			this.avatarPictureBox.BackColor = System.Drawing.Color.LightGray;
			this.avatarPictureBox.Location = new System.Drawing.Point(8, 7);
			this.avatarPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.avatarPictureBox.Name = "avatarPictureBox";
			this.avatarPictureBox.Size = new System.Drawing.Size(62, 49);
			this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.avatarPictureBox.TabIndex = 0;
			this.avatarPictureBox.TabStop = false;
			// 
			// btnToggleSidebar
			// 
			this.btnToggleSidebar.FlatAppearance.BorderSize = 0;
			this.btnToggleSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnToggleSidebar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnToggleSidebar.ForeColor = System.Drawing.Color.White;
			this.btnToggleSidebar.IconChar = FontAwesome.Sharp.IconChar.None;
			this.btnToggleSidebar.IconColor = System.Drawing.Color.White;
			this.btnToggleSidebar.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnToggleSidebar.Location = new System.Drawing.Point(19, 490);
			this.btnToggleSidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnToggleSidebar.Name = "btnToggleSidebar";
			this.btnToggleSidebar.Size = new System.Drawing.Size(213, 39);
			this.btnToggleSidebar.TabIndex = 1;
			this.btnToggleSidebar.Text = "<<";
			this.btnToggleSidebar.UseVisualStyleBackColor = true;
			this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
			// 
			// sidebarPanel
			// 
			this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
			this.sidebarPanel.Controls.Add(this.navContainer);
			this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.sidebarPanel.Location = new System.Drawing.Point(0, 130);
			this.sidebarPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.sidebarPanel.Name = "sidebarPanel";
			this.sidebarPanel.Size = new System.Drawing.Size(240, 600);
			this.sidebarPanel.TabIndex = 1;
			// 
			// navContainer
			// 
			this.navContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
			this.navContainer.Controls.Add(this.btnReport);
			this.navContainer.Controls.Add(this.btnTables);
			this.navContainer.Controls.Add(this.btnMenu);
			this.navContainer.Controls.Add(this.btnOrders);
			this.navContainer.Controls.Add(this.btnReservations);
			this.navContainer.Controls.Add(this.btnVouchers);
			this.navContainer.Controls.Add(this.btnBackup);
			this.navContainer.Controls.Add(this.btnStaff);
			this.navContainer.Controls.Add(this.btnPosition);
			this.navContainer.Controls.Add(this.btnToggleSidebar);
			this.navContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.navContainer.Location = new System.Drawing.Point(0, 0);
			this.navContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.navContainer.Name = "navContainer";
			this.navContainer.Padding = new System.Windows.Forms.Padding(16, 20, 16, 20);
			this.navContainer.Size = new System.Drawing.Size(240, 600);
			this.navContainer.TabIndex = 1;
			this.navContainer.WrapContents = false;
			// 
			// btnReport
			// 
			this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnReport.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
			this.btnReport.IconColor = System.Drawing.Color.White;
			this.btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnReport.IconSize = 26;
			this.btnReport.Location = new System.Drawing.Point(19, 22);
			this.btnReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(213, 48);
			this.btnReport.TabIndex = 0;
			this.btnReport.Text = "Thống kê";
			this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnReport.UseVisualStyleBackColor = true;
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			this.btnReport.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnReport.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnTables
			// 
			this.btnTables.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnTables.IconChar = FontAwesome.Sharp.IconChar.Columns;
			this.btnTables.IconColor = System.Drawing.Color.White;
			this.btnTables.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnTables.IconSize = 24;
			this.btnTables.Location = new System.Drawing.Point(19, 74);
			this.btnTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTables.Name = "btnTables";
			this.btnTables.Size = new System.Drawing.Size(213, 48);
			this.btnTables.TabIndex = 2;
			this.btnTables.Tag = "Thiết lập bàn";
			this.btnTables.Text = "Thiết lập bàn";
			this.btnTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTables.UseVisualStyleBackColor = true;
			this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
			this.btnTables.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnTables.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnMenu
			// 
			this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Burger;
			this.btnMenu.IconColor = System.Drawing.Color.White;
			this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnMenu.IconSize = 24;
			this.btnMenu.Location = new System.Drawing.Point(19, 126);
			this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(213, 48);
			this.btnMenu.TabIndex = 3;
			this.btnMenu.Tag = "Thực đơn";
			this.btnMenu.Text = "Thực đơn";
			this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnMenu.UseVisualStyleBackColor = true;
			this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
			this.btnMenu.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnMenu.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnOrders
			// 
			this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnOrders.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
			this.btnOrders.IconColor = System.Drawing.Color.White;
			this.btnOrders.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnOrders.IconSize = 24;
			this.btnOrders.Location = new System.Drawing.Point(19, 178);
			this.btnOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOrders.Name = "btnOrders";
			this.btnOrders.Size = new System.Drawing.Size(213, 48);
			this.btnOrders.TabIndex = 4;
			this.btnOrders.Tag = "Bán hàng";
			this.btnOrders.Text = "Bán hàng";
			this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOrders.UseVisualStyleBackColor = true;
			this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
			this.btnOrders.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnOrders.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnReservations
			// 
			this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnReservations.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
			this.btnReservations.IconColor = System.Drawing.Color.White;
			this.btnReservations.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnReservations.IconSize = 24;
			this.btnReservations.Location = new System.Drawing.Point(19, 230);
			this.btnReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnReservations.Name = "btnReservations";
			this.btnReservations.Size = new System.Drawing.Size(213, 48);
			this.btnReservations.TabIndex = 5;
			this.btnReservations.Tag = "Đặt bàn";
			this.btnReservations.Text = "Đặt bàn";
			this.btnReservations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnReservations.UseVisualStyleBackColor = true;
			this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
			this.btnReservations.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnReservations.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnVouchers
			// 
			this.btnVouchers.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnVouchers.IconChar = FontAwesome.Sharp.IconChar.Tags;
			this.btnVouchers.IconColor = System.Drawing.Color.White;
			this.btnVouchers.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnVouchers.IconSize = 24;
			this.btnVouchers.Location = new System.Drawing.Point(19, 282);
			this.btnVouchers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnVouchers.Name = "btnVouchers";
			this.btnVouchers.Size = new System.Drawing.Size(213, 48);
			this.btnVouchers.TabIndex = 5;
			this.btnVouchers.Tag = "Voucher";
			this.btnVouchers.Text = "Voucher";
			this.btnVouchers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnVouchers.UseVisualStyleBackColor = true;
			this.btnVouchers.Click += new System.EventHandler(this.btnVouchers_Click);
			this.btnVouchers.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnVouchers.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnBackup
			// 
			this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
			this.btnBackup.IconColor = System.Drawing.Color.White;
			this.btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnBackup.IconSize = 24;
			this.btnBackup.Location = new System.Drawing.Point(19, 334);
			this.btnBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.Size = new System.Drawing.Size(213, 48);
			this.btnBackup.TabIndex = 11;
			this.btnBackup.Tag = "Sao lưu Dữ liệu";
			this.btnBackup.Text = "Sao lưu Dữ liệu";
			this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnBackup.UseVisualStyleBackColor = true;
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			this.btnBackup.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnBackup.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnStaff
			// 
			this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnStaff.IconChar = FontAwesome.Sharp.IconChar.UserTie;
			this.btnStaff.IconColor = System.Drawing.Color.White;
			this.btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnStaff.IconSize = 24;
			this.btnStaff.Location = new System.Drawing.Point(19, 386);
			this.btnStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnStaff.Name = "btnStaff";
			this.btnStaff.Size = new System.Drawing.Size(213, 48);
			this.btnStaff.TabIndex = 6;
			this.btnStaff.Tag = "Nhân viên";
			this.btnStaff.Text = "Nhân viên";
			this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStaff.UseVisualStyleBackColor = true;
			this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
			this.btnStaff.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnStaff.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnPosition
			// 
			this.btnPosition.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnPosition.IconChar = FontAwesome.Sharp.IconChar.MapMarkerAlt;
			this.btnPosition.IconColor = System.Drawing.Color.White;
			this.btnPosition.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnPosition.IconSize = 24;
			this.btnPosition.Location = new System.Drawing.Point(19, 438);
			this.btnPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPosition.Name = "btnPosition";
			this.btnPosition.Size = new System.Drawing.Size(213, 48);
			this.btnPosition.TabIndex = 7;
			this.btnPosition.Tag = "Vị trí";
			this.btnPosition.Text = "Vị trí";
			this.btnPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPosition.UseVisualStyleBackColor = true;
			this.btnPosition.Visible = false;
			this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
			this.btnPosition.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnPosition.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnCombo
			// 
			this.btnCombo.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
			this.btnCombo.IconColor = System.Drawing.Color.White;
			this.btnCombo.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCombo.IconSize = 24;
			this.btnCombo.Location = new System.Drawing.Point(19, 282);
			this.btnCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCombo.Name = "btnCombo";
			this.btnCombo.Size = new System.Drawing.Size(213, 48);
			this.btnCombo.TabIndex = 5;
			this.btnCombo.Tag = "Combo";
			this.btnCombo.Text = "Combo";
			this.btnCombo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCombo.UseVisualStyleBackColor = true;
			this.btnCombo.Visible = false;
			this.btnCombo.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnCombo.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnInvoices
			// 
			this.btnInvoices.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInvoices.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
			this.btnInvoices.IconColor = System.Drawing.Color.White;
			this.btnInvoices.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnInvoices.IconSize = 26;
			this.btnInvoices.Location = new System.Drawing.Point(19, 74);
			this.btnInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnInvoices.Name = "btnInvoices";
			this.btnInvoices.Size = new System.Drawing.Size(213, 48);
			this.btnInvoices.TabIndex = 1;
			this.btnInvoices.Tag = "Hóa đơn";
			this.btnInvoices.Text = "Hóa đơn";
			this.btnInvoices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnInvoices.UseVisualStyleBackColor = true;
			this.btnInvoices.Visible = false;
			this.btnInvoices.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnInvoices.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnCustomers
			// 
			this.btnCustomers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.Users;
			this.btnCustomers.IconColor = System.Drawing.Color.White;
			this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCustomers.IconSize = 24;
			this.btnCustomers.Location = new System.Drawing.Point(19, 490);
			this.btnCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCustomers.Name = "btnCustomers";
			this.btnCustomers.Size = new System.Drawing.Size(213, 48);
			this.btnCustomers.TabIndex = 8;
			this.btnCustomers.Tag = "Khách hàng";
			this.btnCustomers.Text = "Khách hàng";
			this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCustomers.UseVisualStyleBackColor = true;
			this.btnCustomers.Visible = false;
			this.btnCustomers.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnCustomers.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnSettings
			// 
			this.btnSettings.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
			this.btnSettings.IconColor = System.Drawing.Color.White;
			this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSettings.IconSize = 24;
			this.btnSettings.Location = new System.Drawing.Point(19, 542);
			this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(213, 48);
			this.btnSettings.TabIndex = 9;
			this.btnSettings.Tag = "Hệ thống";
			this.btnSettings.Text = "Hệ thống";
			this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Visible = false;
			this.btnSettings.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnSettings.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// btnRestaurant
			// 
			this.btnRestaurant.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRestaurant.IconChar = FontAwesome.Sharp.IconChar.Store;
			this.btnRestaurant.IconColor = System.Drawing.Color.White;
			this.btnRestaurant.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRestaurant.IconSize = 24;
			this.btnRestaurant.Location = new System.Drawing.Point(19, 594);
			this.btnRestaurant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRestaurant.Name = "btnRestaurant";
			this.btnRestaurant.Size = new System.Drawing.Size(213, 48);
			this.btnRestaurant.TabIndex = 10;
			this.btnRestaurant.Tag = "Thiết lập nhà hàng";
			this.btnRestaurant.Text = "Thiết lập nhà hàng";
			this.btnRestaurant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRestaurant.UseVisualStyleBackColor = true;
			this.btnRestaurant.Visible = false;
			this.btnRestaurant.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
			this.btnRestaurant.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
			// 
			// contentPanel
			// 
			this.contentPanel.Controls.Add(this.placeholderPanel);
			this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentPanel.Location = new System.Drawing.Point(240, 130);
			this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(1125, 600);
			this.contentPanel.TabIndex = 2;
			// 
			// placeholderPanel
			// 
			this.placeholderPanel.BackColor = System.Drawing.Color.White;
			this.placeholderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.placeholderPanel.Controls.Add(this.lblPlaceholderHint);
			this.placeholderPanel.Controls.Add(this.lblPlaceholderTitle);
			this.placeholderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.placeholderPanel.Location = new System.Drawing.Point(0, 0);
			this.placeholderPanel.Margin = new System.Windows.Forms.Padding(0);
			this.placeholderPanel.Name = "placeholderPanel";
			this.placeholderPanel.Padding = new System.Windows.Forms.Padding(16);
			this.placeholderPanel.Size = new System.Drawing.Size(1125, 600);
			this.placeholderPanel.TabIndex = 0;
			// 
			// lblPlaceholderHint
			// 
			this.lblPlaceholderHint.AutoSize = true;
			this.lblPlaceholderHint.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblPlaceholderHint.ForeColor = System.Drawing.Color.DimGray;
			this.lblPlaceholderHint.Location = new System.Drawing.Point(37, 78);
			this.lblPlaceholderHint.Name = "lblPlaceholderHint";
			this.lblPlaceholderHint.Size = new System.Drawing.Size(20, 23);
			this.lblPlaceholderHint.TabIndex = 1;
			this.lblPlaceholderHint.Text = "  ";
			// 
			// lblPlaceholderTitle
			// 
			this.lblPlaceholderTitle.AutoSize = true;
			this.lblPlaceholderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
			this.lblPlaceholderTitle.Location = new System.Drawing.Point(35, 34);
			this.lblPlaceholderTitle.Name = "lblPlaceholderTitle";
			this.lblPlaceholderTitle.Size = new System.Drawing.Size(197, 32);
			this.lblPlaceholderTitle.TabIndex = 0;
			this.lblPlaceholderTitle.Text = "Nội dung tại đây";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1365, 730);
			this.Controls.Add(this.contentPanel);
			this.Controls.Add(this.sidebarPanel);
			this.Controls.Add(this.headerPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Huong Viet Administration";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.headerPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.userPanel.ResumeLayout(false);
			this.userPanel.PerformLayout();
			this.userContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
			this.sidebarPanel.ResumeLayout(false);
			this.navContainer.ResumeLayout(false);
			this.contentPanel.ResumeLayout(false);
			this.placeholderPanel.ResumeLayout(false);
			this.placeholderPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private FontAwesome.Sharp.IconButton btnUserMenu;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private FontAwesome.Sharp.IconButton btnToggleSidebar;
        private System.Windows.Forms.FlowLayoutPanel navContainer;
        private FontAwesome.Sharp.IconButton btnReport;
        private FontAwesome.Sharp.IconButton btnInvoices;
        private FontAwesome.Sharp.IconButton btnTables;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnOrders;
        private FontAwesome.Sharp.IconButton btnReservations;
        private FontAwesome.Sharp.IconButton btnCombo;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnPosition;
        private FontAwesome.Sharp.IconButton btnVouchers;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnRestaurant;
        private FontAwesome.Sharp.IconButton btnBackup;
        private System.Windows.Forms.Panel placeholderPanel;
        private System.Windows.Forms.Label lblPlaceholderHint;
        private System.Windows.Forms.Label lblPlaceholderTitle;
        private System.Windows.Forms.ContextMenuStrip userContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemProfile;
        private System.Windows.Forms.ToolStripMenuItem menuItemPassword;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
    }
}

