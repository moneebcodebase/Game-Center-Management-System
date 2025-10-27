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
using BrightIdeasSoftware;

namespace GCMS.Store
{
    public partial class frmCart : Form
    {
        //DataMember that will hold the CartItems
        private enum enFormMode { Empty =0, Filled}
        private enFormMode _Mode;
        private List<CartItemsViewModel> _CartItemsList;
        private int _CartID;
        private bool _IsCartUpdated = false; //flag to determine whether the cart is updated or not


        public frmCart(int CartID)
        {
            InitializeComponent();
            _CartID = CartID;

            if(_CartID !=0)
                _Mode = enFormMode.Filled;
            else
                _Mode = enFormMode.Empty;
        }


        //public event to that notify the subscribers that there has been a change to the cart items

        public event EventHandler<bool> OnCartItemChanged;
        //raising the event 
        protected void RaiseOnCartItemChanged(bool IsCartItemChanged)
        {
            OnCartItemChanged?.Invoke(this, IsCartItemChanged);
        }
        



                                     // loading the cart items data 


        //private method to convert the datatable into List of cart items view model
        private List<CartItemsViewModel> _ConverntDataTablToCartItemsViewModel(DataTable dtCartItems)
        {
            List<CartItemsViewModel> CartItems = new List<CartItemsViewModel>();

            if (dtCartItems == null)
                MessageBox.Show("null");

            foreach (DataRow row in dtCartItems.Rows)
            {
                CartItems.Add(new CartItemsViewModel
                {
                    ID = Convert.ToInt32(row["ID"]),
                    CartID = Convert.ToInt32(row["Cart ID"]),
                    Category = row["Category"].ToString(),
                    Name = row["Name"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    PricePerUnit = Convert.ToInt32(row["Price Per Unit"]),
                    Total = Convert.ToInt32(row["Total"]),
                });
            }

            return CartItems;
        }

        //private method to load the cart  items list into the fast object list view
        private void _FillTheFastObjectListViewWithData()
        {
            DataTable dtCartItems = clsCartItems.GetCartItems(_CartID);
            _CartItemsList = _ConverntDataTablToCartItemsViewModel(dtCartItems);

            //bind the data to list
            folvCartItem.SetObjects(_CartItemsList);
        }

        //private method used to set up the fast object list view columns
        private void _SetupFastObjectListView()
        {
            folvCartItem.FullRowSelect = true;
            folvCartItem.UseAlternatingBackColors = true;
            folvCartItem.BackColor = Color.White; // Even rows
            folvCartItem.AlternateRowBackColor = Color.White; // Odd rows
            folvCartItem.ShowGroups = false;
            folvCartItem.Columns.Clear();


            //Enable hover effect for cells
            folvCartItem.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.Transparent, //renderer decides the hover color
                ForeColor = Color.Empty,

            };
            folvCartItem.UseHyperlinks = true;



            folvCartItem.Columns.Add(new OLVColumn("ID", "ID") { Width=50});
            folvCartItem.Columns.Add(new OLVColumn("Cart ID", "CartID") { Width=50});
            folvCartItem.Columns.Add(new OLVColumn("Category", "Category") { Width = 90 });
            folvCartItem.Columns.Add(new OLVColumn("Name", "Name") { Width = 90 });
            folvCartItem.Columns.Add(new OLVColumn("Qty", "Quantity"));
            folvCartItem.Columns.Add(new OLVColumn("Unit Price", "PricePerUnit"));
            folvCartItem.Columns.Add(new OLVColumn("Total", "Total") { Width = 70 });


            // "Remove" column
            var removeColumn = new OLVColumn("Action", "Remove");
            removeColumn.Width = 80;
            removeColumn.TextAlign = HorizontalAlignment.Center;
            removeColumn.Renderer = new FlatButtonRenderer();
            removeColumn.Hyperlink = true;
            folvCartItem.Columns.Add(removeColumn);
        }
        //On form load
        private void frmCart_Load(object sender, EventArgs e)
        {
            if(_Mode == enFormMode.Filled)
            {
                _SetupFastObjectListView();
                _FillTheFastObjectListViewWithData();
            }
            else
            {
                folvCartItem.Enabled = false;
                btnConfirm.Enabled = false;
            }
           
        }


                                   // Items reomoval from the cart

        private void _PreformRemvingCartItemOpreation(CartItemsViewModel CartItemObject)
        {
            clsCartItems CartItem = clsCartItems.FindCartItem(CartItemObject.ID);

            if (CartItem != null)
            {
                //preform the transaction opreation to remove the cart item 
                if (clsTransactoinsOperations.PreformRemoveItemFromCartItemsOpreation(CartItem.CartItemID, CartItem.ItemID, CartItem.Quantity))
                {
                    // Remove from the list
                    _CartItemsList.Remove(CartItemObject);

                    // Refresh the list
                    folvCartItem.SetObjects(_CartItemsList);

                    //change the flag to true to indicate that the cart has changed
                    _IsCartUpdated = true;

                    //Raising the event

                    RaiseOnCartItemChanged(_IsCartUpdated);
                }
                else
                {
                    MessageBox.Show("Opreation Failed coudn't remove item from cart.", "Opreation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Opreation Failed, Cart Item does not exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void folvCartItem_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column.Text == "Action" && e.Model is CartItemsViewModel CartItem)
            {
                var confirm = MessageBox.Show($"Remove '{CartItem.Name}' with ID '{CartItem.ID}' from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _PreformRemvingCartItemOpreation(CartItem);
                }
            }
        }


                                  //Confirm Cart Payment
        private void _ClosingForm()
        {
            folvCartItem.ClearObjects(); // clear the fast object list view
            btnConfirm.Enabled = false; 
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Get the total of all items
            decimal TotalPayment = _CartItemsList.Sum(item => item.Total);
            
            //call the store payment form
            frmStorePayment frm = new frmStorePayment(TotalPayment,_CartID);
            frm.OnPaymentCompleted += Frm_OnPaymentCompleted; //Subscribe to the event
            frm.ShowDialog();
        }

        private void Frm_OnPaymentCompleted(object sender, bool e)
        {
            if(e)
            {
                _ClosingForm();

                //change the flag to true to indicate that the cart has changed
                _IsCartUpdated = true;

                //Raising the event

                RaiseOnCartItemChanged(_IsCartUpdated);
            }
        }
    }


    //this class will represent the cart items view model
    public class CartItemsViewModel
    {
        public int ID { get; set; }
        public int CartID { get; set;}
        public string Category { get; set; }    
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Total { get; set; }

        // Simulated button text
        public string Remove => "Remove";
    }


    //this class to render the remove button inside the fast object list view
    public class FlatButtonRenderer : BaseRenderer
    {
        public override void Render(Graphics g, Rectangle r)
        {
            // Fill background with a red color
            using (Brush brush = new SolidBrush(Color.IndianRed))
            {
                g.FillRectangle(brush, r);
            }

            // Draw border around the cell
            using (Pen pen = new Pen(Color.Maroon))
            {
                g.DrawRectangle(pen, r);
            }

            // Draw "Remove" text centered
            using (StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("Remove", Font, textBrush, r, sf);
                }
            }
        }
    }
}
