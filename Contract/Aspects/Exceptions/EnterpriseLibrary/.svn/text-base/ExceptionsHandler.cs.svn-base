using System;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices. EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Contract;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;
   
namespace EnterpriseLibrary
{
    public class ExceptionHandlerBase
    {     
        protected readonly string MESSAGE_NOT_FOUND = "Error sin Especificacion";

        protected string Tanslate(string key)
        {
           if (SolutionContext.Current.TextManager == null) return MESSAGE_NOT_FOUND;
           string message = SolutionContext.Current.TextManager.Translate(key);
           return (message!=null)?message:MESSAGE_NOT_FOUND;
        }
        protected void Log(string translateMessage, string originalMessage, string traceMessage, EventLogEntryType eventType)
        {
            string message = string.Format("Translate:{0} Original:{1} Trace:{2}", translateMessage!=null?translateMessage:originalMessage, originalMessage, traceMessage);
            //Logger.Write(message, "Application", 1, 0, eventType, translateMessage);
            try
            {
                EventLog.WriteEntry(SolutionContext.Current.NameApplication, string.Format("Message:\r\n{0}\r\nStackTrace:\r\n{1}", originalMessage, traceMessage), eventType);
            }
            catch { }
        }
        protected void Log(Exception exception)
        {

            
        }
  }      
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class DefaultExceptionHandler : ExceptionHandlerBase, IExceptionHandler
  {
      public DefaultExceptionHandler(NameValueCollection ignore)
     {
     }
     public Exception HandleException(Exception exception, Guid correlationID)
     {
         string message = Tanslate(exception.Message);
         Log(message, exception.Message, exception.StackTrace, EventLogEntryType.Error);
         return new ServiceException(message, ErrorTypeEnum.System,exception);
     }          
  }
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class SqlExceptionExceptionHandler : ExceptionHandlerBase,IExceptionHandler
  {
     public SqlExceptionExceptionHandler(NameValueCollection ignore)
     {
     }
     public Exception HandleException(Exception exception, Guid correlationID)
     {
         SqlException sqlException = exception as SqlException;
         if (sqlException != null)
         {
             string message = Tanslate("SQL_" + sqlException.Number.ToString());
             Log(message, exception.Message, exception.StackTrace, EventLogEntryType.Error);
             return new ServiceException(message, ErrorTypeEnum.User,exception);
         }
         else
         {
             Log(MESSAGE_NOT_FOUND, exception.Message, exception.StackTrace, EventLogEntryType.Error);
             return new ServiceException(MESSAGE_NOT_FOUND,ErrorTypeEnum.User,exception);
         }
     }     
  }
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class MembershipExceptionHandler : ExceptionHandlerBase,IExceptionHandler
  {
      public MembershipExceptionHandler(NameValueCollection ignore)
     {
     }
     public Exception HandleException(Exception exception, Guid correlationID)
     {
         string message = MESSAGE_NOT_FOUND;
         MembershipException _exception = exception as MembershipException;
         if (_exception != null)
           message = Tanslate("MEMBERSHIP_" + _exception.MessageCode);

         Log(message, exception.Message, exception.StackTrace, EventLogEntryType.Error);
         return new ServiceException(message, ErrorTypeEnum.Fatal,exception);
     }     
  }
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class ValidationExceptionHandler : ExceptionHandlerBase,IExceptionHandler
  {
      public ValidationExceptionHandler(NameValueCollection ignore)
     {
     }
     public Exception HandleException(Exception exception, Guid correlationID)
     {
         string message = MESSAGE_NOT_FOUND;
         ValidationException _exception = exception as ValidationException;
         if (_exception != null)
         {
             string messageFormat = Tanslate(_exception.MessageCode);
             if (_exception.MessageParameters != null && _exception.MessageParameters.Length > 0)
                 message = string.Format(messageFormat, _exception.MessageParameters);
             else
                 message = messageFormat;

             if (message == MESSAGE_NOT_FOUND) message = _exception.MessageCode;
         }
         Log(message, exception.Message, exception.StackTrace, EventLogEntryType.Warning);
         return new ServiceException(message, ErrorTypeEnum.User,exception);
     }     
  }
  
}
