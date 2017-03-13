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
    public partial class ProyectoComentarioTecnicoEdit : WebControlEdit<nc.ProyectoComentarioTecnico>
    {

        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.ComentarioTecnico>(ddlComentarioTecnico, ComentarioTecnicoService.Current.GetList(new nc.ComentarioTecnicoFilter() { Activo = true }), "Nombre", "IdComentarioTecnico", new nc.ComentarioTecnico() { IdComentarioTecnico = 0, Nombre = "Seleccione ComentarioTecnico" });

            rfvProyecto.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvComentarioTecnico.ErrorMessage = TranslateFormat("InvalidField", "Tipo");
            revObservacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
            revObservacion.ErrorMessage = TranslateFormat("InvalidField", "Observación");
            rfvObservacion.ErrorMessage = TranslateFormat("FieldIsNull", "Observación");
            diFecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");			
            diFecha.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha"); //Matias 20150120 - Tarea 192
		}
		public override void Clear()
        {			
			
            UIHelper.Clear(txtProyectoCodigo);
            UIHelper.Clear(ddlComentarioTecnico);
			UIHelper.Clear(txtObservacion);
			UIHelper.Clear(diFecha);
            UIHelper.Clear(liProyectoNombre);
            
        }		
		public override void SetValue()
        {

            
            UIHelper.SetValue<ComentarioTecnico,int>(ddlComentarioTecnico, Entity.IdComentarioTecnico, ComentarioTecnicoService.Current.GetById);
			UIHelper.SetValue(txtObservacion, Entity.Observacion);
			UIHelper.SetValue(diFecha, Entity.Fecha);
            if (Entity.IdProyecto != null)
            {
                UIHelper.SetValue(rbTipoProyectoInversion, true);
                
                ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto }).FirstOrDefault();
                UIHelper.SetValue(txtProyectoCodigo, proyecto.Codigo);
                UIHelper.SetValue(liProyectoNombre, proyecto.ProyectoDenominacion);
            }
            else if (Entity.IdPrestamo != null)
            {
                UIHelper.SetValue(rbTipoProyectoInversion, false);
                PrestamoResult prestamo = PrestamoService.Current.GetResult(new nc.PrestamoFilter() { IdPrestamo = Entity.IdPrestamo }).FirstOrDefault();
                UIHelper.SetValue(txtProyectoCodigo, prestamo.Numero);
                UIHelper.SetValue(liProyectoNombre, prestamo.Denominacion);
            }
            else
            {
                UIHelper.SetValue(rbTipoProyectoInversion, true);
            }
        }	
        public override void GetValue()
        {
			//Entity.IdProyecto = ActualProyecto.IdProyecto ;
			Entity.IdComentarioTecnico = UIHelper.GetInt(ddlComentarioTecnico);
			Entity.Observacion = UIHelper.GetString(txtObservacion);
			Entity.Fecha = UIHelper.GetDateTime(diFecha);
            BuscarNumeroProyecto(false);

        }
        #endregion

        #region Methods
        void BuscarNumeroProyecto(bool validate)
        {
            string codigo = UIHelper.GetString(txtProyectoCodigo);            
            int numero=0;
            Int32.TryParse(codigo, out numero);
            if (numero > 0)
            {
                if (rbTipoProyectoInversion.Checked)
                {
                    BuscarProyectoInversion(numero);
                }
                else
                {
                    BuscarProyectoPrestamo(numero);
                }
            }
            else
            {
                UIHelper.ShowAlert(Translate(string.Format("Proyecto inexistente: {0}", txtProyectoCodigo.Text)), Page);
                UIHelper.Clear(txtProyectoCodigo);
                UIHelper.Clear(liProyectoNombre); 
            }
        }
        bool BuscarProyectoInversion(int num)
        {
            ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = num }).FirstOrDefault();
            if (proyecto == null)
            {
                Entity.IdProyecto = null;
                Entity.IdPrestamo = null;
                UIHelper.ShowAlert(Translate(string.Format("Proyecto inexistente: {0}", txtProyectoCodigo.Text)), Page);
                UIHelper.Clear(txtProyectoCodigo);
                UIHelper.Clear(liProyectoNombre);                
                return false;
            }
            Entity.IdProyecto = proyecto.IdProyecto;
            Entity.IdPrestamo = null;
            UIHelper.SetValue(liProyectoNombre, proyecto.ProyectoDenominacion);
            return true;
        }
        bool BuscarProyectoPrestamo(int num)
        {
            PrestamoResult prestamo = PrestamoService.Current.GetResult(new nc.PrestamoFilter() {  Numero = num }).FirstOrDefault();
            if (prestamo == null)
            {
                Entity.IdProyecto = null;
                Entity.IdPrestamo = null;
                UIHelper.Clear(liProyectoNombre);
                return false;
            }
            Entity.IdPrestamo = prestamo.IdPrestamo;
            Entity.IdProyecto = null;
            UIHelper.SetValue(liProyectoNombre, prestamo.Denominacion);
            return true;
        }
        #endregion

        #region Events
        protected void txtProyectoCodigo_TextChanged(object sender, EventArgs e)
        {
            BuscarNumeroProyecto(false);           
        }
        protected void rbTipoProyecto_OnCheckedChanged(object sender, EventArgs e)
        {
            Entity.IdProyecto = null;
            Entity.IdPrestamo = null;
            UIHelper.Clear(txtProyectoCodigo);
            UIHelper.Clear(liProyectoNombre);
        }
        #endregion



    }
}
