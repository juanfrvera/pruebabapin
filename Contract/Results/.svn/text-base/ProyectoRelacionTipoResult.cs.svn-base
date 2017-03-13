using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoRelacionTipoResult : _ProyectoRelacionTipoResult
    {
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoRelacionTipo", new List<DataColumnMapping>(new DataColumnMapping[]{
		    new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
        }
    }
}
