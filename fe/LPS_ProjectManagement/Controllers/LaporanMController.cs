using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.ReportModels;
using LPS_ProjectManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Http;
using System.IO;
using Microsoft.Office.Interop.Excel;
using net.sf.mpxj.planner.schema;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using org.apache.poi.wp.usermodel;
using Microsoft.Office.SharePoint.Tools;
using java.time;
using org.apache.poi.ss.usermodel;
using System.Web.Helpers;
using com.sun.rowset.@internal;
using System.Globalization;
using static jdk.nashorn.@internal.codegen.CompilerConstants;
using System.Web.Http.Results;
using org.apache.poi.ss.util;
using com.sun.org.apache.regexp.@internal;
using static com.sun.xml.@internal.rngom.digested.DDataPattern;
using System.Drawing;

namespace LPS_ProjectManagement.Controllers
{
    public class LaporanMController : Controller
    {
        // GET: LaporanM
        public ActionResult LaporanMingguan()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {


                return View();
            }
        }

        public ActionResult NotFound()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {


                return View();
            }
        }

        public async Task<dynamic> GenerateWordDocument2(string dates)
        {
            var pern = Session["PersonalNumber"].ToString();
            var dates2 = DateTime.Parse(dates);
            var tahun = dates2.Year.ToString();
            var periode = dates2.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
            var minggulalu = dates2.AddDays(-7);
            var periodeLalu= minggulalu.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
            // Create a new Word application
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            //Set status for word application is to be visible or not.  
            wordApp.Visible = false;

            //Create a missing variable for missing value  
            object missing = System.Reflection.Missing.Value;
            #region Chart
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            // Create an Excel chart
            Excel.Worksheet line = null;

            try
            {
                LapMDataModel obj = new LapMDataModel();

                obj.tanggal = DateTime.Parse(dates);

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LapMProgressH";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var ProgressH = JsonConvert.DeserializeObject<LapMProgressHModel>(result);

                HttpClient client2 = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LapMProTimesSeries";
                Uri baseAddress2 = new Uri(url);
                client2.BaseAddress = baseAddress2;
                client2.DefaultRequestHeaders.Accept.Clear();
                var response2 = client2.PostAsJsonAsync(baseAddress2.ToString(), obj).Result;
                var result2 = response2.Content.ReadAsStringAsync().Result;
                var TSeries = JsonConvert.DeserializeObject<List<LapMTSeriesModel>>(result2);

                HttpClient client3 = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LapMCapaian";
                Uri baseAddress3 = new Uri(url);
                client3.BaseAddress = baseAddress3;
                client3.DefaultRequestHeaders.Accept.Clear();
                var response3 = client3.PostAsJsonAsync(baseAddress3.ToString(), obj).Result;
                var result3 = response3.Content.ReadAsStringAsync().Result;
                var capaianini = new List<LapMTPencapaian>();
                var capaianlalu = new List<LapMTPencapaian>();
                var capaian = JsonConvert.DeserializeObject<List<LapMTPencapaian>>(result3);
                if (capaian != null)
                {
                    if (capaian.Count > 0)
                    {
                        capaianini = capaian.Where(x => x.Pencapaian != "").ToList();
                        capaianlalu = capaian.Where(x => x.PencapaianLalu != "").ToList();
                    }
                }

                HttpClient client4 = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LapMRealisasiAnggaran";
                Uri baseAddress4 = new Uri(url);
                client4.BaseAddress = baseAddress4;
                client4.DefaultRequestHeaders.Accept.Clear();
                var response4 = client4.PostAsJsonAsync(baseAddress4.ToString(), obj).Result;
                var result4 = response4.Content.ReadAsStringAsync().Result;
                var realisasiAngg = JsonConvert.DeserializeObject<RealisasiAnggaran>(result4);

                HttpClient client5 = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LapMPencapaianMingguan";
                Uri baseAddress5 = new Uri(url);
                client5.BaseAddress = baseAddress5;
                client5.DefaultRequestHeaders.Accept.Clear();
                var response5 = client5.PostAsJsonAsync(baseAddress5.ToString(), obj).Result;
                var result5 = response5.Content.ReadAsStringAsync().Result;
                var capaianM1 = new List<LapMTStatusPerMinggu>();
                var capaianM2 = new List<LapMTStatusPerMinggu>();
                var capaianM3 = new List<LapMTStatusPerMinggu>();
                var capaianM4 = new List<LapMTStatusPerMinggu>();
                var capaianM5 = new List<LapMTStatusPerMinggu>();
                var capaianMingguan = JsonConvert.DeserializeObject<List<LapMTStatusPerMinggu>>(result5);

                doc.Activate(); // Make the document active before applying the theme font
                doc.Content.Font.Name = "Book Antiqua"; // Replace with the desired theme font name

                if (capaianMingguan!=null)
                {
                    if (capaianMingguan.Count>0)
                    {
                        capaianM1 = capaianMingguan.Where(x => x.Minggu == "Minggu 1" & x.Pencapaian != "").ToList();
                        capaianM2 = capaianMingguan.Where(x => x.Minggu == "Minggu 2" & x.Pencapaian2 != "").ToList();
                        capaianM3 = capaianMingguan.Where(x => x.Minggu == "Minggu 3" & x.Pencapaian3 != "").ToList();
                        capaianM4 = capaianMingguan.Where(x => x.Minggu == "Minggu 4" & x.Pencapaian4 != "").ToList();
                        capaianM5 = capaianMingguan.Where(x => x.Minggu == "Minggu 5" & x.Pencapaian5 != "").ToList();  
                    }
                }
  
                    //Get the header range and add the header details.  
                    Word.Paragraph headerRange = doc.Content.Paragraphs.Add();                  
                    headerRange.Range.Font.Size = 12;
                    headerRange.Range.Font.Bold = 1;
                    headerRange.Range.Text = $"Laporan Mingguan Proyek Strategis per {periode}";
                    headerRange.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Range.InsertParagraphAfter();



                Word.Paragraph head1 = doc.Content.Paragraphs.Add();             
                head1.Range.Text = $"1. Progress Proyek Strategis Tahun {tahun}";
                head1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                head1.Range.InsertParagraphAfter();

                Word.Paragraph para1 = doc.Content.Paragraphs.Add();
                para1.Range.Text = $"a. Progress Proyek Strategis Lembaga Tahun {tahun}, adalah sebagai berikut:";
                para1.Format.LeftIndent = wordApp.InchesToPoints(0.2f);
                para1.Range.InsertParagraphAfter();

                var pTable = doc.Paragraphs.Add();
                pTable.Format.SpaceAfter = 10f;

                // Add a table to the document
                int numRows = 2;
                int numColumns = 5;
                Word.Table table = doc.Tables.Add(pTable.Range, numRows, numColumns, WdDefaultTableBehavior.wdWord9TableBehavior);

                // Set table properties
                table.Borders.Enable = 1; // Enable table borders
                table.Rows.Height = wordApp.InchesToPoints(0.3f); // Set row height

                // Add content to the table cells
                for (int row = 1; row <= numRows; row++)
                {
                    if (row == 1)
                    {
                        for (int col = 1; col <= numColumns; col++)
                        {
                            Word.Cell cell = table.Cell(row, col).Range.Cells[1];
                            string cellText = $"";
                            if (col == 1)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                                cell.Width = 100;
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                cellText = "Periode";
                            }
                            else if (col == 2)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                cellText = "Target";
                            }
                            else if (col == 3)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                cellText = "Realisasi";
                            }
                            else if (col == 4)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                cellText = "Pencapaian Minggu ini";
                            }
                            else
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                cellText = "Pencapaian Minggu lalu";
                            }
                            cell.Range.Text = cellText;
                            // Format header cells with bold
                            cell.Range.Font.Bold = 1;
                        }
                    }
                    else
                    {
                        for (int col = 1; col <= numColumns; col++)
                        {
                            Word.Cell cell = table.Cell(row, col).Range.Cells[1];
                            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            string cellText = $"";
                            if (ProgressH!=null)
                            {
                                if (col == 1)
                                {
                                    cell.Width = 100;
                                    cellText = periode;
                                }
                                else if (col == 2)
                                {
                                    cellText = string.Format("{0:N2}", ProgressH.Target) + " %";
                                }
                                else if (col == 3)
                                {
                                    cellText = string.Format("{0:N2}", ProgressH.Realisasi) + " %";
                                }
                                else if (col == 4)
                                {
                                    cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                                    cell.Range.Font.Color = Word.WdColor.wdColorWhite;
                                    cellText = string.Format("{0:N2}", ProgressH.Pencapaian) + " %";
                                }
                                else
                                {
                                    cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                                    cell.Range.Font.Color = Word.WdColor.wdColorWhite;
                                    cellText = string.Format("{0:N2}", ProgressH.PencapaianLalu) + " %";
                                }
                            }
                            else
                            {
                                cellText = "0";
                            }
                            cell.Range.Text = cellText;
                        }
                    }
                }

                //Part b
                Word.Paragraph para2 = doc.Content.Paragraphs.Add();
                para2.Range.Text = "b. Perkembangan Progress Proyek Strategis Lembaga Tahun " + tahun + " dari awal tahun sampai dengan sekarang dapat dilihat dari grafik dibawah ini:";
                para2.Format.LeftIndent = wordApp.InchesToPoints(0.2f);
                para2.Range.InsertParagraphAfter();

                // Create a new Excel application
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();


                #region Chart Line

                worksheet = workbook.ActiveSheet;

                worksheet.Cells[1, 1].Value = "Periode";
                worksheet.Cells[1, 2].Value = "Target";
                worksheet.Cells[1, 3].Value = "Realisasi";
                var n = 2;
                foreach (var list in TSeries)
                {
                    worksheet.Cells[n, 1].Value = list.Minggu;
                    worksheet.Cells[n, 2].Value = list.Target;
                    worksheet.Cells[n, 3].Value = list.Realisasi;
                    n++;
                }



                Excel.ChartObjects chartObjects = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObject = chartObjects.Add(100, 100, 400, 300);
                Excel.Chart chart2 = chartObject.Chart;

                chart2.ChartType = Excel.XlChartType.xlLine;
                var rg = "B1" + ":" + "C" + n;
                Excel.Range chartRange2 = worksheet.Range[rg];
                // Excel.Range chartRange2 = worksheet.Range["A1:C3"];
                chart2.SetSourceData(chartRange2);

                // Get the category axis (X-axis)
                Excel.Axis categoryAxis = chart2.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);

                // Format axis labels at a 45-degree angle
                categoryAxis.TickLabels.Orientation = (Excel.XlTickLabelOrientation)45; // 45 degrees angle
                categoryAxis.TickLabels.Font.Size = 6;
                categoryAxis.TickLabelSpacing = 1;

                // Set axis scale to display all data
                //Excel.Axis valueAxis = chart2.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlSecondary);
                //categoryAxis.MinimumScale = 0; // Adjust as needed
                //categoryAxis.MaximumScale = 40; // Adjust as needed

                Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)chart2.SeriesCollection();
                Excel.Series seriesA = seriesCollection.Item(1);
                Excel.Series seriesB = seriesCollection.Item(2);

                seriesA.Name = "Target";
                seriesB.Name = "Realisasi";

                seriesA.XValues = worksheet.Range["A2:A" + n];
                seriesA.Values = worksheet.Range["B2:B" + n];

                seriesB.XValues = worksheet.Range["A2:A" + n];
                seriesB.Values = worksheet.Range["C2:C" + n];

                seriesA.Format.Line.Weight = 2;
                seriesB.Format.Line.Weight = 2;

                seriesA.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbBlue;
                seriesB.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbRed;

                // Move the legend to the bottom
                chart2.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;


                chart2.HasTitle = true;
                chart2.ChartTitle.Text = $"Tren Target vs Realisasi Keseluruhan Proyek per Tahun {tahun}";
                chart2.ChartTitle.Font.Size = 12;

                // Export the Excel chart as an image
                //string chartImagePath = @"C:\Path\To\Save\ChartImage.png";
                string chartImagePath2 = Server.MapPath("~/TempFile/Chart/ChartImage2.png");
                chart2.Export(chartImagePath2, "PNG", false);

                // Add the chart image to the Word document
                Word.Paragraph paraLineChart = doc.Content.Paragraphs.Add();
                Word.InlineShape chartShape2 = paraLineChart.Range.InlineShapes.AddPicture(chartImagePath2);
                #endregion
                //Part C
                Word.Paragraph para3 = doc.Content.Paragraphs.Add();
                para3.Range.Text = "c. Apabila dilihat dari detail masing-masing proyek, maka progress penyelesaian pada proyek adalah sebagai berikut:";
                para3.Format.LeftIndent = wordApp.InchesToPoints(0.2f);
                para3.Range.InsertParagraphAfter();

                var pTable2 = doc.Paragraphs.Add();
                pTable2.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                // Add a table to the document
                numRows = 7; // Total number of rows, including header rows
                numColumns = 7;
                table = doc.Tables.Add(pTable2.Range, numRows, numColumns);

                // Set table properties
                table.Borders.Enable = 1; // Enable table borders

                // Merge cells for the nested column header structure

                // Header 1
                table.Cell(1, 1).Range.Text = "No";
                table.Cell(1, 1).Merge(table.Cell(2, 1));
                table.Cell(1, 1).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                float WidthNo = 40f;
                float WidthNo2 = 100f;
                table.Cell(1, 1).Width = WidthNo;


                // Header 2
                table.Cell(1, 2).Range.Text = "Status";
                table.Cell(1, 2).Merge(table.Cell(2, 2));
                table.Cell(1, 2).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(1, 2).Width = WidthNo2;

                // Header 3
               
                table.Cell(1, 3).Range.Text = periodeLalu;
                table.Cell(1, 3).Merge(table.Cell(1, 4));
                table.Cell(1, 3).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 3).Range.Text = "Jumlah";
                table.Cell(2, 3).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 4).Range.Text = "%";
                table.Cell(2, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


                // Header 4
                table.Cell(1, 4).Range.Text = periode;
                table.Cell(1, 4).Merge(table.Cell(1, 5));
                table.Cell(1, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 5).Range.Text = "Jumlah";
                table.Cell(2, 5).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 6).Range.Text = "%";
                table.Cell(2, 6).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 6).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // Header 5
                int symbolCodetitle = 0x0394; //Delta
                table.Cell(1, 5).Range.Text = char.ConvertFromUtf32(symbolCodetitle);
                table.Cell(1, 5).Merge(table.Cell(2, 7));
                table.Cell(1, 5).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                table.Cell(7, 1).Range.Text = "Total";
                table.Cell(7, 1).Merge(table.Cell(7, 2));
                table.Cell(7, 1).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(7, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


                //get ammount perstatus
                double totalini = capaianini.Count();
                double merahini = capaianini.Where(x => x.Pencapaian == "merah").Count();
                double percentmerahini = 0;
                double kuningini = capaianini.Where(x => x.Pencapaian == "kuning").Count();
                double percentkuningini = 0;
                double biruini = capaianini.Where(x => x.Pencapaian == "biru").Count();
                double percentbiruini = 0;
                double hijauini = capaianini.Where(x => x.Pencapaian == "hijau").Count();
                double percenthijauini = 0;
                if (totalini != 0)
                {
                    percentmerahini = (merahini / totalini) * 100;
                    percentkuningini = (kuningini / totalini) * 100;
                    percentbiruini = (biruini / totalini) * 100;
                    percenthijauini = (hijauini / totalini) * 100;
                }
                double totallalu = capaianlalu.Count();
                double merahlalu = capaianlalu.Where(x => x.PencapaianLalu == "merah").Count();
                double percentmerahlalu = 0;
                double kuninglalu = capaianlalu.Where(x => x.PencapaianLalu == "kuning").Count();
                double percentkuninglalu = 0;
                double birulalu = capaianlalu.Where(x => x.PencapaianLalu == "biru").Count();
                double percentbirulalu = 0;
                double hijaulalu = capaianlalu.Where(x => x.PencapaianLalu == "hijau").Count();
                double percenthijaulalu = 0;
                if (totallalu != 0)
                {
                    percentmerahlalu = (merahlalu / totallalu) * 100;
                    percentkuninglalu = (kuninglalu / totallalu) * 100;
                    percentbirulalu = (birulalu / totallalu) * 100;
                    percenthijaulalu = (hijaulalu / totallalu) * 100;
                }
                // Set text for remaining cells
                for (int row = 3; row <= numRows - 1; row++)
                {
                    for (int col = 1; col <= numColumns; col++)
                    {
                        Word.Cell cell = table.Cell(row, col);
                        cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        string cellText = $"";
                        if (col == 2)
                        {
                            cell.Width = WidthNo2;
                            if (row == 3)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorRed;
                                cellText = "";
                            }
                            else if (row == 4)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
                                cellText = "";
                            }
                            else if (row == 5)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGreen;
                                cellText = "";
                            }
                            else if (row == 6)
                            {
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorBlue;
                                cellText = "";
                            }
                        }
                        else if (col == 3)
                        {
                            if (row == 3)
                            {
                                cellText = merahlalu.ToString();
                            }
                            else if (row == 4)
                            {
                                cellText = kuninglalu.ToString();
                            }
                            else if (row == 5)
                            {
                                cellText = hijaulalu.ToString();
                            }
                            else if (row == 6)
                            {
                                cellText = birulalu.ToString(); 
                            }
                        }
                        else if (col == 4)
                        {
                            if (row == 3)
                            {
                                cellText = string.Format("{0:N2}%", percentmerahlalu);
                            }
                            else if (row == 4)
                            {
                                cellText = string.Format("{0:N2}%", percentkuninglalu); 
                            }
                            else if (row == 5)
                            {
                                cellText = string.Format("{0:N2}%", percenthijaulalu); 
                            }
                            else if (row == 6)
                            {
                                cellText = string.Format("{0:N2}%", percentbirulalu);
                            }
                        }
                        else if (col == 5)
                        {
                            if (row == 3)
                            {
                                cellText = merahini.ToString();
                            }
                            else if (row == 4)
                            {
                                cellText = kuningini.ToString();
                            }
                            else if (row == 5)
                            {
                                cellText = hijauini.ToString();
                            }
                            else if (row == 6)
                            {
                                cellText = biruini.ToString(); 
                            }
                        }
                        else if (col == 6)
                        {
                            if (row == 3)
                            {
                                cellText = string.Format("{0:N2}%", percentmerahini);
                            }
                            else if (row == 4)
                            {
                                cellText = string.Format("{0:N2}%", percentkuningini); 
                            }
                            else if (row == 5)
                            {
                                cellText = string.Format("{0:N2}%", percenthijauini); 
                            }
                            else if (row == 6)
                            {
                                cellText = string.Format("{0:N2}%", percentbiruini);
                            }
                        }
                        else if(col== 7)
                        {
                            if (row == 3)
                            {
                                var jml = merahini - merahlalu;
                                var strjml = "";
                                if(jml < 0) {
                                    strjml = "(" + jml*-1 + ")";
                                }
                                else if (jml > 0)
                                {
                                    strjml = jml.ToString();
                                }
                                else
                                {
                                    strjml = "-";
                                }
                                cellText = strjml;
                            }
                            else if (row == 4)
                            {
                                var jml = kuningini - kuninglalu;
                                var strjml = "";
                                if (jml < 0)
                                {
                                    strjml = "(" + jml*-1 + ")";
                                }
                                else if (jml > 0)
                                {
                                    strjml = jml.ToString();
                                }
                                else
                                {
                                    strjml = "-";
                                }
                                cellText = strjml;
                            }
                            else if (row == 5)
                            {
                                var jml = hijauini - hijaulalu;
                                var strjml = "";
                                if (jml < 0)
                                {
                                    strjml = "(" + jml*-1 + ")";
                                }
                                else if (jml > 0)
                                {
                                    strjml = jml.ToString();
                                }
                                else
                                {
                                    strjml = "-";
                                }
                                cellText = strjml;
                            }
                            else if (row == 6)
                            {
                                var jml = biruini - birulalu;
                                var strjml = "";
                                if (jml < 0)
                                {
                                    strjml = "(" + jml*-1 + ")";
                                }
                                else if(jml>0)
                                {
                                    strjml = jml.ToString();
                                }
                                else
                                {
                                    strjml = "-";
                                }
                                cellText = strjml;
                            }                           
                        }
                        if (col == 1)
                        {
                            cell.Width = WidthNo;
                            cell.Range.Text = (row-2).ToString();
                        }
                        else
                        {
                            cell.Range.Text = cellText;
                        }
                    }
                }
                for (int col = 1; col <= numColumns - 1; col++)
                {
                    Word.Cell cell = table.Cell(7, col);
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    string cellText = $"";
                    if (col == 1)
                    {
                        WidthNo = 140f;
                        cell.Width = WidthNo;
                        cellText = "Total";
                    }
                    else if (col == 2)
                    {
                        cellText = totallalu.ToString();
                    }
                    else if (col == 3)
                    {
                        if (totallalu != 0)
                            cellText = "100%";
                        else
                            cellText = "0";
                    }
                    else if (col == 4)
                    {
                        cellText = totalini.ToString();                     
                    }
                    else if (col == 5)
                    {
                        if (totalini != 0)
                            cellText = "100%";
                        else
                            cellText = "0";
                    }
                    else if (col == 6)
                    {
                        cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                    }

                    cell.Range.Text = cellText;
                }

                Word.Paragraph ket = doc.Content.Paragraphs.Add();
                ket.Range.Text = "Keterangan:";
                ket.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                ket.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                ket.Range.InsertParagraphAfter();

                //No 1
                Word.Paragraph parasmall1 = doc.Content.Paragraphs.Add();
                Word.Range range1 = parasmall1.Range;
                range1.Text = "1. Status ";
                Word.Range range2 = parasmall1.Range;
                range2.Start = range1.End;
                range2.Text = "               ";
                range2.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.Red);
                Word.Range range3 = parasmall1.Range;
                range3.Start = range2.End;
                range3.Text = " jika pencapaian <85% dari targetnya";
                range3.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range3.Font.Color = Word.WdColor.wdColorBlack;
                parasmall1.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                parasmall1.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
                parasmall1.Range.InsertParagraphAfter();
                //No 2
                Word.Paragraph parasmall2 = doc.Content.Paragraphs.Add();
                Word.Range range1r2 = parasmall2.Range;
                //range1r2.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                range1r2.Text = "2. Status ";
                range1r2.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range1r2.Font.Color = Word.WdColor.wdColorBlack;
                
                Word.Range range2r2 = parasmall2.Range;
                range2r2.Start = range1r2.End;
                range2r2.Text = "               ";
                range2r2.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.Yellow);
              
                Word.Range range3r2 = parasmall2.Range;            
                range3r2.Start = range2r2.End;
                //range3r2.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                range3r2.Text = " jika pencapaian >=85% dan <100% dari targetnya";
                range3r2.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range3r2.Font.Color = Word.WdColor.wdColorBlack;
                parasmall2.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                parasmall2.Range.InsertParagraphAfter();
                //No 3
                Word.Paragraph parasmall3 = doc.Content.Paragraphs.Add();
                Word.Range range1r3 = parasmall3.Range;
                range1r3.Text = "3. Status ";
                range1r3.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range1r3.Font.Color = Word.WdColor.wdColorBlack;
                Word.Range range2r3 = parasmall3.Range;
                range2r3.Start = range1r3.End;
                range2r3.Text = "               ";
                range2r3.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.Green);
                Word.Range range3r3 = parasmall3.Range;
                range3r3.Start = range2r3.End;
                range3r3.Text = " jika pencapaian >=100% dan <110% dari targetnya";
                range3r3.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range3r3.Font.Color = Word.WdColor.wdColorBlack;
                parasmall3.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                parasmall3.Range.InsertParagraphAfter();
                //No 4
                Word.Paragraph parasmall4 = doc.Content.Paragraphs.Add();
                Word.Range range1r4 = parasmall4.Range;
                range1r4.Text = "4. Status ";
                range1r4.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range1r4.Font.Color = Word.WdColor.wdColorBlack;
                Word.Range range2r4 = parasmall4.Range;
                range2r4.Start = range1r4.End;
                range2r4.Text = "               ";
                range2r4.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.Blue);
                Word.Range range3r4 = parasmall4.Range;
                range3r4.Start = range2r4.End;
                range3r4.Text = " jika pencapaian >=110% dari targetnya";
                range3r4.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                range3r4.Font.Color = Word.WdColor.wdColorBlack;
                parasmall4.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                parasmall4.Range.InsertParagraphAfter();

                Word.Paragraph para4 = doc.Content.Paragraphs.Add();
                var wrdproyekchange = "tidak terdapat perubahan status proyek";
                if(merahini!=merahlalu | kuningini!=kuninglalu | hijauini!=hijaulalu | biruini != birulalu)
                {
                    wrdproyekchange = "terdapat perubahan status proyek";
                }
                para4.Range.Text = $"Progres Proyek diminggu ini {wrdproyekchange} dari minggu sebelumnya. Perkembangan status proyek strategis per minggu dapat dilihat pada grafik dibawah ini:";
                para4.Range.Font.Color = Word.WdColor.wdColorBlack;
                para4.Range.Font.Shading.BackgroundPatternColor = (WdColor)ColorTranslator.ToOle(System.Drawing.Color.White);
                para4.Format.LeftIndent = wordApp.InchesToPoints(0.4f);
                para4.Range.InsertParagraphAfter();



                #region Chart Bar
                worksheet = workbook.ActiveSheet;
                worksheet.Cells[1, 1].Value = "Period";
                worksheet.Cells[1, 2].Value = "Merah";
                worksheet.Cells[1, 3].Value = "Kuning";
                worksheet.Cells[1, 4].Value = "Hijau";
                worksheet.Cells[1, 5].Value = "Biru";
                var c = 2;
                if (capaianM1 != null & capaianM1.Count>0)
                {
                    double total = capaianM1.Count();
                    if (total == 0) { total = 1; }
                    double amt = capaianM1.Where(x => x.Pencapaian == "merah").Count();
                    double prc = (amt / total) * 100;  
                    worksheet.Cells[c, 1].Value = capaianM1[0].Keterangan;
                    worksheet.Cells[c, 2].Value = prc;
                    amt = capaianM1.Where(x => x.Pencapaian == "kuning").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 3].Value = prc;
                    amt = capaianM1.Where(x => x.Pencapaian == "hijau").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 4].Value = prc;
                    amt = capaianM1.Where(x => x.Pencapaian == "biru").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 5].Value = prc;
                }
                else
                {
                    worksheet.Cells[c, 1].Value = "";
                    worksheet.Cells[c, 2].Value = 0;
                    worksheet.Cells[c, 3].Value = 0;
                    worksheet.Cells[c, 4].Value = 0;
                    worksheet.Cells[c, 5].Value = 0;
                }
                c++;
                if (capaianM2 != null & capaianM2.Count > 0)
                {
                    double total = capaianM2.Count();
                    if (total == 0) { total = 1; }
                    double amt = capaianM2.Where(x => x.Pencapaian2 == "merah").Count();
                    double prc = (amt / total) * 100;
                    worksheet.Cells[c, 1].Value = capaianM2[0].Keterangan;
                    worksheet.Cells[c, 2].Value = prc;
                    amt = capaianM2.Where(x => x.Pencapaian2 == "kuning").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 3].Value = prc;
                    amt = capaianM2.Where(x => x.Pencapaian2 == "hijau").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 4].Value = prc;
                    amt = capaianM2.Where(x => x.Pencapaian2 == "biru").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 5].Value = prc;
                }
                else
                {
                    worksheet.Cells[c, 1].Value = "";
                    worksheet.Cells[c, 2].Value = 0;
                    worksheet.Cells[c, 3].Value = 0;
                    worksheet.Cells[c, 4].Value = 0;
                    worksheet.Cells[c, 5].Value = 0;
                }
                c++;
                if (capaianM3 != null & capaianM3.Count > 0)
                {
                    double total = capaianM3.Count();
                    if (total == 0) { total = 1; }
                    double amt = capaianM3.Where(x => x.Pencapaian3 == "merah").Count();
                    double prc = (amt / total) * 100;
                    worksheet.Cells[c, 1].Value = capaianM3[0].Keterangan;
                    worksheet.Cells[c, 2].Value = prc;
                    amt = capaianM3.Where(x => x.Pencapaian3 == "kuning").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 3].Value = prc;
                    amt = capaianM3.Where(x => x.Pencapaian3 == "hijau").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 4].Value = prc;
                    amt = capaianM3.Where(x => x.Pencapaian3 == "biru").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 5].Value = prc;
                }
                else
                {
                    worksheet.Cells[c, 1].Value = "";
                    worksheet.Cells[c, 2].Value = 0;
                    worksheet.Cells[c, 3].Value = 0;
                    worksheet.Cells[c, 4].Value = 0;
                    worksheet.Cells[c, 5].Value = 0;
                }
                c++;
                if (capaianM4 != null & capaianM4.Count > 0)
                {
                    double total = capaianM4.Count();
                    if (total == 0) { total = 1; }
                    double amt = capaianM4.Where(x => x.Pencapaian4 == "merah").Count();
                    double prc = (amt / total) * 100;
                    worksheet.Cells[c, 1].Value = capaianM4[0].Keterangan;
                    worksheet.Cells[c, 2].Value = prc;
                    amt = capaianM4.Where(x => x.Pencapaian4 == "kuning").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 3].Value = prc;
                    amt = capaianM4.Where(x => x.Pencapaian4 == "hijau").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 4].Value = prc;
                    amt = capaianM4.Where(x => x.Pencapaian4 == "biru").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 5].Value = prc;
                }
                else
                {
                    worksheet.Cells[c, 1].Value = "";
                    worksheet.Cells[c, 2].Value = 0;
                    worksheet.Cells[c, 3].Value = 0;
                    worksheet.Cells[c, 4].Value = 0;
                    worksheet.Cells[c, 5].Value = 0;
                }
                c++;
                if (capaianM5 != null & capaianM5.Count > 0)
                {
                    double total = capaianM5.Count();
                    if (total == 0) { total = 1; }
                    double amt = capaianM5.Where(x => x.Pencapaian5 == "merah").Count();
                    double prc = (amt / total) * 100;
                    worksheet.Cells[c, 1].Value = capaianM5[0].Keterangan;
                    worksheet.Cells[c, 2].Value = prc;
                    amt = capaianM5.Where(x => x.Pencapaian5 == "kuning").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 3].Value = prc;
                    amt = capaianM5.Where(x => x.Pencapaian5 == "hijau").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 4].Value = prc;
                    amt = capaianM5.Where(x => x.Pencapaian5 == "biru").Count();
                    prc = (amt / total) * 100;
                    worksheet.Cells[c, 5].Value = prc;
                }
                else
                {
                    worksheet.Cells[c, 1].Value = "";
                    worksheet.Cells[c, 2].Value = 0;
                    worksheet.Cells[c, 3].Value = 0;
                    worksheet.Cells[c, 4].Value = 0;
                    worksheet.Cells[c, 5].Value = 0;
                }


                Excel.ChartObjects chartObjects2 = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObject2 = chartObjects2.Add(100, 100, 400, 300);
                Excel.Chart chart = chartObject.Chart;

                chart.ChartType = Excel.XlChartType.xlColumnClustered;

                Excel.Range dataRange = worksheet.Range["A1:E5"];
                chart.SetSourceData(dataRange);

                // Get the category axis (X-axis)
                Excel.Axis categoryAxis2 = chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);

                // Format axis labels at a 45-degree angle
                categoryAxis2.TickLabels.Orientation = (Excel.XlTickLabelOrientation)45; // 45 degrees angle
                categoryAxis2.TickLabels.Font.Size = 12;

                Excel.SeriesCollection seriesCollection2 = (Excel.SeriesCollection)chart.SeriesCollection();
                Excel.Series series1 = seriesCollection2.Item(1);
                Excel.Series series2 = seriesCollection2.Item(2);
                Excel.Series series3 = seriesCollection2.Item(3);
                Excel.Series series4 = seriesCollection2.Item(4);

                series1.Name = "< 85%";
                series2.Name = ">=85 & <100";
                series3.Name = ">=100 & <110";
                series4.Name = ">= 110";
                chart.Legend.Delete();

                chart.HasTitle = true;
                chart.ChartTitle.Text = $"Status Proyek Strategis per Minggu";
                chart.ChartTitle.Font.Size = 12;

                series1.XValues = worksheet.Range["A2:A6"];
                series1.Values = worksheet.Range["B2:B6"];
                series2.XValues = worksheet.Range["A2:A6"];
                series2.Values = worksheet.Range["C2:C6"];
                series3.XValues = worksheet.Range["A2:A6"];
                series3.Values = worksheet.Range["D2:D6"];
                series4.XValues = worksheet.Range["A2:A6"];
                series4.Values = worksheet.Range["E2:E6"];

                series1.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbRed;
                series2.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbYellow;
                series3.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbGreen;
                series4.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbBlue;

                
                // Export the Excel chart as an image
                //string chartImagePath = @"C:\Path\To\Save\ChartImage.png";
                string chartImagePath = Server.MapPath("~/TempFile/Chart/ChartImage.png");
                chart.Export(chartImagePath, "PNG", false);

                // Add the chart image to the Word document
                Word.Paragraph para = doc.Content.Paragraphs.Add();
                Word.InlineShape chartShape = para.Range.InlineShapes.AddPicture(chartImagePath);
                #endregion

                //Part D
                Word.Paragraph para5 = doc.Content.Paragraphs.Add();
                para5.Range.Text = $"d. Progress realisasi anggaran seluruh proyek Strategis tahun {tahun} sebagai berikut:";
                para5.Format.LeftIndent = wordApp.InchesToPoints(0.2f);
                para5.Range.InsertParagraphAfter();

                var pTable3 = doc.Paragraphs.Add();
                pTable3.Format.SpaceAfter = 10f;
                // Add a table to the document
                numRows = 3; // Total number of rows, including header rows
                numColumns = 5;
                table = doc.Tables.Add(pTable3.Range, numRows, numColumns);

                // Set table properties
                table.Borders.Enable = 1; // Enable table borders

                // Merge cells for the nested column header structure
                WidthNo = 130f;
                // Header 1
                table.Cell(1, 1).Range.Text = "Total Anggaran";
                table.Cell(1, 1).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 1).Merge(table.Cell(2, 1));
                table.Cell(1, 1).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // Header 2
                table.Cell(1, 2).Range.Text = "Estimasi Realisasi";
                table.Cell(1, 2).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 2).Merge(table.Cell(1, 4));
                table.Cell(1, 2).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 2).Range.Text = "Realisasi";
                table.Cell(2, 2).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 2).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 3).Range.Text = "Komitmen";
                table.Cell(2, 3).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 3).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(2, 4).Range.Text = "Jumlah";
                table.Cell(2, 4).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // Header 3
                table.Cell(1, 3).Range.Text = "%";
                table.Cell(1, 3).Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 3).Merge(table.Cell(2, 5));
                table.Cell(1, 3).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                table.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                for (int col = 1; col <= numColumns; col++)
                {
                    Word.Cell cell = table.Cell(3, col);
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cell.Range.Font.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                    string cellText = $"";
                    if (col == 1)
                    {
                        cellText = realisasiAngg.Anggaran.ToString("c0", CultureInfo.GetCultureInfo("id-ID"));
                    }
                    else if (col == 2)
                    {
                        cellText = realisasiAngg.Realisasi.ToString("c0", CultureInfo.GetCultureInfo("id-ID"));
                    }
                    else if (col == 3)
                    {
                        cellText = realisasiAngg.KomitAnggaran.ToString("c0", CultureInfo.GetCultureInfo("id-ID"));
                    }
                    else if (col == 4)
                    {
                        cellText = realisasiAngg.Jumlah.ToString("c0", CultureInfo.GetCultureInfo("id-ID"));
                    }
                    else if (col == 5)
                    {
                        cellText = realisasiAngg.Persentase.ToString("0.00") + "%";
                    }
                    cell.Range.Text = cellText;
                }
                table.Cell(1, 1).Width = WidthNo;
                table.Cell(3, 1).Width = WidthNo;


                // Close the workbook and release the COM objects
                workbook.Close(false);
                Marshal.ReleaseComObject(workbook);
                workbook = null;

                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
                excelApp = null;


                #endregion

                // Save the document
                string fileTempFolder = Server.MapPath("~/TempFile/");
                string tempFile = Path.Combine(fileTempFolder, "LM_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_temp" + ".docx");

                doc.SaveAs2(tempFile);

                // Close the document and the Word application
                doc.Close();
                wordApp.Quit();


                // Return a FileResult so the user can download the document
                byte[] fileBytes = System.IO.File.ReadAllBytes(tempFile);
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Laporan Mingguan "+periode+".docx");

                // Rest of the code to generate the Word document
            }
            catch (Exception ex)
            {
                ErrLogModel obj = new ErrLogModel();
                obj.Modul = "LaporanM";
                obj.Code = "1";
                obj.Description = ex.ToString() + " | ineer :"+ ex.InnerException;
                obj.CreateUser = pern;
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ErrorLogInsert";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                // Handle exceptions
                Response.Redirect("../LaporanM/NotFound");
                return ex.ToString();
            }
            finally
            {
                // Clean up the remaining COM objects
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (line != null)
                {
                    Marshal.ReleaseComObject(line);
                    line = null;
                }

                // Final garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            // Create an Excel chart

        }


    }
}