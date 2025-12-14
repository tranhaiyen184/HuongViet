namespace HuongViet.GUI
{
    partial class FrmPOS
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TabControl tabControlTables;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.DataGridView dgvTables;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutTables;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutItems;
        private System.Windows.Forms.ComboBox cmbAreaFilter;
        private System.Windows.Forms.Label lblTableCount;
        private System.Windows.Forms.Label lblTableInfo;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Panel pnlOrderHeader;
        private System.Windows.Forms.Panel pnlOrderFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tabControlTables = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.cmbAreaFilter = new System.Windows.Forms.ComboBox();
            this.lblTableCount = new System.Windows.Forms.Label();
            this.flowLayoutTables = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelOrderSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderSummary = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lblCustomerMoney = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.txbVoucher = new System.Windows.Forms.TextBox();
            this.txbCustomerMoney = new System.Windows.Forms.TextBox();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblGrandTotalAmount = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.flowLayoutItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOrderHeader = new System.Windows.Forms.Panel();
            this.lblTableInfo = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.pnlOrderFooter = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.tabControlTables.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.tabControlMenu.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            this.tableLayoutPanelOrderSummary.SuspendLayout();
            this.pnlOrderHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.pnlOrderFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.pnlLeft);
            this.splitContainerMain.Panel1.Controls.Add(this.pnlRight);
            this.splitContainerMain.Panel1MinSize = 300;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pnlOrderHeader);
            this.splitContainerMain.Panel2.Controls.Add(this.dgvOrder);
            this.splitContainerMain.Panel2.Controls.Add(this.pnlOrderFooter);
            this.splitContainerMain.Panel2MinSize = 300;
            this.splitContainerMain.Size = new System.Drawing.Size(1400, 800);
            this.splitContainerMain.SplitterDistance = 500;
            this.splitContainerMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabControlTables);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(400, 500);
            this.pnlLeft.TabIndex = 0;
            // 
            // tabControlTables
            // 
            this.tabControlTables.Controls.Add(this.tabPageTables);
            this.tabControlTables.Location = new System.Drawing.Point(0, 0);
            this.tabControlTables.Name = "tabControlTables";
            this.tabControlTables.SelectedIndex = 0;
            this.tabControlTables.Size = new System.Drawing.Size(400, 500);
            this.tabControlTables.TabIndex = 0;
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.cmbAreaFilter);
            this.tabPageTables.Controls.Add(this.lblTableCount);
            this.tabPageTables.Controls.Add(this.flowLayoutTables);
            this.tabPageTables.Controls.Add(this.dgvTables);
            this.tabPageTables.Location = new System.Drawing.Point(4, 25);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(392, 471);
            this.tabPageTables.TabIndex = 0;
            this.tabPageTables.Text = "PHÒNG / BÀN";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // cmbAreaFilter
            // 
            this.cmbAreaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbAreaFilter.FormattingEnabled = true;
            this.cmbAreaFilter.Location = new System.Drawing.Point(3, 3);
            this.cmbAreaFilter.Name = "cmbAreaFilter";
            this.cmbAreaFilter.Size = new System.Drawing.Size(386, 28);
            this.cmbAreaFilter.TabIndex = 1;
            // 
            // lblTableCount
            // 
            this.lblTableCount.AutoSize = true;
            this.lblTableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTableCount.Location = new System.Drawing.Point(3, 448);
            this.lblTableCount.Name = "lblTableCount";
            this.lblTableCount.Size = new System.Drawing.Size(50, 20);
            this.lblTableCount.TabIndex = 0;
            this.lblTableCount.Text = "0 bàn";
            // 
            // flowLayoutTables
            // 
            this.flowLayoutTables.AutoScroll = true;
            this.flowLayoutTables.BackColor = System.Drawing.Color.White;
            this.flowLayoutTables.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutTables.Name = "flowLayoutTables";
            this.flowLayoutTables.Size = new System.Drawing.Size(386, 410);
            this.flowLayoutTables.TabIndex = 2;
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Location = new System.Drawing.Point(3, 31);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowHeadersWidth = 51;
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.Size = new System.Drawing.Size(386, 417);
            this.dgvTables.TabIndex = 0;
            this.dgvTables.Visible = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabControlMenu);
            this.pnlRight.Location = new System.Drawing.Point(400, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1000, 500);
            this.pnlRight.TabIndex = 1;
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Controls.Add(this.tabPageMenu);
            this.tabControlMenu.Location = new System.Drawing.Point(0, 0);
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.Size = new System.Drawing.Size(1000, 500);
            this.tabControlMenu.TabIndex = 0;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.tableLayoutPanelOrderSummary);
            this.tabPageMenu.Controls.Add(this.flowLayoutItems);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 25);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMenu.Size = new System.Drawing.Size(992, 471);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrderSummary
            // 
            this.tableLayoutPanelOrderSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelOrderSummary.ColumnCount = 2;
            this.tableLayoutPanelOrderSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanelOrderSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblOrderSummary, 0, 0);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.labelTotalAmount, 0, 1);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblTotalAmount, 1, 1);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblGrandTotal, 0, 4);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblDiscount, 0, 3);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblVoucher, 0, 2);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblCustomerMoney, 0, 5);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblChange, 0, 6);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.txbVoucher, 1, 2);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.txbCustomerMoney, 1, 5);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblDiscountAmount, 1, 3);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblGrandTotalAmount, 1, 4);
            this.tableLayoutPanelOrderSummary.Controls.Add(this.lblChangeAmount, 1, 6);
            this.tableLayoutPanelOrderSummary.Location = new System.Drawing.Point(600, 6);
            this.tableLayoutPanelOrderSummary.Name = "tableLayoutPanelOrderSummary";
            this.tableLayoutPanelOrderSummary.RowCount = 7;
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelOrderSummary.Size = new System.Drawing.Size(386, 459);
            this.tableLayoutPanelOrderSummary.TabIndex = 1;
            // 
            // lblOrderSummary
            // 
            this.lblOrderSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderSummary.AutoSize = true;
            this.tableLayoutPanelOrderSummary.SetColumnSpan(this.lblOrderSummary, 2);
            this.lblOrderSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderSummary.Location = new System.Drawing.Point(69, 14);
            this.lblOrderSummary.Name = "lblOrderSummary";
            this.lblOrderSummary.Size = new System.Drawing.Size(248, 29);
            this.lblOrderSummary.TabIndex = 0;
            this.lblOrderSummary.Text = "Hoá đơn Thanh toán";
            this.lblOrderSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new System.Drawing.Point(3, 58);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(68, 20);
            this.labelTotalAmount.TabIndex = 1;
            this.labelTotalAmount.Text = "Thành tiền";
            this.labelTotalAmount.UseCompatibleTextRendering = true;
            this.labelTotalAmount.Click += new System.EventHandler(this.labelTotalAmount_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(197, 58);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(24, 25);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "0";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Location = new System.Drawing.Point(3, 178);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(63, 16);
            this.lblGrandTotal.TabIndex = 7;
            this.lblGrandTotal.Text = "Tổng tiền";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(3, 138);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(61, 16);
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Text = "Giảm giá";
            // 
            // lblVoucher
            // 
            this.lblVoucher.AutoSize = true;
            this.lblVoucher.Location = new System.Drawing.Point(3, 98);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(80, 16);
            this.lblVoucher.TabIndex = 8;
            this.lblVoucher.Text = "Mã voucher:";
            // 
            // lblCustomerMoney
            // 
            this.lblCustomerMoney.AutoSize = true;
            this.lblCustomerMoney.Location = new System.Drawing.Point(3, 218);
            this.lblCustomerMoney.Name = "lblCustomerMoney";
            this.lblCustomerMoney.Size = new System.Drawing.Size(65, 16);
            this.lblCustomerMoney.TabIndex = 9;
            this.lblCustomerMoney.Text = "Khách gửi";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Location = new System.Drawing.Point(3, 258);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(65, 16);
            this.lblChange.TabIndex = 10;
            this.lblChange.Text = "Tiền thừa:";
            // 
            // txbVoucher
            // 
            this.txbVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbVoucher.Location = new System.Drawing.Point(197, 101);
            this.txbVoucher.Name = "txbVoucher";
            this.txbVoucher.Size = new System.Drawing.Size(186, 30);
            this.txbVoucher.TabIndex = 11;
            // 
            // txbCustomerMoney
            // 
            this.txbCustomerMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCustomerMoney.Location = new System.Drawing.Point(197, 221);
            this.txbCustomerMoney.Name = "txbCustomerMoney";
            this.txbCustomerMoney.Size = new System.Drawing.Size(186, 30);
            this.txbCustomerMoney.TabIndex = 12;
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmount.Location = new System.Drawing.Point(197, 138);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(127, 25);
            this.lblDiscountAmount.TabIndex = 13;
            this.lblDiscountAmount.Text = "0.000 (-0%)";
            // 
            // lblGrandTotalAmount
            // 
            this.lblGrandTotalAmount.AutoSize = true;
            this.lblGrandTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalAmount.Location = new System.Drawing.Point(197, 178);
            this.lblGrandTotalAmount.Name = "lblGrandTotalAmount";
            this.lblGrandTotalAmount.Size = new System.Drawing.Size(66, 25);
            this.lblGrandTotalAmount.TabIndex = 14;
            this.lblGrandTotalAmount.Text = "0.000";
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.Location = new System.Drawing.Point(197, 258);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(66, 25);
            this.lblChangeAmount.TabIndex = 15;
            this.lblChangeAmount.Text = "0.000";
            // 
            // flowLayoutItems
            // 
            this.flowLayoutItems.AutoScroll = true;
            this.flowLayoutItems.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutItems.Name = "flowLayoutItems";
            this.flowLayoutItems.Size = new System.Drawing.Size(591, 465);
            this.flowLayoutItems.TabIndex = 0;
            // 
            // pnlOrderHeader
            // 
            this.pnlOrderHeader.Controls.Add(this.lblTableInfo);
            this.pnlOrderHeader.Controls.Add(this.lblDateTime);
            this.pnlOrderHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderHeader.Name = "pnlOrderHeader";
            this.pnlOrderHeader.Size = new System.Drawing.Size(1400, 40);
            this.pnlOrderHeader.TabIndex = 2;
            // 
            // lblTableInfo
            // 
            this.lblTableInfo.AutoSize = true;
            this.lblTableInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTableInfo.Location = new System.Drawing.Point(10, 10);
            this.lblTableInfo.Name = "lblTableInfo";
            this.lblTableInfo.Size = new System.Drawing.Size(134, 20);
            this.lblTableInfo.TabIndex = 1;
            this.lblTableInfo.Text = "Chưa chọn bàn";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDateTime.Location = new System.Drawing.Point(1250, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(137, 20);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "20/07/2022 18:17";
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(0, 40);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(1400, 200);
            this.dgvOrder.TabIndex = 1;
            // 
            // pnlOrderFooter
            // 
            this.pnlOrderFooter.Controls.Add(this.btnPayment);
            this.pnlOrderFooter.Controls.Add(this.btnSaveOrder);
            this.pnlOrderFooter.Controls.Add(this.lblCustomerPhone);
            this.pnlOrderFooter.Controls.Add(this.lblCustomerName);
            this.pnlOrderFooter.Controls.Add(this.txtCustomerPhone);
            this.pnlOrderFooter.Controls.Add(this.txtCustomerName);
            this.pnlOrderFooter.Controls.Add(this.btnNewCustomer);
            this.pnlOrderFooter.Controls.Add(this.btnSearchCustomer);
            this.pnlOrderFooter.Location = new System.Drawing.Point(0, 240);
            this.pnlOrderFooter.Name = "pnlOrderFooter";
            this.pnlOrderFooter.Size = new System.Drawing.Size(1400, 60);
            this.pnlOrderFooter.TabIndex = 0;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.Red;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(1200, 10);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(180, 40);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "Thanh toán [F4]";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.BtnPayment_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSaveOrder.Location = new System.Drawing.Point(1000, 10);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(180, 40);
            this.btnSaveOrder.TabIndex = 6;
            this.btnSaveOrder.Text = "Lưu đơn hàng";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.BtnSaveOrder_Click);
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(300, 23);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(88, 16);
            this.lblCustomerPhone.TabIndex = 4;
            this.lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(10, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(106, 16);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(400, 20);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(150, 22);
            this.txtCustomerPhone.TabIndex = 2;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(150, 22);
            this.txtCustomerName.TabIndex = 1;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.BackColor = System.Drawing.Color.Green;
            this.btnNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnNewCustomer.Location = new System.Drawing.Point(670, 18);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(120, 25);
            this.btnNewCustomer.TabIndex = 8;
            this.btnNewCustomer.Text = "Khách hàng mới";
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.BtnNewCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(560, 18);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(100, 25);
            this.btnSearchCustomer.TabIndex = 0;
            this.btnSearchCustomer.Text = "Tìm khách hàng";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.BtnSearchCustomer_Click);
            // 
            // FrmPOS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FrmPOS";
            this.Text = "Hệ thống POS - Bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.tabControlTables.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tabPageTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.tabControlMenu.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            this.tableLayoutPanelOrderSummary.ResumeLayout(false);
            this.tableLayoutPanelOrderSummary.PerformLayout();
            this.pnlOrderHeader.ResumeLayout(false);
            this.pnlOrderHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlOrderFooter.ResumeLayout(false);
            this.pnlOrderFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOrderSummary;
        private System.Windows.Forms.Label lblOrderSummary;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label lblCustomerMoney;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox txbVoucher;
        private System.Windows.Forms.TextBox txbCustomerMoney;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblGrandTotalAmount;
        private System.Windows.Forms.Label lblChangeAmount;
    }
}
