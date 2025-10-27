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

namespace GCMS.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }



        //Related to UI

        //This event is used to control the status strip text when hovering into the username textbox
        private void tbUsername_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Enter Your Username ...";
        }

        //This event is used to control the status strip text when entering(Set Focus) into the username textbox
        private void tbUsername_Enter(object sender, EventArgs e)
        {
            SSTLabel.Text = "Enter Your Username ...";
        }
        //This event is used to control the status strip text when hovering into the Password textbox
        private void tbPassword_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Enter Your Correct Password ...";
        }
        //This event is used to control the status strip text when entering(Set Focus) into the password textbox
        private void tbPassword_Enter(object sender, EventArgs e)
        {
            SSTLabel.Text = "Enter Your Correct Password ...";
        }
        //This event is used to control the status strip text when hovering into the form
        private void frmLoginScreen_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }
        //This event is used to control the status strip text when hovering into the panal
        private void panel1_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "© 2025 moneebcodebase.";
        }
        //This event is used to control the status strip text when hovering into the login button
        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Click to login.";
        }
        //This event is used to control the status strip text when entering(Set Focus) into the login button
        private void btnLogin_Enter(object sender, EventArgs e)
        {
            SSTLabel.Text = "Click to login.";
        }
        //This event is used to control the status strip text when hovering into the remember me checkbox
        private void chkRemeberMe_MouseHover(object sender, EventArgs e)
        {
            SSTLabel.Text = "Do you want to save your login info?";
        }
        //This event is used to control the status strip text when entering(Set Focus) into the  remeber me check box
        private void chkRememberMe_Enter(object sender, EventArgs e)
        {
            SSTLabel.Text = "Do you want to save your login info?";
        }





        //Event used to load login data to the form 
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            //Filling the login information  from windows credentials
            var( Username,Password) = clsCredentialHelper.GetCredential();

            //Filling the credentials feilds 
            if(Username != null)
            {
                tbUsername.Text = Username.ToString();
                tbPassword.Text = Password.ToString();
                chkRememberMe.Checked = true;
            }
            else
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                chkRememberMe.Checked = false;
            }
        }


        //To check if one of the login credentials is missing
        private  bool IsCredentialsEmpty()
        {
            return ((tbUsername.Text == "") || (tbPassword.Text == ""));    
        }

        //Login to the system
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Return if one of the login credentials is missing
            if (IsCredentialsEmpty())
            {
                MessageBox.Show("Please fill all the required feileds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //Trasfering the Password into Hashed to copare it with the stored password
            string Password = clsEncryptionHelper.ComputeHash(tbPassword.Text.ToString());

            //load the user data from Database if exsits
            clsUsers User = clsUsers.FindUserByUsername_Password(tbUsername.Text.ToString(), Password);


            if(User == null)
            {
                MessageBox.Show("Invalid Information.Ckeck the password or username", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //check if the user not active to login to the system
            if(!User.IsActive)
            {
                MessageBox.Show("This account is not active. Please review your account status with your admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            
          
            //Load the user information into the current user to use it all over the program
            clsUserSession.CurrentUser = User;

            
            //Log the login info
            clsUsers.LogLoginInfo(clsUserSession.CurrentUser);

            //If remeber me check box is check then save the login credentials into the windows credential , else save empty login credentials
            if (chkRememberMe.Checked)
                clsCredentialHelper.SaveCredential(tbUsername.Text, tbPassword.Text);
            else
                clsCredentialHelper.SaveCredential("", "");

            this.DialogResult = DialogResult.OK;
            this.Close();

            
           
            
        }

       
    }
}
