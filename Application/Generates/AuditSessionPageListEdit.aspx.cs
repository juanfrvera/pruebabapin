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
	public partial class AuditSessionPageListEdit : PageListEdit<nc.AuditSession ,nc.AuditSessionFilter, nc.AuditSessionResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditAuditSession.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstAuditSession;
            webControlFilter = this.ftAuditSession;
			webControlEdit = this.editAuditSession;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AuditSessionPageEdit.aspx";            
            base._Load();
        }
		protected AuditSessionService Service
		{
			get { return AuditSessionService.Current; }
		}
		protected override IEntityService<nc.AuditSession, nc.AuditSessionFilter, nc.AuditSessionResult, int> EntityService
		{
			get { return AuditSessionService.Current; }
		}
		public override IUserInterfaceMessage MessageDisplay
		{
			get {
                if (IsActivePopup)
                       return webControlEdit.FindControl("MessageBarForm") as IUserInterfaceMessage; 
                   else  
                      return Master.FindControl("MessageBarForm") as IUserInterfaceMessage;                    
                }
		}		
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion	
		#region Methods
        protected override void ShowEdit()
        {            
            base.ShowEdit();
            IsActivePopup = true;
            upEditAuditSession.Update();
            ModalPopupExtenderEditAuditSession.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditAuditSession.Update();
            ModalPopupExtenderEditAuditSession.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditAuditSession.Hide();
        }
        #endregion
		#region Events
        protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }       
        protected virtual void btEdit_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
                ControlCommand(Command.EDIT);
        }
        protected virtual void btView_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
               ControlCommand(Command.VIEW);
        }
        protected virtual void btDelete_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
               ControlCommand(Command.DELETE);
        }
        #endregion	
	}
}
