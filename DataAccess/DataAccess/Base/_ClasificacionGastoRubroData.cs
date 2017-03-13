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
    public abstract class _ClasificacionGastoRubroData : EntityData<ClasificacionGastoRubro,ClasificacionGastoRubroFilter,ClasificacionGastoRubroResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ClasificacionGastoRubro entity)
		{			
			return entity.IdClasificacionGastoRubro;
		}		
		public override ClasificacionGastoRubro GetByEntity(ClasificacionGastoRubro entity)
        {
            return this.GetById(entity.IdClasificacionGastoRubro);
        }
        public override ClasificacionGastoRubro GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacionGastoRubro == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ClasificacionGastoRubro> Query(ClasificacionGastoRubroFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacionGastoRubro == null || filter.IdClasificacionGastoRubro == 0 || o.IdClasificacionGastoRubro==filter.IdClasificacionGastoRubro)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionGastoRubroResult> QueryResult(ClasificacionGastoRubroFilter filter)
        {
		  return (from o in Query(filter)					
					select new ClasificacionGastoRubroResult(){
					 IdClasificacionGastoRubro=o.IdClasificacionGastoRubro
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ClasificacionGastoRubro Copy(nc.ClasificacionGastoRubro entity)
        {           
            nc.ClasificacionGastoRubro _new = new nc.ClasificacionGastoRubro();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(ClasificacionGastoRubro entity,string renameFormat)
        {
            ClasificacionGastoRubro  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ClasificacionGastoRubro entity, int id)
        {            
            entity.IdClasificacionGastoRubro = id;            
        }
		public override void Set(ClasificacionGastoRubro source,ClasificacionGastoRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(ClasificacionGastoRubroResult source,ClasificacionGastoRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(ClasificacionGastoRubro source,ClasificacionGastoRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(ClasificacionGastoRubroResult source,ClasificacionGastoRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ClasificacionGastoRubro source,ClasificacionGastoRubro target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGastoRubro.Equals(target.IdClasificacionGastoRubro))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ClasificacionGastoRubroResult source,ClasificacionGastoRubroResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGastoRubro.Equals(target.IdClasificacionGastoRubro))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
