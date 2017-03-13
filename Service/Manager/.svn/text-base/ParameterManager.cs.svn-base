using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;

namespace Service
{
    public class ParameterManager : IParameterManager 
    {
        
        #region singleton
        private static readonly object padlock = new object();
        private static ParameterManager current;
        public static ParameterManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new ParameterManager();
                    }
                return current;
            }
        }
        #endregion
        
        public string GetStringValue(string key)
        {
            Parameter parameter = GetParameter(key);
            if (parameter == null) return null;
            return parameter.StringValue;
        }
        public bool GetBooleanValue(string key)
        {
            Parameter parameter = GetParameter(key);
            if (parameter == null) return false;
            if(parameter.StringValue.Length == 1)
              return parameter.StringValue=="Y" || parameter.StringValue=="S";
            else return parameter.StringValue=="YES" || parameter.StringValue=="SI";
        }
        public DateTime? GetDateTimeValue(string key)
        {
            Parameter parameter = GetParameter(key);
            if (parameter == null) return null;
            return parameter.DateValue;
        }
        public decimal? GetNumberValue(string key)
        {
            Parameter parameter = GetParameter(key);
            if (parameter == null) return null;
            return parameter.NumberValue;
        }
        public string GetTextValue(string key)
        {
            Parameter parameter = GetParameter(key);
            if (parameter == null) return null;
            return parameter.TextValue;
        }
        public Parameter GetParameter(string key)
        {
            //ParameterResult  parameterResult = ParameterService.Current.GetResult(new nc.ParameterFilter () { Code  = key}).FirstOrDefault();
            ParameterResult parameterResult = (from o in this.Parameters where o.Code == key select o).FirstOrDefault();
            if (parameterResult == null) return null; 
            return parameterResult.ToEntity ();
        }
        private List<ParameterResult> parameters;
        public List<ParameterResult> Parameters
        {
            get
            {
                if (parameters == null)
                {
                    parameters = SolutionContext.Current.CacheByApplicationManager["SLTN_PARAMETERS"] as List<ParameterResult>;
                    if (parameters == null)
                    {
                        parameters = ParameterService.Current.GetResult();
                        SolutionContext.Current.CacheByApplicationManager["SLTN_PARAMETERS"] = parameters;
                    }
                }
                return parameters;
            }
            set { parameters = value; }
        }

        public void Refresh()
        {
            parameters = null;
            SolutionContext.Current.CacheByApplicationManager["SLTN_PARAMETERS"] = null;

        }




    }
}
