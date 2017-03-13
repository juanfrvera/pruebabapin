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
    public partial class PrestamoDictamenAdjuntarEdit : WebControlEdit<nc.PrestamoDictamenFilesCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            diFecha.Width = 80;
            PopUpPrestamoDictamenFiles.Attributes.CssStyle.Add("display", "none");
        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            PrestamoDictamenFileRefresh();
        }
        #endregion Override

        private PrestamoDictamenFileResult actualPrestamoDictamenFile;
        protected PrestamoDictamenFileResult ActualPrestamoDictamenFile
        {
            get
            {
                if (actualPrestamoDictamenFile == null)
                    if (ViewState["actualPrestamoDictamenFile"] != null)
                        actualPrestamoDictamenFile = ViewState["actualPrestamoDictamenFile"] as PrestamoDictamenFileResult;
                    else
                    {
                        actualPrestamoDictamenFile = GetNewPrestamoDictamenFile();
                        ViewState["actualPrestamoDictamenFile"] = actualPrestamoDictamenFile;
                    }
                return actualPrestamoDictamenFile;
            }
            set
            {
                actualPrestamoDictamenFile = value;
                ViewState["actualPrestamoDictamenFile"] = value;
            }
        }
        PrestamoDictamenFileResult GetNewPrestamoDictamenFile()
        {
            int id = 0;
            if (Entity.PrestamoDictamenFiles.Count > 0) id = Entity.PrestamoDictamenFiles.Min(l => l.IdPrestamoDictamenFile);
            if (id > 0) id = 0;
            id--;
            PrestamoDictamenFileResult plResult = new PrestamoDictamenFileResult();
            plResult.IdPrestamoDictamenFile = id;
            plResult.IdPrestamoDictamen = Entity.IdPrestamoDictamen;
            return plResult;
        }

        #region Methods
        void HidePopUpPrestamoDictamenFiles()
        {
            ModalPopupExtenderPrestamoDictamenFiles.Hide();
        }
        void PrestamoDictamenFileClear()
        {
            ActualPrestamoDictamenFile = GetNewPrestamoDictamenFile();
            UIHelper.Clear(tbNombre);
            UIHelper.SetValue(diFecha,DateTime.Now);
            UIHelper.SetValue(lblError, "");
        }
        void PrestamoDictamenFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            UIHelper.SetValue(tbNombre, ActualPrestamoDictamenFile.File_FileName);
            UIHelper.SetValue(diFecha, ActualPrestamoDictamenFile.File_Date);
            fuArchivo.Focus();
        }
        void PrestamoDictamenFileGetValue()
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
                ActualPrestamoDictamenFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualPrestamoDictamenFile.IdPrestamoDictamen = Entity.IdPrestamoDictamen;
                ActualPrestamoDictamenFile.File_Date = fuArchivo.Date;
                ActualPrestamoDictamenFile.File_FileName = fuArchivo.FileName;
            }
        }
        void PrestamoDictamenFileRefresh()
        {
            UIHelper.Load(gridPrestamoDictamenFiles, Entity.PrestamoDictamenFiles, "Order");
            upGridPrestamoDictamenFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoDictamenFileEdit()
        {
            PrestamoDictamenFileSetValue();
            ModalPopupExtenderPrestamoDictamenFiles.Show();
            upPrestamoDictamenFilesPopUp.Update();
        }
        void CommandPrestamoDictamenFileSave()
        {
            if (diFecha.Fecha != null && fuArchivo.IsFileSelected)
            {
                PrestamoDictamenFileGetValue();
                PrestamoDictamenFileResult result = (from l in Entity.PrestamoDictamenFiles
                                             where l.IdPrestamoDictamenFile == ActualPrestamoDictamenFile.ID
                                             select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdPrestamoDictamenFile = ActualPrestamoDictamenFile.IdPrestamoDictamenFile;
                    result.IdFile = ActualPrestamoDictamenFile.IdFile;
                    result.IdPrestamoDictamen = ActualPrestamoDictamenFile.IdPrestamoDictamen;
                    result.File_Date = ActualPrestamoDictamenFile.Fecha;
                    result.File_FileName = ActualPrestamoDictamenFile.Nombre;
                }
                else
                {
                    Entity.PrestamoDictamenFiles.Add(ActualPrestamoDictamenFile);
                }
                PrestamoDictamenFileClear();
                PrestamoDictamenFileRefresh();
            }
            else
            {
                lblError.Text = SolutionContext.Current.TextManager.Translate("Datos obligatorios");
                upPrestamoDictamenFilesPopUp.Update();
            }
        }
        void CommandPrestamoDictamenFileDelete()
        {
            PrestamoDictamenFileResult result = (from l in Entity.PrestamoDictamenFiles where l.IdPrestamoDictamenFile == ActualPrestamoDictamenFile.ID select l).FirstOrDefault();
            Entity.PrestamoDictamenFiles.Remove(result);
            PrestamoDictamenFileClear();
            PrestamoDictamenFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSavePrestamoDictamenFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoDictamenFileSave);
            PrestamoDictamenFileClear();
            if(lblError.Text=="")
                HidePopUpPrestamoDictamenFiles();
            else
                ModalPopupExtenderPrestamoDictamenFiles.Show();
        }
        protected void btNewPrestamoDictamenFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoDictamenFileSave);
            ModalPopupExtenderPrestamoDictamenFiles.Show();
        }
        protected void btCancelPrestamoDictamenFile_Click(object sender, EventArgs e)
        {
            PrestamoDictamenFileClear();
            HidePopUpPrestamoDictamenFiles();
        }
        protected void btAgregarPrestamoDictamenFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderPrestamoDictamenFiles.Show();
            UIHelper.SetValue(diFecha, DateTime.Now);
        }
        #endregion

        #region EventosGrillas
        protected void GridPrestamoDictamenFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridPrestamoDictamenFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.PrestamoDictamenFiles.Where(x => x.IdPrestamoDictamenFile == idRow).Single().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridPrestamoDictamenFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoDictamenFile = (from l in Entity.PrestamoDictamenFiles where l.IdPrestamoDictamenFile == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoDictamenFileEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoDictamenFileDelete();
                    break;
            }
        }
        protected virtual void GridPrestamoDictamenFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridPrestamoDictamenFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridPrestamoDictamenFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridPrestamoDictamenFiles.PageIndex = e.NewPageIndex;
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