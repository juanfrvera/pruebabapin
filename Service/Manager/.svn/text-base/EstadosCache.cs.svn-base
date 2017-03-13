using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;

namespace Service
{
    public class EstadosCache : EntitiesCache<Estado,int>
    {
        #region singleton
        private static readonly object padlock = new object();
        private static EstadosCache current;
        private EstadosCache() { }
        public static EstadosCache Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new EstadosCache();
                    }
                return current;
            }
        }
        #endregion

        protected override object Cache
        {
            get
            {
                return SolutionContext.Current.CacheByApplicationManager["Estados"];
            }
            set
            {
                SolutionContext.Current.CacheByApplicationManager["Estados"]=value;
            }
        }
        protected override List<Estado> GetList()
        {
            return EstadoService.Current.GetList();
        }
        public override Estado GetByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o).FirstOrDefault();
        }
        public override Estado GetByName(string name)
        {
            return (from o in Entities where o.Nombre == name select o).FirstOrDefault();
        }
        public override Estado GetById(int id)
        {
            return (from o in Entities where o.IdEstado == id select o).FirstOrDefault();
        }
        public override int GetIdByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o.IdEstado).FirstOrDefault();
        }
       
    }
}
