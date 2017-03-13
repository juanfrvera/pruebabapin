using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public interface IParameterManager:IRefresh 
    {
        string GetStringValue(string key);
        DateTime? GetDateTimeValue(string key);
        decimal? GetNumberValue(string key);
        string GetTextValue(string key);
        bool GetBooleanValue(string key);
        Parameter GetParameter(string key);
        List<ParameterResult> Parameters { get; set; }
    }
}
