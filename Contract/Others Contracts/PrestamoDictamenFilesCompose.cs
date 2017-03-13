using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class PrestamoDictamenFilesCompose
    {
        public PrestamoDictamenResult PrestamoDictamen { get; set; }
        public Int32 IdPrestamoDictamen
        {
            get { return PrestamoDictamen != null ? PrestamoDictamen.IdPrestamoDictamen : 0; }
        }

        public List<PrestamoDictamenFileResult> PrestamoDictamenFiles = new List<PrestamoDictamenFileResult>();
    }
}