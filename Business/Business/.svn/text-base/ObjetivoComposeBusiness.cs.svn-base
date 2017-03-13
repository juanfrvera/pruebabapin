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


    public abstract class ObjetivoComposeBusiness<TEntityCompose, TEntity, TFilter, TResult, TIdType> : EntityComposeBusiness<TEntityCompose, TEntity, TFilter, TResult, TIdType>
        where TEntityCompose : ObjetivoCompose, new()
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>, new()
        where TIdType : IComparable
    {

        #region Actions
        protected void Add(List<ObjetivoSupuestoResult> supuestos, int IdObjetivo, IContextUser contextUser)
        {

            //Agrego los ObjetivoSupuesto

            foreach (ObjetivoSupuestoResult osr in supuestos)
            {
                osr.IdObjetivo = IdObjetivo;
                ObjetivoSupuestoBusiness.Current.Add(osr.ToEntity(), contextUser);
            }
        }
        protected void Add(List<ObjetivoIndicadorCompose> indicadores, int IdObjetivo, IContextUser contextUser)
        {
            foreach (ObjetivoIndicadorCompose ic in indicadores)
            {
                // Agrego Indicador
                Indicador indicador = IndicadorBusiness.Current.GetNew();
                indicador.IdMedioVerificacion = ic.Indicador.Indicador_IdMedioVerificacion;
                indicador.Observacion = ic.Indicador.Indicador_Observacion;
                indicador.DetalleMedioVerificacion = ic.Indicador.DetalleMedioVerificacion;
                //German 20140511 - Tarea 124
                indicador.IdIndicadorRubro = ic.Indicador.IdIndicadorRubro.Value;
                //German 20140511 - Tarea 124
                IndicadorBusiness.Current.Add(indicador, contextUser);

                // Agrego IndicadorObjetivo
                ic.Indicador.IdObjetivo = IdObjetivo;
                ic.Indicador.IdIndicador = indicador.IdIndicador;
                ObjetivoIndicadorBusiness.Current.Add(ic.Indicador.ToEntity(), contextUser);

                // Agrego las Evoluciones
                foreach (IndicadorEvolucionResult ier in ic.Evoluciones)
                {
                    ier.IdIndicador = indicador.IdIndicador;
                    IndicadorEvolucion ie = ier.ToEntity();
                    IndicadorEvolucionBusiness.Current.Add(ie, contextUser);
                }
            }
        }

        protected void Update(List<ObjetivoIndicadorCompose> indicadores, int IdObjetivo, IContextUser contextUser)
        {

            List<ObjetivoIndicadorCompose> copy = new List<ObjetivoIndicadorCompose>();
            foreach (ObjetivoIndicadorCompose objetivoIndicador in indicadores)
            {

                ObjetivoIndicadorCompose objetivoIndicadorCopy = new ObjetivoIndicadorCompose();
                objetivoIndicadorCopy.Indicador = ObjetivoIndicadorBusiness.Current.CopyResult(objetivoIndicador.Indicador);
                foreach (IndicadorEvolucionResult evoluciones in objetivoIndicador.Evoluciones)
                {
                    objetivoIndicadorCopy.Evoluciones = IndicadorEvolucionBusiness.Current.CopiesResult(objetivoIndicador.Evoluciones);
                }
                copy.Add(objetivoIndicadorCopy);
            }

            try
            {

                //Elimino todos los ObjetivoIndicador con su IndicadorEvolucion
                //correspondiente que ya no esten mas.

                List<int> actualIds = (from o in indicadores where o.Indicador.IdObjetivoIndicador > 0 select o.Indicador.IdObjetivoIndicador).ToList();
                List<ObjetivoIndicadorCompose> indicadoresOld = GetObjetivoIndicadoresComposeByIdObjetivo(IdObjetivo, true);
                List<ObjetivoIndicadorCompose> indicadoresToDelete = (from o in indicadoresOld where !actualIds.Contains(o.Indicador.IdObjetivoIndicador) select o).ToList();


                foreach (ObjetivoIndicadorCompose item in indicadoresToDelete)
                {

                    item.Evoluciones.ForEach(p => IndicadorEvolucionBusiness.Current.Delete(p.IdIndicadorEvolucion, contextUser));
                    ObjetivoIndicadorBusiness.Current.Delete(item.Indicador.IdObjetivoIndicador, contextUser);
                    IndicadorBusiness.Current.Delete(item.Indicador.IdIndicador, contextUser);

                }


                foreach (ObjetivoIndicadorCompose oic in indicadores)
                {

                    if (oic.Indicador.IdObjetivoIndicador < 1)
                    {

                        Indicador indicador = IndicadorBusiness.Current.GetNew();
                        indicador.IdMedioVerificacion = oic.Indicador.Indicador_IdMedioVerificacion;
                        indicador.Observacion = oic.Indicador.Indicador_Observacion;
                        //German 20140511 - Tarea 124
                        indicador.IdIndicadorRubro = oic.Indicador.IdIndicadorRubro.Value;
                        indicador.DetalleMedioVerificacion = oic.Indicador.DetalleMedioVerificacion;
                        //German 20140511 - Tarea 124
                        IndicadorBusiness.Current.Add(indicador, contextUser);


                        oic.Indicador.IdObjetivo = IdObjetivo;
                        oic.Indicador.IdIndicador = indicador.IdIndicador;
                        ObjetivoIndicador oi = oic.Indicador.ToEntity();
                        foreach (IndicadorEvolucionResult ier in oic.Evoluciones)
                        {

                            ier.IdIndicador = indicador.IdIndicador;
                            IndicadorEvolucionBusiness.Current.Add(ier.ToEntity(), contextUser);
                        }
                        ObjetivoIndicadorBusiness.Current.Add(oi, contextUser);
                    }
                    else
                    {


                        Indicador indicador = IndicadorBusiness.Current.GetById(oic.Indicador.IdIndicador);
                        indicador.Observacion = oic.Indicador.Indicador_Observacion;
                        indicador.IdMedioVerificacion = oic.Indicador.Indicador_IdMedioVerificacion;
                        //German 20140511 - Tarea 124
                        indicador.IdIndicadorRubro = oic.Indicador.IdIndicadorRubro.Value;
                        indicador.DetalleMedioVerificacion = oic.Indicador.DetalleMedioVerificacion;
                        //German 20140511 - Tarea 124
                        IndicadorBusiness.Current.Update(indicador, contextUser);

                        //Actualizo ObjetivoIndicador 
                        ObjetivoIndicador oi = oic.Indicador.ToEntity();
                        ObjetivoIndicador objetivoIndicador = ObjetivoIndicadorBusiness.Current.GetById(oi.IdObjetivoIndicador);
                        ObjetivoIndicadorBusiness.Current.Set(oi, objetivoIndicador);

                        ObjetivoIndicadorBusiness.Current.Update(objetivoIndicador, contextUser);

                        //Elimino los IndicadorEvolucion

                        List<int> actualIndicadoresIds = (from o in oic.Evoluciones where o.IdIndicadorEvolucion > 0 select o.IdIndicadorEvolucion).ToList();
                        List<IndicadorEvolucion> oldDetail = IndicadorEvolucionBusiness.Current.GetList(new IndicadorEvolucionFilter() { IdIndicador = objetivoIndicador.IdIndicador });
                        List<IndicadorEvolucion> deletets = (from o in oldDetail where !actualIndicadoresIds.Contains(o.IdIndicadorEvolucion) select o).ToList();
                        IndicadorEvolucionBusiness.Current.Delete(deletets, contextUser);

                        foreach (IndicadorEvolucionResult ier in oic.Evoluciones)
                        {

                            IndicadorEvolucion ie = ier.ToEntity();
                            if (ie.IdIndicadorEvolucion < 1)
                            {
                                //Agrego si es un IndicadorEvolucion nuevo.

                                ie.IdIndicador = objetivoIndicador.IdIndicador;
                                IndicadorEvolucionBusiness.Current.Add(ie, contextUser);

                            }
                            else
                            {

                                //Modificosi es un IndicadorEvolucion que ya existe.

                                IndicadorEvolucion indicadorEvolucion = IndicadorEvolucionBusiness.Current.GetById(ie.IdIndicadorEvolucion);
                                IndicadorEvolucionBusiness.Current.Set(ie, indicadorEvolucion);
                                IndicadorEvolucionBusiness.Current.Update(indicadorEvolucion, contextUser);
                            }
                        }

                    }
                }

            }
            catch
            {
                indicadores = copy;
                throw;
            }

        }
        protected void Update(List<ObjetivoSupuestoResult> supuestos, int IdObjetivo, IContextUser contextUser)
        {

            List<ObjetivoSupuestoResult> copy = ObjetivoSupuestoBusiness.Current.CopiesResult(supuestos);
            try
            {
                // Elimino todos los supuestos

                List<int> actualIds = (from o in supuestos where o.IdObjetivoSupuesto > 0 select o.IdObjetivoSupuesto).ToList();
                List<ObjetivoSupuestoResult> supuestosOld = GetObjetivoSupuestosByIdObjetivo(IdObjetivo);
                List<int> idsToDelete = (from o in supuestosOld where !actualIds.Contains(o.IdObjetivoSupuesto) select o.IdObjetivoSupuesto).ToList();

                ObjetivoSupuestoBusiness.Current.Delete(idsToDelete.ToArray(), contextUser);

                foreach (ObjetivoSupuestoResult osr in supuestos)
                {


                    if (osr.IdObjetivoSupuesto < 1)
                    {
                        ObjetivoSupuesto os = osr.ToEntity();
                        os.IdObjetivo = IdObjetivo;
                        ObjetivoSupuestoBusiness.Current.Add(os, contextUser);

                    }
                    else
                    {
                        ObjetivoSupuesto os = osr.ToEntity();
                        ObjetivoSupuesto objetivoSupuesto = ObjetivoSupuestoBusiness.Current.GetById(os.IdObjetivoSupuesto);
                        ObjetivoSupuestoBusiness.Current.Set(os, objetivoSupuesto);
                        ObjetivoSupuestoBusiness.Current.Update(objetivoSupuesto, contextUser);
                    }

                }
               
            }
            catch
            {
                supuestos = copy;
                throw;
            }

        }

        protected void Delete(List<ObjetivoIndicadorCompose> indicadores, IContextUser contextUser)
        {

            foreach (ObjetivoIndicadorCompose oic in indicadores)
            {
                oic.Evoluciones.ForEach(p => IndicadorEvolucionBusiness.Current.Delete(p.ID, contextUser));
                ObjetivoIndicadorBusiness.Current.Delete(oic.Indicador.IdObjetivoIndicador, contextUser);
                IndicadorBusiness.Current.Delete(oic.Indicador.IdIndicador, contextUser);
            }

        }
        protected void Delete(List<ObjetivoSupuestoResult> supuestos, IContextUser contextUser)
        {
            foreach (ObjetivoSupuestoResult ost in supuestos)
            {
                ObjetivoSupuestoBusiness.Current.Delete(ost.IdObjetivoSupuesto, contextUser);
            }
        }

        protected bool EqualsObjetivoSupuesto(List<ObjetivoSupuestoResult> source, List<ObjetivoSupuestoResult> target)
        {
           
            if (source.Count() != target.Count()) return false;

            foreach (ObjetivoSupuestoResult osr in source)
	        {
                ObjetivoSupuestoResult osrTarget = target.Where(p => p.IdObjetivoSupuesto == osr.IdObjetivoSupuesto).SingleOrDefault();
                if (osrTarget == null) return false;
                if (!ObjetivoSupuestoBusiness.Current.Equals(osr,osrTarget)) return false; 
	        }
            
            return true;
        }
        protected bool EqualsObjetivoIndicadorCompose(List<ObjetivoIndicadorCompose> source, List<ObjetivoIndicadorCompose> target)
        {
            
            if (source.Count() != target.Count()) return false;

            foreach (ObjetivoIndicadorCompose oic in source)
            {
                ObjetivoIndicadorCompose oicTarget = target.Where(p => p.Indicador.IdIndicador == oic.Indicador.IdIndicador).SingleOrDefault();
                if (oicTarget == null) return false;
               // if (!oic.Indicador.Equals(oicTarget.Indicador.ToEntity())) return false;
                if (! ObjetivoIndicadorBusiness.Current.Equals(oic.Indicador, oicTarget.Indicador)) return false;

                if (oic.Evoluciones.Count() != oicTarget.Evoluciones.Count()) return false;

                foreach (IndicadorEvolucionResult ier in oic.Evoluciones)
                {
                    IndicadorEvolucionResult ierTarget = oicTarget.Evoluciones.Where(p => p.IdIndicadorEvolucion == ier.IdIndicadorEvolucion).SingleOrDefault();
                    if (ierTarget == null) return false;
                    if (!  IndicadorEvolucionBusiness.Current.Equals(ier,ierTarget)) return false;
                }
            }

            return true;
        }

        #endregion

        #region protected Methods
        protected List<ObjetivoSupuestoResult> GetObjetivoSupuestosByIdObjetivo(int id)
        {
            return ObjetivoSupuestoBusiness.Current.GetResult(new ObjetivoSupuestoFilter() { IdObjetivo = id });
        }
        protected List<ObjetivoIndicadorCompose> GetObjetivoIndicadoresComposeByIdObjetivo(int id, bool ConEvoluciones)
        {

            List<ObjetivoIndicadorCompose> ObjetivoIndicadoresCompose = new List<ObjetivoIndicadorCompose>();

            List<ObjetivoIndicadorResult> objetivoIndicadores =
                ObjetivoIndicadorBusiness.Current.GetResult(new ObjetivoIndicadorFilter() { IdObjetivo = id });

            List<IndicadorEvolucionResult> indicadoresEvolucion =
                IndicadorEvolucionBusiness.Current.GetResult(new IndicadorEvolucionFilter() { IdsIndicadores = (from o in objetivoIndicadores select o.IdObjetivo).ToList() });


            foreach (ObjetivoIndicadorResult objetivoIndicador in objetivoIndicadores)
            {
                ObjetivoIndicadorCompose objetivoIndicadorCompose = new ObjetivoIndicadorCompose();
                objetivoIndicadorCompose.Indicador = objetivoIndicador;
                if (ConEvoluciones)
                objetivoIndicadorCompose.Evoluciones = (from o in indicadoresEvolucion where o.IdIndicador == objetivoIndicador.IdIndicador select o).ToList();
                ObjetivoIndicadoresCompose.Add(objetivoIndicadorCompose);
            }

            return ObjetivoIndicadoresCompose;
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

            foreach (ObjetivoIndicadorCompose oic in entity.Indicadores)
            {
                DataHelper.Validate(ValidateEvoluciones(oic.Evoluciones), "InvalidField", "Evolucion");
            }
        }

        public override bool Can(TEntityCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }
        #endregion

    }


    // Proyecto (TODO MOVER a neuvo archivo)

    public class ProyectoPropositoComposeBusiness : ObjetivoComposeBusiness<ProyectoPropositoCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile ProyectoPropositoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoPropositoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoPropositoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }


        public override ProyectoPropositoCompose GetById(int id)
        {            
            ProyectoPropositoCompose proyectoPropositoCompose = new ProyectoPropositoCompose();
            proyectoPropositoCompose.Proposito =
                ProyectoPropositoBusiness.Current.GetResult(new ProyectoPropositoFilter() { IdProyectoProposito = id }).FirstOrDefault();

            proyectoPropositoCompose.Indicadores =
                ProyectoPropositoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(proyectoPropositoCompose.Proposito.IdObjetivo, true);
            proyectoPropositoCompose.Supuestos =
                ProyectoPropositoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(proyectoPropositoCompose.Proposito.IdObjetivo);

            return proyectoPropositoCompose;
        }

        public  ProyectoPropositoCompose GetByIdForCopy(int id)
        {

            ProyectoPropositoCompose proyectoPropositoCompose = new ProyectoPropositoCompose();
            proyectoPropositoCompose.Proposito =
                ProyectoPropositoBusiness.Current.GetResult(new ProyectoPropositoFilter() { IdProyectoProposito = id }).FirstOrDefault();

            proyectoPropositoCompose.Indicadores =
                ProyectoPropositoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(proyectoPropositoCompose.Proposito.IdObjetivo, false);
            proyectoPropositoCompose.Supuestos =
                ProyectoPropositoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(proyectoPropositoCompose.Proposito.IdObjetivo);

            return proyectoPropositoCompose;
        }



        #region Actions
        public override void Add(ProyectoPropositoCompose entity, IContextUser contextUser)
        {
            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.Proposito.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.Proposito.IdObjetivo = objetivo.IdObjetivo;
            ProyectoPropositoBusiness.Current.Add(entity.Proposito.ToEntity(), contextUser);

            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Update(ProyectoPropositoCompose entity, IContextUser contextUser)
        {

            ProyectoProposito proyectoProposito = ProyectoPropositoBusiness.Current.GetById(entity.Proposito.IdProyectoProposito);
            ProyectoPropositoBusiness.Current.Set(entity.Proposito.ToEntity(), proyectoProposito);
            ProyectoPropositoBusiness.Current.Update(proyectoProposito, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(proyectoProposito.IdObjetivo);
            objetivo.Nombre = entity.Proposito.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

            //Matias 20131106 - Tarea 80
            ProyectoBusiness.Current.updateFechaUltimaModificacion(proyectoProposito.IdProyecto, contextUser);
            //FinMatias 20131106 - Tarea 80

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoPropositoCompose entity, IContextUser contextUser)
        {

            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            ProyectoPropositoBusiness.Current.Delete(entity.Proposito.IdProyectoProposito, contextUser);
            ObjetivoBusiness.Current.Delete(entity.Proposito.IdObjetivo, contextUser);
        }


        #endregion

        public override bool Equals (ProyectoPropositoCompose source, ProyectoPropositoCompose target)
        {


            if (!source.Proposito.Equals(target.Proposito.ToEntity())) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores)) return false;
            if (!EqualsObjetivoSupuesto(source.Supuestos, target.Supuestos)) return false;

            return true;
        }

    }

    public class ProyectoProductoComposeBusiness : ObjetivoComposeBusiness<ProyectoProductoCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile ProyectoProductoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoProductoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoProductoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }

        public override ProyectoProductoCompose GetById(int id)
        {

            ProyectoProductoCompose proyectoProductoCompose = new ProyectoProductoCompose();
            proyectoProductoCompose.Producto =
                ProyectoProductoBusiness.Current.GetResult(new ProyectoProductoFilter() { IdProyectoProducto = id }).FirstOrDefault();

            proyectoProductoCompose.Indicadores =
                ProyectoProductoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(proyectoProductoCompose.Producto.IdObjetivo, true);
            proyectoProductoCompose.Supuestos =
                ProyectoProductoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(proyectoProductoCompose.Producto.IdObjetivo);

            return proyectoProductoCompose;
        }


        public ProyectoProductoCompose GetByIdForCopy(int id)
        {

            ProyectoProductoCompose proyectoProductoCompose = new ProyectoProductoCompose();
            proyectoProductoCompose.Producto =
                ProyectoProductoBusiness.Current.GetResult(new ProyectoProductoFilter() { IdProyectoProducto = id }).FirstOrDefault();

            proyectoProductoCompose.Indicadores =
                ProyectoProductoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(proyectoProductoCompose.Producto.IdObjetivo, false);
            proyectoProductoCompose.Supuestos =
                ProyectoProductoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(proyectoProductoCompose.Producto.IdObjetivo);

            return proyectoProductoCompose;
        }

        #region Actions
        public override void Add(ProyectoProductoCompose entity, IContextUser contextUser)
        {

            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.Producto.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.Producto.IdObjetivo = objetivo.IdObjetivo;
            ProyectoProductoBusiness.Current.Add(entity.Producto.ToEntity(), contextUser);

            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Update(ProyectoProductoCompose entity, IContextUser contextUser)
        {

            ProyectoProducto proyectoProducto = ProyectoProductoBusiness.Current.GetById(entity.Producto.IdProyectoProducto);
            ProyectoProductoBusiness.Current.Set(entity.Producto.ToEntity(), proyectoProducto);
            ProyectoProductoBusiness.Current.Update(proyectoProducto, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(proyectoProducto.IdObjetivo);
            objetivo.Nombre = entity.Producto.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoProductoCompose entity, IContextUser contextUser)
        {
            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            ProyectoProductoBusiness.Current.Delete(entity.Producto.IdProyectoProducto, contextUser);
            ObjetivoBusiness.Current.Delete(entity.Producto.IdObjetivo, contextUser);
        }
        #endregion

        public override bool Equals(ProyectoProductoCompose source, ProyectoProductoCompose target)
        {
            if (!source.Producto.Equals(target.Producto.ToEntity())) return false;
            if ((source.Producto.Objetivo_Nombre != target.Producto.Objetivo_Nombre) && 
                (!(string.IsNullOrEmpty(source.Producto.Objetivo_Nombre) && string.IsNullOrEmpty(source.Producto.Objetivo_Nombre)))) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores)) return false;
            if (!EqualsObjetivoSupuesto(source.Supuestos, target.Supuestos)) return false;

            return true;
        }

    }

    public class ProyectoObjetivosComposeBusiness : EntityComposeBusiness<ProyectoObjetivosCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoObjetivosComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoObjetivosComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoObjetivosComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(ProyectoObjetivosCompose entity)
        {
            return entity.IdProyecto;
        }

        public override ProyectoObjetivosCompose GetById(int id)
        {
            // ProyectoObjetivosCompose

            ProyectoObjetivosCompose proyectoObjetivosCompose = new ProyectoObjetivosCompose();

            proyectoObjetivosCompose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();

            // Programas

            ProyectoResult proyectoResult = ProyectoBusiness.Current.GetResult(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();

            proyectoObjetivosCompose.Programas =
            ProgramaObjetivoBusiness.Current.GetResult(new ProgramaObjetivoFilter() { IdPrograma = proyectoResult.IdPrograma }).ToList();

            List<ProyectoFinResult> pfList = ProyectoFinBusiness.Current.GetResult(new ProyectoFinFilter() { IdProyecto = id }).ToList();



            proyectoObjetivosCompose.Programas.ForEach(c => c.TieneProyectoFin =
                pfList.Exists(e => e.IdProgramaObjetivo == c.IdProgramaObjetivo));


            // Propositos

            List<ProyectoPropositoResult> pprList =
                ProyectoPropositoBusiness.Current.GetResult(new ProyectoPropositoFilter() { IdProyecto = id }).ToList();

            foreach (ProyectoPropositoResult ppr in pprList)
            {
                proyectoObjetivosCompose.Propositos.Add(ProyectoPropositoComposeBusiness.Current.GetById(ppr.IdProyectoProposito));
            }

            // Producto

            ProyectoProductoCompose proyectoProductoCompose = new ProyectoProductoCompose();
            ProyectoProductoResult pprodr = ProyectoProductoBusiness.Current.GetResult(new ProyectoProductoFilter() { IdProyecto = id }).FirstOrDefault();

            if (pprodr != null)
            {
                proyectoProductoCompose = ProyectoProductoComposeBusiness.Current.GetById(pprodr.IdProyectoProducto);
                proyectoObjetivosCompose.Producto = proyectoProductoCompose;
                proyectoObjetivosCompose.TieneProducto = true;
            }

            /*
            else
            {

                proyectoObjetivosCompose.Producto = new ProyectoProductoCompose();
                proyectoObjetivosCompose.Producto.Producto = new ProyectoProductoResult();
                //proyectoObjetivosCompose.Producto = ProyectoProductoComposeBusiness.Current.GetNew();
            }
            */
            


            return proyectoObjetivosCompose;
        }

        public ProyectoObjetivosCompose GetByIdForCopy(int id, int newId)
        {
            // ProyectoObjetivosCompose

            ProyectoObjetivosCompose proyectoObjetivosCompose = new ProyectoObjetivosCompose();

            // Programas
            ProyectoResult proyectoResult = ProyectoBusiness.Current.GetResult(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();

            proyectoObjetivosCompose.Programas =
            ProgramaObjetivoBusiness.Current.GetResult(new ProgramaObjetivoFilter() { IdPrograma = proyectoResult.IdPrograma }).ToList();

            List<ProyectoFinResult> pfList = ProyectoFinBusiness.Current.GetResult(new ProyectoFinFilter() { IdProyecto = id }).ToList();
            

            proyectoObjetivosCompose.Programas.ForEach(c => c.TieneProyectoFin =
                pfList.Exists(e => e.IdProgramaObjetivo == c.IdProgramaObjetivo));
            
            // Propositos
            List<ProyectoPropositoResult> pprList =
                ProyectoPropositoBusiness.Current.GetResult(new ProyectoPropositoFilter() { IdProyecto = id }).ToList();

            foreach (ProyectoPropositoResult ppr in pprList)
            {
                ProyectoPropositoCompose ppc = ProyectoPropositoComposeBusiness.Current.GetById(ppr.IdProyectoProposito);
                ppc.Proposito.IdProyecto = newId;
                ppc.Indicadores.ForEach(p => p.Evoluciones.Clear());
                proyectoObjetivosCompose.Propositos.Add(ppc);
            }

            // Producto
            ProyectoProductoCompose proyectoProductoCompose = new ProyectoProductoCompose();
            ProyectoProductoResult pprodr = ProyectoProductoBusiness.Current.GetResult(new ProyectoProductoFilter() { IdProyecto = id }).FirstOrDefault();

            if (pprodr != null)
            {
                proyectoProductoCompose = ProyectoProductoComposeBusiness.Current.GetById(pprodr.IdProyectoProducto);
                proyectoProductoCompose.Indicadores.ForEach(p => p.Evoluciones.Clear());
                proyectoObjetivosCompose.Producto = proyectoProductoCompose;
                proyectoObjetivosCompose.TieneProducto = true;
                proyectoProductoCompose.Producto.IdProyecto = newId;
            }
            proyectoObjetivosCompose.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();
            return proyectoObjetivosCompose;
        }



        #region Actions
        public override void Add(ProyectoObjetivosCompose entity, IContextUser contextUser)
        {

            // Programas

            foreach (ProgramaObjetivoResult por in entity.Programas)
            {
                if (por.TieneProyectoFin)
                {
                    ProyectoFin proyectoFin = ProyectoFinBusiness.Current.GetNew();
                    proyectoFin.IdProyecto = entity.IdProyecto;
                    proyectoFin.IdProgramaObjetivo = por.IdProgramaObjetivo;
                    ProyectoFinBusiness.Current.Add(proyectoFin, contextUser);
                }
            }

            foreach (ProyectoPropositoCompose proyectoPropositoCompose in entity.Propositos)
            {
                proyectoPropositoCompose.Proposito.IdProyecto = entity.IdProyecto;
                ProyectoPropositoComposeBusiness.Current.Add(proyectoPropositoCompose, contextUser);
            }

            if (entity.Producto != null)
            ProyectoProductoComposeBusiness.Current.Add(entity.Producto, contextUser);
        }
        public override void Update(ProyectoObjetivosCompose entity, IContextUser contextUser)
        {

            List<int> actualProyectoPropositoIds = (from o in entity.Propositos where o.Proposito.IdProyectoProposito > 0 select o.Proposito.IdProyectoProposito).ToList();
            List<ProyectoProposito> oldProyectoPropositoDetail = ProyectoPropositoBusiness.Current.GetList(new ProyectoPropositoFilter() { IdProyecto = entity.IdProyecto });
            List<int> deleteProyectoPropositoIds = (from o in oldProyectoPropositoDetail where !actualProyectoPropositoIds.Contains(o.IdProyectoProposito) select o.IdProyectoProposito).ToList();

            foreach (int id in deleteProyectoPropositoIds)
            {
                ProyectoPropositoCompose ppc = ProyectoPropositoComposeBusiness.Current.GetById(id);
                ProyectoPropositoComposeBusiness.Current.Delete(ppc, contextUser);
            }


            // Programas
            List<ProyectoFinResult> pfList = ProyectoFinBusiness.Current.GetResult(new ProyectoFinFilter() { IdProyecto = entity.IdProyecto }).ToList();

            foreach (ProgramaObjetivoResult por in entity.Programas)
            {
                bool existe = pfList.Exists(e => e.IdProgramaObjetivo == por.IdProgramaObjetivo);

                if (por.TieneProyectoFin && !existe)
                {
                    ProyectoFin proyectoFin = ProyectoFinBusiness.Current.GetNew();
                    proyectoFin.IdProyecto = entity.IdProyecto;
                    proyectoFin.IdProgramaObjetivo = por.IdProgramaObjetivo;
                    ProyectoFinBusiness.Current.Add(proyectoFin, contextUser);
                }
                else if (!por.TieneProyectoFin && existe)
                {
                    ProyectoFinBusiness.Current.Delete(new ProyectoFinFilter() { IdProyecto = entity.IdProyecto, IdProgramaObjetivo = por.IdProgramaObjetivo }, contextUser);
                }
            }

            // Propositos

            foreach (ProyectoPropositoCompose poc in entity.Propositos)
            {
                if (poc.Proposito.IdProyectoProposito < 1)
                {
                    poc.Proposito.IdProyecto = entity.IdProyecto;
                    ProyectoPropositoComposeBusiness.Current.Add(poc, contextUser);
                }
                else
                {
                    ProyectoPropositoComposeBusiness.Current.Update(poc, contextUser);
                }
            }

            // Productos


            if (!string.IsNullOrEmpty(entity.Producto.Producto.Objetivo_Nombre))
            {
                if (entity.Producto.Producto.IdProyectoProducto < 1)
                {
                    entity.Producto.Producto.IdProyecto = entity.IdProyecto;
                    ProyectoProductoComposeBusiness.Current.Add(entity.Producto, contextUser);

                }
                else
                {
                    ProyectoProductoComposeBusiness.Current.Update(entity.Producto, contextUser);
                }
                entity.TieneProducto = true;
            }
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoObjetivosCompose entity, IContextUser contextUser)
        {
            foreach (ProyectoPropositoCompose proyectoPropositoCompose in entity.Propositos)
            {
                ProyectoPropositoComposeBusiness.Current.Delete(entity.Propositos, contextUser);
            }


            ProyectoProductoComposeBusiness.Current.Delete(entity.Producto, contextUser);
        }
        public virtual int CopyAndSave(int oldId, int newId, IContextUser contextUser)
        {
            ProyectoObjetivosCompose poc = GetByIdForCopy(oldId, newId);
            ProyectoObjetivosComposeBusiness.current.Add(poc, contextUser);
            return newId;
        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(ProyectoObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {

            if (entity.TieneProducto)
            {

                if (string.IsNullOrEmpty(entity.Producto.Producto.Objetivo_Nombre))
                {
                    DataHelper.Validate(false, "InvalidField", "Producto");
                }

            }
            else
            {
                if (string.IsNullOrEmpty(entity.Producto.Producto.Objetivo_Nombre) &&
                    ((entity.Producto.Supuestos.Count > 0) || (entity.Producto.Indicadores.Count > 0)))
                {
                    DataHelper.Validate(false, "InvalidField", "Producto");
                }
            }


            foreach (ProyectoPropositoCompose proyectoPropositoCompose in entity.Propositos)
            {
                ProyectoPropositoComposeBusiness.Current.Validate(proyectoPropositoCompose, actionName, contextUser, args);
            }

            ProyectoProductoComposeBusiness.Current.Validate(entity.Producto, actionName, contextUser, args);
        }

        public override bool Can(ProyectoObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(ProyectoObjetivosCompose source, ProyectoObjetivosCompose target)        
        {
            
            if (source.Programas.Count() != target.Programas.Count()) return false;

            foreach (ProgramaObjetivoResult por in source.Programas)
            {
                ProgramaObjetivoResult porTarget = target.Programas.Where(p => p.IdProgramaObjetivo
                    == por.IdProgramaObjetivo).SingleOrDefault();
                if (porTarget == null) return false;
                if (por.TieneProyectoFin != porTarget.TieneProyectoFin) return false;
            }

            if (source.Propositos.Count() != target.Propositos.Count()) return false;

            foreach (ProyectoPropositoCompose ppc in source.Propositos)
            {
                ProyectoPropositoCompose ppcTarget = target.Propositos.Where(p => p.Proposito.IdProyectoProposito
                    == ppc.Proposito.IdProyectoProposito).SingleOrDefault();
                if (ppcTarget == null) return false;

                if (!ProyectoPropositoComposeBusiness.Current.Equals(ppc, ppcTarget)) return false;
            }

            if (source.Producto != null && !string.IsNullOrEmpty(source.Producto.Producto.Objetivo_Nombre) && target.Producto == null) return false;

            if (source.Producto != null && target.Producto != null) 
            if (!ProyectoProductoComposeBusiness.Current.Equals(source.Producto, target.Producto)) return false;

            return true;
        }

    }


    // Programas (TODO MOVER a neuvo archivo)

    public class ProgramaObjetivoComposeBusiness : ObjetivoComposeBusiness<ProgramaObjetivoCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile ProgramaObjetivoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProgramaObjetivoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProgramaObjetivoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }

        public override ProgramaObjetivoCompose GetById(int id)
        {

            ProgramaObjetivoCompose ProgramaObjetivoCompose = new ProgramaObjetivoCompose();
            ProgramaObjetivoCompose.ProgramaObjetivo =
                ProgramaObjetivoBusiness.Current.GetResult(new ProgramaObjetivoFilter() { IdProgramaObjetivo = id }).FirstOrDefault();

            ProgramaObjetivoCompose.Indicadores =
                ProgramaObjetivoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(ProgramaObjetivoCompose.ProgramaObjetivo.IDObjetivo, true);
            ProgramaObjetivoCompose.Supuestos =
                ProgramaObjetivoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(ProgramaObjetivoCompose.ProgramaObjetivo.IDObjetivo);

            return ProgramaObjetivoCompose;
        }

        #region Actions
        public override void Add(ProgramaObjetivoCompose entity, IContextUser contextUser)
        {

            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.ProgramaObjetivo.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.ProgramaObjetivo.IDObjetivo = objetivo.IdObjetivo;
            ProgramaObjetivoBusiness.Current.Add(entity.ProgramaObjetivo.ToEntity(), contextUser);

            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Update(ProgramaObjetivoCompose entity, IContextUser contextUser)
        {

            ProgramaObjetivo ProgramaObjetivo = ProgramaObjetivoBusiness.Current.GetById(entity.ProgramaObjetivo.IdProgramaObjetivo);
            ProgramaObjetivoBusiness.Current.Set(entity.ProgramaObjetivo.ToEntity(), ProgramaObjetivo);
            ProgramaObjetivoBusiness.Current.Update(ProgramaObjetivo, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(ProgramaObjetivo.IDObjetivo);
            objetivo.Nombre = entity.ProgramaObjetivo.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Delete(ProgramaObjetivoCompose entity, IContextUser contextUser)
        {
            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            ProgramaObjetivoBusiness.Current.Delete(entity.ProgramaObjetivo.IdProgramaObjetivo, contextUser);
            ObjetivoBusiness.Current.Delete(entity.ProgramaObjetivo.IDObjetivo, contextUser);
        }
        #endregion


        public override bool Equals(ProgramaObjetivoCompose source, ProgramaObjetivoCompose target)
        {

            if (!source.ProgramaObjetivo.Equals(target.ProgramaObjetivo.ToEntity())) return false;
            if (source.ProgramaObjetivo.Objetivo_Nombre != target.ProgramaObjetivo.Objetivo_Nombre) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores)) return false;
            if (!EqualsObjetivoSupuesto(source.Supuestos, target.Supuestos)) return false;

            return true;
        }

    }

    public class ProgramaObjetivosComposeBusiness : EntityComposeBusiness<ProgramaObjetivosCompose, Programa, ProgramaFilter, ProgramaResult, int>
    {
        #region Singleton
        private static volatile ProgramaObjetivosComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProgramaObjetivosComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProgramaObjetivosComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(ProgramaObjetivosCompose entity)
        {
            return entity.IdPrograma;
        }

        public override ProgramaObjetivosCompose GetById(int id)
        {
            // ProgramaObjetivosCompose

            ProgramaObjetivosCompose programaObjetivosCompose = new ProgramaObjetivosCompose();

            // Programas

            programaObjetivosCompose.Programa =
                ProgramaBusiness.Current.GetResult(new ProgramaFilter() { IdPrograma = id }).FirstOrDefault();

            // Subprogramas

            programaObjetivosCompose.SubProgramas =
                SubProgramaBusiness.Current.GetResult(new SubProgramaFilter() { IdPrograma = id }).ToList();


            // Objetivos

            List<ProgramaObjetivoResult> pprList =
                ProgramaObjetivoBusiness.Current.GetResult(new ProgramaObjetivoFilter() { IdPrograma = id }).ToList();

            foreach (ProgramaObjetivoResult por in pprList)
            {
                programaObjetivosCompose.Objetivos.Add(ProgramaObjetivoComposeBusiness.Current.GetById(por.IdProgramaObjetivo));
            }


            programaObjetivosCompose.IdPrograma = id;


            return programaObjetivosCompose;
        }

        #region Actions
        public override void Add(ProgramaObjetivosCompose entity, IContextUser contextUser)
        {

            foreach (ProgramaObjetivoCompose programaObjetivoCompose in entity.Objetivos)
            {
                programaObjetivoCompose.ProgramaObjetivo.IdPrograma = entity.IdPrograma;
                ProgramaObjetivoComposeBusiness.Current.Add(programaObjetivoCompose, contextUser);
            }


        }
        public override void Update(ProgramaObjetivosCompose entity, IContextUser contextUser)
        {

            //Elimino los Objetivos

            List<int> actualProgramaObjetivoIds = (from o in entity.Objetivos
                                                   where o.ProgramaObjetivo.IdProgramaObjetivo > 0
                                                   select o.ProgramaObjetivo.IdProgramaObjetivo).ToList();

            List<ProgramaObjetivo> oldProgramaObjetivoDetail = 
                ProgramaObjetivoBusiness.Current.GetList(new ProgramaObjetivoFilter() { IdPrograma = entity.IdPrograma });
            List<int> deleteProgramaObjetivoIds = (from o in oldProgramaObjetivoDetail 
                                                   where !actualProgramaObjetivoIds.Contains(o.IdProgramaObjetivo)
                                                   select o.IdProgramaObjetivo).ToList();

            foreach (int id in deleteProgramaObjetivoIds)
            {
                ProgramaObjetivoCompose poc = ProgramaObjetivoComposeBusiness.Current.GetById(id);
                ProgramaObjetivoComposeBusiness.Current.Delete(poc, contextUser);
            }


            // Modifico o Agrego los Objetivos

            foreach (ProgramaObjetivoCompose poc in entity.Objetivos)
            {
                if (poc.ProgramaObjetivo.IdProgramaObjetivo < 1)
                {
                    poc.ProgramaObjetivo.IdPrograma = entity.IdPrograma;
                    ProgramaObjetivoComposeBusiness.Current.Add(poc, contextUser);
                }
                else
                {
                    ProgramaObjetivoComposeBusiness.Current.Update(poc, contextUser);
                }
            }


        }
        public override void Delete(ProgramaObjetivosCompose entity, IContextUser contextUser)
        {
            foreach (ProgramaObjetivoCompose programaObjetivoCompose in entity.Objetivos)
            {

                ProgramaObjetivoCompose poc = ProgramaObjetivoComposeBusiness.Current.GetById(
                    programaObjetivoCompose.ProgramaObjetivo.IdProgramaObjetivo);
                ProgramaObjetivoComposeBusiness.Current.Delete(poc, contextUser);

            }

        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<Programa, ProgramaFilter, ProgramaResult, int> EntityBusinessBase
        {
            get { return ProgramaBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(ProgramaObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {


            foreach (ProgramaObjetivoCompose programaObjetivoCompose in entity.Objetivos)
            {
                ProgramaObjetivoComposeBusiness.Current.Validate(programaObjetivoCompose, actionName, contextUser, args);
            }


        }

        public override bool Can(ProgramaObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(ProgramaObjetivosCompose source, ProgramaObjetivosCompose target)
        {

            if (source.Objetivos.Count != target.Objetivos.Count) return false;

            foreach (ProgramaObjetivoCompose ppc in source.Objetivos)
            {
                ProgramaObjetivoCompose ppcTarget = target.Objetivos.Where(p => p.ProgramaObjetivo.IdProgramaObjetivo
                    == ppc.ProgramaObjetivo.IdProgramaObjetivo).SingleOrDefault();
                if (ppcTarget == null) return false;

                if (!ProgramaObjetivoComposeBusiness.Current.Equals(ppc, ppcTarget)) return false;
            }

            return true;
        }

        


    }


    // Prestamo (TODO MOVER a neuvo archivo)

    public class PrestamoObjetivoComposeBusiness : ObjetivoComposeBusiness<PrestamoObjetivoCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile PrestamoObjetivoComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoObjetivoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoObjetivoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }

        public override PrestamoObjetivoCompose GetById(int id)
        {

            PrestamoObjetivoCompose PrestamoObjetivoCompose = new PrestamoObjetivoCompose();
            PrestamoObjetivoCompose.PrestamoObjetivo =
                PrestamoObjetivoBusiness.Current.GetResult(new PrestamoObjetivoFilter() { IdPrestamoObjetivo = id }).FirstOrDefault();

            PrestamoObjetivoCompose.Indicadores =
                PrestamoObjetivoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(PrestamoObjetivoCompose.PrestamoObjetivo.IdObjetivo, true);
            PrestamoObjetivoCompose.Supuestos =
                PrestamoObjetivoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(PrestamoObjetivoCompose.PrestamoObjetivo.IdObjetivo);

            return PrestamoObjetivoCompose;
        }
        public override PrestamoObjetivoCompose GetNew()
        {
            PrestamoObjetivoCompose poc = new PrestamoObjetivoCompose();
            poc.Indicadores = new List<ObjetivoIndicadorCompose>();
            poc.PrestamoObjetivo = new PrestamoObjetivoResult();
            poc.Supuestos = new List<ObjetivoSupuestoResult>();
            return poc;
        }

        #region Actions
        public override void Add(PrestamoObjetivoCompose entity, IContextUser contextUser)
        {

            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.PrestamoObjetivo.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.PrestamoObjetivo.IdObjetivo = objetivo.IdObjetivo;

            PrestamoObjetivo po = entity.PrestamoObjetivo.ToEntity();
            PrestamoObjetivoBusiness.Current.Add(po, contextUser);
            entity.PrestamoObjetivo.IdPrestamoObjetivo = po.IdPrestamoObjetivo ; 
            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Update(PrestamoObjetivoCompose entity, IContextUser contextUser)
        {

            PrestamoObjetivo PrestamoObjetivo = PrestamoObjetivoBusiness.Current.GetById(entity.PrestamoObjetivo.IdPrestamoObjetivo);
            PrestamoObjetivoBusiness.Current.Set(entity.PrestamoObjetivo.ToEntity(), PrestamoObjetivo);
            PrestamoObjetivoBusiness.Current.Update(PrestamoObjetivo, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(PrestamoObjetivo.IdObjetivo);
            objetivo.Nombre = entity.PrestamoObjetivo.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(PrestamoObjetivoCompose entity, IContextUser contextUser)
        {
            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            PrestamoObjetivoBusiness.Current.Delete(entity.PrestamoObjetivo.IdPrestamoObjetivo, contextUser);
            ObjetivoBusiness.Current.Delete(entity.PrestamoObjetivo.IdObjetivo, contextUser);
        }
        #endregion


        public override bool Equals(PrestamoObjetivoCompose source, PrestamoObjetivoCompose target)
        {
            if (!PrestamoObjetivoBusiness.Current.Equals(source.PrestamoObjetivo, target.PrestamoObjetivo)) return false;


            if (source.Indicadores.Count != target.Indicadores.Count) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores))return false;
            
            if (source.Supuestos.Count != target.Supuestos.Count) return false;
            foreach (ObjetivoSupuestoResult osr in source.Supuestos)
            {
                ObjetivoSupuestoResult osrTarget = target.Supuestos.Where(i => i.IdObjetivoSupuesto == osr.IdObjetivoSupuesto).SingleOrDefault();
                if (osrTarget == null) return false; 
                if (!ObjetivoSupuestoBusiness.Current.Equals(osr, osrTarget  ))
                    return false;
            }


            return true;
        }

    }

    public class PrestamoObjetivoEspecificoComposeBusiness : ObjetivoComposeBusiness<PrestamoObjetivoEspecificoCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile PrestamoObjetivoEspecificoComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoObjetivoEspecificoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoObjetivoEspecificoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }

        public override PrestamoObjetivoEspecificoCompose GetById(int id)
        {

            PrestamoObjetivoEspecificoCompose prestamoObjetivoEspecificoCompose = new PrestamoObjetivoEspecificoCompose();
            prestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico =
                PrestamoObjetivoEspecificoBusiness.Current.GetResult(new PrestamoObjetivoEspecificoFilter() { IdPrestamoObjetivoEspecifico = id }).FirstOrDefault();

            prestamoObjetivoEspecificoCompose.Indicadores =
                PrestamoObjetivoEspecificoComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(prestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico.IdObjetivo, true);
            prestamoObjetivoEspecificoCompose.Supuestos =
                PrestamoObjetivoEspecificoComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(prestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico.IdObjetivo);

            return prestamoObjetivoEspecificoCompose;
        }

        #region Actions
        public override void Add(PrestamoObjetivoEspecificoCompose entity, IContextUser contextUser)
        {

            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.PrestamoObjetivoEspecifico.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.PrestamoObjetivoEspecifico.IdObjetivo = objetivo.IdObjetivo;
            PrestamoObjetivoEspecificoBusiness.Current.Add(entity.PrestamoObjetivoEspecifico.ToEntity(), contextUser);

            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Update(PrestamoObjetivoEspecificoCompose entity, IContextUser contextUser)
        {

            PrestamoObjetivoEspecifico PrestamoObjetivoEspecifico = PrestamoObjetivoEspecificoBusiness.Current.GetById(entity.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico);
            PrestamoObjetivoEspecificoBusiness.Current.Set(entity.PrestamoObjetivoEspecifico.ToEntity(), PrestamoObjetivoEspecifico);
            PrestamoObjetivoEspecificoBusiness.Current.Update(PrestamoObjetivoEspecifico, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(PrestamoObjetivoEspecifico.IdObjetivo);
            objetivo.Nombre = entity.PrestamoObjetivoEspecifico.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

        }
        public override void Delete(PrestamoObjetivoEspecificoCompose entity, IContextUser contextUser)
        {
            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            PrestamoObjetivoEspecificoBusiness.Current.Delete(entity.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico, contextUser);
            ObjetivoBusiness.Current.Delete(entity.PrestamoObjetivoEspecifico.IdObjetivo, contextUser);
        }
        #endregion


        public override bool Equals(PrestamoObjetivoEspecificoCompose source, PrestamoObjetivoEspecificoCompose target)
        {
            if (!PrestamoObjetivoEspecificoBusiness.Current.Equals(source.PrestamoObjetivoEspecifico, target.PrestamoObjetivoEspecifico)) return false;


            if (source.Indicadores.Count != target.Indicadores.Count) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores)) return false;

            if (source.Supuestos.Count != target.Supuestos.Count) return false;
            foreach (ObjetivoSupuestoResult osr in source.Supuestos)
            {
                ObjetivoSupuestoResult osrTarget = target.Supuestos.Where(i => i.IdObjetivoSupuesto == osr.IdObjetivoSupuesto).SingleOrDefault();
                if (osrTarget == null) return false;
                if (!ObjetivoSupuestoBusiness.Current.Equals(osr, osrTarget))
                    return false;
            }


            return true;
        }

    }

    public class PrestamoObjetivosComposeBusiness : EntityComposeBusiness<PrestamoObjetivosCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoObjetivosComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoObjetivosComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoObjetivosComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(PrestamoObjetivosCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoObjetivosCompose GetNew()
        {
            PrestamoObjetivosCompose poc = new PrestamoObjetivosCompose();
            poc.Objetivo = PrestamoObjetivoComposeBusiness.Current.GetNew ();
            poc.ObjetivosEspecificos = new List<PrestamoObjetivoEspecificoCompose>();
            poc.Prestamo = new PrestamoResult();
            return poc;
        }
        public override PrestamoObjetivosCompose GetById(int id)
        {
            // PrestamoObjetivosCompose

            PrestamoObjetivosCompose PrestamoObjetivosCompose = GetNew();


            // Objetivos Especificos

            List<PrestamoObjetivoEspecificoResult> pprList =
                PrestamoObjetivoEspecificoBusiness.Current.GetResult(new PrestamoObjetivoEspecificoFilter() { IdPrestamo = id }).ToList();

            foreach (PrestamoObjetivoEspecificoResult ppr in pprList)
            {
                PrestamoObjetivosCompose.ObjetivosEspecificos.Add(PrestamoObjetivoEspecificoComposeBusiness.Current.GetById(ppr.IdPrestamoObjetivoEspecifico));
            }

            // PrestamoObjetivo

            PrestamoObjetivoCompose PrestamoObjetivoCompose = new PrestamoObjetivoCompose();
            PrestamoObjetivoResult pprodr = PrestamoObjetivoBusiness.Current.GetResult(new PrestamoObjetivoFilter() { IdPrestamo = id }).FirstOrDefault();

            if (pprodr != null)
            {
                PrestamoObjetivoCompose = PrestamoObjetivoComposeBusiness.Current.GetById(pprodr.IdPrestamoObjetivo);
                PrestamoObjetivosCompose.Objetivo = PrestamoObjetivoCompose;
                PrestamoObjetivosCompose.TieneObjetivo = true;
            }

            /*
            else
            {

                PrestamoObjetivosCompose.Producto = new PrestamoObjetivoCompose();
                PrestamoObjetivosCompose.Producto.Producto = new PrestamoObjetivoResult();
                //PrestamoObjetivosCompose.Producto = PrestamoObjetivoComposeBusiness.Current.GetNew();
            }
            */
            PrestamoObjetivosCompose.Prestamo =  PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter(){ IdPrestamo= id}).FirstOrDefault();


            return PrestamoObjetivosCompose;
        }
        #region Actions
        public override void Add(PrestamoObjetivosCompose entity, IContextUser contextUser)
        {
            foreach (PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose in entity.ObjetivosEspecificos)
            {
                PrestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico.IdPrestamo = entity.IdPrestamo;
                PrestamoObjetivoEspecificoComposeBusiness.Current.Add(PrestamoObjetivoEspecificoCompose, contextUser);
            }

            if (entity.Objetivo != null)
                PrestamoObjetivoComposeBusiness.Current.Add(entity.Objetivo, contextUser);
        }
        public override void Update(PrestamoObjetivosCompose entity, IContextUser contextUser)
        {

            List<int> actualPrestamoObjetivoEspecificoIds = (from o in entity.ObjetivosEspecificos where o.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico > 0 select o.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico).ToList();
            List<PrestamoObjetivoEspecifico> oldPrestamoObjetivoEspecificoDetail = PrestamoObjetivoEspecificoBusiness.Current.GetList(new PrestamoObjetivoEspecificoFilter() { IdPrestamo = entity.IdPrestamo });
            List<int> deletePrestamoObjetivoEspecificoIds = (from o in oldPrestamoObjetivoEspecificoDetail where !actualPrestamoObjetivoEspecificoIds.Contains(o.IdPrestamoObjetivoEspecifico) select o.IdPrestamoObjetivoEspecifico).ToList();

            foreach (int id in deletePrestamoObjetivoEspecificoIds)
            {
                PrestamoObjetivoEspecificoCompose ppc = PrestamoObjetivoEspecificoComposeBusiness.Current.GetById(id);
                PrestamoObjetivoEspecificoComposeBusiness.Current.Delete(ppc, contextUser);
            }


            // Propositos

            foreach (PrestamoObjetivoEspecificoCompose poc in entity.ObjetivosEspecificos)
            {
                if (poc.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico < 1)
                {
                    poc.PrestamoObjetivoEspecifico.IdPrestamo = entity.IdPrestamo;
                    PrestamoObjetivoEspecificoComposeBusiness.Current.Add(poc, contextUser);
                }
                else
                {
                    PrestamoObjetivoEspecificoComposeBusiness.Current.Update(poc, contextUser);
                }
            }

            // Productos


            if (!string.IsNullOrEmpty(entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre))
            {
                if (entity.Objetivo.PrestamoObjetivo.IdPrestamoObjetivo < 1)
                {
                    entity.Objetivo.PrestamoObjetivo.IdPrestamo = entity.IdPrestamo;
                    PrestamoObjetivoComposeBusiness.Current.Add(entity.Objetivo, contextUser);
                    
                }
                else
                {
                    PrestamoObjetivoComposeBusiness.Current.Update(entity.Objetivo, contextUser);
                }
                entity.TieneObjetivo = true;
            }

        }
        public override void Delete(PrestamoObjetivosCompose entity, IContextUser contextUser)
        {
            foreach (PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose in entity.ObjetivosEspecificos)
            {
                PrestamoObjetivoEspecificoComposeBusiness.Current.Delete(entity.ObjetivosEspecificos, contextUser);
            }


            PrestamoObjetivoComposeBusiness.Current.Delete(entity.Objetivo, contextUser);
        }
        public virtual int CopyAndSave(int oldId, int newId, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(PrestamoObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {

            if (entity.TieneObjetivo)
            {

                if (string.IsNullOrEmpty(entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre))
                {
                    DataHelper.Validate(false, "InvalidField", "Objetivo");
                }

            }
            else
            {
                if (string.IsNullOrEmpty(entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre) &&
                    ((entity.Objetivo.Supuestos.Count > 0) || (entity.Objetivo.Indicadores.Count > 0)))
                {
                    DataHelper.Validate(false, "InvalidField", "Objetivo");
                }
            }


            foreach (PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose in entity.ObjetivosEspecificos)
            {
                PrestamoObjetivoEspecificoComposeBusiness.Current.Validate(PrestamoObjetivoEspecificoCompose, actionName, contextUser, args);
            }

            PrestamoObjetivoComposeBusiness.Current.Validate(entity.Objetivo, actionName, contextUser, args);
        }

        public override bool Can(PrestamoObjetivosCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(PrestamoObjetivosCompose source, PrestamoObjetivosCompose target)
        {

            if (!PrestamoObjetivoComposeBusiness.Current.Equals(source.Objetivo, target.Objetivo))
                return false;

            if (source.ObjetivosEspecificos.Count() != target.ObjetivosEspecificos.Count()) return false;

            foreach (PrestamoObjetivoEspecificoCompose ppc in source.ObjetivosEspecificos)
            {
                PrestamoObjetivoEspecificoCompose ppcTarget = target.ObjetivosEspecificos.Where(p => p.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico
                    == ppc.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico).SingleOrDefault();
                if (ppcTarget == null) return false;

                if (!PrestamoObjetivoEspecificoComposeBusiness.Current.Equals(ppc, ppcTarget)) return false;
            }

            return true;
        }

    }


}
