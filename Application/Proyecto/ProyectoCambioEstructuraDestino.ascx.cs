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
    public partial class ProyectoCambioEstructuraDestino : WebControlEdit<nc.CambioEstructuraDestino>
    {
        #region Override
               
        protected override void  _Load()
        {
             this.toEjecutor.Width = 390;
             this.toIniciador.Width = 390;
             this.toResponsable.Width = 390;
 	         base._Load();
        }
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<SafResult>(ddlSAF, SafService.Current.GetResultFromList(new nc.SafFilter() { Activo = true }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", Type.GetType("System.Int32"));
            rfvSAF.ErrorMessage = TranslateFormat("FieldIsNull", "Saf");
            rfvPrograma.ErrorMessage = TranslateFormat("FieldIsNull", "Programa");
            rfvPrograma2.ErrorMessage = TranslateFormat("FieldIsNull", "Programa");
            rfvSubPrograma.ErrorMessage = TranslateFormat("FieldIsNull", "Sub Programa");
            rfvSubPrograma2.ErrorMessage = TranslateFormat("FieldIsNull", "Sub Programa");              
		}
		public override void Clear()
        {
            UIHelper.Clear(toIniciador);
            UIHelper.Clear(toEjecutor);
            UIHelper.Clear(toResponsable);
            ClearCombosAnidados();
        }
        public override void SetValue()
        {
            UIHelper.SetValue<Saf, int>(ddlSAF, Entity.IdSAF, SafService.Current.GetById);
            CargarProgramas();
            UIHelper.SetValue<ProgramaResult, int>(ddlPrograma, Entity.IdPrograma, ProgramaService.Current.GetResultById);
            CargarSubProgramas();
            UIHelper.SetValue<SubPrograma, int>(ddlSubPrograma, Entity.IdSubPrograma, SubProgramaService.Current.GetById);

            UIHelper.SetValue(toIniciador, Entity.IdOficinaIniciador);
            UIHelper.SetValue(toEjecutor, Entity.IdOficinaEjecutor);
            UIHelper.SetValue(toResponsable, Entity.IdOficinaResponsable);
        }	
        public override void GetValue()
        {
            if (Entity == null) Entity = new CambioEstructuraDestino();   
            Entity.IdSAF = UIHelper.GetInt(ddlSAF);
            Entity.IdPrograma = UIHelper.GetInt(ddlPrograma);
            Entity.IdSubPrograma = UIHelper.GetInt(ddlSubPrograma);
            Entity.IdOficinaIniciador = UIHelper.GetInt(toIniciador);
            Entity.IdOficinaEjecutor= UIHelper.GetInt(toEjecutor);
            Entity.IdOficinaResponsable = UIHelper.GetInt(toResponsable);          
        }
        #region Events
        protected void ddlSaf_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarProgramas);
        }
        protected void ddlPrograma_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarSubProgramas);
        }
        #endregion
        #region Private Methods
     
        private void ClearCombosAnidados()
        {
            UIHelper.ClearItems(ddlPrograma);
            ddlPrograma.Enabled = false;
            UIHelper.ClearItems(ddlSubPrograma);
            ddlSubPrograma.Enabled = false;
        }        
        private void CargarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            if (idSaf != 0)
            {
                UIHelper.Load<ProgramaResult>(ddlPrograma, ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true}), "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" });
                ddlPrograma.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlPrograma);
                ddlPrograma.Enabled = false;               
            }
            CargarSubProgramas();
        }
        private void CargarSubProgramas()
        {
            Int32 idPrograma = UIHelper.GetInt(ddlPrograma);
            if (idPrograma != 0)
            {
                UIHelper.Load<SubProgramaResult>(ddlSubPrograma, SubProgramaService.Current.GetResult(new nc.SubProgramaFilter() { IdPrograma = idPrograma, Activo=true }), "CodigoNombre", "IdSubPrograma", new SubProgramaResult() { IdSubPrograma = 0, Codigo = "", Nombre = "Seleccione SubPrograma" });
                ddlSubPrograma.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlSubPrograma);
                ddlSubPrograma.Enabled = false;
            }
        }
        private OficinaResult  GetOficinaUsuario(){
            return OficinaService.Current.GetResult  (new nc.OficinaFilter(){ IdOficina  = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault();
        }
        #endregion
        
       
        #endregion
    }
}
