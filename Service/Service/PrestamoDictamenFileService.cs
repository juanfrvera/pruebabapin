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
    public class PrestamoDictamenFilesComposeService : EntityComposeService<PrestamoDictamenFilesCompose, PrestamoDictamenFilter, PrestamoDictamenResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenFilesComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoDictamenFilesComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenFilesComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoDictamenFilesComposeService"; } }

        protected readonly PrestamoDictamenFilesComposeBusiness Business = PrestamoDictamenFilesComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoDictamenFilesCompose, PrestamoDictamenFilter, PrestamoDictamenResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoDictamenService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoDictamenFilesCompose GetById(Int32 idPrestamoDictamen)
        {
            return PrestamoDictamenFilesComposeBusiness.Current.GetById(idPrestamoDictamen);
        }
    }
    public class PrestamoDictamenFileService : _PrestamoDictamenFileService 
    {	  
	   #region Singleton
	   private static volatile PrestamoDictamenFileService current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenFileService() {}
	   public static PrestamoDictamenFileService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenFileService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
