using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum GeoreferenciacionTipoEnum
    {
        Undefined = 0,
        Punto = 1,
        Linea = 2, 
        Poligono = 3
    }

    public class GeoreferenciacionTipoConfig
    {
        public const string PUNTO = "Punto";
        public const string LINEA = "Línea";
        public const string POLIGONO = "Polígono";

        public static string GetConst(GeoreferenciacionTipoEnum action)
        {
            switch (action)
            {
                case GeoreferenciacionTipoEnum.Punto: return PUNTO;
                case GeoreferenciacionTipoEnum.Linea: return LINEA;
                case GeoreferenciacionTipoEnum.Poligono: return POLIGONO;
            }
            return "";
        }
        public static GeoreferenciacionTipoEnum GetEnum(string action)
        {
            switch (action)
            {
                case PUNTO: return GeoreferenciacionTipoEnum.Punto;
                case LINEA: return GeoreferenciacionTipoEnum.Linea;
                case POLIGONO: return GeoreferenciacionTipoEnum.Poligono;
            }
            return GeoreferenciacionTipoEnum.Undefined;
        }
    }
}
