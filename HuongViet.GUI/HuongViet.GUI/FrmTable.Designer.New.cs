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
            this.btnAreaCancel = new System.Windows.Forms.Button();
            this.btnAreaSave = new System.Windows.Forms.Button();
            this.btnAreaDelete = new System.Windows.Forms.Button();
            this.btnAreaEdit = new System.Windows.Forms.Button();
            this.btnAreaAdd = new System.Windows.Forms.Button();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpTableInfo = new System.Windows.Forms.GroupBox();
            this.pnlTableButtons = new System.Windows.Forms.Panel();
            this.btnTableCancel = new System.Windows.Forms.Button();
            this.btnTableSave = new System.Windows.Forms.Button();
            this.btnTableDelete = new System.Windows.Forms.Button();
            this.btnTableEdit = new System.Windows.Forms.Button();
            this.btnTableAdd = new System.Windows.Forms.Button();
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
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1600, 1000);
            this.pnlMain.TabIndex = 0;
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý bàn";
            
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.btnRefresh.Location = new System.Drawing.Point(1420, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblTreeTitle);
            this.pnlLeft.Controls.Add(this.treeViewTables);
            this.pnlLeft.Location = new System.Drawing.Point(20, 80);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(450, 900);
            this.pnlLeft.TabIndex = 2;
            
            // 
            // lblTreeTitle
            // 
            this.lblTreeTitle.AutoSize = true;
            this.lblTreeTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblTreeTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTreeTitle.Name = "lblTreeTitle";
            this.lblTreeTitle.Size = new System.Drawing.Size(126, 31);
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
            this.treeViewTables.Location = new System.Drawing.Point(0, 40);
            this.treeViewTables.Name = "treeViewTables";
            this.treeViewTables.ShowLines = true;
            this.treeViewTables.ShowPlusMinus = true;
            this.treeViewTables.ShowRootLines = true;
            this.treeViewTables.Size = new System.Drawing.Size(450, 860);
            this.treeViewTables.TabIndex = 1;
            this.treeViewTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTables_AfterSelect);
            
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpAreaInfo);
            this.pnlCenter.Location = new System.Drawing.Point(490, 80);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(450, 900);
            this.pnlCenter.TabIndex = 3;
            
            // 
            // grpAreaInfo
            // 
            this.grpAreaInfo.Controls.Add(this.pnlAreaButtons);
            this.grpAreaInfo.Controls.Add(this.txtAreaName);
            this.grpAreaInfo.Controls.Add(this.lblAreaName);
            this.grpAreaInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.grpAreaInfo.Location = new System.Drawing.Point(0, 0);
            this.grpAreaInfo.Name = "grpAreaInfo";
            this.grpAreaInfo.Size = new System.Drawing.Size(450, 250);
            this.grpAreaInfo.TabIndex = 0;
            this.grpAreaInfo.TabStop = false;
            this.grpAreaInfo.Text = "Quản lý khu vực";
            
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblAreaName.Location = new System.Drawing.Point(20, 50);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(103, 22);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "Tên khu vực:";
            
            // 
            // txtAreaName
            // 
            this.txtAreaName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtAreaName.Location = new System.Drawing.Point(20, 80);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(400, 30);
            this.txtAreaName.TabIndex = 1;
            
            // 
            // pnlAreaButtons
            // 
            this.pnlAreaButtons.Controls.Add(this.btnAreaAdd);
            this.pnlAreaButtons.Controls.Add(this.btnAreaEdit);
            this.pnlAreaButtons.Controls.Add(this.btnAreaDelete);
            this.pnlAreaButtons.Controls.Add(this.btnAreaSave);
            this.pnlAreaButtons.Controls.Add(this.btnAreaCancel);
            this.pnlAreaButtons.Location = new System.Drawing.Point(20, 130);
            this.pnlAreaButtons.Name = "pnlAreaButtons";
            this.pnlAreaButtons.Size = new System.Drawing.Size(400, 80);
            this.pnlAreaButtons.TabIndex = 2;
            
            // 
            // btnAreaAdd
            // 
            this.btnAreaAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAreaAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAreaAdd.Name = "btnAreaAdd";
            this.btnAreaAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAreaAdd.TabIndex = 0;
            this.btnAreaAdd.Text = "Thêm";
            this.btnAreaAdd.UseVisualStyleBackColor = true;
            
            // 
            // btnAreaEdit
            // 
            this.btnAreaEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAreaEdit.Location = new System.Drawing.Point(85, 0);
            this.btnAreaEdit.Name = "btnAreaEdit";
            this.btnAreaEdit.Size = new System.Drawing.Size(75, 35);
            this.btnAreaEdit.TabIndex = 1;
            this.btnAreaEdit.Text = "Sửa";
            this.btnAreaEdit.UseVisualStyleBackColor = true;
            
            // 
            // btnAreaDelete
            // 
            this.btnAreaDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAreaDelete.Location = new System.Drawing.Point(170, 0);
            this.btnAreaDelete.Name = "btnAreaDelete";
            this.btnAreaDelete.Size = new System.Drawing.Size(75, 35);
            this.btnAreaDelete.TabIndex = 2;
            this.btnAreaDelete.Text = "Xóa";
            this.btnAreaDelete.UseVisualStyleBackColor = true;
            
            // 
            // btnAreaSave
            // 
            this.btnAreaSave.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAreaSave.Location = new System.Drawing.Point(0, 45);
            this.btnAreaSave.Name = "btnAreaSave";
            this.btnAreaSave.Size = new System.Drawing.Size(75, 35);
            this.btnAreaSave.TabIndex = 3;
            this.btnAreaSave.Text = "Lưu";
            this.btnAreaSave.UseVisualStyleBackColor = true;
            
            // 
            // btnAreaCancel
            // 
            this.btnAreaCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnAreaCancel.Location = new System.Drawing.Point(85, 45);
            this.btnAreaCancel.Name = "btnAreaCancel";
            this.btnAreaCancel.Size = new System.Drawing.Size(75, 35);
            this.btnAreaCancel.TabIndex = 4;
            this.btnAreaCancel.Text = "Hủy";
            this.btnAreaCancel.UseVisualStyleBackColor = true;
            
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpTableInfo);
            this.pnlRight.Location = new System.Drawing.Point(960, 80);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(620, 900);
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
            this.grpTableInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTableInfo.Name = "grpTableInfo";
            this.grpTableInfo.Size = new System.Drawing.Size(620, 400);
            this.grpTableInfo.TabIndex = 0;
            this.grpTableInfo.TabStop = false;
            this.grpTableInfo.Text = "Thông tin bàn";
            
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTableName.Location = new System.Drawing.Point(20, 50);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(72, 22);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tên bàn:";
            
            // 
            // txtTableName
            // 
            this.txtTableName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTableName.Location = new System.Drawing.Point(140, 47);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(450, 30);
            this.txtTableName.TabIndex = 1;
            
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblFloor.Location = new System.Drawing.Point(20, 90);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(79, 22);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "Khu vực:";
            
            // 
            // cmbFloor
            // 
            this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloor.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(140, 87);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(450, 30);
            this.cmbFloor.TabIndex = 3;
            
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCapacity.Location = new System.Drawing.Point(20, 130);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(89, 22);
            this.lblCapacity.TabIndex = 4;
            this.lblCapacity.Text = "Sức chứa:";
            
            // 
            // nudCapacity
            // 
            this.nudCapacity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nudCapacity.Location = new System.Drawing.Point(140, 128);
            this.nudCapacity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(120, 30);
            this.nudCapacity.TabIndex = 5;
            this.nudCapacity.Value = new decimal(new int[] { 4, 0, 0, 0 });
            
            // 
            // lblTableStatus
            // 
            this.lblTableStatus.AutoSize = true;
            this.lblTableStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTableStatus.Location = new System.Drawing.Point(20, 170);
            this.lblTableStatus.Name = "lblTableStatus";
            this.lblTableStatus.Size = new System.Drawing.Size(91, 22);
            this.lblTableStatus.TabIndex = 6;
            this.lblTableStatus.Text = "Trạng thái:";
            
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
            this.cmbTableStatus.Location = new System.Drawing.Point(140, 167);
            this.cmbTableStatus.Name = "cmbTableStatus";
            this.cmbTableStatus.Size = new System.Drawing.Size(200, 30);
            this.cmbTableStatus.TabIndex = 7;
            
            // 
            // pnlTableButtons
            // 
            this.pnlTableButtons.Controls.Add(this.btnTableAdd);
            this.pnlTableButtons.Controls.Add(this.btnTableEdit);
            this.pnlTableButtons.Controls.Add(this.btnTableDelete);
            this.pnlTableButtons.Controls.Add(this.btnTableSave);
            this.pnlTableButtons.Controls.Add(this.btnTableCancel);
            this.pnlTableButtons.Location = new System.Drawing.Point(20, 220);
            this.pnlTableButtons.Name = "pnlTableButtons";
            this.pnlTableButtons.Size = new System.Drawing.Size(570, 80);
            this.pnlTableButtons.TabIndex = 8;
            
            // 
            // btnTableAdd
            // 
            this.btnTableAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTableAdd.Location = new System.Drawing.Point(0, 0);
            this.btnTableAdd.Name = "btnTableAdd";
            this.btnTableAdd.Size = new System.Drawing.Size(100, 35);
            this.btnTableAdd.TabIndex = 0;
            this.btnTableAdd.Text = "Thêm";
            this.btnTableAdd.UseVisualStyleBackColor = true;
            
            // 
            // btnTableEdit
            // 
            this.btnTableEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTableEdit.Location = new System.Drawing.Point(110, 0);
            this.btnTableEdit.Name = "btnTableEdit";
            this.btnTableEdit.Size = new System.Drawing.Size(100, 35);
            this.btnTableEdit.TabIndex = 1;
            this.btnTableEdit.Text = "Sửa";
            this.btnTableEdit.UseVisualStyleBackColor = true;
            
            // 
            // btnTableDelete
            // 
            this.btnTableDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTableDelete.Location = new System.Drawing.Point(220, 0);
            this.btnTableDelete.Name = "btnTableDelete";
            this.btnTableDelete.Size = new System.Drawing.Size(100, 35);
            this.btnTableDelete.TabIndex = 2;
            this.btnTableDelete.Text = "Xóa";
            this.btnTableDelete.UseVisualStyleBackColor = true;
            
            // 
            // btnTableSave
            // 
            this.btnTableSave.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTableSave.Location = new System.Drawing.Point(0, 45);
            this.btnTableSave.Name = "btnTableSave";
            this.btnTableSave.Size = new System.Drawing.Size(100, 35);
            this.btnTableSave.TabIndex = 3;
            this.btnTableSave.Text = "Lưu";
            this.btnTableSave.UseVisualStyleBackColor = true;
            
            // 
            // btnTableCancel
            // 
            this.btnTableCancel.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTableCancel.Location = new System.Drawing.Point(110, 45);
            this.btnTableCancel.Name = "btnTableCancel";
            this.btnTableCancel.Size = new System.Drawing.Size(100, 35);
            this.btnTableCancel.TabIndex = 4;
            this.btnTableCancel.Text = "Hủy";
            this.btnTableCancel.UseVisualStyleBackColor = true;
            
            // 
            // FrmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.pnlMain);
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