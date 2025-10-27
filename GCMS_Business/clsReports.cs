using GCMS_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMS_Business
{
    /// <summary>
    /// this class will represnt Report business layer that the ui will intract with
    /// </summary>
    public class clsReports
    {
        public static (DataTable,int, int) GCMSReports(DateTime FromDate, DateTime ToDate
           , int ReportType = 1, int PageNumber = 1,int PageSize=20,bool WithPaging = true)
        {
            return clsReports_Data_Access.GCMSReports(ReportType, PageNumber, PageSize, FromDate, ToDate,WithPaging);
        }
    }
}
