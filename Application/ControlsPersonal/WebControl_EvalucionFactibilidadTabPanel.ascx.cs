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
using nc=Contract;
using System.Collections.Generic;

namespace UI.Web
{
    public partial class WebControl_EvaluacionFactibilidadTabPanel : WebControlPageTabPanel
    {
        #region Overrides
        public override List<PageLinkData> GetUrls()
        {
            return new List<PageLinkData>(new PageLinkData[]{
                 new PageLinkData(){ Text="Datos Generales", Url="~/Pages/EvaluacionFactibilidadPageEdit.aspx" ,IsNewVisible=true }
                ,new PageLinkData(){ Text="Seguimiento de Estados", Url="~/Pages/EvaluacionFactibilidadSeguimientoPageEdit.aspx" }
                ,new PageLinkData(){ Text="Adjuntar", Url="~/Pages/EvaluacionFactibilidadAdjuntarPageList.aspx" }              
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