using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoDictamenEstadoData : _PrestamoDictamenEstadoData 
    { 
	   #region Singleton
	   private static volatile PrestamoDictamenEstadoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenEstadoData() {}
	   public static PrestamoDictamenEstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenEstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoDictamenEstado"; } }
        protected override IQueryable<PrestamoDictamenEstadoResult> QueryResult(PrestamoDictamenEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.PrestamoDictamens on o.IdPrestamoDictamen equals t2.IdPrestamoDictamen   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario 
                    join p in this.Context.Personas on t3.IdUsuario equals p.IdPersona 
				   select new PrestamoDictamenEstadoResult(){
					 IdPrestamoDictamenEstado=o.IdPrestamoDictamenEstado
					 ,IdPrestamoDictamen=o.IdPrestamoDictamen
					 ,IdEstado=o.IdEstado
					 ,Fecha=o.Fecha
					 ,Observacion=o.Observacion
					 ,IdUsuario=o.IdUsuario
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,Usuario_NombreUsuario = t3.NombreUsuario 
                        ,Persona_ApellidoYNombre = p.Apellido + " " + p.Nombre 
						}
                    ).AsQueryable();
        }
    }
}
