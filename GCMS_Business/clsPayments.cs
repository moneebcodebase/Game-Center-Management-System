using System;
using GCMS_Data_Access;

namespace GCMS_Business
{
    /// <summary>
    /// This class will represent payments
    /// </summary>
    public class clsPayments
    {
        //Data members
        
        public int PaymentID { get; set; }
        public int PaymentTypeID { get; set; }
        public clsPaymentTypes PaymentType;

        public int PaymentMethodID { get; set; }
        public clsPaymentMethods PaymentMethod;

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers User { get; set; }


        //Constructors
        private clsPayments(int PaymentID,int PaymentTypeID,int PaymentMehtodID,DateTime PaymentDate,decimal Amount,
            int CreatedbyUserID)
        {
            this.PaymentID = PaymentID;
            this.PaymentTypeID = PaymentTypeID;
            this.PaymentType = clsPaymentTypes.FindPaymentType(this.PaymentTypeID);
            this.PaymentMethodID = PaymentMethodID;
            this.PaymentMethod = clsPaymentMethods.FindPaymentMethod(this.PaymentMethodID);
            this.PaymentDate = PaymentDate;
            this.Amount = Amount;
            this.CreatedByUserID = CreatedByUserID;
            this.User = clsUsers.FindUser(this.CreatedByUserID);

           
        }

        public clsPayments()
        {
            this.PaymentID = 0;
            this.PaymentTypeID = 0;
            this.PaymentMethodID = 0;
            this.PaymentDate = DateTime.Now;
            this.Amount = 0;
            this.CreatedByUserID = 0;


           
        }


        public static clsPayments FindPayment(int PaymentID)
        {
            int PaymentTypeID = 0;
            int PaymentMethodID = 0;
            DateTime PaymentDate = DateTime.Now;
            decimal Amount = 0;
            int CreatedByUserID = 0;


            bool IsFound = clsPayments_Data_Access.FindPayment(PaymentID,ref PaymentTypeID,ref PaymentMethodID, ref PaymentDate,
                ref Amount,ref  CreatedByUserID);
                
            if (IsFound)
                return new clsPayments(PaymentID,PaymentTypeID,PaymentMethodID,PaymentDate,Amount,CreatedByUserID);
            else
                return null;

        }
        //private method to add new payment
        private bool _AddNewPayment()
        {
            this.PaymentID = clsPayments_Data_Access.AddNewPayment(this.PaymentTypeID, this.PaymentMethodID,
                this.PaymentDate, this.Amount, this.CreatedByUserID);
            //check if the payment is added successflly
            if (this.PaymentID != -1)
            {
                //filling the composition info 
                this.PaymentType =clsPaymentTypes.FindPaymentType(this.PaymentTypeID);
                this.PaymentMethod = clsPaymentMethods.FindPaymentMethod(this.PaymentMethodID);
                this.User = clsUsers.FindUser(this.CreatedByUserID);
                return true;
            }
            else
                return false;
        }

        
        
        //public method to save the new payment
        public bool Save()
        {
            if (_AddNewPayment())
            {
                this.PaymentType = clsPaymentTypes.FindPaymentType(this.PaymentTypeID);
                this.PaymentMethod=clsPaymentMethods.FindPaymentMethod(this.PaymentMethodID);
                this.User =clsUsers.FindUser(this.CreatedByUserID);

                return true;
            }
            else
                return false;
        }
    }
}
