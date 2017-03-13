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
    public abstract class _EvaluacionTipoData : EntityData<EvaluacionTipo,EvaluacionTipoFilter,EvaluacionTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EvaluacionTipo entity)
		{			
			return entity.IdEvaluacionTipo;
		}		
		public override EvaluacionTipo GetByEntity(EvaluacionTipo entity)
        {
            return this.GetById(entity.IdEvaluacionTipo);
        }
        public override EvaluacionTipo GetById(int id)
        {
            return (from o in this.Table where o.IdEvaluacionTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EvaluacionTipo> Query(EvaluacionTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEvaluacionTipo == null || filter.IdEvaluacionTipo == 0 || o.IdEvaluacionTipo==filter.IdEvaluacionTipo)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.ActivoIsNull == null || filter.ActivoIsNull == true || o.Activo != null ) && (filter.ActivoIsNull == null || filter.ActivoIsNull == false || o.Activo == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EvaluacionTipoResult> QueryResult(EvaluacionTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new EvaluacionTipoResult(){
					 IdEvaluacionTipo=o.IdEvaluacionTipo
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EvaluacionTipo Copy(nc.EvaluacionTipo entity)
        {           
            nc.EvaluacionTipo _new = new nc.EvaluacionTipo();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(EvaluacionTipo entity,string renameFormat)
        {
            EvaluacionTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EvaluacionTipo entity, int id)
        {            
            entity.IdEvaluacionTipo = id;            
        }
		public override void Set(EvaluacionTipo source,EvaluacionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EvaluacionTipoResult source,EvaluacionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(EvaluacionTipo source,EvaluacionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EvaluacionTipoResult source,EvaluacionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(EvaluacionTipo source,EvaluacionTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionTipo.Equals(target.IdEvaluacionTipo))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Activo == null)?(target.Activo.HasValue):!source.Activo.Equals(target.Activo))return false;
			
		  return true;
        }
		public override bool Equals(EvaluacionTipoResult source,EvaluacionTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionTipo.Equals(target.IdEvaluacionTipo))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Activo == null)?(target.Activo.HasValue):!source.Activo.Equals(target.Activo))return false;
					
		  return true;
        }
		#endregion
    }
}
