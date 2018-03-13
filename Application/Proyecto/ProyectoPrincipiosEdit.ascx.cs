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
            revNecesidadASatisfacer.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revNecesidadASatisfacer.ErrorMessage = TranslateFormat("InvalidFiled", "Necesidad a satisfacer");

            revObjetivoDelProyecto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revObjetivoDelProyecto.ErrorMessage = TranslateFormat("InvalidField", "Objetivo Del Proyecto");
            txtObjetivoDelProyecto.ToolTip = "El “objetivo” de un proyecto es la descripción de la solución al problema que se ha diagnosticado (situación que se desea alcanzar). Ejemplo: “si el problema principal en el sector de salud es una alta tasa de mortalidad infantil en la población de menores ingresos, el objetivo sería reducir en un X% la tasa de mortalidad infantil en esa población al cabo de X años”";

            revProductoOServicio.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revProductoOServicio.ErrorMessage = TranslateFormat("InvalidField", "Producto o servicio que brindará el proyecto una vez finalizado?   ");

            revAlternativas.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revAlternativas.ErrorMessage = TranslateFormat("InvalidFiled", "Alternativas");

            revPorqueAlternativa.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revPorqueAlternativa.ErrorMessage = TranslateFormat("InvalidField", "Por que han seleccionado la alternativa elegida");

            revDescripcionTecnica.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revDescripcionTecnica.ErrorMessage = TranslateFormat("InvalidFiled", "Descripcion Tecnica");

            revVidaUtil.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revVidaUtil.ErrorMessage = TranslateFormat("InvalidField", "Vida útil del principal bien de capital a incorporar en el marco del proyecto");

            revCoberturaTerritorial.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCoberturaTerritorial.ErrorMessage = TranslateFormat("InvalidFiled", "Cobertura Territorial");
            revCoberturaPoblacional.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCoberturaPoblacional.ErrorMessage = TranslateFormat("InvalidFiled", "Cobertura Poblacional");
            revCoberturaBeneficiariosDirectos.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCoberturaBeneficiariosDirectos.ErrorMessage = TranslateFormat("InvalidFiled", "Cobertura Beneficiarios Directos");
            revCoberturaBeneficiariosIndirectos.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCoberturaBeneficiariosIndirectos.ErrorMessage = TranslateFormat("InvalidFiled", "Cobertura Beneficiarios Indirectos");

            revDificultadesRiesgosEnumeracion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revDificultadesRiesgosEnumeracion.ErrorMessage = TranslateFormat("InvalidFiled", "Dificultades o Riesgos significativos");

            revDimensionesCostosEnte.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revDimensionesCostosEnte.ErrorMessage = TranslateFormat("InvalidField", "Dimensiones Costos");

            revRequiereIntevencionAutoridad.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(255);
            revRequiereIntevencionAutoridad.ErrorMessage = TranslateFormat("InvalidField", "Autoridad ambiental competente");
            
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
            UIHelper.Clear(cbDimensionesCostosValidados);
            UIHelper.Clear(txtDimensionesCostosEnte);

            UIHelper.Clear(cbRequiereIntevencion);
            UIHelper.Clear(txtRequiereIntevencionAutoridad);
            UIHelper.Clear(cbRequiereIntevencionEstadoAIniciar);
            UIHelper.Clear(cbRequiereIntevencionEstadoEnCurso);
            UIHelper.Clear(cbRequiereIntevencionEstadoTerminado);
            
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

            Entity.PrincipiosFormulacion.DificultadesRiesgos = UIHelper.GetBoolean(cbDificultadesRiesgos);
            Entity.PrincipiosFormulacion.DificultadesRiesgosEnumeracion = UIHelper.GetString(txtDificultadesRiesgosEnumeracion);

            Entity.PrincipiosFormulacion.DimensionesCostosDimensionados = UIHelper.GetBoolean(cbDimensionesCostosDimensionados);
            Entity.PrincipiosFormulacion.DimensionesCostosValidados = UIHelper.GetBoolean(cbDimensionesCostosValidados);
            Entity.PrincipiosFormulacion.DimensionesCostosEnte = UIHelper.GetString(txtDimensionesCostosEnte);

            Entity.PrincipiosFormulacion.RequiereIntevencion = UIHelper.GetBoolean(cbRequiereIntevencion);
            Entity.PrincipiosFormulacion.RequiereIntevencionAutoridad = UIHelper.GetString(txtRequiereIntevencionAutoridad);

            int? estadoRequiereIntervencion = null;
            if (UIHelper.GetBoolean(cbRequiereIntevencionEstadoAIniciar)) estadoRequiereIntervencion = 0;
            if (UIHelper.GetBoolean(cbRequiereIntevencionEstadoEnCurso)) estadoRequiereIntervencion = 1;
            if (UIHelper.GetBoolean(cbRequiereIntevencionEstadoTerminado)) estadoRequiereIntervencion = 2;
            Entity.PrincipiosFormulacion.RequiereIntevencionEstado = estadoRequiereIntervencion;
        }
        public override void SetValue()
        {
            if (Entity.PrincipiosFormulacion == null)
            {
                Entity.PrincipiosFormulacion = new ProyectoPrincipiosFormulacionResult();
                Entity.PrincipiosFormulacion.IdProyecto = Entity.IdProyecto;
                Entity.PrincipiosFormulacion.IdProyectoPrincipiosFormulacion = -1;
            }
            else
            {
                UIHelper.SetValue(txtNecesidadASatisfacer, Entity.PrincipiosFormulacion.NecesidadASatisfacer);
                UIHelper.SetValue(txtObjetivoDelProyecto, Entity.PrincipiosFormulacion.ObjetivoDelProyecto);
                UIHelper.SetValue(txtProductoOServicio, Entity.PrincipiosFormulacion.ProductoOServicio);
                UIHelper.SetValue(txtAlternativas, Entity.PrincipiosFormulacion.Alternativas);
                UIHelper.SetValue(txtPorqueAlternativa, Entity.PrincipiosFormulacion.PorqueAlternativa);
                UIHelper.SetValue(txtDescripcionTecnica, Entity.PrincipiosFormulacion.DescripcionTecnica);
                UIHelper.SetValue(txtVidaUtil, Entity.PrincipiosFormulacion.VidaUtil);
                UIHelper.SetValue(txtCoberturaTerritorial, Entity.PrincipiosFormulacion.CoberturaTerritorial);
                UIHelper.SetValue(txtCoberturaPoblacional, Entity.PrincipiosFormulacion.CoberturaPoblacional);
                UIHelper.SetValue(txtCoberturaBeneficiariosDirectos, Entity.PrincipiosFormulacion.CoberturaBeneficiariosDirectos);
                UIHelper.SetValue(txtCoberturaBeneficiariosIndirectos, Entity.PrincipiosFormulacion.CoberturaBeneficiariosIndirectos);

                UIHelper.SetValue(cbDificultadesRiesgos, Entity.PrincipiosFormulacion.DificultadesRiesgos);
                UIHelper.SetValue(txtDificultadesRiesgosEnumeracion, Entity.PrincipiosFormulacion.DificultadesRiesgosEnumeracion);
                UIHelper.SetValue(cbDimensionesCostosDimensionados, Entity.PrincipiosFormulacion.DimensionesCostosDimensionados);
                UIHelper.SetValue(cbDimensionesCostosValidados, Entity.PrincipiosFormulacion.DimensionesCostosValidados);
                UIHelper.SetValue(txtDimensionesCostosEnte, Entity.PrincipiosFormulacion.DimensionesCostosEnte);
                UIHelper.SetValue(cbRequiereIntevencion, Entity.PrincipiosFormulacion.RequiereIntevencion);
                UIHelper.SetValue(txtRequiereIntevencionAutoridad, Entity.PrincipiosFormulacion.RequiereIntevencionAutoridad);
                UIHelper.SetValue(cbRequiereIntevencionEstadoAIniciar, Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 0);
                UIHelper.SetValue(cbRequiereIntevencionEstadoEnCurso, Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 1);
                UIHelper.SetValue(cbRequiereIntevencionEstadoTerminado, Entity.PrincipiosFormulacion.RequiereIntevencionEstado == 2);
                cbDificultadesRiesgosCheckedChanged();
                cbDimensionesCostosDimensionadosCheckedChanged();
                cbDimensionesCostosValidadosCheckedChanged();
                cbRequiereIntevencion_CheckedChanged();
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
            }

        }
        #endregion Override

        protected void cbDificultadesRiesgos_CheckedChanged(object sender, EventArgs e)
        {
            txtDificultadesRiesgosEnumeracion.Enabled = cbDificultadesRiesgos.Checked;
            if (!cbDificultadesRiesgos.Checked)
            {
                UIHelper.Clear(txtDificultadesRiesgosEnumeracion);
            }
        }

        private void cbDificultadesRiesgosCheckedChanged()
        {
            txtDificultadesRiesgosEnumeracion.Enabled = cbDificultadesRiesgos.Checked;
            if (!cbDificultadesRiesgos.Checked)
            {
                UIHelper.Clear(txtDificultadesRiesgosEnumeracion);
            }
        }

        protected void cbDimensionesCostosDimensionados_CheckedChanged(object sender, EventArgs e)
        {
            cbDimensionesCostosDimensionadosCheckedChanged();
        }
        private void cbDimensionesCostosDimensionadosCheckedChanged()
        {
            cbDimensionesCostosValidados.Enabled = cbDimensionesCostosDimensionados.Checked;
            if (!cbDimensionesCostosDimensionados.Checked)
            {
                UIHelper.Clear(cbDimensionesCostosValidados);
                UIHelper.Clear(txtDimensionesCostosEnte);
            }
        }

        protected void cbDimensionesCostosValidados_CheckedChanged(object sender, EventArgs e)
        {
            cbDimensionesCostosValidadosCheckedChanged();
        }
        private void cbDimensionesCostosValidadosCheckedChanged()
        {
            txtDimensionesCostosEnte.Enabled = cbDimensionesCostosValidados.Checked;
            if (!cbDimensionesCostosValidados.Checked)
            {
                UIHelper.Clear(txtDimensionesCostosEnte);
            }
        }

        protected void cbRequiereIntevencion_CheckedChanged(object sender, EventArgs e)
        {
            cbRequiereIntevencion_CheckedChanged();
        }
        private void cbRequiereIntevencion_CheckedChanged()
        {
            txtRequiereIntevencionAutoridad.Enabled = cbRequiereIntevencion.Checked;
            if (!cbRequiereIntevencion.Checked)
            {
                UIHelper.Clear(txtRequiereIntevencionAutoridad);
                UIHelper.Clear(cbRequiereIntevencionEstadoAIniciar);
                UIHelper.Clear(cbRequiereIntevencionEstadoEnCurso);
                UIHelper.Clear(cbRequiereIntevencionEstadoTerminado);
            }
        }
    }
}