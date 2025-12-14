namespace HuongViet.GUI
{
    partial class FrmCreateCustomer
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
            this.grpCustomerInfo = new System.Windows.Forms.GroupBox();
            this.dtpCustomerDOB = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerDOB = new System.Windows.Forms.Label();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.txtCustomerPhoneNum = new System.Windows.Forms.TextBox();
            this.lblCustomerPhoneNum = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpCustomerInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpCustomerInfo);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(600, 400);
            this.pnlMain.TabIndex = 0;
            // 
            // grpCustomerInfo
            // 
            this.grpCustomerInfo.Controls.Add(this.dtpCustomerDOB);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerDOB);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerEmail);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerEmail);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerPhoneNum);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerPhoneNum);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerName);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerName);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerID);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerID);
            this.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomerInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.grpCustomerInfo.Location = new System.Drawing.Point(10, 10);
            this.grpCustomerInfo.Name = "grpCustomerInfo";
            this.grpCustomerInfo.Padding = new System.Windows.Forms.Padding(15);
            this.grpCustomerInfo.Size = new System.Drawing.Size(580, 320);
            this.grpCustomerInfo.TabIndex = 0;
            this.grpCustomerInfo.TabStop = false;
            this.grpCustomerInfo.Text = "Thông tin khách hàng";
            // 
            // dtpCustomerDOB
            // 
            this.dtpCustomerDOB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpCustomerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustomerDOB.Location = new System.Drawing.Point(18, 280);
            this.dtpCustomerDOB.Name = "dtpCustomerDOB";
            this.dtpCustomerDOB.Size = new System.Drawing.Size(260, 26);
            this.dtpCustomerDOB.TabIndex = 5;
            this.dtpCustomerDOB.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblCustomerDOB
            // 
            this.lblCustomerDOB.AutoSize = true;
            this.lblCustomerDOB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerDOB.Location = new System.Drawing.Point(18, 258);
            this.lblCustomerDOB.Name = "lblCustomerDOB";
            this.lblCustomerDOB.Size = new System.Drawing.Size(87, 19);
            this.lblCustomerDOB.TabIndex = 8;
            this.lblCustomerDOB.Text = "Ngày sinh:";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCustomerEmail.Location = new System.Drawing.Point(298, 220);
            this.txtCustomerEmail.MaxLength = 100;
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(260, 26);
            this.txtCustomerEmail.TabIndex = 4;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerEmail.Location = new System.Drawing.Point(298, 198);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(50, 19);
            this.lblCustomerEmail.TabIndex = 6;
            this.lblCustomerEmail.Text = "Email:";
            // 
            // txtCustomerPhoneNum
            // 
            this.txtCustomerPhoneNum.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCustomerPhoneNum.Location = new System.Drawing.Point(18, 220);
            this.txtCustomerPhoneNum.MaxLength = 15;
            this.txtCustomerPhoneNum.Name = "txtCustomerPhoneNum";
            this.txtCustomerPhoneNum.Size = new System.Drawing.Size(260, 26);
            this.txtCustomerPhoneNum.TabIndex = 3;
            // 
            // lblCustomerPhoneNum
            // 
            this.lblCustomerPhoneNum.AutoSize = true;
            this.lblCustomerPhoneNum.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerPhoneNum.Location = new System.Drawing.Point(18, 198);
            this.lblCustomerPhoneNum.Name = "lblCustomerPhoneNum";
            this.lblCustomerPhoneNum.Size = new System.Drawing.Size(100, 19);
            this.lblCustomerPhoneNum.TabIndex = 4;
            this.lblCustomerPhoneNum.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCustomerName.Location = new System.Drawing.Point(18, 160);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(540, 26);
            this.txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerName.Location = new System.Drawing.Point(18, 138);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(108, 19);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCustomerID.Location = new System.Drawing.Point(18, 100);
            this.txtCustomerID.MaxLength = 255;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(260, 26);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.TabStop = false;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCustomerID.Location = new System.Drawing.Point(18, 78);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(100, 19);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Mã khách hàng:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(10, 330);
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
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmCreateCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo khách hàng mới";
            this.Load += new System.EventHandler(this.FrmCreateCustomer_Load);
            this.pnlMain.ResumeLayout(false);
            this.grpCustomerInfo.ResumeLayout(false);
            this.grpCustomerInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpCustomerInfo;
        private System.Windows.Forms.DateTimePicker dtpCustomerDOB;
        private System.Windows.Forms.Label lblCustomerDOB;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerPhoneNum;
        private System.Windows.Forms.Label lblCustomerPhoneNum;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}