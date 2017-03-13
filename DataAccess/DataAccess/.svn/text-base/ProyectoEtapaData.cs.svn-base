using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc=Contract ;

namespace DataAccess
{
    public class ProyectoEtapaData  : EntityData<ProyectoEtapa,ProyectoEtapaFilter,ProyectoEtapaResult,int> 
    { 
	   #region Singleton
	   private static volatile ProyectoEtapaData current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaData() {}
	   public static ProyectoEtapaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoEtapa"; } }

       public List<ProyectoEtapaResult> GetEtapas(ProyectoEtapaFilter filter)
       {
           List<ProyectoEtapaResult> etapas = (from pe in this.QueryResult(filter)
                                               join e in this.Context.Etapas
                                               on pe.IdEtapa equals e.IdEtapa
                                               where filter.IdFase == 0 || e.IdFase == filter.IdFase
                                               select pe).ToList();

           List<Etapa> es = (from e in this.Context.Etapas select e).ToList();
           foreach (ProyectoEtapaResult i in etapas)
           {
               Etapa et = es.Where(e => e.IdEtapa == i.IdEtapa).Single();
               i.Etapa_IdFase = et.IdFase;
               i.Etapa_Nombre = et.Nombre;
               i.Fase_Nombre = FaseConfig.GetConst(((FaseEnum)et.IdFase));
               i.NroProyecto = (from p in Context.Proyectos where p.IdProyecto == i.IdProyecto select p.NroProyecto).SingleOrDefault().ToString();

               i.TotalEstimado = (from e in this.Context.ProyectoEtapaEstimados
                                  join p in this.Context.ProyectoEtapaEstimadoPeriodos
                                  on e.IdProyectoEtapaEstimado equals p.IdProyectoEtapaEstimado
                                  where e.IdProyectoEtapa == i.IdProyectoEtapa
                                  select p).ToList().Sum(p => p.MontoCalculado);
               i.TotalRealizado = (from r in this.Context.ProyectoEtapaRealizados
                                   join p in this.Context.ProyectoEtapaRealizadoPeriodos
                                  on r.IdProyectoEtapaRealizado equals p.IdProyectoEtapaRealizado
                                  where r.IdProyectoEtapa == i.IdProyectoEtapa
                                  select p).ToList().Sum(p => p.MontoCalculado);
           }

           return etapas;
       }

       public List<ProyectoEtapaIndicadorCompose> GetIndicadoresEtapaProyecto(ProyectoEtapaFilter proyectoEtapaFilter)
       {
           // Busca Los Datos
           List<MedioVerificacion> mvs = (from v in this.Context.MedioVerificacions select v).ToList();

           List<ProyectoEtapaIndicadorResult> rst = (from pei in this.Context.ProyectoEtapaIndicadors
                                                     join pe in this.Context.ProyectoEtapas on pei.IdProyectoEtapa equals pe.IdProyectoEtapa
                                                     join i in this.Context.Indicadors on pei.IdIndicador equals i.IdIndicador
                                                     //into result
                                                     where pe.IdProyecto == proyectoEtapaFilter.IdProyecto
                                                     //from r in result
                                                     select new ProyectoEtapaIndicadorResult()
                                                     {
                                                         IdProyectoEtapaIndicador = pei.IdProyectoEtapaIndicador,
                                                         IdProyectoEtapa = pei.IdProyectoEtapa,
                                                         Descripcion = pei.Descripcion,
                                                         IdUnidadMedia = pei.IdUnidadMedia,
                                                         NroExpediente = pei.NroExpediente,
                                                         IdIndicador = i.IdIndicador,
                                                         FechaLicitacion = pei.FechaLicitacion,
                                                         FechaContratacion = pei.FechaContratacion,
                                                         Contratista = pei.Contratista,
                                                         FechaInicioObra = pei.FechaInicioObra,
                                                         PlazoEjecucion = pei.PlazoEjecucion,
                                                         Indicador_IdMedioVerificacion = i.IdMedioVerificacion,
                                                         Indicador_Observacion = i.Observacion,
                                                         IdMoneda = pei.IdMoneda,
                                                         Magnitud = pei.Magnitud,
                                                         MontoContrato = pei.MontoContrato,
                                                         MontoVigente = pei.MontoVigente,
                                                         IdMedioVerificacion = i.IdMedioVerificacion
                                                         //MedioDeVerificacion = (from v in mvs
                                                         //                       where v.IdMedioVerificacion == r.IdMedioVerificacion
                                                         //                       select v).SingleOrDefault().Nombre
                                                     }
                                                     ).ToList();

           rst.ForEach(p=>p.MedioDeVerificacion = (from o in mvs where o.IdMedioVerificacion == p.IdMedioVerificacion select o.Nombre).FirstOrDefault());

           IndicadorEvolucionFilter f = new IndicadorEvolucionFilter();
           f.IdsIndicadores = (from r in rst where r.IdIndicador != null select (Int32)r.IdIndicador).ToList();
           List<IndicadorEvolucionResult> evos = IndicadorEvolucionData.Current.GetResult(f);

           // Carga el resultado
           List<ProyectoEtapaIndicadorCompose> rv = new List<ProyectoEtapaIndicadorCompose>();
           foreach (ProyectoEtapaIndicadorResult pei in rst)
           {
               ProyectoEtapaIndicadorCompose n = new ProyectoEtapaIndicadorCompose();
               n.Evoluciones = evos.Where(e => e.IdIndicador == pei.IdIndicador).ToList();
               n.Indicador = pei;
               rv.Add(n);
           }

           return rv;
       }
    
       
    		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapa entity)
		{			
			return entity.IdProyectoEtapa;
		}		
		public override ProyectoEtapa GetByEntity(ProyectoEtapa entity)
        {
            return this.GetById(entity.IdProyectoEtapa);
        }
        public override ProyectoEtapa GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapa == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapa> Query(ProyectoEtapaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapa == null || filter.IdProyectoEtapa == 0 || o.IdProyectoEtapa==filter.IdProyectoEtapa)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.CodigoVinculacion == null || filter.CodigoVinculacion.Trim() == string.Empty || filter.CodigoVinculacion.Trim() == "%"  || (filter.CodigoVinculacion.EndsWith("%") && filter.CodigoVinculacion.StartsWith("%") && (o.CodigoVinculacion.Contains(filter.CodigoVinculacion.Replace("%", "")))) || (filter.CodigoVinculacion.EndsWith("%") && o.CodigoVinculacion.StartsWith(filter.CodigoVinculacion.Replace("%",""))) || (filter.CodigoVinculacion.StartsWith("%") && o.CodigoVinculacion.EndsWith(filter.CodigoVinculacion.Replace("%",""))) || o.CodigoVinculacion == filter.CodigoVinculacion )
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.IdEstadoIsNull == null || filter.IdEstadoIsNull == true || o.IdEstado != null ) && (filter.IdEstadoIsNull == null || filter.IdEstadoIsNull == false || o.IdEstado == null)
					  && (filter.FechaInicioEstimada == null || filter.FechaInicioEstimada == DateTime.MinValue || o.FechaInicioEstimada >=  filter.FechaInicioEstimada) && (filter.FechaInicioEstimada_To == null || filter.FechaInicioEstimada_To == DateTime.MinValue || o.FechaInicioEstimada <= filter.FechaInicioEstimada_To)
					  && (filter.FechaInicioEstimadaIsNull == null || filter.FechaInicioEstimadaIsNull == true || o.FechaInicioEstimada != null ) && (filter.FechaInicioEstimadaIsNull == null || filter.FechaInicioEstimadaIsNull == false || o.FechaInicioEstimada == null)
					  && (filter.FechaFinEstimada == null || filter.FechaFinEstimada == DateTime.MinValue || o.FechaFinEstimada >=  filter.FechaFinEstimada) && (filter.FechaFinEstimada_To == null || filter.FechaFinEstimada_To == DateTime.MinValue || o.FechaFinEstimada <= filter.FechaFinEstimada_To)
					  && (filter.FechaFinEstimadaIsNull == null || filter.FechaFinEstimadaIsNull == true || o.FechaFinEstimada != null ) && (filter.FechaFinEstimadaIsNull == null || filter.FechaFinEstimadaIsNull == false || o.FechaFinEstimada == null)
					  && (filter.FechaInicioRealizada == null || filter.FechaInicioRealizada == DateTime.MinValue || o.FechaInicioRealizada >=  filter.FechaInicioRealizada) && (filter.FechaInicioRealizada_To == null || filter.FechaInicioRealizada_To == DateTime.MinValue || o.FechaInicioRealizada <= filter.FechaInicioRealizada_To)
					  && (filter.FechaInicioRealizadaIsNull == null || filter.FechaInicioRealizadaIsNull == true || o.FechaInicioRealizada != null ) && (filter.FechaInicioRealizadaIsNull == null || filter.FechaInicioRealizadaIsNull == false || o.FechaInicioRealizada == null)
					  && (filter.FechaFinRealizada == null || filter.FechaFinRealizada == DateTime.MinValue || o.FechaFinRealizada >=  filter.FechaFinRealizada) && (filter.FechaFinRealizada_To == null || filter.FechaFinRealizada_To == DateTime.MinValue || o.FechaFinRealizada <= filter.FechaFinRealizada_To)
					  && (filter.FechaFinRealizadaIsNull == null || filter.FechaFinRealizadaIsNull == true || o.FechaFinRealizada != null ) && (filter.FechaFinRealizadaIsNull == null || filter.FechaFinRealizadaIsNull == false || o.FechaFinRealizada == null)
					  && (filter.IdEtapa == null || filter.IdEtapa == 0 || o.IdEtapa==filter.IdEtapa)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.NroEtapa == null || o.NroEtapa >=  filter.NroEtapa) && (filter.NroEtapa_To == null || o.NroEtapa <= filter.NroEtapa_To)
					  && (filter.NroEtapaIsNull == null || filter.NroEtapaIsNull == true || o.NroEtapa != null ) && (filter.NroEtapaIsNull == null || filter.NroEtapaIsNull == false || o.NroEtapa == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEtapaResult> QueryResult(ProyectoEtapaFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Estados on o.IdEstado equals _t1.IdEstado into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.Etapas on o.IdEtapa equals t2.IdEtapa  
                    join f in this.Context.Fases on t2.IdFase equals f.IdFase
				    //join t3  in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto   
				   select new ProyectoEtapaResult(){
					 IdProyectoEtapa=o.IdProyectoEtapa
					 ,Nombre=o.Nombre
					 ,CodigoVinculacion=o.CodigoVinculacion
					 ,IdEstado=o.IdEstado
					 ,FechaInicioEstimada=o.FechaInicioEstimada
					 ,FechaFinEstimada=o.FechaFinEstimada
					 ,FechaInicioRealizada=o.FechaInicioRealizada
					 ,FechaFinRealizada=o.FechaFinRealizada
					 ,IdEtapa=o.IdEtapa
					 ,IdProyecto=o.IdProyecto
					 ,NroEtapa=o.NroEtapa
                     ,Estado_Nombre= t1!=null?(string)t1.Nombre:null	
                    //    ,Estado_Codigo= t1!=null?(string)t1.Codigo:null	
                    //    ,Estado_Orden= t1!=null?(int?)t1.Orden:null	
                    //    ,Estado_Descripcion= t1!=null?(string)t1.Descripcion:null	
                    //    ,Estado_Activo= t1!=null?(bool?)t1.Activo:null	
					 ,Etapa_IdFase= t2.IdFase	
					 //,Etapa_Codigo= t2.Codigo	
					 ,Etapa_Nombre= t2.Nombre	
                     ,Etapa_Orden= t2.Orden	
                     ,Etapa_Codigo=t2.Codigo
                     ,Fase_Nombre=f.Nombre
                     ,Fase_Codigo=f.Codigo
                     ,Fase_Orden=f.Orden
                        //,Etapa_Activo= t2.Activo	
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
                        //,Proyecto_IdProyectoPlan= t3.IdProyectoPlan	
                        //,Proyecto_EvaluarValidaciones= t3.EvaluarValidaciones	
						}
                    ).AsQueryable();
        }


        public List<ProyectoEtapaResult> ProyectoEtapaConTotales(ProyectoEtapaFilter filter)
        { 
            var query = ( from o in QueryResult ( filter)
                          orderby o.Fase_Orden , o.Etapa_Orden ,o.IdProyectoEtapa
                           select new ProyectoEtapaResult(){
					             IdProyectoEtapa=o.IdProyectoEtapa
					             ,Nombre=o.Nombre
					             ,CodigoVinculacion=o.CodigoVinculacion
					             ,IdEstado=o.IdEstado
					             ,FechaInicioEstimada=o.FechaInicioEstimada
					             ,FechaFinEstimada=o.FechaFinEstimada
					             ,FechaInicioRealizada=o.FechaInicioRealizada
					             ,FechaFinRealizada=o.FechaFinRealizada
					             ,IdEtapa=o.IdEtapa
					             ,IdProyecto=o.IdProyecto
					             ,NroEtapa=o.NroEtapa
                                 ,NroProyecto = o.NroProyecto /*Matias 20170203 - Ticket #REQ792885*/
                                 ,Estado_Nombre= o.Estado_Nombre	
						         ,Etapa_IdFase= o.Etapa_IdFase	
						         ,Etapa_Nombre= o.Etapa_Nombre	
                                 ,Etapa_Orden= o.Etapa_Orden
                                 ,Etapa_Codigo= o.Etapa_Codigo
	                             ,Fase_Nombre = o.Fase_Nombre
                                 ,Fase_Orden= o.Fase_Orden
                                 ,TotalEstimado =(from pee in this.Context.ProyectoEtapaEstimados 
                                                  join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado 
                                                  where o.IdProyectoEtapa == pee.IdProyectoEtapa 
                                                  select peep).Sum (i=> i.MontoCalculado )
                                 ,TotalRealizado =(from per in this.Context.ProyectoEtapaRealizados 
                                                  join perp in this.Context.ProyectoEtapaRealizadoPeriodos on per.IdProyectoEtapaRealizado equals perp.IdProyectoEtapaRealizado 
                                                  where o.IdProyectoEtapa == per.IdProyectoEtapa 
                                                  select perp).Sum (i=> i.MontoCalculado)
						});
            return query.ToList ();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEtapa Copy(nc.ProyectoEtapa entity)
        {           
            nc.ProyectoEtapa _new = new nc.ProyectoEtapa();
		 _new.Nombre= entity.Nombre;
		 _new.CodigoVinculacion= entity.CodigoVinculacion;
		 _new.IdEstado= entity.IdEstado;
		 _new.FechaInicioEstimada= entity.FechaInicioEstimada;
		 _new.FechaFinEstimada= entity.FechaFinEstimada;
		 _new.FechaInicioRealizada= entity.FechaInicioRealizada;
		 _new.FechaFinRealizada= entity.FechaFinRealizada;
		 _new.IdEtapa= entity.IdEtapa;
		 _new.IdProyecto= entity.IdProyecto;
		 _new.NroEtapa= entity.NroEtapa;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapa entity,string renameFormat)
        {
            ProyectoEtapa  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapa entity, int id)
        {            
            entity.IdProyectoEtapa = id;            
        }
		public override void Set(ProyectoEtapa source,ProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Nombre= source.Nombre ;
		 target.CodigoVinculacion= source.CodigoVinculacion ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaInicioEstimada= source.FechaInicioEstimada ;
		 target.FechaFinEstimada= source.FechaFinEstimada ;
		 target.FechaInicioRealizada= source.FechaInicioRealizada ;
		 target.FechaFinRealizada= source.FechaFinRealizada ;
		 target.IdEtapa= source.IdEtapa ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NroEtapa= source.NroEtapa ;
		 		  
		}
		public override void Set(ProyectoEtapaResult source,ProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Nombre= source.Nombre ;
		 target.CodigoVinculacion= source.CodigoVinculacion ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaInicioEstimada= source.FechaInicioEstimada ;
		 target.FechaFinEstimada= source.FechaFinEstimada ;
		 target.FechaInicioRealizada= source.FechaInicioRealizada ;
		 target.FechaFinRealizada= source.FechaFinRealizada ;
		 target.IdEtapa= source.IdEtapa ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NroEtapa= source.NroEtapa ;
		 
		}
		public override void Set(ProyectoEtapa source,ProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Nombre= source.Nombre ;
		 target.CodigoVinculacion= source.CodigoVinculacion ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaInicioEstimada= source.FechaInicioEstimada ;
		 target.FechaFinEstimada= source.FechaFinEstimada ;
		 target.FechaInicioRealizada= source.FechaInicioRealizada ;
		 target.FechaFinRealizada= source.FechaFinRealizada ;
		 target.IdEtapa= source.IdEtapa ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NroEtapa= source.NroEtapa ;
		 	
		}		
		public override void Set(ProyectoEtapaResult source,ProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Nombre= source.Nombre ;
		 target.CodigoVinculacion= source.CodigoVinculacion ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaInicioEstimada= source.FechaInicioEstimada ;
		 target.FechaFinEstimada= source.FechaFinEstimada ;
		 target.FechaInicioRealizada= source.FechaInicioRealizada ;
		 target.FechaFinRealizada= source.FechaFinRealizada ;
		 target.IdEtapa= source.IdEtapa ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NroEtapa= source.NroEtapa ;
         target.Estado_Nombre= source.Estado_Nombre;	
         //   target.Estado_Codigo= source.Estado_Codigo;	
         //   target.Estado_Orden= source.Estado_Orden;	
         //   target.Estado_Descripcion= source.Estado_Descripcion;	
         //   target.Estado_Activo= source.Estado_Activo;	
			target.Etapa_IdFase= source.Etapa_IdFase;	
			//target.Etapa_Codigo= source.Etapa_Codigo;	
			target.Etapa_Nombre= source.Etapa_Nombre;	
            //target.Etapa_Orden= source.Etapa_Orden;	
            //target.Etapa_Activo= source.Etapa_Activo;	
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
		public override bool Equals(ProyectoEtapa source,ProyectoEtapa target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			 if((source.CodigoVinculacion == null)?target.CodigoVinculacion!=null:!source.CodigoVinculacion.Equals(target.CodigoVinculacion))return false;
			 if((source.IdEstado == null)?(target.IdEstado.HasValue && target.IdEstado.Value > 0):!source.IdEstado.Equals(target.IdEstado))return false;
						  if((source.FechaInicioEstimada == null)?(target.FechaInicioEstimada.HasValue):!source.FechaInicioEstimada.Equals(target.FechaInicioEstimada))return false;
			 if((source.FechaFinEstimada == null)?(target.FechaFinEstimada.HasValue):!source.FechaFinEstimada.Equals(target.FechaFinEstimada))return false;
			 if((source.FechaInicioRealizada == null)?(target.FechaInicioRealizada.HasValue):!source.FechaInicioRealizada.Equals(target.FechaInicioRealizada))return false;
			 if((source.FechaFinRealizada == null)?(target.FechaFinRealizada.HasValue):!source.FechaFinRealizada.Equals(target.FechaFinRealizada))return false;
			 if(!source.IdEtapa.Equals(target.IdEtapa))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.NroEtapa == null)?(target.NroEtapa.HasValue):!source.NroEtapa.Equals(target.NroEtapa))return false;
			
		  return true;
        }
		public override bool Equals(ProyectoEtapaResult source,ProyectoEtapaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			 if((source.CodigoVinculacion == null)?target.CodigoVinculacion!=null:!source.CodigoVinculacion.Equals(target.CodigoVinculacion))return false;
			 if((source.IdEstado == null)?(target.IdEstado.HasValue && target.IdEstado.Value > 0):!source.IdEstado.Equals(target.IdEstado))return false;
						  if((source.FechaInicioEstimada == null)?(target.FechaInicioEstimada.HasValue):!source.FechaInicioEstimada.Equals(target.FechaInicioEstimada))return false;
			 if((source.FechaFinEstimada == null)?(target.FechaFinEstimada.HasValue):!source.FechaFinEstimada.Equals(target.FechaFinEstimada))return false;
			 if((source.FechaInicioRealizada == null)?(target.FechaInicioRealizada.HasValue):!source.FechaInicioRealizada.Equals(target.FechaInicioRealizada))return false;
			 if((source.FechaFinRealizada == null)?(target.FechaFinRealizada.HasValue):!source.FechaFinRealizada.Equals(target.FechaFinRealizada))return false;
			 if(!source.IdEtapa.Equals(target.IdEtapa))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.NroEtapa == null)?(target.NroEtapa.HasValue):!source.NroEtapa.Equals(target.NroEtapa))return false;
             if((source.Estado_Nombre == null)?target.Estado_Nombre!=null:!source.Estado_Nombre.Equals(target.Estado_Nombre))return false;
            if(!source.Etapa_IdFase.Equals(target.Etapa_IdFase))return false;
            if((source.Etapa_Nombre == null)?target.Etapa_Nombre!=null:!source.Etapa_Nombre.Equals(target.Etapa_Nombre))return false;
                      //   if(!source.Etapa_Orden.Equals(target.Etapa_Orden))return false;
                      //if(!source.Etapa_Activo.Equals(target.Etapa_Activo))return false;
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
