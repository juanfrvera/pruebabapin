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
    public partial class PersonaFilter : WebControlFilter<nc.PersonaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toOficina.Width = 550;
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revApellido.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
            revUsuario.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(70);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revApellido.ErrorMessage = TranslateFormat("InvalidField", "Apellido");
            revUsuario.ErrorMessage = TranslateFormat("InvalidField", "Usuario");
            UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccion, JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter()), "CodigoNombre", "IdJurisdiccion", new nc.JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" });
           // UIHelper.Load<nc.OficinaResult>(ddlOficina, OficinaService.Current.GetResult(new nc.OficinaFilter() { Activo = true }), "Nombre", "IdOficina", new nc.OficinaResult() { IdOficina = 0, Nombre = "Seleccione Oficina" });
           // UIHelper.Load<nc.SafResult>(ddlSaf, SafService.Current.GetResult(new nc.SafFilter() { Activo = true }), "Denominacion", "IdSaf", new nc.SafResult() { IdSaf = 0, Denominacion = "Seleccione SAF" });			
            chkActivo.CheckedValue = true;
            chkUsuarioContacto.TagCheckedTrue = "Es Usuario";
            chkUsuarioContacto.TagCheckedFalse = "Es Contacto";
            chkUsuarioContacto.TagOff = "Todos";
                /*.TagCheckedTrue = "Recibidos";
            chkAgenda.TagCheckedFalse = "Enviados";
            chkAgenda.TagOff = "Todos";*/



            if (!CanByUser(SistemaEntidadConfig.USUARIO, ActionConfig.READ))
            {
                chkUsuarioContacto.CheckedValue = false;
                chkUsuarioContacto.Enable = false;
            }
            else
            {
                chkUsuarioContacto.CheckedValue = true;
            }
          
		}
		protected override void Clear()
        {			
            txtNombre.Focus();
            UIHelper.Clear(toOficina);
            UIHelper.Clear(ddlSaf);
            UIHelper.Clear(txtNombre);
            UIHelper.Clear(txtApellido);
            UIHelper.Clear(txtUsuario);
            chkActivo.CheckedValue = true;
            UIHelper.Clear(chkUsuarioContacto);
            UIHelper.Clear(chkIncluirOficinasInteriores);
          //  UIHelper.Clear(chkContacto);
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue(toOficina, Filter.IdOficina );
            UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
            if (Filter.IdJurisdiccion.HasValue)
            {
                BuscarSAF();
                UIHelper.SetValue(ddlSaf, Filter.IdSaf);
            }            
            UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
            UIHelper.SetValueFilter(txtApellido, Filter.Apellido);
            UIHelper.SetValueFilter(txtUsuario, Filter.Usuario_Nombre);
            UIHelper.SetValue(chkActivo, Filter.Activo);
            UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.IncluirOficinasInteriores);
       //     UIHelper.SetValue(chkContacto, Filter.EsContacto);
            UIHelper.SetValue(chkUsuarioContacto, Filter.EsUsuarioContacto);
         //   UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.);

        }	
        protected override void GetValue()
        {
            Filter.IdOficina = UIHelper.GetIntNullable(toOficina);
            Filter.IdSaf = UIHelper.GetIntNullable (ddlSaf);
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
            Filter.Apellido = UIHelper.GetStringBetweenFilter(txtApellido);
            Filter.Usuario_Nombre = UIHelper.GetStringFilter(txtUsuario);
            Filter.Activo = UIHelper.GetBooleanNullable(chkActivo);
            Filter.EsUsuarioContacto = UIHelper.GetBooleanNullable(chkUsuarioContacto);
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);
          //  Filter.EsContacto = UIHelper.GetBooleanNullable(chkContacto);
        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }

        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSAF);
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarOficinas);
        }
        private void BuscarSAF()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
            if (idJurisdiccion == 0)
            {
                UIHelper.ClearItems(ddlSaf);
                ddlSaf.Enabled = false;
                BuscarOficinas();
            }
            else
            {
                UIHelper.Load<nc.SafResult>(ddlSaf, SafService.Current.GetResultFromList(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione SAF" });
                ddlSaf.Enabled = true;
            }
        }
        private void BuscarOficinas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSaf);
            if (idSaf == 0)
            {
                UIHelper.Clear(toOficina);
            }
            else
            {
                //To do: Llenar con oficinas correspondientes
               // UIHelper.Load<nc.Oficina>(ddlOficina, OficinaService.Current.GetList(new nc.OficinaFilter() { IdSaf = idSaf }), "Nombre", "IdOficina", new nc.Oficina() { IdOficina = 0, Nombre = "Seleccione Oficina" });
            }
        }
    }
}
