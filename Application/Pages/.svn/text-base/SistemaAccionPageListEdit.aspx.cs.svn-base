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
	public partial class SistemaAccionPageListEdit : PageListEdit<nc.SistemaAccion ,nc.SistemaAccionFilter, nc.SistemaAccionResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditSistemaAccion.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstSistemaAccion;
            webControlFilter = this.ftSistemaAccion;
			webControlEdit = this.editSistemaAccion;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SistemaAccionPageEdit.aspx";            
            base._Load();
        }
		protected SistemaAccionService Service
		{
			get { return SistemaAccionService.Current; }
		}
		protected override IEntityService<nc.SistemaAccion, nc.SistemaAccionFilter, nc.SistemaAccionResult, int> EntityService
		{
			get { return SistemaAccionService.Current; }
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
            upEditSistemaAccion.Update();
            ModalPopupExtenderEditSistemaAccion.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditSistemaAccion.Update();
            ModalPopupExtenderEditSistemaAccion.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditSistemaAccion.Hide();
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
