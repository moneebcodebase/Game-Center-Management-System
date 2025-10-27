using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS.People;
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.Renters
{
    public partial class frmAddNewRenter : Form
    {

        private int _SelectedPersonID =0; // this will hold the selected person ID

        public frmAddNewRenter()
        {
            InitializeComponent();
        }


        //Button close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Button Select a person
        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            //Calling the select perosn form and return the selected personID
            frmSelectPerson frm = new frmSelectPerson();
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();
        }

        //this method will handle the data that returns after the selection of a person
        private void Frm_DataBack(object sender, int PersonID)
        {
            _SelectedPersonID = PersonID;
            lblSelectedPersonID.Text = PersonID.ToString();
            btnSelectPerson.Enabled = false;
        }

        //Button cancel person selection 
        //this will reset the Person selection
        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            _SelectedPersonID = 0;
            lblSelectedPersonID.Text = "???";
            btnSelectPerson.Enabled = true;
        }



        //Validate the person selection
        private byte _IsPersonSelected()
        {
            byte ErrorCount = 0;

            if(_SelectedPersonID ==0)
            {
                ErrorCount = 1;
                errorProvider1.SetError(btnSelectPerson, "You should select a person.");
            }
            else
            {
                ErrorCount = 0;
                errorProvider1.SetError(btnSelectPerson, string.Empty);
            }
               

            return ErrorCount;
        }
        //Validate the NationalN0
        private byte _IsValidNationalNo()
        {
            byte ErrorCounter = 0;

            if(clsRenters.IsNationalNoExists(tbNatinoalNo.Text))
            {
                ErrorCounter++;
                errorProvider1.SetError(tbNatinoalNo, "This national number is not available.");
            }
            else if(string.IsNullOrWhiteSpace(tbNatinoalNo.Text))
            {
                ErrorCounter++;
                errorProvider1.SetError(tbNatinoalNo, "NationalNo is empty.");
            }
            else if (!clsValidationHelper.IsValidCharacterRange(20, tbNatinoalNo.Text))
            {
                errorProvider1.SetError(tbNatinoalNo, "NationalNo can't be more than 20 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbNatinoalNo, string.Empty);

            return ErrorCounter;
        }

        private bool _IsInputValid()
        {
            byte ErrorCounter = 0;

            ErrorCounter += _IsPersonSelected();
            ErrorCounter += _IsValidNationalNo();

            return (ErrorCounter == 0);
        }

        //Button to add the renter
        private void btnAddNewRenter_Click(object sender, EventArgs e)
        {
            if(_IsInputValid())
            {
                clsRenters NewRenter  = new clsRenters();
                NewRenter.PersonID = _SelectedPersonID;
                NewRenter.NationalNo =tbNatinoalNo.Text.ToString();
                NewRenter.IsBand = false;

                if(NewRenter.Save())
                {
                    lblNewRenterID.Text = NewRenter.RenterID.ToString();
                    btnSelectPerson.Enabled = false;
                    btnCancelSelection.Enabled = false;
                    btnAddNewRenter.Enabled = false;
                    tbNatinoalNo.Enabled = false;

                    DialogResult Result =MessageBox.Show("New renter has been added.\nPress ok to close the screen", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(Result == DialogResult.OK)
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't add new renter.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalied renter info.","Invalid input",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
    }
}
