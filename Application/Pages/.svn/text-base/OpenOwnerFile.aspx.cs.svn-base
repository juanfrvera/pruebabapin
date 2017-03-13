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
using Contract;
using System.Text;

namespace UI.Web
{
    public partial class OpenOwnerFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["idMov"] != null)
            {
                Int32 idMov = 0;
                if (Int32.TryParse(Page.Request["idMov"].ToString(), out idMov))
                {
                    //Movimiento mov = MovimientoService.Current.GetById(idMov);
                    //if (mov != null && mov.TipoArchivo != null)
                    //{
                    //    Response.ContentType = mov.TipoArchivo;
                    //    Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + mov.nombrearchivo + "\"");
                    //    byte[] myData = mov.Archivo.ToArray();
                    //    Response.BinaryWrite(myData);
                    //    Response.End();
                    //}
                }
            }
        }
    }
}
