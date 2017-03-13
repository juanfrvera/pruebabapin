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
using Service; 
namespace UI.Web
{
    public partial class ProyectoIntervencionDNIPEdit : PageEditTabPanel<nc.ProyectoIntervencionDNIPCompose , nc.ProyectoFilter, nc.ProyectoResult, int>
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
            webControlEdit = this.editProyectoIntervencionDNIP;
            webControlEditionButtons = this.editButtons;
            //webControlConfirm = this.confirmarAccion;
            //webControlPageTabPanel = this.proyectoTabPanel;
            PathEditPage = "ProyectoIntervencionDNIPEdit.aspx";
            base._Load();
        }
        protected override void _Initialize()
        {
            base._Initialize();
            webControlConfirm.SetDisplayNone();
        }
        protected ProyectoService Service
        {
            get { return ProyectoService.Current; }
        }
        protected override IEntityService<nc.ProyectoIntervencionDNIPCompose, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return ProyectoIntervencionDNIPComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}
