using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{

    public class SolutionContext
    {
        #region Singleton
        private static volatile SolutionContext current;
        private static object syncRoot = new Object();

        //private AlcanceBusiness() {}
        public static SolutionContext Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new SolutionContext();
                    }
                }
                return current;
            }
        }
        #endregion
        public string NameApplication = "Bapin";
        #region IRefresh
        public ITextManager TextManager;
        public IParameterManager ParameterManager;        
        public IAuthorizationManager AuthorizationManager;
        #endregion
        public IAuditManager AuditManager;
        public INotificationManager NotificationManager;       
        public ICacheBySessionManager CacheBySessionManager;
        public ICacheByApplicationManager CacheByApplicationManager;
        public IMessageManager MessageManager;
        public IFileManager FileManager;

        //ver si es nesesario
        //public ISessionRepository SessionRepository;
        
        #region Parameters
        protected string defaultLanguage;
        public string DefaultLanguage
        {
            get
            {
                if (defaultLanguage == null && SolutionContext.Current.ParameterManager != null)
                    defaultLanguage = SolutionContext.Current.ParameterManager.GetStringValue("DEFAULT_LANGUAGE");
                return defaultLanguage;
            }
        }

        protected Int32 baseCurrencyId;
        public Int32 BaseCurrencyId
        {
            get
            {
                if ((baseCurrencyId == null || baseCurrencyId == 0) && SolutionContext.Current.ParameterManager != null)
                    baseCurrencyId = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("BASE_CURRENCY");
                return baseCurrencyId;
            }
        }
        
        protected string systemLanguage;
        public string SystemLanguage
        {
            get
            {
                if (systemLanguage == null && SolutionContext.Current.ParameterManager != null)
                    systemLanguage = SolutionContext.Current.ParameterManager.GetStringValue("SYSTEM_LANGUAGE");
                return systemLanguage;
            }
        }
        
        protected string systemLanguageSecond;
        public string SystemLanguageSecond
        {
            get
            {
                if (systemLanguageSecond == null && SolutionContext.Current.ParameterManager != null)
                    systemLanguageSecond = SolutionContext.Current.ParameterManager.GetStringValue("SYSTEM_LANGUAGE_SECOND");
                return systemLanguageSecond;
            }
        }
        
        protected decimal? requestMaxLength;
        public decimal RequestMaxLength
        {
            get
            {
                if ((requestMaxLength == null || requestMaxLength.HasValue == false)) 
                    if(SolutionContext.Current.ParameterManager != null)
                       requestMaxLength = SolutionContext.Current.ParameterManager.GetNumberValue("REQUEST_MAX_LENGTH")*1048576;
                return requestMaxLength.HasValue?requestMaxLength.Value:0;
            }
        }

        private Usuario systemUser;
        public Usuario SystemUser
        {
            get { return systemUser; }
            set { systemUser = value; }
        }

        protected Boolean filtrar_Busqueda_Proyecto_Periodo_Stress;
        public Boolean Filtrar_Busqueda_Proyecto_Periodo_Stress
        {
            get
            {
                if (SolutionContext.Current.ParameterManager != null)
                    filtrar_Busqueda_Proyecto_Periodo_Stress = SolutionContext.Current.ParameterManager.GetBooleanValue("FILTRAR_BUSQUEDA_PROYECTO_PERIODO_STRESS");
                return filtrar_Busqueda_Proyecto_Periodo_Stress != null ? filtrar_Busqueda_Proyecto_Periodo_Stress : false;

            }
        }

 

        #endregion

        #region Cache
        public EntitiesCache<Estado, int> EstadosCache;
        public EntitiesCache<SistemaAccion, int> AccionesCache;
        public EntitiesCache<Perfil, int> PerfilCache;
        public EntitiesCache<EstadoDeDesicion, int> EstadoDeDesicionCache;
        #endregion
        
    }

    public interface IRefresh
    {
        void Refresh();
    }
    public interface IFileManager
    {
        FileInfo Download(string folder, string fileName, int? fileVersion);
        FileInfo Download(int fileInfoId);
        FileInfo Download(string folder, string fileName);
        FileInfo Upload(string folder,string fileName, string fileType, byte[] fileData, IContextUser contextUser);
        FileInfo Upload(string folder,string fileName, string fileType, DateTime? fileDate, byte[] fileData, IContextUser contextUser);
    }
}
