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
    public partial class ProcesoTipoList : WebControlGrid<nc.ProcesoTipoResult, int>    
    {
        public override GridView GridView { get { return this.Grid; } }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        protected override bool Can(int id, string actionName)
        {
            return ProcesoTipoService.Current.Can(new Contract.ProcesoTipo() { IdProcesoTipo = id }, actionName, UIContext.Current.ContextUser);
        }
    }
}
