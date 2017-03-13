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
    public class ProgramaComposeService : EntityComposeService<ProgramaCompose, ProgramaFilter, ProgramaResult, int>
    {
        #region Singleton
        private static volatile ProgramaComposeService current;
        private static object syncRoot = new Object();

        public static ProgramaComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProgramaComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProgramaComposeService"; } }

        protected readonly ProgramaComposeBusiness Business = ProgramaComposeBusiness.Current;
        protected override IEntityBusiness<ProgramaCompose, ProgramaFilter, ProgramaResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProgramaService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProgramaCompose GetById(Int32 idPrograma)
        {
            return ProgramaComposeBusiness.Current.GetById(idPrograma);
        }
    }
}