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

        public bool EnableCancel
        {
            get { return this.btCancel.Enabled; }
            set { this.btCancel.Enabled= value; }
        }
        public bool EnableDelete
        {
            get { return true; }
            set {/* this.btDelete.Enabled = value;*/ }
        }
        public string ValidationGroup
        {
            get {
                return this.btSave.ValidationGroup; 
                }
            set {
                //this.btAplicate.ValidationGroup = value;
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