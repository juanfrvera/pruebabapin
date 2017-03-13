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
	public partial class MessagePageEdit : PageEdit<nc.MessageCompose ,nc.MessageFilter, nc.MessageResult, int>
    {	
		#region Override
        protected override void _Initialize()
        {
            base._Initialize();
            this.editButtons.VisibleAplicate = false;
            this.editButtons.TextSave = "Enviar";
            this.editButtons.TextSaveAndNew = "Enviar y Crear Nuevo";
        }
		protected override void _Load()
        {
            webControlEdit = this.editMessage;            
            webControlEditionButtons = this.editButtons;
            PathListPage = "MessagePageList.aspx";
            base._Load();
        }
		protected MessageComposeService Service
		{
            get { return MessageComposeService.Current; }
		}
        protected override IEntityService<nc.MessageCompose, nc.MessageFilter, nc.MessageResult, int> EntityService
		{
            get { return MessageComposeService.Current; }
		}		
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
