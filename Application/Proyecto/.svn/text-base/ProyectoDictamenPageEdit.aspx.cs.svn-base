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
    public partial class ProyectoDictamenPageEdit : PageEditTabPanel<nc.ProyectoDictamen, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int>
    {
        #region Override
        public override PageBehaviour PageBehaviour
        {
            get
            {
                PageBehaviour pageBehaviour = base.PageBehaviour;
                pageBehaviour.HadSerializeEntity = true;
                return pageBehaviour;
            }
        }
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathListPage = "ProyectoDictamenPageList.aspx";
            EditFilter = "ProyectoDictamenFilter";
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoDictamen;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.proyectoDictamenTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoDictamenHead;
            base._Load();
        }
        protected override void _Initialize()
        {
            base._Initialize();
            webControlConfirm.SetDisplayNone();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoDictamenResult GetHeadResult()
        {
            return Service.ToResult(Entity);
        }
        protected ProyectoDictamenService Service
        {
            get { return ProyectoDictamenService.Current; }
        }
        protected override IEntityService<nc.ProyectoDictamen, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int> EntityService
        {
            get { return Service; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
	}
}
