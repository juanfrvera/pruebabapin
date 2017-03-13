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
	public partial class EtapaPageEdit : PageEdit<nc.Etapa ,nc.EtapaFilter, nc.EtapaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editEtapa;
            webControlEditionButtons = this.editButtons;
            PathListPage = "EtapaPageList.aspx";            
            base._Load();
        }
		protected EtapaService Service
		{
			get { return EtapaService.Current; }
		}
		protected override IEntityService<nc.Etapa, nc.EtapaFilter, nc.EtapaResult, int> EntityService
		{
			get { return EtapaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
