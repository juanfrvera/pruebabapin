using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using System.Threading;

namespace UI.Web
{
    public abstract class WebControlAutocomplete<TIdType> : WebControlBase
    {
        #region Atributos
        private SimpleResult<TIdType> selecttedValue;
        private bool doAutoPostback = false;
        private string tag = "";
        #endregion

        #region Propiedades
        public SimpleResult<TIdType> SelecttedValue
        {
            get
            {
                if (selecttedValue == null)
                    selecttedValue = new SimpleResult<TIdType> { ID = ValueId, Text = ValueText };
                return selecttedValue;
            }
        }
        public abstract string WebServiceName { set; }
        public abstract string ServiceMethod { set; }
        public abstract string DelimiterCharacters { set; }
        public abstract int MinimumPrefixLength { set; } 
        public abstract TIdType ValueId { get; set; }
        public abstract string ValueText { get; set; }
        public abstract bool RequiredValue { get; set; }
        public abstract string RequiredMessage { set; }
        public abstract int CompletionSetCount { set; }
        public abstract string CssClass { set; }
        public abstract string ValidationGroup { set; }
        public abstract int Width { set; }
        public bool AutoPostback 
        {
            get { return doAutoPostback; }
            set { doAutoPostback = value; } 
        }
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        #endregion

        #region Metodos
        public abstract void Clear();
        #endregion
    }

    public partial class WebControl_Autocomplete : WebControlAutocomplete<int?>
    {
        #region Atributes
        private bool showClearButton = false;
        protected string dofocus = "";
        #endregion Atributes

        #region Propiedades
        public override string WebServiceName 
        {
            set { wcAutoComplete.ServicePath = value; }
        }
        public override int Width
        {
            set { acTextBox.Width = value; }
        }
        public override string ServiceMethod 
        {
            set { wcAutoComplete.ServiceMethod = value; }
        }
        public override string DelimiterCharacters 
        {
            set { wcAutoComplete.DelimiterCharacters = value; }
        }
        public override int MinimumPrefixLength
        {
            set { wcAutoComplete.MinimumPrefixLength = value; }
        } 
        public override int? ValueId
        {
            get 
            { 
                int res = 0;
                int.TryParse(acHidden.Value, out res);
                return (int?)res; 
            }
            set 
            { 
                acHidden.Value = value.ToString(); 
            }
        }
        public bool Enabled
        {
            get {
                return acTextBox.Enabled;
            }
            set { acTextBox.Enabled = value ; }
        }
        public override string ValueText
        {
            get { return acTextBox.Text; }
            set { acTextBox.Text = value; }
        }
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
        public override int CompletionSetCount
        {
            set
            {
                this.wcAutoComplete.CompletionSetCount = value;
            }
        }
        public override string CssClass
        {
            set { acTextBox.CssClass = value; }
        }
        public override string ValidationGroup
        {
            set
            {
                this.acTextBox.ValidationGroup = value;
                this.required.ValidationGroup = value;
            }
        }        
        public bool IsSelectionItemPostBack
        {
            get
            {
                return this.acHiddenIsPosback.Value != "0";
            }
        }
        public bool ShowClearButton
        {
            set { showClearButton = value; }
            get { return showClearButton; }
        }
        #endregion

        #region Metodos
        protected override void _Initialize()
        {
            base._Initialize();
            wcAutoComplete.BehaviorID = this.ID;
            acTextBox.Attributes["onblur"] = this.ID + "LostFocus()";
            wcAutoComplete.OnClientPopulating = this.ID + wcAutoComplete.OnClientPopulating;
            wcAutoComplete.OnClientPopulated = this.ID + wcAutoComplete.OnClientPopulated;
            wcAutoComplete.OnClientItemSelected = this.ID + wcAutoComplete.OnClientItemSelected;

            base.Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Autocomplete.js", Page.ResolveClientUrl("~/App_Scripts/Autocomplete.js"));

            this.Clear();
        }
        public override void Clear()
        {
            UIHelper.Clear(acTextBox);
            acHidden.Value = "0";
            this.btnClear.Visible = false;
            this.acTextBox.ReadOnly = false;
            wcAutoComplete.Enabled = true;
        }
        public override void Focus()
        {
            acTextBox.Focus();
        }
        public void SetInitialFocus()
        {
            dofocus = "setTimeout(\"autocompleteDoFocus('" + acTextBox.ClientID + "')\", 1000)";
        }
        #endregion

        #region Eventos
        public event EventHandler ValueChanged;
        public void OnValueChanged(object sender, EventArgs e)
        {   
            if (ValueChanged != null)
                ValueChanged(sender, e);

            this.acHiddenIsPosback.Value = "0";

            if (ShowClearButton)
            {
                this.btnClear.Visible = true;
                this.acTextBox.ReadOnly = true;
                wcAutoComplete.Enabled = false;
            }
        }
        public event EventHandler ClearControl;
        public void OnClearControl(object sender, EventArgs e)
        {
            if (ClearControl != null)
                ClearControl(sender, e);

            this.Clear();
            this.acTextBox.Focus();
        }
        #endregion
    }
}