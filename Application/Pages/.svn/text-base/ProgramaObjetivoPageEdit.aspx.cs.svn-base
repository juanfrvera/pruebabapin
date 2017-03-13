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
	public partial class ProgramaObjetivoPageEdit : PageEdit<nc.ProgramaObjetivosCompose ,nc.ProgramaFilter, nc.ProgramaResult, int>
    {	
		#region Override
        protected override void _Initialize()
        {
            base._Initialize();
            this.editButtons.VisibleSaveAndNew = false;
        }
		protected override void _Load()
        {
            webControlEdit = this.editProgramaObjetivo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProgramaObjetivoPageList.aspx";
            base._Load();
        }
		protected ProgramaService Service
		{
			get { return ProgramaService.Current; }
		}
        protected override IEntityService<nc.ProgramaObjetivosCompose, nc.ProgramaFilter, nc.ProgramaResult, int> EntityService
		{
            get { return ProgramaObjetivosComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}

		#endregion
	}
}
