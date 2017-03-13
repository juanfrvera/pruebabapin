using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PerfilActividadData : _PerfilActividadData 
    { 
	   #region Singleton
	   private static volatile PerfilActividadData current;
	   private static object syncRoot = new Object();

	   //private PerfilActividadData() {}
	   public static PerfilActividadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilActividadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPerfilActividad"; } }
        protected override IQueryable<PerfilActividadResult> QueryResult(PerfilActividadFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Actividads on o.IdActividad equals t1.IdActividad   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				   select new PerfilActividadResult(){
					 IdPerfilActividad=o.IdPerfilActividad
					 ,IdPerfil=o.IdPerfil
					 ,IdActividad=o.IdActividad
					,Actividad_Nombre= t1.Nombre	
						,Actividad_Activo= t1.Activo	
						,Perfil_Nombre= t2.Nombre	
						,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
						,Perfil_Activo= t2.Activo	
						,Perfil_EsDefault= t2.EsDefault	
                        //,Perfil_HeredaConsulta= t2.HeredaConsulta	
                        //,Perfil_HeredaEdicion= t2.HeredaEdicion
	                    ,Selected = true
						}
                    ).AsQueryable();
        }
    }
}
