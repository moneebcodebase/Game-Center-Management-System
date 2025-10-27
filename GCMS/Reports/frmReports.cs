using BrightIdeasSoftware;
using GCMS.Users;
using GCMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCMS.Reports
{
    public partial class frmReports : Form
    {
        //private data members used in this form
        private int _PageSize = 20;
        private int _TotalPages;
        private int _TotalRecords=0;
        private int _CurrentPage;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private List<RentalsSalesReportViewModel> _RentalSalesListExport;
        private List<StoreSalesReportViewModel> _StoreSalesListExport;
        public enum enMode { RentalsReports , StoreReports}
        private enMode _Mode;




        public frmReports()
        {
            InitializeComponent();
        }




        //on form load
        private void frmReports_Load(object sender, EventArgs e)
        {
            cbReports.SelectedIndex = 0;
            btnNext.Visible = false;
            btnPrevious.Visible = false;
            lblPageNumber.Text = "1";
            lblTotalRecords.Text = "0";
            btnExport.Enabled = false;
        }




                                         //loading content

        //Rentals Sales Report
        private List<RentalsSalesReportViewModel> ConvertDataTableToRentalsSalesReportList(DataTable dtReport)
        {
            List<RentalsSalesReportViewModel> ReportList = new List<RentalsSalesReportViewModel>();

            if (dtReport != null)
            {
                foreach (DataRow row in dtReport.Rows)
                {
                    ReportList.Add(new RentalsSalesReportViewModel
                    {
                        RentalID = Convert.ToInt32(row["RentalID"]),
                        GameName = row["GameName"].ToString(),
                        Period = row["Period"].ToString(),
                        PaymentType = row["PaymentTypeName"].ToString(),
                        PaymentMethod =row["PaymentMethodName"].ToString(),
                        Amount =Convert.ToDecimal( row["Amount"]),
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString()

                    });
                }
            }


            return ReportList;
        }
        //this method is used to fill the fast object list view with data
        private void FillTheFOLVWithRentalsSalesReprot(DateTime FromDate,DateTime ToDate ,
            int PageNumber,int PageSize,bool WithPaging = true)
        {
            //Getting the data from the db
            var Result = clsReports.GCMSReports(FromDate, ToDate,1, PageNumber, PageSize,WithPaging);

            List<RentalsSalesReportViewModel> RentalsSalesReprotList= ConvertDataTableToRentalsSalesReportList(Result.Item1);
            _TotalPages = Result.Item2;
            _TotalRecords = Result.Item3;
            lblTotalRecords.Text = _TotalRecords.ToString();


            //bind to FastObjectListView
            folvReports.Clear();
            folvReports.Columns.Clear();
            folvReports.View = View.Details;
            folvReports.FullRowSelect = true;
            folvReports.UseAlternatingBackColors = true;
            folvReports.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvReports.Columns.Add(new OLVColumn("Rental ID", "RentalID") { Width = 65 });
            folvReports.Columns.Add(new OLVColumn("Game Name", "GameName") { Width = 110 });
            folvReports.Columns.Add(new OLVColumn("Period", "Period") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Payment Type", "PaymentType") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Payment Method", "PaymentMethod") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Amount", "Amount") { Width = 90 });
            folvReports.Columns.Add(new OLVColumn("User ID", "UserID") { Width = 70 });
            folvReports.Columns.Add(new OLVColumn("Username", "Username") { Width = 130 });

            //changing the  alternating row color 
            folvReports.UseAlternatingBackColors = true;
            folvReports.BackColor = Color.White; // Even rows
            folvReports.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvReports.SetObjects(RentalsSalesReprotList);

        }
        //Store Sales Report
        private List<StoreSalesReportViewModel> ConvertDataTableToStoreSalesReportList(DataTable dtReport)
        {
            List<StoreSalesReportViewModel> ReportList = new List<StoreSalesReportViewModel>();

            if (dtReport != null)
            {
                foreach (DataRow row in dtReport.Rows)
                {
                    ReportList.Add(new StoreSalesReportViewModel
                    {
                        CartPaymentID = Convert.ToInt32(row["CartPaymentID"]),
                        CartID = Convert.ToInt32(row["CartID"]),
                        PaymentType = row["PaymentTypeName"].ToString(),
                        PaymentMethod = row["PaymentMethodName"].ToString(),
                        PaymentDate = (DateTime)row["PaymentDate"],
                        Amount = Convert.ToDecimal(row["Amount"]),
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString()

                    });
                }
            }


            return ReportList;
        }
        //this method is used to fill the fast object list view with data
        private void FillTheFOLVWithStoresSalesReprot(DateTime FromDate, DateTime ToDate,
            int PageNumber, int PageSize , bool WithPaging = true)
        {
            //Getting the data from the db
            var Result = clsReports.GCMSReports(FromDate, ToDate, 2, PageNumber, PageSize, WithPaging);

            List<StoreSalesReportViewModel> StoreSalesReportList= ConvertDataTableToStoreSalesReportList(Result.Item1);
            _TotalPages = Result.Item2;
            _TotalRecords = Result.Item3;
            lblTotalRecords.Text = _TotalRecords.ToString();

            //bind to FastObjectListView
            folvReports.Clear();
            folvReports.Columns.Clear();
            folvReports.View = View.Details;
            folvReports.FullRowSelect = true;
            folvReports.UseAlternatingBackColors = true;
            folvReports.ShowGroups = false;

            //specifiying the cloumns that will be shown
            folvReports.Columns.Add(new OLVColumn("ID", "CartPaymentID") { Width = 65 });
            folvReports.Columns.Add(new OLVColumn("Cart ID", "CartID") { Width = 65 });
            folvReports.Columns.Add(new OLVColumn("Payment Type", "PaymentType") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Payment Method", "PaymentMethod") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Payment Date", "PaymentDate") { Width = 140 });
            folvReports.Columns.Add(new OLVColumn("Amount", "Amount") { Width = 100 });
            folvReports.Columns.Add(new OLVColumn("User ID", "UserID") { Width = 70 });
            folvReports.Columns.Add(new OLVColumn("Username", "Username") { Width = 200 });

            //changing the  alternating row color 
            folvReports.UseAlternatingBackColors = true;
            folvReports.BackColor = Color.White; // Even rows
            folvReports.AlternateRowBackColor = Color.LightGray; // Odd rows


            folvReports.SetObjects(StoreSalesReportList);

        }


        //control the next previous button
        private void _NextPreviousButtonsStatus()
        {
            if (_TotalPages == 0)
                return;

            if (_CurrentPage < _TotalPages)
                btnNext.Visible = true;
            else
                btnNext.Visible = false;

            if (_CurrentPage > 1)
                btnPrevious.Visible = true;
            else
                btnPrevious.Visible = false;

        }


        //on the button serach
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _CurrentPage = 1;
            _PageSize = Convert.ToInt32(nudPageSize.Value);
            _FromDate = dtpStartingDate.Value;
            _ToDate = dtpEndingDate.Value;
            lblPageNumber.Text = _CurrentPage.ToString();

            if (cbReports.SelectedIndex == 0 )
            {
                _Mode = enMode.RentalsReports;
                FillTheFOLVWithRentalsSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);

                _NextPreviousButtonsStatus();
            }
            else
            {
                _Mode= enMode.StoreReports;
                FillTheFOLVWithStoresSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);
                _NextPreviousButtonsStatus();
            }
        }


        //handle the next and the previous 
        private void btnNext_Click(object sender, EventArgs e)
        {
            _CurrentPage++; // move to the next state
            lblPageNumber.Text = _CurrentPage.ToString();

            if (_Mode ==enMode.RentalsReports)
            {
                FillTheFOLVWithRentalsSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);

                _NextPreviousButtonsStatus();
            }
            else
            {
                FillTheFOLVWithStoresSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);
                _NextPreviousButtonsStatus();
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _CurrentPage--; // move to the previous state
            lblPageNumber.Text = _CurrentPage.ToString();

            if (_Mode == enMode.RentalsReports)
            {
                FillTheFOLVWithRentalsSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);

                _NextPreviousButtonsStatus();
            }
            else
            {
                FillTheFOLVWithStoresSalesReprot(_FromDate, _ToDate, _CurrentPage, _PageSize);
                _NextPreviousButtonsStatus();
            }

        }





                              //Exporting reprot to the excel file

        //enable disable the exprot button
        private void folvReports_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            btnExport.Enabled = folvReports.GetItemCount() > 0;
        }
        //private mehtod to get all the record without the paging to export them
        private List<RentalsSalesReportViewModel> GetExportedRentalsSalesList()
        {
            //Getting the data from the db
            var Result = clsReports.GCMSReports(_FromDate, _ToDate, 1, _CurrentPage, _PageSize, false);

            List<RentalsSalesReportViewModel> RentalsSalesReprotList = ConvertDataTableToRentalsSalesReportList(Result.Item1);

            return RentalsSalesReprotList;
        }
        private List<StoreSalesReportViewModel> GetExportedStoreSalesList()
        {
            //Getting the data from the db
            var Result = clsReports.GCMSReports(_FromDate, _ToDate, 2, _CurrentPage, _PageSize, false);

            List<StoreSalesReportViewModel> StoreSalesReprotList = ConvertDataTableToStoreSalesReportList(Result.Item1);

            return StoreSalesReprotList;
        }

        private void _PreformRentalsReportExport()
        {
            _RentalSalesListExport = GetExportedRentalsSalesList();
            if (_RentalSalesListExport == null || _RentalSalesListExport.Count == 0)
            {
                MessageBox.Show("No data to export!");
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Export Report to Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clsExcelExporter.ExportListToExcel(_RentalSalesListExport, saveDialog.FileName);

                        //Ask user if they want to open the file
                        var openFile = MessageBox.Show(
                            "Export completed successfully!\n\nDo you want to open the report now?",
                            "Export Complete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (openFile == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveDialog.FileName,
                                    UseShellExecute = true //required for .xlsx files
                                });
                            }
                            catch (Exception openEx)
                            {
                                MessageBox.Show($"The file was exported, but could not be opened:\n{openEx.Message}",
                                    "Open File Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void _PreformSalesReportExport()
        {
            _StoreSalesListExport = GetExportedStoreSalesList();
            if (_StoreSalesListExport == null || _StoreSalesListExport.Count == 0)
            {
                MessageBox.Show("No data to export!");
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Export Report to Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clsExcelExporter.ExportListToExcel(_StoreSalesListExport, saveDialog.FileName);

                        //Ask user if they want to open the file
                        var openFile = MessageBox.Show(
                            "Export completed successfully!\n\nDo you want to open the report now?",
                            "Export Complete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (openFile == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveDialog.FileName,
                                    UseShellExecute = true //required for .xlsx files
                                });
                            }
                            catch (Exception openEx)
                            {
                                MessageBox.Show($"The file was exported, but could not be opened:\n{openEx.Message}",
                                    "Open File Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Exporting data to excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.RentalsReports)
            {
                _PreformRentalsReportExport();

            }
            else
            {
                _PreformSalesReportExport();
            }

           
        }

       
    }

    public class RentalsSalesReportViewModel
    { 
        public int RentalID {  get; set; }
        public string GameName { get; set; }
        public string Period {  get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }

    }

    public class StoreSalesReportViewModel
    {
        public int CartPaymentID { get; set; }
        public int CartID { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }


    }

}
