using GCMS.Debts;
using GCMS.Game_Manaegement;
using GCMS.Renters;
using GCMS.Reports;
using GCMS.Store;
using GCMS.User_Control;
using GCMS.Users;
using GCMS_Business;
using GCMS_Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCMS
{
    public partial class frmMain : Form
    {
        //this is used to know which gametype will be used in the flowlayoutpanal
        private enum enGameType { PoolTable=1,TennisTable=2,FoosballTable=3,Playstation=4,ChessTable,DeviceRental};



        public frmMain()
        {
            InitializeComponent();
        }



        //Closing the form button
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult Result= MessageBox.Show("Are you sure you want to close the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
                this.Close();
            else
                return;
        }
        //Minimizing the form
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState =FormWindowState.Minimized;
        }


        //timmer tick event to handle the watch
        private void TimerClock_Tick(object sender, EventArgs e)
        {
            // Update every second with the system’s current date and time
            lblWatchDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy  hh:mm:ss tt");
        }


        //Status strip lable changes
        private void btnUser_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to view user information.";
        }

        private void btnDeviceRentals_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to view device rentals.";
        }

        private void btnDebts_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to view all debts.";
        }

        private void btnStore_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to go to store.";
        }

        private void btnManagement_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to manage the system.";
        }

        private void btnAccountSetting_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Click to set your account.";
        }

        private void pnlDashboard_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "© 2025 moneebcodebase.";
        }

        private void tcGAMES_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "GCMS Games.";
        }

        private void flpPoolTables_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Pool Tables Section.";
        }

        private void flpTennisTables_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Tennis Tables Section.";
        }

        private void flpFoosballTables_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Foosball Tables Section.";
        }

        private void flpPlaystations_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Playstations Section.";
        }

        private void flpChessTables_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Chess Tables Section.";
        }

        private void flpDeviceRentals_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "Device Rentals Section.";
        }

        private void pnlTotalCash_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = $"Total Earnings in {DateTime.Now.ToShortDateString()}.";
        }

        private void pnlTotalHours_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = $"Total Hours in {DateTime.Now.ToShortDateString()}.";
        }

        private void frmMain_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "© 2025 moneebcodebase.";
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "© 2025 moneebcodebase.";
        }
        private void btnReports_MouseHover(object sender, EventArgs e)
        {
            SSTLabel1.Text = "GCMS Reports.";
        }


        // this method is used to add the new payment to the total payment
        private void _AddNewPaymentToTotalPayment(decimal NewPayment)
        {
            decimal CurrentTotalPayment = Convert.ToDecimal(lblTotalCash.Text.Substring(1));
            CurrentTotalPayment += NewPayment;

            lblTotalCash.Text = "$" + CurrentTotalPayment.ToString();
        }
        private void _AddNewTimeToTotalWorkTime(int Seconds)
        {
            //Get the current time string
            string CurrentTimeString = lblTotalTime.Text;

            // convert the current time to timespan
            TimeSpan CurrentTime = TimeSpan.Parse(CurrentTimeString);

            //Add the seconds to the current time 
            CurrentTime = CurrentTime.Add(TimeSpan.FromSeconds(Seconds));

            // update the totaltime label
            lblTotalTime.Text = CurrentTime.ToString(@"hh\:mm\:ss");
        }




        //Methods to fill the flow layout panals

        private async void _FillPlaystaions()
        {
            flpPlaystations.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsGames> Playstations = clsGames.GetGamesListByGameType((int)enGameType.Playstation);

            if (Playstations != null)
            {

                foreach (var game in Playstations)
                {
                    ctrlPlaystation Playstation = new ctrlPlaystation(game);
                    Playstation.Margin = new Padding(10); // space between controls
                    Playstation.OnTableCompleted += CtrlGameCompleted_OnTableCompleted;//Subscribe to the control event
                    flpPlaystations.Controls.Add(Playstation);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);

                }
            }
            

        }

        private async void _FillPoolTables()
        {
            flpPoolTables.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsGames> PoolGames = clsGames.GetGamesListByGameType((int)enGameType.PoolTable);

            if( PoolGames != null)
            {
                foreach (var game in PoolGames)
                {
                    ctrlPools ctrlPool = new ctrlPools(game);
                    ctrlPool.Margin = new Padding(10); // space between controls
                    ctrlPool.OnTableCompleted += CtrlGameCompleted_OnTableCompleted;//Subscribe to the control event
                    flpPoolTables.Controls.Add(ctrlPool);

                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);
                }
            }
           
            
        }

        private async void _FillTennisTables()
        {
            flpTennisTables.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsGames> TennisGames = clsGames.GetGamesListByGameType((int)enGameType.TennisTable);
            if(TennisGames != null)
            {
                foreach (var game in TennisGames)
                {
                    ctrlTennisTable ctrlTennis = new ctrlTennisTable(game);
                    ctrlTennis.Margin = new Padding(10); // space between controls
                    ctrlTennis.OnTableCompleted += CtrlGameCompleted_OnTableCompleted;//Subscribe to the control event
                    flpTennisTables.Controls.Add(ctrlTennis);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);

                }
            }
           
            
        }

        private async void _FillFoosballTables()
        {
            flpFoosballTables.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsGames> FoosballGames = clsGames.GetGamesListByGameType((int)enGameType.FoosballTable);

            if(FoosballGames != null)
            {
                
                foreach (var game in FoosballGames)
                {
                    ctrlFoosballTable ctrlFoosball = new ctrlFoosballTable(game);
                    ctrlFoosball.Margin = new Padding(10); // space between controls
                    ctrlFoosball.OnTableCompleted += CtrlGameCompleted_OnTableCompleted;//Subscribe to the control event
                    flpFoosballTables.Controls.Add(ctrlFoosball);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);

                }
            }
           
           
        }

        private async void _FillChessTables()
        {
            flpChessTables.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsGames> ChessTables = clsGames.GetGamesListByGameType((int)enGameType.ChessTable);

            if (ChessTables != null)
            {

                foreach (var game in ChessTables)
                {
                    ctrlChessTable ChessTable = new ctrlChessTable(game);
                    ChessTable.Margin = new Padding(10); // space between controls
                    ChessTable.OnTableCompleted += CtrlGameCompleted_OnTableCompleted;//Subscribe to the control event
                    flpChessTables.Controls.Add(ChessTable);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);

                }
            }
            

        }
        private async void _FillDeviceRentals()
        {
            flpDeviceRentals.Controls.Clear(); // Clear old controls

            //getting all Device Rentals
            List<clsGames> DeviceRentals = clsGames.GetGamesListByGameType((int)enGameType.DeviceRental);

            if (DeviceRentals != null)
            {

                foreach (var game in DeviceRentals)
                {
                    ctrlDeviceRental DeviceRental = new ctrlDeviceRental(game);
                    DeviceRental.Margin = new Padding(10); // space between controls
                    DeviceRental.OnRentCompleted += CtrlRentalCompleted_OnRentCompleted;//Subscribe to the control event
                    flpDeviceRentals.Controls.Add(DeviceRental);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(50);

                }
            }
           
        }

        //This event will handle the data that will be back from all the games tables
        private void CtrlGameCompleted_OnTableCompleted(object sender, clsCompletedEventArgs e)
        {
            _AddNewPaymentToTotalPayment(e.TotalPayment);
            _AddNewTimeToTotalWorkTime(e.Seconds);


            //any code that are releated to what should the program do when any game is finshed
        }

        //This event will handle the data that will be back from all the Device rentals
        private void CtrlRentalCompleted_OnRentCompleted(object sender, clsRentCompletedEventArgs e)
        {
            _AddNewPaymentToTotalPayment(e.TotalPayment);
            
            //you can any code that are releated to what should the program do when any rent is completed
        }


        //Main screen load event
        private void frmMain_Load(object sender, EventArgs e)
        {
            //starting the timer
            TimerClock.Start();
            // Update every second with the system’s current date and time
            lblWatchDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy  hh:mm:ss tt");
            

            btnUsername.Text = clsUserSession.CurrentUser.Username.ToString();


            //filling the main form with all games
            _FillPlaystaions();
            _FillPoolTables();
            _FillTennisTables();
            _FillFoosballTables();
            _FillChessTables();
            _FillDeviceRentals();
        }



        //Main menue buttons
        private void btnUsername_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsUserSession.CurrentUser);
            frm.ShowDialog();

            //Update the main screen showen username incase if the username has changed after the user
            //got into the user info screen
            btnUsername.Text =clsUserSession.CurrentUser.Username.ToString();
        }

        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
           
            if (clsUserSession.CurrentUser.Role == "Supervisor")
            {
                frmUsersManagement frm = new frmUsersManagement();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denied! Please Contact Your Supervisor.", "access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnGamesManagement_Click(object sender, EventArgs e)
        {
            if (clsUserSession.CurrentUser.Role == "Supervisor" || clsUserSession.CurrentUser.Role == "Admin")
            {
                frmGamesManagement frm = new frmGamesManagement();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denied! Please Contact Your Supervisor Or Admin.", "access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            frmStore frm = new frmStore();
            frm.ShowDialog();
        }

        private void btnDebts_Click(object sender, EventArgs e)
        {
            frmDebts frm = new frmDebts();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (clsUserSession.CurrentUser.Role == "Supervisor" || clsUserSession.CurrentUser.Role == "Admin")
            {
                frmReports frm = new frmReports();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denied! Please Contact Your Supervisor Or Admin.", "access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

       
        private void Renters_Click(object sender, EventArgs e)
        {
            frmRenters frm = new frmRenters();
            frm.ShowDialog();
        }



       
    }
}
