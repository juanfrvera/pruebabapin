using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class UsuarioData : EntityData<Usuario,UsuarioFilter,UsuarioResult,int>
    { 
	   #region Singleton
	   private static volatile UsuarioData current;
	   private static object syncRoot = new Object();

	   //private UsuarioData() {}
	   public static UsuarioData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdUsuario"; } }
                      
        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Usuario entity)
		{			
			return entity.IdUsuario;
		}		
		public override Usuario GetByEntity(Usuario entity)
        {
            return this.GetById(entity.IdUsuario);
        }
        public override Usuario GetById(int id)
        {
            return (from o in this.Table where o.IdUsuario == id select o).FirstOrDefault();
        }
        public override ListPaged<SimpleResult<int>> GetSimpleList(UsuarioFilter filter)
        {
            return ListPaged<SimpleResult<int>>((from o in QueryResult(filter) select new SimpleResult<int> { ID = o.IdUsuario, Text = o.Persona_NombreCompleto }).AsQueryable(), filter);
        }
		#endregion
		#region Query
        protected override IQueryable<Usuario> Query(UsuarioFilter filter)
        {
            return (from o in this.Table
                    join t1 in this.Context.Personas on o.IdUsuario equals t1.IdPersona
                    where (
                         (filter.IdUsuario == null || o.IdUsuario == filter.IdUsuario )
                          && (filter.NombreUsuario == null || filter.NombreUsuario.Trim() == string.Empty || filter.NombreUsuario.Trim() == "%" || (filter.NombreUsuario.EndsWith("%") && filter.NombreUsuario.StartsWith("%") && (o.NombreUsuario.Contains(filter.NombreUsuario.Replace("%", "")))) || (filter.NombreUsuario.EndsWith("%") && o.NombreUsuario.StartsWith(filter.NombreUsuario.Replace("%", ""))) || (filter.NombreUsuario.StartsWith("%") && o.NombreUsuario.EndsWith(filter.NombreUsuario.Replace("%", ""))) || o.NombreUsuario == filter.NombreUsuario)
                          && (filter.Clave == null || filter.Clave.Trim() == string.Empty || filter.Clave.Trim() == "%" || (filter.Clave.EndsWith("%") && filter.Clave.StartsWith("%") && (o.Clave.Contains(filter.Clave.Replace("%", "")))) || (filter.Clave.EndsWith("%") && o.Clave.StartsWith(filter.Clave.Replace("%", ""))) || (filter.Clave.StartsWith("%") && o.Clave.EndsWith(filter.Clave.Replace("%", ""))) || o.Clave == filter.Clave)
                          && (filter.Activo == null || o.Activo == filter.Activo)
                          && (filter.EsSectioralista == null || o.EsSectioralista == filter.EsSectioralista)
                          && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (t1.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && t1.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && t1.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || t1.Nombre == filter.Nombre)
                          && (filter.Apellido == null || filter.Apellido.Trim() == string.Empty || filter.Apellido.Trim() == "%" || (filter.Apellido.EndsWith("%") && filter.Apellido.StartsWith("%") && (t1.Apellido.Contains(filter.Apellido.Replace("%", "")))) || (filter.Apellido.EndsWith("%") && t1.Apellido.StartsWith(filter.Apellido.Replace("%", ""))) || (filter.Apellido.StartsWith("%") && t1.Apellido.EndsWith(filter.Apellido.Replace("%", ""))) || t1.Apellido == filter.Apellido)
                          && (filter.NombreCompleto == null || filter.NombreCompleto.Trim() == string.Empty || filter.NombreCompleto.Trim() == "%" || (filter.NombreCompleto.EndsWith("%") && filter.NombreCompleto.StartsWith("%") && (t1.NombreCompleto.Contains(filter.NombreCompleto.Replace("%", "")))) || (filter.NombreCompleto.EndsWith("%") && t1.NombreCompleto.StartsWith(filter.NombreCompleto.Replace("%", ""))) || (filter.NombreCompleto.StartsWith("%") && t1.NombreCompleto.EndsWith(filter.NombreCompleto.Replace("%", ""))) || t1.NombreCompleto == filter.NombreCompleto)
                      )
                    select o
                    ).AsQueryable();
        }	
        protected override IQueryable<UsuarioResult> QueryResult(UsuarioFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Languages on o.IdLanguage equals t1.IdLanguage   
				    join t2  in this.Context.Personas on o.IdUsuario equals t2.IdPersona   
				   select new UsuarioResult(){
					 IdUsuario=o.IdUsuario
					 ,NombreUsuario=o.NombreUsuario
					 ,Clave=o.Clave
					 ,Activo=o.Activo
                     ,AccesoTotal = o.AccesoTotal
					 ,EsSectioralista=o.EsSectioralista
					 ,IdLanguage=o.IdLanguage
					,Language_Name= t1.Name	
						,Language_Code= t1.Code	
						,Persona_EsUsuario= t2.EsUsuario	
						,Persona_EsContacto= t2.EsContacto	
						,Persona_Nombre= t2.Nombre	
						,Persona_Apellido= t2.Apellido	
						,Persona_NombreCompleto= t2.NombreCompleto	
						,Persona_IdOficina= t2.IdOficina	
						,Persona_IdCargo= t2.IdCargo	
						,Persona_Telefono= t2.Telefono	
						,Persona_TelefonoLaboral= t2.TelefonoLaboral	
						,Persona_Fax= t2.Fax	
						,Persona_EMailPersonal= t2.EMailPersonal	
						,Persona_EMailLaboral= t2.EMailLaboral	
						,Persona_CargoEspecifico= t2.CargoEspecifico	
						,Persona_NivelJerarquico= t2.NivelJerarquico	
						,Persona_Domicilio= t2.Domicilio	
						,Persona_CodPostal= t2.CodPostal	
						,NombreCompleto= t2.Apellido +", "+t2.Nombre 	
						//,Persona_IdLocalidad= t2.IdLocalidad	
                        
						,Persona_Sexo= t2.Sexo	
						,Persona_EnviarEMail= t2.EnviarEMail	
						,Persona_EnviarNota= t2.EnviarNota	
						,Persona_FechaAlta= t2.FechaAlta	
						,Persona_FechaBaja= t2.FechaBaja	
						,Persona_Activo= t2.Activo	
						,Persona_FechaUltMod= t2.FechaUltMod	
						,Persona_IdUsuarioUltMod= t2.IdUsuarioUltMod	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Usuario Copy(nc.Usuario entity)
        {           
         nc.Usuario _new = new nc.Usuario();
		 _new.NombreUsuario= entity.NombreUsuario;
		 _new.Clave= entity.Clave;
		 _new.Activo= entity.Activo;
		 _new.EsSectioralista= entity.EsSectioralista;
		 _new.IdLanguage= entity.IdLanguage;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(Usuario entity, int id)
        {            
            entity.IdUsuario = id;            
        }
		public override void Set(Usuario source,Usuario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
         target.AccesoTotal = source.AccesoTotal;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 		  
		}
		public override void Set(UsuarioResult source,Usuario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
         target.AccesoTotal = source.AccesoTotal;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 
		}
		public override void Set(Usuario source,UsuarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
         target.AccesoTotal = source.AccesoTotal;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 	
		}		
		public override void Set(UsuarioResult source,UsuarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
         target.AccesoTotal = source.AccesoTotal;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 target.Language_Name= source.Language_Name;	
			target.Language_Code= source.Language_Code;
            target.Persona_EsUsuario = source.Persona_EsUsuario;
            target.Persona_EsContacto = source.Persona_EsContacto;
            target.Persona_Nombre = source.Persona_Nombre;
            target.Persona_Apellido = source.Persona_Apellido;
            target.Persona_NombreCompleto = source.Persona_NombreCompleto;
            target.Persona_IdOficina = source.Persona_IdOficina;
            target.Persona_IdCargo = source.Persona_IdCargo;
            target.Persona_Telefono = source.Persona_Telefono;
            target.Persona_TelefonoLaboral = source.Persona_TelefonoLaboral;
            target.Persona_Fax = source.Persona_Fax;
            target.Persona_EMailPersonal = source.Persona_EMailPersonal;
            target.Persona_EMailLaboral = source.Persona_EMailLaboral;
            target.Persona_CargoEspecifico = source.Persona_CargoEspecifico;
            target.Persona_NivelJerarquico = source.Persona_NivelJerarquico;
            target.Persona_Domicilio = source.Persona_Domicilio;
            target.Persona_CodPostal = source.Persona_CodPostal;
            target.Persona_IdProvincia = source.Persona_IdProvincia;
            target.Persona_IdLocalidad = source.Persona_IdLocalidad;
            target.Persona_Sexo = source.Persona_Sexo;
            target.Persona_EnviarEMail = source.Persona_EnviarEMail;
            target.Persona_EnviarNota = source.Persona_EnviarNota;
            target.Persona_FechaAlta = source.Persona_FechaAlta;
            target.Persona_FechaBaja = source.Persona_FechaBaja;
            target.Persona_Activo = source.Persona_Activo;
            target.Persona_FechaUltMod = source.Persona_FechaUltMod;
            target.Persona_IdUsuarioUltMod = source.Persona_IdUsuarioUltMod;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Usuario source,Usuario target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.NombreUsuario.Equals(target.NombreUsuario))return false;
		  if(!source.Clave.Equals(target.Clave))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
          if (!source.AccesoTotal.Equals(target.AccesoTotal)) return false;
		  if(!source.EsSectioralista.Equals(target.EsSectioralista))return false;
		  if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		 
		  return true;
        }
		public override bool Equals(UsuarioResult source,UsuarioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.NombreUsuario.Equals(target.NombreUsuario))return false;
		  if(!source.Clave.Equals(target.Clave))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
          if (!source.AccesoTotal.Equals(target.AccesoTotal)) return false;
		  if(!source.EsSectioralista.Equals(target.EsSectioralista))return false;
		  if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if(!source.Language_Name.Equals(target.Language_Name))return false;
					  if(!source.Language_Code.Equals(target.Language_Code))return false;
                      if (!source.Persona_EsUsuario.Equals(target.Persona_EsUsuario)) return false;
                      if (!source.Persona_EsContacto.Equals(target.Persona_EsContacto)) return false;
                      if (!source.Persona_Nombre.Equals(target.Persona_Nombre)) return false;
                      if (!source.Persona_Apellido.Equals(target.Persona_Apellido)) return false;
                      if (!source.Persona_NombreCompleto.Equals(target.Persona_NombreCompleto)) return false;
                      if (!source.Persona_IdOficina.Equals(target.Persona_IdOficina)) return false;
                      if ((source.Persona_IdCargo == null) ? (target.Persona_IdCargo.HasValue && target.Persona_IdCargo.Value > 0) : !source.Persona_IdCargo.Equals(target.Persona_IdCargo)) return false;
                      if (!source.Persona_Telefono.Equals(target.Persona_Telefono)) return false;
                      if (!source.Persona_TelefonoLaboral.Equals(target.Persona_TelefonoLaboral)) return false;
                      if (!source.Persona_Fax.Equals(target.Persona_Fax)) return false;
                      if (!source.Persona_EMailPersonal.Equals(target.Persona_EMailPersonal)) return false;
                      if (!source.Persona_EMailLaboral.Equals(target.Persona_EMailLaboral)) return false;
                      if (!source.Persona_CargoEspecifico.Equals(target.Persona_CargoEspecifico)) return false;
                      if (!source.Persona_NivelJerarquico.Equals(target.Persona_NivelJerarquico)) return false;
                      if (!source.Persona_Domicilio.Equals(target.Persona_Domicilio)) return false;
                      if (!source.Persona_CodPostal.Equals(target.Persona_CodPostal)) return false;
                      if ((source.Persona_IdProvincia == null) ? (target.Persona_IdProvincia.HasValue && target.Persona_IdProvincia.Value > 0) : !source.Persona_IdProvincia.Equals(target.Persona_IdProvincia)) return false;
                      if ((source.Persona_IdLocalidad == null) ? (target.Persona_IdLocalidad.HasValue && target.Persona_IdLocalidad.Value > 0) : !source.Persona_IdLocalidad.Equals(target.Persona_IdLocalidad)) return false;
                      if (!source.Persona_Sexo.Equals(target.Persona_Sexo)) return false;
                      if ((source.Persona_EnviarEMail == null) ? target.Persona_EnviarEMail != null : !source.Persona_EnviarEMail.Equals(target.Persona_EnviarEMail)) return false;
                      if ((source.Persona_EnviarNota == null) ? target.Persona_EnviarNota != null : !source.Persona_EnviarNota.Equals(target.Persona_EnviarNota)) return false;
                      if (!source.Persona_FechaAlta.Equals(target.Persona_FechaAlta)) return false;
                      if ((source.Persona_FechaBaja == null) ? target.Persona_FechaBaja != null : !source.Persona_FechaBaja.Equals(target.Persona_FechaBaja)) return false;
                      if (!source.Persona_Activo.Equals(target.Persona_Activo)) return false;
                      if (!source.Persona_FechaUltMod.Equals(target.Persona_FechaUltMod)) return false;
                      if (!source.Persona_IdUsuarioUltMod.Equals(target.Persona_IdUsuarioUltMod)) return false;
					 		
		  return true;
        }
		#endregion
        
        
        
        #region Query
			
        
		#endregion
    }
}
