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
    public abstract class _ProyectoSeguimientoEstadoData : EntityData<ProyectoSeguimientoEstado,ProyectoSeguimientoEstadoFilter,ProyectoSeguimientoEstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoSeguimientoEstado entity)
		{			
			return entity.IdProyectoSeguimientoEstado;
		}		
		public override ProyectoSeguimientoEstado GetByEntity(ProyectoSeguimientoEstado entity)
        {
            return this.GetById(entity.IdProyectoSeguimientoEstado);
        }
        public override ProyectoSeguimientoEstado GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoSeguimientoEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoSeguimientoEstado> Query(ProyectoSeguimientoEstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoSeguimientoEstado == null || filter.IdProyectoSeguimientoEstado == 0 || o.IdProyectoSeguimientoEstado==filter.IdProyectoSeguimientoEstado)
					  && (filter.IdProyectoSeguimiento == null || filter.IdProyectoSeguimiento == 0 || o.IdProyectoSeguimiento==filter.IdProyectoSeguimiento)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoSeguimientoEstadoResult> QueryResult(ProyectoSeguimientoEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario   
				   select new ProyectoSeguimientoEstadoResult(){
					 IdProyectoSeguimientoEstado=o.IdProyectoSeguimientoEstado
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
					 ,IdEstado=o.IdEstado
					 ,Fecha=o.Fecha
					 ,Observacion=o.Observacion
                     ,GeneraComentarioTecnico = o.GeneraComentarioTecnico
					 ,IdUsuario=o.IdUsuario
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,ProyectoSeguimiento_IdSaf= t2.IdSaf	
						,ProyectoSeguimiento_Denominacion= t2.Denominacion	
						,ProyectoSeguimiento_Ruta= t2.Ruta	
						,ProyectoSeguimiento_Malla= t2.Malla	
						,ProyectoSeguimiento_IdAnalista= t2.IdAnalista	
						,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= t2.IdProyectoSeguimientoAnterior	
						,ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= t2.IdProyectoSeguimientoEstadoUltimo	
						,Usuario_NombreUsuario= t3.NombreUsuario	
						,Usuario_Clave= t3.Clave	
						,Usuario_Activo= t3.Activo	
						,Usuario_EsSectioralista= t3.EsSectioralista	
						,Usuario_IdLanguage= t3.IdLanguage	
						,Usuario_AccesoTotal= t3.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoSeguimientoEstado Copy(nc.ProyectoSeguimientoEstado entity)
        {           
            nc.ProyectoSeguimientoEstado _new = new nc.ProyectoSeguimientoEstado();
		 _new.IdProyectoSeguimiento= entity.IdProyectoSeguimiento;
		 _new.IdEstado= entity.IdEstado;
		 _new.Fecha= entity.Fecha;
		 _new.Observacion= entity.Observacion;
		 _new.IdUsuario= entity.IdUsuario;
		return _new;			
        }
		public override int CopyAndSave(ProyectoSeguimientoEstado entity,string renameFormat)
        {
            ProyectoSeguimientoEstado  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoSeguimientoEstado entity, int id)
        {            
            entity.IdProyectoSeguimientoEstado = id;            
        }
		public override void Set(ProyectoSeguimientoEstado source,ProyectoSeguimientoEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoEstado= source.IdProyectoSeguimientoEstado ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 		  
		}
		public override void Set(ProyectoSeguimientoEstadoResult source,ProyectoSeguimientoEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoEstado= source.IdProyectoSeguimientoEstado ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 
		}
		public override void Set(ProyectoSeguimientoEstado source,ProyectoSeguimientoEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoEstado= source.IdProyectoSeguimientoEstado ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 	
		}		
		public override void Set(ProyectoSeguimientoEstadoResult source,ProyectoSeguimientoEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoEstado= source.IdProyectoSeguimientoEstado ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.ProyectoSeguimiento_IdSaf= source.ProyectoSeguimiento_IdSaf;	
			target.ProyectoSeguimiento_Denominacion= source.ProyectoSeguimiento_Denominacion;	
			target.ProyectoSeguimiento_Ruta= source.ProyectoSeguimiento_Ruta;	
			target.ProyectoSeguimiento_Malla= source.ProyectoSeguimiento_Malla;	
			target.ProyectoSeguimiento_IdAnalista= source.ProyectoSeguimiento_IdAnalista;	
			target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior= source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior;	
			target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoSeguimientoEstado source,ProyectoSeguimientoEstado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoEstado.Equals(target.IdProyectoSeguimientoEstado))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoSeguimientoEstadoResult source,ProyectoSeguimientoEstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoEstado.Equals(target.IdProyectoSeguimientoEstado))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if(!source.ProyectoSeguimiento_IdSaf.Equals(target.ProyectoSeguimiento_IdSaf))return false;
					  if((source.ProyectoSeguimiento_Denominacion == null)?target.ProyectoSeguimiento_Denominacion!=null: !( (target.ProyectoSeguimiento_Denominacion== String.Empty && source.ProyectoSeguimiento_Denominacion== null) || (target.ProyectoSeguimiento_Denominacion==null && source.ProyectoSeguimiento_Denominacion== String.Empty )) &&   !source.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoSeguimiento_Ruta == null)?target.ProyectoSeguimiento_Ruta!=null: !( (target.ProyectoSeguimiento_Ruta== String.Empty && source.ProyectoSeguimiento_Ruta== null) || (target.ProyectoSeguimiento_Ruta==null && source.ProyectoSeguimiento_Ruta== String.Empty )) &&   !source.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoSeguimiento_Malla == null)?target.ProyectoSeguimiento_Malla!=null: !( (target.ProyectoSeguimiento_Malla== String.Empty && source.ProyectoSeguimiento_Malla== null) || (target.ProyectoSeguimiento_Malla==null && source.ProyectoSeguimiento_Malla== String.Empty )) &&   !source.ProyectoSeguimiento_Malla.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Malla.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoSeguimiento_IdAnalista.Equals(target.ProyectoSeguimiento_IdAnalista))return false;
					  if((source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior))return false;
									  if((source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo))return false;
									  if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
					  if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
					  if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
