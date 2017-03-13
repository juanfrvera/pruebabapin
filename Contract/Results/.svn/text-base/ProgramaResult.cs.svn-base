using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProgramaResult : _ProgramaResult
    {
        public string Sectorialista_Nombre { get; set; }
        public string CodigoNombre
        {
            get
            {
                return String.Format("{0}-{1}", Codigo, Nombre);
            }
        }
        public Int32 CodigoInt
        {
            get
            {
                Int32 codigo;
                if (Int32.TryParse(Codigo, out codigo))
                    return codigo;
                else
                {
                    return 0;
                }
            }
        }
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("Programa", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Codigo SAF","SAF_Codigo")
            ,new DataColumnMapping("Denominación SAF","SAF_Denominacion")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaBaja","FechaBaja","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Sectorialista","Sectorialista_Nombre")
			}));
        }
    }
}
