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

namespace GCMS.User_Control
{
    public partial class ctrlUserCard : UserControl
    {
        //Data member to hold the user info inside the card
        private clsUsers _User;

        public ctrlUserCard()
        {
            InitializeComponent();
        }


        //this method used to fill the user card
        private void _FillUserInfo()
        {
            //filling the control with the user info

            lblUsername.Text = _User.Username;
            lblRole.Text = _User.Role;
            lblFullname.Text = _User.PersonInfo.FullName();
            lblEmail.Text = _User.PersonInfo.Email;
            lblPhone.Text = _User.PersonInfo.PhoneNumber;


            if (_User.IsActive == true)
            {
                lblIsActive.ForeColor = Color.LawnGreen;
                lblIsActive.Text = "Active";
            }
            else
            {
                lblIsActive.ForeColor = Color.Red;
                lblIsActive.Text = "Not Active";
            }

        }


        public void  loadUserInfo(clsUsers User)
        {
            this._User = User;

            _FillUserInfo();
        }

        
    }
}
