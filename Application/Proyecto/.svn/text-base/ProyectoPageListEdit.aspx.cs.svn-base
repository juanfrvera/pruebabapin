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
    public partial class ProyectoPageListEdit : PageListEdit<nc.ProyectoGeneralCompose, nc.ProyectoFilter, nc.ProyectoResult, int>
    {
		#region Override
        
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditProyecto.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstProyecto;
            webControlFilter = this.ftProyecto;
			webControlEdit = this.editProyecto;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProyectoPageEdit.aspx";            
            base._Load();
        }
		protected ProyectoService Service
		{
			get { return ProyectoService.Current; }
		}
		protected override IEntityService<nc.ProyectoGeneralCompose , nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
		{
			get { return ProyectoComposeService.Current; }
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
            upEditProyecto.Update();
            ModalPopupExtenderEditProyecto.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditProyecto.Update();
            ModalPopupExtenderEditProyecto.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditProyecto.Hide();
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
