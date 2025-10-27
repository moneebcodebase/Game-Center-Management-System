using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GCMS_Data_Access
{
    /// <summary>
    /// this class will represnet the data access layer for GCMS Reports
    /// </summary>
    public class clsReports_Data_Access
    {
        //this function will return a tuple of the records,total pages and total records
        public static (DataTable,int,int) GCMSReports(int ReportType,int PageNumber,
            int PageSize,DateTime FromDate ,DateTime ToDate , bool WithPaging)
        {
            //Data table to hold users information
            DataTable dtReport = new DataTable();
            int TotalRecord;
            int TotalPages;

            //Database Connection
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetReports", connection);
            command.CommandType = CommandType.StoredProcedure;


            //Setting the input Parameters
            command.Parameters.AddWithValue("@ReportType", ReportType);
            command.Parameters.AddWithValue("@PageNumber", PageNumber);
            command.Parameters.AddWithValue("@PageSize", PageSize);
            command.Parameters.AddWithValue("@FromDate", FromDate);
            command.Parameters.AddWithValue("@ToDate", ToDate);
            command.Parameters.AddWithValue("@WithPaging", WithPaging);

            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter ReportTotalRecordParam = new SqlParameter("@ReportTotalRecords", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ReportTotalRecordParam);
            //creating the output Variable that will be returns from excuting the procedure
            SqlParameter ReportTotalPagesParam = new SqlParameter("@ReportTotalPages", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(ReportTotalPagesParam);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtReport.Load(reader);
                    TotalRecord = (int)ReportTotalRecordParam.Value;
                    TotalPages = (int)ReportTotalPagesParam.Value;
                } 
                else
                {
                    dtReport = null;
                    TotalRecord = 0;
                    TotalPages = 0;
                }
                    

                reader.Close();

            }
            catch (Exception ex)
            {
                dtReport = null;
                TotalRecord = 0;
                TotalPages = 0;

                //Logging the error into Event Logger
                string Message = $"Coudn't load report content. {ex.Message}";
                clsDataAccessSettings.EventLogger("GCMS", Message, clsDataAccessSettings.enEventType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (dtReport,TotalPages,TotalRecord);
        }
    }
}
