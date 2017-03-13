using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class UsuarioOficinaPerfilData : _UsuarioOficinaPerfilData 
    { 
	   #region Singleton
	   private static volatile UsuarioOficinaPerfilData current;
	   private static object syncRoot = new Object();

	   //private UsuarioOficinaPerfilData() {}
	   public static UsuarioOficinaPerfilData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioOficinaPerfilData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion 
       public override string IdFieldName { get { return "IdUsuarioOficinaPerfil"; } }
        
       public List<UsuarioOficinaPerfilSimpleResult> GetResultSimple(UsuarioOficinaPerfilFilter filter)
       {
           IQueryable<UsuarioOficinaPerfilSimpleResult> query = 
               (from o in QueryResult(filter)
                select new UsuarioOficinaPerfilSimpleResult()
                {IdPerfil = o.IdPerfil
                , Activo  = o.Activo
                , IdOficina = o.IdOficina
                , IdUsuario = o.IdUsuario
                , IdUsuarioOficinaPerfil = o.IdUsuarioOficinaPerfil
                , Oficina_Nombre = o.Oficina_Nombre
                , Oficina_BreadcrumbId = o.Oficina_BreadcrumbId
                , Perfil_Nombre = o.Perfil_Nombre
                , Perfil_Codigo = o.Perfil_Codigo /*Matias 20161202*/
                , HeredaConsulta = o.HeredaConsulta
                , HeredaEdicion = o.HeredaEdicion
                , AccesoTotal = o.AccesoTotal
                }).AsQueryable<UsuarioOficinaPerfilSimpleResult>();
           return ListPaged<UsuarioOficinaPerfilSimpleResult>(query, filter);
       }

        
    }
}
