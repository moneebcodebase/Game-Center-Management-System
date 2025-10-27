using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// This class will represent a Debts Data Accesss
    /// </summary>
    public static class clsDebts_Data_Access
    {
        //this method is to find rental by id
        public static bool FindDebt(int DebtID, ref int RenterID,ref int RentalID,ref bool IsPaid, ref int CreatedByUserID)
        {
            //this is a flag to know if the record is found or not
            bool IsFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindDebt", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@DebtID", DebtID);

            // Setting all of the out put parameters
            SqlParameter RenterIDParam = new SqlParameter("@RenterID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RenterIDParam);

            SqlParameter RentalIDParam = new SqlParameter("@RentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalIDParam);


            SqlParameter IsPaidParam = new SqlParameter("@IsPaid", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsPaidParam);


            SqlParameter CreatedByUserIDParam = new SqlParameter("@CreatedByUserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CreatedByUserIDParam);


            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the Person with PersonID Does exists
                //if the Firstname is found then there is definitely a record
                if (RenterIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFound = true;
                    //filling all the parameters with value
                    RenterID = (int)RenterIDParam.Value;
                    RentalID = (int)RentalIDParam.Value;
                    IsPaid = Convert.ToBoolean(IsPaidParam.Value);
                    CreatedByUserID = (int)CreatedByUserIDParam.Value;

                }
                else
                {
                    //Setting the flag to false
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return IsFound;

        }
        //this method is to add new Debt
        public static int AddNewDebt(int RenterID,int RentalID,bool IsPaid,int CreatedByUserID)
        {

            int DebtID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewDebt", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalID",RentalID);
            command.Parameters.AddWithValue("@IsPaid",IsPaid);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter DebtIDParam = new SqlParameter("@NewDebtID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(DebtIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (DebtIDParam.Value != System.DBNull.Value)
                    DebtID = (int)DebtIDParam.Value;
                else
                    DebtID = -1;
            }
            catch (Exception ex)
            {
                DebtID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new Debt. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return DebtID;
        }
        //this method is to update rental record 
        public static bool UpdateDebt(int DebtID,int RenterID,int RentalID,bool IsPaid, int CreatedByUserID)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_SP_UpdateDebt", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@DebtID", DebtID);
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            //creating the output Variable that will be returns from excuting the procedure
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

                if (RowsEffectedParam.Value != System.DBNull.Value)
                    RowsEffected = (int)RowsEffectedParam.Value;
                else
                    RowsEffected = 0;
            }
            catch (Exception ex)
            {
                RowsEffected = 0;
                //log the error into the Event loger
                string Message = $"Error: Coun't Update Debt Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);
        }
        //this mehod is to check if the rental is paid 
        public static bool IsDebtPaid(int DebtID)
        {
            //flag
            bool IsPaid = false;
            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_IsDebtPaid", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameter
            command.Parameters.AddWithValue("DebtID", DebtID);

            //Setting  the output parameter
            SqlParameter IsPaidParam = new SqlParameter("@IsPaid", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsPaidParam);


            //Starting the excution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();


                if (IsPaidParam.Value != DBNull.Value)
                    IsPaid = true;

            }
            catch (Exception ex)
            {
                IsPaid = false;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't check if the debt is paid. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent fill the connection pool
                connection.Close();
            }

            return IsPaid;
        }
        //this method is to get unpaid debts list
        public static DataTable GetUnpaidDebtsList()
        {
            //Data Table  data structure to hold all of the debts list
            DataTable dtDebtList = new DataTable();

            //Setting the connection 
            SqlConnection connection = new SqlConnection (clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_GetUnpaidDebtsList", connection);
            command.CommandType =CommandType.StoredProcedure;

            //Starting Execution

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtDebtList.Load(reader);
                else
                    dtDebtList = null;

                reader.Close();
            }
            catch (Exception ex)
            {
                dtDebtList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load upaid debts list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtDebtList;
        }

        //this method is to get paid debts list
        public static DataTable GetpaidDebtsList()
        {
            //Data Table  data structure to hold all of the debts list
            DataTable dtDebtList = new DataTable();

            //Setting the connection 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Preparing the command
            SqlCommand command = new SqlCommand("SP_GetPaidDebtsList", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Starting Execution

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtDebtList.Load(reader);
                else
                    dtDebtList = null;

                reader.Close();
            }
            catch (Exception ex)
            {
                dtDebtList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load paid debts list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtDebtList;
        }
    }
}
