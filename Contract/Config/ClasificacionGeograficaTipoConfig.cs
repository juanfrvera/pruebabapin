using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum ClasificacionGeograficaTipoEnum
    { 
        Undefined = 0 
        , Departamento = 2
        , Localidad = 3
        , Provincia = 1

     }
     public class ClasificacionGeograficaTipoConfig
     {
        public const string PROVINCIA = "1";
        public const string DEPARTAMENTO = "2";
        public const string LOCALIDAD = "3";

     
        public static string GetConst(ClasificacionGeograficaTipoEnum key)
        {
            switch (key)
            {

                case ClasificacionGeograficaTipoEnum.Departamento: return DEPARTAMENTO;
                case ClasificacionGeograficaTipoEnum.Localidad: return LOCALIDAD;
                case ClasificacionGeograficaTipoEnum.Provincia: return PROVINCIA;
            }
            return "";
        }
        public static ClasificacionGeograficaTipoEnum GetEnum(string key)
        {
            switch (key)
            {
                case DEPARTAMENTO: return ClasificacionGeograficaTipoEnum.Departamento;
                case LOCALIDAD: return ClasificacionGeograficaTipoEnum.Localidad;
                case PROVINCIA: return ClasificacionGeograficaTipoEnum.Provincia;

            }
            return ClasificacionGeograficaTipoEnum.Undefined;
        }
    }
}

