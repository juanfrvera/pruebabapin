using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OficinaSafProgramaData : _OficinaSafProgramaData 
    {
	   #region Singleton
	   private static volatile OficinaSafProgramaData current;
	   private static object syncRoot = new Object();

	   //private OficinaSafProgramaData() {}
	   public static OficinaSafProgramaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaSafProgramaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOficinaSafPrograma"; } }   

        protected override IQueryable<OficinaSafPrograma> Query(OficinaSafProgramaFilter filter)
        {
			return (from o in base.Query(filter)
                    where  (filter.IdOficina == null || filter.IdOficina == 0|| (from os in this.Context.OficinaSafs where os.IdOficina == filter.IdOficina select os.IdOficinaSaf).Contains(o.IdOficinaSaf)) 
                   select o ).AsQueryable();
        }
    }
}
