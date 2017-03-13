using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public partial class WebControlPaggingListButtons : WebControlBase
    {


        public string ValidationGroup
        {
            get
            {
                return this.btSearch.ValidationGroup;
            }
            set
            {
                this.btSearch.ValidationGroup = value;
            }
        }


        private Paged paged;
        private Paged Paged
        {
            get{
                if (paged == null)
                {
                    if (ViewState["paged"] == null)ViewState["paged"] = new Paged();
                    paged = (Paged)ViewState["paged"];
                }
                return paged;
            }
            set{
                paged = value;
                ViewState["paged"] = value;            
            }       
        }
        protected override void _Initialize()
        {
           
        }
        public void Clear()
        {
            UIHelper.Clear(tbPage);
            UIHelper.Clear(tbRows);
        }
        public void SetValue()
        {
            UIHelper.SetValue(tbPage, Paged.PageNumber);
            UIHelper.SetValue(tbRows, Paged.PageSize);
        }
        private void GetValue()
        {
            Paged.PageNumber = UIHelper.GetInt(tbPage);
            Paged.PageSize = UIHelper.GetInt(tbRows);
        } 
        public bool EnableSearch
        {
            get { return this.btSearch.Enabled; }
            set { this.btSearch.Enabled = value; }
        }        
        protected virtual void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        

        


       

        
       
    }
}