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

namespace GCMS.Debts
{
    public partial class frmDebts : Form
    {
        private List<DebtsViewModel> _UnPaidDebtsList = new List<DebtsViewModel>();
        private List<DebtsViewModel> _PaidDebtsList = new List<DebtsViewModel>();

        public frmDebts()
        {
            InitializeComponent();
        }



                                        //folvUnpaidDebtsList


        //This method convert the Debts DataTable into DebtsViewModel list Using the DebtsViewModel Class
        private List<DebtsViewModel> ConvertDataTableDebtsList(DataTable dtDebtsList)
        {
            List<DebtsViewModel> DebtsList = new List<DebtsViewModel>();

            if (dtDebtsList != null)
            {
                foreach (DataRow row in dtDebtsList.Rows)
                {
                    DebtsList.Add(new DebtsViewModel
                    {
                        DebtID = Convert.ToInt32(row["Debt ID"]),
                        RenterName = row["Renter Name"].ToString(),
                        RentalID = Convert.ToInt32(row["Rental ID"]),
                        Amount =Convert.ToDecimal(row["Amount"]),
                        IsPaid = row["Is Paid"].ToString()

                    });
                }
            }


            return DebtsList;
        }

        //this method is used to fill the fast object list view with data
        private void _FillTheUnpaidDebtsFastObjectListViewWithData()
        {
            DataTable dtUnpaidDebysList = clsDebts.GetUnpaidDebtsList();
            _UnPaidDebtsList = ConvertDataTableDebtsList(dtUnpaidDebysList);

            //bind to FastObjectListView
            folvUnpaidDebtsList.Clear();
            folvUnpaidDebtsList.Columns.Clear();
            folvUnpaidDebtsList.View = View.Details;
            folvUnpaidDebtsList.FullRowSelect = true;
            folvUnpaidDebtsList.UseAlternatingBackColors = true;
            folvUnpaidDebtsList.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvUnpaidDebtsList.Columns.Add(new OLVColumn("Debt ID", "DebtID") { Width = 65 });
            folvUnpaidDebtsList.Columns.Add(new OLVColumn("Renter Name", "RenterName") { Width = 300 });
            folvUnpaidDebtsList.Columns.Add(new OLVColumn("Rental ID", "RentalID") { Width = 80 });
            folvUnpaidDebtsList.Columns.Add(new OLVColumn("Amount", "Amount") { Width = 80 });
            folvUnpaidDebtsList.Columns.Add(new OLVColumn("Is Paid", "IsPaid") { Width = 80 });

            //changing the  alternating row color 
            folvUnpaidDebtsList.UseAlternatingBackColors = true;
            folvUnpaidDebtsList.BackColor = Color.White; // Even rows
            folvUnpaidDebtsList.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvUnpaidDebtsList.SetObjects(_UnPaidDebtsList);

        }
        //this method is used to fill the fast object list view with data
        private void _FillThepaidDebtsFastObjectListViewWithData()
        {
            DataTable dtpaidDebysList = clsDebts.GetPaidDebtsList();
            _PaidDebtsList = ConvertDataTableDebtsList(dtpaidDebysList);

            //bind to FastObjectListView
            folvPaidDebtsList.Clear();
            folvPaidDebtsList.Columns.Clear();
            folvPaidDebtsList.View = View.Details;
            folvPaidDebtsList.FullRowSelect = true;
            folvPaidDebtsList.UseAlternatingBackColors = true;
            folvPaidDebtsList.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvPaidDebtsList.Columns.Add(new OLVColumn("Debt ID", "DebtID") { Width = 65 });
            folvPaidDebtsList.Columns.Add(new OLVColumn("Renter Name", "RenterName") { Width = 300 });
            folvPaidDebtsList.Columns.Add(new OLVColumn("Rental ID", "RentalID") { Width = 80 });
            folvPaidDebtsList.Columns.Add(new OLVColumn("Amount", "Amount") { Width = 80 });
            folvPaidDebtsList.Columns.Add(new OLVColumn("Is Paid", "IsPaid") { Width = 80 });


            //changing the  alternating row color 
            folvPaidDebtsList.UseAlternatingBackColors = true;
            folvPaidDebtsList.BackColor = Color.White; // Even rows
            folvPaidDebtsList.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvPaidDebtsList.SetObjects(_PaidDebtsList);

        }
        private void Debts_Load(object sender, EventArgs e)
        {
            _FillTheUnpaidDebtsFastObjectListViewWithData();
            _FillThepaidDebtsFastObjectListViewWithData();
        }


        //filltering the paid and unpaid lists 

        private void _FilterUnPaidList()
        {
            string searchText = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvUnpaidDebtsList.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvUnpaidDebtsList.ModelFilter = new ModelFilter(model =>
                {
                    var Debts = model as DebtsViewModel;
                    if (Debts == null) return false;

                    return Debts.DebtID.ToString().Contains(searchText)
                        || Debts.RenterName.ToLower().Contains(searchText);


                });
            }

            folvUnpaidDebtsList.Refresh();
        }
        private void _FilterPaidList()
        {
            string searchText = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No filter: show full list again
                folvPaidDebtsList.ModelFilter = null;
            }
            else
            {
                // Apply filter
                folvPaidDebtsList.ModelFilter = new ModelFilter(model =>
                {
                    var Debts = model as DebtsViewModel;
                    if (Debts == null) return false;

                    return Debts.DebtID.ToString().Contains(searchText)
                        || Debts.RenterName.ToLower().Contains(searchText);


                });
            }

            folvPaidDebtsList.Refresh();
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(tapDebts.SelectedIndex==0)
            {
                _FilterUnPaidList();
            }
            else
            {
                _FilterPaidList();
            }
        }



        //handles the context menue that will appear when clicking on a row
        private void folvUnpaidDebtsList_MouseDown(object sender, MouseEventArgs e)
        {
            //if the click is the right mouse button
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = folvUnpaidDebtsList.OlvHitTest(e.X, e.Y);

                if (hitTest.Item != null)
                {
                    // Select the row that was right-clicked and make sure that is selected to be used later inside the context menu
                    folvUnpaidDebtsList.SelectedObject = hitTest.RowObject;

                    // Show the context menu manually 
                    cmsUnPaidListOptions.Show(folvUnpaidDebtsList, e.Location);
                }
            }
        }


        //context menue strip action(Paying a debt)
        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected object
            if (folvUnpaidDebtsList.SelectedObject is DebtsViewModel selectedItem)
            {
                //locating the Debt it
                int DebtID = selectedItem.DebtID;

                //calling the paydebt form and pass the debt object to it
                frmPayDebt frm = new frmPayDebt(clsDebts.FindDebt(DebtID));
                frm.ShowDialog();


                //Refreshing the unpaid list 
                _FillTheUnpaidDebtsFastObjectListViewWithData();
            }


        }
    }

    //This class will work as a container that represents a  row of GetUnPaidDebtsList
    public class DebtsViewModel
    {
        public int DebtID { get; set; }
        public string RenterName { get; set; }
        public int RentalID { get; set; }
        public decimal Amount { get; set; }
        public string IsPaid { get; set; } // e.g., "Paid" or "Not Paid"
    }
}
