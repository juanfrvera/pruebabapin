using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public partial class WebControlEditionButtons : WebControlBase, IEditionButtons
    {

        #region Enable Buttons
        #region Text
        public string TextCancel
        {
            get { return this.btCancel.Text; }
            set
            {
                this.btCancel.Text = value;
            }
        }
        public string TextDelete
        {
            get { return this.btDelete != null ? this.btDelete.Text : ""; }
            set
            {
                if (this.btDelete != null)
                    this.btDelete.Text = value;
            }
        }
        public string TextAplicate
        {
            get { return this.btAplicate != null ? this.btAplicate.Text : ""; }
            set
            {
                if (this.btAplicate != null)
                    this.btAplicate.Text = value;
            }
        }
        public string TextSave
        {
            get { return this.btSave != null ? this.btSave.Text : ""; }
            set
            {
                if (this.btSave != null)
                    this.btSave.Text = value;
            }
        }
        public string TextSaveAndNew
        {
            get { return this.btSaveAndNew != null ? this.btSaveAndNew.Text : ""; }
            set
            {
                if (this.btSaveAndNew != null)
                    this.btSaveAndNew.Text = value;
            }
        }
        #endregion
        #region Enable
        public bool EnableCancel
        {
            get { return this.btCancel.Enabled; }
            set { this.btCancel.Enabled= value; 
                }
        }
        public bool EnableDelete
        {
            get { return this.btDelete!=null?this.btDelete.Enabled:false; }
            set { if(this.btDelete !=null)
                     this.btDelete.Enabled = value; 
                }
        }
        public bool EnableAplicate
        {
            get { return this.btAplicate != null ? this.btAplicate.Enabled : false; }
            set
            {
                if (this.btAplicate != null)
                    this.btAplicate.Enabled = value;
            }
        }
        public bool EnableSave
        {
            get { return this.btSave != null ? this.btSave.Enabled : false; }
            set
            {
                if (this.btSave != null)
                    this.btSave.Enabled = value;
            }
        }
        public bool EnableSaveAndNew
        {
            get { return this.btSaveAndNew != null ? this.btSaveAndNew.Enabled : false; }
            set
            {
                if (this.btSaveAndNew != null)
                    this.btSaveAndNew.Enabled = value;
            }
        }
        #endregion
        #region Visible
        public bool VisibleCancel
        {
            get { return this.btCancel.Visible; }
            set
            {
                this.btCancel.Visible = value;
            }
        }
        public bool VisibleDelete
        {
            get { return this.btDelete != null ? this.btDelete.Visible : false; }
            set
            {
                if (this.btDelete != null)
                    this.btDelete.Visible = value;
            }
        }
        public bool VisibleAplicate
        {
            get { return this.btAplicate != null ? this.btAplicate.Visible : false; }
            set
            {
                if (this.btAplicate != null)
                    this.btAplicate.Visible = value;
            }
        }
        public bool VisibleSave
        {
            get { return this.btSave != null ? this.btSave.Visible : false; }
            set
            {
                if (this.btSave != null)
                    this.btSave.Visible = value;
            }
        }
        public bool VisibleSaveAndNew
        {
            get { return this.btSaveAndNew != null ? this.btSaveAndNew.Visible : false; }
            set
            {
                if (this.btSaveAndNew != null)
                    this.btSaveAndNew.Visible = value;
            }
        }
        #endregion
        #endregion
        public string ValidationGroup
        {
            get {
                return this.btSave.ValidationGroup; 
                }
            set {
                this.btAplicate.ValidationGroup = value;
                this.btSave.ValidationGroup = value;
                this.btSaveAndNew.ValidationGroup = value;
                }
        }
        #region Events
        protected virtual void btCancel_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CANCEL);
        }
        protected virtual void btDelete_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.DELETE);
        }
        protected virtual void btSaveAndNew_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SAVE_AND_NEW);
        }
        protected virtual void btSave_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SAVE);
        }
        protected virtual void btAplicate_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.APPLY);
        }
        #endregion

    }
}