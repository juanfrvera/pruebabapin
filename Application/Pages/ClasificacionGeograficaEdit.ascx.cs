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
    public partial class ClasificacionGeograficaEdit : WebControlEdit<nc.ClasificacionGeografica>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            toClasificacionGeograficaPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(4);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(60);
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
			UIHelper.Clear(toClasificacionGeograficaPadre);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(toClasificacionGeograficaPadre, Entity.IdClasificacionGeograficaPadre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(chkSeleccionable, Entity.Seleccionable);
            UIHelper.SetValue(lbTipo, ClasificacionGeograficaTipoService.Current.GetResult(new nc.ClasificacionGeograficaTipoFilter() { IdClasificacionGeograficaTipo = Entity.IdClasificacionGeograficaTipo }).FirstOrDefault().Nombre);	
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.IdClasificacionGeograficaPadre =UIHelper.GetIntNullable(toClasificacionGeograficaPadre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
            ClasificacionGeograficaPadre_ValueChanged();
        }


        #region Events
        public void toClasificacionGeograficaPadre_ValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ClasificacionGeograficaPadre_ValueChanged);
        }
        private void ClasificacionGeograficaPadre_ValueChanged()
        {
            if (UIHelper.GetIntNullable(toClasificacionGeograficaPadre) != null)
            {
                ClasificacionGeograficaResult ClasPadre = ClasificacionGeograficaService.Current.GetResult(new nc.ClasificacionGeograficaFilter() { IdClasificacionGeografica = UIHelper.GetIntNullable(toClasificacionGeograficaPadre) }).FirstOrDefault();
                ClasificacionGeograficaTipoResult ClasificacionGeograficaTipo = ClasificacionGeograficaTipoService.Current.GetResult(new nc.ClasificacionGeograficaTipoFilter() { Nivel = ClasPadre.ClasificacionGeograficaTipo_Nivel + 1 }).FirstOrDefault();
                if (ClasificacionGeograficaTipo == null)
                {
                    Entity.IdClasificacionGeograficaTipo = 0;
                    this.lbTipo.Text = Translate("El Padre no esta permitido");
                    this.lbTipo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Entity.IdClasificacionGeograficaTipo = ClasificacionGeograficaTipo.IdClasificacionGeograficaTipo;
                    this.lbTipo.Text = ClasificacionGeograficaTipo.Nombre;
                    this.lbTipo.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                Entity.IdClasificacionGeograficaTipo = 1;
                this.lbTipo.Text = "";
            }

        }
        #endregion
    }
}
