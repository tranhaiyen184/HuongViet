namespace HuongViet.GUI
{
    partial class FrmAreaManagement
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvAreas = new System.Windows.Forms.DataGridView();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpAreaInfo = new System.Windows.Forms.GroupBox();
			this.txtAreaName = new System.Windows.Forms.TextBox();
			this.lblAreaName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
			this.pnlForm.SuspendLayout();
			this.grpAreaInfo.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlContent);
			this.pnlMain.Controls.Add(this.pnlForm);
			this.pnlMain.Controls.Add(this.pnlHeader);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlMain.Size = new System.Drawing.Size(965, 525);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.dgvAreas);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(13, 74);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.pnlContent.Size = new System.Drawing.Size(640, 439);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvAreas
			// 
			this.dgvAreas.AllowUserToAddRows = false;
			this.dgvAreas.AllowUserToDeleteRows = false;
			this.dgvAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAreas.BackgroundColor = System.Drawing.Color.White;
			this.dgvAreas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvAreas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAreas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvAreas.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvAreas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAreas.Location = new System.Drawing.Point(0, 12);
			this.dgvAreas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvAreas.MultiSelect = false;
			this.dgvAreas.Name = "dgvAreas";
			this.dgvAreas.ReadOnly = true;
			this.dgvAreas.RowHeadersVisible = false;
			this.dgvAreas.RowHeadersWidth = 51;
			this.dgvAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAreas.Size = new System.Drawing.Size(640, 427);
			this.dgvAreas.TabIndex = 0;
			this.dgvAreas.SelectionChanged += new System.EventHandler(this.dgvAreas_SelectionChanged);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpAreaInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlForm.Location = new System.Drawing.Point(653, 74);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Padding = new System.Windows.Forms.Padding(13, 12, 0, 0);
			this.pnlForm.Size = new System.Drawing.Size(299, 439);
			this.pnlForm.TabIndex = 1;
			// 
			// grpAreaInfo
			// 
			this.grpAreaInfo.Controls.Add(this.txtAreaName);
			this.grpAreaInfo.Controls.Add(this.lblAreaName);
			this.grpAreaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpAreaInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpAreaInfo.Location = new System.Drawing.Point(13, 12);
			this.grpAreaInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grpAreaInfo.Name = "grpAreaInfo";
			this.grpAreaInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpAreaInfo.Size = new System.Drawing.Size(286, 316);
			this.grpAreaInfo.TabIndex = 1;
			this.grpAreaInfo.TabStop = false;
			this.grpAreaInfo.Text = "Thông tin khu vực";
			// 
			// txtAreaName
			// 
			this.txtAreaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAreaName.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAreaName.Location = new System.Drawing.Point(28, 83);
			this.txtAreaName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtAreaName.MaxLength = 30;
			this.txtAreaName.Name = "txtAreaName";
			this.txtAreaName.Size = new System.Drawing.Size(237, 30);
			this.txtAreaName.TabIndex = 0;
			// 
			// lblAreaName
			// 
			this.lblAreaName.AutoSize = true;
			this.lblAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblAreaName.Location = new System.Drawing.Point(20, 45);
			this.lblAreaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAreaName.Name = "lblAreaName";
			this.lblAreaName.Size = new System.Drawing.Size(113, 22);
			this.lblAreaName.TabIndex = 0;
			this.lblAreaName.Text = "Tên khu vực:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnSave);
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtons.Location = new System.Drawing.Point(13, 328);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.pnlButtons.Size = new System.Drawing.Size(286, 111);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnCancel.Location = new System.Drawing.Point(155, 68);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(125, 37);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnSave.Location = new System.Drawing.Point(16, 68);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 37);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnDelete.Location = new System.Drawing.Point(195, 12);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(89, 43);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnEdit.Location = new System.Drawing.Point(102, 12);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(89, 43);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAdd.Location = new System.Drawing.Point(9, 12);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(89, 43);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(939, 62);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(4, 18);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(215, 32);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý khu vực";
			this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
			// 
			// FrmAreaManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 525);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAreaManagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Quản lý khu vực";
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
			this.pnlForm.ResumeLayout(false);
			this.grpAreaInfo.ResumeLayout(false);
			this.grpAreaInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpAreaInfo;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}

