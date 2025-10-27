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
using BrightIdeasSoftware;

namespace GCMS.Users
{
    public partial class frmUsersManagement : Form
    {
        //praivate data members used for paging
        private byte _CurrentPage = 1;
        private byte _PageSize =15; // setting the number or records in the page to 30
        private int _TotalPages;

        enum enMode { AllRecords ,Search};
        enMode _Mode;


        //private data members
        private List<UserViewModel> _AllUsers = new List<UserViewModel>(); // Holds full list for filtering
        private List<UserLoginLogViewModel> _AllUsersLoginLogs = new List<UserLoginLogViewModel>(); // Holds full list for filtering



        public frmUsersManagement()
        {
            InitializeComponent();
        }



                          //Status strip Note lable handling

        private void pnlDashboard_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Users management.";
        }

        private void btnAddNewUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to add new user.";
        }

        private void btnActivateUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to activate user.";
        }

        private void btnDeactivateUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to deactivate user.";
        }

        private void tbSearchforUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Search for a user.";
        }

        private void folvUsersList_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Users management list.";
        }

        private void btnAddUser_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to add new user";
        }

        private void tbSearchforLoginInfo_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Search for a login record.";
        }

        private void folvLoginLog_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Login log list.";
        }

        private void btnPrintLog_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = "Click to print the log.";
        }

        private void pnlCurrentUserInfo_MouseHover(object sender, EventArgs e)
        {
            Notes.Text = $"Welcome [ {lblUsername.Text} ].";
        }






                                    //folvUsersList


        //This method convert the Users DataTable into UserViewModel list Using the UserViewModel Class
        private List<UserViewModel> ConvertDataTableToUsers(DataTable dtUsers)
        {
            List<UserViewModel> Users = new List<UserViewModel>();

            foreach (DataRow row in dtUsers.Rows)
            {
                Users.Add(new UserViewModel
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    FullName = row["Full Name"].ToString(),
                    Role = row["Role"].ToString(),
                    Status = row["Status"].ToString()
                });
            }

            return Users;
        }

        
        //this method is used to fill the fast object list view with data
        private void FillTheUsersFastObjectListViewWithData()
        {
            DataTable dtUsersList = clsUsers.UsersList();
            _AllUsers = ConvertDataTableToUsers(dtUsersList);

            //bind to FastObjectListView
            folvUsersList.Clear();
            folvUsersList.Columns.Clear();
            folvUsersList.View = View.Details;
            folvUsersList.FullRowSelect = true;
            folvUsersList.UseAlternatingBackColors = true;
            folvUsersList.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvUsersList.Columns.Add(new OLVColumn("ID", "UserID") { Width = 65 });
            folvUsersList.Columns.Add(new OLVColumn("Username", "Username") { Width = 120 });
            folvUsersList.Columns.Add(new OLVColumn("Name", "FullName") { Width = 280 });
            folvUsersList.Columns.Add(new OLVColumn("Role", "Role") { Width = 120 });
            folvUsersList.Columns.Add(new OLVColumn("Status", "Status") { Width = 175 });

            //changing the  alternating row color 
            folvUsersList.UseAlternatingBackColors = true;
            folvUsersList.BackColor = Color.White; // Even rows
            folvUsersList.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvUsersList.SetObjects(_AllUsers);

        }

        //Users List Fillter
        private void tbSearchforUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchforUser.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvUsersList.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvUsersList.ModelFilter = new ModelFilter(model =>
                {
                    var User = model as UserViewModel;
                    if (User == null) return false;

                    return User.FullName.ToLower().Contains(searchText)
                        || User.UserID.ToString().Contains(searchText)
                        || User.Username.ToLower().Contains(searchText)
                        || User.Role.ToLower().Contains(searchText)
                        || User.Status.ToLower().Contains(searchText);
                        



                });
            }

            folvUsersList.Refresh();
        }



                                   //folvUsersLoginLogsList


        //This method convert the Users DataTable into UserViewModel list Using the UserViewModel Class
        private List<UserLoginLogViewModel> ConvertDataTableToUsersLoginLogList(DataTable dtUsersLoginLogs)
        {
            List<UserLoginLogViewModel> UsersLoginLogs = new List<UserLoginLogViewModel>();

            if(dtUsersLoginLogs != null)
            {
                foreach (DataRow row in dtUsersLoginLogs.Rows)
                {
                    UsersLoginLogs.Add(new UserLoginLogViewModel
                    {
                        LogID = Convert.ToInt32(row["LogID"]),
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString(),
                        FullName = row["FullName"].ToString(),
                        LoginDateTime = (DateTime)row["LoginDateTime"]

                    });
                }
            }
            

            return UsersLoginLogs;
        }


        //this method is used to fill the fast object list view with data
        private void FillTheUsersLoginLogsFastObjectListViewWithData(byte CurrentPage,byte PageSize,string Username = null, 
            DateTime? StartingPeriod = null,DateTime? EndingPeriod = null )
        {
            DataTable dtUsersLoginLogList = clsUsers.GetUsersLoginLogList(CurrentPage,PageSize,Username,StartingPeriod,EndingPeriod);
            _AllUsersLoginLogs = ConvertDataTableToUsersLoginLogList(dtUsersLoginLogList);

            //bind to FastObjectListView
            folvLoginLog.Clear();
            folvLoginLog.Columns.Clear();
            folvLoginLog.View = View.Details;
            folvLoginLog.FullRowSelect = true;
            folvLoginLog.UseAlternatingBackColors = true;
            folvLoginLog.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvLoginLog.Columns.Add(new OLVColumn("Log ID", "LogID") { Width = 65 });
            folvLoginLog.Columns.Add(new OLVColumn("User ID", "UserID") { Width = 65 });
            folvLoginLog.Columns.Add(new OLVColumn("Username", "Username") { Width = 120 });
            folvLoginLog.Columns.Add(new OLVColumn("Name", "FullName") { Width = 280 });
            folvLoginLog.Columns.Add(new OLVColumn("Login Date", "LoginDateTime") { Width = 140 });

            //changing the  alternating row color 
            folvLoginLog.UseAlternatingBackColors = true;
            folvLoginLog.BackColor = Color.White; // Even rows
            folvLoginLog.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvLoginLog.SetObjects(_AllUsersLoginLogs);

        }

        //Users login log list fillter
        private void tbSearchforLoginInfo_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchforLoginInfo.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvLoginLog.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvLoginLog.ModelFilter = new ModelFilter(model =>
                {
                    var UserLoginLog = model as UserLoginLogViewModel;
                    if (UserLoginLog == null) return false;

                    return UserLoginLog.FullName.ToLower().Contains(searchText)
                        || UserLoginLog.UserID.ToString().Contains(searchText)
                        || UserLoginLog.LogID.ToString().Contains(searchText)
                        || UserLoginLog.Username.ToLower().Contains(searchText)
                        || UserLoginLog.LoginDateTime.ToShortDateString().Contains(searchText);



                });
            }

            folvLoginLog.Refresh();
        }






                                       //buttons

        //Add new user buttons
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm =new frmAddNewUser();
            frm.ShowDialog();

            //refresh the list
            FillTheUsersFastObjectListViewWithData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }

        private void btnMyInformation_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsUserSession.CurrentUser);
            frm.ShowDialog();

            //filling the header with the current user info (incase ther was any change in the use info)
            lblUsername.Text = clsUserSession.CurrentUser.Username;
            lblRole.Text = clsUserSession.CurrentUser.Role;

        }
        
        //Search for log
        private void btnSearch_Click(object sender, EventArgs e)
        {


            _CurrentPage = 1;

            int RowCount = clsUsers.GetUsersLoginLogRecordsCount(tbUsername.Text, dtpStartingDate.Value.Date, dtpEndingDate.Value.AddDays(1));
            
            _TotalPages = (int)Math.Ceiling((double)RowCount / _PageSize);
            _Mode = enMode.Search;

            _NextPreviousButtonsStatus();

            FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize, tbUsername.Text, dtpStartingDate.Value.Date, dtpEndingDate.Value.AddDays(1));

         
        }

        //Refresh list button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Calculating the number of pages
            _CurrentPage = 1;
            _TotalPages = (int)Math.Ceiling((double)clsUsers.GetUsersLoginLogRecordsCount() / _PageSize);

            _NextPreviousButtonsStatus();

            //Marking the mode to all records
            _Mode = enMode.AllRecords;



            //only pass the current page and pagesize because it's for all login logs 
            FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize);
        }

        //Button Next and button previous
        private void btnNext_Click(object sender, EventArgs e)
        {
            _CurrentPage++; // move to the next state
            lblPageNumber.Text = _CurrentPage.ToString();


            if(_Mode == enMode.AllRecords)
                FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize);
            else if(_Mode ==enMode.Search)
                FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize,tbUsername.Text,dtpStartingDate.Value,dtpEndingDate.Value.AddDays(1));



            _NextPreviousButtonsStatus();


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _CurrentPage--; // move to the previous state
            lblPageNumber.Text = _CurrentPage.ToString();


            if (_Mode == enMode.AllRecords)
                FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize);
            else if (_Mode == enMode.Search)
                FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage, _PageSize, tbUsername.Text, dtpStartingDate.Value, dtpEndingDate.Value);



            _NextPreviousButtonsStatus();

        }

        //Button print log
        private void btnPrintLog_Click(object sender, EventArgs e)
        {
            //get the current data that is inside the fast object list view as a list
            List<UserLoginLogViewModel> UsersList = System.Linq.Enumerable.Cast<UserLoginLogViewModel>(folvLoginLog.Objects).ToList();

            clsReportService.ExportReportToPdf(UsersList, "GCMS", "Users Login Log");
        }






        // this event will handle the context menu strip that will appear
        private void folvUsersList_MouseDown(object sender, MouseEventArgs e)
        {
            //if the click is the right mouse button
            if( e.Button ==MouseButtons.Right)
            {
                var hitTest = folvUsersList.OlvHitTest(e.X, e.Y);

                if (hitTest.Item != null)
                {
                    // Select the row that was right-clicked and make sure that is selected to be used later inside the context menu
                    folvUsersList.SelectedObject = hitTest.RowObject;

                    // Show the context menu manually 
                    cmsUsersListOptions.Show(folvUsersList, e.Location);
                }
            }
        }


        //Context menue Options
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }
        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected object
            if (folvUsersList.SelectedObject is UserViewModel selectedItem)
            {
                int Test = selectedItem.UserID;
                //call the activate_deactivate form and make the mode ACTIVATE
                frmActivate_Deactivate_Users frm = new frmActivate_Deactivate_Users(selectedItem.UserID, frmActivate_Deactivate_Users.enMode.Activate);
                frm.ShowDialog();


                //Refresh the list
                FillTheUsersFastObjectListViewWithData();
            }
        }
        private void deactivateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected object
            if (folvUsersList.SelectedObject is UserViewModel selectedItem)
            {
                //call the activate_deactivate form and make the mode DEACTIVATE
                frmActivate_Deactivate_Users frm = new frmActivate_Deactivate_Users(selectedItem.UserID, frmActivate_Deactivate_Users.enMode.Deactivate);
                frm.ShowDialog();


                //Refresh the list
                FillTheUsersFastObjectListViewWithData();
            }
        }




        //this method is for setting the date time pickers Min and max vlaues based on the min and max date in the database
        private void _SettingTheDateTimePickersMINandMAXvalues()
        {
            //filling the date time pickers
            DateTime Min = new DateTime();
            DateTime Max = new DateTime();

            clsUsers.GetMinimum_Maxmimum_LoginLogDate(ref Min, ref Max);

            dtpStartingDate.MinDate = Min;
            dtpStartingDate.MaxDate = Max;

            dtpEndingDate.MinDate = Min;
            dtpEndingDate.MaxDate = Max;

            dtpStartingDate.Value = Min;
            dtpEndingDate.Value = Max;  

        }
        //this method is for the next previous button visibility (when and when not to show the buttons)
        private void _NextPreviousButtonsStatus()
        {
            if (_CurrentPage < _TotalPages)
                btnNext.Visible = true;
            else
                btnNext.Visible = false;

            if (_CurrentPage > 1)
                btnPrevious.Visible = true;
            else
                btnPrevious.Visible = false;

        }



                                 //ON LOAD
        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            //filling the header with the current user info
            lblUsername.Text = clsUserSession.CurrentUser.Username;
            lblRole.Text = clsUserSession.CurrentUser.Role;

            //filling the min max values
            _SettingTheDateTimePickersMINandMAXvalues();

            //Filling the users fast object list views with data

            FillTheUsersFastObjectListViewWithData();

            //filling the login logs fast object list view with data

            //Calculating the number of pages
            _TotalPages = (int)Math.Ceiling((double)clsUsers.GetUsersLoginLogRecordsCount() / _PageSize);

            _NextPreviousButtonsStatus();

            _Mode = enMode.AllRecords;

            //only pass the current page and pagesize because it's for all login logs 
            FillTheUsersLoginLogsFastObjectListViewWithData(_CurrentPage,_PageSize);

        }

       
    }

    //This class will work as a container that represents a  row of GetUsersList (a User data)
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role{ get; set; }
        public string Status { get; set; } // e.g., "Active" or "No Active"
    }

    //This class will work as a container that represents a  row of GetUsersLoginLogList
    public class UserLoginLogViewModel
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime LoginDateTime { get; set; }
        
    }
}
