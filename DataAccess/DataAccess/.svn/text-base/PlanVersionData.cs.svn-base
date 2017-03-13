using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PlanVersionData : _PlanVersionData 
    { 
	   #region Singleton
	   private static volatile PlanVersionData current;
	   private static object syncRoot = new Object();

	   //private PlanVersionData() {}
	   public static PlanVersionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanVersionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPlanVersion"; } }

       
        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PlanVersion entity)
		{			
			return entity.IdPlanVersion;
		}		
		public override PlanVersion GetByEntity(PlanVersion entity)
        {
            return this.GetById(entity.IdPlanVersion);
        }
        public override PlanVersion GetById(int id)
        {
            return (from o in this.Table where o.IdPlanVersion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
        protected override IQueryable<PlanVersion> Query(PlanVersionFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || o.IdPlanVersion == filter.IdPlanVersion)
                      && (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || o.IdPlanTipo == filter.IdPlanTipo)
                      && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                      && (filter.Orden == null || o.Orden >= filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
                      && (filter.Activo == null || o.Activo == filter.Activo)
                      && (filter.IdPlanPeriodoActivo == null || filter.IdPlanPeriodoActivo == 0 ||
                       (from ppva in this.Context.PlanPeriodoVersionActivas
                        where ppva.IdPlanPeriodo == filter.IdPlanPeriodoActivo
                        select ppva.IdPlanVersion
                             ).Contains(o.IdPlanVersion))
                    select o);
        }
        //protected override IQueryable<PlanVersion> Query(PlanVersionFilter filter)
        //{
        //    return (from o in this.Table
        //              where (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || o.IdPlanVersion==filter.IdPlanVersion)
        //              && (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || o.IdPlanTipo==filter.IdPlanTipo)
        //              && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
        //              && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
        //              && (filter.Activo == null || o.Activo==filter.Activo)
        //              select o
        //            ).AsQueryable();
        //}	
        protected override IQueryable<PlanVersionResult> QueryResult(PlanVersionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PlanTipos on o.IdPlanTipo equals t1.IdPlanTipo   
				   select new PlanVersionResult(){
					 IdPlanVersion=o.IdPlanVersion
					 ,IdPlanTipo=o.IdPlanTipo
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					,PlanTipo_Sigla= t1.Sigla	
						,PlanTipo_Nombre= t1.Nombre	
						,PlanTipo_Orden= t1.Orden	
						,PlanTipo_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PlanVersion Copy(nc.PlanVersion entity)
        {           
            nc.PlanVersion _new = new nc.PlanVersion();
		 _new.IdPlanTipo= entity.IdPlanTipo;
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(PlanVersion entity,string renameFormat)
        {
            PlanVersion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PlanVersion entity, int id)
        {            
            entity.IdPlanVersion = id;            
        }
		public override void Set(PlanVersion source,PlanVersion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanVersion= source.IdPlanVersion ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PlanVersionResult source,PlanVersion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanVersion= source.IdPlanVersion ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(PlanVersion source,PlanVersionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanVersion= source.IdPlanVersion ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PlanVersionResult source,PlanVersionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanVersion= source.IdPlanVersion ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.PlanTipo_Sigla= source.PlanTipo_Sigla;	
			target.PlanTipo_Nombre= source.PlanTipo_Nombre;	
			target.PlanTipo_Orden= source.PlanTipo_Orden;	
			target.PlanTipo_Activo= source.PlanTipo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PlanVersion source,PlanVersion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		  if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PlanVersionResult source,PlanVersionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		  if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.PlanTipo_Sigla == null)?target.PlanTipo_Sigla!=null:!source.PlanTipo_Sigla.Equals(target.PlanTipo_Sigla))return false;
						 if((source.PlanTipo_Nombre == null)?target.PlanTipo_Nombre!=null:!source.PlanTipo_Nombre.Equals(target.PlanTipo_Nombre))return false;
						 if(!source.PlanTipo_Orden.Equals(target.PlanTipo_Orden))return false;
					  if(!source.PlanTipo_Activo.Equals(target.PlanTipo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }

    
}
