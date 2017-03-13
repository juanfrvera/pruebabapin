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
    public abstract class _UnidadMedidaData : EntityData<UnidadMedida,UnidadMedidaFilter,UnidadMedidaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.UnidadMedida entity)
		{			
			return entity.IdUnidadMedida;
		}		
		public override UnidadMedida GetByEntity(UnidadMedida entity)
        {
            return this.GetById(entity.IdUnidadMedida);
        }
        public override UnidadMedida GetById(int id)
        {
            return (from o in this.Table where o.IdUnidadMedida == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<UnidadMedida> Query(UnidadMedidaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdUnidadMedida == null || filter.IdUnidadMedida == 0 || o.IdUnidadMedida==filter.IdUnidadMedida)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<UnidadMedidaResult> QueryResult(UnidadMedidaFilter filter)
        {
		  return (from o in Query(filter)					
					select new UnidadMedidaResult(){
					 IdUnidadMedida=o.IdUnidadMedida
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.UnidadMedida Copy(nc.UnidadMedida entity)
        {           
            nc.UnidadMedida _new = new nc.UnidadMedida();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(UnidadMedida entity,string renameFormat)
        {
            UnidadMedida  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(UnidadMedida entity, int id)
        {            
            entity.IdUnidadMedida = id;            
        }
		public override void Set(UnidadMedida source,UnidadMedida target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(UnidadMedidaResult source,UnidadMedida target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(UnidadMedida source,UnidadMedidaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(UnidadMedidaResult source,UnidadMedidaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(UnidadMedida source,UnidadMedida target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUnidadMedida.Equals(target.IdUnidadMedida))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(UnidadMedidaResult source,UnidadMedidaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUnidadMedida.Equals(target.IdUnidadMedida))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
