using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web.Pages
{
    public partial class ProyectoPrincipiosEdit : WebControlEdit<nc.ProyectoPrincipiosFormulacionCompose>
    {
         
        #region Override WebControlEdit
              

        protected override void _Initialize()
        {
            base._Initialize();
            revNecesidadASatisfacer.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revNecesidadASatisfacer.ErrorMessage = TranslateFormat("FieldInvalidLength", "Necesidad a satisfacer (2000 caractéres máx.)");
            if (!IsPostBack)
            {
                txtNecesidadASatisfacer.Attributes.Add("maxlength", txtNecesidadASatisfacer.MaxLength.ToString());
                txtObjetivoDelProyecto.Attributes.Add("maxlength", txtObjetivoDelProyecto.MaxLength.ToString());
                txtProductoOServicio.Attributes.Add("maxlength", txtProductoOServicio.MaxLength.ToString());
                txtAlternativas.Attributes.Add("maxlength", txtAlternativas.MaxLength.ToString());
                txtPorqueAlternativa.Attributes.Add("maxlength", txtPorqueAlternativa.MaxLength.ToString());
                txtDescripcionTecnica.Attributes.Add("maxlength", txtDescripcionTecnica.MaxLength.ToString());
                txtVidaUtil.Attributes.Add("maxlength", txtVidaUtil.MaxLength.ToString());
                txtCoberturaTerritorial.Attributes.Add("maxlength", txtCoberturaTerritorial.MaxLength.ToString());
                txtCoberturaPoblacional.Attributes.Add("maxlength", txtCoberturaPoblacional.MaxLength.ToString());
                txtCoberturaBeneficiariosDirectos.Attributes.Add("maxlength", txtCoberturaBeneficiariosDirectos.MaxLength.ToString());
                txtCoberturaBeneficiariosIndirectos.Attributes.Add("maxlength", txtCoberturaBeneficiariosIndirectos.MaxLength.ToString());
                txtDimensionesCostosEnte.Attributes.Add("maxlength", txtDimensionesCostosEnte.MaxLength.ToString());
                txtDificultadesRiesgosEnumeracion.Attributes.Add("maxlength", txtDificultadesRiesgosEnumeracion.MaxLength.ToString());
                txtRequiereIntevencionAutoridad.Attributes.Add("maxlength", txtRequiereIntevencionAutoridad.MaxLength.ToString());
                //No tiene maxlength txtObservacionesDNIP.Attributes.Add("maxlength", txtObservacionesDNIP.MaxLength.ToString());
            }

            revObjetivoDelProyecto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(1000);
            revObjetivoDelProyecto.ErrorMessage = TranslateFormat("FieldInvalidLength", "Objetivo Del Proyecto (1000 caractéres máx.)");
            txtObjetivoDelProyecto.ToolTip = "El “objetivo” de un proyecto es la descripción de la solución al problema que se ha diagnosticado (situación que se desea alcanzar). Ejemplo: “si el problema principal en el sector de salud es una alta tasa de mortalidad infantil en la población de menores ingresos, el objetivo sería reducir en un X% la tasa de mortalidad infantil en esa población al cabo de X años”";

            revProductoOServicio.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revProductoOServicio.ErrorMessage = TranslateFormat("FieldInvalidLength", "Producto o servicio que brindará el proyecto una vez finalizado? (255 caractéres máx.)");

            revAlternativas.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revAlternativas.ErrorMessage = TranslateFormat("FieldInvalidLength", "Alternativas (2000 caractéres máx.)");

            revPorqueAlternativa.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revPorqueAlternativa.ErrorMessage = TranslateFormat("FieldInvalidLength", "Por que han seleccionado la alternativa elegida (2000 caractéres máx.)");

            revDescripcionTecnica.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revDescripcionTecnica.ErrorMessage = TranslateFormat("FieldInvalidLength", "Descripcion Tecnica (2000 caractéres máx.)");

            revVidaUtil.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revVidaUtil.ErrorMessage = TranslateFormat("FieldInvalidLength", "Vida útil del principal bien de capital a incorporar en el marco del proyecto (255 caractéres máx.)");

            revCoberturaTerritorial.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revCoberturaTerritorial.ErrorMessage = TranslateFormat("FieldInvalidLength", "Cobertura Territorial (2000 caractéres máx.)");
            revCoberturaPoblacional.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revCoberturaPoblacional.ErrorMessage = TranslateFormat("FieldInvalidLength", "Cobertura Poblacional (255 caractéres máx.)");
            revCoberturaBeneficiariosDirectos.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revCoberturaBeneficiariosDirectos.ErrorMessage = TranslateFormat("FieldInvalidLength", "Cobertura Beneficiarios Directos (2000 caractéres máx.)");
            revCoberturaBeneficiariosIndirectos.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revCoberturaBeneficiariosIndirectos.ErrorMessage = TranslateFormat("FieldInvalidLength", "Cobertura Beneficiarios Indirectos (255 caractéres máx.)");

            revDificultadesRiesgosEnumeracion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revDificultadesRiesgosEnumeracion.ErrorMessage = TranslateFormat("FieldInvalidLength", "Dificultades o Riesgos significativos. (2000 caractéres máx.)");
            rfvDificultadesRiesgosEnumeracion.ErrorMessage = TranslateFormat("FieldIsNull", "Dificultades o Riesgos significativos.");
            revDificultadesRiesgosEnumeracionMinLength.ErrorMessage = TranslateFormat("{0}", "El campo Dificultades o Riesgos significativos. Requiere como mínimo 8 caractéres.");

            revDimensionesCostosEnte.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revDimensionesCostosEnte.ErrorMessage = TranslateFormat("FieldInvalidLength", "Dimensiones Costos (255 caractéres máx.)");
            rfvDimensionesCostosEnte.ErrorMessage = TranslateFormat("FieldIsNull", "Dimensiones Costos.");
            revDimensionesCostosEnteMinLength.ErrorMessage = TranslateFormat("{0}", "El campo Dimensiones Costos. Requiere como mínimo 8 caractéres.");
            rfvDimensionesCostosValidados.ErrorMessage = TranslateFormat("FieldIsNull", "Dimensiones Costos Validados.");

            revRequiereIntevencionAutoridad.Enabled = false;
            revRequiereIntevencionAutoridad.ValidationExpression = Contract.DataHelper.GetExpRegString(255);
            revRequiereIntevencionAutoridad.ErrorMessage = TranslateFormat("FieldInvalidLength", "Autoridad ambiental competente (255 caractéres máx.)");
            rfvRequiereIntevencionAutoridad.Enabled = false;
            rfvRequiereIntevencionAutoridad.ErrorMessage = TranslateFormat("FieldIsNull", "Autoridad ambiental competente");

            rfvRequiereIntevencionEstado.Enabled = false;
            rfvRequiereIntevencionEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado del trámite");

            revObservacionesDNIP.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revObservacionesDNIP.ErrorMessage = TranslateFormat("InvalidFiled", "Necesidad a satisfacer");

            pnlNecesidadASatisfacer.ToolTip = Translate("TooltipPrincipiosConceptualesDeFormulacion");
            pnlObjetivoDelProyecto.ToolTip = Translate("TooltipObjetivoDelProyecto");
            pnlProductoOServicio.ToolTip = Translate("TooltipProductoServicioDelProyecto");
            pnlDescripcionTecnica.ToolTip = Translate("TooltipDescripcionTecnica");
            pnlVidaUtil.ToolTip = Translate("TooltipVidaUtil");
            txtCoberturaTerritorial.ToolTip = Translate("TooltipCoberturaTerritorial");
            txtCoberturaPoblacional.ToolTip = Translate("TooltipCoberturaPoblacional");
            txtCoberturaBeneficiariosDirectos.ToolTip = Translate("TooltipBeneficiariosDirectos");
            txtCoberturaBeneficiariosIndirectos.ToolTip = Translate("TooltipBeneficiariosIndirectos");
            pnlDificultadesRiesgos.ToolTip = Translate("TooltipDificultadesRiesgos");
            txtObservacionesDNIP.ToolTip = Translate("TooltipObservacionesDNIP");
            if (UIContext.Current.ContextUser != null && UIContext.Current.ContextUser.PerfilesPorOficina != null)
            {
                txtObservacionesDNIP.Enabled = UIContext.Current.ContextUser.PerfilesPorOficina.Where(x => x.Oficina_Nombre == "DNIP").Any();
            }
        }
        public override void Clear()
        {
            UIHelper.Clear(txtNecesidadASatisfacer);
            UIHelper.Clear(txtObjetivoDelProyecto);
            UIHelper.Clear(txtProductoOServicio);
            UIHelper.Clear(txtAlternativas);
            UIHelper.Clear(txtPorqueAlternativa);
            UIHelper.Clear(txtDescripcionTecnica);
            UIHelper.Clear(txtVidaUtil);
            UIHelper.Clear(txtCoberturaTerritorial);
            UIHelper.Clear(txtCoberturaPoblacional);
            UIHelper.Clear(txtCoberturaBeneficiariosDirectos);
            UIHelper.Clear(txtCoberturaBeneficiariosIndirectos);

            UIHelper.Clear(cbDificultadesRiesgos);
            UIHelper.Clear(txtDificultadesRiesgosEnumeracion);
                        
            UIHelper.Clear(cbDimensionesCostosDimensionados);
            rblDimensionesCostosValidados.ClearSelection();
            UIHelper.Clear(txtDimensionesCostosEnte);

            UIHelper.Clear(cbRequiereIntevencion);
            UIHelper.Clear(txtRequiereIntevencionAutoridad);
            rblRequiereIntevencionEstado.ClearSelection();
            UIHelper.Clear(txtObservacionesDNIP);
        }
        public override void GetValue()
        {
            Entity.PrincipiosFormulacion.NecesidadASatisfacer = UIHelper.GetString(txtNecesidadASatisfacer);
            Entity.PrincipiosFormulacion.ObjetivoDelProyecto = UIHelper.GetString(txtObjetivoDelProyecto);
            Entity.PrincipiosFormulacion.ProductoOServicio = UIHelper.GetString(txtProductoOServicio);
            Entity.PrincipiosFormulacion.Alternativas = UIHelper.GetString(txtAlternativas);
            Entity.PrincipiosFormulacion.PorqueAlternativa = UIHelper.GetString(txtPorqueAlternativa);
            Entity.PrincipiosFormulacion.DescripcionTecnica = UIHelper.GetString(txtDescripcionTecnica);
            Entity.PrincipiosFormulacion.VidaUtil = UIHelper.GetString(txtVidaUtil);
            Entity.PrincipiosFormulacion.CoberturaTerritorial = UIHelper.GetString(txtCoberturaTerritorial);
            Entity.PrincipiosFormulacion.CoberturaPoblacional = UIHelper.GetString(txtCoberturaPoblacional);
            Entity.PrincipiosFormulacion.CoberturaBeneficiariosDirectos = UIHelper.GetString(txtCoberturaBeneficiariosDirectos);
            Entity.PrincipiosFormulacion.CoberturaBeneficiariosIndirectos = UIHelper.GetString(txtCoberturaBeneficiariosIndirectos);
            Entity.PrincipiosFormulacion.ObservacionesDNIP = UIHelper.GetString(txtObservacionesDNIP);

            if (cbDificultadesRiesgos.Checked || cbDificultadesRiesgosNo.Checked)
            {
                Entity.PrincipiosFormulacion.DificultadesRiesgos = UIHelper.GetBoolean(cbDificultadesRiesgos);
            }
            Entity.PrincipiosFormulacion.DificultadesRiesgosEnumeracion = UIHelper.GetString(txtDificultadesRiesgosEnumeracion);

            if (cbDimensionesCostosDimensionados.Checked || cbDimensionesCostosDimensionadosNo.Checked)
            {
                Entity.PrincipiosFormulacion.DimensionesCostosDimensionados = UIHelper.GetBoolean(cbDimensionesCostosDimensionados);
                if (!String.IsNullOrEmpty(rblDimensionesCostosValidados.Text))
                {
                    if(rblDimensionesCostosValidados.Text.Equals("Si"))
                    {
                        Entity.PrincipiosFormulacion.DimensionesCostosValidados = true;
                    }
                    else
                    {
                        Entity.PrincipiosFormulacion.DimensionesCostosValidados = false;
                    }
                    Entity.PrincipiosFormulacion.DimensionesCostosEnte = UIHelper.GetString(txtDimensionesCostosEnte);
                }
                else
                {
                    Entity.PrincipiosFormulacion.DimensionesCostosValidados = null;
                }
            }

            if (cbRequiereIntevencion.Checked || cbRequiereIntevencionNo.Checked)
            {
                Entity.PrincipiosFormulacion.RequiereIntevencion = UIHelper.GetBoolean(cbRequiereIntevencion);
                Entity.PrincipiosFormulacion.RequiereIntevencionAutoridad = UIHelper.GetString(txtRequiereIntevencionAutoridad);

                int? estadoRequiereIntervencion = null;
                if (UIHelper.GetString(rblRequiereIntevencionEstado) == "A Iniciar") estadoRequiereIntervencion = 0;
                if (UIHelper.GetString(rblRequiereIntevencionEstado) == "En Curso") estadoRequiereIntervencion = 1;
                if (UIHelper.GetString(rblRequiereIntevencionEstado) == "Terminado") estadoRequiereIntervencion = 2;
                Entity.PrincipiosFormulacion.RequiereIntevencionEstado = estadoRequiereIntervencion;
            }
            

        }
        public override void SetValue()
        {
            lblNecesidadASatisfacer.Style.Remove("color");
            lblObjetivoDelProyecto.Style.Remove("color");
            lblProductoOServicio.Style.Remove("color");
            lblAlternativas.Style.Remove("color");
            lblPorqueAlternativa.Style.Remove("color");
            lblDescripcionTecnica.Style.Remove("color");
            lblCobertura.Style.Remove("color");
            lblVidaUtil.Style.Remove("color");
            lblDificultadesRiesgos.Style.Remove("color");
            lblDimensionesCostos.Style.Remove("color");
            lblRequiereIntevencion.Style.Remove("color");
            if (Entity.PrincipiosFormulacion == null)
            {
                Entity.PrincipiosFormulacion = new ProyectoPrincipiosFormulacionResult();
                Entity.PrincipiosFormulacion.IdProyecto = Entity.IdProyecto;
                Entity.PrincipiosFormulacion.IdProyectoPrincipiosFormulacion = -1;
                lblNecesidadASatisfacer.Style.Add("color", "red");
                lblObjetivoDelProyecto.Style.Add("color", "red");
                lblProductoOServicio.Style.Add("color", "red");
                lblAlternativas.Style.Add("color", "red");
                lblPorqueAlternativa.Style.Add("color", "red");
                lblDescripcionTecnica.Style.Add("color", "red");
                lblVidaUtil.Style.Add("color", "red");
                lblCobertura.Style.Add("color", "red");
                lblDificultadesRiesgos.Style.Add("color", "red");
                lblDimensionesCostos.Style.Add("color", "red");
                lblRequiereIntevencion.Style.Add("color", "red");
            }
            else
            {
                UIHelper.SetValue(txtNecesidadASatisfacer, Entity.PrincipiosFormulacion.NecesidadASatisfacer);
                if (String.IsNullOrEmpty(txtNecesidadASatisfacer.Text)) lblNecesidadASatisfacer.Style.Add("color","red");

                UIHelper.SetValue(txtObjetivoDelProyecto, Entity.PrincipiosFormulacion.ObjetivoDelProyecto);
                if (String.IsNullOrEmpty(txtObjetivoDelProyecto.Text)) lblObjetivoDelProyecto.Style.Add("color", "red");

                UIHelper.SetValue(txtProductoOServicio, Entity.PrincipiosFormulacion.ProductoOServicio);
                if (String.IsNullOrEmpty(txtProductoOServicio.Text)) lblProductoOServicio.Style.Add("color", "red");

                UIHelper.SetValue(txtAlternativas, Entity.PrincipiosFormulacion.Alternativas);
                if (String.IsNullOrEmpty(txtAlternativas.Text)) lblAlternativas.Style.Add("color", "red");

                UIHelper.SetValue(txtPorqueAlternativa, Entity.PrincipiosFormulacion.PorqueAlternativa);
                if (String.IsNullOrEmpty(txtPorqueAlternativa.Text)) lblPorqueAlternativa.Style.Add("color", "red");

                UIHelper.SetValue(txtDescripcionTecnica, Entity.PrincipiosFormulacion.DescripcionTecnica);
                if (String.IsNullOrEmpty(txtDescripcionTecnica.Text)) lblDescripcionTecnica.Style.Add("color", "red");

                UIHelper.SetValue(txtVidaUtil, Entity.PrincipiosFormulacion.VidaUtil);
                if (String.IsNullOrEmpty(txtVidaUtil.Text)) lblVidaUtil.Style.Add("color", "red");

                UIHelper.SetValue(txtCoberturaTerritorial, Entity.PrincipiosFormulacion.CoberturaTerritorial);
                UIHelper.SetValue(txtCoberturaPoblacional, Entity.PrincipiosFormulacion.CoberturaPoblacional);
                UIHelper.SetValue(txtCoberturaBeneficiariosDirectos, Entity.PrincipiosFormulacion.CoberturaBeneficiariosDirectos);
                UIHelper.SetValue(txtCoberturaBeneficiariosIndirectos, Entity.PrincipiosFormulacion.CoberturaBeneficiariosIndirectos);
                if (String.IsNullOrEmpty(txtCoberturaTerritorial.Text)
                    && String.IsNullOrEmpty(txtCoberturaPoblacional.Text)
                    && String.IsNullOrEmpty(txtCoberturaBeneficiariosDirectos.Text)
                    && String.IsNullOrEmpty(txtCoberturaBeneficiariosIndirectos.Text)) lblCobertura.Style.Add("color", "red");

                UIHelper.SetValue(cbDificultadesRiesgos, Entity.PrincipiosFormulacion.DificultadesRiesgos);                
                UIHelper.SetValue(txtDificultadesRiesgosEnumeracion, Entity.PrincipiosFormulacion.DificultadesRiesgosEnumeracion);
                if (Entity.PrincipiosFormulacion.DificultadesRiesgos == null)
                {
                    lblDificultadesRiesgos.Style.Add("color", "red");
                }
                else
                {
                    UIHelper.SetValue(cbDificultadesRiesgosNo, !Entity.PrincipiosFormulacion.DificultadesRiesgos);
                }

                UIHelper.SetValue(cbDimensionesCostosDimensionados, Entity.PrincipiosFormulacion.DimensionesCostosDimensionados);
                if (Entity.PrincipiosFormulacion.DimensionesCostosValidados.HasValue)
                {
                    if (Entity.PrincipiosFormulacion.DimensionesCostosValidados.Value)
                    {
                        UIHelper.SetValue(rblDimensionesCostosValidados, "Si");
                    }
                    else
                    {
                        UIHelper.SetValue(rblDimensionesCostosValidados, "No");
                    }
                }
                UIHelper.SetValue(txtDimensionesCostosEnte, Entity.PrincipiosFormulacion.DimensionesCostosEnte);
                if (Entity.PrincipiosFormulacion.DimensionesCostosDimensionados == null) 
                {
                    lblDimensionesCostos.Style.Add("color", "red");
                }
                else
                {
                    UIHelper.SetValue(cbDimensionesCostosDimensionadosNo, !Entity.PrincipiosFormulacion.DimensionesCostosDimensionados);
                }

                UIHelper.SetValue(cbRequiereIntevencion, Entity.PrincipiosFormulacion.RequiereIntevencion);
                UIHelper.SetValue(txtRequiereIntevencionAutoridad, Entity.PrincipiosFormulacion.RequiereIntevencionAutoridad);
                if (Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 0)
                {
                    UIHelper.SetValue(rblRequiereIntevencionEstado, "A Iniciar");
                }
                else if (Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 1)
                {
                    UIHelper.SetValue(rblRequiereIntevencionEstado, "En Curso");
                }
                else if (Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 2)
                {
                    UIHelper.SetValue(rblRequiereIntevencionEstado, "Terminado");
                }
                if (Entity.PrincipiosFormulacion.RequiereIntevencion == null) 
                {
                    lblRequiereIntevencion.Style.Add("color", "red");
                }
                else
                {
                    UIHelper.SetValue(cbRequiereIntevencionNo, !Entity.PrincipiosFormulacion.RequiereIntevencion);
                }
                UIHelper.SetValue(txtObservacionesDNIP, Entity.PrincipiosFormulacion.ObservacionesDNIP);

                cbDificultadesRiesgosCheckedChanged();
                cbDimensionesCostosDimensionadosCheckedChanged();
                //cbDimensionesCostosValidadosCheckedChanged();
                cbRequiereIntevencionCheckedChanged();
                upNecesidadASatisfacer.Update();
                upObjetivoDelProyecto.Update();
                upProductoOServicio.Update();
                upAlternativas.Update();
                upPorqueAlternativa.Update();
                upDescripcionTecnica.Update();
                upVidaUtil.Update();
                upCobertura.Update();
                upDificultadesRiesgos.Update();
                upDimensionesCostos.Update();
                upRequiereIntevencion.Update();
                upObservacionesDNIP.Update();
            }

        }
        #endregion Override

        protected void cbDificultadesRiesgos_CheckedChanged(object sender, EventArgs e)
        {
            cbDificultadesRiesgosCheckedChanged();
        }

        private void cbDificultadesRiesgosCheckedChanged()
        {
            txtDificultadesRiesgosEnumeracion.Enabled = cbDificultadesRiesgos.Checked;
            rfvDificultadesRiesgosEnumeracion.Enabled = true;
            revDificultadesRiesgosEnumeracion.Enabled = true;
            revDificultadesRiesgosEnumeracionMinLength.Enabled = true;
            if (!cbDificultadesRiesgos.Checked)
            {
                UIHelper.Clear(txtDificultadesRiesgosEnumeracion);
                rfvDificultadesRiesgosEnumeracion.Enabled = false;
                revDificultadesRiesgosEnumeracion.Enabled = false;
                revDificultadesRiesgosEnumeracionMinLength.Enabled = false;
            }
        }

        protected void cbDimensionesCostosDimensionados_CheckedChanged(object sender, EventArgs e)
        {
            cbDimensionesCostosDimensionadosCheckedChanged();
        }
        private void cbDimensionesCostosDimensionadosCheckedChanged()
        {
            rblDimensionesCostosValidados.Enabled = cbDimensionesCostosDimensionados.Checked;
            rfvDimensionesCostosValidados.Enabled = true;
            if (!cbDimensionesCostosDimensionados.Checked)
            {
                rfvDimensionesCostosValidados.Enabled = false;
                rblDimensionesCostosValidados.ClearSelection();
            }
            cbDimensionesCostosValidadosCheckedChanged();
        }

        protected void cbDimensionesCostosValidados_CheckedChanged(object sender, EventArgs e)
        {
            cbDimensionesCostosValidadosCheckedChanged();
        }
        private void cbDimensionesCostosValidadosCheckedChanged()
        {
            rfvDimensionesCostosEnte.Enabled = true;
            revDimensionesCostosEnte.Enabled = true;
            revDimensionesCostosEnteMinLength.Enabled = true;
            txtDimensionesCostosEnte.Enabled = rblDimensionesCostosValidados.Text == "Si";
            if (! (rblDimensionesCostosValidados.Text == "Si"))
            {
                UIHelper.Clear(txtDimensionesCostosEnte);
                rfvDimensionesCostosEnte.Enabled = false;
                revDimensionesCostosEnte.Enabled = false;
                revDimensionesCostosEnteMinLength.Enabled = false;
            }
        }

        protected void cbRequiereIntevencion_CheckedChanged(object sender, EventArgs e)
        {
            cbRequiereIntevencionCheckedChanged();
        }
        protected void cbRequiereIntevencionNo_CheckedChanged(object sender, EventArgs e)
        {
            cbRequiereIntevencionCheckedChanged();
        }
        private void cbRequiereIntevencionCheckedChanged()
        {
            txtRequiereIntevencionAutoridad.Enabled = cbRequiereIntevencion.Checked;
            rblRequiereIntevencionEstado.Enabled = cbRequiereIntevencion.Checked;

            rfvRequiereIntevencionEstado.Enabled = true;
            revRequiereIntevencionAutoridad.Enabled = true;
            rfvRequiereIntevencionAutoridad.Enabled = true;
            if (!cbRequiereIntevencion.Checked)
            {
                rfvRequiereIntevencionEstado.Enabled = false;
                revRequiereIntevencionAutoridad.Enabled = false;
                rfvRequiereIntevencionAutoridad.Enabled = false;
                UIHelper.Clear(txtRequiereIntevencionAutoridad);
                rblRequiereIntevencionEstado.ClearSelection();
            }
        }
    }
}