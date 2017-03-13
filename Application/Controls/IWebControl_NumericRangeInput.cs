using System;

namespace UI.Web
{
    interface IWebControl_NumericRangeInput
    {
        bool AutoPostBack { get; set; }
        void Clear();
        string ErrorMessageValidator { get; set; }
        bool IsValidEmptyFrom { set; }
        bool IsValidEmptyTo { set; }
        string Masks { set; }
        double MaximumValueFrom { set; }
        double MaximumValueTo { set; }
        double MinimumValueFrom { set; }
        double MinimumValueTo { set; }
        System.Web.UI.WebControls.ValidationCompareOperator OperatorValidator { get; set; }
        string TagFrom { get; set; }
        string TagTo { get; set; }
        double ValueFrom { get; set; }
        double ValueTo { get; set; }
        System.Web.UI.WebControls.Unit Width { set; }
    }
}
