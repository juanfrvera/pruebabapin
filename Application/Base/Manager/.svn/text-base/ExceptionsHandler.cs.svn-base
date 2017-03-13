using System;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices. EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Contract;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UI.Web;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using System.Diagnostics;
using System.IO;
   
namespace EnterpriseLibrary
{
    public class ApplicationExceptionHandlerBase : ExceptionHandlerBase
    {
        protected void Redirect(string message)
        {
            UIContext.Current.SetValue(Path.GetFileName(UIContext.Current.PageError), UIContext.Current.PARAMETER_ERROR_MESSAGE, message);
            HttpContext.Current.Response.Redirect(UIContext.Current.PageError,false);
        }
        protected void CloseSession(ErrorTypeEnum errorType,string message)
        {
            //UIHelper.CloseAudit(AuditMandateConfig.GetEnum(errorType),message);
            //UIContext.Current.ContextUser = null;
            //HttpContext.Current.Session.Clear();
            //FormsAuthentication.SignOut();
        }
    
    }

 
  [ConfigurationElementType(typeof(CustomHandlerData))]
    public class ApplicationExceptionHandler : ApplicationExceptionHandlerBase, IExceptionHandler
  {
      public ApplicationExceptionHandler(NameValueCollection ignore)
      {
      }
      public Exception HandleException(Exception exception, Guid correlationID)
      {
          //CloseSession(ErrorTypeEnum.Unkwon,exception.Message);
          Log(MESSAGE_NOT_FOUND, exception.Message, exception.StackTrace, EventLogEntryType.Error);
          //Redirect(MESSAGE_NOT_FOUND);
          return new Exception(exception.Message);
      }
  }
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class ServiceExceptionHandler : ApplicationExceptionHandlerBase, IExceptionHandler
  {
      public ServiceExceptionHandler(NameValueCollection ignore)
      {
      }
      public Exception HandleException(Exception exception, Guid correlationID)
      {
          return new Exception(exception.Message);
          //ServiceException _exception = exception as ServiceException;
          //if (_exception == null)
          //{
          //    CloseSession(ErrorTypeEnum.Unkwon,exception.Message);
          //    Redirect(MESSAGE_NOT_FOUND);
          //}
          //return new Exception(_exception.Message);

          //switch (_exception.ErrorType)
          //{ 
          //    case ErrorTypeEnum.Fatal:
          //    case ErrorTypeEnum.System:
          //    case ErrorTypeEnum.Unkwon:
          //        ////CloseSession(_exception.ErrorType,_exception.OriginalMessage);
          //        //Redirect(_exception.Message);
          //        //break;
          //    case ErrorTypeEnum.User:
          //        return new Exception(_exception.Message);
          //        break;
          //    default:
          //        //CloseSession(ErrorTypeEnum.Unkwon,_exception.OriginalMessage);
          //        Redirect(_exception.Message);
          //        break;
          //}
          //return new Exception(_exception.Message);
      }      
  }
  [ConfigurationElementType(typeof(CustomHandlerData))]
  public class UIValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
  {
      public UIValidationExceptionHandler(NameValueCollection ignore)
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
          return new Exception(message);
      }
  }

  

}
