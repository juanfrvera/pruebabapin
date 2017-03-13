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
    public abstract class _IndicadorTipoData : EntityData<IndicadorTipo,IndicadorTipoFilter,IndicadorTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorTipo entity)
		{			
			return entity.IdIndicadorTipo;
		}		
		public override IndicadorTipo GetByEntity(IndicadorTipo entity)
        {
            return this.GetById(entity.IdIndicadorTipo);
        }
        public override IndicadorTipo GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorTipo> Query(IndicadorTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorTipo == null || filter.IdIndicadorTipo == 0 || o.IdIndicadorTipo==filter.IdIndicadorTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.SectorRequerido == null || o.SectorRequerido==filter.SectorRequerido)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorTipoResult> QueryResult(IndicadorTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new IndicadorTipoResult(){
					 IdIndicadorTipo=o.IdIndicadorTipo
					 ,Nombre=o.Nombre
					 ,SectorRequerido=o.SectorRequerido
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorTipo Copy(nc.IndicadorTipo entity)
        {           
            nc.IndicadorTipo _new = new nc.IndicadorTipo();
		 _new.Nombre= entity.Nombre;
		 _new.SectorRequerido= entity.SectorRequerido;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(IndicadorTipo entity,string renameFormat)
        {
            IndicadorTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorTipo entity, int id)
        {            
            entity.IdIndicadorTipo = id;            
        }
		public override void Set(IndicadorTipo source,IndicadorTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Nombre= source.Nombre ;
		 target.SectorRequerido= source.SectorRequerido ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorTipoResult source,IndicadorTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Nombre= source.Nombre ;
		 target.SectorRequerido= source.SectorRequerido ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorTipo source,IndicadorTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Nombre= source.Nombre ;
		 target.SectorRequerido= source.SectorRequerido ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorTipoResult source,IndicadorTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Nombre= source.Nombre ;
		 target.SectorRequerido= source.SectorRequerido ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorTipo source,IndicadorTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorTipo.Equals(target.IdIndicadorTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.SectorRequerido.Equals(target.SectorRequerido))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorTipoResult source,IndicadorTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorTipo.Equals(target.IdIndicadorTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.SectorRequerido.Equals(target.SectorRequerido))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
