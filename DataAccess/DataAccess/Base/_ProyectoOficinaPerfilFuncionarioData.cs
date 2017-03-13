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
    public abstract class _ProyectoOficinaPerfilFuncionarioData : EntityData<ProyectoOficinaPerfilFuncionario,ProyectoOficinaPerfilFuncionarioFilter,ProyectoOficinaPerfilFuncionarioResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoOficinaPerfilFuncionario entity)
		{			
			return entity.IdProyectoOficinaPerfilFuncionario;
		}		
		public override ProyectoOficinaPerfilFuncionario GetByEntity(ProyectoOficinaPerfilFuncionario entity)
        {
            return this.GetById(entity.IdProyectoOficinaPerfilFuncionario);
        }
        public override ProyectoOficinaPerfilFuncionario GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoOficinaPerfilFuncionario == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoOficinaPerfilFuncionario> Query(ProyectoOficinaPerfilFuncionarioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoOficinaPerfilFuncionario == null || o.IdProyectoOficinaPerfilFuncionario >=  filter.IdProyectoOficinaPerfilFuncionario) && (filter.IdProyectoOficinaPerfilFuncionario_To == null || o.IdProyectoOficinaPerfilFuncionario <= filter.IdProyectoOficinaPerfilFuncionario_To)
					  && (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil==filter.IdProyectoOficinaPerfil)
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoOficinaPerfilFuncionarioResult> QueryResult(ProyectoOficinaPerfilFuncionarioFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoOficinaPerfils on o.IdProyectoOficinaPerfil equals t1.IdProyectoOficinaPerfil   
				    join t2  in this.Context.Usuarios on o.IdUsuario equals t2.IdUsuario   
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
						,Usuario_AccesoTotal= t2.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoOficinaPerfilFuncionario Copy(nc.ProyectoOficinaPerfilFuncionario entity)
        {           
            nc.ProyectoOficinaPerfilFuncionario _new = new nc.ProyectoOficinaPerfilFuncionario();
		 _new.IdProyectoOficinaPerfil= entity.IdProyectoOficinaPerfil;
		 _new.IdUsuario= entity.IdUsuario;
		return _new;			
        }
		public override int CopyAndSave(ProyectoOficinaPerfilFuncionario entity,string renameFormat)
        {
            ProyectoOficinaPerfilFuncionario  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoOficinaPerfilFuncionario entity, int id)
        {            
            entity.IdProyectoOficinaPerfilFuncionario = id;            
        }
		public override void Set(ProyectoOficinaPerfilFuncionario source,ProyectoOficinaPerfilFuncionario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfilFuncionario= source.IdProyectoOficinaPerfilFuncionario ;
		 target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 		  
		}
		public override void Set(ProyectoOficinaPerfilFuncionarioResult source,ProyectoOficinaPerfilFuncionario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfilFuncionario= source.IdProyectoOficinaPerfilFuncionario ;
		 target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 
		}
		public override void Set(ProyectoOficinaPerfilFuncionario source,ProyectoOficinaPerfilFuncionarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfilFuncionario= source.IdProyectoOficinaPerfilFuncionario ;
		 target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 	
		}		
		public override void Set(ProyectoOficinaPerfilFuncionarioResult source,ProyectoOficinaPerfilFuncionarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfilFuncionario= source.IdProyectoOficinaPerfilFuncionario ;
		 target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.ProyectoOficinaPerfil_IdProyecto= source.ProyectoOficinaPerfil_IdProyecto;	
			target.ProyectoOficinaPerfil_IdOficina= source.ProyectoOficinaPerfil_IdOficina;	
			target.ProyectoOficinaPerfil_IdPerfil= source.ProyectoOficinaPerfil_IdPerfil;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoOficinaPerfilFuncionario source,ProyectoOficinaPerfilFuncionario target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOficinaPerfilFuncionario.Equals(target.IdProyectoOficinaPerfilFuncionario))return false;
		  if(!source.IdProyectoOficinaPerfil.Equals(target.IdProyectoOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoOficinaPerfilFuncionarioResult source,ProyectoOficinaPerfilFuncionarioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOficinaPerfilFuncionario.Equals(target.IdProyectoOficinaPerfilFuncionario))return false;
		  if(!source.IdProyectoOficinaPerfil.Equals(target.IdProyectoOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.ProyectoOficinaPerfil_IdProyecto.Equals(target.ProyectoOficinaPerfil_IdProyecto))return false;
					  if(!source.ProyectoOficinaPerfil_IdOficina.Equals(target.ProyectoOficinaPerfil_IdOficina))return false;
					  if(!source.ProyectoOficinaPerfil_IdPerfil.Equals(target.ProyectoOficinaPerfil_IdPerfil))return false;
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
