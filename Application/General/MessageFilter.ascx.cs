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
    public partial class MessageFilter : WebControlFilter<nc.MessageFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.MessageMedia>(ddlMediaFrom, MessageMediaService.Current.GetList(),"Name","IdMessageMedia",new nc.MessageMedia(){IdMessageMedia=0, Name= "Seleccione MessageMedia"});
			UIHelper.Load<nc.Usuario>(ddlUserFrom, UsuarioService.Current.GetList(),"NombreUsuario","IdUsuario",new nc.Usuario(){IdUsuario=0, NombreUsuario= "Seleccione Usuario"});
			UIHelper.Load<nc.Priority>(ddlPriority, PriorityService.Current.GetList(),"Name","IdPriority",new nc.Priority(){IdPriority=0, Name= "Seleccione Priority"});
			revSubject.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
			revBody.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revSubject.ErrorMessage = TranslateFormat("InvalidField", "Asunto");
            revBody.ErrorMessage = TranslateFormat("InvalidField", "Cuerpo del Mail");
			UIHelper.Load<nc.Proyecto>(ddlProyecto, ProyectoService.Current.GetList(),"ProyectoDenominacion","IdProyecto",new nc.Proyecto(){IdProyecto=0, ProyectoDenominacion= "Seleccione Proyecto"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlMediaFrom);
			ddlMediaFrom.Focus();
				UIHelper.Clear(ddlUserFrom);
			UIHelper.Clear(ddlPriority);
			UIHelper.Clear(txtSubject);
			UIHelper.Clear(txtBody);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdSendDate);
			UIHelper.Clear(chkIsManual);
			UIHelper.Clear(ddlProyecto);
				
        }		
		protected override void SetValue()
        {ddlMediaFrom.Focus();
				UIHelper.SetValueFilter(txtSubject, Filter.Subject);
						UIHelper.SetValueFilter(txtBody, Filter.Body);
                        UIHelper.SetValue(ddlMediaFrom, Filter.IdMediaFrom);
                        UIHelper.SetValue(ddlUserFrom, Filter.IdUserFrom);
                        UIHelper.SetValue(ddlPriority, Filter.IdPriority);
                        UIHelper.SetValue(ddlProyecto, Filter.IdProyecto);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdSendDate, Filter.SendDate, Filter.SendDate_To);
						UIHelper.SetValue(chkIsManual, Filter.IsManual);
							
        }	
        protected override void GetValue()
        {
			Filter.IdMediaFrom =UIHelper.GetIntNullable(ddlMediaFrom);
			Filter.IdUserFrom =UIHelper.GetIntNullable(ddlUserFrom);
			Filter.IdPriority =UIHelper.GetIntNullable(ddlPriority);
            Filter.Subject = UIHelper.GetStringBetweenFilter(txtSubject);
            Filter.Body = UIHelper.GetStringBetweenFilter(txtBody);
            Filter.StartDate = UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
            Filter.SendDate = UIHelper.GetValueFromDate(rdSendDate);
            Filter.SendDate_To = UIHelper.GetValueToDate(rdSendDate);
			Filter.IsManual=UIHelper.GetBooleanNullable(chkIsManual);			  
			Filter.IdProyecto =UIHelper.GetIntNullable(ddlProyecto);

        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
