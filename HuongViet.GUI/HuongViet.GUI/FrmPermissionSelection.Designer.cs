namespace HuongViet.GUI
{
    partial class FrmPermissionSelection
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
			this.flpPermissions = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnDeselectAll = new System.Windows.Forms.Button();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlContent);
			this.pnlMain.Controls.Add(this.pnlHeader);
			this.pnlMain.Controls.Add(this.pnlFooter);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlMain.Size = new System.Drawing.Size(800, 615);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.flpPermissions);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(13, 98);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlContent.Size = new System.Drawing.Size(774, 431);
			this.pnlContent.TabIndex = 2;
			// 
			// flpPermissions
			// 
			this.flpPermissions.AutoScroll = true;
			this.flpPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpPermissions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPermissions.Location = new System.Drawing.Point(13, 12);
			this.flpPermissions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.flpPermissions.Name = "flpPermissions";
			this.flpPermissions.Size = new System.Drawing.Size(748, 407);
			this.flpPermissions.TabIndex = 0;
			this.flpPermissions.WrapContents = false;
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(774, 86);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(310, 23);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(172, 32);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "PHÂN QUYỀN";
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnDeselectAll);
			this.pnlFooter.Controls.Add(this.btnSelectAll);
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(13, 529);
			this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlFooter.Size = new System.Drawing.Size(774, 74);
			this.pnlFooter.TabIndex = 1;
			// 
			// btnDeselectAll
			// 
			this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnDeselectAll.Location = new System.Drawing.Point(160, 16);
			this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDeselectAll.Name = "btnDeselectAll";
			this.btnDeselectAll.Size = new System.Drawing.Size(133, 37);
			this.btnDeselectAll.TabIndex = 2;
			this.btnDeselectAll.Text = "Bỏ chọn tất cả";
			this.btnDeselectAll.UseVisualStyleBackColor = true;
			this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnSelectAll.Location = new System.Drawing.Point(26, 16);
			this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(133, 37);
			this.btnSelectAll.TabIndex = 1;
			this.btnSelectAll.Text = "Chọn tất cả";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnOK);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(468, 12);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(293, 50);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnCancel.Location = new System.Drawing.Point(153, 0);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(133, 43);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnOK.Location = new System.Drawing.Point(7, 0);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(133, 43);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Xác nhận";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// FrmPermissionSelection
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(800, 615);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPermissionSelection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Chọn quyền";
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flpPermissions;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}

