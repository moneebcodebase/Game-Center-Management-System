using System;
using System.Data;
using GCMS_Data_Access;

namespace GCMS_Business
{
    public class clsTransactoinsOperations
    {
        //this method will be used to preform non_Debt Device rental opreations
        //which will effect three tables (Rentals - Device rentals - Payments) 
        //using transactions
        public static bool PreformNonDebtDeviceRentalOpreation(int GameID,DateTime StartDate,DateTime EndDate,decimal TotalFees
            ,int CreatedByUserID,int RenterID,string RentalStatus,string Note,byte PaymentMethodID)
        {
            return clsTransactionsOpreations_Data_Access.PreformNonDebtDeviceRentalOpreation(GameID, StartDate, EndDate, TotalFees,
                     CreatedByUserID, RenterID, RentalStatus, Note,PaymentMethodID);
        }


        //this method will be used to preform On Debt Device rental opreations
        //which will effect three tables (Rentals - Device rentals - Debts) 
        //using transactions
        public static bool PreformOnDebtDeviceRentalOpreation(int GameID, DateTime StartDate, DateTime EndDate, decimal TotalFees
            , int CreatedByUserID, int RenterID, string RentalStatus, string Note)
        {
            return clsTransactionsOpreations_Data_Access.PreformOnDebtDeviceRentalOpreation(GameID, StartDate, EndDate, TotalFees,
                     CreatedByUserID, RenterID, RentalStatus, Note);
        }

        //this method will be used to preform return On Debt Device rental opreations
        //which will effect four tables (Rentals - Device rentals - Debts ,Payments) 
        //using transactions
        public static bool PreformDeviceReturnForDebtRental(int DeviceRentalID, int RenterID, int RentalID, int PaymentMethodID
            , decimal TotalFees, int CreatedByUserID)
        {
            return clsTransactionsOpreations_Data_Access.PreformDeviceReturnForDebtRental(DeviceRentalID,RenterID, RentalID, PaymentMethodID
            , TotalFees,CreatedByUserID);
        }

        //this method will be used to preform pay debt opreation for all debts
        //it will effect three tables (Rentals - Payments - Debts)
        //using transactoins

        public static bool PreformPayDebtOpreatoin(int RentalID, int PaymentMethodID,int PaymentTypeID,int CreatedByUserID ,decimal TotalAmount)
        {
            return clsTransactionsOpreations_Data_Access.PreformPayDebtOpreatoin(RentalID, PaymentMethodID, PaymentTypeID, CreatedByUserID, TotalAmount);
        }


        //this method will be used to preform removing item from cart item opreation
        //it will effect two tables (CartITems and StoreItems)
        //using transaction
        public static bool PreformRemoveItemFromCartItemsOpreation(int CartItemID,int ItemID,int ReturnedQuantity)
        {
            return clsTransactionsOpreations_Data_Access.PreformRemoveItemFromCartItemsOpreation(CartItemID, ItemID, ReturnedQuantity);
        }

        //this mehod will be used to preform cart payment opreaiton
        //it will effect 3 tables (payments, cartpayment, cart)
        //using transactions

        public static bool PreformCartPaymentOpreation(int CartID,int PaymentMethodID,int CreatedByUserID,decimal PaymentAmount)
        {
            return clsTransactionsOpreations_Data_Access.PreformCartPaymentOpreation(CartID, PaymentMethodID, CreatedByUserID, PaymentAmount);
        }
    }
}
