using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wc=System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Web.UI.Design;
using System.Collections.Generic;
using Contract;
using c=Contract;
using System.Drawing.Design;
using System.Security.Permissions;


namespace UI.Web
{
    
//    [SupportsEventValidation, DefaultProperty("Text"), Designer("System.Web.UI.Design.WebControls.ButtonDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DefaultEvent("Click"), ToolboxData("<{0}:Button runat=\"server\" Text=\"Button\"></{0}:Button>"), DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), AspNetHostingPermission(SecurityAction.LinkDemand, Level=AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level=AspNetHostingPermissionLevel.Minimal)]
//    public class ListAction : WebControl, IButtonControl, IPostBackEventHandler
//    {

//        private List<int> actionIds;

//        [Category("ActionIds"), Description("Ids of actions")]
//        public string ActionIds { get; set; }

//        protected override void CreateChildControls()
//        {
//            string[] ids = ActionIds.Split(',');

//            Controls.Clear();
//            Table table = new Table();
//            TableRow row = new TableRow();
//            foreach (string sId in ids)
//            {
//                int id = 0;
//                if (!int.TryParse(sId, out id)) continue;

//                SistemaAccion accion = SolutionContext.Current.AccionesCache.GetById(id);

//                TableCell cell = new TableCell();
//                wc.ImageButton img = new wc.ImageButton();
//                img.ImageUrl = "~/Images/add.png";
//                img.ID = "img" + accion.Nombre;
//                img.ToolTip = accion.Nombre;
//                cell.Controls.Add(img);
//                row.Cells.Add(cell);
//            }
//            table.Rows.Add(row);
//            this.Controls.Add(table);

//        }



//    // Fields
//    private static readonly object EventClick = new object();
//    private static readonly object EventCommand = new object();

//    // Events
//    public event EventHandler Click
//    {
//        add
//        {
//            base.Events.AddHandler(EventClick, value);
//        }
//        remove
//        {
//            base.Events.RemoveHandler(EventClick, value);
//        }
//    }    
//    public event CommandEventHandler Command
//    {
//        add
//        {
//            base.Events.AddHandler(EventCommand, value);
//        }
//        remove
//        {
//            base.Events.RemoveHandler(EventCommand, value);
//        }
//    }

//    // Methods
//    public ListAction() : base(HtmlTextWriterTag.Input)
//    {
//    }

//    protected override void AddAttributesToRender(HtmlTextWriter writer)
//    {
//        bool useSubmitBehavior = this.UseSubmitBehavior;
//        if (this.Page != null)
//        {
//            this.Page.VerifyRenderingInServerForm(this);
//        }
//        if (useSubmitBehavior)
//        {
//            writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
//        }
//        else
//        {
//            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
//        }
//        PostBackOptions postBackOptions = this.GetPostBackOptions();
//        string uniqueID = this.UniqueID;
//        if ((uniqueID != null) && ((postBackOptions == null) || (postBackOptions.TargetControl == this)))
//        {
//            writer.AddAttribute(HtmlTextWriterAttribute.Name, uniqueID);
//        }
//        writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
//        bool isEnabled = base.IsEnabled;
//        string firstScript = string.Empty;
//        if (isEnabled)
//        {
//            firstScript = Util.EnsureEndWithSemiColon(this.OnClientClick);
//            if (base.HasAttributes)
//            {
//                string str3 = base.Attributes["onclick"];
//                if (str3 != null)
//                {
//                    firstScript = firstScript + Util.EnsureEndWithSemiColon(str3);
//                    base.Attributes.Remove("onclick");
//                }
//            }
//            if (this.Page != null)
//            {
//                string postBackEventReference = this.Page.ClientScript.GetPostBackEventReference(postBackOptions, false);
//                if (postBackEventReference != null)
//                {
//                    firstScript = Util.MergeScript(firstScript, postBackEventReference);
//                }
//            }
//        }
//        if (this.Page != null)
//        {
//            this.Page.ClientScript.RegisterForEventValidation(postBackOptions);
//        }
//        if (firstScript.Length > 0)
//        {
//            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, firstScript);
//            //if (base.EnableLegacyRendering)
//            //{
//                writer.AddAttribute("language", "javascript", false);
//            //}
//        }
//        if (this.Enabled && !isEnabled)
//        {
//            writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
//        }
//        base.AddAttributesToRender(writer);
//    }  


//    protected virtual PostBackOptions GetPostBackOptions()
//    {
//        PostBackOptions options = new PostBackOptions(this, string.Empty);
//        options.ClientSubmit = false;
//        if (this.Page != null)
//        {
//            if (this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0))
//            {
//                options.PerformValidation = true;
//                options.ValidationGroup = this.ValidationGroup;
//            }
//            if (!string.IsNullOrEmpty(this.PostBackUrl))
//            {
//                options.ActionUrl = HttpUtility.UrlPathEncode(base.ResolveClientUrl(this.PostBackUrl));
//            }
//            options.ClientSubmit = !this.UseSubmitBehavior;
//        }
//        return options;
//    }

//    protected virtual void OnClick(EventArgs e)
//    {
//        EventHandler handler = (EventHandler) base.Events[EventClick];
//        if (handler != null)
//        {
//            handler(this, e);
//        }
//    }

//    protected virtual void OnCommand(CommandEventArgs e)
//    {
//        CommandEventHandler handler = (CommandEventHandler) base.Events[EventCommand];
//        if (handler != null)
//        {
//            handler(this, e);
//        }
//        base.RaiseBubbleEvent(this, e);
//    }

//    //protected internal override void OnPreRender(EventArgs e)
//    //{
//    //    base.OnPreRender(e);
//    //    if ((this.Page != null) && base.IsEnabled)
//    //    {
//    //        if ((this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0)) || !string.IsNullOrEmpty(this.PostBackUrl))
//    //        {
//    //            this.Page.RegisterWebFormsScript();
//    //        }
//    //        else if (!this.UseSubmitBehavior)
//    //        {
//    //            this.Page.RegisterPostBackScript();
//    //        }
//    //    }
//    //}

//    protected virtual void RaisePostBackEvent(string eventArgument)
//    {
//        //base.ValidateEvent(this.UniqueID, eventArgument);
//        if (this.CausesValidation)
//        {
//            this.Page.Validate(this.ValidationGroup);
//        }
//        this.OnClick(EventArgs.Empty);
//        this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
//    }

//    //protected internal override void RenderContents(HtmlTextWriter writer)
//    //{
//    //}

//    void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
//    {
//        this.RaisePostBackEvent(eventArgument);
//    }

//    // Properties
//    public virtual bool CausesValidation
//    {
//        get
//        {
//            object obj2 = this.ViewState["CausesValidation"];
//            if (obj2 != null)
//            {
//                return (bool) obj2;
//            }
//            return true;
//        }
//        set
//        {
//            this.ViewState["CausesValidation"] = value;
//        }
//    }

//    [Bindable(true), DefaultValue(""), Themeable(false)]
//    public string CommandArgument
//    {
//        get
//        {
//            string str = (string) this.ViewState["CommandArgument"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["CommandArgument"] = value;
//        }
//    }

//    [Themeable(false),DefaultValue("")]
//    public string CommandName
//    {
//        get
//        {
//            string str = (string) this.ViewState["CommandName"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["CommandName"] = value;
//        }
//    }

//    [Themeable(false), Description("Button_OnClientClick"), DefaultValue(""), Category("Behavior")]
//    public virtual string OnClientClick
//    {
//        get
//        {
//            string str = (string) this.ViewState["OnClientClick"];
//            if (str == null)
//            {
//                return string.Empty;
//            }
//            return str;
//        }
//        set
//        {
//            this.ViewState["OnClientClick"] = value;
//        }
//    }

//    [DefaultValue(""), Category("Behavior"), Description("Button_PostBackUrl"), Editor("System.Web.UI.Design.UrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Themeable(false), UrlProperty("*.aspx")]
//    public virtual string PostBackUrl
//    {
//        get
//        {
//            string str = (string) this.ViewState["PostBackUrl"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["PostBackUrl"] = value;
//        }
//    }

//    [Description("Button_Text"), Category("Appearance"), DefaultValue(""), Localizable(true), Bindable(true)]
//    public string Text
//    {
//        get
//        {
//            string str = (string) this.ViewState["Text"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["Text"] = value;
//        }
//    }

//    [WebDescription("Button_UseSubmitBehavior"), Category("Behavior"), DefaultValue(true), Themeable(false)]
//    public virtual bool UseSubmitBehavior
//    {
//        get
//        {
//            object obj2 = this.ViewState["UseSubmitBehavior"];
//            if (obj2 != null)
//            {
//                return (bool) obj2;
//            }
//            return true;
//        }
//        set
//        {
//            this.ViewState["UseSubmitBehavior"] = value;
//        }
//    }

//    [WebDescription("PostBackControl_ValidationGroup"), Category("Behavior"), DefaultValue(""), Themeable(false)]
//    public virtual string ValidationGroup
//    {
//        get
//        {
//            string str = (string) this.ViewState["ValidationGroup"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["ValidationGroup"] = value;
//        }
//    }
//}
    
    //public class ListAction : WebControl
    //{
    //    private List<int> actionIds;

    //    [Category("ActionIds"), Description("Ids of actions")]
    //    public string ActionIds { get; set; }
        
    //    protected override void CreateChildControls()
    //    {
    //        string[] ids = ActionIds.Split(',');

    //        Controls.Clear();
    //        Table table = new Table();
    //        TableRow row = new TableRow();
    //        foreach(string sId in ids)
    //        {
    //            int id=0;
    //            if(!int.TryParse(sId,out id))continue;
                
    //            SistemaAccion accion= SolutionContext.Current.AccionesCache.GetById(id);
                
    //            TableCell cell = new TableCell();
    //            wc.ImageButton img = new wc.ImageButton();
    //            img.ImageUrl = "~/Images/add.png";
    //            img.ID = "img" + accion.Nombre;
    //            img.ToolTip =accion.Nombre;
    //            cell.Controls.Add(img);
    //            row.Cells.Add(cell);
    //        }
    //        table.Rows.Add(row);
    //        this.Controls.Add(table);

    //    }

      
    //}

     

    public class ListAction : WebControl
    {
        private List<int> actionIds;

        [Category("ActionIds"), Description("Ids of actions")]
        public string ActionIds
        {
            get
            {
                string str = (string)this.ViewState["ActionIds"];
                if (str != null)
                {
                    return str;
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ActionIds"] = value;
            }
        }
               
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string[] ids = ActionIds.Split(',');

            Controls.Clear();
            Table table = new Table();
            TableRow row = new TableRow();
            foreach (string sId in ids)
            {
                int id = 0;
                if (!int.TryParse(sId, out id)) continue;

                SistemaAccion accion = SolutionContext.Current.AccionesCache.GetById(id);

                TableCell cell = new TableCell();
                wc.ImageButton img = new wc.ImageButton();
                img.ImageUrl = "~/Images/add.png";
                img.ID = "img" + accion.Nombre;
                img.ToolTip = accion.Nombre;
                //img.Click += new ImageClickEventHandler(img_Click);
                //img.Command += new CommandEventHandler(img_Command);                
                cell.Controls.Add(img);
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
            this.Controls.Add(table);
        }

        void img_Command(object sender, CommandEventArgs e)
        {
            
        }
        void img_Click(object sender, ImageClickEventArgs e)
        {
           
        }
    }


    #region Test

//    [DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxData("<{0}:LinkButton runat=\"server\">LinkButton</{0}:LinkButton>"), DefaultEvent("Click"), DefaultProperty("Text"), ParseChildren(false), ControlBuilder(typeof(LinkButtonControlBuilder)), Designer("System.Web.UI.Design.WebControls.LinkButtonDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), SupportsEventValidation, AspNetHostingPermission(SecurityAction.LinkDemand, Level=AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level=AspNetHostingPermissionLevel.Minimal)]
//public class ListAction : WebControl, IButtonControl, IPostBackEventHandler
//{
//    private List<int> actionIds;

//    [Category("ActionIds"), Description("Ids of actions")]
//    public string ActionIds
//    {
//        get
//        {
//            string str = (string)this.ViewState["ActionIds"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["ActionIds"] = value;
//        }
//    }

//    //protected override void CreateChildControls()
//    //{
//    //    string[] ids = ActionIds.Split(',');

//    //    Controls.Clear();
//    //    Table table = new Table();
//    //    TableRow row = new TableRow();
//    //    foreach (string sId in ids)
//    //    {
//    //        int id = 0;
//    //        if (!int.TryParse(sId, out id)) continue;

//    //        SistemaAccion accion = SolutionContext.Current.AccionesCache.GetById(id);

//    //        TableCell cell = new TableCell();
//    //        wc.ImageButton img = new wc.ImageButton();
//    //        img.ImageUrl = "~/Images/add.png";
//    //        img.ID = "img" + accion.Nombre;
//    //        img.ToolTip = accion.Nombre;
//    //        img.Click += new ImageClickEventHandler(img_Click);
//    //        img.Command += new CommandEventHandler(img_Command);
//    //        cell.Controls.Add(img);
//    //        row.Cells.Add(cell);
//    //    }
//    //    table.Rows.Add(row);
//    //    this.Controls.Add(table);

//    //}

//    protected override void OnPreRender(EventArgs e)
//    {
//        base.OnPreRender(e);
//        string[] ids = ActionIds.Split(',');

//        Controls.Clear();
//        Table table = new Table();
//        TableRow row = new TableRow();
//        foreach (string sId in ids)
//        {
//            int id = 0;
//            if (!int.TryParse(sId, out id)) continue;

//            SistemaAccion accion = SolutionContext.Current.AccionesCache.GetById(id);

//            TableCell cell = new TableCell();
//            wc.ImageButton img = new wc.ImageButton();
//            img.ImageUrl = "~/Images/add.png";
//            img.ID = "img" + accion.Nombre;
//            img.ToolTip = accion.Nombre;
//            img.Click += new ImageClickEventHandler(img_Click);
//            img.Command += new CommandEventHandler(img_Command);
//            cell.Controls.Add(img);
//            row.Cells.Add(cell);
//        }
//        table.Rows.Add(row);
//        this.Controls.Add(table);
//    }

//    void img_Command(object sender, CommandEventArgs e)
//    {
       
//    }

//    void img_Click(object sender, ImageClickEventArgs e)
//    {
       
//    }



//    // Fields
//    private static readonly object EventClick = new object();
//    private static readonly object EventCommand = new object();

//    // Events
//    [Category("Action"), Description("LinkButton_OnClick")]
//    public event EventHandler Click
//    {
//        add
//        {
//            base.Events.AddHandler(EventClick, value);
//        }
//        remove
//        {
//            base.Events.RemoveHandler(EventClick, value);
//        }
//    }

//    [Category("Action"), Description("Button_OnCommand")]
//    public event CommandEventHandler Command
//    {
//        add
//        {
//            base.Events.AddHandler(EventCommand, value);
//        }
//        remove
//        {
//            base.Events.RemoveHandler(EventCommand, value);
//        }
//    }

//    // Methods
//    static ListAction()
//    {
//        EventClick = new object();
//        EventCommand = new object();
//    }

//    public ListAction(): base(HtmlTextWriterTag.A)
//    {
//    }

//    protected override void AddAttributesToRender(HtmlTextWriter writer)
//    {
//        //if (this.Page != null)
//        //{
//        //    this.Page.VerifyRenderingInServerForm(this);
//        //}
//        //string str = Util.EnsureEndWithSemiColon(this.OnClientClick);
//        //if (base.HasAttributes)
//        //{
//        //    string str2 = base.Attributes["onclick"];
//        //    if (str2 != null)
//        //    {
//        //        str = str + Util.EnsureEndWithSemiColon(str2);
//        //        base.Attributes.Remove("onclick");
//        //    }
//        //}
//        //if (str.Length > 0)
//        //{
//        //    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
//        //}
//        //bool isEnabled = base.IsEnabled;
//        //if (this.Enabled && !isEnabled)
//        //{
//        //    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
//        //}
//        //base.AddAttributesToRender(writer);
//        //if (isEnabled && (this.Page != null))
//        //{
//        //    PostBackOptions postBackOptions = this.GetPostBackOptions();
//        //    string postBackEventReference = null;
//        //    if (postBackOptions != null)
//        //    {
//        //        postBackEventReference = this.Page.ClientScript.GetPostBackEventReference(postBackOptions, true);
//        //    }
//        //    if (string.IsNullOrEmpty(postBackEventReference))
//        //    {
//        //        postBackEventReference = "javascript:void(0)";
//        //    }
//        //    writer.AddAttribute(HtmlTextWriterAttribute.Href, postBackEventReference);
//        //}
//    }

//    protected override void AddParsedSubObject(object obj)
//    {
//    //    if (this.HasControls())
//    //    {
//    //        base.AddParsedSubObject(obj);
//    //    }
//    //    else if (obj is LiteralControl)
//    //    {
//    //        this.Text = ((LiteralControl) obj).Text;
//    //    }
//    //    else
//    //    {
//    //        string text = this.Text;
//    //        if (text.Length != 0)
//    //        {
//    //            this.Text = string.Empty;
//    //            base.AddParsedSubObject(new LiteralControl(text));
//    //        }
//    //        base.AddParsedSubObject(obj);
//    //    }
//    }

//    protected virtual PostBackOptions GetPostBackOptions()
//    {
//        PostBackOptions options = new PostBackOptions(this, string.Empty);
//        options.RequiresJavaScriptProtocol = true;
//        if (!string.IsNullOrEmpty(this.PostBackUrl))
//        {
//            options.ActionUrl = HttpUtility.UrlPathEncode(base.ResolveClientUrl(this.PostBackUrl));
//            if ((!base.DesignMode && (this.Page != null)) && string.Equals(this.Page.Request.Browser.Browser, "IE", StringComparison.OrdinalIgnoreCase))
//            {
//                options.ActionUrl = Util.QuoteJScriptString(options.ActionUrl, true);
//            }
//        }
//        if (this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0))
//        {
//            options.PerformValidation = true;
//            options.ValidationGroup = this.ValidationGroup;
//        }
//        return options;
//    }

//    //protected override void LoadViewState(object savedState)
//    //{
//    //    if (savedState != null)
//    //    {
//    //        base.LoadViewState(savedState);
//    //        string str = (string) this.ViewState["Text"];
//    //        if (str != null)
//    //        {
//    //            this.Text = str;
//    //        }
//    //    }
//    //}

//    protected virtual void OnClick(EventArgs e)
//    {
//        EventHandler handler = (EventHandler) base.Events[EventClick];
//        if (handler != null)
//        {
//            handler(this, e);
//        }
//    }

//    protected virtual void OnCommand(CommandEventArgs e)
//    {
//        CommandEventHandler handler = (CommandEventHandler) base.Events[EventCommand];
//        if (handler != null)
//        {
//            handler(this, e);
//        }
//        base.RaiseBubbleEvent(this, e);
//    }

//    //protected internal override void OnPreRender(EventArgs e)
//    //{
//    //    base.OnPreRender(e);
//    //    if ((this.Page != null) && this.Enabled)
//    //    {
//    //        this.Page.RegisterPostBackScript();
//    //        if ((this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0)) || !string.IsNullOrEmpty(this.PostBackUrl))
//    //        {
//    //            this.Page.RegisterWebFormsScript();
//    //        }
//    //    }
//    //}

//    protected virtual void RaisePostBackEvent(string eventArgument)
//    {
//        //base.ValidateEvent(this.UniqueID, eventArgument);
//        if (this.CausesValidation)
//        {
//            this.Page.Validate(this.ValidationGroup);
//        }
//        this.OnClick(EventArgs.Empty);
//        this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
//    }

//    //protected internal override void RenderContents(HtmlTextWriter writer)
//    //{
//    //    if (base.HasRenderingData())
//    //    {
//    //        base.RenderContents(writer);
//    //    }
//    //    else
//    //    {
//    //        writer.Write(this.Text);
//    //    }
//    //}

//    void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
//    {
//        this.RaisePostBackEvent(eventArgument);
//    }

//    // Properties
//    [DefaultValue(true), WebDescription("Button_CausesValidation"), Themeable(false), Category("Behavior")]
//    public virtual bool CausesValidation
//    {
//        get
//        {
//            object obj2 = this.ViewState["CausesValidation"];
//            if (obj2 != null)
//            {
//                return (bool) obj2;
//            }
//            return true;
//        }
//        set
//        {
//            this.ViewState["CausesValidation"] = value;
//        }
//    }

//    [DefaultValue(""), Themeable(false), Category("Behavior"), WebDescription("WebControl_CommandArgument"), Bindable(true)]
//    public string CommandArgument
//    {
//        get
//        {
//            string str = (string) this.ViewState["CommandArgument"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["CommandArgument"] = value;
//        }
//    }

//    [WebDescription("WebControl_CommandName"), Category("Behavior"), DefaultValue(""), Themeable(false)]
//    public string CommandName
//    {
//        get
//        {
//            string str = (string) this.ViewState["CommandName"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["CommandName"] = value;
//        }
//    }

//    [DefaultValue(""), Themeable(false), Category("Behavior"), WebDescription("Button_OnClientClick")]
//    public virtual string OnClientClick
//    {
//        get
//        {
//            string str = (string) this.ViewState["OnClientClick"];
//            if (str == null)
//            {
//                return string.Empty;
//            }
//            return str;
//        }
//        set
//        {
//            this.ViewState["OnClientClick"] = value;
//        }
//    }

//    [DefaultValue(""), UrlProperty("*.aspx"), WebDescription("Button_PostBackUrl"), Editor("System.Web.UI.Design.UrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Themeable(false), Category("Behavior")]
//    public virtual string PostBackUrl
//    {
//        get
//        {
//            string str = (string) this.ViewState["PostBackUrl"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["PostBackUrl"] = value;
//        }
//    }

//    //internal override bool RequiresLegacyRendering
//    //{
//    //    get
//    //    {
//    //        return true;
//    //    }
//    //}

//    [Localizable(true), PersistenceMode(PersistenceMode.InnerDefaultProperty), Bindable(true), Category("Appearance"), DefaultValue(""), WebDescription("LinkButton_Text")]
//    public virtual string Text
//    {
//        get
//        {
//            object obj2 = this.ViewState["Text"];
//            if (obj2 != null)
//            {
//                return (string) obj2;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            if (this.HasControls())
//            {
//                this.Controls.Clear();
//            }
//            this.ViewState["Text"] = value;
//        }
//    }

//    [DefaultValue(""), WebDescription("PostBackControl_ValidationGroup"), Category("Behavior"), Themeable(false)]
//    public virtual string ValidationGroup
//    {
//        get
//        {
//            string str = (string) this.ViewState["ValidationGroup"];
//            if (str != null)
//            {
//                return str;
//            }
//            return string.Empty;
//        }
//        set
//        {
//            this.ViewState["ValidationGroup"] = value;
//        }
//    }
    //}
    #endregion

}
