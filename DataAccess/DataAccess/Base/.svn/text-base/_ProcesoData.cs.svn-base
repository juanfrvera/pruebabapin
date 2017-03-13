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
    public abstract class _ProcesoData : EntityData<Proceso,ProcesoFilter,ProcesoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Proceso entity)
		{			
			return entity.IdProceso;
		}		
		public override Proceso GetByEntity(Proceso entity)
        {
            return this.GetById(entity.IdProceso);
        }
        public override Proceso GetById(int id)
        {
            return (from o in this.Table where o.IdProceso == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Proceso> Query(ProcesoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso==filter.IdProceso)
					  && (filter.IdProyectoTipo == null || filter.IdProyectoTipo == 0 || o.IdProyectoTipo==filter.IdProyectoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProcesoResult> QueryResult(ProcesoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoTipos on o.IdProyectoTipo equals t1.IdProyectoTipo   
				   select new ProcesoResult(){
					 IdProceso=o.IdProceso
					 ,IdProyectoTipo=o.IdProyectoTipo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					,ProyectoTipo_Sigla= t1.Sigla	
						,ProyectoTipo_Nombre= t1.Nombre	
						,ProyectoTipo_Activo= t1.Activo	
						,ProyectoTipo_Tipo= t1.Tipo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Proceso Copy(nc.Proceso entity)
        {           
            nc.Proceso _new = new nc.Proceso();
		 _new.IdProyectoTipo= entity.IdProyectoTipo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Proceso entity,string renameFormat)
        {
            Proceso  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Proceso entity, int id)
        {            
            entity.IdProceso = id;            
        }
		public override void Set(Proceso source,Proceso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProceso= source.IdProceso ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ProcesoResult source,Proceso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProceso= source.IdProceso ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Proceso source,ProcesoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProceso= source.IdProceso ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ProcesoResult source,ProcesoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProceso= source.IdProceso ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.ProyectoTipo_Sigla= source.ProyectoTipo_Sigla;	
			target.ProyectoTipo_Nombre= source.ProyectoTipo_Nombre;	
			target.ProyectoTipo_Activo= source.ProyectoTipo_Activo;	
			target.ProyectoTipo_Tipo= source.ProyectoTipo_Tipo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Proceso source,Proceso target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProceso.Equals(target.IdProceso))return false;
		  if(!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ProcesoResult source,ProcesoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProceso.Equals(target.IdProceso))return false;
		  if(!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.ProyectoTipo_Sigla == null)?target.ProyectoTipo_Sigla!=null: !( (target.ProyectoTipo_Sigla== String.Empty && source.ProyectoTipo_Sigla== null) || (target.ProyectoTipo_Sigla==null && source.ProyectoTipo_Sigla== String.Empty )) &&   !source.ProyectoTipo_Sigla.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoTipo_Nombre == null)?target.ProyectoTipo_Nombre!=null: !( (target.ProyectoTipo_Nombre== String.Empty && source.ProyectoTipo_Nombre== null) || (target.ProyectoTipo_Nombre==null && source.ProyectoTipo_Nombre== String.Empty )) &&   !source.ProyectoTipo_Nombre.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoTipo_Activo.Equals(target.ProyectoTipo_Activo))return false;
					  if((source.ProyectoTipo_Tipo == null)?target.ProyectoTipo_Tipo!=null: !( (target.ProyectoTipo_Tipo== String.Empty && source.ProyectoTipo_Tipo== null) || (target.ProyectoTipo_Tipo==null && source.ProyectoTipo_Tipo== String.Empty )) &&   !source.ProyectoTipo_Tipo.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Tipo.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
