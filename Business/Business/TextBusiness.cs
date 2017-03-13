using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class TextBusiness : _TextBusiness 
    {   
	   #region Singleton
	   private static volatile TextBusiness current;
	   private static object syncRoot = new Object();

	   //private TextBusiness() {}
	   public static TextBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Text GetNew()
       {
           Text entity = base.GetNew();
           entity.Checked = false;
           entity.IsAutomaticLoad = false;
           entity.StartDate = DateTime.Now;
           return entity;
       }
       public override void Add(Text entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
           if(contextUser!=null && contextUser.User !=null)
              AddTranslates(entity,contextUser); 
       }
       public void AddTranslates(Text entity, IContextUser contextUser)
       {
           AddTranslates(entity, contextUser.User.Language_Code); 
       }
       public void AddTranslates(Text entity, string languageCode)
       { 
           AddTranslates(entity, languageCode, LanguageBusiness.Current.GetList());                     
           SolutionContext.Current.TextManager.Refresh();       
       }
       public void AddTranslates(Text entity,string languageForm,List<Language> languages)
       {
           TextLanguage textLanguage;
           Language userLanguage = (from o in languages where o.Code == languageForm select o).FirstOrDefault();
           if (userLanguage == null) return;
           try
           {
               textLanguage = TextLanguageBusiness.Current.GetNew();
               textLanguage.IdLanguage = userLanguage.IdLanguage;
               textLanguage.IdText = entity.IdText;
               textLanguage.TranslateText = entity.Code;
               TextLanguageBusiness.Current.Add(textLanguage, null);

               foreach (Language language in languages)
               {
                   if (language.IdLanguage == userLanguage.IdLanguage) continue;
                   AddTranslate(entity, languageForm, language);
               }
           }
           catch { }
       }
       public void AddTranslate(Text entity, string languageFrom, Language languageTo)
       {          
          try
           {
               TextLanguage textLanguage = TextLanguageBusiness.Current.GetNew(); 
               textLanguage.Checked = false;
               textLanguage.IsAutomaticLoad = true;
               textLanguage.StartDate = DateTime.Now;
               textLanguage = TextLanguageBusiness.Current.GetNew();
               textLanguage.IdLanguage = languageTo.IdLanguage;
               textLanguage.IdText = entity.IdText;
               textLanguage.TranslateText = LanguageBusiness.Current.Translate(entity.Code, languageFrom, languageTo.Code);
               TextLanguageBusiness.Current.Add(textLanguage, null);
           }
           catch { }
       }

       #region Actions

       public override void Update(Text entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
