using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class WebControl_NumericRangeInput : WebControlRangeInput<decimal?>
    {
        #region Propiedades
        public override decimal? ValueFrom
        {
            get { return UIHelper.GetDecimalNullable(txtFrom); }
            set { UIHelper.SetValue(txtFrom, value); }
        }
        public override decimal? ValueTo
        {
            get { return UIHelper.GetDecimalNullable(txtTo); }
            set { UIHelper.SetValue(txtTo, value); }
        }
        public override string ErrorMessageValidator
        {
            set { compareValidator.ErrorMessage = value; }
        }
        public override ValidationCompareOperator OperatorValidator
        {
            set { compareValidator.Operator = value; }
        }
        public string ValidationGroup
        {
            set 
            {
                txtFrom.ValidationGroup = value;
                txtTo.ValidationGroup = value;
                requiredFrom.ValidationGroup = value;
                requiredTo.ValidationGroup = value;
                RegularExpressionValidatorFrom.ValidationGroup = value;
                RegularExpressionValidatorTo.ValidationGroup = value;
            }
        }
        public bool AutoPostBack
        {
            get
            {
                return this.txtTo.AutoPostBack;
            }
            set
            {
                this.txtTo.AutoPostBack = value;
            }
        }
        public string CssClass
        {
            get { return pnControl.CssClass; }
            set { pnControl.CssClass = value; }
        }
        
        public bool RequiredFrom
        {
            set { requiredFrom.Enabled = value; }
        }
        public bool RequiredTo
        {
            set { requiredTo.Enabled = value; }
        }
        public string ErrorMessageRequiredFrom
        {
            set { requiredFrom.ErrorMessage = value; }
        }
        public string ErrorMessageRequiredTo
        {
            set { requiredTo.ErrorMessage = value; }
        }
        public string ErrorMessageNumericFrom
        {
            set { RegularExpressionValidatorFrom.ErrorMessage = value; }
        }
        public string ErrorMessageNumericTo
        {
            set { RegularExpressionValidatorTo.ErrorMessage = value; }
        }
        #endregion

        #region Metodos
        public override void Clear()
        {
            UIHelper.Clear(txtFrom);
            UIHelper.Clear(txtTo);
        }
        public override void Focus()
        {
            this.txtFrom.Focus();
        }
        #endregion
    }
}