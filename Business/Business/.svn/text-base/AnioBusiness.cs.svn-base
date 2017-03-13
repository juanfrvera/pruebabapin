using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class AnioBusiness : _AnioBusiness 
    {   
	   #region Singleton
	   private static volatile AnioBusiness current;
	   private static object syncRoot = new Object();

	   //private AnioBusiness() {}
	   public static AnioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AnioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Anio GetNew()
       {
           Anio entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       public override void Validate(Anio entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           switch (actionName)
           {
               case ActionConfig.CREATE:
               case ActionConfig.UPDATE:
                   Int32 anio;
                   DataHelper.Validate(Int32.TryParse(entity.Nombre, out anio), "InvalidField", "Nombre");
                   
                   break;
           
           }
       }

       public override void Add(Anio entity, IContextUser contextUser)
       {
           entity.IdAnio = Int32.Parse(entity.Nombre);
           base.Add(entity, contextUser);
       }
       public override void Update(Anio entity, IContextUser contextUser)
       {
           Delete(entity.IdAnio , contextUser);
           Add (entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
    }
}
