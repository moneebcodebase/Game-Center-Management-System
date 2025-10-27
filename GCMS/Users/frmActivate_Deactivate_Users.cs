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

namespace GCMS.Users
{
    public partial class frmActivate_Deactivate_Users : Form
    {
        public enum enMode { Activate =0,Deactivate};


        private clsUsers _User;//will hold the user object
        private enMode _Mode;//will represent the form mode


        public frmActivate_Deactivate_Users(int UserID,enMode Mode)
        {
            InitializeComponent();

            _User = clsUsers.FindUser(UserID);//getting the User object
            _Mode = Mode; //Getting the form mode
        }


        
        private void frmActivate_Deactivate_Usercs_Load(object sender, EventArgs e)
        {
            //load the user object into the control
            ctrlUserCard1.loadUserInfo(_User);

            
            if(_Mode ==enMode.Activate)
            {
                this.Text = "Activate User";
                btnActivate_Dectivate_lable.Text ="Activate User";
                btnActivate_Deactivate.Text = "Activate";
            }
            else
            {
                this.Text = "Deactivate User";
                btnActivate_Dectivate_lable.Text = "Deactivate User";
                btnActivate_Deactivate.Text = "Deactivate";
            }
        }


        
        private void btnActivate_Deactivate_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Activate)
            {
                //check if the user selected is the current user session
                if(_User ==clsUserSession.CurrentUser)
                {
                    MessageBox.Show("Can't activate or deactivate this user.\nThe user is in use.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //check if the user is already active
                if (_User.IsActive)
                {
                    MessageBox.Show("The User is already active.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Activate the user
                if(clsUsers.ActivateUser(_User.UserID))
                {
                    _User.IsActive = true;
                    btnActivate_Deactivate.Enabled = false;
                    ctrlUserCard1.loadUserInfo(_User);
                    MessageBox.Show("User is activated", "Activated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                   
            }
            else
            {
                //check if the user selected is the current user session
                if (_User == clsUserSession.CurrentUser)
                {
                    MessageBox.Show("Can't activate or deactivate this user.\nThe user is in use.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //check if the user is already deactive
                if (_User.IsActive ==false)
                {
                    MessageBox.Show("The User is already deactive.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Deactivate the user
                if (clsUsers.DeactivateUser(_User.UserID))
                {
                    _User.IsActive = false;
                    btnActivate_Deactivate.Enabled = false;
                    ctrlUserCard1.loadUserInfo(_User);
                    MessageBox.Show("User is deactivated", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }
    }
}
