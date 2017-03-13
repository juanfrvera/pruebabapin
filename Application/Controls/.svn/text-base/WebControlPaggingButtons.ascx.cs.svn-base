using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public abstract class WebControlPagging : WebControlBase, IPaggingControl
    {
        protected Paged pagging;
        public const string PaggingKey = "Pagging";

        #region Public
        public virtual Paged Pagging
        {
            get
            {
                if (pagging == null)
                {
                    pagging = this.GetParameter<Paged>(PaggingKey);
                    if (pagging == null)
                    {
                        pagging = new Paged();
                    }
                }
                return pagging;
            }
            set
            {
                pagging = value;
                this.SetParameter(PaggingKey, pagging);
            }
        }
        public virtual Paged GetPagging()
        {
            GetValue();
            Validate();
            this.SetParameter(PaggingKey, Pagging);
            return Pagging;
        }
        public virtual void LoadPagging()
        {
            SetValue();
        }
        public abstract void ResetPagging();
        public void RefreshPagging(int rows)
        {
            Pagging.Rows = rows;
            SetValue();
            Pagging = Pagging;
            CanButtons();
        }
        public void SetOldPage()
        {
            Pagging.SetOldPage();
            SetValue();
        }
        public void SetPendingConmfirmPage()
        {
            Pagging.SetPendingConmfirmPage();
            SetValue();
        }
        public abstract string ValidationGroup { get; set; }
        public abstract bool EnableSearch { get; set; }
        //private bool searchVisible;
        public abstract bool SearchVisible { get; set; }
        protected string pageGoCommand;
        public virtual string PageGoCommand
        {
            get
            {
                if (pageGoCommand == null)
                {
                    if (GetViewState("pageGoCommand") != null) pageGoCommand = this.GetViewState("pageGoCommand").ToString();
                    else pageGoCommand = Command.PAGE_GO;
                }
                return pageGoCommand;
            }
            set
            {
                pageGoCommand = value;
                SetViewState("pageGoCommand", value);
            }
        }
        #endregion
        
        #region Protected
        protected override void _Initialize()
        {
            ResetPagging();
        }
        protected abstract void Clear();
        protected abstract void SetValue();
        protected abstract void GetValue();
        protected abstract void CanButtons();
        #endregion

        #region Events
        protected virtual void btPageGo_Click(object sender, EventArgs e)
        {
            CallTryMethod(PageGo);
            CanButtons();
        }
        protected void btPrevious_Click(object sender, EventArgs e)
        {
            Pagging.Previuos();
            SetValue();
            CallTryMethod(PageGo);
            CanButtons();
        }
        protected void btLast_Click(object sender, EventArgs e)
        {
            Pagging.Last();
            SetValue();
            CallTryMethod(PageGo);
            CanButtons();


        }


        protected void btFirst_Click(object sender, EventArgs e)
        {
            Pagging.First();
            SetValue();
            CallTryMethod(PageGo);
            CanButtons();
        }
        protected void btNext_Click(object sender, EventArgs e)
        {
            Pagging.Next();
            SetValue();
            CallTryMethod(PageGo);
            CanButtons();
        }        
        #endregion

        protected void PageGo()
        {
            RaiseControlCommand(PageGoCommand);
        }
       
        protected void Validate()
        {
            if (Pagging.Rows.HasValue && Pagging.Rows.Value > 0)
            {
                UIHelper.Validate(((Pagging.PageNumber * Pagging.PageSize) <= (Pagging.Rows.Value + Pagging.PageSize - 1)), "La pagina esta fuera del rango");
            }
        }

    }
    public partial class WebControlPaggingButtons : WebControlPagging 
    {
        #region Override
        public override bool EnableSearch
        {
            get { return this.btPageGo.Enabled; }
            set { this.btPageGo.Enabled = value; }
        }
        public override bool SearchVisible
        {
            get { return btPageGo.Visible; }
            set { btPageGo.Visible = value; }
        }
        public override void ResetPagging()
        {
            int pageSize = UIHelper.GetInt(tbPageSize);
            Clear();
            Pagging = new Paged();
            Pagging.PageSize = pageSize;
            SetValue();
            CanButtons();
        }
        public override string ValidationGroup
        {
            get { return this.btPageGo.ValidationGroup; }
            set { this.btPageGo.ValidationGroup = value; }
        }
        protected override void Clear()
        {
            UIHelper.Clear(tbPageSize);
            UIHelper.Clear(lblTotalPages);
            UIHelper.Clear(tbPageNumber);
        }
        protected override void SetValue()
        {
            if (Pagging.PageSize <= 0) Pagging.PageSize = 10;
            Pagging.RefreshPageCount();
            UIHelper.SetValue(tbPageSize, Pagging.PageSize);
            UIHelper.SetValue(lblTotalPages, Pagging.PageCount.HasValue ? Pagging.PageCount.Value.ToString() : "?");
            UIHelper.SetValue(tbPageNumber, Pagging.PageNumber);
        }
        protected override void GetValue()
        {
            Pagging.PageSize = UIHelper.GetInt(tbPageSize);
            Pagging.PageNumber = UIHelper.GetInt(tbPageNumber);
        }
        protected override void CanButtons()
        {
            btPrevious.Enabled = this.Pagging.CanPreviuos();
            btNext.Enabled = this.Pagging.CanNext();
            btFirst.Enabled = this.Pagging.CanFirst();
            btLast.Enabled = this.Pagging.CanLast();

            PageBase page = Page as PageBase;
            if (page != null && !page.PageBehaviour.GetTotaRowsCount)
            {
                tbPageNumber.Enabled = false;
                btLast.Enabled = false;
                btPageGo.Enabled = false;
            }
        }
        #endregion
    }
}