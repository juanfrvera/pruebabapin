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
	public partial class ComentarioTecnicoPageListEdit : PageListEdit<nc.ComentarioTecnico ,nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditComentarioTecnico.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstComentarioTecnico;
            webControlFilter = this.ftComentarioTecnico;
			webControlEdit = this.editComentarioTecnico;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ComentarioTecnicoPageEdit.aspx";            
            base._Load();
        }
		protected ComentarioTecnicoService Service
		{
			get { return ComentarioTecnicoService.Current; }
		}
		protected override IEntityService<nc.ComentarioTecnico, nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int> EntityService
		{
			get { return ComentarioTecnicoService.Current; }
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
            upEditComentarioTecnico.Update();
            ModalPopupExtenderEditComentarioTecnico.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditComentarioTecnico.Update();
            ModalPopupExtenderEditComentarioTecnico.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditComentarioTecnico.Hide();
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
