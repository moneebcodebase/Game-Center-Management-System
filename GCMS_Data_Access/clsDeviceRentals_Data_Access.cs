using System;
using System.Data;
using System.Data.SqlClient;


namespace GCMS_Data_Access
{
    public class clsDeviceRentals_Data_Access
    {
        //Find a device rental record 
        public static bool FindDeviceRental(int DeviceRentalID, ref int RenterID, ref int RentalID,ref int GameID, ref string RentalStatus, ref string Note)
        {
            //this is a flag to know if the record is found or not
            bool IsFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindDeviceRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@DeviceRentalID", DeviceRentalID);

            // Setting all of the out put parameters
            SqlParameter RenterIDParam = new SqlParameter("@RenterID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RenterIDParam);

            SqlParameter RentalIDParam = new SqlParameter("@RentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalIDParam);


            SqlParameter GameIDParam = new SqlParameter("@GameID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(GameIDParam);


            SqlParameter RentalStatusParam = new SqlParameter("@RentalStatus", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalStatusParam);

            SqlParameter NoteParam = new SqlParameter("@Note", SqlDbType.NVarChar,20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NoteParam);



            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the device rental with RenterID Does exists
                //if the Firstname is found then there is definitely a record
                if (RenterIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFound = true;

                    //filling all the parameters with value
                    RenterID= (int)RenterIDParam.Value;
                    RentalID = (int)RentalIDParam.Value;
                    GameID = (int)GameIDParam.Value;
                    RentalStatus = RentalStatusParam.Value.ToString();

                    //handling the null value
                    if (NoteParam.Value != DBNull.Value)
                        Note = NoteParam.Value.ToString();
                    else
                        Note = null;
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
        //Find active device rental for a game
        public static bool FindActiveDeviceRentalForAGame(ref int DeviceRentalID, ref int RenterID, ref int RentalID, int GameID, ref string RentalStatus, ref string Note)
        {
            //this is a flag to know if the record is found or not
            bool IsFound = false;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_FindActiveDeviceRentalForAGame", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@GameID", GameID);

            // Setting all of the out put parameters
            SqlParameter DeviceRentaIDParam = new SqlParameter("@DeviceRentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(DeviceRentaIDParam);

            SqlParameter RenterIDParam = new SqlParameter("@RenterID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RenterIDParam);

            SqlParameter RentalIDParam = new SqlParameter("@RentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalIDParam);



            SqlParameter RentalStatusParam = new SqlParameter("@RentalStatus", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RentalStatusParam);

            SqlParameter NoteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NoteParam);



            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the device rental with RenterID Does exists
                //if the Firstname is found then there is definitely a record
                if (RenterIDParam.Value != DBNull.Value)
                {
                    //putting the falg to true 
                    IsFound = true;

                    //filling all the parameters with value
                    DeviceRentalID = (int)DeviceRentaIDParam.Value;
                    RenterID = (int)RenterIDParam.Value;
                    RentalID = (int)RentalIDParam.Value;
                    RentalStatus = RentalStatusParam.Value.ToString();

                    //handling the null value
                    if (NoteParam.Value != DBNull.Value)
                        Note = NoteParam.Value.ToString();
                    else
                        Note = null;
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
        public static bool IsDeviceRentalOnRent(int GameID)
        {
            //Boolean flag 
            bool IsOnRent = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_IsDeviceRentalOnRent", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input Parameter
            command.Parameters.AddWithValue("@GameID", GameID);
            //Setting output Parameter
            SqlParameter IsOnRentParam = new SqlParameter("@IsOnRent", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IsOnRentParam);


            //Execution
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (IsOnRentParam.Value != DBNull.Value)
                {
                    IsOnRent = Convert.ToBoolean(IsOnRentParam.Value);
                }
                else
                    IsOnRent = false;

            }
            catch (Exception ex)
            {
                IsOnRent = false;
                //Logging the Error to the Event Loger
                string Message = $"Error: Faild while trying to check the device rental status. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }


            return IsOnRent;
        }
        //Add new device rental
        public static int AddNewDeviceRental(int RenterID, int RentalID,int GameID,string RentalStatus,string Note)
        {
            //the new  Game id  that will be returned
            int NewDeviceRentalID = -1;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Setting the command
            SqlCommand command = new SqlCommand("SP_AddNewDeviceRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@RentalStatus", RentalStatus);
            
            if(Note != null || Note != "")
               command.Parameters.AddWithValue("@Note", Note);
            else
                command.Parameters.AddWithValue("@Note",System.DBNull.Value);


            //Setting the output parameters
            SqlParameter NewDeviceRentalIDParam = new SqlParameter("@@NewDeviceRentalID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(NewDeviceRentalIDParam);


            //Starting Excution

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //Checking if the new Game is addedd
                if (NewDeviceRentalIDParam.Value != DBNull.Value)
                    NewDeviceRentalID = (int)NewDeviceRentalIDParam.Value;
                else
                    NewDeviceRentalID = -1;
            }
            catch (Exception ex)
            {
                NewDeviceRentalID = -1;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't add data {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return NewDeviceRentalID;

        }
        //update device rental into
        public static bool UpdateDeviceRental(int DeviceRentalID,int RenterID, int RentalID, int GameID, string RentalStatus, string Note)
        {
            //int flag
            int RowsEffected = 0;

            //Setting the connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //Setting the command
            SqlCommand command = new SqlCommand("SP_UpdateDeviceRental", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Setting the input parameters
            command.Parameters.AddWithValue("@DeviceRentalID", DeviceRentalID);
            command.Parameters.AddWithValue("@RenterID", RenterID);
            command.Parameters.AddWithValue("@RentalID", RentalID);
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@RentalStatus", RentalStatus);

            if (Note != null)
                command.Parameters.AddWithValue("@Note", Note);
            else
                command.Parameters.AddWithValue("@Note", System.DBNull.Value);

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
                string Message = $"Error: Coun't Update device Rental Info. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return (RowsEffected > 0);

        }

        //this method gets the renter who rentered a game
        public static int GetTheGameRenterID(int GameID)
        {
            int RenterID = 0;

            //preparing the database connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //command to excute stored procedure
            SqlCommand command = new SqlCommand("SP_GetTheGameRenterID", connection);
            command.CommandType = CommandType.StoredProcedure;

            //the input parameter
            command.Parameters.AddWithValue("@GameID", GameID);

            // Setting all of the out put parameters
            SqlParameter RenterIDParam = new SqlParameter("@RenterID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RenterIDParam);

           


            //Starting Execution
            try
            {
                connection.Open();

                command.ExecuteNonQuery();



                //Making sure that there is a data that returns and that the device rental with RenterID Does exists
                //if the Firstname is found then there is definitely a record
                if (RenterIDParam.Value != DBNull.Value)
                    RenterID = (int)RenterIDParam.Value;
                else
                    RenterID = 0;
                
                
            }
            catch (Exception ex)
            {
                RenterID = 0;
                //Loging the Error to the Event Loger
                string Message = $"Error: Coudn't retrive data. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                //Closing the connection to prevent filling the connection pool
                connection.Close();
            }

            return RenterID ;


        }

    }
}
