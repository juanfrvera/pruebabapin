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
    public partial class ProyectoDictamenFilePageList : PageEditTabPanel<nc.ProyectoDictamenFilesCompose, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            PathListPage = "ProyectoDictamenFilePageList.aspx";
            EditFilter = "ProyectoDictamenFileFilter";
            base._SetParameters();
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoDictamenFile;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.ProyectoDictamenTabPanel;
            webControlHead = this.ProyectoDictamenHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoDictamenResult GetHeadResult()
        {
            return Entity.ProyectoDictamen;
        }
        protected ProyectoDictamenService Service
        {
            get { return ProyectoDictamenService.Current; }
        }
        protected override IEntityService<nc.ProyectoDictamenFilesCompose, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int> EntityService
        {
            get { return ProyectoDictamenFilesComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}