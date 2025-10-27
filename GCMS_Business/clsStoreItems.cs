using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GCMS_Data_Access;

namespace GCMS_Business
{
    /// <summary>
    /// this class will represnt sotre items
    /// </summary>
    public class clsStoreItems
    {
        public enum enMode { AddNew = 1, Update = 2 };

        private enMode _Mode;
        //Data members used in this class
        public int ItemID { get; set; }
        public int CategoryID { get; set; } //No need for composition 
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ItemImagePath { get; set; }  

        //public constructor to add new items
        public clsStoreItems()
        {
            this.ItemID = 0;
            this.CategoryID = 0;
            this.ItemName = null;
            this.Price = 0;
            this.Quantity = 0;
            this.ItemImagePath = null;

            this._Mode = enMode.AddNew;
        }
        //public constructor for update and list
        //this constructore is public for one reason which to be able to use it in the get list and for thr find item at the same time
        private clsStoreItems(int ItemID,int CategoryID,string ItemName,decimal Price,int Quantity,string ItemImagePath)
        {
            this.ItemID = ItemID;
            this.CategoryID= CategoryID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.Quantity = Quantity;
            this.ItemImagePath = ItemImagePath;

            _Mode = enMode.Update;
        }


        //Find store item by id
        public static clsStoreItems FindStoreItem(int ItemID)
        {
            int CategoryID = 0;
            string ItemName = null;
            decimal Price = 0;
            int Quantity = 0;
            string ItemImagePath = null;

            bool IsFound = clsStoreItems_Data_Access.FindStoreItem(ItemID,ref CategoryID,ref ItemName,ref Price,ref Quantity,ref ItemImagePath);

            if (IsFound)
                return new clsStoreItems(ItemID, CategoryID, ItemName, Price, Quantity, ItemImagePath);
            else
                return null;

        }

        //Get All store itmes
        public static List<clsStoreItems> GetStoreItemsList()
        {
            //creating the list what will hold the new categories objects
            List<clsStoreItems> StoreItemsList = new List<clsStoreItems>();

            //Getting the datatable that will hold all of the categories content
            DataTable dtStoreItems = new DataTable();
            dtStoreItems = clsStoreItems_Data_Access.GetAllStoreItems();

            //filling the list with the categories
            foreach (DataRow row in dtStoreItems.Rows)
            {
                clsStoreItems StoreItem = new clsStoreItems(Convert.ToInt32(row["ItemID"]), Convert.ToInt32(row["CategoryID"]), row["ItemName"].ToString(),
                   Convert.ToDecimal(row["Price"]), Convert.ToInt32(row["Quantity"]),row["ItemImagePath"].ToString());

                StoreItemsList.Add(StoreItem);
            }


            return StoreItemsList;
        }



        //Private method to add new Store Item Data
        private bool _AddNewStoreItem()
        {
            this.ItemID = clsStoreItems_Data_Access.AddNewStoreItem(this.CategoryID,this.ItemName,this.Price,this.Quantity,this.ItemImagePath);

            return (this.ItemID > -1);
        }
        //Private method to Update a person's Data
        private bool _UpdateStoreItem()
        {
            return clsStoreItems_Data_Access.UpdateStoreItem(this.ItemID,this.CategoryID,this.ItemName,this.Price,this.Quantity,this.ItemImagePath);
        }

        // this method used to save changes for both Update and AddNew StoreItem
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStoreItem())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateStoreItem())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


    }
}
