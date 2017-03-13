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
namespace UI.Web.Prestamo
{
    public partial class PrestamoDictamenSeguimientoEdit : WebControlEdit<nc.PrestamoDictamenCompose>
    {

        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<EstadoResult>(ddlEstadoPopUpEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_SEGUIMIENTO_ESTADO, Activo = true }), "Nombre", "IdEstado", new EstadoResult() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });

            PopUpEstados.Attributes.CssStyle.Add("display", "none");
        }
        public override void SetValue()
        {
            SetPermissions();
            PrestamoDictamenSeguimientoEstadoRefresh();
        }

        public override void GetValue()
        {
        }

        public override void Clear()
        {
            UIHelper.Clear(gridPrestamoDictamenSeguimientoEstado);
        }

        #region PrestamoDictamenSeguimientoEstado
        private PrestamoDictamenEstadoResult  actualPrestamoDictamenSeguimientoEstado;
        protected PrestamoDictamenEstadoResult ActualPrestamoDictamenSeguimientoEstado
        {
            get
            {
                if (actualPrestamoDictamenSeguimientoEstado == null)
                    if (ViewState["actualPrestamoDictamenSeguimientoEstado"] != null)
                        actualPrestamoDictamenSeguimientoEstado = ViewState["actualPrestamoDictamenSeguimientoEstado"] as PrestamoDictamenEstadoResult;
                    else
                    {
                        actualPrestamoDictamenSeguimientoEstado = GetNewPrestamoDictamenSeguimientoEstado();
                        ViewState["actualPrestamoDictamenSeguimientoEstado"] = actualPrestamoDictamenSeguimientoEstado;
                    }
                return actualPrestamoDictamenSeguimientoEstado;
            }
            set
            {
                actualPrestamoDictamenSeguimientoEstado = value;
                ViewState["actualPrestamoDictamenSeguimientoEstado"] = value;
            }
        }
        PrestamoDictamenEstadoResult GetNewPrestamoDictamenSeguimientoEstado()
        {
            return new PrestamoDictamenEstadoResult();
        }
        void HidePopUpPrestamoDictamenSeguimientoEstado()
        {
            ModalPopupExtenderSeguimientoEstado.Hide();
        }
        void ShowPopUpPrestamoDictamenSeguimientoEstado()
        {
            ModalPopupExtenderSeguimientoEstado.Show();
            //upPrestamoDictamenSeguimientoEstadoPopUp.Update();
        }
        #region EventosGrillas

        protected void GridPrestamoDictamenSeguimientoEstado_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualPrestamoDictamenSeguimientoEstado = (from o in Entity.Estados
                                                       where o.IdPrestamoDictamenEstado == id
                                                       select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.READ:
                    CommandPrestamoDictamenSeguimientoEstadoRead();
                    break;
                case Command.DELETE:
                    CommandPrestamoDictamenSeguimientoEstadoDelete();
                    break;
            }

        }

        protected virtual void GridPrestamoDictamenSeguimientoEstado_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridPrestamoDictamenSeguimientoEstado.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridPrestamoDictamenSeguimientoEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridPrestamoDictamenSeguimientoEstado.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSavePrestamoDictamenSeguimientoEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btNewPrestamoDictamenSeguimientoEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelPrestamoDictamenSeguimientoEstado_Click(object sender, EventArgs e)
        {
            PrestamoDictamenSeguimientoEstadoClear();
            HidePopUpPrestamoDictamenSeguimientoEstado();
        }

        #endregion
        #region Commands
        void CommandPrestamoDictamenSeguimientoEstadoRead()
        {
            PrestamoDictamenSeguimientoEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpPrestamoDictamenSeguimientoEstado);
            upEstadosPopUp.Update();
        }
        void CommandPrestamoDictamenSeguimientoEstadoSave()
        {

        }
        void CommandPrestamoDictamenSeguimientoEstadoDelete()
        {
            Entity.Estados.Remove(ActualPrestamoDictamenSeguimientoEstado);
            PrestamoDictamenSeguimientoEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void PrestamoDictamenSeguimientoEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentario);
            ActualPrestamoDictamenSeguimientoEstado = GetNewPrestamoDictamenSeguimientoEstado();
        }
        void PrestamoDictamenSeguimientoEstadoSetValue()
        {
            UIHelper.SetValue<Estado, int>(ddlEstadoPopUpEstado, ActualPrestamoDictamenSeguimientoEstado.IdEstado, EstadoService.Current.GetById);
            UIHelper.SetValue<Usuario, int>(ddlUsuarioPopUpEstado, ActualPrestamoDictamenSeguimientoEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(diFechaPopUpEstado, ActualPrestamoDictamenSeguimientoEstado.Fecha);
            UIHelper.SetValue(txtComentario, ActualPrestamoDictamenSeguimientoEstado.Observacion);
        }
        void PrestamoDictamenSeguimientoEstadoGetValue()
        {
            ActualPrestamoDictamenSeguimientoEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualPrestamoDictamenSeguimientoEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualPrestamoDictamenSeguimientoEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
            ActualPrestamoDictamenSeguimientoEstado.Usuario_NombreUsuario = UIHelper.GetString(ddlUsuarioPopUpEstado);
            ActualPrestamoDictamenSeguimientoEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualPrestamoDictamenSeguimientoEstado.Observacion = UIHelper.GetString(txtComentario);
        }
        void PrestamoDictamenSeguimientoEstadoRefresh()
        {
            UIHelper.Load(gridPrestamoDictamenSeguimientoEstado, Entity.Estados, "Fecha", SortDirection.Ascending  );
        }
        #endregion

        #endregion
        protected bool EnablePrestamoDictamenEstadoDelete { get; set; }
        protected void SetPermissions()
        {
            EnablePrestamoDictamenEstadoDelete = CanByUser(SistemaEntidadConfig.PRESTAMO_DICTAMEN_ESTADO, ActionConfig.DELETE);
           
        }

    }
}