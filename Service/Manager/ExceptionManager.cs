//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Contract;
//using nc=Contract;
//using Service;
//using System.Data.SqlClient;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

//namespace Service
//{
//    public class ExceptionConfig
//    {
//        public const string SuccessMessage = "msgSuccess";
//        public const string DuplicateKeyMessage = "DuplicateKey";
//        public const string FKDeleteConstraint = "FKDeleteConstraint";
//        public const string FKUpdateConstraint = "FKUpdateConstraint";
//        public const string FKEditConstraint = "FKEditConstraint";
//        public const string DuplicateFieldMessage = "DuplicateField";

//        public static List<string> MessageKeys = new List<string>() { DuplicateKeyMessage, FKDeleteConstraint, FKEditConstraint, FKUpdateConstraint };
//    }
//    public class ExceptionManager : IExceptionManager
//    {
//        #region Tanslate
//        public string Tanslate(Exception exception)
//        {
//            string message = exception.Message;
//            if (message.StartsWith("Duplicate") && !message.Equals(ExceptionConfig.DuplicateKeyMessage))
//                return message;
//            else if (ExceptionConfig.MessageKeys.Contains(message))
//                return message;
//            else if (exception is SqlException)
//                return Tanslate(exception as SqlException);
//            else if (exception is MembershipException)
//                return Tanslate(exception as MembershipException);
//            else if (exception is ValidationException)
//                return Tanslate(exception as ValidationException);
//            else
//                return Tanslate(exception.Message);
//        }
//        public string Tanslate(SqlException exception)
//        {
//            return Tanslate("SQL_" + exception.Number.ToString());
//        }
//        public string Tanslate(MembershipException exception)
//        {
//            return Tanslate(exception.MessageCode);
//        }
//        public string Tanslate(ValidationException exception)
//        {
//            string messageFormat = Tanslate(exception.MessageCode);
//            if (exception.MessageParameters != null && exception.MessageParameters.Length > 0)
//                messageFormat = string.Format(messageFormat, exception.MessageParameters);
//            return messageFormat;
//        }
//        public string Tanslate(string key)
//        {
//            if (SolutionContext.Current.TranslateManager == null) return key;
//            return SolutionContext.Current.TranslateManager.Translate(key);
//        }
//        #endregion

//        #region Manage
//        public virtual void Manage(Exception exception)
//        {            
//            throw exception;
//        }
//        public virtual void Manage(Exception exception, IContextUser contextUser)
//        {
            
//            throw exception;
//        }
//        #endregion
//    }
//    public class ServiceExceptionManager : ExceptionManager
//    {
//        #region singleton
//        private static readonly object padlock = new object();
//        private static ServiceExceptionManager current;
//        public static ServiceExceptionManager Current
//        {
//            get
//            {
//                if (current == null)
//                    lock (padlock)
//                    {
//                        if (current == null)
//                            current = new ServiceExceptionManager();
//                    }
//                return current;
//            }
//        }
//        #endregion
        
//        #region Manage
//        public override  void Manage(Exception exception)
//        {            
//            ServiceHelper.ReloadContext();
//            bool rethrow = ExceptionPolicy.HandleException(exception, "Global Policy");
//            if (rethrow)
//                throw exception;

//            //string message = Tanslate(exception);
//            //throw new Exception(message,exception);
//        }
//        public override void Manage(Exception exception, IContextUser contextUser)
//        {
//            ServiceHelper.ReloadContext();
//            string message = Tanslate(exception);
//            throw new Exception(message, exception);
//        }               
//        #endregion        
//    }
//    public class UIExceptionManager : ExceptionManager
//    {
//        #region singleton
//        private static readonly object padlock = new object();
//        private static UIExceptionManager current;
//        public static UIExceptionManager Current
//        {
//            get
//            {
//                if (current == null)
//                    lock (padlock)
//                    {
//                        if (current == null)
//                            current = new UIExceptionManager();
//                    }
//                return current;
//            }
//        }
//        #endregion        
//    }
//}
