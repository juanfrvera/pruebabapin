using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;

namespace Service
{
    public class AccionesCache : EntitiesCache<SistemaAccion,int>
    {
        #region singleton
        private static readonly object padlock = new object();
        private static AccionesCache current;
        private AccionesCache() { }
        public static AccionesCache Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new AccionesCache();
                    }
                return current;
            }
        }
        #endregion

        protected override object Cache
        {
            get
            {
                return SolutionContext.Current.CacheByApplicationManager["Acciones"];
            }
            set
            {
                SolutionContext.Current.CacheByApplicationManager["Acciones"]=value;
            }
        }
        protected override List<SistemaAccion> GetList()
        {
            return SistemaAccionService.Current.GetList();
        }
        public override SistemaAccion GetByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o).FirstOrDefault();
        }
        public override SistemaAccion GetByName(string name)
        {
            return (from o in Entities where o.Nombre == name select o).FirstOrDefault();
        }
        public override SistemaAccion GetById(int id)
        {
            return (from o in Entities where o.IdSistemaAccion == id select o).FirstOrDefault();
        }
        public override int GetIdByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o.IdSistemaAccion).FirstOrDefault();
        }
       
    }
}
