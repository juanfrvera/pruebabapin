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
    public partial class ClasificacionGastoEdit : WebControlEdit<nc.ClasificacionGasto>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            toCaracterEconomico.Width = 500;
            toClasificacionGastoPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(4);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(90);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            toCaracterEconomico.RequiredMessage = TranslateFormat("FieldIsNull", "Caracter Económico");
            rfvClasificacionGastoRubro.ErrorMessage = TranslateFormat("FieldIsNull", "Clasificación del Gasto Rubro");
           UIHelper.Load<nc.ClasificacionGastoRubro>(ddlClasificacionGastoRubro, ClasificacionGastoRubroService.Current.GetList(), "Nombre", "IdClasificacionGastoRubro", new nc.ClasificacionGastoRubro() { IdClasificacionGastoRubro = 0, Nombre = "Seleccione Clasificación Gasto Rubro" });
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(toCaracterEconomico);
            UIHelper.Clear(lbTipo);
            //UIHelper.Clear(ddlClasificacionGastoRubro);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
			//UIHelper.Clear(toClasificacionGastoPadre);
				
        }		
		public override void SetValue()
        {	
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
			UIHelper.SetValue(txtNombre, Entity.Nombre);
            UIHelper.SetValue(toCaracterEconomico, Entity.IdCaracterEconomico);
            UIHelper.SetValue(ddlClasificacionGastoRubro, Entity.IdClasificacionGastoRubro);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(chkSeleccionable, Entity.Seleccionable);
			UIHelper.SetValue(toClasificacionGastoPadre, Entity.IdClasificacionGastoPadre);
            UIHelper.SetValue(lbTipo, ClasificacionGastoTipoService.Current.GetResult(new nc.ClasificacionGastoTipoFilter() { IdClasificacionGastoTipo = Entity.IdClasificacionGastoTipo }).FirstOrDefault().Nombre);	
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
            Entity.IdCaracterEconomico = UIHelper.GetIntNullable(toCaracterEconomico);
            Entity.IdClasificacionGastoRubro = UIHelper.GetInt(ddlClasificacionGastoRubro);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
			Entity.IdClasificacionGastoPadre =UIHelper.GetIntNullable(toClasificacionGastoPadre);
            ClasificacionGastoPadre_ValueChanged();

        }

        #region Events
        public void toClasificacionGastoPadre_ValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ClasificacionGastoPadre_ValueChanged);
        }
        private void ClasificacionGastoPadre_ValueChanged()
        {
            if (UIHelper.GetIntNullable(toClasificacionGastoPadre) != null)
            {
                ClasificacionGastoResult ClasPadre = ClasificacionGastoService.Current.GetResult(new nc.ClasificacionGastoFilter() { IdClasificacionGasto = UIHelper.GetIntNullable(toClasificacionGastoPadre) }).FirstOrDefault();
                ClasificacionGastoTipoResult ClasificacionGastoTipo = ClasificacionGastoTipoService.Current.GetResult(new nc.ClasificacionGastoTipoFilter() { Nivel = ClasPadre.ClasificacionGastoTipo_Nivel + 1 }).FirstOrDefault();
                if (ClasificacionGastoTipo == null)
                {
                    Entity.IdClasificacionGastoTipo = 0;
                    this.lbTipo.Text = Translate("El Padre no esta permitido");
                    this.lbTipo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Entity.IdClasificacionGastoTipo = ClasificacionGastoTipo.IdClasificacionGastoTipo;
                    this.lbTipo.Text = ClasificacionGastoTipo.Nombre;
                    this.lbTipo.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                Entity.IdClasificacionGastoTipo = 1;
                this.lbTipo.Text = "";
            }

        }
        #endregion
    }
}
