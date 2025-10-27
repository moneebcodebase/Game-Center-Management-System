using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// This class will represent a User Data Access
    /// </summary>
    public static class clsUsers_Data_Access
    { 
        //this method is used to find user by user id
        public static bool FindUser(int UserID,ref int PersonID,ref string Username,ref string Password,ref string Role,
            ref bool IsActive)
        { 
            //Boolean falg 
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_FindUserByID", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input variable
            command.Parameters.AddWithValue("@UserID", UserID);

            //Setting the output variables

            SqlParameter PersonIDParam = new SqlParameter("@PersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PersonIDParam);

            SqlParameter UsernameParam = new SqlParameter("@Username", SqlDbType.NVarChar,30)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(UsernameParam);

            SqlParameter PasswordParam = new SqlParameter("@Password", SqlDbType.NVarChar, 64)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PasswordParam);

            SqlParameter RoleParam = new SqlParameter("@Role", SqlDbType.NVarChar, 10)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RoleParam);

            SqlParameter IsActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsActiveParam);



            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                
                if(PersonIDParam.Value != DBNull.Value)
                {
                    //Marking the flag to true to indicate that the user does exists
                    IsFound = true;

                    //filling the user data
                    PersonID = (int)PersonIDParam.Value;
                    Username = UsernameParam.Value.ToString();
                    Password = PasswordParam.Value.ToString();
                    Role = RoleParam.Value.ToString();
                    IsActive = Convert.ToBoolean(IsActiveParam.Value);
                }
                
                    
            }
            catch (Exception ex)
            {
                IsFound=false;
                //Logging the Error into event logger
                string Message = $"Error: Coun't Search for user. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method is used to find user by username and password
        public static bool FindUserByUsername_Password(ref int UserID, ref int PersonID,string Username,string Password, ref string Role,
            ref bool IsActive)
        {
            //Boolean falg 
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_FindUserByUsername_Password", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input variable
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            //Setting the output variables

            SqlParameter PersonIDParam = new SqlParameter("@PersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PersonIDParam);

            SqlParameter UserIDParam = new SqlParameter("@UserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(UserIDParam);

            SqlParameter RoleParam = new SqlParameter("@Role", SqlDbType.NVarChar, 10)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RoleParam);

            SqlParameter IsActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsActiveParam);



            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //
                if (PersonIDParam.Value != DBNull.Value)
                {
                    //Marking the flag to true to indicate that the use does exists
                    IsFound = true;

                    //filling the user data
                    UserID =(int)UserIDParam.Value;
                    PersonID = (int)PersonIDParam.Value;
                    Role = RoleParam.Value.ToString();
                    IsActive = Convert.ToBoolean(IsActiveParam.Value);
                }


            }
            catch (Exception ex)
            {
                IsFound = false;
                //Logging the Error into event logger
                string Message = $"Error: Coun't Search for user. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method checks if the user exists
        public static bool IsUserExists(int UserID)
        {
            //Boolean flag
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the input Parameter
            command.Parameters.AddWithValue("@UserID", UserID);
            //Setting the output Parameter
            SqlParameter IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsFoundParam);


            //Executing

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsFoundParam.Value != DBNull.Value)
                    IsFound = Convert.ToBoolean(IsFoundParam.Value);
            }
            catch (Exception ex)
            {
                IsFound = false;
                //logging the Error into the event logger
                string Message = $"Error: Searching for the User Faild. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method is used to add new user to the database and return the new user id
        public static int AddNewUser(int PersonID,string Username,string Password,string Role,bool IsActive)
        {
            int NewUserID = -1;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_AddNewUser", connection);
            command.CommandType = CommandType.StoredProcedure;


            //Setting the input variables

            command.Parameters.AddWithValue("@PersonID",PersonID);
            command.Parameters.AddWithValue("@Username",Username);
            command.Parameters.AddWithValue("@Password",Password);
            command.Parameters.AddWithValue("@Role", Role);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            //Setting the output Variables
            SqlParameter OutputUserIDParam = new SqlParameter("@NewUserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(OutputUserIDParam);

            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //if the command did execute seccessfully it will return the outo number form the Database
                if(OutputUserIDParam.Value != DBNull.Value)
                    NewUserID =(int)OutputUserIDParam.Value;
                else
                    NewUserID = -1;
            }
            catch (Exception ex)
            {
                NewUserID = -1;
                //Logging the the Error into the Event logger
                string Message = $"Error:Coudn't Add the User. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return NewUserID;
            
        }
        //this method is used to updat use information
        public static bool UpdateUser(int UserID,int PersonID,string Username,string Password,string Role,bool IsActive)
        {
            int RowsEffected = 0;

            //DataBase Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_UpdateUser", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input Variables
            command.Parameters.AddWithValue("@UserID",UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Role", Role);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            //Setting the output Variable
            SqlParameter OutputRowCountParam= new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(OutputRowCountParam);

            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if(OutputRowCountParam.Value != DBNull.Value)
                    RowsEffected=(int)OutputRowCountParam.Value;
               
            }
            catch (Exception ex)
            {
                RowsEffected = 0;

                //Logging the Error into Event Logger
                string Message = $"Error: Coudn't Update user information. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (RowsEffected > 0);
        }

        //this method is used to check if the user is Active
        public static bool IsUserActive(int UserID)
        {

            //Boolean flag
            bool IsActive = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_IsUserActive", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the input Parameter
            command.Parameters.AddWithValue("@UserID", UserID);
            //Setting the output Parameter
            SqlParameter IsActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsActiveParam);


            //Executing

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsActiveParam.Value != DBNull.Value)
                    IsActive = Convert.ToBoolean(IsActiveParam.Value);
            }
            catch (Exception ex)
            {
                IsActive = false;
                //logging the Error into the event logger
                string Message = $"Error: Faild to check user validity. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsActive;

        }

        //Check if there is a user with a specific  username
        public static bool IsUsernameExists(string Username)
        {
            //flag
            bool IsFound = false;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_IsUsernameExists", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameter
            command.Parameters.AddWithValue("@Username", Username);

            //Setting the output Parameter
            SqlParameter IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsFoundParam);


            //Executing

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsFoundParam.Value != DBNull.Value)
                    IsFound = Convert.ToBoolean(IsFoundParam.Value);

            }
            catch (Exception ex)
            {
                IsFound = false;
                //logging the Error into the event logger
                string Message = $"Error: Faild to check username validity. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        //this method is used to change user Password
        public static bool ChangeUserPassword(int UserID,string NewPassword)
        {
            int RowsEffected = 0;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_ChangeUserPassword", connection);
            command.CommandType= CommandType.StoredProcedure;

            //Setting intput variables
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@NewPassword", NewPassword);
            //Setting output variables
            SqlParameter RowsEffectedParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RowsEffectedParam);


            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (RowsEffectedParam.Value != DBNull.Value)
                    RowsEffected = (int)RowsEffectedParam.Value;

            }
            catch(Exception ex)
            {

                RowsEffected = 0;
                //Logging the Error into the Event Logger
                string Message = $"Error: Couldn't Change User Password. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //this method is used to deactivate a user
        public static bool DeactivateUser(int UserID)
        {
            int RowsEffected =0;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_DeactivateUser", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting intput variables
            command.Parameters.AddWithValue("@UserID", UserID);
            
            //Setting output variables
            SqlParameter RowsEffectedParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RowsEffectedParam);


            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (RowsEffectedParam.Value != DBNull.Value)
                    RowsEffected = (int)RowsEffectedParam.Value;

            }
            catch (Exception ex)
            {

                RowsEffected = 0;
                //Logging the Error into the Event Logger
                string Message = $"Error: Couldn't Deactivate User. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //this method is used to activate a user
        public static bool ActivateUser(int UserID)
        {
            int RowsEffected = 0;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_ActivateUser", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting intput variables
            command.Parameters.AddWithValue("@UserID", UserID);

            //Setting output variables
            SqlParameter RowsEffectedParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RowsEffectedParam);


            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (RowsEffectedParam.Value != DBNull.Value)
                    RowsEffected = (int)RowsEffectedParam.Value;

            }
            catch (Exception ex)
            {

                RowsEffected = 0;
                //Logging the Error into the Event Logger
                string Message = $"Error: Couldn't Deactivate User. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //this method is used to get users list
        public static DataTable GetUsersList()
        {
            //Data table to hold users information
            DataTable UsersList = new DataTable();

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Prepare command
            SqlCommand command = new SqlCommand("SP_GetUsersList", connection);
            command.CommandType=CommandType.StoredProcedure;

            //Execution
            try
            {
                connection.Open();
                
                SqlDataReader reader =command.ExecuteReader();

                if (reader.HasRows)
                    UsersList.Load(reader);
                else
                    UsersList = null;

                reader.Close();

            }
            catch(Exception ex)
            {
                UsersList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load Users. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return UsersList;

        }

        //this method is used to log the login info
        public static bool LogLoginInfo(int UserID,string Username,string FullName,DateTime LoginDateTime)
        {
            //flag
             int RowsEffected = 0;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_LogLoginInfo", connection);
            command.CommandType =CommandType.StoredProcedure;


            //Setting the input parameters

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Fullname", FullName);
            command.Parameters.AddWithValue("@LoginDateTime", LoginDateTime);

            //Setting the output parameter

            SqlParameter RowsEffectedParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RowsEffectedParam);

            //starting execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (RowsEffectedParam.Value != DBNull.Value)
                    RowsEffected = (int)RowsEffectedParam.Value;
            }
            catch(Exception ex)
            {
                RowsEffected = 0;
                //Logging the error into Event Logger
                string Message = $"Coudn't log the login info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //Get Users login log records count (all records or for a user)
        public static int GetUsersLoginLogTotalRecords()
        {
            int TotalRecords = 0;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_GetTotalLoginLogsRecords", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the output parameter
            SqlParameter TotalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            
            };
            command.Parameters.Add(TotalRecordsParam);


            //Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                TotalRecords =(int)TotalRecordsParam.Value;

            }
            catch (Exception ex)
            {
                TotalRecords = 0;
                //Logging the error into Event Logger
                string Message = $"Coudn't get total records count {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return TotalRecords;

        }

        //Get Users login log records count (all records or for a user)
        public static int GetUsersLoginLogTotalRecords(string Username,
            DateTime? StartingPeriod, DateTime? EndingPeriod)
        {
            int TotalRecords = 0;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_GetTotalLoginLogsRecords_ForUser", connection);
            command.CommandType = CommandType.StoredProcedure;


            //setting the input paramter
            if(Username == "" || Username == null)
                command.Parameters.AddWithValue("@Username", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Username",Username );

            if(StartingPeriod == null)
                command.Parameters.AddWithValue("@StartingPeriod", DBNull.Value);
            else
                command.Parameters.AddWithValue("@StartingPeriod", StartingPeriod);

            if (EndingPeriod == null)
                command.Parameters.AddWithValue("@EndingPeriod", DBNull.Value);
            else
                command.Parameters.AddWithValue("@EndingPeriod", EndingPeriod);


            //Setting the output parameter
            SqlParameter TotalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output

            };
            command.Parameters.Add(TotalRecordsParam);


            //Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                TotalRecords = (int)TotalRecordsParam.Value;

            }
            catch (Exception ex)
            {
                TotalRecords = 0;
                //Logging the error into Event Logger
                string Message = $"Coudn't get total records count {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return TotalRecords;

        }

        //this method is used to get loging logs list in pages (all record or for a specific user )
        public static DataTable GetUsersLoginLogList(byte PageNumber, byte PageSize, string Username = null,
            DateTime? StartingPeriod = null, DateTime? EndingPeriod = null)
        {
            //Data table to hold users information
            DataTable UsersLoginLogsList = new DataTable();

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            

            SqlCommand command = new SqlCommand("SP_GetLoginLogsList", connection);
            command.CommandType = CommandType.StoredProcedure;


            //Setting the input Parameters
            command.Parameters.AddWithValue("@PageNumber", PageNumber);
            command.Parameters.AddWithValue("@PageSize", PageSize);
                   // handle the null values
            if (Username == "" || Username == null)
                command.Parameters.AddWithValue("@Username", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Username", Username);

            if(StartingPeriod == null)
                command.Parameters.AddWithValue("@StartingPeriod", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@StartingPeriod", StartingPeriod);

            if(EndingPeriod == null)
                command.Parameters.AddWithValue("@EndingPeriod", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@EndingPeriod", EndingPeriod);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    UsersLoginLogsList.Load(reader);
                else
                    UsersLoginLogsList = null;

                reader.Close();

            }
            catch (Exception ex)
            {
                UsersLoginLogsList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load Users login logs. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return UsersLoginLogsList;

        }

        //this method the minimum and maximum date of the loging logs records avaliable
        public static void GetMinimum_Maxmimum_LoginLogDate(ref DateTime MinDate, ref DateTime MaxDate)
        {
            //Setting the connection 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Prepare the command 
            SqlCommand command = new SqlCommand("SP_GetMinimum_Maxmimum_DateInLoginLogs",connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the output parameter
            SqlParameter MinDateParam = new SqlParameter("@MinimumDate", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(MinDateParam);

            SqlParameter MaxDateParam = new SqlParameter("@MaximumDate", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(MaxDateParam);

            //Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                MinDate = (DateTime)MinDateParam.Value;
                MaxDate = (DateTime)MaxDateParam.Value;

            }
            catch (Exception ex)
            {
                
                //Logging the error into Event Logger
                string Message = $"Coudn't get Min and max date. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
