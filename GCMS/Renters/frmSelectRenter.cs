using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Dynamic;
using GCMS_Business;
using GCMS.People;
using BrightIdeasSoftware; //fast object list view namespace

namespace GCMS.Renters
{
    public partial class frmSelectRenter : Form
    {
        //private data members
        private List<RenterViewModel> _AllRenters = new List<RenterViewModel>(); // Holds full list for filtering



        
        //Constructor
        public frmSelectRenter()
        {
            InitializeComponent();
        }


        

        //Declare a delegate
        public delegate void DataBackEventHandler(object sender,int RenterID);
        //declare an event using the delegate
        public event DataBackEventHandler DataBack;




        //This method convert the Renters DataTable into RenterViewModel list Using the RenterViewModel Class
        private List<RenterViewModel> ConvertDataTableToRenters(DataTable dtRenter)
        {
            List<RenterViewModel> renters = new List<RenterViewModel>();

            foreach (DataRow row in dtRenter.Rows)
            {
                renters.Add(new RenterViewModel
                {
                    RenterID = Convert.ToInt32(row["RenterID"]),
                    FullName = row["FullName"].ToString(),
                    NationalNO = row["NationalNO"].ToString(),
                    Status = row["Status"].ToString()
                });
            }

            return renters;
        }

        //this method is used to fill the fast object list view with data
        private void FillTheFastObjectListViewWithData()
        {
            DataTable dtRentersList = clsRenters.GetRentersList();
            _AllRenters = ConvertDataTableToRenters(dtRentersList);

            //bind to FastObjectListView
            folvRentersList.Clear();
            folvRentersList.Columns.Clear();
            folvRentersList.View = View.Details;
            folvRentersList.FullRowSelect = true;
            folvRentersList.UseAlternatingBackColors = true;
            folvRentersList.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvRentersList.Columns.Add(new OLVColumn("ID", "RenterID") { Width = 80 });
            folvRentersList.Columns.Add(new OLVColumn("Name", "FullName") { Width = 285 });
            folvRentersList.Columns.Add(new OLVColumn("National NO", "NationalNO") { Width = 150 });
            folvRentersList.Columns.Add(new OLVColumn("Status", "Status") { Width = 100 });

            //changing the  alternating row color 
            folvRentersList.UseAlternatingBackColors = true;
            folvRentersList.BackColor = Color.White; // Even rows
            folvRentersList.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvRentersList.SetObjects(_AllRenters);

        }

        //filling the form with the list on form load
        private void frmSelectRenter_Load(object sender, EventArgs e)
        {
            FillTheFastObjectListViewWithData();

        }




        //Search filtering 
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvRentersList.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvRentersList.ModelFilter = new ModelFilter(model =>
                {
                    var renter = model as RenterViewModel;
                    if (renter == null) return false;

                    return renter.FullName.ToLower().Contains(searchText)
                        || renter.NationalNO.ToLower().Contains(searchText)
                        || renter.Status.ToLower().Contains(searchText)
                        || renter.RenterID.ToString().Contains(searchText);
                });
            }

            folvRentersList.Refresh();
        }



        //Button Select used to select a renter
        private void btnSelectRenter_Click(object sender, EventArgs e)
        {
            // Get selected item from the FastObjectListView
            if (folvRentersList.SelectedObject is RenterViewModel selectedRenter)
            {
                int RenterID = selectedRenter.RenterID;

                //disable the form contorls 
                folvRentersList.Enabled = false;
                tbSearch.Enabled = false;
                btnSelectRenter.Enabled = false;
                btnAddRenter.Enabled = false;

                //Invoke data to subscripers
                DataBack?.Invoke(this, RenterID);

                DialogResult Result = MessageBox.Show($"Renter with ID [ {RenterID} ] is selected.\n\n" +
                     $"Do you want to close this screen?", "Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                if (Result == DialogResult.Yes)
                     this.Close();


            }
            else
            {
                MessageBox.Show("Please select a row first.","Select Renter",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void folvRentersList_DoubleClick(object sender, EventArgs e)
        {
            btnSelectRenter.PerformClick();
        }


        //button close the screen
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnSelectRenter.Enabled == true)
                MessageBox.Show($"Can't close this screen without selecting a renter.\nPlease select a renter!", "Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                this.Close();
        }
        //button add new renter 
        private void btnAddRenter_Click(object sender, EventArgs e)
        {
            //Open the add new renter screen
            frmAddNewRenter frm = new frmAddNewRenter();
            frm.ShowDialog();

            //refreshing the renters list
            FillTheFastObjectListViewWithData();
        }

       
    }

    //This class will work as a container that represents a  row of GetRentersList (of a renter data)
    public class RenterViewModel
    {
        public int RenterID { get; set; }
        public string FullName { get; set; }
        public string NationalNO { get; set; }
        public string Status { get; set; } // e.g., "Active" or "Banned"
    }


}
