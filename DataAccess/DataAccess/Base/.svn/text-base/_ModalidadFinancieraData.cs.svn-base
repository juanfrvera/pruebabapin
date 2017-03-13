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
    public abstract class _ModalidadFinancieraData : EntityData<ModalidadFinanciera,ModalidadFinancieraFilter,ModalidadFinancieraResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ModalidadFinanciera entity)
		{			
			return entity.IdModalidadFinanciera;
		}		
		public override ModalidadFinanciera GetByEntity(ModalidadFinanciera entity)
        {
            return this.GetById(entity.IdModalidadFinanciera);
        }
        public override ModalidadFinanciera GetById(int id)
        {
            return (from o in this.Table where o.IdModalidadFinanciera == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ModalidadFinanciera> Query(ModalidadFinancieraFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdModalidadFinanciera == null || o.IdModalidadFinanciera >=  filter.IdModalidadFinanciera) && (filter.IdModalidadFinanciera_To == null || o.IdModalidadFinanciera <= filter.IdModalidadFinanciera_To)
					  && (filter.IdOrganismoFinanciero == null || filter.IdOrganismoFinanciero == 0 || o.IdOrganismoFinanciero==filter.IdOrganismoFinanciero)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ModalidadFinancieraResult> QueryResult(ModalidadFinancieraFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.OrganismoFinancieros on o.IdOrganismoFinanciero equals t1.IdOrganismoFinanciero   
				   select new ModalidadFinancieraResult(){
					 IdModalidadFinanciera=o.IdModalidadFinanciera
					 ,IdOrganismoFinanciero=o.IdOrganismoFinanciero
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					,OrganismoFinanciero_Sigla= t1.Sigla	
						,OrganismoFinanciero_Nombre= t1.Nombre	
						,OrganismoFinanciero_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ModalidadFinanciera Copy(nc.ModalidadFinanciera entity)
        {           
            nc.ModalidadFinanciera _new = new nc.ModalidadFinanciera();
		 _new.IdOrganismoFinanciero= entity.IdOrganismoFinanciero;
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(ModalidadFinanciera entity,string renameFormat)
        {
            ModalidadFinanciera  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ModalidadFinanciera entity, int id)
        {            
            entity.IdModalidadFinanciera = id;            
        }
		public override void Set(ModalidadFinanciera source,ModalidadFinanciera target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ModalidadFinancieraResult source,ModalidadFinanciera target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(ModalidadFinanciera source,ModalidadFinancieraResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ModalidadFinancieraResult source,ModalidadFinancieraResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.OrganismoFinanciero_Sigla= source.OrganismoFinanciero_Sigla;	
			target.OrganismoFinanciero_Nombre= source.OrganismoFinanciero_Nombre;	
			target.OrganismoFinanciero_Activo= source.OrganismoFinanciero_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ModalidadFinanciera source,ModalidadFinanciera target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ModalidadFinancieraResult source,ModalidadFinancieraResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.OrganismoFinanciero_Sigla == null)?target.OrganismoFinanciero_Sigla!=null: !( (target.OrganismoFinanciero_Sigla== String.Empty && source.OrganismoFinanciero_Sigla== null) || (target.OrganismoFinanciero_Sigla==null && source.OrganismoFinanciero_Sigla== String.Empty )) &&   !source.OrganismoFinanciero_Sigla.Trim().Replace ("\r","").Equals(target.OrganismoFinanciero_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.OrganismoFinanciero_Nombre == null)?target.OrganismoFinanciero_Nombre!=null: !( (target.OrganismoFinanciero_Nombre== String.Empty && source.OrganismoFinanciero_Nombre== null) || (target.OrganismoFinanciero_Nombre==null && source.OrganismoFinanciero_Nombre== String.Empty )) &&   !source.OrganismoFinanciero_Nombre.Trim().Replace ("\r","").Equals(target.OrganismoFinanciero_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.OrganismoFinanciero_Activo.Equals(target.OrganismoFinanciero_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
