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
    public abstract class _ProyectoDictamenEstadoData : EntityData<ProyectoDictamenEstado,ProyectoDictamenEstadoFilter,ProyectoDictamenEstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoDictamenEstado entity)
		{			
			return entity.IdProyectoDictamenEstado;
		}		
		public override ProyectoDictamenEstado GetByEntity(ProyectoDictamenEstado entity)
        {
            return this.GetById(entity.IdProyectoDictamenEstado);
        }
        public override ProyectoDictamenEstado GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoDictamenEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoDictamenEstado> Query(ProyectoDictamenEstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoDictamenEstado == null || filter.IdProyectoDictamenEstado == 0 || o.IdProyectoDictamenEstado==filter.IdProyectoDictamenEstado)
					  && (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || o.IdProyectoDictamen==filter.IdProyectoDictamen)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoDictamenEstadoResult> QueryResult(ProyectoDictamenEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.ProyectoDictamens on o.IdProyectoDictamen equals t2.IdProyectoDictamen   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario   
				   select new ProyectoDictamenEstadoResult(){
					 IdProyectoDictamenEstado=o.IdProyectoDictamenEstado
					 ,IdProyectoDictamen=o.IdProyectoDictamen
					 ,IdEstado=o.IdEstado
					 ,Fecha=o.Fecha
					 ,Observacion=o.Observacion
					 ,IdUsuario=o.IdUsuario
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,ProyectoDictamen_IdProyectoCalificacion= t2.IdProyectoCalificacion	
						,ProyectoDictamen_Fecha= t2.Fecha	
						,ProyectoDictamen_FechaVencimiento= t2.FechaVencimiento	
						,ProyectoDictamen_IdPlanPeriodo= t2.IdPlanPeriodo	
						,ProyectoDictamen_Monto= t2.Monto	
						,ProyectoDictamen_Ejercicio= t2.Ejercicio	
						,ProyectoDictamen_DuracionMeses= t2.DuracionMeses	
						,ProyectoDictamen_InformeTecnico= t2.InformeTecnico	
						,ProyectoDictamen_FechaComiteTecnico= t2.FechaComiteTecnico	
						,ProyectoDictamen_Observacion= t2.Observacion	
						,ProyectoDictamen_Recomendacion= t2.Recomendacion	
						,ProyectoDictamen_RespuestaOrganismo= t2.RespuestaOrganismo	
						,ProyectoDictamen_FechaRepuesta= t2.FechaRepuesta	
						,ProyectoDictamen_FechaEstado= t2.FechaEstado	
						,ProyectoDictamen_Numero= t2.Numero	
						,ProyectoDictamen_Denominacion= t2.Denominacion	
						,ProyectoDictamen_IdProyectoDictamenEstadoUltimo= t2.IdProyectoDictamenEstadoUltimo	
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
		public override nc.ProyectoDictamenEstado Copy(nc.ProyectoDictamenEstado entity)
        {           
            nc.ProyectoDictamenEstado _new = new nc.ProyectoDictamenEstado();
		 _new.IdProyectoDictamen= entity.IdProyectoDictamen;
		 _new.IdEstado= entity.IdEstado;
		 _new.Fecha= entity.Fecha;
		 _new.Observacion= entity.Observacion;
		 _new.IdUsuario= entity.IdUsuario;
		return _new;			
        }
		public override int CopyAndSave(ProyectoDictamenEstado entity,string renameFormat)
        {
            ProyectoDictamenEstado  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoDictamenEstado entity, int id)
        {            
            entity.IdProyectoDictamenEstado = id;            
        }
		public override void Set(ProyectoDictamenEstado source,ProyectoDictamenEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenEstado= source.IdProyectoDictamenEstado ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 		  
		}
		public override void Set(ProyectoDictamenEstadoResult source,ProyectoDictamenEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenEstado= source.IdProyectoDictamenEstado ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 
		}
		public override void Set(ProyectoDictamenEstado source,ProyectoDictamenEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenEstado= source.IdProyectoDictamenEstado ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 	
		}		
		public override void Set(ProyectoDictamenEstadoResult source,ProyectoDictamenEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDictamenEstado= source.IdProyectoDictamenEstado ;
		 target.IdProyectoDictamen= source.IdProyectoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.ProyectoDictamen_IdProyectoCalificacion= source.ProyectoDictamen_IdProyectoCalificacion;	
			target.ProyectoDictamen_Fecha= source.ProyectoDictamen_Fecha;	
			target.ProyectoDictamen_FechaVencimiento= source.ProyectoDictamen_FechaVencimiento;	
			target.ProyectoDictamen_IdPlanPeriodo= source.ProyectoDictamen_IdPlanPeriodo;	
			target.ProyectoDictamen_Monto= source.ProyectoDictamen_Monto;	
			target.ProyectoDictamen_Ejercicio= source.ProyectoDictamen_Ejercicio;	
			target.ProyectoDictamen_DuracionMeses= source.ProyectoDictamen_DuracionMeses;	
			target.ProyectoDictamen_InformeTecnico= source.ProyectoDictamen_InformeTecnico;	
			target.ProyectoDictamen_FechaComiteTecnico= source.ProyectoDictamen_FechaComiteTecnico;	
			target.ProyectoDictamen_Observacion= source.ProyectoDictamen_Observacion;	
			target.ProyectoDictamen_Recomendacion= source.ProyectoDictamen_Recomendacion;	
			target.ProyectoDictamen_RespuestaOrganismo= source.ProyectoDictamen_RespuestaOrganismo;	
			target.ProyectoDictamen_FechaRepuesta= source.ProyectoDictamen_FechaRepuesta;	
			target.ProyectoDictamen_FechaEstado= source.ProyectoDictamen_FechaEstado;	
			target.ProyectoDictamen_Numero= source.ProyectoDictamen_Numero;	
			target.ProyectoDictamen_IdProyectoDictamenEstadoUltimo= source.ProyectoDictamen_IdProyectoDictamenEstadoUltimo;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoDictamenEstado source,ProyectoDictamenEstado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDictamenEstado.Equals(target.IdProyectoDictamenEstado))return false;
		  if(!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoDictamenEstadoResult source,ProyectoDictamenEstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDictamenEstado.Equals(target.IdProyectoDictamenEstado))return false;
		  if(!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if((source.ProyectoDictamen_IdProyectoCalificacion == null)?(target.ProyectoDictamen_IdProyectoCalificacion.HasValue && target.ProyectoDictamen_IdProyectoCalificacion.Value > 0):!source.ProyectoDictamen_IdProyectoCalificacion.Equals(target.ProyectoDictamen_IdProyectoCalificacion))return false;
									  if((source.ProyectoDictamen_Fecha == null)?(target.ProyectoDictamen_Fecha.HasValue ):!source.ProyectoDictamen_Fecha.Equals(target.ProyectoDictamen_Fecha))return false;
						 if((source.ProyectoDictamen_FechaVencimiento == null)?(target.ProyectoDictamen_FechaVencimiento.HasValue ):!source.ProyectoDictamen_FechaVencimiento.Equals(target.ProyectoDictamen_FechaVencimiento))return false;
						 if((source.ProyectoDictamen_IdPlanPeriodo == null)?(target.ProyectoDictamen_IdPlanPeriodo.HasValue && target.ProyectoDictamen_IdPlanPeriodo.Value > 0):!source.ProyectoDictamen_IdPlanPeriodo.Equals(target.ProyectoDictamen_IdPlanPeriodo))return false;
									  if((source.ProyectoDictamen_Monto == null)?(target.ProyectoDictamen_Monto.HasValue ):!source.ProyectoDictamen_Monto.Equals(target.ProyectoDictamen_Monto))return false;
						 if((source.ProyectoDictamen_Ejercicio == null)?(target.ProyectoDictamen_Ejercicio.HasValue ):!source.ProyectoDictamen_Ejercicio.Equals(target.ProyectoDictamen_Ejercicio))return false;
						 if((source.ProyectoDictamen_DuracionMeses == null)?(target.ProyectoDictamen_DuracionMeses.HasValue ):!source.ProyectoDictamen_DuracionMeses.Equals(target.ProyectoDictamen_DuracionMeses))return false;
						 if((source.ProyectoDictamen_InformeTecnico == null)?target.ProyectoDictamen_InformeTecnico!=null: !( (target.ProyectoDictamen_InformeTecnico== String.Empty && source.ProyectoDictamen_InformeTecnico== null) || (target.ProyectoDictamen_InformeTecnico==null && source.ProyectoDictamen_InformeTecnico== String.Empty )) &&   !source.ProyectoDictamen_InformeTecnico.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_InformeTecnico.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_FechaComiteTecnico == null)?(target.ProyectoDictamen_FechaComiteTecnico.HasValue ):!source.ProyectoDictamen_FechaComiteTecnico.Equals(target.ProyectoDictamen_FechaComiteTecnico))return false;
						 if((source.ProyectoDictamen_Observacion == null)?target.ProyectoDictamen_Observacion!=null: !( (target.ProyectoDictamen_Observacion== String.Empty && source.ProyectoDictamen_Observacion== null) || (target.ProyectoDictamen_Observacion==null && source.ProyectoDictamen_Observacion== String.Empty )) &&   !source.ProyectoDictamen_Observacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Observacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_Recomendacion == null)?target.ProyectoDictamen_Recomendacion!=null: !( (target.ProyectoDictamen_Recomendacion== String.Empty && source.ProyectoDictamen_Recomendacion== null) || (target.ProyectoDictamen_Recomendacion==null && source.ProyectoDictamen_Recomendacion== String.Empty )) &&   !source.ProyectoDictamen_Recomendacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Recomendacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_RespuestaOrganismo == null)?target.ProyectoDictamen_RespuestaOrganismo!=null: !( (target.ProyectoDictamen_RespuestaOrganismo== String.Empty && source.ProyectoDictamen_RespuestaOrganismo== null) || (target.ProyectoDictamen_RespuestaOrganismo==null && source.ProyectoDictamen_RespuestaOrganismo== String.Empty )) &&   !source.ProyectoDictamen_RespuestaOrganismo.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_RespuestaOrganismo.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_FechaRepuesta == null)?(target.ProyectoDictamen_FechaRepuesta.HasValue ):!source.ProyectoDictamen_FechaRepuesta.Equals(target.ProyectoDictamen_FechaRepuesta))return false;
						 if(!source.ProyectoDictamen_FechaEstado.Equals(target.ProyectoDictamen_FechaEstado))return false;
					  if((source.ProyectoDictamen_Numero == null)?target.ProyectoDictamen_Numero!=null: !( (target.ProyectoDictamen_Numero== String.Empty && source.ProyectoDictamen_Numero== null) || (target.ProyectoDictamen_Numero==null && source.ProyectoDictamen_Numero== String.Empty )) &&   !source.ProyectoDictamen_Numero.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Numero.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_Denominacion == null)?target.ProyectoDictamen_Denominacion!=null: !( (target.ProyectoDictamen_Denominacion== String.Empty && source.ProyectoDictamen_Denominacion== null) || (target.ProyectoDictamen_Denominacion==null && source.ProyectoDictamen_Denominacion== String.Empty )) &&   !source.ProyectoDictamen_Denominacion.Trim().Replace ("\r","").Equals(target.ProyectoDictamen_Denominacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoDictamen_IdProyectoDictamenEstadoUltimo == null)?(target.ProyectoDictamen_IdProyectoDictamenEstadoUltimo.HasValue && target.ProyectoDictamen_IdProyectoDictamenEstadoUltimo.Value > 0):!source.ProyectoDictamen_IdProyectoDictamenEstadoUltimo.Equals(target.ProyectoDictamen_IdProyectoDictamenEstadoUltimo))return false;
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
