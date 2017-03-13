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
    public class ProyectoShapeFileComposeBusiness : EntityComposeBusiness<ProyectoShapeFileCompose, ProyectoShapeFile, ProyectoShapeFileFilter, ProyectoShapeFileResult, int>
    {
        #region Singleton

        private static volatile ProyectoShapeFileComposeBusiness  current;

        private static object syncRoot = new Object();

        public ProyectoShapeFileComposeBusiness()
        {
            SingletonsBusiness.COUNT_CHANGES = 0;
        }

        public static ProyectoShapeFileComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoShapeFileComposeBusiness();
                    }
                }
                return current;
            }
        }

        #endregion

        protected override EntityBusiness<ProyectoShapeFile, ProyectoShapeFileFilter, ProyectoShapeFileResult, int> EntityBusinessBase
        {
            get { return ProyectoShapeFileBusiness.Current; }
        }

        #region Gets

        public override ProyectoShapeFileCompose GetNew(ProyectoShapeFileResult example)
        {
            ProyectoShapeFileCompose compose = base.GetNew();
            compose.ProyectoShapeFile = example;

            return compose;
        }

        public override ProyectoShapeFileCompose GetNew()
        {
            ProyectoShapeFileResult example = new ProyectoShapeFileResult();
            ProyectoShapeFileBusiness.Current.Set(ProyectoShapeFileBusiness.Current.GetNew(), example);
            return GetNew(example);
        }

        public override int GetId(ProyectoShapeFileCompose entity)
        {
            return entity.ProyectoShapeFile.IdProyectoShapeFile;
        }

        public override ProyectoShapeFileCompose GetById(int id)
        {
            ProyectoShapeFileCompose compose = new ProyectoShapeFileCompose();
            compose.ProyectoShapeFile = ProyectoShapeFileBusiness.Current.GetResult(new ProyectoShapeFileFilter() { IdProyectoShapeFile = id }).FirstOrDefault();

            return compose;
        }

        #endregion

        #region Actions

        public override void Add(ProyectoShapeFileCompose entity, IContextUser contextUser)
        {
            try
            {
                ProyectoShapeFile proyectoShapeFile = entity.ProyectoShapeFile.ToEntity();
                ProyectoShapeFileBusiness.Current.Add(proyectoShapeFile, contextUser);
                entity.ProyectoShapeFile.IdProyectoShapeFile = proyectoShapeFile.IdProyectoShapeFile;

                SolutionContext.Current.AuthorizationManager.Refresh();
            }
            catch (Exception exception)
            {
                entity.ProyectoShapeFile.IdProyectoShapeFile= 0;
                throw exception;
            }
        }

        public override void Update(ProyectoShapeFileCompose entity, IContextUser contextUser)
        {
            try
            {
                ProyectoShapeFile proyectoShapeFile = ProyectoShapeFileBusiness.Current.GetById(entity.ProyectoShapeFile.ID);
                proyectoShapeFile.IdProyectoShapeFile = entity.ProyectoShapeFile.IdProyectoShapeFile;
                proyectoShapeFile.IdProyecto = entity.ProyectoShapeFile.IdProyecto;
                proyectoShapeFile.RutaArchivo = entity.ProyectoShapeFile.RutaArchivo;

                ProyectoShapeFileBusiness.Current.Update(proyectoShapeFile, contextUser);

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                SolutionContext.Current.AuthorizationManager.Refresh();
                Singletons.COUNT_CHANGES = 0;

            }

            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override void Delete(ProyectoShapeFileCompose entity, IContextUser contextUser)
        {
            ProyectoShapeFileBusiness.Current.Delete(entity.ProyectoShapeFile.IdProyectoShapeFile, contextUser);
        }

        #endregion

        #region Validations

        public override void Validate(ProyectoShapeFileCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            ProyectoShapeFileBusiness.Current.Validate(ProyectoShapeFileBusiness.Current.ToEntity(entity.ProyectoShapeFile), actionName, contextUser, args);
        }

        public override bool Can(ProyectoShapeFileCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            if (entity == null || entity.ProyectoShapeFile == null) return false;
            return ProyectoShapeFileBusiness.Current.Can(ProyectoShapeFileBusiness.Current.ToEntity(entity.ProyectoShapeFile), actionName, contextUser, args);
        }

        #endregion
    }

    public class ProyectoShapeFileBusiness : _ProyectoShapeFileBusiness
    {

        #region Singleton

        private static volatile ProyectoShapeFileBusiness current;

        private static object syncRoot = new Object();

        public static ProyectoShapeFileBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoShapeFileBusiness();
                    }
                }
                return current;
            }
        }

        #endregion

        public override ProyectoShapeFile GetNew()
        {
            ProyectoShapeFile entity = base.GetNew();
            return entity;
        }

        public override void Delete(ProyectoShapeFile entity, IContextUser contextUser)
        {
            Delete(entity.IdProyectoShapeFile, contextUser);
        }

        public override void Delete(int id, IContextUser contextUser)
        {
            ProyectoShapeFileBusiness.Current.Delete(new ProyectoShapeFileFilter() { IdProyectoShapeFile = id }, contextUser);
            base.Delete(id, contextUser);
        }

        public virtual List< ProyectoShapeFileResult> GetShapes(ProyectoShapeFileFilter filter)
        {
           List<ProyectoShapeFileResult> result = ProyectoShapeFileData.Current.QueryResultShapeFiles(filter);
            return result;
        }

    }
}
