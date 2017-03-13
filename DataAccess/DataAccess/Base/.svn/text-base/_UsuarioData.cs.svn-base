using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _UsuarioData : EntityData<Usuario,UsuarioFilter,UsuarioResult,int>
    { 		
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
		#endregion
		#region Query
		protected override IQueryable<Usuario> Query(UsuarioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  && (filter.NombreUsuario == null || filter.NombreUsuario.Trim() == string.Empty || filter.NombreUsuario.Trim() == "%"  || (filter.NombreUsuario.EndsWith("%") && filter.NombreUsuario.StartsWith("%") && (o.NombreUsuario.Contains(filter.NombreUsuario.Replace("%", "")))) || (filter.NombreUsuario.EndsWith("%") && o.NombreUsuario.StartsWith(filter.NombreUsuario.Replace("%",""))) || (filter.NombreUsuario.StartsWith("%") && o.NombreUsuario.EndsWith(filter.NombreUsuario.Replace("%",""))) || o.NombreUsuario == filter.NombreUsuario )
					  && (filter.Clave == null || filter.Clave.Trim() == string.Empty || filter.Clave.Trim() == "%"  || (filter.Clave.EndsWith("%") && filter.Clave.StartsWith("%") && (o.Clave.Contains(filter.Clave.Replace("%", "")))) || (filter.Clave.EndsWith("%") && o.Clave.StartsWith(filter.Clave.Replace("%",""))) || (filter.Clave.StartsWith("%") && o.Clave.EndsWith(filter.Clave.Replace("%",""))) || o.Clave == filter.Clave )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.EsSectioralista == null || o.EsSectioralista==filter.EsSectioralista)
					  && (filter.IdLanguage == null || filter.IdLanguage == 0 || o.IdLanguage==filter.IdLanguage)
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
					 ,EsSectioralista=o.EsSectioralista
					 ,IdLanguage=o.IdLanguage
					,Language_Name= t1.Name	
						,Language_Code= t1.Code	
						,Usuario_EsUsuario= t2.EsUsuario	
						,Usuario_EsContacto= t2.EsContacto	
						,Usuario_Nombre= t2.Nombre	
						,Usuario_Apellido= t2.Apellido	
						,Usuario_NombreCompleto= t2.NombreCompleto	
						,Usuario_IdOficina= t2.IdOficina	
						,Usuario_IdCargo= t2.IdCargo	
						,Usuario_Telefono= t2.Telefono	
						,Usuario_TelefonoLaboral= t2.TelefonoLaboral	
						,Usuario_Fax= t2.Fax	
						,Usuario_EMailPersonal= t2.EMailPersonal	
						,Usuario_EMailLaboral= t2.EMailLaboral	
						,Usuario_CargoEspecifico= t2.CargoEspecifico	
						,Usuario_NivelJerarquico= t2.NivelJerarquico	
						,Usuario_Domicilio= t2.Domicilio	
						,Usuario_CodPostal= t2.CodPostal	
						,Usuario_IdProvincia= t2.IdProvincia	
						,Usuario_IdLocalidad= t2.IdLocalidad	
						,Usuario_Sexo= t2.Sexo	
						,Usuario_EnviarEMail= t2.EnviarEMail	
						,Usuario_EnviarNota= t2.EnviarNota	
						,Usuario_FechaAlta= t2.FechaAlta	
						,Usuario_FechaBaja= t2.FechaBaja	
						,Usuario_Activo= t2.Activo	
						,Usuario_FechaUltMod= t2.FechaUltMod	
						,Usuario_IdUsuarioUltMod= t2.IdUsuarioUltMod	
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
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 		  
		}
		public override void Set(UsuarioResult source,Usuario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 
		}
		public override void Set(Usuario source,UsuarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 	
		}		
		public override void Set(UsuarioResult source,UsuarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuario= source.IdUsuario ;
		 target.NombreUsuario= source.NombreUsuario ;
		 target.Clave= source.Clave ;
		 target.Activo= source.Activo ;
		 target.EsSectioralista= source.EsSectioralista ;
		 target.IdLanguage= source.IdLanguage ;
		 target.Language_Name= source.Language_Name;	
			target.Language_Code= source.Language_Code;	
			target.Usuario_EsUsuario= source.Usuario_EsUsuario;	
			target.Usuario_EsContacto= source.Usuario_EsContacto;	
			target.Usuario_Nombre= source.Usuario_Nombre;	
			target.Usuario_Apellido= source.Usuario_Apellido;	
			target.Usuario_NombreCompleto= source.Usuario_NombreCompleto;	
			target.Usuario_IdOficina= source.Usuario_IdOficina;	
			target.Usuario_IdCargo= source.Usuario_IdCargo;	
			target.Usuario_Telefono= source.Usuario_Telefono;	
			target.Usuario_TelefonoLaboral= source.Usuario_TelefonoLaboral;	
			target.Usuario_Fax= source.Usuario_Fax;	
			target.Usuario_EMailPersonal= source.Usuario_EMailPersonal;	
			target.Usuario_EMailLaboral= source.Usuario_EMailLaboral;	
			target.Usuario_CargoEspecifico= source.Usuario_CargoEspecifico;	
			target.Usuario_NivelJerarquico= source.Usuario_NivelJerarquico;	
			target.Usuario_Domicilio= source.Usuario_Domicilio;	
			target.Usuario_CodPostal= source.Usuario_CodPostal;	
			target.Usuario_IdProvincia= source.Usuario_IdProvincia;	
			target.Usuario_IdLocalidad= source.Usuario_IdLocalidad;	
			target.Usuario_Sexo= source.Usuario_Sexo;	
			target.Usuario_EnviarEMail= source.Usuario_EnviarEMail;	
			target.Usuario_EnviarNota= source.Usuario_EnviarNota;	
			target.Usuario_FechaAlta= source.Usuario_FechaAlta;	
			target.Usuario_FechaBaja= source.Usuario_FechaBaja;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_FechaUltMod= source.Usuario_FechaUltMod;	
			target.Usuario_IdUsuarioUltMod= source.Usuario_IdUsuarioUltMod;	
					
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
		  if(!source.EsSectioralista.Equals(target.EsSectioralista))return false;
		  if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if(!source.Language_Name.Equals(target.Language_Name))return false;
					  if(!source.Language_Code.Equals(target.Language_Code))return false;
					  if(!source.Usuario_EsUsuario.Equals(target.Usuario_EsUsuario))return false;
					  if(!source.Usuario_EsContacto.Equals(target.Usuario_EsContacto))return false;
					  if(!source.Usuario_Nombre.Equals(target.Usuario_Nombre))return false;
					  if(!source.Usuario_Apellido.Equals(target.Usuario_Apellido))return false;
					  if(!source.Usuario_NombreCompleto.Equals(target.Usuario_NombreCompleto))return false;
					  if(!source.Usuario_IdOficina.Equals(target.Usuario_IdOficina))return false;
					  if((source.Usuario_IdCargo == null)?(target.Usuario_IdCargo.HasValue && target.Usuario_IdCargo.Value > 0):!source.Usuario_IdCargo.Equals(target.Usuario_IdCargo))return false;
									  if(!source.Usuario_Telefono.Equals(target.Usuario_Telefono))return false;
					  if(!source.Usuario_TelefonoLaboral.Equals(target.Usuario_TelefonoLaboral))return false;
					  if(!source.Usuario_Fax.Equals(target.Usuario_Fax))return false;
					  if(!source.Usuario_EMailPersonal.Equals(target.Usuario_EMailPersonal))return false;
					  if(!source.Usuario_EMailLaboral.Equals(target.Usuario_EMailLaboral))return false;
					  if(!source.Usuario_CargoEspecifico.Equals(target.Usuario_CargoEspecifico))return false;
					  if(!source.Usuario_NivelJerarquico.Equals(target.Usuario_NivelJerarquico))return false;
					  if(!source.Usuario_Domicilio.Equals(target.Usuario_Domicilio))return false;
					  if(!source.Usuario_CodPostal.Equals(target.Usuario_CodPostal))return false;
					  if((source.Usuario_IdProvincia == null)?(target.Usuario_IdProvincia.HasValue && target.Usuario_IdProvincia.Value > 0):!source.Usuario_IdProvincia.Equals(target.Usuario_IdProvincia))return false;
									  if((source.Usuario_IdLocalidad == null)?(target.Usuario_IdLocalidad.HasValue && target.Usuario_IdLocalidad.Value > 0):!source.Usuario_IdLocalidad.Equals(target.Usuario_IdLocalidad))return false;
									  if(!source.Usuario_Sexo.Equals(target.Usuario_Sexo))return false;
					  if((source.Usuario_EnviarEMail == null)?target.Usuario_EnviarEMail!=null:!source.Usuario_EnviarEMail.Equals(target.Usuario_EnviarEMail))return false;
						 if((source.Usuario_EnviarNota == null)?target.Usuario_EnviarNota!=null:!source.Usuario_EnviarNota.Equals(target.Usuario_EnviarNota))return false;
						 if(!source.Usuario_FechaAlta.Equals(target.Usuario_FechaAlta))return false;
					  if((source.Usuario_FechaBaja == null)?target.Usuario_FechaBaja!=null:!source.Usuario_FechaBaja.Equals(target.Usuario_FechaBaja))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_FechaUltMod.Equals(target.Usuario_FechaUltMod))return false;
					  if(!source.Usuario_IdUsuarioUltMod.Equals(target.Usuario_IdUsuarioUltMod))return false;
					 		
		  return true;
        }
		#endregion
    }
}
