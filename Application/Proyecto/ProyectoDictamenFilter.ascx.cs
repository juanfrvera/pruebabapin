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
    public partial class ProyectoDictamenFilter : WebControlFilter<nc.ProyectoDictamenFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNumero.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(10);
            UIHelper.Load<nc.Estado>(lbxEstado, EstadoService.Current.GetList( new nc.EstadoFilter (){ IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Dictamen }), "Nombre", "IdEstado");
            UIHelper.Load<nc.ProyectoCalificacion>(ddlCalificacion , ProyectoCalificacionService.Current.GetList(), "Nombre", "IdProyectoCalificacion", new nc.ProyectoCalificacion() { IdProyectoCalificacion = 0, Nombre = "Seleccione Calificación" });
            UIHelper.Load<nc.Anio>(ddlEjercicio, AnioService.Current.GetList(new nc.AnioFilter(){ IdAnio_To=DateTime.Now.Year+4} ).OrderByDescending(i=> i.IdAnio ).ToList (), "Nombre", "Nombre", new nc.Anio() {IdAnio =0, Nombre = "Seleccione Año" },false );
            UIHelper.Load<nc.SafResult>(ddlSaf, SafService.Current.GetResult(new nc.SafFilter()), "CodigoDenominacion", "IdSaf", new SafResult() { Denominacion = "Seleccione Saf", IdSaf = 0, }, true, "CodigoInt");
            UIHelper.Load<nc.UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Apellido = "Seleccione Analista", IdUsuario = 0 });
            
		}
		protected override void Clear()
        {
            UIHelper.Clear(ddlCalificacion);
            UIHelper.Clear(txtInformeTecnico);
            UIHelper.Clear(diFecha);
            lbxEstado.ClearSelection();
            UIHelper.Clear(txtNumero);
            UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(txtBapin);
            UIHelper.Clear(ddlEjercicio);
            UIHelper.Clear(diFechaVto);
            UIHelper.Clear(ddlSaf);
            UIHelper.Clear(ddlAnalista );
            UIHelper.Clear(txtMalla );
            UIHelper.Clear(txtRuta );
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue (ddlCalificacion, Filter.IdProyectoCalificacion);
            UIHelper.SetValueFilter(txtInformeTecnico, Filter.InformeTecnico);
            UIHelper.SetValue(diFecha, Filter.Fecha);
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);
            UIHelper.SetValueFilter(txtNumero, Filter.Numero);
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);
            UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
            UIHelper.SetValue(txtBapin, Filter.NroBapin );
            UIHelper.SetValue(ddlEjercicio, Filter.Ejercicio );
            UIHelper.SetValue(diFechaVto, Filter.FechaVencimiento);

            UIHelper.SetValue(ddlSaf, Filter.IdSaf );
            UIHelper.SetValue(ddlAnalista, Filter.IdAnalista );
            UIHelper.SetValueFilter (txtMalla, Filter.Malla );
            UIHelper.SetValueFilter(txtRuta, Filter.Ruta);
        }	
        protected override void GetValue()
        {
            Filter.IdProyectoCalificacion = UIHelper.GetInt(ddlCalificacion);
            Filter.InformeTecnico = UIHelper.GetStringBetweenFilter(txtInformeTecnico);
            Filter.Fecha = UIHelper.GetDateTimeNullable(diFecha);
            Filter.Numero = UIHelper.GetStringBetweenFilter(txtNumero);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
            Filter.NroBapin = UIHelper.GetIntNullable  (txtBapin );
            Filter.Ejercicio = UIHelper.GetIntNullable  (ddlEjercicio);
            Filter.FechaVencimiento = UIHelper.GetDateTimeNullable (diFechaVto );

            Filter.IdSaf = UIHelper.GetIntNullable (ddlSaf);
            Filter.IdAnalista = UIHelper.GetIntNullable (ddlAnalista );
            Filter.Malla = UIHelper.GetStringBetweenFilter (txtMalla );
            Filter.Ruta = UIHelper.GetStringBetweenFilter(txtRuta);
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
