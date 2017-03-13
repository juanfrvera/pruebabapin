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
    public abstract class _IndicadorPriorizacionData : EntityData<IndicadorPriorizacion,IndicadorPriorizacionFilter,IndicadorPriorizacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorPriorizacion entity)
		{			
			return entity.IdIndicadorPriorizacion;
		}		
		public override IndicadorPriorizacion GetByEntity(IndicadorPriorizacion entity)
        {
            return this.GetById(entity.IdIndicadorPriorizacion);
        }
        public override IndicadorPriorizacion GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorPriorizacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorPriorizacion> Query(IndicadorPriorizacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorPriorizacion == null || o.IdIndicadorPriorizacion >=  filter.IdIndicadorPriorizacion) && (filter.IdIndicadorPriorizacion_To == null || o.IdIndicadorPriorizacion <= filter.IdIndicadorPriorizacion_To)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorPriorizacionResult> QueryResult(IndicadorPriorizacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new IndicadorPriorizacionResult(){
					 IdIndicadorPriorizacion=o.IdIndicadorPriorizacion
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorPriorizacion Copy(nc.IndicadorPriorizacion entity)
        {           
            nc.IndicadorPriorizacion _new = new nc.IndicadorPriorizacion();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(IndicadorPriorizacion entity, int id)
        {            
            entity.IdIndicadorPriorizacion = id;            
        }
		public override void Set(IndicadorPriorizacion source,IndicadorPriorizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorPriorizacionResult source,IndicadorPriorizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorPriorizacion source,IndicadorPriorizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorPriorizacionResult source,IndicadorPriorizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorPriorizacion source,IndicadorPriorizacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorPriorizacion.Equals(target.IdIndicadorPriorizacion))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorPriorizacionResult source,IndicadorPriorizacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorPriorizacion.Equals(target.IdIndicadorPriorizacion))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
