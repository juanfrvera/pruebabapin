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
	public partial class MessageSendPageEdit : PageEdit<nc.MessageSend ,nc.MessageSendFilter, nc.MessageSendResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editMessageSend;            
            PathListPage = "MessageSendPageList.aspx";            
            base._Load();
        }
		protected MessageSendService Service
		{
			get { return MessageSendService.Current; }
		}
		protected override IEntityService<nc.MessageSend, nc.MessageSendFilter, nc.MessageSendResult, int> EntityService
		{
			get { return MessageSendService.Current; }
		}
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        protected override void CommandOthers()
        {
            switch (CommandName)
            {
                case Command.CLOSE:
                    CommandClose();
                    break;
            }
        }
        void CommandClose()
        {            
            if (!Entity.IsRead && Entity.IdUserTo == UIContext.Current.ContextUser.User.IdUsuario)
            {//si es el usuario al que se le envio el mail y no lo leyo , se le marca como leido
                Entity.IsRead = true;
                Entity.ReadDate = DateTime.Now;
                EntityService.Save(Entity, this.ContextUser);                
            }
            HideEdit();
            HideEdit();
            RefreshList();
            ShowList();
        }
		#endregion

        #region Events
        protected virtual void btClose_Click(object sender, EventArgs e)
        {
            ControlCommand(Command.CLOSE);
        }
        #endregion
    }
}
