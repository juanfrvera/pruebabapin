using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SectorBusiness : _SectorBusiness 
    {   
	   #region Singleton
	   private static volatile SectorBusiness current;
	   private static object syncRoot = new Object();

	   //private SectorBusiness() {}
	   public static SectorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SectorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Sector GetNew()
       {
           Sector entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Sector entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
