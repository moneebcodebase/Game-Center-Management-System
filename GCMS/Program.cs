using System;
using System.Windows.Forms;
using GCMS.Login;


namespace GCMS
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


            bool exitApp = false;

            while (!exitApp)
            {
                //Show Login Form as dialog
                using (frmLoginScreen loginForm = new frmLoginScreen())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        //If login successful, show Main Form as dialog
                        using (frmMain mainForm = new frmMain())
                        {
                            DialogResult result = mainForm.ShowDialog();

                            if (result == DialogResult.Abort)
                            {
                                // User choose to exit app from Main Form
                                exitApp = true;
                            }
                            else
                            {

                            }//loop continues to show login again on logout
                        }
                    }
                    else
                    {
                        // Login cancelled or failed ➔ exit app
                        exitApp = true;
                    }
                }
            }



        }
    }
}
