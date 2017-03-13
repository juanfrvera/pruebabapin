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
    public partial class ProyectoCambioEstructuraFilter : WebControlFilter<nc.ProyectoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            this.toOficina.Width = 400;
            UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccion, JurisdiccionService.Current.GetResult(), "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" }, true, "CodigoInt", Type.GetType("System.Int32"));
            UIHelper.Load<nc.Estado>(lbxEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo =  SistemaEntidadConfig.PROYECTO }), "Nombre", "IdEstado");
			revNroProyecto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(10);
        }
		protected override void Clear()
        {
            ddlSubPrograma.Focus();
            UIHelper.Clear(ddlJurisdiccion);
            UIHelper.Clear(ddlSAF);
            UIHelper.Clear(ddlPrograma);
			UIHelper.Clear(ddlSubPrograma);
            lbxEstado.ClearSelection();
            UIHelper.Clear(chkBorrador);
            UIHelper.Clear(txtNroProyecto);
            UIHelper.Clear(toOficina);
            UIHelper.Clear(ddlRol);
            ClearCombosAnidados();
        }		
		protected override void SetValue()
        {
            ddlSubPrograma.Focus();
            UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF, Filter.IdSaf);
            BuscarProgramas();
            UIHelper.SetValue(ddlPrograma, Filter.IdPrograma);
            BuscarSubProgramas();
            UIHelper.SetValue(ddlSubPrograma, Filter.IdSubPrograma);
            UIHelper.SetValue(toOficina, Filter.IdOficina);
            UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.IncluirOficinasInteriores);
            UIHelper.SetValue(ddlRol, Filter.IdRol);
            UIHelper.SetValue(chkBorrador, Filter.EsBorrador);
            UIHelper.SetValue(txtNroProyecto, Filter.Codigo);
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);
        }        
        protected override void GetValue()
        {            
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSAF);
            Filter.IdPrograma = UIHelper.GetIntNullable(ddlPrograma);
            Filter.IdSubPrograma = UIHelper.GetIntNullable(ddlSubPrograma);
            Filter.EsBorrador = UIHelper.GetBooleanNullable(chkBorrador);
            Filter.IdOficina = UIHelper.GetIntNullable(toOficina);
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);
            Filter.IdRol = UIHelper.GetIntNullable(ddlRol);
            Filter.Codigo = UIHelper.GetIntNullable(txtNroProyecto);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
            int anio=0;
            Filter.Anio = anio==0?null:(int?)anio;
            Filter.IdUsusarioLogeado = UIContext.Current.ContextUser.User.IdUsuario;
            Filter.UnicamentePorCodigo = true;
            Filter.Activo = true;
        }


        #region Events
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSafs);
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProgramas);
        }
        protected void ddlPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSubProgramas);
        }
        protected void btHistoricoPorPlan_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.HISTORY_PLAN);
        }        
        protected void toOficina_OnValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarRoles);
        }
        #endregion
        #region Private Functions
         private void BuscarSafs()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
            if (idJurisdiccion == 0)
            {
                UIHelper.ClearItems(ddlSAF);
                ddlSAF.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.SafResult>(ddlSAF, SafService.Current.GetResult(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", Type.GetType("System.Int32"));

                ddlSAF.Enabled = true;
            }
            BuscarProgramas();
        }
        private void BuscarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            if (idSaf == 0)
            {
                UIHelper.ClearItems(ddlPrograma);
                ddlPrograma.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.ProgramaResult>(ddlPrograma, ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf }), "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" },true,"CodigoInt" ,Type.GetType ("System.Int32"));
                ddlPrograma.Enabled = true;
            }
            BuscarSubProgramas();
        }
        private void BuscarSubProgramas()
        {
            Int32 idPrograma = UIHelper.GetInt(ddlPrograma);
            if (idPrograma == 0)
            {
                UIHelper.ClearItems(ddlSubPrograma);
                ddlSubPrograma.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.SubProgramaResult>(ddlSubPrograma, SubProgramaService.Current.GetResult(new nc.SubProgramaFilter() { IdPrograma = idPrograma }), "CodigoNombre", "IdSubPrograma", new SubProgramaResult() { IdSubPrograma = 0, Codigo = "", Nombre = "Seleccione SubPrograma" },true,"CodigoInt",Type.GetType ("System.Int32"));

                ddlSubPrograma.Enabled = true;
            }
        }        
        private void ClearCombosAnidados()
        {
            UIHelper.ClearItems(ddlSAF);
            ddlSAF.Enabled = false;
            UIHelper.ClearItems(ddlPrograma);
            ddlPrograma.Enabled = false;
            UIHelper.ClearItems(ddlSubPrograma);
            ddlSubPrograma.Enabled = false;
        }
        private void CargarRoles()
        {
            Int32? IdOficina = UIHelper.GetIntNullable(toOficina); ;
            if (IdOficina != null)
            {
                UIHelper.Load<nc.PerfilResult>(ddlRol, PerfilService.Current.GetResult(new nc.PerfilFilter() { IdPerfilTipo = (int)PerfilTipoEnum.Proyecto }), "Nombre", "IdPerfil", new PerfilResult() { IdPerfil = 0, Nombre = "Seleccione Rol" });
                ddlRol.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlRol);
                ddlRol.Enabled = false;
            }
        }

           
        #endregion



      

    }
}
