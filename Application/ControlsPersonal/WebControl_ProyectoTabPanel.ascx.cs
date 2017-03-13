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
using System.IO;

namespace UI.Web
{

    public partial class WebControl_ProyectoTabPanel : WebControlPageTabPanel
    {
        #region Overrides
        //public override List<PageLinkData> GetUrls()
        //{
        //    return new List<PageLinkData>(new PageLinkData[]{
        //         new PageLinkData(){ Text="Generales", Url="~/Proyecto/ProyectoPageEdit.aspx" ,IsNewVisible=true }
        //        ,new PageLinkData(){ Text="Alcance Geográfico", Url="~/Proyecto/ProyectoAlcanceGeograficoPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Objetivos", Url="~/Proyecto/ProyectoObjetivosPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Producto Intermedio", Url="~/Proyecto/ProyectoProductoIntermedioPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Cronograma", Url="~/Proyecto/ProyectoCronogramaPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Evaluación", Url="~/Proyecto/ProyectoEvaluacionPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Interv. DNIP", Url="~/Proyecto/ProyectoDNIPPageEdit.aspx" }
        //        ,new PageLinkData(){ Text="Adjuntar", Url="~/Proyecto/ProyectoAdjuntarPageList.aspx" }
        //        ,new PageLinkData(){ Text="Calidad", Url="~/Proyecto/ProyectoCalidadPageEdit.aspx" }
        //    });
        //}        
        protected override void SetValue()
        {
            UIHelper.SetValue(rpTab, Urls);
            upTabPanel.Update();
        }
        #endregion
        
    }
}