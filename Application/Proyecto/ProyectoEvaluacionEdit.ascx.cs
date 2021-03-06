﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using Business;

namespace UI.Web.Pages
{
    public partial class ProyectoEvaluacionEdit : WebControlEdit<nc.ProyectoEvaluacionCompose>
    {


        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();
            //[Evolucion]tsEvolucionBeneficio.Width = 460;
            //[Evolucion]tsEvolucionBeneficiario.Width = 470;
            //[Evolucion]tsEvolucionBeneficiario.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            //[Evolucion]tsEvolucionBeneficio.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            //[CriterioEvaluacion]revCriteriosEvaluacion.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revMarcoLegal.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revEstudiosRealizados.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revEstudiosARealizar.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revSituacionSinProyecto.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revOpcionA.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revOpcionB.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            //revJustificacionOpcion.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);

            //[CriterioEvaluacion]revCriteriosEvaluacion.ErrorMessage = TranslateFormat("InvalidField", "Criterio de Evaluación");
            //revMarcoLegal.ErrorMessage = TranslateFormat("InvalidField", "Marco Legal");
            //revEstudiosRealizados.ErrorMessage = TranslateFormat("InvalidField", "Estudios Realizados");
            //revEstudiosARealizar.ErrorMessage = TranslateFormat("InvalidField", "Estudios a Realizar");
            //revSituacionSinProyecto.ErrorMessage = TranslateFormat("InvalidField", "Situación sin Proyecto");
            //revOpcionA.ErrorMessage = TranslateFormat("InvalidField", "Opción A");
            //revOpcionB.ErrorMessage = TranslateFormat("InvalidField", "Opción B");
            //revJustificacionOpcion.ErrorMessage = TranslateFormat("InvalidField", "Justificacion de Opción");

//[AUTOINDICADOR]            autoCmpIndicadorClaseIndicadoresProyecto.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //German 01032014 - tarea 110
            //[AUTOINDICADOR]            autoCmpIndicadorClaseIndicadoresProyecto.Visible = false;
            toIndicadoClaseEconomicoObjetivoGobierno.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //Fin German 01032014 - tarea 110
            rfvAnoIndicadoresProyecto.ErrorMessage = TranslateFormat("FieldIsNull", "Año");
            rfvValorIndicadoresProyecto.ErrorMessage = TranslateFormat("FieldIsNull", "Valor");
            rfvMontoEvaluacionSectorial.ErrorMessage = TranslateFormat("FieldIsNull", "Monto");
            //[Evolucion]rfvCantidadEstimadaEvolucionBeneficiario.ErrorMessage = TranslateFormat("FieldIsNull", "Cantidad Estimada");
            //[Evolucion]rfvCantidadEstimadaEvolucionBeneficio.ErrorMessage = TranslateFormat("FieldIsNull", "Cantidad Estimada");

            autoCmpIndicadorClaseBeneficio.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            //German 01032014 - tarea 110
            autoCmpIndicadorClaseBeneficio.Visible = false;
            toIndicadoClase.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            //Fin German 01032014 - tarea 110
            //[Evolucion]rfvTipoEvolucionBeneficiario.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            //[Evolucion]rfvTipoEvolucionBeneficio.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            //rfvValorIndicadoresProyecto.ErrorMessage = TranslateFormat("FieldIsNull", "Valor");

            //Matias 20141125 - Tarea 183
            revValorIndicadoresProyecto.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);            
            revValorIndicadoresProyecto.ErrorMessage = TranslateFormat("InvalidField", "Valor");
            //FinMatias 20141125 - Tarea 183

            //[Evolucion]revObservacionesIndicadoresBeneficiario.ErrorMessage = TranslateFormat("InvalidField", "Obervaciones");
            revObservacionesIndicadoresBeneficio.ErrorMessage = TranslateFormat("InvalidField", "Obervaciones");
            revObservacionesIndicadoresProyecto.ErrorMessage = TranslateFormat("InvalidField", "Obervaciones");
            //[Evolucion]revObservacionesIndicadoresBeneficiario.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            revObservacionesIndicadoresBeneficio.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            revObservacionesIndicadoresProyecto.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);

            //[Evolucion]diFechaEstimadaEvolucionBeneficiario.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
            //[Evolucion]diFechaEstimadaEvolucionBeneficio.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");

            //[Evolucion]revDescripcionBeneficiario.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            //[Evolucion]rfvDescripcionBeneficiario.ErrorMessage = TranslateFormat("FieldIsNull", "Descripción");
            //[Evolucion]revDescripcionBeneficiario.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);

            //[Evolucion]revCantidadRealizadaEvolucionBeneficio.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revCantidadRealizadaEvolucionBeneficio.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Realizada");

            //[Evolucion]revCantidadEstimadaEvolucionBeneficio.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revCantidadEstimadaEvolucionBeneficio.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Estimada");

            //[Evolucion]revPrecioUnitarioEstimadoEvolucionBeneficio.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revPrecioUnitarioEstimadoEvolucionBeneficio.ErrorMessage = TranslateFormat("InvalidField", "Precio Unitario Estimado");

            //[Evolucion]revPrecioUnitarioRealizadoEvolucionBeneficio.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revPrecioUnitarioRealizadoEvolucionBeneficio.ErrorMessage = TranslateFormat("InvalidField", "Precio Unitario Realizado");

            //[Evolucion]revCantidadRealizadaEvolucionBeneficiario.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revCantidadRealizadaEvolucionBeneficiario.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Realizada");

            //[Evolucion]revCantidadEstimadaEvolucionBeneficiario.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[Evolucion]revCantidadEstimadaEvolucionBeneficiario.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Estimada");

            //[CriterioEvaluacion]revHorizonteEvaluacion.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            //[CriterioEvaluacion]revHorizonteEvaluacion.ErrorMessage = TranslateFormat("InvalidField", "Horizonte de Evaluación");

            //[CriterioEvaluacion]revTasaReferencia.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //[CriterioEvaluacion]revTasaReferencia.ErrorMessage = TranslateFormat("InvalidField", "Tasa de Referencia");

            //Matias 20170209 - Ticket #REQ819714
            rfvMedioVerificacion.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            rfvMedioVerificacion2.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            rfvMedioVerificacionEvaluacionSectorial.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            rfvMedioVerificacionEvaluacionSectorial2.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            //[Evolucion]rfvMedioVerificacion3.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            //[Evolucion]rfvMedioVerificacion4.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            //FinMatias 20170209 - Ticket #REQ819714

            //se pueden unir los 2 para que haga una sola llamada a la BD
            CargarMediosVerificacionBeneficio();
            //[Evolucion]CargarMediosVerificacionBeneficiario();
            //[Evolucion]CargarIndicadorEvolucionBeneficiarioInstancia();
            //[Evolucion]CargarIndicadorEvolucionBeneficioInstancia();
            CargarAnios();
            //[Evolucion]RegistrarScriptTotales();

            PopUpIndicadoresProyecto.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadoresBeneficio.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpIndicadoresBeneficiario.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpEvolucionesBeneficiario.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpEvolucionesBeneficio.Attributes.CssStyle.Add("display", "none");

            pnlIndicadoresEvaluacion.ToolTip = Translate("TooltipIndicadoresEvaluacion");
            //[CriterioEvaluacion]txtCriteriosEvaluacion.ToolTip = Translate("TooltipCriteriosEvaluacion");
            //[CriterioEvaluacion]txtHorizonteEvaluacion.ToolTip = Translate("TooltipHorizonteEvaluacion");
            //[CriterioEvaluacion]txtTasaReferencia.ToolTip = Translate("TooltipTasaReferencia");
            pnlBeneficios.ToolTip = Translate("TooltipOtrosIndicadores");
            pnlIndicadoresObjetivosGobierno.ToolTip = Translate("TooltipContribucionObjetivoGobierno");
            ((DropDownList)toIndicadoClase.PnControl.FindControl("ddlSectorInd")).ToolTip = Translate("TooltipSector");
            ((TextBox)toIndicadoClase.PnControl.FindControl("txtSelect")).ToolTip = Translate("TooltipIndicador");
            ddlMedioVerificacionBeneficio.ToolTip = Translate("TooltipMedioVerificacion");
            txtObservacionesIndicadoresBeneficio.ToolTip = Translate("TooltipObservacionesEvaluacion");

            //Evaluacion Sectorial
            //[AUTOINDICADOR]autoCmpIndicadorClaseEvaluacionSectorial.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            //[AUTOINDICADOR]autoCmpIndicadorClaseEvaluacionSectorial.Visible = false;
            toIndicadorClaseEvaluacionSectorial.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            revObservacionesIndicadoresEvaluacionSectorial.ErrorMessage = TranslateFormat("InvalidField", "Obervaciones");
            revObservacionesIndicadoresEvaluacionSectorial.ValidationExpression = Contract.DataHelper.GetExpRegString(4000);
            CargarMediosVerificacionEvaluacionSectorial();
            PopUpIndicadoresEvaluacionSectorial.Attributes.CssStyle.Add("display", "none");
        }

        /*[Evolucion]
        public void RegistrarScriptTotales()
        {
            string totalesScript = "function CalcularTotales()\n" +
                    "{\n" +

                        "var CantidadEstimadaEvolucionBeneficio = parseFloat(IsNumeric(document.getElementById('" +
                        txtCantidadEstimadaEvolucionBeneficio.ClientID +
                        "').value.replace(',', '.')) ? document.getElementById('" + txtCantidadEstimadaEvolucionBeneficio.ClientID + "').value.replace(',', '.') : '0');\n" +
                        "var PrecioUnitarioEstimadoEvolucionBeneficio = parseFloat(IsNumeric(document.getElementById('" +
                        txtPrecioUnitarioEstimadoEvolucionBeneficio.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtPrecioUnitarioEstimadoEvolucionBeneficio.ClientID + "').value.replace(',', '.') : '0');\n" +
                       
                        "var CantidadRealizadaEvolucionBeneficio = parseFloat(IsNumeric(document.getElementById('" +
                        txtCantidadRealizadaEvolucionBeneficio.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtCantidadRealizadaEvolucionBeneficio.ClientID + "').value.replace(',', '.') : '0');\n" +
                        "var PrecioUnitarioRealizadoEvolucionBeneficio = parseFloat(IsNumeric(document.getElementById('" +
                        txtPrecioUnitarioRealizadoEvolucionBeneficio.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtPrecioUnitarioRealizadoEvolucionBeneficio.ClientID + "').value.replace(',', '.') : '0');\n" +

                        "var MontoEstimadoEvolucionBeneficio =  parseFloat(CantidadEstimadaEvolucionBeneficio * PrecioUnitarioEstimadoEvolucionBeneficio).toFixed(2);\n" +
                        "var MontoRealizadoEvolucionBeneficio = parseFloat(CantidadRealizadaEvolucionBeneficio * PrecioUnitarioRealizadoEvolucionBeneficio).toFixed(2);\n" +

                        "document.getElementById('" + lblMontoEstimadoEvolucionBeneficio.ClientID + "').innerHTML =  MontoEstimadoEvolucionBeneficio.replace('.', ',');\n" +
                        "document.getElementById('" + lblMontoRealizadoEvolucionBeneficio.ClientID + "').innerHTML =  MontoRealizadoEvolucionBeneficio.replace('.', ',');\n" +                    
                    "}";


            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "totalesScript", totalesScript, true);

            txtCantidadEstimadaEvolucionBeneficio.Attributes["onChange"] = "CalcularTotales();";
            txtPrecioUnitarioEstimadoEvolucionBeneficio.Attributes["onChange"] = "CalcularTotales();";
            txtCantidadRealizadaEvolucionBeneficio.Attributes["onChange"] = "CalcularTotales();";
            txtPrecioUnitarioRealizadoEvolucionBeneficio.Attributes["onChange"] = "CalcularTotales();";
                    
        }*/

        protected override void _Load()
        {
            PopUpIndicadoresProyecto.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpIndicadoresBeneficiario.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadoresBeneficio.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpEvolucionesBeneficiario.Attributes.CssStyle.Add("display", "none");
            //[Evolucion]PopUpEvolucionesBeneficio.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadoresEvaluacionSectorial.Attributes.CssStyle.Add("display", "none");
        }
        
        
        public override void Clear()
        {
            UIHelper.Clear(gridIndicadoresBeneficio);
            UIHelper.Clear(gridIndicadoresEvaluacionSectorial);
            //UIHelper.Clear(gridIndicadoresBeneficiario);
            //UIHelper.Clear(txtMarcoLegal);
            //UIHelper.Clear(txtEstudiosRealizados);
            //UIHelper.Clear(txtEstudiosARealizar);
            //UIHelper.Clear(txtSituacionSinProyecto);
            //UIHelper.Clear(txtOpcionA);
            //UIHelper.Clear(txtOpcionB);
            //UIHelper.Clear(txtJustificacionOpcion);
            UIHelper.Clear(gridIndicadoresObjetivosGobierno);
            //[CriterioEvaluacion]UIHelper.Clear(txtCriteriosEvaluacion);
            //[CriterioEvaluacion]UIHelper.Clear(txtHorizonteEvaluacion);
            //[CriterioEvaluacion]UIHelper.Clear(txtTasaReferencia);
            upGridIndicadoresEconomicos.Update();
            upGridIndicadoresEvaluacionSectorial.Update();
        }
        public override void GetValue()
        {
            //[CriterioEvaluacion]Entity.Evaluacion.CriterioEvaluacion = UIHelper.GetString(txtCriteriosEvaluacion);
            //[CriterioEvaluacion]Entity.Evaluacion.HorizonteEvaluacion = UIHelper.GetIntNullable(txtHorizonteEvaluacion);
            //[CriterioEvaluacion]Entity.Evaluacion.TasaReferencia = UIHelper.GetDecimalNullable(txtTasaReferencia);
            //Entity.Evaluacion.MarcoLegal = UIHelper.GetString(txtMarcoLegal);
            //Entity.Evaluacion.EstudioRealizado = UIHelper.GetString(txtEstudiosRealizados);
            //Entity.Evaluacion.EstudioaRealizar = UIHelper.GetString(txtEstudiosARealizar);
            //Entity.Evaluacion.SituacionSinProyecto = UIHelper.GetString(txtSituacionSinProyecto);
            //Entity.Evaluacion.OpcionA = UIHelper.GetString(txtOpcionA);
            //Entity.Evaluacion.OpcionB = UIHelper.GetString(txtOpcionB);
            //Entity.Evaluacion.OpcionJustificacion = UIHelper.GetString(txtJustificacionOpcion);
        }
        public override void SetValue()
        {
            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
            if (Entity.Evaluacion == null)
            {
                Entity.Evaluacion = new ProyectoEvaluacionResult();
                Entity.Evaluacion.Id_Proyecto = Entity.IdProyecto;
                Entity.Evaluacion.Id_ProyectoEvaluacion = -1;
            }
            else
            {
                //UIHelper.SetValue(txtCriteriosEvaluacion, Entity.Evaluacion.CriterioEvaluacion);
                //UIHelper.SetValue(txtHorizonteEvaluacion, Entity.Evaluacion.HorizonteEvaluacion);
                //UIHelper.SetValue(txtTasaReferencia, Entity.Evaluacion.TasaReferencia);
                //UIHelper.SetValue(txtMarcoLegal, Entity.Evaluacion.MarcoLegal);
                //UIHelper.SetValue(txtEstudiosRealizados, Entity.Evaluacion.EstudioRealizado);
                //UIHelper.SetValue(txtEstudiosARealizar, Entity.Evaluacion.EstudioaRealizar);
                //UIHelper.SetValue(txtSituacionSinProyecto, Entity.Evaluacion.SituacionSinProyecto);
                //UIHelper.SetValue(txtOpcionA, Entity.Evaluacion.OpcionA);
                //UIHelper.SetValue(txtOpcionB, Entity.Evaluacion.OpcionB);
                //UIHelper.SetValue(txtJustificacionOpcion, Entity.Evaluacion.OpcionJustificacion);
            }
            //upSituacionSinProyecto.Update();
            //upOpciones.Update();
            //upEstudios.Update();
            //upMarcoLegal.Update();
            IndicadoresEconomicoRefresh();
//*****************************************************************            IndicadoresSectorialRefresh();
            IndicadoresObjetivosGobiernoRefresh();
            //[Evolucion]IndicadoresBeneficiarioRefresh();
            
            IndicadoresBeneficioRefresh();
            IndicadoresBeneficioClear();

            IndicadoresEvaluacionSectorialRefresh();
            IndicadoresEvaluacionSectorialClear();

            //CargarIndicadorProyectoClases((int)IndicadorTipoEnum.Objetivo);
        }

        void CargarAnios()
        {
            nc.AnioFilter anioFilter = new nc.AnioFilter();
            anioFilter.OrderBys.Add(new FilterOrderBy("Nombre", true));
            anioFilter.Activo = true;
            anioFilter.Anio_To = DateTime.Now.Year;

            UIHelper.Load<Anio>(ddlAnoIndicadoresProyecto, AnioBusiness.Current.GetList(anioFilter),
              "Nombre", "IdAnio", new Anio() { IdAnio = 0, Nombre = "Selecione Año" }, false);
        }
        #endregion Override

        //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
        //#region Permissions
        //protected bool EnableSolapa
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(ViewState["EnableSolapa"]);
        //    }
        //    set
        //    {
        //        ViewState["EnableSolapa"] = value;
        //    }
        //}

        //protected void SetPermissions()
        //{
        //    if (CrudAction == CrudActionEnum.Create)
        //    {
        //        //EnableSolapa = false;
        //    }
        //    else if (CrudAction == CrudActionEnum.Read)
        //    {
        //        EnableSolapa = false;
        //        this.pnlIndicadoresEvaluacion.Enabled = false;
        //        this.pnlBeneficios.Enabled = false;
        //        this.pnlBeneficiarios.Enabled = false;
        //        this.pnlMarcoLegal.Enabled = false;
        //        this.pnlEstudios.Enabled = false;
        //        this.pnlMarcoLegal.Enabled = false;
        //        this.pnlSituacionSinProyecto.Enabled = false;
        //        this.pnlOpciones.Enabled = false;
        //        this.pnlIndicadoresObjetivosGobierno.Enabled = false;
        //    }
        //    else
        //    {
        //        //EnableSolapa = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);                
        //    }

        //    //Inhabilito todos los componenetes de la Solapa
        //    //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;            
        //}
        //#endregion
        //FinMatias 20170210 - Ticket #REQ768159

        #region Indicadores Beneficio

        private ProyectoBeneficioIndicadorCompose actualProyectoBeneficioIndicadorCompose;
        protected ProyectoBeneficioIndicadorCompose ActualProyectoBeneficioIndicadorCompose
        {
            get
            {
                if (actualProyectoBeneficioIndicadorCompose == null)
                    if (ViewState["actualProyectoBeneficioIndicadorCompose"] != null)
                        actualProyectoBeneficioIndicadorCompose = ViewState["actualProyectoBeneficioIndicadorCompose"] as ProyectoBeneficioIndicadorCompose;
                    else
                    {
                        actualProyectoBeneficioIndicadorCompose = GetNewProyectoBeneficioIndicadorCompose();
                        ViewState["actualProyectoBeneficioIndicadorCompose"] = actualProyectoBeneficioIndicadorCompose;
                    }
                return actualProyectoBeneficioIndicadorCompose;
            }
            set
            {
                actualProyectoBeneficioIndicadorCompose = value;
                ViewState["actualProyectoBeneficioIndicadorCompose"] = value;
            }
        }
        ProyectoBeneficioIndicadorCompose GetNewProyectoBeneficioIndicadorCompose()
        {

            int id = 0;
            if (Entity.IndicadoresBeneficio.Count > 0) id = Entity.IndicadoresBeneficio.Min(l => l.Indicador.IdProyectoBeneficioIndicador);
            if (id > 0) id = 0;
            id--;
            ProyectoBeneficioIndicadorCompose proyectoBeneficioIndicadorCompose;
            proyectoBeneficioIndicadorCompose = new ProyectoBeneficioIndicadorCompose();
            proyectoBeneficioIndicadorCompose.Indicador = new ProyectoBeneficioIndicadorResult();
            proyectoBeneficioIndicadorCompose.Indicador.IdProyectoBeneficioIndicador = id;

            return proyectoBeneficioIndicadorCompose;
        }

        public void toIndicadorClase_OnValueChanged(object sender, EventArgs e)
        {
            litMontoRango.Visible = false;
            ravMonto.Enabled = false;
            if (toIndicadoClase.ValueId.HasValue)
            {
                IndicadorClase indicadorClase = IndicadorClaseService.Current.GetById(toIndicadoClase.ValueId.Value);
            
                int rangoInicial = 0;
                int rangoFinal = 0;
            
                if(indicadorClase.RangoInicial != null) 
                    rangoInicial = (int)indicadorClase.RangoInicial;

                if (indicadorClase.RangoFinal != null)
                    rangoFinal = (int)indicadorClase.RangoFinal;

                if (rangoInicial > 0 || rangoFinal > 0)
                {
                    litMontoRango.Text = string.Format("Rango monto entre ({0} y {1})", rangoInicial, rangoFinal);
                    litMontoRango.Visible = true;
                    ravMonto.Enabled = true;
                    ravMonto.MinimumValue = rangoInicial.ToString();
                    ravMonto.MaximumValue = rangoFinal.ToString();
                }
            }
        }

        #region Commands
        void CommandIndicadoresBeneficioEdit()
        {
            IndicadoresBeneficioSetValue();
            ModalPopupExtenderIndicadoresBeneficio.Show();
            upIndicadoresBeneficioPopUp.Update();

        }
        void CommandIndicadoresBeneficioSave()
        {
            IndicadoresBeneficioGetValue();

            ProyectoBeneficioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficio
                                                      where l.Indicador.IdProyectoBeneficioIndicador == ActualProyectoBeneficioIndicadorCompose.Indicador.ID
                                                      select l).FirstOrDefault();

            if (pbic != null)
            {

                pbic.Indicador.Indicador_Observacion = ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_Observacion;
                pbic.Indicador.IdIndicadorClase = ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase;
                pbic.Indicador.Indirecto = ActualProyectoBeneficioIndicadorCompose.Indicador.Indirecto;
                pbic.Indicador.Valor = ActualProyectoBeneficioIndicadorCompose.Indicador.Valor;
                pbic.Indicador.Indicador_IdMedioVerificacion = ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion;
                pbic.Indicador.IndicadorClase_Nombre = ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Nombre;
                pbic.Indicador.IndicadorClase_Sigla = ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Sigla;
                pbic.Indicador.IndicadorClase_Unidad = ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Unidad;
                pbic.Indicador.Indicador_MedioVerificacion = ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_MedioVerificacion;
                //German 20140511 - Tarea 124
                //pbic.Indicador.IdIndicadorRubro = pbic.Indicador.IdIndicadorRubro;
                pbic.Indicador.IdIndicadorRubro = ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorRubro;
                //FinGerman 20140511 - Tarea 124

            }
            else
            {

                Entity.IndicadoresBeneficio.Add(ActualProyectoBeneficioIndicadorCompose);
            }

            IndicadoresBeneficioRefresh();
            IndicadoresBeneficioClear();


        }
        void CommandIndicadoresBeneficioDelete()
        {

            ProyectoBeneficioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficio
                                                      where l.Indicador.IdProyectoBeneficioIndicador == ActualProyectoBeneficioIndicadorCompose.Indicador.ID
                                                      select l).FirstOrDefault();

            Entity.IndicadoresBeneficio.Remove(pbic);

            IndicadoresBeneficioClear();
            IndicadoresBeneficioRefresh();

        }
        #endregion

        #region Methods

        void HidePopUpIndicadoresBeneficio()
        {
            ModalPopupExtenderIndicadoresBeneficio.Hide();
        }
        void IndicadoresBeneficioClear()
        {
            ActualProyectoBeneficioIndicadorCompose = GetNewProyectoBeneficioIndicadorCompose();
            
            UIHelper.Clear(txtObservacionesIndicadoresBeneficio);
            UIHelper.Clear(autoCmpIndicadorClaseBeneficio);
            //German 01032014 - tarea 110
            UIHelper.Clear(toIndicadoClase);
            //Fin German 01032014 - tarea 110
            UIHelper.Clear(chkIndirectoBeneficio);
            UIHelper.Clear(ddlMedioVerificacionBeneficio);
            UIHelper.Clear(txtMontoBeneficio);

            int? idIndicadorRubro = null;
            if (toIndicadoClase.Sectores.SelectedIndex >= 0)
                idIndicadorRubro = Convert.ToInt32(toIndicadoClase.Sectores.SelectedValue);

            autoCmpIndicadorClaseBeneficio.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.Beneficio, Activo = true };
            //German 01032014 - tarea 110
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Beneficio, Activo = true };
            //solo por ahora - Ver pq no funciona
            //toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = null, Activo = true };
            //Fin German 01032014 - tarea 110
            upIndicadoresBeneficioPopUp.Update();


        }
        void IndicadoresBeneficioSetValue()
        {
            UIHelper.SetValue(autoCmpIndicadorClaseBeneficio, ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.SetValue(toIndicadoClase, ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase);
            //FinGerman 01032014 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadoClase.Sectores, ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124            
            UIHelper.SetValue(chkIndirectoBeneficio, ActualProyectoBeneficioIndicadorCompose.Indicador.Indirecto);
            UIHelper.SetValue(txtMontoBeneficio, ActualProyectoBeneficioIndicadorCompose.Indicador.Valor);
            UIHelper.SetValue(ddlMedioVerificacionBeneficio, ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadoresBeneficio, ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_Observacion);
        }
        void IndicadoresBeneficioGetValue()
        {

            ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadoresBeneficio);
            ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacionBeneficio);
            ActualProyectoBeneficioIndicadorCompose.Indicador.Indirecto = UIHelper.GetBoolean(chkIndirectoBeneficio);
            ActualProyectoBeneficioIndicadorCompose.Indicador.Valor = UIHelper.GetInt(txtMontoBeneficio);

            ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClaseBeneficio);
            //German 01032014 - tarea 110
            ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadoClase);
            //FinGerman 01032014 - tarea 110
            //German 20140511 - Tarea 124
            ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorRubro = (UIHelper.GetIntNullable(toIndicadoClase.Sectores) == null) ? 0 : UIHelper.GetIntNullable(toIndicadoClase.Sectores).Value;
            //FinGerman 20140511 - Tarea 124
            
            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualProyectoBeneficioIndicadorCompose.Indicador.IdIndicadorClase }).FirstOrDefault();

            ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Sigla = result.Sigla;
            ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Nombre = result.Nombre;
            ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Unidad = result.Unidad_Nombre;

            if (ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion != null)
            {
                ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacionBeneficio);
            }
            else
            {
                ActualProyectoBeneficioIndicadorCompose.Indicador.Indicador_MedioVerificacion = string.Empty;
            }             
            

        }
        void IndicadoresBeneficioRefresh()
        {
            List<ProyectoBeneficioIndicadorResult> indicadores = new List<ProyectoBeneficioIndicadorResult>();
            Entity.IndicadoresBeneficio.ForEach(i => indicadores.Add(i.Indicador));
            UIHelper.Load(gridIndicadoresBeneficio, indicadores, "IndicadorClase_Nombre");
            upGridIndicadoresBeneficio.Update();

        }
        #endregion Methods

        #region Eventos
        protected void btSaveIndicadorBeneficio_Click(object sender, EventArgs e)
        {

            string msgError;
            if (ValidateIndicadoresBeneficio(out  msgError))
            {

                CallTryMethod(CommandIndicadoresBeneficioSave);
                HidePopUpIndicadoresBeneficio();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresBeneficioPopUp);
            }

        }
        protected void btNewIndicadorBeneficio_Click(object sender, EventArgs e)
        {
            string msgError;
            if (ValidateIndicadoresBeneficio(out  msgError))
            {
                CallTryMethod(CommandIndicadoresBeneficioSave);
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresBeneficioPopUp);
            }
        }
        protected void btCancelIndicadorBeneficio_Click(object sender, EventArgs e)
        {
            IndicadoresBeneficioClear();
            HidePopUpIndicadoresBeneficio();
        }
        protected void btAgregarIndicadorBeneficio_Click(object sender, EventArgs e)
        {
            IndicadoresBeneficioClear();
            ModalPopupExtenderIndicadoresBeneficio.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridIndicadoresBeneficio_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoBeneficioIndicadorCompose = (from l in Entity.IndicadoresBeneficio
                                                          where l.Indicador.IdProyectoBeneficioIndicador == id
                                                          select l).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresBeneficioEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresBeneficioDelete();
                    break;
                case Command.SHOW_DETAILS:
                    //[Evolucion]ShowPopUpEvolucionesBeneficio();
                    break;

            }


        }
        protected virtual void GridIndicadoresBeneficio_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridIndicadoresBeneficio.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadoresBeneficio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridIndicadoresBeneficio.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        void CargarMediosVerificacionBeneficio()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacionBeneficio, MedioVerificacionService.Current.GetList(),
                "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Selecione Medio"});
        }


        protected void ddlMedioVerificacionBeneficio_IndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void IndicadoresBeneficio_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

        }

        private bool ValidateIndicadoresBeneficio(out string msgError)
        {
            msgError = string.Empty;
            int id = UIHelper.GetInt(autoCmpIndicadorClaseBeneficio);

            //German 01032014 - tarea 110
            if (autoCmpIndicadorClaseBeneficio.Visible == false)
                id = UIHelper.GetInt(toIndicadoClase);
            //Fin German 01032014 - tarea 110 

            //Matias 20140521 - Tarea 124
            if (id == 0)
            {
                msgError = TranslateFormat("FieldIsNull", "Indicador");
                return false;
            }
            //FinMatias 20140521 - Tarea 124

            int idIndicador = ActualProyectoBeneficioIndicadorCompose.Indicador.IdProyectoBeneficioIndicador;

            if (Entity.IndicadoresBeneficio.Where(p => (p.Indicador.IdProyectoBeneficioIndicador != idIndicador) && (p.Indicador.IdIndicadorClase == id)).Count() > 0)
            {
                msgError = Translate("* No puede haber mas de un indicador de la misma clase.");
                return false;
            }
            return true;
        }


        #endregion

        /*[Evolucion]
        #region Indicadores Beneficiario


        private ProyectoBeneficiarioIndicadorCompose actualProyectoBeneficiarioIndicadorCompose;
        protected ProyectoBeneficiarioIndicadorCompose ActualProyectoBeneficiarioIndicadorCompose
        {
            get
            {
                if (actualProyectoBeneficiarioIndicadorCompose == null)
                    if (ViewState["actualProyectoBeneficiarioIndicadorCompose"] != null)
                        actualProyectoBeneficiarioIndicadorCompose = ViewState["actualProyectoBeneficiarioIndicadorCompose"] as ProyectoBeneficiarioIndicadorCompose;
                    else
                    {
                        actualProyectoBeneficiarioIndicadorCompose = GetNewProyectoBeneficiarioIndicadorCompose();
                        ViewState["actualProyectoBeneficiarioIndicadorCompose"] = actualProyectoBeneficiarioIndicadorCompose;
                    }
                return actualProyectoBeneficiarioIndicadorCompose;
            }
            set
            {
                actualProyectoBeneficiarioIndicadorCompose = value;
                ViewState["actualProyectoBeneficiarioIndicadorCompose"] = value;
            }
        }
        ProyectoBeneficiarioIndicadorCompose GetNewProyectoBeneficiarioIndicadorCompose()
        {

            int id = 0;
            if (Entity.IndicadoresBeneficiario.Count > 0) id = Entity.IndicadoresBeneficiario.Min(l => l.Indicador.IdProyectoBeneficiarioIndicador);
            if (id > 0) id = 0;
            id--;
            ProyectoBeneficiarioIndicadorCompose proyectoBeneficiarioIndicadorCompose;
            proyectoBeneficiarioIndicadorCompose = new ProyectoBeneficiarioIndicadorCompose();
            proyectoBeneficiarioIndicadorCompose.Indicador = new ProyectoBeneficiarioIndicadorResult();
            proyectoBeneficiarioIndicadorCompose.Indicador.IdProyectoBeneficiarioIndicador = id;

            return proyectoBeneficiarioIndicadorCompose;
        }


        #region Commands
        void CommandIndicadoresBeneficiarioEdit()
        {
            IndicadoresBeneficiarioSetValue();
            ModalPopupExtenderIndicadoresBeneficiario.Show();
            upIndicadoresBeneficiarioPopUp.Update();

        }
        void CommandIndicadoresBeneficiarioSave()
        {

            IndicadoresBeneficiarioGetValue();

            ProyectoBeneficiarioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficiario
                                                         where l.Indicador.IdProyectoBeneficiarioIndicador == ActualProyectoBeneficiarioIndicadorCompose.Indicador.ID
                                                         select l).FirstOrDefault();

            if (pbic != null)
            {
                pbic.Indicador.Beneficiario = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Beneficiario;
                pbic.Indicador.Indirecto = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indirecto;
                pbic.Indicador.Indicador_Observacion = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_Observacion;
                pbic.Indicador.Indicador_IdMedioVerificacion = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion;
                pbic.Indicador.Indicador_MedioVerificacion = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_MedioVerificacion;

            }
            else
            {

                Entity.IndicadoresBeneficiario.Add(ActualProyectoBeneficiarioIndicadorCompose);
            }

            IndicadoresBeneficiarioRefresh();
            IndicadoresBeneficiarioClear();


        }
        void CommandIndicadoresBeneficiarioDelete()
        {

            ProyectoBeneficiarioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficiario
                                                         where l.Indicador.IdProyectoBeneficiarioIndicador == ActualProyectoBeneficiarioIndicadorCompose.Indicador.ID
                                                         select l).FirstOrDefault();

            Entity.IndicadoresBeneficiario.Remove(pbic);

            IndicadoresBeneficiarioClear();
            IndicadoresBeneficiarioRefresh();

        }
        #endregion

        #region Methods

        void HidePopUpIndicadoresBeneficiario()
        {
            ModalPopupExtenderIndicadoresBeneficiario.Hide();
        }
        void IndicadoresBeneficiarioClear()
        {
            ActualProyectoBeneficiarioIndicadorCompose = GetNewProyectoBeneficiarioIndicadorCompose();

            UIHelper.Clear(txtDescripcionBeneficiario);
            UIHelper.Clear(txtObservacionesIndicadoresBeneficiario);
            UIHelper.Clear(chkIndirectoBeneficiario);
            UIHelper.Clear(ddlMedioVerificacionBeneficiario);            
            upIndicadoresBeneficiarioPopUp.Update();


        }
        void IndicadoresBeneficiarioSetValue()
        {
            UIHelper.SetValue(txtDescripcionBeneficiario, ActualProyectoBeneficiarioIndicadorCompose.Indicador.Beneficiario);
            UIHelper.SetValue(ddlMedioVerificacionBeneficiario, ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadoresBeneficiario, ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_Observacion);
            UIHelper.SetValue(chkIndirectoBeneficiario, ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indirecto);
        }
        void IndicadoresBeneficiarioGetValue()
        {

            ActualProyectoBeneficiarioIndicadorCompose.Indicador.Beneficiario = UIHelper.GetString(txtDescripcionBeneficiario);
            ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indirecto = UIHelper.GetBoolean(chkIndirectoBeneficiario);
            ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadoresBeneficiario);
            ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacionBeneficiario);
            if (ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_IdMedioVerificacion != null)
            {
                ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacionBeneficiario);
            }
            else
            {
                ActualProyectoBeneficiarioIndicadorCompose.Indicador.Indicador_MedioVerificacion = string.Empty;
            }            

        }
        void IndicadoresBeneficiarioRefresh()
        {
            List<ProyectoBeneficiarioIndicadorResult> indicadores = new List<ProyectoBeneficiarioIndicadorResult>();
            Entity.IndicadoresBeneficiario.ForEach(i => indicadores.Add(i.Indicador));
            //UIHelper.Load(gridIndicadoresBeneficiario, indicadores, "Beneficiario");
            //upGridIndicadoresBeneficiario.Update();
        }
        #endregion Methods

        #region Eventos
        protected void btSaveIndicadorBeneficiario_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandIndicadoresBeneficiarioSave);
            HidePopUpIndicadoresBeneficiario();
        }
        protected void btNewIndicadorBeneficiario_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandIndicadoresBeneficiarioSave);
        }
        protected void btCancelIndicadorBeneficiario_Click(object sender, EventArgs e)
        {
            IndicadoresBeneficiarioClear();
            HidePopUpIndicadoresBeneficiario();
        }
        protected void btAgregarIndicadorBeneficiario_Click(object sender, EventArgs e)
        {
            IndicadoresBeneficiarioClear();
            ModalPopupExtenderIndicadoresBeneficiario.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridIndicadoresBeneficiario_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoBeneficiarioIndicadorCompose  = (from l in Entity.IndicadoresBeneficiario
                                                               where l.Indicador.IdProyectoBeneficiarioIndicador == id
                                                               select l).FirstOrDefault();
            

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresBeneficiarioEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresBeneficiarioDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ShowPopUpEvolucionesBeneficiario();
                    break;

            }

        }
        protected virtual void GridIndicadoresBeneficiario_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                //gridIndicadoresBeneficiario.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadoresBeneficiario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                //gridIndicadoresBeneficiario.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        void CargarMediosVerificacionBeneficiario()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacionBeneficiario, MedioVerificacionService.Current.GetList(),
                "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Selecione Medio" });
        }


        protected void ddlMedioVerificacionBeneficiario_IndexChanged(object sender, EventArgs e)
        {

        }

        
        #endregion
        */

        #region Indicadores Economicos

        private ProyectoIndicadorEconomicoResult actualProyectoIndicadorEconomico;
        protected ProyectoIndicadorEconomicoResult ActualProyectoIndicadorEconomico
        {
            get
            {
                if (actualProyectoIndicadorEconomico == null)
                    if (ViewState["actualProyectoIndicadorEconomico"] != null)
                        actualProyectoIndicadorEconomico = ViewState["actualProyectoIndicadorEconomico"] as ProyectoIndicadorEconomicoResult;
                    else
                    {
                        actualProyectoIndicadorEconomico = GetNewProyectoIndicadorEconomico();
                        ViewState["actualProyectoIndicadorEconomico"] = actualProyectoIndicadorEconomico;
                    }
                return actualProyectoIndicadorEconomico;
            }
            set
            {
                actualProyectoIndicadorEconomico = value;
                ViewState["actualProyectoIndicadorEconomico"] = value;
            }
        }
        ProyectoIndicadorEconomicoResult GetNewProyectoIndicadorEconomico()
        {

            int id = 0;
            if (Entity.IndicadoresEconomico.Count > 0) id = Entity.IndicadoresEconomico.Min(l => l.IdProyectoIndicadorEconomico);
            if (id > 0) id = 0;
            id--;
            ProyectoIndicadorEconomicoResult proyectoIndicadorEconomicoResult;
            proyectoIndicadorEconomicoResult = new ProyectoIndicadorEconomicoResult();
            proyectoIndicadorEconomicoResult.IdProyectoIndicadorEconomico = id;

            return proyectoIndicadorEconomicoResult;
        }

        #region Commands
        void CommandIndicadoresEconomicoEdit()
        {
            IndicadoresEconomicoSetValue();            
        }
        void CommandIndicadoresEconomicoSave()
        {
            ProyectoIndicadorEconomicoResult piep = (from l in Entity.IndicadoresEconomico
                                                        where l.IdProyectoIndicadorEconomico == ActualProyectoIndicadorEconomico.ID
                                                        select l).FirstOrDefault();

            if (piep != null)
            {

                piep.Valor = ActualProyectoIndicadorEconomico.Valor;
                piep.Anio = ActualProyectoIndicadorEconomico.Anio;
                piep.Observacion = ActualProyectoIndicadorEconomico.Observacion;
                piep.IdIndicadorClase = ActualProyectoIndicadorEconomico.IdIndicadorClase;
                piep.IndicadorClase_Nombre = ActualProyectoIndicadorEconomico.IndicadorClase_Nombre;
                piep.IndicadorClase_Sigla = ActualProyectoIndicadorEconomico.IndicadorClase_Sigla;
                piep.IndicadorClase_Unidad = ActualProyectoIndicadorEconomico.IndicadorClase_Unidad;
                piep.IndicadorClase_IdIndicadorTipo = ActualProyectoIndicadorEconomico.IndicadorClase_IdIndicadorTipo;

            }
            else
            {

                Entity.IndicadoresEconomico.Add(ActualProyectoIndicadorEconomico);
            }
        }
        void CommandIndicadoresEconomicoDelete()
        {

            ProyectoIndicadorEconomicoResult pier = (from l in Entity.IndicadoresEconomico
                                                    where l.IdProyectoIndicadorEconomico == ActualProyectoIndicadorEconomico.ID
                                                    select l).FirstOrDefault();

            Entity.IndicadoresEconomico.Remove(pier);

        }
        #endregion

        #region Methods
        void IndicadoresEconomicoClear()
        {
            ActualProyectoIndicadorEconomico = GetNewProyectoIndicadorEconomico();

            int? idIndicadorRubro = null;
            if (toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedIndex >= 0)
                idIndicadorRubro = Convert.ToInt32(toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedValue);

            //[AUTOINDICADOR]           autoCmpIndicadorClaseIndicadoresProyecto.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.Economico, Activo = true };
            //German 01032014 - tarea 110
            toIndicadoClaseEconomicoObjetivoGobierno.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.Economico, Activo = true };
            
            //solo por ahora - Ver pq no funciona
            //toIndicadoClaseEconomicoObjetivoGobierno.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = null, Activo = true };
            //Fin German 01032014 - tarea 110
        }
        void IndicadoresEconomicoSetValue()
        {
            int? idIndicadorRubro = null;
            if (toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedIndex >= 0)
                idIndicadorRubro = Convert.ToInt32(toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedValue);

            //[AUTOINDICADOR]            UIHelper.SetValue(autoCmpIndicadorClaseIndicadoresProyecto, ActualProyectoIndicadorEconomico.IdIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.SetValue(toIndicadoClaseEconomicoObjetivoGobierno, ActualProyectoIndicadorEconomico.IdIndicadorClase);
            //Fin German 01032014 - tarea 110
            UIHelper.SetValue(txtValorIndicadoresProyecto, ActualProyectoIndicadorEconomico.Valor);

            if (ActualProyectoIndicadorEconomico.Anio.HasValue)
                ddlAnoIndicadoresProyecto.SelectedValue = ddlAnoIndicadoresProyecto.Items.FindByText(ActualProyectoIndicadorEconomico.Anio.ToString()).Value;
            else
                UIHelper.Clear(ddlAnoIndicadoresProyecto);  
            //UIHelper.SetValue(ddlAnoIndicadoresProyecto, ActualProyectoIndicadorEconomico.Anio);
            UIHelper.SetValue(txtObservacionesIndicadoresProyecto, ActualProyectoIndicadorEconomico.Observacion);
            
        }
        void IndicadoresEconomicoGetValue()
        {
            VisibleValorIndicadoresProyecto(true); //No visibles para Contribución al Objetivo de Gobierno
            RequiredIndicadoresProyecto(true); //Requeridos anio y valor en economicos

            //[AUTOINDICADOR]           ActualProyectoIndicadorEconomico.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClaseIndicadoresProyecto);
            //German 01032014 - tarea 110
            ActualProyectoIndicadorEconomico.IdIndicadorClase = UIHelper.GetInt(toIndicadoClaseEconomicoObjetivoGobierno);
            //Fin German 01032014 - tarea 110
            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualProyectoIndicadorEconomico.IdIndicadorClase }).FirstOrDefault();
            ActualProyectoIndicadorEconomico.IndicadorClase_Sigla = result.Sigla;
            ActualProyectoIndicadorEconomico.IndicadorClase_Nombre = result.Nombre;
            ActualProyectoIndicadorEconomico.IndicadorClase_Unidad = result.Unidad_Nombre;
 
            ActualProyectoIndicadorEconomico.Anio = Convert.ToInt32(UIHelper.GetString(ddlAnoIndicadoresProyecto));            
            ActualProyectoIndicadorEconomico.Observacion = UIHelper.GetString(txtObservacionesIndicadoresProyecto);
            ActualProyectoIndicadorEconomico.Valor = UIHelper.GetDecimal(txtValorIndicadoresProyecto);

        }
        void IndicadoresEconomicoRefresh()
        {
            UIHelper.Load(gridIndicadoresEconomicos, Entity.IndicadoresEconomico, "IndicadorClase_Nombre");
            upGridIndicadoresEconomicos.Update();

        }
        #endregion Methods

        #region Eventos
        protected void btAgregarIndicadorEconomico_Click(object sender, EventArgs e)
        {
            VisibleValorIndicadoresProyecto(true);
            RequiredIndicadoresProyecto(true); //Requeridos anio y valor en economicos
            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.Economico;
            IndicadoresProyectoClear();
            ModalPopupExtenderIndicadoresProyecto.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridIndicadoresEconomicos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.Economico;
            IndicadoresProyectoClear();
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoIndicadorEconomico = (from l in Entity.IndicadoresEconomico
                                                   where l.IdProyectoIndicadorEconomico == id
                                                   select l).FirstOrDefault();

            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.Economico;

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresProyectoEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresProyectoDelete();
                    break;
            }


        }
        protected virtual void GridIndicadoresEconomicos_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridIndicadoresEconomicos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadoresEconomicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridIndicadoresEconomicos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion
        
        #endregion

        #region Indicadores Sectorial

        private ProyectoEvaluacionSectorialIndicadorCompose actualProyectoEvaluacionSectorialIndicadorCompose;
        protected ProyectoEvaluacionSectorialIndicadorCompose ActualProyectoEvaluacionSectorialIndicadorCompose
        {
            get
            {
                if (actualProyectoEvaluacionSectorialIndicadorCompose == null)
                    if (ViewState["actualProyectoEvaluacionSectorialIndicadorCompose"] != null)
                        actualProyectoEvaluacionSectorialIndicadorCompose = ViewState["actualProyectoEvaluacionSectorialIndicadorCompose"] as ProyectoEvaluacionSectorialIndicadorCompose;
                    else
                    {
                        actualProyectoEvaluacionSectorialIndicadorCompose = GetNewProyectoEvaluacionSectorialIndicadorCompose();
                        ViewState["actualProyectoEvaluacionSectorialIndicadorCompose"] = actualProyectoEvaluacionSectorialIndicadorCompose;
                    }
                return actualProyectoEvaluacionSectorialIndicadorCompose;
            }
            set
            {
                actualProyectoEvaluacionSectorialIndicadorCompose = value;
                ViewState["actualProyectoEvaluacionSectorialIndicadorCompose"] = value;
            }
        }
        ProyectoEvaluacionSectorialIndicadorCompose GetNewProyectoEvaluacionSectorialIndicadorCompose()
        {

            int id = 0;
            if (Entity.IndicadoresEvaluacionSectorial.Count > 0) id = Entity.IndicadoresEvaluacionSectorial.Min(l => l.Indicador.IdProyectoEvaluacionSectorialIndicador);
            if (id > 0) id = 0;
            id--;
            ProyectoEvaluacionSectorialIndicadorCompose proyectoEvaluacionSectorialIndicadorCompose;
            proyectoEvaluacionSectorialIndicadorCompose = new ProyectoEvaluacionSectorialIndicadorCompose();
            proyectoEvaluacionSectorialIndicadorCompose.Indicador = new ProyectoEvaluacionSectorialIndicadorResult();
            proyectoEvaluacionSectorialIndicadorCompose.Indicador.IdProyectoEvaluacionSectorialIndicador = id;

            return proyectoEvaluacionSectorialIndicadorCompose;
        }

        public void toIndicadorClaseEvaluacionSectorial_OnValueChanged(object sender, EventArgs e)
        {
            litMontoRango.Visible = false;
            ravMonto.Enabled = false;
            if (toIndicadorClaseEvaluacionSectorial.ValueId.HasValue)
            {
                IndicadorClase indicadorClase = IndicadorClaseService.Current.GetById(toIndicadorClaseEvaluacionSectorial.ValueId.Value);

                int rangoInicial = 0;
                int rangoFinal = 0;

                if (indicadorClase.RangoInicial != null)
                    rangoInicial = (int)indicadorClase.RangoInicial;

                if (indicadorClase.RangoFinal != null)
                    rangoFinal = (int)indicadorClase.RangoFinal;

                if (rangoInicial > 0 || rangoFinal > 0)
                {
                    litMontoRango.Text = string.Format("Rango monto entre ({0} y {1})", rangoInicial, rangoFinal);
                    litMontoRango.Visible = true;
                    ravMonto.Enabled = true;
                    ravMonto.MinimumValue = rangoInicial.ToString();
                    ravMonto.MaximumValue = rangoFinal.ToString();
                }
            }
        }

        #region Commands
        void CommandIndicadoresEvaluacionSectorialEdit()
        {
            IndicadoresEvaluacionSectorialSetValue();
            ModalPopupExtenderIndicadoresEvaluacionSectorial.Show();
            upIndicadoresEvaluacionSectorialPopUp.Update();

        }
        void CommandIndicadoresEvaluacionSectorialSave()
        {
            IndicadoresEvaluacionSectorialGetValue();

            ProyectoEvaluacionSectorialIndicadorCompose pbic = (from l in Entity.IndicadoresEvaluacionSectorial
                                                      where l.Indicador.IdProyectoEvaluacionSectorialIndicador == ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.ID
                                                      select l).FirstOrDefault();

            if (pbic != null)
            {

                pbic.Indicador.Indicador_Observacion = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_Observacion;
                pbic.Indicador.IdIndicadorClase = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase;
                pbic.Indicador.Indirecto = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indirecto;
                pbic.Indicador.Valor = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Valor;
                pbic.Indicador.Indicador_IdMedioVerificacion = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_IdMedioVerificacion;
                pbic.Indicador.IndicadorClase_Nombre = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Nombre;
                pbic.Indicador.IndicadorClase_Sigla = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Sigla;
                pbic.Indicador.IndicadorClase_Unidad = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Unidad;
                pbic.Indicador.Indicador_MedioVerificacion = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_MedioVerificacion;
                //German 20140511 - Tarea 124
                //pbic.Indicador.IdIndicadorRubro = pbic.Indicador.IdIndicadorRubro;
                pbic.Indicador.IdIndicadorRubro = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorRubro;
                //FinGerman 20140511 - Tarea 124

            }
            else
            {

                Entity.IndicadoresEvaluacionSectorial.Add(ActualProyectoEvaluacionSectorialIndicadorCompose);
            }

            IndicadoresEvaluacionSectorialRefresh();
            IndicadoresEvaluacionSectorialClear();


        }
        void CommandIndicadoresEvaluacionSectorialDelete()
        {

            ProyectoEvaluacionSectorialIndicadorCompose pbic = (from l in Entity.IndicadoresEvaluacionSectorial
                                                      where l.Indicador.IdProyectoEvaluacionSectorialIndicador == ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.ID
                                                      select l).FirstOrDefault();

            Entity.IndicadoresEvaluacionSectorial.Remove(pbic);

            IndicadoresEvaluacionSectorialClear();
            IndicadoresEvaluacionSectorialRefresh();

        }
        #endregion

        #region Methods

        void HidePopUpIndicadoresEvaluacionSectorial()
        {
            ModalPopupExtenderIndicadoresEvaluacionSectorial.Hide();
        }
        void IndicadoresEvaluacionSectorialClear()
        {
            ActualProyectoEvaluacionSectorialIndicadorCompose = GetNewProyectoEvaluacionSectorialIndicadorCompose();


            UIHelper.Clear(txtObservacionesIndicadoresEvaluacionSectorial);
            //[AUTOINDICADOR]UIHelper.Clear(autoCmpIndicadorClaseEvaluacionSectorial);
            //German 01032014 - tarea 110
            UIHelper.Clear(toIndicadorClaseEvaluacionSectorial);
            //Fin German 01032014 - tarea 110
            UIHelper.Clear(chkIndirectoEvaluacionSectorial);
            UIHelper.Clear(ddlMedioVerificacionEvaluacionSectorial);
            UIHelper.Clear(txtMontoEvaluacionSectorial);
            int? idIndicadorRubro = null;
            if (toIndicadorClaseEvaluacionSectorial.Sectores.SelectedIndex >= 0)
                idIndicadorRubro = Convert.ToInt32(toIndicadorClaseEvaluacionSectorial.Sectores.SelectedValue);

            //[AUTOINDICADOR]autoCmpIndicadorClaseEvaluacionSectorial.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.EvaluacionSectorial, Activo = true };
            //German 01032014 - tarea 110
            toIndicadorClaseEvaluacionSectorial.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.EvaluacionSectorial, Activo = true };
            //solo por ahora - Ver pq no funciona
            //toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = null, Activo = true };
            //Fin German 01032014 - tarea 110
            upIndicadoresEvaluacionSectorialPopUp.Update();


        }
        void IndicadoresEvaluacionSectorialSetValue()
        {
            //[AUTOINDICADOR]UIHelper.SetValue(autoCmpIndicadorClaseEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.SetValue(toIndicadorClaseEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase);
            //FinGerman 01032014 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadorClaseEvaluacionSectorial.Sectores, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124            
            UIHelper.SetValue(chkIndirectoEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indirecto);
            UIHelper.SetValue(txtMontoEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Valor);
            UIHelper.SetValue(ddlMedioVerificacionEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadoresEvaluacionSectorial, ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_Observacion);
        }
        void IndicadoresEvaluacionSectorialGetValue()
        {

            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadoresEvaluacionSectorial);
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacionEvaluacionSectorial);
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indirecto = UIHelper.GetBoolean(chkIndirectoEvaluacionSectorial);
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Valor = UIHelper.GetInt(txtMontoEvaluacionSectorial);

            //[AUTOINDICADOR]ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClaseEvaluacionSectorial);
            //German 01032014 - tarea 110
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadorClaseEvaluacionSectorial);
            //FinGerman 01032014 - tarea 110
            //German 20140511 - Tarea 124
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorRubro = (UIHelper.GetIntNullable(toIndicadorClaseEvaluacionSectorial.Sectores) == null) ? 0 : UIHelper.GetIntNullable(toIndicadorClaseEvaluacionSectorial.Sectores).Value;
            //FinGerman 20140511 - Tarea 124

            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdIndicadorClase }).FirstOrDefault();

            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Sigla = result.Sigla;
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Nombre = result.Nombre;
            ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IndicadorClase_Unidad = result.Unidad_Nombre;

            if (ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_IdMedioVerificacion != null)
            {
                ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacionEvaluacionSectorial);
            }
            else
            {
                ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.Indicador_MedioVerificacion = string.Empty;
            }


        }
        void IndicadoresEvaluacionSectorialRefresh()
        {
            List<ProyectoEvaluacionSectorialIndicadorResult> indicadores = new List<ProyectoEvaluacionSectorialIndicadorResult>();
            Entity.IndicadoresEvaluacionSectorial.ForEach(i => indicadores.Add(i.Indicador));
            UIHelper.Load(gridIndicadoresEvaluacionSectorial, indicadores, "IndicadorClase_Nombre");
            upGridIndicadoresEvaluacionSectorial.Update();

        }
        #endregion Methods

        #region Eventos
        protected void btSaveIndicadorEvaluacionSectorial_Click(object sender, EventArgs e)
        {

            string msgError;
            if (ValidateIndicadoresEvaluacionSectorial(out  msgError))
            {

                CallTryMethod(CommandIndicadoresEvaluacionSectorialSave);
                HidePopUpIndicadoresEvaluacionSectorial();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresEvaluacionSectorialPopUp);
            }

        }
        protected void btNewIndicadorEvaluacionSectorial_Click(object sender, EventArgs e)
        {
            string msgError;
            if (ValidateIndicadoresEvaluacionSectorial(out  msgError))
            {
                CallTryMethod(CommandIndicadoresEvaluacionSectorialSave);
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresEvaluacionSectorialPopUp);
            }
        }
        protected void btCancelIndicadorEvaluacionSectorial_Click(object sender, EventArgs e)
        {
            IndicadoresEvaluacionSectorialClear();
            HidePopUpIndicadoresEvaluacionSectorial();
        }
        protected void btAgregarIndicadorEvaluacionSectorial_Click(object sender, EventArgs e)
        {
            IndicadoresEvaluacionSectorialClear();
            ModalPopupExtenderIndicadoresEvaluacionSectorial.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridIndicadoresEvaluacionSectorial_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEvaluacionSectorialIndicadorCompose = (from l in Entity.IndicadoresEvaluacionSectorial
                                                       where l.Indicador.IdProyectoEvaluacionSectorialIndicador == id
                                                       select l).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresEvaluacionSectorialEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresEvaluacionSectorialDelete();
                    break;
                case Command.SHOW_DETAILS:
                    //[Evolucion]ShowPopUpEvolucionesEvaluacionSectorial();
                    break;

            }


        }
        protected virtual void GridIndicadoresEvaluacionSectorial_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridIndicadoresEvaluacionSectorial.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadoresEvaluacionSectorial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridIndicadoresEvaluacionSectorial.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        void CargarMediosVerificacionEvaluacionSectorial()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacionEvaluacionSectorial, MedioVerificacionService.Current.GetList(),
                "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Selecione Medio" });
        }


        protected void ddlMedioVerificacionEvaluacionSectorial_IndexChanged(object sender, EventArgs e)
        {

        }
        protected void IndicadoresEvaluacionSectorial_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

        }

        private bool ValidateIndicadoresEvaluacionSectorial(out string msgError)
        {
            msgError = string.Empty;
            //[AUTOINDICADOR]int id = UIHelper.GetInt(autoCmpIndicadorClaseEvaluacionSectorial);

            //German 01032014 - tarea 110
            //[AUTOINDICADOR]if (autoCmpIndicadorClaseEvaluacionSectorial.Visible == false)
            int id = UIHelper.GetInt(toIndicadorClaseEvaluacionSectorial);
            //Fin German 01032014 - tarea 110 

            //Matias 20140521 - Tarea 124
            if (id == 0)
            {
                msgError = TranslateFormat("FieldIsNull", "Indicador");
                return false;
            }
            //FinMatias 20140521 - Tarea 124

            int idIndicador = ActualProyectoEvaluacionSectorialIndicadorCompose.Indicador.IdProyectoEvaluacionSectorialIndicador;

            if (Entity.IndicadoresEvaluacionSectorial.Where(p => (p.Indicador.IdProyectoEvaluacionSectorialIndicador != idIndicador) && (p.Indicador.IdIndicadorClase == id)).Count() > 0)
            {
                msgError = Translate("* No puede haber mas de un indicador de la misma clase.");
                return false;
            }
            return true;
        }


        #endregion

        #region Contribución al Objetivo de Gobierno (ex Indicadores ObjetivosGobierno)

        private ProyectoIndicadorObjetivosGobiernoResult actualProyectoIndicadorObjetivosGobierno;
        protected ProyectoIndicadorObjetivosGobiernoResult ActualProyectoIndicadorObjetivosGobierno
        {
            get
            {
                if (actualProyectoIndicadorObjetivosGobierno == null)
                    if (ViewState["actualProyectoIndicadorObjetivosGobierno"] != null)
                        actualProyectoIndicadorObjetivosGobierno = ViewState["actualProyectoIndicadorObjetivosGobierno"] as ProyectoIndicadorObjetivosGobiernoResult;
                    else
                    {
                        actualProyectoIndicadorObjetivosGobierno = GetNewProyectoIndicadorObjetivosGobierno();
                        ViewState["actualProyectoIndicadorObjetivosGobierno"] = actualProyectoIndicadorObjetivosGobierno;
                    }
                return actualProyectoIndicadorObjetivosGobierno;
            }
            set
            {
                actualProyectoIndicadorObjetivosGobierno = value;
                ViewState["actualProyectoIndicadorObjetivosGobierno"] = value;
            }
        }
        ProyectoIndicadorObjetivosGobiernoResult GetNewProyectoIndicadorObjetivosGobierno()
        {

            int id = 0;
            if (Entity.IndicadoresObjetivosGobierno.Count > 0) id = Entity.IndicadoresObjetivosGobierno.Min(l => l.IdProyectoIndicadorObjetivosGobierno);
            if (id > 0) id = 0;
            id--;
            ProyectoIndicadorObjetivosGobiernoResult proyectoIndicadorObjetivosGobiernoResult;
            proyectoIndicadorObjetivosGobiernoResult = new ProyectoIndicadorObjetivosGobiernoResult();
            proyectoIndicadorObjetivosGobiernoResult.IdProyectoIndicadorObjetivosGobierno = id;

            return proyectoIndicadorObjetivosGobiernoResult;
        }

        #region Commands
        void CommandIndicadoresObjetivosGobiernoEdit()
        {
            IndicadoresObjetivosGobiernoSetValue();
        }
        void CommandIndicadoresObjetivosGobiernoSave()
        {

            ProyectoIndicadorObjetivosGobiernoResult piep = (from l in Entity.IndicadoresObjetivosGobierno
                                                        where l.IdProyectoIndicadorObjetivosGobierno == ActualProyectoIndicadorObjetivosGobierno.ID
                                                        select l).FirstOrDefault();

            if (piep != null)
            {

                piep.Valor = ActualProyectoIndicadorObjetivosGobierno.Valor;
                piep.Anio = ActualProyectoIndicadorObjetivosGobierno.Anio;
                piep.Observacion = ActualProyectoIndicadorObjetivosGobierno.Observacion;
                piep.IdIndicadorClase = ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase;
                piep.IndicadorClase_Nombre = ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Nombre;
                piep.IndicadorClase_Sigla = ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Sigla;
                piep.IndicadorClase_Unidad = ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Unidad;
                piep.IndicadorClase_IdIndicadorTipo = ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_IdIndicadorTipo;

            }
            else
            {

                Entity.IndicadoresObjetivosGobierno.Add(ActualProyectoIndicadorObjetivosGobierno);                
            }

        }
        void CommandIndicadoresObjetivosGobiernoDelete()
        {

            ProyectoIndicadorObjetivosGobiernoResult piep = (from l in Entity.IndicadoresObjetivosGobierno
                                                     where l.IdProyectoIndicadorObjetivosGobierno == ActualProyectoIndicadorObjetivosGobierno.ID
                                                     select l).FirstOrDefault();

            Entity.IndicadoresObjetivosGobierno.Remove(piep);

        }
        #endregion

        #region Methods
        void IndicadoresObjetivosGobiernoClear()
        {
            int? idIndicadorRubro = null;
            if (toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedIndex >= 0)
                idIndicadorRubro = Convert.ToInt32(toIndicadoClaseEconomicoObjetivoGobierno.Sectores.SelectedValue);

            ActualProyectoIndicadorObjetivosGobierno = GetNewProyectoIndicadorObjetivosGobierno();
            //[AUTOINDICADOR]            autoCmpIndicadorClaseIndicadoresProyecto.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.ObjetivosGobierno, Activo = true };
            //German 01032014 - tarea 110
            toIndicadoClaseEconomicoObjetivoGobierno.Filter = new nc.IndicadorClaseFilter { IdIndicadorRubro = idIndicadorRubro, IdIndicadorTipo = (int)IndicadorTipoEnum.ObjetivosGobierno, Activo = true };
            //solo por ahora - Ver pq no funciona
            //toIndicadoClaseEconomicoObjetivoGobierno.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = null, Activo = true };
            //Fin German 01032014 - tarea 110
        }

        void IndicadoresObjetivosGobiernoSetValue()
        {
            VisibleValorIndicadoresProyecto(false); //No visibles para Contribución al Objetivo de Gobierno
            RequiredIndicadoresProyecto(false); //No Requeridos para Contribución al Objetivo de Gobierno

            //[AUTOINDICADOR]            UIHelper.SetValue(autoCmpIndicadorClaseIndicadoresProyecto, ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.SetValue(toIndicadoClaseEconomicoObjetivoGobierno, ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase);
            //Fin German 01032014 - tarea 110
            UIHelper.SetValue(txtValorIndicadoresProyecto, ActualProyectoIndicadorObjetivosGobierno.Valor);


            if(ActualProyectoIndicadorObjetivosGobierno.Anio != null)
            {
                ddlAnoIndicadoresProyecto.SelectedValue = ddlAnoIndicadoresProyecto.Items.FindByText(ActualProyectoIndicadorObjetivosGobierno.Anio.ToString()).Value;
            }
            //UIHelper.SetValue(ddlAnoIndicadoresProyecto, ActualProyectoIndicadorObjetivosGobierno.Anio);
            UIHelper.SetValue(txtObservacionesIndicadoresProyecto, ActualProyectoIndicadorObjetivosGobierno.Observacion);

        }
        
        void IndicadoresObjetivosGobiernoGetValue()
        {
            //[AUTOINDICADOR]            ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClaseIndicadoresProyecto);
            //German 01032014 - tarea 110
            ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase = UIHelper.GetInt(toIndicadoClaseEconomicoObjetivoGobierno);
            //Fin German 01032014 - tarea 110
            
            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualProyectoIndicadorObjetivosGobierno.IdIndicadorClase }).FirstOrDefault();


            ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Sigla = result.Sigla;
            ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Nombre = result.Nombre;
            ActualProyectoIndicadorObjetivosGobierno.IndicadorClase_Unidad = result.Unidad_Nombre;
            
            ActualProyectoIndicadorObjetivosGobierno.Valor = UIHelper.GetInt(txtValorIndicadoresProyecto);
            ActualProyectoIndicadorObjetivosGobierno.Anio = null;
            if (ddlAnoIndicadoresProyecto.SelectedIndex > 0)
            {
                ActualProyectoIndicadorObjetivosGobierno.Anio = Convert.ToInt32(UIHelper.GetString(ddlAnoIndicadoresProyecto));
            }
            ActualProyectoIndicadorObjetivosGobierno.Observacion = UIHelper.GetString(txtObservacionesIndicadoresProyecto);
                        
        }
        
        void IndicadoresObjetivosGobiernoRefresh()
        {
            UIHelper.Load(gridIndicadoresObjetivosGobierno, Entity.IndicadoresObjetivosGobierno, "IndicadorClase_Nombre");
            upGridIndicadoresObjetivosGobierno.Update();
        }
        #endregion Methods

        #region Eventos
        protected void btAgregarIndicadorObjetivosGobierno_Click(object sender, EventArgs e)
        {
            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.ObjetivosGobierno;
            VisibleValorIndicadoresProyecto(false); //No visibles para Contribución al Objetivo de Gobierno
            RequiredIndicadoresProyecto(false); //No Requeridos para Contribución al Objetivo de Gobierno
            IndicadoresProyectoClear();
            ModalPopupExtenderIndicadoresProyecto.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridIndicadoresObjetivosGobierno_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.ObjetivosGobierno;
            IndicadoresProyectoClear();
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoIndicadorObjetivosGobierno = (from l in Entity.IndicadoresObjetivosGobierno
                                                    where l.IdProyectoIndicadorObjetivosGobierno == id
                                                    select l).FirstOrDefault();

            ModificandoProyectoIndicadores = ModifyProyectoIndicadores.ObjetivosGobierno;

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresProyectoEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresProyectoDelete();
                    break;
            }

        }
        protected virtual void GridIndicadoresObjetivosGobierno_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridIndicadoresObjetivosGobierno.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadoresObjetivosGobierno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridIndicadoresObjetivosGobierno.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion
        
        #endregion

        #region Indicadores Economicos / ObjetivosGobierno - COMUN

        private enum ModifyProyectoIndicadores { Economico, ObjetivosGobierno }
        private ModifyProyectoIndicadores ModificandoProyectoIndicadores
        {
            get { return (ModifyProyectoIndicadores)ViewState["ModifyProyectoIndicadores"]; }
            set { ViewState["ModifyProyectoIndicadores"] = value; }

        }

        #region Commands
        void CommandIndicadoresProyectoEdit()
        {

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    CommandIndicadoresEconomicoEdit();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    CommandIndicadoresObjetivosGobiernoEdit();
                    break;
                default:
                    break;
            }

            ModalPopupExtenderIndicadoresProyecto.Show();
            upIndicadoresProyectoPopUp.Update();

        }
        void CommandIndicadoresProyectoSave()
        {

            //IndicadoresProyectoGetValue();

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    CommandIndicadoresEconomicoSave();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    CommandIndicadoresObjetivosGobiernoSave();
                    break;
                default:
                    break;
            }

            IndicadoresProyectoRefresh();
            IndicadoresProyectoClear();

        }
        void CommandIndicadoresProyectoDelete()
        {

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    CommandIndicadoresEconomicoDelete();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    CommandIndicadoresObjetivosGobiernoDelete();
                    break;
                default:
                    break;
            }

            IndicadoresProyectoClear();
            IndicadoresProyectoRefresh();


        }
        #endregion

        #region Events
        protected void btSaveIndicadorProyecto_Click(object sender, EventArgs e)
        {

            string msgError;
            IndicadoresProyectoGetValue();
            if (ValidateIndicadoresProyecto(out  msgError))
            {

                CallTryMethod(CommandIndicadoresProyectoSave);
                HidePopUpIndicadoresProyecto();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresProyectoPopUp);   
            }           
        }
        protected void btNewIndicadorProyecto_Click(object sender, EventArgs e)
        {
            string msgError;
            IndicadoresProyectoGetValue();
            if (ValidateIndicadoresProyecto(out msgError))
            {

                CallTryMethod(CommandIndicadoresProyectoSave);
            }
            else
            {

                UIHelper.ShowAlert(msgError, upIndicadoresProyectoPopUp);
            }            
        }
        protected void btCancelIndicadorProyecto_Click(object sender, EventArgs e)
        {
            IndicadoresProyectoClear();
            HidePopUpIndicadoresProyecto();
        }
        protected void IndicadoresProyecto_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
        }
        
        #endregion

        #region Methods
        void RequiredIndicadoresProyecto(bool isRequired)
        {
            rfvValorIndicadoresProyecto.Enabled = isRequired;
            rfvAnoIndicadoresProyecto.Enabled = isRequired;
        }
        void VisibleValorIndicadoresProyecto(bool valorVisible)
        {
            txtValorIndicadoresProyecto.Visible = valorVisible;
            ltValorIndicadoresProyecto.Visible = valorVisible;
            trValorIndicadoresProyectoLiteral.Visible = valorVisible;
            trValorIndicadoresProyectoTextBox.Visible = valorVisible;
        }
        void HidePopUpIndicadoresProyecto()
        {
            ModalPopupExtenderIndicadoresProyecto.Hide();
        }
        void IndicadoresProyectoClear()
        {

            UIHelper.Clear(txtObservacionesIndicadoresProyecto);
            UIHelper.Clear(ddlAnoIndicadoresProyecto);
            UIHelper.Clear(txtValorIndicadoresProyecto);
            //[AUTOINDICADOR]           UIHelper.Clear(autoCmpIndicadorClaseIndicadoresProyecto);
            //German 01032014 - tarea 110
            UIHelper.Clear(toIndicadoClaseEconomicoObjetivoGobierno);
            //Fin German 01032014 - tarea 110

            //*** ATENCION esto debe ser despues que los otros clear ya que setea el tipo de indicador**//
            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    IndicadoresEconomicoClear();
                    ltObservacionesIndicadoresProyecto.Text = "Criterios de Evaluación";
                    headerPopUpIndicadoresProyecto.Text = "Indicador de Evaluación Económica";
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    IndicadoresObjetivosGobiernoClear();
                    ltObservacionesIndicadoresProyecto.Text = "Observaciones";
                    headerPopUpIndicadoresProyecto.Text = "Contribución al Objetivo de Gobierno";
                    break;
                default:
                    break;
            }

            upIndicadoresProyectoPopUp.Update();

        }
        void IndicadoresProyectoSetValue()
        {

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    IndicadoresEconomicoSetValue();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    IndicadoresObjetivosGobiernoSetValue();
                    break;
                default:
                    break;
            }

        }
        void IndicadoresProyectoGetValue()
        {

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    IndicadoresEconomicoGetValue();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    IndicadoresObjetivosGobiernoGetValue();
                    break;
                default:
                    break;
            }

        }
        void IndicadoresProyectoRefresh()
        {

            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    IndicadoresEconomicoRefresh();
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    IndicadoresObjetivosGobiernoRefresh();
                    break;
                default:
                    break;
            }
        }
        #endregion Methods


        private bool ValidateIndicadoresProyecto(out string msgError)
        {
            msgError = string.Empty;

            //[AUTOINDICADOR]           int id = UIHelper.GetInt(autoCmpIndicadorClaseIndicadoresProyecto);
            //German 01032014 - tarea 110
            //[AUTOINDICADOR]        if (autoCmpIndicadorClaseIndicadoresProyecto.Visible == false)
            int id = UIHelper.GetInt(toIndicadoClaseEconomicoObjetivoGobierno);
            //Fin German 01032014 - tarea 110
            if (id == 0)
            {
                msgError = TranslateFormat("FieldIsNull", "Indicador");
                return false;
            }

            IndicadorClase indicadorClase = IndicadorClaseService.Current.GetById(id);
            
            int rangoInicial = 0;
            int rangoFinal = 0;
            
            if(indicadorClase.RangoInicial != null) 
                rangoInicial = (int)indicadorClase.RangoInicial;

            if (indicadorClase.RangoFinal != null)
                rangoFinal = (int)indicadorClase.RangoFinal;



            int idIndicador = 0;
            switch (ModificandoProyectoIndicadores)
            {
                case ModifyProyectoIndicadores.Economico:
                    idIndicador = ActualProyectoIndicadorEconomico.IdProyectoIndicadorEconomico;
                    if (Entity.IndicadoresEconomico.Where(p => (p.IdProyectoIndicadorEconomico != idIndicador) && (p.IdIndicadorClase == id)).Count() > 0)            
                    {
                        msgError = Translate("- No puede haber mas de un indicador de la misma clase.");
                        return false;
                    }
                    if ((rangoInicial > 0 && rangoFinal > 0) && (rangoInicial <= rangoFinal))
                    {
                        if (ActualProyectoIndicadorEconomico.Valor < rangoInicial && ActualProyectoIndicadorEconomico.Valor > rangoFinal)
                        {
                            msgError = Translate(string.Format("- El valor del indicador esta fuera del rango permitido. Mínimo: {0} Máximo: {1}", rangoInicial, rangoFinal));
                            return false;
                        }
                    }
                    break;
                case ModifyProyectoIndicadores.ObjetivosGobierno:
                    idIndicador = ActualProyectoIndicadorObjetivosGobierno.IdProyectoIndicadorObjetivosGobierno;
                    if (Entity.IndicadoresObjetivosGobierno.Where(p => (p.IdProyectoIndicadorObjetivosGobierno != idIndicador) && (p.IdIndicadorClase == id)).Count() > 0)            
                    {
                        msgError = Translate("- No puede haber mas de un indicador de la misma clase.");
                        return false;
                    }
                    if ((rangoInicial > 0 && rangoFinal > 0) && (rangoInicial <= rangoFinal))
                    {
                        if (ActualProyectoIndicadorObjetivosGobierno.Valor < rangoInicial || ActualProyectoIndicadorObjetivosGobierno.Valor > rangoFinal)
                        {
                            msgError = Translate(string.Format("- El valor del indicador esta fuera del rango permitido. Mínimo: {0} Máximo: {1}", rangoInicial, rangoFinal));
                            return false;
                        }
                    }
                    break;
                default:
                    break;
            }


            return true;
        }


        #endregion

        /*
        #region Evoluciones Beneficiarios
        private enum PopPupState { Adding, Modifying }
        private PopPupState EvolucionesPopPupState
        {
            get { return (PopPupState)ViewState["EvolucionesPopPupState"]; }
            set { ViewState["EvolucionesPopPupState"] = value; }

        }	
        private IndicadorEvolucionResult actualIndicadorEvolucionBeneficiario;
        protected IndicadorEvolucionResult ActualIndicadorEvolucionBeneficiario
        {
            get
            {
                if (actualIndicadorEvolucionBeneficiario == null)
                    if (ViewState["actualIndicadorEvolucionBeneficiario"] != null)
                        actualIndicadorEvolucionBeneficiario = ViewState["actualIndicadorEvolucionBeneficiario"] as IndicadorEvolucionResult;
                    else
                    {
                        actualIndicadorEvolucionBeneficiario = GetNewEvolucionBeneficiario();
                        ViewState["actualIndicadorEvolucionBeneficiario"] = actualIndicadorEvolucionBeneficiario;
                    }
                return actualIndicadorEvolucionBeneficiario;
            }
            set
            {
                actualIndicadorEvolucionBeneficiario = value;
                ViewState["actualIndicadorEvolucionBeneficiario"] = value;
            }
        }
        IndicadorEvolucionResult GetNewEvolucionBeneficiario()
        {
            int id = 0;
            if (ActualProyectoBeneficiarioIndicadorCompose.Evoluciones.Count > 0) id = ActualProyectoBeneficiarioIndicadorCompose.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            return indicadorEvolucionResult;

        }

        #region Methods
        void HidePopUpEvolucionesBeneficiario()
        {
            ModalPopupExtenderEvolucionesBeneficiario.Hide();
        }
        void ShowPopUpEvolucionesBeneficiario()
        {
          
            EvolucionesBeneficiarioRefresh();
            btNewEvolucionBeneficiario.Enabled = true;
            btSaveEvolucionBeneficiario.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            lblTituloEvolucionesBeneficiario.Text = ActualProyectoBeneficiarioIndicadorCompose.Indicador.Beneficiario;
            upEvolucionesBeneficiarioPopUp.Update();
            ModalPopupExtenderEvolucionesBeneficiario.Show();
        }
        void EvolucionesBeneficiarioClear(bool entradaContinua)
        {
            if (!entradaContinua)
            UIHelper.Clear(tsEvolucionBeneficiario as IWebControlTreeSelect);
            UIHelper.Clear(ddlTipoEvolucionBeneficiario);
            UIHelper.Clear(diFechaEstimadaEvolucionBeneficiario);
            UIHelper.Clear(txtCantidadEstimadaEvolucionBeneficiario);
            UIHelper.Clear(diFechaRealizadaEvolucionBeneficiario);
            UIHelper.Clear(txtCantidadRealizadaEvolucionBeneficiario);

            ActualIndicadorEvolucionBeneficiario = GetNewEvolucionBeneficiario();
        }
        void EvolucionesBeneficiarioSetValue()
        {

            UIHelper.SetValue(tsEvolucionBeneficiario as IWebControlTreeSelect, ActualIndicadorEvolucionBeneficiario.IdClasificacionGeografica);
            UIHelper.SetValue(ddlTipoEvolucionBeneficiario, ActualIndicadorEvolucionBeneficiario.IdIndicadorEvolucionInstancia);
            UIHelper.SetValue(diFechaEstimadaEvolucionBeneficiario, ActualIndicadorEvolucionBeneficiario.FechaEstimada);
            UIHelper.SetValue(txtCantidadEstimadaEvolucionBeneficiario, ActualIndicadorEvolucionBeneficiario.CantidadEstimada);
            UIHelper.SetValue(diFechaRealizadaEvolucionBeneficiario, ActualIndicadorEvolucionBeneficiario.FechaReal);
            UIHelper.SetValue(txtCantidadRealizadaEvolucionBeneficiario, ActualIndicadorEvolucionBeneficiario.CantidadReal);
        }
        void EvolucionesBeneficiarioGetValue()
        {
            ActualIndicadorEvolucionBeneficiario.IdClasificacionGeografica = UIHelper.GetInt(tsEvolucionBeneficiario as IWebControlTreeSelect);
            ActualIndicadorEvolucionBeneficiario.IdIndicadorEvolucionInstancia = UIHelper.GetInt(ddlTipoEvolucionBeneficiario);
            ActualIndicadorEvolucionBeneficiario.FechaEstimada = UIHelper.GetDateTime(diFechaEstimadaEvolucionBeneficiario);
            ActualIndicadorEvolucionBeneficiario.CantidadEstimada = UIHelper.GetDecimal(txtCantidadEstimadaEvolucionBeneficiario);
            ActualIndicadorEvolucionBeneficiario.FechaReal = UIHelper.GetDateTimeNullable(diFechaRealizadaEvolucionBeneficiario);
            ActualIndicadorEvolucionBeneficiario.CantidadReal = UIHelper.GetDecimalNullable(txtCantidadRealizadaEvolucionBeneficiario);
            ActualIndicadorEvolucionBeneficiario.ClasificacionGeografica_Descripcion = UIHelper.GetNodeResult(tsEvolucionBeneficiario as IWebControlTreeSelect).Descripcion;
            ActualIndicadorEvolucionBeneficiario.IndicadorEvolucionInstancia_Nombre = UIHelper.GetString(ddlTipoEvolucionBeneficiario);
        }
        void EvolucionesBeneficiarioRefresh()
        {
                var f = from d in ActualProyectoBeneficiarioIndicadorCompose.Evoluciones
            orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
            select d;

            UIHelper.Load(gridEvolucionesBeneficiario, f.ToList());
            upGridEvolucionesBeneficiario.Update();

        }
        #endregion Methods

        #region Eventos

        protected void btSaveEvolucionBeneficiario_Click(object sender, EventArgs e)
        {
            if (EvolucionesPopPupState == PopPupState.Adding)
            {
                CallTryMethod(CommandEvolucionBeneficiarioSave);
            }
            else
            {

                EvolucionesBeneficiarioClear(false);
                EvolucionesBeneficiarioRefresh();
                btNewEvolucionBeneficiario.Text = Translate("Agregar");
                btCancelEvolucionBeneficiario.Enabled = true;
                btSaveEvolucionBeneficiario.Enabled = false;
                EvolucionesPopPupState = PopPupState.Adding;
                upEvolucionesBeneficiarioPopUp.Update();

            }

        }
        protected void btNewEvolucionBeneficiario_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandEvolucionBeneficiarioSave);
        }
        protected void btCancelEvolucionBeneficiario_Click(object sender, EventArgs e)
        {
            string msgError = string.Empty;
            if (ValidatorEvolucion.ValidateEvoluciones(ActualProyectoBeneficiarioIndicadorCompose.Evoluciones, out msgError))
            {
                EvolucionesBeneficiarioClear(false);

                ProyectoBeneficiarioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficiario
                                                             where l.Indicador.IdProyectoBeneficiarioIndicador == ActualProyectoBeneficiarioIndicadorCompose.Indicador.ID
                                                             select l).FirstOrDefault();

                pbic.Evoluciones = ActualProyectoBeneficiarioIndicadorCompose.Evoluciones;
                
                
                HidePopUpEvolucionesBeneficiario();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upEvolucionesBeneficiarioPopUp);
            }

        }
        protected void btAgregarEvolucionBeneficiario_Click(object sender, EventArgs e)
        {            
            ModalPopupExtenderEvolucionesBeneficiario.Show();
            tsEvolucionBeneficiario.Focus();
        }

        #endregion

        #region Commands
        void CommandEvolucionBeneficiarioEdit()
        {

            EvolucionesBeneficiarioSetValue();
            btNewEvolucionBeneficiario.Text = Translate("Cancelar");
            btSaveEvolucionBeneficiario.Enabled = true;
            btCancelEvolucionBeneficiario.Enabled = false;
            EvolucionesPopPupState = PopPupState.Modifying;
            upEvolucionesBeneficiarioPopUp.Update();


        }
        void CommandEvolucionBeneficiarioSave()
        {

            EvolucionesBeneficiarioGetValue();

            IndicadorEvolucionResult ier = (from l in ActualProyectoBeneficiarioIndicadorCompose.Evoluciones
                                            where l.IdIndicadorEvolucion == ActualIndicadorEvolucionBeneficiario.ID
                                            select l).FirstOrDefault();

            if (ier != null)
            {

                ier.IdClasificacionGeografica = ActualIndicadorEvolucionBeneficiario.IdClasificacionGeografica;
                ier.ClasificacionGeografica_Descripcion = ActualIndicadorEvolucionBeneficiario.ClasificacionGeografica_Descripcion;
                ier.IdIndicadorEvolucionInstancia = ActualIndicadorEvolucionBeneficiario.IdIndicadorEvolucionInstancia;
                ier.IndicadorEvolucionInstancia_Nombre = ActualIndicadorEvolucionBeneficiario.IndicadorEvolucionInstancia_Nombre;
                ier.FechaEstimada = ActualIndicadorEvolucionBeneficiario.FechaEstimada;
                ier.CantidadEstimada = ActualIndicadorEvolucionBeneficiario.CantidadEstimada;
                ier.FechaReal = ActualIndicadorEvolucionBeneficiario.FechaReal;
                ier.CantidadReal = ActualIndicadorEvolucionBeneficiario.CantidadReal;
                EvolucionesBeneficiarioClear(false);

            }
            else
            {
                ActualProyectoBeneficiarioIndicadorCompose.Evoluciones.Add(ActualIndicadorEvolucionBeneficiario);
                EvolucionesBeneficiarioClear(true);
            }



            
            EvolucionesBeneficiarioRefresh();
            btNewEvolucionBeneficiario.Text = Translate("Agregar");
            btCancelEvolucionBeneficiario.Enabled = true;
            btSaveEvolucionBeneficiario.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            upEvolucionesBeneficiarioPopUp.Update();


        }
        void CommandEvolucionBeneficiarioDelete()
        {

            IndicadorEvolucionResult result = (from l in ActualProyectoBeneficiarioIndicadorCompose.Evoluciones
                                               where l.IdIndicadorEvolucion == ActualIndicadorEvolucionBeneficiario.ID
                                             select l).FirstOrDefault();

            ActualProyectoBeneficiarioIndicadorCompose.Evoluciones.Remove(result);

            EvolucionesBeneficiarioClear(false);
            EvolucionesBeneficiarioRefresh();

        }
        #endregion

        #region EventosGrillas
        protected void GridEvolucionesBeneficiario_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;


            ActualIndicadorEvolucionBeneficiario = (from l in ActualProyectoBeneficiarioIndicadorCompose.Evoluciones
                                                    where l.IdIndicadorEvolucion == id
                                                    select l).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandEvolucionBeneficiarioEdit();
                    break;
                case Command.DELETE:
                    CommandEvolucionBeneficiarioDelete();
                    break;
            }

        }
        protected virtual void GridEvolucionesBeneficiario_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridEvolucionesBeneficiario.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridEvolucionesBeneficiario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridEvolucionesBeneficiario.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        void CargarIndicadorEvolucionBeneficiarioInstancia()
        {

            nc.IndicadorEvolucionInstanciaFilter indicadorEvolucionInstanciaFilter = new nc.IndicadorEvolucionInstanciaFilter();
            indicadorEvolucionInstanciaFilter.OrderBys.Add(new FilterOrderBy("IdIndicadorEvolucionInstancia"));
            UIHelper.Load<IndicadorEvolucionInstancia>(ddlTipoEvolucionBeneficiario, IndicadorEvolucionInstanciaService.Current.GetList(indicadorEvolucionInstanciaFilter),
                "Nombre", "IdIndicadorEvolucionInstancia", new IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = 0, Nombre = "Selecione Tipo" }, false);          

        }

        #endregion Evoluciones Beneficiarios

        #region Evoluciones Beneficios

        private IndicadorEvolucionResult actualIndicadorEvolucionBeneficio;
        protected IndicadorEvolucionResult ActualIndicadorEvolucionBeneficio
        {
            get
            {
                if (actualIndicadorEvolucionBeneficio == null)
                    if (ViewState["actualIndicadorEvolucionBeneficio"] != null)
                        actualIndicadorEvolucionBeneficio = ViewState["actualIndicadorEvolucionBeneficio"] as IndicadorEvolucionResult;
                    else
                    {
                        actualIndicadorEvolucionBeneficio = GetNewEvolucionBeneficio();
                        ViewState["actualIndicadorEvolucionBeneficio"] = actualIndicadorEvolucionBeneficio;
                    }
                return actualIndicadorEvolucionBeneficio;
            }
            set
            {
                actualIndicadorEvolucionBeneficio = value;
                ViewState["actualIndicadorEvolucionBeneficio"] = value;
            }
        }
        IndicadorEvolucionResult GetNewEvolucionBeneficio()
        {
            int id = 0;
            if (ActualProyectoBeneficioIndicadorCompose.Evoluciones.Count > 0) id = ActualProyectoBeneficioIndicadorCompose.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            return indicadorEvolucionResult;

        }

        #region Methods
        void HidePopUpEvolucionesBeneficio()
        {
            ModalPopupExtenderEvolucionesBeneficio.Hide();
        }
        void ShowPopUpEvolucionesBeneficio()
        {
            EvolucionesBeneficioRefresh();
            btNewEvolucionBeneficio.Enabled = true;
            btSaveEvolucionBeneficio.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            lblTituloEvolucionesBeneficio.Text = ActualProyectoBeneficioIndicadorCompose.Indicador.IndicadorClase_Nombre;
            upEvolucionesBeneficioPopUp.Update();
            ModalPopupExtenderEvolucionesBeneficio.Show();
        }
        void EvolucionesBeneficioClear(bool entradaContinua)
        {
            if(!entradaContinua)
            UIHelper.Clear(tsEvolucionBeneficio as IWebControlTreeSelect);
            UIHelper.Clear(ddlTipoEvolucionBeneficio);
            UIHelper.Clear(diFechaEstimadaEvolucionBeneficio);
            UIHelper.Clear(txtCantidadEstimadaEvolucionBeneficio);
            UIHelper.Clear(txtPrecioUnitarioEstimadoEvolucionBeneficio);
            UIHelper.Clear(diFechaRealizadaEvolucionBeneficio);
            UIHelper.Clear(txtCantidadRealizadaEvolucionBeneficio);
            UIHelper.Clear(txtPrecioUnitarioRealizadoEvolucionBeneficio);
            UIHelper.Clear(lblMontoEstimadoEvolucionBeneficio);
            UIHelper.Clear(lblMontoRealizadoEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio = GetNewEvolucionBeneficio();
        }
        void EvolucionesBeneficioSetValue()
        {

            UIHelper.SetValue(tsEvolucionBeneficio as IWebControlTreeSelect, ActualIndicadorEvolucionBeneficio.IdClasificacionGeografica);
            UIHelper.SetValue(ddlTipoEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.IdIndicadorEvolucionInstancia);
            UIHelper.SetValue(diFechaEstimadaEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.FechaEstimada);
            UIHelper.SetValue(txtCantidadEstimadaEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.CantidadEstimada);
            UIHelper.SetValue(txtPrecioUnitarioEstimadoEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado);
            UIHelper.SetValue(diFechaRealizadaEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.FechaReal);
            UIHelper.SetValue(txtCantidadRealizadaEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.CantidadReal);
            UIHelper.SetValue(txtPrecioUnitarioRealizadoEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal);
            UIHelper.SetValue(lblMontoEstimadoEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.MontoEstimadoCalc);
            UIHelper.SetValue(lblMontoRealizadoEvolucionBeneficio, ActualIndicadorEvolucionBeneficio.MontoRealizadoCalc);
        }
        void EvolucionesBeneficioGetValue()
        {
            ActualIndicadorEvolucionBeneficio.IdClasificacionGeografica = UIHelper.GetInt(tsEvolucionBeneficio as IWebControlTreeSelect);
            ActualIndicadorEvolucionBeneficio.IdIndicadorEvolucionInstancia = UIHelper.GetInt(ddlTipoEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.FechaEstimada = UIHelper.GetDateTime(diFechaEstimadaEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.CantidadEstimada = UIHelper.GetDecimal(txtCantidadEstimadaEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado = UIHelper.GetDecimalNullable(txtPrecioUnitarioEstimadoEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.FechaReal = UIHelper.GetDateTimeNullable(diFechaRealizadaEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.CantidadReal = UIHelper.GetDecimalNullable(txtCantidadRealizadaEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal = UIHelper.GetDecimalNullable(txtPrecioUnitarioRealizadoEvolucionBeneficio);
            ActualIndicadorEvolucionBeneficio.ClasificacionGeografica_Descripcion = UIHelper.GetNodeResult(tsEvolucionBeneficio as IWebControlTreeSelect).Descripcion;
            ActualIndicadorEvolucionBeneficio.IndicadorEvolucionInstancia_Nombre = UIHelper.GetString(ddlTipoEvolucionBeneficio);

            if ((ActualIndicadorEvolucionBeneficio.CantidadEstimada != null) && (ActualIndicadorEvolucionBeneficio.CantidadEstimada > 0) &&
                (ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado != null) && (ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado > 0))
            {
                ActualIndicadorEvolucionBeneficio.MontoEstimadoCalc = ActualIndicadorEvolucionBeneficio.CantidadEstimada * ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado;
            }

            if ((ActualIndicadorEvolucionBeneficio.CantidadReal != null) && (ActualIndicadorEvolucionBeneficio.CantidadReal > 0) &&
                (ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal != null) && (ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal > 0))
            {
                ActualIndicadorEvolucionBeneficio.MontoRealizadoCalc = ActualIndicadorEvolucionBeneficio.CantidadReal * ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal;
            }
            
            //ActualIndicadorEvolucionBeneficio.MontoEstimadoCalc = UIHelper.GetDecimal(lblMontoEstimadoEvolucionBeneficio);
            //ActualIndicadorEvolucionBeneficio.MontoRealizadoCalc = UIHelper.GetDecimal(lblMontoRealizadoEvolucionBeneficio);
        }


        void EvolucionesBeneficioRefresh()
        {

            var f = from d in ActualProyectoBeneficioIndicadorCompose.Evoluciones
                    orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
                    select d;

            UIHelper.Load(gridEvolucionesBeneficio, f.ToList());
            upGridEvolucionesBeneficio.Update();

        }
        #endregion Methods

        #region Eventos

        protected void btSaveEvolucionBeneficio_Click(object sender, EventArgs e)
        {

            if (EvolucionesPopPupState == PopPupState.Adding)
            {
                CallTryMethod(CommandEvolucionBeneficioSave);
            }
            else
            {

                EvolucionesBeneficioClear(false);
                EvolucionesBeneficioRefresh();
                btNewEvolucionBeneficio.Text = Translate("Agregar");
                btCancelEvolucionBeneficiario.Enabled = true;
                btSaveEvolucionBeneficiario.Enabled = false;
                EvolucionesPopPupState = PopPupState.Adding;
                upEvolucionesBeneficiarioPopUp.Update();

            }

            
        }
        protected void btNewEvolucionBeneficio_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandEvolucionBeneficioSave);
        }
        protected void btCancelEvolucionBeneficio_Click(object sender, EventArgs e)
        {
            string msgError = string.Empty;
            if (ValidatorEvolucion.ValidateEvoluciones(ActualProyectoBeneficioIndicadorCompose.Evoluciones, out msgError))
            {
                EvolucionesBeneficioClear(false);

                ProyectoBeneficioIndicadorCompose pbic = (from l in Entity.IndicadoresBeneficio
                                                          where l.Indicador.IdProyectoBeneficioIndicador == ActualProyectoBeneficioIndicadorCompose.Indicador.ID
                                                          select l).FirstOrDefault();

                pbic.Evoluciones = ActualProyectoBeneficioIndicadorCompose.Evoluciones;


                HidePopUpEvolucionesBeneficio();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upEvolucionesBeneficioPopUp);
            }

        }
        protected void btAgregarEvolucionBeneficio_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderEvolucionesBeneficio.Show();
            tsEvolucionBeneficio.Focus();
        }

        #endregion

        #region Commands
        void CommandEvolucionBeneficioEdit()
        {

            EvolucionesBeneficioSetValue();
            btNewEvolucionBeneficio.Text = Translate("Cancelar");
            btSaveEvolucionBeneficio.Enabled = true;
            btCancelEvolucionBeneficio.Enabled = false;
            EvolucionesPopPupState = PopPupState.Modifying;
            upEvolucionesBeneficioPopUp.Update();

        }
        void CommandEvolucionBeneficioSave()
        {

            EvolucionesBeneficioGetValue();

            IndicadorEvolucionResult ier = (from l in ActualProyectoBeneficioIndicadorCompose.Evoluciones
                                            where l.IdIndicadorEvolucion == ActualIndicadorEvolucionBeneficio.ID
                                            select l).FirstOrDefault();

            if (ier != null)
            {

                ier.IdClasificacionGeografica = ActualIndicadorEvolucionBeneficio.IdClasificacionGeografica;
                ier.ClasificacionGeografica_Descripcion = ActualIndicadorEvolucionBeneficio.ClasificacionGeografica_Descripcion;
                ier.IdIndicadorEvolucionInstancia = ActualIndicadorEvolucionBeneficio.IdIndicadorEvolucionInstancia;
                ier.IndicadorEvolucionInstancia_Nombre = ActualIndicadorEvolucionBeneficio.IndicadorEvolucionInstancia_Nombre;
                ier.FechaEstimada = ActualIndicadorEvolucionBeneficio.FechaEstimada;
                ier.CantidadEstimada = ActualIndicadorEvolucionBeneficio.CantidadEstimada;
                ier.PrecioUnitarioEstimado = ActualIndicadorEvolucionBeneficio.PrecioUnitarioEstimado;
                ier.FechaReal = ActualIndicadorEvolucionBeneficio.FechaReal;
                ier.CantidadReal = ActualIndicadorEvolucionBeneficio.CantidadReal;
                ier.PrecioUnitarioReal = ActualIndicadorEvolucionBeneficio.PrecioUnitarioReal;
                ier.MontoRealizadoCalc = ActualIndicadorEvolucionBeneficio.MontoRealizadoCalc;
                ier.MontoEstimadoCalc = ActualIndicadorEvolucionBeneficio.MontoEstimadoCalc;
                EvolucionesBeneficioClear(false);
            }
            else
            {
                ActualProyectoBeneficioIndicadorCompose.Evoluciones.Add(ActualIndicadorEvolucionBeneficio);
                EvolucionesBeneficioClear(true);
            }



            
            EvolucionesBeneficioRefresh();
            btNewEvolucionBeneficio.Text = Translate("Agregar");
            btCancelEvolucionBeneficio.Enabled = true;
            btSaveEvolucionBeneficio.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            upEvolucionesBeneficioPopUp.Update();


        }
        void CommandEvolucionBeneficioDelete()
        {

            IndicadorEvolucionResult result = (from l in ActualProyectoBeneficioIndicadorCompose.Evoluciones
                                               where l.IdIndicadorEvolucion == ActualIndicadorEvolucionBeneficio.ID
                                               select l).FirstOrDefault();

            ActualProyectoBeneficioIndicadorCompose.Evoluciones.Remove(result);

            EvolucionesBeneficioClear(false);
            EvolucionesBeneficioRefresh();

        }
        #endregion

        #region EventosGrillas
        protected void GridEvolucionesBeneficio_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;


            ActualIndicadorEvolucionBeneficio = (from l in ActualProyectoBeneficioIndicadorCompose.Evoluciones
                                                 where l.IdIndicadorEvolucion == id
                                                 select l).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandEvolucionBeneficioEdit();
                    break;
                case Command.DELETE:
                    CommandEvolucionBeneficioDelete();
                    break;
            }

        }
        protected virtual void GridEvolucionesBeneficio_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridEvolucionesBeneficio.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridEvolucionesBeneficio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridEvolucionesBeneficio.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        void CargarIndicadorEvolucionBeneficioInstancia()
        {

            nc.IndicadorEvolucionInstanciaFilter indicadorEvolucionInstanciaFilter = new nc.IndicadorEvolucionInstanciaFilter();
            indicadorEvolucionInstanciaFilter.OrderBys.Add(new FilterOrderBy("IdIndicadorEvolucionInstancia"));
            UIHelper.Load<IndicadorEvolucionInstancia>(ddlTipoEvolucionBeneficio, IndicadorEvolucionInstanciaService.Current.GetList(indicadorEvolucionInstanciaFilter),
                "Nombre", "IdIndicadorEvolucionInstancia", new IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = 0, Nombre = "Selecione Tipo" }, false);          

        }

        #endregion Evoluciones Beneficios
        */

    }
}