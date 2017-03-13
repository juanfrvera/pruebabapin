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
    public abstract class _CargoData : EntityData<Cargo,CargoFilter,CargoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Cargo entity)
		{			
			return entity.IdCargo;
		}		
		public override Cargo GetByEntity(Cargo entity)
        {
            return this.GetById(entity.IdCargo);
        }
        public override Cargo GetById(int id)
        {
            return (from o in this.Table where o.IdCargo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Cargo> Query(CargoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdCargo == null || filter.IdCargo == 0 || o.IdCargo==filter.IdCargo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<CargoResult> QueryResult(CargoFilter filter)
        {
		  return (from o in Query(filter)					
					select new CargoResult(){
					 IdCargo=o.IdCargo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					 ,Codigo=o.Codigo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Cargo Copy(nc.Cargo entity)
        {           
            nc.Cargo _new = new nc.Cargo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		 _new.Codigo= entity.Codigo;
		return _new;			
        }
		public override int CopyAndSave(Cargo entity,string renameFormat)
        {
            Cargo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Cargo entity, int id)
        {            
            entity.IdCargo = id;            
        }
		public override void Set(Cargo source,Cargo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCargo= source.IdCargo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Codigo= source.Codigo ;
		 		  
		}
		public override void Set(CargoResult source,Cargo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCargo= source.IdCargo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Codigo= source.Codigo ;
		 
		}
		public override void Set(Cargo source,CargoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCargo= source.IdCargo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Codigo= source.Codigo ;
		 	
		}		
		public override void Set(CargoResult source,CargoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCargo= source.IdCargo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Codigo= source.Codigo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Cargo source,Cargo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCargo.Equals(target.IdCargo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(CargoResult source,CargoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCargo.Equals(target.IdCargo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
