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
    public static class clsRentals_Data_Access
    {
        //this method is to find rental by id
        public static bool FindRental(int RentalID, ref int GameID, ref DateTime StartDate, ref DateTime EndDate, ref decimal TotalFees
            , ref bool OnDebt, ref int? PaymentID,ref int CreatedByUserID)
        {
            //this is a flag to know if the record is found or not
            bool IsFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@RentalID", RentalID);

            // Setting all of the out put parameters
            SqlParameter GameIDParam = new SqlParameter("@GameID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(GameIDParam);

            SqlParameter StartDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(StartDateParam);


            SqlParameter EndDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(EndDateParam);


            SqlParameter TotalFeesParam = new SqlParameter("@TotalFees", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(TotalFeesParam);

            SqlParameter OnDebtParam = new SqlParameter("@OnDebt", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(OnDebtParam);

            SqlParameter PaymentIDParam = new SqlParameter("@PaymentID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentIDParam);

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
                if (GameIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFound = true;
                    //filling all the parameters with value
                    GameID = (int)GameIDParam.Value;
                    StartDate = (DateTime)StartDateParam.Value;
                    EndDate = (DateTime)EndDateParam.Value;
                    TotalFees = Convert.ToDecimal(TotalFeesParam.Value);
                    OnDebt = Convert.ToBoolean( OnDebtParam.Value);
                    //Handling the null Coulmn value possibility

                    if (PaymentIDParam.Value != DBNull.Value)
                        PaymentID = (int)PaymentIDParam.Value;
                    else
                        PaymentID = null;

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
        //this method is to add new rental
        public static int AddNewRental(int GameID,DateTime StartDate,DateTime EndDate,decimal TotalFees,bool OnDebt,int? PaymentID,
            int CreatedByUserID)
        {

            int RentalID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@OnDebt", OnDebt);
            //handling the possiblity of null value
            if (PaymentID != null)
                command.Parameters.AddWithValue("@PaymentID",PaymentID);
            else
                command.Parameters.AddWithValue("@PaymentID", System.DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter RentalIDParam = new SqlParameter("@NewRentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (RentalIDParam.Value != System.DBNull.Value)
                    RentalID = (int)RentalIDParam.Value;
                else
                    RentalID = -1;
            }
            catch (Exception ex)
            {
                RentalID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new Rental. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return RentalID;
        }
        //this method is to update rental record 
        public static bool UpdateRental(int RentalID,int GameID, DateTime StartDate, DateTime EndDate, decimal TotalFees, bool OnDebt, int? PaymentID,
            int CreatedByuserID)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@OnDebt", OnDebt);
            //handling the possiblity of null value
            if (PaymentID != null)
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
            else
                command.Parameters.AddWithValue("@PaymentID", System.DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByuserID);



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
                string Message = $"Error: Coun't Update Rental Info. {ex.Message}";
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
        public static bool IsRentalPaid(int RentalID)
        {
            //flag
            bool IsPaid = false;
            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_IsRentalPaid", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameter
            command.Parameters.AddWithValue("@RentalID", RentalID);

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


                if(IsPaidParam.Value != DBNull.Value)
                    IsPaid = true;

            }
            catch (Exception ex)
            {
                IsPaid = false;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't check if the rental is paid. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent fill the connection pool
                connection.Close();
            }

            return IsPaid;
        }


       
    }
}
