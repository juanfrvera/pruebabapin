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
    public abstract class _PerfilData : EntityData<Perfil,PerfilFilter,PerfilResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Perfil entity)
		{			
			return entity.IdPerfil;
		}		
		public override Perfil GetByEntity(Perfil entity)
        {
            return this.GetById(entity.IdPerfil);
        }
        public override Perfil GetById(int id)
        {
            return (from o in this.Table where o.IdPerfil == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Perfil> Query(PerfilFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdPerfilTipo == null || filter.IdPerfilTipo == 0 || o.IdPerfilTipo==filter.IdPerfilTipo)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.EsDefault == null || o.EsDefault==filter.EsDefault)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PerfilResult> QueryResult(PerfilFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PerfilTipos on o.IdPerfilTipo equals t1.IdPerfilTipo   
				   select new PerfilResult(){
					 IdPerfil=o.IdPerfil
					 ,Nombre=o.Nombre
					 ,IdPerfilTipo=o.IdPerfilTipo
					 ,Activo=o.Activo
					 ,EsDefault=o.EsDefault
					 ,Codigo=o.Codigo
					,PerfilTipo_Nombre= t1.Nombre	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Perfil Copy(nc.Perfil entity)
        {           
            nc.Perfil _new = new nc.Perfil();
		 _new.Nombre= entity.Nombre;
		 _new.IdPerfilTipo= entity.IdPerfilTipo;
		 _new.Activo= entity.Activo;
		 _new.EsDefault= entity.EsDefault;
		 _new.Codigo= entity.Codigo;
		return _new;			
        }
		public override int CopyAndSave(Perfil entity,string renameFormat)
        {
            Perfil  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Perfil entity, int id)
        {            
            entity.IdPerfil = id;            
        }
		public override void Set(Perfil source,Perfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfil= source.IdPerfil ;
		 target.Nombre= source.Nombre ;
		 target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Activo= source.Activo ;
		 target.EsDefault= source.EsDefault ;
		 target.Codigo= source.Codigo ;
		 		  
		}
		public override void Set(PerfilResult source,Perfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfil= source.IdPerfil ;
		 target.Nombre= source.Nombre ;
		 target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Activo= source.Activo ;
		 target.EsDefault= source.EsDefault ;
		 target.Codigo= source.Codigo ;
		 
		}
		public override void Set(Perfil source,PerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfil= source.IdPerfil ;
		 target.Nombre= source.Nombre ;
		 target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Activo= source.Activo ;
		 target.EsDefault= source.EsDefault ;
		 target.Codigo= source.Codigo ;
		 	
		}		
		public override void Set(PerfilResult source,PerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfil= source.IdPerfil ;
		 target.Nombre= source.Nombre ;
		 target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Activo= source.Activo ;
		 target.EsDefault= source.EsDefault ;
		 target.Codigo= source.Codigo ;
		 target.PerfilTipo_Nombre= source.PerfilTipo_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Perfil source,Perfil target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdPerfilTipo.Equals(target.IdPerfilTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.EsDefault.Equals(target.EsDefault))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PerfilResult source,PerfilResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdPerfilTipo.Equals(target.IdPerfilTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.EsDefault.Equals(target.EsDefault))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.PerfilTipo_Nombre == null)?target.PerfilTipo_Nombre!=null: !( (target.PerfilTipo_Nombre== String.Empty && source.PerfilTipo_Nombre== null) || (target.PerfilTipo_Nombre==null && source.PerfilTipo_Nombre== String.Empty )) &&   !source.PerfilTipo_Nombre.Trim().Replace ("\r","").Equals(target.PerfilTipo_Nombre.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
