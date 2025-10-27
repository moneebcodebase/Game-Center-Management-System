using System;
using System.Data;
using System.Data.SqlClient;


namespace GCMS_Data_Access
{
    /// <summary>
    /// this class will represent Game types Data Access
    /// </summary>
    public static class clsGameTypes_Data_Access
    {
        //this method is to find a GameType from the database
        public static bool FindGameType(int GameTypeID,ref string GameTypeName)
        {
            bool IsFound = false;

            //Setting the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //Setting the command
            SqlCommand command = new SqlCommand("SP_FindGameType", connection);
            command.CommandType = CommandType.StoredProcedure;

            //input parameter
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);
            //output parameter
            SqlParameter GameTypeNameParam = new SqlParameter("@GameTypeName",SqlDbType.NVarChar,20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(GameTypeNameParam);

            //Starting Execution

            try
            {
                
                connection.Open();
                command.ExecuteNonQuery();

                //Check if the GameType Exists
                if(GameTypeNameParam.Value != DBNull.Value)
                {
                    GameTypeName = GameTypeNameParam.Value.ToString();
                    //Setting the flag to true
                    IsFound = true;
                }
                else
                    IsFound =false;


            }
            catch(Exception ex)
            {
                //Setting the flag to false
                IsFound =false;
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

        //Get all the game types
        public static DataTable GetGameTypesList()
        {
            //DataTable that will hold the games info
            DataTable dtGameTypesList = new DataTable();

            //setting the connection 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_GetGameTypesList", connection);
            command.CommandType = CommandType.StoredProcedure;


            //Start the execution

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                    dtGameTypesList.Load(Reader);
                else
                    dtGameTypesList = null;

                Reader.Close();
            }
            catch (Exception ex)
            {
                dtGameTypesList = null;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild to retrive the game types list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtGameTypesList;
        }


        
    }
}
