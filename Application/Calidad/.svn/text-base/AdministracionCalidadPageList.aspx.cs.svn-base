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
    public partial class AdministracionCalidadPageList : PageList<nc.ProyectoCalidad, nc.ProyectoCalidadFilter, nc.ProyectoCalidadResult, int>
    {
        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            EditFilter = "ProyectoCalidadFilter";
            PathEditPage = "AdministracionCalidadPageEdit.aspx";
            SortExpression = "Nombre";
        }
        protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            UIHelper.Load<SistemaCommand>(ddlStoreReport, SistemaCommandService.Current.GetList(new nc.SistemaCommandFilter() { IdsistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Calidad , Activo = true }), "Nombre", "IdSistemaCommand", new SistemaCommand() { IdSistemaCommand = 0, Nombre = "Seleccione Comando" });

        }	
		protected override void _Load()
        {
            webControlList = this.lstAdministracionCalidad;
            webControlFilter = this.ftAdministracionCalidad;
			webControlPaggingButtons = this.pgButtons;            
            base._Load();
        }
        protected ProyectoCalidadService Service
		{
            get { return ProyectoCalidadService.Current; }
		}
        protected override IEntityService<nc.ProyectoCalidad, nc.ProyectoCalidadFilter, nc.ProyectoCalidadResult, int> EntityService
		{
			get { return Service; }
		}
        protected override IViewService<nc.ProyectoCalidad, nc.ProyectoCalidadFilter, ProyectoCalidadResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
        }
        protected override void RefreshList()
        {
            Filter.IgnorarProvincias = true;
            base.RefreshList();
        }
        public override int? GetSelectedRowIndex(int id)
        {
            for (int i = 0, count = List.Count; i < count; i++)
                if (List[i].IdProyecto.Equals(id)) return i + 1;
            return null;
        }
        #endregion Override

        #region Eventos
        protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
        protected void btStoreReport_OnClick(object sender, EventArgs e)
        {
            int idStoreReport = UIHelper.GetInt(ddlStoreReport);
            if (idStoreReport > 0)
                ControlCommand(Command.SHOW_STORE_REPORT, idStoreReport);
        }
        #endregion Eventos
       
    }
}
