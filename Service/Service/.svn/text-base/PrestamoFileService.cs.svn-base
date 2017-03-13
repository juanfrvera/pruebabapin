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
    public class PrestamoFilesComposeService : EntityComposeService<PrestamoFilesCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoFilesComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoFilesComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoFilesComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoFilesComposeService"; } }

        protected readonly PrestamoFilesComposeBusiness Business = PrestamoFilesComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoFilesCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoFilesCompose GetById(Int32 idPrestamo)
        {
            return PrestamoFilesComposeBusiness.Current.GetById(idPrestamo);
        }
    }
    public class PrestamoFileService : _PrestamoFileService 
    {	  
	   #region Singleton
	   private static volatile PrestamoFileService current;
	   private static object syncRoot = new Object();

	   //private PrestamoFileService() {}
	   public static PrestamoFileService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFileService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
