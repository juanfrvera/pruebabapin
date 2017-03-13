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
    public partial class ProyectoDictamenFileEdit : WebControlEdit<nc.ProyectoDictamenFilesCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            diFecha.Width = 80;
            PopUpProyectoDictamenFiles.Attributes.CssStyle.Add("display", "none");
        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            ProyectoDictamenFileRefresh();
        }
        #endregion Override

        private ProyectoDictamenFileResult actualProyectoDictamenFile;
        protected ProyectoDictamenFileResult ActualProyectoDictamenFile
        {
            get
            {
                if (actualProyectoDictamenFile == null)
                    if (ViewState["actualProyectoDictamenFile"] != null)
                        actualProyectoDictamenFile = ViewState["actualProyectoDictamenFile"] as ProyectoDictamenFileResult;
                    else
                    {
                        actualProyectoDictamenFile = GetNewProyectoDictamenFile();
                        ViewState["actualProyectoDictamenFile"] = actualProyectoDictamenFile;
                    }
                return actualProyectoDictamenFile;
            }
            set
            {
                actualProyectoDictamenFile = value;
                ViewState["actualProyectoDictamenFile"] = value;
            }
        }
        ProyectoDictamenFileResult GetNewProyectoDictamenFile()
        {
            int id = 0;
            if (Entity.ProyectoDictamenFiles.Count > 0) id = Entity.ProyectoDictamenFiles.Min(l => l.IdProyectoDictamenFile);
            if (id > 0) id = 0;
            id--;
            ProyectoDictamenFileResult plResult = new ProyectoDictamenFileResult();
            plResult.IdProyectoDictamenFile = id;
            plResult.IdProyectoDictamen = Entity.IdProyectoDictamen;
            return plResult;
        }

        #region Methods
        void HidePopUpProyectoDictamenFiles()
        {
            ModalPopupExtenderProyectoDictamenFiles.Hide();
        }
        void ProyectoDictamenFileClear()
        {
            ActualProyectoDictamenFile = GetNewProyectoDictamenFile();
            UIHelper.Clear(tbNombre);
            UIHelper.SetValue(diFecha,DateTime.Now);
            UIHelper.SetValue(lblError, "");
        }
        void ProyectoDictamenFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            UIHelper.SetValue(tbNombre, ActualProyectoDictamenFile.File_FileName);
            UIHelper.SetValue(diFecha, ActualProyectoDictamenFile.File_Date);
            fuArchivo.Focus();
        }
        void ProyectoDictamenFileGetValue()
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
                ActualProyectoDictamenFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualProyectoDictamenFile.IdProyectoDictamen = Entity.IdProyectoDictamen;
                ActualProyectoDictamenFile.File_Date = fuArchivo.Date;
                ActualProyectoDictamenFile.File_FileName = fuArchivo.FileName;
            }
        }
        void ProyectoDictamenFileRefresh()
        {
            UIHelper.Load(gridProyectoDictamenFiles, Entity.ProyectoDictamenFiles, "Order");
            upGridProyectoDictamenFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoDictamenFileEdit()
        {
            ProyectoDictamenFileSetValue();
            ModalPopupExtenderProyectoDictamenFiles.Show();
            upProyectoDictamenFilesPopUp.Update();
        }
        void CommandProyectoDictamenFileSave()
        {
            if (diFecha.Fecha != null && fuArchivo.IsFileSelected)
            {
                ProyectoDictamenFileGetValue();
                ProyectoDictamenFileResult result = (from l in Entity.ProyectoDictamenFiles
                                             where l.IdProyectoDictamenFile == ActualProyectoDictamenFile.ID
                                             select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdProyectoDictamenFile = ActualProyectoDictamenFile.IdProyectoDictamenFile;
                    result.IdFile = ActualProyectoDictamenFile.IdFile;
                    result.IdProyectoDictamen = ActualProyectoDictamenFile.IdProyectoDictamen;
                    result.File_Date = ActualProyectoDictamenFile.Fecha;
                    result.File_FileName = ActualProyectoDictamenFile.Nombre;
                }
                else
                {
                    Entity.ProyectoDictamenFiles.Add(ActualProyectoDictamenFile);
                }
                ProyectoDictamenFileClear();
                ProyectoDictamenFileRefresh();
            }
            else
            {
                lblError.Text = SolutionContext.Current.TextManager.Translate("Datos obligatorios");
                upProyectoDictamenFilesPopUp.Update();
            }
        }
        void CommandProyectoDictamenFileDelete()
        {
            ProyectoDictamenFileResult result = (from l in Entity.ProyectoDictamenFiles where l.IdProyectoDictamenFile == ActualProyectoDictamenFile.ID select l).FirstOrDefault();
            Entity.ProyectoDictamenFiles.Remove(result);
            ProyectoDictamenFileClear();
            ProyectoDictamenFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveProyectoDictamenFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoDictamenFileSave);
            ProyectoDictamenFileClear();
            if(lblError.Text=="")
                HidePopUpProyectoDictamenFiles();
            else
                ModalPopupExtenderProyectoDictamenFiles.Show();
        }
        protected void btNewProyectoDictamenFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoDictamenFileSave);
            ModalPopupExtenderProyectoDictamenFiles.Show();
        }
        protected void btCancelProyectoDictamenFile_Click(object sender, EventArgs e)
        {
            ProyectoDictamenFileClear();
            HidePopUpProyectoDictamenFiles();
        }
        protected void btAgregarProyectoDictamenFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderProyectoDictamenFiles.Show();
            UIHelper.SetValue(diFecha, DateTime.Now);
        }
        #endregion

        #region EventosGrillas
        protected void GridProyectoDictamenFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridProyectoDictamenFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.ProyectoDictamenFiles.Where(x => x.IdProyectoDictamenFile == idRow).Single().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridProyectoDictamenFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoDictamenFile = (from l in Entity.ProyectoDictamenFiles where l.IdProyectoDictamenFile == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoDictamenFileEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoDictamenFileDelete();
                    break;
            }
        }
        protected virtual void GridProyectoDictamenFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoDictamenFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoDictamenFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoDictamenFiles.PageIndex = e.NewPageIndex;
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