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
    public abstract class _ProyectoOrigenFinanciamientoTipoData : EntityData<ProyectoOrigenFinanciamientoTipo,ProyectoOrigenFinanciamientoTipoFilter,ProyectoOrigenFinanciamientoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoOrigenFinanciamientoTipo entity)
		{			
			return entity.IdProyectoOrigenFinancianmientoTipo;
		}		
		public override ProyectoOrigenFinanciamientoTipo GetByEntity(ProyectoOrigenFinanciamientoTipo entity)
        {
            return this.GetById(entity.IdProyectoOrigenFinancianmientoTipo);
        }
        public override ProyectoOrigenFinanciamientoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoOrigenFinancianmientoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoOrigenFinanciamientoTipo> Query(ProyectoOrigenFinanciamientoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoOrigenFinancianmientoTipo == null || filter.IdProyectoOrigenFinancianmientoTipo == 0 || o.IdProyectoOrigenFinancianmientoTipo==filter.IdProyectoOrigenFinancianmientoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoOrigenFinanciamientoTipoResult> QueryResult(ProyectoOrigenFinanciamientoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ProyectoOrigenFinanciamientoTipoResult(){
					 IdProyectoOrigenFinancianmientoTipo=o.IdProyectoOrigenFinancianmientoTipo
					 ,Nombre=o.Nombre
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoOrigenFinanciamientoTipo Copy(nc.ProyectoOrigenFinanciamientoTipo entity)
        {           
            nc.ProyectoOrigenFinanciamientoTipo _new = new nc.ProyectoOrigenFinanciamientoTipo();
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(ProyectoOrigenFinanciamientoTipo entity,string renameFormat)
        {
            ProyectoOrigenFinanciamientoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoOrigenFinanciamientoTipo entity, int id)
        {            
            entity.IdProyectoOrigenFinancianmientoTipo = id;            
        }
		public override void Set(ProyectoOrigenFinanciamientoTipo source,ProyectoOrigenFinanciamientoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(ProyectoOrigenFinanciamientoTipoResult source,ProyectoOrigenFinanciamientoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(ProyectoOrigenFinanciamientoTipo source,ProyectoOrigenFinanciamientoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(ProyectoOrigenFinanciamientoTipoResult source,ProyectoOrigenFinanciamientoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.Nombre= source.Nombre ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoOrigenFinanciamientoTipo source,ProyectoOrigenFinanciamientoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOrigenFinancianmientoTipo.Equals(target.IdProyectoOrigenFinancianmientoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ProyectoOrigenFinanciamientoTipoResult source,ProyectoOrigenFinanciamientoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOrigenFinancianmientoTipo.Equals(target.IdProyectoOrigenFinancianmientoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
