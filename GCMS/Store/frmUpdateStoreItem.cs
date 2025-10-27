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
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.Store
{
    public partial class frmUpdateStoreItem : Form
    {
        //private data members used in this form
        private int _ItemID;
        private clsStoreItems _StoreItem;
        private List<clsStoreCategories> _StoreCategoriesList;


        //public event to that notify the subscribers that there has been a change to the store items

       
        public event EventHandler<bool> OnStoreItemChanged;
        
        //raising the event 
        protected void RaiseOnStoreItemChanged(bool IsStoreItemChanged)
        {
            OnStoreItemChanged?.Invoke(this, IsStoreItemChanged);
        }



        public frmUpdateStoreItem(int ItemID)
        {
            InitializeComponent();
            _ItemID = ItemID;
        }



        private void _FillComboBoxWithCategories()
        {
            _StoreCategoriesList = clsStoreCategories.GetGategoriesList();
            cbCategories.DataSource = _StoreCategoriesList;
            cbCategories.DisplayMember = "CategoryName";
            cbCategories.ValueMember = "CategoryID";
        }
        private void _LoadItemImage(string ItemImagePath)
        {
            // Dispose existing image if there is one
            if (pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.Image = null;
            }


            try
            {
                if (File.Exists(ItemImagePath))
                {
                    // Load the image into memory to avoid file lock
                    using (var fs = new FileStream(ItemImagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;
                            pbImage.Image = Image.FromStream(ms);
                        }
                    }

                    btnCancelSelection.Visible = true;
                    lblImagePath.Visible = true;
                    lblImagePath.Text = ItemImagePath;

                }
                else
                {
                    // Image path not found - load default image from resources
                    pbImage.Image = Properties.Resources.StoreItme_256;

                    lblImagePath.Text = "";
                    lblImagePath.Visible = false;
                    btnCancelSelection.Visible = false;

                }
            }
            catch
            {
                // In case of any other error, also load the default image
                pbImage.Image = Properties.Resources.StoreItme_256;
                lblImagePath.Text = "";
                lblImagePath.Visible = false;
                btnCancelSelection.Visible = false;

            }
        }
        private void _FillFormWithItemData()
        {
            lblItemID.Text = _ItemID.ToString();
            _FillComboBoxWithCategories();
            cbCategories.SelectedValue = _StoreItem.CategoryID;
            tbItemName.Text = _StoreItem.ItemName;
            nudPrice.Value = _StoreItem.Price;
            nudQunatity.Value = _StoreItem.Quantity;

            if (_StoreItem.ItemImagePath != "" || _StoreItem.ItemImagePath != null)
            {
                _LoadItemImage(_StoreItem.ItemImagePath);
            }

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
        private bool _IsItemInfoValid()
        {
            //Validate the Item name
            if (string.IsNullOrEmpty(tbItemName.Text))
            {
                MessageBox.Show("Item Name is empty, Please fill the item Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (clsValidationHelper.ContainsNumber(tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot contain numbers, Please remove any numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (clsValidationHelper.ContainsSymbols(tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot contain symbols other than _, Please remove any symbols.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!clsValidationHelper.IsValidCharacterRange(30, tbItemName.Text))
            {
                MessageBox.Show("Item Name cannot be more than 30 character, Please remove extra character", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validate the item price

            if (nudPrice.Value == 0)
            {
                MessageBox.Show("Item price shoud be set", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validate the quantity
            if (nudQunatity.Value == 0)
            {
                MessageBox.Show("Item  quantity should be set", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        



        private void frmUpdateStoreItem_Load(object sender, EventArgs e)
        {
            _StoreItem = clsStoreItems.FindStoreItem(_ItemID);

            if(_StoreItem == null)
            {
                MessageBox.Show("Item Does Not Exists.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                _FillFormWithItemData();
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

        private void btnUpdateStoreItem_Click(object sender, EventArgs e)
        {
            if (_IsItemInfoValid())
            {
                //this holds the old image path to delete the old image if the opreation is done
                string OldImagePath = _StoreItem.ItemImagePath;


                _StoreItem.CategoryID = (int)cbCategories.SelectedValue;
                _StoreItem.ItemName = tbItemName.Text;
                _StoreItem.Price = nudPrice.Value;
                _StoreItem.Quantity = Convert.ToInt32(nudQunatity.Value);

                if (lblImagePath.Text == "???" || lblImagePath.Text == "")
                {
                    _StoreItem.ItemImagePath = "";
                }
                else
                {
                    

                    string appPath = Application.StartupPath;
                    string projectRoot = Directory.GetParent(appPath).Parent.Parent.FullName;
                    string ImagesFolder = Path.Combine(projectRoot, "Items_Images");

                    string NewPath = clsFileHelper.CopyImageToFolder(lblImagePath.Text, ImagesFolder);

                    _StoreItem.ItemImagePath = NewPath;

                }

                //Saving the new item
                if (_StoreItem.Save())
                {
                    //Delete the old image because the item got a new image now
                    if(OldImagePath != "" || OldImagePath != null)
                        clsFileHelper.DeleteImageFromFolder(OldImagePath);

                    RaiseOnStoreItemChanged(true);

                    MessageBox.Show("New Item has been added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //delete the new image because the opration falied and the old image remains
                    clsFileHelper.DeleteImageFromFolder(_StoreItem.ItemImagePath);
                    MessageBox.Show("Failed to add the new item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
                MessageBox.Show("couldn't add new item to the store.", "Opreation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
