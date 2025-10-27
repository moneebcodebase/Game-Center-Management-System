using System;


namespace GCMS_Infrastructure
{

    /// <summary>
    /// This class is shared for all the controls that will use the Rent Completed event args
    /// </summary>
    public class clsRentCompletedEventArgs : EventArgs
    {
        public decimal TotalPayment { get; set; }
        

        public clsRentCompletedEventArgs(decimal TotalPayment)
        {
            this.TotalPayment = TotalPayment;
           
        }

    }

    /// <summary>
    /// this class is for the category selected event args
    /// </summary>
    public class clsStoreCategoryEventArgs : EventArgs
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public clsStoreCategoryEventArgs(int CategoryID, string Name)
        {
            this.CategoryID = CategoryID;
            this.Name = Name;

        }

    }
    /// <summary>
    /// this class is for the store item selected (add to cart) event Args
    /// </summary>
   public class clsStoreItemSelectedEventArgs : EventArgs
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int SelectedQuantity { get; set; }
        public decimal PricePerItem { get; set; }

        public clsStoreItemSelectedEventArgs(int ItemID, string ItemName,int SelectedQuantity,decimal PricePerItem)
        {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.SelectedQuantity = SelectedQuantity;
            this.PricePerItem = PricePerItem;
        }
    }
}
