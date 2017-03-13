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
    public abstract partial class PrestamoPageEditTabPanel<TEntity> : PageEditTabPanel<TEntity, nc.PrestamoFilter, PrestamoResult, int>
      where TEntity : class, new()
    {
        #region Properties
        private PrestamoResult prestamo;
        public PrestamoResult Prestamo
        {
            get
            {
                if (prestamo == null) prestamo = GetPrestamo();
                return prestamo;
            }
            set { prestamo = value; }
        }
        protected abstract PrestamoResult GetPrestamo();
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
            PathListPage = "PrestamoPageList.aspx";
            EditFilter = "PrestamoFilter";
            base._SetParameters();
        }
        protected override List<PageLinkData> GetTabUrls()
        {
            
            List<PageLinkData> urls = new List<PageLinkData>();
            urls.Add(new PageLinkData() { Text = "Generales", Url = "~/Prestamo/PrestamoPageEdit.aspx", IsNewVisible = true });
            urls.Add(new PageLinkData() { Text = "Alcance Geográfico", Url = "~/Prestamo/PrestamoAlcanceGeograficoPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Objetivos", Url = "~/Prestamo/PrestamoObjetivosPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Convenio", Url = "~/Prestamo/PrestamoConvenioPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Componentes", Url = "~/Prestamo/PrestamoComponentesPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Productos", Url = "~/Prestamo/PrestamoProductosPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Interv. DNIP", Url = "~/Prestamo/PrestamoEditDictamenPageEdit.aspx" });
            urls.Add(new PageLinkData() { Text = "Adjuntar", Url = "~/Prestamo/PrestamoAdjuntarPageList.aspx" });

            return urls;
        }
        protected override PrestamoResult GetHeadResult()
        {
            return Prestamo;
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion

    }
    public partial class PrestamoPageEdit : PrestamoPageEditTabPanel<nc.PrestamoGeneralCompose>
    {
        #region Override

        protected override void _Load()
        {
            webControlEdit = this.editPrestamo;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.prestamoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.prestamoHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override PrestamoResult GetPrestamo()
        {
            return Entity.Prestamo;
        }
        protected PrestamoComposeService Service
        {
            get { return PrestamoComposeService.Current; }
        }
        protected override IEntityService<nc.PrestamoGeneralCompose, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
        {
            get { return PrestamoComposeService.Current; }
        }
        protected override void AddNew()
        {
            PrestamoResult example = CommandValue as PrestamoResult;
            if (example == null && Entity != null && Entity.Prestamo != null && Entity.Prestamo.IdPrestamo > 0)
                example = new PrestamoResult() { IdOficina_Usuario = ContextUser.User.Persona_IdOficina };
            Entity = (example != null) ? Service.GetNew(example) : Service.GetNew();
        }




        protected override void _SetPermissions()
        {
            base._SetPermissions();
            bool enableUpdate = false;
            if (CrudAction == CrudActionEnum.Create)
                enableUpdate = true;
            else if (CrudAction != CrudActionEnum.Read)
                enableUpdate = CanByOffice("PrestamoGeneralCompose", Entity.Prestamo.PerfilOficinas, ActionConfig.UPDATE, Entity.Prestamo.IdEstadoActual);
            webControlEditionButtons.EnableSave = enableUpdate;
            webControlEditionButtons.EnableAplicate = enableUpdate;
            webControlEditionButtons.EnableDelete = enableUpdate;
            webControlEditionButtons.EnableSaveAndNew = enableUpdate;
        }
        #endregion
    }
}
