using Business.Base;
using Contract;
using Contract.Others_Contracts;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProyectoGeoLocalizacionComposeBusiness : EntityComposeBusiness<ProyectoGeoLocalizacionCompose, ProyectoGeoLocalizacion, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int>
    {
        #region Singleton
        
        private static volatile ProyectoGeoLocalizacionComposeBusiness current;
        
        private static object syncRoot = new Object();

        public ProyectoGeoLocalizacionComposeBusiness()
        {
            SingletonsBusiness.COUNT_CHANGES = 0;
        }

        public static ProyectoGeoLocalizacionComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoLocalizacionComposeBusiness();
                    }
                }
                return current;
            }
        }
        
        #endregion

        protected override EntityBusiness<ProyectoGeoLocalizacion, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int> EntityBusinessBase
        {
            get { return ProyectoGeoLocalizacionBusiness.Current; }
        }

        #region Gets

        public override ProyectoGeoLocalizacionCompose GetNew(ProyectoGeoLocalizacionResult example)
        {
            ProyectoGeoLocalizacionCompose compose = base.GetNew();
            compose.ProyectoGeoLocalizacion = example;
           
            return compose;
        }

        public override ProyectoGeoLocalizacionCompose GetNew()
        {
            ProyectoGeoLocalizacionResult example = new ProyectoGeoLocalizacionResult();
            ProyectoGeoLocalizacionBusiness.Current.Set(ProyectoGeoLocalizacionBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
       
        public override int GetId(ProyectoGeoLocalizacionCompose entity)
        {
            return entity.ProyectoGeoLocalizacion.IdGeoLocalizacion;
        }

        public override ProyectoGeoLocalizacionCompose GetById(int id)
        {
            ProyectoGeoLocalizacionCompose compose = new ProyectoGeoLocalizacionCompose();
            compose.ProyectoGeoLocalizacion = ProyectoGeoLocalizacionBusiness.Current.GetResult(new ProyectoGeoLocalizacionFilter() { IdGeoLocalizacion = id }).FirstOrDefault();

            return compose;
        }

        #endregion

        #region Actions

        public override void Add(ProyectoGeoLocalizacionCompose entity, IContextUser contextUser)
        {         
            try
            {
                ProyectoGeoLocalizacion proyectoGeoLocalizacion = entity.ProyectoGeoLocalizacion.ToEntity();
                ProyectoGeoLocalizacionBusiness.Current.Add(proyectoGeoLocalizacion, contextUser);
                entity.ProyectoGeoLocalizacion.IdGeoLocalizacion = proyectoGeoLocalizacion.IdGeoLocalizacion;

                SolutionContext.Current.AuthorizationManager.Refresh();
            }
            catch (Exception exception)
            {
                entity.ProyectoGeoLocalizacion.IdGeoLocalizacion = 0;
                throw exception;
            }
        }

        public override void Update(ProyectoGeoLocalizacionCompose entity, IContextUser contextUser)
        {
            try
            {
                ProyectoGeoLocalizacion proyectoGeoLocalizacion = ProyectoGeoLocalizacionBusiness.Current.GetById(entity.ProyectoGeoLocalizacion.ID);
                proyectoGeoLocalizacion.IdGeoLocalizacion = entity.ProyectoGeoLocalizacion.IdGeoLocalizacion;
                proyectoGeoLocalizacion.IdProyecto = entity.ProyectoGeoLocalizacion.IdProyecto;
                proyectoGeoLocalizacion.TipoLocalizacion= entity.ProyectoGeoLocalizacion.TipoLocalizacion;
                proyectoGeoLocalizacion.InfoLocalizacion = entity.ProyectoGeoLocalizacion.InfoLocalizacion;

                ProyectoGeoLocalizacionBusiness.Current.Update(proyectoGeoLocalizacion, contextUser);
               
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                SolutionContext.Current.AuthorizationManager.Refresh();
                Singletons.COUNT_CHANGES=0;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override void Delete(ProyectoGeoLocalizacionCompose entity, IContextUser contextUser)
        {
            ProyectoGeoLocalizacionBusiness.Current.Delete(entity.ProyectoGeoLocalizacion.IdGeoLocalizacion, contextUser);
        }

        #endregion

        #region Validations

        public override void Validate(ProyectoGeoLocalizacionCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            ProyectoGeoLocalizacionBusiness.Current.Validate(ProyectoGeoLocalizacionBusiness.Current.ToEntity(entity.ProyectoGeoLocalizacion), actionName, contextUser, args);
        }

        public override bool Can(ProyectoGeoLocalizacionCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            if (entity == null || entity.ProyectoGeoLocalizacion==null) return false;
            return ProyectoGeoLocalizacionBusiness.Current.Can(ProyectoGeoLocalizacionBusiness.Current.ToEntity(entity.ProyectoGeoLocalizacion), actionName, contextUser, args);
        }

        #endregion
    }

    public class ProyectoGeoLocalizacionBusiness : _ProyectoGeoLocalizacionBusiness
    {

        #region Singleton

        private static volatile ProyectoGeoLocalizacionBusiness current;

        private static object syncRoot = new Object();

        public static ProyectoGeoLocalizacionBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoLocalizacionBusiness();
                    }
                }
                return current;
            }
        }
       
        #endregion

        public override ProyectoGeoLocalizacion GetNew()
        {
            ProyectoGeoLocalizacion entity = base.GetNew();
            return entity;
        }

        public override void Delete(ProyectoGeoLocalizacion entity, IContextUser contextUser)
        {
            Delete(entity.IdGeoLocalizacion, contextUser);
        }

        public override void Delete(int id, IContextUser contextUser)
        {
            ProyectoGeoLocalizacionBusiness.Current.Delete(new ProyectoGeoLocalizacionFilter() { IdGeoLocalizacion = id }, contextUser);
            base.Delete(id, contextUser);
        }

        public virtual ProyectoGeoLocalizacionResult GetProyectoGeoLocalizacion(ProyectoGeoLocalizacionFilter filter)
        {
            ProyectoGeoLocalizacionResult result = ProyectoGeoLocalizacionData.Current.QueryResultProyectoGeolocalizacion(filter);
            return result;
        }

        public virtual List<ProyectoGeoLocalizacionResult> GetProyectoGeoLocalizaciones(ProyectoGeoLocalizacionFilter filter)
        {
           List<ProyectoGeoLocalizacionResult> result = ProyectoGeoLocalizacionData.Current.QueryResultProyectoGeolocalizaciones(filter);
            return result;
        }

    }
}
