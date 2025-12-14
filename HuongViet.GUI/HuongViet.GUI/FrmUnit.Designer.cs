using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    partial class FrmUnit
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvUnits = new System.Windows.Forms.DataGridView();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpUnitInfo = new System.Windows.Forms.GroupBox();
			this.btnCancel = new FontAwesome.Sharp.IconButton();
			this.btnSave = new FontAwesome.Sharp.IconButton();
			this.txtUnitName = new System.Windows.Forms.TextBox();
			this.lblUnitName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnDelete = new FontAwesome.Sharp.IconButton();
			this.btnEdit = new FontAwesome.Sharp.IconButton();
			this.btnAdd = new FontAwesome.Sharp.IconButton();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.lblSearch = new System.Windows.Forms.Label();
			this.btnRefresh = new FontAwesome.Sharp.IconButton();
			this.btnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
			this.pnlForm.SuspendLayout();
			this.grpUnitInfo.SuspendLayout();
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
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(2015, 1081);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.dgvUnits);
			this.pnlContent.Location = new System.Drawing.Point(13, 73);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(1381, 995);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvUnits
			// 
			this.dgvUnits.AllowUserToAddRows = false;
			this.dgvUnits.AllowUserToDeleteRows = false;
			this.dgvUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvUnits.BackgroundColor = System.Drawing.Color.White;
			this.dgvUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvUnits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 14F);
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvUnits.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgvUnits.Location = new System.Drawing.Point(0, 0);
			this.dgvUnits.Margin = new System.Windows.Forms.Padding(4);
			this.dgvUnits.MultiSelect = false;
			this.dgvUnits.Name = "dgvUnits";
			this.dgvUnits.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvUnits.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dgvUnits.RowHeadersVisible = false;
			this.dgvUnits.RowHeadersWidth = 51;
			this.dgvUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUnits.Size = new System.Drawing.Size(1381, 980);
			this.dgvUnits.TabIndex = 0;
			this.dgvUnits.SelectionChanged += new System.EventHandler(this.dgvUnits_SelectionChanged);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpUnitInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Location = new System.Drawing.Point(1402, 73);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Size = new System.Drawing.Size(499, 938);
			this.pnlForm.TabIndex = 1;
			// 
			// grpUnitInfo
			// 
			this.grpUnitInfo.Controls.Add(this.btnCancel);
			this.grpUnitInfo.Controls.Add(this.btnSave);
			this.grpUnitInfo.Controls.Add(this.txtUnitName);
			this.grpUnitInfo.Controls.Add(this.lblUnitName);
			this.grpUnitInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpUnitInfo.Location = new System.Drawing.Point(14, 12);
			this.grpUnitInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpUnitInfo.Name = "grpUnitInfo";
			this.grpUnitInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpUnitInfo.Size = new System.Drawing.Size(481, 223);
			this.grpUnitInfo.TabIndex = 1;
			this.grpUnitInfo.TabStop = false;
			this.grpUnitInfo.Text = "Thông tin đơn vị tính";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnCancel.IconColor = System.Drawing.Color.Black;
			this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCancel.IconSize = 20;
			this.btnCancel.Location = new System.Drawing.Point(325, 153);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnCancel.Size = new System.Drawing.Size(149, 48);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnSave.IconColor = System.Drawing.Color.Black;
			this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSave.IconSize = 20;
			this.btnSave.Location = new System.Drawing.Point(162, 153);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnSave.Size = new System.Drawing.Size(149, 48);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtUnitName
			// 
			this.txtUnitName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUnitName.Location = new System.Drawing.Point(24, 93);
			this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
			this.txtUnitName.MaxLength = 50;
			this.txtUnitName.Name = "txtUnitName";
			this.txtUnitName.Size = new System.Drawing.Size(449, 38);
			this.txtUnitName.TabIndex = 1;
			// 
			// lblUnitName
			// 
			this.lblUnitName.AutoSize = true;
			this.lblUnitName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblUnitName.Location = new System.Drawing.Point(24, 52);
			this.lblUnitName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUnitName.Name = "lblUnitName";
			this.lblUnitName.Size = new System.Drawing.Size(165, 27);
			this.lblUnitName.TabIndex = 0;
			this.lblUnitName.Text = "Tên đơn vị tính:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Location = new System.Drawing.Point(13, 239);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(482, 96);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
			this.btnDelete.IconColor = System.Drawing.Color.Black;
			this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnDelete.IconSize = 20;
			this.btnDelete.Location = new System.Drawing.Point(332, 23);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnDelete.Size = new System.Drawing.Size(142, 60);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnEdit.IconColor = System.Drawing.Color.Black;
			this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnEdit.IconSize = 20;
			this.btnEdit.Location = new System.Drawing.Point(172, 23);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnEdit.Size = new System.Drawing.Size(142, 60);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.btnAdd.IconColor = System.Drawing.Color.Black;
			this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAdd.IconSize = 20;
			this.btnAdd.Location = new System.Drawing.Point(12, 23);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAdd.Size = new System.Drawing.Size(142, 60);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1893, 61);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.lblSearch);
			this.pnlSearch.Controls.Add(this.btnRefresh);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.txtSearch);
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1884, 61);
			this.pnlSearch.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblSearch.Location = new System.Drawing.Point(20, 16);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(109, 27);
			this.lblSearch.TabIndex = 4;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
			this.btnRefresh.IconColor = System.Drawing.Color.Black;
			this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRefresh.IconSize = 20;
			this.btnRefresh.Location = new System.Drawing.Point(1673, 6);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnRefresh.Size = new System.Drawing.Size(201, 47);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
			this.btnSearch.IconColor = System.Drawing.Color.Black;
			this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSearch.IconSize = 20;
			this.btnSearch.Location = new System.Drawing.Point(1448, 6);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnSearch.Size = new System.Drawing.Size(201, 47);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 16F);
			this.txtSearch.Location = new System.Drawing.Point(165, 10);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(1216, 43);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// FrmUnit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1920, 1081);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmUnit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý đơn vị tính";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
			this.pnlForm.ResumeLayout(false);
			this.grpUnitInfo.ResumeLayout(false);
			this.grpUnitInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpUnitInfo;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label lblUnitName;
		private System.Windows.Forms.Panel pnlButtons;
		private FontAwesome.Sharp.IconButton btnCancel;
		private FontAwesome.Sharp.IconButton btnSave;
		private FontAwesome.Sharp.IconButton btnDelete;
		private FontAwesome.Sharp.IconButton btnEdit;
		private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
		private FontAwesome.Sharp.IconButton btnRefresh;
		private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

