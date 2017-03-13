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

namespace UI.Web.Proyecto
{

    public partial class ProyectoSeguimientoEstadoPageEdit: PageEditTabPanel<nc.ProyectoSeguimientoCompose , nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathListPage = "ProyectoSeguimientoPageList.aspx";
            EditFilter = "ProyectoSeguimientoFilter";
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoEstado;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.ProyectoSeguimientoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoSeguimientoHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoSeguimientoResult GetHeadResult()
        {
            return Entity.ProyectoSeguimiento;
        }
        protected ProyectoSeguimientoService Service
        {
            get { return ProyectoSeguimientoService.Current; }
        }
        protected override IEntityService<nc.ProyectoSeguimientoCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int> EntityService
        {
            get { return ProyectoSeguimientoComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }

        #endregion
    }
}
