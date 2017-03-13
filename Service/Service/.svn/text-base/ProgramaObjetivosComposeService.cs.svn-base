using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class ProgramaObjetivosComposeService : EntityComposeService<ProgramaObjetivosCompose, ProgramaFilter, ProgramaResult, int>
    {
        #region Singleton
        private static volatile ProgramaObjetivosComposeService current;
        private static object syncRoot = new Object();

        public static ProgramaObjetivosComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProgramaObjetivosComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProgramaObjetivosComposeService"; } }

        protected readonly ProgramaObjetivosComposeBusiness Business = ProgramaObjetivosComposeBusiness.Current;
        protected override IEntityBusiness<ProgramaObjetivosCompose, ProgramaFilter, ProgramaResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProgramaService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProgramaObjetivosCompose GetById(Int32 idPrograma)
        {
            return ProgramaObjetivosComposeBusiness.Current.GetById(idPrograma);
        }
    }
}

