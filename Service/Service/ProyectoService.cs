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
    public class ProyectoService : _ProyectoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoService() {}
	   public static ProyectoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Gets
       public virtual ListPaged<ProyectoResult> GetResultWithOfficePerfil(ProyectoFilter filter)
       {
           return Business.GetResultWithOfficePerfil(filter);
       }
       public virtual ListPaged<ProyectoResult> GetResultFromListWithOfficePerfil(ProyectoFilter filter)
       {
           return Business.GetResultFromListWithOfficePerfil(filter);
       }       
       public List<ProyectoReportResult> GetProyectoReport(ProyectoFilter filter)
       {
           return Business.GetProyectoReport(filter);
       }     
       public List<ProyectoObjetivoReportResult> GetProyectoObjetivo(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoObjetivo(filter);
       }
       public List<ProyectoObjetivoReportResult> GetProyectoProducto(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoProducto(filter);
       }
       public List<ProyectoEtapaReportResult> GetProyectoEtapa(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoEtapa(filter);
       }
       public List<ProyectoCronogramaReportResult> GetCronograma(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetCronograma(filter);
       }
       public List<ProyectoBeneficiosReportResult> GetProyectoBeneficio(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoBeneficio(filter);
       }
       public List<ProyectoBeneficiarioReportResult> GetProyectoBeneficiario(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoBeneficiario(filter);
       }
       public List<ProyectoObjetivoReportResult> GetProyectoObjetivoFines(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyectoObjetivoFines(filter);
       }
       public List<ProyectoOficinaPerfilFuncionarioResult> GetProyectoOficinaPerfilFuncionarioResult(Int32 IdOficina)
       {
           return ProyectoGeneralComposeBusiness.Current.GetProyectoOficinaPerfilFuncionarioResult(IdOficina);
       }

       //Matias 20140512 - Tarea 133
       public virtual ListPaged<ProyectoResult> GetResultGraficos(ProyectoFilter filter)
       {
           //ListPaged<ProyectoResult> result = GetResult(filter);
           //LoadPerfilOficinas(result);
           //return result;
           return ProyectoBusiness.Current.GetResultGraficos(filter);
       }
       public virtual ListPaged<ProyectoResult> GetResultGraficosLocalizaciones(ProyectoFilter filter)
       {
           //ListPaged<ProyectoResult> result = GetResult(filter);
           //LoadPerfilOficinas(result);
           //return result;
           return ProyectoBusiness.Current.GetResultGraficosLocalizaciones(filter);
       }
       public virtual ListPaged<ProyectoResult> GetResultGraficosPrestamos(ProyectoFilter filter)
       {
           //ListPaged<ProyectoResult> result = GetResult(filter);
           //LoadPerfilOficinas(result);
           //return result;
           return ProyectoBusiness.Current.GetResultGraficosPrestamos(filter);
       }
       public virtual ListPaged<ProyectoResult> GetResultGraficosLocalizacionesPartido(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetResultGraficosLocalizacionesPartido(filter);
       }
       //FinMatias 20140512 - Tarea 133

       //Matias 20141014 - Tarea 158
       public virtual ListPaged<ProyectoResult> GetResultGraficosProvincia(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetResultGraficosProvincia(filter);
       }
       public virtual ProyectoResult GetProyecto(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetProyecto(filter);
       }
       //FinMatias 20141014 - Tarea 158

       public virtual ListPaged<ProyectoResult> GetResultSP(ProyectoFilter filter)
       {
           return ProyectoBusiness.Current.GetResultSP(filter);
       }
       
       #endregion

       #region Actions
       public void CopyAndSave(int id, ProyectCopy proyectoCopy, IContextUser contextUser)
       {
           ProyectoBusiness.Current.CopyAndSave(id, proyectoCopy, contextUser);
       }
       protected override object ExecuteAction(Proyecto entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           switch (actionName)
           {
               case ActionConfig.POSTULAR:
                  Business.CambiarEstadoDeDesicion(entity, EstadoDeDesicionConfig.POSTULADO, contextUser,args);
                  break;
               case ActionConfig.CONFORMAR:
                  Business.CambiarEstadoDeDesicion(entity, EstadoDeDesicionConfig.CONFORMADO, contextUser,args);
                  break;
               case ActionConfig.ACEPTAR:
                  Business.CambiarEstadoDeDesicion(entity, EstadoDeDesicionConfig.ACEPTADO, contextUser,args);
                  break;
               case ActionConfig.OBSERVAR:
                  Business.CambiarEstadoDeDesicion(entity, EstadoDeDesicionConfig.OBSERVADO, contextUser,args);
                  break;
               case ActionConfig.REINICIAR:
                  Business.CambiarEstadoDeDesicion(entity, EstadoDeDesicionConfig.REINICIADO, contextUser,args);
                  break;
           }
           return null;
       }
       protected override object ExecuteAction(ProyectoFilter filter, string actionName, IContextUser contextUser, Hashtable args)
       {
           switch (actionName)
           {
               case ActionConfig.HISTORY_PLAN:
                   EntityBusiness.ExecuteStoreProcedure("spProyectoHistoricoPlan", filter);
                   break;
               case ActionConfig.CHANGE_STRUCTURE:
                   Business.ChangeStructure(filter, args["CambioEstructuraDestino"] as CambioEstructuraDestino, contextUser);
                   break;
           }
           return null;
       }
       protected override object ExecuteAction(int[] ids, string actionName, IContextUser contextUser, Hashtable args)
       {
           switch (actionName)
           {
               case ActionConfig.CHANGE_STRUCTURE:
                   Business.ChangeStructure(ids, args["CambioEstructuraDestino"] as CambioEstructuraDestino, contextUser);
                   break;
           }
           return null;
       }
       #endregion

    }
    public class ProyectoComposeService : EntityComposeService<ProyectoGeneralCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static ProyectoComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoComposeService"; } }

        protected readonly ProyectoGeneralComposeBusiness Business = ProyectoGeneralComposeBusiness.Current ;
        protected override IEntityBusiness<ProyectoGeneralCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }
    }

}
