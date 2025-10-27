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

namespace GCMS.Users
{
    public partial class frmAddNewUser : Form
    {
        private int _PersonID =0; //data memeber to hold the Selected PersonID

        public frmAddNewUser()
        {
            InitializeComponent();
        }



                                   //Person selection and cancling the selection
        //Select person button
        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmSelectPerson frm = new frmSelectPerson();
            frm.DataBack += PersonSelected_DataBack; //Register to the frmSelectPerson Event
            frm.ShowDialog();
        }
        //Cancel Selection button
        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            _PersonID = 0;
            lblSelectedPersonName.Text = "???";
        }
        //this method will be called after the Person selection
        private void PersonSelected_DataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;

            lblSelectedPersonName.Text = clsPeople.FindPerson(PersonID).FullName();
        }


        //Validate all required feilds
        private byte _ValidatePersonSelection()
        {
            byte ErrorCount = 0;

            if(_PersonID == 0)
            {
                errorProvider1.SetError(btnSelectPerson, "Person should be selected!");
                ErrorCount++;
            }
            else
               errorProvider1.SetError(btnSelectPerson,string.Empty);
           

            return ErrorCount;
           
        }
        private byte _ValidateUsername()
        {
            byte ErrorCount = 0;


            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username should not be empty!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (tbUsername.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(tbUsername, "Username should not be all in digits!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(30, tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username should not be more than 30 characters!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (clsUsers.IsUsernameExists(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username is not available!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);

                //Adding an error to the error provider
                ErrorCount = 0;
            }


            return ErrorCount;
        }
        private byte _ValidatePassword()
        {
            byte ErrorCount = 0;


            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Password should not be empty!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(30, tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Password should not be more than 64 characters!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);

                //Adding an error to the error provider
                ErrorCount = 0;
            }



            return ErrorCount;
        }
        private byte _ValidateUserRole()
        {
            byte ErrorCount = 0;

            if(rbUser.Checked ==false && rbAdmin.Checked==false && rbSupervisor.Checked ==false)
            {
                errorProvider1.SetError(pnlUserRole, "Select a the user role!");
                ErrorCount++;

            }
            else
                errorProvider1.SetError(pnlUserRole, string.Empty);

            return ErrorCount;

        }

        private bool _IsInputValid()
        {
            byte ErrorCounter = 0;

            ErrorCounter += _ValidatePersonSelection();
            ErrorCounter += _ValidateUsername();
            ErrorCounter += _ValidatePassword();
            ErrorCounter += _ValidateUserRole();

            return (ErrorCounter == 0);
        }


        //this method used to close the interaction with the form after the user is add
        private void _CloseFormInteraction()
        {
            btnSelectPerson.Enabled = false;
            btnCancelSelection.Enabled = false;
            btnAddNewUser.Enabled = false;
            pnlUserRole.Enabled = false;
            tbUsername.Enabled = false;
            tbPassword.Enabled = false;
        }



        //private method to add the user to the database
        private bool _AddNewUser()
        {
            clsUsers User = new clsUsers();

            User.PersonID = _PersonID;
            User.Username = tbUsername.Text;
            User.Password = clsEncryptionHelper.ComputeHash(tbPassword.Text);

            if (rbUser.Checked)
                User.Role = "User";
            else if (rbAdmin.Checked)
                User.Role = "Admin";
            else
                User.Role = "Supervisor";

            User.IsActive = true;


            if(User.Save())
            {
                lblNewUserID.Text = User.UserID.ToString();

                _CloseFormInteraction();
                return true;
            }
            else
            {
                return false;
            }

        }



        //Button add new user
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if(_IsInputValid())
            {
                if(_AddNewUser())
                    MessageBox.Show("New user has been added.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to add new user", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Missing information, Please fill all the Information required!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
