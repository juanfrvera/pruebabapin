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
    public class PrestamoProductoBusiness : _PrestamoProductoBusiness
    {
        #region Singleton
        private static volatile PrestamoProductoBusiness current;
        private static object syncRoot = new Object();

        //private PrestamoProductoBusiness() {}
        public static PrestamoProductoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoProductoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        internal List<PrestamoProducto> GetByPrestamoId(int id)
        {
            return PrestamoProductoData.Current.GetByPrestamoId(id);
        }

        internal List<PrestamoProductoResult> GetResultByPrestamoId(int id)
        {
            return PrestamoProductoData.Current.GetResultByPrestamoId(id);
        }
    }

    public class PrestamoProductosComposeBusiness : EntityComposeBusiness<PrestamoProductosCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoProductosComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoProductosComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoProductosComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }

        protected override IEntityData<PrestamoProductosCompose, PrestamoFilter, PrestamoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoProductosCompose GetNew(PrestamoResult example)
        {
            PrestamoProductosCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Productos = new List<PrestamoProductoResult>();
            return compose;
        }
        public override PrestamoProductosCompose GetNew()
        {
            PrestamoProductosCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Productos = new List<PrestamoProductoResult>();
            return compose;
        }
        public override int GetId(PrestamoProductosCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoProductosCompose GetById(int id)
        {
            PrestamoProductosCompose compose = new PrestamoProductosCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter() { IdPrestamo = id }).FirstOrDefault();
            compose.Productos = PrestamoProductoBusiness.Current.GetResultByPrestamoId(id);
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoProductosCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (PrestamoProductoResult ppr in entity.Productos)
                {
                    PrestamoProducto pp = ppr.ToEntity();
                    PrestamoProductoBusiness.Current.Add(pp, contextUser);
                    ppr.IdPrestamoProducto = pp.IdPrestamoProducto;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(PrestamoProductosCompose entity, IContextUser contextUser)
        {
            #region Productos

            List<int> actualIdsProd = (from o in entity.Productos where o.IdPrestamoProducto > 0 select o.IdPrestamoProducto).ToList();
            List<PrestamoProducto> oldDetailProd = PrestamoProductoBusiness.Current.GetByPrestamoId(entity.IdPrestamo);
            List<PrestamoProducto> deletesProd = (from o in oldDetailProd where !actualIdsProd.Contains(o.IdPrestamoProducto) select o).ToList();
            PrestamoProductoBusiness.Current.Delete(deletesProd, contextUser);

            List<ProyectoOrigenFinanciamiento> deletesOrigFinanc = new List<ProyectoOrigenFinanciamiento>();

            foreach (PrestamoProducto prestamoproducto in deletesProd)
            {
                if (prestamoproducto.IdProyecto != 0)
                {

                    // busco el prestamo compponente para luego obtener el id del prestamo
                    PrestamoComponente presComponente = PrestamoComponenteBusiness.Current.GetById(prestamoproducto.IdPrestamoComponente);

                    //creo un filtro para origen de financiamiento asi elimino los registros
                    ProyectoOrigenFinanciamientoFilter filtroOrigenFinanciamiento = new ProyectoOrigenFinanciamientoFilter();
                    filtroOrigenFinanciamiento.IdPrestamo = presComponente.IdPrestamo;
                    filtroOrigenFinanciamiento.IdProyecto = prestamoproducto.IdProyecto;
                    filtroOrigenFinanciamiento.IdProyectoOrigenFinanciamiento = prestamoproducto.IdProyectoOrigenFinanciamiento;

                    ProyectoOrigenFinanciamiento origFinanc = ProyectoOrigenFinanciamientoBusiness.Current.GetList(filtroOrigenFinanciamiento).FirstOrDefault();

                    deletesOrigFinanc.Add(origFinanc);
                }
            }

            foreach (PrestamoProductoResult ppr in entity.Productos)
            {
                PrestamoProducto pp = ppr.ToEntity();

                if (ppr.IdPrestamoProducto <= 0)
                {
                    //Nuevo relacion Prestamo-Producto

                    pp.IdPrestamoProducto = 0;
                    pp.IdProyectoOrigenFinanciamiento = 0;
                    PrestamoProductoBusiness.Current.Add(pp, contextUser);

                    // Agrego el origen de financiamiento para que aparezca el registro en la pagina de inversion--> Origen financiamiento
                    ProyectoOrigenFinanciamiento pof = new ProyectoOrigenFinanciamientoResult().ToEntity();
                    if (pp.IdProyecto != null)
                    {
                        pof.IdProyecto = pp.IdProyecto.Value;
                        pof.IdProyectoOrigenFinancianmientoTipo = 1;
                        pof.IdPrestamo = pp.PrestamoComponente.IdPrestamo;

                        //Matias 20170214 - Valida primero que este o no el registro ProyectoPrestamo en Proyecto.Origen del Financiamiento
                        ProyectoOrigenFinanciamientoFilter filtro = new ProyectoOrigenFinanciamientoFilter();
                        filtro.IdProyecto = pof.IdProyecto;
                        filtro.IdPrestamo = pof.IdPrestamo;
                        ProyectoOrigenFinanciamiento pofExistente = ProyectoOrigenFinanciamientoBusiness.Current.GetList(filtro).FirstOrDefault();
                        if (pofExistente == null)
                        //FinMatias 20170214
                        {
                            ProyectoOrigenFinanciamientoBusiness.Current.Add(pof, contextUser);
                        }
                    }

                    if (pof.IdProyectoOrigenFinanciamiento > 0)
                    {
                        pp.IdProyectoOrigenFinanciamiento = pof.IdProyectoOrigenFinanciamiento;
                        PrestamoProductoBusiness.Current.Update(pp, contextUser);
                    }

                }
                else
                {
                    //Edición de relacion Prestamo-Producto

                    int idProyectoOrigenFinanciamiento = 0;
                    // Primero busco el componente para obtener el id de prestamo
                    if (pp.IdProyecto != null)
                    {
                        //Proyecto ingresado en la relacion Prestamo-Proyecto (PP)
                        PrestamoComponente presComp = PrestamoComponenteBusiness.Current.GetById(ppr.IdPrestamoComponente);

                        ProyectoOrigenFinanciamientoFilter filtro = new ProyectoOrigenFinanciamientoFilter();
                        filtro.IdPrestamo = presComp.IdPrestamo;
                        filtro.IdProyecto = pp.IdProyecto.Value;
                        ProyectoOrigenFinanciamiento pofOld = ProyectoOrigenFinanciamientoBusiness.Current.GetList(filtro).FirstOrDefault();

                        if (pofOld != null)
                        {
                            //Edicion del mismo Proyecto en la relacion PP
                            ProyectoOrigenFinanciamientoBusiness.Current.Update(pofOld, contextUser);
                            idProyectoOrigenFinanciamiento = pofOld.IdProyectoOrigenFinanciamiento;
                        }
                        else
                        {
                            //Nuevo Proyecto en la relacion PP
                            ProyectoOrigenFinanciamiento pof = new ProyectoOrigenFinanciamientoResult().ToEntity();
                            pof.IdProyecto = pp.IdProyecto.Value;
                            pof.IdProyectoOrigenFinancianmientoTipo = 1;
                            pof.IdPrestamo = presComp.IdPrestamo;
                            ProyectoOrigenFinanciamientoBusiness.Current.Add(pof, contextUser);
                            if (pof.IdProyectoOrigenFinanciamiento > 0)
                                idProyectoOrigenFinanciamiento = pof.IdProyectoOrigenFinanciamiento;

                            //Matias 20170208 - Ticket #ER967470
                            //Ahora tendria que eliminar SI EXISTE DE ANTES la asociacion del Origen del Financiamiento del Proyecto anterior.
                            foreach (PrestamoProducto prepro in presComp.PrestamoProductos)
                            {
                                if (prepro.IdProyecto != null)
                                {
                                    //El PP tenia asociado, previamente, un Proyecto.
                                    if ((prepro.IdPrestamoProducto == pp.IdPrestamoProducto) && (prepro.IdProyecto.Value != pp.IdProyecto.Value))
                                    {
                                        //Elimino la relacion del Proyecto en Orig del Finan con el Prestamo actual
                                        List<ProyectoOrigenFinanciamiento> deletesOrigFinancEditados = new List<ProyectoOrigenFinanciamiento>();

                                        //creo un filtro para origen de financiamiento asi elimino los registros
                                        ProyectoOrigenFinanciamientoFilter filtroOrigenFinanciamiento = new ProyectoOrigenFinanciamientoFilter();
                                        filtroOrigenFinanciamiento.IdPrestamo = presComp.IdPrestamo;
                                        filtroOrigenFinanciamiento.IdProyecto = prepro.IdProyecto.Value;
                                        //filtroOrigenFinanciamiento.IdProyectoOrigenFinanciamiento = prestamoproducto.IdProyectoOrigenFinanciamiento;

                                        ProyectoOrigenFinanciamiento origFinanc = ProyectoOrigenFinanciamientoBusiness.Current.GetList(filtroOrigenFinanciamiento).FirstOrDefault();

                                        deletesOrigFinancEditados.Add(origFinanc);

                                        ProyectoOrigenFinanciamientoBusiness.Current.Delete(deletesOrigFinancEditados, contextUser);
                                    }
                                }
                            }
                            //FinMatias 20170208 - Ticket #ER967470
                        }
                    }
                    //Matias 20170208 - Ticket #ER967470                        
                    else
                    {
                        //No hay Proyecto asignado en la relacion PP (es relacion sin proyecto (no tiene mucho sentido pero existe!)

                        //Ahora tendria que eliminar, en caso de existir, la asociacion del Origen del Financiamiento del Proyecto anterior.
                        PrestamoComponente presComp = PrestamoComponenteBusiness.Current.GetById(ppr.IdPrestamoComponente);
                        foreach (PrestamoProducto prepro in presComp.PrestamoProductos)
                        {
                            //if (prepro.IdProyecto != null && pp.IdProyecto != null && prepro.IdPrestamoProducto == pp.IdPrestamoProducto && prepro.IdProyecto.Value != pp.IdProyecto.Value)
                            if (prepro.IdProyecto != null && prepro.IdPrestamoProducto == pp.IdPrestamoProducto)
                            {
                                //Elimino la relacion del Proyecto en Orig del Finan con el Prestamo actual
                                List<ProyectoOrigenFinanciamiento> deletesOrigFinancEditados = new List<ProyectoOrigenFinanciamiento>();

                                //Creo un filtro para origen de financiamiento para buscar y eliminar los registros asociados
                                ProyectoOrigenFinanciamientoFilter filtroOrigenFinanciamiento = new ProyectoOrigenFinanciamientoFilter();
                                filtroOrigenFinanciamiento.IdPrestamo = presComp.IdPrestamo;
                                filtroOrigenFinanciamiento.IdProyecto = prepro.IdProyecto.Value;
                                //filtroOrigenFinanciamiento.IdProyectoOrigenFinanciamiento = prestamoproducto.IdProyectoOrigenFinanciamiento;

                                ProyectoOrigenFinanciamiento origFinanc = ProyectoOrigenFinanciamientoBusiness.Current.GetList(filtroOrigenFinanciamiento).FirstOrDefault();

                                deletesOrigFinancEditados.Add(origFinanc);

                                ProyectoOrigenFinanciamientoBusiness.Current.Delete(deletesOrigFinancEditados, contextUser);
                            }
                        }                        
                    }
                    //FinMatias 20170208 - Ticket #ER967470

                    pp.IdProyectoOrigenFinanciamiento = idProyectoOrigenFinanciamiento;
                    PrestamoProductoBusiness.Current.Update(pp, contextUser);

                }
                ppr.IdPrestamoProducto = pp.IdPrestamoProducto;
            }

            // Elimino todos los proyectoOrigenFinanciamiento que quedaron pendientes y envio mensaje si es necesario
            if (deletesOrigFinanc.Count > 0)
            {
                ProyectoOrigenFinanciamientoBusiness.Current.Delete(deletesOrigFinanc, contextUser);

                // En base a los ids anteriores, busco en la tabla prestamoproducto a ver si existe algun proyecto con estos ids
                foreach (ProyectoOrigenFinanciamiento proyOrig in deletesOrigFinanc)
                {
                    PrestamoProductoResult prestamoproducto = PrestamoProductoBusiness.Current.GetResult(new PrestamoProductoFilter() { IdPrestamo = proyOrig.IdPrestamo, IdProyecto = proyOrig.IdProyecto, IdProyectoOrigenFinanciamiento = proyOrig.IdProyectoOrigenFinanciamiento }).FirstOrDefault();


                    // si no existe ENVIO MENSAJE sino NO
                    if (prestamoproducto == null)
                        this.createMessageSend(proyOrig, contextUser);
                }


            }

            #endregion Productos

        }

        private void createMessageSend(ProyectoOrigenFinanciamiento deleteOrigFinanc, IContextUser contextUser)
        {
            // Primero busco el bapin relacionado al prestamo
            Contract.Proyecto proyecto = ProyectoBusiness.Current.GetById(deleteOrigFinanc.IdProyecto);

            // busco el usuario SISTEMA BAPIN para asignarlo al mensaje que voy a enviar
            UsuarioFilter filtroUsuario = new UsuarioFilter();
            filtroUsuario.NombreUsuario = "BAPIN";
            filtroUsuario.Clave = "BAPIN";

            UsuarioResult usuarioResult = UsuarioBusiness.Current.GetResult(filtroUsuario).FirstOrDefault();

            if (usuarioResult != null)
            {

                // creo el objeto Message
                Message message = new Message();
                message.IdMediaFrom = 1;
                message.IdPriority = 3;
                message.IdUserFrom = usuarioResult.IdUsuario; ;
                message.IsManual = false;
                //message.Subject = "Desvinculación con préstamo N° " + deleteOrigFinanc.Prestamo.Numero; //Matias
                message.Subject = "Desvinculación del Proyecto N° " + proyecto.NroProyecto + " con el Préstamo N° " + deleteOrigFinanc.Prestamo.Numero;
                message.IdProyecto = proyecto.IdProyecto;
                message.StartDate = DateTime.Now;
                message.SendDate = DateTime.Now;
                //message.Body = "El sistema BAPIN informa que en el día de la fecha se ha desvinculado el BAPIN del Préstamo." + //Matias
                message.Body = "El sistema BAPIN informa que en el día de la fecha se ha desvinculado el Préstamo del Proyecto en referencia." +
                    " La desvinculación ha sido gestionada por el usuario: " + contextUser.User.ApellidoYNombre;

                MessageBusiness.Current.Add(message, contextUser);
                int idMensaje = message.IdMessage;

                if (idMensaje > 0)
                {

                    // creo el objeto para enviar el mensaje
                    MessageSend messageSend = new MessageSend();
                    messageSend.IdMediaTo = 1;
                    messageSend.IdMessage = idMensaje;
                    messageSend.IdUserTo = proyecto.IdUsuarioModificacion;
                    messageSend.IsRead = false;

                    // Envio el mensaje
                    MessageSendBusiness.Current.Add(messageSend, contextUser);
                }
            }


        }
        public override void Delete(PrestamoProductosCompose entity, IContextUser contextUser)
        {
            List<int> actualIds = (from o in entity.Productos where o.IdPrestamoProducto > 0 select o.IdPrestamoProducto).ToList();
            PrestamoProductoBusiness.Current.Delete(actualIds.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(PrestamoProductosCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            foreach (PrestamoProductoResult ppr in entity.Productos)
            {
                //Matias 20140429 - Tarea 142
                //DataHelper.Validate((bool)ppr.Ejecucion || (bool)ppr.InicioGestion || (bool)ppr.NegociarAutorizacion, "InvalidChecksPrestamoProducto");
                //FinMatias 20140429 - Tarea 142
                DataHelper.Validate(ppr.IdPrestamoComponente != 0 && ppr.IdPrestamoComponente != default(int), "FieldIsNull", "Componente");
                //DataHelper.Validate(entity.Prestamo.MontoTotal <= ppr.MontoPrestamo, "FieldIsNull", "Componente");

            }

        }

        public override bool Can(PrestamoProductosCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return true;
        }

        public override bool Equals(PrestamoProductosCompose source, PrestamoProductosCompose target)
        {
            bool eq = source.IdPrestamo == target.IdPrestamo;

            if (source.Productos.Count() != target.Productos.Count()) return false;

            foreach (PrestamoProductoResult s in source.Productos)
            {
                PrestamoProductoResult t = target.Productos.Where(a => a.IdPrestamoProducto == s.IdPrestamoProducto).SingleOrDefault();
                eq = eq && t != null &&
                     t.IdPrestamoComponente == s.IdPrestamoComponente &&
                     t.IdPrestamoProducto == s.IdPrestamoProducto &&
                     t.IdPrestamoSubComponente == s.IdPrestamoSubComponente &&
                     t.IdProyecto == s.IdProyecto &&
                     t.Descripcion == s.Descripcion &&
                     t.MontoContraparte == s.MontoContraparte &&
                     t.MontoPrestamo == s.MontoPrestamo &&
                     t.NegociarAutorizacion == s.NegociarAutorizacion &&
                     t.InicioGestion == s.InicioGestion &&
                     t.Ejecucion == s.Ejecucion;
            }

            return eq;
        }

        #endregion
    }
}
