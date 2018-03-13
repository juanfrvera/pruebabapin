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
     
    public class ProyectoPrincipiosFormulacionComposeBusiness : EntityComposeBusiness<ProyectoPrincipiosFormulacionCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoPrincipiosFormulacionComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoPrincipiosFormulacionComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoPrincipiosFormulacionComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(ProyectoPrincipiosFormulacionCompose entity)
        {
            return entity.IdProyecto;
        }

        public override ProyectoPrincipiosFormulacionCompose GetById(int id)
        {
           
            ProyectoPrincipiosFormulacionCompose proyectoPrincipiosFormulacionCompose = new ProyectoPrincipiosFormulacionCompose();
            proyectoPrincipiosFormulacionCompose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            
            //Proyecto PrincipiosFormulacion
            proyectoPrincipiosFormulacionCompose.PrincipiosFormulacion = ProyectoPrincipiosFormulacionBusiness.Current.GetResult(new ProyectoPrincipiosFormulacionFilter() { IdProyecto = id }).FirstOrDefault();

            return proyectoPrincipiosFormulacionCompose;

        }

        public ProyectoPrincipiosFormulacionCompose GetByIdForCopy(int id, int newId)
        {

            ProyectoPrincipiosFormulacionCompose proyectoPrincipiosFormulacionCompose = new ProyectoPrincipiosFormulacionCompose();

            

            //Proyecto PrincipiosFormulacion

            proyectoPrincipiosFormulacionCompose.PrincipiosFormulacion = ProyectoPrincipiosFormulacionBusiness.Current.GetResult(new ProyectoPrincipiosFormulacionFilter() { IdProyecto = id }).FirstOrDefault();

            proyectoPrincipiosFormulacionCompose.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();
            return proyectoPrincipiosFormulacionCompose;

        }

        #region Actions
        public override void Add(ProyectoPrincipiosFormulacionCompose entity, IContextUser contextUser)
        {
            //Agrego ProyectoPrincipiosFormulacion
            entity.PrincipiosFormulacion.IdProyecto = entity.IdProyecto;
            ProyectoPrincipiosFormulacionBusiness.Current.Add(entity.PrincipiosFormulacion.ToEntity(), contextUser);
        }
        public override void Update(ProyectoPrincipiosFormulacionCompose entity, IContextUser contextUser)
        {
            // Modifico Proyecto PrincipiosFormulacion
            ProyectoPrincipiosFormulacion pe = entity.PrincipiosFormulacion.ToEntity();
            pe.IdProyecto = entity.IdProyecto;
            if (entity.PrincipiosFormulacion.IdProyectoPrincipiosFormulacion <= 0)
            {
                ProyectoPrincipiosFormulacionBusiness.Current.Add(pe, contextUser);
            }
            else
                ProyectoPrincipiosFormulacionBusiness.Current.Update(pe, contextUser);

            entity.PrincipiosFormulacion.IdProyectoPrincipiosFormulacion = pe.IdProyectoPrincipiosFormulacion;

            ProyectoBusiness.Current.updateFechaUltimaModificacion(entity.IdProyecto, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;    
        }

        public override void Delete(ProyectoPrincipiosFormulacionCompose entity, IContextUser contextUser)
        {
            ProyectoPrincipiosFormulacionBusiness.Current.Delete(entity.PrincipiosFormulacion.IdProyectoPrincipiosFormulacion, contextUser);
        }

        public virtual int CopyAndSave(int oldId, int newId, IContextUser contextUser)
        {

            ProyectoPrincipiosFormulacionCompose pec = GetByIdForCopy(oldId, newId);
            if (pec.PrincipiosFormulacion != null)
            {
                ProyectoPrincipiosFormulacionComposeBusiness.current.Add(pec, contextUser);
                return 0;
            }
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

        public override void Validate(ProyectoPrincipiosFormulacionCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
     
        }

        public override bool Can(ProyectoPrincipiosFormulacionCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(ProyectoPrincipiosFormulacionCompose source, ProyectoPrincipiosFormulacionCompose target)
        {
            if (!ProyectoPrincipiosFormulacionBusiness.Current.Equals(source.PrincipiosFormulacion, target.PrincipiosFormulacion)) return false;

            return true;
        }
    }
}
