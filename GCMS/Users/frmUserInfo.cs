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
    public partial class frmUserInfo : Form
    {
        //private 
        private clsUsers _User;
        //form won't be uesed unless their is a user object
        public frmUserInfo(clsUsers User)
        {
            InitializeComponent();
            
            this._User = User;

            ctrlUserCard1.loadUserInfo(User);
        }

        private void btnUpdateLoginInfo_Click(object sender, EventArgs e)
        {
            frmUpdateLoginInfo frm = new frmUpdateLoginInfo(_User);
            frm.ShowDialog();

            //Update the  _User in this form incase the user did update the user info
            _User = clsUserSession.CurrentUser;

            ctrlUserCard1.loadUserInfo(_User);
        }
    }
}
