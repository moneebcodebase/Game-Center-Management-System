using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Infrastructure;
using GCMS_Business;

namespace GCMS.Users
{
    public partial class frmUpdateLoginInfo : Form
    {
        private clsUsers _User;


        public frmUpdateLoginInfo(clsUsers User)
        {
            InitializeComponent();
            this._User = User;

        }


        //Status strip text handling
        private void frmEditUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Update user info.";
        }

        private void tbUsername_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Enter your new username.";
        }

        private void tbCurrentPassword_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Ebter your current password.";
        }

        private void tbNewPassword_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Enter your new password.";
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to confirm updates.";
        }

        private void pnlChoices_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Please select what you want to update.";
        }

        //Determines what the user wants to update
        private void chkUpdateUsername_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateUsername.Checked)
            {
                lblUsername.Visible = true;
                tbUsername.Visible = true;
            }
            else
            {
                lblUsername.Visible = false;
                tbUsername.Visible = false;
            }
        }

        private void chkUpdatePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdatePassword.Checked)
            {
                lblCurrentPassword.Visible = true;
                tbCurrentPassword.Visible = true;
                lblNewPassword.Visible = true;
                tbNewPassword.Visible = true;
            }
            else
            {
                lblCurrentPassword.Visible = false;
                tbCurrentPassword.Visible = false;
                lblNewPassword.Visible = false;
                tbNewPassword.Visible = false;
            }
        }



        //Validation 

        private byte _ValidateUsername()
        {
            byte ErrorCount = 0;


            if(string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                errorProvider1.SetError( tbUsername, "Username should not be empty!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if(tbUsername.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(tbUsername, "Username should not be all in digits!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if(!clsValidationHelper.IsValidCharacterRange(30,tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username should not be more than 30 characters!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if(clsUsers.IsUsernameExists(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username is not available!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);

                //Adding an error to the error provider
                ErrorCount =0;
            }



            return ErrorCount;
        }
        private byte _ValidateCurrentPassword()
        {
            byte ErrorCount = 0;


            if (string.IsNullOrWhiteSpace(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Current password should not be empty!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(64, tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Password should not be more than 64 characters!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (_User.Password != clsEncryptionHelper.ComputeHash(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Wrong password!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, string.Empty);

                //Adding an error to the error provider
                ErrorCount = 0;
            }



            return ErrorCount;
        }
        private byte _ValidateNewPassword()
        {
            byte ErrorCount = 0;


            if (string.IsNullOrWhiteSpace(tbNewPassword.Text))
            {
                errorProvider1.SetError(tbNewPassword, "New password should not be empty!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(30, tbNewPassword.Text))
            {
                errorProvider1.SetError(tbNewPassword, "Password should not be more than 64 characters!");

                //Adding an error to the error provider
                ErrorCount++;
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, string.Empty);

                //Adding an error to the error provider
                ErrorCount = 0;
            }



            return ErrorCount;
        }

        private bool _IsInputValid()
        {
            byte ErrorCounter = 0;

            if(chkUpdateUsername.Checked ==false && chkUpdatePassword.Checked ==false)
                ErrorCounter++;

            if(chkUpdateUsername.Checked)
                 ErrorCounter += _ValidateUsername();

            if(chkUpdatePassword.Checked)
            {
                ErrorCounter += _ValidateCurrentPassword();
                ErrorCounter += _ValidateNewPassword();
            }
           

            return (ErrorCounter == 0);
        }


        //Used when the update is done and now the user should close the form
        private void _ClosingForm()
        {
            tbUsername.Enabled = false;
            tbCurrentPassword.Enabled = false;
            tbNewPassword.Enabled = false;
            btnUpdate.Enabled = false;
            chkUpdateUsername.Enabled = false;
            chkUpdatePassword.Enabled = false;
        }



        //Button update user credentials 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //check if the all of the input is valid
            if(_IsInputValid())
            {

                if(chkUpdateUsername.Checked)
                   _User.Username =tbUsername.Text;

                if(chkUpdatePassword.Checked)
                   _User.Password =clsEncryptionHelper.ComputeHash(tbNewPassword.Text);

                if(_User.Save())
                {
                    //Update current user session 
                    clsUserSession.CurrentUser = _User;

                    _ClosingForm();
                    MessageBox.Show("Login info has been updatd.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid information, double check your input.", "Invalid info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

      
    }
}
