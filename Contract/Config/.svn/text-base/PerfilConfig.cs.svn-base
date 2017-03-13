using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    //public enum PerfilEnum
    //{
    //    Undefined = 0,
    //    Iniciador = 3,
    //    Responsable = 4,
    //    Ejecutor = 8
    //}

    public class PerfilConfig
    {
        public const string RESPONSABLE = "RESP";
        public const string INICIADOR = "INIC";
        public const string EJECUTOR = "EJEC";
        public const string ASOCIADO = "ASCPM";
        public const string RESPONSABLE_PRESTAMO = "RSPPM";

        public static int IdResponsable{get {return SolutionContext.Current.PerfilCache.GetIdByCode(RESPONSABLE); }}
        public static int IdIniciador { get { return SolutionContext.Current.PerfilCache.GetIdByCode(INICIADOR); } }
        public static int IdEjecutor { get { return SolutionContext.Current.PerfilCache.GetIdByCode(EJECUTOR); } }
        public static int IdAsociado { get { return SolutionContext.Current.PerfilCache.GetIdByCode(ASOCIADO); } }
        public static int IdResponsablePrestamo { get { return SolutionContext.Current.PerfilCache.GetIdByCode(RESPONSABLE_PRESTAMO); } }

        //public static string GetConst(PerfilEnum action)
        //{
        //    switch (action)
        //    {
        //        case PerfilEnum.Responsable: return RESPONSABLE;
        //        case PerfilEnum.Iniciador: return INICIADOR;
        //        case PerfilEnum.Ejecutor: return EJECUTOR;
        //    }
        //    return "";
        //}
        //public static PerfilEnum GetEnum(string action)
        //{
        //    switch (action)
        //    {
        //        case RESPONSABLE: return PerfilEnum.Responsable;
        //        case INICIADOR: return PerfilEnum.Iniciador;
        //        case EJECUTOR: return PerfilEnum.Ejecutor;
        //    }
        //    return PerfilEnum.Undefined;
        //}
    }
}