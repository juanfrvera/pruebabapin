﻿using System;
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
    public partial class WebControl_EvaluacionFactibilidadHead : WebControlHead<nc.ProyectoSeguimiento> 
    {
        #region Overrides
        protected override void Clear()
        {
            UIHelper.Clear(lblNumero);
            UIHelper.Clear(lblDescripcion);
            UIHelper.Clear(lblFechaIngreso);
            UIHelper.Clear(lblFechaUltimaModificacion);
        }      
        protected override void SetValue()
        {
         /*   UIHelper.SetValue(lblNumero, Result.Codigo);
            UIHelper.SetValue(lblDescripcion, Result.ProyectoDenominacion);
            UIHelper.SetValue(lblFechaIngreso,Result.FechaAlta.ToString("dd/MM/yyyy"));
            UIHelper.SetValue(lblFechaUltimaModificacion, Result.FechaModificacion.ToString("dd/MM/yyyy"));*/
        }
        #endregion        
    }
}