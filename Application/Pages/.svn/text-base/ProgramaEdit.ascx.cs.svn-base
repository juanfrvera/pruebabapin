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

    public partial class ProgramaEdit : WebControlEdit<nc.ProgramaCompose>
    { 
		protected override void _Initialize()
        {
            base._Initialize();

            UIHelper.Load<nc.SafResult>(ddlSAF, SafService.Current.GetResultFromList(new Contract.SafFilter() { Activo = true }), "CodigoDenominacion", "IdSaf", new nc.SafResult() { IdSaf = 0, CodigoDenominacion = "Seleccione Saf" });
			
            revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(3);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            
            
            revDatosGeneralesDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(255);
            revDatosGeneralesDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvDatosGeneralesDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
                                  
            rfvSAF.ErrorMessage = TranslateFormat("FieldIsNull", "SAF");
            //diFechaAlta.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Alta");

            revSubProgramaDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(255);
            revSubProgramaDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvSubProgramaDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");

            revSubProgramaCodigo.ValidationExpression = Contract.DataHelper.GetExpRegString(3);
            revSubProgramaCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvSubProgramaCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");

            UIHelper.Load<UsuarioResult>(ddlSectorialista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Sectorialista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            //rfvSectorialista.ErrorMessage = TranslateFormat("FieldIsNull", "Sectorialista");

            pnlDatosGenerales.Enabled = Can(Entity, ActionConfig.SAVE );
        }
        
		public override void Clear()
        {	
		    
			UIHelper.Clear(ddlSAF);			
            UIHelper.Clear(txtCodigo);
			UIHelper.Clear(txtDatosGeneralesDenominacion);
            UIHelper.Clear(ddlSectorialista);
            UIHelper.Clear(chkActivo);
			//UIHelper.Clear(diFechaAlta);
			//UIHelper.Clear(diFechaBaja);
			//UIHelper.Clear(chkActivo);
            ddlSAF.Focus();
            udpDatosGenerales.Update();
        }		
		public override void SetValue()
        {
            UIHelper.SetValue<Saf,int>(ddlSAF,Entity.Programa.IdSAF,SafService.Current.GetById);
			ddlSAF.Focus();
            UIHelper.SetValue(txtCodigo, Entity.Programa.Codigo);
            UIHelper.SetValue(txtDatosGeneralesDenominacion, Entity.Programa.Nombre);
            UIHelper.SetValue(ddlSectorialista, Entity.Programa.IdSectorialista);
            UIHelper.SetValue(chkActivo, Entity.Programa.Activo);
            //UIHelper.SetValue(diFechaAlta, Entity.Programa.FechaAlta);
            //UIHelper.SetValue(diFechaBaja, Entity.Programa.FechaBaja);
			//UIHelper.SetValue(chkActivo, Entity.Activo);
            SubProgramasRefresh();
            udpDatosGenerales.Update();
				
        }	
        public override void GetValue()
        {

            Entity.Programa.IdSAF = UIHelper.GetInt(ddlSAF);
            Entity.Programa.Codigo = UIHelper.GetString(txtCodigo);
            Entity.Programa.Nombre = UIHelper.GetString(txtDatosGeneralesDenominacion);
            Entity.Programa.IdSectorialista = UIHelper.GetIntNullable(ddlSectorialista);
            Entity.Programa.Activo = UIHelper.GetBoolean(chkActivo);
            //Entity.Programa.FechaAlta = UIHelper.GetDateTime(diFechaAlta);
            //Entity.Programa.FechaBaja = UIHelper.GetDateTimeNullable(diFechaBaja);
			//Entity.Activo=UIHelper.GetBoolean(chkActivo);
			
        }



        protected virtual void GridSubprogramas_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridSubProgramas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridSubprogramas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridSubProgramas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }


        #region SubProgramas

        private SubProgramaResult actualSubPrograma;
        protected SubProgramaResult ActualSubPrograma
        {
            get
            {
                if (actualSubPrograma == null)
                    if (ViewState["actualSubPrograma"] != null)
                        actualSubPrograma = ViewState["actualSubPrograma"] as SubProgramaResult;
                    else
                    {
                        actualSubPrograma = GetNewSubPrograma();
                        ViewState["actualSubPrograma"] = actualSubPrograma;
                    }
                return actualSubPrograma;
            }
            set
            {
                actualSubPrograma = value;
                ViewState["actualSubPrograma"] = value;
            }
        }
        SubProgramaResult GetNewSubPrograma()
        {
            int id = 0;
            if (Entity.SubProgramas.Count > 0) id = Entity.SubProgramas.Min(l => l.IdSubPrograma);
            if (id > 0) id = 0;
            id--;
            SubProgramaResult sbr = new SubProgramaResult ();
            SubProgramaService.Current.Set (  SubProgramaService.Current.GetNew(),sbr) ;
            sbr.IdSubPrograma = id;
            sbr.IdPrograma = Entity.IdPrograma;
            return sbr;
        }

        #region Methods
        void HidePopUpSubProgramas()
        {
            ModalPopupExtenderSubProgramas.Hide();
        }
        void SubProgramasClear()
        {
            UIHelper.Clear(txtSubProgramaCodigo);
            UIHelper.Clear(txtSubProgramaDenominacion);
            ActualSubPrograma = GetNewSubPrograma();
        }
        void SubProgramasSetValue()
        {
            UIHelper.SetValue(txtSubProgramaCodigo, ActualSubPrograma.Codigo);
            UIHelper.SetValue(txtSubProgramaDenominacion, ActualSubPrograma.Nombre);
        }
        void SubProgramasGetValue()
        {
            ActualSubPrograma.Codigo = UIHelper.GetString(txtSubProgramaCodigo);
            ActualSubPrograma.Nombre = UIHelper.GetString(txtSubProgramaDenominacion);            
        }
        void SubProgramasRefresh()
        {
            UIHelper.Load(gridSubProgramas, Entity.SubProgramas, "Nombre");
            upGridSubProgramas.Update();
        }
        #endregion Methods

        #region Commands
        void CommandSubProgramaEdit()
        {

            SubProgramasSetValue();
            ModalPopupExtenderSubProgramas.Show();
            upSubProgramasPopUp.Update();

        }
        void CommandSubProgramaSave()
        {

            SubProgramasGetValue();


            SubProgramaResult spr = (from l in Entity.SubProgramas
                                     where l.IdSubPrograma == ActualSubPrograma.ID
                                     select l).FirstOrDefault();

            if (spr != null)
            {
                spr.Nombre = ActualSubPrograma.Nombre;
                spr.Codigo = ActualSubPrograma.Codigo;
                SubProgramasRefresh();
            }
            else
            {

                Entity.SubProgramas.Add(ActualSubPrograma);
            }

            SubProgramasClear();
            SubProgramasRefresh();

        }
        void CommandSubProgramaDelete()
        {

            SubProgramaResult compose = (from l in Entity.SubProgramas
                                         where l.IdSubPrograma == ActualSubPrograma.ID
                                         select l).FirstOrDefault();
            Entity.SubProgramas.Remove(compose);
            SubProgramasClear();
            SubProgramasRefresh();

        }
        #endregion

        #region Eventos
        protected void btSaveSubPrograma_Click(object sender, EventArgs e)
        {

            CallTryMethod(CommandSubProgramaSave);
            HidePopUpSubProgramas();

        }
        protected void btNewSubPrograma_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandSubProgramaSave);
        }
        protected void btCancelSubPrograma_Click(object sender, EventArgs e)
        {
            SubProgramasClear();
            HidePopUpSubProgramas();
        }
        protected void btAgregarSubPrograma_Click(object sender, EventArgs e)
        {
            SubProgramasClear();
            ModalPopupExtenderSubProgramas.Show();
            txtSubProgramaCodigo.Focus();
        }

        #endregion

        #region EventosGrillas
        protected void GridSubProgramas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualSubPrograma = (from l in Entity.SubProgramas
                                 where l.IdSubPrograma == id
                                 select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandSubProgramaEdit();
                    break;
                case Command.DELETE:
                    CommandSubProgramaDelete();
                    break;
            }

        }
        protected virtual void GridSubProgramas_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridSubProgramas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridSubProgramas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridSubProgramas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }





        #endregion

        #endregion SubProgramas




    }
}
