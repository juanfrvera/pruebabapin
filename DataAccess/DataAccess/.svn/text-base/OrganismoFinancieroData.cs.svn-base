using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OrganismoFinancieroData : _OrganismoFinancieroData 
    { 
	   #region Singleton
	   private static volatile OrganismoFinancieroData current;
	   private static object syncRoot = new Object();

	   //private OrganismoFinancieroData() {}
	   public static OrganismoFinancieroData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoFinancieroData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOrganismoFinanciero"; } }    
    }
}
