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
    public abstract class _PrestamoConvenioData : EntityData<PrestamoConvenio,PrestamoConvenioFilter,PrestamoConvenioResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoConvenio entity)
		{			
			return entity.IdPrestamoConvenio;
		}		
		public override PrestamoConvenio GetByEntity(PrestamoConvenio entity)
        {
            return this.GetById(entity.IdPrestamoConvenio);
        }
        public override PrestamoConvenio GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoConvenio == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoConvenio> Query(PrestamoConvenioFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoConvenio == null || filter.IdPrestamoConvenio == 0 || o.IdPrestamoConvenio==filter.IdPrestamoConvenio)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdOrganismoFinanciero == null || filter.IdOrganismoFinanciero == 0 || o.IdOrganismoFinanciero==filter.IdOrganismoFinanciero)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Numero == null || filter.Numero.Trim() == string.Empty || filter.Numero.Trim() == "%"  || (filter.Numero.EndsWith("%") && filter.Numero.StartsWith("%") && (o.Numero.Contains(filter.Numero.Replace("%", "")))) || (filter.Numero.EndsWith("%") && o.Numero.StartsWith(filter.Numero.Replace("%",""))) || (filter.Numero.StartsWith("%") && o.Numero.EndsWith(filter.Numero.Replace("%",""))) || o.Numero == filter.Numero )
					  && (filter.MontoTotal == null || o.MontoTotal >=  filter.MontoTotal) && (filter.MontoTotal_To == null || o.MontoTotal <= filter.MontoTotal_To)
					  && (filter.MontoPrestamo == null || o.MontoPrestamo >=  filter.MontoPrestamo) && (filter.MontoPrestamo_To == null || o.MontoPrestamo <= filter.MontoPrestamo_To)
					  && (filter.IdMoneda == null || filter.IdMoneda == 0 || o.IdMoneda==filter.IdMoneda)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.IdModalidadFinanciera == null || o.IdModalidadFinanciera >=  filter.IdModalidadFinanciera) && (filter.IdModalidadFinanciera_To == null || o.IdModalidadFinanciera <= filter.IdModalidadFinanciera_To)
					  && (filter.IdModalidadFinancieraIsNull == null || filter.IdModalidadFinancieraIsNull == true || o.IdModalidadFinanciera != null ) && (filter.IdModalidadFinancieraIsNull == null || filter.IdModalidadFinancieraIsNull == false || o.IdModalidadFinanciera == null)
					  && (filter.DatosModalidadFinanciera == null || filter.DatosModalidadFinanciera.Trim() == string.Empty || filter.DatosModalidadFinanciera.Trim() == "%"  || (filter.DatosModalidadFinanciera.EndsWith("%") && filter.DatosModalidadFinanciera.StartsWith("%") && (o.DatosModalidadFinanciera.Contains(filter.DatosModalidadFinanciera.Replace("%", "")))) || (filter.DatosModalidadFinanciera.EndsWith("%") && o.DatosModalidadFinanciera.StartsWith(filter.DatosModalidadFinanciera.Replace("%",""))) || (filter.DatosModalidadFinanciera.StartsWith("%") && o.DatosModalidadFinanciera.EndsWith(filter.DatosModalidadFinanciera.Replace("%",""))) || o.DatosModalidadFinanciera == filter.DatosModalidadFinanciera )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoConvenioResult> QueryResult(PrestamoConvenioFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Monedas on o.IdMoneda equals t1.IdMoneda   
				    join t2  in this.Context.OrganismoFinancieros on o.IdOrganismoFinanciero equals t2.IdOrganismoFinanciero   
				    join t3  in this.Context.Prestamos on o.IdPrestamo equals t3.IdPrestamo   
				   select new PrestamoConvenioResult(){
					 IdPrestamoConvenio=o.IdPrestamoConvenio
					 ,IdPrestamo=o.IdPrestamo
					 ,IdOrganismoFinanciero=o.IdOrganismoFinanciero
					 ,Sigla=o.Sigla
					 ,Numero=o.Numero
					 ,MontoTotal=o.MontoTotal
					 ,MontoPrestamo=o.MontoPrestamo
					 ,IdMoneda=o.IdMoneda
					 ,Observacion=o.Observacion
					 ,IdModalidadFinanciera=o.IdModalidadFinanciera
					 ,DatosModalidadFinanciera=o.DatosModalidadFinanciera
					,Moneda_Sigla= t1.Sigla	
						,Moneda_Nombre= t1.Nombre	
						,Moneda_Activo= t1.Activo	
						,Moneda_Base= t1.Base	
						,OrganismoFinanciero_Sigla= t2.Sigla	
						,OrganismoFinanciero_Nombre= t2.Nombre	
						,OrganismoFinanciero_Activo= t2.Activo	
                        //,Prestamo_IdPrograma= t3.IdPrograma	
                        //,Prestamo_Numero= t3.Numero	
                        //,Prestamo_Denominacion= t3.Denominacion	
                        //,Prestamo_Descripcion= t3.Descripcion	
                        //,Prestamo_Observacion= t3.Observacion	
                        //,Prestamo_FechaAlta= t3.FechaAlta	
                        //,Prestamo_FechaModificacion= t3.FechaModificacion	
                        //,Prestamo_IdUsuarioModificacion= t3.IdUsuarioModificacion	
                        //,Prestamo_IdEstadoActual= t3.IdEstadoActual	
                        //,Prestamo_ResponsablePolitico= t3.ResponsablePolitico	
                        //,Prestamo_ResponsableTecnico= t3.ResponsableTecnico	
                        //,Prestamo_CodigoVinculacion1= t3.CodigoVinculacion1	
                        //,Prestamo_CodigoVinculacion2= t3.CodigoVinculacion2	
                        //,Prestamo_Activo= t3.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoConvenio Copy(nc.PrestamoConvenio entity)
        {           
            nc.PrestamoConvenio _new = new nc.PrestamoConvenio();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdOrganismoFinanciero= entity.IdOrganismoFinanciero;
		 _new.Sigla= entity.Sigla;
		 _new.Numero= entity.Numero;
		 _new.MontoTotal= entity.MontoTotal;
		 _new.MontoPrestamo= entity.MontoPrestamo;
		 _new.IdMoneda= entity.IdMoneda;
		 _new.Observacion= entity.Observacion;
		 _new.IdModalidadFinanciera= entity.IdModalidadFinanciera;
		 _new.DatosModalidadFinanciera= entity.DatosModalidadFinanciera;
		return _new;			
        }
		public override int CopyAndSave(PrestamoConvenio entity,string renameFormat)
        {
            PrestamoConvenio  newEntity = Copy(entity);
            newEntity.Sigla = string.Format(renameFormat,newEntity.Sigla);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoConvenio entity, int id)
        {            
            entity.IdPrestamoConvenio = id;            
        }
		public override void Set(PrestamoConvenio source,PrestamoConvenio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Numero= source.Numero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Observacion= source.Observacion ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.DatosModalidadFinanciera= source.DatosModalidadFinanciera ;
		 		  
		}
		public override void Set(PrestamoConvenioResult source,PrestamoConvenio target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Numero= source.Numero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Observacion= source.Observacion ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.DatosModalidadFinanciera= source.DatosModalidadFinanciera ;
		 
		}
		public override void Set(PrestamoConvenio source,PrestamoConvenioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Numero= source.Numero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Observacion= source.Observacion ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.DatosModalidadFinanciera= source.DatosModalidadFinanciera ;
		 	
		}		
		public override void Set(PrestamoConvenioResult source,PrestamoConvenioResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Numero= source.Numero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Observacion= source.Observacion ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.DatosModalidadFinanciera= source.DatosModalidadFinanciera ;
		 target.Moneda_Sigla= source.Moneda_Sigla;	
			target.Moneda_Nombre= source.Moneda_Nombre;	
			target.Moneda_Activo= source.Moneda_Activo;	
			target.Moneda_Base= source.Moneda_Base;	
			target.OrganismoFinanciero_Sigla= source.OrganismoFinanciero_Sigla;	
			target.OrganismoFinanciero_Nombre= source.OrganismoFinanciero_Nombre;	
			target.OrganismoFinanciero_Activo= source.OrganismoFinanciero_Activo;	
            //target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
            //target.Prestamo_Numero= source.Prestamo_Numero;	
            //target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
            //target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
            //target.Prestamo_Observacion= source.Prestamo_Observacion;	
            //target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
            //target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
            //target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
            //target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
            //target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
            //target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
            //target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
            //target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
            //target.Prestamo_Activo= source.Prestamo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoConvenio source,PrestamoConvenio target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Numero == null)?target.Numero!=null:  !( (target.Numero== String.Empty && source.Numero== null) || (target.Numero==null && source.Numero== String.Empty )) &&  !source.Numero.Trim().Replace ("\r","").Equals(target.Numero.Trim().Replace ("\r","")))return false;
			 if(!source.MontoTotal.Equals(target.MontoTotal))return false;
		  if(!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.IdModalidadFinanciera == null)?(target.IdModalidadFinanciera.HasValue):!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
			 if((source.DatosModalidadFinanciera == null)?target.DatosModalidadFinanciera!=null:  !( (target.DatosModalidadFinanciera== String.Empty && source.DatosModalidadFinanciera== null) || (target.DatosModalidadFinanciera==null && source.DatosModalidadFinanciera== String.Empty )) &&  !source.DatosModalidadFinanciera.Trim().Replace ("\r","").Equals(target.DatosModalidadFinanciera.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoConvenioResult source,PrestamoConvenioResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Numero == null)?target.Numero!=null: !( (target.Numero== String.Empty && source.Numero== null) || (target.Numero==null && source.Numero== String.Empty )) && !source.Numero.Trim().Replace ("\r","").Equals(target.Numero.Trim().Replace ("\r","")))return false;
			 if(!source.MontoTotal.Equals(target.MontoTotal))return false;
		  if(!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.IdModalidadFinanciera == null)?(target.IdModalidadFinanciera.HasValue):!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
			 if((source.DatosModalidadFinanciera == null)?target.DatosModalidadFinanciera!=null: !( (target.DatosModalidadFinanciera== String.Empty && source.DatosModalidadFinanciera== null) || (target.DatosModalidadFinanciera==null && source.DatosModalidadFinanciera== String.Empty )) && !source.DatosModalidadFinanciera.Trim().Replace ("\r","").Equals(target.DatosModalidadFinanciera.Trim().Replace ("\r","")))return false;
			 if((source.Moneda_Sigla == null)?target.Moneda_Sigla!=null: !( (target.Moneda_Sigla== String.Empty && source.Moneda_Sigla== null) || (target.Moneda_Sigla==null && source.Moneda_Sigla== String.Empty )) &&   !source.Moneda_Sigla.Trim().Replace ("\r","").Equals(target.Moneda_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.Moneda_Nombre == null)?target.Moneda_Nombre!=null: !( (target.Moneda_Nombre== String.Empty && source.Moneda_Nombre== null) || (target.Moneda_Nombre==null && source.Moneda_Nombre== String.Empty )) &&   !source.Moneda_Nombre.Trim().Replace ("\r","").Equals(target.Moneda_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Moneda_Activo.Equals(target.Moneda_Activo))return false;
					  if(!source.Moneda_Base.Equals(target.Moneda_Base))return false;
					  if((source.OrganismoFinanciero_Sigla == null)?target.OrganismoFinanciero_Sigla!=null: !( (target.OrganismoFinanciero_Sigla== String.Empty && source.OrganismoFinanciero_Sigla== null) || (target.OrganismoFinanciero_Sigla==null && source.OrganismoFinanciero_Sigla== String.Empty )) &&   !source.OrganismoFinanciero_Sigla.Trim().Replace ("\r","").Equals(target.OrganismoFinanciero_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.OrganismoFinanciero_Nombre == null)?target.OrganismoFinanciero_Nombre!=null: !( (target.OrganismoFinanciero_Nombre== String.Empty && source.OrganismoFinanciero_Nombre== null) || (target.OrganismoFinanciero_Nombre==null && source.OrganismoFinanciero_Nombre== String.Empty )) &&   !source.OrganismoFinanciero_Nombre.Trim().Replace ("\r","").Equals(target.OrganismoFinanciero_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.OrganismoFinanciero_Activo.Equals(target.OrganismoFinanciero_Activo))return false;
                      //if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
                      //if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
                      //if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
                      //if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
                      //if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
                      //if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
                      //   if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
