using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
   /*
    public class ProyectoObjetivoComposeBusiness : EntityComposeBusiness<ProyectoObjetivoCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoObjetivoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoObjetivoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoObjetivoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }
        #region Gets
        public override int GetId(ProyectoObjetivoCompose entity)
        {
            return entity.IdProyecto ;
        }
        public override ProyectoObjetivoCompose GetById(int id)
        {
            ProyectoObjetivoCompose compose = new ProyectoObjetivoCompose();
            List<ProyectoPropositoResult> propositos = ProyectoPropositoBusiness.Current.GetResult(new ProyectoPropositoFilter(){ IdProyecto = id});
            List<ObjetivoSupuestoResult> supuestos = ObjetivoSupuestoBusiness.Current.GetResult( new ObjetivoSupuestoFilter(){ IdsObjetivos = (from o in propositos select o.IdObjetivo).ToList()} );
            foreach(ProyectoPropositoResult proposito in propositos)
            {
                ProyectoPropositoCompose proyectoPropositoCompose = new ProyectoPropositoCompose();
                proyectoPropositoCompose.proposito = proposito;
                proyectoPropositoCompose.Supuestos = (from o in supuestos where o.IdObjetivo == proposito.IdObjetivo select o ).ToList();
                compose.Propositos.Add(proyectoPropositoCompose);
            }
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoObjetivoCompose entity, IContextUser contextUser)
        {
            try
            {
                                
                foreach (ProyectoPropositoCompose ppc in entity.Propositos)
	            {
                    Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
                    objetivo.Nombre = ppc.proposito.Objetivo_Nombre;
                    ObjetivoBusiness.Current.Add(objetivo, contextUser);
                    ppc.proposito.IdObjetivo = objetivo.IdObjetivo;

                    ppc.proposito.IdProyecto = entity.IdProyecto;
                    ProyectoProposito proyectoProposito = ppc.proposito.ToEntity();
                    ProyectoPropositoBusiness.Current.Add(proyectoProposito, contextUser);
                    ppc.proposito.IdProyectoProposito = proyectoProposito.IdProyectoProposito;

                    foreach (ObjetivoSupuestoResult osr in ppc.Supuestos)
                    {
                        osr.IdObjetivo = ppc.proposito.IdObjetivo;
                        ObjetivoSupuesto objetivoSupuesto = osr.ToEntity();
                        ObjetivoSupuestoBusiness.Current.Add(objetivoSupuesto, contextUser);
                        osr.IdObjetivoSupuesto = objetivoSupuesto.IdObjetivoSupuesto;
                    }                                                           
	            }

            }                        
            catch (Exception exception)
            {
                foreach (ProyectoPropositoCompose ppc in entity.Propositos)
                {
                    ppc.proposito.IdProyectoProposito = 0;
                    ppc.proposito.IdObjetivo = 0;
                    foreach (ObjetivoSupuestoResult osr in ppc.Supuestos)
                    {
                        osr.IdObjetivoSupuesto = 0;
                        osr.IdObjetivo = 0;
                    }
                }
                throw exception;
            }

        }
        public override void Update(ProyectoObjetivoCompose entity, IContextUser contextUser)
        {
            
            //List<ProyectoLocalizacionResult> copy1 = ProyectoLocalizacionBusiness.Current.CopiesResult(entity.Localizaciones);
            //List<ProyectoAlcanceGeograficoResult> copy2 = ProyectoAlcanceGeograficoBusiness.Current.CopiesResult(entity.Alcances);
            //List<ProyectoGeoreferenciacionResult> copy3 = ProyectoGeoreferenciacionBusiness.Current.CopiesResult(entity.Georeferenciaciones);

            ProyectoObjetivoCompose proyectoObjetivoCompose = ProyectoObjetivoComposeBusiness.Current.GetById(entity.IdProyecto);
                        

            foreach (ProyectoPropositoCompose ppc in entity.Propositos)
            {
                if (ppc.proposito.IdProyectoProposito < 1)
                {
                    Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
                    objetivo.Nombre = ppc.proposito.Objetivo_Nombre;
                    ObjetivoBusiness.Current.Add(objetivo, contextUser);
                    ppc.proposito.IdObjetivo = objetivo.IdObjetivo;

                    ppc.proposito.IdProyecto = entity.IdProyecto;
                    ProyectoProposito proyectoProposito = ppc.proposito.ToEntity();
                    ProyectoPropositoBusiness.Current.Add(proyectoProposito, contextUser);
                    ppc.proposito.IdProyectoProposito = proyectoProposito.IdProyectoProposito;

                    foreach (ObjetivoSupuestoResult osr in ppc.Supuestos)
                    {
                        osr.IdObjetivo = ppc.proposito.IdObjetivo;
                        ObjetivoSupuesto objetivoSupuesto = osr.ToEntity();
                        ObjetivoSupuestoBusiness.Current.Add(objetivoSupuesto, contextUser);
                        osr.IdObjetivoSupuesto = objetivoSupuesto.IdObjetivoSupuesto;
                    }

                }
                else
                {
                    ProyectoPropositoBusiness.Current.Update(ppc.proposito.ToEntity(), contextUser);

               
                }

            }

            
        }
        public override void Delete(ProyectoObjetivoCompose entity, IContextUser contextUser)
        {
            foreach (ProyectoPropositoCompose ppc in entity.Propositos)
            {
                ObjetivoSupuestoBusiness.Current.Delete(new ObjetivoSupuestoFilter() { IdObjetivo = ppc.proposito.IdObjetivo}, contextUser);
                ObjetivoBusiness.Current.Delete(new ObjetivoFilter() { IdObjetivo = ppc.proposito.IdObjetivo }, contextUser);                
            }
            ProyectoPropositoBusiness.Current.Delete(new ProyectoPropositoFilter() { IdProyecto = entity.IdProyecto }, contextUser);
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(ProyectoObjetivoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            
        }

        public override bool Can(ProyectoObjetivoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }
        #endregion

    }
    
    */

}
