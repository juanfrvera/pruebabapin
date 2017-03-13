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

namespace UI.Web
{
    public partial class WebControl_IndicadorClaseAutocompleteSinSector : WebControlAutocompleteSimple<nc.IndicadorClaseFilter>
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

        #region Override
        protected override void _SetControls()
        {
            this._txtSelect = txtSelect;
            this._hdSelect = hdSelect;
            this._pnControl = pnControl;
            this._hdFilter = hdFilter;
            base._SetControls();

        }
        protected override void _Initialize()
        {
            base._Initialize();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _txtSelect.Width = 650;
        }
        public override int? ValueId
        {
            get
            {
                if (Value == null) return null;
                return Value.ID;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                {


                    SimpleList<int> list = new SimpleList<int>();

                    //SimpleResult<int> result = IndicadorClaseService.Current.GetSimpleList(new Contract.IndicadorClaseFilter() { IdIndicadorClase = value.Value }).FirstOrDefault();

                    IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = value.Value }).FirstOrDefault();


                    if (value != null)
                    {

                        Value = new SimpleIntResult() { ID = result.ID, Text = "[" + result.Sigla.Trim() + "] " + result.Nombre.Trim() + " (" + result.Unidad_Sigla.Trim() + ")" };
                    }
                    else
                    {
                        UIHelper.Clear(txtSelect);
                    }



                }
                else
                {
                    Value = null;

                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), ClientID, ClientID + "SetAutocomplete();", true);
        }

        #endregion

    }
}