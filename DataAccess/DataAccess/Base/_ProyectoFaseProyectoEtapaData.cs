using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoFaseProyectoEtapaData : EntityData<ProyectoFaseProyectoEtapa,ProyectoFaseProyectoEtapaFilter,ProyectoFaseProyectoEtapaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoFaseProyectoEtapa entity)
		{			
			return entity.IdProyectoFaseProyectoEtapa;
		}		
		public override ProyectoFaseProyectoEtapa GetByEntity(ProyectoFaseProyectoEtapa entity)
        {
            return this.GetById(entity.IdProyectoFaseProyectoEtapa);
        }
        public override ProyectoFaseProyectoEtapa GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoFaseProyectoEtapa == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoFaseProyectoEtapa> Query(ProyectoFaseProyectoEtapaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoFaseProyectoEtapa == null || o.IdProyectoFaseProyectoEtapa >=  filter.IdProyectoFaseProyectoEtapa) && (filter.IdProyectoFaseProyectoEtapa_To == null || o.IdProyectoFaseProyectoEtapa <= filter.IdProyectoFaseProyectoEtapa_To)
					  && (filter.IdProyectoFase == null || filter.IdProyectoFase == 0 || o.IdProyectoFase==filter.IdProyectoFase)
					  && (filter.IdProyectoEtapa == null || filter.IdProyectoEtapa == 0 || o.IdProyectoEtapa==filter.IdProyectoEtapa)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoFaseProyectoEtapaResult> QueryResult(ProyectoFaseProyectoEtapaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Etapas on o.IdProyectoEtapa equals t1.IdEtapa   
				    join t2  in this.Context.Fases on o.IdProyectoFase equals t2.IdFase   
				   select new ProyectoFaseProyectoEtapaResult(){
					 IdProyectoFaseProyectoEtapa=o.IdProyectoFaseProyectoEtapa
					 ,IdProyectoFase=o.IdProyectoFase
					 ,IdProyectoEtapa=o.IdProyectoEtapa
					,ProyectoEtapa_IdFase= t1.IdFase	
						,ProyectoEtapa_Codigo= t1.Codigo	
						,ProyectoEtapa_Nombre= t1.Nombre	
						,ProyectoEtapa_Orden= t1.Orden	
						,ProyectoEtapa_Activo= t1.Activo	
						,ProyectoFase_Codigo= t2.Codigo	
						,ProyectoFase_Nombre= t2.Nombre	
						,ProyectoFase_Orden= t2.Orden	
						,ProyectoFase_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoFaseProyectoEtapa Copy(nc.ProyectoFaseProyectoEtapa entity)
        {           
            nc.ProyectoFaseProyectoEtapa _new = new nc.ProyectoFaseProyectoEtapa();
		 _new.IdProyectoFase= entity.IdProyectoFase;
		 _new.IdProyectoEtapa= entity.IdProyectoEtapa;
		return _new;			
        }
		public override int CopyAndSave(ProyectoFaseProyectoEtapa entity,string renameFormat)
        {
            ProyectoFaseProyectoEtapa  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoFaseProyectoEtapa entity, int id)
        {            
            entity.IdProyectoFaseProyectoEtapa = id;            
        }
		public override void Set(ProyectoFaseProyectoEtapa source,ProyectoFaseProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFaseProyectoEtapa= source.IdProyectoFaseProyectoEtapa ;
		 target.IdProyectoFase= source.IdProyectoFase ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 		  
		}
		public override void Set(ProyectoFaseProyectoEtapaResult source,ProyectoFaseProyectoEtapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFaseProyectoEtapa= source.IdProyectoFaseProyectoEtapa ;
		 target.IdProyectoFase= source.IdProyectoFase ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 
		}
		public override void Set(ProyectoFaseProyectoEtapa source,ProyectoFaseProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFaseProyectoEtapa= source.IdProyectoFaseProyectoEtapa ;
		 target.IdProyectoFase= source.IdProyectoFase ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 	
		}		
		public override void Set(ProyectoFaseProyectoEtapaResult source,ProyectoFaseProyectoEtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFaseProyectoEtapa= source.IdProyectoFaseProyectoEtapa ;
		 target.IdProyectoFase= source.IdProyectoFase ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.ProyectoEtapa_IdFase= source.ProyectoEtapa_IdFase;	
			target.ProyectoEtapa_Codigo= source.ProyectoEtapa_Codigo;	
			target.ProyectoEtapa_Nombre= source.ProyectoEtapa_Nombre;	
			target.ProyectoEtapa_Orden= source.ProyectoEtapa_Orden;	
			target.ProyectoEtapa_Activo= source.ProyectoEtapa_Activo;	
			target.ProyectoFase_Codigo= source.ProyectoFase_Codigo;	
			target.ProyectoFase_Nombre= source.ProyectoFase_Nombre;	
			target.ProyectoFase_Orden= source.ProyectoFase_Orden;	
			target.ProyectoFase_Activo= source.ProyectoFase_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoFaseProyectoEtapa source,ProyectoFaseProyectoEtapa target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFaseProyectoEtapa.Equals(target.IdProyectoFaseProyectoEtapa))return false;
		  if(!source.IdProyectoFase.Equals(target.IdProyectoFase))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoFaseProyectoEtapaResult source,ProyectoFaseProyectoEtapaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFaseProyectoEtapa.Equals(target.IdProyectoFaseProyectoEtapa))return false;
		  if(!source.IdProyectoFase.Equals(target.IdProyectoFase))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if(!source.ProyectoEtapa_IdFase.Equals(target.ProyectoEtapa_IdFase))return false;
					  if((source.ProyectoEtapa_Codigo == null)?target.ProyectoEtapa_Codigo!=null: !( (target.ProyectoEtapa_Codigo== String.Empty && source.ProyectoEtapa_Codigo== null) || (target.ProyectoEtapa_Codigo==null && source.ProyectoEtapa_Codigo== String.Empty )) &&   !source.ProyectoEtapa_Codigo.Trim().Replace ("\r","").Equals(target.ProyectoEtapa_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoEtapa_Nombre == null)?target.ProyectoEtapa_Nombre!=null: !( (target.ProyectoEtapa_Nombre== String.Empty && source.ProyectoEtapa_Nombre== null) || (target.ProyectoEtapa_Nombre==null && source.ProyectoEtapa_Nombre== String.Empty )) &&   !source.ProyectoEtapa_Nombre.Trim().Replace ("\r","").Equals(target.ProyectoEtapa_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoEtapa_Orden.Equals(target.ProyectoEtapa_Orden))return false;
					  if(!source.ProyectoEtapa_Activo.Equals(target.ProyectoEtapa_Activo))return false;
					  if((source.ProyectoFase_Codigo == null)?target.ProyectoFase_Codigo!=null: !( (target.ProyectoFase_Codigo== String.Empty && source.ProyectoFase_Codigo== null) || (target.ProyectoFase_Codigo==null && source.ProyectoFase_Codigo== String.Empty )) &&   !source.ProyectoFase_Codigo.Trim().Replace ("\r","").Equals(target.ProyectoFase_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoFase_Nombre == null)?target.ProyectoFase_Nombre!=null: !( (target.ProyectoFase_Nombre== String.Empty && source.ProyectoFase_Nombre== null) || (target.ProyectoFase_Nombre==null && source.ProyectoFase_Nombre== String.Empty )) &&   !source.ProyectoFase_Nombre.Trim().Replace ("\r","").Equals(target.ProyectoFase_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoFase_Orden.Equals(target.ProyectoFase_Orden))return false;
					  if(!source.ProyectoFase_Activo.Equals(target.ProyectoFase_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
