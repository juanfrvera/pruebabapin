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
    public abstract class _EtapaData : EntityData<Etapa,EtapaFilter,EtapaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Etapa entity)
		{			
			return entity.IdEtapa;
		}		
		public override Etapa GetByEntity(Etapa entity)
        {
            return this.GetById(entity.IdEtapa);
        }
        public override Etapa GetById(int id)
        {
            return (from o in this.Table where o.IdEtapa == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Etapa> Query(EtapaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEtapa == null || filter.IdEtapa == 0 || o.IdEtapa==filter.IdEtapa)
					  && (filter.IdFase == null || filter.IdFase == 0 || o.IdFase==filter.IdFase)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EtapaResult> QueryResult(EtapaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Fases on o.IdFase equals t1.IdFase   
				   select new EtapaResult(){
					 IdEtapa=o.IdEtapa
					 ,IdFase=o.IdFase
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					,Fase_Codigo= t1.Codigo	
						,Fase_Nombre= t1.Nombre	
						,Fase_Orden= t1.Orden	
						,Fase_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Etapa Copy(nc.Etapa entity)
        {           
            nc.Etapa _new = new nc.Etapa();
		 _new.IdFase= entity.IdFase;
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Etapa entity,string renameFormat)
        {
            Etapa  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Etapa entity, int id)
        {            
            entity.IdEtapa = id;            
        }
		public override void Set(Etapa source,Etapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEtapa= source.IdEtapa ;
		 target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EtapaResult source,Etapa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEtapa= source.IdEtapa ;
		 target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Etapa source,EtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEtapa= source.IdEtapa ;
		 target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EtapaResult source,EtapaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEtapa= source.IdEtapa ;
		 target.IdFase= source.IdFase ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.Fase_Codigo= source.Fase_Codigo;	
			target.Fase_Nombre= source.Fase_Nombre;	
			target.Fase_Orden= source.Fase_Orden;	
			target.Fase_Activo= source.Fase_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Etapa source,Etapa target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEtapa.Equals(target.IdEtapa))return false;
		  if(!source.IdFase.Equals(target.IdFase))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(EtapaResult source,EtapaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEtapa.Equals(target.IdEtapa))return false;
		  if(!source.IdFase.Equals(target.IdFase))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Fase_Codigo == null)?target.Fase_Codigo!=null: !( (target.Fase_Codigo== String.Empty && source.Fase_Codigo== null) || (target.Fase_Codigo==null && source.Fase_Codigo== String.Empty )) &&   !source.Fase_Codigo.Trim().Replace ("\r","").Equals(target.Fase_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Fase_Nombre == null)?target.Fase_Nombre!=null: !( (target.Fase_Nombre== String.Empty && source.Fase_Nombre== null) || (target.Fase_Nombre==null && source.Fase_Nombre== String.Empty )) &&   !source.Fase_Nombre.Trim().Replace ("\r","").Equals(target.Fase_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Fase_Orden.Equals(target.Fase_Orden))return false;
					  if(!source.Fase_Activo.Equals(target.Fase_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
