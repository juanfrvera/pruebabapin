using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum ProyectoOrigenFinanciamientoTipoEnum
    {
        Undefined = 0,
        Prestamo = 1,
        Transferencia = 2
    }

    public class ProyectoOrigenFinanciamientoTipoConfig
    {
        public const string PRESTAMO = "Prestamo";
        public const string TRANSFERENCIA = "Transferencia";

        public static string GetConst(ProyectoOrigenFinanciamientoTipoEnum action)
        {
            switch (action)
            {
                case ProyectoOrigenFinanciamientoTipoEnum.Prestamo: return PRESTAMO;
                case ProyectoOrigenFinanciamientoTipoEnum.Transferencia: return TRANSFERENCIA;
            }
            return "";
        }
        public static ProyectoOrigenFinanciamientoTipoEnum GetEnum(string action)
        {
            switch (action)
            {
                case PRESTAMO: return ProyectoOrigenFinanciamientoTipoEnum.Prestamo;
                case TRANSFERENCIA: return ProyectoOrigenFinanciamientoTipoEnum.Transferencia;
            }
            return ProyectoOrigenFinanciamientoTipoEnum.Undefined;
        }
    }

    public enum PrioridadEnum
    {
        Undefined = 0
        ,
        ppa = 18
            ,
        ppp = 17
            ,
        Prioridad_0 = 1
            ,
        Prioridad_1 = 2
            ,
        Prioridad_2 = 3
            ,
        Prioridad_3 = 4
            ,
        Prioridad_3_Preferencial = 6
            ,
        Prioridad_4 = 5
            ,
        Prioridad_5 = 7
            ,
        Prioridad_6 = 8
            ,
        Prioridad_7 = 9
            ,
        Prioridad_8 = 10
            ,
        Prioridad_inactivo = 14
    }

    public class PrioridadConfig
    {
        public const string PRIORIDAD_0 = "PR0";
        public const string PRIORIDAD_1 = "PR1";
        public const string PRIORIDAD_2 = "PR2";
        public const string PRIORIDAD_3 = "PR3";
        public const string PRIORIDAD_4 = "PR4";
        public const string PRIORIDAD_3_PREFERENCIAL = "PR3P";
        public const string PRIORIDAD_5 = "PR5";
        public const string PRIORIDAD_6 = "PR6";
        public const string PRIORIDAD_7 = "PR7";
        public const string PRIORIDAD_8 = "Pr8";
        public const string PRIORIDAD_INACTIVO = "PRI";
        public const string PPP = "ppp";
        public const string PPA = "ppa";

        public static string GetConst(PrioridadEnum key)
        {
            switch (key)
            {
                case PrioridadEnum.ppa: return PPA;
                case PrioridadEnum.ppp: return PPP;
                case PrioridadEnum.Prioridad_0: return PRIORIDAD_0;
                case PrioridadEnum.Prioridad_1: return PRIORIDAD_1;
                case PrioridadEnum.Prioridad_2: return PRIORIDAD_2;
                case PrioridadEnum.Prioridad_3: return PRIORIDAD_3;
                case PrioridadEnum.Prioridad_3_Preferencial: return PRIORIDAD_3_PREFERENCIAL;
                case PrioridadEnum.Prioridad_4: return PRIORIDAD_4;
                case PrioridadEnum.Prioridad_5: return PRIORIDAD_5;
                case PrioridadEnum.Prioridad_6: return PRIORIDAD_6;
                case PrioridadEnum.Prioridad_7: return PRIORIDAD_7;
                case PrioridadEnum.Prioridad_8: return PRIORIDAD_8;
                case PrioridadEnum.Prioridad_inactivo: return PRIORIDAD_INACTIVO;
            }
            return "";
        }

        public static PrioridadEnum GetEnum(string key)
        {
            switch (key)
            {
                case PPA: return PrioridadEnum.ppa;
                case PPP: return PrioridadEnum.ppp;
                case PRIORIDAD_0: return PrioridadEnum.Prioridad_0;
                case PRIORIDAD_1: return PrioridadEnum.Prioridad_1;
                case PRIORIDAD_2: return PrioridadEnum.Prioridad_2;
                case PRIORIDAD_3: return PrioridadEnum.Prioridad_3;
                case PRIORIDAD_3_PREFERENCIAL: return PrioridadEnum.Prioridad_3_Preferencial;
                case PRIORIDAD_4: return PrioridadEnum.Prioridad_4;
                case PRIORIDAD_5: return PrioridadEnum.Prioridad_5;
                case PRIORIDAD_6: return PrioridadEnum.Prioridad_6;
                case PRIORIDAD_7: return PrioridadEnum.Prioridad_7;
                case PRIORIDAD_8: return PrioridadEnum.Prioridad_8;
                case PRIORIDAD_INACTIVO: return PrioridadEnum.Prioridad_inactivo;
            } return PrioridadEnum.Undefined;
        }
    }
}