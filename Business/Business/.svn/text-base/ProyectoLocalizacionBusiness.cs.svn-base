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
    public class ProyectoLocalizacionBusiness : _ProyectoLocalizacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoLocalizacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoLocalizacionBusiness() {}
	   public static ProyectoLocalizacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoLocalizacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override void Validate(ProyectoLocalizacion entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
       }

       internal void DeleteBranch(int idProyecto, int idClasificacionGeografica)
       {
           this.Data.DeleteBranch(idProyecto, idClasificacionGeografica);
       }

       #region Actions

       public override void Update(ProyectoLocalizacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
