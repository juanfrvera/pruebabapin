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
    public partial class FuenteFinanciamientoEdit : WebControlEdit<nc.FuenteFinanciamiento>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            toFuenteFinanciamientoPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(2);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(lbTipo);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
			UIHelper.Clear(toFuenteFinanciamientoPadre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
                UIHelper.SetValue(chkActivo, Entity.Activo);
			UIHelper.SetValue(chkSeleccionable, Entity.Seleccionable);
			UIHelper.SetValue(toFuenteFinanciamientoPadre, Entity.IdFuenteFinanciamientoPadre);
            UIHelper.SetValue(lbTipo, FuenteFinanciamientoTipoService.Current.GetResult(new nc.FuenteFinanciamientoTipoFilter() { IdFuenteFinanciamientoTipo = Entity.IdFuenteFinanciamientoTipo }).FirstOrDefault().Nombre);	
      	
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
			Entity.IdFuenteFinanciamientoPadre =UIHelper.GetIntNullable(toFuenteFinanciamientoPadre);
            FuenteFinanciamientoPadre_ValueChanged();
        }

        #region Events
        public void toFuenteFinanciamientoPadre_ValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(FuenteFinanciamientoPadre_ValueChanged);
        }

        private void FuenteFinanciamientoPadre_ValueChanged()
        {

            if (UIHelper.GetIntNullable(toFuenteFinanciamientoPadre) != null)
            {
                FuenteFinanciamientoResult FuenteFinanciamientoPadre = FuenteFinanciamientoService.Current.GetResult(new nc.FuenteFinanciamientoFilter() { IdFuenteFinanciamiento = UIHelper.GetIntNullable(toFuenteFinanciamientoPadre) }).FirstOrDefault();
                FuenteFinanciamientoTipoResult FuenteFinanciamientoTipo = FuenteFinanciamientoTipoService.Current.GetResult(new nc.FuenteFinanciamientoTipoFilter() { Nivel = FuenteFinanciamientoPadre.FuenteFinanciamientoTipo_Nivel + 1 }).FirstOrDefault();
                if (FuenteFinanciamientoTipo == null)
                {
                    Entity.IdFuenteFinanciamientoTipo = 0;
                    this.lbTipo.Text = Translate("El Padre no esta permitido");
                    this.lbTipo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Entity.IdFuenteFinanciamientoTipo = FuenteFinanciamientoTipo.IdFuenteFinanciamientoTipo;
                    this.lbTipo.Text = FuenteFinanciamientoTipo.Nombre;
                    this.lbTipo.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                Entity.IdFuenteFinanciamientoTipo = 1;
                this.lbTipo.Text = "";
            }
        }
        #endregion
    }
}
