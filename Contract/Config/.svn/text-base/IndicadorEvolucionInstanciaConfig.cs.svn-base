using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{

    public enum IndicadorEvolucionInstanciaEnum
    {
        Undefined = 0
        ,
        Base = 1
            ,
        Intermedio = 2
            ,
        Final = 3
    }

    public class IndicadorEvolucionInstanciaConfig
    {
        public const string BASE = "Base";
        public const string INTERMEDIO = "Intermedio";
        public const string FINAL = "Final";
       
        public static string GetConst(IndicadorEvolucionInstanciaEnum tipo)
        {
            switch (tipo)
            {
                case IndicadorEvolucionInstanciaEnum.Base: return BASE;
                case IndicadorEvolucionInstanciaEnum.Intermedio: return INTERMEDIO;
                case IndicadorEvolucionInstanciaEnum.Final: return FINAL;
            }
            return "";
        }
        public static IndicadorEvolucionInstanciaEnum GetEnum(string tipo)
        {
            switch (tipo)
            {
                case BASE: return IndicadorEvolucionInstanciaEnum.Base;
                case INTERMEDIO: return IndicadorEvolucionInstanciaEnum.Intermedio;
                case FINAL: return IndicadorEvolucionInstanciaEnum.Final;
            }
            return IndicadorEvolucionInstanciaEnum.Undefined;
        }
    }
}