using System;
using System.Data;
using System.Data.SqlClient;


namespace GCMS_Data_Access
{
    /// <summary>
    /// This class represent Payment data access
    /// </summary>
    public static class clsPayments_Data_Access
    {

        //Find payment
        public static bool FindPayment(int PaymentID, ref int PaymentTypeID, ref int PaymentMethodID, ref DateTime PaymentDate,
            ref decimal Amount, ref int CreatedByUserID)
        {
            //this is a flag to know if the record is found or not
            bool IsFoung = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindPayment", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            // Setting all of the out put parameters
            SqlParameter PaymentTypeIDParam = new SqlParameter("@PaymentTypeID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentTypeIDParam);

            SqlParameter PaymentMethodIDParam = new SqlParameter("@PaymentMethodID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentMethodIDParam);


            SqlParameter PaymentDateParam = new SqlParameter("@PaymentDate", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentDateParam);


            SqlParameter AmountParam = new SqlParameter("@Amount", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(AmountParam);

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



                //Making sure that there is a data that returns 
                if (PaymentTypeIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFoung = true;
                    //filling all the parameters with value
                    PaymentTypeID = (int)PaymentTypeIDParam.Value;
                    PaymentMethodID = (int)PaymentMethodIDParam.Value;
                    PaymentDate = (DateTime)PaymentDateParam.Value;
                    Amount = Convert.ToDecimal(AmountParam.Value);
                    CreatedByUserID = (int)CreatedByUserIDParam.Value;


                }
                else
                {
                    //Setting the flag to false
                    IsFoung = false;
                }
            }
            catch (Exception ex)
            {
                IsFoung = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return IsFoung;
        }


        //Add new Payment
        public static int AddNewPayment(int PaymentTypeID,int PaymentMethodID,DateTime PaymentDate,decimal Amount,
        int CreatedByUserID)
        {
             //the new  Game id  that will be returned
            int NewPaymentID = -1;

            //Setting the connection
            SqlConnection connection= new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Setting the command
            SqlCommand command = new SqlCommand("SP_AddNewPayment", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@PaymentAmount", Amount);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            //Setting the output parameters
            SqlParameter NewPaymentIDParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NewPaymentIDParam);


            //Starting Excution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //Checking if the new Game is addedd
                if (NewPaymentIDParam.Value != DBNull.Value)
                    NewPaymentID = (int)NewPaymentIDParam.Value;
                else
                    NewPaymentID = -1;
            }
            catch (Exception ex)
            {
                NewPaymentID = -1;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't add data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return NewPaymentID;

        }


        
    }
}
