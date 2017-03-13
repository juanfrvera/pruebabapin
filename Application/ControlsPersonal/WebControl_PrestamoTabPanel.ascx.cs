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
using UI.Web;
using System.Collections.Generic;

namespace UI.Web
{

    public partial class WebControl_PrestamoTabPanel : WebControlPageTabPanel
    {
        #region Overrides
        public override List<PageLinkData> GetUrls()
        {
            return new List<PageLinkData>(new PageLinkData[]{
                 new PageLinkData(){ Text="Generales", Url="~/Prestamo/PrestamoPageEdit.aspx" ,IsNewVisible=true }
                ,new PageLinkData(){ Text="Alcance Geográfico", Url="~/Prestamo/PrestamoAlcanceGeograficoPageEdit.aspx" }
                ,new PageLinkData(){ Text="Objetivos", Url="~/Prestamo/PrestamoObjetivosPageEdit.aspx" }
                ,new PageLinkData(){ Text="Convenio", Url="~/Prestamo/PrestamoConvenioPageEdit.aspx" }
                ,new PageLinkData(){ Text="Componentes", Url="~/Prestamo/PrestamoComponentesPageEdit.aspx" }
                ,new PageLinkData(){ Text="Productos", Url="~/Prestamo/PrestamoProductosPageEdit.aspx" }
                ,new PageLinkData(){ Text="Interv. DNIP", Url="~/Prestamo/PrestamoEditDictamenPageEdit.aspx" }
                ,new PageLinkData(){ Text="Adjuntar", Url="~/Prestamo/PrestamoAdjuntarPageList.aspx" }
            });
        }
        protected override void SetValue()
        {
            UIHelper.SetValue(rpTab, Urls);
            upTabPanel.Update();
        }
        #endregion
    }
}