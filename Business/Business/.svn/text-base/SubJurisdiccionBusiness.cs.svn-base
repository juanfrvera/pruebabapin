using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SubJurisdiccionBusiness : _SubJurisdiccionBusiness 
    {   
	   #region Singleton
	   private static volatile SubJurisdiccionBusiness current;
	   private static object syncRoot = new Object();

	   //private SubJurisdiccionBusiness() {}
	   public static SubJurisdiccionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubJurisdiccionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override SubJurisdiccion GetNew()
       {
           SubJurisdiccion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(SubJurisdiccion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
