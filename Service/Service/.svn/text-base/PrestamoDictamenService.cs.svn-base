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
    public class PrestamoDictamenService : _PrestamoDictamenService 
    {	  
	   #region Singleton
	   private static volatile PrestamoDictamenService current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenService() {}
	   public static PrestamoDictamenService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<PrestamoDictamenResult> QueryResultExcel(PrestamoDictamenFilter filter)
       {
           return PrestamoDictamenBusiness.Current.QueryResultExcel(filter);
       }
    }
    public class PrestamoEditDictamenComposeService : EntityComposeService<PrestamoEditDictamenCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoEditDictamenComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoEditDictamenComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoEditDictamenComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoEditDictamenComposeService"; } }

        protected readonly PrestamoEditDictamenComposeBusiness Business = PrestamoEditDictamenComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoEditDictamenCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoEditDictamenCompose GetById(Int32 idPrestamo)
        {
            return PrestamoEditDictamenComposeBusiness.Current.GetById(idPrestamo);
        }
    }

    public class PrestamoDictamenComposeService : EntityComposeService<PrestamoDictamenCompose, PrestamoDictamenFilter, PrestamoDictamenResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoDictamenComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoDictamenComposeService"; } }

        protected readonly PrestamoDictamenComposeBusiness Business = PrestamoDictamenComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoDictamenCompose, PrestamoDictamenFilter, PrestamoDictamenResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoDictamenService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoDictamenCompose GetById(Int32 idPrestamoDictamen)
        {
            return PrestamoDictamenComposeBusiness.Current.GetById(idPrestamoDictamen);
        }
    }




}
