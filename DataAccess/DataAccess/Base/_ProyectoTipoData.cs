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
    public abstract class _ProyectoTipoData : EntityData<ProyectoTipo,ProyectoTipoFilter,ProyectoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoTipo entity)
		{			
			return entity.IdProyectoTipo;
		}		
		public override ProyectoTipo GetByEntity(ProyectoTipo entity)
        {
            return this.GetById(entity.IdProyectoTipo);
        }
        public override ProyectoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoTipo> Query(ProyectoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoTipo == null || filter.IdProyectoTipo == 0 || o.IdProyectoTipo==filter.IdProyectoTipo)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.Tipo == null || filter.Tipo.Trim() == string.Empty || filter.Tipo.Trim() == "%"  || (filter.Tipo.EndsWith("%") && filter.Tipo.StartsWith("%") && (o.Tipo.Contains(filter.Tipo.Replace("%", "")))) || (filter.Tipo.EndsWith("%") && o.Tipo.StartsWith(filter.Tipo.Replace("%",""))) || (filter.Tipo.StartsWith("%") && o.Tipo.EndsWith(filter.Tipo.Replace("%",""))) || o.Tipo == filter.Tipo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoTipoResult> QueryResult(ProyectoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ProyectoTipoResult(){
					 IdProyectoTipo=o.IdProyectoTipo
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					 ,Tipo=o.Tipo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoTipo Copy(nc.ProyectoTipo entity)
        {           
            nc.ProyectoTipo _new = new nc.ProyectoTipo();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		 _new.Tipo= entity.Tipo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoTipo entity,string renameFormat)
        {
            ProyectoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoTipo entity, int id)
        {            
            entity.IdProyectoTipo = id;            
        }
		public override void Set(ProyectoTipo source,ProyectoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Tipo= source.Tipo ;
		 		  
		}
		public override void Set(ProyectoTipoResult source,ProyectoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Tipo= source.Tipo ;
		 
		}
		public override void Set(ProyectoTipo source,ProyectoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Tipo= source.Tipo ;
		 	
		}		
		public override void Set(ProyectoTipoResult source,ProyectoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.Tipo= source.Tipo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoTipo source,ProyectoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Tipo == null)?target.Tipo!=null:  !( (target.Tipo== String.Empty && source.Tipo== null) || (target.Tipo==null && source.Tipo== String.Empty )) &&  !source.Tipo.Trim().Replace ("\r","").Equals(target.Tipo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ProyectoTipoResult source,ProyectoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Tipo == null)?target.Tipo!=null: !( (target.Tipo== String.Empty && source.Tipo== null) || (target.Tipo==null && source.Tipo== String.Empty )) && !source.Tipo.Trim().Replace ("\r","").Equals(target.Tipo.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
