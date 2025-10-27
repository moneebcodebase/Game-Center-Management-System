using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.Store
{
    public partial class frmStoreManagement : Form
    {
        //Private data memebers used in this form
        private List<clsStoreCategories> _StoreCategoriesList;
        private List<clsStoreItems> _StoreItemsList;
        private int _CurrentCategory; //keep track of the current category 
        public frmStoreManagement()
        {
            InitializeComponent();
        }


 
                                 //Status strip
        private void pnlDashborad_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Store management.";
        }

        private void btnManageCategories_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Click to manage categories.";
        }

        private void btnManageItems_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Click to manage items.";
        }

        private void cbCategories_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Select category to list it's items.";
        }

        private void gbAddStoreItem_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Fill new item information.";
        }

        private void folvStoreItems_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "VIEW, EDIT AND DELETE ITEMS.";
        }

        private void tabItems_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Manage Store items.";
        }

        private void tabCategories_MouseHover(object sender, EventArgs e)
        {
            sstLabel.Text = "Manage Store Categories.";
        }





        //Categories list, Edit and add
        private void _SetupCateogriessfolv()
        {
            //prepare the columns
            folvCategories.FullRowSelect = true;
            folvCategories.UseAlternatingBackColors = true;
            folvCategories.BackColor = Color.White; // Even rows
            folvCategories.AlternateRowBackColor = Color.White; // Odd rows
            folvCategories.ShowGroups = false;
            folvCategories.Columns.Clear();

            // Create and configure the Id column (read-only)
            OLVColumn idColumn = new OLVColumn("ID", "CategoryID");
            idColumn.IsEditable = false; // Prevent editing

            // Create and configure the Name column (editable)
            OLVColumn nameColumn = new OLVColumn("Name", "CategoryName"){ Width=150};
            nameColumn.IsEditable = true; // Enable editing

            // Add columns to the list view
            folvCategories.Columns.Add(idColumn);
            folvCategories.Columns.Add(nameColumn);

            // Allow editing when double-clicking a cell
            folvCategories.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;

        }
        private void _LoadCategories()
        {
            _StoreCategoriesList = clsStoreCategories.GetGategoriesList();
            folvCategories.SetObjects(_StoreCategoriesList);
        }
        private bool _ValidateCategoyName(string CategoryNewName, clsStoreCategories EditedCategory=null)
        {
            //Validate the category name
            if(clsValidationHelper.IsEmptyOrWhiteSpaces(CategoryNewName))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(clsValidationHelper.ContainsNumber(CategoryNewName))
            {
                MessageBox.Show("Category Name cannot contain numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(!clsValidationHelper.IsValidCharacterRange(30,CategoryNewName))
            {
                MessageBox.Show("Category Name cannot contain more than 30 character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (clsValidationHelper.ContainsSymbols(CategoryNewName))
            {
                MessageBox.Show("Category Name cannot contain Symbols other than _ .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            
            //check if the category name dose exists for both add new or update
            if(EditedCategory != null)
            {
                bool CategoryNameExists = _StoreCategoriesList.Any(cat => cat != EditedCategory &&
                string.Equals(cat.CategoryName, CategoryNewName, StringComparison.OrdinalIgnoreCase));
                if (CategoryNameExists)
                {
                    MessageBox.Show("Category Name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                bool CategoryNameExists= _StoreCategoriesList.Any(cat =>
                         string.Equals(cat.CategoryName, CategoryNewName, StringComparison.OrdinalIgnoreCase));

                if (CategoryNameExists)
                {
                    MessageBox.Show("Category Name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
                        

            return true;
        }
        private void folvCategories_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "Name")
            {
                // cast the raw object to the store category object
                clsStoreCategories editedCategory = (clsStoreCategories)e.RowObject;

                //Get the new name
                string CategoryNewName = e.NewValue?.ToString();

                //validation
                if (!_ValidateCategoyName(CategoryNewName, editedCategory))
                {

                    e.Cancel = true; // Cancel the edit

                    //revert the original name
                   
                    e.Control.Text = editedCategory.CategoryName;


                    return;
                }

                // Update the Name property
                editedCategory.CategoryName = CategoryNewName;

                //save changes
                if(editedCategory.Save())
                {
                    MessageBox.Show("Category gas been updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //update the combo box that is used in the item managment
                    _FillComboBoxWithCategories();
                } 
                else
                    MessageBox.Show("Failed to update category", "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if(_ValidateCategoyName(tbCateogryName.Text))
            {
                clsStoreCategories NewStoreCategory = new clsStoreCategories();
                NewStoreCategory.CategoryName=tbCateogryName.Text;

                if(NewStoreCategory.Save())
                {
                    MessageBox.Show("New category has been added.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //update the list by adding the new category to it and refresh the fast objec list view
                    _StoreCategoriesList.Add(NewStoreCategory);
                    folvCategories.SetObjects(_StoreCategoriesList);

                    //update the categories in the combo box used in the item managment
                    _FillComboBoxWithCategories();
                }
                else
                    MessageBox.Show("Coudn't add new category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //Items list , edit and add
        private void _FillComboBoxWithCategories()
        {
            // Temporarily detach the event handler to prevent the event from fireing up when setting the data source
            cbCategories.SelectedIndexChanged -= cbCategories_SelectedIndexChanged;

            cbCategories.DataSource = _StoreCategoriesList;
            cbCategories.DisplayMember = "CategoryName";
            cbCategories.ValueMember = "CategoryID";

            cbCategories.SelectedIndex = 0;
            

            //Re-attech the event 
            cbCategories.SelectedIndexChanged += cbCategories_SelectedIndexChanged;

        }
        private void _LoadAllStoreItems()
        {
            _StoreItemsList = clsStoreItems.GetStoreItemsList();
        }
        private void _SetupStoreItemsfolv()
        {
            //prepare the columns
            folvStoreItems.FullRowSelect = true;
            folvStoreItems.UseAlternatingBackColors = true;
            folvStoreItems.BackColor = Color.White; // Even rows
            folvStoreItems.AlternateRowBackColor = Color.LightGray; // Odd rows
            folvStoreItems.ShowGroups = false;
            folvStoreItems.Columns.Clear();

            // Create and configure the Id column (read-only)
            OLVColumn ItemIDColumn = new OLVColumn("Item ID", "ItemID");
            ItemIDColumn.IsEditable = false; // Prevent editing

            // Create and configure the Category id column (editable)
            OLVColumn CategoryIDColumn = new OLVColumn("Category ID", "CategoryID");
            CategoryIDColumn.IsEditable = false; // Enable editing

            // Create and configure the Item Name column (editable)
            OLVColumn ItemNameColumn = new OLVColumn("Name", "ItemName") { Width=150};
            ItemNameColumn.IsEditable = false; // Enable editing

            // Create and configure the Price column (editable)
            OLVColumn PriceColumn = new OLVColumn("Price", "Price") { Width=80};
            PriceColumn.IsEditable = false; // Enable editing

            // Create and configure the quantity column (editable)
            OLVColumn QuantityColumn = new OLVColumn("Qnt", "Quantity") { Width = 80};
            QuantityColumn.IsEditable = false; // Enable editing

            // Create and configure the Image column (editable)
            OLVColumn ItemImagePathColumn = new OLVColumn("Image", "ItemImagePath") { Width=200};
            ItemImagePathColumn.IsEditable = false; // Enable editing

            // Add columns to the list view
            folvStoreItems.Columns.Add(ItemIDColumn);
            folvStoreItems.Columns.Add(CategoryIDColumn);
            folvStoreItems.Columns.Add(ItemNameColumn);
            folvStoreItems.Columns.Add(PriceColumn);
            folvStoreItems.Columns.Add(QuantityColumn);
            folvStoreItems.Columns.Add(ItemImagePathColumn);

            // Allow editing when double-clicking a cell
            folvStoreItems.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
        }
        private void _FillStoreItemsfolv(int CategoryID)
        {
            //Filter all the sotre items
            List<clsStoreItems>filteredItems = _StoreItemsList.Where(item => item.CategoryID == CategoryID).ToList();
            
            folvStoreItems.SetObjects(filteredItems);
        }
        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedCategoryID = Convert.ToInt32(cbCategories.SelectedValue);

            
            _FillStoreItemsfolv(SelectedCategoryID);

        }
        private bool _IsItemInfoValid()
        {
            //Validate the Item name
            if(string.IsNullOrEmpty(tbItemName.Text))
            {
                MessageBox.Show("Item Name is empty, Please fill the item Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(clsValidationHelper.ContainsNumber(tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot contain numbers, Please remove any numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (clsValidationHelper.ContainsSymbols(tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot contain symbols other than _, Please remove any symbols.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!clsValidationHelper.IsValidCharacterRange(30,tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot be more than 30 character, Please remove extra character", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validate the item price

            if(nudPrice.Value == 0)
            {
                MessageBox.Show("Item price shoud be set", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validate the quantity
            if(nudQunatity.Value ==0)
            {
                MessageBox.Show("Item  quantity should be set", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        private bool _SelectandLoadItemImage()
        {

            using (OpenFileDialog OpenfileDialog = new OpenFileDialog())
            {
                OpenfileDialog.Title = "Choose item image";
                OpenfileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
                OpenfileDialog.Multiselect = false;

                if (OpenfileDialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectedImagePath = OpenfileDialog.FileName;
                    lblImagePath.Visible = true;
                    lblImagePath.Text = SelectedImagePath;

                    // Dispose existing image if there is one
                    if (pbImage.Image != null)
                    {
                        pbImage.Image.Dispose();
                        pbImage.Image = null;
                    }


                    try
                    {
                        if (File.Exists(SelectedImagePath))
                        {
                            // Load the image into memory to avoid file lock
                            using (var fs = new FileStream(SelectedImagePath, FileMode.Open, FileAccess.Read))
                            {
                                using (var ms = new MemoryStream())
                                {
                                    fs.CopyTo(ms);
                                    ms.Position = 0;
                                    pbImage.Image = Image.FromStream(ms);
                                }
                            }

                            btnCancelSelection.Visible = true;
                            return true;
                        }
                        else
                        {
                            // Image path not found - load default image from resources
                            pbImage.Image = Properties.Resources.StoreItme_256;

                            lblImagePath.Text = "";
                            lblImagePath.Visible = false;
                            btnCancelSelection.Visible = false;
                            return false;
                        }
                    }
                    catch
                    {
                        // In case of any other error, also load the default image
                        pbImage.Image = Properties.Resources.StoreItme_256;
                        lblImagePath.Text = "";
                        lblImagePath.Visible = false;
                        btnCancelSelection.Visible = false;
                        return false;
                    }
                }
            }


            return false;

        }
        private void _CancelImageSelection()
        {
            // Dispose existing image if there is one
            if (pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.Image = null;
                pbImage.Image = Properties.Resources.StoreItme_256;

                lblImagePath.Text = "";
                lblImagePath.Visible = false;
                btnCancelSelection.Visible = false;
            }
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (!_SelectandLoadItemImage())
                MessageBox.Show("Failed to load image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            _CancelImageSelection();
        }
        private void btnAddNewItem_Click(object sender, EventArgs e)
        {

            if (_IsItemInfoValid())
            {
                clsStoreItems NewItem = new clsStoreItems();
                NewItem.CategoryID = (int)cbCategories.SelectedValue;
                NewItem.ItemName = tbItemName.Text;
                NewItem.Price = nudPrice.Value;
                NewItem.Quantity = Convert.ToInt32(nudQunatity.Value);

                if (lblImagePath.Text == "???" || lblImagePath.Text == "")
                {
                    NewItem.ItemImagePath = "";
                }
                else
                {
                    string appPath = Application.StartupPath;
                    string projectRoot = Directory.GetParent(appPath).Parent.Parent.FullName;
                    string ImagesFolder = Path.Combine(projectRoot, "Items_Images");

                    string NewPath = clsFileHelper.CopyImageToFolder(lblImagePath.Text,ImagesFolder);

                    NewItem.ItemImagePath = NewPath;

                }

                //Saving the new item
                if(NewItem.Save())
                {
                    MessageBox.Show("New Item has been added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //refresh the fast object list view
                    _StoreItemsList.Add(NewItem);
                    _FillStoreItemsfolv(NewItem.CategoryID);
                }
                else
                {
                    //delete the image from the folder
                    clsFileHelper.DeleteImageFromFolder(NewItem.ItemImagePath);
                    MessageBox.Show("Failed to add the new item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("couldn't add new item to the store.", "Opreation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





        //On Form load
        private void frmStoreManagement_Load(object sender, EventArgs e)
        {
            //Categories
            _SetupCateogriessfolv();
            _LoadCategories();

            //Items
            _LoadAllStoreItems();
            _FillComboBoxWithCategories();
            _SetupStoreItemsfolv();
            
        }

        private void folvStoreItems_DoubleClick(object sender, EventArgs e)
        {
            // Get mouse position relative to the control
            Point mousePos = folvStoreItems.PointToClient(Cursor.Position);

            // Use hit test to determine where the user clicked
            var hitTest = folvStoreItems.OlvHitTest(mousePos.X,mousePos.Y);

            // Only proceed if a row (item) was double-clicked
            if (hitTest.Item != null && hitTest.RowObject is clsStoreItems clickedItem)
            {
                _CurrentCategory = clickedItem.CategoryID;

                frmUpdateStoreItem frm = new frmUpdateStoreItem(clickedItem.ItemID);
                frm.OnStoreItemChanged += Frm_OnStoreItemChanged;
                frm.ShowDialog();
            }
            
        }

        private void Frm_OnStoreItemChanged(object sender, bool e)
        {

            _LoadAllStoreItems();
            _FillStoreItemsfolv(_CurrentCategory);
        }



        //buttons to navigate through the taps
        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            tabStoreManagement.SelectedIndex = 1;
        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {
            tabStoreManagement.SelectedIndex = 0;
        }
    }
}
