using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsApp1
{

    public partial class Fatura : Form
    {
        private List<string> pdfFiles;
        private string selectedPath, excelPath;
        Excel.Application excelApp;
        Excel.Workbook wb;
        Excel.Worksheet ws;
        List<FaturaOrnegi> faturalar;
        FaturaOrnegi faturaOrnegi;
        Excel.Range cf;
        object missing = System.Reflection.Missing.Value;

        public Fatura()
        {
            InitializeComponent();
        }


        private void btnExcellYolu_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Dosyayı Kaydetmek İstediğiniz Yeri Seçin";
                sfd.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    excelPath = sfd.FileName;
                    txtExcellYolu.Text = excelPath;
                }
            }

        }

        private void btnFaturaYolu_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pdfFiles = new List<string>(Directory.GetFiles(fbd.SelectedPath, "*.pdf"));
                    txtFaturaYolu.Text = fbd.SelectedPath;
                    selectedPath = fbd.SelectedPath;
                    lstBxFaturalar.Items.Clear();

                    foreach (String file in pdfFiles)
                    {
                        lstBxFaturalar.Items.Add(file.Substring(1 + file.LastIndexOf(@"\")));
                    }
                    int count = pdfFiles.Count;
                    if (count > 0)
                    {
                        txtCount.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        txtCount.ForeColor = System.Drawing.Color.Red;
                    }
                    txtCount.Text = count.ToString();

                }
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (txtFaturaYolu.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Fatura Yolu Seçilmeli", "Message");
                return;

            }
            else if (txtExcellYolu.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Excell Yolu Seçilmeli", "Message");
                return;
            }

            faturalar = new List<FaturaOrnegi>();

            string pathToExcel;
            Directory.CreateDirectory(selectedPath + @"\\Fatura_Excell");
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // This property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            foreach (String file in pdfFiles)
            {
                pathToExcel = ReplaceLastOccurence(file, @"\", @"\Fatura_Excell\");
                pathToExcel = Path.ChangeExtension(pathToExcel, ".xls");
                f.OpenPdf(file);

                if (f.PageCount > 0)
                {
                    int result = f.ToExcel(pathToExcel);

                }
                f.ClosePdf();

            }

            readExcelFiles(Directory.GetFiles(selectedPath + @"\Fatura_Excell", "*.xls"));



        }


        string hesapNo = null, donem = null, kuruluGuc = null, sozlesmeGucu = null, enerjiBedeli = null, enerjiBedeliTuketim = null, enerjiBedeliBirim = null,
            enduktif = null, enduktifTuketim = null, enduktifBirim = null, kapasitif = null, kapasitifTuketim = null, kapasitifBirim = null, vergiNo = null, musteriGrubu;

        private void readExcelFiles(string[] excellFiles)
        {

            foreach (String excelFile in excellFiles)
            {
                try
                {

                    hesapNo = null; donem = null; kuruluGuc = null; sozlesmeGucu = null; enerjiBedeli = null; enerjiBedeliTuketim = null; enerjiBedeliBirim = null;
                    enduktif = null; enduktifTuketim = null; enduktifBirim = null; kapasitif = null; kapasitifTuketim = null; kapasitifBirim = null; vergiNo = null; musteriGrubu = null;
                    if (excelApp == null)
                    {
                        excelApp = new Excel.Application();
                    }

                    faturaOrnegi = new FaturaOrnegi();
                    wb = excelApp.Workbooks.Open(excelFile);
                    ws = wb.Worksheets[1];

                    cf = ws.Range["B4"]; //Hesap no
                    hesapNo = cf.Text;

                    cf = ws.Range["B7"]; //Dönem
                    donem = " " + cf.Text;

                    cf = ws.Range["B9"]; //Müşteri Grubu
                    musteriGrubu = cf.Text;

                    cf = ws.Range["B12"]; //Kurulu Güç
                    kuruluGuc = cf.Text;

                    cf = ws.Range["B13"]; // Sözleşme gücü
                    sozlesmeGucu = cf.Text;

                    string[] tempTuketim, tempBirimFiyat, tempTutar;

                    tempTuketim = ws.Range["B27"].Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    tempBirimFiyat = ws.Range["C27"].Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    tempTutar = ws.Range["D27"].Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    enerjiBedeliTuketim = tempTuketim[0];
                    enerjiBedeliBirim = tempBirimFiyat[0];
                    enerjiBedeli = tempTutar[0];

                    int row;
                    row = searchStringInExcel("İndüktif");

                    if (row > 0)
                    {

                        enduktifTuketim = tempTuketim[2];
                        enduktifBirim = tempBirimFiyat[2];
                        enduktif = tempTutar[2];
                    }
                    /* 
                    row = searchStringInExcel(strKapasitif);

                    if (row > 0)
                    {
                        temp = getValues(row);
                        kapasitifTuketim = temp[0];
                        kapasitifBirim = temp[1];
                        kapasitif = temp[2];
                    }
                    */

                    cf = ws.Range["B49"]; // Vergi No
                    vergiNo = cf.Text;


                    faturaOrnegi.hesapNo = hesapNo;
                    faturaOrnegi.donem = donem;
                    faturaOrnegi.kuruluGuc = kuruluGuc;
                    faturaOrnegi.sozlesmeGucu = sozlesmeGucu;

                    faturaOrnegi.enerjiBedeli = enerjiBedeli;
                    faturaOrnegi.enerjiBedeliBirim = enerjiBedeliBirim;
                    faturaOrnegi.enerjiBedeliTuketim = enerjiBedeliTuketim;


                    faturaOrnegi.enduktif = enduktif;
                    faturaOrnegi.enduktifBirim = enduktifBirim;
                    faturaOrnegi.enduktifTuketim = enduktifTuketim;

                    faturaOrnegi.kapasitif = kapasitif;
                    faturaOrnegi.kapasitifTuketim = kapasitifTuketim;
                    faturaOrnegi.kapasitifBirim = kapasitifBirim;

                    faturaOrnegi.vergiNo = vergiNo;
                    faturaOrnegi.musteriGrubu = musteriGrubu;

                    string pathPDF = ReplaceLastOccurence(excelFile, @"\Fatura_Excell\", @"\");

                    pathPDF = Path.ChangeExtension(pathPDF, ".pdf");

                    faturaOrnegi.faturaYolu = pathPDF;

                    faturalar.Add(faturaOrnegi);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("hata " + ex.Message + " Oluşan dosya");

                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //  Marshal.FinalReleaseComObject(range);
                    if (ws != null)
                    {
                        Marshal.FinalReleaseComObject(ws);


                        wb.Close(false, missing, missing);
                        Marshal.FinalReleaseComObject(wb);
                    }

                }


            }
            // Quit Excel application
            excelApp.Quit();

            // Release COM objects (very important!)
            if (excelApp != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            if (ws != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);

            // Empty variables
            excelApp = null;
            ws = null;

            // Force garbage collector cleaning
            GC.Collect();
            ExportToExcel(faturalar);

        }


        public int searchStringInExcel(string find)
        {
            Excel.Range currentFind = null;

            Excel.Range Fruits = excelApp.get_Range("A1", "E53");
            // You should specify all these parameters every time you call this method,
            // since they can be overridden in the user interface.

            currentFind = Fruits.Find(find, missing, //Toplam Fiyat
                Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
                missing, missing);

            if (currentFind != null)
            {
                return currentFind.Row;
            }
            return 0;

        }


        public static string ReplaceLastOccurence(string originalValue, string occurenceValue, string newValue)
        {
            if (string.IsNullOrEmpty(originalValue))
                return string.Empty;
            if (string.IsNullOrEmpty(occurenceValue))
                return originalValue;
            if (string.IsNullOrEmpty(newValue))
                return originalValue;
            int startindex = originalValue.LastIndexOf(occurenceValue);
            return originalValue.Remove(startindex, occurenceValue.Length).Insert(startindex, newValue);
        }

        public void ExportToExcel(List<FaturaOrnegi> faturas)
        {
            // Load Excel application
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Visible = false;
            Microsoft.Office.Interop.Excel.Range excelCell;
            excel.DisplayAlerts = false;
            // Create empty workbook
            excel.Workbooks.Add();

            // Create Worksheet from active sheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet;

            // I created Application and Worksheet objects before try/catch,
            // so that i can close them in finnaly block.
            // It's IMPORTANT to release these COM objects!!
            try
            {
                // ------------------------------------------------
                // Creation of header cells
                // ------------------------------------------------
                workSheet.Cells[1, "A"] = "Hesap no";
                workSheet.Cells[1, "B"] = "Dönem";
                workSheet.Cells[1, "C"] = "Kurulu Güç";
                workSheet.Cells[1, "D"] = "Sözleşme Gücü";
                workSheet.Cells[1, "E"] = "Enerji Bedeli Tüketim";
                workSheet.Cells[1, "F"] = "Enerji Bedeli Birim Fiyat";
                workSheet.Cells[1, "G"] = "Enerji Bedeli Tutar";

                workSheet.Cells[1, "H"] = "Endüktif Tüketim";
                workSheet.Cells[1, "I"] = "Endüktif Birim Fiyat";
                workSheet.Cells[1, "J"] = "Endüktif Tutar";

                workSheet.Cells[1, "K"] = "Kapasitif Tüketim";
                workSheet.Cells[1, "L"] = "Kapasitif Birim Fiyat";
                workSheet.Cells[1, "M"] = "Kapasitif Tutar";
                workSheet.Cells[1, "N"] = "Vergi No";
                workSheet.Cells[1, "O"] = "Müşteri Grubu";
                workSheet.Cells[1, "P"] = "Dosya Adı";

                // ------------------------------------------------
                // Populate sheet with some real data from "Faturalar" list
                // ------------------------------------------------
                int row = 2; // start row (in row 1 are header cells)
                foreach (FaturaOrnegi fatura in faturas)
                {
                    workSheet.Cells[row, "A"] = fatura.hesapNo;
                    workSheet.Cells[row, "B"] = fatura.donem;
                    workSheet.Cells[row, "C"] = fatura.kuruluGuc;
                    workSheet.Cells[row, "D"] = fatura.sozlesmeGucu;
                    workSheet.Cells[row, "E"] = fatura.enerjiBedeliTuketim;
                    workSheet.Cells[row, "F"] = fatura.enerjiBedeliBirim;
                    workSheet.Cells[row, "G"] = fatura.enerjiBedeli;

                    workSheet.Cells[row, "H"] = fatura.enduktifTuketim;
                    workSheet.Cells[row, "I"] = fatura.enduktifBirim;
                    workSheet.Cells[row, "J"] = fatura.enduktif;

                    workSheet.Cells[row, "K"] = fatura.kapasitifTuketim;
                    workSheet.Cells[row, "L"] = fatura.kapasitifBirim;
                    workSheet.Cells[row, "M"] = fatura.kapasitif;

                    workSheet.Cells[row, "N"] = fatura.vergiNo;
                    workSheet.Cells[row, "O"] = fatura.musteriGrubu;
                    excelCell = (Microsoft.Office.Interop.Excel.Range)workSheet.get_Range(("P" + row), ("P" + row));
                    workSheet.Hyperlinks.Add(excelCell, fatura.faturaYolu, Type.Missing, Type.Missing, fatura.faturaYolu.Substring(1 + fatura.faturaYolu.LastIndexOf(@"\")));

                    row++;
                }

                // Apply some predefined styles for data to look nicely :)
                workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);

                // Save this data as a file
                workSheet.SaveAs(excelPath);

                // Display SUCCESS message
                MessageBox.Show(string.Format("The file '{0}' is saved successfully!", excelPath));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception",
                    "There was a PROBLEM saving Excel file!\n" + exception.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Quit Excel application
                excel.Quit();

                // Release COM objects (very important!)
                if (excel != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

                // Empty variables
                excel = null;
                workSheet = null;

                // Force garbage collector cleaning
                GC.Collect();
            }
        }


    }



    public class FaturaOrnegi
    {
        public string hesapNo { get; set; }
        public string donem { get; set; }
        public string kuruluGuc { get; set; }
        public string sozlesmeGucu { get; set; }
        public string enerjiBedeli { get; set; }
        public string enerjiBedeliTuketim { get; set; }
        public string enerjiBedeliBirim { get; set; }
        public string enduktif { get; set; }
        public string enduktifTuketim { get; set; }
        public string enduktifBirim { get; set; }
        public string kapasitif { get; set; }
        public string kapasitifTuketim { get; set; }
        public string kapasitifBirim { get; set; }
        public string vergiNo { get; set; }
        public string musteriGrubu { get; set; }
        public string faturaYolu { get; set; }

    }

}

