using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PermisoBusiness : _PermisoBusiness 
    {   
	   #region Singleton
	   private static volatile PermisoBusiness current;
	   private static object syncRoot = new Object();

	   //private PermisoBusiness() {}
	   public static PermisoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PermisoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Permiso GetNew()
       {
           Permiso entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public List<PermisoSimpleResult> GetSimpleResult(PermisoPerfilFilter filter)
       {
           return Data.GetSimpleResult(filter);
       }


       #region Actions

       public override void Update(Permiso entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
