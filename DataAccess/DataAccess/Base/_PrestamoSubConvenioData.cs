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
    public abstract class _PrestamoSubConvenioData : EntityData<PrestamoSubConvenio,PrestamoSubConvenioFilter,PrestamoSubConvenioResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoSubConvenio entity)
		{			
			return entity.IdPrestamoSubConvenio;
		}		
		public override PrestamoSubConvenio GetByEntity(PrestamoSubConvenio entity)
        {
            return this.GetById(entity.IdPrestamoSubConvenio);
        }
        public override PrestamoSubConvenio GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoSubConvenio == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoSubConvenio> Query(PrestamoSubConvenioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoSubConvenio == null || o.IdPrestamoSubConvenio >=  filter.IdPrestamoSubConvenio) && (filter.IdPrestamoSubConvenio_To == null || o.IdPrestamoSubConvenio <= filter.IdPrestamoSubConvenio_To)
					  && (filter.IdPrestamoConvenio == null || filter.IdPrestamoConvenio == 0 || o.IdPrestamoConvenio==filter.IdPrestamoConvenio)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.IdTipoSubConvenio == null || filter.IdTipoSubConvenio == 0 || o.IdTipoSubConvenio==filter.IdTipoSubConvenio)
					  && (filter.Contraparte == null || filter.Contraparte.Trim() == string.Empty || filter.Contraparte.Trim() == "%"  || (filter.Contraparte.EndsWith("%") && filter.Contraparte.StartsWith("%") && (o.Contraparte.Contains(filter.Contraparte.Replace("%", "")))) || (filter.Contraparte.EndsWith("%") && o.Contraparte.StartsWith(filter.Contraparte.Replace("%",""))) || (filter.Contraparte.StartsWith("%") && o.Contraparte.EndsWith(filter.Contraparte.Replace("%",""))) || o.Contraparte == filter.Contraparte )
					  && (filter.MontoTotal == null || o.MontoTotal >=  filter.MontoTotal) && (filter.MontoTotal_To == null || o.MontoTotal <= filter.MontoTotal_To)
					  && (filter.MontoPrestamo == null || o.MontoPrestamo >=  filter.MontoPrestamo) && (filter.MontoPrestamo_To == null || o.MontoPrestamo <= filter.MontoPrestamo_To)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Ejecutor == null || filter.Ejecutor.Trim() == string.Empty || filter.Ejecutor.Trim() == "%"  || (filter.Ejecutor.EndsWith("%") && filter.Ejecutor.StartsWith("%") && (o.Ejecutor.Contains(filter.Ejecutor.Replace("%", "")))) || (filter.Ejecutor.EndsWith("%") && o.Ejecutor.StartsWith(filter.Ejecutor.Replace("%",""))) || (filter.Ejecutor.StartsWith("%") && o.Ejecutor.EndsWith(filter.Ejecutor.Replace("%",""))) || o.Ejecutor == filter.Ejecutor )
					  && (filter.Observaciones == null || filter.Observaciones.Trim() == string.Empty || filter.Observaciones.Trim() == "%"  || (filter.Observaciones.EndsWith("%") && filter.Observaciones.StartsWith("%") && (o.Observaciones.Contains(filter.Observaciones.Replace("%", "")))) || (filter.Observaciones.EndsWith("%") && o.Observaciones.StartsWith(filter.Observaciones.Replace("%",""))) || (filter.Observaciones.StartsWith("%") && o.Observaciones.EndsWith(filter.Observaciones.Replace("%",""))) || o.Observaciones == filter.Observaciones )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoSubConvenioResult> QueryResult(PrestamoSubConvenioFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PrestamoConvenios on o.IdPrestamoConvenio equals t1.IdPrestamoConvenio   
				    join t2  in this.Context.SubConvenioTipos on o.IdTipoSubConvenio equals t2.IdSubconvenioTipo   
				   select new PrestamoSubConvenioResult(){
					 IdPrestamoSubConvenio=o.IdPrestamoSubConvenio
					 ,IdPrestamoConvenio=o.IdPrestamoConvenio
					 ,Codigo=o.Codigo
					 ,Descripcion=o.Descripcion
					 ,IdTipoSubConvenio=o.IdTipoSubConvenio
					 ,Contraparte=o.Contraparte
					 ,MontoTotal=o.MontoTotal
					 ,MontoPrestamo=o.MontoPrestamo
					 ,Fecha=o.Fecha
					 ,Ejecutor=o.Ejecutor
					 ,Observaciones=o.Observaciones
					,PrestamoConvenio_IdPrestamo= t1.IdPrestamo	
						,PrestamoConvenio_IdOrganismoFinanciero= t1.IdOrganismoFinanciero	
						,PrestamoConvenio_Sigla= t1.Sigla	
						,PrestamoConvenio_Numero= t1.Numero	
						,PrestamoConvenio_MontoTotal= t1.MontoTotal	
						,PrestamoConvenio_MontoPrestamo= t1.MontoPrestamo	
						,PrestamoConvenio_IdMoneda= t1.IdMoneda	
						,PrestamoConvenio_Observacion= t1.Observacion	
						,PrestamoConvenio_IdModalidadFinanciera= t1.IdModalidadFinanciera	
						,PrestamoConvenio_DatosModalidadFinanciera= t1.DatosModalidadFinanciera	
						,TipoSubConvenio_Nombre= t2.Nombre	
						,TipoSubConvenio_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoSubConvenio Copy(nc.PrestamoSubConvenio entity)
        {           
            nc.PrestamoSubConvenio _new = new nc.PrestamoSubConvenio();
		 _new.IdPrestamoConvenio= entity.IdPrestamoConvenio;
		 _new.Codigo= entity.Codigo;
		 _new.Descripcion= entity.Descripcion;
		 _new.IdTipoSubConvenio= entity.IdTipoSubConvenio;
		 _new.Contraparte= entity.Contraparte;
		 _new.MontoTotal= entity.MontoTotal;
		 _new.MontoPrestamo= entity.MontoPrestamo;
		 _new.Fecha= entity.Fecha;
		 _new.Ejecutor= entity.Ejecutor;
		 _new.Observaciones= entity.Observaciones;
		return _new;			
        }
		public override int CopyAndSave(PrestamoSubConvenio entity,string renameFormat)
        {
            PrestamoSubConvenio  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoSubConvenio entity, int id)
        {            
            entity.IdPrestamoSubConvenio = id;            
        }
		public override void Set(PrestamoSubConvenio source,PrestamoSubConvenio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubConvenio= source.IdPrestamoSubConvenio ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdTipoSubConvenio= source.IdTipoSubConvenio ;
		 target.Contraparte= source.Contraparte ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.Ejecutor= source.Ejecutor ;
		 target.Observaciones= source.Observaciones ;
		 		  
		}
		public override void Set(PrestamoSubConvenioResult source,PrestamoSubConvenio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubConvenio= source.IdPrestamoSubConvenio ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdTipoSubConvenio= source.IdTipoSubConvenio ;
		 target.Contraparte= source.Contraparte ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.Ejecutor= source.Ejecutor ;
		 target.Observaciones= source.Observaciones ;
		 
		}
		public override void Set(PrestamoSubConvenio source,PrestamoSubConvenioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubConvenio= source.IdPrestamoSubConvenio ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdTipoSubConvenio= source.IdTipoSubConvenio ;
		 target.Contraparte= source.Contraparte ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.Ejecutor= source.Ejecutor ;
		 target.Observaciones= source.Observaciones ;
		 	
		}		
		public override void Set(PrestamoSubConvenioResult source,PrestamoSubConvenioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubConvenio= source.IdPrestamoSubConvenio ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdTipoSubConvenio= source.IdTipoSubConvenio ;
		 target.Contraparte= source.Contraparte ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.Ejecutor= source.Ejecutor ;
		 target.Observaciones= source.Observaciones ;
		 target.PrestamoConvenio_IdPrestamo= source.PrestamoConvenio_IdPrestamo;	
			target.PrestamoConvenio_IdOrganismoFinanciero= source.PrestamoConvenio_IdOrganismoFinanciero;	
			target.PrestamoConvenio_Sigla= source.PrestamoConvenio_Sigla;	
			target.PrestamoConvenio_Numero= source.PrestamoConvenio_Numero;	
			target.PrestamoConvenio_MontoTotal= source.PrestamoConvenio_MontoTotal;	
			target.PrestamoConvenio_MontoPrestamo= source.PrestamoConvenio_MontoPrestamo;	
			target.PrestamoConvenio_IdMoneda= source.PrestamoConvenio_IdMoneda;	
			target.PrestamoConvenio_Observacion= source.PrestamoConvenio_Observacion;	
			target.PrestamoConvenio_IdModalidadFinanciera= source.PrestamoConvenio_IdModalidadFinanciera;	
			target.PrestamoConvenio_DatosModalidadFinanciera= source.PrestamoConvenio_DatosModalidadFinanciera;	
			target.TipoSubConvenio_Nombre= source.TipoSubConvenio_Nombre;	
			target.TipoSubConvenio_Activo= source.TipoSubConvenio_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoSubConvenio source,PrestamoSubConvenio target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoSubConvenio.Equals(target.IdPrestamoSubConvenio))return false;
		  if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdTipoSubConvenio.Equals(target.IdTipoSubConvenio))return false;
		  if((source.Contraparte == null)?target.Contraparte!=null:  !( (target.Contraparte== String.Empty && source.Contraparte== null) || (target.Contraparte==null && source.Contraparte== String.Empty )) &&  !source.Contraparte.Trim().Replace ("\r","").Equals(target.Contraparte.Trim().Replace ("\r","")))return false;
			 if(!source.MontoTotal.Equals(target.MontoTotal))return false;
		  if(!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Ejecutor == null)?target.Ejecutor!=null:  !( (target.Ejecutor== String.Empty && source.Ejecutor== null) || (target.Ejecutor==null && source.Ejecutor== String.Empty )) &&  !source.Ejecutor.Trim().Replace ("\r","").Equals(target.Ejecutor.Trim().Replace ("\r","")))return false;
			 if((source.Observaciones == null)?target.Observaciones!=null:  !( (target.Observaciones== String.Empty && source.Observaciones== null) || (target.Observaciones==null && source.Observaciones== String.Empty )) &&  !source.Observaciones.Trim().Replace ("\r","").Equals(target.Observaciones.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoSubConvenioResult source,PrestamoSubConvenioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoSubConvenio.Equals(target.IdPrestamoSubConvenio))return false;
		  if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdTipoSubConvenio.Equals(target.IdTipoSubConvenio))return false;
		  if((source.Contraparte == null)?target.Contraparte!=null: !( (target.Contraparte== String.Empty && source.Contraparte== null) || (target.Contraparte==null && source.Contraparte== String.Empty )) && !source.Contraparte.Trim().Replace ("\r","").Equals(target.Contraparte.Trim().Replace ("\r","")))return false;
			 if(!source.MontoTotal.Equals(target.MontoTotal))return false;
		  if(!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Ejecutor == null)?target.Ejecutor!=null: !( (target.Ejecutor== String.Empty && source.Ejecutor== null) || (target.Ejecutor==null && source.Ejecutor== String.Empty )) && !source.Ejecutor.Trim().Replace ("\r","").Equals(target.Ejecutor.Trim().Replace ("\r","")))return false;
			 if((source.Observaciones == null)?target.Observaciones!=null: !( (target.Observaciones== String.Empty && source.Observaciones== null) || (target.Observaciones==null && source.Observaciones== String.Empty )) && !source.Observaciones.Trim().Replace ("\r","").Equals(target.Observaciones.Trim().Replace ("\r","")))return false;
			 if(!source.PrestamoConvenio_IdPrestamo.Equals(target.PrestamoConvenio_IdPrestamo))return false;
					  if(!source.PrestamoConvenio_IdOrganismoFinanciero.Equals(target.PrestamoConvenio_IdOrganismoFinanciero))return false;
					  if((source.PrestamoConvenio_Sigla == null)?target.PrestamoConvenio_Sigla!=null: !( (target.PrestamoConvenio_Sigla== String.Empty && source.PrestamoConvenio_Sigla== null) || (target.PrestamoConvenio_Sigla==null && source.PrestamoConvenio_Sigla== String.Empty )) &&   !source.PrestamoConvenio_Sigla.Trim().Replace ("\r","").Equals(target.PrestamoConvenio_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoConvenio_Numero == null)?target.PrestamoConvenio_Numero!=null: !( (target.PrestamoConvenio_Numero== String.Empty && source.PrestamoConvenio_Numero== null) || (target.PrestamoConvenio_Numero==null && source.PrestamoConvenio_Numero== String.Empty )) &&   !source.PrestamoConvenio_Numero.Trim().Replace ("\r","").Equals(target.PrestamoConvenio_Numero.Trim().Replace ("\r","")))return false;
						 if(!source.PrestamoConvenio_MontoTotal.Equals(target.PrestamoConvenio_MontoTotal))return false;
					  if(!source.PrestamoConvenio_MontoPrestamo.Equals(target.PrestamoConvenio_MontoPrestamo))return false;
					  if(!source.PrestamoConvenio_IdMoneda.Equals(target.PrestamoConvenio_IdMoneda))return false;
					  if((source.PrestamoConvenio_Observacion == null)?target.PrestamoConvenio_Observacion!=null: !( (target.PrestamoConvenio_Observacion== String.Empty && source.PrestamoConvenio_Observacion== null) || (target.PrestamoConvenio_Observacion==null && source.PrestamoConvenio_Observacion== String.Empty )) &&   !source.PrestamoConvenio_Observacion.Trim().Replace ("\r","").Equals(target.PrestamoConvenio_Observacion.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoConvenio_IdModalidadFinanciera == null)?(target.PrestamoConvenio_IdModalidadFinanciera.HasValue ):!source.PrestamoConvenio_IdModalidadFinanciera.Equals(target.PrestamoConvenio_IdModalidadFinanciera))return false;
						 if((source.PrestamoConvenio_DatosModalidadFinanciera == null)?target.PrestamoConvenio_DatosModalidadFinanciera!=null: !( (target.PrestamoConvenio_DatosModalidadFinanciera== String.Empty && source.PrestamoConvenio_DatosModalidadFinanciera== null) || (target.PrestamoConvenio_DatosModalidadFinanciera==null && source.PrestamoConvenio_DatosModalidadFinanciera== String.Empty )) &&   !source.PrestamoConvenio_DatosModalidadFinanciera.Trim().Replace ("\r","").Equals(target.PrestamoConvenio_DatosModalidadFinanciera.Trim().Replace ("\r","")))return false;
						 if((source.TipoSubConvenio_Nombre == null)?target.TipoSubConvenio_Nombre!=null: !( (target.TipoSubConvenio_Nombre== String.Empty && source.TipoSubConvenio_Nombre== null) || (target.TipoSubConvenio_Nombre==null && source.TipoSubConvenio_Nombre== String.Empty )) &&   !source.TipoSubConvenio_Nombre.Trim().Replace ("\r","").Equals(target.TipoSubConvenio_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.TipoSubConvenio_Activo.Equals(target.TipoSubConvenio_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
