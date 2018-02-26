using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Resources;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using QiHe.CodeLib;
using QiHe.Office.CompoundDocumentFormat;
using QiHe.Office.Excel;
//using CarlosAg.ExcelXmlWriter;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Contract
{
    #region Config
    public enum ReportEnum
    { Undefined = 0
    , Excel     = 1
    , CSV       = 2 
    , Pdf       = 3
    }
    public enum DataType
    {
        NotSet = 0,
        String = 1,
        Number = 2,
        DateTime = 3,
        Boolean = 4,
        Integer = 5,
        Error = 999,
    }
    public class ReportConfig
    {
        public const string EXCEL = "EXCEL";
        public const string CSV = "CSV";
        public const string PDF = "PDF";


        public string EnumtToConst(ReportEnum value)
        {
            switch (value)
            {
                case ReportEnum.Excel: return EXCEL;
                case ReportEnum.CSV: return CSV;
                case ReportEnum.Pdf: return PDF;
                case ReportEnum.Undefined: return "";
                default: return "";
            }
        }
        public ReportEnum ConstToEnum(string value)
        {
            switch (value)
            {
                case EXCEL: return ReportEnum.Excel;
                case CSV:   return ReportEnum.CSV;
                case PDF:   return ReportEnum.Pdf;
                default:    return ReportEnum.Undefined; 
            }
        }
    }
    #endregion

    public class IOHelper
    { 
        
        public static Stream ToExcel<T>(List<T> list, DataTableMapping mapping ) where T:class, new()
        {
            DataTable dataTable = DataHelper.ToDataTable<T>(list, mapping);
            
            MemoryStream stream = new MemoryStream();
            Writer writer = WriterManager.Current.GetWriter(ReportEnum.Excel, stream);
            writer.Write(dataTable);

            return stream;        
        }
    
    }


    public class WriterManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static WriterManager current;
        public static WriterManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new WriterManager();
                    }
                return current;
            }
        }
        #endregion
        public static Writer Get(ReportEnum reportEnum, Stream stream)
        {
            return WriterManager.Current.GetWriter(reportEnum, stream);
        }
        public Writer GetWriter(ReportEnum reportEnum, Stream stream)
        {
            switch (reportEnum)
            {
                case ReportEnum.CSV: return new WriterCSV(stream);
                case ReportEnum.Excel: return new WriterEXCELEPplus(stream);
                case ReportEnum.Pdf: return new WriterPDF(stream); 
            }
            return null;
        }
    }
    public abstract class Writer : IDisposable
    { 
        private Stream stream;
        private StreamWriter streamWriter;
        
        public Stream Stream
        {
          get { 
              if(this.stream==null)
                  this.stream= new MemoryStream();
              return stream; }
          set { stream = value; }
        }
        public StreamWriter StreamWriter
        {
          get {
              if (this.streamWriter == null)
                  this.streamWriter = new StreamWriter(this.Stream, System.Text.Encoding.UTF8);
              return streamWriter;
          }
            set { streamWriter = value; }
        }

        public abstract void Write(DataTable dataSource);

        #region Dispose
        private bool IsDisposed = false;

       public void Free()
       {
         if (IsDisposed)
                  throw new System.ObjectDisposedException("Object Name");
       }
       //Call Dispose to free resources explicitly
       public void Dispose()
       {
         //Pass true in dispose method to clean managed resources too and say GC to skip finalize
         //in next line.
         Dispose(true);
         //If dispose is called already then say GC to skip finalize on this instance.
         GC.SuppressFinalize(this);
       }
       ~Writer()
       {
         //Pass false as param because no need to free managed resources when you call finalize it
         //will be done
         //by GC itself as its work of finalize to manage managed resources.
         Dispose(false);
       }
       //Implement dispose to free resources
       protected virtual void Dispose(bool disposedStatus)
       {
         if (!IsDisposed)
         {             
             IsDisposed = true;             
             if (disposedStatus)
             {
                 this._Dispose();
             }
         }
       }
       protected virtual void _Dispose()
       {
           this.streamWriter.Dispose();
           //this.Stream.Dispose();
       }
       #endregion
    }
    public class WriterCSV : Writer
    {
        public WriterCSV(Stream stream)
        {
            this.Stream= stream;
        }
        public override void Write(DataTable dataSource)
        {
            //trabajo con header
            int colCount = dataSource.Columns.Count;
            bool[] columnsIsString = new bool[colCount];
            foreach (DataColumn dataColumn in dataSource.Columns)
            {
                 //this.StreamWriter.Write(("\"" + (dataColumn.ColumnName.Replace("\"", "\"\"") + "\",")));
                 this.StreamWriter.Write(dataColumn.ColumnName + ",");
            }               
            this.StreamWriter.WriteLine();
            int i = 1;
            foreach (DataRow datarow in dataSource.Rows)
            {
                foreach (DataColumn dataColumn in dataSource.Columns)
                {
                    string value = datarow[dataColumn].ToString();
                    //if (dataColumn.DataType.FullName == "System.String")
                    //    this.StreamWriter.Write(("\"" + (value.Replace("\"", "\"\"") + "\",")));
                    //else
                        this.StreamWriter.Write((value + ","));
                }
                i++;
            }
            this.StreamWriter.Flush();
        }
    }
    #region Excel
    public class WriterEXCEL : Writer
    {
        public WriterEXCEL(Stream stream)
        {
            this.Stream = stream;
        }
        public override void Write(DataTable dataSource)
        {            
            QiHe.Office.Excel.Workbook workbook = new QiHe.Office.Excel.Workbook();
            QiHe.Office.Excel.Worksheet worksheet = new QiHe.Office.Excel.Worksheet(dataSource.TableName);
                        
            foreach (DataColumn dataColumn in dataSource.Columns)
            {
                worksheet.Cells[0, dataColumn.Ordinal] = new QiHe.Office.Excel.Cell(dataColumn.ColumnName);
            }
            int i = 1;
            foreach (DataRow datarow in dataSource.Rows)
            {
                foreach (DataColumn dataColumn in dataSource.Columns)
                {
                    worksheet.Cells[i, dataColumn.Ordinal] = new QiHe.Office.Excel.Cell(datarow[dataColumn].ToString());
                }
                i++;
            }
            workbook.Worksheets.Add(worksheet);
            workbook.Save(this.Stream);
        }        
        protected override void _Dispose()
        {            
        }
    }
    public class WriterEXCELEPplus : Writer
    {
        public WriterEXCELEPplus(Stream stream)
        {
            this.Stream = stream;
        }
        public override void Write(DataTable dataSource)
        {    
            using (ExcelPackage package = new ExcelPackage(this.Stream))
            {
                var excelBook = package.Workbook;
                excelBook.Properties.Title = dataSource.TableName;
                excelBook.Properties.Created = DateTime.Now;
                excelBook.Properties.Author = "Ingematica";

                var excelSheet = excelBook.Worksheets.Add("Sheet1");
                excelSheet.View.FreezePanes(2,1);

                //Add a HyperLink to the statistics sheet. 
                var excelHeaderStyle = package.Workbook.Styles.CreateNamedStyle("HeaderRowStyle");
                excelHeaderStyle.Style.Font.Bold = true;
                excelHeaderStyle.Style.Font.Name = "Verdana";
                excelHeaderStyle.Style.Font.Size = 8;
                excelHeaderStyle.Style.Font.Bold = true;
                excelHeaderStyle.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                excelHeaderStyle.Style.Fill.PatternType = ExcelFillStyle.Solid;
                excelHeaderStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);

                var excelRowStyle = package.Workbook.Styles.CreateNamedStyle("RowStyle");
                excelRowStyle.Style.Font.Bold = false;
                excelRowStyle.Style.Font.Name = "Verdana";
                excelRowStyle.Style.Font.Size = 8;
                excelRowStyle.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                excelRowStyle.Style.Fill.PatternType = ExcelFillStyle.Solid;
                excelRowStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);

                //trabajo con header
                int colCount = dataSource.Columns.Count;
                Dictionary<string, DataType> columnsType = new Dictionary<string, DataType>(colCount);
                int i = 0;
                foreach (DataColumn dataColumn in dataSource.Columns)
                {
                    i++;
                    columnsType.Add(dataColumn.ColumnName, ExcelDataType(dataColumn));
                    excelSheet.Cells[1,i].StyleName = "HeaderRowStyle";
                    excelSheet.Cells[1,i].Value = dataColumn.ColumnName;
                    excelSheet.Column(i).Width = (int)DataHelper.ColumnSize(dataColumn);
                }
                int r = 1;
                foreach (DataRow datarow in dataSource.Rows)
                {
                    r++;
                    int c = 0;
                    foreach (DataColumn dataColumn in dataSource.Columns)
                    {
                        c++;
                        string value = "";
                        DataType dataType = columnsType[dataColumn.ColumnName];
                        switch (dataType)
                        {
                            case DataType.Boolean:
                                value = datarow[dataColumn].ToString() == "True" ? "1" : "0";
                                break;
                            default:
                                value = datarow[dataColumn].ToString();
                                break;
                        }
                        excelSheet.Cells[r, c].Value = value;
                        excelSheet.Cells[r, c].StyleName = "RowStyle";
                    }
                }
                package.Save();
            }
        }
       
        protected  DataType ExcelDataType(DataColumn dataColumn)
        {
            switch (dataColumn.DataType.FullName)
            {
                case "System.Decimal":
                case "System.Int32":
                    return DataType.Number;
                case "System.DataTime":
                    return DataType.String;//return DataType.DateTime;
                case "System.Boolean":
                      return DataType.Boolean;
                case "System.Object":
                case "System.String":
                    return  DataType.String;
                default: 
                    return DataType.String;//return  DataType.NotSet;
            }
        }



        protected override void _Dispose()
        {            
        }
    }
    public class WriterXMLExcel : Writer
    {
        public WriterXMLExcel(Stream stream)
        {
            this.Stream = stream;
        }
        public override void Write(DataTable dataSource)
        {       
            using (TextWriter tw = new StreamWriter(this.Stream))
            { 
                tw.Write(this.Document(this.Sheet(dataSource.TableName, this.Table(dataSource))));
            }
        }        
        #region Writer
     
        protected string Document(string sheets)
        {
            return string.Format(@"<?xml version=""1.0""?> "
   + @" <?mso-application progid=""Excel.Sheet""?> "
   + @" <Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:o=""urn:schemas-microsoft-com:office:office"" "
   + @" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" "
   + @" xmlns:html=""http://www.w3.org/TR/REC-html40"">"
   + @"<DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">"
   + @"<Author>Flavio Rita</Author>"
   + @"<LastAuthor>frita</LastAuthor>"
   + @"<Created>2010-01-25T16:17:40Z</Created>"
   + @"<LastSaved>2010-01-25T16:17:41Z</LastSaved>"
   + @"<Version>12.00</Version>"
   + @"</DocumentProperties>"
   + @"<ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">"
   + @"<WindowHeight>9780</WindowHeight>"
   + @"<WindowWidth>23955</WindowWidth>"
   + @"<WindowTopX>0</WindowTopX>"
   + @"<WindowTopY>135</WindowTopY>"
   + @"<ProtectStructure>False</ProtectStructure>"
   + @"<ProtectWindows>False</ProtectWindows>"
   + @"</ExcelWorkbook>"
   + @"<Styles>"
   + @"<Style ss:ID=""Default"" ss:Name=""Normal"">"
   + @"<Alignment ss:Vertical=""Bottom"" />"
   + @"<Borders/>"
   + @"<Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>"
   + @"<Interior/>"
   + @"<NumberFormat/>"
   + @"<Protection/>"
   + @"</Style>"
   + @"<Style ss:ID=""s57"">"
   + @"<Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>"
   + @"<Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000"" ss:Bold=""1""/>"
   + @"</Style>"
   + @"<Style ss:ID=""s58"">"
   + @"<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>"
   + @"</Style>"
   + @"</Styles>"
   + @"{0}"
   + @"</Workbook>", sheets);

        }
        protected string Sheet(string name, string content)
        {
            return string.Format(@" <Worksheet ss:Name=""{0}"">"
  + @" <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">"
  + @" <Selected/>"
  + @" <DoNotDisplayGridlines/>"
  + @" <ProtectObjects>False</ProtectObjects>"
  + @" <ProtectScenarios>False</ProtectScenarios>"
  + @" </WorksheetOptions>"
  + @" {1}"
  + @" </Worksheet>", name, content);

        }
        protected string Table(DataTable dataSource)
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append(@" <Table ss:ExpandedColumnCount=""3"" ss:ExpandedRowCount=""5"" x:FullColumns=""1""  x:FullRows=""1"" ss:DefaultRowHeight=""15"">");
            foreach (DataColumn dataColumn in dataSource.Columns)
            {             
              float size = DataHelper.ColumnSize(dataColumn); 
              sb.AppendFormat(@"<Column ss:Width=""{0}""/>",size);
            }
            sb.Append(@"<Row>");
            foreach (DataColumn dataColumn in dataSource.Columns)
            {                
                sb.Append(CellHead(dataColumn));
            }
            sb.Append(@"</Row>");
            foreach (DataRow datarow in dataSource.Rows)
            {
                sb.Append(@"<Row>");
                foreach (DataColumn dataColumn in dataSource.Columns)
                {
                    sb.Append(Cell(dataColumn,datarow[dataColumn].ToString()));
                }
                sb.Append(@"</Row>");
            }
            sb.Append(@"</Table>");
            return sb.ToString();
        }
        protected string CellHead(DataColumn dataColumn)
        {
            return string.Format(@"<Cell ss:StyleID=""s57""><Data ss:Type=""{0}"">{1}</Data></Cell>",ExcelDataType(dataColumn),dataColumn.ColumnName);
        }
        protected string Cell(DataColumn dataColumn,object value)
        {
            return string.Format(@"<Cell ss:StyleID=""s58""><Data ss:Type=""{0}"">{1}</Data></Cell>", value, dataColumn.ColumnName);
        }
        #endregion

        protected string ExcelDataType(DataColumn dataColumn)
        {
            switch (dataColumn.DataType.FullName)
            {
                case "System.Decimal":
                case "System.Int32":
                    return "Number";
                case "System.DataTime":
                    return "DateTime";
                case "System.Boolean":
                    return "Boolean";
                case "System.Object":
                case "System.String":
                    return "String";
                default: return "NotSet";
            }
        }
        
        protected override void _Dispose()
        {
        }
    }         
    #endregion
    #region PDF

    public class WriterPDF : Writer
    {
        public WriterPDF(Stream stream)
        {
            this.Stream = stream;
        }
        public override void Write(DataTable dataSource)
        {
            _PdfWriter pdfWriter = new _PdfWriter();
            pdfWriter.ShowLandscape = true;
            pdfWriter.Write(this.Stream, dataSource);
        }
        protected override void _Dispose()
        {
        }
    }
    #endregion


}
