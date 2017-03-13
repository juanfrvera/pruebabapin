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
    public abstract class _ConfigurationData : EntityData<Configuration,ConfigurationFilter,ConfigurationResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Configuration entity)
		{			
			return entity.IdConfiguration;
		}		
		public override Configuration GetByEntity(Configuration entity)
        {
            return this.GetById(entity.IdConfiguration);
        }
        public override Configuration GetById(int id)
        {
            return (from o in this.Table where o.IdConfiguration == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Configuration> Query(ConfigurationFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdConfiguration == null || o.IdConfiguration >=  filter.IdConfiguration) && (filter.IdConfiguration_To == null || o.IdConfiguration <= filter.IdConfiguration_To)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Code == null || filter.Code.Trim() == string.Empty || filter.Code.Trim() == "%"  || (filter.Code.EndsWith("%") && filter.Code.StartsWith("%") && (o.Code.Contains(filter.Code.Replace("%", "")))) || (filter.Code.EndsWith("%") && o.Code.StartsWith(filter.Code.Replace("%",""))) || (filter.Code.StartsWith("%") && o.Code.EndsWith(filter.Code.Replace("%",""))) || o.Code == filter.Code )
					  && (filter.Description == null || filter.Description.Trim() == string.Empty || filter.Description.Trim() == "%"  || (filter.Description.EndsWith("%") && filter.Description.StartsWith("%") && (o.Description.Contains(filter.Description.Replace("%", "")))) || (filter.Description.EndsWith("%") && o.Description.StartsWith(filter.Description.Replace("%",""))) || (filter.Description.StartsWith("%") && o.Description.EndsWith(filter.Description.Replace("%",""))) || o.Description == filter.Description )
					  && (filter.IdConfigurationCategory == null || filter.IdConfigurationCategory == 0 || o.IdConfigurationCategory==filter.IdConfigurationCategory)
					  && (filter.Active == null || o.Active==filter.Active)
					  && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.IdSistemaEntidadIsNull == null || filter.IdSistemaEntidadIsNull == true || o.IdSistemaEntidad != null ) && (filter.IdSistemaEntidadIsNull == null || filter.IdSistemaEntidadIsNull == false || o.IdSistemaEntidad == null)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.IdEstadoIsNull == null || filter.IdEstadoIsNull == true || o.IdEstado != null ) && (filter.IdEstadoIsNull == null || filter.IdEstadoIsNull == false || o.IdEstado == null)
					  && (filter.StringValue == null || filter.StringValue.Trim() == string.Empty || filter.StringValue.Trim() == "%"  || (filter.StringValue.EndsWith("%") && filter.StringValue.StartsWith("%") && (o.StringValue.Contains(filter.StringValue.Replace("%", "")))) || (filter.StringValue.EndsWith("%") && o.StringValue.StartsWith(filter.StringValue.Replace("%",""))) || (filter.StringValue.StartsWith("%") && o.StringValue.EndsWith(filter.StringValue.Replace("%",""))) || o.StringValue == filter.StringValue )
					  && (filter.NumberValue == null || o.NumberValue >=  filter.NumberValue) && (filter.NumberValue_To == null || o.NumberValue <= filter.NumberValue_To)
					  && (filter.NumberValueIsNull == null || filter.NumberValueIsNull == true || o.NumberValue != null ) && (filter.NumberValueIsNull == null || filter.NumberValueIsNull == false || o.NumberValue == null)
					  && (filter.DateValue == null || filter.DateValue == DateTime.MinValue || o.DateValue >=  filter.DateValue) && (filter.DateValue_To == null || filter.DateValue_To == DateTime.MinValue || o.DateValue <= filter.DateValue_To)
					  && (filter.DateValueIsNull == null || filter.DateValueIsNull == true || o.DateValue != null ) && (filter.DateValueIsNull == null || filter.DateValueIsNull == false || o.DateValue == null)
					  && (filter.BooleanValue == null || o.BooleanValue==filter.BooleanValue)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ConfigurationResult> QueryResult(ConfigurationFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ConfigurationCategories on o.IdConfigurationCategory equals t1.IdConfigurationCategory   
				   join _t2  in this.Context.Estados on o.IdEstado equals _t2.IdEstado into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals _t3.IdSistemaEntidad into tt3 from t3 in tt3.DefaultIfEmpty()
				   select new ConfigurationResult(){
					 IdConfiguration=o.IdConfiguration
					 ,Name=o.Name
					 ,Code=o.Code
					 ,Description=o.Description
					 ,IdConfigurationCategory=o.IdConfigurationCategory
					 ,Active=o.Active
					 ,IdSistemaEntidad=o.IdSistemaEntidad
					 ,IdEstado=o.IdEstado
					 ,StringValue=o.StringValue
					 ,NumberValue=o.NumberValue
					 ,DateValue=o.DateValue
					 ,BooleanValue=o.BooleanValue
					,ConfigurationCategory_Name= t1.Name	
						,Estado_Nombre= t2!=null?(string)t2.Nombre:null	
						,Estado_Codigo= t2!=null?(string)t2.Codigo:null	
						,Estado_Orden= t2!=null?(int?)t2.Orden:null	
						,Estado_Descripcion= t2!=null?(string)t2.Descripcion:null	
						,Estado_Activo= t2!=null?(bool?)t2.Activo:null	
						,SistemaEntidad_Codigo= t3!=null?(string)t3.Codigo:null	
						,SistemaEntidad_Nombre= t3!=null?(string)t3.Nombre:null	
						,SistemaEntidad_EntidadTipo= t3!=null?(string)t3.EntidadTipo:null	
						,SistemaEntidad_EntidadClase= t3!=null?(string)t3.EntidadClase:null	
						,SistemaEntidad_EntidadClaseBase= t3!=null?(string)t3.EntidadClaseBase:null	
						,SistemaEntidad_Activo= t3!=null?(bool?)t3.Activo:null	
						,SistemaEntidad_IncluirSeguridad= t3!=null?(bool?)t3.IncluirSeguridad:null	
						,SistemaEntidad_IncluirConfiguracion= t3!=null?(bool?)t3.IncluirConfiguracion:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Configuration Copy(nc.Configuration entity)
        {           
            nc.Configuration _new = new nc.Configuration();
		 _new.Name= entity.Name;
		 _new.Code= entity.Code;
		 _new.Description= entity.Description;
		 _new.IdConfigurationCategory= entity.IdConfigurationCategory;
		 _new.Active= entity.Active;
		 _new.IdSistemaEntidad= entity.IdSistemaEntidad;
		 _new.IdEstado= entity.IdEstado;
		 _new.StringValue= entity.StringValue;
		 _new.NumberValue= entity.NumberValue;
		 _new.DateValue= entity.DateValue;
		 _new.BooleanValue= entity.BooleanValue;
		return _new;			
        }
		public override int CopyAndSave(Configuration entity,string renameFormat)
        {
            Configuration  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Configuration entity, int id)
        {            
            entity.IdConfiguration = id;            
        }
		public override void Set(Configuration source,Configuration target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfiguration= source.IdConfiguration ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Active= source.Active ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.BooleanValue= source.BooleanValue ;
		 		  
		}
		public override void Set(ConfigurationResult source,Configuration target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfiguration= source.IdConfiguration ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Active= source.Active ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.BooleanValue= source.BooleanValue ;
		 
		}
		public override void Set(Configuration source,ConfigurationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfiguration= source.IdConfiguration ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Active= source.Active ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.BooleanValue= source.BooleanValue ;
		 	
		}		
		public override void Set(ConfigurationResult source,ConfigurationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfiguration= source.IdConfiguration ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Active= source.Active ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.BooleanValue= source.BooleanValue ;
		 target.ConfigurationCategory_Name= source.ConfigurationCategory_Name;	
			target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.SistemaEntidad_Codigo= source.SistemaEntidad_Codigo;	
			target.SistemaEntidad_Nombre= source.SistemaEntidad_Nombre;	
			target.SistemaEntidad_EntidadTipo= source.SistemaEntidad_EntidadTipo;	
			target.SistemaEntidad_EntidadClase= source.SistemaEntidad_EntidadClase;	
			target.SistemaEntidad_EntidadClaseBase= source.SistemaEntidad_EntidadClaseBase;	
			target.SistemaEntidad_Activo= source.SistemaEntidad_Activo;	
			target.SistemaEntidad_IncluirSeguridad= source.SistemaEntidad_IncluirSeguridad;	
			target.SistemaEntidad_IncluirConfiguracion= source.SistemaEntidad_IncluirConfiguracion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Configuration source,Configuration target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdConfiguration.Equals(target.IdConfiguration))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null:  !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) &&  !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null:  !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) &&  !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdConfigurationCategory.Equals(target.IdConfigurationCategory))return false;
		  if(!source.Active.Equals(target.Active))return false;
		  if((source.IdSistemaEntidad == null)?(target.IdSistemaEntidad.HasValue && target.IdSistemaEntidad.Value > 0):!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
						  if((source.IdEstado == null)?(target.IdEstado.HasValue && target.IdEstado.Value > 0):!source.IdEstado.Equals(target.IdEstado))return false;
						  if((source.StringValue == null)?target.StringValue!=null:  !( (target.StringValue== String.Empty && source.StringValue== null) || (target.StringValue==null && source.StringValue== String.Empty )) &&  !source.StringValue.Trim().Replace ("\r","").Equals(target.StringValue.Trim().Replace ("\r","")))return false;
			 if((source.NumberValue == null)?(target.NumberValue.HasValue):!source.NumberValue.Equals(target.NumberValue))return false;
			 if((source.DateValue == null)?(target.DateValue.HasValue):!source.DateValue.Equals(target.DateValue))return false;
			 if(!source.BooleanValue.Equals(target.BooleanValue))return false;
		 
		  return true;
        }
		public override bool Equals(ConfigurationResult source,ConfigurationResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdConfiguration.Equals(target.IdConfiguration))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null: !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) && !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null: !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) && !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdConfigurationCategory.Equals(target.IdConfigurationCategory))return false;
		  if(!source.Active.Equals(target.Active))return false;
		  if((source.IdSistemaEntidad == null)?(target.IdSistemaEntidad.HasValue && target.IdSistemaEntidad.Value > 0):!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
						  if((source.IdEstado == null)?(target.IdEstado.HasValue && target.IdEstado.Value > 0):!source.IdEstado.Equals(target.IdEstado))return false;
						  if((source.StringValue == null)?target.StringValue!=null: !( (target.StringValue== String.Empty && source.StringValue== null) || (target.StringValue==null && source.StringValue== String.Empty )) && !source.StringValue.Trim().Replace ("\r","").Equals(target.StringValue.Trim().Replace ("\r","")))return false;
			 if((source.NumberValue == null)?(target.NumberValue.HasValue):!source.NumberValue.Equals(target.NumberValue))return false;
			 if((source.DateValue == null)?(target.DateValue.HasValue):!source.DateValue.Equals(target.DateValue))return false;
			 if(!source.BooleanValue.Equals(target.BooleanValue))return false;
		  if((source.ConfigurationCategory_Name == null)?target.ConfigurationCategory_Name!=null: !( (target.ConfigurationCategory_Name== String.Empty && source.ConfigurationCategory_Name== null) || (target.ConfigurationCategory_Name==null && source.ConfigurationCategory_Name== String.Empty )) &&   !source.ConfigurationCategory_Name.Trim().Replace ("\r","").Equals(target.ConfigurationCategory_Name.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if((source.SistemaEntidad_Codigo == null)?target.SistemaEntidad_Codigo!=null: !( (target.SistemaEntidad_Codigo== String.Empty && source.SistemaEntidad_Codigo== null) || (target.SistemaEntidad_Codigo==null && source.SistemaEntidad_Codigo== String.Empty )) &&   !source.SistemaEntidad_Codigo.Trim().Replace ("\r","").Equals(target.SistemaEntidad_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_Nombre == null)?target.SistemaEntidad_Nombre!=null: !( (target.SistemaEntidad_Nombre== String.Empty && source.SistemaEntidad_Nombre== null) || (target.SistemaEntidad_Nombre==null && source.SistemaEntidad_Nombre== String.Empty )) &&   !source.SistemaEntidad_Nombre.Trim().Replace ("\r","").Equals(target.SistemaEntidad_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadTipo == null)?target.SistemaEntidad_EntidadTipo!=null: !( (target.SistemaEntidad_EntidadTipo== String.Empty && source.SistemaEntidad_EntidadTipo== null) || (target.SistemaEntidad_EntidadTipo==null && source.SistemaEntidad_EntidadTipo== String.Empty )) &&   !source.SistemaEntidad_EntidadTipo.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadTipo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadClase == null)?target.SistemaEntidad_EntidadClase!=null: !( (target.SistemaEntidad_EntidadClase== String.Empty && source.SistemaEntidad_EntidadClase== null) || (target.SistemaEntidad_EntidadClase==null && source.SistemaEntidad_EntidadClase== String.Empty )) &&   !source.SistemaEntidad_EntidadClase.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadClase.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadClaseBase == null)?target.SistemaEntidad_EntidadClaseBase!=null: !( (target.SistemaEntidad_EntidadClaseBase== String.Empty && source.SistemaEntidad_EntidadClaseBase== null) || (target.SistemaEntidad_EntidadClaseBase==null && source.SistemaEntidad_EntidadClaseBase== String.Empty )) &&   !source.SistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaEntidad_Activo.Equals(target.SistemaEntidad_Activo))return false;
					  if((source.SistemaEntidad_IncluirSeguridad == null)?(target.SistemaEntidad_IncluirSeguridad.HasValue ):!source.SistemaEntidad_IncluirSeguridad.Equals(target.SistemaEntidad_IncluirSeguridad))return false;
						 if((source.SistemaEntidad_IncluirConfiguracion == null)?(target.SistemaEntidad_IncluirConfiguracion.HasValue ):!source.SistemaEntidad_IncluirConfiguracion.Equals(target.SistemaEntidad_IncluirConfiguracion))return false;
								
		  return true;
        }
		#endregion
    }
}
