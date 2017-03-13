using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;

namespace Service
{
    public class EstadoDeDesicionCache : EntitiesCache<EstadoDeDesicion,int>
    {
        #region singleton
        private static readonly object padlock = new object();
        private static EstadoDeDesicionCache current;
        private EstadoDeDesicionCache() { }
        public static EstadoDeDesicionCache Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new EstadoDeDesicionCache();
                    }
                return current;
            }
        }
        #endregion

        protected override object Cache
        {
            get
            {
                return SolutionContext.Current.CacheByApplicationManager["EstadoDeDesicionCache"];
            }
            set
            {
                SolutionContext.Current.CacheByApplicationManager["EstadoDeDesicionCache"] = value;
            }
        }
        protected override List<EstadoDeDesicion> GetList()
        {
            return EstadoDeDesicionService.Current.GetList();
        }
        public override EstadoDeDesicion GetByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o).FirstOrDefault();
        }
        public override EstadoDeDesicion GetByName(string name)
        {
            return (from o in Entities where o.Nombre == name select o).FirstOrDefault();
        }
        public override EstadoDeDesicion GetById(int id)
        {
            return (from o in Entities where o.IdEstadoDeDesicion == id select o).FirstOrDefault();
        }
        public override int GetIdByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o.IdEstadoDeDesicion).FirstOrDefault();
        }
       
    }
}
