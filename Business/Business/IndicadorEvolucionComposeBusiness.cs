using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
     

    public abstract class IndicadoresEvolucionComposeBusiness<TEntityCompose, TEntity, TFilter, TResult, TIdType> : EntityComposeBusiness<TEntityCompose, TEntity, TFilter, TResult, TIdType>
        where TEntityCompose : IndicadoresEvolucionCompose, new()
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>, new()
        where TIdType : IComparable
    {

        #region Actions

        protected void Add(List<IndicadorEvolucionResult> evoluciones, int IdIndicador, IContextUser contextUser)
        {
            //Agrego los IndicadorEvolucion

            foreach (IndicadorEvolucionResult ier in evoluciones)
            {
                ier.IdIndicador = IdIndicador;
                IndicadorEvolucionBusiness.Current.Add(ier.ToEntity(), contextUser);
            }
        }
        protected void Update(List<IndicadorEvolucionResult> evoluciones, int IdIndicador, IContextUser contextUser)
        {

            List<IndicadorEvolucionResult> copy = IndicadorEvolucionBusiness.Current.CopiesResult(evoluciones);
            try
            {
                // Elimino todos los evoluciones

                List<int> actualIds = (from o in evoluciones where o.IdIndicadorEvolucion > 0 select o.IdIndicadorEvolucion).ToList();
                List<IndicadorEvolucionResult> evolucionesOld = GetIndicadoresEvolucionByIdIndicador(IdIndicador);
                List<int> idsToDelete = (from o in evolucionesOld where !actualIds.Contains(o.IdIndicadorEvolucion) select o.IdIndicadorEvolucion).ToList();

                IndicadorEvolucionBusiness.Current.Delete(idsToDelete.ToArray(), contextUser);

                foreach (IndicadorEvolucionResult ier in evoluciones)
                {


                    if (ier.IdIndicadorEvolucion < 1)
                    {
                        IndicadorEvolucion ie = ier.ToEntity();
                        ie.IdIndicador = IdIndicador;
                        IndicadorEvolucionBusiness.Current.Add(ie, contextUser);

                    }
                    else
                    {
                        IndicadorEvolucion ie = ier.ToEntity();
                        IndicadorEvolucion IndicadorEvolucion = IndicadorEvolucionBusiness.Current.GetById(ie.IdIndicadorEvolucion);
                        IndicadorEvolucionBusiness.Current.Set(ie, IndicadorEvolucion);
                        IndicadorEvolucionBusiness.Current.Update(IndicadorEvolucion, contextUser);
                    }

                }
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch
            {
                evoluciones = copy;
                throw;
            }


        }
        protected void Delete(List<IndicadorEvolucionResult> evoluciones, IContextUser contextUser)
        {
            evoluciones.ForEach( p => IndicadorEvolucionBusiness.Current.Delete(p.ID, contextUser));
        }

        #endregion

        #region protected Methods
        protected List<IndicadorEvolucionResult> GetIndicadoresEvolucionByIdIndicador(int id)
        {
            List<IndicadorEvolucionResult> ier = IndicadorEvolucionBusiness.Current.GetResult(new IndicadorEvolucionFilter() { IdIndicador = id });
            return ier;
        }
        #endregion

        #region Validations


        public bool ValidateEvoluciones(List<IndicadorEvolucionResult> Evoluciones)
        {

            var tabla =
                        from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            CantBase = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Base),
                            CantIntermedio = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio),
                            CantFinal = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Final)
                        };


            foreach (var linea in tabla)
            {
                // Valdio que en casa región geográfica deba exisitir obligatoriamente una evolución base, y al menos una intermedia o una sola final.
                if (!((linea.CantBase == 1) && ((linea.CantIntermedio >= 1 && linea.CantFinal <= 1) || (linea.CantFinal == 1))))
                {
                    return false;
                }
            }

            var tabla2 =
            from evolucion in Evoluciones
            group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
            select new
            {
                IdClasificacionGeografica = evolucionGroup.Key,
                MonthGroups =
                    from o in evolucionGroup
                    group o by o.FechaEstimada into mg
                    select new
                    {
                        Fecha = mg.Key,
                        Cantidad = mg.Count()
                    }

            };

            foreach (var linea2 in tabla2)
            {

                if (linea2.MonthGroups.Count(p => p.Cantidad > 1) > 0)
                {
                    return false;
                }
            }

            var tabla3 =
            from evolucion in Evoluciones
            group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
            select new
            {
                IdClasificacionGeografica = evolucionGroup.Key,
                MonthGroups =
                    from o in evolucionGroup
                    orderby o.FechaEstimada
                    select new
                    {
                        Fecha = o.FechaEstimada,
                        Instancia = o.IdIndicadorEvolucionInstancia
                    }

            };

            foreach (var linea3 in tabla3)
            {

                if (linea3.MonthGroups.First().Instancia != (int)IndicadorEvolucionInstanciaEnum.Base)
                {
                    return false;
                }

                if (linea3.MonthGroups.Count(i => i.Instancia == (int)IndicadorEvolucionInstanciaEnum.Final) > 0
                    && linea3.MonthGroups.Last().Instancia != (int)IndicadorEvolucionInstanciaEnum.Final)
                {
                    return false;
                }

            }

            return true;


        }


        public override void Validate(TEntityCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            DataHelper.Validate(ValidateEvoluciones(entity.Evoluciones), "InvalidField", "Evolucion");                                      
        }

        public override bool Can(TEntityCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }
        #endregion

    }

    public class ProyectoBeneficiarioIndicadorComposeBusiness : IndicadoresEvolucionComposeBusiness<ProyectoBeneficiarioIndicadorCompose, Indicador, IndicadorFilter, IndicadorResult, int>
    {
        #region Singleton
        private static volatile ProyectoBeneficiarioIndicadorComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoBeneficiarioIndicadorComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoBeneficiarioIndicadorComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Indicador, IndicadorFilter, IndicadorResult, int> EntityBusinessBase
        {
            get { return IndicadorBusiness.Current; }
        }


        public override ProyectoBeneficiarioIndicadorCompose GetById(int id)
        {

            ProyectoBeneficiarioIndicadorCompose proyectoBeneficiarioIndicadorCompose = new ProyectoBeneficiarioIndicadorCompose();

            proyectoBeneficiarioIndicadorCompose.Indicador = ProyectoBeneficiarioIndicadorBusiness.Current.GetResult(
                new ProyectoBeneficiarioIndicadorFilter() { IdProyectoBeneficiarioIndicador = id }).FirstOrDefault();

            proyectoBeneficiarioIndicadorCompose.Evoluciones =
                ProyectoBeneficiarioIndicadorComposeBusiness.Current.GetIndicadoresEvolucionByIdIndicador(proyectoBeneficiarioIndicadorCompose.Indicador.IdIndicador);

            return proyectoBeneficiarioIndicadorCompose;

        }

        public ProyectoBeneficiarioIndicadorCompose GetByIdForCopy(int id)
        {

            ProyectoBeneficiarioIndicadorCompose proyectoBeneficiarioIndicadorCompose = new ProyectoBeneficiarioIndicadorCompose();

            proyectoBeneficiarioIndicadorCompose.Indicador = ProyectoBeneficiarioIndicadorBusiness.Current.GetResult(
                new ProyectoBeneficiarioIndicadorFilter() { IdProyectoBeneficiarioIndicador = id }).FirstOrDefault();

            return proyectoBeneficiarioIndicadorCompose;

        }

        #region Actions
        public override void Add(ProyectoBeneficiarioIndicadorCompose entity, IContextUser contextUser)
        {
          
            Indicador indicador = IndicadorBusiness.Current.GetNew();
            indicador.Observacion = entity.Indicador.Indicador_Observacion;
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;
            IndicadorBusiness.Current.Add(indicador, contextUser);

            entity.Indicador.IdIndicador = indicador.IdIndicador;
            ProyectoBeneficiarioIndicadorBusiness.Current.Add(entity.Indicador.ToEntity(), contextUser);
            Add(entity.Evoluciones, indicador.IdIndicador, contextUser);

           
        }
        public override void Update(ProyectoBeneficiarioIndicadorCompose entity, IContextUser contextUser)
        {

            ProyectoBeneficiarioIndicador  proyectoBeneficiarioIndicador = 
                ProyectoBeneficiarioIndicadorBusiness.Current.GetById(entity.Indicador.IdProyectoBeneficiarioIndicador);
            ProyectoBeneficiarioIndicadorBusiness.Current.Set(entity.Indicador.ToEntity(), proyectoBeneficiarioIndicador);
            ProyectoBeneficiarioIndicadorBusiness.Current.Update(proyectoBeneficiarioIndicador, contextUser);

            Indicador indicador = IndicadorBusiness.Current.GetById(proyectoBeneficiarioIndicador.IdIndicador);
            indicador.Observacion = entity.Indicador.Indicador_Observacion;            
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;

            IndicadorBusiness.Current.Update(indicador, contextUser);

            Update(entity.Evoluciones, indicador.IdIndicador, contextUser);
                       
        }
        public override void Delete(ProyectoBeneficiarioIndicadorCompose entity, IContextUser contextUser)
        {
            
            Delete(entity.Evoluciones, contextUser);
            ProyectoBeneficiarioIndicadorBusiness.Current.Delete(entity.Indicador.IdProyectoBeneficiarioIndicador, contextUser);
            IndicadorBusiness.Current.Delete(entity.Indicador.IdIndicador, contextUser); 
            
        }


        #endregion

        public override bool Equals(ProyectoBeneficiarioIndicadorCompose source, ProyectoBeneficiarioIndicadorCompose target)
        {

            if (!ProyectoBeneficiarioIndicadorBusiness.Current.Equals(source.Indicador, target.Indicador)) return false;

            if (source.Evoluciones.Count() != target.Evoluciones.Count()) return false;

            foreach (IndicadorEvolucionResult ier in source.Evoluciones)
            {
                IndicadorEvolucionResult ierTarget = source.Evoluciones.Where(p => p.IdIndicadorEvolucion == ier.IdIndicadorEvolucion).SingleOrDefault();
                if (ierTarget == null) return false;
                if (!ier.Equals(ierTarget.ToEntity())) return false;
            }
          
            return true;
        }

    }

    public class ProyectoBeneficioIndicadorComposeBusiness : IndicadoresEvolucionComposeBusiness<ProyectoBeneficioIndicadorCompose, Indicador, IndicadorFilter, IndicadorResult, int>
    {
        #region Singleton
        private static volatile ProyectoBeneficioIndicadorComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoBeneficioIndicadorComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoBeneficioIndicadorComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Indicador, IndicadorFilter, IndicadorResult, int> EntityBusinessBase
        {
            get { return IndicadorBusiness.Current; }
        }


        public override ProyectoBeneficioIndicadorCompose GetById(int id)
        {

            ProyectoBeneficioIndicadorCompose proyectoBeneficioIndicadorCompose = new ProyectoBeneficioIndicadorCompose();

            proyectoBeneficioIndicadorCompose.Indicador = ProyectoBeneficioIndicadorBusiness.Current.GetResult(
                new ProyectoBeneficioIndicadorFilter() { IdProyectoBeneficioIndicador = id }).FirstOrDefault();

            proyectoBeneficioIndicadorCompose.Evoluciones =
                ProyectoBeneficioIndicadorComposeBusiness.Current.GetIndicadoresEvolucionByIdIndicador(proyectoBeneficioIndicadorCompose.Indicador.IdIndicador);

            foreach (IndicadorEvolucionResult ier in proyectoBeneficioIndicadorCompose.Evoluciones)
	        {
                if ((ier.CantidadEstimada != null) && (ier.CantidadEstimada > 0) &&
                    (ier.PrecioUnitarioEstimado != null) && (ier.PrecioUnitarioEstimado > 0))
                {
                    ier.MontoEstimadoCalc = ier.CantidadEstimada * ier.PrecioUnitarioEstimado;
                }

                if ((ier.CantidadReal != null) && (ier.CantidadReal > 0) &&
                    (ier.PrecioUnitarioReal != null) && (ier.PrecioUnitarioReal > 0))
                {
                    ier.MontoRealizadoCalc = ier.CantidadReal * ier.PrecioUnitarioReal;
                }
            }
            
 


            return proyectoBeneficioIndicadorCompose;

        }

        public ProyectoBeneficioIndicadorCompose GetByIdForCopy(int id)
        {
            ProyectoBeneficioIndicadorCompose proyectoBeneficioIndicadorCompose = new ProyectoBeneficioIndicadorCompose();

            proyectoBeneficioIndicadorCompose.Indicador = ProyectoBeneficioIndicadorBusiness.Current.GetResult(
                new ProyectoBeneficioIndicadorFilter() { IdProyectoBeneficioIndicador = id }).FirstOrDefault();

            proyectoBeneficioIndicadorCompose.Evoluciones =
                ProyectoBeneficioIndicadorComposeBusiness.Current.GetIndicadoresEvolucionByIdIndicador(proyectoBeneficioIndicadorCompose.Indicador.IdIndicador);
            
            return proyectoBeneficioIndicadorCompose;

        }


        #region Actions
        public override void Add(ProyectoBeneficioIndicadorCompose entity, IContextUser contextUser)
        {

            Indicador indicador = IndicadorBusiness.Current.GetNew();
            indicador.Observacion = entity.Indicador.Indicador_Observacion;
            //German 20140511 - Tarea 124
            indicador.IdIndicadorRubro = entity.Indicador.IdIndicadorRubro;
            //German 20140511 - Tarea 124
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;
            IndicadorBusiness.Current.Add(indicador, contextUser);

            entity.Indicador.IdIndicador = indicador.IdIndicador;
            ProyectoBeneficioIndicadorBusiness.Current.Add(entity.Indicador.ToEntity(), contextUser);
            Add(entity.Evoluciones, indicador.IdIndicador, contextUser);


        }
        public override void Update(ProyectoBeneficioIndicadorCompose entity, IContextUser contextUser)
        {

            ProyectoBeneficioIndicador proyectoBeneficioIndicador =
                ProyectoBeneficioIndicadorBusiness.Current.GetById(entity.Indicador.IdProyectoBeneficioIndicador);
            ProyectoBeneficioIndicadorBusiness.Current.Set(entity.Indicador.ToEntity(), proyectoBeneficioIndicador);
            ProyectoBeneficioIndicadorBusiness.Current.Update(proyectoBeneficioIndicador, contextUser);

            Indicador indicador = IndicadorBusiness.Current.GetById(proyectoBeneficioIndicador.IdIndicador);
            indicador.Observacion = entity.Indicador.Indicador_Observacion;
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;
            //German 20140511 - Tarea 124
            indicador.IdIndicadorRubro = entity.Indicador.IdIndicadorRubro;
            //German 20140511 - Tarea 124
            
            IndicadorBusiness.Current.Update(indicador, contextUser);

            Update(entity.Evoluciones, indicador.IdIndicador, contextUser);

        }
        public override void Delete(ProyectoBeneficioIndicadorCompose entity, IContextUser contextUser)
        {

            Delete(entity.Evoluciones, contextUser);
            ProyectoBeneficioIndicadorBusiness.Current.Delete(entity.Indicador.IdProyectoBeneficioIndicador, contextUser);
            IndicadorBusiness.Current.Delete(entity.Indicador.IdIndicador, contextUser);

        }
        
        #endregion

        public override bool Equals(ProyectoBeneficioIndicadorCompose source, ProyectoBeneficioIndicadorCompose target)
        {

            if (!ProyectoBeneficioIndicadorBusiness.Current.Equals(source.Indicador, target.Indicador)) return false;

            if (source.Evoluciones.Count() != target.Evoluciones.Count()) return false;

            foreach (IndicadorEvolucionResult ier in source.Evoluciones)
            {
                IndicadorEvolucionResult ierTarget = source.Evoluciones.Where(p => p.IdIndicadorEvolucion == ier.IdIndicadorEvolucion).SingleOrDefault();
                if (ierTarget == null) return false;
                if (!ier.Equals(ierTarget.ToEntity())) return false;
            }

            return true;
        }
    }

    public class ProyectoEvaluacionSectorialIndicadorComposeBusiness : IndicadoresEvolucionComposeBusiness<ProyectoEvaluacionSectorialIndicadorCompose, Indicador, IndicadorFilter, IndicadorResult, int>
    {
        #region Singleton
        private static volatile ProyectoEvaluacionSectorialIndicadorComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoEvaluacionSectorialIndicadorComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEvaluacionSectorialIndicadorComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Indicador, IndicadorFilter, IndicadorResult, int> EntityBusinessBase
        {
            get { return IndicadorBusiness.Current; }
        }


        public override ProyectoEvaluacionSectorialIndicadorCompose GetById(int id)
        {

            ProyectoEvaluacionSectorialIndicadorCompose proyectoEvaluacionSectorialIndicadorCompose = new ProyectoEvaluacionSectorialIndicadorCompose();

            proyectoEvaluacionSectorialIndicadorCompose.Indicador = ProyectoEvaluacionSectorialIndicadorBusiness.Current.GetResult(
                new ProyectoEvaluacionSectorialIndicadorFilter() { IdProyectoEvaluacionSectorialIndicador = id }).FirstOrDefault();

            proyectoEvaluacionSectorialIndicadorCompose.Evoluciones =
                ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.GetIndicadoresEvolucionByIdIndicador(proyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicador);

            foreach (IndicadorEvolucionResult ier in proyectoEvaluacionSectorialIndicadorCompose.Evoluciones)
            {
                if ((ier.CantidadEstimada != null) && (ier.CantidadEstimada > 0) &&
                    (ier.PrecioUnitarioEstimado != null) && (ier.PrecioUnitarioEstimado > 0))
                {
                    ier.MontoEstimadoCalc = ier.CantidadEstimada * ier.PrecioUnitarioEstimado;
                }

                if ((ier.CantidadReal != null) && (ier.CantidadReal > 0) &&
                    (ier.PrecioUnitarioReal != null) && (ier.PrecioUnitarioReal > 0))
                {
                    ier.MontoRealizadoCalc = ier.CantidadReal * ier.PrecioUnitarioReal;
                }
            }




            return proyectoEvaluacionSectorialIndicadorCompose;

        }

        public ProyectoEvaluacionSectorialIndicadorCompose GetByIdForCopy(int id)
        {
            ProyectoEvaluacionSectorialIndicadorCompose proyectoEvaluacionSectorialIndicadorCompose = new ProyectoEvaluacionSectorialIndicadorCompose();

            proyectoEvaluacionSectorialIndicadorCompose.Indicador = ProyectoEvaluacionSectorialIndicadorBusiness.Current.GetResult(
                new ProyectoEvaluacionSectorialIndicadorFilter() { IdProyectoEvaluacionSectorialIndicador = id }).FirstOrDefault();

            proyectoEvaluacionSectorialIndicadorCompose.Evoluciones =
                ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.GetIndicadoresEvolucionByIdIndicador(proyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicador);

            return proyectoEvaluacionSectorialIndicadorCompose;

        }


        #region Actions
        public override void Add(ProyectoEvaluacionSectorialIndicadorCompose entity, IContextUser contextUser)
        {

            Indicador indicador = IndicadorBusiness.Current.GetNew();
            indicador.Observacion = entity.Indicador.Indicador_Observacion;
            //German 20140511 - Tarea 124
            indicador.IdIndicadorRubro = entity.Indicador.IdIndicadorRubro;
            //German 20140511 - Tarea 124
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;
            IndicadorBusiness.Current.Add(indicador, contextUser);

            entity.Indicador.IdIndicador = indicador.IdIndicador;
            ProyectoEvaluacionSectorialIndicadorBusiness.Current.Add(entity.Indicador.ToEntity(), contextUser);
            Add(entity.Evoluciones, indicador.IdIndicador, contextUser);


        }
        public override void Update(ProyectoEvaluacionSectorialIndicadorCompose entity, IContextUser contextUser)
        {

            ProyectoEvaluacionSectorialIndicador proyectoEvaluacionSectorialIndicador =
            ProyectoEvaluacionSectorialIndicadorBusiness.Current.GetById(entity.Indicador.IdProyectoEvaluacionSectorialIndicador);
            ProyectoEvaluacionSectorialIndicadorBusiness.Current.Set(entity.Indicador.ToEntity(), proyectoEvaluacionSectorialIndicador);
            ProyectoEvaluacionSectorialIndicadorBusiness.Current.Update(proyectoEvaluacionSectorialIndicador, contextUser);

            Indicador indicador = IndicadorBusiness.Current.GetById(proyectoEvaluacionSectorialIndicador.IdIndicador);
            indicador.Observacion = entity.Indicador.Indicador_Observacion;
            indicador.IdMedioVerificacion = entity.Indicador.Indicador_IdMedioVerificacion;
            //German 20140511 - Tarea 124
            indicador.IdIndicadorRubro = entity.Indicador.IdIndicadorRubro;
            //German 20140511 - Tarea 124

            IndicadorBusiness.Current.Update(indicador, contextUser);

            Update(entity.Evoluciones, indicador.IdIndicador, contextUser);

        }
        public override void Delete(ProyectoEvaluacionSectorialIndicadorCompose entity, IContextUser contextUser)
        {

            Delete(entity.Evoluciones, contextUser);
            ProyectoEvaluacionSectorialIndicadorBusiness.Current.Delete(entity.Indicador.IdProyectoEvaluacionSectorialIndicador, contextUser);
            IndicadorBusiness.Current.Delete(entity.Indicador.IdIndicador, contextUser);

        }

        #endregion

        public override bool Equals(ProyectoEvaluacionSectorialIndicadorCompose source, ProyectoEvaluacionSectorialIndicadorCompose target)
        {

            if (!ProyectoEvaluacionSectorialIndicadorBusiness.Current.Equals(source.Indicador, target.Indicador)) return false;

            if (source.Evoluciones.Count() != target.Evoluciones.Count()) return false;

            foreach (IndicadorEvolucionResult ier in source.Evoluciones)
            {
                IndicadorEvolucionResult ierTarget = source.Evoluciones.Where(p => p.IdIndicadorEvolucion == ier.IdIndicadorEvolucion).SingleOrDefault();
                if (ierTarget == null) return false;
                if (!ier.Equals(ierTarget.ToEntity())) return false;
            }

            return true;
        }
    }
}
