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

namespace GCMS.Store
{
    public partial class frmStorePayment : Form
    {
        //Data members used in this form
        private decimal _TotalPayment;
        private int _CartID;
        private bool _PaymentCompleted = false;

        //Constructor
        public frmStorePayment(decimal TotalPayment,int CartID)
        {
            InitializeComponent();
            _TotalPayment = TotalPayment;
            _CartID = CartID;
        }



        //public event to that notify the subscribers that the payment is set

        public event EventHandler<bool> OnPaymentCompleted;
        //raising the event 
        protected void RaiseOnPaymentCompleted(bool IsPaymentCompleted)
        {
            OnPaymentCompleted?.Invoke(this, IsPaymentCompleted);
        }




        private void frmStorePayment_Load(object sender, EventArgs e)
        {
            btnTotalPayment.Text = "$"+_TotalPayment;
            rbCach.Checked = true;
        }

        private byte GetPaymentMethodID()
        {
            if (rbCach.Checked)
                return 1;
            else if (rbVisa.Checked)
                return 2;
            else
                return 3;

        }
        private void _ClosingForm()
        {
            btnSave.Enabled = false;
            rbCach.Enabled = false;
            rbVisa.Enabled = false;
            rbWallet.Enabled = false;
        }

        //Saving the cart payment 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to make the payment","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsTransactoinsOperations.PreformCartPaymentOpreation(_CartID, GetPaymentMethodID(), clsUserSession.CurrentUser.UserID, _TotalPayment))
                {
                    _PaymentCompleted = true;
                    RaiseOnPaymentCompleted(_PaymentCompleted);
                    MessageBox.Show("Payment has been made.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ClosingForm();
                }
                else
                {
                    MessageBox.Show("Opreation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
