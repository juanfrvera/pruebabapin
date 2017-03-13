using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Contract;

namespace UI.Web
{
    public abstract class WebControlEdit<TEntity> : WebControlBase, IControlEdition<TEntity>
    {
        private TEntity entity;
        public TEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        } 
        public abstract void SetValue();
        public abstract void GetValue();
        public abstract void Clear();

        public virtual void SetEnable(bool enable)
        {
            SetEnable(enable, true);
        }
        public virtual void SetEnable(bool enable, bool enableDelete) { }



    }
}