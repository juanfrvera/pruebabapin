using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace UI.Web
{
    public abstract class WebControlFilter<TFilter> : WebControlBase, IControlFilter<TFilter> where TFilter:class,new()
    { 
        public const string FilterKey ="Filter";

        #region Properties
        protected TFilter filter;
        public virtual TFilter Filter
        {
            get
            {
                if (filter == null)
                {
                    if (filter == null)
                        filter = new TFilter();
                }
                return filter;
            }
            set
            {
                filter = value;                           
            }
        }
        protected override void OnPreRender(EventArgs e)
        {            
            Filter = Filter;
            base.OnPreRender(e);
        }
        #endregion


        public TFilter GetFilter()
        {
            GetValue();
            //this.SetParameter(FilterKey, Filter);
            return Filter;
        }
        public void LoadFilter()
        {
            //Filter = this.GetParameter<TFilter>(FilterKey);            
            SetValue();
        }
        //public void SaveFilter()
        //{
        //    GetValue();
        //    this.SetParameter(PARAMETER_FILTER,Filter);             
        //}
        public void ResetFilter()
        {
            Clear();
            Filter = new TFilter();
            SetValue();
            //this.SetParameter(FilterKey, Filter);
        }
        public void ClearFilter()
        {
            Clear();
        }
        protected abstract void SetValue();
        protected abstract void GetValue();
        protected abstract void Clear();
        
        //public abstract TFilter GetFilter();
        //public abstract void SetFilter(TFilter filter);
        //public abstract void ResetFilter();
    }
}