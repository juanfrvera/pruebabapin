using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{

    


    public class PermisoData : _PermisoData 
    { 
	   #region Singleton
	   private static volatile PermisoData current;
	   private static object syncRoot = new Object();

	   //private PermisoData() {}
	   public static PermisoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PermisoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPermiso"; } }

        public List<PermisoSimpleResult> GetSimpleResult(PermisoPerfilFilter filter)
        {
         filter.Activo = true; 
         return (from o in Query(filter)					
            join ap in this.Context.ActividadPermisos on o.IdPermiso equals ap.IdPermiso
            join a in  this.Context.Actividads on ap.IdActividad equals a.IdActividad
            join pa in this.Context.PerfilActividads on ap.IdActividad equals pa.IdActividad
            join _t1  in this.Context.SistemaAccions on o.IdSistemaAccion equals _t1.IdSistemaAccion into tt1 from t1 in tt1.DefaultIfEmpty()
            join _t2  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals _t2.IdSistemaEntidad into tt2 from t2 in tt2.DefaultIfEmpty()
            join _t3  in this.Context.SistemaEntidadEstados on o.IdSistemaEstado equals _t3.IdSistemaEntidadEstado into tt3 from t3 in tt3.DefaultIfEmpty()
            where  a.Activo == true
            && ( filter.IdPerfil== null || filter.IdPerfil == 0 || pa.IdPerfil ==  filter.IdPerfil  )
            && ( t1 == null ||  t1.Activo == true)
            && (t2 == null || t2.Activo == true )            
            select new PermisoSimpleResult()
            {
            IdPermiso=o.IdPermiso
            ,Nombre=o.Nombre
            ,Codigo = o.Codigo
            ,IdSistemaEntidad=o.IdSistemaEntidad
            ,IdSistemaAccion=o.IdSistemaAccion
            ,IdSistemaEstado=o.IdSistemaEstado
            ,SistemaAccion_Codigo= t1!=null?(string)t1.Codigo:null	
            ,SistemaAccion_IncluirEstado = t1!=null?t1.IncluirEstado:false 
            ,SistemaEntidad_Codigo= t2!=null?(string)t2.Codigo:null
            }
            ).Distinct().ToList();
        }

    }
}
