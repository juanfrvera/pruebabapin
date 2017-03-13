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
	public partial class IndicadorRubroPageListEdit : PageListEdit<nc.IndicadorRubro ,nc.IndicadorRubroFilter, nc.IndicadorRubroResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditIndicadorRubro.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstIndicadorRubro;
            webControlFilter = this.ftIndicadorRubro;
			webControlEdit = this.editIndicadorRubro;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "IndicadorRubroPageEdit.aspx";            
            base._Load();
        }
		protected IndicadorRubroService Service
		{
			get { return IndicadorRubroService.Current; }
		}
		protected override IEntityService<nc.IndicadorRubro, nc.IndicadorRubroFilter, nc.IndicadorRubroResult, int> EntityService
		{
			get { return IndicadorRubroService.Current; }
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
            upEditIndicadorRubro.Update();
            ModalPopupExtenderEditIndicadorRubro.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditIndicadorRubro.Update();
            ModalPopupExtenderEditIndicadorRubro.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditIndicadorRubro.Hide();
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
