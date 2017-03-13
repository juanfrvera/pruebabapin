using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class PrestamoService : _PrestamoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoService() {}
	   public static PrestamoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public virtual ListPaged<PrestamoResult> GetResultWithOfficePerfil(PrestamoFilter filter)
       {
           return Business.GetResultWithOfficePerfil(filter);
       }
       public virtual PrestamoResult GetResultById(int id)
       {
           return Business.GetResultById(id);
       }
       #region Reportes
       public List<PrestamoObjetivoReportResult> GetPrestamoObjetivo(PrestamoFilter filter)
       {
           return PrestamoBusiness.Current.GetPrestamoObjetivo(filter);
       }
       public List<PrestamoObjetivoReportResult> GetPrestamoObjetivosEspecificos(PrestamoFilter filter)
       {
           return PrestamoBusiness.Current.GetPrestamoObjetivosEspecificos(filter);
       }
       public List<PrestamoComponentesReportResult> GetPrestamoComponentes(PrestamoFilter filter)
       {
           return PrestamoBusiness.Current.GetPrestamoComponentes(filter);
       }

       public ReportInfo GetReport(int idReporte, PrestamoReportInfo  reportInfo)
       {
           return PrestamoBusiness.Current.GetReport(idReporte, reportInfo);
       }
       #endregion
    }

    public class PrestamoComposeService : EntityComposeService<PrestamoGeneralCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static PrestamoComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoComposeService"; } }

        protected readonly PrestamoGeneralComposeBusiness Business = PrestamoGeneralComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoGeneralCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public void ActualizarFuncionarios(PrestamoGeneralCompose compose)
        {
            PrestamoGeneralComposeBusiness.Current.ActualizarFuncionarios(compose);
        }


        public List<PrestamoOficinaFuncionarioResult> GetPrestamoOficinaPerfilFuncionarioResult(Int32 IdOficina)
        {
            return PrestamoGeneralComposeBusiness.Current.GetPrestamoOficinaPerfilFuncionarioResult(IdOficina);
        }
    }
}
