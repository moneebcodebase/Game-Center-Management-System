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

namespace GCMS.People
{
    public partial class frmSelectPerson : Form
    {
        //private data members
        private List<PersonViewModel> _AllPersons = new List<PersonViewModel>(); // Holds full list for filtering


        //Constructor
        public frmSelectPerson()
        {
            InitializeComponent();
        }


        //Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);
        //declare an event using the delegate
        public event DataBackEventHandler DataBack;


        //This method convert the People DataTable into PersonViewModel list Using the PersonViewModel Class
        private List<PersonViewModel> ConvertDataTableToPeople(DataTable dtPeople)
        {
            List<PersonViewModel> renters = new List<PersonViewModel>();

            foreach (DataRow row in dtPeople.Rows)
            {
                renters.Add(new PersonViewModel
                {
                    PersonID = Convert.ToInt32(row["PersonID"]),
                    FullName = row["FullName"].ToString(),
                    PhoneNumber =row["PhoneNumber"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return renters;
        }

        //this method is used to fill the fast object list view with data
        private void FillTheFastObjectListViewWithData()
        {
            DataTable dtPeopleList = clsPeople.GetPeopleList();
            _AllPersons = ConvertDataTableToPeople(dtPeopleList);

            //bind to FastObjectListView
            folvPeopleList.Clear();
            folvPeopleList.Columns.Clear();
            folvPeopleList.View = View.Details;
            folvPeopleList.FullRowSelect = true;
            folvPeopleList.UseAlternatingBackColors = true;
            folvPeopleList.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvPeopleList.Columns.Add(new OLVColumn("ID", "PersonID") { Width = 65 });
            folvPeopleList.Columns.Add(new OLVColumn("Name", "FullName") { Width = 280 });
            folvPeopleList.Columns.Add(new OLVColumn("Phone", "PhoneNumber") { Width = 90 });
            folvPeopleList.Columns.Add(new OLVColumn("Email", "Email") { Width = 175 });

            //changing the  alternating row color 
            folvPeopleList.UseAlternatingBackColors = true;
            folvPeopleList.BackColor = Color.White; // Even rows
            folvPeopleList.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvPeopleList.SetObjects(_AllPersons);

        }
        //Filling the list with data on form load
        private void frmSelectPerson_Load(object sender, EventArgs e)
        {
            FillTheFastObjectListViewWithData();
        }

        //List Filtering using the textbox textchanged event
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvPeopleList.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvPeopleList.ModelFilter = new ModelFilter(model =>
                {
                    var Person = model as PersonViewModel;
                    if (Person == null) return false;

                    return Person.FullName.ToLower().Contains(searchText)
                        || Person.PersonID.ToString().Contains(searchText)
                        || Person.PhoneNumber.ToLower().Contains(searchText)
                        || Person.Email.ToString().Contains(searchText);
                });
            }

            folvPeopleList.Refresh();
        }


        //select button used to select person ID
        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            // Get selected item from the FastObjectListView
            if (folvPeopleList.SelectedObject is PersonViewModel selectedPerson)
            {
                int PersonID = selectedPerson.PersonID;

                //disable the form contorls 
                folvPeopleList.Enabled = false;
                tbSearch.Enabled = false;
                btnSelectPerson.Enabled = false;
                btnAddPerson.Enabled = false;

                //Invoke data to subscribers
                DataBack?.Invoke(this, PersonID);

                DialogResult Result = MessageBox.Show($"Person with ID [ {PersonID} ] is selected.\n\n" +
                     $"Do you want to close this screen?", "Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (Result == DialogResult.Yes)
                    this.Close();


            }
            else
            {
                MessageBox.Show("Please select a row first.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Preform as the select button
        private void folvPeopleList_DoubleClick(object sender, EventArgs e)
        {
            btnSelectPerson.PerformClick();
        }



        //Button close screen
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnSelectPerson.Enabled == true)
                MessageBox.Show($"Can't close this screen without selecting a person.\nPlease select a Person!", "Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
           
            //Calling the add new person screen
            frmAddNewPerson frm = new frmAddNewPerson();
            frm.ShowDialog();

            //Refreshing the list 
            FillTheFastObjectListViewWithData();
        }
    }


    //This class will work as a container that represents a  row of GetPeopleList (a Person data)
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } // e.g., "Active" or "Banned"
    }

}
