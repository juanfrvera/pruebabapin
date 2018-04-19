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
    public class ProyectoEtapaBusiness : _ProyectoEtapaBusiness
    {
        #region Singleton
        private static volatile ProyectoEtapaBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoEtapaBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        #region Actions
        // Metodos
        public List<ProyectoEtapaResult> GetEtapas(ProyectoEtapaFilter filter)
        {
            return ProyectoEtapaData.Current.GetEtapas(filter);
        }
        public override void Validate(ProyectoEtapa entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser,args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdProyectoEtapa != default(int), "InvalidField", "ProyectoEtapa");
                        DataHelper.Validate(entity.IdEtapa != default(int), "InvalidField", "Etapa");
                        DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");

                        if (entity.FechaInicioEstimada != null && entity.FechaFinEstimada != null)
                            DataHelper.Validate(entity.FechaInicioEstimada <= entity.FechaFinEstimada, "InvalidField", "FechaEstimada");
                        if (entity.FechaInicioRealizada != null && entity.FechaFinRealizada != null)
                            DataHelper.Validate(entity.FechaInicioRealizada <= entity.FechaFinRealizada, "InvalidField", "FechaRealizada");

                    }
                    DataHelper.Validate(entity.Nombre != null, "FiledIsNull", "Nombre");
                    DataHelper.Validate(entity.Nombre.Trim().Length <= 500, "FiledInvalidLength", "Nombre");
                    DataHelper.Validate(entity.IdEtapa != default(int), "InvalidField", "Etapa");
                    DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdProyectoEtapa != default(int), "InvalidField", "ProyectoEtapa");

                    break;
            }
        }
        public override void Delete(List<ProyectoEtapa> entities, IContextUser contextUser)
        {
            foreach (ProyectoEtapa entity in entities)
            {                
                List<ProyectoEtapaEstimado> deletes = ProyectoEtapaEstimadoBusiness.Current.GetList(new ProyectoEtapaEstimadoFilter() { IdProyectoEtapa = entity.IdProyectoEtapa });
                foreach (ProyectoEtapaEstimado e in deletes)
                {
                    List<ProyectoEtapaEstimadoPeriodo> delps = ProyectoEtapaEstimadoPeriodoBusiness.Current.GetList(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyectoEtapaEstimado = e.IdProyectoEtapaEstimado });
                    ProyectoEtapaEstimadoPeriodoBusiness.Current.Delete(delps, contextUser);
                }
                ProyectoEtapaEstimadoBusiness.Current.Delete(deletes, contextUser);

                List<ProyectoEtapaInformacionPresupuestaria> deleteInfos = ProyectoEtapaInformacionPresupuestariaBusiness.Current.GetList(new ProyectoEtapaInformacionPresupuestariaFilter() { IdProyectoEtapa = entity.IdProyectoEtapa });
                foreach (ProyectoEtapaInformacionPresupuestaria e in deleteInfos)
                {
                    List<ProyectoEtapaInformacionPresupuestariaPeriodo> delpInfos = ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.GetList(new ProyectoEtapaInformacionPresupuestariaPeriodoFilter() { IdProyectoEtapaInformacionPresupuestaria = e.IdProyectoEtapaInformacionPresupuestaria });
                    ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Delete(delpInfos, contextUser);
                }
                ProyectoEtapaInformacionPresupuestariaBusiness.Current.Delete(deleteInfos, contextUser);

                this.Delete(entity, contextUser);
            }
        }


        public List<ProyectoEtapaResult> ProyectoEtapaConTotales(ProyectoEtapaFilter filter)
        {
            return ProyectoEtapaData.Current.ProyectoEtapaConTotales(filter); 
        }

        public override void Update(ProyectoEtapa entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }

}
