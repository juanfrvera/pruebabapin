using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class ProyectoDictamenFilesCompose
    {
        public ProyectoDictamenFilesCompose()
        {

        }
        public ProyectoDictamenResult ProyectoDictamen { get; set; }
        public Int32 IdProyectoDictamen
        {
            get { return ProyectoDictamen != null ? ProyectoDictamen.IdProyectoDictamen : 0; }
        }

        public List<ProyectoDictamenFileResult> ProyectoDictamenFiles = new List<ProyectoDictamenFileResult>();
    }
}
