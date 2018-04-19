using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess
{
    public class ProyectoEtapaInformacionPresupuestariaData : EntityData<ProyectoEtapaInformacionPresupuestaria, ProyectoEtapaInformacionPresupuestariaFilter, ProyectoEtapaInformacionPresupuestariaResult, int>
    {
        #region Singleton
        private static volatile ProyectoEtapaInformacionPresupuestariaData current;
        private static object syncRoot = new Object();

        //private ProyectoEtapaInformacionPresupuestariaData() {}
        public static ProyectoEtapaInformacionPresupuestariaData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaInformacionPresupuestariaData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdProyectoEtapaInformacionPresupuestaria"; } }

        public List<ProyectoEtapaInformacionPresupuestariaResult> GetEtapasInformacionPresupuestarias(ProyectoEtapaFilter filter)
        {
            List<ProyectoEtapaInformacionPresupuestariaResult> retval = new List<ProyectoEtapaInformacionPresupuestariaResult>();
            if (filter.IdProyecto > 0)
            {
                #region Busca los datos
                var pees = (from pee in this.Table 
                            join e in this.Context.ProyectoEtapas on pee.IdProyectoEtapa equals e.IdProyectoEtapa
                            join et in this.Context.Etapas on e.IdEtapa equals et.IdEtapa
                            where e.IdProyecto == filter.IdProyecto && et.IdFase == filter.IdFase
                            select pee);
                var peeps = (from pp in this.Context.ProyectoEtapaInformacionPresupuestariaPeriodos
                             join pee in pees on pp.IdProyectoEtapaInformacionPresupuestaria equals pee.IdProyectoEtapaInformacionPresupuestaria
                             select pp);
                List<ClasificacionGasto> gastos = (from pp in this.Context.ProyectoEtapaInformacionPresupuestariaPeriodos
                                                   join pee in pees on pp.IdProyectoEtapaInformacionPresupuestaria equals pee.IdProyectoEtapaInformacionPresupuestaria
                                                   join g in this.Context.ClasificacionGastos on pee.IdClasificacionGasto equals g.IdClasificacionGasto
                                                   select g).Distinct().ToList();
                //List<ProyectoOrigenFinanciamientoResult> of = (from pp in this.Context.ProyectoEtapaInformacionPresupuestariaPeriodos
                //                                               join pee in pees on pp.IdProyectoEtapaInformacionPresupuestaria equals pee.IdProyectoEtapaInformacionPresupuestaria
                //                                               join o in this.Context.ProyectoOrigenFinanciamientos on pee.IdProyectoOrigenFinanciamiento equals o.IdProyectoOrigenFinanciamiento
                //                                               join p in this.Context.Prestamos on o.IdPrestamo equals p.IdPrestamo
                //                                               select new ProyectoOrigenFinanciamientoResult()
                //                                               {
                //                                                   IdProyectoOrigenFinanciamiento = (int)pee.IdProyectoOrigenFinanciamiento,
                //                                                   Prestamo_Numero = p.Numero,
                //                                                   Prestamo_Denominacion = p.Denominacion
                //                                               }).Distinct().ToList();
                List<FuenteFinanciamiento> ff = (from pp in this.Context.ProyectoEtapaInformacionPresupuestariaPeriodos
                                                 join pee in pees on pp.IdProyectoEtapaInformacionPresupuestaria equals pee.IdProyectoEtapaInformacionPresupuestaria
                                                 join f in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals f.IdFuenteFinanciamiento
                                                 select f).Distinct().ToList();
                #endregion

                #region Carga el resultado
                foreach (ProyectoEtapaInformacionPresupuestaria pee in pees.ToList())
                {
                    ProyectoEtapaInformacionPresupuestariaResult peer = new ProyectoEtapaInformacionPresupuestariaResult();
                    peer.IdProyectoEtapa = pee.IdProyectoEtapa;
                    peer.IdProyectoEtapaInformacionPresupuestaria = pee.IdProyectoEtapaInformacionPresupuestaria;
                    peer.IdClasificacionGasto = pee.IdClasificacionGasto;
                    peer.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento;
                    //peer.IdProyectoOrigenFinanciamiento = pee.IdProyectoOrigenFinanciamiento;
                    peer.IdMoneda = pee.IdMoneda;
                    //if (peer.IdProyectoOrigenFinanciamiento != null && peer.IdProyectoOrigenFinanciamiento > 0)
                    //{
                    //    ProyectoOrigenFinanciamientoResult v = of.Where(o => o.IdProyectoOrigenFinanciamiento == peer.IdProyectoOrigenFinanciamiento).SingleOrDefault();
                    //    peer.OrigenFinanciemiento = v.Descripcion;
                    //}
                    if (peer.IdClasificacionGasto > 0 && gastos.Where(g => g.IdClasificacionGasto == peer.IdClasificacionGasto).Count() > 0)
                    {
                        ClasificacionGasto cl = gastos.Where(g => g.IdClasificacionGasto == peer.IdClasificacionGasto).Single();
                        peer.ClasificacionGasto_Codigo = cl.Codigo;
                        peer.ClasificacionGasto_CodigoCompleto = cl.BreadcrumbCode;
                        peer.ClasificacionGasto_Nombre = cl.Nombre;
                    }
                    if (peer.IdFuenteFinanciamiento > 0 && ff.Where(f => f.IdFuenteFinanciamiento == peer.IdFuenteFinanciamiento).Count() > 0)
                    {
                        FuenteFinanciamiento fu = ff.Where(f => f.IdFuenteFinanciamiento == peer.IdFuenteFinanciamiento).Single();
                        peer.FuenteFinanciamiento_Nombre = fu.BreadcrumbCode + " - " + fu.Nombre;
                    }
                    foreach (ProyectoEtapaInformacionPresupuestariaPeriodo peep in peeps.Where(t => t.IdProyectoEtapaInformacionPresupuestaria == pee.IdProyectoEtapaInformacionPresupuestaria).ToList())
                    {
                        ProyectoEtapaInformacionPresupuestariaPeriodoResult peepr = new ProyectoEtapaInformacionPresupuestariaPeriodoResult();
                        peepr.IdProyectoEtapaInformacionPresupuestaria = peep.IdProyectoEtapaInformacionPresupuestaria;
                        peepr.IdProyectoEtapaInformacionPresupuestariaPeriodo = peep.IdProyectoEtapaInformacionPresupuestariaPeriodo;
                        peepr.Periodo = peep.Periodo;
                        peepr.MontoInicial = peep.MontoInicial;
                        peepr.MontoVigente = peep.MontoVigente;
                        peepr.MontoDevengado = peep.MontoDevengado;
                        peepr.MontoVigenteEstimativo = peep.MontoVigenteEstimativo;
                        peer.Periodos.Add(peepr);
                    }

                    retval.Add(peer);
                }
                #endregion
            }

            return retval;
        }

        protected override IQueryable<ProyectoEtapaInformacionPresupuestariaResult> QueryResult(ProyectoEtapaInformacionPresupuestariaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGastos on o.IdClasificacionGasto equals t1.IdClasificacionGasto   
				    join t2  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamiento equals t2.IdFuenteFinanciamiento   
				    join t3  in this.Context.Monedas on o.IdMoneda equals t3.IdMoneda   
				    join t4  in this.Context.ProyectoEtapas on o.IdProyectoEtapa equals t4.IdProyectoEtapa   
				   //join _t5  in this.Context.ProyectoOrigenFinanciamientos on o.IdProyectoOrigenFinanciamiento equals _t5.IdProyectoOrigenFinanciamiento into tt5 from t5 in tt5.DefaultIfEmpty()
				  where ( filter.IdProyecto == null || filter.IdProyecto == 0 || t4.IdProyecto == filter.IdProyecto  )
                  select new ProyectoEtapaInformacionPresupuestariaResult(){
					 IdProyectoEtapaInformacionPresupuestaria=o.IdProyectoEtapaInformacionPresupuestaria
					 ,IdProyectoEtapa=o.IdProyectoEtapa
					 ,IdClasificacionGasto=o.IdClasificacionGasto
					 ,IdFuenteFinanciamiento=o.IdFuenteFinanciamiento
					 //,IdProyectoOrigenFinanciamiento=o.IdProyectoOrigenFinanciamiento
					 ,IdMoneda=o.IdMoneda
					,ClasificacionGasto_Codigo= t1.Codigo
                    ,ClasificacionGasto_CodigoCompleto=t1.BreadcrumbCode
						,ClasificacionGasto_Nombre= t1.Nombre	
                        //,ClasificacionGasto_IdClasificacionGastoTipo= t1.IdClasificacionGastoTipo	
                        //,ClasificacionGasto_IdCaracterEconomico= t1.IdCaracterEconomico	
                        //,ClasificacionGasto_Activo= t1.Activo	
                        //,ClasificacionGasto_IdClasificacionGastoPadre= t1.IdClasificacionGastoPadre	
                        //,ClasificacionGasto_BreadcrumbId= t1.BreadcrumbId	
                        //,ClasificacionGasto_BreadcrumbOrden= t1.BreadcrumbOrden	
                        //,ClasificacionGasto_Nivel= t1.Nivel	
                        //,ClasificacionGasto_Orden= t1.Orden	
                        //,ClasificacionGasto_Descripcion= t1.Descripcion	
                        //,ClasificacionGasto_DescripcionInvertida= t1.DescripcionInvertida	
                        //,ClasificacionGasto_IdClasificacionGastoRubro= t1.IdClasificacionGastoRubro	
                        //,ClasificacionGasto_Seleccionable= t1.Seleccionable	
                        //,ClasificacionGasto_BreadcrumbCode= t1.BreadcrumbCode	
                        //,ClasificacionGasto_DescripcionCodigo= t1.DescripcionCodigo	
                        //,FuenteFinanciamiento_Codigo= t2.Codigo	
						,FuenteFinanciamiento_Nombre= t2.Nombre	
                        //,FuenteFinanciamiento_IdFuenteFinanciamientoTipo= t2.IdFuenteFinanciamientoTipo	
                        //,FuenteFinanciamiento_Activo= t2.Activo	
                        //,FuenteFinanciamiento_IdFuenteFinanciamientoPadre= t2.IdFuenteFinanciamientoPadre	
                        //,FuenteFinanciamiento_BreadcrumbId= t2.BreadcrumbId	
                        //,FuenteFinanciamiento_BreadcrumbOrden= t2.BreadcrumbOrden	
                        //,FuenteFinanciamiento_Nivel= t2.Nivel	
                        //,FuenteFinanciamiento_Orden= t2.Orden	
                        //,FuenteFinanciamiento_Descripcion= t2.Descripcion	
                        //,FuenteFinanciamiento_DescripcionInvertida= t2.DescripcionInvertida	
                        //,FuenteFinanciamiento_Seleccionable= t2.Seleccionable	
                        //,FuenteFinanciamiento_BreadcrumbCode= t2.BreadcrumbCode	
                        //,FuenteFinanciamiento_DescripcionCodigo= t2.DescripcionCodigo	
                        //,Moneda_Sigla= t3.Sigla	
                        //,Moneda_Nombre= t3.Nombre	
                        //,Moneda_Activo= t3.Activo	
                        //,Moneda_Base= t3.Base	
                        //,ProyectoEtapa_Nombre= t4.Nombre	
                        //,ProyectoEtapa_CodigoVinculacion= t4.CodigoVinculacion	
                        //,ProyectoEtapa_IdEstado= t4.IdEstado	
                        //,ProyectoEtapa_FechaInicioInformacionPresupuestaria= t4.FechaInicioInformacionPresupuestaria	
                        //,ProyectoEtapa_FechaFinInformacionPresupuestaria= t4.FechaFinInformacionPresupuestaria	
                        //,ProyectoEtapa_FechaInicioRealizada= t4.FechaInicioRealizada	
                        //,ProyectoEtapa_FechaFinRealizada= t4.FechaFinRealizada	
                        //,ProyectoEtapa_IdEtapa= t4.IdEtapa	
                        //,ProyectoEtapa_IdProyecto= t4.IdProyecto	
                        //,ProyectoEtapa_NroEtapa= t4.NroEtapa	
                        //,ProyectoOrigenFinanciamiento_IdProyecto= t5!=null?(int?)t5.IdProyecto:null	
                        //,ProyectoOrigenFinanciamiento_IdProyectoOrigenFinancianmientoTipo= t5!=null?(int?)t5.IdProyectoOrigenFinancianmientoTipo:null	
                        //,ProyectoOrigenFinanciamiento_IdPrestamo= t5!=null?(int?)t5.IdPrestamo:null	
						}
                    ).AsQueryable();
        }

        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapaInformacionPresupuestaria entity)
		{			
			return entity.IdProyectoEtapaInformacionPresupuestaria;
		}		
		public override ProyectoEtapaInformacionPresupuestaria GetByEntity(ProyectoEtapaInformacionPresupuestaria entity)
        {
            return this.GetById(entity.IdProyectoEtapaInformacionPresupuestaria);
        }
        public override ProyectoEtapaInformacionPresupuestaria GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapaInformacionPresupuestaria == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapaInformacionPresupuestaria> Query(ProyectoEtapaInformacionPresupuestariaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapaInformacionPresupuestaria == null || filter.IdProyectoEtapaInformacionPresupuestaria == 0 || o.IdProyectoEtapaInformacionPresupuestaria==filter.IdProyectoEtapaInformacionPresupuestaria)
					  && (filter.IdProyectoEtapa == null || filter.IdProyectoEtapa == 0 || o.IdProyectoEtapa==filter.IdProyectoEtapa)
					  && (filter.IdClasificacionGasto == null || filter.IdClasificacionGasto == 0 || o.IdClasificacionGasto==filter.IdClasificacionGasto)
					  && (filter.IdFuenteFinanciamiento == null || filter.IdFuenteFinanciamiento == 0 || o.IdFuenteFinanciamiento==filter.IdFuenteFinanciamiento)
					  && (filter.IdMoneda == null || filter.IdMoneda == 0 || o.IdMoneda==filter.IdMoneda)
					  select o
                    ).AsQueryable();
        }	
        //protected override IQueryable<ProyectoEtapaInformacionPresupuestariaResult> QueryResult(ProyectoEtapaInformacionPresupuestariaFilter filter)
        //{
        //  return (from o in Query(filter)					
        //             join t1  in this.Context.ClasificacionGastos on o.IdClasificacionGasto equals t1.IdClasificacionGasto   
        //            join t2  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamiento equals t2.IdFuenteFinanciamiento   
        //            join t3  in this.Context.Monedas on o.IdMoneda equals t3.IdMoneda   
        //            join t4  in this.Context.ProyectoEtapas on o.IdProyectoEtapa equals t4.IdProyectoEtapa   
        //           select new ProyectoEtapaInformacionPresupuestariaResult(){
        //             IdProyectoEtapaInformacionPresupuestaria=o.IdProyectoEtapaInformacionPresupuestaria
        //             ,IdProyectoEtapa=o.IdProyectoEtapa
        //             ,IdClasificacionGasto=o.IdClasificacionGasto
        //             ,IdFuenteFinanciamiento=o.IdFuenteFinanciamiento
        //             ,IdMoneda=o.IdMoneda
        //            ,ClasificacionGasto_Codigo= t1.Codigo	
        //                ,ClasificacionGasto_Nombre= t1.Nombre	
        //                //,ClasificacionGasto_IdClasificacionGastoTipo= t1.IdClasificacionGastoTipo	
        //                //,ClasificacionGasto_IdCaracterEconomico= t1.IdCaracterEconomico	
        //                //,ClasificacionGasto_Activo= t1.Activo	
        //                //,ClasificacionGasto_IdClasificacionGastoPadre= t1.IdClasificacionGastoPadre	
        //                //,ClasificacionGasto_BreadcrumbId= t1.BreadcrumbId	
        //                //,ClasificacionGasto_BreadcrumbOrden= t1.BreadcrumbOrden	
        //                //,ClasificacionGasto_Nivel= t1.Nivel	
        //                //,ClasificacionGasto_Orden= t1.Orden	
        //                //,ClasificacionGasto_Descripcion= t1.Descripcion	
        //                //,ClasificacionGasto_DescripcionInvertida= t1.DescripcionInvertida	
        //                //,ClasificacionGasto_IdClasificacionGastoRubro= t1.IdClasificacionGastoRubro	
        //                //,ClasificacionGasto_Seleccionable= t1.Seleccionable	
        //                //,ClasificacionGasto_BreadcrumbCode= t1.BreadcrumbCode	
        //                //,ClasificacionGasto_DescripcionCodigo= t1.DescripcionCodigo	
        //                //,FuenteFinanciamiento_Codigo= t2.Codigo	
        //                ,FuenteFinanciamiento_Nombre= t2.Nombre	
        //                //,FuenteFinanciamiento_IdFuenteFinanciamientoTipo= t2.IdFuenteFinanciamientoTipo	
        //                //,FuenteFinanciamiento_Activo= t2.Activo	
        //                //,FuenteFinanciamiento_IdFuenteFinanciamientoPadre= t2.IdFuenteFinanciamientoPadre	
        //                //,FuenteFinanciamiento_BreadcrumbId= t2.BreadcrumbId	
        //                //,FuenteFinanciamiento_BreadcrumbOrden= t2.BreadcrumbOrden	
        //                //,FuenteFinanciamiento_Nivel= t2.Nivel	
        //                //,FuenteFinanciamiento_Orden= t2.Orden	
        //                //,FuenteFinanciamiento_Descripcion= t2.Descripcion	
        //                //,FuenteFinanciamiento_DescripcionInvertida= t2.DescripcionInvertida	
        //                //,FuenteFinanciamiento_Seleccionable= t2.Seleccionable	
        //                //,FuenteFinanciamiento_BreadcrumbCode= t2.BreadcrumbCode	
        //                //,FuenteFinanciamiento_DescripcionCodigo= t2.DescripcionCodigo	
        //                //,Moneda_Sigla= t3.Sigla	
        //                //,Moneda_Nombre= t3.Nombre	
        //                //,Moneda_Activo= t3.Activo	
        //                //,Moneda_Base= t3.Base	
        //                //,ProyectoEtapa_Nombre= t4.Nombre	
        //                //,ProyectoEtapa_CodigoVinculacion= t4.CodigoVinculacion	
        //                //,ProyectoEtapa_IdEstado= t4.IdEstado	
        //                //,ProyectoEtapa_FechaInicioInformacionPresupuestaria= t4.FechaInicioInformacionPresupuestaria	
        //                //,ProyectoEtapa_FechaFinInformacionPresupuestaria= t4.FechaFinInformacionPresupuestaria	
        //                //,ProyectoEtapa_FechaInicioRealizada= t4.FechaInicioRealizada	
        //                //,ProyectoEtapa_FechaFinRealizada= t4.FechaFinRealizada	
        //                //,ProyectoEtapa_IdEtapa= t4.IdEtapa	
        //                //,ProyectoEtapa_IdProyecto= t4.IdProyecto	
        //                //,ProyectoEtapa_NroEtapa= t4.NroEtapa	
        //                }
        //            ).AsQueryable();
        //}
		#endregion
		#region Copy
		public override nc.ProyectoEtapaInformacionPresupuestaria Copy(nc.ProyectoEtapaInformacionPresupuestaria entity)
        {           
            nc.ProyectoEtapaInformacionPresupuestaria _new = new nc.ProyectoEtapaInformacionPresupuestaria();
		 _new.IdProyectoEtapa= entity.IdProyectoEtapa;
		 _new.IdClasificacionGasto= entity.IdClasificacionGasto;
		 _new.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento;
		 _new.IdMoneda= entity.IdMoneda;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapaInformacionPresupuestaria entity,string renameFormat)
        {
            ProyectoEtapaInformacionPresupuestaria  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapaInformacionPresupuestaria entity, int id)
        {            
            entity.IdProyectoEtapaInformacionPresupuestaria = id;            
        }
		public override void Set(ProyectoEtapaInformacionPresupuestaria source,ProyectoEtapaInformacionPresupuestaria target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 		  
		}
		public override void Set(ProyectoEtapaInformacionPresupuestariaResult source,ProyectoEtapaInformacionPresupuestaria target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 
		}
		public override void Set(ProyectoEtapaInformacionPresupuestaria source,ProyectoEtapaInformacionPresupuestariaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 	
		}		
		public override void Set(ProyectoEtapaInformacionPresupuestariaResult source,ProyectoEtapaInformacionPresupuestariaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaInformacionPresupuestaria= source.IdProyectoEtapaInformacionPresupuestaria ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 target.ClasificacionGasto_Codigo= source.ClasificacionGasto_Codigo;
         target.ClasificacionGasto_CodigoCompleto = source.ClasificacionGasto_CodigoCompleto;
			target.ClasificacionGasto_Nombre= source.ClasificacionGasto_Nombre;	
            //target.ClasificacionGasto_IdClasificacionGastoTipo= source.ClasificacionGasto_IdClasificacionGastoTipo;	
            //target.ClasificacionGasto_IdCaracterEconomico= source.ClasificacionGasto_IdCaracterEconomico;	
            //target.ClasificacionGasto_Activo= source.ClasificacionGasto_Activo;	
            //target.ClasificacionGasto_IdClasificacionGastoPadre= source.ClasificacionGasto_IdClasificacionGastoPadre;	
            //target.ClasificacionGasto_BreadcrumbId= source.ClasificacionGasto_BreadcrumbId;	
            //target.ClasificacionGasto_BreadcrumbOrden= source.ClasificacionGasto_BreadcrumbOrden;	
            //target.ClasificacionGasto_Nivel= source.ClasificacionGasto_Nivel;	
            //target.ClasificacionGasto_Orden= source.ClasificacionGasto_Orden;	
            //target.ClasificacionGasto_Descripcion= source.ClasificacionGasto_Descripcion;	
            //target.ClasificacionGasto_DescripcionInvertida= source.ClasificacionGasto_DescripcionInvertida;	
            //target.ClasificacionGasto_IdClasificacionGastoRubro= source.ClasificacionGasto_IdClasificacionGastoRubro;	
            //target.ClasificacionGasto_Seleccionable= source.ClasificacionGasto_Seleccionable;	
            //target.ClasificacionGasto_BreadcrumbCode= source.ClasificacionGasto_BreadcrumbCode;	
            //target.ClasificacionGasto_DescripcionCodigo= source.ClasificacionGasto_DescripcionCodigo;	
            //target.FuenteFinanciamiento_Codigo= source.FuenteFinanciamiento_Codigo;	
			target.FuenteFinanciamiento_Nombre= source.FuenteFinanciamiento_Nombre;	
            //target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo= source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo;	
            //target.FuenteFinanciamiento_Activo= source.FuenteFinanciamiento_Activo;	
            //target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre= source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre;	
            //target.FuenteFinanciamiento_BreadcrumbId= source.FuenteFinanciamiento_BreadcrumbId;	
            //target.FuenteFinanciamiento_BreadcrumbOrden= source.FuenteFinanciamiento_BreadcrumbOrden;	
            //target.FuenteFinanciamiento_Nivel= source.FuenteFinanciamiento_Nivel;	
            //target.FuenteFinanciamiento_Orden= source.FuenteFinanciamiento_Orden;	
            //target.FuenteFinanciamiento_Descripcion= source.FuenteFinanciamiento_Descripcion;	
            //target.FuenteFinanciamiento_DescripcionInvertida= source.FuenteFinanciamiento_DescripcionInvertida;	
            //target.FuenteFinanciamiento_Seleccionable= source.FuenteFinanciamiento_Seleccionable;	
            //target.FuenteFinanciamiento_BreadcrumbCode= source.FuenteFinanciamiento_BreadcrumbCode;	
            //target.FuenteFinanciamiento_DescripcionCodigo= source.FuenteFinanciamiento_DescripcionCodigo;	
            //target.Moneda_Sigla= source.Moneda_Sigla;	
            //target.Moneda_Nombre= source.Moneda_Nombre;	
            //target.Moneda_Activo= source.Moneda_Activo;	
            //target.Moneda_Base= source.Moneda_Base;	
            //target.ProyectoEtapa_Nombre= source.ProyectoEtapa_Nombre;	
            //target.ProyectoEtapa_CodigoVinculacion= source.ProyectoEtapa_CodigoVinculacion;	
            //target.ProyectoEtapa_IdEstado= source.ProyectoEtapa_IdEstado;	
            //target.ProyectoEtapa_FechaInicioInformacionPresupuestaria= source.ProyectoEtapa_FechaInicioInformacionPresupuestaria;	
            //target.ProyectoEtapa_FechaFinInformacionPresupuestaria= source.ProyectoEtapa_FechaFinInformacionPresupuestaria;	
            //target.ProyectoEtapa_FechaInicioRealizada= source.ProyectoEtapa_FechaInicioRealizada;	
            //target.ProyectoEtapa_FechaFinRealizada= source.ProyectoEtapa_FechaFinRealizada;	
            //target.ProyectoEtapa_IdEtapa= source.ProyectoEtapa_IdEtapa;	
            //target.ProyectoEtapa_IdProyecto= source.ProyectoEtapa_IdProyecto;	
            //target.ProyectoEtapa_NroEtapa= source.ProyectoEtapa_NroEtapa;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEtapaInformacionPresupuestaria source,ProyectoEtapaInformacionPresupuestaria target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaInformacionPresupuestaria.Equals(target.IdProyectoEtapaInformacionPresupuestaria))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoEtapaInformacionPresupuestariaResult source,ProyectoEtapaInformacionPresupuestariaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaInformacionPresupuestaria.Equals(target.IdProyectoEtapaInformacionPresupuestaria))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if((source.ClasificacionGasto_Codigo == null)?target.ClasificacionGasto_Codigo!=null:!source.ClasificacionGasto_Codigo.Equals(target.ClasificacionGasto_Codigo))return false;
          if ((source.ClasificacionGasto_CodigoCompleto == null) ? target.ClasificacionGasto_CodigoCompleto != null : !source.ClasificacionGasto_CodigoCompleto.Equals(target.ClasificacionGasto_CodigoCompleto)) return false;
						 if((source.ClasificacionGasto_Nombre == null)?target.ClasificacionGasto_Nombre!=null:!source.ClasificacionGasto_Nombre.Equals(target.ClasificacionGasto_Nombre))return false;
                      //   if(!source.ClasificacionGasto_IdClasificacionGastoTipo.Equals(target.ClasificacionGasto_IdClasificacionGastoTipo))return false;
                      //if((source.ClasificacionGasto_IdCaracterEconomico == null)?(target.ClasificacionGasto_IdCaracterEconomico.HasValue ):!source.ClasificacionGasto_IdCaracterEconomico.Equals(target.ClasificacionGasto_IdCaracterEconomico))return false;
                      //   if(!source.ClasificacionGasto_Activo.Equals(target.ClasificacionGasto_Activo))return false;
                      //if((source.ClasificacionGasto_IdClasificacionGastoPadre == null)?(target.ClasificacionGasto_IdClasificacionGastoPadre.HasValue && target.ClasificacionGasto_IdClasificacionGastoPadre.Value > 0):!source.ClasificacionGasto_IdClasificacionGastoPadre.Equals(target.ClasificacionGasto_IdClasificacionGastoPadre))return false;
                      //                if((source.ClasificacionGasto_BreadcrumbId == null)?target.ClasificacionGasto_BreadcrumbId!=null:!source.ClasificacionGasto_BreadcrumbId.Equals(target.ClasificacionGasto_BreadcrumbId))return false;
                      //   if((source.ClasificacionGasto_BreadcrumbOrden == null)?target.ClasificacionGasto_BreadcrumbOrden!=null:!source.ClasificacionGasto_BreadcrumbOrden.Equals(target.ClasificacionGasto_BreadcrumbOrden))return false;
                      //   if((source.ClasificacionGasto_Nivel == null)?(target.ClasificacionGasto_Nivel.HasValue ):!source.ClasificacionGasto_Nivel.Equals(target.ClasificacionGasto_Nivel))return false;
                      //   if((source.ClasificacionGasto_Orden == null)?(target.ClasificacionGasto_Orden.HasValue ):!source.ClasificacionGasto_Orden.Equals(target.ClasificacionGasto_Orden))return false;
                      //   if((source.ClasificacionGasto_Descripcion == null)?target.ClasificacionGasto_Descripcion!=null:!source.ClasificacionGasto_Descripcion.Equals(target.ClasificacionGasto_Descripcion))return false;
                      //   if((source.ClasificacionGasto_DescripcionInvertida == null)?target.ClasificacionGasto_DescripcionInvertida!=null:!source.ClasificacionGasto_DescripcionInvertida.Equals(target.ClasificacionGasto_DescripcionInvertida))return false;
                      //   if(!source.ClasificacionGasto_IdClasificacionGastoRubro.Equals(target.ClasificacionGasto_IdClasificacionGastoRubro))return false;
                      //if(!source.ClasificacionGasto_Seleccionable.Equals(target.ClasificacionGasto_Seleccionable))return false;
                      //if((source.ClasificacionGasto_BreadcrumbCode == null)?target.ClasificacionGasto_BreadcrumbCode!=null:!source.ClasificacionGasto_BreadcrumbCode.Equals(target.ClasificacionGasto_BreadcrumbCode))return false;
                      //   if((source.ClasificacionGasto_DescripcionCodigo == null)?target.ClasificacionGasto_DescripcionCodigo!=null:!source.ClasificacionGasto_DescripcionCodigo.Equals(target.ClasificacionGasto_DescripcionCodigo))return false;
                      //   if((source.FuenteFinanciamiento_Codigo == null)?target.FuenteFinanciamiento_Codigo!=null:!source.FuenteFinanciamiento_Codigo.Equals(target.FuenteFinanciamiento_Codigo))return false;
                         if((source.FuenteFinanciamiento_Nombre == null)?target.FuenteFinanciamiento_Nombre!=null:!source.FuenteFinanciamiento_Nombre.Equals(target.FuenteFinanciamiento_Nombre))return false;
                      //   if(!source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo))return false;
                      //if(!source.FuenteFinanciamiento_Activo.Equals(target.FuenteFinanciamiento_Activo))return false;
                      //if((source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre == null)?(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.HasValue && target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Value > 0):!source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre))return false;
                      //                if((source.FuenteFinanciamiento_BreadcrumbId == null)?target.FuenteFinanciamiento_BreadcrumbId!=null:!source.FuenteFinanciamiento_BreadcrumbId.Equals(target.FuenteFinanciamiento_BreadcrumbId))return false;
                         //if((source.FuenteFinanciamiento_BreadcrumbOrden == null)?target.FuenteFinanciamiento_BreadcrumbOrden!=null:!source.FuenteFinanciamiento_BreadcrumbOrden.Equals(target.FuenteFinanciamiento_BreadcrumbOrden))return false;
                         //if((source.FuenteFinanciamiento_Nivel == null)?(target.FuenteFinanciamiento_Nivel.HasValue ):!source.FuenteFinanciamiento_Nivel.Equals(target.FuenteFinanciamiento_Nivel))return false;
                         //if((source.FuenteFinanciamiento_Orden == null)?(target.FuenteFinanciamiento_Orden.HasValue ):!source.FuenteFinanciamiento_Orden.Equals(target.FuenteFinanciamiento_Orden))return false;
                         //if((source.FuenteFinanciamiento_Descripcion == null)?target.FuenteFinanciamiento_Descripcion!=null:!source.FuenteFinanciamiento_Descripcion.Equals(target.FuenteFinanciamiento_Descripcion))return false;
                         //if((source.FuenteFinanciamiento_DescripcionInvertida == null)?target.FuenteFinanciamiento_DescripcionInvertida!=null:!source.FuenteFinanciamiento_DescripcionInvertida.Equals(target.FuenteFinanciamiento_DescripcionInvertida))return false;
                      //   if(!source.FuenteFinanciamiento_Seleccionable.Equals(target.FuenteFinanciamiento_Seleccionable))return false;
                      //if((source.FuenteFinanciamiento_BreadcrumbCode == null)?target.FuenteFinanciamiento_BreadcrumbCode!=null:!source.FuenteFinanciamiento_BreadcrumbCode.Equals(target.FuenteFinanciamiento_BreadcrumbCode))return false;
                      //   if((source.FuenteFinanciamiento_DescripcionCodigo == null)?target.FuenteFinanciamiento_DescripcionCodigo!=null:!source.FuenteFinanciamiento_DescripcionCodigo.Equals(target.FuenteFinanciamiento_DescripcionCodigo))return false;
                      //   if((source.Moneda_Sigla == null)?target.Moneda_Sigla!=null:!source.Moneda_Sigla.Equals(target.Moneda_Sigla))return false;
                      //   if((source.Moneda_Nombre == null)?target.Moneda_Nombre!=null:!source.Moneda_Nombre.Equals(target.Moneda_Nombre))return false;
                      //   if(!source.Moneda_Activo.Equals(target.Moneda_Activo))return false;
                      //if(!source.Moneda_Base.Equals(target.Moneda_Base))return false;
                      //if((source.ProyectoEtapa_Nombre == null)?target.ProyectoEtapa_Nombre!=null:!source.ProyectoEtapa_Nombre.Equals(target.ProyectoEtapa_Nombre))return false;
                      //   if((source.ProyectoEtapa_CodigoVinculacion == null)?target.ProyectoEtapa_CodigoVinculacion!=null:!source.ProyectoEtapa_CodigoVinculacion.Equals(target.ProyectoEtapa_CodigoVinculacion))return false;
                      //   if((source.ProyectoEtapa_IdEstado == null)?(target.ProyectoEtapa_IdEstado.HasValue && target.ProyectoEtapa_IdEstado.Value > 0):!source.ProyectoEtapa_IdEstado.Equals(target.ProyectoEtapa_IdEstado))return false;
                      //                if((source.ProyectoEtapa_FechaInicioInformacionPresupuestaria == null)?(target.ProyectoEtapa_FechaInicioInformacionPresupuestaria.HasValue ):!source.ProyectoEtapa_FechaInicioInformacionPresupuestaria.Equals(target.ProyectoEtapa_FechaInicioInformacionPresupuestaria))return false;
                      //   if((source.ProyectoEtapa_FechaFinInformacionPresupuestaria == null)?(target.ProyectoEtapa_FechaFinInformacionPresupuestaria.HasValue ):!source.ProyectoEtapa_FechaFinInformacionPresupuestaria.Equals(target.ProyectoEtapa_FechaFinInformacionPresupuestaria))return false;
                      //   if((source.ProyectoEtapa_FechaInicioRealizada == null)?(target.ProyectoEtapa_FechaInicioRealizada.HasValue ):!source.ProyectoEtapa_FechaInicioRealizada.Equals(target.ProyectoEtapa_FechaInicioRealizada))return false;
                      //   if((source.ProyectoEtapa_FechaFinRealizada == null)?(target.ProyectoEtapa_FechaFinRealizada.HasValue ):!source.ProyectoEtapa_FechaFinRealizada.Equals(target.ProyectoEtapa_FechaFinRealizada))return false;
                      //   if(!source.ProyectoEtapa_IdEtapa.Equals(target.ProyectoEtapa_IdEtapa))return false;
                      //if(!source.ProyectoEtapa_IdProyecto.Equals(target.ProyectoEtapa_IdProyecto))return false;
                      //if((source.ProyectoEtapa_NroEtapa == null)?(target.ProyectoEtapa_NroEtapa.HasValue ):!source.ProyectoEtapa_NroEtapa.Equals(target.ProyectoEtapa_NroEtapa))return false;
								
		  return true;
        }
		#endregion
    }
}