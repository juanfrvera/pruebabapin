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
    public abstract class _SistemaCommandData : EntityData<SistemaCommand,SistemaCommandFilter,SistemaCommandResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaCommand entity)
		{			
			return entity.IdSistemaCommand;
		}		
		public override SistemaCommand GetByEntity(SistemaCommand entity)
        {
            return this.GetById(entity.IdSistemaCommand);
        }
        public override SistemaCommand GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaCommand == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaCommand> Query(SistemaCommandFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaCommand == null || o.IdSistemaCommand >=  filter.IdSistemaCommand) && (filter.IdSistemaCommand_To == null || o.IdSistemaCommand <= filter.IdSistemaCommand_To)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.IdsistemaEntidad == null || filter.IdsistemaEntidad == 0 || o.IdsistemaEntidad==filter.IdsistemaEntidad)
					  && (filter.CommandText == null || filter.CommandText.Trim() == string.Empty || filter.CommandText.Trim() == "%"  || (filter.CommandText.EndsWith("%") && filter.CommandText.StartsWith("%") && (o.CommandText.Contains(filter.CommandText.Replace("%", "")))) || (filter.CommandText.EndsWith("%") && o.CommandText.StartsWith(filter.CommandText.Replace("%",""))) || (filter.CommandText.StartsWith("%") && o.CommandText.EndsWith(filter.CommandText.Replace("%",""))) || o.CommandText == filter.CommandText )
					  && (filter.CommandType == null || o.CommandType >=  filter.CommandType) && (filter.CommandType_To == null || o.CommandType <= filter.CommandType_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaCommandResult> QueryResult(SistemaCommandFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.SistemaEntidads on o.IdsistemaEntidad equals t1.IdSistemaEntidad   
				   select new SistemaCommandResult(){
					 IdSistemaCommand=o.IdSistemaCommand
					 ,Nombre=o.Nombre
					 ,Descripcion=o.Descripcion
					 ,IdsistemaEntidad=o.IdsistemaEntidad
					 ,CommandText=o.CommandText
					 ,CommandType=o.CommandType
					 ,Activo=o.Activo
					,sistemaEntidad_Codigo= t1.Codigo	
						,sistemaEntidad_Nombre= t1.Nombre	
						,sistemaEntidad_EntidadTipo= t1.EntidadTipo	
						,sistemaEntidad_EntidadClase= t1.EntidadClase	
						,sistemaEntidad_EntidadClaseBase= t1.EntidadClaseBase	
						,sistemaEntidad_Activo= t1.Activo	
						,sistemaEntidad_IncluirSeguridad= t1.IncluirSeguridad	
						,sistemaEntidad_IncluirConfiguracion= t1.IncluirConfiguracion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaCommand Copy(nc.SistemaCommand entity)
        {           
            nc.SistemaCommand _new = new nc.SistemaCommand();
		 _new.Nombre= entity.Nombre;
		 _new.Descripcion= entity.Descripcion;
		 _new.IdsistemaEntidad= entity.IdsistemaEntidad;
		 _new.CommandText= entity.CommandText;
		 _new.CommandType= entity.CommandType;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(SistemaCommand entity,string renameFormat)
        {
            SistemaCommand  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaCommand entity, int id)
        {            
            entity.IdSistemaCommand = id;            
        }
		public override void Set(SistemaCommand source,SistemaCommand target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaCommand= source.IdSistemaCommand ;
		 target.Nombre= source.Nombre ;
		 target.Descripcion= source.Descripcion ;
		 target.IdsistemaEntidad= source.IdsistemaEntidad ;
		 target.CommandText= source.CommandText ;
		 target.CommandType= source.CommandType ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(SistemaCommandResult source,SistemaCommand target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaCommand= source.IdSistemaCommand ;
		 target.Nombre= source.Nombre ;
		 target.Descripcion= source.Descripcion ;
		 target.IdsistemaEntidad= source.IdsistemaEntidad ;
		 target.CommandText= source.CommandText ;
		 target.CommandType= source.CommandType ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(SistemaCommand source,SistemaCommandResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaCommand= source.IdSistemaCommand ;
		 target.Nombre= source.Nombre ;
		 target.Descripcion= source.Descripcion ;
		 target.IdsistemaEntidad= source.IdsistemaEntidad ;
		 target.CommandText= source.CommandText ;
		 target.CommandType= source.CommandType ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(SistemaCommandResult source,SistemaCommandResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaCommand= source.IdSistemaCommand ;
		 target.Nombre= source.Nombre ;
		 target.Descripcion= source.Descripcion ;
		 target.IdsistemaEntidad= source.IdsistemaEntidad ;
		 target.CommandText= source.CommandText ;
		 target.CommandType= source.CommandType ;
		 target.Activo= source.Activo ;
		 target.sistemaEntidad_Codigo= source.sistemaEntidad_Codigo;	
			target.sistemaEntidad_Nombre= source.sistemaEntidad_Nombre;	
			target.sistemaEntidad_EntidadTipo= source.sistemaEntidad_EntidadTipo;	
			target.sistemaEntidad_EntidadClase= source.sistemaEntidad_EntidadClase;	
			target.sistemaEntidad_EntidadClaseBase= source.sistemaEntidad_EntidadClaseBase;	
			target.sistemaEntidad_Activo= source.sistemaEntidad_Activo;	
			target.sistemaEntidad_IncluirSeguridad= source.sistemaEntidad_IncluirSeguridad;	
			target.sistemaEntidad_IncluirConfiguracion= source.sistemaEntidad_IncluirConfiguracion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(SistemaCommand source,SistemaCommand target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaCommand.Equals(target.IdSistemaCommand))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdsistemaEntidad.Equals(target.IdsistemaEntidad))return false;
		  if((source.CommandText == null)?target.CommandText!=null:  !( (target.CommandText== String.Empty && source.CommandText== null) || (target.CommandText==null && source.CommandText== String.Empty )) &&  !source.CommandText.Trim().Replace ("\r","").Equals(target.CommandText.Trim().Replace ("\r","")))return false;
			 if(!source.CommandType.Equals(target.CommandType))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(SistemaCommandResult source,SistemaCommandResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaCommand.Equals(target.IdSistemaCommand))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdsistemaEntidad.Equals(target.IdsistemaEntidad))return false;
		  if((source.CommandText == null)?target.CommandText!=null: !( (target.CommandText== String.Empty && source.CommandText== null) || (target.CommandText==null && source.CommandText== String.Empty )) && !source.CommandText.Trim().Replace ("\r","").Equals(target.CommandText.Trim().Replace ("\r","")))return false;
			 if(!source.CommandType.Equals(target.CommandType))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.sistemaEntidad_Codigo == null)?target.sistemaEntidad_Codigo!=null: !( (target.sistemaEntidad_Codigo== String.Empty && source.sistemaEntidad_Codigo== null) || (target.sistemaEntidad_Codigo==null && source.sistemaEntidad_Codigo== String.Empty )) &&   !source.sistemaEntidad_Codigo.Trim().Replace ("\r","").Equals(target.sistemaEntidad_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.sistemaEntidad_Nombre == null)?target.sistemaEntidad_Nombre!=null: !( (target.sistemaEntidad_Nombre== String.Empty && source.sistemaEntidad_Nombre== null) || (target.sistemaEntidad_Nombre==null && source.sistemaEntidad_Nombre== String.Empty )) &&   !source.sistemaEntidad_Nombre.Trim().Replace ("\r","").Equals(target.sistemaEntidad_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.sistemaEntidad_EntidadTipo == null)?target.sistemaEntidad_EntidadTipo!=null: !( (target.sistemaEntidad_EntidadTipo== String.Empty && source.sistemaEntidad_EntidadTipo== null) || (target.sistemaEntidad_EntidadTipo==null && source.sistemaEntidad_EntidadTipo== String.Empty )) &&   !source.sistemaEntidad_EntidadTipo.Trim().Replace ("\r","").Equals(target.sistemaEntidad_EntidadTipo.Trim().Replace ("\r","")))return false;
						 if((source.sistemaEntidad_EntidadClase == null)?target.sistemaEntidad_EntidadClase!=null: !( (target.sistemaEntidad_EntidadClase== String.Empty && source.sistemaEntidad_EntidadClase== null) || (target.sistemaEntidad_EntidadClase==null && source.sistemaEntidad_EntidadClase== String.Empty )) &&   !source.sistemaEntidad_EntidadClase.Trim().Replace ("\r","").Equals(target.sistemaEntidad_EntidadClase.Trim().Replace ("\r","")))return false;
						 if((source.sistemaEntidad_EntidadClaseBase == null)?target.sistemaEntidad_EntidadClaseBase!=null: !( (target.sistemaEntidad_EntidadClaseBase== String.Empty && source.sistemaEntidad_EntidadClaseBase== null) || (target.sistemaEntidad_EntidadClaseBase==null && source.sistemaEntidad_EntidadClaseBase== String.Empty )) &&   !source.sistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","").Equals(target.sistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","")))return false;
						 if(!source.sistemaEntidad_Activo.Equals(target.sistemaEntidad_Activo))return false;
					  if((source.sistemaEntidad_IncluirSeguridad == null)?(target.sistemaEntidad_IncluirSeguridad.HasValue ):!source.sistemaEntidad_IncluirSeguridad.Equals(target.sistemaEntidad_IncluirSeguridad))return false;
						 if((source.sistemaEntidad_IncluirConfiguracion == null)?(target.sistemaEntidad_IncluirConfiguracion.HasValue ):!source.sistemaEntidad_IncluirConfiguracion.Equals(target.sistemaEntidad_IncluirConfiguracion))return false;
								
		  return true;
        }
		#endregion
    }
}
