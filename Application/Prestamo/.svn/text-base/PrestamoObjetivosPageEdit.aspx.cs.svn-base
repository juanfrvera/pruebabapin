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
    public partial class PrestamoObjetivosPageEdit : PageEditTabPanel<nc.PrestamoObjetivosCompose, nc.PrestamoFilter, nc.PrestamoResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            PathListPage = "PrestamoPageList.aspx";
            EditFilter = "PrestamoFilter";
            base._SetParameters();
        }
        protected override void _Load()
        {
            webControlEdit = this.editPrestamoObjetivos;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.PrestamoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
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
        public override PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }
        protected PrestamoService Service
        {
            get { return PrestamoService.Current; }
        }
        protected override IEntityService<nc.PrestamoObjetivosCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoObjetivosComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}
