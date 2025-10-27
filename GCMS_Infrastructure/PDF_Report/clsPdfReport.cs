using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;


namespace GCMS_Infrastructure.PDF_Report
{

    /// <summary>
    /// This class is generic used pdf reports genarating using the PDFSharp lib
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 

    public class PdfReport<T>
    {
        private readonly List<T> _data;
        private readonly string _projectName;
        private readonly string _reportTitle;

        public PdfReport(List<T> data, string projectName, string reportTitle)
        {
            _data = data ?? new List<T>();
            _projectName = projectName;
            _reportTitle = reportTitle;
        }

        public void GeneratePdf(string outputPath)
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("No data to export.");

            PdfDocument document = new PdfDocument();
            document.Info.Title = _reportTitle;

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Fonts
            XFont fontTitle = new XFont("Verdana", 16, XFontStyle.Bold);
            XFont fontHeader = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont fontRow = new XFont("Verdana", 10, XFontStyle.Regular);

            // Margins and page size
            double marginLeft = 40;
            double marginTop = 40;
            double yPoint = marginTop;
            double pageWidth = page.Width.Point;
            double pageHeight = page.Height.Point;
            double padding = 5;

            // Draw title and report name
            gfx.DrawString(_projectName, fontTitle, XBrushes.DarkBlue,
                new XRect(marginLeft, yPoint, pageWidth - 2 * marginLeft, 30), XStringFormats.TopLeft);
            yPoint += 30;

            gfx.DrawString(_reportTitle, fontHeader, XBrushes.Black,
                new XRect(marginLeft, yPoint, pageWidth - 2 * marginLeft, 25), XStringFormats.TopLeft);
            yPoint += 40;

            // Extract properties for columns
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int columnCount = properties.Length;

            // Measure max width for each column
            XGraphics gfxMeasure = XGraphics.CreateMeasureContext(new XSize(800, 600), XGraphicsUnit.Point, XPageDirection.Downwards);
            double[] columnWidths = new double[columnCount];

            // Measure header text
            for (int i = 0; i < columnCount; i++)
            {
                var headerSize = gfxMeasure.MeasureString(properties[i].Name, fontHeader);
                columnWidths[i] = headerSize.Width + 10;
            }

            // Measure data content
            foreach (var item in _data)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    string value = properties[i].GetValue(item)?.ToString() ?? string.Empty;
                    var valueSize = gfxMeasure.MeasureString(value, fontRow);
                    columnWidths[i] = Math.Max(columnWidths[i], valueSize.Width + 10);
                }
            }

            // Fit to page width if needed
            double totalWidth = columnWidths.Sum();
            double availableWidth = pageWidth - 2 * marginLeft;

            if (totalWidth > availableWidth)
            {
                double scaleFactor = availableWidth / totalWidth;
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    columnWidths[i] *= scaleFactor;
                }
            }

            // Draw table headers
            double rowHeight = 20;
            double x = marginLeft;
            for (int i = 0; i < columnCount; i++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, x, yPoint, columnWidths[i], rowHeight);
                gfx.DrawString(properties[i].Name, fontHeader, XBrushes.Black,
                    new XRect(x +padding, yPoint + 3, columnWidths[i], rowHeight), XStringFormats.TopLeft);
                x += columnWidths[i];
            }
            yPoint += rowHeight;

            // Draw data rows
            foreach (var item in _data)
            {
                // New page if needed
                if (yPoint + rowHeight > pageHeight - marginTop)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = marginTop;
                }

                double currentX = marginLeft;

                for (int i = 0; i < columnCount; i++)
                {
                    string value = properties[i].GetValue(item)?.ToString() ?? string.Empty;
                    gfx.DrawString(value, fontRow, XBrushes.Black,
                        new XRect(currentX + padding, yPoint + 3, columnWidths[i], rowHeight), XStringFormats.TopLeft);
                    currentX += columnWidths[i];
                }

                yPoint += rowHeight;
            }

            // Draw grid lines (horizontal)
            double tableTop = marginTop + 70;
            int totalRows = _data.Count + 1;

            for (int i = 0; i <= totalRows; i++)
            {
                double y = tableTop + i * rowHeight;
                gfx.DrawLine(XPens.Black, marginLeft, y, marginLeft + columnWidths.Sum(), y);
            }

            // Draw grid lines (vertical)
            double currentXLine = marginLeft;
            for (int i = 0; i <= columnCount; i++)
            {
                gfx.DrawLine(XPens.Black, currentXLine, tableTop, currentXLine, tableTop + totalRows * rowHeight);
                if (i < columnCount)
                    currentXLine += columnWidths[i];
            }

            // Save the document
            document.Save(outputPath);
            document.Close();
        }

    }
}
