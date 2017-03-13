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
    public partial class PrestamoProductosPageEdit : PageEditTabPanel<nc.PrestamoProductosCompose, nc.PrestamoFilter, nc.PrestamoResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            PathListPage = "PrestamoPageList.aspx";
            EditFilter = "PrestamoFilter";
            base._SetParameters();
        }
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
            webControlEdit = this.editPrestamoProductos;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.prestamoTabPanel;
            webControlHead = this.prestamoHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override PrestamoResult GetHeadResult()
        {
            return Entity.Prestamo;
        }

        protected PrestamoService Service
        {
            get { return PrestamoService.Current; }
        }
        protected override IEntityService<nc.PrestamoProductosCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoProductosComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}