using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Contract;
using nc = Contract;
using System.Collections.Generic;
using Service;
namespace UI.Web
{
    public partial class WebControl_ProyectoVerReporte : WebControlPopup
    {

        protected override void _Initialize()
        {
            base._Initialize();
            revAnioInicial.ValidationExpression = DataHelper.GetExpRegNumber();
            revAnioInicial.ErrorMessage = TranslateFormat("InvalidField", "Año");
            UIHelper.Load<Fase>(ddlFase, FaseService.Current.GetList(new nc.FaseFilter() { Activo = true }), "Nombre", "IdFase", new nc.Fase() { IdFase = 0, Nombre = "Seleccione Fase" });
            UIHelper.SetValue(txtAnioInicial, DateTime.Now.Year);

        }

        ProyectoReportFilter filtro;
        public ProyectoReportFilter Filtro
        {
            get
            {
                if (filtro == null)
                    if (ViewState["filtro"] != null)
                        filtro = ViewState["filtro"] as ProyectoReportFilter;
                    else
                    {
                        filtro = new ProyectoReportFilter();
                        ViewState["filtro"] = filtro;
                    }
                return filtro;
            }
            set
            {
                filtro = value;
                ViewState["filtro"] = value;
            }
        }

        #region Methods

        public override void HidePopup()
        {
            Clear();
            mpePopupVerReporte.Hide();
        }
        public override void ShowPopup()
        {
            mpePopupVerReporte.Show();
            Clear();
        }
        public void Aceptar()
        {
            if (string.IsNullOrEmpty(this.txtAnioInicial.Text))
                throw new Exception("El año inicial no puede ser vacio");

            int añoInicial = Convert.ToInt32(this.txtAnioInicial.Text);
            if (añoInicial > DateTime.Now.Year + 15)
                throw new Exception("El año inicial no puede exceder mas de 15 años del año actual");
            else if (añoInicial < 1950)
                throw new Exception("El año inicial no puede ser menor a 1950");

            GetValue();
            RaiseControlCommand(Command.SHOW_REPORT, Filtro.IdReport);
        }
        public void Exportar()
        {
            if (string.IsNullOrEmpty(this.txtAnioInicial.Text))
                throw new Exception("El año inicial no puede ser vacio");

            int añoInicial = Convert.ToInt32(this.txtAnioInicial.Text);
            if (añoInicial > DateTime.Now.Year + 15)
                throw new Exception("El año inicial no puede exceder mas de 15 años del año actual");
            else if (añoInicial < 1950)
                 throw new Exception("El año inicial no puede ser menor a 1950");

            GetValue();
            RaiseControlCommand(Command.SHOW_EXCEL_REPORT, Filtro.IdReport);
            ShowDownLoadExport();
        }
        protected void Clear()
        {
            UIHelper.Clear(txtAnioInicial);
            UIHelper.Clear(rbEstimados);
            UIHelper.Clear(rbRealizados);
            UIHelper.Clear(rbTodos);
            //UIHelper.Clear(chkAperturaPresupuestaria);
            UIHelper.Clear(ddlFase);
            UIHelper.SetValue(ddlFase, (Int32)FaseEnum.Ejecucion);
            UIHelper.SetValue(txtAnioInicial, DateTime.Now.Year);
            UIHelper.SetValue(rbEstimados, true);
            upControls.Update();
        }
        protected void GetValue()
        {
            Filtro.AnioInicialCronograma = UIHelper.GetInt(txtAnioInicial);
            Filtro.SoloEstimados = UIHelper.GetBooleanNullable(rbEstimados, rbRealizados, rbTodos);
            //Filtro.ConsideraAperturas = UIHelper.GetBoolean(chkAperturaPresupuestaria);
            Filtro.IdFase = UIHelper.GetInt(ddlFase);
        }

        #endregion

        #region Events

        protected void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar();
                HidePopup();
            }
            catch (Exception excepcion)
            {
                if (excepcion.Message.Length <= 50)
                {
                    UIHelper.ShowAlert(Translate(excepcion.Message), upControls);
                }
                else
                {
                    UIHelper.ShowAlert("El año inicial no puede exceder mas de 15 años del año actual", upControls);
                }
            }
          
        }

        protected void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Exportar();
                HidePopup();
            }
            catch (Exception excepcion)
            {
                if (excepcion.Message.Length <= 50)
                {
                    UIHelper.ShowAlert(Translate(excepcion.Message), upControls);
                }
                else
                {
                    UIHelper.ShowAlert("El año inicial no puede exceder mas de 15 años del año actual", upControls);
                }
            }


        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion




    }
}