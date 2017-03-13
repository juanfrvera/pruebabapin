using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace UI.Web
{
    public abstract partial class WebControlHead<TResult> : WebControlBase
    where TResult : class, new()
    {
        public const string ResultKey = "Result";

        #region Properties
        protected TResult result;
        public virtual TResult Result
        {
            get
            {
                if (result == null)
                {
                    if (result == null)
                        result = new TResult();
                }
                return result;
            }
            set
            {
                result = value;
            }
        }
        #endregion


        public void Set(TResult result)
        {
            Result = result;
            SetValue();
        }
        public void ClearData()
        {
            Clear();
        }


        protected abstract void SetValue();
        protected abstract void Clear();
        public virtual bool HeadVisible{get;set;}

    }
}
