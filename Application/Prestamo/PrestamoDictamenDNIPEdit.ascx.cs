using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using nc = Contract;
using Service;
namespace UI.Web
{
    public partial class PrestamoDictamenDNIPEdit : WebControlEdit<nc.PrestamoDictamenDNIPCompose>
    {

        public override void SetValue()
        {
            PrestamoDictamenRefresh();
        }
        public override void GetValue()
        {
        }
        public override void Clear()
        {
            UIHelper.Clear(gridDictamen);
        }
        #region Dictamen
        private nc.PrestamoDictamenCompose actualPrestamoDictamen;
        protected nc.PrestamoDictamenCompose ActualPrestamoDictamen
        {
            get
            {
                if (actualPrestamoDictamen == null)
                    if (ViewState["actualPrestamoDictamen"] != null)
                        actualPrestamoDictamen = ViewState["actualPrestamoDictamen"] as nc.PrestamoDictamenCompose;
                    else
                    {
                        actualPrestamoDictamen = GetNewPrestamoDictamen();
                        ViewState["actualPrestamoDictamen"] = actualPrestamoDictamen;
                    }
                return actualPrestamoDictamen;
            }
            set
            {
                actualPrestamoDictamen = value;
                ViewState["actualPrestamoDictamen"] = value;
            }
        }
        nc.PrestamoDictamenCompose GetNewPrestamoDictamen()
        {
            return PrestamoDictamenComposeService.Current.GetNew();
        }
        void HidePopUpDictamen()
        {
            ModalPopupExtenderDictamen.Hide();
        }
        void ShowPopUpDictamen()
        {
            ModalPopupExtenderDictamen.Show();
            upDictamenPopUp.Update();
        }
        #region EventosGrillas

        protected void GridDictamen_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualPrestamoDictamen = PrestamoDictamenComposeService.Current.GetById(id);
            //ActualPrestamoDictamen =  (from o in Entity.prestamoDictamen where o.IdPrestamoDictamen == id select o).FirstOrDefault();
            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoDictamenEdit();
                    break;
            }
        }
        protected virtual void GridDictamen_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridDictamen.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridDictamen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridDictamen.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion
        #region Events
        protected void btSaveDictamen_Click(object sender, EventArgs e)
        {
        }
        protected void btNewDictamen_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelDictamen1_Click(object sender, EventArgs e)
        {
            PrestamoDictamenClear();
            HidePopUpDictamen();
        }
        #endregion
        #region Commands
        void CommandPrestamoDictamenEdit()
        {
            PrestamoDictamenSetValue();
            UIHelper.CallTryMethod(ShowPopUpDictamen);
        }
        void CommandPrestamoDictamenSave()
        {
        }
        void CommandPrestamoDictamenDelete()
        {
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void PrestamoDictamenClear()
        {
            pDictamen.Clear();
            ActualPrestamoDictamen = GetNewPrestamoDictamen();
        }
        void PrestamoDictamenSetValue()
        {
            pDictamen.Entity = ActualPrestamoDictamen;
            pDictamen.SetValue();
        }
        void PrestamoDictamenGetValue()
        {
        }
        void PrestamoDictamenRefresh()
        {
            UIHelper.Load(gridDictamen, Entity.prestamoDictamen);
        }
        #endregion

        #endregion

    }
}