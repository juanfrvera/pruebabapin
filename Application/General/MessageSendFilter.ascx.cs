using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class MessageSendFilter : WebControlFilter<nc.MessageSendFilter>
    {
        private bool? primeraEjecucion;
        protected bool PrimeraEjecucion
        {
            get
            {
                if (primeraEjecucion == null)
                    if (ViewState["primeraEjecucion"] != null)
                        primeraEjecucion = ViewState["primeraEjecucion"] as bool?;
                    else
                    {
                        primeraEjecucion = Filter.EsPrimeraEjecucion==null;
                        ViewState["actualOficina"] = primeraEjecucion;
                    }
                return primeraEjecucion.Value ;
            }
            set
            {
                primeraEjecucion = value;
                ViewState["primeraEjecucion"] = value;
            }
        }


		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Priority>(ddlPriority, PriorityService.Current.GetList(), "Name", "IdPriority", new nc.Priority() { IdPriority = 0, Name = "Seleccione Prioridad" });
            revSubject.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
            revCodProyecto.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();

            revSubject.ErrorMessage = TranslateFormat("InvalidField", "Asunto");
            revCodProyecto.ErrorMessage = TranslateFormat("InvalidField", "Código de Proyecto");

            rdReadDate.ErrorMessageValidator = TranslateFormat("InvalidField", "Fechas de Lectura Incorrecta");
            rdReadDate.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Lectura de");
            rdReadDate.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Lectura a");
            rdStartDate.ErrorMessageValidator = TranslateFormat("InvalidField", "Fechas de Envío Incorrecta");
            rdStartDate.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Envío de");
            rdStartDate.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Envío a");
       
              
            //diFechaDesde.RequiredErrorMessage = TranslateFormat("InvalidField", "Fecha de");
            //diFechaHasta.RequiredErrorMessage = TranslateFormat("InvalidField", "Fecha a");
            //compareValidatorFecha.ErrorMessage = TranslateFormat("El Rango de Fechas es Incorrecto");
            //diFechaLecturaDesde.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Lectura de");
            //diFechaLecturaHasta.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Lectura a");
            //compareValidatorFechaLectura.ErrorMessage = TranslateFormat("El Rango de Fechas de Le es Incorrecto");

            chkAgenda.TagCheckedTrue = "Recibidos";
            chkAgenda.TagCheckedFalse = "Enviados";
            chkAgenda.TagOff = "Todos";
            chkAgenda.CheckedValue = true;
            chkIsRead.CheckedValue = false;
            chkIsManual.TagCheckedTrue = "Manual";
            chkIsManual.TagCheckedFalse = "Automático";
            chkIsManual.CheckedValue = null;
            

        }
		protected override void Clear()
        {          
            UIHelper.Clear(acUserTo);
            UIHelper.Clear(ddlPriority);
            UIHelper.Clear(txtSubject);            
            UIHelper.Clear(rdStartDate);
            UIHelper.Clear(rdReadDate);
            //UIHelper.Clear(diFechaDesde);
            //UIHelper.Clear(diFechaHasta);
            //UIHelper.Clear(diFechaLecturaDesde);
            //UIHelper.Clear(diFechaLecturaHasta);
            UIHelper.Clear(chkIsManual);
            UIHelper.Clear(txtCodProyecto);
            chkAgenda.CheckedValue = true;
            chkIsRead.CheckedValue = false;
        }

		protected override void SetValue()
        {
            if (PrimeraEjecucion )
            {
                Filter.IsRead = false;
                Filter.IsRecibido = true;
                PrimeraEjecucion = false;
                
            }
			UIHelper.SetValue(chkIsRead, Filter.IsRead);
            UIHelper.SetValue(chkAgenda, Filter.IsRecibido);
            UIHelper.SetValueFilter(txtSubject, Filter.Subject);                
            UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
            UIHelper.SetValue<DateTime?>(rdReadDate, Filter.ReadDate, Filter.ReadDate_To);
            //UIHelper.SetValue(diFechaDesde, Filter.StartDate);
            //UIHelper.SetValue(diFechaHasta, Filter.StartDate_To);
            //UIHelper.SetValue(diFechaLecturaDesde, Filter.ReadDate);
            //UIHelper.SetValue(diFechaLecturaHasta, Filter.ReadDate_To); 
 
            UIHelper.SetValue(chkIsManual, Filter.IsManual);
            UIHelper.SetValue(this.acUserTo, Filter.IdUserTo, Filter.UserTo_NombreCompleto);
            UIHelper.SetValue(txtCodProyecto, Filter.Project_Codigo);
        }	
        protected override void GetValue()
        {
            
            Filter.EsPrimeraEjecucion = false;
			Filter.IsRead=UIHelper.GetBooleanNullable(chkIsRead);
            Filter.IsRecibido = UIHelper.GetBooleanNullable(chkAgenda);

            Filter.IdUserTo = UIHelper.GetIntNullable(acUserTo);
            Filter.UserFrom_NombreCompleto = UIHelper.GetString(this.acUserTo);
            
            Filter.IdPriority = UIHelper.GetIntNullable(ddlPriority);
            Filter.Subject = UIHelper.GetStringBetweenFilter(txtSubject);



            Filter.StartDate = UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
            Filter.ReadDate = UIHelper.GetValueFromDate(rdReadDate);
            Filter.ReadDate_To = UIHelper.GetValueToDate(rdReadDate);

            //Filter.ReadDate = UIHelper.GetFromDateTimeNullable(diFechaLecturaDesde);
            //Filter.ReadDate = UIHelper.GetToDateTimeNullable(diFechaLecturaDesde);
            //Filter.StartDate = UIHelper.GetFromDateTimeNullable(diFechaDesde);
            //Filter.StartDate_To = UIHelper.GetToDateTimeNullable(diFechaHasta);

            Filter.IsManual = UIHelper.GetBooleanNullable(chkIsManual);
                        
         //   Filter.IdProyecto = UIHelper.GetIntNullable(acProject);
         //   Filter.Project_Denominacion = UIHelper.GetString(this.acProject);
            Filter.Project_Codigo = UIHelper.GetIntNullable(txtCodProyecto);
            Filter.UsuarioBandeja = UIContext.Current.ContextUser.User.IdUsuario;
        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
