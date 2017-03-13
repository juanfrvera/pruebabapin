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
    public class IndicadorClaseBusiness : _IndicadorClaseBusiness
    {
        #region Singleton
        private static volatile IndicadorClaseBusiness current;
        private static object syncRoot = new Object();

        //private IndicadorClaseBusiness() {}
        public static IndicadorClaseBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new IndicadorClaseBusiness();
                    }
                }
                return current;
            }
        }
        #endregion
        public override IndicadorClase GetNew()
        {
            IndicadorClase entity = base.GetNew();
            entity.Activo = true;
            return entity;
        }
        public override void Delete(IndicadorClase entity, IContextUser contextUser)
        {
            Delete(entity.IdIndicadorClase, contextUser);
        }
        public override void Delete(int id, IContextUser contextUser)
        {
            IndicadorRelacionRubroBusiness.Current.Delete(new IndicadorRelacionRubroFilter() { IdIndicadorClase = id }, contextUser);
            base.Delete(id, contextUser);
        }
        /*German 20140129 - tarea 110*/
        public ListPaged<NodeResult> GetNodesResult(IndicadorClaseFilter filter)
        {
            return Data.GetNodesResult(filter);
        }
        /*Fin German 20140129 - tarea 110*/
    }
    public class IndicadorClaseComposeBusiness : EntityComposeBusiness<IndicadorClaseCompose, IndicadorClase, IndicadorClaseFilter, IndicadorClaseResult, int>
    {
        #region Singleton
        private static volatile IndicadorClaseComposeBusiness current;
        private static object syncRoot = new Object();

        //private IndicadorClaseBusiness() {}
        public static IndicadorClaseComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new IndicadorClaseComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<IndicadorClase, IndicadorClaseFilter, IndicadorClaseResult, int> EntityBusinessBase
        {
            get { return IndicadorClaseBusiness.Current; }
        }
        #region Gets
        public override IndicadorClaseCompose GetNew(IndicadorClaseResult example)
        {
            IndicadorClaseCompose compose = base.GetNew();
            compose.IndicadorClase = example;
            compose.Rubros = ToIndicadorRelacionRubros(IndicadorRubroBusiness.Current.GetResult(new IndicadorRubroFilter() { Activo = true }));
            return compose;
        }
        public override IndicadorClaseCompose GetNew()
        {
            IndicadorClaseResult example = new IndicadorClaseResult();
            example.Activo = true;
            IndicadorClaseBusiness.Current.Set(IndicadorClaseBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(IndicadorClaseCompose entity)
        {
            return entity.IndicadorClase.IdIndicadorClase;
        }
        public override IndicadorClaseCompose GetById(int id)
        {
            IndicadorClaseCompose compose = new IndicadorClaseCompose();
            compose.IndicadorClase = IndicadorClaseBusiness.Current.GetResult(new IndicadorClaseFilter() { IdIndicadorClase = id }).FirstOrDefault();
            //obtiene los rubros asociados y los que no estan asociados
            List<IndicadorRubroResult> rubros = IndicadorRubroBusiness.Current.GetResult(new IndicadorRubroFilter() { Activo = true });
            List<IndicadorRelacionRubroResult> indicadorClaseRubros = IndicadorRelacionRubroBusiness.Current.GetResult(new IndicadorRelacionRubroFilter() { IdIndicadorClase = id });
            indicadorClaseRubros.ForEach(p => p.Selected = true);

            List<IndicadorRelacionRubroResult> unselectedRubros = (from a in rubros
                                                                   where !(from ea in indicadorClaseRubros select ea.IdIndicadorRubro).Contains(a.IdIndicadorRubro)
                                                                   select ToIndicadorRelacionRubros(a)).ToList();
            indicadorClaseRubros.AddRange(unselectedRubros);
            compose.Rubros = indicadorClaseRubros;
            return compose;
        }
        #endregion
        #region Actions
        public override void Add(IndicadorClaseCompose entity, IContextUser contextUser)
        {
            IndicadorClase indicadorClase = entity.IndicadorClase.ToEntity();
            IndicadorClaseBusiness.Current.Add(indicadorClase, contextUser);
            entity.IndicadorClase.IdIndicadorClase = indicadorClase.IdIndicadorClase;

            foreach (IndicadorRelacionRubroResult rubro in entity.Rubros)
            {
                if (rubro.Selected && rubro.IdIndicadorRelacionRubro < 1)
                {
                    IndicadorRelacionRubro indicadorClaseRubro = IndicadorRelacionRubroBusiness.Current.GetNew();
                    indicadorClaseRubro.IdIndicadorRubro = rubro.IdIndicadorRubro;
                    indicadorClaseRubro.IdIndicadorClase = indicadorClase.IdIndicadorClase;
                    IndicadorRelacionRubroBusiness.Current.Add(indicadorClaseRubro, contextUser);
                    rubro.IdIndicadorRelacionRubro = indicadorClaseRubro.IdIndicadorRelacionRubro;
                }
            }
        }
        public override void Update(IndicadorClaseCompose entity, IContextUser contextUser)
        {
            IndicadorClase indicadorClase = IndicadorClaseBusiness.Current.GetById(entity.IndicadorClase.IdIndicadorClase);
            IndicadorClaseBusiness.Current.Set(entity.IndicadorClase, indicadorClase);
            IndicadorClaseBusiness.Current.Update(indicadorClase, contextUser);

            foreach (IndicadorRelacionRubroResult rubro in entity.Rubros)
            {
                if (rubro.Selected && rubro.IdIndicadorRelacionRubro < 1)
                {
                    IndicadorRelacionRubro indicadorClaseRubro = IndicadorRelacionRubroBusiness.Current.GetNew();
                    indicadorClaseRubro.IdIndicadorRubro = rubro.IdIndicadorRubro;
                    indicadorClaseRubro.IdIndicadorClase = indicadorClase.IdIndicadorClase;
                    IndicadorRelacionRubroBusiness.Current.Add(indicadorClaseRubro, contextUser);
                    rubro.IdIndicadorRelacionRubro = indicadorClaseRubro.IdIndicadorRelacionRubro;
                }
                if (!rubro.Selected && rubro.IdIndicadorRelacionRubro > 1)
                {
                    IndicadorRelacionRubroBusiness.Current.Delete(rubro.IdIndicadorRelacionRubro, contextUser);
                }
            }

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(IndicadorClaseCompose entity, IContextUser contextUser)
        {
            IndicadorClaseBusiness.Current.Delete(entity.IndicadorClase.IdIndicadorClase, contextUser);
        }
        #endregion

        #region protected Methods
        protected List<IndicadorRelacionRubroResult> ToIndicadorRelacionRubros(List<IndicadorRubroResult> rubros)
        {
            List<IndicadorRelacionRubroResult> target = new List<IndicadorRelacionRubroResult>(rubros.Count);
            foreach (IndicadorRubroResult rubro in rubros)
                target.Add(ToIndicadorRelacionRubros(rubro));
            return target;
        }
        protected IndicadorRelacionRubroResult ToIndicadorRelacionRubros(IndicadorRubroResult rubro)
        {
            IndicadorRelacionRubroResult target = new IndicadorRelacionRubroResult();
            target.IdIndicadorRubro = rubro.IdIndicadorRubro;
            target.IndicadorRubro_Activo = rubro.Activo;
            target.IndicadorRubro_Nombre = rubro.Nombre;
            target.Selected = false;
            return target;
        }
        protected Boolean validateRubroSelected(IndicadorClaseCompose entity)
        {
            foreach (IndicadorRelacionRubroResult rubro in entity.Rubros)
            {
                if (rubro.Selected)
                    return true;
            }
            return false;
        }
        #endregion

        #region Validations
        public override void Validate(IndicadorClaseCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            IndicadorClaseBusiness.Current.Validate(IndicadorClaseBusiness.Current.ToEntity(entity.IndicadorClase), actionName, contextUser, args);
            IndicadorClaseResult indicadorClaseResult = IndicadorClaseBusiness.Current.GetResult(new IndicadorClaseFilter() { IdIndicadorTipo = entity.IndicadorClase.IdIndicadorTipo }).FirstOrDefault();
            if (indicadorClaseResult != null)
                DataHelper.Validate((indicadorClaseResult.IndicadorTipo_SectorRequerido) ? validateRubroSelected(entity) : true, "Debe seleccionar al menos un Sector para este Tipo de Indicador");

        }

        #endregion
    }
}
