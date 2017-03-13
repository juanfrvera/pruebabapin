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
    public abstract class _IndicadorObjetivoData : EntityData<IndicadorObjetivo,IndicadorObjetivoFilter,IndicadorObjetivoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorObjetivo entity)
		{			
			return entity.IdIndicadorPriorizacion;
		}		
		public override IndicadorObjetivo GetByEntity(IndicadorObjetivo entity)
        {
            return this.GetById(entity.IdIndicadorPriorizacion);
        }
        public override IndicadorObjetivo GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorPriorizacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorObjetivo> Query(IndicadorObjetivoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorPriorizacion == null || o.IdIndicadorPriorizacion >=  filter.IdIndicadorPriorizacion) && (filter.IdIndicadorPriorizacion_To == null || o.IdIndicadorPriorizacion <= filter.IdIndicadorPriorizacion_To)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdUnidadMedida == null || filter.IdUnidadMedida == 0 || o.IdUnidadMedida==filter.IdUnidadMedida)
					  && (filter.Funcion == null || filter.Funcion.Trim() == string.Empty || filter.Funcion.Trim() == "%"  || (filter.Funcion.EndsWith("%") && filter.Funcion.StartsWith("%") && (o.Funcion.Contains(filter.Funcion.Replace("%", "")))) || (filter.Funcion.EndsWith("%") && o.Funcion.StartsWith(filter.Funcion.Replace("%",""))) || (filter.Funcion.StartsWith("%") && o.Funcion.EndsWith(filter.Funcion.Replace("%",""))) || o.Funcion == filter.Funcion )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorObjetivoResult> QueryResult(IndicadorObjetivoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.UnidadMedidas on o.IdUnidadMedida equals t1.IdUnidadMedida   
				   select new IndicadorObjetivoResult(){
					 IdIndicadorPriorizacion=o.IdIndicadorPriorizacion
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,IdUnidadMedida=o.IdUnidadMedida
					 ,Funcion=o.Funcion
					 ,Activo=o.Activo
					,UnidadMedida_Sigla= t1.Sigla	
						,UnidadMedida_Nombre= t1.Nombre	
						,UnidadMedida_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorObjetivo Copy(nc.IndicadorObjetivo entity)
        {           
            nc.IndicadorObjetivo _new = new nc.IndicadorObjetivo();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.IdUnidadMedida= entity.IdUnidadMedida;
		 _new.Funcion= entity.Funcion;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(IndicadorObjetivo entity, int id)
        {            
            entity.IdIndicadorPriorizacion = id;            
        }
		public override void Set(IndicadorObjetivo source,IndicadorObjetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Funcion= source.Funcion ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorObjetivoResult source,IndicadorObjetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Funcion= source.Funcion ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorObjetivo source,IndicadorObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Funcion= source.Funcion ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorObjetivoResult source,IndicadorObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorPriorizacion= source.IdIndicadorPriorizacion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidadMedida= source.IdUnidadMedida ;
		 target.Funcion= source.Funcion ;
		 target.Activo= source.Activo ;
		 target.UnidadMedida_Sigla= source.UnidadMedida_Sigla;	
			target.UnidadMedida_Nombre= source.UnidadMedida_Nombre;	
			target.UnidadMedida_Activo= source.UnidadMedida_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorObjetivo source,IndicadorObjetivo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorPriorizacion.Equals(target.IdIndicadorPriorizacion))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.IdUnidadMedida.Equals(target.IdUnidadMedida))return false;
		  if(!source.Funcion.Equals(target.Funcion))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorObjetivoResult source,IndicadorObjetivoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorPriorizacion.Equals(target.IdIndicadorPriorizacion))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.IdUnidadMedida.Equals(target.IdUnidadMedida))return false;
		  if(!source.Funcion.Equals(target.Funcion))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.UnidadMedida_Sigla.Equals(target.UnidadMedida_Sigla))return false;
					  if(!source.UnidadMedida_Nombre.Equals(target.UnidadMedida_Nombre))return false;
					  if(!source.UnidadMedida_Activo.Equals(target.UnidadMedida_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
