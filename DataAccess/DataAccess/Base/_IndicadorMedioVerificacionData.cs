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
    public abstract class _IndicadorMedioVerificacionData : EntityData<IndicadorMedioVerificacion,IndicadorMedioVerificacionFilter,IndicadorMedioVerificacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorMedioVerificacion entity)
		{			
			return entity.IdIndicadorMedioVerificacion;
		}		
		public override IndicadorMedioVerificacion GetByEntity(IndicadorMedioVerificacion entity)
        {
            return this.GetById(entity.IdIndicadorMedioVerificacion);
        }
        public override IndicadorMedioVerificacion GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorMedioVerificacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorMedioVerificacion> Query(IndicadorMedioVerificacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorMedioVerificacion == null || o.IdIndicadorMedioVerificacion >=  filter.IdIndicadorMedioVerificacion) && (filter.IdIndicadorMedioVerificacion_To == null || o.IdIndicadorMedioVerificacion <= filter.IdIndicadorMedioVerificacion_To)
					  && (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador==filter.IdIndicador)
					  && (filter.IdMedioVerificacion == null || filter.IdMedioVerificacion == 0 || o.IdMedioVerificacion==filter.IdMedioVerificacion)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorMedioVerificacionResult> QueryResult(IndicadorMedioVerificacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.IndicadorClases on o.IdIndicador equals t1.IdIndicadorClase   
				    join t2  in this.Context.MedioVerificacions on o.IdMedioVerificacion equals t2.IdMedioVerificacion   
				   select new IndicadorMedioVerificacionResult(){
					 IdIndicadorMedioVerificacion=o.IdIndicadorMedioVerificacion
					 ,IdIndicador=o.IdIndicador
					 ,IdMedioVerificacion=o.IdMedioVerificacion
					,Indicador_IdIndicadorTipo= t1.IdIndicadorTipo	
						,Indicador_Sigla= t1.Sigla	
						,Indicador_Nombre= t1.Nombre	
						,Indicador_IdUnidad= t1.IdUnidad	
						,Indicador_RangoInicial= t1.RangoInicial	
						,Indicador_RangoFinal= t1.RangoFinal	
						,Indicador_Activo= t1.Activo	
						,MedioVerificacion_Sigla= t2.Sigla	
						,MedioVerificacion_Nombre= t2.Nombre	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorMedioVerificacion Copy(nc.IndicadorMedioVerificacion entity)
        {           
            nc.IndicadorMedioVerificacion _new = new nc.IndicadorMedioVerificacion();
		 _new.IdIndicador= entity.IdIndicador;
		 _new.IdMedioVerificacion= entity.IdMedioVerificacion;
		return _new;			
        }
		public override int CopyAndSave(IndicadorMedioVerificacion entity,string renameFormat)
        {
            IndicadorMedioVerificacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorMedioVerificacion entity, int id)
        {            
            entity.IdIndicadorMedioVerificacion = id;            
        }
		public override void Set(IndicadorMedioVerificacion source,IndicadorMedioVerificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorMedioVerificacion= source.IdIndicadorMedioVerificacion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 		  
		}
		public override void Set(IndicadorMedioVerificacionResult source,IndicadorMedioVerificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorMedioVerificacion= source.IdIndicadorMedioVerificacion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 
		}
		public override void Set(IndicadorMedioVerificacion source,IndicadorMedioVerificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorMedioVerificacion= source.IdIndicadorMedioVerificacion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 	
		}		
		public override void Set(IndicadorMedioVerificacionResult source,IndicadorMedioVerificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorMedioVerificacion= source.IdIndicadorMedioVerificacion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Indicador_IdIndicadorTipo= source.Indicador_IdIndicadorTipo;	
			target.Indicador_Sigla= source.Indicador_Sigla;	
			target.Indicador_Nombre= source.Indicador_Nombre;	
			target.Indicador_IdUnidad= source.Indicador_IdUnidad;	
			target.Indicador_RangoInicial= source.Indicador_RangoInicial;	
			target.Indicador_RangoFinal= source.Indicador_RangoFinal;	
			target.Indicador_Activo= source.Indicador_Activo;	
			target.MedioVerificacion_Sigla= source.MedioVerificacion_Sigla;	
			target.MedioVerificacion_Nombre= source.MedioVerificacion_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorMedioVerificacion source,IndicadorMedioVerificacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorMedioVerificacion.Equals(target.IdIndicadorMedioVerificacion))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if(!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorMedioVerificacionResult source,IndicadorMedioVerificacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorMedioVerificacion.Equals(target.IdIndicadorMedioVerificacion))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if(!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
		  if(!source.Indicador_IdIndicadorTipo.Equals(target.Indicador_IdIndicadorTipo))return false;
					  if((source.Indicador_Sigla == null)?target.Indicador_Sigla!=null: !( (target.Indicador_Sigla== String.Empty && source.Indicador_Sigla== null) || (target.Indicador_Sigla==null && source.Indicador_Sigla== String.Empty )) &&   !source.Indicador_Sigla.Trim().Replace ("\r","").Equals(target.Indicador_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.Indicador_Nombre == null)?target.Indicador_Nombre!=null: !( (target.Indicador_Nombre== String.Empty && source.Indicador_Nombre== null) || (target.Indicador_Nombre==null && source.Indicador_Nombre== String.Empty )) &&   !source.Indicador_Nombre.Trim().Replace ("\r","").Equals(target.Indicador_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Indicador_IdUnidad.Equals(target.Indicador_IdUnidad))return false;
					  if((source.Indicador_RangoInicial == null)?(target.Indicador_RangoInicial.HasValue ):!source.Indicador_RangoInicial.Equals(target.Indicador_RangoInicial))return false;
						 if((source.Indicador_RangoFinal == null)?(target.Indicador_RangoFinal.HasValue ):!source.Indicador_RangoFinal.Equals(target.Indicador_RangoFinal))return false;
						 if(!source.Indicador_Activo.Equals(target.Indicador_Activo))return false;
					  if((source.MedioVerificacion_Sigla == null)?target.MedioVerificacion_Sigla!=null: !( (target.MedioVerificacion_Sigla== String.Empty && source.MedioVerificacion_Sigla== null) || (target.MedioVerificacion_Sigla==null && source.MedioVerificacion_Sigla== String.Empty )) &&   !source.MedioVerificacion_Sigla.Trim().Replace ("\r","").Equals(target.MedioVerificacion_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.MedioVerificacion_Nombre == null)?target.MedioVerificacion_Nombre!=null: !( (target.MedioVerificacion_Nombre== String.Empty && source.MedioVerificacion_Nombre== null) || (target.MedioVerificacion_Nombre==null && source.MedioVerificacion_Nombre== String.Empty )) &&   !source.MedioVerificacion_Nombre.Trim().Replace ("\r","").Equals(target.MedioVerificacion_Nombre.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
