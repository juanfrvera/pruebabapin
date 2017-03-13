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
using Contract;
using nc = Contract;
using Service;
using System.Collections.Generic; 

namespace UI.Web
{

    public partial class ProyectoDictamenFactibilidadPageEdit : PageEditTabPanel<nc.DictamenCompose , nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int>
    {
        public override PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }
        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathListPage = "ProyectoDictamenPageList.aspx";
            EditFilter = "ProyectoDictamenFilter";
        }
        protected override void _Load()
        {
            webControlEdit = this.editProyectoDictamenFactibilidad;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.proyectoDictamenTabPanel;
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
        protected override void _Initialize()
        {
            base._Initialize();
            webControlConfirm.SetDisplayNone();
        }

        protected DictamenComposeService Service
        {
            get { return DictamenComposeService.Current; }
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
