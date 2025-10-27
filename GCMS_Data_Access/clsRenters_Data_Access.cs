using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// This class will represent a Renter Data Access
    /// </summary>
    public static class clsRenters_Data_Access
    {
        //this method is used to find Renter by Renter id
        public static bool FindRenter(int RenterID, ref int PersonID, ref string NationalNo, ref bool IsBand)
        {
            //Boolean falg 
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_FindRenter", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input variable
            command.Parameters.AddWithValue("@RenterID", RenterID);

            //Setting the output variables

            SqlParameter PersonIDParam = new SqlParameter("@PersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PersonIDParam);

            SqlParameter NationalNoParam = new SqlParameter("@NationalNo", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NationalNoParam);


            SqlParameter IsBandParam = new SqlParameter("@IsBand", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsBandParam);



            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                
                if (PersonIDParam.Value != DBNull.Value)
                {
                    //Marking the flag to true to indicate that the Renter does exists
                    IsFound = true;

                    //filling the Renter data
                    PersonID = (int)PersonIDParam.Value;
                    NationalNo =NationalNoParam.Value.ToString();
                    IsBand = Convert.ToBoolean(IsBandParam.Value);
                }


            }
            catch (Exception ex)
            {
                IsFound = false;
                //Logging the Error into event logger
                string Message = $"Error: Coun't Search for Renter. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method is used to find Renter by Person id
        public static bool FindRenterByPersonID(ref int RenterID, int PersonID, ref string NationalNo, ref bool IsBand)
        {
            //Boolean falg 
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_FindRenterByPersonID", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input variable
            command.Parameters.AddWithValue("@PersonID", PersonID);

            //Setting the output variables

            SqlParameter RenterIDParam = new SqlParameter("@RenterID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RenterIDParam);

            SqlParameter NationalNoParam = new SqlParameter("@NationalNo", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NationalNoParam);


            SqlParameter IsBandParam = new SqlParameter("@IsBand", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsBandParam);



            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();


                if (RenterIDParam.Value != DBNull.Value)
                {
                    //Marking the flag to true to indicate that the Renter does exists
                    IsFound = true;

                    //filling the Renter data
                    RenterID = (int)RenterIDParam.Value;
                    NationalNo = NationalNoParam.Value.ToString();
                    IsBand = Convert.ToBoolean(IsBandParam.Value);
                }


            }
            catch (Exception ex)
            {
                IsFound = false;
                //Logging the Error into event logger
                string Message = $"Error: Coun't Search for Renter. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method checks if the renter exists
        public static bool IsRenterExists(int RenterID)
        {
            //Boolean flag
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_IsRenterExists", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the input Parameter
            command.Parameters.AddWithValue("@RenterID", RenterID);
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
                string Message = $"Error: Searching for the Renter Faild. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        //this method checks if the renter baned
        public static bool IsBanded(int RenterID)
        {
            //Boolean flag
            bool IsFound = false;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_IsRenterBaned", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the input Parameter
            command.Parameters.AddWithValue("@RenterID", RenterID);
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
                string Message = $"Error: Faild to check renter's validity. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }
        //Check if the nationalno Exsits
        public static bool IsNationalNoExists(string NationalNo)
        {
            //flag
            bool Found = false;

            // Setting the connectoin
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_IsNationalNoExists",connection);
            command.CommandType =CommandType.StoredProcedure;

            //Setting input parameters
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            //Setting the output parameter
            SqlParameter FoundParam = new SqlParameter("@Found", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(FoundParam);

            //Execution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if(FoundParam.Value != DBNull.Value)
                    Found=Convert.ToBoolean(FoundParam.Value);

            }
            catch(Exception ex)
            {
                Found = false;
                //logging the Error into the event logger
                string Message = $"Error: Searching for NationalNo Failed. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection
                connection.Close();
            }

            return Found;
        
        }

        //this method gets the renters list
        public static DataTable GetRentersList()
        {

            DataTable dtRentersList = new DataTable();

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_GetRentersList", connection);
            command.CommandType =CommandType.StoredProcedure;

            //Starting Execution

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtRentersList.Load(reader);
                else
                    dtRentersList = null;

                reader.Close();
            }
            catch (Exception ex)
            {
                dtRentersList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load renters list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtRentersList;
        }

        //this method is to add new renter record
        public static int AddNewRenter(int PersonID, string NationalNo, bool IsBand)
        {

            int RenterID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewRenter", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@IsBand",IsBand);

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter outputIDParam = new SqlParameter("@NewRenterID", SqlDbType.Int)
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
                    RenterID =(int)outputIDParam.Value;
                else
                    RenterID = -1;
            }
            catch (Exception ex)
            {
                RenterID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new renter. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return RenterID;
        }
        //this method is to update person record 
        public static bool UpdateRenter(int RenterID,int PersonID,string NationalNo,bool IsBand)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateRenter", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@IsBand", IsBand);
            

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

                if (outputParam.Value != System.DBNull.Value)
                    RowsEffected = (int)outputParam.Value;
                else
                    RowsEffected = 0;
            }
            catch (Exception ex)
            {
                RowsEffected = 0;
                //log the error into the Event loger
                string Message = $"Error: Coun't Update Renter Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);
        }

    }
}
