using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Reporting.WebForms;
using rwf = Microsoft.Reporting.WebForms;
using Contract;
using System.Collections.Generic;
using System.IO;


namespace UI.Web
{
    public static class ReportViewerManager
    {

        public static void Setvalue(ReportViewer ReportViewer, ReportInfo ReportInfo)
        {
            ReportViewer.Reset();

            //Matias 20170302 - Ticket #REQ792885 - Error ALEATORIO de apertura de formulario en debbug
            /*  
             * Posible configuracion del reporte ProyectoPrint
             * >> BuildAction = Content
             * Original:
             * >> BuildAction = Embedded Resource
            */
            //Otra opcion: ReportViewer.InteractivityPostBackMode = InteractivityPostBackMode.AlwaysSynchronous; 
            //FinMatias 20170302 - Ticket #REQ792885 - Error ALEATORIO de apertura de formulario en debbug.

            if (ReportInfo == null) return;

            //establece el archivo del reporte
            ReportViewer.LocalReport.ReportPath = "./App_Data/Reports/" + ReportInfo.ReportFileName;
            
            ReportViewer.LocalReport.DataSources.Clear();
            
            //pasa los parametros
            List<rwf.ReportParameter> parameters = new List<rwf.ReportParameter>();
            foreach (ReportInfoParameter parameterInfo in ReportInfo.Parameters)
            {
                if (parameterInfo.Values.Count > 0)
                    parameters.Add(new rwf.ReportParameter(parameterInfo.Name, parameterInfo.Values.ToArray()));
                else
                    parameters.Add(new rwf.ReportParameter(parameterInfo.Name, parameterInfo.Value, parameterInfo.Visible));
            }
            if (parameters.Count > 0)
                ReportViewer.LocalReport.SetParameters(parameters);
            
            //pasa los DataSources
            foreach (ReportInfoDataSource dataSourceInfo in ReportInfo.DataSources)
                ReportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataSourceInfo.Name, dataSourceInfo.Value));
        }
     
        public static void SaveReportExcel(ReportInfo ReportInfo)
        {
            ReportViewer ReportViewer = new ReportViewer();
            Setvalue(ReportViewer, ReportInfo);
            SaveReportExcel(ReportViewer);
        }
        public static void SaveReportExcel(ReportViewer ReportViewer,ReportInfo ReportInfo)
        {
            Setvalue(ReportViewer,ReportInfo);
            SaveReportExcel(ReportViewer);
        }
        public static void SaveReportPDF(ReportInfo ReportInfo)
        {
            ReportViewer ReportViewer = new ReportViewer();
            Setvalue(ReportViewer, ReportInfo);
            SaveReportPDF(ReportViewer);
        }
        public static void SaveReportPDF(ReportViewer ReportViewer, ReportInfo ReportInfo)
        {
            Setvalue(ReportViewer, ReportInfo);
            SaveReportPDF(ReportViewer);
        }
        public static void SaveReportExcel(ReportViewer ReportViewer)
        {
            string reportType = "EXCEL";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            LocalReport localReport = ReportViewer.LocalReport;

            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            MemoryStream stream = new MemoryStream(renderedBytes);

            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/vnd.ms-excel";
            HttpContext.Current.Session["OpenXmlFileName"] = "Reporte.xls";


        }
        public static void SaveReportPDF(ReportViewer ReportViewer)
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "";
            // @"<DeviceInfo><OutputFormat>PDF</OutputFormat><PageWidth>9in</PageWidth><PageHeight>11.5in</PageHeight><MarginTop>0.1in</MarginTop><MarginLeft>0.1in</MarginLeft><MarginRight>0.1in</MarginRight><MarginBottom>0.1in</MarginBottom></DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            LocalReport localReport = ReportViewer.LocalReport;

            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            
            MemoryStream stream = new MemoryStream(renderedBytes);

            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/pdf";
            HttpContext.Current.Session["OpenXmlFileName"] = "Reporte.pdf";


        }


    }
}
