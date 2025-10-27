using System;
using System.Data;
using System.Data.SqlClient;

namespace GCMS_Data_Access
{
    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// This class will represent Games Data Accesss
    /// </summary>
    public static class clsGames_Data_Access
    {
        //Find a game record 
        public static bool FindGame(int GameID, ref int GameTypeID, ref string GameName, ref decimal Rate, ref bool Status,
            ref int DisplayOrder)
        {
            //this is a flag to know if the record is found or not
            bool IsFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindGame", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@GameID", GameID);

            // Setting all of the out put parameters
            SqlParameter GameTypeIDParam = new SqlParameter("@GameTypeID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(GameTypeIDParam);

            SqlParameter GameNameParam = new SqlParameter("@GameName", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(GameNameParam);


            SqlParameter RateParam = new SqlParameter("@Rate", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RateParam);


            SqlParameter StatusParam = new SqlParameter("@Status", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(StatusParam);

            SqlParameter DisplayOrderParam = new SqlParameter("@DisplayOrder", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(DisplayOrderParam);

            

            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the Game with GameID Does exists
                //if the Firstname is found then there is definitely a record
                if (GameNameParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFound = true;
                    //filling all the parameters with value
                    GameTypeID = (int)GameTypeIDParam.Value;
                    GameName = GameNameParam.Value.ToString();
                    Rate =  Convert.ToDecimal(RateParam.Value);
                    Status = Convert.ToBoolean( StatusParam.Value);
                    DisplayOrder = (int)DisplayOrderParam.Value;
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

        //check if the game is avaliable for use or not
        public static bool IsGameAvailable(int GameID)
        {
            //Boolean flag 
            bool IsAvailable = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_IsGameAvailable", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input Parameter
            command.Parameters.AddWithValue("@GameID", GameID);
            //Setting output Parameter
            SqlParameter IsAvailableParam = new SqlParameter("@IsAvailable", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsAvailableParam);


            //Execution
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsAvailableParam.Value != DBNull.Value)
                {
                    IsAvailable = Convert.ToBoolean(IsAvailableParam.Value);
                }
                else
                    IsAvailable = false;

            }
            catch (Exception ex)
            {
                IsAvailable = false;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild while trying to check the game status. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }


            return IsAvailable;
        }
        //Add new Game to games 
        public static int AddNewGame(int GameTypeID,string GameName,decimal Rate,bool Status)
        {
            //the new  Game id  that will be returned
            int NewGameID = -1;

            //Setting the connection
            SqlConnection connection= new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Setting the command
            SqlCommand command = new SqlCommand("SP_AddNewGame", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);
            command.Parameters.AddWithValue("@GameName",GameName);
            command.Parameters.AddWithValue("@Rate",Rate);
            command.Parameters.AddWithValue("@Status",Status);
            //Setting the output parameters
            SqlParameter NewGameIDParam = new SqlParameter("@NewGameID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NewGameIDParam);


            //Starting Excution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //Checking if the new Game is addedd
                if (NewGameIDParam.Value != DBNull.Value)
                    NewGameID = (int)NewGameIDParam.Value;
                else
                    NewGameID = -1;
            }
            catch (Exception ex)
            {
                NewGameID = -1;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't add data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return NewGameID;

        }
        //update a game into
        public static bool UpdateGame(int GameID,int GameTypeID, string GameName, decimal Rate, bool Status, int DisplayOrder)
        {
            //int flag
            int RowsEffected = 0;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Setting the command
            SqlCommand command = new SqlCommand("SP_UpdateGame", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);
            command.Parameters.AddWithValue("@GameName", GameName);
            command.Parameters.AddWithValue("@Rate", Rate);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@DisplayOrder", DisplayOrder);
            //Creating the output parameter that will return from the procedure
            SqlParameter outputParam = new SqlParameter("@RowsEffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputParam);


            //Starting Excution

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
                string Message = $"Error: Coun't Update Game Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);

        }
        //Get the games list by game type id
        public static DataTable GetGamesListByGameType(int GameTypeID)
        {
            //DataTable that will hold the games info
            DataTable dtGamesList = new DataTable();

            //setting the connection 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_GetGameslistByGameType", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);


            //Start the execution

            try
            {
                connection.Open();
                
                SqlDataReader Reader = command.ExecuteReader();

                if(Reader.HasRows)
                    dtGamesList.Load(Reader);
                else
                    dtGamesList =null;

                Reader.Close(); 
            }
            catch(Exception ex)
            {
                dtGamesList=null;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild to retrive the game list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtGamesList;
        }

        //Get all the games
        public static DataTable GetGamesList()
        {
            //DataTable that will hold the games info
            DataTable dtGamesList = new DataTable();

            //setting the connection 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //preparing the command 
            SqlCommand command = new SqlCommand("SP_GetGameslist", connection);
            command.CommandType = CommandType.StoredProcedure;


            //Start the execution

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                    dtGamesList.Load(Reader);
                else
                    dtGamesList = null;

                Reader.Close();
            }
            catch (Exception ex)
            {
                dtGamesList = null;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild to retrive the game list. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtGamesList;
        }


    }
}
