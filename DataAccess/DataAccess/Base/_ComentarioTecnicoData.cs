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
    public abstract class _ComentarioTecnicoData : EntityData<ComentarioTecnico,ComentarioTecnicoFilter,ComentarioTecnicoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ComentarioTecnico entity)
		{			
			return entity.IdComentarioTecnico;
		}		
		public override ComentarioTecnico GetByEntity(ComentarioTecnico entity)
        {
            return this.GetById(entity.IdComentarioTecnico);
        }
        public override ComentarioTecnico GetById(int id)
        {
            return (from o in this.Table where o.IdComentarioTecnico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ComentarioTecnico> Query(ComentarioTecnicoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdComentarioTecnico == null || filter.IdComentarioTecnico == 0 || o.IdComentarioTecnico==filter.IdComentarioTecnico)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ComentarioTecnicoResult> QueryResult(ComentarioTecnicoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ComentarioTecnicoResult(){
					 IdComentarioTecnico=o.IdComentarioTecnico
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ComentarioTecnico Copy(nc.ComentarioTecnico entity)
        {           
            nc.ComentarioTecnico _new = new nc.ComentarioTecnico();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(ComentarioTecnico entity,string renameFormat)
        {
            ComentarioTecnico  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ComentarioTecnico entity, int id)
        {            
            entity.IdComentarioTecnico = id;            
        }
		public override void Set(ComentarioTecnico source,ComentarioTecnico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ComentarioTecnicoResult source,ComentarioTecnico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(ComentarioTecnico source,ComentarioTecnicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ComentarioTecnicoResult source,ComentarioTecnicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ComentarioTecnico source,ComentarioTecnico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdComentarioTecnico.Equals(target.IdComentarioTecnico))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ComentarioTecnicoResult source,ComentarioTecnicoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdComentarioTecnico.Equals(target.IdComentarioTecnico))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
