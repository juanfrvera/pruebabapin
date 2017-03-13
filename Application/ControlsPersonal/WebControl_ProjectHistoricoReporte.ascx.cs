using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using Service;

namespace UI.Web
{
    public partial class WebControl_ProjectHistoricoReporte : WebControlPopup
    {
        #region Properties
        private ProyectoResult result;
        public virtual ProyectoResult Result
        {
            get
            {
                if (result == null)
                {
                    if (ViewState["result"] != null)
                        result = ViewState["result"] as ProyectoResult;
                }
                return result;
            }
            set
            {
                result = value;
                ViewState["result"] = value;
            }
        }
        private ReportHistoryInfo info;
        public virtual ReportHistoryInfo Info
        {
            get
            {
                if (info == null)
                {
                    if (ViewState["info"] != null)
                        info = ViewState["info"] as ReportHistoryInfo;
                    if (info == null) info = new ReportHistoryInfo();
                }
                return info;
            }
            set
            {
                info = value;
                ViewState["info"] = value;
            }
        }
        #endregion

        #region Methods
        protected override void _Initialize()
        {
            base._Initialize();
            //btAceptar.Attributes.Add("onclick", "PleaseWaitButton('" + btAceptar.ClientID + "');$('" + btCancelar.ClientID + "').disabled=true; ");     
        
        }
        public override void HidePopup()
        {
            Clear();
            mpePopupHistoryReport.Hide();
        }
        public override void ShowPopup()
        {
            mpePopupHistoryReport.Show();
            Clear();
            SetValue();            
        }
        public void Aceptar()
        {
            GetValue();
            RaiseControlCommand(CommandName, Result);
            Clear();
            SetValue();
            upControls.Update();
        }        
        public void Clear()
        {            
            upControls.Update();
            UIHelper.Clear(lblProyectoCodigo);
            UIHelper.Clear(lblProyectoDenominacion);
            UIHelper.Clear(txtComentario);
            UIHelper.Clear(GridReports);
            UIHelper.Clear(GridEstadoDesicionHistorico);
        }
        protected void SetValue()
        {
            if (Result != null)
            {
                SistemaReporte sistemaReporte = SistemaReporteService.Current.FirstOrDefault(new SistemaReporteFilter(){ Codigo = "Proyecto"});
                if(sistemaReporte != null)
                {
                    UIHelper.SetValue(lblProyectoCodigo, Result.Codigo);
                    UIHelper.SetValue(lblProyectoDenominacion, Result.ProyectoDenominacion);
                    List<SistemaReporteHistoricoResult> reporteshistoricos = SistemaReporteHistoricoService.Current.GetResult(new Contract.SistemaReporteHistoricoFilter() { IdSistemaReporte = sistemaReporte.IdSistemaReporte, EntityId = Result.IdProyecto.ToString(), });
                    UIHelper.Load(GridReports, reporteshistoricos);

                    List<EstadoDeDesicionHistoricoResult> result = EstadoDeDesicionHistoricoService.Current.GetResult(new Contract.EstadoDeDesicionHistoricoFilter() { IdProyecto = Result.ID });
                    UIHelper.Load(GridEstadoDesicionHistorico, result);
  
                    upControls.Update();            
                }
                else
                {
                    Clear();
                }
            }
            else
            {
                Clear();
            }
        }
        protected void GetValue()
        {
            Info.Comments = UIHelper.GetString(txtComentario);
        }
        #endregion 

        #region Events
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            CallTryMethod(Aceptar);
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #region Events
        protected void btCancelarHistDecision_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion
        protected virtual void Grid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            RaiseControlCommand(e.CommandName, e.CommandArgument);
            SetValue();
        }
        #endregion

        

        
    }
}