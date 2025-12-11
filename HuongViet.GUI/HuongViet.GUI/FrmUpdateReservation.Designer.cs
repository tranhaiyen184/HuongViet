namespace HuongViet.GUI
{
    partial class FrmUpdateReservation
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpReservationInfo = new System.Windows.Forms.GroupBox();
            this.txtSpecialRequests = new System.Windows.Forms.TextBox();
            this.lblSpecialRequests = new System.Windows.Forms.Label();
            this.nudDepositAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmbReservationStatus = new System.Windows.Forms.ComboBox();
            this.lblReservationStatus = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.nudNumberOfGuests = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfGuests = new System.Windows.Forms.Label();
            this.dtpReservationTime = new System.Windows.Forms.DateTimePicker();
            this.lblReservationTime = new System.Windows.Forms.Label();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.lblReservationDate = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtContactPhone = new System.Windows.Forms.TextBox();
            this.lblContactPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpReservationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfGuests)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpReservationInfo);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(600, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // grpReservationInfo
            // 
            this.grpReservationInfo.Controls.Add(this.txtSpecialRequests);
            this.grpReservationInfo.Controls.Add(this.lblSpecialRequests);
            this.grpReservationInfo.Controls.Add(this.nudDepositAmount);
            this.grpReservationInfo.Controls.Add(this.lblDepositAmount);
            this.grpReservationInfo.Controls.Add(this.nudDuration);
            this.grpReservationInfo.Controls.Add(this.lblDuration);
            this.grpReservationInfo.Controls.Add(this.cmbReservationStatus);
            this.grpReservationInfo.Controls.Add(this.lblReservationStatus);
            this.grpReservationInfo.Controls.Add(this.cmbRoom);
            this.grpReservationInfo.Controls.Add(this.lblRoom);
            this.grpReservationInfo.Controls.Add(this.cmbTable);
            this.grpReservationInfo.Controls.Add(this.lblTable);
            this.grpReservationInfo.Controls.Add(this.nudNumberOfGuests);
            this.grpReservationInfo.Controls.Add(this.lblNumberOfGuests);
            this.grpReservationInfo.Controls.Add(this.dtpReservationTime);
            this.grpReservationInfo.Controls.Add(this.lblReservationTime);
            this.grpReservationInfo.Controls.Add(this.dtpReservationDate);
            this.grpReservationInfo.Controls.Add(this.lblReservationDate);
            this.grpReservationInfo.Controls.Add(this.cmbCustomer);
            this.grpReservationInfo.Controls.Add(this.lblCustomer);
            this.grpReservationInfo.Controls.Add(this.txtContactPhone);
            this.grpReservationInfo.Controls.Add(this.lblContactPhone);
            this.grpReservationInfo.Controls.Add(this.txtCustomerName);
            this.grpReservationInfo.Controls.Add(this.lblCustomerName);
            this.grpReservationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReservationInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.grpReservationInfo.Location = new System.Drawing.Point(10, 10);
            this.grpReservationInfo.Name = "grpReservationInfo";
            this.grpReservationInfo.Padding = new System.Windows.Forms.Padding(15);
            this.grpReservationInfo.Size = new System.Drawing.Size(580, 620);
            this.grpReservationInfo.TabIndex = 0;
            this.grpReservationInfo.TabStop = false;
            this.grpReservationInfo.Text = "Cập nhật thông tin đặt bàn";
            // 
            // txtSpecialRequests
            // 
            this.txtSpecialRequests.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtSpecialRequests.Location = new System.Drawing.Point(18, 560);
            this.txtSpecialRequests.Multiline = true;
            this.txtSpecialRequests.Name = "txtSpecialRequests";
            this.txtSpecialRequests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecialRequests.Size = new System.Drawing.Size(540, 50);
            this.txtSpecialRequests.TabIndex = 16;
            // 
            // lblSpecialRequests
            // 
            this.lblSpecialRequests.AutoSize = true;
            this.lblSpecialRequests.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSpecialRequests.Location = new System.Drawing.Point(18, 538);
            this.lblSpecialRequests.Name = "lblSpecialRequests";
            this.lblSpecialRequests.Size = new System.Drawing.Size(113, 19);
            this.lblSpecialRequests.TabIndex = 15;
            this.lblSpecialRequests.Text = "Yêu cầu đặc biệt:";
            // 
            // nudDepositAmount
            // 
            this.nudDepositAmount.DecimalPlaces = 2;
            this.nudDepositAmount.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudDepositAmount.Location = new System.Drawing.Point(18, 500);
            this.nudDepositAmount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudDepositAmount.Name = "nudDepositAmount";
            this.nudDepositAmount.Size = new System.Drawing.Size(260, 26);
            this.nudDepositAmount.TabIndex = 14;
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDepositAmount.Location = new System.Drawing.Point(18, 478);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(80, 19);
            this.lblDepositAmount.TabIndex = 13;
            this.lblDepositAmount.Text = "Tiền cọc:";
            // 
            // nudDuration
            // 
            this.nudDuration.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudDuration.Location = new System.Drawing.Point(298, 500);
            this.nudDuration.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(260, 26);
            this.nudDuration.TabIndex = 15;
            this.nudDuration.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDuration.Location = new System.Drawing.Point(298, 478);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(100, 19);
            this.lblDuration.TabIndex = 11;
            this.lblDuration.Text = "Thời lượng (h):";
            // 
            // cmbReservationStatus
            // 
            this.cmbReservationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReservationStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbReservationStatus.FormattingEnabled = true;
            this.cmbReservationStatus.Items.AddRange(new object[] {
            "Chờ xác nhận",
            "Đã xác nhận",
            "Đã hủy"});
            this.cmbReservationStatus.Location = new System.Drawing.Point(18, 440);
            this.cmbReservationStatus.Name = "cmbReservationStatus";
            this.cmbReservationStatus.Size = new System.Drawing.Size(260, 27);
            this.cmbReservationStatus.TabIndex = 12;
            // 
            // lblReservationStatus
            // 
            this.lblReservationStatus.AutoSize = true;
            this.lblReservationStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblReservationStatus.Location = new System.Drawing.Point(18, 418);
            this.lblReservationStatus.Name = "lblReservationStatus";
            this.lblReservationStatus.Size = new System.Drawing.Size(85, 19);
            this.lblReservationStatus.TabIndex = 9;
            this.lblReservationStatus.Text = "Trạng thái:";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(298, 380);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(260, 27);
            this.cmbRoom.TabIndex = 11;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblRoom.Location = new System.Drawing.Point(298, 358);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(55, 19);
            this.lblRoom.TabIndex = 7;
            this.lblRoom.Text = "Phòng:";
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(18, 380);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(260, 27);
            this.cmbTable.TabIndex = 10;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTable.Location = new System.Drawing.Point(18, 358);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(40, 19);
            this.lblTable.TabIndex = 5;
            this.lblTable.Text = "Bàn:";
            // 
            // nudNumberOfGuests
            // 
            this.nudNumberOfGuests.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudNumberOfGuests.Location = new System.Drawing.Point(18, 320);
            this.nudNumberOfGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfGuests.Name = "nudNumberOfGuests";
            this.nudNumberOfGuests.Size = new System.Drawing.Size(260, 26);
            this.nudNumberOfGuests.TabIndex = 9;
            this.nudNumberOfGuests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfGuests
            // 
            this.lblNumberOfGuests.AutoSize = true;
            this.lblNumberOfGuests.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNumberOfGuests.Location = new System.Drawing.Point(18, 298);
            this.lblNumberOfGuests.Name = "lblNumberOfGuests";
            this.lblNumberOfGuests.Size = new System.Drawing.Size(75, 19);
            this.lblNumberOfGuests.TabIndex = 3;
            this.lblNumberOfGuests.Text = "Số khách:";
            // 
            // dtpReservationTime
            // 
            this.dtpReservationTime.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpReservationTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpReservationTime.Location = new System.Drawing.Point(298, 260);
            this.dtpReservationTime.Name = "dtpReservationTime";
            this.dtpReservationTime.ShowUpDown = true;
            this.dtpReservationTime.Size = new System.Drawing.Size(260, 26);
            this.dtpReservationTime.TabIndex = 8;
            // 
            // lblReservationTime
            // 
            this.lblReservationTime.AutoSize = true;
            this.lblReservationTime.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblReservationTime.Location = new System.Drawing.Point(298, 238);
            this.lblReservationTime.Name = "lblReservationTime";
            this.lblReservationTime.Size = new System.Drawing.Size(66, 19);
            this.lblReservationTime.TabIndex = 2;
            this.lblReservationTime.Text = "Giờ đặt:";
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReservationDate.Location = new System.Drawing.Point(18, 260);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(260, 26);
            this.dtpReservationDate.TabIndex = 7;
            // 
            // lblReservationDate
            // 
            this.lblReservationDate.AutoSize = true;
            this.lblReservationDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblReservationDate.Location = new System.Drawing.Point(18, 238);
            this.lblReservationDate.Name = "lblReservationDate";
            this.lblReservationDate.Size = new System.Drawing.Size(71, 19);
            this.lblReservationDate.TabIndex = 1;
            this.lblReservationDate.Text = "Ngày đặt:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(18, 140);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(540, 27);
            this.cmbCustomer.TabIndex = 5;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomer.Location = new System.Drawing.Point(18, 118);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(130, 19);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Khách hàng (nếu có):";
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtContactPhone.Location = new System.Drawing.Point(298, 80);
            this.txtContactPhone.MaxLength = 15;
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.Size = new System.Drawing.Size(260, 26);
            this.txtContactPhone.TabIndex = 4;
            // 
            // lblContactPhone
            // 
            this.lblContactPhone.AutoSize = true;
            this.lblContactPhone.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblContactPhone.Location = new System.Drawing.Point(298, 58);
            this.lblContactPhone.Name = "lblContactPhone";
            this.lblContactPhone.Size = new System.Drawing.Size(100, 19);
            this.lblContactPhone.TabIndex = 2;
            this.lblContactPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCustomerName.Location = new System.Drawing.Point(18, 80);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(260, 26);
            this.txtCustomerName.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerName.Location = new System.Drawing.Point(18, 58);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(108, 19);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(10, 630);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(580, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(300, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(160, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmUpdateReservation
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật đặt bàn";
            this.pnlMain.ResumeLayout(false);
            this.grpReservationInfo.ResumeLayout(false);
            this.grpReservationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfGuests)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpReservationInfo;
        private System.Windows.Forms.TextBox txtSpecialRequests;
        private System.Windows.Forms.Label lblSpecialRequests;
        private System.Windows.Forms.NumericUpDown nudDepositAmount;
        private System.Windows.Forms.Label lblDepositAmount;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cmbReservationStatus;
        private System.Windows.Forms.Label lblReservationStatus;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.NumericUpDown nudNumberOfGuests;
        private System.Windows.Forms.Label lblNumberOfGuests;
        private System.Windows.Forms.DateTimePicker dtpReservationTime;
        private System.Windows.Forms.Label lblReservationTime;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label lblReservationDate;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtContactPhone;
        private System.Windows.Forms.Label lblContactPhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}