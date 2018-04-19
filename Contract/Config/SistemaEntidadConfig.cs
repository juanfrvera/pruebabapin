
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum SistemaEntidadEnum
    { Undefined = 0 

, Objetivo_Supuesto = 436
, Proyecto = 437
, Proyecto_Beneficiario_Indicador = 438
, Evaluacion_Resultado = 439
, Audit_Operation_Detail = 440
, Prestamo_Financiamiento = 441
, Indicador_Objetivo = 442
, Prestamo_Oficina_Perfil = 443
, Proyecto_Seguimiento = 444
, Indicador_Economico = 445
, Sistema_Entidad_Estado = 446
, Proyecto_Seguimiento_Localizacion = 447
, Programa = 448
, Indicador_Tipo = 449
, Estado = 450
, Indicador = 451
, Sistema_Entidad_Accion = 452
, Proyecto_Calificacion = 453
, Proyecto_Seguimiento_Estado = 454
, Indicador_Evolucion = 455
, Objetivo_Indicador = 456
, Indicador_Relacion_Rubro = 457
, Proyecto_Etapa = 458
, Proyecto_Oficina_Perfil = 459
, Jurisdiccion = 460
, Proyecto_Producto = 461
, Proyecto_Seguimiento_Proyecto = 462
, Perfil_Tipo = 463
, Moneda_Cotizacion = 464
, Indicador_Medio_Verificacion = 465
, Actividad_Permiso = 466
, Proyecto_Dictamen_Seguimiento = 467
, Sector = 468
, Proyecto_Comentario_Tecnico = 469
, Administracion_Tipo = 470
, Prestamo_Sub_Convenio = 471
, Proyecto_Producto_Proyecto_Etapa = 472
, Actividad = 473
, Entidad_Tipo = 474
, Option_Menu = 475
, Cargo = 476
, Clasificacion = 477
, Sub_Jurisdiccion = 478
, Language = 479
, Proyecto_Beneficio_Indicador = 480
, Proyecto_Origen_Financiamiento = 481
, Perfil_Actividad = 482
, Plan_Periodo = 483
, Organismo_Tipo = 484
, Prestamo_Oficina_Funcionario = 485
, Indicador_Rubro = 486
, Proyecto_Origen_Financiamiento_Tipo = 487
, Prestamo_Estado = 488
, Prestamo_Producto = 489
, Proceso_Tipo = 490
, Proyecto_Demora = 491
, Organismo_Prioridad = 492
, Clasificacion_Geografica = 493
, Perfil = 494
, Proyecto_Calidad = 495
, Organismo_Financiero = 496
, Prestamo_Dictamen_Estado = 497
, Proyecto_Prioridad = 498
, Proyecto_Tipo = 499
, Prestamo_Alcance_Geografico = 500
, Prestamo_Objetivo_Especifico = 501
, Gestion_Tipo = 502
, Modalidad_Financiera = 503
, Prioridad = 504
, Proyecto_Plan = 505
, Prestamo_Calificacion = 506
, Programa_Objetivo = 507
, Prestamo_Objetivo = 508
, Sub_Programa = 509
, Prestamo_Modalidad_Financiera = 510
, Proyecto_Dictamen = 511
, Finalidad_Funcion_Tipo = 512
, Sub_Convenio_Tipo = 513
, Oficina = 514
, Finalidad_Funcion = 515
, Prestamo = 516
, Prestamo_Dictamen = 517
, Objetivo = 518
, Fuente_Financiamiento_Tipo = 519
, Saf = 520
, Message_Media = 521
, Proyecto_Relacion_Tipo = 522
, Clasificacion_Gasto_Tipo = 523
, Proyecto_Etapa_Indicador = 524
, Proyecto_Relacion = 525
, Moneda = 526
, Indicador_Priorizacion = 527
, Message_Attach = 528
, Fase = 529
, Proyecto_Etapa_Estimado = 530
, Text = 531
, Message_Send = 532
, Plan_Tipo = 533
, Proyecto_Alcance_Geografico = 534
, Prestamo_Componente = 535
, Etapa = 536
, Prestamo_Convenio = 537
, Priority = 538
, Text_Language = 539
, Plan_Version = 540
, Prestamo_Sub_Componente = 541
, Usuario_Oficina_Perfil = 542
, Sub_Proceso = 543
, Evaluacion_Aspecto = 544
, Proyecto_Etapa_Realizado = 545
, Proyecto_Localizacion = 546
, Evaluacion_Tipo = 547
, Numeration = 548
, Evaluacion_Aspecto_Evaluacion_Resultado = 549
, Proyecto_Fin = 550
, Caracter_Economico_Tipo = 551
, Parameter_Category = 552
, Parameter = 553
, Sistema_Accion = 554
, Caracter_Economico = 555
, Evaluacion_Tipo_Evaluacion_Aspecto = 556
, Plan_Periodo_Version_Activa = 557
, Proyecto_Fase_Proyecto_Etapa = 558
, Proyecto_Proposito = 559
, Message = 560
, Text_Category = 561
, Medio_Verificacion = 562
, Proyecto_Evaluacion = 563
, Clasificacion_Gasto = 564
, Permiso = 565
, Prestamo_Finalidad_Funcion = 566
, Indicador_Detalle = 567
, Proyecto_Indicador_Economico = 568
, Persona = 569
, Proceso = 570
, Clasificacion_Geografica_Tipo = 571
, Sistema_Entidad = 572
, Usuario = 573
, Fuente_Financiamiento = 574
, Audit_Session = 575
, Modalidad_Contratacion = 576
, Proyecto_Indicador_Priorizacion = 577
, Unidad_Medida = 578
, Audit_Operation = 579
, Comentario_Tecnico = 580
, Indicador_Clase = 581
, Indicador_Sector = 582
, Organismo = 589
, Proyecto_Oficina_Perfil_Funcionario = 591
, Proyecto_Etapa_Estimado_Periodo = 592
, File_Info = 593
, Proyecto_Etapa_Realizado_Periodo = 594
, Proyecto_File = 595
, Oficina_Saf = 596
, Transferencia = 597
, Transferencia_Detalle = 598
, Oficina_Saf_Programa = 599
, Clasificacion_Gasto_Rubro = 600
, Indicador_Evolucion_Instancia = 601
, Estado_Tipo = 602
, Georeferenciacion = 603
, Georeferenciacion_Punto = 604
, Proyecto_Georeferenciacion = 605
, Proyecto_Calidad_Localizacion = 606
, Prestamo_File = 607
, Prestamo_Dictamen_File = 608
, Anio = 609
, Georeferenciacion_Tipo = 610
, Proyecto_Seguimiento_File = 611
, Configuration_Category = 612
, Configuration = 613
, Usuario_Perfil = 614
, Certificado = 619
, Proyecto_Cronograma_Compose = 620
//, Proyecto_Etapa_Realizado_Periodo = 621
, Proyecto_Etapa_Informacion_Presupuestaria = 622
, Proyecto_Etapa_Informacion_Presupuestaria_Periodo = 623
 }
 public class SistemaEntidadConfig
 {
public const string OBJETIVO_SUPUESTO = "ObjetivoSupuesto";
public const string PROYECTO = "Proyecto";
public const string PROYECTO_BENEFICIARIO_INDICADOR = "ProyectoBeneficiarioIndicador";
public const string EVALUACION_RESULTADO = "EvaluacionResultado";
public const string AUDIT_OPERATION_DETAIL = "AuditOperationDetail";
public const string PRESTAMO_FINANCIAMIENTO = "PrestamoFinanciamiento";
public const string INDICADOR_OBJETIVO = "IndicadorObjetivo";
public const string PRESTAMO_OFICINA_PERFIL = "PrestamoOficinaPerfil";
public const string PROYECTO_SEGUIMIENTO = "ProyectoSeguimiento";
public const string INDICADOR_ECONOMICO = "IndicadorEconomico";
public const string SISTEMA_ENTIDAD_ESTADO = "SistemaEntidadEstado";
public const string PROYECTO_SEGUIMIENTO_LOCALIZACION = "ProyectoSeguimientoLocalizacion";
public const string PROGRAMA = "Programa";
public const string INDICADOR_TIPO = "IndicadorTipo";
public const string ESTADO = "Estado";
public const string INDICADOR = "Indicador";
public const string SISTEMA_ENTIDAD_ACCION = "SistemaEntidadAccion";
public const string PROYECTO_CALIFICACION = "ProyectoCalificacion";
public const string PROYECTO_SEGUIMIENTO_ESTADO = "ProyectoSeguimientoEstado";
public const string INDICADOR_EVOLUCION = "IndicadorEvolucion";
public const string OBJETIVO_INDICADOR = "ObjetivoIndicador";
public const string INDICADOR_RELACION_RUBRO = "IndicadorRelacionRubro";
public const string PROYECTO_ETAPA = "ProyectoEtapa";
public const string PROYECTO_OFICINA_PERFIL = "ProyectoOficinaPerfil";
public const string JURISDICCION = "Jurisdiccion";
public const string PROYECTO_PRODUCTO = "ProyectoProducto";
public const string PROYECTO_SEGUIMIENTO_PROYECTO = "ProyectoSeguimientoProyecto";
public const string PERFIL_TIPO = "PerfilTipo";
public const string MONEDA_COTIZACION = "MonedaCotizacion";
public const string INDICADOR_MEDIO_VERIFICACION = "IndicadorMedioVerificacion";
public const string ACTIVIDAD_PERMISO = "ActividadPermiso";
public const string PROYECTO_DICTAMEN_SEGUIMIENTO = "ProyectoDictamenSeguimiento";
public const string SECTOR = "Sector";
public const string PROYECTO_COMENTARIO_TECNICO = "ProyectoComentarioTecnico";
public const string ADMINISTRACION_TIPO = "AdministracionTipo";
public const string PRESTAMO_SUB_CONVENIO = "PrestamoSubConvenio";
public const string PROYECTO_PRODUCTO_PROYECTO_ETAPA = "ProyectoProductoProyectoEtapa";
public const string ACTIVIDAD = "Actividad";
public const string ENTIDAD_TIPO = "EntidadTipo";
public const string OPTION_MENU = "OptionMenu";
public const string CARGO = "Cargo";
public const string CLASIFICACION = "Clasificacion";
public const string SUB_JURISDICCION = "SubJurisdiccion";
public const string LANGUAGE = "Language";
public const string PROYECTO_BENEFICIO_INDICADOR = "ProyectoBeneficioIndicador";
public const string PROYECTO_ORIGEN_FINANCIAMIENTO = "ProyectoOrigenFinanciamiento";
public const string PERFIL_ACTIVIDAD = "PerfilActividad";
public const string PLAN_PERIODO = "PlanPeriodo";
public const string ORGANISMO_TIPO = "OrganismoTipo";
public const string PRESTAMO_OFICINA_FUNCIONARIO = "PrestamoOficinaFuncionario";
public const string INDICADOR_RUBRO = "IndicadorRubro";
public const string PROYECTO_ORIGEN_FINANCIAMIENTO_TIPO = "ProyectoOrigenFinanciamientoTipo";
public const string PRESTAMO_ESTADO = "PrestamoEstado";
public const string PRESTAMO_PRODUCTO = "PrestamoProducto";
public const string PROCESO_TIPO = "ProcesoTipo";
public const string PROYECTO_DEMORA = "ProyectoDemora";
public const string ORGANISMO_PRIORIDAD = "OrganismoPrioridad";
public const string CLASIFICACION_GEOGRAFICA = "ClasificacionGeografica";
public const string PERFIL = "Perfil";
public const string PROYECTO_CALIDAD = "ProyectoCalidad";
public const string ORGANISMO_FINANCIERO = "OrganismoFinanciero";
public const string PRESTAMO_DICTAMEN_ESTADO = "PrestamoDictamenEstado";
public const string PROYECTO_PRIORIDAD = "ProyectoPrioridad";
public const string PROYECTO_TIPO = "ProyectoTipo";
public const string PRESTAMO_ALCANCE_GEOGRAFICO = "PrestamoAlcanceGeografico";
public const string PRESTAMO_OBJETIVO_ESPECIFICO = "PrestamoObjetivoEspecifico";
public const string GESTION_TIPO = "GestionTipo";
public const string MODALIDAD_FINANCIERA = "ModalidadFinanciera";
public const string PRIORIDAD = "Prioridad";
public const string PROYECTO_PLAN = "ProyectoPlan";
public const string PRESTAMO_CALIFICACION = "PrestamoCalificacion";
public const string PROGRAMA_OBJETIVO = "ProgramaObjetivo";
public const string PRESTAMO_OBJETIVO = "PrestamoObjetivo";
public const string SUB_PROGRAMA = "SubPrograma";
public const string PRESTAMO_MODALIDAD_FINANCIERA = "PrestamoModalidadFinanciera";
public const string PROYECTO_DICTAMEN = "ProyectoDictamen";
public const string FINALIDAD_FUNCION_TIPO = "FinalidadFuncionTipo";
public const string SUB_CONVENIO_TIPO = "SubConvenioTipo";
public const string OFICINA = "Oficina";
public const string FINALIDAD_FUNCION = "FinalidadFuncion";
public const string PRESTAMO = "Prestamo";
public const string PRESTAMO_DICTAMEN = "PrestamoDictamen";
public const string OBJETIVO = "Objetivo";
public const string FUENTE_FINANCIAMIENTO_TIPO = "FuenteFinanciamientoTipo";
public const string SAF = "Saf";
public const string MESSAGE_MEDIA = "MessageMedia";
public const string PROYECTO_RELACION_TIPO = "ProyectoRelacionTipo";
public const string CLASIFICACION_GASTO_TIPO = "ClasificacionGastoTipo";
public const string PROYECTO_ETAPA_INDICADOR = "ProyectoEtapaIndicador";
public const string PROYECTO_RELACION = "ProyectoRelacion";
public const string MONEDA = "Moneda";
public const string INDICADOR_PRIORIZACION = "IndicadorPriorizacion";
public const string MESSAGE_ATTACH = "MessageAttach";
public const string FASE = "Fase";
public const string PROYECTO_ETAPA_ESTIMADO = "ProyectoEtapaEstimado";
public const string TEXT = "Text";
public const string MESSAGE_SEND = "MessageSend";
public const string PLAN_TIPO = "PlanTipo";
public const string PROYECTO_ALCANCE_GEOGRAFICO = "ProyectoAlcanceGeografico";
public const string PRESTAMO_COMPONENTE = "PrestamoComponente";
public const string ETAPA = "Etapa";
public const string PRESTAMO_CONVENIO = "PrestamoConvenio";
public const string PRIORITY = "Priority";
public const string TEXT_LANGUAGE = "TextLanguage";
public const string PLAN_VERSION = "PlanVersion";
public const string PRESTAMO_SUB_COMPONENTE = "PrestamoSubComponente";
public const string USUARIO_OFICINA_PERFIL = "UsuarioOficinaPerfil";
public const string SUB_PROCESO = "SubProceso";
public const string EVALUACION_ASPECTO = "EvaluacionAspecto";
public const string PROYECTO_ETAPA_REALIZADO = "ProyectoEtapaRealizado";
public const string PROYECTO_LOCALIZACION = "ProyectoLocalizacion";
public const string EVALUACION_TIPO = "EvaluacionTipo";
public const string NUMERATION = "Numeration";
public const string EVALUACION_ASPECTO_EVALUACION_RESULTADO = "EvaluacionAspectoEvaluacionResultado";
public const string PROYECTO_FIN = "ProyectoFin";
public const string CARACTER_ECONOMICO_TIPO = "CaracterEconomicoTipo";
public const string PARAMETER_CATEGORY = "ParameterCategory";
public const string PARAMETER = "Parameter";
public const string SISTEMA_ACCION = "SistemaAccion";
public const string CARACTER_ECONOMICO = "CaracterEconomico";
public const string EVALUACION_TIPO_EVALUACION_ASPECTO = "EvaluacionTipoEvaluacionAspecto";
public const string PLAN_PERIODO_VERSION_ACTIVA = "PlanPeriodoVersionActiva";
public const string PROYECTO_FASE_PROYECTO_ETAPA = "ProyectoFaseProyectoEtapa";
public const string PROYECTO_PROPOSITO = "ProyectoProposito";
public const string MESSAGE = "Message";
public const string TEXT_CATEGORY = "TextCategory";
public const string MEDIO_VERIFICACION = "MedioVerificacion";
public const string PROYECTO_EVALUACION = "ProyectoEvaluacion";
public const string CLASIFICACION_GASTO = "ClasificacionGasto";
public const string PERMISO = "Permiso";
public const string PRESTAMO_FINALIDAD_FUNCION = "PrestamoFinalidadFuncion";
public const string INDICADOR_DETALLE = "IndicadorDetalle";
public const string PROYECTO_INDICADOR_ECONOMICO = "ProyectoIndicadorEconomico";
public const string PERSONA = "Persona";
public const string PROCESO = "Proceso";
public const string CLASIFICACION_GEOGRAFICA_TIPO = "ClasificacionGeograficaTipo";
public const string SISTEMA_ENTIDAD = "SistemaEntidad";
public const string USUARIO = "Usuario";
public const string FUENTE_FINANCIAMIENTO = "FuenteFinanciamiento";
public const string AUDIT_SESSION = "AuditSession";
public const string MODALIDAD_CONTRATACION = "ModalidadContratacion";
public const string PROYECTO_INDICADOR_PRIORIZACION = "ProyectoIndicadorPriorizacion";
public const string UNIDAD_MEDIDA = "UnidadMedida";
public const string AUDIT_OPERATION = "AuditOperation";
public const string COMENTARIO_TECNICO = "ComentarioTecnico";
public const string INDICADOR_CLASE = "IndicadorClase";
public const string INDICADOR_SECTOR = "IndicadorSector";
public const string ORGANISMO = "Organismo";
public const string PROYECTO_OFICINA_PERFIL_FUNCIONARIO = "ProyectoOficinaPerfilFuncionario";
public const string PROYECTO_ETAPA_ESTIMADO_PERIODO = "ProyectoEtapaEstimadoPeriodo";
public const string FILE_INFO = "FileInfo";
public const string PROYECTO_ETAPA_REALIZADO_PERIODO = "ProyectoEtapaRealizadoPeriodo";
public const string PROYECTO_FILE = "ProyectoFile";
public const string OFICINA_SAF = "OficinaSaf";
public const string TRANSFERENCIA = "Transferencia";
public const string TRANSFERENCIA_DETALLE = "TransferenciaDetalle";
public const string OFICINA_SAF_PROGRAMA = "OficinaSafPrograma";
public const string CLASIFICACION_GASTO_RUBRO = "ClasificacionGastoRubro";
public const string INDICADOR_EVOLUCION_INSTANCIA = "IndicadorEvolucionInstancia";
public const string ESTADO_TIPO = "EstadoTipo";
public const string GEOREFERENCIACION = "Georeferenciacion";
public const string GEOREFERENCIACION_PUNTO = "GeoreferenciacionPunto";
public const string PROYECTO_GEOREFERENCIACION = "ProyectoGeoreferenciacion";
public const string PROYECTO_CALIDAD_LOCALIZACION = "ProyectoCalidadLocalizacion";
public const string PRESTAMO_FILE = "PrestamoFile";
public const string PRESTAMO_DICTAMEN_FILE = "PrestamoDictamenFile";
public const string ANIO = "Anio";
public const string GEOREFERENCIACION_TIPO = "GeoreferenciacionTipo";
public const string PROYECTO_SEGUIMIENTO_FILE = "ProyectoSeguimientoFile";
public const string CONFIGURATION_CATEGORY = "ConfigurationCategory";
public const string CONFIGURATION = "Configuration";
public const string USUARIO_PERFIL = "UsuarioPerfil";
public const string CERTIFICADO = "Certificado";
public const string PROYECTO_CRONOGRAMA_COMPOSE = "ProyectoCronogramaCompose";
//public const string PROYECTO_ETAPA_REALIZADO_PERIODO = "ProyectoEtapaRealizadoPeriodo";
public const string PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA = "ProyectoEtapaInformacionPresupuestaria";
public const string PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA_PERIODO = "ProyectoEtapaInformacionPresupuestariaPeriodo";

 public static string GetConst(SistemaEntidadEnum key)
        {
            switch (key)
            {
case SistemaEntidadEnum.Objetivo_Supuesto: return OBJETIVO_SUPUESTO;
case SistemaEntidadEnum.Proyecto: return PROYECTO;
case SistemaEntidadEnum.Proyecto_Beneficiario_Indicador: return PROYECTO_BENEFICIARIO_INDICADOR;
case SistemaEntidadEnum.Evaluacion_Resultado: return EVALUACION_RESULTADO;
case SistemaEntidadEnum.Audit_Operation_Detail: return AUDIT_OPERATION_DETAIL;
case SistemaEntidadEnum.Prestamo_Financiamiento: return PRESTAMO_FINANCIAMIENTO;
case SistemaEntidadEnum.Indicador_Objetivo: return INDICADOR_OBJETIVO;
case SistemaEntidadEnum.Prestamo_Oficina_Perfil: return PRESTAMO_OFICINA_PERFIL;
case SistemaEntidadEnum.Proyecto_Seguimiento: return PROYECTO_SEGUIMIENTO;
case SistemaEntidadEnum.Indicador_Economico: return INDICADOR_ECONOMICO;
case SistemaEntidadEnum.Sistema_Entidad_Estado: return SISTEMA_ENTIDAD_ESTADO;
case SistemaEntidadEnum.Proyecto_Seguimiento_Localizacion: return PROYECTO_SEGUIMIENTO_LOCALIZACION;
case SistemaEntidadEnum.Programa: return PROGRAMA;
case SistemaEntidadEnum.Indicador_Tipo: return INDICADOR_TIPO;
case SistemaEntidadEnum.Estado: return ESTADO;
case SistemaEntidadEnum.Indicador: return INDICADOR;
case SistemaEntidadEnum.Sistema_Entidad_Accion: return SISTEMA_ENTIDAD_ACCION;
case SistemaEntidadEnum.Proyecto_Calificacion: return PROYECTO_CALIFICACION;
case SistemaEntidadEnum.Proyecto_Seguimiento_Estado: return PROYECTO_SEGUIMIENTO_ESTADO;
case SistemaEntidadEnum.Indicador_Evolucion: return INDICADOR_EVOLUCION;
case SistemaEntidadEnum.Objetivo_Indicador: return OBJETIVO_INDICADOR;
case SistemaEntidadEnum.Indicador_Relacion_Rubro: return INDICADOR_RELACION_RUBRO;
case SistemaEntidadEnum.Proyecto_Etapa: return PROYECTO_ETAPA;
case SistemaEntidadEnum.Proyecto_Oficina_Perfil: return PROYECTO_OFICINA_PERFIL;
case SistemaEntidadEnum.Jurisdiccion: return JURISDICCION;
case SistemaEntidadEnum.Proyecto_Producto: return PROYECTO_PRODUCTO;
case SistemaEntidadEnum.Proyecto_Seguimiento_Proyecto: return PROYECTO_SEGUIMIENTO_PROYECTO;
case SistemaEntidadEnum.Perfil_Tipo: return PERFIL_TIPO;
case SistemaEntidadEnum.Moneda_Cotizacion: return MONEDA_COTIZACION;
case SistemaEntidadEnum.Indicador_Medio_Verificacion: return INDICADOR_MEDIO_VERIFICACION;
case SistemaEntidadEnum.Actividad_Permiso: return ACTIVIDAD_PERMISO;
case SistemaEntidadEnum.Proyecto_Dictamen_Seguimiento: return PROYECTO_DICTAMEN_SEGUIMIENTO;
case SistemaEntidadEnum.Sector: return SECTOR;
case SistemaEntidadEnum.Proyecto_Comentario_Tecnico: return PROYECTO_COMENTARIO_TECNICO;
case SistemaEntidadEnum.Administracion_Tipo: return ADMINISTRACION_TIPO;
case SistemaEntidadEnum.Prestamo_Sub_Convenio: return PRESTAMO_SUB_CONVENIO;
case SistemaEntidadEnum.Proyecto_Producto_Proyecto_Etapa: return PROYECTO_PRODUCTO_PROYECTO_ETAPA;
case SistemaEntidadEnum.Actividad: return ACTIVIDAD;
case SistemaEntidadEnum.Entidad_Tipo: return ENTIDAD_TIPO;
case SistemaEntidadEnum.Option_Menu: return OPTION_MENU;
case SistemaEntidadEnum.Cargo: return CARGO;
case SistemaEntidadEnum.Clasificacion: return CLASIFICACION;
case SistemaEntidadEnum.Sub_Jurisdiccion: return SUB_JURISDICCION;
case SistemaEntidadEnum.Language: return LANGUAGE;
case SistemaEntidadEnum.Proyecto_Beneficio_Indicador: return PROYECTO_BENEFICIO_INDICADOR;
case SistemaEntidadEnum.Proyecto_Origen_Financiamiento: return PROYECTO_ORIGEN_FINANCIAMIENTO;
case SistemaEntidadEnum.Perfil_Actividad: return PERFIL_ACTIVIDAD;
case SistemaEntidadEnum.Plan_Periodo: return PLAN_PERIODO;
case SistemaEntidadEnum.Organismo_Tipo: return ORGANISMO_TIPO;
case SistemaEntidadEnum.Prestamo_Oficina_Funcionario: return PRESTAMO_OFICINA_FUNCIONARIO;
case SistemaEntidadEnum.Indicador_Rubro: return INDICADOR_RUBRO;
case SistemaEntidadEnum.Proyecto_Origen_Financiamiento_Tipo: return PROYECTO_ORIGEN_FINANCIAMIENTO_TIPO;
case SistemaEntidadEnum.Prestamo_Estado: return PRESTAMO_ESTADO;
case SistemaEntidadEnum.Prestamo_Producto: return PRESTAMO_PRODUCTO;
case SistemaEntidadEnum.Proceso_Tipo: return PROCESO_TIPO;
case SistemaEntidadEnum.Proyecto_Demora: return PROYECTO_DEMORA;
case SistemaEntidadEnum.Organismo_Prioridad: return ORGANISMO_PRIORIDAD;
case SistemaEntidadEnum.Clasificacion_Geografica: return CLASIFICACION_GEOGRAFICA;
case SistemaEntidadEnum.Perfil: return PERFIL;
case SistemaEntidadEnum.Proyecto_Calidad: return PROYECTO_CALIDAD;
case SistemaEntidadEnum.Organismo_Financiero: return ORGANISMO_FINANCIERO;
case SistemaEntidadEnum.Prestamo_Dictamen_Estado: return PRESTAMO_DICTAMEN_ESTADO;
case SistemaEntidadEnum.Proyecto_Prioridad: return PROYECTO_PRIORIDAD;
case SistemaEntidadEnum.Proyecto_Tipo: return PROYECTO_TIPO;
case SistemaEntidadEnum.Prestamo_Alcance_Geografico: return PRESTAMO_ALCANCE_GEOGRAFICO;
case SistemaEntidadEnum.Prestamo_Objetivo_Especifico: return PRESTAMO_OBJETIVO_ESPECIFICO;
case SistemaEntidadEnum.Gestion_Tipo: return GESTION_TIPO;
case SistemaEntidadEnum.Modalidad_Financiera: return MODALIDAD_FINANCIERA;
case SistemaEntidadEnum.Prioridad: return PRIORIDAD;
case SistemaEntidadEnum.Proyecto_Plan: return PROYECTO_PLAN;
case SistemaEntidadEnum.Prestamo_Calificacion: return PRESTAMO_CALIFICACION;
case SistemaEntidadEnum.Programa_Objetivo: return PROGRAMA_OBJETIVO;
case SistemaEntidadEnum.Prestamo_Objetivo: return PRESTAMO_OBJETIVO;
case SistemaEntidadEnum.Sub_Programa: return SUB_PROGRAMA;
case SistemaEntidadEnum.Prestamo_Modalidad_Financiera: return PRESTAMO_MODALIDAD_FINANCIERA;
case SistemaEntidadEnum.Proyecto_Dictamen: return PROYECTO_DICTAMEN;
case SistemaEntidadEnum.Finalidad_Funcion_Tipo: return FINALIDAD_FUNCION_TIPO;
case SistemaEntidadEnum.Sub_Convenio_Tipo: return SUB_CONVENIO_TIPO;
case SistemaEntidadEnum.Oficina: return OFICINA;
case SistemaEntidadEnum.Finalidad_Funcion: return FINALIDAD_FUNCION;
case SistemaEntidadEnum.Prestamo: return PRESTAMO;
case SistemaEntidadEnum.Prestamo_Dictamen: return PRESTAMO_DICTAMEN;
case SistemaEntidadEnum.Objetivo: return OBJETIVO;
case SistemaEntidadEnum.Fuente_Financiamiento_Tipo: return FUENTE_FINANCIAMIENTO_TIPO;
case SistemaEntidadEnum.Saf: return SAF;
case SistemaEntidadEnum.Message_Media: return MESSAGE_MEDIA;
case SistemaEntidadEnum.Proyecto_Relacion_Tipo: return PROYECTO_RELACION_TIPO;
case SistemaEntidadEnum.Clasificacion_Gasto_Tipo: return CLASIFICACION_GASTO_TIPO;
case SistemaEntidadEnum.Proyecto_Etapa_Indicador: return PROYECTO_ETAPA_INDICADOR;
case SistemaEntidadEnum.Proyecto_Relacion: return PROYECTO_RELACION;
case SistemaEntidadEnum.Moneda: return MONEDA;
case SistemaEntidadEnum.Indicador_Priorizacion: return INDICADOR_PRIORIZACION;
case SistemaEntidadEnum.Message_Attach: return MESSAGE_ATTACH;
case SistemaEntidadEnum.Fase: return FASE;
case SistemaEntidadEnum.Proyecto_Etapa_Estimado: return PROYECTO_ETAPA_ESTIMADO;
case SistemaEntidadEnum.Text: return TEXT;
case SistemaEntidadEnum.Message_Send: return MESSAGE_SEND;
case SistemaEntidadEnum.Plan_Tipo: return PLAN_TIPO;
case SistemaEntidadEnum.Proyecto_Alcance_Geografico: return PROYECTO_ALCANCE_GEOGRAFICO;
case SistemaEntidadEnum.Prestamo_Componente: return PRESTAMO_COMPONENTE;
case SistemaEntidadEnum.Etapa: return ETAPA;
case SistemaEntidadEnum.Prestamo_Convenio: return PRESTAMO_CONVENIO;
case SistemaEntidadEnum.Priority: return PRIORITY;
case SistemaEntidadEnum.Text_Language: return TEXT_LANGUAGE;
case SistemaEntidadEnum.Plan_Version: return PLAN_VERSION;
case SistemaEntidadEnum.Prestamo_Sub_Componente: return PRESTAMO_SUB_COMPONENTE;
case SistemaEntidadEnum.Usuario_Oficina_Perfil: return USUARIO_OFICINA_PERFIL;
case SistemaEntidadEnum.Sub_Proceso: return SUB_PROCESO;
case SistemaEntidadEnum.Evaluacion_Aspecto: return EVALUACION_ASPECTO;
case SistemaEntidadEnum.Proyecto_Etapa_Realizado: return PROYECTO_ETAPA_REALIZADO;
case SistemaEntidadEnum.Proyecto_Localizacion: return PROYECTO_LOCALIZACION;
case SistemaEntidadEnum.Evaluacion_Tipo: return EVALUACION_TIPO;
case SistemaEntidadEnum.Numeration: return NUMERATION;
case SistemaEntidadEnum.Evaluacion_Aspecto_Evaluacion_Resultado: return EVALUACION_ASPECTO_EVALUACION_RESULTADO;
case SistemaEntidadEnum.Proyecto_Fin: return PROYECTO_FIN;
case SistemaEntidadEnum.Caracter_Economico_Tipo: return CARACTER_ECONOMICO_TIPO;
case SistemaEntidadEnum.Parameter_Category: return PARAMETER_CATEGORY;
case SistemaEntidadEnum.Parameter: return PARAMETER;
case SistemaEntidadEnum.Sistema_Accion: return SISTEMA_ACCION;
case SistemaEntidadEnum.Caracter_Economico: return CARACTER_ECONOMICO;
case SistemaEntidadEnum.Evaluacion_Tipo_Evaluacion_Aspecto: return EVALUACION_TIPO_EVALUACION_ASPECTO;
case SistemaEntidadEnum.Plan_Periodo_Version_Activa: return PLAN_PERIODO_VERSION_ACTIVA;
case SistemaEntidadEnum.Proyecto_Fase_Proyecto_Etapa: return PROYECTO_FASE_PROYECTO_ETAPA;
case SistemaEntidadEnum.Proyecto_Proposito: return PROYECTO_PROPOSITO;
case SistemaEntidadEnum.Message: return MESSAGE;
case SistemaEntidadEnum.Text_Category: return TEXT_CATEGORY;
case SistemaEntidadEnum.Medio_Verificacion: return MEDIO_VERIFICACION;
case SistemaEntidadEnum.Proyecto_Evaluacion: return PROYECTO_EVALUACION;
case SistemaEntidadEnum.Clasificacion_Gasto: return CLASIFICACION_GASTO;
case SistemaEntidadEnum.Permiso: return PERMISO;
case SistemaEntidadEnum.Prestamo_Finalidad_Funcion: return PRESTAMO_FINALIDAD_FUNCION;
case SistemaEntidadEnum.Indicador_Detalle: return INDICADOR_DETALLE;
case SistemaEntidadEnum.Proyecto_Indicador_Economico: return PROYECTO_INDICADOR_ECONOMICO;
case SistemaEntidadEnum.Persona: return PERSONA;
case SistemaEntidadEnum.Proceso: return PROCESO;
case SistemaEntidadEnum.Clasificacion_Geografica_Tipo: return CLASIFICACION_GEOGRAFICA_TIPO;
case SistemaEntidadEnum.Sistema_Entidad: return SISTEMA_ENTIDAD;
case SistemaEntidadEnum.Usuario: return USUARIO;
case SistemaEntidadEnum.Fuente_Financiamiento: return FUENTE_FINANCIAMIENTO;
case SistemaEntidadEnum.Audit_Session: return AUDIT_SESSION;
case SistemaEntidadEnum.Modalidad_Contratacion: return MODALIDAD_CONTRATACION;
case SistemaEntidadEnum.Proyecto_Indicador_Priorizacion: return PROYECTO_INDICADOR_PRIORIZACION;
case SistemaEntidadEnum.Unidad_Medida: return UNIDAD_MEDIDA;
case SistemaEntidadEnum.Audit_Operation: return AUDIT_OPERATION;
case SistemaEntidadEnum.Comentario_Tecnico: return COMENTARIO_TECNICO;
case SistemaEntidadEnum.Indicador_Clase: return INDICADOR_CLASE;
case SistemaEntidadEnum.Indicador_Sector: return INDICADOR_SECTOR;
case SistemaEntidadEnum.Organismo: return ORGANISMO;
case SistemaEntidadEnum.Proyecto_Oficina_Perfil_Funcionario: return PROYECTO_OFICINA_PERFIL_FUNCIONARIO;
case SistemaEntidadEnum.Proyecto_Etapa_Estimado_Periodo: return PROYECTO_ETAPA_ESTIMADO_PERIODO;
case SistemaEntidadEnum.File_Info: return FILE_INFO;
case SistemaEntidadEnum.Proyecto_Etapa_Realizado_Periodo: return PROYECTO_ETAPA_REALIZADO_PERIODO;
case SistemaEntidadEnum.Proyecto_File: return PROYECTO_FILE;
case SistemaEntidadEnum.Oficina_Saf: return OFICINA_SAF;
case SistemaEntidadEnum.Transferencia: return TRANSFERENCIA;
case SistemaEntidadEnum.Transferencia_Detalle: return TRANSFERENCIA_DETALLE;
case SistemaEntidadEnum.Oficina_Saf_Programa: return OFICINA_SAF_PROGRAMA;
case SistemaEntidadEnum.Clasificacion_Gasto_Rubro: return CLASIFICACION_GASTO_RUBRO;
case SistemaEntidadEnum.Indicador_Evolucion_Instancia: return INDICADOR_EVOLUCION_INSTANCIA;
case SistemaEntidadEnum.Estado_Tipo: return ESTADO_TIPO;
case SistemaEntidadEnum.Georeferenciacion: return GEOREFERENCIACION;
case SistemaEntidadEnum.Georeferenciacion_Punto: return GEOREFERENCIACION_PUNTO;
case SistemaEntidadEnum.Proyecto_Georeferenciacion: return PROYECTO_GEOREFERENCIACION;
case SistemaEntidadEnum.Proyecto_Calidad_Localizacion: return PROYECTO_CALIDAD_LOCALIZACION;
case SistemaEntidadEnum.Prestamo_File: return PRESTAMO_FILE;
case SistemaEntidadEnum.Prestamo_Dictamen_File: return PRESTAMO_DICTAMEN_FILE;
case SistemaEntidadEnum.Anio: return ANIO;
case SistemaEntidadEnum.Georeferenciacion_Tipo: return GEOREFERENCIACION_TIPO;
case SistemaEntidadEnum.Proyecto_Seguimiento_File: return PROYECTO_SEGUIMIENTO_FILE;
case SistemaEntidadEnum.Configuration_Category: return CONFIGURATION_CATEGORY;
case SistemaEntidadEnum.Configuration: return CONFIGURATION;
case SistemaEntidadEnum.Usuario_Perfil: return USUARIO_PERFIL;
case SistemaEntidadEnum.Certificado: return CERTIFICADO;
case SistemaEntidadEnum.Proyecto_Cronograma_Compose: return PROYECTO_CRONOGRAMA_COMPOSE;
//case SistemaEntidadEnum.Proyecto_Etapa_Realizado_Periodo: return PROYECTO_ETAPA_REALIZADO_PERIODO;
case SistemaEntidadEnum.Proyecto_Etapa_Informacion_Presupuestaria: return PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA;
case SistemaEntidadEnum.Proyecto_Etapa_Informacion_Presupuestaria_Periodo: return PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA_PERIODO;

}
            return "";
        }
        public static SistemaEntidadEnum GetEnum(string key)
        {
            switch (key)
            {
                case OBJETIVO_SUPUESTO: return SistemaEntidadEnum.Objetivo_Supuesto;
case PROYECTO: return SistemaEntidadEnum.Proyecto;
case PROYECTO_BENEFICIARIO_INDICADOR: return SistemaEntidadEnum.Proyecto_Beneficiario_Indicador;
case EVALUACION_RESULTADO: return SistemaEntidadEnum.Evaluacion_Resultado;
case AUDIT_OPERATION_DETAIL: return SistemaEntidadEnum.Audit_Operation_Detail;
case PRESTAMO_FINANCIAMIENTO: return SistemaEntidadEnum.Prestamo_Financiamiento;
case INDICADOR_OBJETIVO: return SistemaEntidadEnum.Indicador_Objetivo;
case PRESTAMO_OFICINA_PERFIL: return SistemaEntidadEnum.Prestamo_Oficina_Perfil;
case PROYECTO_SEGUIMIENTO: return SistemaEntidadEnum.Proyecto_Seguimiento;
case INDICADOR_ECONOMICO: return SistemaEntidadEnum.Indicador_Economico;
case SISTEMA_ENTIDAD_ESTADO: return SistemaEntidadEnum.Sistema_Entidad_Estado;
case PROYECTO_SEGUIMIENTO_LOCALIZACION: return SistemaEntidadEnum.Proyecto_Seguimiento_Localizacion;
case PROGRAMA: return SistemaEntidadEnum.Programa;
case INDICADOR_TIPO: return SistemaEntidadEnum.Indicador_Tipo;
case ESTADO: return SistemaEntidadEnum.Estado;
case INDICADOR: return SistemaEntidadEnum.Indicador;
case SISTEMA_ENTIDAD_ACCION: return SistemaEntidadEnum.Sistema_Entidad_Accion;
case PROYECTO_CALIFICACION: return SistemaEntidadEnum.Proyecto_Calificacion;
case PROYECTO_SEGUIMIENTO_ESTADO: return SistemaEntidadEnum.Proyecto_Seguimiento_Estado;
case INDICADOR_EVOLUCION: return SistemaEntidadEnum.Indicador_Evolucion;
case OBJETIVO_INDICADOR: return SistemaEntidadEnum.Objetivo_Indicador;
case INDICADOR_RELACION_RUBRO: return SistemaEntidadEnum.Indicador_Relacion_Rubro;
case PROYECTO_ETAPA: return SistemaEntidadEnum.Proyecto_Etapa;
case PROYECTO_OFICINA_PERFIL: return SistemaEntidadEnum.Proyecto_Oficina_Perfil;
case JURISDICCION: return SistemaEntidadEnum.Jurisdiccion;
case PROYECTO_PRODUCTO: return SistemaEntidadEnum.Proyecto_Producto;
case PROYECTO_SEGUIMIENTO_PROYECTO: return SistemaEntidadEnum.Proyecto_Seguimiento_Proyecto;
case PERFIL_TIPO: return SistemaEntidadEnum.Perfil_Tipo;
case MONEDA_COTIZACION: return SistemaEntidadEnum.Moneda_Cotizacion;
case INDICADOR_MEDIO_VERIFICACION: return SistemaEntidadEnum.Indicador_Medio_Verificacion;
case ACTIVIDAD_PERMISO: return SistemaEntidadEnum.Actividad_Permiso;
case PROYECTO_DICTAMEN_SEGUIMIENTO: return SistemaEntidadEnum.Proyecto_Dictamen_Seguimiento;
case SECTOR: return SistemaEntidadEnum.Sector;
case PROYECTO_COMENTARIO_TECNICO: return SistemaEntidadEnum.Proyecto_Comentario_Tecnico;
case ADMINISTRACION_TIPO: return SistemaEntidadEnum.Administracion_Tipo;
case PRESTAMO_SUB_CONVENIO: return SistemaEntidadEnum.Prestamo_Sub_Convenio;
case PROYECTO_PRODUCTO_PROYECTO_ETAPA: return SistemaEntidadEnum.Proyecto_Producto_Proyecto_Etapa;
case ACTIVIDAD: return SistemaEntidadEnum.Actividad;
case ENTIDAD_TIPO: return SistemaEntidadEnum.Entidad_Tipo;
case OPTION_MENU: return SistemaEntidadEnum.Option_Menu;
case CARGO: return SistemaEntidadEnum.Cargo;
case CLASIFICACION: return SistemaEntidadEnum.Clasificacion;
case SUB_JURISDICCION: return SistemaEntidadEnum.Sub_Jurisdiccion;
case LANGUAGE: return SistemaEntidadEnum.Language;
case PROYECTO_BENEFICIO_INDICADOR: return SistemaEntidadEnum.Proyecto_Beneficio_Indicador;
case PROYECTO_ORIGEN_FINANCIAMIENTO: return SistemaEntidadEnum.Proyecto_Origen_Financiamiento;
case PERFIL_ACTIVIDAD: return SistemaEntidadEnum.Perfil_Actividad;
case PLAN_PERIODO: return SistemaEntidadEnum.Plan_Periodo;
case ORGANISMO_TIPO: return SistemaEntidadEnum.Organismo_Tipo;
case PRESTAMO_OFICINA_FUNCIONARIO: return SistemaEntidadEnum.Prestamo_Oficina_Funcionario;
case INDICADOR_RUBRO: return SistemaEntidadEnum.Indicador_Rubro;
case PROYECTO_ORIGEN_FINANCIAMIENTO_TIPO: return SistemaEntidadEnum.Proyecto_Origen_Financiamiento_Tipo;
case PRESTAMO_ESTADO: return SistemaEntidadEnum.Prestamo_Estado;
case PRESTAMO_PRODUCTO: return SistemaEntidadEnum.Prestamo_Producto;
case PROCESO_TIPO: return SistemaEntidadEnum.Proceso_Tipo;
case PROYECTO_DEMORA: return SistemaEntidadEnum.Proyecto_Demora;
case ORGANISMO_PRIORIDAD: return SistemaEntidadEnum.Organismo_Prioridad;
case CLASIFICACION_GEOGRAFICA: return SistemaEntidadEnum.Clasificacion_Geografica;
case PERFIL: return SistemaEntidadEnum.Perfil;
case PROYECTO_CALIDAD: return SistemaEntidadEnum.Proyecto_Calidad;
case ORGANISMO_FINANCIERO: return SistemaEntidadEnum.Organismo_Financiero;
case PRESTAMO_DICTAMEN_ESTADO: return SistemaEntidadEnum.Prestamo_Dictamen_Estado;
case PROYECTO_PRIORIDAD: return SistemaEntidadEnum.Proyecto_Prioridad;
case PROYECTO_TIPO: return SistemaEntidadEnum.Proyecto_Tipo;
case PRESTAMO_ALCANCE_GEOGRAFICO: return SistemaEntidadEnum.Prestamo_Alcance_Geografico;
case PRESTAMO_OBJETIVO_ESPECIFICO: return SistemaEntidadEnum.Prestamo_Objetivo_Especifico;
case GESTION_TIPO: return SistemaEntidadEnum.Gestion_Tipo;
case MODALIDAD_FINANCIERA: return SistemaEntidadEnum.Modalidad_Financiera;
case PRIORIDAD: return SistemaEntidadEnum.Prioridad;
case PROYECTO_PLAN: return SistemaEntidadEnum.Proyecto_Plan;
case PRESTAMO_CALIFICACION: return SistemaEntidadEnum.Prestamo_Calificacion;
case PROGRAMA_OBJETIVO: return SistemaEntidadEnum.Programa_Objetivo;
case PRESTAMO_OBJETIVO: return SistemaEntidadEnum.Prestamo_Objetivo;
case SUB_PROGRAMA: return SistemaEntidadEnum.Sub_Programa;
case PRESTAMO_MODALIDAD_FINANCIERA: return SistemaEntidadEnum.Prestamo_Modalidad_Financiera;
case PROYECTO_DICTAMEN: return SistemaEntidadEnum.Proyecto_Dictamen;
case FINALIDAD_FUNCION_TIPO: return SistemaEntidadEnum.Finalidad_Funcion_Tipo;
case SUB_CONVENIO_TIPO: return SistemaEntidadEnum.Sub_Convenio_Tipo;
case OFICINA: return SistemaEntidadEnum.Oficina;
case FINALIDAD_FUNCION: return SistemaEntidadEnum.Finalidad_Funcion;
case PRESTAMO: return SistemaEntidadEnum.Prestamo;
case PRESTAMO_DICTAMEN: return SistemaEntidadEnum.Prestamo_Dictamen;
case OBJETIVO: return SistemaEntidadEnum.Objetivo;
case FUENTE_FINANCIAMIENTO_TIPO: return SistemaEntidadEnum.Fuente_Financiamiento_Tipo;
case SAF: return SistemaEntidadEnum.Saf;
case MESSAGE_MEDIA: return SistemaEntidadEnum.Message_Media;
case PROYECTO_RELACION_TIPO: return SistemaEntidadEnum.Proyecto_Relacion_Tipo;
case CLASIFICACION_GASTO_TIPO: return SistemaEntidadEnum.Clasificacion_Gasto_Tipo;
case PROYECTO_ETAPA_INDICADOR: return SistemaEntidadEnum.Proyecto_Etapa_Indicador;
case PROYECTO_RELACION: return SistemaEntidadEnum.Proyecto_Relacion;
case MONEDA: return SistemaEntidadEnum.Moneda;
case INDICADOR_PRIORIZACION: return SistemaEntidadEnum.Indicador_Priorizacion;
case MESSAGE_ATTACH: return SistemaEntidadEnum.Message_Attach;
case FASE: return SistemaEntidadEnum.Fase;
case PROYECTO_ETAPA_ESTIMADO: return SistemaEntidadEnum.Proyecto_Etapa_Estimado;
case TEXT: return SistemaEntidadEnum.Text;
case MESSAGE_SEND: return SistemaEntidadEnum.Message_Send;
case PLAN_TIPO: return SistemaEntidadEnum.Plan_Tipo;
case PROYECTO_ALCANCE_GEOGRAFICO: return SistemaEntidadEnum.Proyecto_Alcance_Geografico;
case PRESTAMO_COMPONENTE: return SistemaEntidadEnum.Prestamo_Componente;
case ETAPA: return SistemaEntidadEnum.Etapa;
case PRESTAMO_CONVENIO: return SistemaEntidadEnum.Prestamo_Convenio;
case PRIORITY: return SistemaEntidadEnum.Priority;
case TEXT_LANGUAGE: return SistemaEntidadEnum.Text_Language;
case PLAN_VERSION: return SistemaEntidadEnum.Plan_Version;
case PRESTAMO_SUB_COMPONENTE: return SistemaEntidadEnum.Prestamo_Sub_Componente;
case USUARIO_OFICINA_PERFIL: return SistemaEntidadEnum.Usuario_Oficina_Perfil;
case SUB_PROCESO: return SistemaEntidadEnum.Sub_Proceso;
case EVALUACION_ASPECTO: return SistemaEntidadEnum.Evaluacion_Aspecto;
case PROYECTO_ETAPA_REALIZADO: return SistemaEntidadEnum.Proyecto_Etapa_Realizado;
case PROYECTO_LOCALIZACION: return SistemaEntidadEnum.Proyecto_Localizacion;
case EVALUACION_TIPO: return SistemaEntidadEnum.Evaluacion_Tipo;
case NUMERATION: return SistemaEntidadEnum.Numeration;
case EVALUACION_ASPECTO_EVALUACION_RESULTADO: return SistemaEntidadEnum.Evaluacion_Aspecto_Evaluacion_Resultado;
case PROYECTO_FIN: return SistemaEntidadEnum.Proyecto_Fin;
case CARACTER_ECONOMICO_TIPO: return SistemaEntidadEnum.Caracter_Economico_Tipo;
case PARAMETER_CATEGORY: return SistemaEntidadEnum.Parameter_Category;
case PARAMETER: return SistemaEntidadEnum.Parameter;
case SISTEMA_ACCION: return SistemaEntidadEnum.Sistema_Accion;
case CARACTER_ECONOMICO: return SistemaEntidadEnum.Caracter_Economico;
case EVALUACION_TIPO_EVALUACION_ASPECTO: return SistemaEntidadEnum.Evaluacion_Tipo_Evaluacion_Aspecto;
case PLAN_PERIODO_VERSION_ACTIVA: return SistemaEntidadEnum.Plan_Periodo_Version_Activa;
case PROYECTO_FASE_PROYECTO_ETAPA: return SistemaEntidadEnum.Proyecto_Fase_Proyecto_Etapa;
case PROYECTO_PROPOSITO: return SistemaEntidadEnum.Proyecto_Proposito;
case MESSAGE: return SistemaEntidadEnum.Message;
case TEXT_CATEGORY: return SistemaEntidadEnum.Text_Category;
case MEDIO_VERIFICACION: return SistemaEntidadEnum.Medio_Verificacion;
case PROYECTO_EVALUACION: return SistemaEntidadEnum.Proyecto_Evaluacion;
case CLASIFICACION_GASTO: return SistemaEntidadEnum.Clasificacion_Gasto;
case PERMISO: return SistemaEntidadEnum.Permiso;
case PRESTAMO_FINALIDAD_FUNCION: return SistemaEntidadEnum.Prestamo_Finalidad_Funcion;
case INDICADOR_DETALLE: return SistemaEntidadEnum.Indicador_Detalle;
case PROYECTO_INDICADOR_ECONOMICO: return SistemaEntidadEnum.Proyecto_Indicador_Economico;
case PERSONA: return SistemaEntidadEnum.Persona;
case PROCESO: return SistemaEntidadEnum.Proceso;
case CLASIFICACION_GEOGRAFICA_TIPO: return SistemaEntidadEnum.Clasificacion_Geografica_Tipo;
case SISTEMA_ENTIDAD: return SistemaEntidadEnum.Sistema_Entidad;
case USUARIO: return SistemaEntidadEnum.Usuario;
case FUENTE_FINANCIAMIENTO: return SistemaEntidadEnum.Fuente_Financiamiento;
case AUDIT_SESSION: return SistemaEntidadEnum.Audit_Session;
case MODALIDAD_CONTRATACION: return SistemaEntidadEnum.Modalidad_Contratacion;
case PROYECTO_INDICADOR_PRIORIZACION: return SistemaEntidadEnum.Proyecto_Indicador_Priorizacion;
case UNIDAD_MEDIDA: return SistemaEntidadEnum.Unidad_Medida;
case AUDIT_OPERATION: return SistemaEntidadEnum.Audit_Operation;
case COMENTARIO_TECNICO: return SistemaEntidadEnum.Comentario_Tecnico;
case INDICADOR_CLASE: return SistemaEntidadEnum.Indicador_Clase;
case INDICADOR_SECTOR: return SistemaEntidadEnum.Indicador_Sector;
case ORGANISMO: return SistemaEntidadEnum.Organismo;
case PROYECTO_OFICINA_PERFIL_FUNCIONARIO: return SistemaEntidadEnum.Proyecto_Oficina_Perfil_Funcionario;
case PROYECTO_ETAPA_ESTIMADO_PERIODO: return SistemaEntidadEnum.Proyecto_Etapa_Estimado_Periodo;
case FILE_INFO: return SistemaEntidadEnum.File_Info;
case PROYECTO_ETAPA_REALIZADO_PERIODO: return SistemaEntidadEnum.Proyecto_Etapa_Realizado_Periodo;
case PROYECTO_FILE: return SistemaEntidadEnum.Proyecto_File;
case OFICINA_SAF: return SistemaEntidadEnum.Oficina_Saf;
case TRANSFERENCIA: return SistemaEntidadEnum.Transferencia;
case TRANSFERENCIA_DETALLE: return SistemaEntidadEnum.Transferencia_Detalle;
case OFICINA_SAF_PROGRAMA: return SistemaEntidadEnum.Oficina_Saf_Programa;
case CLASIFICACION_GASTO_RUBRO: return SistemaEntidadEnum.Clasificacion_Gasto_Rubro;
case INDICADOR_EVOLUCION_INSTANCIA: return SistemaEntidadEnum.Indicador_Evolucion_Instancia;
case ESTADO_TIPO: return SistemaEntidadEnum.Estado_Tipo;
case GEOREFERENCIACION: return SistemaEntidadEnum.Georeferenciacion;
case GEOREFERENCIACION_PUNTO: return SistemaEntidadEnum.Georeferenciacion_Punto;
case PROYECTO_GEOREFERENCIACION: return SistemaEntidadEnum.Proyecto_Georeferenciacion;
case PROYECTO_CALIDAD_LOCALIZACION: return SistemaEntidadEnum.Proyecto_Calidad_Localizacion;
case PRESTAMO_FILE: return SistemaEntidadEnum.Prestamo_File;
case PRESTAMO_DICTAMEN_FILE: return SistemaEntidadEnum.Prestamo_Dictamen_File;
case ANIO: return SistemaEntidadEnum.Anio;
case GEOREFERENCIACION_TIPO: return SistemaEntidadEnum.Georeferenciacion_Tipo;
case PROYECTO_SEGUIMIENTO_FILE: return SistemaEntidadEnum.Proyecto_Seguimiento_File;
case CONFIGURATION_CATEGORY: return SistemaEntidadEnum.Configuration_Category;
case CONFIGURATION: return SistemaEntidadEnum.Configuration;
case USUARIO_PERFIL: return SistemaEntidadEnum.Usuario_Perfil;
case CERTIFICADO: return SistemaEntidadEnum.Certificado;
case PROYECTO_CRONOGRAMA_COMPOSE: return SistemaEntidadEnum.Proyecto_Cronograma_Compose;
//case PROYECTO_ETAPA_REALIZADO_PERIODO: return SistemaEntidadEnum.Proyecto_Etapa_Realizado_Periodo;
case PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA: return SistemaEntidadEnum.Proyecto_Etapa_Informacion_Presupuestaria;
case PROYECTO_ETAPA_INFORMACION_PRESUPUESTARIA_PERIODO: return SistemaEntidadEnum.Proyecto_Etapa_Informacion_Presupuestaria_Periodo;

 }
            return SistemaEntidadEnum.Undefined;
        }
    }
}

