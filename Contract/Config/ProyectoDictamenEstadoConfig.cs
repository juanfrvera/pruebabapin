using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum ProyectoDicatamenEstadoEnum
    {
        Undefined = 0,
        EnEsperaDNIP = 31,
        EnEsperaRespuesta = 25,
        EnEsperaSPE = 30,
        Terminado = 8,
        Dictaminado = 32,
        Migracion = 44 /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
    }

    public class ProyectoDicatamenEstadoConfig
    {
        public const string EN_ESPERA_DNIP= "EnEsperaDNIP";
        public const string EN_ESPERA_RESPUESTA = "EnEsperaRespuesta";
        public const string EN_ESPERA_SPE = "EnEsperaSPE";
        public const string TERMINADO = "Terminado";
        public const string DICTAMINADO = "Dictaminado";
        public const string MIGRACION = "Migracion"; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */

        public static string GetConst(ProyectoDicatamenEstadoEnum action)
        {
            switch (action)
            {
                case ProyectoDicatamenEstadoEnum.EnEsperaDNIP: return EN_ESPERA_DNIP;
                case ProyectoDicatamenEstadoEnum.EnEsperaRespuesta: return EN_ESPERA_RESPUESTA;
                case ProyectoDicatamenEstadoEnum.EnEsperaSPE: return EN_ESPERA_SPE;
                case ProyectoDicatamenEstadoEnum.Terminado: return TERMINADO;
                case ProyectoDicatamenEstadoEnum.Dictaminado: return DICTAMINADO;
                case ProyectoDicatamenEstadoEnum.Migracion: return MIGRACION; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
            }
            return "";
        }
        public static ProyectoDicatamenEstadoEnum GetEnum(string action)
        {
            switch (action)
            {
                case EN_ESPERA_DNIP: return ProyectoDicatamenEstadoEnum.EnEsperaDNIP;
                case EN_ESPERA_RESPUESTA: return ProyectoDicatamenEstadoEnum.EnEsperaRespuesta;
                case EN_ESPERA_SPE: return ProyectoDicatamenEstadoEnum.EnEsperaSPE;
                case TERMINADO: return ProyectoDicatamenEstadoEnum.Terminado;
                case DICTAMINADO: return ProyectoDicatamenEstadoEnum.Dictaminado;
                case MIGRACION: return ProyectoDicatamenEstadoEnum.Migracion; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
            }
            return ProyectoDicatamenEstadoEnum.Undefined;
        }
    }
}