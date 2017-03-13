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
    public partial class DictamenEdit : WebControlEdit<nc.Dictamen>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
			UIHelper.Load<nc.DictamenTipo>(ddlDictamenTipo, DictamenTipoService.Current.GetList(),"Nombre","IdDictamenTipo",new nc.DictamenTipo(){IdDictamenTipo=0, Nombre= "Seleccione DictamenTipo"});
			UIHelper.Load<nc.Dictamen>(ddlDictamenPadre, DictamenService.Current.GetList(),"Nombre","IdDictamen",new nc.Dictamen(){IdDictamen=0, Nombre= "Seleccione Dictamen"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(chkActivo);
			UIHelper.Clear(ddlDictamenTipo);
			UIHelper.Clear(ddlDictamenPadre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Entity.Activo);
			UIHelper.SetValue(ddlDictamenTipo, Entity.IdDictamenTipo);
			UIHelper.SetValue(ddlDictamenPadre, Entity.IdDictamenPadre);
				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
			Entity.IdDictamenTipo =UIHelper.GetInt(ddlDictamenTipo);
			Entity.IdDictamenPadre =UIHelper.GetIntNullable(ddlDictamenPadre);
				
        }
    }
}
