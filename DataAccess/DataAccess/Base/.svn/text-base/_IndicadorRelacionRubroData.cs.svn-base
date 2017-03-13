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
    public abstract class _IndicadorRelacionRubroData : EntityData<IndicadorRelacionRubro,IndicadorRelacionRubroFilter,IndicadorRelacionRubroResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorRelacionRubro entity)
		{			
			return entity.IdIndicadorRelacionRubro;
		}		
		public override IndicadorRelacionRubro GetByEntity(IndicadorRelacionRubro entity)
        {
            return this.GetById(entity.IdIndicadorRelacionRubro);
        }
        public override IndicadorRelacionRubro GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorRelacionRubro == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorRelacionRubro> Query(IndicadorRelacionRubroFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorRelacionRubro == null || o.IdIndicadorRelacionRubro >=  filter.IdIndicadorRelacionRubro) && (filter.IdIndicadorRelacionRubro_To == null || o.IdIndicadorRelacionRubro <= filter.IdIndicadorRelacionRubro_To)
					  && (filter.IdIndicadorClase == null || filter.IdIndicadorClase == 0 || o.IdIndicadorClase==filter.IdIndicadorClase)
					  && (filter.IdIndicadorRubro == null || filter.IdIndicadorRubro == 0 || o.IdIndicadorRubro==filter.IdIndicadorRubro)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorRelacionRubroResult> QueryResult(IndicadorRelacionRubroFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.IndicadorClases on o.IdIndicadorClase equals t1.IdIndicadorClase   
				    join t2  in this.Context.IndicadorRubros on o.IdIndicadorRubro equals t2.IdIndicadorRubro   
				   select new IndicadorRelacionRubroResult(){
					 IdIndicadorRelacionRubro=o.IdIndicadorRelacionRubro
					 ,IdIndicadorClase=o.IdIndicadorClase
					 ,IdIndicadorRubro=o.IdIndicadorRubro
					,IndicadorClase_IdIndicadorTipo= t1.IdIndicadorTipo	
						,IndicadorClase_Sigla= t1.Sigla	
						,IndicadorClase_Nombre= t1.Nombre	
						,IndicadorClase_IdUnidad= t1.IdUnidad	
						,IndicadorClase_RangoInicial= t1.RangoInicial	
						,IndicadorClase_RangoFinal= t1.RangoFinal	
						,IndicadorClase_Activo= t1.Activo	
						,IndicadorRubro_Nombre= t2.Nombre	
						,IndicadorRubro_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorRelacionRubro Copy(nc.IndicadorRelacionRubro entity)
        {           
            nc.IndicadorRelacionRubro _new = new nc.IndicadorRelacionRubro();
		 _new.IdIndicadorClase= entity.IdIndicadorClase;
		 _new.IdIndicadorRubro= entity.IdIndicadorRubro;
		return _new;			
        }
		public override int CopyAndSave(IndicadorRelacionRubro entity,string renameFormat)
        {
            IndicadorRelacionRubro  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorRelacionRubro entity, int id)
        {            
            entity.IdIndicadorRelacionRubro = id;            
        }
		public override void Set(IndicadorRelacionRubro source,IndicadorRelacionRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRelacionRubro= source.IdIndicadorRelacionRubro ;
		 target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 		  
		}
		public override void Set(IndicadorRelacionRubroResult source,IndicadorRelacionRubro target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRelacionRubro= source.IdIndicadorRelacionRubro ;
		 target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 
		}
		public override void Set(IndicadorRelacionRubro source,IndicadorRelacionRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRelacionRubro= source.IdIndicadorRelacionRubro ;
		 target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 	
		}		
		public override void Set(IndicadorRelacionRubroResult source,IndicadorRelacionRubroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorRelacionRubro= source.IdIndicadorRelacionRubro ;
		 target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorRubro= source.IdIndicadorRubro ;
		 target.IndicadorClase_IdIndicadorTipo= source.IndicadorClase_IdIndicadorTipo;	
			target.IndicadorClase_Sigla= source.IndicadorClase_Sigla;	
			target.IndicadorClase_Nombre= source.IndicadorClase_Nombre;	
			target.IndicadorClase_IdUnidad= source.IndicadorClase_IdUnidad;	
			target.IndicadorClase_RangoInicial= source.IndicadorClase_RangoInicial;	
			target.IndicadorClase_RangoFinal= source.IndicadorClase_RangoFinal;	
			target.IndicadorClase_Activo= source.IndicadorClase_Activo;	
			target.IndicadorRubro_Nombre= source.IndicadorRubro_Nombre;	
			target.IndicadorRubro_Activo= source.IndicadorRubro_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorRelacionRubro source,IndicadorRelacionRubro target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorRelacionRubro.Equals(target.IdIndicadorRelacionRubro))return false;
		  if(!source.IdIndicadorClase.Equals(target.IdIndicadorClase))return false;
		  if(!source.IdIndicadorRubro.Equals(target.IdIndicadorRubro))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorRelacionRubroResult source,IndicadorRelacionRubroResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorRelacionRubro.Equals(target.IdIndicadorRelacionRubro))return false;
		  if(!source.IdIndicadorClase.Equals(target.IdIndicadorClase))return false;
		  if(!source.IdIndicadorRubro.Equals(target.IdIndicadorRubro))return false;
		  if(!source.IndicadorClase_IdIndicadorTipo.Equals(target.IndicadorClase_IdIndicadorTipo))return false;
					  if((source.IndicadorClase_Sigla == null)?target.IndicadorClase_Sigla!=null: !( (target.IndicadorClase_Sigla== String.Empty && source.IndicadorClase_Sigla== null) || (target.IndicadorClase_Sigla==null && source.IndicadorClase_Sigla== String.Empty )) &&   !source.IndicadorClase_Sigla.Trim().Replace ("\r","").Equals(target.IndicadorClase_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.IndicadorClase_Nombre == null)?target.IndicadorClase_Nombre!=null: !( (target.IndicadorClase_Nombre== String.Empty && source.IndicadorClase_Nombre== null) || (target.IndicadorClase_Nombre==null && source.IndicadorClase_Nombre== String.Empty )) &&   !source.IndicadorClase_Nombre.Trim().Replace ("\r","").Equals(target.IndicadorClase_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.IndicadorClase_IdUnidad.Equals(target.IndicadorClase_IdUnidad))return false;
					  if((source.IndicadorClase_RangoInicial == null)?(target.IndicadorClase_RangoInicial.HasValue ):!source.IndicadorClase_RangoInicial.Equals(target.IndicadorClase_RangoInicial))return false;
						 if((source.IndicadorClase_RangoFinal == null)?(target.IndicadorClase_RangoFinal.HasValue ):!source.IndicadorClase_RangoFinal.Equals(target.IndicadorClase_RangoFinal))return false;
						 if(!source.IndicadorClase_Activo.Equals(target.IndicadorClase_Activo))return false;
					  if((source.IndicadorRubro_Nombre == null)?target.IndicadorRubro_Nombre!=null: !( (target.IndicadorRubro_Nombre== String.Empty && source.IndicadorRubro_Nombre== null) || (target.IndicadorRubro_Nombre==null && source.IndicadorRubro_Nombre== String.Empty )) &&   !source.IndicadorRubro_Nombre.Trim().Replace ("\r","").Equals(target.IndicadorRubro_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.IndicadorRubro_Activo.Equals(target.IndicadorRubro_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
