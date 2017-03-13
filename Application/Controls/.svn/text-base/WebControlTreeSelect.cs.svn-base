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
    public interface IWebControlTreeSelect
    {
        string AutocompleteHandler { get; set; }
        bool Autopostback { get; set; }
        void Clear();
        event EventHandler ClearControl;
        void Focus();
        void OnClearControl(object sender, EventArgs e);
        void OnValueChanged(object sender, EventArgs e);
        string RootText { get; set; }
        string TreeHandler { get; set; }
        NodeResult Value { get; set; }
        event EventHandler ValueChanged;
        int? ValueId { get; set; }
        Unit Width { get; set; }
        bool RequiredValue { get; set; }
        string RequiredMessage { set; }
        string ValidationGroup { get; set; }
    }
    public interface IWebControlAutocompleteSimple
    {
        string AutocompleteHandler { get; set; }
        bool Autopostback { get; set; }
        void Clear();
        event EventHandler ClearControl;
        void Focus();
        void OnClearControl(object sender, EventArgs e);
        void OnValueChanged(object sender, EventArgs e);
        string RequiredMessage { set; }
        bool RequiredValue { get; set; }
        SelectOptionEnum SelectOption { get; set; }
        ShowOptionEnum ShowOption { get; set; }
        string ValidationGroup { get; set; }
        event EventHandler ValueChanged;
        int? ValueId { get; set; }
        Unit Width { get; set; }       
        SimpleIntResult Value { get; set; }
    }

    public abstract partial class WebControlAutocompleteBase : WebControlBase
    {
        #region Controls
        protected TextBox _txtSelect;
        protected HiddenField _hdSelect;
        protected HiddenField _hdFilter;
        protected Panel _pnControl;
        protected Unit width = 1;
        #endregion

        #region Page Methods
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _pnControl.Width = Width;
            _txtSelect.Width = (int)(Width.Value - (double)80);
        }
        #endregion

        #region Properties
        public string AutocompleteHandler
        {
            get {
                if (ViewState["AutocompleteHandler"] == null) return "";
                  return ViewState["AutocompleteHandler"].ToString(); }
            set { ViewState["AutocompleteHandler"] = value; }
        }
        private bool autopostback;
        public virtual bool Autopostback
        {
            get
            {
                if (ViewState["autopostback"] != null)
                    autopostback = bool.Parse(ViewState["autopostback"].ToString());
                else
                    autopostback = false;
                return autopostback;
            }
            set
            {
                autopostback = value;
                ViewState["autopostback"] = value;
            }
        }
        private SelectOptionEnum selectOption= SelectOptionEnum.Undefined;
        public SelectOptionEnum SelectOption
        {
            get
            {
                if (selectOption == SelectOptionEnum.Undefined)
                {
                    if (ViewState["selectOption"] != null) 
                        selectOption = (SelectOptionEnum) int.Parse(ViewState["selectOption"].ToString());
                }
                return selectOption;
            }
            set
            {
                selectOption = value;
                ViewState["selectOption"] = (int) value;
            }
        }
        public ShowOptionEnum showOption = ShowOptionEnum.Undefined;
        public ShowOptionEnum ShowOption
        {
            get
            {
                if (showOption == ShowOptionEnum.Undefined)
                {
                    if (ViewState["showOption"] != null)
                        showOption = (ShowOptionEnum)int.Parse(ViewState["showOption"].ToString());
                }
                return showOption;
            }
            set
            {
                showOption = value;
                ViewState["showOption"] = (int)value;
            }
        }
       
        public virtual int? ValueId { get; set; }
        public Unit Width
        {
            get
            {
                if (width == 1)
                {
                    if (ViewState["width"] != null) width = (Unit)ViewState["width"];
                    else width = 300;
                }
                return width;
            }
            set
            {
                width = value;
                ViewState["width"] = value;
            }
        }
        public abstract bool RequiredValue { get; set; }
        public abstract string RequiredMessage { set; }
        public abstract string ValidationGroup { get; set; }
        #endregion

        #region Methods
        public virtual void Clear()
        {
            UIHelper.Clear(_txtSelect);
        }
        public virtual void Focus()
        {
            _txtSelect.Focus();
        }
        #endregion

        #region Eventos
        public event EventHandler ValueChanged;
        public void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }
        public event EventHandler ClearControl;
        public void OnClearControl(object sender, EventArgs e)
        {
            if (ClearControl != null)
                ClearControl(sender, e);
        }
        #endregion
    }

    public abstract partial class WebControlAutocompleteSimple<TFilter> : WebControlAutocompleteBase, IWebControlAutocompleteSimple
      where TFilter : nc.Filter, new()
    {
        #region Page Methods
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Filter = Filter;
        }
        #endregion

        #region Properties
        public short TabIndex
        {
            get { return _txtSelect != null ? _txtSelect.TabIndex : (short)-1; }
            set { if (_txtSelect != null)_txtSelect.TabIndex = value; }
        }
        private TFilter filter;
        public TFilter Filter
        {
            get
            {

                if (filter == null)
                {
                    if (_hdFilter.Value != null || _hdFilter.Value.Trim() != string.Empty)
                        filter = JsonConvert.DeserializeObject<TFilter>(_hdFilter.Value);
                    if (filter == null) filter = new TFilter();
                }
                return filter;
            }
            set
            {
                filter = value;
                if (filter != null)
                    _hdFilter.Value = JsonConvert.SerializeObject(filter);
            }
        }
        public SimpleIntResult Value
        {
            get
            {
                if (_hdSelect.Value == null || _hdSelect.Value.Trim() == string.Empty) return null;
                return JsonConvert.DeserializeObject<SimpleIntResult>(_hdSelect.Value);
            }
            set
            {
                if (value == null)
                    _hdSelect.Value = null;
                else
                {
                    _hdSelect.Value = JsonConvert.SerializeObject(value);
                    UIHelper.SetValue(_txtSelect, Value.Text);
                }
            }
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
                    Value.ID = value.HasValue ? value.Value : 0;
                }
            }
        }

        public override void Clear()
        {
            Value = null;
            UIHelper.Clear(_txtSelect);
        }

        #endregion
    }

    public abstract partial class WebControlNodeAutocomplete<TFilter> : WebControlAutocompleteBase
       where TFilter : nc.Filter, new()
    {

        #region Page Methods
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Filter = Filter;
        }
        #endregion

        #region Properties
        public short TabIndex
        {
            get { return  _txtSelect != null?_txtSelect.TabIndex:(short)-1; }
            set { if(_txtSelect != null)_txtSelect.TabIndex=value; }
        }

        private TFilter filter;
        public TFilter Filter
        {
            get
            {

                if (filter == null)
                {
                    if (_hdFilter.Value != null || _hdFilter.Value.Trim() != string.Empty)
                        filter = JsonConvert.DeserializeObject<TFilter>(_hdFilter.Value);
                    if (filter == null) filter = new TFilter();
                }
                return filter;
            }
            set
            {
                filter = value;
                if (filter != null)
                    _hdFilter.Value = JsonConvert.SerializeObject(filter);
            }
        }
        public NodeResult Value
        {
            get
            {
                if (_hdSelect.Value == null || _hdSelect.Value.Trim() == string.Empty) return null;
                return JsonConvert.DeserializeObject<NodeResult>(_hdSelect.Value);
            }
            set
            {
                if (value == null)
                    _hdSelect.Value = null;
                else
                {
                    _hdSelect.Value = JsonConvert.SerializeObject(value);
                    UIHelper.SetValue(_txtSelect, "[" + Value.BreadcrumbCodigo + "] " + Value.DescripcionInvertida);
                }
            }
        }       
        #endregion

        #region Methods
        public override void Clear()
        {
            Value = null;
            UIHelper.Clear(_txtSelect);
        }
        #endregion
    }
    
    public abstract partial class WebControlTreeSelect<TFilter> : WebControlNodeAutocomplete<TFilter>, IWebControlTreeSelect
       where TFilter : nc.Filter, new()
    {
        #region Controls
        protected string treeTitle;
        #endregion

        #region Page Methods
        #endregion

        #region Properties
        public string TreeHandler { get; set; }
        public string RootText { get; set; }
        public string TreeTitle
        {
            get
            {
                if (treeTitle == null)
                {
                    if (ViewState["treeTitle"] != null)
                        treeTitle = ViewState["treeTitle"].ToString();
                }
                return treeTitle;
            }
            set
            {
                treeTitle = value;
                ViewState["treeTitle"] = value;
            }
        }
        public bool Enabled
        {
            get { return this._pnControl.Enabled; }
            set { this._pnControl.Enabled = value; }
        }
        public Panel PnControl {
            get {
                return _pnControl;
            }
            set {
                _pnControl = value;
            }
        }
        #endregion
    }
}
