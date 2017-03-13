using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProcesoResult : _ProcesoResult
    {
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("Proceso", new List<DataColumnMapping>(new DataColumnMapping[]{
		     new DataColumnMapping("Tipo de Proyecto","ProyectoTipo_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}
            ));
        }
    }

}
