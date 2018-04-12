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
    public partial class ProyectoAdjuntarEdit : WebControlEdit<nc.ProyectoFilesCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            diFecha.Width = 80;
            diFecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");
            PopUpProyectoFiles.Attributes.CssStyle.Add("display", "none");
            revMarcoLegal.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            revInfoAdicional.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            revMarcoLegal.ErrorMessage = TranslateFormat("InvalidField", "Marco Legal");
            revInfoAdicional.ErrorMessage = TranslateFormat("InvalidField", "Información adicional");

            pnProyectoFiles.ToolTip = Translate("TooltipArchivosAdjuntos");
            pnlMarcoLegal.ToolTip = Translate("TooltipMarcoLegal");
            pnlInfoAdicional.ToolTip = Translate("TooltipOtraInformacionAdicional");
        }
        public override void Clear()
        {
            UIHelper.Clear(tbNombre);
            tbNombre.Focus();
            UIHelper.Clear(diFecha);
            UIHelper.Clear(txtMarcoLegal);
            UIHelper.Clear(txtInfoAdicional);
        }
        public override void GetValue()
        {
            Entity.Evaluacion.MarcoLegal = UIHelper.GetString(txtMarcoLegal);
            Entity.Evaluacion.InfoAdicional = UIHelper.GetString(txtInfoAdicional);
            ProyectoEvaluacionService.Current.Save(Entity.Evaluacion.ToEntity(), UIContext.Current.ContextUser);
        }
        public override void SetValue()
        {
            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
            var pes = ProyectoEvaluacionService.Current.GetResult(new nc.ProyectoEvaluacionFilter() { Id_Proyecto = Entity.IdProyecto }).FirstOrDefault();
            if (pes != null)
            {
                Entity.Evaluacion = pes;
                UIHelper.SetValue(txtMarcoLegal, Entity.Evaluacion.MarcoLegal);
                UIHelper.SetValue(txtInfoAdicional, Entity.Evaluacion.InfoAdicional);
            }
            ProyectoFileRefresh();
            upMarcoLegal.Update();
            upInfoAdicional.Update();
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
        //        this.pnlProyectoFiles.Enabled = false;    
        //    }
        //    else
        //    {
        //        //EnableSolapa = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);                
        //    }

        //    //Inhabilito todos los componenetes de la Solapa
        //    //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;            
        //}
        //#endregion
        //FinMatias 20170210 - Ticket #REQ768159

        private ProyectoFileResult actualProyectoFile;
        protected ProyectoFileResult ActualProyectoFile
        {
            get
            {
                if (actualProyectoFile == null)
                {
                    if (ExistsPersist("actualProyectoFile"))
                        actualProyectoFile = ((ProyectoFileResult)GetPersist("actualProyectoFile"));
                    else
                    {
                        actualProyectoFile = GetNewProyectoFile();
                        SetPersist("actualProyectoFile", actualProyectoFile);
                    }
                }
                return actualProyectoFile;
            }
            set
            {
                actualProyectoFile = value;
                SetPersist("actualProyectoFile", value);
            }
        }
        ProyectoFileResult GetNewProyectoFile()
        {
            int id = 0;
            if (Entity.ProyectoFiles.Count > 0) id = Entity.ProyectoFiles.Min(l => l.IdProyectoFile);
            if (id > 0) id = 0;
            id--;
            ProyectoFileResult plResult = new ProyectoFileResult();
            plResult.IdProyectoFile = id;
            plResult.IdProyecto = Entity.IdProyecto;
            return plResult;
        }

        #region Methods
        void HidePopUpProyectoFiles()
        {
            ModalPopupExtenderProyectoFiles.Hide();
        }
        void ProyectoFileClear()
        {
            ActualProyectoFile = GetNewProyectoFile();
            UIHelper.Clear(tbNombre);
            UIHelper.SetValue(diFecha,DateTime.Now);
            UIHelper.SetValue(lblError, "");
        }
        void ProyectoFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            UIHelper.SetValue(tbNombre, ActualProyectoFile.File_FileName);
            UIHelper.SetValue(diFecha, ActualProyectoFile.File_Date);
            fuArchivo.Focus();
        }
        void ProyectoFileGetValue()
        {
            if (fuArchivo.IsFileSelected)
            {
                if (tbNombre.Text != "")
                {
                    // Le agrega la extención del archivo
                    string[] partes = fuArchivo.GetNewFileName().Split('.');
                    fuArchivo.FileName = tbNombre.Text + "." + partes[partes.Length-1];
                }
                fuArchivo.Date = (! diFecha.IsValidEmpty) ? UIHelper.GetDateTime(diFecha) : DateTime.Now;
                ActualProyectoFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualProyectoFile.IdProyecto = Entity.IdProyecto;
                ActualProyectoFile.File_Date = fuArchivo.Date;
                ActualProyectoFile.File_FileName = fuArchivo.FileName;
            }
        }
        void ProyectoFileRefresh()
        {
            UIHelper.Load(gridProyectoFiles, Entity.ProyectoFiles, "Order");
            upGridProyectoFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoFileEdit()
        {
            ProyectoFileSetValue();
            ModalPopupExtenderProyectoFiles.Show();
            upProyectoFilesPopUp.Update();
        }
        void CommandProyectoFileSave()
        {
            if (fuArchivo.IsFileSelected)
            {
                ProyectoFileGetValue();
                ProyectoFileResult result = (from l in Entity.ProyectoFiles
                                                where l.IdProyectoFile == ActualProyectoFile.ID
                                                select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdProyectoFile = ActualProyectoFile.IdProyectoFile;
                    result.IdFile = ActualProyectoFile.IdFile;
                    result.IdProyecto = ActualProyectoFile.IdProyecto;
                    result.File_Date = ActualProyectoFile.File_Date;
                    result.File_FileName = ActualProyectoFile.File_FileName;
                }
                else
                {
                    Entity.ProyectoFiles.Add(ActualProyectoFile);
                }
                ProyectoFileClear();
                ProyectoFileRefresh();

            }
            else
            {
                lblError.Text = TranslateFormat("FieldIsNull", "Archivo");
                upProyectoFilesPopUp.Update();
            }
        }
        void CommandProyectoFileDelete()
        {
            ProyectoFileResult result = (from l in Entity.ProyectoFiles where l.IdProyectoFile == ActualProyectoFile.ID select l).FirstOrDefault();
            Entity.ProyectoFiles.Remove(result);
            ProyectoFileClear();
            ProyectoFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveProyectoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoFileSave);
            ProyectoFileClear();
            if(lblError.Text=="")
                HidePopUpProyectoFiles();
            else
                ModalPopupExtenderProyectoFiles.Show();
        }
        protected void btNewProyectoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoFileSave);
            ModalPopupExtenderProyectoFiles.Show();
        }
        protected void btCancelProyectoFile_Click(object sender, EventArgs e)
        {
            ProyectoFileClear();
            HidePopUpProyectoFiles();
        }
        protected void btAgregarProyectoFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderProyectoFiles.Show();
            UIHelper.SetValue(diFecha, DateTime.Now);
        }
        #endregion

        #region EventosGrillas
        protected void GridProyectoFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridProyectoFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.ProyectoFiles.Where(x => x.IdProyectoFile == idRow).Single().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridProyectoFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoFile = (from l in Entity.ProyectoFiles where l.IdProyectoFile == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoFileEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoFileDelete();
                    break;
            }
        }
        protected virtual void GridProyectoFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoFiles.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion
    }
}