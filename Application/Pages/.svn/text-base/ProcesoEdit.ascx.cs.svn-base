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
    public partial class ProcesoEdit : WebControlEdit<nc.Proceso>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.ProyectoTipo>(ddlProyectoTipo, ProyectoTipoService.Current.GetList(new nc.ProyectoTipoFilter() { Activo = true }), "Nombre", "IdProyectoTipo", new nc.ProyectoTipo() { IdProyectoTipo = 0, Nombre = "Seleccione ProyectoTipo" });
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
           // rfvProyectoTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Proyecto");
            rfvProyectoTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Proyecto");
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlProyectoTipo);
			ddlProyectoTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue<ProyectoTipo,int>(ddlProyectoTipo, Entity.IdProyectoTipo, ProyectoTipoService.Current.GetById);
			ddlProyectoTipo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.IdProyectoTipo =UIHelper.GetInt(ddlProyectoTipo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
