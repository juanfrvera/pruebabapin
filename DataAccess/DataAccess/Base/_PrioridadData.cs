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
    public abstract class _PrioridadData : EntityData<Prioridad,PrioridadFilter,PrioridadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Prioridad entity)
		{			
			return entity.IdPrioridad;
		}		
		public override Prioridad GetByEntity(Prioridad entity)
        {
            return this.GetById(entity.IdPrioridad);
        }
        public override Prioridad GetById(int id)
        {
            return (from o in this.Table where o.IdPrioridad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Prioridad> Query(PrioridadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrioridad == null || filter.IdPrioridad == 0 || o.IdPrioridad==filter.IdPrioridad)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrioridadResult> QueryResult(PrioridadFilter filter)
        {
		  return (from o in Query(filter)					
					select new PrioridadResult(){
					 IdPrioridad=o.IdPrioridad
					 ,Sigla=o.Sigla
					 ,Orden=o.Orden
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Prioridad Copy(nc.Prioridad entity)
        {           
            nc.Prioridad _new = new nc.Prioridad();
		 _new.Sigla= entity.Sigla;
		 _new.Orden= entity.Orden;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Prioridad entity,string renameFormat)
        {
            Prioridad  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Prioridad entity, int id)
        {            
            entity.IdPrioridad = id;            
        }
		public override void Set(Prioridad source,Prioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrioridad= source.IdPrioridad ;
		 target.Sigla= source.Sigla ;
		 target.Orden= source.Orden ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PrioridadResult source,Prioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrioridad= source.IdPrioridad ;
		 target.Sigla= source.Sigla ;
		 target.Orden= source.Orden ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Prioridad source,PrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrioridad= source.IdPrioridad ;
		 target.Sigla= source.Sigla ;
		 target.Orden= source.Orden ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PrioridadResult source,PrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrioridad= source.IdPrioridad ;
		 target.Sigla= source.Sigla ;
		 target.Orden= source.Orden ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Prioridad source,Prioridad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrioridad.Equals(target.IdPrioridad))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PrioridadResult source,PrioridadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrioridad.Equals(target.IdPrioridad))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
