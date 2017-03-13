using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
    public partial class WebControlHourInput : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Int32 Hour
        {
            get {
                return UIHelper.GetInt (txtHour);
            }
            set {
                if (value > 12)
                {
                    UIHelper.SetValue(txtHour, value - 12);
                    AMFM = "fm";
                }
                else {
                    UIHelper.SetValue(txtHour, value);
                    AMFM = "am";
                
                }
            }
        }
        public Int32 Minutes
        {
            get
            {
                return UIHelper.GetInt(txtMinutes );
            }
            set
            {
                UIHelper.SetValue(txtMinutes , value);
            }
        }
        public String AMFM
        {
            get
            {
                return UIHelper.GetString(txtAMFM );
            }
            set
            {
                UIHelper.SetValue(txtAMFM , value);
            }
        }
        private Int32 IntAMFM
        {
            get {
                if (UIHelper.GetString(txtAMFM) == "am")
                    return 1;
                else
                {
                    return 2;
                }
                
            }
        
        }

        public DateTime Date
        {
            get {

                DateTime date = new DateTime();
                date.AddHours(UIHelper.GetInt(txtHour) * IntAMFM ) ;
                date.AddMinutes(UIHelper.GetInt(txtMinutes));
                return date;
            }
            set {
                Hour = value.Hour;
                Minutes = value.Minute;            
            }
        }

        public void Clear()
        {
            UIHelper.Clear(txtHour);
            UIHelper.Clear(txtMinutes);
            UIHelper.Clear(txtAMFM);
        }
    }
}