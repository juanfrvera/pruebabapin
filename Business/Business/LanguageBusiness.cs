using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Business
{
    public class LanguageBusiness : _LanguageBusiness 
    {   
	   #region Singleton
	   private static volatile LanguageBusiness current;
	   private static object syncRoot = new Object();

	   //private LanguageBusiness() {}
	   public static LanguageBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new LanguageBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
               
       public int Complete(Language languaje, IContextUser contextUser)
       {
           return Complete(languaje, 150, contextUser);
       }
       public int Complete(Language languaje, int translateMax, IContextUser contextUser)
       {
           int translateCount = 0;

           string systemLangugeCode =(languaje.Code == SolutionContext.Current.SystemLanguage)?
               SolutionContext.Current.SystemLanguageSecond:
               SolutionContext.Current.SystemLanguage;
           
           Language systemLanguage = FirstOrDefault(new LanguageFilter() { Code = systemLangugeCode });
           List<TextLanguageResult> translates = TextLanguageBusiness.Current.GetResult(new TextLanguageFilter() { IdLanguage = languaje.IdLanguage });
           List<TextLanguageResult> systemTranslates = TextLanguageBusiness.Current.GetResult(new TextLanguageFilter() { IdLanguage = systemLanguage.IdLanguage });
           
           foreach (TextLanguageResult systemTranslate in systemTranslates)
           {
               if (translateCount > translateMax) return translateCount;
               if (!(from o in translates select o.IdText).Contains(systemTranslate.IdText))
               {                    
                   TextLanguage textLanguage = TextLanguageBusiness.Current.GetNew();
                   textLanguage.Checked = false;
                   textLanguage.IsAutomaticLoad = true;
                   textLanguage.StartDate = DateTime.Now;
                   textLanguage.IdLanguage = languaje.IdLanguage;
                   textLanguage.IdText = systemTranslate.IdText;
                   textLanguage.TranslateText = Translate(systemTranslate.TranslateText, systemLanguage.Code, languaje.Code);
                   TextLanguageBusiness.Current.Add(textLanguage, contextUser);
                   translateCount++;
               }           
           }
           if(translateCount> 0)
             SolutionContext.Current.TextManager.Refresh();
           return translateCount;
       }
       public string Translate(string text,string languageTarget)
       { 
                return Translate(text,SolutionContext.Current.SystemLanguage);
       }
       public string Translate(string text, string languageSource, string languageTarget)
       {
           try
           {
               string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}|{2}", text, languageSource, languageTarget);
               HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);
               HttpWebResponse res = (HttpWebResponse)hwr.GetResponse();
               Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
               StreamReader sr = new StreamReader(res.GetResponseStream(),encoding);
               string html = sr.ReadToEnd();

               int start = html.IndexOf("onmouseout=\"this.style.backgroundColor='#fff'\">") + "onmouseout=\"this.style.backgroundColor='#fff'\">".Length;
               if (start <= 0) return text;
               int end = html.IndexOf("<", start);
               if (end <= 0 || start >= end) return text;
               return html.Substring(start, end - start);
           }
           catch (Exception exception)
           {
               return text;
           }
       }

       #region Actions

       public override void Update(Language entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
