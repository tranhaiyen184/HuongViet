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
            this.flowLayoutItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOrderHeader = new System.Windows.Forms.Panel();
            this.lblTableInfo = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.pnlOrderFooter = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
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
            this.tabPageTables.Location = new System.Drawing.Point(4, 22);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(392, 474);
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
            this.cmbAreaFilter.Size = new System.Drawing.Size(386, 24);
            this.cmbAreaFilter.TabIndex = 1;
            // 
            // lblTableCount
            // 
            this.lblTableCount.AutoSize = true;
            this.lblTableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTableCount.Location = new System.Drawing.Point(3, 448);
            this.lblTableCount.Name = "lblTableCount";
            this.lblTableCount.Size = new System.Drawing.Size(44, 17);
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
            this.tabPageMenu.Controls.Add(this.flowLayoutItems);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 22);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMenu.Size = new System.Drawing.Size(992, 474);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // flowLayoutItems
            // 
            this.flowLayoutItems.AutoScroll = true;
            this.flowLayoutItems.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutItems.Name = "flowLayoutItems";
            this.flowLayoutItems.Size = new System.Drawing.Size(986, 465);
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
            this.lblTableInfo.Size = new System.Drawing.Size(117, 17);
            this.lblTableInfo.TabIndex = 1;
            this.lblTableInfo.Text = "Chưa chọn bàn";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDateTime.Location = new System.Drawing.Point(1250, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(120, 17);
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
            this.pnlOrderFooter.Controls.Add(this.lblTotalAmount);
            this.pnlOrderFooter.Controls.Add(this.lblCustomerPhone);
            this.pnlOrderFooter.Controls.Add(this.lblCustomerName);
            this.pnlOrderFooter.Controls.Add(this.txtCustomerPhone);
            this.pnlOrderFooter.Controls.Add(this.txtCustomerName);
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
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(849, 23);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "0";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(300, 23);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(73, 13);
            this.lblCustomerPhone.TabIndex = 4;
            this.lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(10, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(89, 13);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(400, 20);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(150, 20);
            this.txtCustomerPhone.TabIndex = 2;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(150, 20);
            this.txtCustomerName.TabIndex = 1;
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
            this.pnlOrderHeader.ResumeLayout(false);
            this.pnlOrderHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlOrderFooter.ResumeLayout(false);
            this.pnlOrderFooter.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
