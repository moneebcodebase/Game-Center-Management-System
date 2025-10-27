using System;
using System.Data;
using GCMS_Data_Access;


namespace GCMS_Business
{
    public class clsRenters
    {
        //Data Members Used in This Class
        public enum enMode { AddNew=1,Update=2};
        private enMode _Mode { get; set; }
        public int RenterID { get; set; }
        public int PersonID { get; set; }

        //instead of only having the personID, this is a composition to have access to all of Person Data
        public clsPeople PersonInfo;

        public string NationalNo { get; set; }
        public bool IsBand { get; set; }


        //Private constructor used to update recrods
        private clsRenters(int RenterID,int PersonID,string NationalNo,bool IsBand)
        {
            _Mode = enMode.Update;

            this.RenterID = RenterID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPeople.FindPerson(PersonID);
            this.NationalNo = NationalNo;
            this.IsBand = IsBand;
           
        }
        //Public constructor used to add new Renters
        public clsRenters()
        {
            _Mode = enMode.AddNew;

            this.RenterID = -1;
            this.PersonID = -1;
            this.NationalNo = "";
            this.IsBand = false;
        }

        //Find Renter by Renter ID
        public static clsRenters FindRenter(int RenterID)
        {
            int PersonID = -1;
            string NationalNo = "";
            bool IsBand = false;

            if (clsRenters_Data_Access.FindRenter(RenterID, ref PersonID, ref NationalNo, ref IsBand))
                return new clsRenters(RenterID, PersonID, NationalNo,IsBand);
            else
                return null;
        }

        //Find Renter by Person Id
        public static clsRenters FindRenterByPersonID(int PersonID)
        {
            int RenterID = -1;
            string NationalNo = "";
            bool IsBand = false;

            if (clsRenters_Data_Access.FindRenterByPersonID(ref RenterID,PersonID, ref NationalNo, ref IsBand))
                return new clsRenters(RenterID, PersonID, NationalNo, IsBand);
            else
                return null;
        }

        //Check if the renter Exists
        public static bool IsRenterExists(int RenterID)
        {
            return clsRenters_Data_Access.IsRenterExists(RenterID);
        }
        //Check if the renter is Baned
        public static bool IsBanded(int RenterID)
        {
            return clsRenters_Data_Access.IsBanded(RenterID);
        }
        //Check if the nationalno Exsits
        public static bool IsNationalNoExists(string NationalNo)
        {
            return clsRenters_Data_Access.IsNationalNoExists(NationalNo);
        }

        //Get Renters List 
        public static DataTable GetRentersList()
        {
            return clsRenters_Data_Access.GetRentersList();
        }


        //Private method to add new Renter Data
        private bool _AddNewRenter()
        {
            this.RenterID =clsRenters_Data_Access.AddNewRenter(this.PersonID,this.NationalNo,this.IsBand);

            return (this.PersonID > -1);
        }
        //Private method to Update a renter Data
        private bool _UpdateRenter()
        {
            return clsRenters_Data_Access.UpdateRenter(this.RenterID,this.PersonID,this.NationalNo,this.IsBand);
        }

        // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRenter())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateRenter())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }

    }
}
