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
    public partial class ProyectoSeguimientoAdjuntarPageList : PageEditTabPanel<nc.ProyectoSeguimientoFilesCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int>
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
        protected override void _Load()
        {
            webControlEdit = this.editProyectoSeguimientoAdjuntar;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.ProyectoSeguimientoTabPanel;
            base._Load();
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