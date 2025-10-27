using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GCMS_Data_Access
{
    public class clsStoreItems_Data_Access
    {
        //this method is to find store item by id
        public static bool FindStoreItem(int ItemID,ref int CategoryID,ref string ItemName,ref decimal Price,ref int Quantity,ref string ItemImagePath)
        {
            //this is a flag to know if the record is found or not
            bool InformationFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindStoreItemByID", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@ItemID", ItemID);

            // Setting all of the out put parameters
            SqlParameter CategoryIDParam = new SqlParameter("@CategoryID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(CategoryIDParam);

            SqlParameter ItemNameParam = new SqlParameter("@ItemName", SqlDbType.NVarChar, 30)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ItemNameParam);


            SqlParameter PriceParam = new SqlParameter("@Price", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(PriceParam);


            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(QuantityParam);

            SqlParameter ItemImagePathParam = new SqlParameter("@ItemImagePath", SqlDbType.NVarChar, 250)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ItemImagePathParam);

            

            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the item with categoryID Does exists
                //if the Category id is found then there is definitely a record
                if (CategoryIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    InformationFound = true;
                    //filling all the parameters with value
                    CategoryID = (int)CategoryIDParam.Value;
                    ItemName = ItemNameParam.Value.ToString();

                    Price = Convert.ToDecimal(PriceParam.Value);
                    Quantity = (int)QuantityParam.Value;

                    //Handling the null Coulmn value possibility

                    if (ItemImagePathParam.Value != DBNull.Value)
                        ItemImagePath= ItemImagePathParam.Value.ToString();
                    else
                        ItemImagePath = "";

                   
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
                string Message = $"Error: Coudn't retrive store item data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return InformationFound;

        }

        //this method is to get all the store items data 
        public static DataTable GetAllStoreItems()
        {
            //Data table to hold users information
            DataTable StoreItemsList = new DataTable();

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Prepare command
            SqlCommand command = new SqlCommand("SP_GetAllStoreItems", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Execution
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    StoreItemsList.Load(reader);
                else
                    StoreItemsList = null;

                reader.Close();

            }
            catch (Exception ex)
            {
                StoreItemsList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't fetch store Items Data. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return StoreItemsList;
        }


        //this method is to add new store item record
        public static int AddNewStoreItem(int CategoryID, string ItemName, decimal Price, int Quantity, string ItemImagePath)
        {

            int ItemID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewStoreItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@ItemName", ItemName);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            //handling the possiblity of null value
            if (ItemImagePath != "")
                command.Parameters.AddWithValue("@ItemImagePath", ItemImagePath);
            else
                command.Parameters.AddWithValue("@ItemImagePath", System.DBNull.Value);

           

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter NewItemIDParam = new SqlParameter("@NewItemID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NewItemIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (NewItemIDParam.Value != System.DBNull.Value)
                    ItemID = (int)NewItemIDParam.Value;
                else
                    ItemID = -1;
            }
            catch (Exception ex)
            {
                ItemID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new Item. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return ItemID;
        }
        //this method is to update store item record 
        public static bool UpdateStoreItem(int ItemID,int CategoryID, string ItemName, decimal Price, int Quantity, string ItemImagePath)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateStoreItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@ItemName", ItemName);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            //handling the possiblity of null value
            if (ItemImagePath != "")
                command.Parameters.AddWithValue("@ItemImagePath", ItemImagePath);
            else
                command.Parameters.AddWithValue("@ItemImagePath", System.DBNull.Value);



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
                string Message = $"Error: Coun't Update Store Item Info. {ex.Message}";
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
