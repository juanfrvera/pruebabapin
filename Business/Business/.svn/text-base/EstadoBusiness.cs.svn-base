using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EstadoBusiness : _EstadoBusiness 
    {   
	   #region Singleton
	   private static volatile EstadoBusiness current;
	   private static object syncRoot = new Object();

	   //private EstadoBusiness() {}
	   public static EstadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override Estado GetNew()
       {
           Estado entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions
       public override void Add(Estado entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
           SolutionContext.Current.EstadosCache.Refresh();
       }
       public override void Update(Estado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SolutionContext.Current.EstadosCache.Refresh();
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       public override void Delete(Estado entity, IContextUser contextUser)
       {
           base.Delete(entity, contextUser);
           SolutionContext.Current.EstadosCache.Refresh();
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           base.Delete(id, contextUser);
           SolutionContext.Current.EstadosCache.Refresh();
       }
       #endregion


      
    }
}
