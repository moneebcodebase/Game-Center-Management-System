using System;
using System.Data;
using System.Collections.Generic;
using GCMS_Data_Access;

namespace GCMS_Business
{
    /// <summary>
    /// This class is to represent the games
    /// </summary>
    public class clsGames
    {
        //Data members used in this class
        public enum enMode { AddNew =1,Update =2};
        private enMode _Mode;

        public int GameID { get; set; }
        public int GameTypeID { get; set; }
              
        public clsGameTypes GameType;//Composition to use all of the info about the gametype
        public string GameName { get; set; }
        public decimal Rate { get; set; }
        public bool Status { get; set; }
        public int DisplayOrder { get; set; }

        // First Constructor used to update a record
        private clsGames(int GameID,int GameTypeID,string GameName,decimal Rate,bool Status,int DisplayOrder)
        {
            this.GameID =GameID;
            this.GameTypeID =GameTypeID;
            this.GameType = clsGameTypes.FindGameType(GameTypeID);
            this.GameName = GameName;
            this.Rate = Rate;
            this.Status =Status;
            this.DisplayOrder =DisplayOrder;

            _Mode = enMode.Update;
        }
        // Second Constructor used to add new record
        public clsGames()
        {
            this.GameID =0;
            this.GameTypeID = 0;
            this.GameName ="";
            this.Rate = 0;
            this.Status = false;
            this.DisplayOrder =0;

            _Mode = enMode.AddNew;
        }




        //Find game with PersonID
        public static clsGames FindGame(int GameID)
        {
            int GameTypeID = 0;
            string GameName = "";
            decimal Rate = 0;
            bool Status = false;
            int DisplayOrder = 0;

            bool IsFound = clsGames_Data_Access.FindGame(GameID, ref GameTypeID, ref GameName, ref Rate, ref Status, ref DisplayOrder);

            if (IsFound)
                return new clsGames(GameID, GameTypeID, GameName, Rate, Status, DisplayOrder);
            else
                return null;

        }

        //Check if the game is available or not
        public static bool IsGameAvailable(int GameID)
        {
            return clsGames_Data_Access.IsGameAvailable(GameID);
        }

        //private method used to add new game
        private bool _AddNewGame()
        {
            this.GameID = clsGames_Data_Access.AddNewGame(this.GameTypeID, this.GameName, this.Rate, this.Status);

            //getting the game type info
            if(this.GameID >-1)
                this.GameType = clsGameTypes.FindGameType(GameTypeID);

            return (this.GameID > -1);
        }
        //Private method to Update a game
        private bool _UpdateGame()
        {
            return clsGames_Data_Access.UpdateGame(this.GameID, this.GameTypeID, this.GameName, this.Rate, this.Status,this.DisplayOrder);
        }

        // this method used to save changes for both Update and AddNew Person
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGame())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateGame())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


        //this method is used to get the games list by gametype

        public static List<clsGames> GetGamesListByGameType(int GameType)
        {
            //Get the DataTable from the DataBase
            DataTable dtGamesList = clsGames_Data_Access.GetGamesListByGameType(GameType);

            //Creating the list that will be holding the all games objects
            List<clsGames> GamesList = new List<clsGames>();


            
            if(dtGamesList != null)
            {
                //filling the list with objects
                foreach (DataRow row in dtGamesList.Rows)
                {
                    clsGames Game = new clsGames((int)row["GameID"], (int)row["GameTypeID"], row["GameName"].ToString(), 
                        Convert.ToDecimal(row["Rate"]), Convert.ToBoolean(row["Status"]), (int)row["DisplayOrder"]);


                    GamesList.Add(Game);
                }
            }
            else
            {
                GamesList = null;
            }
            


            return GamesList;
        }

        public static List<clsGames> GetGamesList()
        {
            //Get the DataTable from the DataBase
            DataTable dtGamesList = clsGames_Data_Access.GetGamesList();

            //Creating the list that will be holding the all games objects
            List<clsGames> GamesList = new List<clsGames>();



            if (dtGamesList != null)
            {
                //filling the list with objects
                foreach (DataRow row in dtGamesList.Rows)
                {
                    clsGames Game = new clsGames((int)row["GameID"], (int)row["GameTypeID"], row["GameName"].ToString(),
                        Convert.ToDecimal(row["Rate"]), Convert.ToBoolean(row["Status"]), (int)row["DisplayOrder"]);


                    GamesList.Add(Game);
                }
            }
            else
            {
                GamesList = null;
            }



            return GamesList;
        }



    }
    
}
