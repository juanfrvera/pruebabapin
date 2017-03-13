using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoEtapaIndicadorData : _ProyectoEtapaIndicadorData 
    { 
	   #region Singleton
	   private static volatile ProyectoEtapaIndicadorData current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaIndicadorData() {}
	   public static ProyectoEtapaIndicadorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaIndicadorData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoEtapaIndicador"; } }

       public List<ProyectoEtapaIndicador> GetByIdProyecto(int IdProyecto)
       {
           return (from i in this.Table
                   join p in this.Context.ProyectoEtapas on i.IdProyectoEtapa equals p.IdProyectoEtapa
                   where p.IdProyecto == IdProyecto
                   select i).ToList();
       }

       public List<IndicadorEvolucion> GetIndicadoresEvolucionByIdIndicador(int IdProyectoetapaIndicador)
       {
           return (from pei in this.Table
                   join e in this.Context.IndicadorEvolucions on pei.IdIndicador equals e.IdIndicador
                   where pei.IdProyectoEtapaIndicador == IdProyectoetapaIndicador
                   select e).ToList();
       }
    }
}
