using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class TextLanguageBusiness : _TextLanguageBusiness 
    {   
	   #region Singleton
	   private static volatile TextLanguageBusiness current;
	   private static object syncRoot = new Object();

	   //private TextLanguageBusiness() {}
	   public static TextLanguageBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextLanguageBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override TextLanguage GetNew()
       {
           TextLanguage entity = base.GetNew();
           entity.Checked = false;
           entity.IsAutomaticLoad = false;
           entity.StartDate = DateTime.Now;
           return entity;
       }

       #region Actions

       public override void Update(TextLanguage entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
