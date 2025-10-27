using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GCMS.Reports
{
    public class clsExcelExporter
    {
        public static void ExportListToExcel<T>(List<T> dataList, string filePath, string sheetName = "Report")
        {
            if (dataList == null || dataList.Count == 0)
            {
                throw new ArgumentException("The data list is empty or null.");
            }

            // set license for non-commercial use
            ExcelPackage.License.SetNonCommercialPersonal("YourNameHere");
           

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);

                PropertyInfo[] properties = typeof(T).GetProperties();

                // HEADER ROW
                for (int col = 0; col < properties.Length; col++)
                {
                    var cell = worksheet.Cells[1, col + 1];
                    cell.Value = properties[col].Name;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // DATA ROWS
                for (int row = 0; row < dataList.Count; row++)
                {
                    var item = dataList[row];
                    for (int col = 0; col < properties.Length; col++)
                    {
                        var value = properties[col].GetValue(item, null);
                        worksheet.Cells[row + 2, col + 1].Value = value ?? "";
                    }
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.View.FreezePanes(2, 1);

                var dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}

