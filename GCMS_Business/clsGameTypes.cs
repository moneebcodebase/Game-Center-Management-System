using GCMS_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

namespace GCMS_Business
{
    /// <summary>
    /// This Calss Will Represent Game Types
    /// </summary>
    public class clsGameTypes
    {
        //Data members used in this class
        public int GameTypeID { get; set; }
        public string GameTypeName { get; set; }

        //Constructor for this class
        private clsGameTypes(int GameTypeID,string GameName)
        {
           this.GameTypeID = GameTypeID;
           this.GameTypeName = GameName;
        }

        //find a game type by id
        public static clsGameTypes FindGameType(int GameTypeID)
        {
            string GameTypeName = "";
            if(clsGameTypes_Data_Access.FindGameType(GameTypeID,ref GameTypeName))
                return new clsGameTypes(GameTypeID,GameTypeName);
            else
                return null;
        }

        //Get all game types
        public static List<clsGameTypes> GetGamesTypesList()
        {
            //Get the DataTable from the DataBase
            DataTable dtGamesTypeList = clsGameTypes_Data_Access.GetGameTypesList();

            //Creating the list that will be holding the all games objects
            List<clsGameTypes> GameTypesList = new List<clsGameTypes>();



            if (dtGamesTypeList != null)
            {
                //filling the list with objects
                foreach (DataRow row in dtGamesTypeList.Rows)
                {
                    clsGameTypes GameType = new clsGameTypes((int)row["GameTypeID"], row["GameTypeName"].ToString());


                    GameTypesList.Add(GameType);
                }
            }
            else
            {
                GameTypesList = null;
            }



            return GameTypesList;
        }

       
    }
}
