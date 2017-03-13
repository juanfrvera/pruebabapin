using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum EstadoEnum
    { Undefined = 0 
, Idea = 1
, Perfil = 2
, PreFactibilidad = 3
, Factibilidad = 4
, En_Ejecucion = 5
, En_EjecOper = 6
, En_Operacion = 7
, Terminado = 8
, Cancelado = 9
, Postergado = 10
, Suspendio = 11
, Inicio_de_Gestion = 12
, Autorizacion_a_Negociar = 13
, Pendiente = 15
, Iniciado = 16
, Conformado = 17
, Suspendido = 18
, En_espera_de_Informacion = 23
, en_Espera_de_Respuesta = 25
, En_espera_de_CT = 29
, En_espera_de_SPE = 30
, En_espera_de_DNIP = 31
, Dictaminado = 32
, Postulado = 34
, Aprobado = 35
, Revisado = 37
, A_Corregir = 38
, Corregido = 39
, Respondido = 40
, Migracion = 44 /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
 }
 public class EstadoConfig
 {
public const string IDEA = "II";
public const string PERFIL = "IL";
public const string PREFACTIBILIDAD = "IV";
public const string FACTIBILIDAD = "IF";
public const string EN_EJECUCION = "IE";
public const string EN_EJEC_OPER = "OE";
public const string EN_OPERACION = "IO";
public const string TERMINADO = "IT";
public const string CANCELADO = "IC";
public const string POSTERGADO = "IP";
public const string SUSPENDIO = "IS";
public const string INICIO_DE_GESTION = "PG";
public const string AUTORIZACION_A_NEGOCIAR = "PA";
public const string PENDIENTE = "EP";
public const string INICIADO = "EI";
public const string CONFORMADO = "CO";
public const string SUSPENDIDO = "ES";
public const string EN_ESPERA_DE_INFORMACION = "PE";
public const string EN_ESPERA_DE_RESPUESTA = "IR";
public const string EN_ESPERA_DE_CT = "SC";
public const string EN_ESPERA_DE_SPE = "SS";
public const string EN_ESPERA_DE_DNIP = "SP";
public const string DICTAMINADO = "SD";
public const string POSTULADO = "AP";
public const string APROBADO = "AA";
public const string REVISADO = "CR";
public const string A_CORREGIR = "CU";
public const string CORREGIDO = "PU";
public const string RESPONDIDO = "RE";
public const string MIGRACION = "MI"; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */

 public static string GetConst(EstadoEnum key)
        {
            switch (key)
            {
case EstadoEnum.Idea: return IDEA;
case EstadoEnum.Perfil: return PERFIL;
case EstadoEnum.PreFactibilidad: return PREFACTIBILIDAD;
case EstadoEnum.Factibilidad: return FACTIBILIDAD;
case EstadoEnum.En_Ejecucion: return EN_EJECUCION;
case EstadoEnum.En_EjecOper: return EN_EJEC_OPER;
case EstadoEnum.En_Operacion: return EN_OPERACION;
case EstadoEnum.Terminado: return TERMINADO;
case EstadoEnum.Cancelado: return CANCELADO;
case EstadoEnum.Postergado: return POSTERGADO;
case EstadoEnum.Suspendio: return SUSPENDIO;
case EstadoEnum.Inicio_de_Gestion: return INICIO_DE_GESTION;
case EstadoEnum.Autorizacion_a_Negociar: return AUTORIZACION_A_NEGOCIAR;
case EstadoEnum.Pendiente: return PENDIENTE;
case EstadoEnum.Iniciado: return INICIADO;
case EstadoEnum.Conformado: return CONFORMADO;
case EstadoEnum.Suspendido: return SUSPENDIDO;
case EstadoEnum.En_espera_de_Informacion: return EN_ESPERA_DE_INFORMACION;
case EstadoEnum.en_Espera_de_Respuesta: return EN_ESPERA_DE_RESPUESTA;
case EstadoEnum.En_espera_de_CT: return EN_ESPERA_DE_CT;
case EstadoEnum.En_espera_de_SPE: return EN_ESPERA_DE_SPE;
case EstadoEnum.En_espera_de_DNIP: return EN_ESPERA_DE_DNIP;
case EstadoEnum.Dictaminado: return DICTAMINADO;
case EstadoEnum.Postulado: return POSTULADO;
case EstadoEnum.Aprobado: return APROBADO;
case EstadoEnum.Revisado: return REVISADO;
case EstadoEnum.A_Corregir: return A_CORREGIR;
case EstadoEnum.Corregido: return CORREGIDO;
case EstadoEnum.Respondido: return RESPONDIDO;
case EstadoEnum.Migracion: return MIGRACION; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */

}
            return "";
        }
        public static EstadoEnum GetEnum(string key)
        {
            switch (key)
            {
case IDEA: return EstadoEnum.Idea;
case PERFIL: return EstadoEnum.Perfil;
case PREFACTIBILIDAD: return EstadoEnum.PreFactibilidad;
case FACTIBILIDAD: return EstadoEnum.Factibilidad;
case EN_EJECUCION: return EstadoEnum.En_Ejecucion;
case EN_EJEC_OPER: return EstadoEnum.En_EjecOper;
case EN_OPERACION: return EstadoEnum.En_Operacion;
case TERMINADO: return EstadoEnum.Terminado;
case CANCELADO: return EstadoEnum.Cancelado;
case POSTERGADO: return EstadoEnum.Postergado;
case SUSPENDIO: return EstadoEnum.Suspendio;
case INICIO_DE_GESTION: return EstadoEnum.Inicio_de_Gestion;
case AUTORIZACION_A_NEGOCIAR: return EstadoEnum.Autorizacion_a_Negociar;
case PENDIENTE: return EstadoEnum.Pendiente;
case INICIADO: return EstadoEnum.Iniciado;
case CONFORMADO: return EstadoEnum.Conformado;
case SUSPENDIDO: return EstadoEnum.Suspendido;
case EN_ESPERA_DE_INFORMACION: return EstadoEnum.En_espera_de_Informacion;
case EN_ESPERA_DE_RESPUESTA: return EstadoEnum.en_Espera_de_Respuesta;
case EN_ESPERA_DE_CT: return EstadoEnum.En_espera_de_CT;
case EN_ESPERA_DE_SPE: return EstadoEnum.En_espera_de_SPE;
case EN_ESPERA_DE_DNIP: return EstadoEnum.En_espera_de_DNIP;
case DICTAMINADO: return EstadoEnum.Dictaminado;
case POSTULADO: return EstadoEnum.Postulado;
case APROBADO: return EstadoEnum.Aprobado;
case REVISADO: return EstadoEnum.Revisado;
case A_CORREGIR: return EstadoEnum.A_Corregir;
case CORREGIDO: return EstadoEnum.Corregido;
case RESPONDIDO : return EstadoEnum.Respondido ;
case MIGRACION: return EstadoEnum.Migracion; /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */

 }
            return EstadoEnum.Undefined;
        }
    }
}

