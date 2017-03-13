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
    public class ClasificacionGastoBusiness : _ClasificacionGastoBusiness
    {
        #region Singleton
        private static volatile ClasificacionGastoBusiness current;
        private static object syncRoot = new Object();

        //private ClasificacionGastoBusiness() {}
        public static ClasificacionGastoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ClasificacionGastoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override ClasificacionGasto GetNew()
        {
            ClasificacionGasto entity = base.GetNew();
            entity.Activo = true;
            return entity;
        }
        public List<ClasificacionGastoResult> GetClasificacionGastos(bool PorCodigo, string text)
        {
            return ClasificacionGastoData.Current.GetClasificacionGastos(PorCodigo, text);
        }
        public ListPaged<NodeResult> GetNodesResult(ClasificacionGastoFilter filter)
        {
            return Data.GetNodesResult(filter);
        }
        #region Actions
        public override void Add(ClasificacionGasto entity, IContextUser contextUser)
        {

            base.Add(entity, contextUser);
            Data.RefreshClasificacionGasto(entity.IdClasificacionGastoPadre);
        }
        public override void Update(ClasificacionGasto entity, IContextUser contextUser)
        {
            ClasificacionGasto clasificacionGasto = ClasificacionGastoBusiness.Current.GetById(entity.IdClasificacionGasto);
            if ((!entity.Activo) && clasificacionGasto.Activo)
            {
                Data.ActiveCascadaClasificacionGasto(entity.IdClasificacionGasto, false);
            }
            Set(entity, clasificacionGasto);
            base.Update(clasificacionGasto, contextUser);
            Data.RefreshClasificacionGasto(clasificacionGasto.IdClasificacionGastoPadre);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        #endregion
        #region Validations
        public override void Validate(ClasificacionGasto entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            DataHelper.Validate(entity.IdClasificacionGastoTipo != 0, "La Clasificación del Gasto Padre debe ser de un nivel superior ");
            base.Validate(entity, actionName, contextUser, args);
            if (entity.IdClasificacionGastoPadre != null)
            {
                DataHelper.Validate((entity.Activo) ? ClasificacionGastoBusiness.Current.GetList(new ClasificacionGastoFilter() { IdClasificacionGasto = entity.IdClasificacionGastoPadre }).FirstOrDefault().Activo : true, "Para activar el Objeto del Gasto Actual, el Objeto del Gasto Padre debe estar activa");
            }
        }
        #endregion
    }
}
