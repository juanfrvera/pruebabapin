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
    public abstract class _FaseData : EntityData<Fase,FaseFilter,FaseResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Fase entity)
		{			
			return entity.IdFase;
		}		
		public override Fase GetByEntity(Fase entity)
        {
            return this.GetById(entity.IdFase);
        }
        public override Fase GetById(int id)
        {
            return (from o in this.Table where o.IdFase == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Fase> Query(FaseFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFase == null || filter.IdFase == 0 || o.IdFase==filter.IdFase)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<FaseResult> QueryResult(FaseFilter filter)
        {
		  return (from o in Query(filter)					
					select new FaseResult(){
					 IdFase=o.IdFase
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Fase Copy(nc.Fase entity)
        {           
            nc.Fase _new = new nc.Fase();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Fase entity,string renameFormat)
        {
            Fase  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Fase entity, int id)
        {            
            entity.IdFase = id;            
        }
		public override void Set(Fase source,Fase target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(FaseResult source,Fase target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Fase source,FaseResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(FaseResult source,FaseResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Fase source,Fase target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFase.Equals(target.IdFase))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(FaseResult source,FaseResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFase.Equals(target.IdFase))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
