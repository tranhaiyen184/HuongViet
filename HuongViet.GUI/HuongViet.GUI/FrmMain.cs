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
        
        private void InitializeStaffSubMenu()
        {
            // Create sub-menu panel for Staff
            Panel subMenuPanel = new Panel();
            subMenuPanel.Name = "subMenuStaff";
            subMenuPanel.Height = 0; // Start collapsed
            subMenuPanel.Visible = false;
            subMenuPanel.Margin = new Padding(8, 0, 8, 0);
            subMenuPanel.Padding = new Padding(0);
            subMenuPanel.AutoSize = false;
            subMenuPanel.Width = 240;
            subMenuPanel.BackColor = SidebarBackground;
            
            // Create Department sub-item
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
            btnDepartment.UseVisualStyleBackColor = false; // Important!
            btnDepartment.ForeColor = MenuItemText;
            btnDepartment.BackColor = SubMenuItemBackground;
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.ImageAlign = ContentAlignment.MiddleLeft;
            btnDepartment.Padding = new Padding(48, 10, 16, 10);
            btnDepartment.Margin = new Padding(0, 4, 0, 0);
            btnDepartment.Height = 40;
            btnDepartment.Width = 224;
            btnDepartment.Dock = DockStyle.Top;
            btnDepartment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDepartment.Font = new Font("Segoe UI", 9F);
            btnDepartment.Click += BtnDepartment_Click;
            ApplyModernButtonStyle(btnDepartment, true);
            
            // Create Position sub-item
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
            btnPositionSub.UseVisualStyleBackColor = false; // Important!
            btnPositionSub.ForeColor = MenuItemText;
            btnPositionSub.BackColor = SubMenuItemBackground;
            btnPositionSub.TextAlign = ContentAlignment.MiddleLeft;
            btnPositionSub.ImageAlign = ContentAlignment.MiddleLeft;
            btnPositionSub.Padding = new Padding(48, 10, 16, 10);
            btnPositionSub.Margin = new Padding(0, 4, 0, 0);
            btnPositionSub.Height = 40;
            btnPositionSub.Width = 224;
            btnPositionSub.Dock = DockStyle.Top;
            btnPositionSub.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPositionSub.Font = new Font("Segoe UI", 9F);
            btnPositionSub.Click += BtnPositionSub_Click;
            ApplyModernButtonStyle(btnPositionSub, true);
            
            // Create User (Nhân viên) sub-item
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
            btnUser.UseVisualStyleBackColor = false; // Important!
            btnUser.ForeColor = MenuItemText;
            btnUser.BackColor = SubMenuItemBackground;
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Padding = new Padding(48, 10, 16, 10);
            btnUser.Margin = new Padding(0, 4, 0, 0);
            btnUser.Height = 40;
            btnUser.Width = 224;
            btnUser.Dock = DockStyle.Top;
            btnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUser.Font = new Font("Segoe UI", 9F);
            btnUser.Click += BtnUser_Click;
            ApplyModernButtonStyle(btnUser, true);
            
            // Create Role (Vai trò) sub-item
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
            btnRole.UseVisualStyleBackColor = false; // Important!
            btnRole.ForeColor = MenuItemText;
            btnRole.BackColor = SubMenuItemBackground;
            btnRole.TextAlign = ContentAlignment.MiddleLeft;
            btnRole.ImageAlign = ContentAlignment.MiddleLeft;
            btnRole.Padding = new Padding(48, 10, 16, 10);
            btnRole.Margin = new Padding(0, 4, 0, 0);
            btnRole.Height = 40;
            btnRole.Width = 224;
            btnRole.Dock = DockStyle.Top;
            btnRole.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRole.Font = new Font("Segoe UI", 9F);
            btnRole.Click += BtnRole_Click;
            ApplyModernButtonStyle(btnRole, true);
            
            // Add sub-items to panel (in reverse order for Dock.Top)
            subMenuPanel.Controls.Add(btnRole);
            subMenuPanel.Controls.Add(btnUser);
            subMenuPanel.Controls.Add(btnPositionSub);
            subMenuPanel.Controls.Add(btnDepartment);
            
            // Calculate total height (including margins)
            subMenuPanel.Height = btnDepartment.Height + btnPositionSub.Height + btnUser.Height + btnRole.Height + 16; // 16 for margins
            
            // Find btnStaff in navContainer and insert sub-menu after it
            int staffIndex = navContainer.Controls.IndexOf(btnStaff);
            if (staffIndex >= 0)
            {
                navContainer.Controls.Add(subMenuPanel);
                navContainer.Controls.SetChildIndex(subMenuPanel, staffIndex + 1);
            }
            
            // Store references
            _subMenuPanels[btnStaff] = subMenuPanel;
            _menuExpandedState[btnStaff] = false;
            
            // Ensure btnStaff tag is set correctly
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
            // Reset previous active sub-item
            if (_activeSubMenuItem != null && _activeSubMenuItem != button)
            {
                _activeSubMenuItem.BackColor = SubMenuItemBackground;
                _activeSubMenuItem.ForeColor = MenuItemText;
                _activeSubMenuItem.IconColor = MenuItemText;
                _activeSubMenuItem.Invalidate();
            }
            
            // Set new active sub-item
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
            // Reset previous active item
            if (_activeMenuItem != null && _activeMenuItem != button)
            {
                _activeMenuItem.BackColor = MenuItemBackground;
                _activeMenuItem.ForeColor = MenuItemText;
                _activeMenuItem.IconColor = MenuItemText;
                _activeMenuItem.Invalidate();
            }
            
            // Set new active item
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
            // Handled by ModernButton_MouseEnter
        }

        private void navButton_MouseLeave(object sender, EventArgs e)
        {
            // Handled by ModernButton_MouseLeave
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _sidebarExpanded = !_sidebarExpanded;
            UpdateSidebarState();
        }

        private void UpdateSidebarState(bool force = false)
        {
            sidebarPanel.Width = _sidebarExpanded ? ExpandedSidebarWidth : CollapsedSidebarWidth;

            foreach (var button in _navigationButtons)
            {
                var isToggleButton = button == btnToggleSidebar;
                var horizontalPadding = _sidebarExpanded ? 16 : 8;

                if (!isToggleButton)
                {
                    var label = button.Tag?.ToString() ?? string.Empty;
                    // Clean label if it contains pipe separator
                    if (label.Contains("|"))
                    {
                        label = label.Split('|')[0];
                    }
                    
                    // Special handling for expandable menus
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
                    
                    // Apply modern spacing
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
                
                // Ensure colors are maintained
                if (!isToggleButton)
                {
                    // Re-apply colors if not active
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
                    button.UseVisualStyleBackColor = false; // Ensure this is false
                    button.Invalidate(); // Refresh button
                }
            }
            
            // Update sub-menu visibility and width
            foreach (var kvp in _subMenuPanels)
            {
                bool shouldBeVisible = _sidebarExpanded && 
                    (_menuExpandedState.ContainsKey(kvp.Key) && _menuExpandedState[kvp.Key]);
                kvp.Value.Visible = shouldBeVisible;
                kvp.Value.Width = sidebarPanel.Width;
                
                // Update sub-menu items
                foreach (Control control in kvp.Value.Controls)
                {
                    if (control is IconButton subBtn)
                    {
                        subBtn.Width = _sidebarExpanded ? sidebarPanel.Width - 32 : 0; // Account for margins
                        subBtn.Text = _sidebarExpanded ? (subBtn.Tag?.ToString() ?? string.Empty) : string.Empty;
                    }
                }
            }

            navContainer.Padding = _sidebarExpanded ? new Padding(12, 16, 12, 16) : new Padding(4, 16, 4, 16);
            
            // Update chevron in button text
            if (_subMenuPanels.ContainsKey(btnStaff))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnStaff) && _menuExpandedState[btnStaff];
                UpdateStaffChevron(isExpanded);
            }
            
            navContainer.Refresh();

            if (force)
            {
                sidebarPanel.PerformLayout();
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
                // Update user display (assuming you have labels for user info)
                // You may need to check if these controls exist in your form
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
                    // Ignore if controls don't exist
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
            // Create and configure TabControl
            _mainTabControl = new TabControl();
            _mainTabControl.Dock = DockStyle.Fill;
            _mainTabControl.Alignment = TabAlignment.Top;
            _mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            _mainTabControl.SizeMode = TabSizeMode.Fixed;
            _mainTabControl.ItemSize = new Size(150, 30);
            _mainTabControl.Padding = new Point(20, 4);
            _mainTabControl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            
            // Add event handlers
            _mainTabControl.DrawItem += TabControl_DrawItem;
            _mainTabControl.MouseDown += TabControl_MouseDown;
            _mainTabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            
            // Hide initially
            _mainTabControl.Visible = false;
            
            // Add to content panel
            contentPanel.Controls.Add(_mainTabControl);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            
            // Colors
            Color backColor = e.State == DrawItemState.Selected ? SystemColors.Highlight : SystemColors.Window;
            Color textColor = e.State == DrawItemState.Selected ? SystemColors.HighlightText : SystemColors.ControlText;
            Color borderColor = SystemColors.ControlDark;
            
            // Fill background
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }
            
            // Draw border
            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, tabRect);
            }
            
            // Draw text
            string tabText = tabPage.Text;
            if (tabText.Length > 15)
            {
                tabText = tabText.Substring(0, 12) + "...";
            }
            
            TextRenderer.DrawText(e.Graphics, tabText, tabControl.Font, tabRect, textColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            
            // Draw close button (X)
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
                // Update section title
                if (this.Controls.Find("lblSectionTitle", true).FirstOrDefault() is Label lblSectionTitle)
                {
                    lblSectionTitle.Text = _mainTabControl.SelectedTab.Text;
                }
            }
        }

        private void LoadChildFormInTab(Form childForm, string title, string tabKey)
        {
            // Check if tab already exists
            if (_openTabs.ContainsKey(tabKey))
            {
                // Switch to existing tab
                for (int i = 0; i < _mainTabControl.TabPages.Count; i++)
                {
                    if (_mainTabControl.TabPages[i].Name == tabKey)
                    {
                        _mainTabControl.SelectedIndex = i;
                        return;
                    }
                }
            }

            // Hide placeholder panel
            placeholderPanel.Visible = false;
            _mainTabControl.Visible = true;
            _mainTabControl.BringToFront();

            // Create new tab page
            TabPage tabPage = new TabPage(title);
            tabPage.Name = tabKey;
            tabPage.Padding = new Padding(3);

            // Configure child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add form to tab page
            tabPage.Controls.Add(childForm);
            childForm.Show();

            // Add tab page to tab control
            _mainTabControl.TabPages.Add(tabPage);
            _mainTabControl.SelectedTab = tabPage;

            // Store reference
            _openTabs[tabKey] = childForm;

            // Update section title
            if (this.Controls.Find("lblSectionTitle", true).FirstOrDefault() is Label lblSectionTitle)
            {
                lblSectionTitle.Text = title;
            }
        }

        private void ShowPlaceholder()
        {
            // Hide tab control
            _mainTabControl.Visible = false;

            // Show placeholder panel
            placeholderPanel.Visible = true;
            placeholderPanel.BringToFront();

            // Reset section title
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

                // Dispose form if exists
                if (_openTabs.ContainsKey(tabKey))
                {
                    Form form = _openTabs[tabKey];
                    form.Close();
                    form.Dispose();
                    _openTabs.Remove(tabKey);
                }

                // Remove tab page
                _mainTabControl.TabPages.RemoveAt(tabIndex);

                // If no tabs left, show placeholder
                if (_mainTabControl.TabPages.Count == 0)
                {
                    ShowPlaceholder();
                }
            }
        }

        private void CloseAllTabs()
        {
            while (_mainTabControl.TabPages.Count > 0)
            {
                CloseTab(0);
            }
        }

        private void lblRoleDescription_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        // Additional navigation methods for other buttons
        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement Menu management form
                MessageBox.Show("Tính năng quản lý thực đơn sẽ được triển khai sau.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement Orders management form
                MessageBox.Show("Tính năng quản lý đơn hàng sẽ được triển khai sau.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Clean up all tabs
            CloseAllTabs();
            
            // Dispose tab control
            if (_mainTabControl != null)
            {
                _mainTabControl.Dispose();
            }
            
            base.OnFormClosed(e);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // Only toggle if sidebar is expanded
            if (!_sidebarExpanded)
            {
                return;
            }
            
            // Set as active menu item
            SetActiveMenuItem(btnStaff);
            
            // Toggle sub-menu expansion
            if (_subMenuPanels.ContainsKey(btnStaff))
            {
                bool isExpanded = _menuExpandedState.ContainsKey(btnStaff) && _menuExpandedState[btnStaff];
                _menuExpandedState[btnStaff] = !isExpanded;
                
                // Show/hide sub-menu
                _subMenuPanels[btnStaff].Visible = !isExpanded;
                
                // Update chevron in button text/icon area
                UpdateStaffChevron(!isExpanded);
                
                // Force layout update
                navContainer.PerformLayout();
                navContainer.Refresh();
            }
        }
        
        private void UpdateStaffChevron(bool isExpanded)
        {
            // Update button text to include chevron
            string baseText = btnStaff.Tag?.ToString() ?? "Nhân viên";
            if (baseText.Contains("|"))
            {
                baseText = baseText.Split('|')[0];
            }
            
            if (_sidebarExpanded)
            {
                // Add chevron to text (using Unicode arrow)
                btnStaff.Text = baseText + "  " + (isExpanded ? "▲" : "▼");
            }
            else
            {
                btnStaff.Text = string.Empty;
            }
        }

        // Keep btnPosition_Click for backward compatibility but it should not be called
        private void btnPosition_Click(object sender, EventArgs e)
        {
            // This should not be called as btnPosition is now hidden
            // Redirect to sub-menu item
            BtnPositionSub_Click(sender, e);
        }

		private void lblPlaceholderHint_Click(object sender, EventArgs e)
		{

		}

		private void btnTables_Click_1(object sender, EventArgs e)
		{

		}
	}
}

