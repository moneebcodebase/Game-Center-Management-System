using System;
using System.Collections.Generic;
using System.Data;
using GCMS_Data_Access;

namespace GCMS_Business
{

    /// <summary>
    /// This class will represent Debts
    /// </summary>
    public class clsDebts
    {
        //Data members used in this class
        public enum enMode { AddNew=1,Update=2};
        private enMode _Mode;

        public int DebtID { get; set; }
        public int RenterID { get; set; }
        public clsRenters Renter;
        public int RentalID { get; set; }
        public clsRentals Rental;
        public bool IsPaid { get; set; }
        public int CreatedByUserID { get; set; }

        //Private constructor to update and edit Debts
        private clsDebts(int DebtID,int RenterID, int RentalID,bool IsPaid, int CreatedByUserID)
        {
            this.DebtID = DebtID;
            this.RenterID = RenterID;
            this.Renter = clsRenters.FindRenter(this.RenterID);
            this.RentalID = RentalID;
            this.Rental = clsRentals.FindRental(this.RentalID);
            this.IsPaid = IsPaid;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }
        //public constructor used to add new debt
        public clsDebts()
        {
            this.DebtID = 0;
            this.RenterID = 0;
            this.RentalID = 0;
            this.IsPaid = false;
            this.CreatedByUserID = 0;

            _Mode = enMode.AddNew;
        }


        //Find Rental with RentalID
        public static clsDebts FindDebt(int DebtID)
        {
            int RenterID = 0;
            int RentalID = 0;
            bool IsPaid = false;
            int CreatedByUserID = 0;

            bool IsFound = clsDebts_Data_Access.FindDebt(DebtID,ref RenterID,ref RentalID,ref IsPaid,ref CreatedByUserID);

            if (IsFound)
                return new clsDebts(DebtID,RenterID,RentalID,IsPaid,CreatedByUserID);
            else
                return null;

        }

        private bool _AddNewDebt()
        {
            this.DebtID = clsDebts_Data_Access.AddNewDebt(this.RenterID,this.RentalID,this.IsPaid,this.CreatedByUserID);

            return (this.DebtID > -1);
        }
        //Private method to Update debt
        private bool _UpdateDebt()
        {
            return clsDebts_Data_Access.UpdateDebt(this.DebtID,this.RenterID,this.RentalID,this.IsPaid,this.CreatedByUserID);
        }

        // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDebt())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateDebt())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


        //this method is to check if a rental is paid or not
        public static bool IsDebtPaid(int DebtID)
        {
            return clsDebts_Data_Access.IsDebtPaid(DebtID);
        }

        //this method is used to get the Unpaid Debts List
        public static DataTable GetUnpaidDebtsList()
        {
            return clsDebts_Data_Access.GetUnpaidDebtsList();
        }

        //this method is used to get the paid Debts List
        public static DataTable GetPaidDebtsList()
        {
            return clsDebts_Data_Access.GetpaidDebtsList();
        }

        

    }
}
