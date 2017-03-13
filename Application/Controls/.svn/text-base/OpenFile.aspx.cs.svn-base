using System;
using System.IO;
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
using Service;
using nc = Contract;
using System.Text;
using Contract;

namespace UI.Web
{
    public partial class OpenFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["file"] != null)
            {
                Int32 idfile = 0;
                if (Int32.TryParse(Page.Request["file"].ToString(), out idfile))
                {
                    SolutionContext.Current.FileManager.Download(idfile);


                    nc.FileInfo fileInfo = SolutionContext.Current.FileManager.Download(idfile); ;
                    if (fileInfo != null && fileInfo.FileType != null)
                    {
                        Response.ContentType = fileInfo.FileType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + fileInfo.FileName + "\"");
                        byte[] myData = fileInfo.Data.ToArray();
                        Response.BinaryWrite(myData);
                        Response.End();
                    }
                }
            }
        }
    }
}
