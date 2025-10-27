using System;
using GCMS_Data_Access;

namespace GCMS_Business
{
    /// <summary>
    /// This class Represents PaymentTypes
    /// </summary>
    public class clsPaymentTypes
    {
        //Data members used in this class
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }

        //Constructor for this class
        private clsPaymentTypes(int PaymentTypeID, string PaymentTypeName)
        {
            this.PaymentTypeID = PaymentTypeID;
            this.PaymentTypeName = PaymentTypeName;
        }

        public static clsPaymentTypes FindPaymentType(int PaymentTypeID)
        {
            string PaymentTypeName = "";
            if (clsPaymentTypes_Data_Access.FindPaymentType(PaymentTypeID, ref PaymentTypeName))
                return new clsPaymentTypes (PaymentTypeID, PaymentTypeName);
            else
                return null;
        }
    }
}
