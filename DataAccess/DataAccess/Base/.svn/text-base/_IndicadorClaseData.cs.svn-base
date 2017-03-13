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
    public abstract class _IndicadorClaseData : EntityData<IndicadorClase,IndicadorClaseFilter,IndicadorClaseResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorClase entity)
		{			
			return entity.IdIndicadorClase;
		}		
		public override IndicadorClase GetByEntity(IndicadorClase entity)
        {
            return this.GetById(entity.IdIndicadorClase);
        }
        public override IndicadorClase GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorClase == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorClase> Query(IndicadorClaseFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorClase == null || filter.IdIndicadorClase == 0 || o.IdIndicadorClase==filter.IdIndicadorClase)
					  && (filter.IdIndicadorTipo == null || filter.IdIndicadorTipo == 0 || o.IdIndicadorTipo==filter.IdIndicadorTipo)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdUnidad == null || filter.IdUnidad == 0 || o.IdUnidad==filter.IdUnidad)
					  && (filter.RangoInicial == null || o.RangoInicial >=  filter.RangoInicial) && (filter.RangoInicial_To == null || o.RangoInicial <= filter.RangoInicial_To)
					  && (filter.RangoInicialIsNull == null || filter.RangoInicialIsNull == true || o.RangoInicial != null ) && (filter.RangoInicialIsNull == null || filter.RangoInicialIsNull == false || o.RangoInicial == null)
					  && (filter.RangoFinal == null || o.RangoFinal >=  filter.RangoFinal) && (filter.RangoFinal_To == null || o.RangoFinal <= filter.RangoFinal_To)
					  && (filter.RangoFinalIsNull == null || filter.RangoFinalIsNull == true || o.RangoFinal != null ) && (filter.RangoFinalIsNull == null || filter.RangoFinalIsNull == false || o.RangoFinal == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorClaseResult> QueryResult(IndicadorClaseFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.IndicadorTipos on o.IdIndicadorTipo equals t1.IdIndicadorTipo   
				    join t2  in this.Context.UnidadMedidas on o.IdUnidad equals t2.IdUnidadMedida   
				   select new IndicadorClaseResult(){
					 IdIndicadorClase=o.IdIndicadorClase
					 ,IdIndicadorTipo=o.IdIndicadorTipo
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,IdUnidad=o.IdUnidad
					 ,RangoInicial=o.RangoInicial
					 ,RangoFinal=o.RangoFinal
					 ,Activo=o.Activo
					,IndicadorTipo_Nombre= t1.Nombre	
						,IndicadorTipo_SectorRequerido= t1.SectorRequerido	
						,IndicadorTipo_Activo= t1.Activo	
						,Unidad_Sigla= t2.Sigla	
						,Unidad_Nombre= t2.Nombre	
						,Unidad_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorClase Copy(nc.IndicadorClase entity)
        {           
            nc.IndicadorClase _new = new nc.IndicadorClase();
		 _new.IdIndicadorTipo= entity.IdIndicadorTipo;
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.IdUnidad= entity.IdUnidad;
		 _new.RangoInicial= entity.RangoInicial;
		 _new.RangoFinal= entity.RangoFinal;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(IndicadorClase entity,string renameFormat)
        {
            IndicadorClase  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorClase entity, int id)
        {            
            entity.IdIndicadorClase = id;            
        }
		public override void Set(IndicadorClase source,IndicadorClase target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidad= source.IdUnidad ;
		 target.RangoInicial= source.RangoInicial ;
		 target.RangoFinal= source.RangoFinal ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(IndicadorClaseResult source,IndicadorClase target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidad= source.IdUnidad ;
		 target.RangoInicial= source.RangoInicial ;
		 target.RangoFinal= source.RangoFinal ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(IndicadorClase source,IndicadorClaseResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidad= source.IdUnidad ;
		 target.RangoInicial= source.RangoInicial ;
		 target.RangoFinal= source.RangoFinal ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(IndicadorClaseResult source,IndicadorClaseResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorClase= source.IdIndicadorClase ;
		 target.IdIndicadorTipo= source.IdIndicadorTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.IdUnidad= source.IdUnidad ;
		 target.RangoInicial= source.RangoInicial ;
		 target.RangoFinal= source.RangoFinal ;
		 target.Activo= source.Activo ;
		 target.IndicadorTipo_Nombre= source.IndicadorTipo_Nombre;	
			target.IndicadorTipo_SectorRequerido= source.IndicadorTipo_SectorRequerido;	
			target.IndicadorTipo_Activo= source.IndicadorTipo_Activo;	
			target.Unidad_Sigla= source.Unidad_Sigla;	
			target.Unidad_Nombre= source.Unidad_Nombre;	
			target.Unidad_Activo= source.Unidad_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorClase source,IndicadorClase target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorClase.Equals(target.IdIndicadorClase))return false;
		  if(!source.IdIndicadorTipo.Equals(target.IdIndicadorTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdUnidad.Equals(target.IdUnidad))return false;
		  if((source.RangoInicial == null)?(target.RangoInicial.HasValue):!source.RangoInicial.Equals(target.RangoInicial))return false;
			 if((source.RangoFinal == null)?(target.RangoFinal.HasValue):!source.RangoFinal.Equals(target.RangoFinal))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorClaseResult source,IndicadorClaseResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorClase.Equals(target.IdIndicadorClase))return false;
		  if(!source.IdIndicadorTipo.Equals(target.IdIndicadorTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdUnidad.Equals(target.IdUnidad))return false;
		  if((source.RangoInicial == null)?(target.RangoInicial.HasValue):!source.RangoInicial.Equals(target.RangoInicial))return false;
			 if((source.RangoFinal == null)?(target.RangoFinal.HasValue):!source.RangoFinal.Equals(target.RangoFinal))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IndicadorTipo_Nombre == null)?target.IndicadorTipo_Nombre!=null: !( (target.IndicadorTipo_Nombre== String.Empty && source.IndicadorTipo_Nombre== null) || (target.IndicadorTipo_Nombre==null && source.IndicadorTipo_Nombre== String.Empty )) &&   !source.IndicadorTipo_Nombre.Trim().Replace ("\r","").Equals(target.IndicadorTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.IndicadorTipo_SectorRequerido.Equals(target.IndicadorTipo_SectorRequerido))return false;
					  if(!source.IndicadorTipo_Activo.Equals(target.IndicadorTipo_Activo))return false;
					  if((source.Unidad_Sigla == null)?target.Unidad_Sigla!=null: !( (target.Unidad_Sigla== String.Empty && source.Unidad_Sigla== null) || (target.Unidad_Sigla==null && source.Unidad_Sigla== String.Empty )) &&   !source.Unidad_Sigla.Trim().Replace ("\r","").Equals(target.Unidad_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.Unidad_Nombre == null)?target.Unidad_Nombre!=null: !( (target.Unidad_Nombre== String.Empty && source.Unidad_Nombre== null) || (target.Unidad_Nombre==null && source.Unidad_Nombre== String.Empty )) &&   !source.Unidad_Nombre.Trim().Replace ("\r","").Equals(target.Unidad_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Unidad_Activo.Equals(target.Unidad_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
