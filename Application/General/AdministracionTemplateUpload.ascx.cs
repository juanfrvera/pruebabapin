using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;
using Business.Managers;

namespace UI.Web
{
    public partial class AdministracionTemplateUpload : WebControlEdit<nc.FileInfoResult> 
    {
        #region Override WebControlEdit
        protected int idLastTemplateVersion { get; set; }
        protected override void _Initialize()
        {
            base._Initialize();
            PopUpTemplateFiles.Attributes.CssStyle.Add("display", "none");
            try
            {
                idLastTemplateVersion = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_TEMPLATE_IMPORTACION");
            }
            catch (InvalidOperationException)
            {
            }

            if (idLastTemplateVersion > 0)
            {
                Entity = Service.ToResult(FileInfoService.Current.GetById(idLastTemplateVersion));
            }
            TemplateFileRefresh();
        }
        public override void Clear()
        {

        }
        public override void GetValue()
        {
        }
        public override void SetValue()
        {
            TemplateFileRefresh();
        }
        #endregion Override

        protected FileInfoService Service
        {
            get { return FileInfoService.Current; }
        }

        private FileInfoResult actualTemplateFile;
        protected FileInfoResult ActualTemplateFile
        {
            get
            {
                if (actualTemplateFile == null)
                    if (ViewState["actualTemplateFile"] != null)
                        actualTemplateFile = ViewState["actualTemplateFile"] as FileInfoResult;
                    else
                    {
                        actualTemplateFile = GetNewTemplateFile();
                        ViewState["actualTemplateFile"] = actualTemplateFile;
                    }
                return actualTemplateFile;
            }
            set
            {
                actualTemplateFile = value;
                ViewState["actualTemplateFile"] = value;
            }
        }
        FileInfoResult GetNewTemplateFile()
        {
            int id = 0;
            if (id > 0) id = 0;
            id--;
            FileInfoResult plResult = new FileInfoResult();
            return plResult;
        }

        #region Methods
        void HidePopUpTemplateFiles()
        {
            ModalPopupExtenderTemplateFiles.Hide();
        }
        void TemplateFileClear()
        {
            ActualTemplateFile = GetNewTemplateFile();
            UIHelper.SetValue(lblError, "");
        }
        void TemplateFileSetValue()
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
        }
        void TemplateFileGetValue()
        {
            if (fuArchivo.IsFileSelected)
            {
                ActualTemplateFile.IdFile = fuArchivo.GetIdFileSelected();
                ActualTemplateFile.Date = fuArchivo.Date;
                ActualTemplateFile.FileName = fuArchivo.FileName;
            }
        }
        void TemplateFileRefresh()
        {
            var listFileInfo = new List<FileInfoResult>();
            if (Entity != null)
            {
                listFileInfo.Add(Entity);
            }
            UIHelper.Load(gridTemplateFiles, listFileInfo, "Order");
            upGridTemplateFiles.Update();
        }
        #endregion Methods

        #region Commands
        void CommandTemplateFileEdit()
        {
            TemplateFileSetValue();
            ModalPopupExtenderTemplateFiles.Show();
            upTemplateFilesPopUp.Update();
        }
        void CommandTemplateFileSave()
        {
            if (fuArchivo.IsFileSelected)
            {
                TemplateFileGetValue();
                
                FileInfoResult result = Entity;

                if (result != null)
                {
                    result.IdFile = ActualTemplateFile.IdFile;
                    result.FileName = ActualTemplateFile.FileName;
                }
                else
                {
                    Entity = ActualTemplateFile;
                }

                var prResult = SolutionContext.Current.ParameterManager.Parameters.Where(x => x.Code == "ID_TEMPLATE_IMPORTACION").FirstOrDefault();
                if (prResult == null)
                {
                    nc.Parameter pr = new nc.Parameter();
                    pr.NumberValue = Entity.IdFile;
                    pr.Name = "Id Template Importación";
                    pr.Code = "ID_TEMPLATE_IMPORTACION";
                    pr.IdParameterCategory = 3; //Business
                    ParameterService.Current.Save(pr, UIContext.Current.ContextUser);
                    idLastTemplateVersion = (int)pr.NumberValue;
                }
                else
                {
                    nc.Parameter pr = ParameterService.Current.GetById(prResult.IdParameter);
                    FileInfoService.Current.Delete(FileInfoService.Current.GetById((Int32)pr.NumberValue), UIContext.Current.ContextUser);
                    pr.NumberValue = Entity.IdFile;
                    ParameterService.Current.Update(pr, UIContext.Current.ContextUser);
                    idLastTemplateVersion = (int)pr.NumberValue;
                }
                SolutionContext.Current.ParameterManager.Parameters.Where(x => x.Code == "ID_TEMPLATE_IMPORTACION").FirstOrDefault().NumberValue = idLastTemplateVersion;
 
                TemplateFileClear();
                TemplateFileRefresh();
            }
            else
            {
                lblError.Text = SolutionContext.Current.TextManager.Translate("Datos obligatorios");
                upTemplateFilesPopUp.Update();
            }
        }
        void CommandTemplateFileDelete()
        {
            TemplateFileClear();
            TemplateFileRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveTemplateFile_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandTemplateFileSave);
            TemplateFileClear();
            if(lblError.Text=="")
                HidePopUpTemplateFiles();
            else
                ModalPopupExtenderTemplateFiles.Show();
        }
        protected void btCancelTemplateFile_Click(object sender, EventArgs e)
        {
            TemplateFileClear();
            HidePopUpTemplateFiles();
        }
        protected void btAgregarTemplateFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            fuArchivo.Focus();
            ModalPopupExtenderTemplateFiles.Show();
        }
        protected void btRegenerarTemplateFile_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblError, "");
            //Get Template ID
            var idLastTemplateVersion = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_TEMPLATE_IMPORTACION");
            if (idLastTemplateVersion > 0)
            {
                TemplateProjectManager.UpdateTemplateProjects(idLastTemplateVersion);
                Entity = Service.ToResult(FileInfoService.Current.GetById(idLastTemplateVersion));
                TemplateFileClear();
                TemplateFileRefresh();
            }
        }
        #endregion

        #region EventosGrillas
        protected void GridTemplateFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridTemplateFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = (Int32)Entity.IdFile;

                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }
        protected void GridTemplateFiles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandTemplateFileEdit();
                    break;
                case Command.DELETE:
                    CommandTemplateFileDelete();
                    break;
            }
        }
        protected virtual void GridTemplateFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridTemplateFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridTemplateFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridTemplateFiles.PageIndex = e.NewPageIndex;
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