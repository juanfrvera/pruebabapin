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
    public partial class WebControl_IndicadorClaseTree : WebControlTreeSelect<nc.IndicadorClaseFilter>
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
            TreeTitle = "Indicador";
            TreeHandler = "../Handlers/IndicadorClaseHandler.ashx";
            AutocompleteHandler = "../Handlers/IndicadorClaseAutocompleteHandler.ashx";
            base._SetControls();
            ddlSectorInd.Attributes["onchange"] = ClientID + "SelectSector();";
            
        }
        //German 20140511 - Tarea 124
        public DropDownList Sectores
        {
            get
            {
                return ddlSectorInd;
            }
        }
        //Fin German 20140511 - Tarea 124
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
                {
                    Value = IndicadorClaseService.Current.GetNodesResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = value.Value }).FirstOrDefault();
                    if (value.Value == 0)
                    {
                        UIHelper.Clear(txtSelect);
                    }
                }
                else
                    Value = null;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), ClientID, ClientID + "SetAutocomplete();", true);
        }

        protected override void _Initialize()
        {
            base._Initialize();
            //German 10140419 - Tarea 124
            /*
            UIHelper.Load<IndicadorRubro>(ddlSectorInd, IndicadorRubroService.Current.GetList(new nc.IndicadorRubroFilter { Activo = true }),
                          "Nombre", "IdIndicadorRubro", new IndicadorRubro() { IdIndicadorRubro = -1, Nombre = "Todos lo sectores" });
            */
/*            UIHelper.Load<IndicadorRubro>(ddlSectorInd, IndicadorRubroService.Current.GetList(new nc.IndicadorRubroFilter { Activo = true }),
                          "Nombre", "IdIndicadorRubro");*/
            //Fin German 10140419 - Tarea 124
        }

        protected override void _Load()
        {
            base._Load();

            UIHelper.Load<IndicadorRubro>(ddlSectorInd, IndicadorRubroService.Current.GetList(new nc.IndicadorRubroFilter { Activo = true }),
                          "Nombre", "IdIndicadorRubro");
            //Fin German 10140419 - Tarea 124
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _txtSelect.Width = 300;
        }

        public override void Clear()
        {
            UIHelper.Clear(ddlSectorInd);
            Filter = new Contract.IndicadorClaseFilter();
            base.Clear();
        }

    }
}