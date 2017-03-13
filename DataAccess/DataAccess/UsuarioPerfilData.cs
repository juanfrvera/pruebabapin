using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class UsuarioPerfilData : _UsuarioPerfilData 
    { 
	   #region Singleton
	   private static volatile UsuarioPerfilData current;
	   private static object syncRoot = new Object();

	   //private UsuarioPerfilData() {}
	   public static UsuarioPerfilData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioPerfilData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdUsuarioPerfil"; } }

        	                    
        protected override IQueryable<UsuarioPerfilResult> QueryResult(UsuarioPerfilFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Perfils on o.IdPerfil equals _t1.IdPerfil into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.Usuarios on o.IdUsuario equals t2.IdUsuario   
				   select new UsuarioPerfilResult(){
					 IdUsuarioPerfil=o.IdUsuarioPerfil
					 ,IdUsuario=o.IdUsuario
					 ,IdPerfil=o.IdPerfil
					,Perfil_Nombre= t1!=null?(string)t1.Nombre:null	
						,Perfil_IdPerfilTipo= t1!=null?(int?)t1.IdPerfilTipo:null	
						,Perfil_Activo= t1!=null?(bool?)t1.Activo:null	
						,Perfil_EsDefault= t1!=null?(bool?)t1.EsDefault:null	
                        //,Perfil_HeredaConsulta= t1!=null?(bool?)t1.HeredaConsulta:null	
                        //,Perfil_HeredaEdicion= t1!=null?(bool?)t1.HeredaEdicion:null	
						,Usuario_NombreUsuario= t2.NombreUsuario	
						,Usuario_Clave= t2.Clave	
						,Usuario_Activo= t2.Activo	
						,Usuario_EsSectioralista= t2.EsSectioralista	
						,Usuario_IdLanguage= t2.IdLanguage
                        ,Selected = true
						}
                    ).AsQueryable();
        }
    }
}
