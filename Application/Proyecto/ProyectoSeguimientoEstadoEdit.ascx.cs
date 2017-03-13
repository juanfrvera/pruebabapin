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
namespace UI.Web.Proyecto
{
    public partial class ProyectoSeguimientoEstadoEdit : WebControlEdit<nc.ProyectoSeguimientoCompose >
    {

        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<EstadoResult>(ddlEstadoPopUpEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_SEGUIMIENTO_ESTADO,Activo=true }), "Nombre", "IdEstado", new EstadoResult() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true ,EsSectioralista =true}), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            PopUpEstados.Attributes.CssStyle.Add("display", "none");
            SetPermissions();
        }
        public override void SetValue()
        {
            ProyectoSeguimientoEstadoRefresh();
        }

        public override void GetValue()
        {
        }

        public override void Clear()
        {
            UIHelper.Clear(gridProyectoSeguimientoEstado);
        }

        #region ProyectoSeguimientoEstado
        private ProyectoSeguimientoEstadoResult actualProyectoSeguimientoEstado;
        protected ProyectoSeguimientoEstadoResult ActualProyectoSeguimientoEstado
        {
            get
            {
                if (actualProyectoSeguimientoEstado == null)
                    if (ViewState["actualProyectoSeguimientoEstado"] != null)
                        actualProyectoSeguimientoEstado = ViewState["actualProyectoSeguimientoEstado"] as ProyectoSeguimientoEstadoResult;
                    else
                    {
                        actualProyectoSeguimientoEstado = GetNewProyectoSeguimientoEstado();
                        ViewState["actualProyectoSeguimientoEstado"] = actualProyectoSeguimientoEstado;
                    }
                return actualProyectoSeguimientoEstado;
            }
            set
            {
                actualProyectoSeguimientoEstado = value;
                ViewState["actualProyectoSeguimientoEstado"] = value;
            }
        }
        ProyectoSeguimientoEstadoResult GetNewProyectoSeguimientoEstado()
        {
            return new ProyectoSeguimientoEstadoResult();
        }
        void HidePopUpProyectoSeguimientoEstado()
        {
            ModalPopupExtenderSeguimientoEstado.Hide();
        }
        void ShowPopUpProyectoSeguimientoEstado()
        {
            ModalPopupExtenderSeguimientoEstado.Show();
            //upProyectoSeguimientoEstadoPopUp.Update();
        }
        #region EventosGrillas

        protected void GridProyectoSeguimientoEstado_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoSeguimientoEstado = (from o in Entity.ProyectoSeguimientoEstado  where o.IdProyectoSeguimientoEstado == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.READ :
                    CommandProyectoSeguimientoEstadoRead();
                    break;
                case Command.DELETE:
                    CommandProyectoSeguimientoEstadoDelete();
                    break;
            }

        }

        protected void GridProyectoSeguimientoEstado_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               if(e.Row.Cells[4].Text == "True" )
                   e.Row.Cells[4].Text = "Si"; 
               else
                   e.Row.Cells[4].Text = "No";

            }
        }

        protected virtual void GridProyectoSeguimientoEstado_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoSeguimientoEstado.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoSeguimientoEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoSeguimientoEstado.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoSeguimientoEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btNewProyectoSeguimientoEstado_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelProyectoSeguimientoEstado_Click(object sender, EventArgs e)
        {
            ProyectoSeguimientoEstadoClear();
            HidePopUpProyectoSeguimientoEstado();
        }

        #endregion
        #region Commands
        void CommandProyectoSeguimientoEstadoRead()
        {
            ProyectoSeguimientoEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoSeguimientoEstado);
            upEstadosPopUp.Update();
        }

        void CommandProyectoSeguimientoEstadoSave()
        {

        }
        void CommandProyectoSeguimientoEstadoDelete()
        {
            Entity.ProyectoSeguimientoEstado.Remove(ActualProyectoSeguimientoEstado);
            ProyectoSeguimientoEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoSeguimientoEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentario);
            ActualProyectoSeguimientoEstado = GetNewProyectoSeguimientoEstado();
        }
        void ProyectoSeguimientoEstadoSetValue()
        {
            UIHelper.SetValue<Estado,int>(ddlEstadoPopUpEstado, ActualProyectoSeguimientoEstado.IdEstado, EstadoService.Current.GetById);
            UIHelper.SetValue<Usuario,int>(ddlUsuarioPopUpEstado, ActualProyectoSeguimientoEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(diFechaPopUpEstado, ActualProyectoSeguimientoEstado.Fecha);
            UIHelper.SetValue(txtComentario, ActualProyectoSeguimientoEstado.Observacion);
            UIHelper.SetValue(chkGeneraComent, ActualProyectoSeguimientoEstado.GeneraComentarioTecnico);
        }
        void ProyectoSeguimientoEstadoGetValue()
        {
            ActualProyectoSeguimientoEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualProyectoSeguimientoEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualProyectoSeguimientoEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
            ActualProyectoSeguimientoEstado.Usuario_NombreUsuario = UIHelper.GetString(ddlUsuarioPopUpEstado);
            ActualProyectoSeguimientoEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualProyectoSeguimientoEstado.Observacion = UIHelper.GetString(txtComentario);
            ActualProyectoSeguimientoEstado.GeneraComentarioTecnico = UIHelper.GetBoolean(chkGeneraComent);
        }
        void ProyectoSeguimientoEstadoRefresh()
        {
            //Entity.ProyectoSeguimientoEstado = Entity.ProyectoSeguimientoEstado.OrderBy(i => i.Fecha).ToList();
        
            UIHelper.Load(gridProyectoSeguimientoEstado, Entity.ProyectoSeguimientoEstado, "Fecha", SortDirection.Descending );
        }
        #endregion

        


        #endregion

        protected bool EnableProyectoSeguimientoEstadoDelete { get; set; }
        protected void SetPermissions()
        {
            EnableProyectoSeguimientoEstadoDelete = CanByUser(SistemaEntidadConfig.PROYECTO_SEGUIMIENTO_ESTADO, ActionConfig.DELETE);

        }

    }
}