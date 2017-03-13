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
    public partial class WebControl_ProjectEstadoDesicionHistorico : WebControlPopup
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
        private int idProyecto;
        public virtual int IdProyecto
        {
            get
            {
                if (idProyecto == null)
                {
                    if (ViewState["idProyecto"] != null)
                        int.TryParse(ViewState["idProyecto"].ToString(),out idProyecto);                      
                   
                }
                return idProyecto;
            }
            set
            {
                idProyecto = value;
                ViewState["idProyecto"] = value;
            }
        }
        #endregion

        #region Methods
        protected override void _Initialize()
        {
            base._Initialize();
        }
        public override void HidePopup()
        {
            Clear();
            mpePopupEstadoDesicionHistorico.Hide();
        }
        public override void ShowPopup()
        {
            mpePopupEstadoDesicionHistorico.Show();
            Clear();
            SetValue();            
        }
        public void Aceptar()
        {
            GetValue();
            RaiseControlCommand(CommandName, Result);  
        }        
        public void Clear()
        {            
            upControls.Update();           
            UIHelper.Clear(GridEstadoDesicionHistorico);
        }
        protected void SetValue()
        { 
            if (IdProyecto > 0)
            {
                List<EstadoDeDesicionHistoricoResult> result = EstadoDeDesicionHistoricoService.Current.GetResult(new Contract.EstadoDeDesicionHistoricoFilter() { IdProyecto = IdProyecto });
                UIHelper.Load(GridEstadoDesicionHistorico, result);
                upControls.Update();            
            }
            else
            {
                Clear();
            }            
        }
        protected void GetValue()
        {           
        }
        #endregion 

        #region Events        
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion

        

        
    }
}