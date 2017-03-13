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
    public abstract class _JurisdiccionData : EntityData<Jurisdiccion,JurisdiccionFilter,JurisdiccionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Jurisdiccion entity)
		{			
			return entity.IdJurisdiccion;
		}		
		public override Jurisdiccion GetByEntity(Jurisdiccion entity)
        {
            return this.GetById(entity.IdJurisdiccion);
        }
        public override Jurisdiccion GetById(int id)
        {
            return (from o in this.Table where o.IdJurisdiccion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Jurisdiccion> Query(JurisdiccionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || o.IdJurisdiccion==filter.IdJurisdiccion)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<JurisdiccionResult> QueryResult(JurisdiccionFilter filter)
        {
		  return (from o in Query(filter)					
					select new JurisdiccionResult(){
					 IdJurisdiccion=o.IdJurisdiccion
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Jurisdiccion Copy(nc.Jurisdiccion entity)
        {           
            nc.Jurisdiccion _new = new nc.Jurisdiccion();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Jurisdiccion entity,string renameFormat)
        {
            Jurisdiccion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Jurisdiccion entity, int id)
        {            
            entity.IdJurisdiccion = id;            
        }
		public override void Set(Jurisdiccion source,Jurisdiccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(JurisdiccionResult source,Jurisdiccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Jurisdiccion source,JurisdiccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(JurisdiccionResult source,JurisdiccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Jurisdiccion source,Jurisdiccion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdJurisdiccion.Equals(target.IdJurisdiccion))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(JurisdiccionResult source,JurisdiccionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdJurisdiccion.Equals(target.IdJurisdiccion))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
