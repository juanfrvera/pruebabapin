using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
   

    public enum IndicadorTipoEnum
    {
        Undefined = 0
        ,
        Objetivo = 1
            ,
        Beneficio = 2
            ,
        Economico = 3
            ,
        Priorizacion = 4
            ,
        ObjetivosGobierno = 5
            ,
        EvaluacionSectorial = 6        
    }

    public class IndicadorTipoConfig
    {
        public const string OBJETIVO = "Objetivo";
        public const string BENEFICIO = "Beneficio";
        public const string ECONOMICO = "Económico";
        public const string PRIORIZACION = "Priorización";
        public const string OBJETIVOSGOBIERNO = "ObjetivosGobierno";
        public const string EVALUACIONSECTORIAL = "EvaluacionSectorial";

        public static string GetConst(IndicadorTipoEnum tipo)
        {
            switch (tipo)
            {
                case IndicadorTipoEnum.Objetivo: return OBJETIVO;
                case IndicadorTipoEnum.Beneficio: return BENEFICIO;
                case IndicadorTipoEnum.Economico: return ECONOMICO;
                case IndicadorTipoEnum.Priorizacion: return PRIORIZACION;
                case IndicadorTipoEnum.ObjetivosGobierno: return OBJETIVOSGOBIERNO;
                case IndicadorTipoEnum.EvaluacionSectorial: return EVALUACIONSECTORIAL;
            }
            return "";
        }
        public static IndicadorTipoEnum GetEnum(string tipo)
        {
            switch (tipo)
            {
                case OBJETIVO: return IndicadorTipoEnum.Objetivo;
                case BENEFICIO: return IndicadorTipoEnum.Beneficio;
                case ECONOMICO: return IndicadorTipoEnum.Economico;
                case PRIORIZACION: return IndicadorTipoEnum.Priorizacion;
                case OBJETIVOSGOBIERNO: return IndicadorTipoEnum.ObjetivosGobierno;
                case EVALUACIONSECTORIAL: return IndicadorTipoEnum.EvaluacionSectorial;
            }
            return IndicadorTipoEnum.Undefined;
        }
    }
}