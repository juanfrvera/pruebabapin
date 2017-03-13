using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web
{
    public partial class PrestamoProductosEdit : WebControlEdit<nc.PrestamoProductosCompose>
    {
        #region Override WebControlEdit
        protected override void _Initialize()
        {
            base._Initialize();

            //rfvComponentes1.ErrorMessage = TranslateFormat("FieldIsNull", "Componente");
            revBAPIN.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            revBAPIN.ErrorMessage = TranslateFormat("InvalidField", "Nro. Proyecto");

            rfvComponentes.ErrorMessage = TranslateFormat("FieldIsNull", "Componente");
            rfvDescripcion.ErrorMessage = TranslateFormat("FieldIsNull", "Descripción");
            rfvMontoContraparte.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Contraparte");
            rfvMontoPrestamo.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Préstamo");

            PopUpProductos.Attributes.CssStyle.Add("display", "none");
        }
        protected override void _Load()
        {
            base._Load();

            // Cargar combos Componentes
            //if (!this.IsPostBack)
            //{
            //    List<PrestamoComponenteResult> aux = PrestamoComponenteService.Current.GetResult(new nc.PrestamoComponenteFilter() { IdPrestamo = Entity.IdPrestamo });
            //    if (aux.Count > 0)
            //    {
            //        UIHelper.Load<nc.PrestamoComponenteResult>(ddlComponentes, aux, "Objetivo_Nombre", "IdPrestamoComponente", new PrestamoComponenteResult() { IdPrestamoComponente=0, Objetivo_Nombre= Translate("Seleccione uno") });
            //        ManejarCombos();
            //    }
            //    else
            //    {
            //        ddlComponentes.Enabled = false;
            //    }                
            //}

            //
        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {

            List<PrestamoComponenteResult> aux = PrestamoComponenteService.Current.GetResult(new nc.PrestamoComponenteFilter() { IdPrestamo = Entity.IdPrestamo });
            if (aux.Count > 0)
            {
                UIHelper.Load<nc.PrestamoComponenteResult>(ddlComponentes, aux, "Objetivo_Nombre", "IdPrestamoComponente");
                ManejarCombos();
            }
            else
            {
                ddlComponentes.Enabled = false;
            }
            PrestamoProductoRefresh();
        }
        #endregion Override

        #region Productos
        private PrestamoProductoResult actualPrestamoProducto;
        protected PrestamoProductoResult ActualPrestamoProducto
        {
            get
            {
                if (actualPrestamoProducto == null)
                    if (ViewState["actualPrestamoProducto"] != null)
                        actualPrestamoProducto = ViewState["actualPrestamoProducto"] as PrestamoProductoResult;
                    else
                    {
                        actualPrestamoProducto = GetNewProducto();
                        ViewState["actualPrestamoProducto"] = actualPrestamoProducto;
                    }
                return actualPrestamoProducto;
            }
            set
            {
                actualPrestamoProducto = value;
                ViewState["actualPrestamoProducto"] = value;
            }
        }
        PrestamoProductoResult GetNewProducto()
        {
            int id = 0;
            if (Entity.Productos.Count > 0) id = Entity.Productos.Min(l => l.IdPrestamoProducto);
            if (id > 0) id = 0;
            id--;
            PrestamoProductoResult plResult = new PrestamoProductoResult();
            plResult.IdPrestamoProducto = id;
            return plResult;
        }

        #region Methods
        void HidePopUpProductos()
        {
            ModalPopupExtenderProductos.Hide();
        }
        void PrestamoProductoClear()
        {
            UIHelper.Clear(txtDescripcion);
            UIHelper.Clear(ddlComponentes);
            UIHelper.Clear(txtMontoContraparte);
            UIHelper.Clear(txtMontoPrestamo);
            UIHelper.Clear(cbAutorizacion);
            UIHelper.Clear(cbEjecucion);
            UIHelper.Clear(cbGestion);
            UIHelper.Clear(txtBAPIN);
            UIHelper.Clear(lbProyectoDenominacion);

            ActualPrestamoProducto = GetNewProducto();
        }
        void PrestamoProductoSetValue()
        {
            UIHelper.SetValue(lblErrorProducto, "");
            UIHelper.SetValue(txtDescripcion, ActualPrestamoProducto.Descripcion);
            UIHelper.SetValue(ddlComponentes, ActualPrestamoProducto.IdPrestamoComponente);
            Int32 id = ActualPrestamoProducto.IdPrestamoComponente > 0 ? ActualPrestamoProducto.IdPrestamoComponente : Int32.Parse(ddlComponentes.SelectedValue);
            if (id > 0)
                UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlSubComponentes, PrestamoSubComponenteService.Current.GetResult(new nc.PrestamoSubComponenteFilter() { IdPrestamoComponente = id }), "Descripcion", "IdPrestamoSubComponente", new PrestamoSubComponenteResult() { IdPrestamoSubComponente = 0, Descripcion = "Seleccione SubComponente" });

            UIHelper.SetValue(txtMontoContraparte, ActualPrestamoProducto.MontoContraparte);
            UIHelper.SetValue(txtMontoPrestamo, ActualPrestamoProducto.MontoPrestamo);
            UIHelper.SetValue(cbAutorizacion, ActualPrestamoProducto.NegociarAutorizacion);
            UIHelper.SetValue(cbEjecucion, ActualPrestamoProducto.Ejecucion);
            UIHelper.SetValue(cbGestion, ActualPrestamoProducto.InicioGestion);
            UIHelper.SetValue(txtBAPIN, ActualPrestamoProducto.Proyecto_Codigo);
            UIHelper.SetValue(lbProyectoDenominacion, ActualPrestamoProducto.Proyecto_ProyectoDenominacion);

            ManejarCombos();

            if (ActualPrestamoProducto.IdPrestamoSubComponente != null)
                UIHelper.SetValue(ddlSubComponentes, ActualPrestamoProducto.IdPrestamoSubComponente);
        }
        string GetBoolString(bool value)
        {
            return value ? SolutionContext.Current.TextManager.Translate("Si") :
                           SolutionContext.Current.TextManager.Translate("No");
        }
        void PrestamoProductoGetValue()
        {
            ActualPrestamoProducto.IdPrestamoComponente = UIHelper.GetInt(ddlComponentes);
            if (ActualPrestamoProducto.IdPrestamoComponente > 0)
            {
                ActualPrestamoProducto.Descripcion = UIHelper.GetString(txtDescripcion);
                ActualPrestamoProducto.Componente = ddlComponentes.SelectedItem.Text;

                ActualPrestamoProducto.IdPrestamoSubComponente = UIHelper.GetIntNullable(ddlSubComponentes);
                if (ddlSubComponentes.SelectedItem != null)
                    ActualPrestamoProducto.SubComponente = ddlSubComponentes.SelectedItem.Text;
                else
                    ActualPrestamoProducto.SubComponente = "";

                ActualPrestamoProducto.MontoContraparte = UIHelper.GetDecimal(txtMontoContraparte);
                ActualPrestamoProducto.MContraparte = string.Format("{0:N0}", ActualPrestamoProducto.MontoContraparte);
                ActualPrestamoProducto.MontoPrestamo = UIHelper.GetDecimal(txtMontoPrestamo);
                ActualPrestamoProducto.MPrestamo = string.Format("{0:N0}", ActualPrestamoProducto.MontoPrestamo);

                ActualPrestamoProducto.NegociarAutorizacion = UIHelper.GetBooleanNullable(cbAutorizacion);
                ActualPrestamoProducto.StrANegociar = GetBoolString((bool)ActualPrestamoProducto.NegociarAutorizacion);

                ActualPrestamoProducto.Ejecucion = UIHelper.GetBooleanNullable(cbEjecucion);
                ActualPrestamoProducto.StrEjecucion = GetBoolString((bool)ActualPrestamoProducto.Ejecucion);

                ActualPrestamoProducto.InicioGestion = UIHelper.GetBooleanNullable(cbGestion);
                ActualPrestamoProducto.StrIGestion = GetBoolString((bool)ActualPrestamoProducto.InicioGestion);


                // Carga el proyecto
                Int32 auxCodigo = 0;
                if (Int32.TryParse(txtBAPIN.Text, out auxCodigo))
                {
                    List<nc.Proyecto> ps = ProyectoService.Current.GetList(new nc.ProyectoFilter() { Codigo = auxCodigo });
                    if (ps.Count == 1)
                    {
                        if (ps[0].EsBorrador)
                            throw new Exception("ERROR: EL BAPIN buscado esta en BORRADOR");

                        if (!ps[0].Activo)
                            throw new Exception("ERROR: EL BAPIN buscado esta INACTIVO");

                        ActualPrestamoProducto.IdProyecto = ps[0].IdProyecto;
                        ActualPrestamoProducto.Proyecto_Codigo = ps[0].Codigo;
                        ActualPrestamoProducto.BAPIN = ps[0].Codigo.ToString();
                        ActualPrestamoProducto.Proyecto_ProyectoDenominacion = ps[0].ProyectoDenominacion;
                        //Matias 20170222 - Ticket #REQ217514
                        Estado e = EstadoService.Current.GetById(ps[0].IdEstado);
                        ActualPrestamoProducto.ProyectoEstado = (e != null) ? e.Nombre : string.Empty;
                        //FinMatias 20170222 - Ticket #REQ217514
                    }
                }
                //Matias 20170208 - Ticket #ER967470
                else
                {
                    ActualPrestamoProducto.IdProyecto = null;
                    ActualPrestamoProducto.Proyecto_Codigo = null;
                    ActualPrestamoProducto.BAPIN = string.Empty;
                    ActualPrestamoProducto.Proyecto_ProyectoDenominacion = string.Empty;
                    ActualPrestamoProducto.ProyectoEstado = string.Empty; //Matias 20170222 - Ticket #REQ217514
                }
                //FinMatias 20170208 - Ticket #ER967470
            }
        }
        void PrestamoProductoRefresh()
        {
            UIHelper.Load(gridProductos, Entity.Productos, "Descripcion");
            upGridProductos.Update();
        }
        void ManejarCombos()
        {
            ddlSubComponentes.SelectedValue = null;
            Int32 id = ActualPrestamoProducto.IdPrestamoComponente > 0 ? ActualPrestamoProducto.IdPrestamoComponente : Int32.Parse(ddlComponentes.SelectedValue);
            if (id > 0)
                UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlSubComponentes, PrestamoSubComponenteService.Current.GetResult(new nc.PrestamoSubComponenteFilter() { IdPrestamoComponente = id }), "Descripcion", "IdPrestamoSubComponente");
            else
            {
                ddlSubComponentes.DataSource = null;
                ddlSubComponentes.Items.Clear();
            }
            ddlComponentes.Enabled = ddlComponentes.Items.Count > 0;
            ddlSubComponentes.Enabled = ddlSubComponentes.Items.Count > 0;
            if (ddlSubComponentes.Enabled)
                UIHelper.SetValue(ddlSubComponentes, 0);
        }
        bool ValidarProducto(out string msgError)
        {
            /*
             * Matias 20140429 - Tarea 142
            if(!((bool)ActualPrestamoProducto.NegociarAutorizacion ||
                   (bool)ActualPrestamoProducto.InicioGestion ||
                   (bool)ActualPrestamoProducto.Ejecucion))
            {
                msgError = SolutionContext.Current.TextManager.Translate("- Debe seleccionar al menos un estado");
                return false;
            }
             * FinMatias 20140429 - Tarea 142
            */
            int? numero = UIHelper.GetIntNullable(txtBAPIN);
            if (numero != null)
            {
                ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = numero }).FirstOrDefault();
                if (proyecto == null)
                {
                    msgError = TranslateFormat("InvalidField", "Nro. Proyecto");
                    return false;
                }
            }
            msgError = string.Empty;
            return true;
        }
        private void ActualizarSubComponentes()
        {
            int IdPrestamoComp = UIHelper.GetInt(ddlComponentes);
            if (IdPrestamoComp > 0)
            {
                UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlSubComponentes, PrestamoSubComponenteService.Current.GetResult(new nc.PrestamoSubComponenteFilter() { IdPrestamoComponente = IdPrestamoComp }), "Descripcion", "IdPrestamoSubComponente");
                UIHelper.SetValue(ddlSubComponentes, 0);
            }
            else
            {
                ddlSubComponentes.DataSource = null;
                ddlSubComponentes.Items.Clear();
                ddlComponentes.Enabled = ddlComponentes.Items.Count > 0;
            }
            ddlSubComponentes.Enabled = ddlSubComponentes.Items.Count > 0;
        }
        protected void btSearchProyecto_Click(object sender, EventArgs e)
        {
            int? numero = UIHelper.GetIntNullable(txtBAPIN);
            if (numero != null)
            {
                ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = numero }).FirstOrDefault();
                if (proyecto == null)
                {
                    UIHelper.ShowAlert(TranslateFormat("El campo nro. de proyecto hace referencia a un proyecto inexistente"), upProductosPopUp);
                    UIHelper.Clear(lbProyectoDenominacion);
                }
                else
                {
                    lbProyectoDenominacion.Text = proyecto.ProyectoDenominacion;
                }
            }
            //Matias 20170208 - Ticket #ER967470
            else 
            {
                UIHelper.Clear(txtBAPIN); 
                UIHelper.Clear(lbProyectoDenominacion);
            }
            //FinMatias 20170208 - Ticket #ER967470
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoProductoEdit()
        {
            PrestamoProductoSetValue();
            ModalPopupExtenderProductos.Show();
            upProductosPopUp.Update();
        }
        void CommandPrestamoProductoSave()
        {
            string msgError = string.Empty;
            lblErrorProducto.Text = "";
            PrestamoProductoGetValue();
            PrestamoProductoResult result = (from l in Entity.Productos
                                             where l.IdPrestamoProducto == ActualPrestamoProducto.IdPrestamoProducto
                                             select l).FirstOrDefault();

            if (ActualPrestamoProducto.IdPrestamoComponente > 0)
            {
                if (ValidarProducto(out msgError))
                {
                    if (result != null)
                    {
                        result.IdPrestamoComponente = ActualPrestamoProducto.IdPrestamoComponente;
                        result.IdPrestamoSubComponente = ActualPrestamoProducto.IdPrestamoSubComponente;
                        result.InicioGestion = ActualPrestamoProducto.InicioGestion;
                        result.NegociarAutorizacion = ActualPrestamoProducto.NegociarAutorizacion;
                        result.Ejecucion = ActualPrestamoProducto.Ejecucion;
                        result.Descripcion = ActualPrestamoProducto.Descripcion;
                        result.IdProyecto = ActualPrestamoProducto.IdProyecto;
                        result.MontoPrestamo = ActualPrestamoProducto.MontoPrestamo;
                        result.MontoContraparte = ActualPrestamoProducto.MontoContraparte;

                        result.Componente = ActualPrestamoProducto.Componente;
                        result.SubComponente = ActualPrestamoProducto.SubComponente;
                        result.MContraparte = ActualPrestamoProducto.MContraparte;
                        result.MPrestamo = ActualPrestamoProducto.MPrestamo;
                        result.StrANegociar = ActualPrestamoProducto.StrANegociar;
                        result.StrEjecucion = ActualPrestamoProducto.StrEjecucion;
                        result.StrIGestion = ActualPrestamoProducto.StrIGestion;
                        result.BAPIN = ActualPrestamoProducto.BAPIN;
                        result.Proyecto_Codigo = ActualPrestamoProducto.Proyecto_Codigo;
                        result.Proyecto_ProyectoDenominacion = ActualPrestamoProducto.Proyecto_ProyectoDenominacion; //Matias 20140429 - Tarea 145
                        result.ProyectoEstado = ActualPrestamoProducto.ProyectoEstado; //Matias 20170222 - Ticket #REQ217514
                    }
                    else
                    {
                        Entity.Productos.Add(ActualPrestamoProducto);
                    }

                    PrestamoProductoClear();
                    PrestamoProductoRefresh();
                }
                else
                {
                    lblErrorProducto.Text = msgError;
                    UIHelper.ShowAlert(msgError, upProductosPopUp);
                    upProductosPopUp.Update();
                }
            }
            else
            {
                lblErrorProducto.Text = SolutionContext.Current.TextManager.Translate("- Debe seleccionar al menos un componente");
                UIHelper.ShowAlert(lblErrorProducto.Text, upProductosPopUp);
                upProductosPopUp.Update();
            }
        }
        void CommandPrestamoProductoDelete()
        {
            PrestamoProductoResult result = (from l in Entity.Productos where l.IdPrestamoProducto == ActualPrestamoProducto.ID select l).FirstOrDefault();
            Entity.Productos.Remove(result);
            PrestamoProductoClear();
            PrestamoProductoRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveProducto_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorProducto, "");
            CallTryMethod(CommandPrestamoProductoSave);
            if (lblErrorProducto.Text == "")
                HidePopUpProductos();
        }
        protected void btNewProducto_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorProducto, "");
            CallTryMethod(CommandPrestamoProductoSave);
        }
        protected void btCancelProducto_Click(object sender, EventArgs e)
        {
            PrestamoProductoClear();
            HidePopUpProductos();
        }
        protected void btAgregarProducto_Click(object sender, EventArgs e)
        {
            lblErrorProducto.Text = "";
            PrestamoProductoClear();
            ActualizarSubComponentes();
            upProductosPopUp.Update();
            ModalPopupExtenderProductos.Show();

        }
        protected void ddlComponenetes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Recargar combo de Subcomponentes
            ActualPrestamoProducto.IdPrestamoComponente = UIHelper.GetInt(ddlComponentes);
            if (ActualPrestamoProducto.IdPrestamoComponente > 0)
                UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlSubComponentes, PrestamoSubComponenteService.Current.GetResult(new nc.PrestamoSubComponenteFilter() { IdPrestamoComponente = ActualPrestamoProducto.IdPrestamoComponente }), "Descripcion", "IdPrestamoSubComponente");
            UIHelper.SetValue(ddlSubComponentes, 0);
            ManejarCombos();
        }

        /*   protected void txtBAPIN_OnTextChanged(object sender, EventArgs e)
           {
               Int32 auxCodigo = 0;
               lblErrorProducto.Text = "";
               lbProyectoDenominacion.Text = "";
               if (Int32.TryParse(txtBAPIN.Text, out auxCodigo))
               {
                   List<nc.Proyecto> ps = ProyectoService.Current.GetList(new nc.ProyectoFilter() { Codigo = auxCodigo });
                   if (ps.Count == 1)
                       lbProyectoDenominacion.Text = ps[0].ProyectoDenominacion;
                   else
                   {
                       lblErrorProducto.Text = SolutionContext.Current.TextManager.Translate("- Proyecto no encontrado");
                       UIHelper.ShowAlert(lblErrorProducto.Text, upProductosPopUp);
                   }
               }
               else
               {
                   lblErrorProducto.Text = SolutionContext.Current.TextManager.Translate("- Código Incorrecto");
                   UIHelper.ShowAlert(lblErrorProducto.Text, upProductosPopUp);
               }
           }*/
        protected void limpiarMensaje_OnCheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                lblErrorProducto.Text = "";
                ((CheckBox)sender).Focus();
                upProductosPopUp.Update();
            }
        }
        #endregion

        #region EventosGrillas
        protected void GridImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoProducto = (from l in Entity.Productos where l.IdPrestamoProducto == id select l).FirstOrDefault();

            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoProductoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoProductoDelete();
                    break;
            }
        }
        protected void GridProductos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoProducto = (from l in Entity.Productos where l.IdPrestamoProducto == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoProductoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoProductoDelete();
                    break;
            }
        }
        protected virtual void GridProductos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProductos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProductos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion
        #endregion Productos
    }
}