using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum PerfilTipoEnum
    {   
         Undefined  = 0
        , Sistema   = 1
        , Oficina   = 2
        , Proyecto  = 3
    }
 
    public class PerfilTipoConfig
    {
        public const string SISTEMA  = "Sistema";
        public const string OFICINA  = "Oficina";
        public const string PROYECTO = "Proyecto";

        public static string GetConst(PerfilTipoEnum action)
        {
            switch (action)
            {
                case PerfilTipoEnum.Sistema: return SISTEMA;
                case PerfilTipoEnum.Oficina: return OFICINA;
                case PerfilTipoEnum.Proyecto : return PROYECTO ;
            }
            return "";
        }
        public static PerfilTipoEnum GetEnum(string action)
        {
            switch (action)
            {
                case SISTEMA: return PerfilTipoEnum.Sistema;
                case OFICINA: return PerfilTipoEnum.Oficina;
                case PROYECTO : return PerfilTipoEnum.Proyecto ;
            }
            return PerfilTipoEnum.Undefined;
        }   
    }
}
