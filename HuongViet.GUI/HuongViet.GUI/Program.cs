using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuongViet.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                using (var loginForm = new FrmLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Save logged in user to session
                        SessionManager.CurrentUser = loginForm.LoggedInUser;
                        
                        // Pass logged in user to main form
                        Application.Run(new FrmMain(loginForm.LoggedInUser));
                        //Application.Run(new FrmReservation());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clear session on exit
                SessionManager.ClearSession();
            }
        }
    }
}
