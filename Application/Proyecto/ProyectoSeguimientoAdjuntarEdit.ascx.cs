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
    public partial class ProyectoSeguimientoAdjuntarEdit : WebControlEdit<nc.ProyectoSeguimientoFilesCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            diFecha.Width = 80;
            PopUpProyectoSeguimientoFiles.Attributes.CssStyle.Add("display", "none");
        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            ProyectoSeguimientoFileRefresh();
        }
        #endregion Override

        private ProyectoSeguimientoFileResult actualProyectoSeguimientoFile;
        protected ProyectoSeguimientoFileResult ActualProyectoSeguimientoFile
        {
            get
            {
                if (actualProyectoSeguimientoFile == null)
                    if (ViewState["actualProyectoSeguimientoFile"] != null)
                        actualProyectoSeguimientoFile = ViewState["actualProyectoSeguimientoFile"] as ProyectoSeguimientoFileResult;
                    else
                    {
                        actualProyectoSeguimientoFile = GetNewProyectoSeguimientoFile();
                        ViewState["actualProyectoSeguimientoFile"] = actualProyectoSeguimientoFile;
                    }
                return actualProyectoSeguimientoFile;
            }
            set
            {
                actualProyectoSeguimientoFile = value;
                ViewState["actualProyectoSeguimientoFile"] = value;
            }
        }
        ProyectoSeguimientoFileResult GetNewProyectoSeguimientoFile()
        {
            int id = 0;
            if (Entity.ProyectoSeguimientoFiles.Count > 0) id = Entity.ProyectoSeguimientoFiles.Min(l => l.IdProyectoSeguimientoFile);
            if (id > 0) id = 0;
            id--;
            ProyectoSeguimientoFileResult plResult = new ProyectoSeguimientoFileResult();
            plResult.IdProyectoSeguimientoFile = id;
            plResult.IdProyectoSeguimiento = Entity.IdProyectoSeguimiento;
            return plResult;
        }

        #region Methods
        void HidePopUpProyectoSeguimientoFiles()
        {
            ModalPopupExtenderProyectoSeguimientoFiles.Hide();
        }
        void ProyectoSeguimientoFileClear()
        {
            ActualProyectoSeguimientoFile = GetNewProyectoSeguimientoFile();
            UIHelper.Clear(tbNombre);
            UIHelper.SetValue(diFecha,DateTime.Now);
            UIHelper.SetValue(lblError, "");
            upAdjuntar.Update();
        }
        void ProyectoSeguimientoFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            UIHelper.SetValue(tbNombre, ActualProyectoSeguimientoFile.File_FileName);
            UIHelper.SetValue(diFecha, ActualProyectoSeguimientoFile.File_Date);
            fuArchivo.Focus();
        }
        void ProyectoSeguimientoFileGetValue()
        {
            if (fuArchivo.IsFileSelected)
            {
                if (tbNombre.Text != "")
                {
                    // Le agrega la extención del archivo
                    string[] partes = fuArchivo.GetNewFileName().Split('.');
                    fuArchivo.FileName = tbNombre.Text + "." + partes[partes.Length-1];
                }
                fuArchivo.Date = (!diFecha.IsValidEmpty) ? UIHelper.GetDateTime(diFecha) : DateTime.Now;
                ActualProyectoSeguimientoFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualProyectoSeguimientoFile.IdProyectoSeguimiento = Entity.IdProyectoSeguimiento;
                ActualProyectoSeguimientoFile.File_Date = fuArchivo.Date;
                ActualProyectoSeguimientoFile.File_FileName = fuArchivo.FileName;
            }
        }
        void ProyectoSeguimientoFileRefresh()
        {
            UIHelper.Load(gridProyectoSeguimientoFiles, Entity.ProyectoSeguimientoFiles, "Order");
            upGridProyectoSeguimientoFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoSeguimientoFileEdit()
        {
            ProyectoSeguimientoFileSetValue();
            ModalPopupExtenderProyectoSeguimientoFiles.Show();
            upProyectoSeguimientoFilesPopUp.Update();
        }
        void CommandProyectoSeguimientoFileSave()
        {
            if (diFecha.Fecha != null && fuArchivo.IsFileSelected)
            {
                ProyectoSeguimientoFileGetValue();
                ProyectoSeguimientoFileResult result = (from l in Entity.ProyectoSeguimientoFiles
                                             where l.IdProyectoSeguimientoFile == ActualProyectoSeguimientoFile.ID
                                             select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdProyectoSeguimientoFile = ActualProyectoSeguimientoFile.IdProyectoSeguimientoFile;
                    result.IdFile = ActualProyectoSeguimientoFile.IdFile;
                    result.IdProyectoSeguimiento = ActualProyectoSeguimientoFile.IdProyectoSeguimiento;
                    result.File_Date = ActualProyectoSeguimientoFile.Fecha;
                    result.File_FileName = ActualProyectoSeguimientoFile.Nombre;
                }
                else
                {
                    Entity.ProyectoSeguimientoFiles.Add(ActualProyectoSeguimientoFile);
                }
                ProyectoSeguimientoFileClear();
                ProyectoSeguimientoFileRefresh();
            }
            else
            {
                lblError.Text = SolutionContext.Current.TextManager.Translate("Datos obligatorios");
                upProyectoSeguimientoFilesPopUp.Update();
            }
        }
        void CommandProyectoSeguimientoFileDelete()
        {
            ProyectoSeguimientoFileResult result = (from l in Entity.ProyectoSeguimientoFiles where l.IdProyectoSeguimientoFile == ActualProyectoSeguimientoFile.ID select l).FirstOrDefault();
            Entity.ProyectoSeguimientoFiles.Remove(result);
            ProyectoSeguimientoFileClear();
            ProyectoSeguimientoFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveProyectoSeguimientoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoSeguimientoFileSave);
            ProyectoSeguimientoFileClear();
            if(lblError.Text=="")
                HidePopUpProyectoSeguimientoFiles();
            else
                ModalPopupExtenderProyectoSeguimientoFiles.Show();
        }
        protected void btNewProyectoSeguimientoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoSeguimientoFileSave);
            ModalPopupExtenderProyectoSeguimientoFiles.Show();
        }
        protected void btCancelProyectoSeguimientoFile_Click(object sender, EventArgs e)
        {
            ProyectoSeguimientoFileClear();
            HidePopUpProyectoSeguimientoFiles();
        }
        protected void btAgregarProyectoSeguimientoFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderProyectoSeguimientoFiles.Show();
            ProyectoSeguimientoFileClear();
        }
        #endregion

        #region EventosGrillas
        protected void GridProyectoSeguimientoFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridProyectoSeguimientoFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.ProyectoSeguimientoFiles.Where(x => x.IdProyectoSeguimientoFile == idRow).Single().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridProyectoSeguimientoFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoSeguimientoFile = (from l in Entity.ProyectoSeguimientoFiles where l.IdProyectoSeguimientoFile == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoSeguimientoFileEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoSeguimientoFileDelete();
                    break;
            }
        }
        protected virtual void GridProyectoSeguimientoFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoSeguimientoFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoSeguimientoFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoSeguimientoFiles.PageIndex = e.NewPageIndex;
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