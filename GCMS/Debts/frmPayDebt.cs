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

namespace GCMS.Debts
{
    public partial class frmPayDebt : Form
    {
        //private data memeber to hold the debt info
        private clsDebts Debt =new clsDebts();

        // this form can only be called with debt object
        public frmPayDebt(clsDebts debt)
        {
            InitializeComponent();
            this.Debt = debt;
        }

        //Filling the form with data while in load
        private void frmPayDebt_Load(object sender, EventArgs e)
        {
            lblDebtID.Text = Debt.DebtID.ToString();
            lblRenterName.Text = Debt.Renter.PersonInfo.FullName();
            lblTotalDebt.Text = "$"+ Debt.Rental.TotalFees.ToString();
        }


        //Get The Payment Method ID
        private byte GetPaymentMethodID()
        {
            if (rbCash.Checked)
                return 1;
            else if (rbVisa.Checked)
                return 2;
            else
                return 3;

        }
        //Get the Payment Type ID
        private byte GetPaymentTypeID()
        {
            if (Debt.Rental.Game.GameTypeID == 6)
                return 3; // this indicate that the payment type was for device rental
            else
                return 1; //this indicate that the payment type was for rentals

        }



        private void btnPayDebt_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to pay this debt?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                //paying the debt using the transaction function
                if(clsTransactoinsOperations.PreformPayDebtOpreatoin(Debt.RentalID,GetPaymentMethodID(),GetPaymentTypeID()
                    ,clsUserSession.CurrentUser.UserID,Debt.Rental.TotalFees))
                {
                    MessageBox.Show("Debt has been paid...", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPayDebt.Enabled = false;
                    rbCash.Enabled = false;
                    rbVisa.Enabled = false;
                    rbWallet.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to pay the debt !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
              
        }
    }
}
