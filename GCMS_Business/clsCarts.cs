using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCMS_Data_Access;

namespace GCMS_Business
{
    public class clsCarts
    {
        //data Members used in this class
        public enum enMode { AddNew=0, Update};
        private enMode _Mode;

        public int CartID { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedByUserID { get; set; }


        //public constructor for new carts
        public clsCarts()
        {
            this.CartID = 0;
            this.IsLocked = false;
            this.CreatedByUserID = 0;

            this._Mode = enMode.AddNew;
        }

        //private constructor to update a cart
        private clsCarts(int CartID,bool IsLocked ,int CreatedByUserID)
        {
            this.CartID = CartID;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = enMode.Update;
        }


        //Find Acitve Cart 
        public static clsCarts FindActiveCart()
        {
            int CartID = 0;
            bool IsLocked = false; // to only look for the active unclosed cart
            int CreatedByUserID = 0;

            bool IsFound = clsCarts_Data_Access.FindActiveCart(ref CartID,IsLocked,ref CreatedByUserID);

            if (IsFound)
                return new clsCarts(CartID, IsLocked, CreatedByUserID);
            else
                return null;

        }
        //Find Cart with cart id
        public static clsCarts FindCart(int CartID)
        {
            
            bool IsLocked = false;
            int CreatedByUserID = 0;

            bool IsFound = clsCarts_Data_Access.FindCart(CartID,ref IsLocked,ref CreatedByUserID);

            if (IsFound)
                return new clsCarts(CartID, IsLocked, CreatedByUserID);
            else
                return null;

        }

        //private method to add new cart
        private bool _AddNewCart()
        {
            this.CartID = clsCarts_Data_Access.AddNewCart(this.IsLocked,this.CreatedByUserID);

            return (this.CartID > -1);
        }
        //Private method to Update a cart's Data
        private bool _UpdateCart()
        {
            return clsCarts_Data_Access.UpdateCart(this.CartID,this.IsLocked, this.CreatedByUserID);
        }

        // this method used to save changes for both Update and AddNew Cart
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCart())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    if (_UpdateCart())
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }

    }
    
}
