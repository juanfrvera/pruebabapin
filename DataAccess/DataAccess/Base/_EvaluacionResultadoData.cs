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
    public abstract class _EvaluacionResultadoData : EntityData<EvaluacionResultado,EvaluacionResultadoFilter,EvaluacionResultadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EvaluacionResultado entity)
		{			
			return entity.IdEvaluacionResultado;
		}		
		public override EvaluacionResultado GetByEntity(EvaluacionResultado entity)
        {
            return this.GetById(entity.IdEvaluacionResultado);
        }
        public override EvaluacionResultado GetById(int id)
        {
            return (from o in this.Table where o.IdEvaluacionResultado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EvaluacionResultado> Query(EvaluacionResultadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEvaluacionResultado == null || filter.IdEvaluacionResultado == 0 || o.IdEvaluacionResultado==filter.IdEvaluacionResultado)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Aspecto == null || filter.Aspecto.Trim() == string.Empty || filter.Aspecto.Trim() == "%"  || (filter.Aspecto.EndsWith("%") && filter.Aspecto.StartsWith("%") && (o.Aspecto.Contains(filter.Aspecto.Replace("%", "")))) || (filter.Aspecto.EndsWith("%") && o.Aspecto.StartsWith(filter.Aspecto.Replace("%",""))) || (filter.Aspecto.StartsWith("%") && o.Aspecto.EndsWith(filter.Aspecto.Replace("%",""))) || o.Aspecto == filter.Aspecto )
					  && (filter.Aprobado == null || o.Aprobado==filter.Aprobado)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EvaluacionResultadoResult> QueryResult(EvaluacionResultadoFilter filter)
        {
		  return (from o in Query(filter)					
					select new EvaluacionResultadoResult(){
					 IdEvaluacionResultado=o.IdEvaluacionResultado
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Aspecto=o.Aspecto
					 ,Aprobado=o.Aprobado
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EvaluacionResultado Copy(nc.EvaluacionResultado entity)
        {           
            nc.EvaluacionResultado _new = new nc.EvaluacionResultado();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Aspecto= entity.Aspecto;
		 _new.Aprobado= entity.Aprobado;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(EvaluacionResultado entity,string renameFormat)
        {
            EvaluacionResultado  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EvaluacionResultado entity, int id)
        {            
            entity.IdEvaluacionResultado = id;            
        }
		public override void Set(EvaluacionResultado source,EvaluacionResultado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Aspecto= source.Aspecto ;
		 target.Aprobado= source.Aprobado ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EvaluacionResultadoResult source,EvaluacionResultado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Aspecto= source.Aspecto ;
		 target.Aprobado= source.Aprobado ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(EvaluacionResultado source,EvaluacionResultadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Aspecto= source.Aspecto ;
		 target.Aprobado= source.Aprobado ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EvaluacionResultadoResult source,EvaluacionResultadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Aspecto= source.Aspecto ;
		 target.Aprobado= source.Aprobado ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(EvaluacionResultado source,EvaluacionResultado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionResultado.Equals(target.IdEvaluacionResultado))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Aspecto == null)?target.Aspecto!=null:  !( (target.Aspecto== String.Empty && source.Aspecto== null) || (target.Aspecto==null && source.Aspecto== String.Empty )) &&  !source.Aspecto.Trim().Replace ("\r","").Equals(target.Aspecto.Trim().Replace ("\r","")))return false;
			 if(!source.Aprobado.Equals(target.Aprobado))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(EvaluacionResultadoResult source,EvaluacionResultadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionResultado.Equals(target.IdEvaluacionResultado))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Aspecto == null)?target.Aspecto!=null: !( (target.Aspecto== String.Empty && source.Aspecto== null) || (target.Aspecto==null && source.Aspecto== String.Empty )) && !source.Aspecto.Trim().Replace ("\r","").Equals(target.Aspecto.Trim().Replace ("\r","")))return false;
			 if(!source.Aprobado.Equals(target.Aprobado))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
