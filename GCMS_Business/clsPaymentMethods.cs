using System;
using GCMS_Data_Access;


namespace GCMS_Business
{
    /// <summary>
    /// This class is to represent paymentmethods
    /// </summary>
    public class clsPaymentMethods
    {
        //Data members used in this class
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }

        //Constructor for this class
        private clsPaymentMethods(int PaymentMethodID, string PaymentMethodName)
        {
            this.PaymentMethodID = PaymentMethodID;
            this.PaymentMethodName = PaymentMethodName;
        }

        public static clsPaymentMethods FindPaymentMethod(int PaymentMethodID)
        {
            string PaymentMethodName = "";
            if (clsPaymentMethod_Data_Access.FindPaymentMethod(PaymentMethodID, ref PaymentMethodName))
                return new clsPaymentMethods(PaymentMethodID, PaymentMethodName);
            else
                return null;
        }

        
    }
}
