namespace HuongViet.GUI
{
    partial class FrmVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvVouchers = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.grpVoucherInfo = new System.Windows.Forms.GroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.nudUsageLimit = new System.Windows.Forms.NumericUpDown();
            this.lblUsageLimit = new System.Windows.Forms.Label();
            this.dtpEndAt = new System.Windows.Forms.DateTimePicker();
            this.lblEndAt = new System.Windows.Forms.Label();
            this.dtpStartAt = new System.Windows.Forms.DateTimePicker();
            this.lblStartAt = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.nudPercentage = new System.Windows.Forms.NumericUpDown();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.grpVoucherInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsageLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentage)).BeginInit();
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
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1440, 878);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvVouchers);
            this.pnlContent.Location = new System.Drawing.Point(10, 106);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1110, 762);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvVouchers
            // 
            this.dgvVouchers.AllowUserToAddRows = false;
            this.dgvVouchers.AllowUserToDeleteRows = false;
            this.dgvVouchers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVouchers.BackgroundColor = System.Drawing.Color.White;
            this.dgvVouchers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVouchers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVouchers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVouchers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVouchers.Location = new System.Drawing.Point(0, 0);
            this.dgvVouchers.MultiSelect = false;
            this.dgvVouchers.Name = "dgvVouchers";
            this.dgvVouchers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVouchers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVouchers.RowHeadersVisible = false;
            this.dgvVouchers.RowHeadersWidth = 51;
            this.dgvVouchers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVouchers.Size = new System.Drawing.Size(1110, 762);
            this.dgvVouchers.TabIndex = 0;
            this.dgvVouchers.SelectionChanged += new System.EventHandler(this.dgvVouchers_SelectionChanged);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.grpVoucherInfo);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Location = new System.Drawing.Point(1130, 106);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(300, 762);
            this.pnlForm.TabIndex = 1;
            // 
            // grpVoucherInfo
            // 
            this.grpVoucherInfo.Controls.Add(this.chkActive);
            this.grpVoucherInfo.Controls.Add(this.nudUsageLimit);
            this.grpVoucherInfo.Controls.Add(this.lblUsageLimit);
            this.grpVoucherInfo.Controls.Add(this.dtpEndAt);
            this.grpVoucherInfo.Controls.Add(this.lblEndAt);
            this.grpVoucherInfo.Controls.Add(this.dtpStartAt);
            this.grpVoucherInfo.Controls.Add(this.lblStartAt);
            this.grpVoucherInfo.Controls.Add(this.txtDescription);
            this.grpVoucherInfo.Controls.Add(this.lblDescription);
            this.grpVoucherInfo.Controls.Add(this.nudPercentage);
            this.grpVoucherInfo.Controls.Add(this.lblPercentage);
            this.grpVoucherInfo.Controls.Add(this.txtCode);
            this.grpVoucherInfo.Controls.Add(this.lblCode);
            this.grpVoucherInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVoucherInfo.Location = new System.Drawing.Point(10, 10);
            this.grpVoucherInfo.Name = "grpVoucherInfo";
            this.grpVoucherInfo.Padding = new System.Windows.Forms.Padding(15);
            this.grpVoucherInfo.Size = new System.Drawing.Size(280, 520);
            this.grpVoucherInfo.TabIndex = 1;
            this.grpVoucherInfo.TabStop = false;
            this.grpVoucherInfo.Text = "Thông tin voucher";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.chkActive.Location = new System.Drawing.Point(18, 480);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(75, 23);
            this.chkActive.TabIndex = 12;
            this.chkActive.Text = "Kích hoạt";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // nudUsageLimit
            // 
            this.nudUsageLimit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudUsageLimit.Location = new System.Drawing.Point(18, 440);
            this.nudUsageLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudUsageLimit.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudUsageLimit.Name = "nudUsageLimit";
            this.nudUsageLimit.Size = new System.Drawing.Size(244, 26);
            this.nudUsageLimit.TabIndex = 11;
            // 
            // lblUsageLimit
            // 
            this.lblUsageLimit.AutoSize = true;
            this.lblUsageLimit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblUsageLimit.Location = new System.Drawing.Point(18, 418);
            this.lblUsageLimit.Name = "lblUsageLimit";
            this.lblUsageLimit.Size = new System.Drawing.Size(130, 19);
            this.lblUsageLimit.TabIndex = 10;
            this.lblUsageLimit.Text = "Giới hạn sử dụng:";
            // 
            // dtpEndAt
            // 
            this.dtpEndAt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpEndAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndAt.Location = new System.Drawing.Point(18, 375);
            this.dtpEndAt.Name = "dtpEndAt";
            this.dtpEndAt.ShowCheckBox = true;
            this.dtpEndAt.Size = new System.Drawing.Size(244, 26);
            this.dtpEndAt.TabIndex = 9;
            // 
            // lblEndAt
            // 
            this.lblEndAt.AutoSize = true;
            this.lblEndAt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblEndAt.Location = new System.Drawing.Point(18, 353);
            this.lblEndAt.Name = "lblEndAt";
            this.lblEndAt.Size = new System.Drawing.Size(95, 19);
            this.lblEndAt.TabIndex = 8;
            this.lblEndAt.Text = "Ngày kết thúc:";
            // 
            // dtpStartAt
            // 
            this.dtpStartAt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpStartAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartAt.Location = new System.Drawing.Point(18, 310);
            this.dtpStartAt.Name = "dtpStartAt";
            this.dtpStartAt.ShowCheckBox = true;
            this.dtpStartAt.Size = new System.Drawing.Size(244, 26);
            this.dtpStartAt.TabIndex = 7;
            // 
            // lblStartAt
            // 
            this.lblStartAt.AutoSize = true;
            this.lblStartAt.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblStartAt.Location = new System.Drawing.Point(18, 288);
            this.lblStartAt.Name = "lblStartAt";
            this.lblStartAt.Size = new System.Drawing.Size(90, 19);
            this.lblStartAt.TabIndex = 6;
            this.lblStartAt.Text = "Ngày bắt đầu:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtDescription.Location = new System.Drawing.Point(18, 200);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(244, 70);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDescription.Location = new System.Drawing.Point(18, 178);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(50, 19);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả:";
            // 
            // nudPercentage
            // 
            this.nudPercentage.DecimalPlaces = 2;
            this.nudPercentage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudPercentage.Location = new System.Drawing.Point(18, 135);
            this.nudPercentage.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPercentage.Name = "nudPercentage";
            this.nudPercentage.Size = new System.Drawing.Size(244, 26);
            this.nudPercentage.TabIndex = 3;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPercentage.Location = new System.Drawing.Point(18, 113);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(100, 19);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Text = "Phần trăm (%):";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(18, 68);
            this.txtCode.MaxLength = 64;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(244, 32);
            this.txtCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblCode.Location = new System.Drawing.Point(18, 44);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(88, 21);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Mã voucher:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Location = new System.Drawing.Point(10, 540);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(280, 90);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Location = new System.Drawing.Point(145, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.Location = new System.Drawing.Point(35, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.Location = new System.Drawing.Point(184, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEdit.Location = new System.Drawing.Point(109, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.Location = new System.Drawing.Point(33, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pnlSearch);
            this.pnlHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1420, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1420, 86);
            this.pnlSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblSearch.Location = new System.Drawing.Point(15, 45);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 21);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.btnRefresh.Location = new System.Drawing.Point(1264, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 38);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.btnSearch.Location = new System.Drawing.Point(1130, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 38);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtSearch.Location = new System.Drawing.Point(89, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1021, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 878);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý voucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.grpVoucherInfo.ResumeLayout(false);
            this.grpVoucherInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsageLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentage)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvVouchers;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpVoucherInfo;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.NumericUpDown nudUsageLimit;
        private System.Windows.Forms.Label lblUsageLimit;
        private System.Windows.Forms.DateTimePicker dtpEndAt;
        private System.Windows.Forms.Label lblEndAt;
        private System.Windows.Forms.DateTimePicker dtpStartAt;
        private System.Windows.Forms.Label lblStartAt;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.NumericUpDown nudPercentage;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
