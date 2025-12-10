namespace HuongViet.GUI
{
    partial class FrmTable
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.lblTreeTitle = new System.Windows.Forms.Label();
			this.treeViewTables = new System.Windows.Forms.TreeView();
			this.pnlCenter = new System.Windows.Forms.Panel();
			this.grpAreaInfo = new System.Windows.Forms.GroupBox();
			this.pnlAreaButtons = new System.Windows.Forms.Panel();
			this.btnAreaAdd = new System.Windows.Forms.Button();
			this.btnAreaEdit = new System.Windows.Forms.Button();
			this.btnAreaDelete = new System.Windows.Forms.Button();
			this.btnAreaSave = new System.Windows.Forms.Button();
			this.btnAreaCancel = new System.Windows.Forms.Button();
			this.txtAreaName = new System.Windows.Forms.TextBox();
			this.lblAreaName = new System.Windows.Forms.Label();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.grpTableInfo = new System.Windows.Forms.GroupBox();
			this.pnlTableButtons = new System.Windows.Forms.Panel();
			this.btnTableAdd = new System.Windows.Forms.Button();
			this.btnTableEdit = new System.Windows.Forms.Button();
			this.btnTableDelete = new System.Windows.Forms.Button();
			this.btnTableSave = new System.Windows.Forms.Button();
			this.btnTableCancel = new System.Windows.Forms.Button();
			this.cmbTableStatus = new System.Windows.Forms.ComboBox();
			this.lblTableStatus = new System.Windows.Forms.Label();
			this.nudCapacity = new System.Windows.Forms.NumericUpDown();
			this.lblCapacity = new System.Windows.Forms.Label();
			this.cmbFloor = new System.Windows.Forms.ComboBox();
			this.lblFloor = new System.Windows.Forms.Label();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.lblTableName = new System.Windows.Forms.Label();
			this.pnlMain.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlCenter.SuspendLayout();
			this.grpAreaInfo.SuspendLayout();
			this.pnlAreaButtons.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.grpTableInfo.SuspendLayout();
			this.pnlTableButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.lblTitle);
			this.pnlMain.Controls.Add(this.btnRefresh);
			this.pnlMain.Controls.Add(this.pnlLeft);
			this.pnlMain.Controls.Add(this.pnlCenter);
			this.pnlMain.Controls.Add(this.pnlRight);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1414, 812);
			this.pnlMain.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(15, 16);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(158, 31);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý bàn";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.Location = new System.Drawing.Point(1065, 16);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(112, 32);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.lblTreeTitle);
			this.pnlLeft.Controls.Add(this.treeViewTables);
			this.pnlLeft.Location = new System.Drawing.Point(15, 65);
			this.pnlLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(650, 731);
			this.pnlLeft.TabIndex = 2;
			// 
			// lblTreeTitle
			// 
			this.lblTreeTitle.AutoSize = true;
			this.lblTreeTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTreeTitle.Location = new System.Drawing.Point(2, 1);
			this.lblTreeTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTreeTitle.Name = "lblTreeTitle";
			this.lblTreeTitle.Size = new System.Drawing.Size(78, 22);
			this.lblTreeTitle.TabIndex = 0;
			this.lblTreeTitle.Text = "Khu vực";
			// 
			// treeViewTables
			// 
			this.treeViewTables.BackColor = System.Drawing.Color.White;
			this.treeViewTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeViewTables.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.treeViewTables.FullRowSelect = true;
			this.treeViewTables.HideSelection = false;
			this.treeViewTables.ItemHeight = 30;
			this.treeViewTables.Location = new System.Drawing.Point(0, 28);
			this.treeViewTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.treeViewTables.Name = "treeViewTables";
			this.treeViewTables.Size = new System.Drawing.Size(648, 699);
			this.treeViewTables.TabIndex = 1;
			this.treeViewTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTables_AfterSelect);
			// 
			// pnlCenter
			// 
			this.pnlCenter.Controls.Add(this.grpAreaInfo);
			this.pnlCenter.Location = new System.Drawing.Point(670, 65);
			this.pnlCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlCenter.Name = "pnlCenter";
			this.pnlCenter.Size = new System.Drawing.Size(338, 731);
			this.pnlCenter.TabIndex = 3;
			// 
			// grpAreaInfo
			// 
			this.grpAreaInfo.Controls.Add(this.pnlAreaButtons);
			this.grpAreaInfo.Controls.Add(this.txtAreaName);
			this.grpAreaInfo.Controls.Add(this.lblAreaName);
			this.grpAreaInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
			this.grpAreaInfo.Location = new System.Drawing.Point(2, 2);
			this.grpAreaInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpAreaInfo.Name = "grpAreaInfo";
			this.grpAreaInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpAreaInfo.Size = new System.Drawing.Size(338, 203);
			this.grpAreaInfo.TabIndex = 0;
			this.grpAreaInfo.TabStop = false;
			this.grpAreaInfo.Text = "Quản lý khu vực";
			// 
			// pnlAreaButtons
			// 
			this.pnlAreaButtons.Controls.Add(this.btnAreaAdd);
			this.pnlAreaButtons.Controls.Add(this.btnAreaEdit);
			this.pnlAreaButtons.Controls.Add(this.btnAreaDelete);
			this.pnlAreaButtons.Controls.Add(this.btnAreaSave);
			this.pnlAreaButtons.Controls.Add(this.btnAreaCancel);
			this.pnlAreaButtons.Location = new System.Drawing.Point(15, 106);
			this.pnlAreaButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlAreaButtons.Name = "pnlAreaButtons";
			this.pnlAreaButtons.Size = new System.Drawing.Size(300, 85);
			this.pnlAreaButtons.TabIndex = 2;
			// 
			// btnAreaAdd
			// 
			this.btnAreaAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaAdd.Location = new System.Drawing.Point(0, 7);
			this.btnAreaAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAreaAdd.Name = "btnAreaAdd";
			this.btnAreaAdd.Size = new System.Drawing.Size(70, 32);
			this.btnAreaAdd.TabIndex = 0;
			this.btnAreaAdd.Text = "Thêm";
			this.btnAreaAdd.UseVisualStyleBackColor = true;
			// 
			// btnAreaEdit
			// 
			this.btnAreaEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaEdit.Location = new System.Drawing.Point(117, 7);
			this.btnAreaEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAreaEdit.Name = "btnAreaEdit";
			this.btnAreaEdit.Size = new System.Drawing.Size(70, 32);
			this.btnAreaEdit.TabIndex = 1;
			this.btnAreaEdit.Text = "Sửa";
			this.btnAreaEdit.UseVisualStyleBackColor = true;
			// 
			// btnAreaDelete
			// 
			this.btnAreaDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaDelete.Location = new System.Drawing.Point(226, 7);
			this.btnAreaDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAreaDelete.Name = "btnAreaDelete";
			this.btnAreaDelete.Size = new System.Drawing.Size(70, 32);
			this.btnAreaDelete.TabIndex = 2;
			this.btnAreaDelete.Text = "Xóa";
			this.btnAreaDelete.UseVisualStyleBackColor = true;
			// 
			// btnAreaSave
			// 
			this.btnAreaSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaSave.Location = new System.Drawing.Point(68, 44);
			this.btnAreaSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAreaSave.Name = "btnAreaSave";
			this.btnAreaSave.Size = new System.Drawing.Size(70, 32);
			this.btnAreaSave.TabIndex = 3;
			this.btnAreaSave.Text = "Lưu";
			this.btnAreaSave.UseVisualStyleBackColor = true;
			// 
			// btnAreaCancel
			// 
			this.btnAreaCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnAreaCancel.Location = new System.Drawing.Point(171, 44);
			this.btnAreaCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAreaCancel.Name = "btnAreaCancel";
			this.btnAreaCancel.Size = new System.Drawing.Size(70, 32);
			this.btnAreaCancel.TabIndex = 4;
			this.btnAreaCancel.Text = "Hủy";
			this.btnAreaCancel.UseVisualStyleBackColor = true;
			// 
			// txtAreaName
			// 
			this.txtAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.txtAreaName.Location = new System.Drawing.Point(15, 65);
			this.txtAreaName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtAreaName.Name = "txtAreaName";
			this.txtAreaName.Size = new System.Drawing.Size(301, 26);
			this.txtAreaName.TabIndex = 1;
			// 
			// lblAreaName
			// 
			this.lblAreaName.AutoSize = true;
			this.lblAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblAreaName.Location = new System.Drawing.Point(15, 41);
			this.lblAreaName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblAreaName.Name = "lblAreaName";
			this.lblAreaName.Size = new System.Drawing.Size(88, 19);
			this.lblAreaName.TabIndex = 0;
			this.lblAreaName.Text = "Tên khu vực:";
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.grpTableInfo);
			this.pnlRight.Location = new System.Drawing.Point(938, 65);
			this.pnlRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Size = new System.Drawing.Size(465, 731);
			this.pnlRight.TabIndex = 4;
			// 
			// grpTableInfo
			// 
			this.grpTableInfo.Controls.Add(this.pnlTableButtons);
			this.grpTableInfo.Controls.Add(this.cmbTableStatus);
			this.grpTableInfo.Controls.Add(this.lblTableStatus);
			this.grpTableInfo.Controls.Add(this.nudCapacity);
			this.grpTableInfo.Controls.Add(this.lblCapacity);
			this.grpTableInfo.Controls.Add(this.cmbFloor);
			this.grpTableInfo.Controls.Add(this.lblFloor);
			this.grpTableInfo.Controls.Add(this.txtTableName);
			this.grpTableInfo.Controls.Add(this.lblTableName);
			this.grpTableInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
			this.grpTableInfo.Location = new System.Drawing.Point(2, 20);
			this.grpTableInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpTableInfo.Name = "grpTableInfo";
			this.grpTableInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpTableInfo.Size = new System.Drawing.Size(461, 325);
			this.grpTableInfo.TabIndex = 0;
			this.grpTableInfo.TabStop = false;
			this.grpTableInfo.Text = "Thông tin bàn";
			// 
			// pnlTableButtons
			// 
			this.pnlTableButtons.Controls.Add(this.btnTableAdd);
			this.pnlTableButtons.Controls.Add(this.btnTableEdit);
			this.pnlTableButtons.Controls.Add(this.btnTableDelete);
			this.pnlTableButtons.Controls.Add(this.btnTableSave);
			this.pnlTableButtons.Controls.Add(this.btnTableCancel);
			this.pnlTableButtons.Location = new System.Drawing.Point(15, 179);
			this.pnlTableButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlTableButtons.Name = "pnlTableButtons";
			this.pnlTableButtons.Size = new System.Drawing.Size(428, 83);
			this.pnlTableButtons.TabIndex = 8;
			// 
			// btnTableAdd
			// 
			this.btnTableAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableAdd.Location = new System.Drawing.Point(47, 2);
			this.btnTableAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnTableAdd.Name = "btnTableAdd";
			this.btnTableAdd.Size = new System.Drawing.Size(88, 37);
			this.btnTableAdd.TabIndex = 0;
			this.btnTableAdd.Text = "Thêm";
			this.btnTableAdd.UseVisualStyleBackColor = true;
			// 
			// btnTableEdit
			// 
			this.btnTableEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableEdit.Location = new System.Drawing.Point(181, 2);
			this.btnTableEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnTableEdit.Name = "btnTableEdit";
			this.btnTableEdit.Size = new System.Drawing.Size(88, 37);
			this.btnTableEdit.TabIndex = 1;
			this.btnTableEdit.Text = "Sửa";
			this.btnTableEdit.UseVisualStyleBackColor = true;
			// 
			// btnTableDelete
			// 
			this.btnTableDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableDelete.Location = new System.Drawing.Point(315, 2);
			this.btnTableDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnTableDelete.Name = "btnTableDelete";
			this.btnTableDelete.Size = new System.Drawing.Size(88, 37);
			this.btnTableDelete.TabIndex = 2;
			this.btnTableDelete.Text = "Xóa";
			this.btnTableDelete.UseVisualStyleBackColor = true;
			// 
			// btnTableSave
			// 
			this.btnTableSave.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableSave.Location = new System.Drawing.Point(108, 43);
			this.btnTableSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnTableSave.Name = "btnTableSave";
			this.btnTableSave.Size = new System.Drawing.Size(88, 37);
			this.btnTableSave.TabIndex = 3;
			this.btnTableSave.Text = "Lưu";
			this.btnTableSave.UseVisualStyleBackColor = true;
			// 
			// btnTableCancel
			// 
			this.btnTableCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.btnTableCancel.Location = new System.Drawing.Point(242, 44);
			this.btnTableCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnTableCancel.Name = "btnTableCancel";
			this.btnTableCancel.Size = new System.Drawing.Size(88, 37);
			this.btnTableCancel.TabIndex = 4;
			this.btnTableCancel.Text = "Hủy";
			this.btnTableCancel.UseVisualStyleBackColor = true;
			// 
			// cmbTableStatus
			// 
			this.cmbTableStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTableStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.cmbTableStatus.FormattingEnabled = true;
			this.cmbTableStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang sử dụng",
            "Đang dọn dẹp",
            "Không khả dụng"});
			this.cmbTableStatus.Location = new System.Drawing.Point(105, 136);
			this.cmbTableStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cmbTableStatus.Name = "cmbTableStatus";
			this.cmbTableStatus.Size = new System.Drawing.Size(151, 27);
			this.cmbTableStatus.TabIndex = 7;
			// 
			// lblTableStatus
			// 
			this.lblTableStatus.AutoSize = true;
			this.lblTableStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblTableStatus.Location = new System.Drawing.Point(15, 138);
			this.lblTableStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTableStatus.Name = "lblTableStatus";
			this.lblTableStatus.Size = new System.Drawing.Size(71, 19);
			this.lblTableStatus.TabIndex = 6;
			this.lblTableStatus.Text = "Trạng thái:";
			// 
			// nudCapacity
			// 
			this.nudCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.nudCapacity.Location = new System.Drawing.Point(105, 104);
			this.nudCapacity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.nudCapacity.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudCapacity.Name = "nudCapacity";
			this.nudCapacity.Size = new System.Drawing.Size(90, 26);
			this.nudCapacity.TabIndex = 5;
			this.nudCapacity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// lblCapacity
			// 
			this.lblCapacity.AutoSize = true;
			this.lblCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblCapacity.Location = new System.Drawing.Point(15, 106);
			this.lblCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCapacity.Name = "lblCapacity";
			this.lblCapacity.Size = new System.Drawing.Size(71, 19);
			this.lblCapacity.TabIndex = 4;
			this.lblCapacity.Text = "Sức chứa:";
			// 
			// cmbFloor
			// 
			this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFloor.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.cmbFloor.FormattingEnabled = true;
			this.cmbFloor.Location = new System.Drawing.Point(105, 71);
			this.cmbFloor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cmbFloor.Name = "cmbFloor";
			this.cmbFloor.Size = new System.Drawing.Size(338, 27);
			this.cmbFloor.TabIndex = 3;
			// 
			// lblFloor
			// 
			this.lblFloor.AutoSize = true;
			this.lblFloor.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblFloor.Location = new System.Drawing.Point(15, 73);
			this.lblFloor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblFloor.Name = "lblFloor";
			this.lblFloor.Size = new System.Drawing.Size(65, 19);
			this.lblFloor.TabIndex = 2;
			this.lblFloor.Text = "Khu vực:";
			// 
			// txtTableName
			// 
			this.txtTableName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.txtTableName.Location = new System.Drawing.Point(105, 38);
			this.txtTableName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(338, 26);
			this.txtTableName.TabIndex = 1;
			// 
			// lblTableName
			// 
			this.lblTableName.AutoSize = true;
			this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lblTableName.Location = new System.Drawing.Point(15, 41);
			this.lblTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(61, 19);
			this.lblTableName.TabIndex = 0;
			this.lblTableName.Text = "Tên bàn:";
			// 
			// FrmTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1414, 812);
			this.Controls.Add(this.pnlMain);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FrmTable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý bàn";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmTable_Load);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.pnlLeft.ResumeLayout(false);
			this.pnlLeft.PerformLayout();
			this.pnlCenter.ResumeLayout(false);
			this.grpAreaInfo.ResumeLayout(false);
			this.grpAreaInfo.PerformLayout();
			this.pnlAreaButtons.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.grpTableInfo.ResumeLayout(false);
			this.grpTableInfo.PerformLayout();
			this.pnlTableButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTreeTitle;
        private System.Windows.Forms.TreeView treeViewTables;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.GroupBox grpAreaInfo;
        private System.Windows.Forms.Panel pnlAreaButtons;
        private System.Windows.Forms.Button btnAreaCancel;
        private System.Windows.Forms.Button btnAreaSave;
        private System.Windows.Forms.Button btnAreaDelete;
        private System.Windows.Forms.Button btnAreaEdit;
        private System.Windows.Forms.Button btnAreaAdd;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpTableInfo;
        private System.Windows.Forms.Panel pnlTableButtons;
        private System.Windows.Forms.Button btnTableCancel;
        private System.Windows.Forms.Button btnTableSave;
        private System.Windows.Forms.Button btnTableDelete;
        private System.Windows.Forms.Button btnTableEdit;
        private System.Windows.Forms.Button btnTableAdd;
        private System.Windows.Forms.ComboBox cmbTableStatus;
        private System.Windows.Forms.Label lblTableStatus;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
    }
}