using System;
using GCMS_Business;
using GCMS_Infrastructure;
using GCMS.Device_Rentals;

using System.Windows.Forms;

namespace GCMS.User_Control
{
    public partial class ctrlDeviceRental : UserControl
    {
        //DataMembers Used in this class

        private clsGames _Game; //private game object


        // this control can't be used unless there is a game  that this control will represent
        public ctrlDeviceRental(clsGames Game)
        {
            InitializeComponent();

            _Game = Game;
            lblGameName.Text = _Game.GameName;
        }


        //public event 
        public event EventHandler<clsRentCompletedEventArgs> OnRentCompleted;
        //the event method that will be raised after the table game is completed
        public void RaiseOnRentCompleted( decimal TotalPayment)
        {
            RaiseOnRentCompleted(new clsRentCompletedEventArgs(TotalPayment));
        }
        protected void RaiseOnRentCompleted(clsRentCompletedEventArgs e)
        {
            OnRentCompleted?.Invoke(this, e);
        }



        //this private method load the game in two different ways either for rent or for returning
        private void _Load()
        {
            //if the device is available for rent
            if(!clsDeviceRentals.IsDeviceRentalOnRent(_Game.GameID))
            {
                //Only show the rent button
                btnRent.Visible = true;
                btnReturn.Visible = false;
                lblRenter.Visible = false;
                lblRenterName.Visible = false;
            }
            else
            {
                //Only show the return button
                btnRent.Visible = false;
                btnReturn.Visible = true;
                lblRenter.Visible = true;
                lblRenterName.Visible = true;

                lblRenterName.Text = clsRenters.FindRenter(clsDeviceRentals.GetTheGameRenterID(_Game.GameID)).PersonInfo.FullName();
            }
        }
        private void ctrlDeviceRental_Load(object sender, EventArgs e)
        {
            _Load();
        }




                                     // Rent & Return Buttons

        private void btnRent_Click(object sender, EventArgs e)
        {

            frmRentScreen frm = new frmRentScreen(_Game);
            frm.DataBack += RentScreen_DataBack; //subscribe to the event
            frm.ShowDialog();
        }
        //handle the data that will be back from the rent screen
        private void RentScreen_DataBack(object sender, decimal TotalPayment, bool IsOnDebt)
        {
            _Load(); // will reload the control to the new state which is the device is on rent


            //if the payment is set and not on debt
            //This will invoke the method that will return the total payment
            if (!IsOnDebt)
                RaiseOnRentCompleted(TotalPayment);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmReturnScreen frm = new frmReturnScreen(_Game);
            frm.DataBack += ReturnScreen_DataBack;
            frm.ShowDialog();
        }

        private void ReturnScreen_DataBack(object sender, decimal TotalPayment)
        {
            _Load(); // will reload the control to the new state which is the device is on rent


            //if the debt has been paid 
            //This will invoke the method that will return the total payment
            if (TotalPayment != 0)
                RaiseOnRentCompleted(TotalPayment);
        }

        
    }
}
