using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OrganismoTipoData : _OrganismoTipoData 
    {
	   #region Singleton
	   private static volatile OrganismoTipoData current;
	   private static object syncRoot = new Object();

	   //private OrganismoTipoData() {}
	   public static OrganismoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOrganismoTipo"; } }
    }
}
