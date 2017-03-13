using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;
using System.Collections;

namespace UI.Web
{
    public partial class ProyectoCambioEstructuraPageList : PageList<nc.Proyecto, nc.ProyectoFilter, nc.ProyectoResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            OrderBys.Add(new FilterOrderBy("Saf_Jurisdiccion"));
            OrderBys.Add(new FilterOrderBy("Saf_Codigo"));
            OrderBys.Add(new FilterOrderBy("Programa_Codigo"));
            OrderBys.Add(new FilterOrderBy("SubPrograma_Codigo"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
            rbOnlySelectedItems.Checked = true;
        }
        protected override void _Load()
        {
            webControlList = this.lstProyecto;
            webControlFilter = this.ftProyecto;
            webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProyectoPageEdit.aspx";  
            base._Load();
        }
        protected ProyectoService Service
        {
            get { return ProyectoService.Current; }
        }
        protected override IEntityService<nc.Proyecto, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return Service; }
        }
        protected override IViewService<nc.Proyecto, nc.ProyectoFilter, ProyectoResult, int> ViewService
        {
            get { return Service; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        protected override void RefreshList()
        {
            Filter.IdsOficinaByUsuario = null;
            List = ProyectoService.Current.GetResult(Filter);
            if (List.TotalRows.HasValue) this.webControlPaggingButtons.RefreshPagging(List.TotalRows.Value);
            webControlList.DataSource = List;
            webControlList.DataBind();
        }
        #endregion

        #region Methods
        protected override void CommandOthers()
        {
            switch (CommandName)
            { 
                case Command.CHANGE_STRUCTURE:
                    ChangedStructure();
                    break;
            }            
            base.CommandOthers();
        }
        protected void ChangedStructure()
        {
            destinoProyecto.GetValue(); 
            UIHelper.Validate(destinoProyecto.Entity.IsChanged, "Debe seleccionar al menos un parametro de destino");

            Hashtable args = new Hashtable();                       
            args.Add("CambioEstructuraDestino", destinoProyecto.Entity);

            if (this.rbAllItems.Checked)
            {                
                EntityService.Execute(this.ftProyecto.GetFilter(),ActionConfig.CHANGE_STRUCTURE, ContextUser, args);
                RefreshStruture();
            }
            else
            {
                int[] SelectedsId = this.lstProyecto.GetSelectedIds();
                UIHelper.Validate(SelectedsId.Length > 0, "Debe seleccionar al menos un Item");                
                EntityService.Execute(SelectedsId, ActionConfig.CHANGE_STRUCTURE, ContextUser, args);
                RefreshStruture();
            }
        }
        protected void RefreshStruture()
        {
            this.lstProyecto.ClearAllSelecteds();
            destinoProyecto.Clear();
            RefreshList();
        }
        #endregion
        
        #region Events

        protected void btClearSelecteds_OnClick(object sender, EventArgs e)
        {
            this.lstProyecto.ClearAllSelecteds();
        }
        protected void btCopiaHistoria_OnClick(object sender, EventArgs e)
        {
           ///pendiente hacer la copia historia , para lo cual primero hay que terminar el reporte por Proyecto.
        }
        protected void btCambiarEstructura_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.CHANGE_STRUCTURE);
        }
        #endregion
    }
}
