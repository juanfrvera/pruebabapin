using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class UnidadMedidaBusiness : _UnidadMedidaBusiness 
    {   
	   #region Singleton
	   private static volatile UnidadMedidaBusiness current;
	   private static object syncRoot = new Object();

	   //private UnidadMedidaBusiness() {}
	   public static UnidadMedidaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UnidadMedidaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override UnidadMedida GetNew()
       {
           UnidadMedida entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(UnidadMedida entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
