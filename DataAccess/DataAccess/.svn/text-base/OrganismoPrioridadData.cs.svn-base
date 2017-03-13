using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OrganismoPrioridadData : _OrganismoPrioridadData 
    {
        #region Singleton
	   private static volatile OrganismoPrioridadData current;
	   private static object syncRoot = new Object();

	   //private OrganismoPrioridadData() {}
	   public static OrganismoPrioridadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoPrioridadData();
				}
			 }
			 return current;
		  }
	   }
        #endregion
       public override string IdFieldName { get { return "IdOrganismoPrioridad"; } }
    }
}
