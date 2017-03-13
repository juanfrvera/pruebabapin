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
    public abstract class _MonedaData : EntityData<Moneda,MonedaFilter,MonedaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Moneda entity)
		{			
			return entity.IdMoneda;
		}		
		public override Moneda GetByEntity(Moneda entity)
        {
            return this.GetById(entity.IdMoneda);
        }
        public override Moneda GetById(int id)
        {
            return (from o in this.Table where o.IdMoneda == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Moneda> Query(MonedaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMoneda == null || filter.IdMoneda == 0 || o.IdMoneda==filter.IdMoneda)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.Base == null || o.Base==filter.Base)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MonedaResult> QueryResult(MonedaFilter filter)
        {
		  return (from o in Query(filter)					
					select new MonedaResult(){
					 IdMoneda=o.IdMoneda
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					 ,Base=o.Base
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Moneda Copy(nc.Moneda entity)
        {           
            nc.Moneda _new = new nc.Moneda();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		 _new.Base= entity.Base;
		return _new;			
        }
		public override int CopyAndSave(Moneda entity,string renameFormat)
        {
            Moneda  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Moneda entity, int id)
        {            
            entity.IdMoneda = id;            
        }
		public override void Set(Moneda source,Moneda target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMoneda= source.IdMoneda ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Base= source.Base ;
		 		  
		}
		public override void Set(MonedaResult source,Moneda target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMoneda= source.IdMoneda ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Base= source.Base ;
		 
		}
		public override void Set(Moneda source,MonedaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMoneda= source.IdMoneda ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Base= source.Base ;
		 	
		}		
		public override void Set(MonedaResult source,MonedaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMoneda= source.IdMoneda ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Base= source.Base ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Moneda source,Moneda target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.Base.Equals(target.Base))return false;
		 
		  return true;
        }
		public override bool Equals(MonedaResult source,MonedaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.Base.Equals(target.Base))return false;
		 		
		  return true;
        }
		#endregion
    }
}
