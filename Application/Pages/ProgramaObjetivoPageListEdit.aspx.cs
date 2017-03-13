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
	public partial class ProgramaObjetivoPageListEdit : PageListEdit<nc.ProgramaObjetivo ,nc.ProgramaObjetivoFilter, nc.ProgramaObjetivoResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditProgramaObjetivo.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstProgramaObjetivo;
            webControlFilter = this.ftProgramaObjetivo;
			//webControlEdit = this.editProgramaObjetivo;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProgramaObjetivoPageEdit.aspx";            
            base._Load();
        }
		protected ProgramaObjetivoService Service
		{
			get { return ProgramaObjetivoService.Current; }
		}
		protected override IEntityService<nc.ProgramaObjetivo, nc.ProgramaObjetivoFilter, nc.ProgramaObjetivoResult, int> EntityService
		{
			get { return ProgramaObjetivoService.Current; }
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
            upEditProgramaObjetivo.Update();
            ModalPopupExtenderEditProgramaObjetivo.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditProgramaObjetivo.Update();
            ModalPopupExtenderEditProgramaObjetivo.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditProgramaObjetivo.Hide();
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
