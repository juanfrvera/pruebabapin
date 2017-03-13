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
    public partial class WebControl_ProyectoSeguimientoHead : WebControlHead<nc.ProyectoSeguimientoResult> 
    {
        #region Overrides
        protected override void Clear()
        {
            UIHelper.Clear(lblNumeroDenominacion);
            UIHelper.Clear(lblCodSaf);
            UIHelper.Clear(lblDescripcion);
        }      
        protected override void SetValue()
        {
            UIHelper.SetValue(lblNumeroDenominacion, Result.IdProyectoSeguimiento);
            UIHelper.SetValue(lblCodSaf, Result.Saf_Codigo);
            UIHelper.SetValue(lblDescripcion, Result.Denominacion);
        }
        public override bool HeadVisible
        {
            get
            {
                return tbHead.Visible;
            }
            set
            {
                tbHead.Visible = value;
            }
        }
        #endregion        
    }
}