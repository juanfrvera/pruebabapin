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
using Contract;
using Service;
namespace UI.Web
{
    public partial class PrestamoEditDictamenEdit : WebControlEdit<nc.PrestamoEditDictamenCompose >
    {
        protected override void _Initialize()
        {
            base._Initialize();
            PopUpDictamen.Attributes.CssStyle.Add("display", "none");
        }
        public override void SetValue()
        {
            PrestamoDictamenRefresh();
            ProyectoComentarioTecnicoRefresh();
        }

        public override void GetValue()
        {
        }

        public override void Clear()
        {
            UIHelper.Clear(gridDictamen);
        }

         #region Dictamen
         private PrestamoDictamenCompose  actualPrestamoDictamen;
         protected PrestamoDictamenCompose ActualPrestamoDictamen
         {
             get
             {
                 if (actualPrestamoDictamen == null)
                     if (ViewState["actualPrestamoDictamen"] != null)
                         actualPrestamoDictamen = ViewState["actualPrestamoDictamen"] as PrestamoDictamenCompose;
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
         PrestamoDictamenCompose GetNewPrestamoDictamen()
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
          //   upDictamenPopUp.Update();
         }
         #region EventosGrillas

         protected void GridDictamen_RowCommand(Object sender, GridViewCommandEventArgs e)
         {
             int id;
             if (!int.TryParse(e.CommandArgument.ToString(), out id))
                 return;
             ActualPrestamoDictamen = PrestamoDictamenComposeService.Current.GetById(id);
             //ActualPrestamoDictamen = (from o in Entity.Dictamenes  where o.IdPrestamoDictamen  == id select o).FirstOrDefault();


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
                 gridDictamen .PageIndex = 0;
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
             upDictamenPopUp.Update();
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
             pDictamen.SetReadOnly();
             pDictamen.Entity = ActualPrestamoDictamen;
             pDictamen.SetValue();
         }
         void PrestamoDictamenGetValue()
         {
            
         }
         void PrestamoDictamenRefresh()
         {
             UIHelper.Load(gridDictamen, Entity.Dictamenes );
             upGridDictamenes.Update();
         }
         #endregion


         #endregion



         #region ProyectoComentarioTecnico
         private ProyectoComentarioTecnicoResult actualProyectoComentarioTecnico;
         protected ProyectoComentarioTecnicoResult ActualProyectoComentarioTecnico
         {
             get
             {
                 if (actualProyectoComentarioTecnico == null)
                     if (ViewState["actualProyectoComentarioTecnico"] != null)
                         actualProyectoComentarioTecnico = ViewState["actualProyectoComentarioTecnico"] as ProyectoComentarioTecnicoResult;
                     else
                     {
                         actualProyectoComentarioTecnico = GetNewProyectoComentarioTecnico();
                         ViewState["actualProyectoComentarioTecnico"] = actualProyectoComentarioTecnico;
                     }
                 return actualProyectoComentarioTecnico;
             }
             set
             {
                 actualProyectoComentarioTecnico = value;
                 ViewState["actualProyectoComentarioTecnico"] = value;
             }
         }
         ProyectoComentarioTecnicoResult GetNewProyectoComentarioTecnico()
         {
             return new ProyectoComentarioTecnicoResult();
         }
         void HidePopUpProyectoComentarioTecnico()
         {
             ModalPopupExtenderComentarioTecnico.Hide();
         }
         void ShowPopUpProyectoComentarioTecnico()
         {
             ModalPopupExtenderComentarioTecnico.Show();
             //upProyectoComentarioTecnicoPopUp.Update();
         }
         #region EventosGrillas

         protected void GridProyectoComentarioTecnico_RowCommand(Object sender, GridViewCommandEventArgs e)
         {
             int id;
             if (!int.TryParse(e.CommandArgument.ToString(), out id))
                 return;
             ActualProyectoComentarioTecnico = (from o in Entity.ProyectoComentarioTecnico where o.IdProyectoComentarioTecnico == id select o).FirstOrDefault();


             switch (e.CommandName)
             {
                 case Command.EDIT:
                     CommandProyectoComentarioTecnicoEdit();
                     break;

             }

         }

         protected virtual void GridProyectoComentarioTecnico_Sorting(object sender, GridViewSortEventArgs e)
         {
             try
             {
                 gridProyectoComentarioTecnico.PageIndex = 0;
                 RaiseControlCommand(Command.SORT, e);
             }
             catch (Exception exception)
             {
                 AddException(exception);
             }
         }
         protected virtual void GridProyectoComentarioTecnico_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             try
             {
                 gridProyectoComentarioTecnico.PageIndex = e.NewPageIndex;
                 base.RaiseControlCommand(Command.REFRESH);
             }
             catch (Exception exception)
             {
                 AddException(exception);
             }
         }

         #endregion
         #region Events
         protected void btSaveProyectoComentarioTecnico_Click(object sender, EventArgs e)
         {
         }
         protected void btNewProyectoComentarioTecnico_Click(object sender, EventArgs e)
         {
         }
         protected void btCancelProyectoComentarioTecnico1_Click(object sender, EventArgs e)
         {
             ProyectoComentarioTecnicoClear();
             HidePopUpProyectoComentarioTecnico();
         }

         #endregion
         #region Commands
         void CommandProyectoComentarioTecnicoEdit()
         {
             ProyectoComentarioTecnicoSetValue();
             UIHelper.CallTryMethod(ShowPopUpProyectoComentarioTecnico);
         }
         void CommandProyectoComentarioTecnicoSave()
         {

         }
         void CommandProyectoComentarioTecnicoDelete()
         {
         }
         #endregion
         #region Clear SetValue GetValue Refresh
         void ProyectoComentarioTecnicoClear()
         {
             ctlProyectoComentarioTecnico.Clear();
             ActualProyectoComentarioTecnico = GetNewProyectoComentarioTecnico();
         }
         void ProyectoComentarioTecnicoSetValue()
         {
             ctlProyectoComentarioTecnico.Entity = ActualProyectoComentarioTecnico.ToEntity();
             ctlProyectoComentarioTecnico.SetValue();
             upComentarioTecnicoPopUp.Update();

         }
         void ProyectoComentarioTecnicoGetValue()
         {

         }
         void ProyectoComentarioTecnicoRefresh()
         {
             Entity.ProyectoComentarioTecnico = Entity.ProyectoComentarioTecnico.OrderByDescending(i => i.Fecha).ToList();
             UIHelper.Load(gridProyectoComentarioTecnico, Entity.ProyectoComentarioTecnico);
             upGridDictamenes.Update();
         }
         #endregion


         #endregion



    }
}