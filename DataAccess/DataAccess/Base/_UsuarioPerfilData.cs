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
    public abstract class _UsuarioPerfilData : EntityData<UsuarioPerfil,UsuarioPerfilFilter,UsuarioPerfilResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.UsuarioPerfil entity)
		{			
			return entity.IdUsuarioPerfil;
		}		
		public override UsuarioPerfil GetByEntity(UsuarioPerfil entity)
        {
            return this.GetById(entity.IdUsuarioPerfil);
        }
        public override UsuarioPerfil GetById(int id)
        {
            return (from o in this.Table where o.IdUsuarioPerfil == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<UsuarioPerfil> Query(UsuarioPerfilFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdUsuarioPerfil == null || o.IdUsuarioPerfil >=  filter.IdUsuarioPerfil) && (filter.IdUsuarioPerfil_To == null || o.IdUsuarioPerfil <= filter.IdUsuarioPerfil_To)
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  && (filter.IdPerfilIsNull == null || filter.IdPerfilIsNull == true || o.IdPerfil != null ) && (filter.IdPerfilIsNull == null || filter.IdPerfilIsNull == false || o.IdPerfil == null)
					  select o
                    ).AsQueryable();
        }	
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
						,Perfil_Codigo= t1!=null?(string)t1.Codigo:null	
						,Usuario_NombreUsuario= t2.NombreUsuario	
						,Usuario_Clave= t2.Clave	
						,Usuario_Activo= t2.Activo	
						,Usuario_EsSectioralista= t2.EsSectioralista	
						,Usuario_IdLanguage= t2.IdLanguage	
						,Usuario_AccesoTotal= t2.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.UsuarioPerfil Copy(nc.UsuarioPerfil entity)
        {           
            nc.UsuarioPerfil _new = new nc.UsuarioPerfil();
		 _new.IdUsuario= entity.IdUsuario;
		 _new.IdPerfil= entity.IdPerfil;
		return _new;			
        }
		public override int CopyAndSave(UsuarioPerfil entity,string renameFormat)
        {
            UsuarioPerfil  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(UsuarioPerfil entity, int id)
        {            
            entity.IdUsuarioPerfil = id;            
        }
		public override void Set(UsuarioPerfil source,UsuarioPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioPerfil= source.IdUsuarioPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdPerfil= source.IdPerfil ;
		 		  
		}
		public override void Set(UsuarioPerfilResult source,UsuarioPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioPerfil= source.IdUsuarioPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdPerfil= source.IdPerfil ;
		 
		}
		public override void Set(UsuarioPerfil source,UsuarioPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioPerfil= source.IdUsuarioPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdPerfil= source.IdPerfil ;
		 	
		}		
		public override void Set(UsuarioPerfilResult source,UsuarioPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioPerfil= source.IdUsuarioPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Perfil_Nombre= source.Perfil_Nombre;	
			target.Perfil_IdPerfilTipo= source.Perfil_IdPerfilTipo;	
			target.Perfil_Activo= source.Perfil_Activo;	
			target.Perfil_EsDefault= source.Perfil_EsDefault;	
			target.Perfil_Codigo= source.Perfil_Codigo;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(UsuarioPerfil source,UsuarioPerfil target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuarioPerfil.Equals(target.IdUsuarioPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.IdPerfil == null)?(target.IdPerfil.HasValue && target.IdPerfil.Value > 0):!source.IdPerfil.Equals(target.IdPerfil))return false;
						 
		  return true;
        }
		public override bool Equals(UsuarioPerfilResult source,UsuarioPerfilResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuarioPerfil.Equals(target.IdUsuarioPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.IdPerfil == null)?(target.IdPerfil.HasValue && target.IdPerfil.Value > 0):!source.IdPerfil.Equals(target.IdPerfil))return false;
						  if((source.Perfil_Nombre == null)?target.Perfil_Nombre!=null: !( (target.Perfil_Nombre== String.Empty && source.Perfil_Nombre== null) || (target.Perfil_Nombre==null && source.Perfil_Nombre== String.Empty )) &&   !source.Perfil_Nombre.Trim().Replace ("\r","").Equals(target.Perfil_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Perfil_IdPerfilTipo.Equals(target.Perfil_IdPerfilTipo))return false;
					  if(!source.Perfil_Activo.Equals(target.Perfil_Activo))return false;
					  if(!source.Perfil_EsDefault.Equals(target.Perfil_EsDefault))return false;
					  if((source.Perfil_Codigo == null)?target.Perfil_Codigo!=null: !( (target.Perfil_Codigo== String.Empty && source.Perfil_Codigo== null) || (target.Perfil_Codigo==null && source.Perfil_Codigo== String.Empty )) &&   !source.Perfil_Codigo.Trim().Replace ("\r","").Equals(target.Perfil_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
					  if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
					  if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
