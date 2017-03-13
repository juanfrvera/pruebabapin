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
    public partial class WebControl_Oficinas : WebControlTreeSelect<nc.OficinaFilter>
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
        public override void Focus()
        {
            txtSelect.Focus();
        }

        public short  TabIndex {
            get { return txtSelect.TabIndex; }
            set { txtSelect.TabIndex = value; } 
        }
        #endregion

        #region Override
        protected override void _SetControls()
        {
            this._txtSelect = txtSelect;
            this._hdSelect = hdSelect;
            this._pnControl = pnControl;
            this._hdFilter = hdFilter;
            RootText = "Root";
            TreeTitle = "Oficinas";
            TreeHandler = "../Handlers/OficinaHandler.ashx";
            AutocompleteHandler = "../Handlers/OficinaAutocompleteHandler.ashx";
            ddlJurisdiccion.Attributes["onchange"] = "SelectJurisdiccion(this.value);";
            //Si usa el arbolde jurisdiccion solo debe mostrar los visible
            Filter.Visible = true;
            base._SetControls();
        }
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<Jurisdiccion>(ddlJurisdiccion, JurisdiccionService.Current.GetList(), "Nombre", "IdJurisdiccion", new Jurisdiccion() { IdJurisdiccion = 0, Nombre = "Seleccione Jurisdicción" });
            Filter.IdJurisdiccion = 0;
        }
        #endregion



        public int? IsSaf { get; set; }
        public override  int? ValueId
        {
            get
            {
                if (Value == null) return null;
                return Value.Id;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                {
                    Value = OficinaService.Current.GetNodesResult(new Contract.OficinaFilter() { IdOficina = value.Value }).FirstOrDefault();
                    if (value.Value == 0)
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
    }
}