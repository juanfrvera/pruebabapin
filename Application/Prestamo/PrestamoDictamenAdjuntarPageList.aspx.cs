using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public partial class PrestamoDictamenAdjuntarPageList : PageEditTabPanel<nc.PrestamoDictamenFilesCompose, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            PathListPage = "PrestamoDictamenPageList.aspx";
            EditFilter = "PrestamoDictamenFilter";
            base._SetParameters();
        }
        protected override void _Load()
        {
            webControlEdit = this.editPrestamoDictamenAdjuntar;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.PrestamoDictamenTabPanel;
            webControlHead = this.prestamoDictamenHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override PrestamoDictamenResult GetHeadResult()
        {
            return Entity.PrestamoDictamen;
        }
        protected PrestamoDictamenService Service
        {
            get { return PrestamoDictamenService.Current; }
        }
        protected override IEntityService<nc.PrestamoDictamenFilesCompose, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int> EntityService
        {
            get { return PrestamoDictamenFilesComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}