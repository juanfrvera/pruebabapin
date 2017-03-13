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
    public partial class AdministracionCalidadFilter : WebControlFilter<nc.ProyectoCalidadFilter>
    {
        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.EstadoResult>(lbxEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO }), "Nombre", "IdEstado", "Orden", SortDirection.Ascending);
            UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione Tipo de Plan" });
            UIHelper.Load<nc.OrganismoTipo>(ddlOrganismoTipo, OrganismoTipoService.Current.GetList(), "Nombre", "IdOrganismoTipo", new nc.OrganismoTipo() { IdOrganismoTipo = 0, Nombre = "Seleccione Tipo de Organismo" });
            UIHelper.Load<nc.UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new Contract.UsuarioFilter() { EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new nc.UsuarioResult() { IdUsuario = 0, Persona_Apellido = "Seleccione un analista" });
            UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyecto, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, }), "Nombre", "IdProyectoTipo", new ProyectoTipoResult() { IdProyectoTipo = 0, Nombre = "Seleccione Uno" });
            UIHelper.Load < nc.EstadoResult>(lbxEstadoCalidad, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_CALIDAD }), "Nombre", "IdEstado", "Orden", SortDirection.Ascending);
            revNroProyecto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(10);
            ddlSAF.Enabled = false;
            ddlPlanPeriodo.Enabled = false;
            ddlPlanVersion.Enabled = false;
            ddlPrograma.Enabled = false;
		}
		protected override void Clear()
        {
            UIHelper.Clear(ddlSAF);
            UIHelper.Clear(ddlPrograma);
            UIHelper.Clear(ddlAnalista);            
            UIHelper.Clear(ddlPlanTipo);
            UIHelper.Clear(ddlPlanPeriodo);
            UIHelper.Clear(ddlPlanVersion);
            lbxEstado.ClearSelection();
            ddlProceso.ClearSelection();
            UIHelper.Clear(ddlOrganismoTipo);
            UIHelper.Clear(ddlTipoProyecto);
            UIHelper.Clear(drFechaEstado);
            UIHelper.Clear(txtNroProyecto);
            lbxEstadoCalidad.ClearSelection();
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue(ddlAnalista,Filter.IdUsuarioModificacion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF,Filter.IdSaf);
            BuscarProgramas();
            UIHelper.SetValue(ddlPrograma,Filter.IdPrograma);
            UIHelper.SetValue(ddlPlanTipo,Filter.IdPlanTipo);
            BuscarPlan();
            UIHelper.SetValue(ddlPlanPeriodo, Filter.IdPlanPeriodo);
            UIHelper.SetValue(ddlPlanVersion, Filter.IdPlanVersion);

            UIHelper.SetValue(lbxEstado, Filter.Estados );
            UIHelper.SetValue(ddlOrganismoTipo,Filter.IdOrganismoTipo);
            UIHelper.SetValue(ddlTipoProyecto, Filter.IdProyectoTipo);
            BuscarProceso();
            UIHelper.SetValue(ddlProceso, Filter.Procesos);
            UIHelper.SetValue<DateTime?>(drFechaEstado, Filter.FechaEstado, Filter.FechaEstado_To);
            UIHelper.SetValue(lbxEstadoCalidad, Filter.EstadosCalidad);
            UIHelper.SetValue(txtNroProyecto, Filter.Proyecto_Codigo);
        }	
        protected override void GetValue()
        {
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSAF);
            Filter.IdPrograma = UIHelper.GetIntNullable(ddlPrograma);
            Filter.IdUsuarioModificacion = UIHelper.GetIntNullable(ddlAnalista);
            Filter.IdPlanVersion = UIHelper.GetInt(ddlPlanVersion);
            Filter.IdPlanPeriodo = UIHelper.GetInt(ddlPlanPeriodo);
            Filter.IdPlanTipo = UIHelper.GetInt(ddlPlanTipo);
            Filter.Estados = UIHelper.GetSelectedIntValues(lbxEstado);
            //Filter.IdProceso  = UIHelper.GetInt(ddlProceso);
            Filter.IdOrganismoTipo = UIHelper.GetIntNullable(ddlOrganismoTipo);
            Filter.IdProyectoTipo = UIHelper.GetIntNullable(ddlTipoProyecto);
            Filter.FechaEstado = UIHelper.GetValueFromDate(drFechaEstado);
            Filter.FechaEstado_To = UIHelper.GetValueToDate(drFechaEstado);
            Filter.EstadosCalidad = UIHelper.GetSelectedIntValues(lbxEstadoCalidad );
            Filter.Proyecto_Codigo = UIHelper.GetInt(txtNroProyecto );
            Filter.ProyectoActivo = true;
            Filter.ProyectoBorrador = false ;
        }
        #endregion

        #region Eventos
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            //this.Filter.OrderByProperty = "Proyecto_Codigo";
            RaiseControlCommand(Command.SEARCH);
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProgramas);
        }
        protected void ddlPlanTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarPlan);
        }
        protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSafs);
        }
        protected void ddlTipoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProceso);
        }
        #endregion

        #region Metodos
        private void BuscarPlan()
        {
            Int32 idPlanTipo = UIHelper.GetInt(ddlPlanTipo);
            if (idPlanTipo == 0)
            {
                UIHelper.ClearItems(ddlPlanPeriodo);
                ddlPlanPeriodo.Enabled = false;
                UIHelper.ClearItems(ddlPlanVersion);
                ddlPlanVersion.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(new nc.PlanPeriodoFilter() { IdPlanTipo = idPlanTipo }), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período de Plan" });
                UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo }), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión de Plan" });
                ddlPlanPeriodo.Enabled = true;
                ddlPlanVersion.Enabled = true;
            }
        }
        private void BuscarSafs()
        {
            Int32? idTipo = UIHelper.GetIntNullable(ddlOrganismoTipo);
            Int32? idSectorialista = UIHelper.GetIntNullable(ddlAnalista);
            UIHelper.ClearItems(ddlSAF);
            UIHelper.Load<nc.SafResult>(ddlSAF, SafService.Current.GetResult(new nc.SafFilter() { IdTipoOrganismo = idTipo, IdSectorialistaPrograma = idSectorialista }), "CodigoDenominacion", "IdSaf", new nc.SafResult() { IdSaf = 0, CodigoDenominacion = "Seleccione SAF" });
            for (int i = 0; i < ddlSAF.Items.Count; i++)
            {
                ddlSAF.Items[i].Attributes.Add("title", ddlSAF.Items[i].Text);
            }
            ddlSAF.Enabled = ddlSAF.Items.Count >0;
            BuscarProgramas();
        }
        private void BuscarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            if (idSaf == 0)
            {
                UIHelper.ClearItems(ddlPrograma);                
            }
            else
            {
                Int32 idAnalista = UIHelper.GetInt(ddlAnalista);
                UIHelper.Load<nc.ProgramaResult>(ddlPrograma, ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, IdSectorialista = idAnalista }), "CodigoNombre", "IdPrograma", new nc.ProgramaResult() { IdPrograma = 0, Nombre = "Seleccione Programa" });
            }
            ddlPrograma.Enabled = ddlPrograma.Items.Count > 0;
        }
        private void BuscarProceso()
        {

            Int32 idTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);
            if (idTipoProyecto == 0)
            {
                UIHelper.Clear(ddlProceso);
            }
            else
            {
                UIHelper.Load<nc.ProcesoResult>(ddlProceso, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { IdProyectoTipo = idTipoProyecto }), "Nombre", "IdProceso", new ProcesoResult() { IdProceso = 0, Nombre ="Seleccione Proceso" });
            }
            
        }
        #endregion

     

    }
}
