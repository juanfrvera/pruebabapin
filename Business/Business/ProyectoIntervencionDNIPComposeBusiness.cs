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
    public class ProyectoIntervencionDNIPComposeBusiness : EntityComposeBusiness<ProyectoIntervencionDNIPCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoIntervencionDNIPComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoIntervencionDNIPComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoIntervencionDNIPComposeBusiness();
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

        protected override IEntityData<ProyectoIntervencionDNIPCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }
        public override bool Equals(ProyectoIntervencionDNIPCompose source, ProyectoIntervencionDNIPCompose target)
        {
            return true;
        }

        #region Gets
        public override ProyectoIntervencionDNIPCompose GetNew(ProyectoResult example)
        {
            return GetNew();
        }

        public override ProyectoIntervencionDNIPCompose GetNew()
        {
            return new ProyectoIntervencionDNIPCompose(); 
        }
        public override int GetId(ProyectoIntervencionDNIPCompose entity)
        {
            return entity.IdProyecto; 
        }
        public override ProyectoIntervencionDNIPCompose GetById(int id)
        {            
            ProyectoIntervencionDNIPCompose compose = new ProyectoIntervencionDNIPCompose();
            //compose.proyectoDictamen = DictamenComposeBusiness.Current.GetList( id);
            List<int> estados = new List<int>();
            estados.Add((int)EstadoEnum.Terminado);
            estados.Add((int)EstadoEnum.en_Espera_de_Respuesta);
            estados.Add((int)EstadoEnum.Migracion); /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
            
            compose.proyectoDictamen = ProyectoDictamenBusiness.Current.GetResult(new ProyectoDictamenFilter() { IdProyecto = id, IdsEstado = estados });
            compose.proyectoPrioridad = ProyectoPrioridadBusiness.Current.GetResult(new ProyectoPrioridadFilter() { IdProyecto = id });
            compose.proyectoComentarioTecnico = ProyectoComentarioTecnicoBusiness.Current.GetResult (new ProyectoComentarioTecnicoFilter() { IdProyecto = id });
            compose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoIntervencionDNIPCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override void Update(ProyectoIntervencionDNIPCompose entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoIntervencionDNIPCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(ProyectoIntervencionDNIPCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            throw new NotImplementedException();
        }

        public override bool Can(ProyectoIntervencionDNIPCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion
    }
}
