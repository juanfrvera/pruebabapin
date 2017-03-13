using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PerfilData : _PerfilData 
    { 
	   #region Singleton
	   private static volatile PerfilData current;
	   private static object syncRoot = new Object();

	   //private PerfilData() {}
	   public static PerfilData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPerfil"; } }

       protected override IQueryable<Perfil> Query(PerfilFilter filter)
       {
           return (from o in this.Table                   
                   where (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil == filter.IdPerfil)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.IdPerfilTipo == null || filter.IdPerfilTipo == 0 || o.IdPerfilTipo == filter.IdPerfilTipo)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.EsDefault == null || o.EsDefault == filter.EsDefault)
                   //&& (filter.HeredaConsulta == null || o.HeredaConsulta == filter.HeredaConsulta)
                   //&& (filter.HeredaEdicion == null || o.HeredaEdicion == filter.HeredaEdicion)
                   && (filter.IdUsuario == null || filter.IdUsuario == 0 || (from up in this.Context.UsuarioPerfils where up.IdUsuario == filter.IdUsuario select up.IdPerfil).Contains(o.IdPerfil))
                   && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                   select o
                   ).AsQueryable();
       }
    }
}
