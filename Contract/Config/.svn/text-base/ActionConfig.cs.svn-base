using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum CrudActionEnum
    { Undefined = 0
    , Unknown   = 1
    , Create    = 2
    , Read      = 3
    , Update    = 4 
    , Delete    = 5 
    }
    public enum ActionEnum
    { Undefined = 0
    , Unknown   = 1
    , Create    = 2
    , Read      = 3
    , Update    = 4 
    , Delete    = 5
    , Save      = 6
    }
    public class ActionConfig
    {
    public const string CREATE  = "CREATE";
    public const string READ    = "READ";    
    public const string UPDATE  = "UPDATE";
    public const string DELETE  = "DELETE";
    public const string COPY    = "COPY";
    public const string SAVE    = "SAVE";
    public const string OK      = "OK";
    public const string REFUSE  = "REFUSE";
    public const string APPROVE = "APPROVE";
    public const string REVISE  = "REVISE";
    public const string UPLOAD_FILES = "UPLOAD_FILES";
    public const string SHOW_ALCANCEGEOGRAFICO = "SHOW_ALCANCEGEOGRAFICO";
    public const string SHOW_CANALES = "SHOW_CANALES";
    public const string CREATE_REQUERIMIENTO = "CREATE_REQUERIMIENTO";
    public const string ACCEPT = "ACCEPT";
    public const string CANCEL = "CANCEL";
    public const string FINISH = "FINISH";
    public const string EDIT = "EDIT";
    public const string LOG = "LOG";
    public const string LIST = "LIST";
    public const string COMPLETE = "COMPLETE";
    public const string HISTORY_PLAN = "HISTORY_PLAN";
    public const string PRINT = "PRINT";
    public const string CHANGE_STRUCTURE = "CHANGE_STRUCTURE";

    public const string POSTULAR = "POSTULAR";
    public const string CONFORMAR = "CONFORMAR";
    public const string ACEPTAR = "ACEPTAR";
    public const string OBSERVAR = "OBSERVAR";
    public const string REINICIAR = "REINICIAR";
    public const string ESTADO_DESICION_HISTORY = "EstadoDesicionHistory";

    public const string POSTULADO = "Postulado";
    public const string CONFORMADO = "Conformado";
    public const string ACEPTADO = "Aceptado";
    public const string OBSERVADO = "Observado";
    public const string REINICIADO = "Reiniciado";

        

    public static string GetConst(ActionEnum action)
    {
        switch (action)
        {
            case ActionEnum.Create: return CREATE;
            case ActionEnum.Read: return READ;
            case ActionEnum.Update: return UPDATE;
            case ActionEnum.Delete: return DELETE;
            case ActionEnum.Save: return SAVE;
        }
        return "";
    }
    public static ActionEnum GetEnum(string action)
    {
        switch (action)
        {
            case CREATE: return ActionEnum.Create;
            case READ: return ActionEnum.Read;
            case UPDATE: return ActionEnum.Update;
            case DELETE: return ActionEnum.Delete;
            case SAVE: return ActionEnum.Save;
        }
        return ActionEnum.Unknown;
    }   
}
}
