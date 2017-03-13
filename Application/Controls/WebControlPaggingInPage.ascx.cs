using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public partial class WebControlPaggingInPage : WebControlPagging 
    {
        #region Override               
        public override void LoadPagging()
        {
            Pagging.SetOnePaging();
            this.PageGoCommand = Command.CONFIRM_PAGE_GO;
            SetValue();
        }
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
            Clear();
            Pagging = new Paged();
            Pagging.PageSize = 1;
            Pagging.RowIndex = 1;
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
            UIHelper.Clear(lblTotalPages);
            UIHelper.Clear(tbPageNumber);
        }
        protected override void SetValue()
        {  
            Pagging.RefreshPageCount();
            UIHelper.SetValue(lblTotalPages, Pagging.PageCount.HasValue ? Pagging.PageCount.Value.ToString() : "?");
            UIHelper.SetValue(tbPageNumber, Pagging.PageNumber);
            CanButtons();
        }
        protected override void GetValue()
        {
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