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
    public abstract class _IndicadorData : EntityData<Indicador,IndicadorFilter,IndicadorResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Indicador entity)
		{			
			return entity.IdIndicador;
		}		
		public override Indicador GetByEntity(Indicador entity)
        {
            return this.GetById(entity.IdIndicador);
        }
        public override Indicador GetById(int id)
        {
            return (from o in this.Table where o.IdIndicador == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Indicador> Query(IndicadorFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador==filter.IdIndicador)
					  && (filter.IdMedioVerificacion == null || filter.IdMedioVerificacion == 0 || o.IdMedioVerificacion==filter.IdMedioVerificacion)
					  && (filter.IdMedioVerificacionIsNull == null || filter.IdMedioVerificacionIsNull == true || o.IdMedioVerificacion != null ) && (filter.IdMedioVerificacionIsNull == null || filter.IdMedioVerificacionIsNull == false || o.IdMedioVerificacion == null)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorResult> QueryResult(IndicadorFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.MedioVerificacions on o.IdMedioVerificacion equals _t1.IdMedioVerificacion into tt1 from t1 in tt1.DefaultIfEmpty()
				   select new IndicadorResult(){
					 IdIndicador=o.IdIndicador
					 ,IdMedioVerificacion=o.IdMedioVerificacion
					 ,Observacion=o.Observacion
                     ,DetalleMedioVerificacion = o.DetalleMedioVerificacion
					,MedioVerificacion_Sigla= t1!=null?(string)t1.Sigla:null	
						,MedioVerificacion_Nombre= t1!=null?(string)t1.Nombre:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Indicador Copy(nc.Indicador entity)
        {           
            nc.Indicador _new = new nc.Indicador();
		 _new.IdMedioVerificacion= entity.IdMedioVerificacion;
		 _new.Observacion= entity.Observacion;
         _new.DetalleMedioVerificacion = entity.DetalleMedioVerificacion;
		return _new;			
        }
		public override int CopyAndSave(Indicador entity,string renameFormat)
        {
            Indicador  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Indicador entity, int id)
        {            
            entity.IdIndicador = id;            
        }
		public override void Set(Indicador source,Indicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
         target.DetalleMedioVerificacion = source.DetalleMedioVerificacion;
		 		  
		}
		public override void Set(IndicadorResult source,Indicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
         target.DetalleMedioVerificacion = source.DetalleMedioVerificacion;
		}
		public override void Set(Indicador source,IndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
         target.DetalleMedioVerificacion = source.DetalleMedioVerificacion;
		}		
		public override void Set(IndicadorResult source,IndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicador= source.IdIndicador ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
		 target.MedioVerificacion_Sigla= source.MedioVerificacion_Sigla;	
			target.MedioVerificacion_Nombre= source.MedioVerificacion_Nombre;
            target.DetalleMedioVerificacion = source.DetalleMedioVerificacion;
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Indicador source,Indicador target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if((source.IdMedioVerificacion == null)?(target.IdMedioVerificacion.HasValue && target.IdMedioVerificacion.Value > 0):!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
						  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(IndicadorResult source,IndicadorResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if((source.IdMedioVerificacion == null)?(target.IdMedioVerificacion.HasValue && target.IdMedioVerificacion.Value > 0):!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
						  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.MedioVerificacion_Sigla == null)?target.MedioVerificacion_Sigla!=null: !( (target.MedioVerificacion_Sigla== String.Empty && source.MedioVerificacion_Sigla== null) || (target.MedioVerificacion_Sigla==null && source.MedioVerificacion_Sigla== String.Empty )) &&   !source.MedioVerificacion_Sigla.Trim().Replace ("\r","").Equals(target.MedioVerificacion_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.MedioVerificacion_Nombre == null)?target.MedioVerificacion_Nombre!=null: !( (target.MedioVerificacion_Nombre== String.Empty && source.MedioVerificacion_Nombre== null) || (target.MedioVerificacion_Nombre==null && source.MedioVerificacion_Nombre== String.Empty )) &&   !source.MedioVerificacion_Nombre.Trim().Replace ("\r","").Equals(target.MedioVerificacion_Nombre.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
