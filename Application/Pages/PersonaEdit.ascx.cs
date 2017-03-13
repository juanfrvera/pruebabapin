using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class PersonaEdit : WebControlEdit<nc.PersonaCompose>
    { 
        #region Override
        protected override void _Load()
        {
            PopUpRolesOficina.Attributes.CssStyle.Add("display", "none");
            toOficina.ValueChanged += new EventHandler(toOficina_ValueChanged);
            base._Load();
        }
        void toOficina_ValueChanged(object sender, EventArgs e)
        {
            
        }
        protected override void _Initialize()
        {
            base._Initialize();
            toOficina.Width=500;
            this.tsAlcanceGeografico.Width = 680;
            revNombre.ValidationExpression = Contract.DataHelper.GetExpRegString(70);
            revApellido.ValidationExpression = Contract.DataHelper.GetExpRegString(70);
            //revIdOficina.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revTelefono.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revTelefonoLaboral.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revFax.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revEMailPersonal.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revEMailLaboral.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revCargoEspecifico.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(150);
            revNivelJerarquico.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revDomicilio.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(150);
            revCodPostal.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(10);
            revNombreUsuario.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            //revSexo.ValidationExpression = Contract.DataHelper.GetExpRegString(1);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revApellido.ErrorMessage = TranslateFormat("InvalidField", "Apellido");
            revTelefono.ErrorMessage = TranslateFormat("InvalidField", "Teléfono");
            revTelefonoLaboral.ErrorMessage = TranslateFormat("InvalidField", "Teléfono Laboral");
            revFax.ErrorMessage = TranslateFormat("InvalidField", "Fax");
            revEMailPersonal.ErrorMessage = TranslateFormat("InvalidField", "Email Personal");
            revEMailLaboral.ErrorMessage = TranslateFormat("InvalidField", "Email Laboral");
            revCargoEspecifico.ErrorMessage = TranslateFormat("InvalidField", "Cargo Específico");
            revNivelJerarquico.ErrorMessage = TranslateFormat("InvalidField", "Nivel Jerárquico");
            revDomicilio.ErrorMessage = TranslateFormat("InvalidField", "Domicilio");
            revCodPostal.ErrorMessage = TranslateFormat("InvalidField", "Código Postal");
            revNombreUsuario.ErrorMessage = TranslateFormat("InvalidField", "Nombre del Usuario");

            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvApellido.ErrorMessage = TranslateFormat("FieldIsNull", "Apellido");
            rfvTelefonoLaboral.ErrorMessage = TranslateFormat("FieldIsNull","Teléfono Laboral");
            rfvRol.ErrorMessage = TranslateFormat("FieldIsNull", "Rol");
            rfvCargo.ErrorMessage = TranslateFormat("FieldIsNull", "Cargo");
            rfvLanguage.ErrorMessage = TranslateFormat("FieldIsNull", "Lenguaje");

            
            toOficina.RequiredMessage = TranslateFormat("FieldIsNull", "Oficina");

            UIHelper.Load<nc.PerfilResult>(ddlRol, PerfilService.Current.GetResult(new nc.PerfilFilter() { Activo = true , IdPerfilTipo = (short)PerfilTipoEnum.Oficina  }), "Nombre", "IdPerfil" ,new nc.PerfilResult() { IdPerfil= 0, Nombre = "Seleccione Perfil" });
            UIHelper.Load(ddlLanguage, LanguageService.Current.GetResult(), "Name", "IdLanguage", new nc.LanguageResult () { IdLanguage= 0, Name = "Seleccione Lenguaje" });
            UIHelper.Load(ddlCargo, CargoService.Current.GetResult(new nc.CargoFilter() { Activo = true }), "Nombre", "IdCargo", new nc.CargoResult() { IdCargo= 0, Nombre = "Seleccione Cargo" });
            //UIHelper.Load<nc.ClasificacionGeografica>(ddlProvincia, ClasificacionGeograficaService.Current.GetList(), "Nombre", "IdClasificacionGeografica", new nc.ClasificacionGeografica() { IdClasificacionGeografica = 0, Nombre = "Seleccione Clasificacion Geografica" });
            //UIHelper.Load<nc.ClasificacionGeografica>(ddlLocalidad, ClasificacionGeograficaService.Current.GetList(), "Nombre", "IdClasificacionGeografica", new nc.ClasificacionGeografica() { IdClasificacionGeografica = 0, Nombre = "Seleccione Clasificacion Geografica" });


            if (!CanByUser(SistemaEntidadConfig.USUARIO, ActionConfig.UPDATE))
            {
                chkContacto.Checked = true;
                chkEsUsuario.Enabled = false;
            }
            else
            {
                chkEsUsuario.Checked = true;
            }
        }
        public override void Clear()
        {
            UsuarioClear();
            //UIHelper.Clear(chkEsUsuario);
            //chkEsUsuario.Focus();
            UIHelper.Clear(chkUsuarioSectorialista);
            UIHelper.Clear(txtNombre);
            UIHelper.Clear(txtApellido);
            //UIHelper.Clear(txtNombreCompleto);
            //UIHelper.Clear(txtIdOficina);
            UIHelper.Clear(toOficina);
            UIHelper.Clear(ddlCargo);
            UIHelper.Clear(txtTelefono);
            UIHelper.Clear(txtTelefonoLaboral);
            UIHelper.Clear(txtFax);
            UIHelper.Clear(txtEMailPersonal);
            UIHelper.Clear(txtEMailLaboral);
            UIHelper.Clear(txtCargoEspecifico);
            UIHelper.Clear(txtNivelJerarquico);
            UIHelper.Clear(txtDomicilio);
            UIHelper.Clear(txtCodPostal);
            //UIHelper.Clear(ddlProvincia);
            //UIHelper.Clear(ddlLocalidad);
            UIHelper.Clear(tsAlcanceGeografico as IWebControlTreeSelect);
            //UIHelper.Clear(ddlSexo);
            UIHelper.Clear(rbFemenino);
            UIHelper.Clear(rbMasculino);
            UIHelper.Clear(chkEsUsuario);
            UIHelper.Clear(chkEnviarMail);
            UIHelper.Clear(chkEnviarNota);
            //UIHelper.Clear(diFechaAlta);
            //UIHelper.Clear(diFechaBaja);
            UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkContacto);
            //UIHelper.Clear(diFechaUltMod);
            //UIHelper.Clear(txtIdUsuarioUltMod);
            UsuarioOficinaPerfilClear();
            
            UIHelper.Clear(dlPerfiles );

            UpdatePanels();

        }
        public override void SetValue()
        {
            if (CrudAction == CrudActionEnum.Create)
            {
                SeleccionarPerfilDefault();
                tcContainer.ActiveTabIndex = 0;
            }
            UIHelper.SetValue(chkUsuarioSectorialista, Entity.Usuario.EsSectioralista);
            //chkEsUsuario.Focus();
            UIHelper.SetValue(chkContacto, Entity.Persona.EsContacto);
            UIHelper.SetValue(txtNombre, Entity.Persona.Nombre);
            txtNombre.Focus();
            UIHelper.SetValue(txtApellido, Entity.Persona.Apellido);
            //UIHelper.SetValue(txtNombreCompleto, Entity.Persona.NombreCompleto);
            //UIHelper.SetValue(txtIdOficina, Entity.Persona.IdOficina);
            UIHelper.SetValue(toOficina as IWebControlTreeSelect, Entity.Persona.IdOficina);
            if(Entity.Persona.IdCargo.HasValue)
                UIHelper.SetValue<Cargo,int>(ddlCargo, Entity.Persona.IdCargo.Value, CargoService.Current.GetById);
            UIHelper.SetValue(txtTelefono, Entity.Persona.Telefono);
            UIHelper.SetValue(txtTelefonoLaboral, Entity.Persona.TelefonoLaboral);
            UIHelper.SetValue(txtFax, Entity.Persona.Fax);
            UIHelper.SetValue(txtEMailPersonal, Entity.Persona.EMailPersonal);
            UIHelper.SetValue(txtEMailLaboral, Entity.Persona.EMailLaboral);
            UIHelper.SetValue(txtCargoEspecifico, Entity.Persona.CargoEspecifico);
            UIHelper.SetValue(txtNivelJerarquico, Entity.Persona.NivelJerarquico);
            UIHelper.SetValue(txtDomicilio, Entity.Persona.Domicilio);
            UIHelper.SetValue(txtCodPostal, Entity.Persona.CodPostal);
            UIHelper.SetValue(tsAlcanceGeografico as IWebControlTreeSelect, Entity.Persona.IdClasificacionGeografica);
            //UIHelper.SetValue(ddlProvincia, Entity.Persona.IdProvincia);
            //UIHelper.SetValue(ddlLocalidad, Entity.Persona.IdLocalidad);
            //UIHelper.SetValue(txtSexo, Entity.Persona.Sexo);
            //UIHelper.SetValue(ddlSexo , Entity.Persona.Sexo);
            UIHelper.SetValue (rbFemenino, Entity.Persona.Sexo_Femenino);
            UIHelper.SetValue(rbMasculino, Entity.Persona.Sexo_Masculino);
            UIHelper.SetValue(chkEnviarMail, Entity.Persona.EnviarEMail);
            UIHelper.SetValue(chkEnviarNota, Entity.Persona.EnviarNota);
            //UIHelper.SetValue(diFechaAlta, Entity.Persona.FechaAlta);
            //UIHelper.SetValue(diFechaBaja, Entity.Persona.FechaBaja);
            UIHelper.SetValue(chkActivo, Entity.Persona.Activo);
            //UIHelper.SetValue(diFechaUltMod, Entity.Persona.FechaUltMod);
            //UIHelper.SetValue(txtIdUsuarioUltMod, Entity.Persona.IdUsuarioUltMod);
            UIHelper.SetValue(chkEsUsuario, Entity.Persona.EsUsuario);

            VisibilidadUsuario(); //Matias 20131211 - Tarea 99
            
            if (Entity.Persona.EsUsuario)
            {
                //VisibilidadUsuario(); Matias 20131211 - Tarea 99
                UsuarioSetValue();
                UsuarioOficinaPerfilRefresh();
                UIHelper.Sort(Entity.UsuarioPerfiles, "Perfil_Nombre");
            }

            UIHelper.SetValue(dlPerfiles, Entity.UsuarioPerfiles);
            HabilitarChecksContacto();
        }

        
        public override void GetValue()
        {
            Entity.Persona.EsContacto = UIHelper.GetBoolean(chkContacto);
            Entity.Persona.Nombre = UIHelper.GetString(txtNombre);
            Entity.Persona.Apellido = UIHelper.GetString(txtApellido);
            //Entity.Persona.NombreCompleto = UIHelper.GetString(txtNombreCompleto);
            //Entity.Persona.IdOficina = UIHelper.GetInt(txtIdOficina);
            Entity.Persona.IdOficina = UIHelper.GetInt(toOficina as IWebControlTreeSelect);
            Entity.Persona.IdCargo = UIHelper.GetIntNullable(ddlCargo);
            Entity.Persona.Telefono = UIHelper.GetString(txtTelefono);
            Entity.Persona.TelefonoLaboral = UIHelper.GetString(txtTelefonoLaboral);
            Entity.Persona.Fax = UIHelper.GetString(txtFax);
            Entity.Persona.EMailPersonal = UIHelper.GetString(txtEMailPersonal);
            Entity.Persona.EMailLaboral = UIHelper.GetString(txtEMailLaboral);
            Entity.Persona.CargoEspecifico = UIHelper.GetString(txtCargoEspecifico);
            Entity.Persona.NivelJerarquico = UIHelper.GetString(txtNivelJerarquico);
            Entity.Persona.Domicilio = UIHelper.GetString(txtDomicilio);
            Entity.Persona.CodPostal = UIHelper.GetString(txtCodPostal);

            Entity.Persona.IdClasificacionGeografica = UIHelper.GetIntNullable(tsAlcanceGeografico as IWebControlTreeSelect);
            Entity.Persona.NombreCompleto = UIHelper.GetString(txtApellido)+ ", " + UIHelper.GetString(txtNombre);
            //Entity.Persona.IdProvincia = UIHelper.GetIntNullable(ddlProvincia);
            //Entity.Persona.IdLocalidad = UIHelper.GetIntNullable(ddlLocalidad);
            //Entity.Persona.Sexo = UIHelper.GetString (ddlSexo );
            Entity.Persona.Sexo_Femenino = UIHelper.GetBoolean(rbFemenino);
            Entity.Persona.Sexo_Masculino = UIHelper.GetBoolean(rbMasculino);
            Entity.Persona.EnviarEMail = UIHelper.GetBoolean(chkEnviarMail);
            Entity.Persona.EnviarNota = UIHelper.GetBoolean(chkEnviarNota);
            //Entity.Persona.FechaAlta = UIHelper.GetDateTime(diFechaAlta);
            //Entity.Persona.FechaBaja = UIHelper.GetDateTimeNullable(diFechaBaja);
            Entity.Persona.Activo = UIHelper.GetBoolean(chkActivo);
            Entity.Persona.EsUsuario = UIHelper.GetBoolean(chkEsUsuario);
            //Entity.Persona.FechaUltMod = UIHelper.GetDateTime(diFechaUltMod);
            //Entity.Persona.IdUsuarioUltMod = UIHelper.GetInt(txtIdUsuarioUltMod);
            if (Entity.Persona.EsUsuario)
            {
                UsuarioGetValue();
                Entity.Usuario = ActualUsuario; 
                Update(dlPerfiles , Entity.UsuarioPerfiles );
            }

        }
        #endregion
        #region Events

        protected void chkEsUsuario_CheckedChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(VisibilidadUsuario);
        }

        protected void chkContacto_CheckedChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(HabilitarChecksContacto);
        }
        protected void toOficina_OnChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(OficinaOnChanged);
        }
 
        #endregion
        #region private Methods
        private void VisibilidadUsuario()
        {
            bool Visibilidad = UIHelper.GetBoolean(chkEsUsuario);
            if(Visibilidad)
                tpDatosUsuario.Enabled = CanByUser(SistemaEntidadConfig.USUARIO, ActionConfig.READ);
            else
                tpDatosUsuario.Enabled  = false;

            tpDatosUsuario.Visible = Visibilidad; //Matias 20131211 - Tarea 99

            //pnlRoles.Visible = Visibilidad;
        }
        private void HabilitarChecksContacto()
        {
            bool Habilitar = UIHelper.GetBoolean(chkContacto);
            if(! Habilitar)
            {
                chkEnviarMail.Checked = false;
                chkEnviarNota.Checked = false;
            }
            chkEnviarMail.Enabled = Habilitar;
            chkEnviarNota.Enabled = Habilitar;
        }
        private void OficinaOnChanged()
        {
            //Probar
           if(UIHelper.GetBoolean(chkEsUsuario))
            {
                List<PerfilResult> prl = PerfilService.Current.GetResult(new nc.PerfilFilter() { EsDefault = true, IdPerfilTipo = (Int32)PerfilTipoEnum.Oficina });

               

               foreach (PerfilResult pr in prl)
                {;
                    ActualUsuarioOficinaPerfil.IdOficina = UIHelper.GetInt(toOficina);
                    ActualUsuarioOficinaPerfil.IdPerfil = pr.IdPerfil;
                    ActualUsuarioOficinaPerfil.HeredaConsulta = true;
                    ActualUsuarioOficinaPerfil.HeredaEdicion = false; ;
                    ActualUsuarioOficinaPerfil.AccesoTotal = false;
                    ActualUsuarioOficinaPerfil.AgregadoPorDefault = true;
                    UsuarioOficinaPerfilSetValue();
                    CommandUsuarioOficinaPerfilSave();
                }
            }
        }
        private void Update(DataList dataList, List<UsuarioPerfilResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                UsuarioPerfilResult item = (from o in list where o.IdPerfil == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }
        private void SeleccionarPerfilDefault()
        {
     
            
            ( from o in Entity.UsuarioPerfiles 
              where //( from p in perfiles select p.IdPerfil ).Contains (o.IdPerfil )
                (from p in PerfilService.Current.GetResult(new nc.PerfilFilter() { Activo = true, EsDefault = true, IdPerfilTipo = (Int32)PerfilTipoEnum.Sistema })
                 select p.IdPerfil).Contains (o.IdPerfil.Value )
              select o
                  ).Each( i=> i.Selected = true ) ;

            

        }
        private void UpdatePanels()
        {
            upDatosGenerales.Update();
            upDomicilio.Update();
            upPnlChecks.Update();
            upDatosLaborales.Update();
            upDatosUsuario.Update();
            upRolesOficinaPopUp.Update();
            upRoles.Update();
            upGridRoles.Update();
        }
        #endregion
        #region User
        private UsuarioResult actualUsuario;
        protected UsuarioResult ActualUsuario
        {
            get
            {
                if (actualUsuario == null)
                    if (ViewState["actualUsuario"] != null)
                        actualUsuario = ViewState["actualUsuario"] as UsuarioResult;
                    else
                    {
                        actualUsuario = GetNewUsuario();
                        ViewState["actualUsuario"] = actualUsuario;
                    }
                return actualUsuario;
            }
            set
            {
                actualUsuario = value;
                ViewState["actualUsuario"] = value;
            }
        }
        UsuarioResult  GetNewUsuario()
        {
            int id = 0;
            id = Entity.Usuario!=null? Entity.Usuario.IdUsuario :0;
            if (id > 0) id = 0;
            id--;
            UsuarioResult usuarioResult = new UsuarioResult();
            UsuarioService.Current.Set(UsuarioService.Current.GetNew(), usuarioResult);
            usuarioResult.IdUsuario = id;
            return usuarioResult;
        }
        #region Clear SetValue GetValue Refresh
        void UsuarioClear()
        {

            UIHelper.Clear(txtNombreUsuario );
            UIHelper.Clear(txtClave );
            UIHelper.Clear(ddlLanguage);
            UIHelper.Clear(chkUsuarioActivo);
            UIHelper.Clear(chkUsuarioAccesoTotal);
            ActualUsuario = GetNewUsuario();
            txtNombreUsuario.Focus();
        }
        void UsuarioSetValue()
        {
            ActualUsuario = Entity.Usuario;
            UIHelper.SetValue(txtNombreUsuario, ActualUsuario.NombreUsuario);
            UIHelper.SetValue(txtClave, ActualUsuario.Clave);
            UIHelper.SetValue(ddlLanguage, ActualUsuario.IdLanguage);
            UIHelper.SetValue(chkUsuarioActivo, ActualUsuario.Activo );
            UIHelper.SetValue(chkUsuarioAccesoTotal, ActualUsuario.AccesoTotal);
            if (CrudAction == CrudActionEnum.Create)
            {
                UIHelper.SetValue(ddlLanguage, UIContext.Current.DefaultLanguage.IdLanguage);
            }
        }
        void UsuarioGetValue()
        {

            ActualUsuario.EsSectioralista = UIHelper.GetBoolean(chkUsuarioSectorialista);
            ActualUsuario.NombreUsuario= UIHelper.GetString(txtNombreUsuario);
            ActualUsuario.Clave  = UIHelper.GetString(txtClave );
            ActualUsuario.IdLanguage  = UIHelper.GetInt(ddlLanguage );
            ActualUsuario.Activo = UIHelper.GetBoolean(chkUsuarioActivo);
            ActualUsuario.AccesoTotal = UIHelper.GetBoolean(chkUsuarioAccesoTotal);
        }
        void UsuarioRefresh()
        {
            
        }
        #endregion

        #region Commands
        
        #endregion
        #region Events
        
        #endregion
        #endregion
        #region RolesOficina
        private UsuarioOficinaPerfilResult actualUsuarioOficinaPerfil;
        protected UsuarioOficinaPerfilResult ActualUsuarioOficinaPerfil
        {
            get
            {
                if (actualUsuarioOficinaPerfil == null)
                    if (ViewState["actualUsuarioOficinaPerfil"] != null)
                        actualUsuarioOficinaPerfil = ViewState["actualUsuarioOficinaPerfil"] as UsuarioOficinaPerfilResult;
                    else
                    {
                        actualUsuarioOficinaPerfil = GetNewUsuarioOficinaPerfil();
                        ViewState["actualUsuarioOficinaPerfil"] = actualUsuarioOficinaPerfil;
                    }
                return actualUsuarioOficinaPerfil;
            }
            set
            {
                actualUsuarioOficinaPerfil = value;
                ViewState["actualUsuarioOficinaPerfil"] = value;
            }
        }
        UsuarioOficinaPerfilResult GetNewUsuarioOficinaPerfil()
        {
            int id = 0;
            if (Entity.UsuarioOficinaPerfiles.Count > 0) id = Entity.UsuarioOficinaPerfiles.Min(o => o.IdUsuarioOficinaPerfil );
            if (id > 0) id = 0;
            id--;
            UsuarioOficinaPerfilResult uopResult = new UsuarioOficinaPerfilResult();
            UsuarioOficinaPerfilService.Current.Set(UsuarioOficinaPerfilService.Current.GetNew(), uopResult);
            uopResult.IdUsuarioOficinaPerfil = id;
            return uopResult;
        }
        void HidePopUpRolesOficina()
        {
            ModalPopupExtenderRolesOficina.Hide();
        }
        void ShowPopUpRolesOficina()
        {
            ModalPopupExtenderRolesOficina.Show();
            toOficinaPopUp.Focus();
            upRolesOficinaPopUp.Update();
        }
        #region EventosGrillas
  
        protected void GridRoles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualUsuarioOficinaPerfil= (from o in Entity.UsuarioOficinaPerfiles  where o.IdUsuarioOficinaPerfil  == id select o).FirstOrDefault();


                switch (e.CommandName)
                {
                    case Command.EDIT:
                        CommandUsuarioOficinaPerfilEdit();
                        break;
                    case Command.DELETE:
                        CommandUsuarioOficinaPerfilDelete();
                        break;
                }
           
        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridRoles .PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridRoles.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
   
        #endregion
        #region Events
        protected void btSaveRolesOficina_Click(object sender, EventArgs e)
        { 
            UIHelper.CallTryMethod(CommandUsuarioOficinaPerfilSave);
            HidePopUpRolesOficina();
        }
        protected void btNewRolesOficina_Click(object sender, EventArgs e)
        { 
            UIHelper.CallTryMethod(CommandUsuarioOficinaPerfilSave);
        }
        protected void btCancelRolesOficina_Click(object sender, EventArgs e)
        { 
            UsuarioOficinaPerfilClear();
            HidePopUpRolesOficina();
        }
        protected void btAgregarRolOficina_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpRolesOficina);
        }
        #endregion
        #region Commands
        void CommandUsuarioOficinaPerfilEdit()
        {
            UsuarioOficinaPerfilSetValue();
            UIHelper.CallTryMethod(ShowPopUpRolesOficina);
        }
        void CommandUsuarioOficinaPerfilSave()
        {
            UsuarioOficinaPerfilGetValue();
            UsuarioOficinaPerfilResult result = (from o in Entity.UsuarioOficinaPerfiles where o.IdUsuarioOficinaPerfil == ActualUsuarioOficinaPerfil.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.IdOficina = ActualUsuarioOficinaPerfil.IdOficina ;
                result.IdPerfil  = ActualUsuarioOficinaPerfil.IdPerfil;
                result.Oficina_Nombre = ActualUsuarioOficinaPerfil.Oficina_Nombre;
                result.Perfil_Nombre = ActualUsuarioOficinaPerfil.Perfil_Nombre;
                result.HeredaConsulta = ActualUsuarioOficinaPerfil.HeredaConsulta;
                result.HeredaEdicion = ActualUsuarioOficinaPerfil.HeredaEdicion;
                result.AccesoTotal = ActualUsuarioOficinaPerfil.AccesoTotal;
                result.AgregadoPorDefault = ActualUsuarioOficinaPerfil.AgregadoPorDefault;
            }
            else
            {
                Entity.UsuarioOficinaPerfiles.Add(ActualUsuarioOficinaPerfil);

                //Agrego el Perfil asociado a la oficina a los perfiles del sistema
                UsuarioPerfilResult UPR = new UsuarioPerfilResult();
                UPR.IdPerfil = ActualUsuarioOficinaPerfil.IdPerfil;
                UPR.IdUsuario = ActualUsuarioOficinaPerfil.IdUsuario;
                UPR.Perfil_Nombre = ActualUsuarioOficinaPerfil.Perfil_Nombre;
                Entity.UsuarioPerfiles.Add(UPR);
                UIHelper.Sort(Entity.UsuarioPerfiles, "Perfil_Nombre");
                UIHelper.SetValue(dlPerfiles, Entity.UsuarioPerfiles);
            }
            UsuarioOficinaPerfilClear();
            UsuarioOficinaPerfilRefresh();
        }
        void CommandUsuarioOficinaPerfilDelete()
        {
            UsuarioOficinaPerfilResult result = (from o in Entity.UsuarioOficinaPerfiles where o.IdUsuarioOficinaPerfil == ActualUsuarioOficinaPerfil.ID select o).FirstOrDefault();
            Entity.UsuarioOficinaPerfiles.Remove(result);
            UsuarioOficinaPerfilClear();
            UsuarioOficinaPerfilRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void UsuarioOficinaPerfilClear()
        {
            UIHelper.Clear(toOficinaPopUp);
            UIHelper.Clear(ddlRol );
            UIHelper.Clear(chkHeredaConsulta);
            UIHelper.Clear(chkHeredaEdicion);
            UIHelper.Clear(chkAccesoTotal);
            ActualUsuarioOficinaPerfil = GetNewUsuarioOficinaPerfil ();
        }
        void UsuarioOficinaPerfilSetValue()
        {
            UIHelper.SetValue(toOficinaPopUp as IWebControlTreeSelect, ActualUsuarioOficinaPerfil.IdOficina);
            UIHelper.SetValue(ddlRol , ActualUsuarioOficinaPerfil.IdPerfil );
            UIHelper.SetValue(chkHeredaConsulta, ActualUsuarioOficinaPerfil.HeredaConsulta);
            UIHelper.SetValue(chkHeredaEdicion, ActualUsuarioOficinaPerfil.HeredaEdicion);
            UIHelper.SetValue(chkAccesoTotal, ActualUsuarioOficinaPerfil.AccesoTotal);
        }
        void UsuarioOficinaPerfilGetValue()
        {
            Entity.Persona.IdOficina = UIHelper.GetInt(toOficina as IWebControlTreeSelect);
            ActualUsuarioOficinaPerfil.IdOficina = UIHelper.GetInt(toOficinaPopUp as IWebControlTreeSelect);
            ActualUsuarioOficinaPerfil.Oficina_Nombre = UIHelper.GetString(toOficinaPopUp as IWebControlTreeSelect);
            ActualUsuarioOficinaPerfil.IdPerfil = UIHelper.GetInt(ddlRol);
            ActualUsuarioOficinaPerfil.Perfil_Nombre = UIHelper.GetString(ddlRol );
            ActualUsuarioOficinaPerfil.HeredaConsulta = UIHelper.GetBoolean(chkHeredaConsulta);
            ActualUsuarioOficinaPerfil.HeredaEdicion = UIHelper.GetBoolean(chkHeredaEdicion);
            ActualUsuarioOficinaPerfil.AccesoTotal = UIHelper.GetBoolean(chkAccesoTotal);
        }
        void UsuarioOficinaPerfilRefresh()
        {
            UIHelper.Load(gridRoles , Entity.UsuarioOficinaPerfiles);
            upGridRoles.Update();
        }
        #endregion
      
            
        #endregion
    }
}
