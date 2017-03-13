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
    public abstract class _MessageData : EntityData<Message,MessageFilter,MessageResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Message entity)
		{			
			return entity.IdMessage;
		}		
		public override Message GetByEntity(Message entity)
        {
            return this.GetById(entity.IdMessage);
        }
        public override Message GetById(int id)
        {
            return (from o in this.Table where o.IdMessage == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Message> Query(MessageFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMessage == null || filter.IdMessage == 0 || o.IdMessage==filter.IdMessage)
					  && (filter.IdMediaFrom == null || filter.IdMediaFrom == 0 || o.IdMediaFrom==filter.IdMediaFrom)
					  && (filter.IdUserFrom == null || filter.IdUserFrom == 0 || o.IdUserFrom==filter.IdUserFrom)
					  && (filter.IdPriority == null || filter.IdPriority == 0 || o.IdPriority==filter.IdPriority)
					  && (filter.Subject == null || filter.Subject.Trim() == string.Empty || filter.Subject.Trim() == "%"  || (filter.Subject.EndsWith("%") && filter.Subject.StartsWith("%") && (o.Subject.Contains(filter.Subject.Replace("%", "")))) || (filter.Subject.EndsWith("%") && o.Subject.StartsWith(filter.Subject.Replace("%",""))) || (filter.Subject.StartsWith("%") && o.Subject.EndsWith(filter.Subject.Replace("%",""))) || o.Subject == filter.Subject )
					  && (filter.Body == null || filter.Body.Trim() == string.Empty || filter.Body.Trim() == "%"  || (filter.Body.EndsWith("%") && filter.Body.StartsWith("%") && (o.Body.Contains(filter.Body.Replace("%", "")))) || (filter.Body.EndsWith("%") && o.Body.StartsWith(filter.Body.Replace("%",""))) || (filter.Body.StartsWith("%") && o.Body.EndsWith(filter.Body.Replace("%",""))) || o.Body == filter.Body )
					  && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >=  filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
					  && (filter.SendDate == null || filter.SendDate == DateTime.MinValue || o.SendDate >=  filter.SendDate) && (filter.SendDate_To == null || filter.SendDate_To == DateTime.MinValue || o.SendDate <= filter.SendDate_To)
					  && (filter.SendDateIsNull == null || filter.SendDateIsNull == true || o.SendDate != null ) && (filter.SendDateIsNull == null || filter.SendDateIsNull == false || o.SendDate == null)
					  && (filter.IsManual == null || o.IsManual==filter.IsManual)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == true || o.IdProyecto != null ) && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == false || o.IdProyecto == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MessageResult> QueryResult(MessageFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.MessageMedias on o.IdMediaFrom equals t1.IdMessageMedia   
				    join t2  in this.Context.Priorities on o.IdPriority equals t2.IdPriority   
				   join _t3  in this.Context.Proyectos on o.IdProyecto equals _t3.IdProyecto into tt3 from t3 in tt3.DefaultIfEmpty()
				    join t4  in this.Context.Usuarios on o.IdUserFrom equals t4.IdUsuario   
				   select new MessageResult(){
					 IdMessage=o.IdMessage
					 ,IdMediaFrom=o.IdMediaFrom
					 ,IdUserFrom=o.IdUserFrom
					 ,IdPriority=o.IdPriority
					 ,Subject=o.Subject
					 ,Body=o.Body
					 ,StartDate=o.StartDate
					 ,SendDate=o.SendDate
					 ,IsManual=o.IsManual
					 ,IdProyecto=o.IdProyecto
					,MediaFrom_Name= t1.Name	
						,MediaFrom_Img= t1.Img	
						,Priority_Name= t2.Name	
						,Priority_Img= t2.Img	
                        //,Proyecto_IdTipoProyecto= t3!=null?(int?)t3.IdTipoProyecto:null	
                        //,Proyecto_IdSubPrograma= t3!=null?(int?)t3.IdSubPrograma:null	
                        ,Proyecto_Codigo= t3!=null?(int?)t3.Codigo:null	
                        ,Proyecto_ProyectoDenominacion= t3!=null?(string)t3.ProyectoDenominacion:null	
                        //,Proyecto_ProyectoSituacionActual= t3!=null?(string)t3.ProyectoSituacionActual:null	
                        //,Proyecto_ProyectoDescripcion= t3!=null?(string)t3.ProyectoDescripcion:null	
                        //,Proyecto_ProyectoObservacion= t3!=null?(string)t3.ProyectoObservacion:null	
                        //,Proyecto_IdEstado= t3!=null?(int?)t3.IdEstado:null	
                        //,Proyecto_IdProceso= t3!=null?(int?)t3.IdProceso:null	
                        //,Proyecto_IdModalidadContratacion= t3!=null?(int?)t3.IdModalidadContratacion:null	
                        //,Proyecto_IdFinalidadFuncion= t3!=null?(int?)t3.IdFinalidadFuncion:null	
                        //,Proyecto_IdOrganismoPrioridad= t3!=null?(int?)t3.IdOrganismoPrioridad:null	
                        //,Proyecto_SubPrioridad= t3!=null?(int?)t3.SubPrioridad:null	
                        //,Proyecto_EsBorrador= t3!=null?(bool?)t3.EsBorrador:null	
                        //,Proyecto_EsProyecto= t3!=null?(bool?)t3.EsProyecto:null	
                        //,Proyecto_NroProyecto= t3!=null?(int?)t3.NroProyecto:null	
                        //,Proyecto_AnioCorriente= t3!=null?(int?)t3.AnioCorriente:null	
                        //,Proyecto_FechaInicioEjecucionCalculada= t3!=null?(DateTime?)t3.FechaInicioEjecucionCalculada:null	
                        //,Proyecto_FechaFinEjecucionCalculada= t3!=null?(DateTime?)t3.FechaFinEjecucionCalculada:null	
                        //,Proyecto_FechaAlta= t3!=null?(DateTime?)t3.FechaAlta:null	
                        //,Proyecto_FechaModificacion= t3!=null?(DateTime?)t3.FechaModificacion:null	
                        //,Proyecto_IdUsuarioModificacion= t3!=null?(int?)t3.IdUsuarioModificacion:null	
                        //,Proyecto_IdProyectoPlan= t3!=null?(int?)t3.IdProyectoPlan:null	
                        //,Proyecto_EvaluarValidaciones= t3!=null?(bool?)t3.EvaluarValidaciones:null	
                        //,Proyecto_Activo= t3!=null?(bool?)t3.Activo:null	
						,UserFrom_NombreUsuario= t4.NombreUsuario	
						,UserFrom_Clave= t4.Clave	
						,UserFrom_Activo= t4.Activo	
						,UserFrom_EsSectioralista= t4.EsSectioralista	
						,UserFrom_IdLanguage= t4.IdLanguage	
						,UserFrom_AccesoTotal= t4.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Message Copy(nc.Message entity)
        {           
            nc.Message _new = new nc.Message();
		 _new.IdMediaFrom= entity.IdMediaFrom;
		 _new.IdUserFrom= entity.IdUserFrom;
		 _new.IdPriority= entity.IdPriority;
		 _new.Subject= entity.Subject;
		 _new.Body= entity.Body;
		 _new.StartDate= entity.StartDate;
		 _new.SendDate= entity.SendDate;
		 _new.IsManual= entity.IsManual;
		 _new.IdProyecto= entity.IdProyecto;
		return _new;			
        }
		public override int CopyAndSave(Message entity,string renameFormat)
        {
            Message  newEntity = Copy(entity);
            newEntity.Subject = string.Format(renameFormat,newEntity.Subject);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Message entity, int id)
        {            
            entity.IdMessage = id;            
        }
		public override void Set(Message source,Message target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessage= source.IdMessage ;
		 target.IdMediaFrom= source.IdMediaFrom ;
		 target.IdUserFrom= source.IdUserFrom ;
		 target.IdPriority= source.IdPriority ;
		 target.Subject= source.Subject ;
		 target.Body= source.Body ;
		 target.StartDate= source.StartDate ;
		 target.SendDate= source.SendDate ;
		 target.IsManual= source.IsManual ;
		 target.IdProyecto= source.IdProyecto ;
		 		  
		}
		public override void Set(MessageResult source,Message target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessage= source.IdMessage ;
		 target.IdMediaFrom= source.IdMediaFrom ;
		 target.IdUserFrom= source.IdUserFrom ;
		 target.IdPriority= source.IdPriority ;
		 target.Subject= source.Subject ;
		 target.Body= source.Body ;
		 target.StartDate= source.StartDate ;
		 target.SendDate= source.SendDate ;
		 target.IsManual= source.IsManual ;
		 target.IdProyecto= source.IdProyecto ;
		 
		}
		public override void Set(Message source,MessageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessage= source.IdMessage ;
		 target.IdMediaFrom= source.IdMediaFrom ;
		 target.IdUserFrom= source.IdUserFrom ;
		 target.IdPriority= source.IdPriority ;
		 target.Subject= source.Subject ;
		 target.Body= source.Body ;
		 target.StartDate= source.StartDate ;
		 target.SendDate= source.SendDate ;
		 target.IsManual= source.IsManual ;
		 target.IdProyecto= source.IdProyecto ;
		 	
		}		
		public override void Set(MessageResult source,MessageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessage= source.IdMessage ;
		 target.IdMediaFrom= source.IdMediaFrom ;
		 target.IdUserFrom= source.IdUserFrom ;
		 target.IdPriority= source.IdPriority ;
		 target.Subject= source.Subject ;
		 target.Body= source.Body ;
		 target.StartDate= source.StartDate ;
		 target.SendDate= source.SendDate ;
		 target.IsManual= source.IsManual ;
		 target.IdProyecto= source.IdProyecto ;
		 target.MediaFrom_Name= source.MediaFrom_Name;	
			target.MediaFrom_Img= source.MediaFrom_Img;	
			target.Priority_Name= source.Priority_Name;	
			target.Priority_Img= source.Priority_Img;	
            //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
            //target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
            //target.Proyecto_Codigo= source.Proyecto_Codigo;	
            //target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
            //target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
            //target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
            //target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
            //target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
            //target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
            //target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
            //target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
            //target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
            //target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
            //target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
            //target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
            //target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
            //target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
            //target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
            //target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
            //target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
            //target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
            //target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
            //target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
            //target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
            //target.Proyecto_Activo= source.Proyecto_Activo;	
			target.UserFrom_NombreUsuario= source.UserFrom_NombreUsuario;	
			target.UserFrom_Clave= source.UserFrom_Clave;	
			target.UserFrom_Activo= source.UserFrom_Activo;	
			target.UserFrom_EsSectioralista= source.UserFrom_EsSectioralista;	
			target.UserFrom_IdLanguage= source.UserFrom_IdLanguage;	
			target.UserFrom_AccesoTotal= source.UserFrom_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Message source,Message target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.IdMediaFrom.Equals(target.IdMediaFrom))return false;
		  if(!source.IdUserFrom.Equals(target.IdUserFrom))return false;
		  if(!source.IdPriority.Equals(target.IdPriority))return false;
		  if((source.Subject == null)?target.Subject!=null:  !( (target.Subject== String.Empty && source.Subject== null) || (target.Subject==null && source.Subject== String.Empty )) &&  !source.Subject.Trim().Replace ("\r","").Equals(target.Subject.Trim().Replace ("\r","")))return false;
			 if((source.Body == null)?target.Body!=null:  !( (target.Body== String.Empty && source.Body== null) || (target.Body==null && source.Body== String.Empty )) &&  !source.Body.Trim().Replace ("\r","").Equals(target.Body.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.SendDate == null)?(target.SendDate.HasValue):!source.SendDate.Equals(target.SendDate))return false;
			 if(!source.IsManual.Equals(target.IsManual))return false;
		  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						 
		  return true;
        }
		public override bool Equals(MessageResult source,MessageResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.IdMediaFrom.Equals(target.IdMediaFrom))return false;
		  if(!source.IdUserFrom.Equals(target.IdUserFrom))return false;
		  if(!source.IdPriority.Equals(target.IdPriority))return false;
		  if((source.Subject == null)?target.Subject!=null: !( (target.Subject== String.Empty && source.Subject== null) || (target.Subject==null && source.Subject== String.Empty )) && !source.Subject.Trim().Replace ("\r","").Equals(target.Subject.Trim().Replace ("\r","")))return false;
			 if((source.Body == null)?target.Body!=null: !( (target.Body== String.Empty && source.Body== null) || (target.Body==null && source.Body== String.Empty )) && !source.Body.Trim().Replace ("\r","").Equals(target.Body.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.SendDate == null)?(target.SendDate.HasValue):!source.SendDate.Equals(target.SendDate))return false;
			 if(!source.IsManual.Equals(target.IsManual))return false;
		  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						  if((source.MediaFrom_Name == null)?target.MediaFrom_Name!=null: !( (target.MediaFrom_Name== String.Empty && source.MediaFrom_Name== null) || (target.MediaFrom_Name==null && source.MediaFrom_Name== String.Empty )) &&   !source.MediaFrom_Name.Trim().Replace ("\r","").Equals(target.MediaFrom_Name.Trim().Replace ("\r","")))return false;
						 if((source.MediaFrom_Img == null)?target.MediaFrom_Img!=null: !( (target.MediaFrom_Img== String.Empty && source.MediaFrom_Img== null) || (target.MediaFrom_Img==null && source.MediaFrom_Img== String.Empty )) &&   !source.MediaFrom_Img.Trim().Replace ("\r","").Equals(target.MediaFrom_Img.Trim().Replace ("\r","")))return false;
						 if((source.Priority_Name == null)?target.Priority_Name!=null: !( (target.Priority_Name== String.Empty && source.Priority_Name== null) || (target.Priority_Name==null && source.Priority_Name== String.Empty )) &&   !source.Priority_Name.Trim().Replace ("\r","").Equals(target.Priority_Name.Trim().Replace ("\r","")))return false;
						 if((source.Priority_Img == null)?target.Priority_Img!=null: !( (target.Priority_Img== String.Empty && source.Priority_Img== null) || (target.Priority_Img==null && source.Priority_Img== String.Empty )) &&   !source.Priority_Img.Trim().Replace ("\r","").Equals(target.Priority_Img.Trim().Replace ("\r","")))return false;
                      //   if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
                      //if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
                      //if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
                      //if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
                      //if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
                      //                if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
                      //                if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
                      //                if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
                      //                if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
                      //   if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
                      //if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
                      //   if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
                      //   if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
                      //   if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
                      //   if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
                      //   if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
                      //if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
                      //if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
                      //if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
                      //   if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
                      //if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					  if((source.UserFrom_NombreUsuario == null)?target.UserFrom_NombreUsuario!=null: !( (target.UserFrom_NombreUsuario== String.Empty && source.UserFrom_NombreUsuario== null) || (target.UserFrom_NombreUsuario==null && source.UserFrom_NombreUsuario== String.Empty )) &&   !source.UserFrom_NombreUsuario.Trim().Replace ("\r","").Equals(target.UserFrom_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.UserFrom_Clave == null)?target.UserFrom_Clave!=null: !( (target.UserFrom_Clave== String.Empty && source.UserFrom_Clave== null) || (target.UserFrom_Clave==null && source.UserFrom_Clave== String.Empty )) &&   !source.UserFrom_Clave.Trim().Replace ("\r","").Equals(target.UserFrom_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.UserFrom_Activo.Equals(target.UserFrom_Activo))return false;
					  if(!source.UserFrom_EsSectioralista.Equals(target.UserFrom_EsSectioralista))return false;
					  if(!source.UserFrom_IdLanguage.Equals(target.UserFrom_IdLanguage))return false;
					  if(!source.UserFrom_AccesoTotal.Equals(target.UserFrom_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
