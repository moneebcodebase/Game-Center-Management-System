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
namespace GCMS.User_Control
{
    /// <summary>
    /// this control is to represent a category
    /// </summary>
    public partial class ctrlCategoryItem : UserControl
    {
                              //public event to return the category information

        public event EventHandler<clsStoreCategoryEventArgs> OnCategoryClick;
        //the event method that will be raised after the table game is completed
        public void RaiseOnCategoryClick(int CategoryID,string Name)
        {
            RaiseOnCategoryClick(new clsStoreCategoryEventArgs(CategoryID,Name));
        }
        protected void RaiseOnCategoryClick(clsStoreCategoryEventArgs e)
        {
            OnCategoryClick?.Invoke(this, e);
        }


        //Constructor to only allow calling this control with it's category
        public ctrlCategoryItem(clsStoreCategories Category)
        {
            InitializeComponent();

            //Filling the category information
            btnCategory.Text = Category.CategoryName;
            btnCategory.Tag = Category.CategoryID;


        }




        private void btnCategory_Click(object sender, EventArgs e)
        {
            //Raising the event whenever the category buttn is clicked
            RaiseOnCategoryClick((int)btnCategory.Tag, btnCategory.Text);
        }
    }
}
