using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Business;
using GCMS_Infrastructure;
using System.IO;

namespace GCMS.User_Control
{
    /// <summary>
    /// This control will represent a store item
    /// </summary>
    public partial class ctrlStoreItem : UserControl
    {
        //Data Memebers used in this control
        private clsStoreItems _StoreItem;

        //constructor that only allow creating an instance only with store item control object
        public ctrlStoreItem(clsStoreItems StoreItem)
        {
            InitializeComponent();


            _StoreItem = StoreItem;

            
        }


        //Filling the Store item control with information
        private void _FillTheStoreItemControlWithData()
        {
            gbItemName.Text = _StoreItem.ItemName;
            lblItemPrice.Text = "$" + _StoreItem.Price.ToString();
            _LoadItemImage();
            _SetNUDLimits();
        }

        //private method that controls the numaric up down limits
        private void _SetNUDLimits()
        {
            lblItemQuantity.Text = _StoreItem.Quantity.ToString();

            if (_StoreItem.Quantity != 0)
            {
                nudSelectedAmount.Minimum = 1;
                nudSelectedAmount.Maximum = _StoreItem.Quantity;

                nudSelectedAmount.Enabled = true;
                lblNoItemsLeft.Visible = false;
                btnAddToCart.Enabled = true;
            }
            else
            {
                nudSelectedAmount.Minimum = 0;
                nudSelectedAmount.Maximum = 0;

                nudSelectedAmount.Enabled = false;
                lblNoItemsLeft.Visible = true;
                btnAddToCart.Enabled = false;
            }
        }
        //private method used to load the item image
        private void _LoadItemImage()
        {
            // Dispose existing image if there is one
            if (pbItemImage.Image != null)
            {
                pbItemImage.Image.Dispose();
                pbItemImage.Image = null;
            }

            try
            {
                if (File.Exists(_StoreItem.ItemImagePath))
                {
                    // Load the image into memory to avoid file lock
                    using (var fs = new FileStream(_StoreItem.ItemImagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;
                            pbItemImage.Image = Image.FromStream(ms);
                        }
                    }
                   
                }
                else
                {
                    // Image path not found - load default image from resources
                    pbItemImage.Image = Properties.Resources.StoreItme_256;
                }
            }
            catch
            {
                // In case of any other error, also load the default image
                pbItemImage.Image = Properties.Resources.StoreItme_256;
            }
        }

        private void ctrlStoreItem_Load(object sender, EventArgs e)
        {
            //Filling the item control with information

            _FillTheStoreItemControlWithData();
        }



        //public event to return the selected Item information with the selected quantity
        // ON Add to cart click

        public event EventHandler<clsStoreItemSelectedEventArgs> OnAddToCartClick;
        //method to Raise the event on the add to cart button click
        public void RaiseOnAddToCartClick(int ItemID,string ItemName,int SelectedQuantity,decimal PricePerItem)
        {
            RaiseOnAddToCartClick(new clsStoreItemSelectedEventArgs(ItemID,ItemName,SelectedQuantity,PricePerItem));
        }
        protected void RaiseOnAddToCartClick(clsStoreItemSelectedEventArgs e)
        {
           OnAddToCartClick?.Invoke(this, e);
        }



        //public method used to cancel the selected quantity for the store item and update the database
        public void CancelSelectedItemQuantity(int Quantity)
        {
            //add the quantity to the store item quantity and update the num limits
            _StoreItem.Quantity += Quantity;
            _SetNUDLimits();

           _StoreItem.Save();
        }

        //This button will handel the add to cart functionality
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            
            int PreviousQuantity = _StoreItem.Quantity;

            //Subtract the selected quantity form the main quantity
            _StoreItem.Quantity = _StoreItem.Quantity - (int)nudSelectedAmount.Value;
            _SetNUDLimits();

            if (_StoreItem.Save())
            {
                //Raise the event to expose the needed data to the main form
                RaiseOnAddToCartClick(_StoreItem.ItemID, _StoreItem.ItemName, (int)nudSelectedAmount.Value, _StoreItem.Price);
            }
            else
            {
                //if the update failed restore the preivous state
                _StoreItem.Quantity = PreviousQuantity;
                _SetNUDLimits();
            }

        }

       
    }
}
