using System;
using GCMS_Data_Access;


namespace GCMS_Business
{
    public class clsDeviceRentals
    {
        //Data members used in this class
        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;

        public int DeviceRentalID { get; set; }
        public int RenterID { get; set; }
        public clsRenters RenterInfo;

        public int RentalID {get; set; }
        public clsRentals RentalInfo;

        public int GameID { get; set; }
        public clsGames GameInfo;

        public string RentalStatus { get; set; }

        public string Note { get; set; }




        // First Constructor used to update a record
        private clsDeviceRentals (int DeviceRentalID, int RenterID, int RentalID, int GameID, string RentalStatus, string Note)
        {
            this.DeviceRentalID = DeviceRentalID;
            this.RenterID = RenterID;
            this.RenterInfo = clsRenters.FindRenter(RenterID);
            this.RentalID=RentalID;
            this.RentalInfo = clsRentals.FindRental(RentalID);
            this.GameID = GameID;
            this.GameInfo = clsGames.FindGame(GameID);
            this.RentalStatus = RentalStatus;
            this.Note = Note;


            _Mode = enMode.Update;
        }
        // Second Constructor used to add new record
        public clsDeviceRentals()
        {
            this.DeviceRentalID = 0;
            this.RenterID = 0;
            this.RentalID = 0;
            this.GameID = 0;
            this.RentalStatus = "";
            this.Note ="";

            _Mode = enMode.AddNew;
        }




        //Find device rental with id
        public static clsDeviceRentals FindDeviceRental(int DeviceRentalID)
        {
            int RenterID = 0;
            int RentalID = 0;
            int GameID = 0;
            string RentalStatus = "";
            string Note = "";

            bool IsFound = clsDeviceRentals_Data_Access.FindDeviceRental(DeviceRentalID, ref RenterID, ref RentalID, ref GameID, ref RentalStatus, ref Note);

            if (IsFound)
                return new clsDeviceRentals(DeviceRentalID,RenterID,RentalID,GameID,RentalStatus,Note);
            else
                return null;

        }
        //Find Active Device Rental for a game
        public static clsDeviceRentals FindActiveDeviceRentalForAGame(int GameID)
        {
            int DeviceRentalID = 0;
            int RenterID = 0;
            int RentalID = 0;
            string RentalStatus = "";
            string Note = "";

            bool IsFound = clsDeviceRentals_Data_Access.FindActiveDeviceRentalForAGame(ref DeviceRentalID, ref RenterID, ref RentalID, GameID, ref RentalStatus, ref Note);

            if (IsFound)
                return new clsDeviceRentals(DeviceRentalID, RenterID, RentalID, GameID, RentalStatus, Note);
            else
                return null;
        }
        //Check if the device rental is rented
        public static bool IsDeviceRentalOnRent(int GameID)
        {
            return clsDeviceRentals_Data_Access.IsDeviceRentalOnRent(GameID);
        }

        //private method used to add new device rental
        private bool _AddNewDeviceRental()
        {
            this.DeviceRentalID = clsDeviceRentals_Data_Access.AddNewDeviceRental(this.RenterID, this.RentalID, this.GameID, this.RentalStatus, this.Note);

            return (this.DeviceRentalID > -1);
        }
        //Private method to Update a device rental
        private bool _UpdateDeviceRental()
        {
            return clsDeviceRentals_Data_Access.UpdateDeviceRental(this.DeviceRentalID,this.RenterID, this.RentalID, this.GameID, this.RentalStatus, this.Note);
        }

        // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDeviceRental())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateDeviceRental())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


        //this method gets the renter who rentered a game
        public static int GetTheGameRenterID(int GameID)
        {

            return clsDeviceRentals_Data_Access.GetTheGameRenterID(GameID);
        }
        

    }
}

