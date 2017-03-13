using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using System.Threading;
using Newtonsoft.Json;
using Service;

namespace UI.Web
{  
    public partial class WebControl_LocalizacionGeograficaOLD : WebControl_TreeSelect
    {
        protected override void _Initialize()
        {
            base._Initialize();
            RootText="Argentina";
            Handler = "../Handlers/ClasificacionGeograficaHandler.ashx";
        }

        public override int? ValueId
        {
            get {
                if (Value == null) return null;
                return Value.Id;
                }
            set {
                    if (value.HasValue)
                        Value = ClasificacionGeograficaService.Current.GetNodesResult(new Contract.ClasificacionGeograficaFilter() { IdClasificacionGeografica = value.Value }).FirstOrDefault();
                    else
                        Value = null;
                }
        }
        public Unit Width
        {
            get { return this.txtSelect.Width; }
            set { Unit valor = new Unit(value.Value - 40); this.txtSelect.Width = valor; }
        }
        
    }
}