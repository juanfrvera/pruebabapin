using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum FaseEnum
    {
        Undefined = 0,
        Planeamiento = 1,
        Ejecucion = 2,
        Operacion = 3,
        Desmantelamiento = 4
    }

    public class FaseConfig
    {
        public const string PLANEAMIENTO = "Planeamiento";
        public const string EJECUCION = "Ejecución";
        public const string OPERACION = "Operación";
        public const string DESMANTELAMIENTO = "Desmantelamiento";

        public static string GetConst(FaseEnum action)
        {
            switch (action)
            {
                case FaseEnum.Planeamiento: return PLANEAMIENTO;
                case FaseEnum.Ejecucion: return EJECUCION;
                case FaseEnum.Operacion: return OPERACION;
                case FaseEnum.Desmantelamiento: return DESMANTELAMIENTO;
            }
            return "";
        }
        public static FaseEnum GetEnum(string action)
        {
            switch (action)
            {
                case PLANEAMIENTO: return FaseEnum.Planeamiento;
                case EJECUCION: return FaseEnum.Ejecucion;
                case OPERACION: return FaseEnum.Operacion;
                case DESMANTELAMIENTO: return FaseEnum.Desmantelamiento;
            }
            return FaseEnum.Undefined;
        }
    }
}