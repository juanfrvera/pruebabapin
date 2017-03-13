using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using System.IO;

namespace UI.Web
{
    public partial class ProyectoAlcanceGeograficoEdit : WebControlEdit<nc.ProyectoAlcanceGeograficoCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();

            this.tsLocalizacion.Width = 700;
            this.tsAlcanceGeografico.Width = 700;

            //revDescripcionGeo.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revLongitudGeo.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revLatitudGeo.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revOrdenGeo.ValidationExpression = Contract.DataHelper.GetExpRegNumberInteger();
           
            //revDescripcionGeo.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvLongitudGeo.ErrorMessage = TranslateFormat("FieldIsNull", "Longitud");
            revLongitudGeo.ErrorMessage = TranslateFormat("InvalidField", "Longitud");
            rfvLatitudGeo.ErrorMessage = TranslateFormat("FieldIsNull", "Latitud");
            revLatitudGeo.ErrorMessage = TranslateFormat("InvalidField", "Latitud");
            rfvOrdenGeo.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
            revOrdenGeo.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            // Localizaciones
            PopUpLocalizaciones.Attributes.CssStyle.Add("display", "none");
            // Alcances
            PopUpAlcances.Attributes.CssStyle.Add("display", "none");
            // Georeferenciaciones
            PopUpGeoreferenciaciones.Attributes.CssStyle.Add("display", "none");

            //txtOrden.Enabled = false; //Matias 20150130 - Tarea 196
        }

        public override void Clear()
        {
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
            ProyectoLocalizacionRefresh();
            ProyectoAlcanceRefresh();
            ProyectoGeoreferenciacionRefresh();
        }
        #endregion Override

        //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
        //#region Permissions
        //protected bool EnableSolapa
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(ViewState["EnableSolapa"]);
        //    }
        //    set
        //    {
        //        ViewState["EnableSolapa"] = value;
        //    }
        //}

        //protected void SetPermissions()
        //{
        //    if (CrudAction == CrudActionEnum.Create)
        //    {
        //        //EnableSolapa = false;
        //    }
        //    else if (CrudAction == CrudActionEnum.Read)
        //    {
        //        EnableSolapa = false;
        //        this.pnlAlcanceGeografico.Enabled = false;
        //        this.pnlLocalizacionGeografica.Enabled = false;
        //        this.pnlGeoreferenciacion.Enabled = false;
        //    }
        //    else
        //    {
        //        //EnableSolapa = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);                
        //    }

        //    //Inhabilito todos los componenetes de la Solapa
        //    //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;
        //    //this.btAgregarPlan.Enabled = EnablePlanUpdate;
        //}
        //#endregion
        //FinMatias 20170210 - Ticket #REQ768159

        #region Sobre Localizacion

        private ProyectoLocalizacionResult actualProyectoLocalizacion;
        protected ProyectoLocalizacionResult ActualProyectoLocalizacion
        {
            get
            {
                if (actualProyectoLocalizacion == null)
                {
                    if (ExistsPersist("actualProyectoLocalizacion"))
                        actualProyectoLocalizacion = ((ProyectoLocalizacionResult)GetPersist("actualProyectoLocalizacion"));
                    else
                    {
                        actualProyectoLocalizacion = GetNewLocalizacion();
                        SetPersist("actualProyectoLocalizacion", actualProyectoLocalizacion);
                    }
                }
                return actualProyectoLocalizacion;
            }
            set
            {
                actualProyectoLocalizacion = value;
                SetPersist("actualProyectoLocalizacion", value);
            }
        }
        ProyectoLocalizacionResult GetNewLocalizacion()
        {
            int id = 0;
            if (Entity.Localizaciones.Count > 0) id = Entity.Localizaciones.Min(l => l.IdProyectoLocalizacion);
            if (id > 0) id = 0;
            id--;
            ProyectoLocalizacionResult plResult = new ProyectoLocalizacionResult();
            plResult.IdProyectoLocalizacion = id;
            plResult.IdProyecto = Entity.IdProyecto;
            plResult.IdClasificacionGeografica = 0;
            return plResult;
        }

        #region Methods
        void HidePopUpLocalizaciones()
        {
            ModalPopupExtenderLocalizaciones.Hide();
        }
        void ProyectoLocalizacionClear()
        {
            UIHelper.Clear(tsLocalizacion as IWebControlTreeSelect);
            ActualProyectoLocalizacion = GetNewLocalizacion();
        }
        void ProyectoLocalizacionSetValue()
        {
            UIHelper.SetValue(tsLocalizacion as IWebControlTreeSelect, ActualProyectoLocalizacion.IdClasificacionGeografica);
        }
        void ProyectoLocalizacionGetValue()
        {
            ActualProyectoLocalizacion.IdClasificacionGeografica = UIHelper.GetInt(tsLocalizacion as IWebControlTreeSelect);
            // Busca la clasificacion seleccionada
            ClasificacionGeografica cg = ClasificacionGeograficaService.Current.GetById(ActualProyectoLocalizacion.IdClasificacionGeografica);
            ActualProyectoLocalizacion.Tipo = cg.IdClasificacionGeograficaTipo;
            ActualProyectoLocalizacion.Descripcion = cg.Descripcion;
        }
        void ProyectoLocalizacionRefresh()
        {
            UIHelper.Load(gridLocalizaciones, Entity.Localizaciones, "Orden");
            upGridLocalizaciones.Update();
        }

        protected bool ValidateLocalizacion()
        {
            int IdClasificacionGeografica = UIHelper.GetInt(tsLocalizacion as IWebControlTreeSelect);
            if (IdClasificacionGeografica > 0)
            {
                List<ProyectoLocalizacionResult> plr = Entity.Localizaciones.Where(p => p.IdClasificacionGeografica == IdClasificacionGeografica).ToList();
                if (ActualProyectoAlcance.ID < 0)
                {
                    if (plr != null && plr.Count == 1)
                    {
                        UIHelper.ShowAlert("La localicación ya existe en la lista.", upLocalizacionesPopUp);
                        return false;
                    }
                }
                else
                {
                    if (plr != null && plr.Count == 1 && ActualProyectoAlcance.ID != plr.FirstOrDefault().ID)
                    {
                        UIHelper.ShowAlert("La localicación ya existe en la lista.", upLocalizacionesPopUp);
                        return false;
                    }

                }
            }
            return true;
        }
        #endregion Methods

        #region Commands
        void CommandProyectoLocalizacionEdit()
        {
            ProyectoLocalizacionSetValue();
            ModalPopupExtenderLocalizaciones.Show();
            upLocalizacionesPopUp.Update();
        }
        void CommandProyectoLocalizacionSave()
        {
            if (UIHelper.GetInt(tsLocalizacion as IWebControlTreeSelect) > 0)
            {
                ProyectoLocalizacionGetValue();
                ProyectoLocalizacionResult result = (from l in Entity.Localizaciones
                                                     where l.IdProyectoLocalizacion == ActualProyectoLocalizacion.ID
                                                     || l.IdClasificacionGeografica == ActualProyectoLocalizacion.IdClasificacionGeografica
                                                     select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdClasificacionGeografica = ActualProyectoLocalizacion.IdClasificacionGeografica;
                    result.Tipo = ActualProyectoLocalizacion.Tipo;
                    result.Descripcion = ActualProyectoLocalizacion.Descripcion;
                }
                else
                {
                    Entity.Localizaciones.Add(ActualProyectoLocalizacion);
                }
                ProyectoLocalizacionClear();
                ProyectoLocalizacionRefresh();
            }
        }
        void CommandProyectoLocalizacionDelete()
        {
            ProyectoLocalizacionResult result = (from l in Entity.Localizaciones where l.IdProyectoLocalizacion == ActualProyectoLocalizacion.ID select l).FirstOrDefault();
            Entity.Localizaciones.Remove(result);
            ProyectoLocalizacionClear();
            ProyectoLocalizacionRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveLocalizacion_Click(object sender, EventArgs e)
        {

            if (ValidateLocalizacion())
            {
                CallTryMethod(CommandProyectoLocalizacionSave);
                HidePopUpLocalizaciones();
            }



        }
        protected void btNewLocalizacion_Click(object sender, EventArgs e)
        {
            if (ValidateLocalizacion())
            {
                CallTryMethod(CommandProyectoLocalizacionSave);
            }
        }
        protected void btCancelLocalizacion_Click(object sender, EventArgs e)
        {
            ProyectoLocalizacionClear();
            HidePopUpLocalizaciones();
        }
        protected void btAgregarLocalizacion_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderLocalizaciones.Show();
            tsLocalizacion.Focus();
        }
        #endregion

        #region EventosGrillas
        protected void GridLocalizaciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoLocalizacion = (from l in Entity.Localizaciones where l.IdProyectoLocalizacion == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoLocalizacionEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoLocalizacionDelete();
                    break;
            }
        }
        protected virtual void GridLocalizaciones_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridLocalizaciones.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridLocalizaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridLocalizaciones.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Localizacion

        #region Sobre Alcance

        private ProyectoAlcanceGeograficoResult actualProyectoAlcance;
        protected ProyectoAlcanceGeograficoResult ActualProyectoAlcance
        {
            get
            {
                if (actualProyectoAlcance == null)
                {
                    if (ExistsPersist("actualProyectoAlcance"))
                        actualProyectoAlcance = ((ProyectoAlcanceGeograficoResult)GetPersist("actualProyectoAlcance"));
                    else
                    {
                        actualProyectoAlcance = GetNewAlcance();
                        SetPersist("actualProyectoAlcance", actualProyectoAlcance);
                    }
                }
                return actualProyectoAlcance;
            }
            set
            {
                actualProyectoAlcance = value;
                SetPersist("actualProyectoAlcance", value);
            }
        }
        ProyectoAlcanceGeograficoResult GetNewAlcance()
        {
            int id = 0;
            if (Entity.Alcances.Count > 0) id = Entity.Alcances.Min(l => l.IdProyectoAlcanceGeografico);
            if (id > 0) id = 0;
            id--;
            ProyectoAlcanceGeograficoResult plResult = new ProyectoAlcanceGeograficoResult();
            plResult.IdProyectoAlcanceGeografico = id;
            plResult.IdProyecto = Entity.IdProyecto;
            plResult.IdClasificacionGeografica = 0;
            return plResult;
        }

        #region Methods
        void HidePopUpAlcances()
        {
            ModalPopupExtenderAlcances.Hide();
        }
        void ProyectoAlcanceClear()
        {
            UIHelper.Clear(tsAlcanceGeografico as IWebControlTreeSelect);
            ActualProyectoAlcance = GetNewAlcance();
        }
        void ProyectoAlcanceSetValue()
        {
            UIHelper.SetValue(tsAlcanceGeografico as IWebControlTreeSelect, ActualProyectoAlcance.IdClasificacionGeografica);
        }
        void ProyectoAlcanceGetValue()
        {
            ActualProyectoAlcance.IdClasificacionGeografica = UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect);
            // Busca la clasificacion seleccionada
            ClasificacionGeografica cg = ClasificacionGeograficaService.Current.GetById(ActualProyectoAlcance.IdClasificacionGeografica);
            ActualProyectoAlcance.Tipo = cg.IdClasificacionGeograficaTipo;
            ActualProyectoAlcance.Descripcion = cg.Descripcion;
        }
        void ProyectoAlcanceRefresh()
        {
            UIHelper.Load(gridAlcances, Entity.Alcances, "Orden");
            upGridAlcances.Update();
        }
        protected bool ValidateAlcance()
        {
            int IdClasificacionGeografica = UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect);
            if (IdClasificacionGeografica > 0)
            {
                List<ProyectoAlcanceGeograficoResult> pagr = Entity.Alcances.Where(p => p.IdClasificacionGeografica == IdClasificacionGeografica).ToList();
                if (ActualProyectoAlcance.ID < 0)
                {
                    if (pagr != null && pagr.Count == 1)
                    {
                        UIHelper.ShowAlert("El Alcance geográfico ya existe en la lista.", upAlcancesPopUp);
                        return false;
                    }
                }
                else
                {
                    if (pagr != null && pagr.Count == 1 && ActualProyectoAlcance.ID != pagr.FirstOrDefault().ID)
                    {
                        UIHelper.ShowAlert("El Alcance geográfico ya existe en la lista.", upAlcancesPopUp);
                        return false;
                    }

                }
            }
            return true;
        }
        #endregion Methods

        #region Commands

        void CommandProyectoAlcanceEdit()
        {
            ProyectoAlcanceSetValue();
            ModalPopupExtenderAlcances.Show();
            upAlcancesPopUp.Update();
        }
        void CommandProyectoAlcanceSave()
        {
            if (UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect) > 0)
            {
                ProyectoAlcanceGetValue();
                ProyectoAlcanceGeograficoResult result = (from l in Entity.Alcances
                                                          where l.IdProyectoAlcanceGeografico == ActualProyectoAlcance.ID
                                                          || l.IdClasificacionGeografica == ActualProyectoAlcance.IdClasificacionGeografica
                                                          select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdClasificacionGeografica = ActualProyectoAlcance.IdClasificacionGeografica;
                    result.Tipo = ActualProyectoAlcance.Tipo;
                    result.Descripcion = ActualProyectoAlcance.Descripcion;
                }
                else
                {
                    Entity.Alcances.Add(ActualProyectoAlcance);
                }
                ProyectoAlcanceClear();
                ProyectoAlcanceRefresh();
            }
        }
        void CommandProyectoAlcanceDelete()
        {

            ProyectoAlcanceGeograficoResult result = (from l in Entity.Alcances where l.IdProyectoAlcanceGeografico == ActualProyectoAlcance.ID select l).FirstOrDefault();
            Entity.Alcances.Remove(result);
            ProyectoAlcanceClear();
            ProyectoAlcanceRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveAlcance_Click(object sender, EventArgs e)
        {

            if (ValidateAlcance())
            {
                CallTryMethod(CommandProyectoAlcanceSave);
                HidePopUpAlcances();
            }


        }
        protected void btNewAlcance_Click(object sender, EventArgs e)
        {
            if (ValidateAlcance())
            {
                CallTryMethod(CommandProyectoAlcanceSave);
            }
        }
        protected void btCancelAlcance_Click(object sender, EventArgs e)
        {
            ProyectoAlcanceClear();
            HidePopUpAlcances();
        }
        protected void btAgregarAlcance_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderAlcances.Show();
            tsAlcanceGeografico.Focus();
        }
        #endregion

        #region EventosGrillas

        protected void GridAlcances_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoAlcance = (from l in Entity.Alcances where l.IdProyectoAlcanceGeografico == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoAlcanceEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoAlcanceDelete();
                    break;
            }
        }
        protected virtual void GridAlcances_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridAlcances.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridAlcances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridAlcances.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion Alcance

        #region Sobre Georeferenciacion

        private ProyectoGeoreferenciacionResult actualProyectoGeoreferenciacion;
        protected ProyectoGeoreferenciacionResult ActualProyectoGeoreferenciacion
        {
            get
            {
                if (actualProyectoGeoreferenciacion == null)
                {
                    if (ExistsPersist("actualProyectoGeoreferenciacion"))
                        actualProyectoGeoreferenciacion = ((ProyectoGeoreferenciacionResult)GetPersist("actualProyectoGeoreferenciacion"));
                    else
                    {
                        actualProyectoGeoreferenciacion = GetNewGeoreferenciacion();
                        SetPersist("actualProyectoGeoreferenciacion", actualProyectoGeoreferenciacion);
                    }
                }
                return actualProyectoGeoreferenciacion;
            }
            set
            {
                actualProyectoGeoreferenciacion = value;
                SetPersist("actualProyectoGeoreferenciacion", value);
            }
        }
        ProyectoGeoreferenciacionResult GetNewGeoreferenciacion()
        {
            int id = 0;
            if (Entity.Georeferenciaciones.Count > 0) id = Entity.Georeferenciaciones.Min(l => l.IdProyectoGeoreferenciacion);
            if (id > 0) id = 0;
            id--;
            ProyectoGeoreferenciacionResult plResult = new ProyectoGeoreferenciacionResult();
            plResult.IdProyectoGeoreferenciacion = id;
            plResult.IdProyecto = Entity.IdProyecto;
            plResult.IdGeoreferenciacion = id;
            plResult.Georeferenciacion = new GeoreferenciacionResult();
            plResult.Georeferenciacion.IdGeoreferenciacionTipo = (int)GeoreferenciacionTipoEnum.Punto;
            plResult.Puntos = new List<GeoreferenciacionPuntoResult>();
            return plResult;
        }
        GeoreferenciacionPuntoResult GetNewGeoreferenciacionPunto()
        {
            int id = 0;
            if (ActualProyectoGeoreferenciacion.Puntos.Count > 0) id = ActualProyectoGeoreferenciacion.Puntos.Min(p => p.IdGeoreferenciacionPunto);
            if (id > 0) id = 0;
            id--;
            GeoreferenciacionPuntoResult pResult = new GeoreferenciacionPuntoResult();
            pResult.IdGeoreferenciacionPunto = id;
            return pResult;
        }

        #region Methods
        void HidePopUpGeoreferenciaciones()
        {
            ModalPopupExtenderGeoreferenciaciones.Hide();
        }
        void ProyectoGeoreferenciacionClear()
        {
            UIHelper.Clear(rbPunto);
            UIHelper.Clear(rbLinea);
            UIHelper.Clear(rbPoligono);
            ActualProyectoGeoreferenciacion = GetNewGeoreferenciacion();
            ProyectoGeoreferenciacionRefresh();
            upGeoreferenciacionesPopUp.Update();
            LoadGridPuntos();
            rbPunto.Enabled = true;
            rbPunto.Checked = true;
            //txtOrden.Enabled = true; Matias 20150130 - Tarea 196
            txtLongitud.Enabled = true;
            txtLatitud.Enabled = true;
            btnAgregarPunto.Enabled = true;
            txtOrden.Text = "1";
            UIHelper.Clear(txtLongitud);
            UIHelper.Clear(txtLatitud);
            UIHelper.Clear(txtDescricpion);
            txtLongitud.Focus();
        }
        void ProyectoGeoreferenciacionSetValue()
        {
            switch ((GeoreferenciacionTipoEnum)ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo)
            {
                case GeoreferenciacionTipoEnum.Punto:
                    {
                        rbPunto.Checked = true;
                        rbLinea.Checked = false;
                        rbPoligono.Checked = false;
                        break;
                    }
                case GeoreferenciacionTipoEnum.Linea:
                    {
                        rbPunto.Checked = false;
                        rbLinea.Checked = true;
                        rbPoligono.Checked = false;
                        break;
                    }
                case GeoreferenciacionTipoEnum.Poligono:
                    {
                        rbPunto.Checked = false;
                        rbLinea.Checked = false;
                        rbPoligono.Checked = true;
                        break;
                    }
            }

            if (ActualProyectoGeoreferenciacion.Puntos.Count > 0)
                txtDescricpion.Text = ActualProyectoGeoreferenciacion.Puntos[0].descripcion;

            LoadGridPuntos();
            ManejarControles();
        }
        void ProyectoGeoreferenciacionGetValue()
        {
             if (rbPunto.Checked)
                 ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo = (int)GeoreferenciacionTipoEnum.Punto;
             else if (rbLinea.Checked)
                 ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo = (int)GeoreferenciacionTipoEnum.Linea;
             else if (rbPoligono.Checked)
                 ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo = (int)GeoreferenciacionTipoEnum.Poligono;

             foreach (GeoreferenciacionPuntoResult p in ActualProyectoGeoreferenciacion.Puntos)
                 p.descripcion = txtDescricpion.Text;
        }
        void ProyectoGeoreferenciacionRefresh()
        {
            UIHelper.Load(gridGeoreferenciaciones, Entity.Georeferenciaciones);
            upGridGeoreferenciaciones.Update();
        }
        void ManejarControles()
        {
            lblMsjError.Text = "";
            if ((ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo == (int)GeoreferenciacionTipoEnum.Punto &&
                ActualProyectoGeoreferenciacion.Puntos.Count > 0) ||
                (ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo == (int)GeoreferenciacionTipoEnum.Linea &&
                ActualProyectoGeoreferenciacion.Puntos.Count > 1))
            {
                //this.txtOrden.Enabled = false; Matias 20150130 - Tarea 196
                this.txtLongitud.Enabled = false;
                this.txtLatitud.Enabled = false;
                this.btnAgregarPunto.Enabled = false;
                this.btSaveGeoreferenciaciones.Focus();
            }
            else
            {
                //this.txtOrden.Enabled = true; Matias 20150130 - Tarea 196
                this.txtLongitud.Enabled = true;
                this.txtLatitud.Enabled = true;
                this.btnAgregarPunto.Enabled = true;
                this.txtLongitud.Focus();
            }

            txtOrden.Text = ActualProyectoGeoreferenciacion.Puntos.Count == 0 ? "1" :
                           (ActualProyectoGeoreferenciacion.Puntos.Max(p => p.Orden) + 1).ToString();
            UIHelper.Clear(txtLatitud);
            UIHelper.Clear(txtLongitud);
            rbPunto.Enabled = ActualProyectoGeoreferenciacion.Puntos.Count <= 1;
            rbLinea.Enabled = ActualProyectoGeoreferenciacion.Puntos.Count <= 2;
        }
        bool ValidaGeoreferenciacion(ref string msgErr)
        {
            bool retval = true;

            if (ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo == (int)GeoreferenciacionTipoEnum.Punto &&
                ActualProyectoGeoreferenciacion.Puntos.Count != 1)
            {
                msgErr = Translate("Un Punto debe contener solo un item");
                retval = false;
            }
            else if (ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo == (int)GeoreferenciacionTipoEnum.Linea &&
                     ActualProyectoGeoreferenciacion.Puntos.Count != 2)
            {
                msgErr = Translate("Una Linea debe contener dos items");
                retval = false;
            }
            else if (ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo == (int)GeoreferenciacionTipoEnum.Poligono &&
                     ActualProyectoGeoreferenciacion.Puntos.Count <= 2)
            {
                msgErr = Translate("Un Polígono debe contener por lo menos tres items");
                retval = false;
            }
            else if (txtDescricpion.Text == "")
            {
                msgErr = Translate("El campo Descripción es obligatorio");
                retval = false;
            }


            return retval;
            
        }
        bool ValidaAltaPuntos()
        {
             try
             {
                 lblMsjError.Text = "";
                 Int32.Parse(txtOrden.Text);
                 decimal.Parse(txtLatitud.Text);
                 decimal.Parse(txtLongitud.Text);
             }
             catch 
             {
                 lblMsjError.Text = TranslateFormat("InvalidField", "Orden", "Latitud", "Longitud");
                 UIHelper.ShowAlert(TranslateFormat("InvalidField", "Orden", "Latitud", "Longitud"),upGeoreferenciacionesPopUp);
             }
             return lblMsjError.Text == "";
            
        }
        void LoadGridPuntos()
        {
            // UIHelper.Load(GridPuntos, ActualProyectoGeoreferenciacion.Puntos, "Orden", SortDirection.Ascending, Type.GetType("System.Int32"));
        }

        #endregion Methods

        #region Commands
        void CommandProyectoGeoreferenciacionEdit()
        {
            ProyectoGeoreferenciacionSetValue();
            ModalPopupExtenderGeoreferenciaciones.Show();
            upGeoreferenciacionesPopUp.Update();
        }
        void CommandProyectoGeoreferenciacionSave()
        {
             if (ActualProyectoGeoreferenciacion.Puntos.Count > 0 &&
                (rbPunto.Checked || rbLinea.Checked || rbPoligono.Checked))
             {
                 ProyectoGeoreferenciacionGetValue();
                 ProyectoGeoreferenciacionResult result = (from l in Entity.Georeferenciaciones
                                                           where l.IdProyectoGeoreferenciacion == ActualProyectoGeoreferenciacion.ID                                                          
                                                           select l).FirstOrDefault();
                 // Reasigna el orden a los puntos
                 int i = 0;
                 ActualProyectoGeoreferenciacion.Puntos.Sort(delegate(GeoreferenciacionPuntoResult p1, GeoreferenciacionPuntoResult p2) { return p1.Orden.CompareTo(p2.Orden); });
                 foreach(GeoreferenciacionPuntoResult pr in ActualProyectoGeoreferenciacion.Puntos)  
                 {
                     i++;
                     pr.Orden = i;                    
                 }

                 string msgErr = "";
                 if (ValidaGeoreferenciacion(ref msgErr))
                 {
                     if (result != null)
                     {
                         result.Georeferenciacion = ActualProyectoGeoreferenciacion.Georeferenciacion;
                         result.Puntos = ActualProyectoGeoreferenciacion.Puntos;
                     }
                     else
                     {
                         Entity.Georeferenciaciones.Add(ActualProyectoGeoreferenciacion);
                     }
                     ProyectoGeoreferenciacionClear();
                     ProyectoGeoreferenciacionRefresh();
                 }
                 else
                 {
                     lblMsjError.Text = msgErr;
                     UIHelper.ShowAlert(msgErr, upGeoreferenciacionesPopUp);
                 }
             }
        }
        void CommandProyectoGeoreferenciacionDelete()
        {
            ProyectoGeoreferenciacionResult result = (from l in Entity.Georeferenciaciones where l.IdProyectoGeoreferenciacion == ActualProyectoGeoreferenciacion.ID select l).FirstOrDefault();
            Entity.Georeferenciaciones.Remove(result);
            ProyectoGeoreferenciacionClear();
            ProyectoGeoreferenciacionRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveGeoreferenciacion_Click(object sender, EventArgs e)
        {
            lblMsjError.Text = "";
            CallTryMethod(CommandProyectoGeoreferenciacionSave);
            if(lblMsjError.Text == "")
                HidePopUpGeoreferenciaciones();
        }
        protected void btNewGeoreferenciacion_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoGeoreferenciacionSave);
        }
        protected void btCancelGeoreferenciacion_Click(object sender, EventArgs e)
        {
            ProyectoGeoreferenciacionClear();
            HidePopUpGeoreferenciaciones();
        }
        protected void btAgregarGeoreferenciacion_Click(object sender, EventArgs e)
        {
            lblMsjError.Text = "";
            ProyectoGeoreferenciacionClear();
            txtDescricpion.Focus();

            ModalPopupExtenderGeoreferenciaciones.Show();
        }

        protected void btAgregarPunto_Click(object sender, EventArgs e)
        {
             if (ValidaAltaPuntos())
             {
                 GeoreferenciacionPuntoResult np = GetNewGeoreferenciacionPunto();
                 np.Orden = Int32.Parse(txtOrden.Text);
                 np.Latitud = decimal.Parse(txtLatitud.Text);
                 np.Longitud = decimal.Parse(txtLongitud.Text);
                 np.IdGeoreferenciacion = ActualProyectoGeoreferenciacion.IdGeoreferenciacion;
                 ActualProyectoGeoreferenciacion.Puntos.Add(np);
                 LoadGridPuntos();
                 ManejarControles();
             }
        }
        protected void btDeletePunto_Click(object sender, EventArgs e)
        {
            GeoreferenciacionPuntoResult p = (from d in ActualProyectoGeoreferenciacion.Puntos
                                              where d.IdGeoreferenciacionPunto.ToString() == ((ImageButton)sender).CommandArgument
                                              select d).FirstOrDefault();
            ActualProyectoGeoreferenciacion.Puntos.Remove(p);
            LoadGridPuntos();
            ManejarControles();
        }
        protected void rbGeoTipo_OnCheckedChanged(object sender, EventArgs e)
        {
             ActualProyectoGeoreferenciacion.Georeferenciacion.IdGeoreferenciacionTipo = rbPunto.Checked ? (int)GeoreferenciacionTipoEnum.Punto :
                                                                      rbLinea.Checked ? (int)GeoreferenciacionTipoEnum.Linea :
                                                                                        (int)GeoreferenciacionTipoEnum.Poligono;
             ManejarControles();      
        }
        #endregion

        #region EventosGrillas

        protected void GridGeoreferenciaciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoGeoreferenciacion = (from l in Entity.Georeferenciaciones where l.IdProyectoGeoreferenciacion == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoGeoreferenciacionEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoGeoreferenciacionDelete();
                    break;
            }
        }
        protected virtual void GridGeoreferenciaciones_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridGeoreferenciaciones.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridGeoreferenciaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridGeoreferenciaciones.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion Georeferenciacion
    }
}
