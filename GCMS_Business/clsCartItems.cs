using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GCMS_Data_Access;


namespace GCMS_Business
{
    public class clsCartItems
    {
        //data Members used in this class
        public enum enMode { AddNew = 0, Update };
        private enMode _Mode;

        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public clsCarts Cart;
        public int ItemID { get; set; }
        public clsStoreItems Item;
        public int Quantity { get; set; }


        //public constructor for new cart item
        public clsCartItems()
        {
            this.CartItemID = 0;
            this.CartID = 0;
            this.ItemID = 0;
            this.Quantity = 0;

            this._Mode = enMode.AddNew;
        }

        //private constructor to update a cart item
        private clsCartItems(int CartItemID,int CartID, int ItemID,int Quantity)
        {
            this.CartItemID = CartItemID;
            this.CartID = CartID;
            Cart = clsCarts.FindCart(CartID);
            this.ItemID = ItemID;
            Item = clsStoreItems.FindStoreItem(ItemID);
            this.Quantity = Quantity;


            this._Mode = enMode.Update;
        }


       
        //Find Cart Items with CartItemsID
        public static clsCartItems FindCartItem(int CartItemID)
        {

            int CartID = 0;
            int ItemID = 0;
            int Quantity = 0;

            bool IsFound = clsCartItems_Data_Access.FindCartItem(CartItemID,ref CartID,ref ItemID,ref Quantity);

            if (IsFound)
                return new clsCartItems(CartItemID, CartID, ItemID, Quantity);
            else
                return null;

        }

        //private method to add new cart item
        private bool _AddNewCartItem()
        {
            this.CartItemID = clsCartItems_Data_Access.AddNewCartItem(this.CartID,this.ItemID,this.Quantity);

            return (this.CartItemID > -1);
        }
        //Private method to Update cart item Data
        private bool _UpdateCartItem()
        {
            return clsCartItems_Data_Access.UpdateCartItem(this.CartItemID,this.CartID, this.ItemID, this.Quantity);
        }

        // this method used to save changes for both Update and AddNew Cart item
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCartItem())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateCartItem())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }


        //this method is to return a list full of all Cart items
        public static DataTable GetCartItems(int CartID)
        {
            return clsCartItems_Data_Access.GetCartItems(CartID);
        }
    }
}
