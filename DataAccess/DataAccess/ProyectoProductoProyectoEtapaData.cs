using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc= Contract ;
namespace DataAccess
{
    public class ProyectoProductoProyectoEtapaData :  EntityData<ProyectoProductoProyectoEtapa,ProyectoProductoProyectoEtapaFilter,ProyectoProductoProyectoEtapaResult,int> 
    { 
	    #region Singleton
	   private static volatile ProyectoProductoProyectoEtapaData current;
	   private static object syncRoot = new Object();

	   //private ProyectoProductoProyectoEtapaData() {}
	   public static ProyectoProductoProyectoEtapaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoProductoProyectoEtapaData();
				}
			 }
			 return current;
		  }
	   }
        #endregion
        public override string IdFieldName { get { return "IdProyectoProductoProyectoEtapa"; } }
   
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoProductoProyectoEtapa entity)
		{			
			return entity.IdProyectoProductoProyectoEtapa;
		}		
		public override ProyectoProductoProyectoEtapa GetByEntity(ProyectoProductoProyectoEtapa entity)
        {
            return this.GetById(entity.IdProyectoProductoProyectoEtapa);
        }
        public override ProyectoProductoProyectoEtapa GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoProductoProyectoEtapa == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoProductoProyectoEtapa> Query(ProyectoProductoProyectoEtapaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoProductoProyectoEtapa == null || o.IdProyectoProductoProyectoEtapa >=  filter.IdProyectoProductoProyectoEtapa) && (filter.IdProyectoProductoProyectoEtapa_To == null || o.IdProyectoProductoProyectoEtapa <= filter.IdProyectoProductoProyectoEtapa_To)
					  && (filter.IdProyectoProducto == null || filter.IdProyectoProducto == 0 || o.IdProyectoProducto==filter.IdProyectoProducto)
					  && (filter.IdProyectoEtapa == null || filter.IdProyectoEtapa == 0 || o.IdProyectoEtapa==filter.IdProyectoEtapa)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoProductoProyectoEtapaResult> QueryResult(ProyectoProductoProyectoEtapaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapas on o.IdProyectoEtapa equals t1.IdProyectoEtapa   
				    join t2  in this.Context.ProyectoProductos on o.IdProyectoProducto equals t2.IdProyectoProducto   
				   select new ProyectoProductoProyectoEtapaResult(){
					 IdProyectoProductoProyectoEtapa=o.IdProyectoProductoProyectoEtapa
					 ,IdProyectoProducto=o.IdProyectoProducto
					 ,IdProyectoEtapa=o.IdProyectoEtapa
                    //,ProyectoEtapa_Nombre= t1.Nombre	
                    //    ,ProyectoEtapa_CodigoVinculacion= t1.CodigoVinculacion	
                    //    ,ProyectoEtapa_IdEstado= t1.IdEstado	
                    //    ,ProyectoEtapa_FechaInicioEstimada= t1.FechaInicioEstimada	
                    //    ,ProyectoEtapa_FechaFinEstimada= t1.FechaFinEstimada	
                    //    ,ProyectoEtapa_FechaInicioRealizada= t1.FechaInicioRealizada	
                    //    ,ProyectoEtapa_FechaFinRealizada= t1.FechaFinRealizada	
                    //    ,ProyectoEtapa_IdEtapa= t1.IdEtapa	
                    //    ,ProyectoEtapa_IdProyecto= t1.IdProyecto	
                    //    ,ProyectoEtapa_NroEtapa= t1.NroEtapa	
                    //    ,ProyectoProducto_IdProyecto= t2.IdProyecto	
                    //    ,ProyectoProducto_IdObjetivo= t2.IdObjetivo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoProductoProyectoEtapa Copy(nc.ProyectoProductoProyectoEtapa entity)
        {           
            nc.ProyectoProductoProyectoEtapa _new = new nc.ProyectoProductoProyectoEtapa();
		 _new.IdProyectoProducto= entity.IdProyectoProducto;
		 _new.IdProyectoEtapa= entity.IdProyectoEtapa;
		return _new;			
        }
		public override int CopyAndSave(ProyectoProductoProyectoEtapa entity,string renameFormat)
        {
            ProyectoProductoProyectoEtapa  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoProductoProyectoEtapa entity, int id)
        {            
            entity.IdProyectoProductoProyectoEtapa = id;            
        }
		public override void Set(ProyectoProductoProyectoEtapa source,ProyectoProductoProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProductoProyectoEtapa= source.IdProyectoProductoProyectoEtapa ;
		 target.IdProyectoProducto= source.IdProyectoProducto ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 		  
		}
		public override void Set(ProyectoProductoProyectoEtapaResult source,ProyectoProductoProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProductoProyectoEtapa= source.IdProyectoProductoProyectoEtapa ;
		 target.IdProyectoProducto= source.IdProyectoProducto ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 
		}
		public override void Set(ProyectoProductoProyectoEtapa source,ProyectoProductoProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProductoProyectoEtapa= source.IdProyectoProductoProyectoEtapa ;
		 target.IdProyectoProducto= source.IdProyectoProducto ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 	
		}		
		public override void Set(ProyectoProductoProyectoEtapaResult source,ProyectoProductoProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProductoProyectoEtapa= source.IdProyectoProductoProyectoEtapa ;
		 target.IdProyectoProducto= source.IdProyectoProducto ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
         //target.ProyectoEtapa_Nombre= source.ProyectoEtapa_Nombre;	
         //   target.ProyectoEtapa_CodigoVinculacion= source.ProyectoEtapa_CodigoVinculacion;	
         //   target.ProyectoEtapa_IdEstado= source.ProyectoEtapa_IdEstado;	
         //   target.ProyectoEtapa_FechaInicioEstimada= source.ProyectoEtapa_FechaInicioEstimada;	
         //   target.ProyectoEtapa_FechaFinEstimada= source.ProyectoEtapa_FechaFinEstimada;	
         //   target.ProyectoEtapa_FechaInicioRealizada= source.ProyectoEtapa_FechaInicioRealizada;	
         //   target.ProyectoEtapa_FechaFinRealizada= source.ProyectoEtapa_FechaFinRealizada;	
         //   target.ProyectoEtapa_IdEtapa= source.ProyectoEtapa_IdEtapa;	
         //   target.ProyectoEtapa_IdProyecto= source.ProyectoEtapa_IdProyecto;	
         //   target.ProyectoEtapa_NroEtapa= source.ProyectoEtapa_NroEtapa;	
         //   target.ProyectoProducto_IdProyecto= source.ProyectoProducto_IdProyecto;	
         //   target.ProyectoProducto_IdObjetivo= source.ProyectoProducto_IdObjetivo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoProductoProyectoEtapa source,ProyectoProductoProyectoEtapa target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoProductoProyectoEtapa.Equals(target.IdProyectoProductoProyectoEtapa))return false;
		  if(!source.IdProyectoProducto.Equals(target.IdProyectoProducto))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoProductoProyectoEtapaResult source,ProyectoProductoProyectoEtapaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoProductoProyectoEtapa.Equals(target.IdProyectoProductoProyectoEtapa))return false;
		  if(!source.IdProyectoProducto.Equals(target.IdProyectoProducto))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
          //if((source.ProyectoEtapa_Nombre == null)?target.ProyectoEtapa_Nombre!=null:!source.ProyectoEtapa_Nombre.Equals(target.ProyectoEtapa_Nombre))return false;
          //               if((source.ProyectoEtapa_CodigoVinculacion == null)?target.ProyectoEtapa_CodigoVinculacion!=null:!source.ProyectoEtapa_CodigoVinculacion.Equals(target.ProyectoEtapa_CodigoVinculacion))return false;
          //               if((source.ProyectoEtapa_IdEstado == null)?(target.ProyectoEtapa_IdEstado.HasValue && target.ProyectoEtapa_IdEstado.Value > 0):!source.ProyectoEtapa_IdEstado.Equals(target.ProyectoEtapa_IdEstado))return false;
          //                            if((source.ProyectoEtapa_FechaInicioEstimada == null)?(target.ProyectoEtapa_FechaInicioEstimada.HasValue ):!source.ProyectoEtapa_FechaInicioEstimada.Equals(target.ProyectoEtapa_FechaInicioEstimada))return false;
          //               if((source.ProyectoEtapa_FechaFinEstimada == null)?(target.ProyectoEtapa_FechaFinEstimada.HasValue ):!source.ProyectoEtapa_FechaFinEstimada.Equals(target.ProyectoEtapa_FechaFinEstimada))return false;
          //               if((source.ProyectoEtapa_FechaInicioRealizada == null)?(target.ProyectoEtapa_FechaInicioRealizada.HasValue ):!source.ProyectoEtapa_FechaInicioRealizada.Equals(target.ProyectoEtapa_FechaInicioRealizada))return false;
          //               if((source.ProyectoEtapa_FechaFinRealizada == null)?(target.ProyectoEtapa_FechaFinRealizada.HasValue ):!source.ProyectoEtapa_FechaFinRealizada.Equals(target.ProyectoEtapa_FechaFinRealizada))return false;
          //               if(!source.ProyectoEtapa_IdEtapa.Equals(target.ProyectoEtapa_IdEtapa))return false;
          //            if(!source.ProyectoEtapa_IdProyecto.Equals(target.ProyectoEtapa_IdProyecto))return false;
          //            if((source.ProyectoEtapa_NroEtapa == null)?(target.ProyectoEtapa_NroEtapa.HasValue ):!source.ProyectoEtapa_NroEtapa.Equals(target.ProyectoEtapa_NroEtapa))return false;
          //               if(!source.ProyectoProducto_IdProyecto.Equals(target.ProyectoProducto_IdProyecto))return false;
          //            if(!source.ProyectoProducto_IdObjetivo.Equals(target.ProyectoProducto_IdObjetivo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
