using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract;
namespace DataAccess
{
    public class ProyectoAlcanceGeograficoData :  EntityData<ProyectoAlcanceGeografico,ProyectoAlcanceGeograficoFilter,ProyectoAlcanceGeograficoResult,int> 
    {
	   #region Singleton
	   private static volatile ProyectoAlcanceGeograficoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoAlcanceGeograficoData() {}
	   public static ProyectoAlcanceGeograficoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoAlcanceGeograficoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoAlcanceGeografico"; } }
    
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoAlcanceGeografico entity)
		{			
			return entity.IdProyectoAlcanceGeografico;
		}		
		public override ProyectoAlcanceGeografico GetByEntity(ProyectoAlcanceGeografico entity)
        {
            return this.GetById(entity.IdProyectoAlcanceGeografico);
        }
        public override ProyectoAlcanceGeografico GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoAlcanceGeografico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoAlcanceGeografico> Query(ProyectoAlcanceGeograficoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoAlcanceGeografico == null || o.IdProyectoAlcanceGeografico >=  filter.IdProyectoAlcanceGeografico) && (filter.IdProyectoAlcanceGeografico_To == null || o.IdProyectoAlcanceGeografico <= filter.IdProyectoAlcanceGeografico_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoAlcanceGeograficoResult> QueryResult(ProyectoAlcanceGeograficoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t1.IdClasificacionGeografica   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				   select new ProyectoAlcanceGeograficoResult(){
					 IdProyectoAlcanceGeografico=o.IdProyectoAlcanceGeografico
					 ,IdProyecto=o.IdProyecto
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
                     ,ClasificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
                     ,ClasificacionGeografica_Descripcion= t1.Descripcion	
                    
					}
                ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoAlcanceGeografico Copy(nc.ProyectoAlcanceGeografico entity)
        {           
            nc.ProyectoAlcanceGeografico _new = new nc.ProyectoAlcanceGeografico();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		return _new;			
        }
		public override int CopyAndSave(ProyectoAlcanceGeografico entity,string renameFormat)
        {
            ProyectoAlcanceGeografico  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoAlcanceGeografico entity, int id)
        {            
            entity.IdProyectoAlcanceGeografico = id;            
        }
		public override void Set(ProyectoAlcanceGeografico source,ProyectoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 		  
		}
		public override void Set(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 
		}
		public override void Set(ProyectoAlcanceGeografico source,ProyectoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 	
		}		
		public override void Set(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		     if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		     target.IdProyecto= source.IdProyecto ;
		     target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
             target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
             target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
             
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoAlcanceGeografico source,ProyectoAlcanceGeografico target)
        {
		    if(source == null && target == null)return true;
		    if(source == null )return false;
		    if(target == null)return false;
            if(!source.IdProyectoAlcanceGeografico.Equals(target.IdProyectoAlcanceGeografico))return false;
		    if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		    if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		 
		    return true;
        }
		public override bool Equals(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeograficoResult target)
        {
		    if(source == null && target == null)return true;
		    if(source == null )return false;
		    if(target == null)return false;
            if(!source.IdProyectoAlcanceGeografico.Equals(target.IdProyectoAlcanceGeografico))return false;
		    if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		    if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
            if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
            if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null:!source.ClasificacionGeografica_Descripcion.Equals(target.ClasificacionGeografica_Descripcion))return false;
            
					 		
		  return true;
        }
		#endregion
    }
}
