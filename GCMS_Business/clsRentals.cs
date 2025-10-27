using System;
using GCMS_Data_Access;


namespace GCMS_Business
{
    /// <summary>
    /// this class is for Rentals 
    /// </summary>
    public class clsRentals
    {
        //Data members used in this class
        public enum enMode { AddNew=1,Update=2};
        private enMode _Mode;

        public int RentalID { get; set; }
        public int GameID { get; set; }
        public clsGames Game;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalFees { get; set; }
        public bool OnDebt { get; set; }
        public int? PaymentID { get; set; }
        public clsPayments Payment;
        public int CreatedByUserID { get; set; }
        public clsUsers User;

        //private constructor used to update a rental record

        private clsRentals (int RentalID,int GameID,DateTime StartDate,DateTime EndDate,decimal TotalFees,bool OnDebt,int? PaymentID,
            int CreatedByUserID)
        {
            this.RentalID = RentalID;
            this.GameID = GameID;
            this.Game = clsGames.FindGame(GameID);
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.TotalFees = TotalFees;
            this.OnDebt = OnDebt;
            this.PaymentID = PaymentID;
            this.CreatedByUserID = CreatedByUserID;
            this.User = clsUsers.FindUser(CreatedByUserID);

            _Mode = enMode.Update;

        }

        //publlic constructor used to Add new rental

        public clsRentals()
        {
            this.RentalID = 0;
            this.GameID = 0;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.TotalFees = 0;
            this.OnDebt = false;
            this.PaymentID = null;
            this.CreatedByUserID = 0;

            _Mode = enMode.AddNew;
        }

        //Find Rental with RentalID
        public static clsRentals FindRental (int RentalID)
        {
            int GameID = 0;
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            decimal TotalFees = 0;
            bool OnDebt = false;
            int? PaymentID = null;
            int CreatedByUserID = 0;

            bool IsFound = clsRentals_Data_Access.FindRental(RentalID,ref GameID,ref StartDate,ref EndDate,ref TotalFees,ref OnDebt,
                ref PaymentID,ref CreatedByUserID);

            if (IsFound)
                return new clsRentals(RentalID, GameID, StartDate, EndDate, TotalFees,OnDebt,PaymentID,CreatedByUserID);
            else
                return null;

        }

        private bool _AddNewRental()
        {
            this.RentalID = clsRentals_Data_Access.AddNewRental(this.GameID, this.StartDate, this.EndDate, this.TotalFees, this.OnDebt,
                this.PaymentID, this.CreatedByUserID);

            return (this.RentalID > -1);
        }
        //Private method to Update a rental Data
        private bool _UpdateRental()
        {
            return clsRentals_Data_Access.UpdateRental(this.RentalID,this.GameID, this.StartDate, this.EndDate, this.TotalFees, this.OnDebt,
                this.PaymentID, this.CreatedByUserID);
        }

        // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRental())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateRental())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


        //this method is to check if a rental is paid or not
        public static bool IsRentalPaid(int RentalID)
        {
            return clsRentals_Data_Access.IsRentalPaid(RentalID);
        }

    }
}
