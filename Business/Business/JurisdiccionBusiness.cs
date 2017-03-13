using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class JurisdiccionBusiness : _JurisdiccionBusiness 
    {   
	   #region Singleton
	   private static volatile JurisdiccionBusiness current;
	   private static object syncRoot = new Object();

	   //private JurisdiccionBusiness() {}
	   public static JurisdiccionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new JurisdiccionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Jurisdiccion GetNew()
       {
           Jurisdiccion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Jurisdiccion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
