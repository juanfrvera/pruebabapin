using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ModalidadContratacionBusiness : _ModalidadContratacionBusiness 
    {   
	   #region Singleton
	   private static volatile ModalidadContratacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ModalidadContratacionBusiness() {}
	   public static ModalidadContratacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadContratacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ModalidadContratacion GetNew()
       {
           ModalidadContratacion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(ModalidadContratacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
