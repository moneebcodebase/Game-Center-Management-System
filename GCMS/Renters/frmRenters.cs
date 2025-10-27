using BrightIdeasSoftware;
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

namespace GCMS.Renters
{
    public partial class frmRenters : Form
    {
        //private data members
        private List<RenterViewModel> _AllRenters = new List<RenterViewModel>(); // Holds full list for filtering
        private clsRenters _Renter;
        private bool _IsRenterClicked = false;//this will track wheather the user clicked a record or not

        public frmRenters()
        {
            InitializeComponent();
        }


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

        private void frmRenters_Load(object sender, EventArgs e)
        {
            //hide the seconed tab (Renter info)
            TabRenters.TabPages.Remove(RenterInfoPage);
            //Fill the renters list
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


        //button add new renter
        private void btnAddRenter_Click(object sender, EventArgs e)
        {
            //Open the add new renter screen
            frmAddNewRenter frm = new frmAddNewRenter();
            frm.ShowDialog();

            //refreshing the renters list
            FillTheFastObjectListViewWithData();
        }



        //this will handle the selection of a renter and showing it's information
        private void _FillRenterInfo(int RenterID)
        {
            _Renter = clsRenters.FindRenter(RenterID);
            if(_Renter != null)
            {
                lblRenterID.Text = RenterID.ToString();
                lblRenterName.Text = _Renter.PersonInfo.FullName();
                lblNationalNo.Text = _Renter.NationalNo.ToString();
                lblEmail.Text = _Renter.PersonInfo.Email.ToString();
                lblPhoneNumber.Text = _Renter.PersonInfo.PhoneNumber.ToString();

                if (_Renter.IsBand)
                    rbBaned.Checked = true;
                else
                    rbNotBaned.Checked = true;


                //show the renter info page
                if(!_IsRenterClicked )
                {
                    TabRenters.TabPages.Add(RenterInfoPage);
                    //indcate that a click happened on a renter record to prevent the form from adding new pages
                    //(only allow adding this page once)
                    _IsRenterClicked = true;
                }
                       
                //move to that page
                TabRenters.SelectedTab = RenterInfoPage;
            }

        }
        private void folvRentersList_DoubleClick(object sender, EventArgs e)
        {
            // Get selected item from the FastObjectListView
            if (folvRentersList.SelectedObject is RenterViewModel selectedRenter)
            {

                _FillRenterInfo(selectedRenter.RenterID);
            }
            
        }

        private void UpdateStatus_Click(object sender, EventArgs e)
        {
            _Renter.IsBand = (rbBaned.Checked);

            if(_Renter.Save())
            {
                MessageBox.Show("Renter Sataus has been changed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Couldn't udpate renter sataus!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }


}
