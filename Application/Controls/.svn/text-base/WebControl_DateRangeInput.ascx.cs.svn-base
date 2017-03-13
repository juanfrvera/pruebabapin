using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public abstract class WebControlRangeInput<TType> : WebControlBase, IRangeInput<TType>
    {
        #region Atributos
        private string tagFrom = "de";
        private string tagTo = "a";
        #endregion

        #region Propiedades
        public abstract ValidationCompareOperator OperatorValidator { set; }
        public abstract string ErrorMessageValidator { set; }
        public string TagFrom
        {
            get { return tagFrom; }
            set { tagFrom = value; }
        }
        public string TagTo
        {
            get { return tagTo; }
            set { tagTo = value; }
        }
        private RangeValue<TType> value;
        public RangeValue<TType> Value
        {
            get
            {
                if (value == null)
                    value = new RangeValue<TType> { From = ValueFrom, To = ValueTo };
                return value;
            }
            set
            {
                ValueFrom = value.From;
                ValueTo = value.To;
            }
        }
        public abstract TType ValueFrom { get; set; }
        public abstract TType ValueTo { get; set; }
        public abstract void Clear();
        #endregion
    }

    public partial class WebControl_DateRangeInput : WebControlRangeInput<DateTime?>
    {
        #region Propiedades
        public override DateTime? ValueFrom
        {
            get { return UIHelper.GetDateTimeNullable(diDateValueFrom); }
            set { UIHelper.SetValue(diDateValueFrom, value); }
        }
        public override DateTime? ValueTo
        {
            get { return UIHelper.GetDateTimeNullable(diDateValueTo); }
            set { UIHelper.SetValue(diDateValueTo, value); }
        }
        public override string ErrorMessageValidator 
        {
            set { compareValidator.ErrorMessage = value; }
        }
        public string RangeErrorMessageFrom
        {
            set { diDateValueFrom.RangeErrorMessage = value; }
        }
        public string RangeErrorMessageTo
        {
            set { diDateValueTo.RangeErrorMessage = value; }
        }
        public override ValidationCompareOperator OperatorValidator
        {
            set { compareValidator.Operator = value; }
        }
        public string ValidationGroup
        {
            set
            {
                diDateValueFrom.ValidationGroup = value;
                diDateValueTo.ValidationGroup = value;
                compareValidator.ValidationGroup = value;
            }
        }
        public bool AutoPostBack
        {
            get
            {
                return this.diDateValueFrom.AutoPostBack;
            }
            set
            {
                this.diDateValueTo.AutoPostBack = value;
            }
        }
        public string CssClass
        {
            get { return pnControl.CssClass; }
            set { pnControl.CssClass = value; }
        }
        public short TabIndexFrom
        {
            set { diDateValueFrom.TabIndex = value; }
            get { return diDateValueFrom.TabIndex; }
        }
        public short TabIndexTo
        {
            set { diDateValueTo.TabIndex = value; }
            get { return diDateValueTo.TabIndex; }
        }

        #endregion

        #region Metodos
        public override void Clear()
        {
            UIHelper.Clear(diDateValueFrom);
            UIHelper.Clear(diDateValueTo);
        }
        public override void Focus()
        {
            diDateValueFrom.Focus();
        }
        #endregion
    }
}