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
using GCMS.Renters;
using GCMS.Payment;

namespace GCMS.Device_Rentals
{
    public partial class frmRentScreen : Form
    {
        //private data members used in this form
        private clsGames _Game = new clsGames();
        private clsRenters _Renter = new clsRenters();
        private decimal _TotalPaymentAmount;




        //declaring a delegate
        public delegate void DataBackEventHandler(object sender, decimal TotalPayment, bool IsOnDebt);
        //declare an event using the delegate
        public event DataBackEventHandler DataBack;





        //Constructor 
        //this form can only be called with a game object
        public frmRentScreen(clsGames Game)
        {
            InitializeComponent();

            this._Game = Game;
        }
        //private method used to initial all the data into the form
        private void _Load()
        {
            lblGameID.Text = _Game.GameID.ToString();
            lblGameType.Text = _Game.GameType.GameTypeName.ToString();
            lblGameName.Text = _Game.GameName.ToString();
            lblRetePerHour.Text = "$" + _Game.Rate.ToString();
            lblRenterName.Visible = false;

            dtpStartingDate.Value = DateTime.Now;
            dtpReturnDate.MinDate = dtpStartingDate.Value.AddDays(1);
            dtpReturnDate.Value = dtpReturnDate.MinDate;

            DateTime Start = dtpStartingDate.Value.Date;
            DateTime End = dtpReturnDate.Value.Date;

            TimeSpan Difference = End - Start;
            _TotalPaymentAmount = Difference.Days * _Game.Rate;

            lblTotalPayment.Text = "$" + _TotalPaymentAmount.ToString();
        }
        private void frmRentScreen_Load(object sender, EventArgs e)
        {
            _Load();
        }


        //handle the check box changes
        private void chkMakePayment_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMakePayment.Checked)
            {
                rbCash.Checked = true;
                rbCash.Visible = true;
                rbVisa.Visible = true;
                rbWallet.Visible = true;
            }
            else
            {
                rbCash.Visible = false;
                rbVisa.Visible = false;
                rbWallet.Visible = false;
            }
                
        }



        //handle the renter selection buttons
        private void btnSelectRenter_Click(object sender, EventArgs e)
        {
            frmSelectRenter frm = new frmSelectRenter();
            frm.DataBack += HandlefrmSelectRenter_DataBack;
            frm.ShowDialog();
        }

        private void HandlefrmSelectRenter_DataBack(object sender, int RenterID)
        {
            _Renter = clsRenters.FindRenter(RenterID);

            lblRenterName.Visible = true;
            lblRenterName.Text = _Renter.PersonInfo.FullName();
        }

        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            lblRenterName.Text = "???";
            lblRenterName.Visible = false;
            _Renter = new clsRenters();
        }



        //Returnning Date on change event
        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime Start = dtpStartingDate.Value.Date;
            DateTime End = dtpReturnDate.Value.Date;

            TimeSpan Difference = End - Start;
            _TotalPaymentAmount = Difference.Days * _Game.Rate;

            lblTotalPayment.Text = "$" + _TotalPaymentAmount.ToString();
        }





        //Closing the from 
        private void _CloseTheForm()
        {
            btnSelectRenter.Enabled = false;
            btnCancelSelection.Enabled = false;
            dtpReturnDate.Enabled = false;
            chkMakePayment.Enabled = false;
            tbNote.Enabled = false;
            rbCash.Enabled = false;
            rbVisa.Enabled = false;
            rbWallet.Enabled = false;

            btnRent.Enabled = false;
        }
        //Get the paymentmethod id
        private byte _GetPaymentMethodID()
        {
            if (rbCash.Checked)
                return 1;
            else if (rbVisa.Checked)
                return 2;
            else
                return 3;
        }
       




        //Handle the non_debt device rental opreation
        private bool _SaveNonDebtDeviceRental()
        {
            if(clsTransactoinsOperations.PreformNonDebtDeviceRentalOpreation(_Game.GameID,dtpStartingDate.Value,dtpReturnDate.Value,
                _TotalPaymentAmount,clsUserSession.CurrentUser.UserID,_Renter.RenterID,"Active",tbNote.Text,_GetPaymentMethodID()))
            {
                return true;
            }
            return false;
        }
        //Handle the On Debt device rental opreation
        private bool _SaveOnDebtDeviceRental()
        {
            if (clsTransactoinsOperations.PreformOnDebtDeviceRentalOpreation(_Game.GameID, dtpStartingDate.Value, dtpReturnDate.Value,
                _TotalPaymentAmount, clsUserSession.CurrentUser.UserID, _Renter.RenterID, "Active", tbNote.Text))
            {
                return true;
            }
            return false;
        }



        //Button Rent
        private void btnRent_Click(object sender, EventArgs e)
        {
            //make sure that there is not missing data
            if(_Renter.RenterID ==-1)
            {
                MessageBox.Show("Please choose a renter first!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            //the payment is not on debt
            if(chkMakePayment.Checked)
            {
                if(_SaveNonDebtDeviceRental())
                {
                    MessageBox.Show("Device rental is set successfully.", "Rented", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _CloseTheForm();

                    DataBack?.Invoke(this, _TotalPaymentAmount, false);


                    return;

                }
                else
                {
                    MessageBox.Show("Failed to set device rental.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else //Payment is on debt
            {
                if (_SaveOnDebtDeviceRental())
                {
                    MessageBox.Show("Device rental is set successfully.", "Rented", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _CloseTheForm();

                    DataBack?.Invoke(this, _TotalPaymentAmount, true);
                    return;

                }
                else
                {
                    MessageBox.Show("Failed to set device rental.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }



        
    }
}
