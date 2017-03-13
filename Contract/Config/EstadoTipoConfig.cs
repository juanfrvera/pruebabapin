using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum EstadoTipoEnum
    {
        Undefined = 0
        , Proyecto_de_Inversion = 1
        , Proyecto_de_Prestamo = 2
        , Etapa = 3
        , Dictamen_de_Prestamo = 4
        , Dictamen_e_Inversion = 5
        , Segimiento_de_Factibildad = 6
        , Autorizaciones = 7
        , Proyecto_Calidad = 8
        , Indicador_Certificado = 9
    }

    public class EstadoTipoConfig
    {
        public const string PROYECTO_DE_INVERSION = "Proyecto de Inversión";
        public const string PROYECTO_DE_PRESTAMO = "Proyecto de Préstamo";
        public const string ETAPA = "Etapa";
        public const string DICTAMEN_DE_PRESTAMO = "Dictamen de Prestamo";
        public const string DICTAMEN_E_INVERSION = "Dictamen e Inversión";
        public const string SEGIMIENTO_DE_FACTIBILDAD = "Segimiento de Factibildad";
        public const string AUTORIZACIONES = "Autorizaciones";
        public const string PROYECTO_CALIDAD = "Proyecto Calidad";
        public const string INDICADOR_CERTIFICADO = "IndicadorCertificado";

        public static string GetConst(EstadoTipoEnum action)
        {
            switch (action)
            {
                case EstadoTipoEnum.Proyecto_de_Inversion: return PROYECTO_DE_INVERSION;
                case EstadoTipoEnum.Proyecto_de_Prestamo: return PROYECTO_DE_PRESTAMO;
                case EstadoTipoEnum.Etapa: return ETAPA;
                case EstadoTipoEnum.Dictamen_de_Prestamo: return DICTAMEN_DE_PRESTAMO;
                case EstadoTipoEnum.Dictamen_e_Inversion: return DICTAMEN_E_INVERSION;
                case EstadoTipoEnum.Segimiento_de_Factibildad: return SEGIMIENTO_DE_FACTIBILDAD;
                case EstadoTipoEnum.Autorizaciones: return AUTORIZACIONES;
                case EstadoTipoEnum.Proyecto_Calidad: return PROYECTO_CALIDAD;
                case EstadoTipoEnum.Indicador_Certificado: return INDICADOR_CERTIFICADO;
            }
            return "";
        }
        public static EstadoTipoEnum GetEnum(string action)
        {
            switch (action)
            {
                case PROYECTO_DE_INVERSION: return EstadoTipoEnum.Proyecto_de_Inversion;
                case PROYECTO_DE_PRESTAMO: return EstadoTipoEnum.Proyecto_de_Prestamo;
                case ETAPA: return EstadoTipoEnum.Etapa;
                case DICTAMEN_DE_PRESTAMO: return EstadoTipoEnum.Dictamen_de_Prestamo;
                case DICTAMEN_E_INVERSION: return EstadoTipoEnum.Dictamen_e_Inversion;
                case SEGIMIENTO_DE_FACTIBILDAD: return EstadoTipoEnum.Segimiento_de_Factibildad;
                case AUTORIZACIONES: return EstadoTipoEnum.Autorizaciones;
                case PROYECTO_CALIDAD: return EstadoTipoEnum.Proyecto_Calidad;
                case INDICADOR_CERTIFICADO: return EstadoTipoEnum.Indicador_Certificado;
            }
            return EstadoTipoEnum.Undefined;
        }
    }
}
