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
    public partial class CaracterEconomicoEdit : WebControlEdit<nc.CaracterEconomico>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            toCaracterEconomicoPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            
		}
		public override void Clear()
        {			
			 txtCodigo.Focus();
				UIHelper.Clear(txtCodigo);
			UIHelper.Clear(txtNombre);
            UIHelper.Clear(lbTipo);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
			UIHelper.Clear(toCaracterEconomicoPadre);
				
        }		
		public override void SetValue()
        {			
		     txtCodigo.Focus();
				UIHelper.SetValue(txtCodigo, Entity.Codigo);
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(chkSeleccionable, Entity.Seleccionable);
			UIHelper.SetValue(toCaracterEconomicoPadre, Entity.IdCaracterEconomicoPadre);
            UIHelper.SetValue(lbTipo, CaracterEconomicoTipoService.Current.GetResult(new nc.CaracterEconomicoTipoFilter() { IdCaracterEconomicoTipo = Entity.IdCaracterEconomicoTipo }).FirstOrDefault().Nombre);	
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
			Entity.IdCaracterEconomicoPadre =UIHelper.GetIntNullable(toCaracterEconomicoPadre);
            CaracterEconomicoPadre_ValueChanged();
        }


        #region Events
        public void toCaracterEconomicoPadre_ValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CaracterEconomicoPadre_ValueChanged);
        }
        private void CaracterEconomicoPadre_ValueChanged()
        {
            if (UIHelper.GetIntNullable(toCaracterEconomicoPadre) != null)
            {
                CaracterEconomicoResult ClasPadre = CaracterEconomicoService.Current.GetResult(new nc.CaracterEconomicoFilter() { IdCaracterEconomico = UIHelper.GetIntNullable(toCaracterEconomicoPadre) }).FirstOrDefault();
                CaracterEconomicoTipoResult CaracterEconomicoTipo = CaracterEconomicoTipoService.Current.GetResult(new nc.CaracterEconomicoTipoFilter() { Nivel = ClasPadre.CaracterEconomicoTipo_Nivel + 1 }).FirstOrDefault();
                if (CaracterEconomicoTipo == null)
                {
                    Entity.IdCaracterEconomicoTipo = 0;
                    this.lbTipo.Text = Translate("El Padre no esta permitido");
                    this.lbTipo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Entity.IdCaracterEconomicoTipo = CaracterEconomicoTipo.IdCaracterEconomicoTipo;
                    this.lbTipo.Text = CaracterEconomicoTipo.Nombre;
                    this.lbTipo.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                Entity.IdCaracterEconomicoTipo = 1;
                this.lbTipo.Text = "";
            }

        }
        #endregion
    }
}
