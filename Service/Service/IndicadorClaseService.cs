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
    public class IndicadorClaseService : _IndicadorClaseService 
    {	  
	   #region Singleton
	   private static volatile IndicadorClaseService current;
	   private static object syncRoot = new Object();

	   //private IndicadorClaseService() {}
	   public static IndicadorClaseService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorClaseService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       /*German 20140129 - tarea 110*/
       public ListPaged<NodeResult> GetNodesResult(IndicadorClaseFilter filter)
       {
           return Business.GetNodesResult(filter);
       }
       /*Fin German 20140129 - tarea 110*/
    }

    public class IndicadorClaseComposeService : EntityComposeService<IndicadorClaseCompose, IndicadorClaseFilter, IndicadorClaseResult, int>
    {
        #region Singleton
        private static volatile IndicadorClaseComposeService current;
        private static object syncRoot = new Object();
        public static IndicadorClaseComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new IndicadorClaseComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected readonly IndicadorClaseComposeBusiness Business = new IndicadorClaseComposeBusiness();
        protected override IEntityBusiness<IndicadorClaseCompose, IndicadorClaseFilter, IndicadorClaseResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return IndicadorClaseService.Current.Execute(id, actionName, contextUser, args);
        }
    }
}
