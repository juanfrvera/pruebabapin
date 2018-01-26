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
using Service;
using Contract;

namespace UI.Web
{
    public partial class Administracion : PageBase 
    {

        private const string RootPath = @"../Generates/";
        private const string GeneratePath = @"../Generates/";
        private const string GeneralPath = @"../General/";
        private const string PagePath = @"../Pages/";
        private const string ProyectoPath = @"../Proyecto/";
        
        #region Initialize
        protected override void _Initialize()
        {
            HabilitarBotones();
        }       
        private void HabilitarBotones()
        {
            liText.Visible = TextService.Current.Can(new Contract.Text(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liParameter.Visible = ParameterService.Current.Can(new Contract.Parameter(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liAuditSession.Visible = AuditSessionService.Current.Can(new Contract.AuditSession(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liAuditOpereration.Visible = AuditOperationService.Current.Can(new Contract.AuditOperation(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liLanguage.Visible = LanguageService.Current.Can(new Language() { IdLanguage = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liTextCategory.Visible = TextCategoryService.Current.Can(new TextCategory(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liParameterCategory.Visible = ParameterCategoryService.Current.Can(new ParameterCategory(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liNumeration.Visible = NumerationService.Current.Can(new Numeration(), ActionConfig.LIST, UIContext.Current.ContextUser);
            liTextLanguage.Visible = TextLanguageService.Current.Can(new TextLanguage(), ActionConfig.LIST, UIContext.Current.ContextUser);

            liCaracterEconomicoTipo.Visible = CaracterEconomicoTipoService.Current.Can(new CaracterEconomicoTipo() { IdCaracterEconomicoTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liClasificacionGeograficaTipo.Visible = ClasificacionGeograficaTipoService.Current.Can(new ClasificacionGeograficaTipo() { IdClasificacionGeograficaTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liFinalidadFuncionTipo.Visible = FinalidadFuncionTipoService.Current.Can(new FinalidadFuncionTipo() { IdFinalidadFuncionTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liClasificacionGastoTipo.Visible = ClasificacionGastoTipoService.Current.Can(new ClasificacionGastoTipo() { IdClasificacionGastoTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liFuenteFinanciamientoTipo.Visible = FuenteFinanciamientoTipoService.Current.Can(new FuenteFinanciamientoTipo() { IdFuenteFinanciamientoTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liMonedaCotizacion.Visible = MonedaCotizacionService.Current.Can(new MonedaCotizacion() { IdMonedaCotizacion = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
          //  liProcesoTipo.Visible = ProcesoTipoService.Current.Can(new ProcesoTipo() { IdProcesoTipo = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);

            liSistemaEntidad.Visible = SistemaEntidadService.Current.Can(new SistemaEntidad() { IdSistemaEntidad = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liSistemaAccion.Visible = SistemaAccionService.Current.Can(new SistemaAccion() { IdSistemaAccion = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            liEstado.Visible = EstadoService.Current.Can(new Estado() { IdEstado = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            
            //liSistemaEntidadAccion.Visible = SistemaEntidadAccionService.Current.Can(new SistemaEntidadAccion() { IdSistemaEntidadAccion = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            //liSistemaEntidadEstado.Visible = SistemaEntidadEstadoService.Current.Can(new SistemaEntidadEstado() { IdSistemaEntidadEstado = 0 }, ActionConfig.LIST, UIContext.Current.ContextUser);
            
        }
        #endregion Can        

        #region Command Events

        #region Configuration
        protected void btLanguage_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "LanguagePageList.aspx", false);
        }
        protected void btTextCategory_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "TextCategoryPageList.aspx", false);
        }
        protected void btParameterCategory_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "ParameterCategoryPageList.aspx", false);
        }
        protected void btNumeration_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "NumerationPageList.aspx", false);
        }
        protected void btText_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "TextPageList.aspx", false);
        }
        protected void btTextLanguage_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "TextLanguagePageList.aspx", false);
        }
        protected void btParameter_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "ParameterPageList.aspx", false);
        }        
        protected void btAuditSession_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "AuditSessionPageList.aspx", false);
        }
        protected void btAuditOperation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "AuditOperationPageList.aspx", false);
        }
        protected void btConfiguracion_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "ConfigurationPageList.aspx", false);
        }
        protected void btConfiguracionCategoria_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(GeneralPath + "ConfigurationCategoryPageList.aspx", false);
        } 
        #endregion

        protected void btCaracterEconomicoTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "CaracterEconomicoTipoPageList.aspx", false); }
        protected void btClasificacionGeograficaTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "ClasificacionGeograficaTipoPageList.aspx", false); }
        protected void btFinalidadFuncionTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "FinalidadFuncionTipoPageList.aspx", false); }
        protected void btClasificacionGastoTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "ClasificacionGastoTipoPageList.aspx", false); }
        protected void btFuenteFinanciamientoTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "FuenteFinanciamientoTipoPageList.aspx", false); }
        protected void btMonedaCotizacion_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "MonedaCotizacionPageList.aspx", false); }
       // protected void btProcesoTipo_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "ProcesoTipoPageList.aspx", false); }

        protected void btPermiso_OnClick(object sender, EventArgs e) { Response.Redirect(GeneralPath + "PermisoPageList.aspx", false); }
        protected void btActividad_OnClick(object sender, EventArgs e) { Response.Redirect(GeneralPath + "ActividadPageList.aspx", false); }
        protected void btPerfil_OnClick(object sender, EventArgs e) { Response.Redirect(GeneralPath + "PerfilPageList.aspx", false); }

        protected void btSistemaEntidad_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "SistemaEntidadPageList.aspx", false); }
        protected void btSistemaEntidadEstado_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "SistemaEntidadEstadoPageList.aspx", false); }
        protected void btEstado_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "EstadoPageList.aspx", false); }
        protected void btConfigMensajes_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "ConfigMensajesPageList.aspx", false); }
        protected void btSistemaEntidadAccion_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "SistemaEntidadAccionPageList.aspx", false); }
        protected void btSistemaAccion_OnClick(object sender, EventArgs e) { Response.Redirect(PagePath + "SistemaAccionPageList.aspx", false); }
        protected void btSistemaCommand_OnClick(object sender, EventArgs e) { Response.Redirect(GeneralPath + "SistemaCommandPageList.aspx", false); }
        protected void btCacheManager_OnClick(object sender, EventArgs e) { Response.Redirect(GeneralPath + "CacheManagerPageEdit.aspx", false); }

        protected void btLBListarProyectos_Click(object sender, EventArgs e) { Response.Redirect(GeneralPath + "CacheManagerPageEdit.aspx", false); }
        protected void btLBActualizarTemplate_Click(object sender, EventArgs e) { Response.Redirect(GeneralPath + "CacheManagerPageEdit.aspx", false); }
        protected void btLBSubirTemplate_Click(object sender, EventArgs e) { Response.Redirect(GeneralPath + "AdministracionTemplate.aspx", false); }

        #endregion Command Events


//Link de acceso a Cubos
        protected void btLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cubos/CubosPrincipal.aspx");
        }

        protected void btLinkButtonConfigurarMatching_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matching/Matching_Config.aspx");
        }
    }
}
