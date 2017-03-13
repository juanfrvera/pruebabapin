using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class ProyectoCambioEstructuraList : WebControlGridWithSelection<nc.ProyectoResult, int>    
    {
        public override GridView GridView { get { return this.Grid; } }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #region Can        
        public override bool CanById(object id, string actionName)
        {
            ProyectoResult item = GetItem(ConvertId(id));
            if (item == null) return false;
            if(!PageBase.CanByOffice(item.PerfilOficinas, actionName, item.IdEstado))return false;
            return CanByResult(item, actionName);            
        }
        #endregion
    }
}
