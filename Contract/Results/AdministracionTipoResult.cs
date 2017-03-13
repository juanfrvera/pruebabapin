using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class AdministracionTipoResult : _AdministracionTipoResult
    { 	
        public string CodigoNombre
        {
            get
            {
                return String.Format("{0}-{1}", Codigo, Nombre);
            }
        }
    }
}
