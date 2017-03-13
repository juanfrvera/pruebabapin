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
    public abstract class _PrestamoFinalidadFuncionData : EntityData<PrestamoFinalidadFuncion,PrestamoFinalidadFuncionFilter,PrestamoFinalidadFuncionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoFinalidadFuncion entity)
		{			
			return entity.IdPrestamoFinalidadFuncion;
		}		
		public override PrestamoFinalidadFuncion GetByEntity(PrestamoFinalidadFuncion entity)
        {
            return this.GetById(entity.IdPrestamoFinalidadFuncion);
        }
        public override PrestamoFinalidadFuncion GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoFinalidadFuncion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoFinalidadFuncion> Query(PrestamoFinalidadFuncionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoFinalidadFuncion == null || o.IdPrestamoFinalidadFuncion >=  filter.IdPrestamoFinalidadFuncion) && (filter.IdPrestamoFinalidadFuncion_To == null || o.IdPrestamoFinalidadFuncion <= filter.IdPrestamoFinalidadFuncion_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || o.IdFinalidadFuncion==filter.IdFinalidadFuncion)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoFinalidadFuncionResult> QueryResult(PrestamoFinalidadFuncionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals t1.IdFinalidadFuncion   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoFinalidadFuncionResult(){
					 IdPrestamoFinalidadFuncion=o.IdPrestamoFinalidadFuncion
					 ,IdPrestamo=o.IdPrestamo
					 ,IdFinalidadFuncion=o.IdFinalidadFuncion
					,FinalidadFuncion_Codigo= t1.Codigo	
						,FinalidadFuncion_Denominacion= t1.Denominacion	
						,FinalidadFuncion_Activo= t1.Activo	
						,FinalidadFuncion_IdFinalidadFunciontipo= t1.IdFinalidadFunciontipo	
						,FinalidadFuncion_IdFinalidadFuncionPadre= t1.IdFinalidadFuncionPadre	
						,FinalidadFuncion_BreadcrumbId= t1.BreadcrumbId	
						,FinalidadFuncion_BreadcrumbOrden= t1.BreadcrumbOrden	
						,FinalidadFuncion_Nivel= t1.Nivel	
						,FinalidadFuncion_Orden= t1.Orden	
						,FinalidadFuncion_Descripcion= t1.Descripcion	
						,FinalidadFuncion_DescripcionInvertida= t1.DescripcionInvertida	
						,FinalidadFuncion_Seleccionable= t1.Seleccionable	
						,FinalidadFuncion_BreadcrumbCode= t1.BreadcrumbCode	
						,FinalidadFuncion_DescripcionCodigo= t1.DescripcionCodigo	
                        //,Prestamo_IdPrograma= t2.IdPrograma	
                        //,Prestamo_Numero= t2.Numero	
                        //,Prestamo_Denominacion= t2.Denominacion	
                        //,Prestamo_Descripcion= t2.Descripcion	
                        //,Prestamo_Observacion= t2.Observacion	
                        //,Prestamo_FechaAlta= t2.FechaAlta	
                        //,Prestamo_FechaModificacion= t2.FechaModificacion	
                        //,Prestamo_IdUsuarioModificacion= t2.IdUsuarioModificacion	
                        //,Prestamo_IdEstadoActual= t2.IdEstadoActual	
                        //,Prestamo_ResponsablePolitico= t2.ResponsablePolitico	
                        //,Prestamo_ResponsableTecnico= t2.ResponsableTecnico	
                        //,Prestamo_CodigoVinculacion1= t2.CodigoVinculacion1	
                        //,Prestamo_CodigoVinculacion2= t2.CodigoVinculacion2	
                        //,Prestamo_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoFinalidadFuncion Copy(nc.PrestamoFinalidadFuncion entity)
        {           
            nc.PrestamoFinalidadFuncion _new = new nc.PrestamoFinalidadFuncion();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdFinalidadFuncion= entity.IdFinalidadFuncion;
		return _new;			
        }
		public override int CopyAndSave(PrestamoFinalidadFuncion entity,string renameFormat)
        {
            PrestamoFinalidadFuncion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoFinalidadFuncion entity, int id)
        {            
            entity.IdPrestamoFinalidadFuncion = id;            
        }
		public override void Set(PrestamoFinalidadFuncion source,PrestamoFinalidadFuncion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinalidadFuncion= source.IdPrestamoFinalidadFuncion ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 		  
		}
		public override void Set(PrestamoFinalidadFuncionResult source,PrestamoFinalidadFuncion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinalidadFuncion= source.IdPrestamoFinalidadFuncion ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 
		}
		public override void Set(PrestamoFinalidadFuncion source,PrestamoFinalidadFuncionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinalidadFuncion= source.IdPrestamoFinalidadFuncion ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 	
		}		
		public override void Set(PrestamoFinalidadFuncionResult source,PrestamoFinalidadFuncionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinalidadFuncion= source.IdPrestamoFinalidadFuncion ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.FinalidadFuncion_Codigo= source.FinalidadFuncion_Codigo;	
			target.FinalidadFuncion_Denominacion= source.FinalidadFuncion_Denominacion;	
			target.FinalidadFuncion_Activo= source.FinalidadFuncion_Activo;	
			target.FinalidadFuncion_IdFinalidadFunciontipo= source.FinalidadFuncion_IdFinalidadFunciontipo;	
			target.FinalidadFuncion_IdFinalidadFuncionPadre= source.FinalidadFuncion_IdFinalidadFuncionPadre;	
			target.FinalidadFuncion_BreadcrumbId= source.FinalidadFuncion_BreadcrumbId;	
			target.FinalidadFuncion_BreadcrumbOrden= source.FinalidadFuncion_BreadcrumbOrden;	
			target.FinalidadFuncion_Nivel= source.FinalidadFuncion_Nivel;	
			target.FinalidadFuncion_Orden= source.FinalidadFuncion_Orden;	
			target.FinalidadFuncion_Descripcion= source.FinalidadFuncion_Descripcion;	
			target.FinalidadFuncion_DescripcionInvertida= source.FinalidadFuncion_DescripcionInvertida;	
			target.FinalidadFuncion_Seleccionable= source.FinalidadFuncion_Seleccionable;	
			target.FinalidadFuncion_BreadcrumbCode= source.FinalidadFuncion_BreadcrumbCode;	
			target.FinalidadFuncion_DescripcionCodigo= source.FinalidadFuncion_DescripcionCodigo;	
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
		public override bool Equals(PrestamoFinalidadFuncion source,PrestamoFinalidadFuncion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFinalidadFuncion.Equals(target.IdPrestamoFinalidadFuncion))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoFinalidadFuncionResult source,PrestamoFinalidadFuncionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFinalidadFuncion.Equals(target.IdPrestamoFinalidadFuncion))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		  if((source.FinalidadFuncion_Codigo == null)?target.FinalidadFuncion_Codigo!=null: !( (target.FinalidadFuncion_Codigo== String.Empty && source.FinalidadFuncion_Codigo== null) || (target.FinalidadFuncion_Codigo==null && source.FinalidadFuncion_Codigo== String.Empty )) &&   !source.FinalidadFuncion_Codigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_Denominacion == null)?target.FinalidadFuncion_Denominacion!=null: !( (target.FinalidadFuncion_Denominacion== String.Empty && source.FinalidadFuncion_Denominacion== null) || (target.FinalidadFuncion_Denominacion==null && source.FinalidadFuncion_Denominacion== String.Empty )) &&   !source.FinalidadFuncion_Denominacion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncion_Activo.Equals(target.FinalidadFuncion_Activo))return false;
					  if((source.FinalidadFuncion_IdFinalidadFunciontipo == null)?(target.FinalidadFuncion_IdFinalidadFunciontipo.HasValue && target.FinalidadFuncion_IdFinalidadFunciontipo.Value > 0):!source.FinalidadFuncion_IdFinalidadFunciontipo.Equals(target.FinalidadFuncion_IdFinalidadFunciontipo))return false;
									  if((source.FinalidadFuncion_IdFinalidadFuncionPadre == null)?(target.FinalidadFuncion_IdFinalidadFuncionPadre.HasValue && target.FinalidadFuncion_IdFinalidadFuncionPadre.Value > 0):!source.FinalidadFuncion_IdFinalidadFuncionPadre.Equals(target.FinalidadFuncion_IdFinalidadFuncionPadre))return false;
									  if((source.FinalidadFuncion_BreadcrumbId == null)?target.FinalidadFuncion_BreadcrumbId!=null: !( (target.FinalidadFuncion_BreadcrumbId== String.Empty && source.FinalidadFuncion_BreadcrumbId== null) || (target.FinalidadFuncion_BreadcrumbId==null && source.FinalidadFuncion_BreadcrumbId== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_BreadcrumbOrden == null)?target.FinalidadFuncion_BreadcrumbOrden!=null: !( (target.FinalidadFuncion_BreadcrumbOrden== String.Empty && source.FinalidadFuncion_BreadcrumbOrden== null) || (target.FinalidadFuncion_BreadcrumbOrden==null && source.FinalidadFuncion_BreadcrumbOrden== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_Nivel == null)?(target.FinalidadFuncion_Nivel.HasValue ):!source.FinalidadFuncion_Nivel.Equals(target.FinalidadFuncion_Nivel))return false;
						 if((source.FinalidadFuncion_Orden == null)?(target.FinalidadFuncion_Orden.HasValue ):!source.FinalidadFuncion_Orden.Equals(target.FinalidadFuncion_Orden))return false;
						 if((source.FinalidadFuncion_Descripcion == null)?target.FinalidadFuncion_Descripcion!=null: !( (target.FinalidadFuncion_Descripcion== String.Empty && source.FinalidadFuncion_Descripcion== null) || (target.FinalidadFuncion_Descripcion==null && source.FinalidadFuncion_Descripcion== String.Empty )) &&   !source.FinalidadFuncion_Descripcion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_DescripcionInvertida == null)?target.FinalidadFuncion_DescripcionInvertida!=null: !( (target.FinalidadFuncion_DescripcionInvertida== String.Empty && source.FinalidadFuncion_DescripcionInvertida== null) || (target.FinalidadFuncion_DescripcionInvertida==null && source.FinalidadFuncion_DescripcionInvertida== String.Empty )) &&   !source.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncion_Seleccionable.Equals(target.FinalidadFuncion_Seleccionable))return false;
					  if((source.FinalidadFuncion_BreadcrumbCode == null)?target.FinalidadFuncion_BreadcrumbCode!=null: !( (target.FinalidadFuncion_BreadcrumbCode== String.Empty && source.FinalidadFuncion_BreadcrumbCode== null) || (target.FinalidadFuncion_BreadcrumbCode==null && source.FinalidadFuncion_BreadcrumbCode== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_DescripcionCodigo == null)?target.FinalidadFuncion_DescripcionCodigo!=null: !( (target.FinalidadFuncion_DescripcionCodigo== String.Empty && source.FinalidadFuncion_DescripcionCodigo== null) || (target.FinalidadFuncion_DescripcionCodigo==null && source.FinalidadFuncion_DescripcionCodigo== String.Empty )) &&   !source.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
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
