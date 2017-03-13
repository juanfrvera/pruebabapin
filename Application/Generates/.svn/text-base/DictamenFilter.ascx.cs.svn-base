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
    public partial class DictamenFilter : WebControlFilter<nc.DictamenFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			UIHelper.Load<nc.DictamenTipo>(ddlDictamenTipo, DictamenTipoService.Current.GetList(),"Nombre","IdDictamenTipo",new nc.DictamenTipo(){IdDictamenTipo=0, Nombre= "Seleccione DictamenTipo"});
			UIHelper.Load<nc.Dictamen>(ddlDictamenPadre, DictamenService.Current.GetList(),"Nombre","IdDictamen",new nc.Dictamen(){IdDictamen=0, Nombre= "Seleccione Dictamen"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(chkActivo);
			UIHelper.Clear(ddlDictamenTipo);
			UIHelper.Clear(ddlDictamenPadre);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.IdDictamenTipo =UIHelper.GetIntNullable(ddlDictamenTipo);
			Filter.IdDictamenPadre =UIHelper.GetIntNullable(ddlDictamenPadre);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
