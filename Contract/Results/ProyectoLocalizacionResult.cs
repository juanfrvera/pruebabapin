using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoLocalizacionResult : _ProyectoLocalizacionResult
    { 	
        public string Descripcion
        {
            get { return ClasificacionGeografica_Descripcion; }
            set { ClasificacionGeografica_Descripcion = value; }
        }
        public Int32 Tipo
        {
            get { return ClasificacionGeografica_IdClasificacionGeograficaTipo; }
            set { ClasificacionGeografica_IdClasificacionGeograficaTipo = value; }
        }
        public string Orden
        {
            get { return ClasificacionGeografica_IdClasificacionGeograficaTipo.ToString() + ClasificacionGeografica_Descripcion; }
        }
        public Int32 IdProvincia
        { 
            get { 
                Int32 idprov;
                if ( !Int32.TryParse ( ClasificacionGeografica_BreadcrumbId.Substring (1,ClasificacionGeografica_BreadcrumbId.Substring (1).IndexOf ( '.')), out idprov ))
                      idprov = 0;
                return idprov ;
            } 
        }
    }
}
