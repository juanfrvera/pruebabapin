using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web
{
    public partial class WebControl_FileUpload : WebControlBase
    {
        private FileInfo fileInfo = new FileInfo();
        public static string PathQueryOpenFile = "../Controls/OpenFile.aspx?file=";

        #region Public Members

        public Int32 ValueId
        {
            get { return fileInfo.IdFile; }
            set { fileInfo.IdFile = value; }
        }
        public FileInfo Value
        {
            get { return fileInfo; }
            set { fileInfo = value; }
        }
        public bool IsFileSelected
        {
            get { return fuArchivo.FileContent != null && fuArchivo.FileContent.Length > 0; }
        }
        public string FileName
        {
            get { return fileInfo.FileName; }
            set { fileInfo.FileName = value; }
        }
        public DateTime Date
        {
            get { return (DateTime)fileInfo.Date; } 
            set { fileInfo.Date = value; } 
        }
        public string GetNewFileName()
        {
            return fuArchivo.FileName;
        }
        public Int32 GetIdFileSelected()
        {
            if (fuArchivo.FileContent != null)
            {
                UIHelper.Validate(fuArchivo.PostedFile.InputStream.Length < SolutionContext.Current.RequestMaxLength, "FileInvalidLength",(SolutionContext.Current.RequestMaxLength/1048576));
                //Matias 20140121 - Tarea 113
                string[] partes = fuArchivo.FileName.Split('.');
                if ((partes[partes.Length - 1] != null) && ( (partes[partes.Length - 1]).ToUpper() == "EXE"))
                    UIHelper.Validate(false, "FieldInvalidFormat", "EXE");
                //FinMatias 20140121 - Tarea 113
                fileInfo = SolutionContext.Current.FileManager.Upload("",(FileName!=null && FileName != string.Empty)?FileName:fuArchivo.FileName, fuArchivo.PostedFile.ContentType,fileInfo.Date,fuArchivo.FileBytes, UIContext.Current.ContextUser);
                return fileInfo.IdFile;
            }  
            return 0;
        }
        public void Focus()
        {
            fuArchivo.Focus();
        }
        public Unit Width
        {
            get {
                return fuArchivo.Width;
            }
            set {
                fuArchivo.Width = value;
            }
        }
        #endregion Public Members

        #region Eventos
        #endregion Eventos
    }
}