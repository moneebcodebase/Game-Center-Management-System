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
    /// this class is represent the categories of the store
    /// </summary>
    public class clsStoreCategories
    {
        //private data members used in this class
        public enum enMode { AddNew=0 , Update}
        private enMode _Mode;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


        //public constructor 
        public clsStoreCategories()
        {
            this.CategoryID = 0;
            this.CategoryName = "";

            _Mode = enMode.AddNew;
        }
        private clsStoreCategories (int CategoryID ,string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;

            _Mode = enMode.Update;
        }


        //Private method to add new Store Item Data
        private bool _AddNewStoreCategory()
        {
            this.CategoryID = clsStoreCategories_Data_Access.AddNewStoreCategory(this.CategoryName);

            return (this.CategoryID > -1);
        }
        //Private method to Update a person's Data
        private bool _UpdateStoreCategory()
        {
            return clsStoreCategories_Data_Access.UpdateStoreCategory(this.CategoryID,this.CategoryName);
        }

        // this method used to save changes for both Update and AddNew Store Category
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStoreCategory())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateStoreCategory())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }

        //this method is to return a list full of all the categories
        public static List<clsStoreCategories> GetGategoriesList()
        {
            //creating the list what will hold the new categories objects
            List<clsStoreCategories> CategoriesList = new List<clsStoreCategories>();

            //Getting the datatable that will hold all of the categories content
            DataTable dtCategories = new DataTable();
            dtCategories = clsStoreCategories_Data_Access.GetAllCategories();

            //filling the list with the categories
            foreach (DataRow row in dtCategories.Rows)
            {
                clsStoreCategories Category = new clsStoreCategories(Convert.ToInt32(row["CategoryID"]), row["Name"].ToString());
               
                CategoriesList.Add(Category);
            }


            return CategoriesList;
        }
    }
}
