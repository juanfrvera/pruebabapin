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
    public partial class WebControl_ProyectoDictamenTabPanel : WebControlPageTabPanel
    {
        #region Overrides
        public override List<PageLinkData> GetUrls()
        {
            return new List<PageLinkData>(new PageLinkData[]{
                 new PageLinkData(){ Text="Datos Generales", Url="~/Proyecto/ProyectoDictamenFactibilidadPageEdit.aspx" ,IsNewVisible=true }
                 ,new PageLinkData(){ Text="Seguimiento de Estados", Url="~/Proyecto/ProyectoDictamenEstadoPageEdit.aspx" }
                 ,new PageLinkData(){ Text="Datos del Dictamen", Url="~/Proyecto/ProyectoDictamenPageEdit.aspx" }
                 ,new PageLinkData(){ Text="Adjuntar", Url="~/Proyecto/ProyectoDictamenFilePageList.aspx" }
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