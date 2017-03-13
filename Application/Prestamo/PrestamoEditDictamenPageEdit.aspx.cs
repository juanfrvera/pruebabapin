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
namespace UI.Web
{
    public partial class PrestamoEditDictamenPageEdit : PageEditTabPanel<nc.PrestamoEditDictamenCompose, nc.PrestamoFilter, nc.PrestamoResult, int>
    {
        #region Override
        public override PageBehaviour PageBehaviour
        {
            get
            {
                PageBehaviour pageBehaviour = base.PageBehaviour;
                pageBehaviour.ConfirmOnPageChange = false;
                return pageBehaviour;
            }
        }
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathListPage = "PrestamoPageList.aspx";
            EditFilter = "PrestamoFilter";
        }
        protected override void _Load()
        {
            webControlEdit = this.editPrestamoEditDictamen;
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
        
        protected override void _Initialize()
        {
            base._Initialize();
            this.editButtons.VisibleAplicate = false;
            this.editButtons.VisibleSave = false;
            this.editButtons.VisibleSaveAndNew = false;
            this.editButtons.TextCancel = "Cerrar";
            webControlConfirm.SetDisplayNone();
        }
        protected override PrestamoResult GetHeadResult()
        {
            return Entity.Prestamo;
        }
        protected PrestamoService Service
        {
            get { return PrestamoService.Current; }
        }
        protected override IEntityService<nc.PrestamoEditDictamenCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoEditDictamenComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}
