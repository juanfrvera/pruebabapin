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
	public partial class ModalidadContratacionPageListEdit : PageListEdit<nc.ModalidadContratacion ,nc.ModalidadContratacionFilter, nc.ModalidadContratacionResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditModalidadContratacion.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstModalidadContratacion;
            webControlFilter = this.ftModalidadContratacion;
			webControlEdit = this.editModalidadContratacion;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ModalidadContratacionPageEdit.aspx";            
            base._Load();
        }
		protected ModalidadContratacionService Service
		{
			get { return ModalidadContratacionService.Current; }
		}
		protected override IEntityService<nc.ModalidadContratacion, nc.ModalidadContratacionFilter, nc.ModalidadContratacionResult, int> EntityService
		{
			get { return ModalidadContratacionService.Current; }
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
            upEditModalidadContratacion.Update();
            ModalPopupExtenderEditModalidadContratacion.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditModalidadContratacion.Update();
            ModalPopupExtenderEditModalidadContratacion.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditModalidadContratacion.Hide();
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
