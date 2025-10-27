using System;
using System.Data;
using System.Data.SqlClient;


namespace GCMS_Data_Access
{
                    //this class is static to prevent any object creation form this class
                    //all of the methods will be static inside this class
    /// <summary>
    /// This class will represent a Person Data Accesss
    /// </summary>
    public static class clsPeople_Data_Access
    {

        //this method is to find person by ID
        public static bool FindPerson(int PersonID,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName
            ,ref string PhoneNumber,ref string Email)
        {
                                  //this is a flag to know if the record is found or not
            bool InformationFound = false;

                                 //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                                 //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindPersonByID", connection);
            command.CommandType = CommandType.StoredProcedure;

                                //the input parameter
            command.Parameters.AddWithValue("@PersonID", PersonID);

                               // Setting all of the out put parameters
            SqlParameter FirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(FirstNameParam);

            SqlParameter SecondNameParam = new SqlParameter("@SecondName", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(SecondNameParam);


            SqlParameter ThirdNameParam = new SqlParameter("@ThirdName", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ThirdNameParam);


            SqlParameter LastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 15)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(LastNameParam);

            SqlParameter PhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,15)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PhoneNumberParam);

            SqlParameter EmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(EmailParam);


                                  //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                             

                                 //Making sure that there is a data that returns and that the Person with PersonID Does exists
                                 //if the Firstname is found then there is definitely a record
                if(FirstNameParam.Value != DBNull.Value)
                {
                                 //putting the falg to true 
                    InformationFound = true;
                                 //filling all the parameters with value
                    FirstName = FirstNameParam.Value.ToString();
                    SecondName = SecondNameParam.Value.ToString();

                                 //Handling the null Coulmn value possibility

                    if (ThirdNameParam.Value != DBNull.Value)
                        ThirdName = ThirdNameParam.Value.ToString();
                    else
                        ThirdName = "";

                    LastName = LastNameParam.Value.ToString();
                    PhoneNumber =PhoneNumberParam.Value.ToString();
                    Email = EmailParam.Value.ToString();
                }
                else
                {
                    //Setting the flag to false
                    InformationFound = false;
                }
            }
            catch (Exception ex)
            {
                InformationFound=false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return InformationFound;

        }

        //this method is to ckeck the existince of a person
        public static bool IsPersonExists(int PersonID)
        {
                                 //Boolean flag 
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_ISPersonExists", connection);
            command.CommandType = CommandType.StoredProcedure;

                                  //Setting the input Parameter
            command.Parameters.AddWithValue("@PersonID", PersonID);
                                  //Setting output Parameter
            SqlParameter IsFoundParam = new SqlParameter("@ISFound", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsFoundParam);


            //Execution
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsFoundParam.Value != DBNull.Value)
                {
                    IsFound =Convert.ToBoolean(IsFoundParam.Value);
                }
                else
                    IsFound= false;
                    
            }
            catch(Exception ex)
            {
                IsFound = false;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild while trying to find the person. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS",Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        //this method is to add new person record
        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName
            , string PhoneNumber, string Email)
        {

            int PersonID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewPerson", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            //handling the possiblity of null value
            if (ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter outputIDParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (outputIDParam.Value != System.DBNull.Value)
                    PersonID = (int)command.Parameters["@NewPersonID"].Value;
                else
                    PersonID = -1;
            }
            catch(Exception ex)
            {
                PersonID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new person. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS",Message,clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return PersonID;
        }
        //this method is to update person record 
        public static bool UpdatePerson(int PersonID,string FirstName, string SecondName, string ThirdName, string LastName
            , string PhoneNumber, string Email)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdatePersonInfo", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            //handling the possiblity of null value
            if (ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);


            //Creating the output parameter that will return from the procedure
            SqlParameter outputParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputParam);

            //Execution
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if(outputParam.Value != System.DBNull.Value)
                    RowsEffected =(int)outputParam.Value;
                else
                    RowsEffected = 0;
            }
            catch (Exception ex)
            {
                RowsEffected = 0;
                //log the error into the Event loger
                string Message = $"Error: Coun't Update Person Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //this method gets the renters list
        public static DataTable GetPeopleList()
        {

            DataTable dtPeopleList = new DataTable();

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_GetPeopleList", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Starting Execution

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtPeopleList.Load(reader);
                else
                    dtPeopleList = null;

                reader.Close();
            }
            catch (Exception ex)
            {
                dtPeopleList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load People list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtPeopleList;
        }

    }
}
