using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class CacheManagerResult:IResult <string>
    {
        private IRefresh manager;
        public string Nombre { get; set; }
        public void Refresh()
        {
            manager.Refresh();
        }
        public IRefresh Manager
        {
            
            set{
                manager = value;
            }
        }
        public CacheManagerResult(IRefresh Manager, String Nombre)
        {
            this.Manager = Manager;
            this.Nombre = Nombre;
        }
        public CacheManagerResult()
        { 
            
        }

        #region IResult<string> Members

        public string  ID
        {
            get { return Nombre; }
        }

        public DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
