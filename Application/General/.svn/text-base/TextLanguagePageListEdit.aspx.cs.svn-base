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
	public partial class TextLanguagePageListEdit : PageListEdit<nc.TextLanguage ,nc.TextLanguageFilter, nc.TextLanguageResult, int>
    {
		#region Override
		protected override void _Initialize()
        {
			base._Initialize();
            pnPopUpEditTextLanguage.Attributes.CssStyle.Add("display", "none");
        }	
		protected override void _Load()
        {
            webControlList = this.lstTextLanguage;
            webControlFilter = this.ftTextLanguage;
			webControlEdit = this.editTextLanguage;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "TextLanguagePageEdit.aspx";            
            base._Load();
        }
		protected TextLanguageService Service
		{
			get { return TextLanguageService.Current; }
		}
		protected override IEntityService<nc.TextLanguage, nc.TextLanguageFilter, nc.TextLanguageResult, int> EntityService
		{
			get { return TextLanguageService.Current; }
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
            upEditTextLanguage.Update();
            ModalPopupExtenderEditTextLanguage.Show();            
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditTextLanguage.Update();
            ModalPopupExtenderEditTextLanguage.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditTextLanguage.Hide();
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
