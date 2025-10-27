using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    public class clsTransactionsOpreations_Data_Access
    {
        //this method will be used to preform non_Debt Device rental opreations
        //which will effect three tables (Rentals - Device rentals- Payments) 
        //using transactions
        public static bool PreformNonDebtDeviceRentalOpreation(int GameID, DateTime StartDate, DateTime EndDate, decimal TotalFees,
             int CreatedByUserID, int RenterID, string RentalStatus, string Note,byte PaymentMethodID)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformNonDebtDeviceRentalOpreation", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalStatus", RentalStatus);

            if(Note != "")
               command.Parameters.AddWithValue("@Note", Note);
            else
                command.Parameters.AddWithValue("@Note", System.DBNull.Value);

            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethodID);

            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }


        //this method will be used to preform on Debt Device rental opreations
        //which will effect three tables (Rentals - Device rentals - Debts) 
        //using transactions
        public static bool PreformOnDebtDeviceRentalOpreation(int GameID, DateTime StartDate, DateTime EndDate, decimal TotalFees,
             int CreatedByUserID, int RenterID, string RentalStatus, string Note)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformOnDebtDeviceRentalOpreation", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalStatus", RentalStatus);

            if (Note != "")
                command.Parameters.AddWithValue("@Note", Note);
            else
                command.Parameters.AddWithValue("@Note", System.DBNull.Value);

            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }

        //this method will be used to preform return On Debt Device rental opreations
        //which will effect four tables (Rentals - Device rentals - Debts ,Payments) 
        //using transactions
        public static bool PreformDeviceReturnForDebtRental(int DeviceRentalID, int RenterID, int RentalID, int PaymentMethodID
            , decimal TotalFees, int CreatedByUserID)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformDeviceReturnForDebtRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@DeviceRentalID", DeviceRentalID);
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@PaymentMethod", PaymentMethodID);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           

            

            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }

        //this method will be used to preform pay debt opreation for all debts
        //it will effect three tables (Rentals - Payments - Debts)
        //using transactoins

        public static bool PreformPayDebtOpreatoin(int RentalID, int PaymentMethodID, int PaymentTypeID, int CreatedByUserID, decimal TotalAmount)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformPayDebtOpreatoin", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }

        //this method will be used to preform removing item from cart item opreation
        //it will effect two tables (CartITems and StoreItems)
        //using transaction
        public static bool PreformRemoveItemFromCartItemsOpreation(int CartItemID, int ItemID, int ReturnedQuantity)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformRemoveItemFromCartItemsOpreation", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@CartItemID", CartItemID);
            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@ReturnedQuantity", ReturnedQuantity);
           

            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }

        //this mehod will be used to preform cart payment opreaiton
        //it will effect 3 tables (payments, cartpayment, cart)
        //using transactions

        public static bool PreformCartPaymentOpreation(int CartID, int PaymentMethodID, int CreatedByUserID, decimal PaymentAmount)
        {
            //flag
            bool completed = false;

            //setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command
            SqlCommand command = new SqlCommand("SP_PreformCartPaymentOpreation", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters

            command.Parameters.AddWithValue("@CartID", CartID);
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);


            //setting the output parameter

            SqlParameter CompletedParam = new SqlParameter("@Completed", DbType.Binary)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CompletedParam);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (CompletedParam.Value != System.DBNull.Value)
                    completed = Convert.ToBoolean(CompletedParam.Value);
                else
                    completed = false;


            }
            catch (Exception ex)
            {
                completed = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't complete the opreation{ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return completed;
        }
    }
}
