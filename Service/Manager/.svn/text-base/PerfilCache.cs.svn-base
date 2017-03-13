using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;

namespace Service
{
    public class PerfilCache : EntitiesCache<Perfil,int>
    {
        #region singleton
        private static readonly object padlock = new object();
        private static PerfilCache current;
        private PerfilCache() { }
        public static PerfilCache Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new PerfilCache();
                    }
                return current;
            }
        }
        #endregion

        protected override object Cache
        {
            get
            {
                return SolutionContext.Current.CacheByApplicationManager["Perfiles"];
            }
            set
            {
                SolutionContext.Current.CacheByApplicationManager["Perfiles"] = value;
            }
        }
        protected override List<Perfil> GetList()
        {
            return PerfilService.Current.GetList();
        }
        public override Perfil GetByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o).FirstOrDefault();
        }
        public override Perfil GetByName(string name)
        {
            return (from o in Entities where o.Nombre == name select o).FirstOrDefault();
        }
        public override Perfil GetById(int id)
        {
            return (from o in Entities where o.IdPerfil == id select o).FirstOrDefault();
        }
        public override int GetIdByCode(string code)
        {
            return (from o in Entities where o.Codigo == code select o.IdPerfil).FirstOrDefault();
        } 
    }
}
