using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    /// <summary>
    /// this class will represent Payment types Data Access
    /// </summary>
     public static class clsPaymentTypes_Data_Access
    {
        //this method is to find a PaymentType from the database
        public static bool FindPaymentType(int PaymentTypeID, ref string PaymentTypeName)
        {
            bool IsFound = false;

            //Setting the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Setting the command
            SqlCommand command = new SqlCommand("SP_FindPaymentType", connection);
            command.CommandType = CommandType.StoredProcedure;

            //input parameter
            command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
            //output parameter
            SqlParameter PaymentTypeNameParam = new SqlParameter("@PaymentTypeName", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PaymentTypeNameParam);

            //Starting Execution

            try
            {

                connection.Open();
                command.ExecuteNonQuery();

                //Check if the GameType Exists
                if (PaymentTypeNameParam.Value != DBNull.Value)
                {
                    PaymentTypeName = PaymentTypeNameParam.Value.ToString();
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
