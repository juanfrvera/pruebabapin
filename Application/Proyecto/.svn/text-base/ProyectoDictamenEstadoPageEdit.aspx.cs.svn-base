using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;
using Service;

namespace UI.Web
{

    public partial class ProyectoDictamenEstadoPageEdit: PageEditTabPanel<nc.DictamenCompose , nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathListPage = "ProyectoDictamenPageList.aspx";
            EditFilter = "ProyectoDictamenFilter";
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoEstado;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.ProyectoDictamenTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoDictamenHead;
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
        protected override IEntityService<nc.DictamenCompose, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int> EntityService
        {
            get { return DictamenComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }

        #endregion
    }
}

