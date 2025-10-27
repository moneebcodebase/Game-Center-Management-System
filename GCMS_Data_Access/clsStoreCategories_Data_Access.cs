using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GCMS_Data_Access
{
    /// <summary>
    /// this class will represent the categories data access layer
    /// </summary>
    public class clsStoreCategories_Data_Access
    {
        //method to get all the categories from the database 
        public static DataTable GetAllCategories()
        {
            //Data table to hold users information
            DataTable CategoriesList = new DataTable();

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Prepare command
            SqlCommand command = new SqlCommand("SP_GetAllCategories", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Execution
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    CategoriesList.Load(reader);
                else
                    CategoriesList = null;

                reader.Close();

            }
            catch (Exception ex)
            {
                CategoriesList = null;
                //Logging the error into Event Logger
                string Message = $"Coudn't load Categories. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return CategoriesList;

        }


        //this method is to add new store category record
        public static int AddNewStoreCategory(string CategoryName)
        {

            int NewCategoryID = -1;
            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_AddNewStoreCategroy", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            command.Parameters.AddWithValue("@CategoryName", CategoryName);
            

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter NewCategoryIDParam = new SqlParameter("@NewCategoryID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NewCategoryIDParam);

            //Executing
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (NewCategoryIDParam.Value != System.DBNull.Value)
                    NewCategoryID = (int)NewCategoryIDParam.Value;
                else
                    NewCategoryID = -1;
            }
            catch (Exception ex)
            {
                NewCategoryID = -1;
                //logging the error into the Event loger
                string Message = $"Error: Coudn't add new Category. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return NewCategoryID;
        }
        //this method is to update person record 
        public static bool UpdateStoreCategory(int CategoryID,string CategoryName)
        {
            int RowsEffected = 0;

            //connection the database
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //the command that will be excuted 
            //Excuting a stored procedure
            SqlCommand command = new SqlCommand("SP_UpdateStoreCategroy", connection);
            command.CommandType = CommandType.StoredProcedure;

            //setting the variables values
            
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);
            
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
                string Message = $"Error: Coun't Update Store Category Info. {ex.Message}";
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
