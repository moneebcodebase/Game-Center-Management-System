using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    /// <summary>
    /// this class will represent Payment methods Data Access
    /// </summary>
    public static class clsPaymentMethod_Data_Access
    {
        //this method is to find a Paymentmethod from the database
        public static bool FindPaymentMethod(int PaymentMethodID, ref string PaymentMethodName)
        {
            bool IsFound = false;

            //Setting the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Setting the command
            SqlCommand command = new SqlCommand("SP_FindPaymentMethod", connection);
            command.CommandType = CommandType.StoredProcedure;

            //input parameter
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            //output parameter
            SqlParameter PaymentMethodNameParam = new SqlParameter("@PaymentMethodName", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentMethodNameParam);

            //Starting Execution

            try
            {

                connection.Open();
                command.ExecuteNonQuery();

                //Check if the GameType Exists
                if (PaymentMethodNameParam.Value != DBNull.Value)
                {
                    PaymentMethodName = PaymentMethodNameParam.Value.ToString();
                    //Setting the flag to true
                    IsFound = true;
                }
                else
                    IsFound = false;


            }
            catch (Exception ex)
            {
                //Setting the flag to false
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
    }
}
