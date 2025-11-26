using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmCategory : Form
    {
        private readonly CategoryBLL categoryBLL;
        private List<Category> categories;
        private Category selectedCategory;
        private bool isEditing = false;

        public FrmCategory()
        {
            InitializeComponent();
            categoryBLL = new CategoryBLL();
            InitializeForm();
            LoadCategories();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        private void InitializeComponent()
        {
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpCategoryInfo = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.grpCategoryInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(20, 20);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(500, 400);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
            
            // 
            // grpCategoryInfo
            // 
            this.grpCategoryInfo.Controls.Add(this.lblCategoryName);
            this.grpCategoryInfo.Controls.Add(this.txtCategoryName);
            this.grpCategoryInfo.Controls.Add(this.lblDescription);
            this.grpCategoryInfo.Controls.Add(this.txtDescription);
            this.grpCategoryInfo.Location = new System.Drawing.Point(540, 20);
            this.grpCategoryInfo.Name = "grpCategoryInfo";
            this.grpCategoryInfo.Size = new System.Drawing.Size(350, 250);
            this.grpCategoryInfo.TabIndex = 1;
            this.grpCategoryInfo.TabStop = false;
            this.grpCategoryInfo.Text = "Thông tin thể loại";
            
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(20, 35);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(80, 13);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Tên thể loại:";
            
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(20, 55);
            this.txtCategoryName.MaxLength = 100;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(310, 20);
            this.txtCategoryName.TabIndex = 1;
            
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(40, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Mô tả:";
            
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 110);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(310, 100);
            this.txtDescription.TabIndex = 3;
            
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Location = new System.Drawing.Point(540, 290);
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
            // FrmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 450);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grpCategoryInfo);
            this.Controls.Add(this.dgvCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCategory";
            this.Text = "Quản lý thể loại";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.Panel pnlButtons;

        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.ReadOnly = true;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCategories.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvCategories.RowTemplate.Height = 30;
            dgvCategories.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadCategories()
        {
            try
            {
                categories = categoryBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thể loại: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvCategories.DataSource = null;
            
            if (categories != null && categories.Count > 0)
            {
                var displayData = categories.Select(c => new
                {
                    CateID = c.CateID,
                    CateName = c.CateName,
                    CateDescription = c.CateDescription
                }).ToList();

                dgvCategories.DataSource = displayData;
                
                if (dgvCategories.Columns.Count > 0)
                {
                    dgvCategories.Columns["CateID"].HeaderText = "Mã thể loại";
                    dgvCategories.Columns["CateName"].HeaderText = "Tên thể loại";
                    dgvCategories.Columns["CateDescription"].HeaderText = "Mô tả";
                    
                    dgvCategories.Columns["CateID"].FillWeight = 20;
                    dgvCategories.Columns["CateName"].FillWeight = 30;
                    dgvCategories.Columns["CateDescription"].FillWeight = 50;
                }
            }
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            txtDescription.Clear();
            selectedCategory = null;
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
            txtCategoryName.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            txtCategoryName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtDescription.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedCategory != null;
            btnDelete.Enabled = !enable && selectedCategory != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvCategories.Enabled = !enable;
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvCategories.SelectedRows[0];
                string categoryId = row.Cells["CateID"].Value.ToString();
                
                selectedCategory = categories.FirstOrDefault(c => c.CateID == categoryId);
                
                if (selectedCategory != null)
                {
                    txtCategoryName.Text = selectedCategory.CateName;
                    txtDescription.Text = selectedCategory.CateDescription ?? string.Empty;
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
            selectedCategory = null;
            isEditing = true;
            ClearForm();
            EnableEditMode(true);
            txtCategoryName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtCategoryName.Focus();
                txtCategoryName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại '{selectedCategory.CateName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = categoryBLL.Delete(selectedCategory.CateID);
                    if (success)
                    {
                        MessageBox.Show("Xóa thể loại thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa thể loại!", "Lỗi", 
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
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thể loại!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                Category category = selectedCategory ?? new Category
                {
                    CateID = categoryBLL.GenerateNewCategoryID()
                };
                
                category.CateName = txtCategoryName.Text.Trim();
                category.CateDescription = txtDescription.Text.Trim();

                bool success;
                string message;

                if (selectedCategory == null) // Add new
                {
                    success = categoryBLL.Insert(category);
                    message = success ? "Thêm thể loại thành công!" : "Không thể thêm thể loại!";
                }
                else // Update existing
                {
                    success = categoryBLL.Update(category);
                    message = success ? "Cập nhật thể loại thành công!" : "Không thể cập nhật thể loại!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
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
            if (selectedCategory != null)
            {
                txtCategoryName.Text = selectedCategory.CateName;
                txtDescription.Text = selectedCategory.CateDescription ?? string.Empty;
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

