using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class PrestamoAlcanceGeograficoEdit : WebControlEdit<nc.PrestamoAlcanceGeograficoCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();

            tsAlcanceGeografico.Width = 700;
            // Alcances
            PopUpAlcances.Attributes.CssStyle.Add("display", "none");
		}
		public override void Clear()
        {            
        }	
        public override void GetValue()
        {            
        }
        public override void SetValue()
        {
            PrestamoAlcanceRefresh();
        }
        #endregion Override

        #region Sobre Alcance

        private PrestamoAlcanceGeograficoResult actualPrestamoAlcance;
        protected PrestamoAlcanceGeograficoResult ActualPrestamoAlcance
        {
            get
            {
                if (actualPrestamoAlcance == null)
                    if (ViewState["actualPrestamoAlcance"] != null)
                        actualPrestamoAlcance = ViewState["actualPrestamoAlcance"] as PrestamoAlcanceGeograficoResult;
                    else
                    {
                        actualPrestamoAlcance = GetNewAlcance();
                        ViewState["actualPrestamoAlcance"] = actualPrestamoAlcance;
                    }
                return actualPrestamoAlcance;
            }
            set
            {
                actualPrestamoAlcance = value;
                ViewState["actualPrestamoAlcance"] = value;
            }
        }
        PrestamoAlcanceGeograficoResult GetNewAlcance()
        {
            int id = 0;
            if (Entity.Alcances.Count > 0) id = Entity.Alcances.Min(l => l.IdPrestamoAlcanceGeografico);
            if (id > 0) id = 0;
            id--;
            PrestamoAlcanceGeograficoResult plResult = new PrestamoAlcanceGeograficoResult();
            plResult.IdPrestamoAlcanceGeografico = id;
            plResult.IdPrestamo = Entity.IdPrestamo;
            plResult.IdClasificacionGeografica = 0;
            return plResult;
        }

        #region Methods
        void HidePopUpAlcances()
        {
            ModalPopupExtenderAlcances.Hide();
        }
        void PrestamoAlcanceClear()
        {
            UIHelper.Clear(tsAlcanceGeografico as IWebControlTreeSelect);
            ActualPrestamoAlcance = GetNewAlcance();
        }
        void PrestamoAlcanceSetValue()
        {
            UIHelper.SetValue(tsAlcanceGeografico as IWebControlTreeSelect, ActualPrestamoAlcance.IdClasificacionGeografica);
        }
        void PrestamoAlcanceGetValue()
        {
            ActualPrestamoAlcance.IdClasificacionGeografica = UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect);
            // Busca la clasificacion seleccionada
            ClasificacionGeografica cg = ClasificacionGeograficaService.Current.GetById(ActualPrestamoAlcance.IdClasificacionGeografica);
            ActualPrestamoAlcance.Tipo = cg.IdClasificacionGeograficaTipo;
            ActualPrestamoAlcance.Descripcion = cg.Descripcion;
        }
        void PrestamoAlcanceRefresh()
        {
            UIHelper.Load(gridAlcances, Entity.Alcances, "Orden");
            upGridAlcances.Update();
        }
        protected bool ValidateAlcance()
        {
            int IdClasificacionGeografica = UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect);
            if (IdClasificacionGeografica > 0)
            {
                List<PrestamoAlcanceGeograficoResult> pagr = Entity.Alcances.Where(p => p.IdClasificacionGeografica == IdClasificacionGeografica).ToList();
                if (ActualPrestamoAlcance.ID < 0)
                {
                    if (pagr != null && pagr.Count == 1)
                    {
                        UIHelper.ShowAlert("El Alcance geográfico ya existe en la lista.", upAlcancesPopUp);
                        return false;
                    }
                }
                else
                {
                    if (pagr != null && pagr.Count == 1 && ActualPrestamoAlcance.ID != pagr.FirstOrDefault().ID)
                    {
                        UIHelper.ShowAlert("El Alcance geográfico ya existe en la lista.", upAlcancesPopUp);
                        return false;
                    }

                }
            }
            return true;
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoAlcanceEdit()
        {
            PrestamoAlcanceSetValue();
            ModalPopupExtenderAlcances.Show();
            upAlcancesPopUp.Update();
        }
        void CommandPrestamoAlcanceSave()
        {
            if (UIHelper.GetInt(tsAlcanceGeografico as IWebControlTreeSelect) > 0)
            {
                PrestamoAlcanceGetValue();
                PrestamoAlcanceGeograficoResult result = (from l in Entity.Alcances
                                                          where l.IdPrestamoAlcanceGeografico == ActualPrestamoAlcance.ID
                                                          || l.IdClasificacionGeografica == ActualPrestamoAlcance.IdClasificacionGeografica
                                                          select l).FirstOrDefault();
                if (result != null)
                {
                    result.IdClasificacionGeografica = ActualPrestamoAlcance.IdClasificacionGeografica;
                    result.Tipo = ActualPrestamoAlcance.Tipo;
                    result.Descripcion = ActualPrestamoAlcance.Descripcion;
                }
                else
                {
                    Entity.Alcances.Add(ActualPrestamoAlcance);
                }
                PrestamoAlcanceClear();
                PrestamoAlcanceRefresh();
            }
        }
        void CommandPrestamoAlcanceDelete()
        {

            PrestamoAlcanceGeograficoResult result = (from l in Entity.Alcances where l.IdPrestamoAlcanceGeografico == ActualPrestamoAlcance.ID select l).FirstOrDefault();
            Entity.Alcances.Remove(result);
            PrestamoAlcanceClear();
            PrestamoAlcanceRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveAlcance_Click(object sender, EventArgs e)
        {
            if (ValidateAlcance())
            {
                CallTryMethod(CommandPrestamoAlcanceSave);
                HidePopUpAlcances();
            }
        }
        protected void btNewAlcance_Click(object sender, EventArgs e)
        {
            if (ValidateAlcance())
            {
                CallTryMethod(CommandPrestamoAlcanceSave);
            }
        }
        protected void btCancelAlcance_Click(object sender, EventArgs e)
        {
            PrestamoAlcanceClear();
            HidePopUpAlcances();
        }
        protected void btAgregarAlcance_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderAlcances.Show();
            tsAlcanceGeografico.Focus();
        }
        #endregion

        #region EventosGrillas

        protected void GridAlcances_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoAlcance = (from l in Entity.Alcances where l.IdPrestamoAlcanceGeografico == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoAlcanceEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoAlcanceDelete();
                    break;
            }
        }
        protected virtual void GridAlcances_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridAlcances.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridAlcances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridAlcances.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion Alcance
   }
}
