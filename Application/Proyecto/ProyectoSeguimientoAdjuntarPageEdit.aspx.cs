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
    public partial class ProyectoSeguimientoAdjuntarPageEdit : PageEditTabPanel<nc.ProyectoSeguimientoFilesCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int>
    {
        #region Override
        public override PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }
        protected override void _SetParameters()
        {
            PathListPage = "ProyectoSeguimientoPageList.aspx";
            EditFilter = "ProyectoSeguimientoFilter";
            base._SetParameters();
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoSeguimientoAdjuntar;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.proyectoSeguimientoTabPanel;
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
        protected override IEntityService<nc.ProyectoSeguimientoFilesCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int> EntityService
        {
            get { return ProyectoSeguimientoFilesComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}