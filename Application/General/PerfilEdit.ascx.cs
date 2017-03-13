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
    public partial class PerfilEdit : WebControlEdit<nc.PerfilCompose>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revCodigo.ValidationExpression = Contract.DataHelper.GetExpRegString(5);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvPerfilTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Perfil");
            UIHelper.Load<nc.PerfilTipo>(ddlPerfilTipo, PerfilTipoService.Current.GetList(), "Nombre", "IdPerfilTipo", new nc.PerfilTipo() { IdPerfilTipo = 0, Nombre = "Seleccione Tipo Perfil" });
            //pnlHerencia
        
        }
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(ddlPerfilTipo);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(chkEsDefault);
			
            UIHelper.Clear(dlActividades);
            UIHelper.Clear(txtCodigo );	
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Perfil.Nombre);
			txtNombre.Focus();
            UIHelper.SetValue(ddlPerfilTipo, Entity.Perfil.IdPerfilTipo);
            UIHelper.SetValue(chkActivo, Entity.Perfil.Activo);
            UIHelper.SetValue(chkEsDefault, Entity.Perfil.EsDefault);
            
            UIHelper.Sort<PerfilActividadResult>(Entity.Actividades, "Actividad_Nombre");
            UIHelper.SetValue(dlActividades, Entity.Actividades);
            UIHelper.SetValue(txtCodigo , Entity.Perfil.Codigo );	
        }	
        public override void GetValue()
        {
            Entity.Perfil.Nombre = UIHelper.GetString(txtNombre);
            Entity.Perfil.IdPerfilTipo = UIHelper.GetInt(ddlPerfilTipo);
            Entity.Perfil.Activo = UIHelper.GetBoolean(chkActivo);
            Entity.Perfil.EsDefault = UIHelper.GetBoolean(chkEsDefault);
            Entity.Perfil.Codigo = UIHelper.GetString(txtCodigo);
            Update(dlActividades, Entity.Actividades);
        }
        private void Update(DataList dataList, List<PerfilActividadResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                PerfilActividadResult item = (from o in list where o.IdActividad == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }        
    }
}
