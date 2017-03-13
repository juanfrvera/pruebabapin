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
    public abstract class _PrestamoOficinaFuncionarioData : EntityData<PrestamoOficinaFuncionario,PrestamoOficinaFuncionarioFilter,PrestamoOficinaFuncionarioResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoOficinaFuncionario entity)
		{			
			return entity.IdPrestamoOficinaPerfilFuncionario;
		}		
		public override PrestamoOficinaFuncionario GetByEntity(PrestamoOficinaFuncionario entity)
        {
            return this.GetById(entity.IdPrestamoOficinaPerfilFuncionario);
        }
        public override PrestamoOficinaFuncionario GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoOficinaPerfilFuncionario == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoOficinaFuncionario> Query(PrestamoOficinaFuncionarioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoOficinaPerfilFuncionario == null || o.IdPrestamoOficinaPerfilFuncionario >=  filter.IdPrestamoOficinaPerfilFuncionario) && (filter.IdPrestamoOficinaPerfilFuncionario_To == null || o.IdPrestamoOficinaPerfilFuncionario <= filter.IdPrestamoOficinaPerfilFuncionario_To)
					  && (filter.IdPrestamoOficinaPerfil == null || filter.IdPrestamoOficinaPerfil == 0 || o.IdPrestamoOficinaPerfil==filter.IdPrestamoOficinaPerfil)
					  && (filter.IdUsuario == null || o.IdUsuario >=  filter.IdUsuario) && (filter.IdUsuario_To == null || o.IdUsuario <= filter.IdUsuario_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoOficinaFuncionarioResult> QueryResult(PrestamoOficinaFuncionarioFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PrestamoOficinaPerfils on o.IdPrestamoOficinaPerfil equals t1.IdPrestamoOficinaPerfil   
				   select new PrestamoOficinaFuncionarioResult(){
					 IdPrestamoOficinaPerfilFuncionario=o.IdPrestamoOficinaPerfilFuncionario
					 ,IdPrestamoOficinaPerfil=o.IdPrestamoOficinaPerfil
					 ,IdUsuario=o.IdUsuario
					,PrestamoOficinaPerfil_IdPrestamo= t1.IdPrestamo	
						,PrestamoOficinaPerfil_IdOficina= t1.IdOficina	
						,PrestamoOficinaPerfil_IdPerfil= t1.IdPerfil	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoOficinaFuncionario Copy(nc.PrestamoOficinaFuncionario entity)
        {           
            nc.PrestamoOficinaFuncionario _new = new nc.PrestamoOficinaFuncionario();
		 _new.IdPrestamoOficinaPerfil= entity.IdPrestamoOficinaPerfil;
		 _new.IdUsuario= entity.IdUsuario;
		return _new;			
        }
		public override int CopyAndSave(PrestamoOficinaFuncionario entity,string renameFormat)
        {
            PrestamoOficinaFuncionario  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoOficinaFuncionario entity, int id)
        {            
            entity.IdPrestamoOficinaPerfilFuncionario = id;            
        }
		public override void Set(PrestamoOficinaFuncionario source,PrestamoOficinaFuncionario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfilFuncionario= source.IdPrestamoOficinaPerfilFuncionario ;
		 target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 		  
		}
		public override void Set(PrestamoOficinaFuncionarioResult source,PrestamoOficinaFuncionario target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfilFuncionario= source.IdPrestamoOficinaPerfilFuncionario ;
		 target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 
		}
		public override void Set(PrestamoOficinaFuncionario source,PrestamoOficinaFuncionarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfilFuncionario= source.IdPrestamoOficinaPerfilFuncionario ;
		 target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 	
		}		
		public override void Set(PrestamoOficinaFuncionarioResult source,PrestamoOficinaFuncionarioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfilFuncionario= source.IdPrestamoOficinaPerfilFuncionario ;
		 target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.PrestamoOficinaPerfil_IdPrestamo= source.PrestamoOficinaPerfil_IdPrestamo;	
			target.PrestamoOficinaPerfil_IdOficina= source.PrestamoOficinaPerfil_IdOficina;	
			target.PrestamoOficinaPerfil_IdPerfil= source.PrestamoOficinaPerfil_IdPerfil;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoOficinaFuncionario source,PrestamoOficinaFuncionario target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoOficinaPerfilFuncionario.Equals(target.IdPrestamoOficinaPerfilFuncionario))return false;
		  if(!source.IdPrestamoOficinaPerfil.Equals(target.IdPrestamoOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoOficinaFuncionarioResult source,PrestamoOficinaFuncionarioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoOficinaPerfilFuncionario.Equals(target.IdPrestamoOficinaPerfilFuncionario))return false;
		  if(!source.IdPrestamoOficinaPerfil.Equals(target.IdPrestamoOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.PrestamoOficinaPerfil_IdPrestamo.Equals(target.PrestamoOficinaPerfil_IdPrestamo))return false;
					  if(!source.PrestamoOficinaPerfil_IdOficina.Equals(target.PrestamoOficinaPerfil_IdOficina))return false;
					  if(!source.PrestamoOficinaPerfil_IdPerfil.Equals(target.PrestamoOficinaPerfil_IdPerfil))return false;
					 		
		  return true;
        }
		#endregion
    }
}
