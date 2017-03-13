using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OrganismoData : _OrganismoData 
    {
	   #region Singleton
	   private static volatile OrganismoData current;
	   private static object syncRoot = new Object();

	   //private OrganismoData() {}
	   public static OrganismoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOrganismo"; } }    
    }
}
