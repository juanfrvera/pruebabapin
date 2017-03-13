using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc=Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{    
	public partial class ActividadPageEdit : PageEdit<nc.ActividadCompose ,nc.ActividadFilter, nc.ActividadResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editActividad;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ActividadPageList.aspx";            
            base._Load();
        }
		protected ActividadComposeService Service
		{
			get { return ActividadComposeService.Current; }
		}
		protected override IEntityService<nc.ActividadCompose, nc.ActividadFilter, nc.ActividadResult, int> EntityService
		{
			get { return ActividadComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        public override bool CanById(int id, string actionName)
        {
            return ActividadService.Current.Can(new Contract.Actividad() { IdActividad = id }, actionName, UIContext.Current.ContextUser);
        }
		#endregion
	}
}
