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
using System.Collections.Generic;

namespace UI.Web
{
    public partial class WebControlHourInput2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaComboHoras();
                CargaComboMinutos();
            }
        }
        private void CargaComboHoras()
        {
            List<KeyValuePair<int, string>> Horas = new List<KeyValuePair<int, string>>();
            Horas.Add(new KeyValuePair<int, string>(0, ""));
            for (Int32 i = 1; i <= 12; i++)
                Horas.Add(new KeyValuePair<int, string>(i,i.ToString()));

            UIHelper.Load<int, string>(ddlHour, Horas);            
        }
        private void CargaComboMinutos()
        {
            List<KeyValuePair<int, string>> Minutos = new List<KeyValuePair<int, string>>();
            Minutos.Add(new KeyValuePair<int, string>(0, ""));
            for (Int32 i = 1; i <= 59; i++)
                Minutos.Add(new KeyValuePair<int, string>(i, i.ToString()));

            UIHelper.Load<int, string>(ddlMinutos, Minutos);
        }
        public int Hour
        {
            get {
                
                int hour = UIHelper.GetInt(ddlHour) + (AMPM == 1 ? 0 : 12);
                return (hour<1)?1:(hour>23)?23:hour;
            }
            set {
                if (value > 12)
                {
                    UIHelper.SetValue(ddlHour, value - 12);
                    AMPM = 2;
                }
                else
                {
                    UIHelper.SetValue(ddlHour, value);
                    AMPM = 1;
                }
            }
        }
        public int Minutes
        {
            get
            {
                return UIHelper.GetInt(ddlMinutos);
            }
            set
            {
                UIHelper.SetValue(ddlMinutos, value);
            }
        }
        public Int32 AMPM
        {
            get {
                return UIHelper.GetInt(ddlAMPM);
            }
            set {
                UIHelper.SetValue(ddlAMPM, value);
            }
        }
        public DateTime? Date
        {
            get {
                if (Hour <= 0) return null; 
                  return new DateTime(2000,1,1,Hour,Minutes,0);
                }
            set {
                    if (value.HasValue)
                    {
                        Hour = value.Value.Hour;
                        Minutes = value.Value.Minute;
                    }
                    else
                    {
                        Hour = 0;
                        Minutes = 0;
                    }
                }
        }
        public void Clear()
        {
            UIHelper.Clear(ddlHour);
            UIHelper.Clear(ddlMinutos);
            UIHelper.Clear(ddlAMPM);
        }
    }
}