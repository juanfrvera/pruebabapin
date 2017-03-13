using Contract;
using Core;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace UI.Web.Proyecto
{
    /// <summary>
    /// Summary description for ProyectoAlcanceGeograficoEditWebService
    /// </summary>
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProyectoAlcanceGeograficoEditWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string CopyFile()
        {
            string filename = string.Empty;
            string extension = string.Empty;
            string codigoBapin = string.Empty;
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var searchFile = HttpContext.Current.Request.Files["searchFile"];
                    codigoBapin = HttpContext.Current.Request.Params["codigoBapin"];

                    string path = string.Empty;
                    filename = searchFile.FileName.Split('.')[0];
                    extension = searchFile.FileName.Split('.')[1];

                    if (searchFile != null && searchFile.ContentLength > 0)
                    {

                        //obtengo el directorio base de la aplicacion
                        string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

                        //verifico si la carpeta ShapesFiles existe en el directorio local sino la creo
                        if (!Directory.Exists(rutaAplicacion + @"ShapesFiles\"))
                            Directory.CreateDirectory(rutaAplicacion + @"\ShapesFiles\");

                        //guardo el archivo recibido en la carpeta ShapesFiles 
                        path = rutaAplicacion + @"ShapesFiles\" + filename + "_" + codigoBapin + "." + extension;

                        searchFile.SaveAs(path);

                    }

                }

                return filename + "_" + codigoBapin + "." + extension;
            }
            catch (Exception)
            {
                return filename;
            }
        }
    }
}
