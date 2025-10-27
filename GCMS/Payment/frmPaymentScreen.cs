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

namespace GCMS.Payment
{
    public partial class frmPaymentScreen : Form
    {
        //Data members used in this class
        public enum enPaymentType {Rentals =1,StorePurchase=2,DeviceRentals=3};
        private enPaymentType _PaymentType;
        private decimal _TotalPaymentAmount;
        private int _RenterID;  //will be used when dealing with device rental -
                                //instead double picking the renter the renter will be sent from the device rental screen dirctly 
                                //and if the payment will be on debt then this renter id will be usefull to avoid re_selecting the renter from the payment screen



        //this screen won't open unless we have a totalPayment and paymentype (public constructor)
        public frmPaymentScreen(decimal TotalPaymentAmount,enPaymentType PaymentType,int RenterID =0)
        {
            InitializeComponent();

            //setting the total payment amount and type
            _TotalPaymentAmount = TotalPaymentAmount;
            _PaymentType = PaymentType;
            _RenterID = RenterID;

            //filling the labels, rido button , and checkboxes
            btnTotalPayment.Text ="$"+ _TotalPaymentAmount.ToString();

            if (_PaymentType == enPaymentType.Rentals)
                lblPaymentType.Text = "Rentals";
            else if (_PaymentType == enPaymentType.StorePurchase)
                lblPaymentType.Text = "Store Purchase";
            else
                lblPaymentType.Text = "Device Rental";

            rbCach.Checked = true;

            chkOnDept.Checked = false;

        }

        //declaring a delegate 
        //either return PaymentID which indicates that the payment is not on debt or return renterID
        //to indicate that the payment is on debt
        public delegate void DataBackEventHandler(object sender, int PaymentID,int RenterID);
        //declare an event using the delegate
        public event DataBackEventHandler DataBack;



        private byte GetPaymentMethodID()
        {
            if (rbCach.Checked)
                return 1;
            else if (rbVisa.Checked)
                return 2;
            else
                return 3;

        }
        private void Closingtheform()
        {
            lblPaymentType.Enabled=false;
            rbCach.Enabled = false;
            rbVisa.Enabled = false;
            rbWallet.Enabled = false;
            chkOnDept.Enabled = false;
            btnSave.Enabled = false;

            //close the screen or not
           
            DialogResult Result = MessageBox.Show("Payment is set.\n Do you want to close the screen?", "Payment", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.OK)
                this.Close();
        }




        //Exit button
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(btnSave.Enabled == true)
            {
                MessageBox.Show("You must save the payment first, please click on the save button. \n ", "Confirm payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
                this.Close();
        }

        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            //checking if the payment is set to be on dept or not
            if (chkOnDept.Checked)
            {
                
                //if the debt check box is checked and the payment will be on debt
                if(_RenterID != 0)//this means that the payment screen is called from the device rental screen
                {
                    DataBack?.Invoke(this, 0, _RenterID); //invoke the event the payment id is set to 0 and the renter id is set to the renter id
                                                          //that the device rental sent as parameter (the payment for this device rental will be on debt)

                    Closingtheform();
                }
                else
                {
                    //this means that the payment will be registed on debt for a non_device rental so we need to take the renter id from a select renter screen

                    frmSelectRenter frm = new frmSelectRenter();
                    frm.DataBack += HandleDebt_DataBack; //Subscribe to the event
                    frm.ShowDialog();

                    Closingtheform();
                }


               
            }
            else 
            {
                //this means that the payment will be paied immediately
                clsPayments NewPayment = new clsPayments();
                NewPayment.PaymentTypeID = (int)_PaymentType;
                NewPayment.PaymentMethodID =GetPaymentMethodID();
                NewPayment.PaymentDate = DateTime.Now;
                NewPayment.Amount = _TotalPaymentAmount;
                NewPayment.CreatedByUserID = clsUserSession.CurrentUser.UserID;

                if(NewPayment.Save())
                {
                    //That means that the payment is done
                    MessageBox.Show("Payment processed successfully", "Payment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //invoke the event and share the paymentID only incating that the rental is paid 
                    DataBack?.Invoke(this, NewPayment.PaymentID, 0);

                    Closingtheform();
                }
                else
                {
                    //if the payment faild return to the payment screen and cancel the save button work
                    MessageBox.Show("Payment processed failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
              
            }
            

            
        }


        //this method used to handle the data that will be back from the renter screen(in case of debt)
        private void HandleDebt_DataBack(object sender, int RenterID)
        {
            //invoke the event and share the renterID only indecating that the rental will be on debt
            DataBack?.Invoke(this,0, RenterID);
        }

        
    }
}
