using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract;

namespace DataAccess
{
    public class ProyectoPlanData : EntityData<ProyectoPlan, ProyectoPlanFilter, ProyectoPlanResult, int>//_ProyectoPlanData 
    { 
	   #region Singleton
	   private static volatile ProyectoPlanData current;
	   private static object syncRoot = new Object();

	   //private ProyectoPlanData() {}
	   public static ProyectoPlanData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPlanData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoPlan"; } }

        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoPlan entity)
		{			
			return entity.IdProyectoPlan;
		}		
		public override ProyectoPlan GetByEntity(ProyectoPlan entity)
        {
            return this.GetById(entity.IdProyectoPlan);
        }
        public override ProyectoPlan GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoPlan == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoPlan> Query(ProyectoPlanFilter filter)
        {
			return (from o in this.Table
                      where //(filter.IdProyectoPlan == null || o.IdProyectoPlan >=  filter.IdProyectoPlan) && (filter.IdProyectoPlan_To == null || o.IdProyectoPlan <= filter.IdProyectoPlan_To)
                      (filter.IdProyectoPlan == null || o.IdProyectoPlan ==  0 || o.IdProyectoPlan == filter.IdProyectoPlan)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo==filter.IdPlanPeriodo)
					  && (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || o.IdPlanVersion==filter.IdPlanVersion)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  select o
                    ).AsQueryable();
        }
	    protected override IQueryable<ProyectoPlanResult> QueryResult(ProyectoPlanFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PlanPeriodos on o.IdPlanPeriodo equals t1.IdPlanPeriodo   
				    join t2  in this.Context.PlanVersions on o.IdPlanVersion equals t2.IdPlanVersion   
//				    join t3  in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto 
                    join planTipo in this.Context.PlanTipos on t2.IdPlanTipo equals planTipo.IdPlanTipo 
                    where ( filter.ValidarPlanPeriodoVersionActiva == null || filter.ValidarPlanPeriodoVersionActiva == false ||
                                (from ppva in this.Context.PlanPeriodoVersionActivas
                                where ppva.IdPlanPeriodo == t1.IdPlanPeriodo && ppva.IdPlanVersion == t2.IdPlanVersion 
                                select ppva.IdPlanPeriodoVersionActiva ).Count() > 0 )
				   select new ProyectoPlanResult(){
					 IdProyectoPlan=o.IdProyectoPlan
					 ,IdProyecto=o.IdProyecto
					 ,IdPlanPeriodo=o.IdPlanPeriodo
					 ,IdPlanVersion=o.IdPlanVersion
					 ,Fecha=o.Fecha
					//,PlanPeriodo_IdPlanTipo= t1.IdPlanTipo	
						,PlanPeriodo_Nombre= t1.Nombre	
						//,PlanPeriodo_Sigla= t1.Sigla	
						,PlanPeriodo_AnioInicial= t1.AnioInicial	
						,PlanPeriodo_AnioFinal= t1.AnioFinal	
						//,PlanPeriodo_Activo= t1.Activo	
						//,PlanVersion_IdPlanTipo= t2.IdPlanTipo	
						,PlanVersion_Nombre= t2.Nombre	
                        ,PlanVersion_Orden= t2.Orden	
                        //,PlanVersion_Activo= t2.Activo	
                        //,Proyecto_IdTipoProyecto= t3.IdTipoProyecto	
                        //,Proyecto_IdSubPrograma= t3.IdSubPrograma	
                        //,Proyecto_Codigo= t3.Codigo	
                        //,Proyecto_ProyectoDenominacion= t3.ProyectoDenominacion	
                        //,Proyecto_ProyectoSituacionActual= t3.ProyectoSituacionActual	
                        //,Proyecto_ProyectoDescripcion= t3.ProyectoDescripcion	
                        //,Proyecto_ProyectoObservacion= t3.ProyectoObservacion	
                        //,Proyecto_IdEstado= t3.IdEstado	
                        //,Proyecto_IdProceso= t3.IdProceso	
                        //,Proyecto_IdModalidadContratacion= t3.IdModalidadContratacion	
                        //,Proyecto_IdFinalidadFuncion= t3.IdFinalidadFuncion	
                        //,Proyecto_IdOrganismoPrioridad= t3.IdOrganismoPrioridad	
                        //,Proyecto_SubPrioridad= t3.SubPrioridad	
                        //,Proyecto_EsBorrador= t3.EsBorrador	
                        //,Proyecto_EsProyecto= t3.EsProyecto	
                        //,Proyecto_NroProyecto= t3.NroProyecto	
                        //,Proyecto_AnioCorriente= t3.AnioCorriente	
                        //,Proyecto_FechaInicioEjecucionCalculada= t3.FechaInicioEjecucionCalculada	
                        //,Proyecto_FechaFinEjecucionCalculada= t3.FechaFinEjecucionCalculada	
                        //,Proyecto_FechaAlta= t3.FechaAlta	
                        //,Proyecto_FechaModificacion= t3.FechaModificacion	
                        //,Proyecto_IdUsuarioModificacion= t3.IdUsuarioModificacion
                        ,IdPlanTipo = t2.IdPlanTipo
                        ,PlanTipo_Nombre = planTipo.Nombre 
                        ,PlanTipo_Orden = planTipo.Orden 
                        ,Activo = 
                            ( from ppva in this.Context.PlanPeriodoVersionActivas 
                                where ppva.IdPlanVersion == o.IdPlanVersion && ppva.IdPlanPeriodo == o.IdPlanPeriodo 
                                select ppva.IdPlanPeriodoVersionActiva ).Count() > 0 
						}
                    ).AsQueryable();
        }
        public Int32? GetIdTipoPlan(Int32 IdProyecto)
        {
            Int32? rv = null;

            List<PlanPeriodo> planes = (from x in this.Table
                                        join p in this.Context.PlanPeriodos on x.IdPlanPeriodo equals p.IdPlanPeriodo
                                        where x.IdProyecto == IdProyecto 
                                        orderby p.IdPlanTipo
                                        select p).ToList();
            if (planes.Count > 0)
                rv = planes[0].IdPlanTipo;

            return rv;
        }
        //protected override IQueryable<ProyectoPlanResult> QueryResult(ProyectoPlanFilter filter)
        //{
        //  return (from o in Query(filter)					
        //             join t1  in this.Context.PlanPeriodos on o.IdPlanPeriodo equals t1.IdPlanPeriodo   
        //            join t2  in this.Context.PlanVersions on o.IdPlanVersion equals t2.IdPlanVersion   
        //            join t3  in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto   
        //           select new ProyectoPlanResult(){
        //             IdProyectoPlan=o.IdProyectoPlan
        //             ,IdProyecto=o.IdProyecto
        //             ,IdPlanPeriodo=o.IdPlanPeriodo
        //             ,IdPlanVersion=o.IdPlanVersion
        //             ,Fecha=o.Fecha
        //            ,PlanPeriodo_IdPlanTipo= t1.IdPlanTipo	
        //                ,PlanPeriodo_Nombre= t1.Nombre	
        //                ,PlanPeriodo_Sigla= t1.Sigla	
        //                ,PlanPeriodo_AnioInicial= t1.AnioInicial	
        //                ,PlanPeriodo_AnioFinal= t1.AnioFinal	
        //                ,PlanPeriodo_Activo= t1.Activo	
        //                ,PlanVersion_IdPlanTipo= t2.IdPlanTipo	
        //                ,PlanVersion_Nombre= t2.Nombre	
        //                ,PlanVersion_Orden= t2.Orden	
        //                ,PlanVersion_Activo= t2.Activo	
        //                ,Proyecto_IdTipoProyecto= t3.IdTipoProyecto	
        //                ,Proyecto_IdSubPrograma= t3.IdSubPrograma	
        //                ,Proyecto_Codigo= t3.Codigo	
        //                ,Proyecto_ProyectoDenominacion= t3.ProyectoDenominacion	
        //                ,Proyecto_ProyectoSituacionActual= t3.ProyectoSituacionActual	
        //                ,Proyecto_ProyectoDescripcion= t3.ProyectoDescripcion	
        //                ,Proyecto_ProyectoObservacion= t3.ProyectoObservacion	
        //                ,Proyecto_IdEstado= t3.IdEstado	
        //                ,Proyecto_IdProceso= t3.IdProceso	
        //                ,Proyecto_IdModalidadContratacion= t3.IdModalidadContratacion	
        //                ,Proyecto_IdFinalidadFuncion= t3.IdFinalidadFuncion	
        //                ,Proyecto_IdOrganismoPrioridad= t3.IdOrganismoPrioridad	
        //                ,Proyecto_SubPrioridad= t3.SubPrioridad	
        //                ,Proyecto_EsBorrador= t3.EsBorrador	
        //                ,Proyecto_EsProyecto= t3.EsProyecto	
        //                ,Proyecto_NroProyecto= t3.NroProyecto	
        //                ,Proyecto_AnioCorriente= t3.AnioCorriente	
        //                ,Proyecto_FechaInicioEjecucionCalculada= t3.FechaInicioEjecucionCalculada	
        //                ,Proyecto_FechaFinEjecucionCalculada= t3.FechaFinEjecucionCalculada	
        //                ,Proyecto_FechaAlta= t3.FechaAlta	
        //                ,Proyecto_FechaModificacion= t3.FechaModificacion	
        //                ,Proyecto_IdUsuarioModificacion= t3.IdUsuarioModificacion	
        //                ,Proyecto_IdProyectoPlan= t3.IdProyectoPlan	
        //                ,Proyecto_EvaluarValidaciones= t3.EvaluarValidaciones	
        //                }
        //            ).AsQueryable();
        //}
        #endregion
		#region Copy
		public override nc.ProyectoPlan Copy(nc.ProyectoPlan entity)
        {           
            nc.ProyectoPlan _new = new nc.ProyectoPlan();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdPlanPeriodo= entity.IdPlanPeriodo;
		 _new.IdPlanVersion= entity.IdPlanVersion;
		 _new.Fecha= entity.Fecha;
		return _new;			
        }
		public override int CopyAndSave(ProyectoPlan entity,string renameFormat)
        {
            ProyectoPlan  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoPlan entity, int id)
        {            
            entity.IdProyectoPlan = id;            
        }
		public override void Set(ProyectoPlan source,ProyectoPlan target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 target.Fecha= source.Fecha ;
		 		  
		}
		public override void Set(ProyectoPlanResult source,ProyectoPlan target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 target.Fecha= source.Fecha ;
		 
		}
		public override void Set(ProyectoPlan source,ProyectoPlanResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 target.Fecha= source.Fecha ;
		 	
		}		
		public override void Set(ProyectoPlanResult source,ProyectoPlanResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 target.Fecha= source.Fecha ;
		 //target.PlanPeriodo_IdPlanTipo= source.PlanPeriodo_IdPlanTipo;	
			target.PlanPeriodo_Nombre= source.PlanPeriodo_Nombre;	
			//target.PlanPeriodo_Sigla= source.PlanPeriodo_Sigla;	
			target.PlanPeriodo_AnioInicial= source.PlanPeriodo_AnioInicial;	
			target.PlanPeriodo_AnioFinal= source.PlanPeriodo_AnioFinal;	
            //target.PlanPeriodo_Activo= source.PlanPeriodo_Activo;	
            //target.PlanVersion_IdPlanTipo= source.PlanVersion_IdPlanTipo;	
			target.PlanVersion_Nombre= source.PlanVersion_Nombre;	
            target.PlanVersion_Orden= source.PlanVersion_Orden;	
            //target.PlanVersion_Activo= source.PlanVersion_Activo;	
            //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
            //target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
            //target.Proyecto_Codigo= source.Proyecto_Codigo;	
            //target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
            //target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
            //target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
            //target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
            //target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
            //target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
            //target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
            //target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
            //target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
            //target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
            //target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
            //target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
            //target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
            //target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
            //target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
            //target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
            //target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
            //target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
            //target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
            //target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
            //target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoPlan source,ProyectoPlan target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoPlan.Equals(target.IdProyectoPlan))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoPlanResult source,ProyectoPlanResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoPlan.Equals(target.IdProyectoPlan))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  //if(!source.PlanPeriodo_IdPlanTipo.Equals(target.PlanPeriodo_IdPlanTipo))return false;
					  if((source.PlanPeriodo_Nombre == null)?target.PlanPeriodo_Nombre!=null:!source.PlanPeriodo_Nombre.Equals(target.PlanPeriodo_Nombre))return false;
						 //if((source.PlanPeriodo_Sigla == null)?target.PlanPeriodo_Sigla!=null:!source.PlanPeriodo_Sigla.Equals(target.PlanPeriodo_Sigla))return false;
						 if(!source.PlanPeriodo_AnioInicial.Equals(target.PlanPeriodo_AnioInicial))return false;
					  if(!source.PlanPeriodo_AnioFinal.Equals(target.PlanPeriodo_AnioFinal))return false;
                      //if(!source.PlanPeriodo_Activo.Equals(target.PlanPeriodo_Activo))return false;
                      //if(!source.PlanVersion_IdPlanTipo.Equals(target.PlanVersion_IdPlanTipo))return false;
					  if((source.PlanVersion_Nombre == null)?target.PlanVersion_Nombre!=null:!source.PlanVersion_Nombre.Equals(target.PlanVersion_Nombre))return false;
                      if(!source.PlanVersion_Orden.Equals(target.PlanVersion_Orden))return false;
                      //if(!source.PlanVersion_Activo.Equals(target.PlanVersion_Activo))return false;
                      //if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
                      //if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
                      //if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
                      //if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null:!source.Proyecto_ProyectoDenominacion.Equals(target.Proyecto_ProyectoDenominacion))return false;
                      //   if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null:!source.Proyecto_ProyectoSituacionActual.Equals(target.Proyecto_ProyectoSituacionActual))return false;
                      //   if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null:!source.Proyecto_ProyectoDescripcion.Equals(target.Proyecto_ProyectoDescripcion))return false;
                      //   if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null:!source.Proyecto_ProyectoObservacion.Equals(target.Proyecto_ProyectoObservacion))return false;
                      //   if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
                      //if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
                      //                if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
                      //                if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
                      //                if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
                      //                if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
                      //   if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
                      //if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
                      //   if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
                      //   if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
                      //   if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
                      //   if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
                      //   if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
                      //if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
                      //if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
                      //if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
                      //   if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
					 		
		  return true;
        }
		#endregion
        
       
    }
}
