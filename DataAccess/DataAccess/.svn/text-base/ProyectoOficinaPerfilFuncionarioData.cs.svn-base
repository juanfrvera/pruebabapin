using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoOficinaPerfilFuncionarioData : _ProyectoOficinaPerfilFuncionarioData 
    { 
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilFuncionarioData current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilFuncionarioData() {}
	   public static ProyectoOficinaPerfilFuncionarioData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilFuncionarioData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoOficinaPerfilFuncionario"; } }

       //IdsProyectoOficinaPerfil
       protected override IQueryable<ProyectoOficinaPerfilFuncionario> Query(ProyectoOficinaPerfilFuncionarioFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdProyectoOficinaPerfilFuncionario == null || o.IdProyectoOficinaPerfilFuncionario >= filter.IdProyectoOficinaPerfilFuncionario) && (filter.IdProyectoOficinaPerfilFuncionario_To == null || o.IdProyectoOficinaPerfilFuncionario <= filter.IdProyectoOficinaPerfilFuncionario_To)
                   && (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil == filter.IdProyectoOficinaPerfil)
                   && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario == filter.IdUsuario)
                   && (filter.IdsProyectoOficinaPerfil == null || filter.IdsProyectoOficinaPerfil.Length == 0 || filter.IdsProyectoOficinaPerfil.Contains(o.IdProyectoOficinaPerfil))
                   select o
                   ).AsQueryable();
       }
       protected override IQueryable<ProyectoOficinaPerfilFuncionarioResult> QueryResult(ProyectoOficinaPerfilFuncionarioFilter filter)
       {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoOficinaPerfils on o.IdProyectoOficinaPerfil equals t1.IdProyectoOficinaPerfil   
				    join t2  in this.Context.Usuarios on o.IdUsuario equals t2.IdUsuario   
                    join persona in this.Context.Personas on t2.IdUsuario equals persona.IdPersona 
				   select new ProyectoOficinaPerfilFuncionarioResult(){
					 IdProyectoOficinaPerfilFuncionario=o.IdProyectoOficinaPerfilFuncionario
					 ,IdProyectoOficinaPerfil=o.IdProyectoOficinaPerfil
					 ,IdUsuario=o.IdUsuario
					,ProyectoOficinaPerfil_IdProyecto= t1.IdProyecto	
						,ProyectoOficinaPerfil_IdOficina= t1.IdOficina	
						,ProyectoOficinaPerfil_IdPerfil= t1.IdPerfil	                    
						,Usuario_NombreUsuario= t2.NombreUsuario
						,Usuario_Clave= t2.Clave	
						,Usuario_Activo= t2.Activo	
						,Usuario_EsSectioralista= t2.EsSectioralista	
						,Usuario_IdLanguage= t2.IdLanguage	
                        ,Usuario_Nombre = persona.Nombre
                        ,Usuario_Apellido = persona.Apellido 
                        ,Selected = true
						}
                    ).AsQueryable();
       }

       public override void Set(ProyectoOficinaPerfilFuncionarioResult source, ProyectoOficinaPerfilFuncionarioResult target, bool hadSetId)
       {
           if (hadSetId) target.IdProyectoOficinaPerfilFuncionario = source.IdProyectoOficinaPerfilFuncionario;
           target.IdProyectoOficinaPerfil = source.IdProyectoOficinaPerfil;
           target.IdUsuario = source.IdUsuario;
           target.ProyectoOficinaPerfil_IdProyecto = source.ProyectoOficinaPerfil_IdProyecto;
           target.ProyectoOficinaPerfil_IdOficina = source.ProyectoOficinaPerfil_IdOficina;
           target.ProyectoOficinaPerfil_IdPerfil = source.ProyectoOficinaPerfil_IdPerfil;
           target.Usuario_NombreUsuario = source.Usuario_NombreUsuario;
           target.Usuario_Clave = source.Usuario_Clave;
           target.Usuario_Activo = source.Usuario_Activo;
           target.Usuario_EsSectioralista = source.Usuario_EsSectioralista;
           target.Usuario_IdLanguage = source.Usuario_IdLanguage;
           target.Usuario_AccesoTotal = source.Usuario_AccesoTotal;
           target.Selected = source.Selected;
       }

       #region Equals
       public override bool Equals(ProyectoOficinaPerfilFuncionarioResult source, ProyectoOficinaPerfilFuncionarioResult target)
       {
           if (! base.Equals(source, target)) return false;
           //if (! source.Selected.Equals(target.Selected)) return false;
           return true;
       }
       #endregion
    }
}
