using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum AuditMandateEnum
    { Undefined     = 0
    , Unknown       = 1
    , LogoutNormal  = 2
    , TimeOut       = 3
    , DepurateUser  = 4
    , KillUser      = 5 
    , ErrorFatal    = 6
    , ErrorSystem   = 7
    , ErrorUnknown  = 8
    }
    public class AuditMandateConfig
    {
    public const string UNDEFINED       = "X";
    public const string UNKNOWN         = "Z";
    public const string LOGOUT_NORMAL   = "N";
    public const string TIMEOUT         = "T";
    public const string DEPUTARE_USER   = "D";
    public const string KILL_USER       = "K";
    public const string ERROR_FATAL     = "F";
    public const string ERROR_SYSTEM    = "S";
    public const string ERROR_UNKNOWN   = "U";

    public static string GetConst(AuditMandateEnum action)
    {
        switch (action)
        {
            case AuditMandateEnum.Undefined:    return UNDEFINED;
            case AuditMandateEnum.Unknown:      return UNKNOWN;
            case AuditMandateEnum.LogoutNormal: return LOGOUT_NORMAL;
            case AuditMandateEnum.TimeOut:      return TIMEOUT;
            case AuditMandateEnum.DepurateUser: return DEPUTARE_USER;
            case AuditMandateEnum.KillUser:     return KILL_USER;
            case AuditMandateEnum.ErrorFatal:   return ERROR_FATAL;
            case AuditMandateEnum.ErrorSystem:  return ERROR_SYSTEM;
            case AuditMandateEnum.ErrorUnknown: return ERROR_UNKNOWN;            
        }
        return "";
    }
    public static AuditMandateEnum GetEnum(ErrorTypeEnum erroType)
    {
        switch (erroType)
        {
            case ErrorTypeEnum.Undefined: return AuditMandateEnum.Undefined;
            case ErrorTypeEnum.Fatal: return AuditMandateEnum.ErrorFatal;
            case ErrorTypeEnum.System: return AuditMandateEnum.ErrorSystem;
            case ErrorTypeEnum.Unkwon: return AuditMandateEnum.ErrorUnknown;  
        }
        return AuditMandateEnum.Unknown;
    } 
    public static AuditMandateEnum GetEnum(string action)
    {
        switch (action)
        {
            case UNDEFINED:     return AuditMandateEnum.Undefined;
            case UNKNOWN:       return AuditMandateEnum.Unknown;
            case LOGOUT_NORMAL: return AuditMandateEnum.LogoutNormal;
            case TIMEOUT:       return AuditMandateEnum.TimeOut;
            case DEPUTARE_USER: return AuditMandateEnum.DepurateUser;
            case KILL_USER:     return AuditMandateEnum.KillUser;
            case ERROR_FATAL:   return AuditMandateEnum.ErrorFatal;
            case ERROR_SYSTEM:  return AuditMandateEnum.ErrorSystem;
            case ERROR_UNKNOWN: return AuditMandateEnum.ErrorUnknown;  
        }
        return AuditMandateEnum.Unknown;
    }   
}
}
