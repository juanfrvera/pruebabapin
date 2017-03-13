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
    public partial class PrestamoDictamenPageEdit : PageEditTabPanel<nc.PrestamoDictamenCompose, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int>
    {	
		#region Override
        protected override void _SetParameters()
        {
            PathListPage = "PrestamoDictamenPageList.aspx";
            EditFilter = "PrestamoDictamenFilter";
            base._SetParameters();
        }
		protected override void _Load()
        {
            webControlEdit = this.editPrestamoDictamen;
            webControlEditionButtons = this.editButtons;            
            webControlPaggingInPage = this.paggingInPage;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.PrestamoDictamenTabPanel;
            webControlHead = this.prestamoDictamenHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override PrestamoDictamenResult GetHeadResult()
        {
            return Entity.Dictamen;
        }
        public override PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }

		protected PrestamoDictamenService Service
		{
			get { return PrestamoDictamenService.Current; }
		}
		protected override IEntityService<nc.PrestamoDictamenCompose, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int> EntityService
		{
			get { return PrestamoDictamenComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
