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
    public abstract class _ProyectoEtapaInformacionPresupuestariaPeriodoData : EntityData<ProyectoEtapaInformacionPresupuestariaPeriodo,ProyectoEtapaInformacionPresupuestariaPeriodoFilter,ProyectoEtapaInformacionPresupuestariaPeriodoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapaInformacionPresupuestariaPeriodo entity)
		{			
			return entity.IdProyectoEtapaInformacionPresupuestariaPeriodo;
		}		
		public override ProyectoEtapaInformacionPresupuestariaPeriodo GetByEntity(ProyectoEtapaInformacionPresupuestariaPeriodo entity)
        {
            return this.GetById(entity.IdProyectoEtapaInformacionPresupuestariaPeriodo);
        }
        public override ProyectoEtapaInformacionPresupuestariaPeriodo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapaInformacionPresupuestariaPeriodo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapaInformacionPresupuestariaPeriodo> Query(ProyectoEtapaInformacionPresupuestariaPeriodoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapaInformacionPresupuestariaPeriodo == null || o.IdProyectoEtapaInformacionPresupuestariaPeriodo >=  filter.IdProyectoEtapaInformacionPresupuestariaPeriodo) && (filter.IdProyectoEtapaInformacionPresupuestariaPeriodo_To == null || o.IdProyectoEtapaInformacionPresupuestariaPeriodo <= filter.IdProyectoEtapaInformacionPresupuestariaPeriodo_To)
					  && (filter.IdProyectoEtapaInformacionPresupuestaria == null || filter.IdProyectoEtapaInformacionPresupuestaria == 0 || o.IdProyectoEtapaInformacionPresupuestaria==filter.IdProyectoEtapaInformacionPresupuestaria)
					  && (filter.Periodo == null || o.Periodo >=  filter.Periodo) && (filter.Periodo_To == null || o.Periodo <= filter.Periodo_To)
                      && (filter.MontoInicial == null || o.MontoInicial >= filter.MontoInicial) && (filter.MontoInicial_To == null || o.MontoInicial <= filter.MontoInicial_To)
                      && (filter.MontoDevengado == null || o.MontoDevengado >= filter.MontoDevengado) && (filter.MontoDevengado_To == null || o.MontoDevengado <= filter.MontoDevengado_To)
                      && (filter.MontoVigenteEstimativo == null || o.MontoVigenteEstimativo == filter.MontoVigenteEstimativo) && (filter.MontoVigenteEstimativo_To == null || o.MontoVigenteEstimativo == filter.MontoVigenteEstimativo_To)
                      && (filter.MontoVigente == null || o.MontoVigente >= filter.MontoVigente) && (filter.MontoVigente_To == null || o.MontoVigente <= filter.MontoVigente_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEtapaInformacionPresupuestariaPeriodoResult> QueryResult(ProyectoEtapaInformacionPresupuestariaPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaInformacionPresupuestarias on o.IdProyectoEtapaInformacionPresupuestaria equals t1.IdProyectoEtapaInformacionPresupuestaria   
				   select new ProyectoEtapaInformacionPresupuestariaPeriodoResult(){
					 IdProyectoEtapaInformacionPresupuestariaPeriodo=o.IdProyectoEtapaInformacionPresupuestariaPeriodo
					 ,IdProyectoEtapaInformacionPresupuestaria=o.IdProyectoEtapaInformacionPresupuestaria
					 ,Periodo=o.Periodo
                     ,MontoInicial = o.MontoInicial
                     ,MontoVigente = o.MontoVigente
                     ,MontoDevengado = o.MontoDevengado
                     ,MontoVigenteEstimativo = o.MontoVigenteEstimativo
					,ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						,ProyectoEtapaInformacionPresupuestaria_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEtapaInformacionPresupuestariaPeriodo Copy(nc.ProyectoEtapaInformacionPresupuestariaPeriodo entity)
        {           
            nc.ProyectoEtapaInformacionPresupuestariaPeriodo _new = new nc.ProyectoEtapaInformacionPresupuestariaPeriodo();
		 _new.IdProyectoEtapaInformacionPresupuestaria= entity.IdProyectoEtapaInformacionPresupuestaria;
		 _new.Periodo= entity.Periodo;
         _new.MontoInicial = entity.MontoInicial;
         _new.MontoVigente = entity.MontoVigente;
         _new.MontoDevengado = entity.MontoDevengado;
         _new.MontoVigenteEstimativo = entity.MontoVigenteEstimativo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapaInformacionPresupuestariaPeriodo entity,string renameFormat)
        {
            ProyectoEtapaInformacionPresupuestariaPeriodo  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapaInformacionPresupuestariaPeriodo entity, int id)
        {            
            entity.IdProyectoEtapaInformacionPresupuestariaPeriodo = id;            
        }
		public override void Set(ProyectoEtapaInformacionPresupuestariaPeriodo source,ProyectoEtapaInformacionPresupuestariaPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestariaPeriodo= source.IdProyectoEtapaInformacionPresupuestariaPeriodo ;
		 target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.Periodo= source.Periodo ;
         target.MontoInicial = source.MontoInicial;
         target.MontoVigente = source.MontoVigente;
         target.MontoDevengado = source.MontoDevengado;
         target.MontoVigenteEstimativo = source.MontoVigenteEstimativo;
		}
		public override void Set(ProyectoEtapaInformacionPresupuestariaPeriodoResult source,ProyectoEtapaInformacionPresupuestariaPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestariaPeriodo= source.IdProyectoEtapaInformacionPresupuestariaPeriodo ;
		 target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.Periodo= source.Periodo ;
         target.MontoInicial     = source.MontoInicial;
         target.MontoVigente = source.MontoVigente;
         target.MontoDevengado = source.MontoDevengado;
         target.MontoVigenteEstimativo = source.MontoVigenteEstimativo;
		 
		}
		public override void Set(ProyectoEtapaInformacionPresupuestariaPeriodo source,ProyectoEtapaInformacionPresupuestariaPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestariaPeriodo= source.IdProyectoEtapaInformacionPresupuestariaPeriodo ;
		 target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.Periodo= source.Periodo ;
         target.MontoInicial = source.MontoInicial;
         target.MontoVigente = source.MontoVigente;
		}		
		public override void Set(ProyectoEtapaInformacionPresupuestariaPeriodoResult source,ProyectoEtapaInformacionPresupuestariaPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestariaPeriodo= source.IdProyectoEtapaInformacionPresupuestariaPeriodo ;
		 target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.Periodo= source.Periodo ;
         target.MontoInicial = source.MontoInicial;
         target.MontoVigente = source.MontoVigente;
         target.MontoDevengado = source.MontoDevengado;
         target.MontoVigenteEstimativo = source.MontoVigenteEstimativo;
		 target.ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa= source.ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa;	
			target.ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto= source.ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto;	
			target.ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento= source.ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento;	
			target.ProyectoEtapaInformacionPresupuestaria_IdMoneda= source.ProyectoEtapaInformacionPresupuestaria_IdMoneda;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEtapaInformacionPresupuestariaPeriodo source,ProyectoEtapaInformacionPresupuestariaPeriodo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaInformacionPresupuestariaPeriodo.Equals(target.IdProyectoEtapaInformacionPresupuestariaPeriodo))return false;
		  if(!source.IdProyectoEtapaInformacionPresupuestaria.Equals(target.IdProyectoEtapaInformacionPresupuestaria))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
             if (!source.MontoInicial.Equals(target.MontoInicial)) return false;
             if (!source.MontoVigente.Equals(target.MontoVigente)) return false;
             if (!source.MontoDevengado.Equals(target.MontoDevengado)) return false;
             if (!source.MontoVigenteEstimativo.Equals(target.MontoVigenteEstimativo)) return false;
		  return true;
        }
		public override bool Equals(ProyectoEtapaInformacionPresupuestariaPeriodoResult source,ProyectoEtapaInformacionPresupuestariaPeriodoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaInformacionPresupuestariaPeriodo.Equals(target.IdProyectoEtapaInformacionPresupuestariaPeriodo))return false;
		  if(!source.IdProyectoEtapaInformacionPresupuestaria.Equals(target.IdProyectoEtapaInformacionPresupuestaria))return false;
		  if(!source.Periodo.Equals(target.Periodo))return false;
             if (!source.MontoInicial.Equals(target.MontoInicial)) return false;
             if (!source.MontoVigente.Equals(target.MontoVigente)) return false;
             if (!source.MontoDevengado.Equals(target.MontoDevengado)) return false;
             if (!source.MontoVigenteEstimativo.Equals(target.MontoVigenteEstimativo)) return false;
		  if(!source.ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa.Equals(target.ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa))return false;
					  if(!source.ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto.Equals(target.ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto))return false;
					  if(!source.ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento.Equals(target.ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento))return false;
					  if(!source.ProyectoEtapaInformacionPresupuestaria_IdMoneda.Equals(target.ProyectoEtapaInformacionPresupuestaria_IdMoneda))return false;
					 		
		  return true;
        }
		#endregion
    }
}
