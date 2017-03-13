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
    public class OficinaService : _OficinaService 
    {	  
	   #region Singleton
	   private static volatile OficinaService current;
	   private static object syncRoot = new Object();

	   //private OficinaService() {}
	   public static OficinaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public ListPaged<NodeResult> GetNodesResult(OficinaFilter filter)
       {
           return Business.GetNodesResult(filter);
       }

       

       #region Store Procedures
       public List<int> GetIdsOficinaPorUsuario(int IdUsuario)
       {
           return Business.GetIdsOficinaPorUsuario(IdUsuario);
       }
       public void RefreshOficina()
       {
           Business.RefreshOficina();
       }
       public void RefreshOficina(int? idOficina)
       {
           Business.RefreshOficina(idOficina);
       }
       #endregion
    }
    public class OficinaComposeService : EntityComposeService<OficinaCompose, OficinaFilter, OficinaResult, int>
    {
        #region Singleton
        private static volatile OficinaComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static OficinaComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new OficinaComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "OficinaComposeService"; } }

        protected readonly OficinaComposeBusiness Business = new OficinaComposeBusiness();
        protected override IEntityBusiness<OficinaCompose, OficinaFilter, OficinaResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return OficinaService.Current.Execute(id, actionName, contextUser, args);
        }
        public List<OficinaSafProgramaResult> GetNewsOficinaSafPrograma(ProgramaFilter filter)
        {
            return Business.GetNewsOficinaSafPrograma(filter);
        }
        
    }
}
