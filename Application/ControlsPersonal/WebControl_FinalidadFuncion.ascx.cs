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
using nc = Contract;

namespace UI.Web.ControlsPersonal
{
    public partial class WebControl_FinalidadFuncion : WebControlTreeSelect<nc.FinalidadFuncionFilter>
    {
        #region Properties
        public override bool RequiredValue
        {
            get
            {
                return this.required.Enabled;
            }
            set
            {
                this.required.Enabled = value;
            }
        }
        public override string RequiredMessage
        {
            set
            {
                this.required.ErrorMessage = value;
            }
        }
        public override string ValidationGroup
        {
            get
            {
                return this.required.ValidationGroup;
            }
            set
            {
                this.required.ValidationGroup = value;
            }
        }
        #endregion

        protected override void _SetControls()
        {
            this._txtSelect = txtSelect;
            this._hdSelect = hdSelect;
            this._pnControl = pnControl;
            this._hdFilter = hdFilter;
            RootText = "Root";
            TreeTitle = "Finalidad - Función";
            TreeHandler = "../Handlers/FinalidadFuncionHandler.ashx";
            AutocompleteHandler = "../Handlers/FinalidadFuncionAutocompleteHandler.ashx";
            base._SetControls();
        }
        public override int? ValueId
        {
            get
            {
                if (Value == null) return null;
                return Value.Id;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    Value = FinalidadFuncionService.Current.GetNodesResult(new Contract.FinalidadFuncionFilter() { IdFinalidadFuncion = value.Value }).FirstOrDefault();
                else
                    Value = null;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), ClientID, ClientID + "SetAutocomplete();", true);
        }
    }
}