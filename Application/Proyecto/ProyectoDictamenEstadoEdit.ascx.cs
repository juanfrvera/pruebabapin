using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using nc = Contract;
using Contract;
using Service;
namespace UI.Web
{
    public partial class ProyectoDictamenEstadoEdit : WebControlEdit<nc.DictamenCompose>
    {

        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<EstadoResult>(ddlEstadoPopUpEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_DICTAMEN, Activo = true }), "Nombre", "IdEstado", new EstadoResult() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            PopUpEstados.Attributes.CssStyle.Add("display", "none");
            SetPermissions();
        }
        public override void SetValue()
        {
            ProyectoDictamenEstadoRefresh();
        }

        public override void GetValue()
        {
        }

        public override void Clear()
        {
            UIHelper.Clear(gridProyectoDictamenEstado);
        }

        #region ProyectoDictamenEstado
        private ProyectoDictamenEstadoResult actualProyectoDictamenEstado;
        protected ProyectoDictamenEstadoResult ActualProyectoDictamenEstado
        {
            get
            {
                if (actualProyectoDictamenEstado == null)
                    if (ViewState["actualProyectoDictamenEstado"] != null)
                        actualProyectoDictamenEstado = ViewState["actualProyectoDictamenEstado"] as ProyectoDictamenEstadoResult;
                    else
                    {
                        actualProyectoDictamenEstado = GetNewProyectoDictamenEstado();
                        ViewState["actualProyectoDictamenEstado"] = actualProyectoDictamenEstado;
                    }
                return actualProyectoDictamenEstado;
            }
            set
            {
                actualProyectoDictamenEstado = value;
                ViewState["actualProyectoDictamenEstado"] = value;
            }
        }
        ProyectoDictamenEstadoResult GetNewProyectoDictamenEstado()
        {
            return new ProyectoDictamenEstadoResult();
        }
        void HidePopUpProyectoDictamenEstado()
        {
            ModalPopupExtenderDictamenEstado.Hide();
        }
        void ShowPopUpProyectoDictamenEstado()
        {
            ModalPopupExtenderDictamenEstado.Show();
            //upProyectoDictamenEstadoPopUp.Update();
        }
        #region EventosGrillas

        protected void GridProyectoDictamenEstado_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoDictamenEstado = (from o in Entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.READ:
                    CommandProyectoDictamenEstadoRead();
                    break;
                case Command.DELETE:
                    CommandProyectoDictamenEstadoDelete();
                    break;
            }

        }

        protected virtual void GridProyectoDictamenEstado_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoDictamenEstado.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoDictamenEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoDictamenEstado.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoDictamenEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btNewProyectoDictamenEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelProyectoDictamenEstado_Click(object sender, EventArgs e)
        {
            ProyectoDictamenEstadoClear();
            HidePopUpProyectoDictamenEstado();
        }

        #endregion
        #region Commands
        void CommandProyectoDictamenEstadoRead()
        {
            ProyectoDictamenEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoDictamenEstado);
            upEstadosPopUp.Update();
        }

        void CommandProyectoDictamenEstadoSave()
        {

        }
        void CommandProyectoDictamenEstadoDelete()
        {
            Entity.ProyectoDictamenEstado.Remove(ActualProyectoDictamenEstado);
            ProyectoDictamenEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoDictamenEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentario);
            ActualProyectoDictamenEstado = GetNewProyectoDictamenEstado();
        }
        void ProyectoDictamenEstadoSetValue()
        {
            UIHelper.SetValue<Estado, int>(ddlEstadoPopUpEstado, ActualProyectoDictamenEstado.IdEstado, EstadoService.Current.GetById);
            UIHelper.SetValue<Usuario, int>(ddlUsuarioPopUpEstado, ActualProyectoDictamenEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(diFechaPopUpEstado, ActualProyectoDictamenEstado.Fecha);
            UIHelper.SetValue(txtComentario, ActualProyectoDictamenEstado.Observacion);
        }
        void ProyectoDictamenEstadoGetValue()
        {
            ActualProyectoDictamenEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualProyectoDictamenEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualProyectoDictamenEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
            ActualProyectoDictamenEstado.Usuario_NombreUsuario = UIHelper.GetString(ddlUsuarioPopUpEstado);
            ActualProyectoDictamenEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualProyectoDictamenEstado.Observacion = UIHelper.GetString(txtComentario);
        }
        void ProyectoDictamenEstadoRefresh()
        {
            //Entity.ProyectoDictamenEstado = Entity.ProyectoDictamenEstado.OrderBy(i => i.Fecha).ToList();
            UIHelper.Load(gridProyectoDictamenEstado, Entity.ProyectoDictamenEstado, "Fecha", SortDirection.Descending);
        }
        #endregion




        #endregion

        protected bool EnableProyectoDictamenEstadoDelete { get; set; }
        protected void SetPermissions()
        {
            EnableProyectoDictamenEstadoDelete = CanByUser(SistemaEntidadConfig.PROYECTO_DICTAMEN, ActionConfig.DELETE);
        }

    }
}