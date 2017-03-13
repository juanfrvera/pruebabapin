using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public abstract class EntitiesCache<TEntity, TIdType>
    {
        private List<TEntity> entities;
        public List<TEntity> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = Cache as List<TEntity>;
                    if (entities == null)
                    {
                        entities = GetList();
                        Cache = entities;
                    }
                }
                return entities;
            }
            set { entities = value; }
        }

        protected abstract object Cache { get; set; }
        protected abstract List<TEntity> GetList();
        public abstract TEntity GetByCode(string code);
        public abstract TEntity GetByName(string name);
        public abstract TEntity GetById(TIdType id);
        public abstract TIdType GetIdByCode(string code);
        public void Refresh()
        {
            entities = null;
            Cache = null;
        }
    }
}
