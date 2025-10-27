using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.User_Control
{
    public partial class ctrlGategoriesList : UserControl
    {


        //public event to return the category information

        public event EventHandler<clsStoreCategoryEventArgs> OnCategoryClickFromTheList;
        //raising the event on category clicked 
        public void RaiseOnCategoryClickedFromTheList(int CategoryID, string Name)
        {
            RaiseOnCategoryClickedFromTheList(new clsStoreCategoryEventArgs(CategoryID, Name));
        }
        protected void RaiseOnCategoryClickedFromTheList(clsStoreCategoryEventArgs e)
        {
            OnCategoryClickFromTheList?.Invoke(this, e);
        }


        //Constructor
        public ctrlGategoriesList()
        {
            InitializeComponent();
        }





        //Method to fill the Category List
        private async void _FillTheCategoriesList()
        {
            flpCategoriesList.Controls.Clear(); // Clear old controls

            //getting all pool games list
            List<clsStoreCategories> CategoriesLlist = clsStoreCategories.GetGategoriesList();

            if (CategoriesLlist != null)
            {
                flpCategoriesList.Visible = true;
                btnNoCategories.Visible = false;


                foreach (var Category in CategoriesLlist)
                {
                    ctrlCategoryItem CategoryItem = new ctrlCategoryItem(Category);
                    CategoryItem.Margin = new Padding(0); // space between controls
                    CategoryItem.OnCategoryClick += CategoryItem_OnCategoryClick;//Subscribe to the control event
                    flpCategoriesList.Controls.Add(CategoryItem);


                    // Allow the UI to repaint and delay for animation effect
                    await Task.Delay(80);

                }
            }
            else
            {
                //Hide the categorylist flow layout panel and show the no categories button message
                flpCategoriesList.Visible = false;
                btnNoCategories.Visible = true;
            }

        }

        private void CategoryItem_OnCategoryClick(object sender, GCMS_Infrastructure.clsStoreCategoryEventArgs e)
        {
            //Here we will raise the Category list event that will send to the main form the category that has been selected
            RaiseOnCategoryClickedFromTheList(e.CategoryID, e.Name);

        }





        //this method to prevent the conflict that happend in the desigen time
        //to prevent the control fron trying to load real data while in run time
        private bool _IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }



        //on the load of the CategoriesList control
        private void ctrlGategoriesList_Load(object sender, EventArgs e)
        {
            if (_IsInDesignMode())
                return;

            _FillTheCategoriesList();
        }
    }
}
