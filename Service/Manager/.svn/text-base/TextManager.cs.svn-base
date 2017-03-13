using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Service;
using System.Data.SqlClient;
using Business;

namespace Service
{
    public class TextManager : ITextManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static TextManager current;
        public static TextManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new TextManager();
                    }
                return current;
            }
        }
        #endregion

        private List<Language> languages;
        public List<Language> Languages
        {
            get {
                  if(languages==null)languages = LanguageBusiness.Current.GetList();
                  return languages;
                }
            set { languages = value; }
        }
        public string Translate(string textCode)
        {
            return Translate(textCode, SolutionContext.Current.DefaultLanguage); 
        }
        public void Complete(IContextUser contextUser)
        {
            if (contextUser != null && contextUser.User != null)
            {
                Language userLanguage = (from o in Languages where o.Code == contextUser.User.Language_Code select o).FirstOrDefault();
                if (userLanguage != null)
                LanguageBusiness.Current.Complete(userLanguage, 50, contextUser);
            }
        }
        public string Translate(string textCode, string languageCode)
        {
            try
            {
                if (textCode == null || textCode.Trim() == string.Empty || Excludes.Contains(textCode.Trim().ToUpper())) return textCode;
                TextLanguageResult textResult = (from o in this.Texts where o.Text_Code.ToUpper() == textCode.ToUpper() && o.Language_Code == languageCode select o).FirstOrDefault();
                if (textResult == null)
                {
                    if ((from o in TextsPending where o.Code == textCode select o).Count() > 0)
                        return textCode;
                    //si no existe la palabra la agrega al diccionario
                    Text text = TextBusiness.Current.GetList(new TextFilter() { Code = textCode }).FirstOrDefault();
                    if (text == null)
                    {
                        text = TextBusiness.Current.GetNew();
                        text.Code = textCode;
                        text.IdTextCategory = 1;
                        TextBusiness.Current.Add(text, null);

                        Language userLanguage = (from o in Languages where o.Code == SolutionContext.Current.SystemLanguage select o).FirstOrDefault();
                        if (userLanguage != null)
                        {
                            TextLanguage textLanguage = TextLanguageBusiness.Current.GetNew();
                            textLanguage.IdLanguage = userLanguage.IdLanguage;
                            textLanguage.IdText = text.IdText;
                            textLanguage.TranslateText = text.Code;
                            TextLanguageBusiness.Current.Add(textLanguage, null);
                        }
                    }
                    if (text != null)
                        TextsPending.Add(text);

                    //TextBusiness.Current.AddTranslates(text,SolutionContext.Current.SystemLanguage,Languages);                
                    //List<TextLanguageResult> translates = TextLanguageBusiness.Current.GetResult(new TextLanguageFilter() { IdText = text.IdText });
                    //Texts.AddRange((from o in translates where !(from t in Texts select t.IdTextLanguage).Contains(o.IdTextLanguage) select o).ToList());
                    //Texts = Texts;

                    //textResult = (from o in translates where o.Text_Code.ToUpper() == textCode.ToUpper() && o.Language_Code == languageCode select o).FirstOrDefault();
                    //if(textResult==null)return textCode;
                    return textCode;
                }
                return textResult.TranslateText;
            }
            catch (Exception exception)
            {
                return exception.Message + "-" + textCode;
            }
        }
        public string[] Excludes = { "<<", "<", "*", ">", ">>","\\","/","?" }; 
        public List<Text> TextsPending = new List<Text>(); 
        private List<TextLanguageResult> texts;
        public List<TextLanguageResult> Texts
        {
            get {
                if (texts == null)
                {
                    texts = SolutionContext.Current.CacheByApplicationManager["SLTN_TEXTS"] as List<TextLanguageResult>;
                    if (texts == null)
                    {
                        texts = TextLanguageBusiness.Current.GetResult();
                        SolutionContext.Current.CacheByApplicationManager["SLTN_TEXTS"] = texts;
                    }                
                }
                return texts;
            }
            set { texts = value;
            SolutionContext.Current.CacheByApplicationManager["SLTN_TEXTS"] = texts;
                }
        }
        public void Refresh()
        {
            texts = null;
            TextsPending = new List<Text>();
            SolutionContext.Current.CacheByApplicationManager["SLTN_TEXTS"] = null;
        }


        #region Exceptions
        private const string SuccessMessage = "msgSuccess";
        private const string DuplicateKeyMessage = "DuplicateKey";
        private const string FKDeleteConstraint = "FKDeleteConstraint";
        private const string FKUpdateConstraint = "FKUpdateConstraint";
        private const string FKEditConstraint = "FKEditConstraint";
        private const string DuplicateFieldMessage = "DuplicateField";

        public string Translate(Exception ex)
        {
            List<string> Messages = new List<string>() { DuplicateKeyMessage, FKDeleteConstraint, FKEditConstraint, FKUpdateConstraint };
            string msg = ex.Message;
            // PENDIENTE VER ESTO
            //string msg = ExceptionHelper.Process(ex);
            //Solucion por ahora, ya que la creacion de usuarios en membership devuelve errores como "DuplicateEmail"
            if (msg.StartsWith("Duplicate") && !msg.Equals(DuplicateKeyMessage))
            {
                //Application.Text.ITextProvider provider = Application.Text.TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
                //msg = provider.GetFieldText((short)PageCode.Master, DuplicateFieldMessage, Contract.Context.IdLanguage) + msg.Substring(9);
                //msg = provider.GetFieldText((short)PageCode.Master, DuplicateFieldMessage, Contract.Context.IdLanguage) + msg.Substring(9);
            }
            else if (Messages.Contains(msg))
            {
                //Application.Text.ITextProvider provider = Application.Text.TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
                //msg = provider.GetFieldText((short)PageCode.Master, msg, Contract.Context.IdLanguage);
                //msg = provider.GetFieldText((short)PageCode.Master, DuplicateFieldMessage, Contract.Context.IdLanguage) + msg.Substring(9);
            }
            else
            {
                if (ex is SqlException)
                {
                    msg = Translate("SQL_" + (ex as SqlException).Number.ToString());
                }
                else if (ex is MembershipException)
                {
                    msg = Translate((ex as MembershipException).MessageCode);
                }
                else if (ex is ValidationException)
                {
                    msg = Translate((ex as ValidationException));
                }
                else
                {
                    msg = Translate(ex.Message);
                }
            }
            return msg;
        }
        public string Translate(ValidationException exception)
        {
            string messageFormat = Translate(exception.MessageCode);
            if (exception.MessageParameters != null && exception.MessageParameters.Length > 0)
            {
                messageFormat = string.Format(messageFormat, exception.MessageParameters);
            }
            return messageFormat;
        }
       
        #endregion



    }
}
