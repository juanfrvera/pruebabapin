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
    public abstract class _ProyectoDictamenSeguimientoData : EntityData<ProyectoDictamenSeguimiento,ProyectoDictamenSeguimientoFilter,ProyectoDictamenSeguimientoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoDictamenSeguimiento entity)
		{			
			return entity.IdProyectoDictamenSeguimiento;
		}		
		public override ProyectoDictamenSeguimiento GetByEntity(ProyectoDictamenSeguimiento entity)
        {
            return this.GetById(entity.IdProyectoDictamenSeguimiento);
        }
        public override ProyectoDictamenSeguimiento GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoDictamenSeguimiento == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoDictamenSeguimiento> Query(ProyectoDictamenSeguimientoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoDictamenSeguimiento == null || o.IdProyectoDictamenSeguimiento >=  filter.IdProyectoDictamenSeguimiento) && (filter.IdProyectoDictamenSeguimiento_To == null || o.IdProyectoDictamenSeguimiento <= filter.IdProyectoDictamenSeguimiento_To)
					  && (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || o.IdProyectoDictamen==filter.IdProyectoDictamen)
					  && (filter.IdProyectoSeguimiento == null || filter.IdProyectoSeguimiento == 0 || o.IdProyectoSeguimiento==filter.IdProyectoSeguimiento)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoDictamenSeguimientoResult> QueryResult(ProyectoDictamenSeguimientoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoDictamens on o.IdProyectoDictamen equals t1.IdProyectoDictamen   
				    join t2  in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento   
				   select new ProyectoDictamenSeguimientoResult(){
					 IdProyectoDictamenSeguimiento=o.IdProyectoDictamenSeguimiento
					 ,IdProyectoDictamen=o.IdProyectoDictamen
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
                    //,ProyectoDictamen_IdProyectoCalificacion= t1.IdProyectoCalificacion	
                    //    ,ProyectoDictamen_Fecha= t1.Fecha	
                    //    ,ProyectoDictamen_FechaVencimiento= t1.FechaVencimiento	
                    //    ,ProyectoDictamen_IdPlanPeriodo= t1.IdPlanPeriodo	
                    //    ,ProyectoDictamen_Monto= t1.Monto	
                    //    ,ProyectoDictamen_Ejercicio= t1.Ejercicio	
                    //    ,ProyectoDictamen_DuracionMeses= t1.DuracionMeses	
                    //    ,ProyectoDictamen_InformeTecnico= t1.InformeTecnico	
                    //    ,ProyectoDictamen_FechaComiteTecnico= t1.FechaComiteTecnico	
                    //    ,ProyectoDictamen_Observacion= t1.Observacion	
                    //    ,ProyectoDictamen_Recomendacion= t1.Recomendacion	
                    //    ,ProyectoDictamen_RespuestaOrganismo= t1.RespuestaOrganismo	
                    //    ,ProyectoDictamen_FechaRepuesta= t1.FechaRepuesta	
                    //    ,ProyectoDictamen_IdEstado= t1.IdEstado	
                    //    ,ProyectoDictamen_FechaEstado= t1.FechaEstado	
                    //    ,ProyectoDictamen_Numero= t1.Numero	
                    //    ,ProyectoDictamen_Denominacion= t1.Denominacion	
                    //    ,ProyectoDictamen_IdFile= t1.IdFile	
                    //    ,ProyectoSeguimiento_IdSaf= t2.IdSaf	
                    //    ,ProyectoSeguimiento_Denominacion= t2.Denominacion	
                    //    ,ProyectoSeguimiento_Ruta= t2.Ruta	
                    //    ,ProyectoSeguimiento_Malla= t2.Malla	
                    //    ,ProyectoSeguimiento_IdAnalista= t2.IdAnalista	
                    //    ,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= t2.IdProyectoSeguimientoAnterior	
                    //    ,ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= t2.IdProyectoSeguimientoEstadoUltimo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoDictamenSeguimiento Copy(nc.ProyectoDictamenSeguimiento entity)
        {           
            nc.ProyectoDictamenSeguimiento _new = new nc.ProyectoDictamenSeguimiento();
		 _new.IdProyectoDictamen= entity.IdProyectoDictamen;
		 _new.IdProyectoSeguimiento= entity.IdProyectoSeguimiento;
		return _new;			
        }
		public override int CopyAndSave(ProyectoDictamenSeguimiento entity,string renameFormat)
        {
            ProyectoDictamenSeguimiento  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoDictamenSeguimiento entity, int id)
        {            
            entity.IdProyectoDictamenSeguimiento = id;            
        }
		public override void Set(ProyectoDictamenSeguimiento source,ProyectoDictamenSeguimiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenSeguimiento= source.IdProyectoDictamenSeguimiento ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 		  
		}
		public override void Set(ProyectoDictamenSeguimientoResult source,ProyectoDictamenSeguimiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenSeguimiento= source.IdProyectoDictamenSeguimiento ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 
		}
		public override void Set(ProyectoDictamenSeguimiento source,ProyectoDictamenSeguimientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenSeguimiento= source.IdProyectoDictamenSeguimiento ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 	
		}		
		public override void Set(ProyectoDictamenSeguimientoResult source,ProyectoDictamenSeguimientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenSeguimiento= source.IdProyectoDictamenSeguimiento ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
         //target.ProyectoDictamen_IdProyectoCalificacion= source.ProyectoDictamen_IdProyectoCalificacion;	
         //   target.ProyectoDictamen_Fecha= source.ProyectoDictamen_Fecha;	
         //   target.ProyectoDictamen_FechaVencimiento= source.ProyectoDictamen_FechaVencimiento;	
         //   target.ProyectoDictamen_IdPlanPeriodo= source.ProyectoDictamen_IdPlanPeriodo;	
         //   target.ProyectoDictamen_Monto= source.ProyectoDictamen_Monto;	
         //   target.ProyectoDictamen_Ejercicio= source.ProyectoDictamen_Ejercicio;	
         //   target.ProyectoDictamen_DuracionMeses= source.ProyectoDictamen_DuracionMeses;	
         //   target.ProyectoDictamen_InformeTecnico= source.ProyectoDictamen_InformeTecnico;	
         //   target.ProyectoDictamen_FechaComiteTecnico= source.ProyectoDictamen_FechaComiteTecnico;	
         //   target.ProyectoDictamen_Observacion= source.ProyectoDictamen_Observacion;	
         //   target.ProyectoDictamen_Recomendacion= source.ProyectoDictamen_Recomendacion;	
         //   target.ProyectoDictamen_RespuestaOrganismo= source.ProyectoDictamen_RespuestaOrganismo;	
         //   target.ProyectoDictamen_FechaRepuesta= source.ProyectoDictamen_FechaRepuesta;	
         //   target.ProyectoDictamen_IdEstado= source.ProyectoDictamen_IdEstado;	
         //   target.ProyectoDictamen_FechaEstado= source.ProyectoDictamen_FechaEstado;	
         //   target.ProyectoDictamen_Numero= source.ProyectoDictamen_Numero;	
         //   target.ProyectoDictamen_Denominacion= source.ProyectoDictamen_Denominacion;	
         //   target.ProyectoDictamen_IdFile= source.ProyectoDictamen_IdFile;	
         //   target.ProyectoSeguimiento_IdSaf= source.ProyectoSeguimiento_IdSaf;	
         //   target.ProyectoSeguimiento_Denominacion= source.ProyectoSeguimiento_Denominacion;	
         //   target.ProyectoSeguimiento_Ruta= source.ProyectoSeguimiento_Ruta;	
         //   target.ProyectoSeguimiento_Malla= source.ProyectoSeguimiento_Malla;	
         //   target.ProyectoSeguimiento_IdAnalista= source.ProyectoSeguimiento_IdAnalista;	
         //   target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior= source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior;	
         //   target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoDictamenSeguimiento source,ProyectoDictamenSeguimiento target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDictamenSeguimiento.Equals(target.IdProyectoDictamenSeguimiento))return false;
		  if(!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoDictamenSeguimientoResult source,ProyectoDictamenSeguimientoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDictamenSeguimiento.Equals(target.IdProyectoDictamenSeguimiento))return false;
		  if(!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
          //if((source.ProyectoDictamen_IdProyectoCalificacion == null)?(target.ProyectoDictamen_IdProyectoCalificacion.HasValue && target.ProyectoDictamen_IdProyectoCalificacion.Value > 0):!source.ProyectoDictamen_IdProyectoCalificacion.Equals(target.ProyectoDictamen_IdProyectoCalificacion))return false;
          //                            if((source.ProyectoDictamen_Fecha == null)?(target.ProyectoDictamen_Fecha.HasValue ):!source.ProyectoDictamen_Fecha.Equals(target.ProyectoDictamen_Fecha))return false;
          //               if((source.ProyectoDictamen_FechaVencimiento == null)?(target.ProyectoDictamen_FechaVencimiento.HasValue ):!source.ProyectoDictamen_FechaVencimiento.Equals(target.ProyectoDictamen_FechaVencimiento))return false;
          //               if((source.ProyectoDictamen_IdPlanPeriodo == null)?(target.ProyectoDictamen_IdPlanPeriodo.HasValue && target.ProyectoDictamen_IdPlanPeriodo.Value > 0):!source.ProyectoDictamen_IdPlanPeriodo.Equals(target.ProyectoDictamen_IdPlanPeriodo))return false;
          //                            if((source.ProyectoDictamen_Monto == null)?(target.ProyectoDictamen_Monto.HasValue ):!source.ProyectoDictamen_Monto.Equals(target.ProyectoDictamen_Monto))return false;
          //               if((source.ProyectoDictamen_Ejercicio == null)?(target.ProyectoDictamen_Ejercicio.HasValue ):!source.ProyectoDictamen_Ejercicio.Equals(target.ProyectoDictamen_Ejercicio))return false;
          //               if((source.ProyectoDictamen_DuracionMeses == null)?(target.ProyectoDictamen_DuracionMeses.HasValue ):!source.ProyectoDictamen_DuracionMeses.Equals(target.ProyectoDictamen_DuracionMeses))return false;
          //               if((source.ProyectoDictamen_InformeTecnico == null)?target.ProyectoDictamen_InformeTecnico!=null: !( (target.ProyectoDictamen_InformeTecnico== String.Empty && source.ProyectoDictamen_InformeTecnico== null) || (target.ProyectoDictamen_InformeTecnico==null && source.ProyectoDictamen_InformeTecnico== String.Empty )) &&   !source.ProyectoDictamen_InformeTecnico.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_InformeTecnico.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_FechaComiteTecnico == null)?(target.ProyectoDictamen_FechaComiteTecnico.HasValue ):!source.ProyectoDictamen_FechaComiteTecnico.Equals(target.ProyectoDictamen_FechaComiteTecnico))return false;
          //               if((source.ProyectoDictamen_Observacion == null)?target.ProyectoDictamen_Observacion!=null: !( (target.ProyectoDictamen_Observacion== String.Empty && source.ProyectoDictamen_Observacion== null) || (target.ProyectoDictamen_Observacion==null && source.ProyectoDictamen_Observacion== String.Empty )) &&   !source.ProyectoDictamen_Observacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Observacion.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_Recomendacion == null)?target.ProyectoDictamen_Recomendacion!=null: !( (target.ProyectoDictamen_Recomendacion== String.Empty && source.ProyectoDictamen_Recomendacion== null) || (target.ProyectoDictamen_Recomendacion==null && source.ProyectoDictamen_Recomendacion== String.Empty )) &&   !source.ProyectoDictamen_Recomendacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Recomendacion.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_RespuestaOrganismo == null)?target.ProyectoDictamen_RespuestaOrganismo!=null: !( (target.ProyectoDictamen_RespuestaOrganismo== String.Empty && source.ProyectoDictamen_RespuestaOrganismo== null) || (target.ProyectoDictamen_RespuestaOrganismo==null && source.ProyectoDictamen_RespuestaOrganismo== String.Empty )) &&   !source.ProyectoDictamen_RespuestaOrganismo.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_RespuestaOrganismo.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_FechaRepuesta == null)?(target.ProyectoDictamen_FechaRepuesta.HasValue ):!source.ProyectoDictamen_FechaRepuesta.Equals(target.ProyectoDictamen_FechaRepuesta))return false;
          //               if(!source.ProyectoDictamen_IdEstado.Equals(target.ProyectoDictamen_IdEstado))return false;
          //            if(!source.ProyectoDictamen_FechaEstado.Equals(target.ProyectoDictamen_FechaEstado))return false;
          //            if((source.ProyectoDictamen_Numero == null)?target.ProyectoDictamen_Numero!=null: !( (target.ProyectoDictamen_Numero== String.Empty && source.ProyectoDictamen_Numero== null) || (target.ProyectoDictamen_Numero==null && source.ProyectoDictamen_Numero== String.Empty )) &&   !source.ProyectoDictamen_Numero.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Numero.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_Denominacion == null)?target.ProyectoDictamen_Denominacion!=null: !( (target.ProyectoDictamen_Denominacion== String.Empty && source.ProyectoDictamen_Denominacion== null) || (target.ProyectoDictamen_Denominacion==null && source.ProyectoDictamen_Denominacion== String.Empty )) &&   !source.ProyectoDictamen_Denominacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Denominacion.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoDictamen_IdFile == null)?(target.ProyectoDictamen_IdFile.HasValue ):!source.ProyectoDictamen_IdFile.Equals(target.ProyectoDictamen_IdFile))return false;
          //               if(!source.ProyectoSeguimiento_IdSaf.Equals(target.ProyectoSeguimiento_IdSaf))return false;
          //            if((source.ProyectoSeguimiento_Denominacion == null)?target.ProyectoSeguimiento_Denominacion!=null: !( (target.ProyectoSeguimiento_Denominacion== String.Empty && source.ProyectoSeguimiento_Denominacion== null) || (target.ProyectoSeguimiento_Denominacion==null && source.ProyectoSeguimiento_Denominacion== String.Empty )) &&   !source.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoSeguimiento_Ruta == null)?target.ProyectoSeguimiento_Ruta!=null: !( (target.ProyectoSeguimiento_Ruta== String.Empty && source.ProyectoSeguimiento_Ruta== null) || (target.ProyectoSeguimiento_Ruta==null && source.ProyectoSeguimiento_Ruta== String.Empty )) &&   !source.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","")))return false;
          //               if((source.ProyectoSeguimiento_Malla == null)?target.ProyectoSeguimiento_Malla!=null: !( (target.ProyectoSeguimiento_Malla== String.Empty && source.ProyectoSeguimiento_Malla== null) || (target.ProyectoSeguimiento_Malla==null && source.ProyectoSeguimiento_Malla== String.Empty )) &&   !source.ProyectoSeguimiento_Malla.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Malla.Trim().Replace ("\r","")))return false;
          //               if(!source.ProyectoSeguimiento_IdAnalista.Equals(target.ProyectoSeguimiento_IdAnalista))return false;
          //            if((source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior))return false;
          //                            if((source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo))return false;
									 		
		  return true;
        }
		#endregion
    }
}
