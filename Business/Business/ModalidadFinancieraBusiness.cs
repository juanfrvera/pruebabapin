using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ModalidadFinancieraBusiness : _ModalidadFinancieraBusiness 
    {   
	   #region Singleton
	   private static volatile ModalidadFinancieraBusiness current;
	   private static object syncRoot = new Object();

	   //private ModalidadFinancieraBusiness() {}
	   public static ModalidadFinancieraBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadFinancieraBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ModalidadFinanciera GetNew()
       {
           ModalidadFinanciera entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(ModalidadFinanciera entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
