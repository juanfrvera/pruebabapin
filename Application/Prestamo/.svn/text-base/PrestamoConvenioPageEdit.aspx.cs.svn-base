using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc=Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public partial class PrestamoConvenioPageEdit : PageEditTabPanel<nc.PrestamoConvenioCompose, nc.PrestamoFilter, nc.PrestamoResult, int>
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
                PageBehaviour pageBehaviour = base.PageBehaviour;
                pageBehaviour.ConfirmOnPageChange = true;
                return pageBehaviour;
            }
        }
        protected override void _Load()
        {
            webControlEdit = this.editPrestamoConvenio;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.prestamoTabPanel ;
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
        protected PrestamoService Service
        {
            get { return PrestamoService.Current; }
        }
        protected override IEntityService<nc.PrestamoConvenioCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoConvenioComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}
