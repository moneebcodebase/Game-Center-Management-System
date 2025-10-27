using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    public class clsCarts_Data_Access
    {

        //this method is to find a cart
        public static bool FindCart(int CartID,ref bool IsLocked, ref int CreatedByUserID)
        {
            //this is a flag to know if the record is found or not
            bool InformationFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindCart", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@CartID", CartID);

            // Setting all of the out put parameters
            SqlParameter IsLockedParam = new SqlParameter("@IsLocked", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsLockedParam);

            SqlParameter CraetedByUserIDParam = new SqlParameter("@CreatedByUserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CraetedByUserIDParam);





            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the Person with PersonID Does exists
                //if the Firstname is found then there is definitely a record
                if (IsLockedParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    InformationFound = true;
                    //filling all the parameters with value
                    IsLocked = (bool)IsLockedParam.Value;
                    CreatedByUserID = (int)CraetedByUserIDParam.Value;


                }
                else
                {
                    //Setting the flag to false
                    InformationFound = false;
                }
            }
            catch (Exception ex)
            {
                InformationFound = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive cart data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return InformationFound;

        }
        //this method is to find active cart
        public static bool FindActiveCart(ref int CartID,bool IsLocked,ref int CreatedByUserID)
        {
            //this is a flag to know if the record is found or not
            bool InformationFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindActiveCart", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            // Setting all of the out put parameters
            SqlParameter CartIDParam = new SqlParameter("@CartID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CartIDParam);

            SqlParameter CraetedByUserIDParam = new SqlParameter("@CreatedByUserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CraetedByUserIDParam);


           


            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the Person with PersonID Does exists
                //if the Firstname is found then there is definitely a record
                if (CartIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    InformationFound = true;
                    //filling all the parameters with value
                    CartID = (int)CartIDParam.Value;
                    CreatedByUserID = (int)CraetedByUserIDParam.Value;

                  
                }
                else
                {
                    //Setting the flag to false
                    InformationFound = false;
                }
            }
            catch (Exception ex)
            {
                InformationFound = false;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive cart data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return InformationFound;

        }
        //this method is to add new person record
        public static int AddNewCart(bool IsLocked , int CreatedByUserID)
        {

            int CartID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewCart", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter CartIDParam = new SqlParameter("@NewCartID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CartIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (CartIDParam.Value != System.DBNull.Value)
                    CartID = (int)command.Parameters["@NewCartID"].Value;
                else
                    CartID = -1;
            }
            catch (Exception ex)
            {
                CartID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new cart. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return CartID;
        }

        //this method is to update person record 
        public static bool UpdateCart(int CartID,bool IsLocked, int CreatedByUserID)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateCart", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@CartID", CartID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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
                string Message = $"Error: Coun't Update Cart Info. {ex.Message}";
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
