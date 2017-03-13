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
    public partial class PrestamoAlcanceGeograficoPageEdit : PageEditTabPanel<nc.PrestamoAlcanceGeograficoCompose, nc.PrestamoFilter, nc.PrestamoResult, int>
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
            webControlEdit = this.editPrestamoAlcanceGeografico;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.PrestamoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.prestamoHead;
            base._Load();
        }
        protected PrestamoService Service
        {
            get { return PrestamoService.Current; }
        }
        protected override PrestamoResult GetHeadResult()
        {
            return Entity.Prestamo;
        }
        protected override IEntityService<nc.PrestamoAlcanceGeograficoCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoAlcanceGeograficoComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}
