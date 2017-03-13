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
    public partial class FinalidadFuncionEdit : WebControlEdit<nc.FinalidadFuncion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            toFinalidadFuncionPadre.Width = 500;
            toFinalidadFuncionPadre.RequiredMessage = TranslateFormat("FieldIsNull", "Finalidad Función Padre");
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(3);
			revDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominación");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtDenominacion);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
            UIHelper.Clear(lbTipo);
            UIHelper.Clear(toFinalidadFuncionPadre);	
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtDenominacion, Entity.Denominacion);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(chkSeleccionable, Entity.Seleccionable);
            UIHelper.SetValue(toFinalidadFuncionPadre, Entity.IdFinalidadFuncionPadre);
            UIHelper.SetValue(lbTipo, FinalidadFuncionTipoService.Current.GetResult(new nc.FinalidadFuncionTipoFilter() { IdFinalidadFuncionTipo = Entity.IdFinalidadFunciontipo }).FirstOrDefault().Nombre);	
      	
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Denominacion =UIHelper.GetString(txtDenominacion);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
            Entity.IdFinalidadFuncionPadre = UIHelper.GetIntNullable(toFinalidadFuncionPadre);
            FinalidadFuncionPadre_ValueChanged();
        }

        #region Events
        public void toFinalidadFuncionPadre_ValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(FinalidadFuncionPadre_ValueChanged);
        }
        private void FinalidadFuncionPadre_ValueChanged()
        {
            if (UIHelper.GetIntNullable(toFinalidadFuncionPadre) != null)
            {
                FinalidadFuncionResult FinalidadFuncionPadre = FinalidadFuncionService.Current.GetResult(new nc.FinalidadFuncionFilter() { IdFinalidadFuncion = UIHelper.GetIntNullable(toFinalidadFuncionPadre) }).FirstOrDefault();
                FinalidadFuncionTipoResult FinalidadFuncionTipo = FinalidadFuncionTipoService.Current.GetResult(new nc.FinalidadFuncionTipoFilter() { Nivel = FinalidadFuncionPadre.FinalidadFunciontipo_Nivel + 1 }).FirstOrDefault();
                if (FinalidadFuncionTipo == null)
                {
                    Entity.IdFinalidadFunciontipo = 0;
                    this.lbTipo.Text = Translate("El Padre no esta permitido");
                    this.lbTipo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Entity.IdFinalidadFunciontipo = FinalidadFuncionTipo.IdFinalidadFuncionTipo;
                    this.lbTipo.Text = FinalidadFuncionTipo.Nombre;
                    this.lbTipo.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                Entity.IdFinalidadFunciontipo = 1;
                this.lbTipo.Text = "";
            }
        }
        #endregion
    }
}
