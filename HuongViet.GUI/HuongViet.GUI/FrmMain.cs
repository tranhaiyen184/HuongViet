using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmMain : Form
    {
        private const int ExpandedSidebarWidth = 240;
        private const int CollapsedSidebarWidth = 72;

        private bool _sidebarExpanded = true;
        private IReadOnlyCollection<IconButton> _navigationButtons = Array.Empty<IconButton>();
        private User _currentUser;
        private TabControl _mainTabControl;
        private Dictionary<string, Form> _openTabs = new Dictionary<string, Form>();
        
        // Menu expansion state
        private Dictionary<IconButton, bool> _menuExpandedState = new Dictionary<IconButton, bool>();
        private Dictionary<IconButton, Panel> _subMenuPanels = new Dictionary<IconButton, Panel>();
        private IconButton btnRevenueReport;
        
        // Modern color scheme
        private readonly Color SidebarBackground = Color.FromArgb(245, 247, 250); // Light gray
        private readonly Color MenuItemBackground = Color.White;
        private readonly Color MenuItemText = Color.FromArgb(51, 51, 51); // Dark gray
        private readonly Color MenuItemHover = Color.FromArgb(240, 242, 245); // Light hover
        private readonly Color MenuItemActive = Color.FromArgb(70, 70, 70); // Dark gray for active
        private readonly Color MenuItemActiveText = Color.White;
        private readonly Color SubMenuItemBackground = Color.FromArgb(235, 237, 240); // Slightly darker for sub-items
        private readonly Color SubMenuItemActive = Color.FromArgb(60, 60, 60); // Darker for active sub-item
        private IconButton _activeMenuItem = null;
        private IconButton _activeSubMenuItem = null;

        public FrmMain() : this(null)
        {
        }

        public FrmMain(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            InitializeLayoutState();
            UpdateUserInfo();
            this.Shown += FrmMain_Shown;
            
            // Add Resize event handler to update layout
            this.Resize += FrmMain_Resize;
        }
        
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;
                
            int headerHeight = headerPanel.Height;
            int formHeight = this.ClientSize.Height;
            int formWidth = this.ClientSize.Width;
            
            // Update header panel
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(formWidth, headerHeight);
            
            // Update sidebar panel
            sidebarPanel.Location = new Point(0, headerHeight);
            sidebarPanel.Height = formHeight - headerHeight;
            
            // Update navContainer
            navContainer.Size = new Size(sidebarPanel.Width, sidebarPanel.Height);
            
            // Update content panel
            contentPanel.Location = new Point(sidebarPanel.Width, headerHeight);
            contentPanel.Size = new Size(formWidth - sidebarPanel.Width, formHeight - headerHeight);
            
            // Update tab control size
            if (_mainTabControl != null)
            {
                _mainTabControl.Size = new Size(contentPanel.Width, contentPanel.Height);
                
                // Update all child forms size
                foreach (TabPage tabPage in _mainTabControl.TabPages)
                {
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control is Form childForm)
                        {
                            childForm.Size = new Size(tabPage.Width, tabPage.Height);
                        }
                    }
                }
            }
            
            // Update placeholder panel size
            if (placeholderPanel != null && placeholderPanel.Visible)
            {
                placeholderPanel.Size = new Size(
                    contentPanel.Width - contentPanel.Padding.Left - contentPanel.Padding.Right,
                    contentPanel.Height - contentPanel.Padding.Top - contentPanel.Padding.Bottom);
            }
        }

        private void InitializeLayoutState()
        {
            _navigationButtons = navContainer.Controls.OfType<IconButton>().ToArray();
            foreach (var button in _navigationButtons)
            {
                // Store original text in Tag if not already set
                if (string.IsNullOrEmpty(button.Tag?.ToString()) && !string.IsNullOrEmpty(button.Text))
                {
                    button.Tag = button.Text;
                }
                
                ApplyModernButtonStyle(button, false);
                
                // Force button to redraw
                button.Invalidate();
            }

            // Set sidebar background
            sidebarPanel.BackColor = SidebarBackground;
            navContainer.BackColor = SidebarBackground;

            // Initialize sub-menu for Staff
            InitializeStaffSubMenu();
            
            // Initialize sub-menu for Menu
            InitializeMenuSubMenu();

            // Initialize sub-menu for Report
            InitializeReportSubMenu();
            
            UpdateSidebarState(force: true);
            
            // Initialize tab control
            InitializeTabControl();
            
            // Ensure placeholder is visible initially
            ShowPlaceholder();
        }
        
        private void ApplyModernButtonStyle(IconButton button, bool isSubItem = false)
        {
            if (button == btnToggleSidebar)
            {
                return; // Skip toggle button
            }
            
            // Modern flat style
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = MenuItemHover;
            button.FlatAppearance.MouseDownBackColor = MenuItemHover;
            
            // IMPORTANT: Disable UseVisualStyleBackColor to allow custom colors
            button.UseVisualStyleBackColor = false;
            
            // Default colors
            if (isSubItem)
            {
                button.BackColor = SubMenuItemBackground;
                button.ForeColor = MenuItemText;
                button.IconColor = MenuItemText;
            }
            else
            {
                button.BackColor = MenuItemBackground;
                button.ForeColor = MenuItemText;
                button.IconColor = MenuItemText;
            }
            
            // Modern font
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            
            // Add rounded corners effect (we'll use a custom paint event)
            // Only add once
            button.Paint -= Button_Paint;
            button.Paint += Button_Paint;
            
            // Add hover effects
            button.MouseEnter -= ModernButton_MouseEnter;
            button.MouseEnter += ModernButton_MouseEnter;
            button.MouseLeave -= ModernButton_MouseLeave;
            button.MouseLeave += ModernButton_MouseLeave;
        }
        
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            if (sender is IconButton btn && btn != btnToggleSidebar)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                // Draw rounded rectangle background with modern style
                int radius = 8;
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                System.Drawing.Drawing2D.GraphicsPath path = null;
                
                try
                {
                    path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();
                    
                    // Fill background
                    using (SolidBrush brush = new SolidBrush(btn.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    
                    // Set region for click area
                    if (_sidebarExpanded || btn == btnToggleSidebar)
                    {
                        btn.Region = new Region(path);
                        path = null; // Prevent disposal, region owns it now
                    }
                    else
                    {
                        btn.Region = null; // Reset region when collapsed
                    }
                }
                finally
                {
                    if (path != null)
                    {
                        path.Dispose();
                    }
                }
                
                // Draw icon and text manually
                if (_sidebarExpanded)
                {
                    // Expanded mode: icon on left, text next to it
                    int iconX = 16; // Left padding
                    int iconY = (btn.Height - btn.IconSize) / 2;
                    
                    // Draw icon if available
                    if (btn.IconChar != IconChar.None)
                    {
                        try
                        {
                            using (var iconBitmap = btn.IconChar.ToBitmap(btn.IconFont, btn.IconSize, btn.IconColor))
                            {
                                if (iconBitmap != null)
                                {
                                    e.Graphics.DrawImage(iconBitmap, iconX, iconY);
                                }
                            }
                        }
                        catch
                        {
                            // If icon rendering fails, continue without icon
                        }
                    }
                    
                    // Draw text
                    if (!string.IsNullOrEmpty(btn.Text))
                    {
                        Rectangle textRect = new Rectangle(iconX + btn.IconSize + 8, 0, btn.Width - iconX - btn.IconSize - 16, btn.Height);
                        TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, textRect, btn.ForeColor, 
                            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                    }
                }
                else
                {
                    // Collapsed mode: icon centered
                    int iconX = (btn.Width - btn.IconSize) / 2;
                    int iconY = (btn.Height - btn.IconSize) / 2;
                    
                    // Draw icon if available
                    if (btn.IconChar != IconChar.None)
                    {
                        try
                        {
                            using (var iconBitmap = btn.IconChar.ToBitmap(btn.IconFont, btn.IconSize, btn.IconColor))
                            {
                                if (iconBitmap != null)
                                {
                                    e.Graphics.DrawImage(iconBitmap, iconX, iconY);
                                }
                            }
                        }
                        catch
                        {
                            // If icon rendering fails, continue without icon
                        }
                    }
                }
            }
        }
        
        private void ModernButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is IconButton btn && btn != btnToggleSidebar && btn != _activeMenuItem && btn != _activeSubMenuItem)
            {
                btn.BackColor = MenuItemHover;
                btn.Invalidate(); // Force redraw
            }
        }
        
        private void ModernButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is IconButton btn && btn != btnToggleSidebar && btn != _activeMenuItem && btn != _activeSubMenuItem)
            {
                // Check if it's a sub-item
                bool isSubItem = _subMenuPanels.Values.Any(panel => panel.Controls.Contains(btn));
                btn.BackColor = isSubItem ? SubMenuItemBackground : MenuItemBackground;
                btn.Invalidate(); // Force redraw
            }
        }
        
        private void InitializeMenuSubMenu()
        {
            // Create sub-menu panel for Menu
            Panel subMenuPanel = new Panel();
            subMenuPanel.Name = "subMenuFood";
            subMenuPanel.Height = 0; // Start collapsed
            subMenuPanel.Visible = false;
            subMenuPanel.Margin = new Padding(8, 0, 8, 0);
            subMenuPanel.Padding = new Padding(0);
            subMenuPanel.AutoSize = false;
            subMenuPanel.Width = 240;
            subMenuPanel.BackColor = SidebarBackground;
            
            // Create Category sub-item
            IconButton btnCategory = new IconButton();
            btnCategory.Name = "btnCategory";
            btnCategory.Text = "Thể loại";
            btnCategory.Tag = "Thể loại";
            btnCategory.IconChar = IconChar.Circle;
            btnCategory.IconColor = MenuItemText;
            btnCategory.IconFont = IconFont.Auto;
            btnCategory.IconSize = 6;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.ForeColor = MenuItemText;
            btnCategory.BackColor = SubMenuItemBackground;
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategory.Padding = new Padding(48, 10, 16, 10);
            btnCategory.Margin = new Padding(0, 4, 0, 0);
            btnCategory.Height = 40;
            btnCategory.Width = 224;
            btnCategory.Dock = DockStyle.None;
            btnCategory.Location = new Point(8, 0);
            btnCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategory.Font = new Font("Segoe UI", 9F);
            btnCategory.Click += BtnCategory_Click;
            ApplyModernButtonStyle(btnCategory, true);
            
            // Create Unit sub-item
            IconButton btnUnit = new IconButton();
            btnUnit.Name = "btnUnit";
            btnUnit.Text = "Đơn vị tính";
            btnUnit.Tag = "Đơn vị tính";
            btnUnit.IconChar = IconChar.Circle;
            btnUnit.IconColor = MenuItemText;
            btnUnit.IconFont = IconFont.Auto;
            btnUnit.IconSize = 6;
            btnUnit.FlatAppearance.BorderSize = 0;
            btnUnit.FlatStyle = FlatStyle.Flat;
            btnUnit.UseVisualStyleBackColor = false;
            btnUnit.ForeColor = MenuItemText;
            btnUnit.BackColor = SubMenuItemBackground;
            btnUnit.TextAlign = ContentAlignment.MiddleLeft;
            btnUnit.ImageAlign = ContentAlignment.MiddleLeft;
            btnUnit.Padding = new Padding(48, 10, 16, 10);
            btnUnit.Margin = new Padding(0, 4, 0, 0);
            btnUnit.Height = 40;
            btnUnit.Width = 224;
            btnUnit.Dock = DockStyle.None;
            btnUnit.Location = new Point(8, 44);
            btnUnit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUnit.Font = new Font("Segoe UI", 9F);
            btnUnit.Click += BtnUnit_Click;
            ApplyModernButtonStyle(btnUnit, true);
            
            // Create Item sub-item
            IconButton btnItemMenu = new IconButton();
            btnItemMenu.Name = "btnItemMenu";
            btnItemMenu.Text = "Món ăn";
            btnItemMenu.Tag = "Món ăn";
            btnItemMenu.IconChar = IconChar.Circle;
            btnItemMenu.IconColor = MenuItemText;
            btnItemMenu.IconFont = IconFont.Auto;
            btnItemMenu.IconSize = 6;
            btnItemMenu.FlatAppearance.BorderSize = 0;
            btnItemMenu.FlatStyle = FlatStyle.Flat;
            btnItemMenu.UseVisualStyleBackColor = false;
            btnItemMenu.ForeColor = MenuItemText;
            btnItemMenu.BackColor = SubMenuItemBackground;
            btnItemMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnItemMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnItemMenu.Padding = new Padding(48, 10, 16, 10);
            btnItemMenu.Margin = new Padding(0, 4, 0, 0);
            btnItemMenu.Height = 40;
            btnItemMenu.Width = 224;
            btnItemMenu.Dock = DockStyle.None;
            btnItemMenu.Location = new Point(8, 88);
            btnItemMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnItemMenu.Font = new Font("Segoe UI", 9F);
            btnItemMenu.Click += BtnItemMenu_Click;
            ApplyModernButtonStyle(btnItemMenu, true);
            
            IconButton btnServiceMenu = new IconButton();
            btnServiceMenu.Name = "btnServiceMenu";
            btnServiceMenu.Text = "Dịch vụ";
            btnServiceMenu.Tag = "Dịch vụ";
            btnServiceMenu.IconChar = IconChar.Circle;
            btnServiceMenu.IconColor = MenuItemText;
            btnServiceMenu.IconFont = IconFont.Auto;
            btnServiceMenu.IconSize = 6;
            btnServiceMenu.FlatAppearance.BorderSize = 0;
            btnServiceMenu.FlatStyle = FlatStyle.Flat;
            btnServiceMenu.UseVisualStyleBackColor = false;
            btnServiceMenu.ForeColor = MenuItemText;
            btnServiceMenu.BackColor = SubMenuItemBackground;
            btnServiceMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnServiceMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnServiceMenu.Padding = new Padding(48, 10, 16, 10);
            btnServiceMenu.Margin = new Padding(0, 4, 0, 0);
            btnServiceMenu.Height = 40;
            btnServiceMenu.Width = 224;
            btnServiceMenu.Dock = DockStyle.None;
            btnServiceMenu.Location = new Point(8, 132);
            btnServiceMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServiceMenu.Font = new Font("Segoe UI", 9F);
            btnServiceMenu.Click += BtnServiceMenu_Click;
            ApplyModernButtonStyle(btnServiceMenu, true);
            
            subMenuPanel.Controls.Add(btnCategory);
            subMenuPanel.Controls.Add(btnUnit);
            subMenuPanel.Controls.Add(btnItemMenu);
            subMenuPanel.Controls.Add(btnServiceMenu);
            
            subMenuPanel.Height = btnCategory.Height + btnUnit.Height + btnItemMenu.Height + btnServiceMenu.Height + 20;
            int menuIndex = navContainer.Controls.IndexOf(btnMenu);
            if (menuIndex >= 0)
            {
                navContainer.Controls.Add(subMenuPanel);
                navContainer.Controls.SetChildIndex(subMenuPanel, menuIndex + 1);
            }
            
            _subMenuPanels[btnMenu] = subMenuPanel;
            _menuExpandedState[btnMenu] = false;
            
            if (btnMenu.Tag == null || !btnMenu.Tag.ToString().StartsWith("Thực đơn"))
            {
                btnMenu.Tag = "Thực đơn";
            }
        }

        private void InitializeReportSubMenu()
        {
            Panel subMenuPanel = new Panel();
            subMenuPanel.Name = "subMenuReport";
            subMenuPanel.Height = 0;
            subMenuPanel.Visible = false;
            subMenuPanel.Margin = new Padding(8, 0, 8, 0);
            subMenuPanel.Padding = new Padding(0);
            subMenuPanel.AutoSize = false;
            subMenuPanel.Width = 240;
            subMenuPanel.BackColor = SidebarBackground;

            btnRevenueReport = new IconButton();
            btnRevenueReport.Name = "btnRevenueReport";
            btnRevenueReport.Text = "Thống kê doanh thu";
            btnRevenueReport.Tag = "Thống kê doanh thu";
            btnRevenueReport.IconChar = IconChar.Circle;
            btnRevenueReport.IconColor = MenuItemText;
            btnRevenueReport.IconFont = IconFont.Auto;
            btnRevenueReport.IconSize = 6;
            btnRevenueReport.FlatAppearance.BorderSize = 0;
            btnRevenueReport.FlatStyle = FlatStyle.Flat;
            btnRevenueReport.UseVisualStyleBackColor = false;
            btnRevenueReport.ForeColor = MenuItemText;
            btnRevenueReport.BackColor = SubMenuItemBackground;
            btnRevenueReport.TextAlign = ContentAlignment.MiddleLeft;
            btnRevenueReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnRevenueReport.Padding = new Padding(48, 10, 16, 10);
            btnRevenueReport.Margin = new Padding(0, 4, 0, 0);
            btnRevenueReport.Height = 40;
            btnRevenueReport.Width = 224;
            btnRevenueReport.Dock = DockStyle.None;
            btnRevenueReport.Location = new Point(8, 0);
            btnRevenueReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRevenueReport.Font = new Font("Segoe UI", 9F);
            btnRevenueReport.Click += BtnRevenueReport_Click;
            ApplyModernButtonStyle(btnRevenueReport, true);

            IconButton btnBestSellingReport = new IconButton();
            btnBestSellingReport.Name = "btnBestSellingReport";
            btnBestSellingReport.Text = "Sản phẩm bán chạy";
            btnBestSellingReport.Tag = "Sản phẩm bán chạy";
            btnBestSellingReport.IconChar = IconChar.Circle;
            btnBestSellingReport.IconColor = MenuItemText;
            btnBestSellingReport.IconFont = IconFont.Auto;
            btnBestSellingReport.IconSize = 6;
            btnBestSellingReport.FlatAppearance.BorderSize = 0;
            btnBestSellingReport.FlatStyle = FlatStyle.Flat;
            btnBestSellingReport.UseVisualStyleBackColor = false;
            btnBestSellingReport.ForeColor = MenuItemText;
            btnBestSellingReport.BackColor = SubMenuItemBackground;
            btnBestSellingReport.TextAlign = ContentAlignment.MiddleLeft;
            btnBestSellingReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnBestSellingReport.Padding = new Padding(48, 10, 16, 10);
            btnBestSellingReport.Margin = new Padding(0, 4, 0, 0);
            btnBestSellingReport.Height = 40;
            btnBestSellingReport.Width = 224;
            btnBestSellingReport.Dock = DockStyle.None;
            btnBestSellingReport.Location = new Point(8, 44);
            btnBestSellingReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBestSellingReport.Font = new Font("Segoe UI", 9F);
            btnBestSellingReport.Click += BtnBestSellingReport_Click;
            ApplyModernButtonStyle(btnBestSellingReport, true);

            subMenuPanel.Controls.Add(btnRevenueReport);
            subMenuPanel.Controls.Add(btnBestSellingReport);

            subMenuPanel.Height = btnRevenueReport.Height + btnBestSellingReport.Height + 12;

            int reportIndex = navContainer.Controls.IndexOf(btnReport);
            if (reportIndex >= 0)
            {
                navContainer.Controls.Add(subMenuPanel);
                navContainer.Controls.SetChildIndex(subMenuPanel, reportIndex + 1);
            }

            _subMenuPanels[btnReport] = subMenuPanel;
            _menuExpandedState[btnReport] = false;

            if (btnReport.Tag == null || !btnReport.Tag.ToString().StartsWith("Thống kê"))
            {
                btnReport.Tag = "Thống kê";
            }
        }
        
        private void BtnCategory_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmCategory(), "Quản lý thể loại", "category");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý thể loại: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnUnit_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmUnit(), "Quản lý đơn vị tính", "unit");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý đơn vị tính: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnItemMenu_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmItem(), "Quản lý món ăn", "item");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý món ăn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnServiceMenu_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmService(), "Quản lý dịch vụ", "service");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý dịch vụ: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRevenueReport_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmRevenueReport(), "Thống kê doanh thu", "report");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở thống kê doanh thu: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBestSellingReport_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmBestSellingReport(), "Báo cáo sản phẩm", "bestSellingReport");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở báo cáo sản phẩm: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            // Open revenue report by default when the main form appears
            if (btnRevenueReport != null)
            {
                BtnRevenueReport_Click(btnRevenueReport, EventArgs.Empty);
            }
        }
        
        private void InitializeStaffSubMenu()
        {
            Panel subMenuPanel = new Panel();
            subMenuPanel.Name = "subMenuStaff";
            subMenuPanel.Height = 0; 
            subMenuPanel.Visible = false;
            subMenuPanel.Margin = new Padding(8, 0, 8, 0);
            subMenuPanel.Padding = new Padding(0);
            subMenuPanel.AutoSize = false;
            subMenuPanel.Width = 240;
            subMenuPanel.BackColor = SidebarBackground;
            
            IconButton btnDepartment = new IconButton();
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Text = "Phòng ban";
            btnDepartment.Tag = "Phòng ban";
            btnDepartment.IconChar = IconChar.Circle;
            btnDepartment.IconColor = MenuItemText;
            btnDepartment.IconFont = IconFont.Auto;
            btnDepartment.IconSize = 6;
            btnDepartment.FlatAppearance.BorderSize = 0;
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.UseVisualStyleBackColor = false; 
            btnDepartment.ForeColor = MenuItemText;
            btnDepartment.BackColor = SubMenuItemBackground;
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.ImageAlign = ContentAlignment.MiddleLeft;
            btnDepartment.Padding = new Padding(48, 10, 16, 10);
            btnDepartment.Margin = new Padding(0, 4, 0, 0);
            btnDepartment.Height = 40;
            btnDepartment.Width = 224;
            btnDepartment.Dock = DockStyle.None;
            btnDepartment.Location = new Point(8, 0);
            btnDepartment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDepartment.Font = new Font("Segoe UI", 9F);
            btnDepartment.Click += BtnDepartment_Click;
            ApplyModernButtonStyle(btnDepartment, true);
            
            IconButton btnPositionSub = new IconButton();
            btnPositionSub.Name = "btnPositionSub";
            btnPositionSub.Text = "Vị trí";
            btnPositionSub.Tag = "Vị trí";
            btnPositionSub.IconChar = IconChar.Circle;
            btnPositionSub.IconColor = MenuItemText;
            btnPositionSub.IconFont = IconFont.Auto;
            btnPositionSub.IconSize = 6;
            btnPositionSub.FlatAppearance.BorderSize = 0;
            btnPositionSub.FlatStyle = FlatStyle.Flat;
            btnPositionSub.UseVisualStyleBackColor = false;
            btnPositionSub.ForeColor = MenuItemText;
            btnPositionSub.BackColor = SubMenuItemBackground;
            btnPositionSub.TextAlign = ContentAlignment.MiddleLeft;
            btnPositionSub.ImageAlign = ContentAlignment.MiddleLeft;
            btnPositionSub.Padding = new Padding(48, 10, 16, 10);
            btnPositionSub.Margin = new Padding(0, 4, 0, 0);
            btnPositionSub.Height = 40;
            btnPositionSub.Width = 224;
            btnPositionSub.Dock = DockStyle.None;
            btnPositionSub.Location = new Point(8, 44);
            btnPositionSub.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPositionSub.Font = new Font("Segoe UI", 9F);
            btnPositionSub.Click += BtnPositionSub_Click;
            ApplyModernButtonStyle(btnPositionSub, true);
            
            IconButton btnUser = new IconButton();
            btnUser.Name = "btnUser";
            btnUser.Text = "Nhân viên";
            btnUser.Tag = "Nhân viên";
            btnUser.IconChar = IconChar.Circle;
            btnUser.IconColor = MenuItemText;
            btnUser.IconFont = IconFont.Auto;
            btnUser.IconSize = 6;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.ForeColor = MenuItemText;
            btnUser.BackColor = SubMenuItemBackground;
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Padding = new Padding(48, 10, 16, 10);
            btnUser.Margin = new Padding(0, 4, 0, 0);
            btnUser.Height = 40;
            btnUser.Width = 224;
            btnUser.Dock = DockStyle.None;
            btnUser.Location = new Point(8, 88);
            btnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUser.Font = new Font("Segoe UI", 9F);
            btnUser.Click += BtnUser_Click;
            ApplyModernButtonStyle(btnUser, true);
            
            IconButton btnRole = new IconButton();
            btnRole.Name = "btnRole";
            btnRole.Text = "Vai trò";
            btnRole.Tag = "Vai trò";
            btnRole.IconChar = IconChar.Circle;
            btnRole.IconColor = MenuItemText;
            btnRole.IconFont = IconFont.Auto;
            btnRole.IconSize = 6;
            btnRole.FlatAppearance.BorderSize = 0;
            btnRole.FlatStyle = FlatStyle.Flat;
            btnRole.UseVisualStyleBackColor = false;
            btnRole.ForeColor = MenuItemText;
            btnRole.BackColor = SubMenuItemBackground;
            btnRole.TextAlign = ContentAlignment.MiddleLeft;
            btnRole.ImageAlign = ContentAlignment.MiddleLeft;
            btnRole.Padding = new Padding(48, 10, 16, 10);
            btnRole.Margin = new Padding(0, 4, 0, 0);
            btnRole.Height = 40;
            btnRole.Width = 224;
            btnRole.Dock = DockStyle.None;
            btnRole.Location = new Point(8, 132);
            btnRole.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRole.Font = new Font("Segoe UI", 9F);
            btnRole.Click += BtnRole_Click;
            ApplyModernButtonStyle(btnRole, true);
            
            subMenuPanel.Controls.Add(btnDepartment);
            subMenuPanel.Controls.Add(btnPositionSub);
            subMenuPanel.Controls.Add(btnUser);
            subMenuPanel.Controls.Add(btnRole);
            
            subMenuPanel.Height = btnDepartment.Height + btnPositionSub.Height + btnUser.Height + btnRole.Height + 16;
            
            int staffIndex = navContainer.Controls.IndexOf(btnStaff);
            if (staffIndex >= 0)
            {
                navContainer.Controls.Add(subMenuPanel);
                navContainer.Controls.SetChildIndex(subMenuPanel, staffIndex + 1);
            }
            
            _subMenuPanels[btnStaff] = subMenuPanel;
            _menuExpandedState[btnStaff] = false;
            
            if (btnStaff.Tag == null || !btnStaff.Tag.ToString().StartsWith("Nhân viên"))
            {
                btnStaff.Tag = "Nhân viên";
            }
        }
        
        
        private void BtnDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmDepartment(), "Quản lý phòng ban", "department");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý phòng ban: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnPositionSub_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmPosition(), "Quản lý vị trí", "position");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý vị trí: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnUser_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmUser(), "Quản lý nhân viên", "user");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý nhân viên: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnRole_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveSubMenuItem(sender as IconButton);
                LoadChildFormInTab(new FrmRole(), "Quản lý vai trò", "role");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý vai trò: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SetActiveSubMenuItem(IconButton button)
        {
            if (_activeSubMenuItem != null && _activeSubMenuItem != button)
            {
                _activeSubMenuItem.BackColor = SubMenuItemBackground;
                _activeSubMenuItem.ForeColor = MenuItemText;
                _activeSubMenuItem.IconColor = MenuItemText;
                _activeSubMenuItem.Invalidate();
            }
          
            _activeSubMenuItem = button;
            if (button != null)
            {
                button.BackColor = SubMenuItemActive;
                button.ForeColor = MenuItemActiveText;
                button.IconColor = MenuItemActiveText;
                button.Invalidate();
            }
        }
        
        private void SetActiveMenuItem(IconButton button)
        {
           
            if (_activeMenuItem != null && _activeMenuItem != button)
            {
                _activeMenuItem.BackColor = MenuItemBackground;
                _activeMenuItem.ForeColor = MenuItemText;
                _activeMenuItem.IconColor = MenuItemText;
                _activeMenuItem.Invalidate();
            }
            
            _activeMenuItem = button;
            if (button != null)
            {
                button.BackColor = MenuItemActive;
                button.ForeColor = MenuItemActiveText;
                button.IconColor = MenuItemActiveText;
                button.Invalidate();
            }
        }

        private void navButton_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void navButton_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _sidebarExpanded = !_sidebarExpanded;
            UpdateSidebarState();
        }

        private void UpdateSidebarState(bool force = false)
        {
            int headerHeight = headerPanel.Height;
            int formHeight = this.ClientSize.Height;
            int formWidth = this.ClientSize.Width;

            sidebarPanel.Width = _sidebarExpanded ? ExpandedSidebarWidth : CollapsedSidebarWidth;
            sidebarPanel.Location = new Point(0, headerHeight);
            sidebarPanel.Height = formHeight - headerHeight;

            navContainer.Location = new Point(0, 0);
            navContainer.Size = new Size(sidebarPanel.Width, sidebarPanel.Height);

            contentPanel.Location = new Point(sidebarPanel.Width, headerHeight);
            contentPanel.Size = new Size(formWidth - sidebarPanel.Width, formHeight - headerHeight);

            if (_mainTabControl != null)
            {
                _mainTabControl.Size = new Size(contentPanel.Width, contentPanel.Height);
            }

            foreach (var button in _navigationButtons)
            {
                var isToggleButton = button == btnToggleSidebar;
                var horizontalPadding = _sidebarExpanded ? 16 : 8;

                if (!isToggleButton)
                {
                    var label = button.Tag?.ToString() ?? string.Empty;
                    if (label.Contains("|"))
                    {
                        label = label.Split('|')[0];
                    }

                    if (_subMenuPanels.ContainsKey(button) && _sidebarExpanded)
                    {
                        bool isExpanded = _menuExpandedState.ContainsKey(button) && _menuExpandedState[button];
                        button.Text = label + "  " + (isExpanded ? "▲" : "▼");
                    }
                    else
                    {
                        button.Text = _sidebarExpanded ? label : string.Empty;
                    }

                    button.Padding = _sidebarExpanded ? new Padding(16, 0, 16, 0) : new Padding(0);
                    button.TextAlign = _sidebarExpanded ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
                    button.ImageAlign = _sidebarExpanded ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;

                    if (_sidebarExpanded)
                    {
                        button.Margin = new Padding(8, 4, 8, 4);
                        button.Height = 44;
                    }
                    else
                    {
                        button.Margin = new Padding(4, 4, 4, 4);
                        button.Height = 44;
                    }
                }
                else
                {
                    button.Text = _sidebarExpanded ? "<<" : ">>";
                    button.Padding = new Padding(0);
                    button.TextAlign = ContentAlignment.MiddleCenter;
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.Margin = new Padding(8, 8, 8, 8);
                }

                button.Width = sidebarPanel.Width - horizontalPadding;

                if (!isToggleButton)
                {
                    if (button != _activeMenuItem && button != _activeSubMenuItem)
                    {
                        bool isSubItem = _subMenuPanels.Values.Any(panel => panel.Controls.Contains(button));
                        if (isSubItem)
                        {
                            button.BackColor = SubMenuItemBackground;
                            button.ForeColor = MenuItemText;
                            button.IconColor = MenuItemText;
                        }
                        else
                        {
                            button.BackColor = MenuItemBackground;
                            button.ForeColor = MenuItemText;
                            button.IconColor = MenuItemText;
                        }
                    }
                    button.UseVisualStyleBackColor = false;
                    button.Invalidate();
                }

                foreach (var kvp in _subMenuPanels)
                {
                    bool shouldBeVisible = _sidebarExpanded &&
                        (_menuExpandedState.ContainsKey(kvp.Key) && _menuExpandedState[kvp.Key]);
                    kvp.Value.Visible = shouldBeVisible;
                    kvp.Value.Width = sidebarPanel.Width;

                    foreach (Control control in kvp.Value.Controls)
                    {
                        if (control is IconButton subBtn)
                        {
                            subBtn.Width = _sidebarExpanded ? sidebarPanel.Width - 32 : 0;
                            subBtn.Text = _sidebarExpanded ? (subBtn.Tag?.ToString() ?? string.Empty) : string.Empty;
                        }
                    }
                }

            navContainer.Padding = _sidebarExpanded ? new Padding(12, 16, 12, 16) : new Padding(4, 16, 4, 16);
            
            // Update chevron in button text/icon area
            if (_subMenuPanels.ContainsKey(btnStaff))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnStaff) && _menuExpandedState[btnStaff];
                UpdateStaffChevron(isExpanded);
            }
            
            if (_subMenuPanels.ContainsKey(btnMenu))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnMenu) && _menuExpandedState[btnMenu];
                UpdateMenuChevron(isExpanded);
            }
            
            navContainer.Refresh();

                if (_subMenuPanels.ContainsKey(btnReport))
                {
                    bool isExpanded = _menuExpandedState.ContainsKey(btnReport) && _menuExpandedState[btnReport];
                    UpdateReportChevron(isExpanded);
                }

                if (_subMenuPanels.ContainsKey(btnStaff))
                {
                    bool isExpanded = _menuExpandedState.ContainsKey(btnStaff) && _menuExpandedState[btnStaff];
                    UpdateStaffChevron(isExpanded);
                }

                if (_subMenuPanels.ContainsKey(btnMenu))
                {
                    bool isExpanded = _menuExpandedState.ContainsKey(btnMenu) && _menuExpandedState[btnMenu];
                    UpdateMenuChevron(isExpanded);
                }

                navContainer.Refresh();

                if (force)
                {
                    sidebarPanel.PerformLayout();
                }
            }
        }


        private void btnUserMenu_Click(object sender, EventArgs e)
        {
            ShowUserContextMenu();
        }

        private void UpdateUserInfo()
        {
            if (_currentUser != null)
            {
                try
                {
                    if (this.Controls.Find("lblUserName", true).FirstOrDefault() is Label lblUserName)
                    {
                        lblUserName.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
                    }
                    
                    if (this.Controls.Find("lblRoleDescription", true).FirstOrDefault() is Label lblRoleDescription)
                    {
                        lblRoleDescription.Text = _currentUser.Role?.RoleName ?? "Người dùng";
                    }
                }
                catch
                {
                }
            }
        }

        private void menuItemProfile_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                string userInfo = $"Tên người dùng: {_currentUser.FirstName} {_currentUser.LastName}\n" +
                                $"Tài khoản: {_currentUser.UserName}\n" +
                                $"Số điện thoại: {_currentUser.PhoneNumber ?? "Chưa cập nhật"}\n" +
                                $"Vai trò: {_currentUser.Role?.RoleName ?? "Chưa xác định"}\n" +
                                $"Trạng thái: {(_currentUser.Status == UserStatus.active ? "Hoạt động" : "Không hoạt động")}";
                
                MessageBox.Show(userInfo, "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có thông tin người dùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuItemPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Tính năng cập nhật mật khẩu sẽ được triển khai ở các phiên bản sau.",
                "Cập nhật mật khẩu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowUserContextMenu()
        {
            if (userContextMenu == null)
            {
                return;
            }

            var menuWidth = userContextMenu.PreferredSize.Width;
            var x = Math.Max(0, userPanel.Width - menuWidth);
            var point = new Point(x, userPanel.Height);
            userContextMenu.Show(userPanel, point);
        }

        private void InitializeTabControl()
        {
            _mainTabControl = new TabControl();
            _mainTabControl.Dock = DockStyle.Fill;
            _mainTabControl.Alignment = TabAlignment.Top;
            _mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            _mainTabControl.SizeMode = TabSizeMode.Fixed;
            _mainTabControl.ItemSize = new Size(0, 1);
            _mainTabControl.Appearance = TabAppearance.FlatButtons;
            
            _mainTabControl.DrawItem += TabControl_DrawItem;
            _mainTabControl.MouseDown += TabControl_MouseDown;
            _mainTabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            
            contentPanel.Controls.Add(_mainTabControl);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            
            Color backColor = e.State == DrawItemState.Selected ? SystemColors.Highlight : SystemColors.Window;
            Color textColor = e.State == DrawItemState.Selected ? SystemColors.HighlightText : SystemColors.ControlText;
            Color borderColor = SystemColors.ControlDark;
            
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }
            
            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, tabRect);
            }
            
            string tabText = tabPage.Text;
            if (tabText.Length > 15)
            {
                tabText = tabText.Substring(0, 12) + "...";
            }
            
            TextRenderer.DrawText(e.Graphics, tabText, tabControl.Font, tabRect, textColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            
            if (tabControl.TabPages.Count > 0)
            {
                Rectangle closeRect = new Rectangle(tabRect.Right - 20, tabRect.Top + 8, 14, 14);
                using (Pen pen = new Pen(textColor, 2))
                {
                    e.Graphics.DrawLine(pen, closeRect.Left + 3, closeRect.Top + 3, closeRect.Right - 3, closeRect.Bottom - 3);
                    e.Graphics.DrawLine(pen, closeRect.Right - 3, closeRect.Top + 3, closeRect.Left + 3, closeRect.Bottom - 3);
                }
            }
        }

        private void TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < _mainTabControl.TabPages.Count; i++)
                {
                    Rectangle tabRect = _mainTabControl.GetTabRect(i);
                    Rectangle closeRect = new Rectangle(tabRect.Right - 20, tabRect.Top + 8, 14, 14);
                    
                    if (closeRect.Contains(e.Location))
                    {
                        CloseTab(i);
                        break;
                    }
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mainTabControl.SelectedTab != null)
            {
                if (this.Controls.Find("lblSectionTitle", true).FirstOrDefault() is Label lblSectionTitle)
                {
                    lblSectionTitle.Text = _mainTabControl.SelectedTab.Text;
                }
            }
        }

        private void LoadChildFormInTab(Form childForm, string title, string tabKey)
        {
            if (_openTabs.ContainsKey(tabKey))
            {
                for (int i = 0; i < _mainTabControl.TabPages.Count; i++)
                {
                    if (_mainTabControl.TabPages[i].Name == tabKey)
                    {
                        _mainTabControl.SelectedIndex = i;
                        return;
                    }
                }
            }

            placeholderPanel.Visible = false;
            _mainTabControl.Visible = true;
            _mainTabControl.BringToFront();

            TabPage tabPage = new TabPage(title);
            tabPage.Name = tabKey;
            tabPage.Padding = new Padding(3);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            childForm.Location = new Point(0, 0);

            tabPage.Controls.Add(childForm);

            _mainTabControl.TabPages.Add(tabPage);
            _mainTabControl.SelectedTab = tabPage;
            
            Rectangle tabPageClientRect = tabPage.DisplayRectangle;
            childForm.Size = new Size(tabPageClientRect.Width, tabPageClientRect.Height);
            childForm.Show();

            _openTabs[tabKey] = childForm;

            if (this.Controls.Find("lblSectionTitle", true).FirstOrDefault() is Label lblSectionTitle)
            {
                lblSectionTitle.Text = title;
            }
        }

        private void ShowPlaceholder()
        {
            _mainTabControl.Visible = false;

            placeholderPanel.Visible = true;
            placeholderPanel.BringToFront();

            if (this.Controls.Find("lblSectionTitle", true).FirstOrDefault() is Label lblSectionTitle)
            {
                lblSectionTitle.Text = "Hệ thống quản lý";
            }
        }

        private void CloseTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < _mainTabControl.TabPages.Count)
            {
                TabPage tabPage = _mainTabControl.TabPages[tabIndex];
                string tabKey = tabPage.Name;

               
                if (_openTabs.ContainsKey(tabKey))
                {
                    Form form = _openTabs[tabKey];
                    form.Close();
                    form.Dispose();
                    _openTabs.Remove(tabKey);
                }

                _mainTabControl.TabPages.RemoveAt(tabIndex);

                if (_mainTabControl.TabPages.Count == 0)
                {
                    ShowPlaceholder();
                }
            }
        }

      
        private void lblUserName_Click(object sender, EventArgs e)
        {

        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!_sidebarExpanded)
            {
                return;
            }
            
            SetActiveMenuItem(btnMenu);
            
            if (_subMenuPanels.ContainsKey(btnMenu))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnMenu) && _menuExpandedState[btnMenu];
                _menuExpandedState[btnMenu] = !isExpanded;
                
                _subMenuPanels[btnMenu].Visible = !isExpanded;
                
                UpdateMenuChevron(!isExpanded);
                
                navContainer.PerformLayout();
                navContainer.Refresh();
            }
        }
        
        private void UpdateMenuChevron(bool isExpanded)
        {
            string baseText = btnMenu.Tag?.ToString() ?? "Thực đơn";
            if (baseText.Contains("|"))
            {
                baseText = baseText.Split('|')[0];
            }
            
            if (_sidebarExpanded)
            {
                btnMenu.Text = baseText + "  " + (isExpanded ? "▲" : "▼");
            }
            else
            {
                btnMenu.Text = string.Empty;
            }
        }

        private void UpdateReportChevron(bool isExpanded)
        {
            string baseText = btnReport.Tag?.ToString() ?? "Thống kê";
            if (baseText.Contains("|"))
            {
                baseText = baseText.Split('|')[0];
            }

            if (_sidebarExpanded)
            {
                btnReport.Text = baseText + "  " + (isExpanded ? "▲" : "▼");
            }
            else
            {
                btnReport.Text = string.Empty;
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveMenuItem(btnOrders);
                LoadChildFormInTab(new FrmPOS(), "Bán hàng", "pos");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form bán hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveMenuItem(btnReservations);
                LoadChildFormInTab(new FrmReservation(), "Đặt bàn trước", "reservation");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form đặt bàn trước: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveMenuItem(btnTables);
                LoadChildFormInTab(new FrmTable(), "Quản lý bàn", "table");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý bàn: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVouchers_Click(object sender, EventArgs e)
        {
            try
            {
                SetActiveMenuItem(btnVouchers);
                LoadChildFormInTab(new FrmVoucher(), "Quản lý Voucher", "voucher");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
        
            if (!_sidebarExpanded)
            {
                return;
            }
            
           
            SetActiveMenuItem(btnStaff);
            
         
            if (_subMenuPanels.ContainsKey(btnStaff))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnStaff) && _menuExpandedState[btnStaff];
                _menuExpandedState[btnStaff] = !isExpanded;
                _subMenuPanels[btnStaff].Visible = !isExpanded;            
                UpdateStaffChevron(!isExpanded);
                navContainer.PerformLayout();
                navContainer.Refresh();
            }
        }
        
        private void UpdateStaffChevron(bool isExpanded)
        {
           
            string baseText = btnStaff.Tag?.ToString() ?? "Nhân viên";
            if (baseText.Contains("|"))
            {
                baseText = baseText.Split('|')[0];
            }
            
            if (_sidebarExpanded)
            {
               
                btnStaff.Text = baseText + "  " + (isExpanded ? "▲" : "▼");
            }
            else
            {
                btnStaff.Text = string.Empty;
            }
        }

     
        private void btnPosition_Click(object sender, EventArgs e)
        {
           
            BtnPositionSub_Click(sender, e);
        }

		private void lblPlaceholderHint_Click(object sender, EventArgs e)
		{

		}

		private void btnTables_Click_1(object sender, EventArgs e)
		{

		}

		private void btnDashboard_Click(object sender, EventArgs e)
		{
			ShowPlaceholder();
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
            if (!_sidebarExpanded)
            {
                return;
            }

            SetActiveMenuItem(btnReport);

            if (_subMenuPanels.ContainsKey(btnReport))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnReport) && _menuExpandedState[btnReport];
                _menuExpandedState[btnReport] = !isExpanded;
                _subMenuPanels[btnReport].Visible = !isExpanded;
                UpdateReportChevron(!isExpanded);
                navContainer.PerformLayout();
                navContainer.Refresh();
            }
		}
	}
}

