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
    public partial class MessageSendEdit : WebControlEdit<nc.MessageSend>
    { 
		protected override void _Initialize()
        {
            base._Initialize();				
		}        
		public override void Clear()
        {			
			UIHelper.Clear(lbFecha);			
		    UIHelper.Clear(lbFechaLeido);
			UIHelper.Clear(lbUserFrom);
			UIHelper.Clear(lbUserTo);
            UIHelper.Clear(lbBody);
            UIHelper.Clear(lbBAPIN);
            UIHelper.Clear(lbPrioridad);
            UIHelper.Clear(chkEsManual);
            UIHelper.Clear(chkLeido);
            UIHelper.Clear(lbDenominacionBAPIN);
            UIHelper.Clear(lbAsunto);
            UIHelper.Clear(lbFechaLeido);
        }		
		public override void SetValue()
        {
            if (Entity.IdMessageSend > 0)
            {
                MessageCompose compose = MessageComposeService.Current.GetById(Entity.IdMessage);
                MessageSendResult result = MessageSendService.Current.GetResult(new Contract.MessageSendFilter() { IdMessageSend = Entity.IdMessageSend }).FirstOrDefault();
                if (compose != null)
                {
                    UIHelper.SetValue(lbFecha, compose.Message.StartDate);
                    if (Entity.IdUserTo == UIContext.Current.ContextUser.User.ID)
                    {
                        UIHelper.SetValue(lbFechaLeido, Entity.ReadDate.HasValue ? Entity.ReadDate.Value : DateTime.Now);
                    }
                    UIHelper.SetValue(lbUserFrom, result.Message_UserFrom_NombreCompleto);
                    UIHelper.SetValue(lbUserTo, result.UserTo_NombreCompleto);
                    UIHelper.SetValue(lbBody, compose.Message.Body);
                    UIHelper.SetValue(lbBAPIN, compose.Message.Proyecto_Codigo);
                    UIHelper.SetValue(lbPrioridad, compose.Message.Priority_Name);
                    UIHelper.SetValue(chkEsManual, compose.Message.IsManual);
                    UIHelper.SetValue(chkLeido, result.IsRead);
                    UIHelper.SetValue(lbDenominacionBAPIN, compose.Message.Proyecto_ProyectoDenominacion);
                    UIHelper.SetValue(lbAsunto, compose.Message.Subject);
                }
            }
            else
            {
                Clear();
            }
        }	
        public override void GetValue()
        {			
        }
    }
}
