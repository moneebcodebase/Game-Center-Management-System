using System;
using System.Collections.Generic;
using System.Windows.Forms; //for SaveFileDialog
using GCMS_Infrastructure.PDF_Report;




/// <summary>
/// This class is used for report exporting and printing
/// </summary>
namespace GCMS_Infrastructure
{

    /// <summary>
    /// This class is used for Reports services
    /// </summary>

    public class clsReportService
    {
        //static method that export lists into a structured pdf file
        public static void ExportReportToPdf<T>(List<T> dataList, string projectName, string reportTitle)
        {
            if (dataList == null || dataList.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = $"{reportTitle.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Use your PdfReport<T> class from clsPdfReports
                        var report = new PdfReport<T>(dataList, projectName, reportTitle);
                        report.GeneratePdf(saveDialog.FileName);

                        MessageBox.Show("Report exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting report:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
