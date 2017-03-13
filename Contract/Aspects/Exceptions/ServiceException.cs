using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum ErrorTypeEnum
    { Undefined     = 0
    , Unkwon        = 1
    , User          = 2
    , System        = 3
    , Fatal         = 4
    }
    public class ServiceException : Exception
    {
        public ErrorTypeEnum ErrorType { get; set; }

        //public ServiceException(string message, ErrorTypeEnum errorType)
        //    : base(message)
        //{
        //    ErrorType = errorType;
        //}
        public ServiceException(string message, ErrorTypeEnum errorType,Exception innerException)
            : base(message, innerException)
        {
            ErrorType = errorType;
        }

        public string OriginalMessage
        {
            get { return this.InnerException != null ? this.InnerException.Message : this.Message;}
        }
    }
}
