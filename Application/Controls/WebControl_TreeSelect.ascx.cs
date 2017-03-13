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

namespace UI.Web
{   
    public partial class WebControl_TreeSelect : WebControlBase
    { 
       public string Handler { get; set;}
       public string RootText { get; set; }
       public string JsonFilter { get; set;}
 
       public NodeResult Value
       {
           get {
                 if (hdSelect.Value == null || hdSelect.Value.Trim() == string.Empty) return null;
                 return JsonConvert.DeserializeObject<NodeResult>(hdSelect.Value); 
               }
          set  {
                  if (value == null)
                      hdSelect.Value = null;
                  else
                  {
                      hdSelect.Value = JsonConvert.SerializeObject(value);
                      UIHelper.SetValue(txtSelect, Value.Text);
                  }   
               }
       }
       public virtual int? ValueId { get; set; }
       public void Clear()
       {
           Value = null;
           UIHelper.Clear(txtSelect);
       }
       public virtual void Focus()
       {
           txtSelect.Focus();
       }
       public Unit Width
       {
           get { return pnControl.Width; }
           set { pnControl.Width = value; }
       }


       public void hdSelect_ValueChanged(Object sender, EventArgs e)
       {
           string s = e.ToString();          

       }

    }
}