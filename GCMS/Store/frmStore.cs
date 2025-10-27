using GCMS.Game_Manaegement;
using GCMS.User_Control;
using GCMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCMS.Store
{
    public partial class frmStore : Form
    {
                                       //Praiate data members

        //Private data member that will represnt all the store items
        private List<clsStoreItems> _AllStoreItems;

        //Dictionary that will hold refrence to the loaded controls
        private Dictionary<int, ctrlStoreItem> _ItemControls = new Dictionary<int,ctrlStoreItem>();

        //represnt the active cart (either exists or it will be null and the itemcontrol will create new one for use)
        private clsCarts _Cart;

        //hold the current category id to use it when refreshing the items
        private int _CurrentCategoryID = 0;




        //Constructor
        public frmStore()
        {
            InitializeComponent();

            
        }



        //ON Store form load 
        private void frmStore_Load(object sender, EventArgs e)                                                                                      
        {
            //Load all store items
            _AllStoreItems = clsStoreItems.GetStoreItemsList();
            //load the active cart if exists
            _Cart = clsCarts.FindActiveCart();
        }




                                                  //Status strip changes
        private void frmStore_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }

        private void ctrlGategoriesList1_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Select a Category to show it's details.";
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }

        private void pnlOptions_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }

        private void btnCart_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Click to manage the cart.";
        }

        private void btnCategoriesManagement_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Click to manage the categories and items.";
        }

        private void pbStoreImage_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }


        // Items Lising & cart handling 

        //private method that will handle filling the items 
        private async void _FillThefolpItemsWithCategoryItems(int CategoryID)
        {
            if (CategoryID == 0)//that means that no category has been selected so there is no _CurrentCategoryID
                return;



            //Using the linq this will filter the itmes per category
            List<clsStoreItems> FilteredItems = _AllStoreItems.Where(Item => Item.CategoryID == CategoryID).ToList();


            //Clear the flow layout panel and the dictionanry
            flpItems.Controls.Clear();
            _ItemControls.Clear();


            //if the category does not have any items show the no data control else load the items control
            if (FilteredItems.Count == 0)
            {
                ctrlNoData noData = new ctrlNoData();
                noData.Margin = new Padding((flpItems.Width - noData.Width) / 2, 20, 0, 0); // Horizontal center

                flpItems.Controls.Add(noData);
            }
            else
            {
                //loop through all items
                foreach(clsStoreItems Item in FilteredItems)
                {
                    ctrlStoreItem ItemControl = new ctrlStoreItem(Item);
                    ItemControl.Margin = new Padding(10); // space between controls
                    ItemControl.OnAddToCartClick += ItemControl_OnAddToCartClick; //Subscribe to the event
                    flpItems.Controls.Add(ItemControl);

                    _ItemControls[Item.ItemID] = ItemControl; //hold the refrence to that control in the dictionary to handle the reverse 

                    await Task.Delay(80);
                }

               
            }
        }
        private void _RefreshItemsfolv()
        {
            _AllStoreItems = clsStoreItems.GetStoreItemsList(); // Reload from DB
            _FillThefolpItemsWithCategoryItems(_CurrentCategoryID); // Rebind UI
            _Cart = clsCarts.FindActiveCart();//update the cart information in case that cart has been closed
        }
        private bool _ConfirmTheExistanceOftheActiveCart()
        {
            
            if (_Cart == null) //Create new cart
            {
                _Cart = new clsCarts();

                _Cart.IsLocked = false;
                _Cart.CreatedByUserID = clsUserSession.CurrentUser.UserID;
                


                if (_Cart.Save())
                    return true;
                else
                    return false;
            }
            else // Active cart does exists
                return true;
        }
        private bool _CancelSelectedItemQuantity(int ItemID , int Quantity)
        {
            if(_ItemControls.TryGetValue(ItemID,out var ctrl))
            {
                ctrl.CancelSelectedItemQuantity(Quantity);

                return true;
            }

            return false;
        }
        private void ItemControl_OnAddToCartClick(object sender, GCMS_Infrastructure.clsStoreItemSelectedEventArgs e)
        {
            //check if there is an active cart or create on
            if(_ConfirmTheExistanceOftheActiveCart())
            {
                
                
                //here we will add the new cart item 
                clsCartItems NewCartItem = new clsCartItems();
                NewCartItem.CartID = _Cart.CartID;
                NewCartItem.ItemID = e.ItemID;
                NewCartItem.Quantity = e.SelectedQuantity;
               
                if(NewCartItem.Save())
                    MessageBox.Show("Item is added to the cart.", "Added to cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //preform the reverce logic to cnacel the quantity selection
                    if (_CancelSelectedItemQuantity(e.ItemID,e.SelectedQuantity))
                    {
                        MessageBox.Show("Failed to add item to cart!, selection is canceled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       
                        MessageBox.Show("Failed to add item to cart!, selection cancling failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                    

            }
            else
            {
                //preform the revers logic
                MessageBox.Show("Failed to create a new active cart,Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }




        //Using the created event in the categorylist control that returns the chosen Category to list all of it's items
        private void ctrlGategoriesList1_OnCategoryClickFromTheList(object sender, GCMS_Infrastructure.clsStoreCategoryEventArgs e)
        {
            //assign the category id to the flag 
            _CurrentCategoryID = e.CategoryID;
            //fill the fast object list view with items
            _FillThefolpItemsWithCategoryItems(e.CategoryID);
        }



                        //Cart Management button
        private void btnCart_Click(object sender, EventArgs e)
        {
            // if there is no open cart open the cart from in empty mode else open the cart form with filled mode and subscribe to the event
            if (_Cart == null)
            {
                frmCart frm = new frmCart(0);
                frm.ShowDialog();
            }
            else
            {
                frmCart frm = new frmCart(_Cart.CartID);
                frm.OnCartItemChanged += Frm_OnCartItemChanged;
                frm.ShowDialog();
            }    
                
        }

        
        private void Frm_OnCartItemChanged(object sender, bool e)
        {
            _RefreshItemsfolv();
        }




                             // storee management
        private void btnStoreManagement_Click(object sender, EventArgs e)
        {
            if (clsUserSession.CurrentUser.Username == "Supervisor" || clsUserSession.CurrentUser.Username == "Admin")
            {
                frmStoreManagement frm = new frmStoreManagement();
                frm.FormClosing += Frm_StoreManagementFormClosing; //Subscribe to the form closing event to refresh the store items 
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denied! Please Contact Your Supervisor Or Admin.", "access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Frm_StoreManagementFormClosing(object sender, FormClosingEventArgs e)
        {
            _RefreshItemsfolv();
        }

        
    }
}
