using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Business;

namespace GCMS.Device_Rentals
{
    public partial class frmReturnScreen : Form
    {
        //private members used in this form
        private clsGames _Game;
        private clsDeviceRentals _DeviceRental;

        //Constructor
        public frmReturnScreen(clsGames Game)
        {
            InitializeComponent();

            _Game = Game;
            _DeviceRental = clsDeviceRentals.FindActiveDeviceRentalForAGame(_Game.GameID);
        }



        //declaring a delegate
        public delegate void DataBackEventHandler(object sender, decimal TotalPayment);
        //declare an event using the delegate
        public event DataBackEventHandler DataBack;



        private void _Load()
        {
            lblGameID.Text = _Game.GameID.ToString();
            lblGameType.Text = _Game.GameType.GameTypeName.ToString();
            lblGameName.Text = _Game.GameName.ToString();
            lblRetePerHour.Text ="$"+_Game.Rate.ToString();
            lblRenterName.Text = _DeviceRental.RenterInfo.PersonInfo.FullName();
            lblTotalPayment.Text = "$"+_DeviceRental.RentalInfo.TotalFees.ToString();

            if(_DeviceRental.RentalInfo.PaymentID == null)
            {
                gbPaymentMethods.Visible = true;
                rbCash.Checked = true;
                
            }
        }
        private void frmReturnScreen_Load(object sender, EventArgs e)
        {
            _Load();
        }


        private byte _GetPaymentMethodID()
        {
            if (rbCash.Checked)
                return 1;
            else if (rbVisa.Checked)
                return 2;
            else
                return 3;
        }



        private void _PreformDeviceReturnForNonDebtRental()
        {
            _DeviceRental.RentalStatus = "Completed";
            if (_DeviceRental.Save())
            {
                btnReturn.Enabled = false;

                MessageBox.Show("The device is returned", "Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, 0); //the total payment inovked as 0 because the payment has been done before
            }
            else
            {
                btnReturn.Enabled = true;

                MessageBox.Show("Coudn't return the device", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void _PreformDeviceReturnForDebtRental()
        {

            if (clsTransactoinsOperations.PreformDeviceReturnForDebtRental(_DeviceRental.DeviceRentalID,_DeviceRental.RenterID,
                _DeviceRental.RentalID,_GetPaymentMethodID(),_DeviceRental.RentalInfo.TotalFees,clsUserSession.CurrentUser.UserID))
            {
                btnReturn.Enabled = false;
                gbPaymentMethods.Enabled = false;

                MessageBox.Show("The device is returned", "Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _DeviceRental.RentalInfo.TotalFees); //the total payment inovked with the total payment 

            }
            else
            {
                btnReturn.Enabled = true;
                gbPaymentMethods.Enabled = true;

                MessageBox.Show("Coudn't return the device", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //check if the payment for this device rental is already done when the customer rented it
            if(_DeviceRental.RentalInfo.PaymentID != null)
            {
               _PreformDeviceReturnForNonDebtRental();

               
                return;
            }

            _PreformDeviceReturnForDebtRental();
            
            return;

        }
    }
}
