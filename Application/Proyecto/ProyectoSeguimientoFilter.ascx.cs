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
    public partial class ProyectoSeguimientoFilter : WebControlFilter<nc.ProyectoSeguimientoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
			revRuta.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revMalla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            UIHelper.Load<SafResult>(ddlSaf, SafService.Current.GetResult(), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Denominacion = "Seleccione Saf" }, true, "CodigoInt", typeof (Int32));
            UIHelper.Load<UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            UIHelper.Load<nc.Estado>(lbxEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_SEGUIMIENTO_ESTADO }), "Nombre", "IdEstado");
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlSaf );
			ddlSaf.Focus();
			UIHelper.Clear(txtDenominacion);
			UIHelper.Clear(txtRuta);
			UIHelper.Clear(txtMalla);
			UIHelper.Clear(ddlAnalista );
            UIHelper.Clear(txtNroProyecto);
            lbxEstado.ClearSelection();
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue(ddlSaf, Filter.IdSaf);
			ddlSaf.Focus();
			UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
            UIHelper.SetValueFilter(txtRuta, Filter.Ruta);
			UIHelper.SetValueFilter(txtMalla, Filter.Malla);
			UIHelper.SetValue(ddlAnalista, Filter.IdAnalista);
            UIHelper.SetValue(txtNroProyecto, Filter.Proyecto_Codigo);
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);
        }	
        protected override void GetValue()
        {
			Filter.IdSaf=UIHelper.GetIntNullable(ddlSaf);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
            Filter.Ruta = UIHelper.GetStringBetweenFilter(txtRuta);
            Filter.Malla = UIHelper.GetStringBetweenFilter(txtMalla);
			Filter.IdAnalista=UIHelper.GetIntNullable(ddlAnalista);
            Filter.Proyecto_Codigo = UIHelper.GetIntNullable(txtNroProyecto);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
        }
		protected void btClear_Click(object sender, EventArgs e)
        {
           RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
