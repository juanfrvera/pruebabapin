using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class SafResult : _SafResult
    {
        public string CodigoDenominacion
        {
            get
            {
                return String.Format("{0}-{1}", Codigo, Denominacion);
            }
            set { Denominacion = value; }
        }
       public Int32 CodigoInt
       {
           get {
               Int32 codigo;
               if (Int32.TryParse(Codigo, out codigo))
                   return codigo;
               else
               {
                   return 0;
               }
           }
       }
      
       public string CodigoJurisdiccion_Nombre
       {
           get
           {
               if (Jurisdiccion_Codigo != null)
                   return String.Format("{0}-{1}", Jurisdiccion_Codigo, Jurisdiccion_Nombre);
               else
                   return "";
           }
       }
       public string CodigoSector_Nombre
       {
           get
           {
               if (Sector_Codigo != null)
                return String.Format("{0}-{1}", Sector_Codigo, Sector_Nombre);
               else
                   return "";
           }
       }
       public string CodigoEntidadTipo_Nombre
       {
           get
           {
               if (EntidadTipo_Codigo != null)
                return String.Format("{0}-{1}", EntidadTipo_Codigo, EntidadTipo_Nombre);
               else
                   return "";
           }
       }
       public string CodigoAdministracionTipo_Nombre
       {
           get
           {
               if (AdministracionTipo_Codigo != null)
                return String.Format("{0}-{1}", AdministracionTipo_Codigo, AdministracionTipo_Nombre);
               else
                   return "";
           }
       }
       public string CodigoSubJurisdiccion_Nombre
       {
           get
           {
               if (Codigo != null)
                return String.Format("{0}-{1}", SubJurisdiccion_Codigo, SubJurisdiccion_Nombre);
               else
                   return "";
           }
       }
    }
}
