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
    public abstract class _PrestamoData : EntityData<Prestamo,PrestamoFilter,PrestamoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Prestamo entity)
		{			
			return entity.IdPrestamo;
		}		
		public override Prestamo GetByEntity(Prestamo entity)
        {
            return this.GetById(entity.IdPrestamo);
        }
        public override Prestamo GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Prestamo> Query(PrestamoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma==filter.IdPrograma)
					  && (filter.Numero == null || o.Numero >=  filter.Numero) && (filter.Numero_To == null || o.Numero <= filter.Numero_To)
					  && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%"  || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%",""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%",""))) || o.Denominacion == filter.Denominacion )
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >=  filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
					  && (filter.IdUsuarioModificacion == null || o.IdUsuarioModificacion >=  filter.IdUsuarioModificacion) && (filter.IdUsuarioModificacion_To == null || o.IdUsuarioModificacion <= filter.IdUsuarioModificacion_To)
					  && (filter.IdEstadoActual == null || o.IdEstadoActual >=  filter.IdEstadoActual) && (filter.IdEstadoActual_To == null || o.IdEstadoActual <= filter.IdEstadoActual_To)
					  && (filter.IdEstadoActualIsNull == null || filter.IdEstadoActualIsNull == true || o.IdEstadoActual != null ) && (filter.IdEstadoActualIsNull == null || filter.IdEstadoActualIsNull == false || o.IdEstadoActual == null)
					  && (filter.ResponsablePolitico == null || filter.ResponsablePolitico.Trim() == string.Empty || filter.ResponsablePolitico.Trim() == "%"  || (filter.ResponsablePolitico.EndsWith("%") && filter.ResponsablePolitico.StartsWith("%") && (o.ResponsablePolitico.Contains(filter.ResponsablePolitico.Replace("%", "")))) || (filter.ResponsablePolitico.EndsWith("%") && o.ResponsablePolitico.StartsWith(filter.ResponsablePolitico.Replace("%",""))) || (filter.ResponsablePolitico.StartsWith("%") && o.ResponsablePolitico.EndsWith(filter.ResponsablePolitico.Replace("%",""))) || o.ResponsablePolitico == filter.ResponsablePolitico )
					  && (filter.ResponsableTecnico == null || filter.ResponsableTecnico.Trim() == string.Empty || filter.ResponsableTecnico.Trim() == "%"  || (filter.ResponsableTecnico.EndsWith("%") && filter.ResponsableTecnico.StartsWith("%") && (o.ResponsableTecnico.Contains(filter.ResponsableTecnico.Replace("%", "")))) || (filter.ResponsableTecnico.EndsWith("%") && o.ResponsableTecnico.StartsWith(filter.ResponsableTecnico.Replace("%",""))) || (filter.ResponsableTecnico.StartsWith("%") && o.ResponsableTecnico.EndsWith(filter.ResponsableTecnico.Replace("%",""))) || o.ResponsableTecnico == filter.ResponsableTecnico )
					  && (filter.CodigoVinculacion1 == null || filter.CodigoVinculacion1.Trim() == string.Empty || filter.CodigoVinculacion1.Trim() == "%"  || (filter.CodigoVinculacion1.EndsWith("%") && filter.CodigoVinculacion1.StartsWith("%") && (o.CodigoVinculacion1.Contains(filter.CodigoVinculacion1.Replace("%", "")))) || (filter.CodigoVinculacion1.EndsWith("%") && o.CodigoVinculacion1.StartsWith(filter.CodigoVinculacion1.Replace("%",""))) || (filter.CodigoVinculacion1.StartsWith("%") && o.CodigoVinculacion1.EndsWith(filter.CodigoVinculacion1.Replace("%",""))) || o.CodigoVinculacion1 == filter.CodigoVinculacion1 )
					  && (filter.CodigoVinculacion2 == null || filter.CodigoVinculacion2.Trim() == string.Empty || filter.CodigoVinculacion2.Trim() == "%"  || (filter.CodigoVinculacion2.EndsWith("%") && filter.CodigoVinculacion2.StartsWith("%") && (o.CodigoVinculacion2.Contains(filter.CodigoVinculacion2.Replace("%", "")))) || (filter.CodigoVinculacion2.EndsWith("%") && o.CodigoVinculacion2.StartsWith(filter.CodigoVinculacion2.Replace("%",""))) || (filter.CodigoVinculacion2.StartsWith("%") && o.CodigoVinculacion2.EndsWith(filter.CodigoVinculacion2.Replace("%",""))) || o.CodigoVinculacion2 == filter.CodigoVinculacion2 )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoResult> QueryResult(PrestamoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Programas on o.IdPrograma equals t1.IdPrograma   
				   select new PrestamoResult(){
					 IdPrestamo=o.IdPrestamo
					 ,IdPrograma=o.IdPrograma
					 ,Numero=o.Numero
					 ,Denominacion=o.Denominacion
					 ,Descripcion=o.Descripcion
					 ,Observacion=o.Observacion
					 ,FechaAlta=o.FechaAlta
					 ,FechaModificacion=o.FechaModificacion
					 ,IdUsuarioModificacion=o.IdUsuarioModificacion
					 ,IdEstadoActual=o.IdEstadoActual
					 ,ResponsablePolitico=o.ResponsablePolitico
					 ,ResponsableTecnico=o.ResponsableTecnico
					 ,CodigoVinculacion1=o.CodigoVinculacion1
					 ,CodigoVinculacion2=o.CodigoVinculacion2
					 ,Activo=o.Activo
					,Programa_IdSAF= t1.IdSAF	
						,Programa_Codigo= t1.Codigo	
						,Programa_Nombre= t1.Nombre	
						,Programa_FechaAlta= t1.FechaAlta	
						,Programa_FechaBaja= t1.FechaBaja	
						,Programa_Activo= t1.Activo	
						,Programa_IdSectorialista= t1.IdSectorialista	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Prestamo Copy(nc.Prestamo entity)
        {           
            nc.Prestamo _new = new nc.Prestamo();
		 _new.IdPrograma= entity.IdPrograma;
		 _new.Numero= entity.Numero;
		 _new.Denominacion= entity.Denominacion;
		 _new.Descripcion= entity.Descripcion;
		 _new.Observacion= entity.Observacion;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaModificacion= entity.FechaModificacion;
		 _new.IdUsuarioModificacion= entity.IdUsuarioModificacion;
		 _new.IdEstadoActual= entity.IdEstadoActual;
		 _new.ResponsablePolitico= entity.ResponsablePolitico;
		 _new.ResponsableTecnico= entity.ResponsableTecnico;
		 _new.CodigoVinculacion1= entity.CodigoVinculacion1;
		 _new.CodigoVinculacion2= entity.CodigoVinculacion2;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Prestamo entity,string renameFormat)
        {
            Prestamo  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Prestamo entity, int id)
        {            
            entity.IdPrestamo = id;            
        }
		public override void Set(Prestamo source,Prestamo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Numero= source.Numero ;
		 target.Denominacion= source.Denominacion ;
		 target.Descripcion= source.Descripcion ;
		 target.Observacion= source.Observacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdEstadoActual= source.IdEstadoActual ;
		 target.ResponsablePolitico= source.ResponsablePolitico ;
		 target.ResponsableTecnico= source.ResponsableTecnico ;
		 target.CodigoVinculacion1= source.CodigoVinculacion1 ;
		 target.CodigoVinculacion2= source.CodigoVinculacion2 ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PrestamoResult source,Prestamo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Numero= source.Numero ;
		 target.Denominacion= source.Denominacion ;
		 target.Descripcion= source.Descripcion ;
		 target.Observacion= source.Observacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdEstadoActual= source.IdEstadoActual ;
		 target.ResponsablePolitico= source.ResponsablePolitico ;
		 target.ResponsableTecnico= source.ResponsableTecnico ;
		 target.CodigoVinculacion1= source.CodigoVinculacion1 ;
		 target.CodigoVinculacion2= source.CodigoVinculacion2 ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Prestamo source,PrestamoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Numero= source.Numero ;
		 target.Denominacion= source.Denominacion ;
		 target.Descripcion= source.Descripcion ;
		 target.Observacion= source.Observacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdEstadoActual= source.IdEstadoActual ;
		 target.ResponsablePolitico= source.ResponsablePolitico ;
		 target.ResponsableTecnico= source.ResponsableTecnico ;
		 target.CodigoVinculacion1= source.CodigoVinculacion1 ;
		 target.CodigoVinculacion2= source.CodigoVinculacion2 ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PrestamoResult source,PrestamoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Numero= source.Numero ;
		 target.Denominacion= source.Denominacion ;
		 target.Descripcion= source.Descripcion ;
		 target.Observacion= source.Observacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdEstadoActual= source.IdEstadoActual ;
		 target.ResponsablePolitico= source.ResponsablePolitico ;
		 target.ResponsableTecnico= source.ResponsableTecnico ;
		 target.CodigoVinculacion1= source.CodigoVinculacion1 ;
		 target.CodigoVinculacion2= source.CodigoVinculacion2 ;
		 target.Activo= source.Activo ;
		 target.Programa_IdSAF= source.Programa_IdSAF;	
			target.Programa_Codigo= source.Programa_Codigo;	
			target.Programa_Nombre= source.Programa_Nombre;	
			target.Programa_FechaAlta= source.Programa_FechaAlta;	
			target.Programa_FechaBaja= source.Programa_FechaBaja;	
			target.Programa_Activo= source.Programa_Activo;	
			target.Programa_IdSectorialista= source.Programa_IdSectorialista;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Prestamo source,Prestamo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.Numero.Equals(target.Numero))return false;
		  if((source.Denominacion == null)?target.Denominacion!=null:  !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) &&  !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion))return false;
		  if((source.IdEstadoActual == null)?(target.IdEstadoActual.HasValue):!source.IdEstadoActual.Equals(target.IdEstadoActual))return false;
			 if((source.ResponsablePolitico == null)?target.ResponsablePolitico!=null:  !( (target.ResponsablePolitico== String.Empty && source.ResponsablePolitico== null) || (target.ResponsablePolitico==null && source.ResponsablePolitico== String.Empty )) &&  !source.ResponsablePolitico.Trim().Replace ("\r","").Equals(target.ResponsablePolitico.Trim().Replace ("\r","")))return false;
			 if((source.ResponsableTecnico == null)?target.ResponsableTecnico!=null:  !( (target.ResponsableTecnico== String.Empty && source.ResponsableTecnico== null) || (target.ResponsableTecnico==null && source.ResponsableTecnico== String.Empty )) &&  !source.ResponsableTecnico.Trim().Replace ("\r","").Equals(target.ResponsableTecnico.Trim().Replace ("\r","")))return false;
			 if((source.CodigoVinculacion1 == null)?target.CodigoVinculacion1!=null:  !( (target.CodigoVinculacion1== String.Empty && source.CodigoVinculacion1== null) || (target.CodigoVinculacion1==null && source.CodigoVinculacion1== String.Empty )) &&  !source.CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.CodigoVinculacion1.Trim().Replace ("\r","")))return false;
			 if((source.CodigoVinculacion2 == null)?target.CodigoVinculacion2!=null:  !( (target.CodigoVinculacion2== String.Empty && source.CodigoVinculacion2== null) || (target.CodigoVinculacion2==null && source.CodigoVinculacion2== String.Empty )) &&  !source.CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.CodigoVinculacion2.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoResult source,PrestamoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.Numero.Equals(target.Numero))return false;
		  if((source.Denominacion == null)?target.Denominacion!=null: !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) && !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion))return false;
		  if((source.IdEstadoActual == null)?(target.IdEstadoActual.HasValue):!source.IdEstadoActual.Equals(target.IdEstadoActual))return false;
			 if((source.ResponsablePolitico == null)?target.ResponsablePolitico!=null: !( (target.ResponsablePolitico== String.Empty && source.ResponsablePolitico== null) || (target.ResponsablePolitico==null && source.ResponsablePolitico== String.Empty )) && !source.ResponsablePolitico.Trim().Replace ("\r","").Equals(target.ResponsablePolitico.Trim().Replace ("\r","")))return false;
			 if((source.ResponsableTecnico == null)?target.ResponsableTecnico!=null: !( (target.ResponsableTecnico== String.Empty && source.ResponsableTecnico== null) || (target.ResponsableTecnico==null && source.ResponsableTecnico== String.Empty )) && !source.ResponsableTecnico.Trim().Replace ("\r","").Equals(target.ResponsableTecnico.Trim().Replace ("\r","")))return false;
			 if((source.CodigoVinculacion1 == null)?target.CodigoVinculacion1!=null: !( (target.CodigoVinculacion1== String.Empty && source.CodigoVinculacion1== null) || (target.CodigoVinculacion1==null && source.CodigoVinculacion1== String.Empty )) && !source.CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.CodigoVinculacion1.Trim().Replace ("\r","")))return false;
			 if((source.CodigoVinculacion2 == null)?target.CodigoVinculacion2!=null: !( (target.CodigoVinculacion2== String.Empty && source.CodigoVinculacion2== null) || (target.CodigoVinculacion2==null && source.CodigoVinculacion2== String.Empty )) && !source.CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.CodigoVinculacion2.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.Programa_IdSAF.Equals(target.Programa_IdSAF))return false;
					  if((source.Programa_Codigo == null)?target.Programa_Codigo!=null: !( (target.Programa_Codigo== String.Empty && source.Programa_Codigo== null) || (target.Programa_Codigo==null && source.Programa_Codigo== String.Empty )) &&   !source.Programa_Codigo.Trim().Replace ("\r","").Equals(target.Programa_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Programa_Nombre == null)?target.Programa_Nombre!=null: !( (target.Programa_Nombre== String.Empty && source.Programa_Nombre== null) || (target.Programa_Nombre==null && source.Programa_Nombre== String.Empty )) &&   !source.Programa_Nombre.Trim().Replace ("\r","").Equals(target.Programa_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Programa_FechaAlta.Equals(target.Programa_FechaAlta))return false;
					  if((source.Programa_FechaBaja == null)?(target.Programa_FechaBaja.HasValue ):!source.Programa_FechaBaja.Equals(target.Programa_FechaBaja))return false;
						 if(!source.Programa_Activo.Equals(target.Programa_Activo))return false;
					  if((source.Programa_IdSectorialista == null)?(target.Programa_IdSectorialista.HasValue && target.Programa_IdSectorialista.Value > 0):!source.Programa_IdSectorialista.Equals(target.Programa_IdSectorialista))return false;
									 		
		  return true;
        }
		#endregion
    }
}
