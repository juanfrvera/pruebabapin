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
    public abstract class _ProyectoEtapaRealizadoPeriodoData : EntityData<ProyectoEtapaRealizadoPeriodo,ProyectoEtapaRealizadoPeriodoFilter,ProyectoEtapaRealizadoPeriodoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapaRealizadoPeriodo entity)
		{			
			return entity.IdProyectoEtapaRealizadoPeriodo;
		}		
		public override ProyectoEtapaRealizadoPeriodo GetByEntity(ProyectoEtapaRealizadoPeriodo entity)
        {
            return this.GetById(entity.IdProyectoEtapaRealizadoPeriodo);
        }
        public override ProyectoEtapaRealizadoPeriodo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapaRealizadoPeriodo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapaRealizadoPeriodo> Query(ProyectoEtapaRealizadoPeriodoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapaRealizadoPeriodo == null || o.IdProyectoEtapaRealizadoPeriodo >=  filter.IdProyectoEtapaRealizadoPeriodo) && (filter.IdProyectoEtapaRealizadoPeriodo_To == null || o.IdProyectoEtapaRealizadoPeriodo <= filter.IdProyectoEtapaRealizadoPeriodo_To)
					  && (filter.IdProyectoEtapaRealizado == null || filter.IdProyectoEtapaRealizado == 0 || o.IdProyectoEtapaRealizado==filter.IdProyectoEtapaRealizado)
					  && (filter.Periodo == null || o.Periodo >=  filter.Periodo) && (filter.Periodo_To == null || o.Periodo <= filter.Periodo_To)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Monto == null || o.Monto >=  filter.Monto) && (filter.Monto_To == null || o.Monto <= filter.Monto_To)
					  && (filter.Cotizacion == null || o.Cotizacion >=  filter.Cotizacion) && (filter.Cotizacion_To == null || o.Cotizacion <= filter.Cotizacion_To)
					  && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == true || o.Cotizacion != null ) && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == false || o.Cotizacion == null)
					  && (filter.MontoCalculado == null || o.MontoCalculado >=  filter.MontoCalculado) && (filter.MontoCalculado_To == null || o.MontoCalculado <= filter.MontoCalculado_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEtapaRealizadoPeriodoResult> QueryResult(ProyectoEtapaRealizadoPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaRealizados on o.IdProyectoEtapaRealizado equals t1.IdProyectoEtapaRealizado   
				   select new ProyectoEtapaRealizadoPeriodoResult(){
					 IdProyectoEtapaRealizadoPeriodo=o.IdProyectoEtapaRealizadoPeriodo
					 ,IdProyectoEtapaRealizado=o.IdProyectoEtapaRealizado
					 ,Periodo=o.Periodo
					 ,Fecha=o.Fecha
					 ,Monto=o.Monto
					 ,Cotizacion=o.Cotizacion
					 ,MontoCalculado=o.MontoCalculado
					,ProyectoEtapaRealizado_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaRealizado_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaRealizado_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						,ProyectoEtapaRealizado_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEtapaRealizadoPeriodo Copy(nc.ProyectoEtapaRealizadoPeriodo entity)
        {           
            nc.ProyectoEtapaRealizadoPeriodo _new = new nc.ProyectoEtapaRealizadoPeriodo();
		 _new.IdProyectoEtapaRealizado= entity.IdProyectoEtapaRealizado;
		 _new.Periodo= entity.Periodo;
		 _new.Fecha= entity.Fecha;
		 _new.Monto= entity.Monto;
		 _new.Cotizacion= entity.Cotizacion;
		 _new.MontoCalculado= entity.MontoCalculado;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapaRealizadoPeriodo entity,string renameFormat)
        {
            ProyectoEtapaRealizadoPeriodo  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapaRealizadoPeriodo entity, int id)
        {            
            entity.IdProyectoEtapaRealizadoPeriodo = id;            
        }
		public override void Set(ProyectoEtapaRealizadoPeriodo source,ProyectoEtapaRealizadoPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaRealizadoPeriodo= source.IdProyectoEtapaRealizadoPeriodo ;
		 target.IdProyectoEtapaRealizado= source.IdProyectoEtapaRealizado ;
		 target.Periodo= source.Periodo ;
		 target.Fecha= source.Fecha ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		 		  
		}
		public override void Set(ProyectoEtapaRealizadoPeriodoResult source,ProyectoEtapaRealizadoPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaRealizadoPeriodo= source.IdProyectoEtapaRealizadoPeriodo ;
		 target.IdProyectoEtapaRealizado= source.IdProyectoEtapaRealizado ;
		 target.Periodo= source.Periodo ;
		 target.Fecha= source.Fecha ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		 
		}
		public override void Set(ProyectoEtapaRealizadoPeriodo source,ProyectoEtapaRealizadoPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaRealizadoPeriodo= source.IdProyectoEtapaRealizadoPeriodo ;
		 target.IdProyectoEtapaRealizado= source.IdProyectoEtapaRealizado ;
		 target.Periodo= source.Periodo ;
		 target.Fecha= source.Fecha ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		 	
		}		
		public override void Set(ProyectoEtapaRealizadoPeriodoResult source,ProyectoEtapaRealizadoPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaRealizadoPeriodo= source.IdProyectoEtapaRealizadoPeriodo ;
		 target.IdProyectoEtapaRealizado= source.IdProyectoEtapaRealizado ;
		 target.Periodo= source.Periodo ;
		 target.Fecha= source.Fecha ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		 target.ProyectoEtapaRealizado_IdProyectoEtapa= source.ProyectoEtapaRealizado_IdProyectoEtapa;	
			target.ProyectoEtapaRealizado_IdClasificacionGasto= source.ProyectoEtapaRealizado_IdClasificacionGasto;	
			target.ProyectoEtapaRealizado_IdFuenteFinanciamiento= source.ProyectoEtapaRealizado_IdFuenteFinanciamiento;	
			target.ProyectoEtapaRealizado_IdMoneda= source.ProyectoEtapaRealizado_IdMoneda;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEtapaRealizadoPeriodo source,ProyectoEtapaRealizadoPeriodo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaRealizadoPeriodo.Equals(target.IdProyectoEtapaRealizadoPeriodo))return false;
		  if(!source.IdProyectoEtapaRealizado.Equals(target.IdProyectoEtapaRealizado))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if(!source.MontoCalculado.Equals(target.MontoCalculado))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoEtapaRealizadoPeriodoResult source,ProyectoEtapaRealizadoPeriodoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaRealizadoPeriodo.Equals(target.IdProyectoEtapaRealizadoPeriodo))return false;
		  if(!source.IdProyectoEtapaRealizado.Equals(target.IdProyectoEtapaRealizado))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if(!source.MontoCalculado.Equals(target.MontoCalculado))return false;
		  if(!source.ProyectoEtapaRealizado_IdProyectoEtapa.Equals(target.ProyectoEtapaRealizado_IdProyectoEtapa))return false;
					  if(!source.ProyectoEtapaRealizado_IdClasificacionGasto.Equals(target.ProyectoEtapaRealizado_IdClasificacionGasto))return false;
					  if(!source.ProyectoEtapaRealizado_IdFuenteFinanciamiento.Equals(target.ProyectoEtapaRealizado_IdFuenteFinanciamiento))return false;
					  if((source.ProyectoEtapaRealizado_IdMoneda == null)?(target.ProyectoEtapaRealizado_IdMoneda.HasValue && target.ProyectoEtapaRealizado_IdMoneda.Value > 0):!source.ProyectoEtapaRealizado_IdMoneda.Equals(target.ProyectoEtapaRealizado_IdMoneda))return false;
									 		
		  return true;
        }
		#endregion
    }
}
