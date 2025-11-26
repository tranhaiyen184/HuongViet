using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmUnit : Form
    {
        private readonly UnitBLL unitBLL;
        private List<Unit> units;
        private Unit selectedUnit;
        private bool isEditing = false;

        public FrmUnit()
        {
            InitializeComponent();
            unitBLL = new UnitBLL();
            InitializeForm();
            LoadUnits();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeComponent()
        {
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.grpUnitInfo = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.grpUnitInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnits.Location = new System.Drawing.Point(20, 20);
            this.dgvUnits.MultiSelect = false;
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.RowHeadersVisible = false;
            this.dgvUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.Size = new System.Drawing.Size(500, 400);
            this.dgvUnits.TabIndex = 0;
            this.dgvUnits.SelectionChanged += new System.EventHandler(this.dgvUnits_SelectionChanged);
            
            // 
            // grpUnitInfo
            // 
            this.grpUnitInfo.Controls.Add(this.lblUnitName);
            this.grpUnitInfo.Controls.Add(this.txtUnitName);
            this.grpUnitInfo.Location = new System.Drawing.Point(540, 20);
            this.grpUnitInfo.Name = "grpUnitInfo";
            this.grpUnitInfo.Size = new System.Drawing.Size(350, 150);
            this.grpUnitInfo.TabIndex = 1;
            this.grpUnitInfo.TabStop = false;
            this.grpUnitInfo.Text = "Thông tin đơn vị tính";
            
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(20, 35);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(95, 13);
            this.lblUnitName.TabIndex = 0;
            this.lblUnitName.Text = "Tên đơn vị tính:";
            
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(20, 55);
            this.txtUnitName.MaxLength = 50;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(310, 20);
            this.txtUnitName.TabIndex = 1;
            
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Location = new System.Drawing.Point(540, 190);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(350, 130);
            this.pnlButtons.TabIndex = 2;
            
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(130, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(75, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(185, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // 
            // FrmUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 450);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grpUnitInfo);
            this.Controls.Add(this.dgvUnits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUnit";
            this.Text = "Quản lý đơn vị tính";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.grpUnitInfo.ResumeLayout(false);
            this.grpUnitInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.GroupBox grpUnitInfo;
        private System.Windows.Forms.Panel pnlButtons;

        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvUnits.RowHeadersVisible = false;
            dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnits.MultiSelect = false;
            dgvUnits.AllowUserToAddRows = false;
            dgvUnits.AllowUserToDeleteRows = false;
            dgvUnits.ReadOnly = true;
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvUnits.EnableHeadersVisualStyles = false;
            dgvUnits.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dgvUnits.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvUnits.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUnits.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvUnits.RowTemplate.Height = 30;
            dgvUnits.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvUnits.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvUnits.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadUnits()
        {
            try
            {
                units = unitBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn vị tính: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvUnits.DataSource = null;
            
            if (units != null && units.Count > 0)
            {
                var displayData = units.Select(u => new
                {
                    UnitID = u.UnitID,
                    UnitName = u.UnitName
                }).ToList();

                dgvUnits.DataSource = displayData;
                
                if (dgvUnits.Columns.Count > 0)
                {
                    dgvUnits.Columns["UnitID"].HeaderText = "Mã đơn vị";
                    dgvUnits.Columns["UnitName"].HeaderText = "Tên đơn vị tính";
                    
                    dgvUnits.Columns["UnitID"].FillWeight = 30;
                    dgvUnits.Columns["UnitName"].FillWeight = 70;
                }
            }
        }

        private void ClearForm()
        {
            txtUnitName.Clear();
            selectedUnit = null;
            isEditing = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            EnableEditMode(false);
        }

        private void EnableEditMode(bool enable)
        {
            txtUnitName.ReadOnly = !enable;
            txtUnitName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedUnit != null;
            btnDelete.Enabled = !enable && selectedUnit != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvUnits.Enabled = !enable;
        }

        private void dgvUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUnits.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvUnits.SelectedRows[0];
                string unitId = row.Cells["UnitID"].Value.ToString();
                
                selectedUnit = units.FirstOrDefault(u => u.UnitID == unitId);
                
                if (selectedUnit != null)
                {
                    txtUnitName.Text = selectedUnit.UnitName;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else if (!isEditing)
            {
                ClearForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedUnit = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            txtUnitName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUnit != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtUnitName.Focus();
                txtUnitName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUnit == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đơn vị tính '{selectedUnit.UnitName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = unitBLL.Delete(selectedUnit.UnitID);
                    if (success)
                    {
                        MessageBox.Show("Xóa đơn vị tính thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUnits();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa đơn vị tính!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUnitName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đơn vị tính!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitName.Focus();
                    return;
                }

                Unit unit = selectedUnit ?? new Unit
                {
                    UnitID = unitBLL.GenerateNewUnitID()
                };
                
                unit.UnitName = txtUnitName.Text.Trim();

                bool success;
                string message;

                if (selectedUnit == null) // Add new
                {
                    success = unitBLL.Insert(unit);
                    message = success ? "Thêm đơn vị tính thành công!" : "Không thể thêm đơn vị tính!";
                }
                else // Update existing
                {
                    success = unitBLL.Update(unit);
                    message = success ? "Cập nhật đơn vị tính thành công!" : "Không thể cập nhật đơn vị tính!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUnits();
                    ClearForm();
                    EnableEditMode(false);
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedUnit != null)
            {
                txtUnitName.Text = selectedUnit.UnitName;
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }
    }
}

