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
    public abstract class _IndicadorSectorData : EntityData<IndicadorSector,IndicadorSectorFilter,IndicadorSectorResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorSector entity)
		{			
			return entity.IdIndicadorSector;
		}		
		public override IndicadorSector GetByEntity(IndicadorSector entity)
        {
            return this.GetById(entity.IdIndicadorSector);
        }
        public override IndicadorSector GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorSector == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorSector> Query(IndicadorSectorFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorSector == null || filter.IdIndicadorSector == 0 || o.IdIndicadorSector==filter.IdIndicadorSector)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorSectorResult> QueryResult(IndicadorSectorFilter filter)
        {
		  return (from o in Query(filter)					
					select new IndicadorSectorResult(){
					 IdIndicadorSector=o.IdIndicadorSector
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorSector Copy(nc.IndicadorSector entity)
        {           
            nc.IndicadorSector _new = new nc.IndicadorSector();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(IndicadorSector entity, int id)
        {            
            entity.IdIndicadorSector = id;            
        }
		public override void Set(IndicadorSector source,IndicadorSector target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorSector= source.IdIndicadorSector ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorSectorResult source,IndicadorSector target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorSector= source.IdIndicadorSector ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorSector source,IndicadorSectorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorSector= source.IdIndicadorSector ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorSectorResult source,IndicadorSectorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorSector= source.IdIndicadorSector ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorSector source,IndicadorSector target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorSector.Equals(target.IdIndicadorSector))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorSectorResult source,IndicadorSectorResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorSector.Equals(target.IdIndicadorSector))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
