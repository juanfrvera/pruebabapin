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
    public partial class ProyectoComentarioTecnicoFilter : WebControlFilter<nc.ProyectoComentarioTecnicoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            rdFecha.ErrorMessageValidator = TranslateFormat("InvalidField", "Rango de Fechas");
            rdFecha.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de");
            rdFecha.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha a");
            revNroProyecto.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            chkTipoProyecto.TagCheckedTrue = "Proyecto";
            chkTipoProyecto.TagCheckedFalse = "Prestamo";
            chkTipoProyecto.TagOff = "Todos";
			UIHelper.Load<nc.ComentarioTecnico>(ddlComentarioTecnico, ComentarioTecnicoService.Current.GetList(),"Nombre","IdComentarioTecnico",new nc.ComentarioTecnico(){IdComentarioTecnico=0, Nombre= "Seleccione ComentarioTecnico"});
            UIHelper.Load<UsuarioResult>(ddlUsuario, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true , EsSectioralista = true  }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Usuario", Persona_Apellido = String.Empty, IdUsuario = 0 });
		}
		protected override void Clear()
        {			
			
            ddlComentarioTecnico.Focus();
			UIHelper.Clear(ddlComentarioTecnico);
            UIHelper.Clear(txtNroProyecto);
            UIHelper.Clear(rdFecha);
            UIHelper.Clear(ddlUsuario);

				
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue (ddlComentarioTecnico, Filter.IdComentarioTecnico );
            UIHelper.SetValue(rdFecha, Filter.Fecha, Filter.Fecha_To);
            UIHelper.SetValue(txtNroProyecto, Filter.Numero);
            UIHelper.SetValue(ddlUsuario, Filter.IdUsuario);
            if (Filter.IdPrestamoIsNull == true && Filter.IdProyectoIsNull == false)
            {
                UIHelper.SetValue(chkTipoProyecto, true);
            }
            else if (Filter.IdPrestamoIsNull == false && Filter.IdProyectoIsNull == true)
            {
                UIHelper.SetValue(chkTipoProyecto, false);
            }
            else
            {
                UIHelper.SetValue(chkTipoProyecto, null);
            }

        }	
        protected override void GetValue()
        {
            Filter.IdComentarioTecnico = UIHelper.GetIntNullable(ddlComentarioTecnico);
            
            Filter.Fecha =UIHelper.GetValueFromDate(rdFecha);
            Filter.Fecha_To = UIHelper.GetValueToDate(rdFecha);            
            Filter.IdUsuario = UIHelper.GetIntNullable(ddlUsuario);
            Filter.IdUsuario_To = UIHelper.GetIntNullable(ddlUsuario);
            Filter.Numero = UIHelper.GetIntNullable(txtNroProyecto);

            if (chkTipoProyecto.CheckedValue == true)
            {
                Filter.IdPrestamoIsNull = true;
                Filter.IdProyectoIsNull = false;
            }
            else if (chkTipoProyecto.CheckedValue == false)
            {
                Filter.IdPrestamoIsNull = false;
                Filter.IdProyectoIsNull = true;
            }
            else
            {
                Filter.IdPrestamoIsNull = null;
                Filter.IdProyectoIsNull = null;
            }
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
