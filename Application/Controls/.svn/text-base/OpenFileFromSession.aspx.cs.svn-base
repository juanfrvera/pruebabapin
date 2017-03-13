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
    public partial class OpenFromSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["OpenXmlStreamInput"] != null)
            {
                string fileName = HttpContext.Current.Session["OpenXmlFileName"].ToString();
                string fileContentType = HttpContext.Current.Session["OpenXmlFileContentType"].ToString();
                Stream stream = ((Stream)HttpContext.Current.Session["OpenXmlStreamInput"]);

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = fileContentType;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.BinaryWrite(DataHelper.ToArrByte(stream));
                Response.End();

                HttpContext.Current.Session["OpenXmlStreamInput"] = null;
                HttpContext.Current.Session["OpenXmlFileName"] = null;
                HttpContext.Current.Session["OpenXmlFileContentType"] = null;
            }
        }
    }
}
