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
	public partial class PrestamoList : WebControlGrid<nc.PrestamoResult,int>    
    {
		public override GridView GridView { get { return this.Grid;} }
        protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        #region Can
        public override bool CanById(object id, string actionName)
        {
            PrestamoResult item = GetItem(ConvertId(id));
            if (item == null) return false;
            if(!PageBase.CanByOffice(item.PerfilOficinas, actionName, item.IdEstadoActual))return false;
            return PrestamoService.Current.Can(item, actionName, UIContext.Current.ContextUser);
        }
        #endregion
    }
}
