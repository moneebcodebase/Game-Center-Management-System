using System;
using System.Data;
using GCMS_Data_Access;


namespace GCMS_Business
{

    /// <summary>
    /// This Class Will Represent User Data 
    /// </summary>
    public class clsUsers
    {
        //Data members used for this class
        public enum enMode { AddNew=1,Update =2}
        private enMode _Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }

        //instead of only having the personID, this is a composition to have access to all of Person Data

        public clsPeople PersonInfo;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }



       
        //Private constructor used to update recrods
        private clsUsers(int UserID,int PersonID,string Username,string Password,string Role,bool IsActive)
        {
            _Mode = enMode.Update;

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPeople.FindPerson(PersonID);
            this.Username= Username;
            this.Password= Password;
            this.Role = Role;
            this.IsActive = IsActive;
        }
        //Public constructor used to add new users
        public clsUsers()
        {
            _Mode = enMode.AddNew;

            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.Role = "";
            this.IsActive = false;
        }

        //Find User by User ID
        public static clsUsers FindUser(int UserID)
        {
            int PersonID = -1;
            string Username = "";
            string Password = "";
            string Role = "";
            bool IsActive = false;

            if (clsUsers_Data_Access.FindUser(UserID, ref PersonID, ref Username, ref Password, ref Role, ref IsActive))
                return new clsUsers(UserID, PersonID, Username, Password, Role, IsActive);
            else
                return null;
        }

        //Find User by Username and password
        public static clsUsers FindUserByUsername_Password(string Username,string Password)
        {
            
            int UserID = -1;
            int PersonID = -1;
            string Role = "";
            bool IsActive = false;

            if (clsUsers_Data_Access.FindUserByUsername_Password(ref UserID, ref PersonID,Username,Password, ref Role, ref IsActive))
                return new clsUsers(UserID, PersonID, Username, Password, Role, IsActive);
            else
                return null;
        }


        //Check if the user Exists
        public static bool IsUserExists(int UserID)
        {
            return clsUsers_Data_Access.IsUserExists(UserID);
        }

        //Private method to add new User Data
        private bool _AddNewUser()
        {
            
            this.UserID = clsUsers_Data_Access.AddNewUser(this.PersonID, this.Username, this.Password, this.Role, this.IsActive);

            if (this.UserID != -1)
                this.PersonInfo = clsPeople.FindPerson(this.PersonID);
            else
                this.PersonInfo = null;

            return (this.UserID>-1);

        }
        //Private method to Update a User Data
        private bool _UpdateUser()
        {
            return clsUsers_Data_Access.UpdateUser(this.UserID,this.PersonID, this.Username,this.Password, this.Role, this.IsActive);
        }

        //Save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateUser())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }


        //Checks if user is Active
        public static bool IsUserActive(int UserID)
        {
            return clsUsers_Data_Access.IsUserActive(UserID);
        }

        //Check if there is a user with a specific  username
        public static bool IsUsernameExists(string Username)
        {
            return clsUsers_Data_Access.IsUsernameExists(Username);
        }

        //Change User Password
        public bool ChangeUserPasword(string NewPassword)
        {
            return clsUsers_Data_Access.ChangeUserPassword(this.UserID, NewPassword);
        }

        //Deactivate User
        public static bool DeactivateUser(int UserID)
        {
            return clsUsers_Data_Access.DeactivateUser(UserID);
        }

        //Activate User
        public static bool ActivateUser(int UserID)
        {
            return clsUsers_Data_Access.ActivateUser(UserID);
        }

        //Get Users list
        public static DataTable UsersList()
        {
            return clsUsers_Data_Access.GetUsersList();
        }

        //this method is used to log the login info
        public static bool LogLoginInfo(clsUsers User)
        {
            return clsUsers_Data_Access.LogLoginInfo(User.UserID, User.Username, User.PersonInfo.FullName(), DateTime.Now);
        }

        
        //Get Users login log records count (all records or for a user)
        public static int GetUsersLoginLogRecordsCount()
        {
            return clsUsers_Data_Access.GetUsersLoginLogTotalRecords();
        }

        //Get Users login log records count (all records or for a user)
        public static int GetUsersLoginLogRecordsCount(string Username,
            DateTime? StartingPeriod, DateTime? EndingPeriod)
        {
            return clsUsers_Data_Access.GetUsersLoginLogTotalRecords(Username,StartingPeriod,EndingPeriod);
        }

        //Get Users login log list by pages (all records or for a user)
        public static DataTable GetUsersLoginLogList(byte PageNumber,byte PageSize ,string Username =null,
            DateTime? StartingPeriod = null,DateTime? EndingPeriod = null)
        {
            return clsUsers_Data_Access.GetUsersLoginLogList(PageNumber, PageSize,  Username,
            StartingPeriod, EndingPeriod);
        }

        //this method the minimum and maximum date of the loging logs records avaliable
        public static void GetMinimum_Maxmimum_LoginLogDate( ref DateTime MinDate,ref DateTime MaxDate)
        {
            clsUsers_Data_Access.GetMinimum_Maxmimum_LoginLogDate(ref MinDate, ref MaxDate);
        }

    }
}
