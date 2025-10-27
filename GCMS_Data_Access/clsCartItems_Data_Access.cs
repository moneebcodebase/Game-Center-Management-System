using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    public class clsCartItems_Data_Access
    {
        //this method is to find a cart
        public static bool FindCartItem(int CartItemID,ref int CartID,ref int ItemID,ref int Quantity)
        {
            //this is a flag to know if the record is found or not
            bool InformationFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindCartItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@CartItemID", CartItemID);

            // Setting all of the out put parameters
            SqlParameter CartIDParam = new SqlParameter("@CartID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CartIDParam);

            SqlParameter ItemIDParam = new SqlParameter("@ItemID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ItemIDParam);

            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(QuantityParam);





            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                
                //if the Cart id is found then there is definitely a record
                if (CartIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    InformationFound = true;
                    //filling all the parameters with value
                    CartID = (int)CartIDParam.Value;
                    ItemID = (int)ItemIDParam.Value;
                    Quantity =(int)QuantityParam.Value;


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
                string Message = $"Error: Coudn't retrive cart item data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return InformationFound;

        }
       

        //this method is to add new cart item record
        public static int AddNewCartItem(int CartID,int ItemID,int Quantity)
        {

            int NewCartID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewCartItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@CartID", CartID);
            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@Quantity", Quantity);

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter CartItemIDParam = new SqlParameter("@NewCartItemID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CartItemIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (CartItemIDParam.Value != System.DBNull.Value)
                    NewCartID = (int)CartItemIDParam.Value;
                else
                    NewCartID = -1;
            }
            catch (Exception ex)
            {
                NewCartID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new cart item. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return NewCartID;
        }

        //this method is to update person record 
        public static bool UpdateCartItem(int CartItemID,int CartID, int ItemID, int Quantity)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateCartItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@CartItemID", CartItemID);
            command.Parameters.AddWithValue("@CartID", CartID);
            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@Quantity",Quantity);


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
                string Message = $"Error: Coun't Update Cart item Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        //method to get all the cart Items from the database 
        public static DataTable GetCartItems(int CartID)
        {
            //Data table to hold cart items information
            DataTable dtItemList = new DataTable();

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Prepare command
            SqlCommand command = new SqlCommand("SP_GetCartItems", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameter
            command.Parameters.AddWithValue("@CartID", CartID);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtItemList.Load(reader);
                else
                    dtItemList = null;

                reader.Close();

            }
            catch (Exception ex)
            {
                dtItemList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load cart items. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtItemList;

        }
    }
}
