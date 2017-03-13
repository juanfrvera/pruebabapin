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
    public abstract class _IndicadorRubroData : EntityData<IndicadorRubro,IndicadorRubroFilter,IndicadorRubroResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorRubro entity)
		{			
			return entity.IdIndicadorRubro;
		}		
		public override IndicadorRubro GetByEntity(IndicadorRubro entity)
        {
            return this.GetById(entity.IdIndicadorRubro);
        }
        public override IndicadorRubro GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorRubro == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorRubro> Query(IndicadorRubroFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorRubro == null || filter.IdIndicadorRubro == 0 || o.IdIndicadorRubro==filter.IdIndicadorRubro)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorRubroResult> QueryResult(IndicadorRubroFilter filter)
        {
		  return (from o in Query(filter)					
					select new IndicadorRubroResult(){
					 IdIndicadorRubro=o.IdIndicadorRubro
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorRubro Copy(nc.IndicadorRubro entity)
        {           
            nc.IndicadorRubro _new = new nc.IndicadorRubro();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(IndicadorRubro entity,string renameFormat)
        {
            IndicadorRubro  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorRubro entity, int id)
        {            
            entity.IdIndicadorRubro = id;            
        }
		public override void Set(IndicadorRubro source,IndicadorRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorRubroResult source,IndicadorRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorRubro source,IndicadorRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorRubroResult source,IndicadorRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorRubro source,IndicadorRubro target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorRubro.Equals(target.IdIndicadorRubro))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorRubroResult source,IndicadorRubroResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorRubro.Equals(target.IdIndicadorRubro))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
