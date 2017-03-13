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
    public abstract class _AnioData : EntityData<Anio,AnioFilter,AnioResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Anio entity)
		{			
			return entity.IdAnio;
		}		
		public override Anio GetByEntity(Anio entity)
        {
            return this.GetById(entity.IdAnio);
        }
        public override Anio GetById(int id)
        {
            return (from o in this.Table where o.IdAnio == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Anio> Query(AnioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdAnio == null || o.IdAnio >=  filter.IdAnio) && (filter.IdAnio_To == null || o.IdAnio <= filter.IdAnio_To)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<AnioResult> QueryResult(AnioFilter filter)
        {
		  return (from o in Query(filter)					
					select new AnioResult(){
					 IdAnio=o.IdAnio
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Anio Copy(nc.Anio entity)
        {           
            nc.Anio _new = new nc.Anio();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Anio entity,string renameFormat)
        {
            Anio  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Anio entity, int id)
        {            
            entity.IdAnio = id;            
        }
		public override void Set(Anio source,Anio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAnio= source.IdAnio ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(AnioResult source,Anio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAnio= source.IdAnio ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Anio source,AnioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAnio= source.IdAnio ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(AnioResult source,AnioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAnio= source.IdAnio ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Anio source,Anio target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAnio.Equals(target.IdAnio))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(AnioResult source,AnioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAnio.Equals(target.IdAnio))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
