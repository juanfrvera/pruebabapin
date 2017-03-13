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
	public partial class ClasificacionGeograficaTipoPageListEdit : PageListEdit<nc.ClasificacionGeograficaTipo ,nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditClasificacionGeograficaTipo.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstClasificacionGeograficaTipo;
            webControlFilter = this.ftClasificacionGeograficaTipo;
			webControlEdit = this.editClasificacionGeograficaTipo;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ClasificacionGeograficaTipoPageEdit.aspx";            
            base._Load();
        }
		protected ClasificacionGeograficaTipoService Service
		{
			get { return ClasificacionGeograficaTipoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGeograficaTipo, nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int> EntityService
		{
			get { return ClasificacionGeograficaTipoService.Current; }
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
            upEditClasificacionGeograficaTipo.Update();
            ModalPopupExtenderEditClasificacionGeograficaTipo.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditClasificacionGeograficaTipo.Update();
            ModalPopupExtenderEditClasificacionGeograficaTipo.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditClasificacionGeograficaTipo.Hide();
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
