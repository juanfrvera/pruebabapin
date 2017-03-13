using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SubProgramaBusiness : _SubProgramaBusiness 
    {   
	   #region Singleton
	   private static volatile SubProgramaBusiness current;
	   private static object syncRoot = new Object();

	   //private SubProgramaBusiness() {}
	   public static SubProgramaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProgramaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override SubPrograma GetNew()
       {
           SubPrograma entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public override SubPrograma GetNew(SubProgramaResult example)
       {
           example.Activo = true;
           return base.GetNew(example);
       }

       #region Actions

       public override void Update(SubPrograma entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
