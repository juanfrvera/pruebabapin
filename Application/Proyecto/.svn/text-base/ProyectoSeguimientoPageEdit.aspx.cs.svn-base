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

    public abstract partial class ProyectoSeguimientoPageEditTabPanel<TEntity> : PageEditTabPanel<TEntity, nc.ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
  where TEntity : class, new()
    {
        #region Properties
        private ProyectoSeguimientoResult proyectoSeguimiento;
        public ProyectoSeguimientoResult ProyectoSeguimiento
        {
            get
            {
                if (proyectoSeguimiento == null) proyectoSeguimiento = GetProyectoSeguimiento();
                return proyectoSeguimiento;
            }
            set { proyectoSeguimiento = value; }
        }
        protected abstract ProyectoSeguimientoResult GetProyectoSeguimiento();
        #endregion

        #region Override
        public override PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }
        protected override void _SetParameters()
        {
            PathListPage = "ProyectoSeguimientoPageList.aspx";
            EditFilter = "ProyectoSeguimientoFilter";
            base._SetParameters();
        }
        protected override List<PageLinkData> GetTabUrls()
        {
            List<PageLinkData> urls = new List<PageLinkData>();
            urls.Add(new PageLinkData() { Text = "Generales", Url = "~/Proyecto/ProyectoSeguimientoPageEdit.aspx", IsNewVisible = true });
            urls.Add(new PageLinkData() { Text = "Seguimiento de Estados", Url = "~/Proyecto/ProyectoSeguimientoEstadoPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Adjuntar", Url = "~/Proyecto/ProyectoSeguimientoAdjuntarPageEdit.aspx" });
            return urls;
        }
        protected override ProyectoSeguimientoResult GetHeadResult()
        {
            return ProyectoSeguimiento;
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion

    }
    public partial class ProyectoSeguimientoPageEdit : ProyectoSeguimientoPageEditTabPanel<nc.ProyectoSeguimientoCompose> //PageEditTabPanel<nc.ProyectoSeguimientoCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int>
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

        protected override void _SetParameters()
        {
            PathListPage = "ProyectoSeguimientoPageList.aspx";
            EditFilter = "ProyectoSeguimientoFilter";
            base._SetParameters();
        }
		protected override void _Load()
        {
            webControlEdit = this.editProyectoSeguimiento;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.proyectoSeguimientoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoSeguimientoHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoSeguimientoResult GetHeadResult()
        {
            return Entity.ProyectoSeguimiento;
        }
        protected override ProyectoSeguimientoResult GetProyectoSeguimiento()
        {
            return Entity.ProyectoSeguimiento;
        }
		protected ProyectoSeguimientoService Service
		{
			get { return ProyectoSeguimientoService.Current; }
		}
        protected override IEntityService<nc.ProyectoSeguimientoCompose, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int> EntityService
		{
            get { return ProyectoSeguimientoComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
