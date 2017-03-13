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
    public abstract class _SistemaAccionData : EntityData<SistemaAccion,SistemaAccionFilter,SistemaAccionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaAccion entity)
		{			
			return entity.IdSistemaAccion;
		}		
		public override SistemaAccion GetByEntity(SistemaAccion entity)
        {
            return this.GetById(entity.IdSistemaAccion);
        }
        public override SistemaAccion GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaAccion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaAccion> Query(SistemaAccionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaAccion == null || filter.IdSistemaAccion == 0 || o.IdSistemaAccion==filter.IdSistemaAccion)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IncluirEstado == null || o.IncluirEstado==filter.IncluirEstado)
					  && (filter.EsLectura == null || o.EsLectura==filter.EsLectura)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaAccionResult> QueryResult(SistemaAccionFilter filter)
        {
		  return (from o in Query(filter)					
					select new SistemaAccionResult(){
					 IdSistemaAccion=o.IdSistemaAccion
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					 ,IncluirEstado=o.IncluirEstado
					 ,EsLectura=o.EsLectura
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaAccion Copy(nc.SistemaAccion entity)
        {           
            nc.SistemaAccion _new = new nc.SistemaAccion();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		 _new.IncluirEstado= entity.IncluirEstado;
		 _new.EsLectura= entity.EsLectura;
		return _new;			
        }
		public override int CopyAndSave(SistemaAccion entity,string renameFormat)
        {
            SistemaAccion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaAccion entity, int id)
        {            
            entity.IdSistemaAccion = id;            
        }
		public override void Set(SistemaAccion source,SistemaAccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IncluirEstado= source.IncluirEstado ;
		 target.EsLectura= source.EsLectura ;
		 		  
		}
		public override void Set(SistemaAccionResult source,SistemaAccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IncluirEstado= source.IncluirEstado ;
		 target.EsLectura= source.EsLectura ;
		 
		}
		public override void Set(SistemaAccion source,SistemaAccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IncluirEstado= source.IncluirEstado ;
		 target.EsLectura= source.EsLectura ;
		 	
		}		
		public override void Set(SistemaAccionResult source,SistemaAccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IncluirEstado= source.IncluirEstado ;
		 target.EsLectura= source.EsLectura ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(SistemaAccion source,SistemaAccion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.IncluirEstado.Equals(target.IncluirEstado))return false;
		  if(!source.EsLectura.Equals(target.EsLectura))return false;
		 
		  return true;
        }
		public override bool Equals(SistemaAccionResult source,SistemaAccionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.IncluirEstado.Equals(target.IncluirEstado))return false;
		  if(!source.EsLectura.Equals(target.EsLectura))return false;
		 		
		  return true;
        }
		#endregion
    }
}
