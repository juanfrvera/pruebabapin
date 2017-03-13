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
    public abstract class _MedioVerificacionData : EntityData<MedioVerificacion,MedioVerificacionFilter,MedioVerificacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.MedioVerificacion entity)
		{			
			return entity.IdMedioVerificacion;
		}		
		public override MedioVerificacion GetByEntity(MedioVerificacion entity)
        {
            return this.GetById(entity.IdMedioVerificacion);
        }
        public override MedioVerificacion GetById(int id)
        {
            return (from o in this.Table where o.IdMedioVerificacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<MedioVerificacion> Query(MedioVerificacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMedioVerificacion == null || filter.IdMedioVerificacion == 0 || o.IdMedioVerificacion==filter.IdMedioVerificacion)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MedioVerificacionResult> QueryResult(MedioVerificacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new MedioVerificacionResult(){
					 IdMedioVerificacion=o.IdMedioVerificacion
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.MedioVerificacion Copy(nc.MedioVerificacion entity)
        {           
            nc.MedioVerificacion _new = new nc.MedioVerificacion();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(MedioVerificacion entity,string renameFormat)
        {
            MedioVerificacion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(MedioVerificacion entity, int id)
        {            
            entity.IdMedioVerificacion = id;            
        }
		public override void Set(MedioVerificacion source,MedioVerificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(MedioVerificacionResult source,MedioVerificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(MedioVerificacion source,MedioVerificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(MedioVerificacionResult source,MedioVerificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(MedioVerificacion source,MedioVerificacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(MedioVerificacionResult source,MedioVerificacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
