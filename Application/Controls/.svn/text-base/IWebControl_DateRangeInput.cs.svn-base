using System;
using Contract;

namespace UI.Web
{

    public interface IRangeInput<TType>
    {
        //bool AutoPostBack { get; set; }
        void Clear();
        string ErrorMessageValidator { set; }
        System.Web.UI.WebControls.ValidationCompareOperator OperatorValidator { set; }
        string TagFrom { get; set; }
        string TagTo { get; set; }
        RangeValue<TType> Value { get; set; }
        TType ValueFrom { get; set; }
        TType ValueTo { get; set; }
        
    }
    public interface IDateTimeRangeInput : IRangeInput<DateTime>{}
    public interface IDateTimeNullableRangeInput : IRangeInput<DateTime?> { }
}
