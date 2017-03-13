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
    public partial class SistemaEntidadEdit : WebControlEdit<nc.SistemaEntidadCompose>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
			revEntidadClase.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revEntidadClaseBase.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revEntidadTipo.ValidationExpression = Contract.DataHelper.GetExpRegString(50);
            revEntidadTipo.ErrorMessage = TranslateFormat("InvalidField", "EntidadTipo");
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revEntidadClase.ErrorMessage = TranslateFormat("InvalidField", "Entidad Clase");
            revEntidadClaseBase.ErrorMessage = TranslateFormat("InvalidField", "Entidad Clase Base");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvEntidadTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Entidad");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtEntidadClase);
			UIHelper.Clear(txtEntidadClaseBase);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(dlAcciones);
            UIHelper.Clear(dlEstados);
            UIHelper.Clear(chkIncluirSeguridad);
            UIHelper.Clear(chkIncluirConfiguracion);
            UIHelper.Clear(txtEntidadTipo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Entidad.Codigo);
			txtCodigo.Focus();
            UIHelper.SetValue(txtNombre, Entity.Entidad.Nombre);
            UIHelper.SetValue(txtEntidadClase, Entity.Entidad.EntidadClase);
            UIHelper.SetValue(txtEntidadClaseBase, Entity.Entidad.EntidadClaseBase);
            UIHelper.SetValue(chkActivo, Entity.Entidad.Activo);
            UIHelper.Sort<SistemaEntidadAccionResult>(Entity.Acciones, "SistemaAccion_Nombre");
            UIHelper.SetValue(dlAcciones, Entity.Acciones);
            UIHelper.Sort<SistemaEntidadEstadoResult>(Entity.Estados, "Estado_Nombre");
            UIHelper.SetValue(dlEstados, Entity.Estados);
            UIHelper.SetValue(chkIncluirSeguridad, Entity.Entidad.IncluirSeguridad);
            UIHelper.SetValue(chkIncluirConfiguracion, Entity.Entidad.IncluirConfiguracion);
            UIHelper.SetValue(txtEntidadTipo, Entity.Entidad.EntidadTipo);	
        }	
        public override void GetValue()
        {
			Entity.Entidad.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Entidad.Nombre =UIHelper.GetString(txtNombre);
            Entity.Entidad.EntidadClase = UIHelper.GetString(txtEntidadClase);
            Entity.Entidad.EntidadClaseBase = UIHelper.GetString(txtEntidadClaseBase);
            Entity.Entidad.Activo = UIHelper.GetBoolean(chkActivo);
            Update(dlAcciones, Entity.Acciones);
            Update(dlEstados, Entity.Estados);
            Entity.Entidad.IncluirSeguridad = UIHelper.GetBoolean(chkIncluirSeguridad);
            Entity.Entidad.IncluirConfiguracion = UIHelper.GetBoolean(chkIncluirConfiguracion);
            Entity.Entidad.EntidadTipo = UIHelper.GetString(txtEntidadTipo);
        }
        private void Update(DataList dataList, List<SistemaEntidadAccionResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                SistemaEntidadAccionResult item = (from o in list where o.IdSistemaAccion == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }
        private void Update(DataList dataList, List<SistemaEntidadEstadoResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                SistemaEntidadEstadoResult item = (from o in list where o.IdEstado == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }
    }
}
