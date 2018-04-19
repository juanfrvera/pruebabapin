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
    public abstract class _ProyectoEtapaEstimadoPeriodoData : EntityData<ProyectoEtapaEstimadoPeriodo,ProyectoEtapaEstimadoPeriodoFilter,ProyectoEtapaEstimadoPeriodoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapaEstimadoPeriodo entity)
		{			
			return entity.IdProyectoEtapaEstimadoPeriodo;
		}		
		public override ProyectoEtapaEstimadoPeriodo GetByEntity(ProyectoEtapaEstimadoPeriodo entity)
        {
            return this.GetById(entity.IdProyectoEtapaEstimadoPeriodo);
        }
        public override ProyectoEtapaEstimadoPeriodo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapaEstimadoPeriodo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapaEstimadoPeriodo> Query(ProyectoEtapaEstimadoPeriodoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapaEstimadoPeriodo == null || o.IdProyectoEtapaEstimadoPeriodo >=  filter.IdProyectoEtapaEstimadoPeriodo) && (filter.IdProyectoEtapaEstimadoPeriodo_To == null || o.IdProyectoEtapaEstimadoPeriodo <= filter.IdProyectoEtapaEstimadoPeriodo_To)
					  && (filter.IdProyectoEtapaEstimado == null || filter.IdProyectoEtapaEstimado == 0 || o.IdProyectoEtapaEstimado==filter.IdProyectoEtapaEstimado)
					  && (filter.Periodo == null || o.Periodo >=  filter.Periodo) && (filter.Periodo_To == null || o.Periodo <= filter.Periodo_To)
					  && (filter.Monto == null || o.Monto >=  filter.Monto) && (filter.Monto_To == null || o.Monto <= filter.Monto_To)
					  && (filter.Cotizacion == null || o.Cotizacion >=  filter.Cotizacion) && (filter.Cotizacion_To == null || o.Cotizacion <= filter.Cotizacion_To)
					  && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == true || o.Cotizacion != null ) && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == false || o.Cotizacion == null)
					  && (filter.MontoCalculado == null || o.MontoCalculado >=  filter.MontoCalculado) && (filter.MontoCalculado_To == null || o.MontoCalculado <= filter.MontoCalculado_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEtapaEstimadoPeriodoResult> QueryResult(ProyectoEtapaEstimadoPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaEstimados on o.IdProyectoEtapaEstimado equals t1.IdProyectoEtapaEstimado   
				   select new ProyectoEtapaEstimadoPeriodoResult(){
					 IdProyectoEtapaEstimadoPeriodo=o.IdProyectoEtapaEstimadoPeriodo
					 ,IdProyectoEtapaEstimado=o.IdProyectoEtapaEstimado
					 ,Periodo=o.Periodo
					 ,Monto=o.Monto
					 ,Cotizacion=o.Cotizacion
					 ,MontoCalculado=o.MontoCalculado
					,ProyectoEtapaEstimado_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaEstimado_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaEstimado_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						,ProyectoEtapaEstimado_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEtapaEstimadoPeriodo Copy(nc.ProyectoEtapaEstimadoPeriodo entity)
        {           
            nc.ProyectoEtapaEstimadoPeriodo _new = new nc.ProyectoEtapaEstimadoPeriodo();
		 _new.IdProyectoEtapaEstimado= entity.IdProyectoEtapaEstimado;
		 _new.Periodo= entity.Periodo;
		 _new.Monto= entity.Monto;
		 _new.Cotizacion= entity.Cotizacion;
		 _new.MontoCalculado= entity.MontoCalculado;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapaEstimadoPeriodo entity,string renameFormat)
        {
            ProyectoEtapaEstimadoPeriodo  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapaEstimadoPeriodo entity, int id)
        {            
            entity.IdProyectoEtapaEstimadoPeriodo = id;            
        }
		public override void Set(ProyectoEtapaEstimadoPeriodo source,ProyectoEtapaEstimadoPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaEstimadoPeriodo= source.IdProyectoEtapaEstimadoPeriodo ;
		 target.IdProyectoEtapaEstimado= source.IdProyectoEtapaEstimado ;
		 target.Periodo= source.Periodo ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		}
		public override void Set(ProyectoEtapaEstimadoPeriodoResult source,ProyectoEtapaEstimadoPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaEstimadoPeriodo= source.IdProyectoEtapaEstimadoPeriodo ;
		 target.IdProyectoEtapaEstimado= source.IdProyectoEtapaEstimado ;
		 target.Periodo= source.Periodo ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		}
		public override void Set(ProyectoEtapaEstimadoPeriodo source,ProyectoEtapaEstimadoPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaEstimadoPeriodo= source.IdProyectoEtapaEstimadoPeriodo ;
		 target.IdProyectoEtapaEstimado= source.IdProyectoEtapaEstimado ;
		 target.Periodo= source.Periodo ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		}		
		public override void Set(ProyectoEtapaEstimadoPeriodoResult source,ProyectoEtapaEstimadoPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaEstimadoPeriodo= source.IdProyectoEtapaEstimadoPeriodo ;
		 target.IdProyectoEtapaEstimado= source.IdProyectoEtapaEstimado ;
		 target.Periodo= source.Periodo ;
		 target.Monto= source.Monto ;
		 target.Cotizacion= source.Cotizacion ;
		 target.MontoCalculado= source.MontoCalculado ;
		 target.ProyectoEtapaEstimado_IdProyectoEtapa= source.ProyectoEtapaEstimado_IdProyectoEtapa;	
			target.ProyectoEtapaEstimado_IdClasificacionGasto= source.ProyectoEtapaEstimado_IdClasificacionGasto;	
			target.ProyectoEtapaEstimado_IdFuenteFinanciamiento= source.ProyectoEtapaEstimado_IdFuenteFinanciamiento;	
			target.ProyectoEtapaEstimado_IdMoneda= source.ProyectoEtapaEstimado_IdMoneda;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEtapaEstimadoPeriodo source,ProyectoEtapaEstimadoPeriodo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaEstimadoPeriodo.Equals(target.IdProyectoEtapaEstimadoPeriodo))return false;
		  if(!source.IdProyectoEtapaEstimado.Equals(target.IdProyectoEtapaEstimado))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if(!source.MontoCalculado.Equals(target.MontoCalculado))return false;
		  return true;
        }
		public override bool Equals(ProyectoEtapaEstimadoPeriodoResult source,ProyectoEtapaEstimadoPeriodoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaEstimadoPeriodo.Equals(target.IdProyectoEtapaEstimadoPeriodo))return false;
		  if(!source.IdProyectoEtapaEstimado.Equals(target.IdProyectoEtapaEstimado))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if(!source.MontoCalculado.Equals(target.MontoCalculado))return false;
		  if(!source.ProyectoEtapaEstimado_IdProyectoEtapa.Equals(target.ProyectoEtapaEstimado_IdProyectoEtapa))return false;
					  if(!source.ProyectoEtapaEstimado_IdClasificacionGasto.Equals(target.ProyectoEtapaEstimado_IdClasificacionGasto))return false;
					  if(!source.ProyectoEtapaEstimado_IdFuenteFinanciamiento.Equals(target.ProyectoEtapaEstimado_IdFuenteFinanciamiento))return false;
					  if(!source.ProyectoEtapaEstimado_IdMoneda.Equals(target.ProyectoEtapaEstimado_IdMoneda))return false;
					 		
		  return true;
        }
		#endregion
    }
}
