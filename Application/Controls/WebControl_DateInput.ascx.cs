using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace UI.Web
{
    public partial class WebControl_DateInput : WebControlBase //System.Web.UI.UserControl
    {

        protected override void _Load()
        {
            //Set the culture settings  
            //Set the culture settings
            CultureInfo oCulture = CultureInfo.CurrentCulture;
            MaskedEditExtender1.CultureName = oCulture.Name;
            txFechaCalendar.Format = oCulture.DateTimeFormat.ShortDatePattern;
            //CalendarMaskExtender expects something like "99/99/9999"
            string Mask = txFechaCalendar.Format.Replace(oCulture.DateTimeFormat.DateSeparator, "/");
            if (Mask.IndexOf("d") != Mask.LastIndexOf("d"))
            {
                Mask = Mask.Replace("d", "9");
            }
            else
            {
                Mask = Mask.Replace("d", "99");
            }
            if (Mask.IndexOf("M") != Mask.LastIndexOf("M"))
            {
                Mask = Mask.Replace("M", "9");
            }
            else
            {
                Mask = Mask.Replace("M", "99");
            }
            Mask = Mask.Replace("y", "9");
            MaskedEditExtender1.Mask = Mask;
            base._Load();
        }

        #region Public Members

        public bool Enabled
        {
            get { return txFecha.Enabled; }
            set { txFecha.Enabled = value; btCalendario.Enabled = value; }
        }

        public bool ReadOnly
        {
            set
            {
                txFecha.ReadOnly = value;
                btCalendario.Visible = !value;
                txFechaCalendar.Enabled = !value;
            }
        }

        public DateTime MinValue
        {
            get 
            {
                return DateTime.Parse(rvFecha.MinimumValue);
            }
            set
            {
                rvFecha.MinimumValue = value.ToString("d"); 
            }
        }

        public DateTime MaxValue
        {
            get
            {
                return DateTime.Parse(rvFecha.MaximumValue);
            }
            set
            {
                rvFecha.MaximumValue = value.ToString("d");
            }
        }

        public string RangeErrorMessage
        {
            get 
            {
                return rvFecha.ErrorMessage;
            }

            set
            {
                rvFecha.ErrorMessage = value;
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return rfvFecha.ErrorMessage;
            }

            set
            {
                rfvFecha.ErrorMessage = value;
            }
        }

        public DateTime? Fecha
        {
            get
            {
                DateTime? fechaDesde;
                try
                {
                    fechaDesde = UIHelper.GetDateTimeNullable(txFecha);
                    //if (fechaDesde.HasValue && Hour.HasValue)
                    //    fechaDesde = new DateTime(fechaDesde.Value.Year, fechaDesde.Value.Month, fechaDesde.Value.Day, Hour.HasValue?Hour.Value.Hour:0,Hour.HasValue?Hour.Value.Minute:0, Hour.HasValue?Hour.Value.Second:0);
                    return fechaDesde;
                }
                catch 
                {
                    return null;
                }
            }
            set
            {
                UIHelper.SetValue(txFecha,value);
            }
        }
        //private DateTime? hour;
        //public DateTime? Hour
        //{
        //    get {
        //        if (hour == null)
        //        {
        //            hour = GetViewState("Hour") as DateTime?;
        //            if (hour == null || !hour.HasValue)
        //            { 
        //               DateTime now = DateTime.Now;
        //               hour = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        //               SetViewState("Hour", hour);
        //            }
        //        }
        //        return hour; }
        //    set { 
        //            hour = value;
        //            SetViewState("Hour", value);
        //        }
        //}
        public void Clear()
        {
            UIHelper.Clear(txFecha);   
        }
        public bool AutoPostBack
        {
            get { return txFecha.AutoPostBack; }
            set { txFecha.AutoPostBack = value; }
        }

        public short TabIndex
        {
            set { txFecha.TabIndex = value; }
            get { return txFecha.TabIndex; }
        }

        public event EventHandler TextChanged;

        public override void Focus()
        {
            txFecha.Focus();
        }

        /// <summary>
        /// Setea el With del textbox de fecha
        /// </summary>
        public Unit Width
        {
            get { return txFecha.Width; }
            set { txFecha.Width = value; }
        }

        /// <summary>
        /// Default: true
        /// </summary>
        public bool IsValidEmpty
        { 
            get 
            {
                return rfvFecha.Enabled;// rvFecha.IsValidEmpty;
            }

            set 
            {
                rfvFecha.Enabled = value;  
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rvFecha.ValidationGroup;
            }

            set
            {
                rvFecha.ValidationGroup = value;
                rfvFecha.ValidationGroup = value;
            }
        }

        public Unit  SetControlWidth
        { 
            set
            {
                txFecha.Width = value;
            }
            get
            {
                return txFecha.Width;
            }
        
        }
        #endregion Pubilc Members
        
        protected void txFecha_OnTextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, null);
        }
    }
}