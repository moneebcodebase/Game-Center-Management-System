using System;
using System.Data;
using GCMS_Data_Access;

namespace GCMS_Business
{
    /// <summary>
    /// This Calss Will Represent Person Data
    /// </summary>
    public class clsPeople
    {
        // Data Members Used in this class
        public enum enMode { AddNew =1 , Update =2};

        private enMode _Mode;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }



                              // First Constructor used to update a record
        private clsPeople(int PersonID , string FirstName , string SecondName,string ThirdName, string LastName
            ,string PhoneNumber, string Email)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;

            this._Mode = enMode.Update;
        }
        
                              // Second Constructor used to add new record
        public clsPeople()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.PhoneNumber = "";
            this.Email = "";

            this._Mode = enMode.AddNew;
        }


                              //Find Person with PersonID
        public static clsPeople FindPerson(int PersonID)
        {
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string PhoneNumber = "";
            string Email = "";

            bool IsFound = clsPeople_Data_Access.FindPerson(PersonID,ref FirstName, ref SecondName,
                ref ThirdName, ref LastName,ref PhoneNumber, ref Email);

            if (IsFound)
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName, PhoneNumber, Email);
            else
                return null;
            
        }

                              //Checking is the person Exists
        public static bool IsPersonExists(int PersonID)
        {
            return clsPeople_Data_Access.IsPersonExists(PersonID);
        }

                              //Private method to add new Person Data
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeople_Data_Access.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.PhoneNumber, this.Email);

            return (this.PersonID > -1);
        }
                              //Private method to Update a person's Data
        private bool _UpdatePerson()
        {
            return clsPeople_Data_Access.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName,this.LastName,
                this.PhoneNumber,this.Email);
        }

                              // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdatePerson())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


                                  //this method used to get people list
        
        public static DataTable GetPeopleList()
        {
            return clsPeople_Data_Access.GetPeopleList();
        }

    }
}
