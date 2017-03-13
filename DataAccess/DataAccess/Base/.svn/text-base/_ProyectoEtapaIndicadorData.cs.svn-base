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
    public abstract class _ProyectoEtapaIndicadorData : EntityData<ProyectoEtapaIndicador,ProyectoEtapaIndicadorFilter,ProyectoEtapaIndicadorResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEtapaIndicador entity)
		{			
			return entity.IdProyectoEtapaIndicador;
		}		
		public override ProyectoEtapaIndicador GetByEntity(ProyectoEtapaIndicador entity)
        {
            return this.GetById(entity.IdProyectoEtapaIndicador);
        }
        public override ProyectoEtapaIndicador GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoEtapaIndicador == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEtapaIndicador> Query(ProyectoEtapaIndicadorFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoEtapaIndicador == null || o.IdProyectoEtapaIndicador >=  filter.IdProyectoEtapaIndicador) && (filter.IdProyectoEtapaIndicador_To == null || o.IdProyectoEtapaIndicador <= filter.IdProyectoEtapaIndicador_To)
					  && (filter.IdProyectoEtapa == null || filter.IdProyectoEtapa == 0 || o.IdProyectoEtapa==filter.IdProyectoEtapa)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.IdUnidadMedia == null || o.IdUnidadMedia >=  filter.IdUnidadMedia) && (filter.IdUnidadMedia_To == null || o.IdUnidadMedia <= filter.IdUnidadMedia_To)
					  && (filter.IdUnidadMediaIsNull == null || filter.IdUnidadMediaIsNull == true || o.IdUnidadMedia != null ) && (filter.IdUnidadMediaIsNull == null || filter.IdUnidadMediaIsNull == false || o.IdUnidadMedia == null)
					  && (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador==filter.IdIndicador)
					  && (filter.IdIndicadorIsNull == null || filter.IdIndicadorIsNull == true || o.IdIndicador != null ) && (filter.IdIndicadorIsNull == null || filter.IdIndicadorIsNull == false || o.IdIndicador == null)
					  && (filter.NroExpediente == null || filter.NroExpediente.Trim() == string.Empty || filter.NroExpediente.Trim() == "%"  || (filter.NroExpediente.EndsWith("%") && filter.NroExpediente.StartsWith("%") && (o.NroExpediente.Contains(filter.NroExpediente.Replace("%", "")))) || (filter.NroExpediente.EndsWith("%") && o.NroExpediente.StartsWith(filter.NroExpediente.Replace("%",""))) || (filter.NroExpediente.StartsWith("%") && o.NroExpediente.EndsWith(filter.NroExpediente.Replace("%",""))) || o.NroExpediente == filter.NroExpediente )
					  && (filter.FechaLicitacion == null || filter.FechaLicitacion == DateTime.MinValue || o.FechaLicitacion >=  filter.FechaLicitacion) && (filter.FechaLicitacion_To == null || filter.FechaLicitacion_To == DateTime.MinValue || o.FechaLicitacion <= filter.FechaLicitacion_To)
					  && (filter.FechaLicitacionIsNull == null || filter.FechaLicitacionIsNull == true || o.FechaLicitacion != null ) && (filter.FechaLicitacionIsNull == null || filter.FechaLicitacionIsNull == false || o.FechaLicitacion == null)
					  && (filter.FechaContratacion == null || filter.FechaContratacion == DateTime.MinValue || o.FechaContratacion >=  filter.FechaContratacion) && (filter.FechaContratacion_To == null || filter.FechaContratacion_To == DateTime.MinValue || o.FechaContratacion <= filter.FechaContratacion_To)
					  && (filter.FechaContratacionIsNull == null || filter.FechaContratacionIsNull == true || o.FechaContratacion != null ) && (filter.FechaContratacionIsNull == null || filter.FechaContratacionIsNull == false || o.FechaContratacion == null)
					  && (filter.Contratista == null || filter.Contratista.Trim() == string.Empty || filter.Contratista.Trim() == "%"  || (filter.Contratista.EndsWith("%") && filter.Contratista.StartsWith("%") && (o.Contratista.Contains(filter.Contratista.Replace("%", "")))) || (filter.Contratista.EndsWith("%") && o.Contratista.StartsWith(filter.Contratista.Replace("%",""))) || (filter.Contratista.StartsWith("%") && o.Contratista.EndsWith(filter.Contratista.Replace("%",""))) || o.Contratista == filter.Contratista )
					  && (filter.FechaInicioObra == null || filter.FechaInicioObra == DateTime.MinValue || o.FechaInicioObra >=  filter.FechaInicioObra) && (filter.FechaInicioObra_To == null || filter.FechaInicioObra_To == DateTime.MinValue || o.FechaInicioObra <= filter.FechaInicioObra_To)
					  && (filter.FechaInicioObraIsNull == null || filter.FechaInicioObraIsNull == true || o.FechaInicioObra != null ) && (filter.FechaInicioObraIsNull == null || filter.FechaInicioObraIsNull == false || o.FechaInicioObra == null)
					  && (filter.PlazoEjecucion == null || filter.PlazoEjecucion.Trim() == string.Empty || filter.PlazoEjecucion.Trim() == "%"  || (filter.PlazoEjecucion.EndsWith("%") && filter.PlazoEjecucion.StartsWith("%") && (o.PlazoEjecucion.Contains(filter.PlazoEjecucion.Replace("%", "")))) || (filter.PlazoEjecucion.EndsWith("%") && o.PlazoEjecucion.StartsWith(filter.PlazoEjecucion.Replace("%",""))) || (filter.PlazoEjecucion.StartsWith("%") && o.PlazoEjecucion.EndsWith(filter.PlazoEjecucion.Replace("%",""))) || o.PlazoEjecucion == filter.PlazoEjecucion )
					  && (filter.IdMoneda == null || o.IdMoneda >=  filter.IdMoneda) && (filter.IdMoneda_To == null || o.IdMoneda <= filter.IdMoneda_To)
					  && (filter.IdMonedaIsNull == null || filter.IdMonedaIsNull == true || o.IdMoneda != null ) && (filter.IdMonedaIsNull == null || filter.IdMonedaIsNull == false || o.IdMoneda == null)
					  && (filter.Magnitud == null || o.Magnitud >=  filter.Magnitud) && (filter.Magnitud_To == null || o.Magnitud <= filter.Magnitud_To)
					  && (filter.MagnitudIsNull == null || filter.MagnitudIsNull == true || o.Magnitud != null ) && (filter.MagnitudIsNull == null || filter.MagnitudIsNull == false || o.Magnitud == null)
					  && (filter.MontoContrato == null || o.MontoContrato >=  filter.MontoContrato) && (filter.MontoContrato_To == null || o.MontoContrato <= filter.MontoContrato_To)
					  && (filter.MontoContratoIsNull == null || filter.MontoContratoIsNull == true || o.MontoContrato != null ) && (filter.MontoContratoIsNull == null || filter.MontoContratoIsNull == false || o.MontoContrato == null)
					  && (filter.MontoVigente == null || o.MontoVigente >=  filter.MontoVigente) && (filter.MontoVigente_To == null || o.MontoVigente <= filter.MontoVigente_To)
					  && (filter.MontoVigenteIsNull == null || filter.MontoVigenteIsNull == true || o.MontoVigente != null ) && (filter.MontoVigenteIsNull == null || filter.MontoVigenteIsNull == false || o.MontoVigente == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEtapaIndicadorResult> QueryResult(ProyectoEtapaIndicadorFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Indicadors on o.IdIndicador equals _t1.IdIndicador into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.ProyectoEtapas on o.IdProyectoEtapa equals t2.IdProyectoEtapa   
				   select new ProyectoEtapaIndicadorResult(){
					 IdProyectoEtapaIndicador=o.IdProyectoEtapaIndicador
					 ,IdProyectoEtapa=o.IdProyectoEtapa
					 ,Descripcion=o.Descripcion
					 ,IdUnidadMedia=o.IdUnidadMedia
					 ,IdIndicador=o.IdIndicador
					 ,NroExpediente=o.NroExpediente
					 ,FechaLicitacion=o.FechaLicitacion
					 ,FechaContratacion=o.FechaContratacion
					 ,Contratista=o.Contratista
					 ,FechaInicioObra=o.FechaInicioObra
					 ,PlazoEjecucion=o.PlazoEjecucion
					 ,IdMoneda=o.IdMoneda
					 ,Magnitud=o.Magnitud
					 ,MontoContrato=o.MontoContrato
					 ,MontoVigente=o.MontoVigente
					,Indicador_IdMedioVerificacion= t1!=null?(int?)t1.IdMedioVerificacion:null	
						,Indicador_Observacion= t1!=null?(string)t1.Observacion:null	
						,ProyectoEtapa_Nombre= t2.Nombre	
						,ProyectoEtapa_CodigoVinculacion= t2.CodigoVinculacion	
						,ProyectoEtapa_IdEstado= t2.IdEstado	
						,ProyectoEtapa_FechaInicioEstimada= t2.FechaInicioEstimada	
						,ProyectoEtapa_FechaFinEstimada= t2.FechaFinEstimada	
						,ProyectoEtapa_FechaInicioRealizada= t2.FechaInicioRealizada	
						,ProyectoEtapa_FechaFinRealizada= t2.FechaFinRealizada	
						,ProyectoEtapa_IdEtapa= t2.IdEtapa	
						,ProyectoEtapa_IdProyecto= t2.IdProyecto	
						,ProyectoEtapa_NroEtapa= t2.NroEtapa	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEtapaIndicador Copy(nc.ProyectoEtapaIndicador entity)
        {           
            nc.ProyectoEtapaIndicador _new = new nc.ProyectoEtapaIndicador();
		 _new.IdProyectoEtapa= entity.IdProyectoEtapa;
		 _new.Descripcion= entity.Descripcion;
		 _new.IdUnidadMedia= entity.IdUnidadMedia;
		 _new.IdIndicador= entity.IdIndicador;
		 _new.NroExpediente= entity.NroExpediente;
		 _new.FechaLicitacion= entity.FechaLicitacion;
		 _new.FechaContratacion= entity.FechaContratacion;
		 _new.Contratista= entity.Contratista;
		 _new.FechaInicioObra= entity.FechaInicioObra;
		 _new.PlazoEjecucion= entity.PlazoEjecucion;
		 _new.IdMoneda= entity.IdMoneda;
		 _new.Magnitud= entity.Magnitud;
		 _new.MontoContrato= entity.MontoContrato;
		 _new.MontoVigente= entity.MontoVigente;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEtapaIndicador entity,string renameFormat)
        {
            ProyectoEtapaIndicador  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEtapaIndicador entity, int id)
        {            
            entity.IdProyectoEtapaIndicador = id;            
        }
		public override void Set(ProyectoEtapaIndicador source,ProyectoEtapaIndicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaIndicador= source.IdProyectoEtapaIndicador ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Descripcion= source.Descripcion ;
		 target.IdUnidadMedia= source.IdUnidadMedia ;
		 target.IdIndicador= source.IdIndicador ;
		 target.NroExpediente= source.NroExpediente ;
		 target.FechaLicitacion= source.FechaLicitacion ;
		 target.FechaContratacion= source.FechaContratacion ;
		 target.Contratista= source.Contratista ;
		 target.FechaInicioObra= source.FechaInicioObra ;
		 target.PlazoEjecucion= source.PlazoEjecucion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Magnitud= source.Magnitud ;
		 target.MontoContrato= source.MontoContrato ;
		 target.MontoVigente= source.MontoVigente ;
		 		  
		}
		public override void Set(ProyectoEtapaIndicadorResult source,ProyectoEtapaIndicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaIndicador= source.IdProyectoEtapaIndicador ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Descripcion= source.Descripcion ;
		 target.IdUnidadMedia= source.IdUnidadMedia ;
		 target.IdIndicador= source.IdIndicador ;
		 target.NroExpediente= source.NroExpediente ;
		 target.FechaLicitacion= source.FechaLicitacion ;
		 target.FechaContratacion= source.FechaContratacion ;
		 target.Contratista= source.Contratista ;
		 target.FechaInicioObra= source.FechaInicioObra ;
		 target.PlazoEjecucion= source.PlazoEjecucion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Magnitud= source.Magnitud ;
		 target.MontoContrato= source.MontoContrato ;
		 target.MontoVigente= source.MontoVigente ;
		 
		}
		public override void Set(ProyectoEtapaIndicador source,ProyectoEtapaIndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaIndicador= source.IdProyectoEtapaIndicador ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Descripcion= source.Descripcion ;
		 target.IdUnidadMedia= source.IdUnidadMedia ;
		 target.IdIndicador= source.IdIndicador ;
		 target.NroExpediente= source.NroExpediente ;
		 target.FechaLicitacion= source.FechaLicitacion ;
		 target.FechaContratacion= source.FechaContratacion ;
		 target.Contratista= source.Contratista ;
		 target.FechaInicioObra= source.FechaInicioObra ;
		 target.PlazoEjecucion= source.PlazoEjecucion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Magnitud= source.Magnitud ;
		 target.MontoContrato= source.MontoContrato ;
		 target.MontoVigente= source.MontoVigente ;
		 	
		}		
		public override void Set(ProyectoEtapaIndicadorResult source,ProyectoEtapaIndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoEtapaIndicador= source.IdProyectoEtapaIndicador ;
		 target.IdProyectoEtapa= source.IdProyectoEtapa ;
		 target.Descripcion= source.Descripcion ;
		 target.IdUnidadMedia= source.IdUnidadMedia ;
		 target.IdIndicador= source.IdIndicador ;
		 target.NroExpediente= source.NroExpediente ;
		 target.FechaLicitacion= source.FechaLicitacion ;
		 target.FechaContratacion= source.FechaContratacion ;
		 target.Contratista= source.Contratista ;
		 target.FechaInicioObra= source.FechaInicioObra ;
		 target.PlazoEjecucion= source.PlazoEjecucion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Magnitud= source.Magnitud ;
		 target.MontoContrato= source.MontoContrato ;
		 target.MontoVigente= source.MontoVigente ;
		 target.Indicador_IdMedioVerificacion= source.Indicador_IdMedioVerificacion;	
			target.Indicador_Observacion= source.Indicador_Observacion;	
			target.ProyectoEtapa_Nombre= source.ProyectoEtapa_Nombre;	
			target.ProyectoEtapa_CodigoVinculacion= source.ProyectoEtapa_CodigoVinculacion;	
			target.ProyectoEtapa_IdEstado= source.ProyectoEtapa_IdEstado;	
			target.ProyectoEtapa_FechaInicioEstimada= source.ProyectoEtapa_FechaInicioEstimada;	
			target.ProyectoEtapa_FechaFinEstimada= source.ProyectoEtapa_FechaFinEstimada;	
			target.ProyectoEtapa_FechaInicioRealizada= source.ProyectoEtapa_FechaInicioRealizada;	
			target.ProyectoEtapa_FechaFinRealizada= source.ProyectoEtapa_FechaFinRealizada;	
			target.ProyectoEtapa_IdEtapa= source.ProyectoEtapa_IdEtapa;	
			target.ProyectoEtapa_IdProyecto= source.ProyectoEtapa_IdProyecto;	
			target.ProyectoEtapa_NroEtapa= source.ProyectoEtapa_NroEtapa;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEtapaIndicador source,ProyectoEtapaIndicador target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaIndicador.Equals(target.IdProyectoEtapaIndicador))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.IdUnidadMedia == null)?(target.IdUnidadMedia.HasValue):!source.IdUnidadMedia.Equals(target.IdUnidadMedia))return false;
			 if((source.IdIndicador == null)?(target.IdIndicador.HasValue && target.IdIndicador.Value > 0):!source.IdIndicador.Equals(target.IdIndicador))return false;
						  if((source.NroExpediente == null)?target.NroExpediente!=null:  !( (target.NroExpediente== String.Empty && source.NroExpediente== null) || (target.NroExpediente==null && source.NroExpediente== String.Empty )) &&  !source.NroExpediente.Trim().Replace ("\r","").Equals(target.NroExpediente.Trim().Replace ("\r","")))return false;
			 if((source.FechaLicitacion == null)?(target.FechaLicitacion.HasValue):!source.FechaLicitacion.Equals(target.FechaLicitacion))return false;
			 if((source.FechaContratacion == null)?(target.FechaContratacion.HasValue):!source.FechaContratacion.Equals(target.FechaContratacion))return false;
			 if((source.Contratista == null)?target.Contratista!=null:  !( (target.Contratista== String.Empty && source.Contratista== null) || (target.Contratista==null && source.Contratista== String.Empty )) &&  !source.Contratista.Trim().Replace ("\r","").Equals(target.Contratista.Trim().Replace ("\r","")))return false;
			 if((source.FechaInicioObra == null)?(target.FechaInicioObra.HasValue):!source.FechaInicioObra.Equals(target.FechaInicioObra))return false;
			 if((source.PlazoEjecucion == null)?target.PlazoEjecucion!=null:  !( (target.PlazoEjecucion== String.Empty && source.PlazoEjecucion== null) || (target.PlazoEjecucion==null && source.PlazoEjecucion== String.Empty )) &&  !source.PlazoEjecucion.Trim().Replace ("\r","").Equals(target.PlazoEjecucion.Trim().Replace ("\r","")))return false;
			 if((source.IdMoneda == null)?(target.IdMoneda.HasValue):!source.IdMoneda.Equals(target.IdMoneda))return false;
			 if((source.Magnitud == null)?(target.Magnitud.HasValue):!source.Magnitud.Equals(target.Magnitud))return false;
			 if((source.MontoContrato == null)?(target.MontoContrato.HasValue):!source.MontoContrato.Equals(target.MontoContrato))return false;
			 if((source.MontoVigente == null)?(target.MontoVigente.HasValue):!source.MontoVigente.Equals(target.MontoVigente))return false;
			
		  return true;
        }
		public override bool Equals(ProyectoEtapaIndicadorResult source,ProyectoEtapaIndicadorResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoEtapaIndicador.Equals(target.IdProyectoEtapaIndicador))return false;
		  if(!source.IdProyectoEtapa.Equals(target.IdProyectoEtapa))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.IdUnidadMedia == null)?(target.IdUnidadMedia.HasValue):!source.IdUnidadMedia.Equals(target.IdUnidadMedia))return false;
			 if((source.IdIndicador == null)?(target.IdIndicador.HasValue && target.IdIndicador.Value > 0):!source.IdIndicador.Equals(target.IdIndicador))return false;
						  if((source.NroExpediente == null)?target.NroExpediente!=null: !( (target.NroExpediente== String.Empty && source.NroExpediente== null) || (target.NroExpediente==null && source.NroExpediente== String.Empty )) && !source.NroExpediente.Trim().Replace ("\r","").Equals(target.NroExpediente.Trim().Replace ("\r","")))return false;
			 if((source.FechaLicitacion == null)?(target.FechaLicitacion.HasValue):!source.FechaLicitacion.Equals(target.FechaLicitacion))return false;
			 if((source.FechaContratacion == null)?(target.FechaContratacion.HasValue):!source.FechaContratacion.Equals(target.FechaContratacion))return false;
			 if((source.Contratista == null)?target.Contratista!=null: !( (target.Contratista== String.Empty && source.Contratista== null) || (target.Contratista==null && source.Contratista== String.Empty )) && !source.Contratista.Trim().Replace ("\r","").Equals(target.Contratista.Trim().Replace ("\r","")))return false;
			 if((source.FechaInicioObra == null)?(target.FechaInicioObra.HasValue):!source.FechaInicioObra.Equals(target.FechaInicioObra))return false;
			 if((source.PlazoEjecucion == null)?target.PlazoEjecucion!=null: !( (target.PlazoEjecucion== String.Empty && source.PlazoEjecucion== null) || (target.PlazoEjecucion==null && source.PlazoEjecucion== String.Empty )) && !source.PlazoEjecucion.Trim().Replace ("\r","").Equals(target.PlazoEjecucion.Trim().Replace ("\r","")))return false;
			 if((source.IdMoneda == null)?(target.IdMoneda.HasValue):!source.IdMoneda.Equals(target.IdMoneda))return false;
			 if((source.Magnitud == null)?(target.Magnitud.HasValue):!source.Magnitud.Equals(target.Magnitud))return false;
			 if((source.MontoContrato == null)?(target.MontoContrato.HasValue):!source.MontoContrato.Equals(target.MontoContrato))return false;
			 if((source.MontoVigente == null)?(target.MontoVigente.HasValue):!source.MontoVigente.Equals(target.MontoVigente))return false;
			 if((source.Indicador_IdMedioVerificacion == null)?(target.Indicador_IdMedioVerificacion.HasValue && target.Indicador_IdMedioVerificacion.Value > 0):!source.Indicador_IdMedioVerificacion.Equals(target.Indicador_IdMedioVerificacion))return false;
									  if((source.Indicador_Observacion == null)?target.Indicador_Observacion!=null: !( (target.Indicador_Observacion== String.Empty && source.Indicador_Observacion== null) || (target.Indicador_Observacion==null && source.Indicador_Observacion== String.Empty )) &&   !source.Indicador_Observacion.Trim().Replace ("\r","").Equals(target.Indicador_Observacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoEtapa_Nombre == null)?target.ProyectoEtapa_Nombre!=null: !( (target.ProyectoEtapa_Nombre== String.Empty && source.ProyectoEtapa_Nombre== null) || (target.ProyectoEtapa_Nombre==null && source.ProyectoEtapa_Nombre== String.Empty )) &&   !source.ProyectoEtapa_Nombre.Trim().Replace ("\r","").Equals(target.ProyectoEtapa_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoEtapa_CodigoVinculacion == null)?target.ProyectoEtapa_CodigoVinculacion!=null: !( (target.ProyectoEtapa_CodigoVinculacion== String.Empty && source.ProyectoEtapa_CodigoVinculacion== null) || (target.ProyectoEtapa_CodigoVinculacion==null && source.ProyectoEtapa_CodigoVinculacion== String.Empty )) &&   !source.ProyectoEtapa_CodigoVinculacion.Trim().Replace ("\r","").Equals(target.ProyectoEtapa_CodigoVinculacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoEtapa_IdEstado == null)?(target.ProyectoEtapa_IdEstado.HasValue && target.ProyectoEtapa_IdEstado.Value > 0):!source.ProyectoEtapa_IdEstado.Equals(target.ProyectoEtapa_IdEstado))return false;
									  if((source.ProyectoEtapa_FechaInicioEstimada == null)?(target.ProyectoEtapa_FechaInicioEstimada.HasValue ):!source.ProyectoEtapa_FechaInicioEstimada.Equals(target.ProyectoEtapa_FechaInicioEstimada))return false;
						 if((source.ProyectoEtapa_FechaFinEstimada == null)?(target.ProyectoEtapa_FechaFinEstimada.HasValue ):!source.ProyectoEtapa_FechaFinEstimada.Equals(target.ProyectoEtapa_FechaFinEstimada))return false;
						 if((source.ProyectoEtapa_FechaInicioRealizada == null)?(target.ProyectoEtapa_FechaInicioRealizada.HasValue ):!source.ProyectoEtapa_FechaInicioRealizada.Equals(target.ProyectoEtapa_FechaInicioRealizada))return false;
						 if((source.ProyectoEtapa_FechaFinRealizada == null)?(target.ProyectoEtapa_FechaFinRealizada.HasValue ):!source.ProyectoEtapa_FechaFinRealizada.Equals(target.ProyectoEtapa_FechaFinRealizada))return false;
						 if(!source.ProyectoEtapa_IdEtapa.Equals(target.ProyectoEtapa_IdEtapa))return false;
					  if(!source.ProyectoEtapa_IdProyecto.Equals(target.ProyectoEtapa_IdProyecto))return false;
					  if((source.ProyectoEtapa_NroEtapa == null)?(target.ProyectoEtapa_NroEtapa.HasValue ):!source.ProyectoEtapa_NroEtapa.Equals(target.ProyectoEtapa_NroEtapa))return false;
								
		  return true;
        }
		#endregion
    }
}
