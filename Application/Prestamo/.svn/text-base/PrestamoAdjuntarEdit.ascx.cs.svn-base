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
    public partial class PrestamoAdjuntarEdit : WebControlEdit<nc.PrestamoFilesCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            diFecha.Width = 80;
            diFecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");
            PopUpPrestamoFiles.Attributes.CssStyle.Add("display", "none");
        }
        public override void Clear()
        {
             UIHelper.Clear(tbNombre);
			tbNombre.Focus();
				UIHelper.Clear(diFecha);
        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            PrestamoFileRefresh();
        }
        #endregion Override

        private PrestamoFileResult actualPrestamoFile;
        protected PrestamoFileResult ActualPrestamoFile
        {
            get
            {
                if (actualPrestamoFile == null)
                    if (ViewState["actualPrestamoFile"] != null)
                        actualPrestamoFile = ViewState["actualPrestamoFile"] as PrestamoFileResult;
                    else
                    {
                        actualPrestamoFile = GetNewPrestamoFile();
                        ViewState["actualPrestamoFile"] = actualPrestamoFile;
                    }
                return actualPrestamoFile;
            }
            set
            {
                actualPrestamoFile = value;
                ViewState["actualPrestamoFile"] = value;
            }
        }
        PrestamoFileResult GetNewPrestamoFile()
        {
            int id = 0;
            if (Entity.PrestamoFiles.Count > 0) id = Entity.PrestamoFiles.Min(l => l.IdPrestamoFile);
            if (id > 0) id = 0;
            id--;
            PrestamoFileResult plResult = new PrestamoFileResult();
            plResult.IdPrestamoFile = id;
            plResult.IdPrestamo = Entity.IdPrestamo;
            return plResult;
        }

        #region Methods
        void HidePopUpPrestamoFiles()
        {
            ModalPopupExtenderPrestamoFiles.Hide();
        }
        void PrestamoFileClear()
        {
            ActualPrestamoFile = GetNewPrestamoFile();
            UIHelper.Clear(tbNombre);
            UIHelper.SetValue(diFecha,DateTime.Now);
            UIHelper.SetValue(lblError, "");
        }
        void PrestamoFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            UIHelper.SetValue(tbNombre, ActualPrestamoFile.File_FileName);
            UIHelper.SetValue(diFecha, ActualPrestamoFile.File_Date);
            fuArchivo.Focus();
        }
        void PrestamoFileGetValue()
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
                ActualPrestamoFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualPrestamoFile.IdPrestamo = Entity.IdPrestamo;
                ActualPrestamoFile.File_Date = fuArchivo.Date;
                ActualPrestamoFile.File_FileName = fuArchivo.FileName;
            }
        }
        void PrestamoFileRefresh()
        {
            UIHelper.Load(gridPrestamoFiles, Entity.PrestamoFiles, "Order");
            upGridPrestamoFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoFileEdit()
        {
            PrestamoFileSetValue();
            ModalPopupExtenderPrestamoFiles.Show();
            upPrestamoFilesPopUp.Update();
        }
        void CommandPrestamoFileSave()
        {
            if (diFecha.Fecha != null && fuArchivo.IsFileSelected)
            {
                PrestamoFileGetValue();
                PrestamoFileResult result = (from l in Entity.PrestamoFiles
                                             where l.IdPrestamoFile == ActualPrestamoFile.ID
                                             select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdPrestamoFile = ActualPrestamoFile.IdPrestamoFile;
                    result.IdFile = ActualPrestamoFile.IdFile;
                    result.IdPrestamo = ActualPrestamoFile.IdPrestamo;
                    result.File_Date = ActualPrestamoFile.Fecha;
                    result.File_FileName = ActualPrestamoFile.Nombre;
                }
                else
                {
                    Entity.PrestamoFiles.Add(ActualPrestamoFile);
                }
                PrestamoFileClear();
                PrestamoFileRefresh();
            }
            else
            {
                lblError.Text = SolutionContext.Current.TextManager.Translate("Datos obligatorios");
                upPrestamoFilesPopUp.Update();
            }
        }
        void CommandPrestamoFileDelete()
        {
            PrestamoFileResult result = (from l in Entity.PrestamoFiles where l.IdPrestamoFile == ActualPrestamoFile.ID select l).FirstOrDefault();
            Entity.PrestamoFiles.Remove(result);
            PrestamoFileClear();
            PrestamoFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSavePrestamoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoFileSave);
            PrestamoFileClear();
            if(lblError.Text=="")
                HidePopUpPrestamoFiles();
            else
                ModalPopupExtenderPrestamoFiles.Show();
        }
        protected void btNewPrestamoFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoFileSave);
            ModalPopupExtenderPrestamoFiles.Show();
        }
        protected void btCancelPrestamoFile_Click(object sender, EventArgs e)
        {
            PrestamoFileClear();
            HidePopUpPrestamoFiles();
        }
        protected void btAgregarPrestamoFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderPrestamoFiles.Show();
            UIHelper.SetValue(diFecha, DateTime.Now);
        }
        #endregion

        #region EventosGrillas
        protected void GridPrestamoFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridPrestamoFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.PrestamoFiles.Where(x => x.IdPrestamoFile == idRow).Single().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridPrestamoFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoFile = (from l in Entity.PrestamoFiles where l.IdPrestamoFile == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoFileEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoFileDelete();
                    break;
            }
        }
        protected virtual void GridPrestamoFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridPrestamoFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridPrestamoFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridPrestamoFiles.PageIndex = e.NewPageIndex;
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