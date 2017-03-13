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
    public abstract class _PrestamoAlcanceGeograficoData : EntityData<PrestamoAlcanceGeografico,PrestamoAlcanceGeograficoFilter,PrestamoAlcanceGeograficoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoAlcanceGeografico entity)
		{			
			return entity.IdPrestamoAlcanceGeografico;
		}		
		public override PrestamoAlcanceGeografico GetByEntity(PrestamoAlcanceGeografico entity)
        {
            return this.GetById(entity.IdPrestamoAlcanceGeografico);
        }
        public override PrestamoAlcanceGeografico GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoAlcanceGeografico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoAlcanceGeografico> Query(PrestamoAlcanceGeograficoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoAlcanceGeografico == null || o.IdPrestamoAlcanceGeografico >=  filter.IdPrestamoAlcanceGeografico) && (filter.IdPrestamoAlcanceGeografico_To == null || o.IdPrestamoAlcanceGeografico <= filter.IdPrestamoAlcanceGeografico_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoAlcanceGeograficoResult> QueryResult(PrestamoAlcanceGeograficoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t1.IdClasificacionGeografica   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoAlcanceGeograficoResult(){
					 IdPrestamoAlcanceGeografico=o.IdPrestamoAlcanceGeografico
					 ,IdPrestamo=o.IdPrestamo
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
					,ClasificacionGeografica_Codigo= t1.Codigo	
						,ClasificacionGeografica_Nombre= t1.Nombre	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t1.IdClasificacionGeograficaPadre	
						,ClasificacionGeografica_Activo= t1.Activo	
						,ClasificacionGeografica_Descripcion= t1.Descripcion	
						,ClasificacionGeografica_BreadcrumbId= t1.BreadcrumbId	
						,ClasificacionGeografica_BreadcrumOrden= t1.BreadcrumOrden	
						,ClasificacionGeografica_Orden= t1.Orden	
						,ClasificacionGeografica_Nivel= t1.Nivel	
						,ClasificacionGeografica_DescripcionInvertida= t1.DescripcionInvertida	
						,ClasificacionGeografica_Seleccionable= t1.Seleccionable	
						,ClasificacionGeografica_BreadcrumbCode= t1.BreadcrumbCode	
						,ClasificacionGeografica_DescripcionCodigo= t1.DescripcionCodigo	
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
		public override nc.PrestamoAlcanceGeografico Copy(nc.PrestamoAlcanceGeografico entity)
        {           
            nc.PrestamoAlcanceGeografico _new = new nc.PrestamoAlcanceGeografico();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		return _new;			
        }
		public override int CopyAndSave(PrestamoAlcanceGeografico entity,string renameFormat)
        {
            PrestamoAlcanceGeografico  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoAlcanceGeografico entity, int id)
        {            
            entity.IdPrestamoAlcanceGeografico = id;            
        }
		public override void Set(PrestamoAlcanceGeografico source,PrestamoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoAlcanceGeografico= source.IdPrestamoAlcanceGeografico ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 		  
		}
		public override void Set(PrestamoAlcanceGeograficoResult source,PrestamoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoAlcanceGeografico= source.IdPrestamoAlcanceGeografico ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 
		}
		public override void Set(PrestamoAlcanceGeografico source,PrestamoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoAlcanceGeografico= source.IdPrestamoAlcanceGeografico ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 	
		}		
		public override void Set(PrestamoAlcanceGeograficoResult source,PrestamoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoAlcanceGeografico= source.IdPrestamoAlcanceGeografico ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.ClasificacionGeografica_Codigo= source.ClasificacionGeografica_Codigo;	
			target.ClasificacionGeografica_Nombre= source.ClasificacionGeografica_Nombre;	
			target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
			target.ClasificacionGeografica_IdClasificacionGeograficaPadre= source.ClasificacionGeografica_IdClasificacionGeograficaPadre;	
			target.ClasificacionGeografica_Activo= source.ClasificacionGeografica_Activo;	
			target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
			target.ClasificacionGeografica_BreadcrumbId= source.ClasificacionGeografica_BreadcrumbId;	
			target.ClasificacionGeografica_BreadcrumOrden= source.ClasificacionGeografica_BreadcrumOrden;	
			target.ClasificacionGeografica_Orden= source.ClasificacionGeografica_Orden;	
			target.ClasificacionGeografica_Nivel= source.ClasificacionGeografica_Nivel;	
			target.ClasificacionGeografica_DescripcionInvertida= source.ClasificacionGeografica_DescripcionInvertida;	
			target.ClasificacionGeografica_Seleccionable= source.ClasificacionGeografica_Seleccionable;	
			target.ClasificacionGeografica_BreadcrumbCode= source.ClasificacionGeografica_BreadcrumbCode;	
			target.ClasificacionGeografica_DescripcionCodigo= source.ClasificacionGeografica_DescripcionCodigo;	
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
		public override bool Equals(PrestamoAlcanceGeografico source,PrestamoAlcanceGeografico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoAlcanceGeografico.Equals(target.IdPrestamoAlcanceGeografico))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoAlcanceGeograficoResult source,PrestamoAlcanceGeograficoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoAlcanceGeografico.Equals(target.IdPrestamoAlcanceGeografico))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if((source.ClasificacionGeografica_Codigo == null)?target.ClasificacionGeografica_Codigo!=null: !( (target.ClasificacionGeografica_Codigo== String.Empty && source.ClasificacionGeografica_Codigo== null) || (target.ClasificacionGeografica_Codigo==null && source.ClasificacionGeografica_Codigo== String.Empty )) &&   !source.ClasificacionGeografica_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Nombre == null)?target.ClasificacionGeografica_Nombre!=null: !( (target.ClasificacionGeografica_Nombre== String.Empty && source.ClasificacionGeografica_Nombre== null) || (target.ClasificacionGeografica_Nombre==null && source.ClasificacionGeografica_Nombre== String.Empty )) &&   !source.ClasificacionGeografica_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
					  if((source.ClasificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.ClasificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.ClasificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.ClasificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaPadre))return false;
									  if(!source.ClasificacionGeografica_Activo.Equals(target.ClasificacionGeografica_Activo))return false;
					  if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null: !( (target.ClasificacionGeografica_Descripcion== String.Empty && source.ClasificacionGeografica_Descripcion== null) || (target.ClasificacionGeografica_Descripcion==null && source.ClasificacionGeografica_Descripcion== String.Empty )) &&   !source.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumbId == null)?target.ClasificacionGeografica_BreadcrumbId!=null: !( (target.ClasificacionGeografica_BreadcrumbId== String.Empty && source.ClasificacionGeografica_BreadcrumbId== null) || (target.ClasificacionGeografica_BreadcrumbId==null && source.ClasificacionGeografica_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumOrden == null)?target.ClasificacionGeografica_BreadcrumOrden!=null: !( (target.ClasificacionGeografica_BreadcrumOrden== String.Empty && source.ClasificacionGeografica_BreadcrumOrden== null) || (target.ClasificacionGeografica_BreadcrumOrden==null && source.ClasificacionGeografica_BreadcrumOrden== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Orden == null)?(target.ClasificacionGeografica_Orden.HasValue ):!source.ClasificacionGeografica_Orden.Equals(target.ClasificacionGeografica_Orden))return false;
						 if((source.ClasificacionGeografica_Nivel == null)?(target.ClasificacionGeografica_Nivel.HasValue ):!source.ClasificacionGeografica_Nivel.Equals(target.ClasificacionGeografica_Nivel))return false;
						 if((source.ClasificacionGeografica_DescripcionInvertida == null)?target.ClasificacionGeografica_DescripcionInvertida!=null: !( (target.ClasificacionGeografica_DescripcionInvertida== String.Empty && source.ClasificacionGeografica_DescripcionInvertida== null) || (target.ClasificacionGeografica_DescripcionInvertida==null && source.ClasificacionGeografica_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_Seleccionable.Equals(target.ClasificacionGeografica_Seleccionable))return false;
					  if((source.ClasificacionGeografica_BreadcrumbCode == null)?target.ClasificacionGeografica_BreadcrumbCode!=null: !( (target.ClasificacionGeografica_BreadcrumbCode== String.Empty && source.ClasificacionGeografica_BreadcrumbCode== null) || (target.ClasificacionGeografica_BreadcrumbCode==null && source.ClasificacionGeografica_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_DescripcionCodigo == null)?target.ClasificacionGeografica_DescripcionCodigo!=null: !( (target.ClasificacionGeografica_DescripcionCodigo== String.Empty && source.ClasificacionGeografica_DescripcionCodigo== null) || (target.ClasificacionGeografica_DescripcionCodigo==null && source.ClasificacionGeografica_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","")))return false;
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
