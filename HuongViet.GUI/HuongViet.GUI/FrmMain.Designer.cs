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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.userPanel = new System.Windows.Forms.Panel();
            this.userContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserMenu = new FontAwesome.Sharp.IconButton();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.iconSearch = new FontAwesome.Sharp.IconPictureBox();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.btnToggleSidebar = new FontAwesome.Sharp.IconButton();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.navContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.btnInvoices = new FontAwesome.Sharp.IconButton();
            this.btnTables = new FontAwesome.Sharp.IconButton();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.btnOrders = new FontAwesome.Sharp.IconButton();
            this.btnCombo = new FontAwesome.Sharp.IconButton();
            this.btnStaff = new FontAwesome.Sharp.IconButton();
            this.btnPosition = new FontAwesome.Sharp.IconButton();
            this.btnCustomers = new FontAwesome.Sharp.IconButton();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnRestaurant = new FontAwesome.Sharp.IconButton();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.placeholderPanel = new System.Windows.Forms.Panel();
            this.lblPlaceholderHint = new System.Windows.Forms.Label();
            this.lblPlaceholderTitle = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.userContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.sidebarPanel.SuspendLayout();
            this.navContainer.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.placeholderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Controls.Add(this.userPanel);
            this.headerPanel.Controls.Add(this.searchPanel);
            this.headerPanel.Controls.Add(this.lblSectionTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.headerPanel.Size = new System.Drawing.Size(1024, 72);
            this.headerPanel.TabIndex = 0;
            // 
            // userPanel
            // 
            this.userPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userPanel.ContextMenuStrip = this.userContextMenu;
            this.userPanel.Controls.Add(this.btnUserMenu);
            this.userPanel.Controls.Add(this.lblUserRole);
            this.userPanel.Controls.Add(this.lblUserName);
            this.userPanel.Controls.Add(this.avatarPictureBox);
            this.userPanel.Location = new System.Drawing.Point(784, 13);
            this.userPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(222, 46);
            this.userPanel.TabIndex = 4;
            // 
            // userContextMenu
            // 
            this.userContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.userContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProfile,
            this.menuItemPassword,
            this.menuItemLogout});
            this.userContextMenu.Name = "userContextMenu";
            this.userContextMenu.Size = new System.Drawing.Size(176, 70);
            // 
            // menuItemProfile
            // 
            this.menuItemProfile.Name = "menuItemProfile";
            this.menuItemProfile.Size = new System.Drawing.Size(175, 22);
            this.menuItemProfile.Text = "Thông tin cơ bản";
            this.menuItemProfile.Click += new System.EventHandler(this.menuItemProfile_Click);
            // 
            // menuItemPassword
            // 
            this.menuItemPassword.Name = "menuItemPassword";
            this.menuItemPassword.Size = new System.Drawing.Size(175, 22);
            this.menuItemPassword.Text = "Cập nhật mật khẩu";
            this.menuItemPassword.Click += new System.EventHandler(this.menuItemPassword_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(175, 22);
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
            this.btnUserMenu.Location = new System.Drawing.Point(186, 10);
            this.btnUserMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUserMenu.Name = "btnUserMenu";
            this.btnUserMenu.Size = new System.Drawing.Size(30, 26);
            this.btnUserMenu.TabIndex = 3;
            this.btnUserMenu.UseVisualStyleBackColor = true;
            this.btnUserMenu.Click += new System.EventHandler(this.btnUserMenu_Click);
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.Gray;
            this.lblUserRole.Location = new System.Drawing.Point(48, 24);
            this.lblUserRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(101, 15);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Quản trị hệ thống";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Black;
            this.lblUserName.Location = new System.Drawing.Point(47, 7);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 19);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Hồ Ánh Hòa*";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.avatarPictureBox.Location = new System.Drawing.Point(6, 6);
            this.avatarPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(36, 39);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPictureBox.TabIndex = 0;
            this.avatarPictureBox.TabStop = false;
            // 
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.iconSearch);
            this.searchPanel.Location = new System.Drawing.Point(180, 20);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.searchPanel.Size = new System.Drawing.Size(588, 32);
            this.searchPanel.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(36, 8);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(540, 18);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Nhập từ khóa tìm kiếm...";
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.Transparent;
            this.iconSearch.ForeColor = System.Drawing.Color.Gray;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.Color.Gray;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.IconSize = 15;
            this.iconSearch.Location = new System.Drawing.Point(12, 8);
            this.iconSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.iconSearch.Size = new System.Drawing.Size(15, 16);
            this.iconSearch.TabIndex = 0;
            this.iconSearch.TabStop = false;
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.Location = new System.Drawing.Point(270, 23);
            this.lblSectionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(198, 25);
            this.lblSectionTitle.TabIndex = 2;
            this.lblSectionTitle.Text = "Lịch sử đơn hàng mới";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Image = global::HuongViet.GUI.Properties.Resources.huong_viet_logo_no_bg;
            this.logoPictureBox.Location = new System.Drawing.Point(18, 8);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(150, 56);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 5;
            this.logoPictureBox.TabStop = false;
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
            this.btnToggleSidebar.Location = new System.Drawing.Point(8, 445);
            this.btnToggleSidebar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(160, 32);
            this.btnToggleSidebar.TabIndex = 1;
            this.btnToggleSidebar.Text = "<<";
            this.btnToggleSidebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnToggleSidebar.UseVisualStyleBackColor = true;
            this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.sidebarPanel.Controls.Add(this.navContainer);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 72);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(180, 521);
            this.sidebarPanel.TabIndex = 1;
            // 
            // navContainer
            // 
            this.navContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.navContainer.Controls.Add(this.btnDashboard);
            this.navContainer.Controls.Add(this.btnInvoices);
            this.navContainer.Controls.Add(this.btnTables);
            this.navContainer.Controls.Add(this.btnMenu);
            this.navContainer.Controls.Add(this.btnOrders);
            this.navContainer.Controls.Add(this.btnCombo);
            this.navContainer.Controls.Add(this.btnStaff);
            // btnPosition is now a sub-item of btnStaff, but kept for backward compatibility
            this.btnPosition.Visible = false;
            this.navContainer.Controls.Add(this.btnPosition);
            this.navContainer.Controls.Add(this.btnCustomers);
            this.navContainer.Controls.Add(this.btnSettings);
            this.navContainer.Controls.Add(this.btnRestaurant);
            this.navContainer.Controls.Add(this.btnToggleSidebar);
            this.navContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navContainer.Location = new System.Drawing.Point(0, 0);
            this.navContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.navContainer.Name = "navContainer";
            this.navContainer.Padding = new System.Windows.Forms.Padding(12, 16, 12, 16);
            this.navContainer.Size = new System.Drawing.Size(180, 521);
            this.navContainer.TabIndex = 1;
            this.navContainer.WrapContents = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 26;
            this.btnDashboard.Location = new System.Drawing.Point(8, 15);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(160, 39);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Thống kê";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnDashboard.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnInvoices
            // 
            this.btnInvoices.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnInvoices.IconColor = System.Drawing.Color.White;
            this.btnInvoices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInvoices.IconSize = 26;
            this.btnInvoices.Location = new System.Drawing.Point(8, 58);
            this.btnInvoices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(160, 39);
            this.btnInvoices.TabIndex = 1;
            this.btnInvoices.Tag = "Hóa đơn";
            this.btnInvoices.Text = "Hóa đơn";
            this.btnInvoices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoices.UseVisualStyleBackColor = true;
            this.btnInvoices.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnInvoices.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnTables
            // 
            this.btnTables.IconChar = FontAwesome.Sharp.IconChar.Columns;
            this.btnTables.IconColor = System.Drawing.Color.White;
            this.btnTables.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTables.IconSize = 24;
            this.btnTables.Location = new System.Drawing.Point(8, 101);
            this.btnTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(160, 39);
            this.btnTables.TabIndex = 2;
            this.btnTables.Tag = "Mặt bàn";
            this.btnTables.Text = "Mặt bàn";
            this.btnTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnTables.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnMenu
            // 
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Burger;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 24;
            this.btnMenu.Location = new System.Drawing.Point(8, 144);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(160, 39);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Tag = "Mặt hàng";
            this.btnMenu.Text = "Mặt hàng";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnMenu.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnOrders
            // 
            this.btnOrders.IconChar = FontAwesome.Sharp.IconChar.BowlFood;
            this.btnOrders.IconColor = System.Drawing.Color.White;
            this.btnOrders.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOrders.IconSize = 24;
            this.btnOrders.Location = new System.Drawing.Point(8, 187);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(160, 39);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Tag = "Thực đơn";
            this.btnOrders.Text = "Thực đơn";
            this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnOrders.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnCombo
            // 
            this.btnCombo.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btnCombo.IconColor = System.Drawing.Color.White;
            this.btnCombo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCombo.IconSize = 24;
            this.btnCombo.Location = new System.Drawing.Point(8, 230);
            this.btnCombo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(160, 39);
            this.btnCombo.TabIndex = 5;
            this.btnCombo.Tag = "Combo";
            this.btnCombo.Text = "Combo";
            this.btnCombo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCombo.UseVisualStyleBackColor = true;
            this.btnCombo.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnCombo.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnStaff
            // 
            this.btnStaff.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnStaff.IconColor = System.Drawing.Color.White;
            this.btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStaff.IconSize = 24;
            this.btnStaff.Location = new System.Drawing.Point(8, 273);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(160, 39);
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
            this.btnPosition.IconChar = FontAwesome.Sharp.IconChar.MapMarkerAlt;
            this.btnPosition.IconColor = System.Drawing.Color.White;
            this.btnPosition.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPosition.IconSize = 24;
            this.btnPosition.Location = new System.Drawing.Point(8, 316);
            this.btnPosition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(160, 39);
            this.btnPosition.TabIndex = 7;
            this.btnPosition.Tag = "Vị trí";
            this.btnPosition.Text = "Vị trí";
            this.btnPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            this.btnPosition.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnPosition.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnCustomers
            // 
            this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCustomers.IconColor = System.Drawing.Color.White;
            this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomers.IconSize = 24;
            this.btnCustomers.Location = new System.Drawing.Point(8, 359);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(160, 39);
            this.btnCustomers.TabIndex = 8;
            this.btnCustomers.Tag = "Khách hàng";
            this.btnCustomers.Text = "Khách hàng";
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnCustomers.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnSettings
            // 
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSettings.IconColor = System.Drawing.Color.White;
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 24;
            this.btnSettings.Location = new System.Drawing.Point(8, 402);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(160, 39);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Tag = "Hệ thống";
            this.btnSettings.Text = "Hệ thống";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // btnRestaurant
            // 
            this.btnRestaurant.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnRestaurant.IconColor = System.Drawing.Color.White;
            this.btnRestaurant.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestaurant.IconSize = 24;
            this.btnRestaurant.Location = new System.Drawing.Point(8, 445);
            this.btnRestaurant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestaurant.Name = "btnRestaurant";
            this.btnRestaurant.Size = new System.Drawing.Size(160, 39);
            this.btnRestaurant.TabIndex = 10;
            this.btnRestaurant.Tag = "Thiết lập nhà hàng";
            this.btnRestaurant.Text = "Thiết lập nhà hàng";
            this.btnRestaurant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurant.UseVisualStyleBackColor = true;
            this.btnRestaurant.MouseEnter += new System.EventHandler(this.navButton_MouseEnter);
            this.btnRestaurant.MouseLeave += new System.EventHandler(this.navButton_MouseLeave);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.placeholderPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(180, 72);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(24, 26, 24, 26);
            this.contentPanel.Size = new System.Drawing.Size(844, 521);
            this.contentPanel.TabIndex = 2;
            // 
            // placeholderPanel
            // 
            this.placeholderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.placeholderPanel.BackColor = System.Drawing.Color.White;
            this.placeholderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placeholderPanel.Controls.Add(this.lblPlaceholderHint);
            this.placeholderPanel.Controls.Add(this.lblPlaceholderTitle);
            this.placeholderPanel.Location = new System.Drawing.Point(26, 21);
            this.placeholderPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.placeholderPanel.Name = "placeholderPanel";
            this.placeholderPanel.Padding = new System.Windows.Forms.Padding(24, 26, 24, 26);
            this.placeholderPanel.Size = new System.Drawing.Size(792, 472);
            this.placeholderPanel.TabIndex = 0;
            // 
            // lblPlaceholderHint
            // 
            this.lblPlaceholderHint.AutoSize = true;
            this.lblPlaceholderHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlaceholderHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblPlaceholderHint.Location = new System.Drawing.Point(28, 63);
            this.lblPlaceholderHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlaceholderHint.Name = "lblPlaceholderHint";
            this.lblPlaceholderHint.Size = new System.Drawing.Size(471, 19);
            this.lblPlaceholderHint.TabIndex = 1;
            this.lblPlaceholderHint.Text = "Khu vực này tạm thời để trống. Bạn có thể tiếp tục phát triển các màn hình.";
            // 
            // lblPlaceholderTitle
            // 
            this.lblPlaceholderTitle.AutoSize = true;
            this.lblPlaceholderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPlaceholderTitle.Location = new System.Drawing.Point(26, 28);
            this.lblPlaceholderTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlaceholderTitle.Name = "lblPlaceholderTitle";
            this.lblPlaceholderTitle.Size = new System.Drawing.Size(156, 25);
            this.lblPlaceholderTitle.TabIndex = 0;
            this.lblPlaceholderTitle.Text = "Nội dung tại đây";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 593);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huong Viet Administration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.userContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
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
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconPictureBox iconSearch;
        private System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private FontAwesome.Sharp.IconButton btnToggleSidebar;
        private System.Windows.Forms.FlowLayoutPanel navContainer;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnInvoices;
        private FontAwesome.Sharp.IconButton btnTables;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnOrders;
        private FontAwesome.Sharp.IconButton btnCombo;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnPosition;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnRestaurant;
        private System.Windows.Forms.Panel placeholderPanel;
        private System.Windows.Forms.Label lblPlaceholderHint;
        private System.Windows.Forms.Label lblPlaceholderTitle;
        private System.Windows.Forms.ContextMenuStrip userContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemProfile;
        private System.Windows.Forms.ToolStripMenuItem menuItemPassword;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
    }
}

