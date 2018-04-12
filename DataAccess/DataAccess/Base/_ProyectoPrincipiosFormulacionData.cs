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
    public abstract class _ProyectoPrincipiosFormulacionData : EntityData<ProyectoPrincipiosFormulacion,ProyectoPrincipiosFormulacionFilter,ProyectoPrincipiosFormulacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoPrincipiosFormulacion entity)
		{			
			return entity.IdProyectoPrincipiosFormulacion;
		}		
		public override ProyectoPrincipiosFormulacion GetByEntity(ProyectoPrincipiosFormulacion entity)
        {
            return this.GetById(entity.IdProyectoPrincipiosFormulacion);
        }
        public override ProyectoPrincipiosFormulacion GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoPrincipiosFormulacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoPrincipiosFormulacion> Query(ProyectoPrincipiosFormulacionFilter filter)
        {
            var q = (from o in this.Table
                    where (filter.IdProyectoPrincipiosFormulacion == null || o.IdProyectoPrincipiosFormulacion >= filter.IdProyectoPrincipiosFormulacion) 
                    && (filter.IdProyectoPrincipiosFormulacion_To == null || o.IdProyectoPrincipiosFormulacion <= filter.IdProyectoPrincipiosFormulacion_To)
                    && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)

                    && (filter.NecesidadASatisfacer == null || filter.NecesidadASatisfacer.Trim() == string.Empty || filter.NecesidadASatisfacer.Trim() == "%" || (filter.NecesidadASatisfacer.EndsWith("%") && filter.NecesidadASatisfacer.StartsWith("%") && (o.NecesidadASatisfacer.Contains(filter.NecesidadASatisfacer.Replace("%", "")))) || (filter.NecesidadASatisfacer.EndsWith("%") && o.NecesidadASatisfacer.StartsWith(filter.NecesidadASatisfacer.Replace("%", ""))) || (filter.NecesidadASatisfacer.StartsWith("%") && o.NecesidadASatisfacer.EndsWith(filter.NecesidadASatisfacer.Replace("%", ""))) || o.NecesidadASatisfacer == filter.NecesidadASatisfacer)
                    && (filter.ObjetivoDelProyecto == null || filter.ObjetivoDelProyecto.Trim() == string.Empty || filter.ObjetivoDelProyecto.Trim() == "%" || (filter.ObjetivoDelProyecto.EndsWith("%") && filter.ObjetivoDelProyecto.StartsWith("%") && (o.ObjetivoDelProyecto.Contains(filter.ObjetivoDelProyecto.Replace("%", "")))) || (filter.ObjetivoDelProyecto.EndsWith("%") && o.ObjetivoDelProyecto.StartsWith(filter.ObjetivoDelProyecto.Replace("%", ""))) || (filter.ObjetivoDelProyecto.StartsWith("%") && o.ObjetivoDelProyecto.EndsWith(filter.ObjetivoDelProyecto.Replace("%", ""))) || o.ObjetivoDelProyecto == filter.ObjetivoDelProyecto)
                    && (filter.ProductoOServicio == null || filter.ProductoOServicio.Trim() == string.Empty || filter.ProductoOServicio.Trim() == "%" || (filter.ProductoOServicio.EndsWith("%") && filter.ProductoOServicio.StartsWith("%") && (o.ProductoOServicio.Contains(filter.ProductoOServicio.Replace("%", "")))) || (filter.ProductoOServicio.EndsWith("%") && o.ProductoOServicio.StartsWith(filter.ProductoOServicio.Replace("%", ""))) || (filter.ProductoOServicio.StartsWith("%") && o.ProductoOServicio.EndsWith(filter.ProductoOServicio.Replace("%", ""))) || o.ProductoOServicio == filter.ProductoOServicio)
                    && (filter.Alternativas == null || filter.Alternativas.Trim() == string.Empty || filter.Alternativas.Trim() == "%" || (filter.Alternativas.EndsWith("%") && filter.Alternativas.StartsWith("%") && (o.Alternativas.Contains(filter.Alternativas.Replace("%", "")))) || (filter.Alternativas.EndsWith("%") && o.Alternativas.StartsWith(filter.Alternativas.Replace("%", ""))) || (filter.Alternativas.StartsWith("%") && o.Alternativas.EndsWith(filter.Alternativas.Replace("%", ""))) || o.Alternativas == filter.Alternativas)
                    && (filter.PorqueAlternativa == null || filter.PorqueAlternativa.Trim() == string.Empty || filter.PorqueAlternativa.Trim() == "%" || (filter.PorqueAlternativa.EndsWith("%") && filter.PorqueAlternativa.StartsWith("%") && (o.PorqueAlternativa.Contains(filter.PorqueAlternativa.Replace("%", "")))) || (filter.PorqueAlternativa.EndsWith("%") && o.PorqueAlternativa.StartsWith(filter.PorqueAlternativa.Replace("%", ""))) || (filter.PorqueAlternativa.StartsWith("%") && o.PorqueAlternativa.EndsWith(filter.PorqueAlternativa.Replace("%", ""))) || o.PorqueAlternativa == filter.PorqueAlternativa)
                    && (filter.DescripcionTecnica == null || filter.DescripcionTecnica.Trim() == string.Empty || filter.DescripcionTecnica.Trim() == "%" || (filter.DescripcionTecnica.EndsWith("%") && filter.DescripcionTecnica.StartsWith("%") && (o.DescripcionTecnica.Contains(filter.DescripcionTecnica.Replace("%", "")))) || (filter.DescripcionTecnica.EndsWith("%") && o.DescripcionTecnica.StartsWith(filter.DescripcionTecnica.Replace("%", ""))) || (filter.DescripcionTecnica.StartsWith("%") && o.DescripcionTecnica.EndsWith(filter.DescripcionTecnica.Replace("%", ""))) || o.DescripcionTecnica == filter.DescripcionTecnica)
                    && (filter.VidaUtil == null || filter.VidaUtil.Trim() == string.Empty || filter.VidaUtil.Trim() == "%" || (filter.VidaUtil.EndsWith("%") && filter.VidaUtil.StartsWith("%") && (o.VidaUtil.Contains(filter.VidaUtil.Replace("%", "")))) || (filter.VidaUtil.EndsWith("%") && o.VidaUtil.StartsWith(filter.VidaUtil.Replace("%", ""))) || (filter.VidaUtil.StartsWith("%") && o.VidaUtil.EndsWith(filter.VidaUtil.Replace("%", ""))) || o.VidaUtil == filter.VidaUtil)
                    && (filter.CoberturaTerritorial == null || filter.CoberturaTerritorial.Trim() == string.Empty || filter.CoberturaTerritorial.Trim() == "%" || (filter.CoberturaTerritorial.EndsWith("%") && filter.CoberturaTerritorial.StartsWith("%") && (o.CoberturaTerritorial.Contains(filter.CoberturaTerritorial.Replace("%", "")))) || (filter.CoberturaTerritorial.EndsWith("%") && o.CoberturaTerritorial.StartsWith(filter.CoberturaTerritorial.Replace("%", ""))) || (filter.CoberturaTerritorial.StartsWith("%") && o.CoberturaTerritorial.EndsWith(filter.CoberturaTerritorial.Replace("%", ""))) || o.CoberturaTerritorial == filter.CoberturaTerritorial)
                    && (filter.CoberturaPoblacional == null || filter.CoberturaPoblacional.Trim() == string.Empty || filter.CoberturaPoblacional.Trim() == "%" || (filter.CoberturaPoblacional.EndsWith("%") && filter.CoberturaPoblacional.StartsWith("%") && (o.CoberturaPoblacional.Contains(filter.CoberturaPoblacional.Replace("%", "")))) || (filter.CoberturaPoblacional.EndsWith("%") && o.CoberturaPoblacional.StartsWith(filter.CoberturaPoblacional.Replace("%", ""))) || (filter.CoberturaPoblacional.StartsWith("%") && o.CoberturaPoblacional.EndsWith(filter.CoberturaPoblacional.Replace("%", ""))) || o.CoberturaPoblacional == filter.CoberturaPoblacional)
                    && (filter.CoberturaBeneficiariosDirectos == null || filter.CoberturaBeneficiariosDirectos.Trim() == string.Empty || filter.CoberturaBeneficiariosDirectos.Trim() == "%" || (filter.CoberturaBeneficiariosDirectos.EndsWith("%") && filter.CoberturaBeneficiariosDirectos.StartsWith("%") && (o.CoberturaBeneficiariosDirectos.Contains(filter.CoberturaBeneficiariosDirectos.Replace("%", "")))) || (filter.CoberturaBeneficiariosDirectos.EndsWith("%") && o.CoberturaBeneficiariosDirectos.StartsWith(filter.CoberturaBeneficiariosDirectos.Replace("%", ""))) || (filter.CoberturaBeneficiariosDirectos.StartsWith("%") && o.CoberturaBeneficiariosDirectos.EndsWith(filter.CoberturaBeneficiariosDirectos.Replace("%", ""))) || o.CoberturaBeneficiariosDirectos == filter.CoberturaBeneficiariosDirectos)
                    && (filter.CoberturaBeneficiariosIndirectos == null || filter.CoberturaBeneficiariosIndirectos.Trim() == string.Empty || filter.CoberturaBeneficiariosIndirectos.Trim() == "%" || (filter.CoberturaBeneficiariosIndirectos.EndsWith("%") && filter.CoberturaBeneficiariosIndirectos.StartsWith("%") && (o.CoberturaBeneficiariosIndirectos.Contains(filter.CoberturaBeneficiariosIndirectos.Replace("%", "")))) || (filter.CoberturaBeneficiariosIndirectos.EndsWith("%") && o.CoberturaBeneficiariosIndirectos.StartsWith(filter.CoberturaBeneficiariosIndirectos.Replace("%", ""))) || (filter.CoberturaBeneficiariosIndirectos.StartsWith("%") && o.CoberturaBeneficiariosIndirectos.EndsWith(filter.CoberturaBeneficiariosIndirectos.Replace("%", ""))) || o.CoberturaBeneficiariosIndirectos == filter.CoberturaBeneficiariosIndirectos)

                    && (filter.DificultadesRiesgos == null || o.DificultadesRiesgos == filter.DificultadesRiesgos)
                    && (filter.DificultadesRiesgosEnumeracion == null || filter.DificultadesRiesgosEnumeracion.Trim() == string.Empty || filter.DificultadesRiesgosEnumeracion.Trim() == "%" || (filter.DificultadesRiesgosEnumeracion.EndsWith("%") && filter.DificultadesRiesgosEnumeracion.StartsWith("%") && (o.DificultadesRiesgosEnumeracion.Contains(filter.DificultadesRiesgosEnumeracion.Replace("%", "")))) || (filter.DificultadesRiesgosEnumeracion.EndsWith("%") && o.DificultadesRiesgosEnumeracion.StartsWith(filter.DificultadesRiesgosEnumeracion.Replace("%", ""))) || (filter.DificultadesRiesgosEnumeracion.StartsWith("%") && o.DificultadesRiesgosEnumeracion.EndsWith(filter.DificultadesRiesgosEnumeracion.Replace("%", ""))) || o.DificultadesRiesgosEnumeracion == filter.DificultadesRiesgosEnumeracion)

                    && (filter.DimensionesCostosDimensionados == null || o.DimensionesCostosDimensionados == filter.DimensionesCostosDimensionados)
                    && (filter.DimensionesCostosValidados == null || o.DimensionesCostosValidados == filter.DimensionesCostosValidados)
                    && (filter.DimensionesCostosEnte == null || filter.DimensionesCostosEnte.Trim() == string.Empty || filter.DimensionesCostosEnte.Trim() == "%" || (filter.DimensionesCostosEnte.EndsWith("%") && filter.DimensionesCostosEnte.StartsWith("%") && (o.DimensionesCostosEnte.Contains(filter.DimensionesCostosEnte.Replace("%", "")))) || (filter.DimensionesCostosEnte.EndsWith("%") && o.DimensionesCostosEnte.StartsWith(filter.DimensionesCostosEnte.Replace("%", ""))) || (filter.DimensionesCostosEnte.StartsWith("%") && o.DimensionesCostosEnte.EndsWith(filter.DimensionesCostosEnte.Replace("%", ""))) || o.DimensionesCostosEnte == filter.DimensionesCostosEnte)
                    && (filter.RequiereIntevencion == null || o.RequiereIntevencion == filter.RequiereIntevencion)
                    && (filter.RequiereIntevencionAutoridad == null || filter.RequiereIntevencionAutoridad.Trim() == string.Empty || filter.RequiereIntevencionAutoridad.Trim() == "%" || (filter.RequiereIntevencionAutoridad.EndsWith("%") && filter.RequiereIntevencionAutoridad.StartsWith("%") && (o.RequiereIntevencionAutoridad.Contains(filter.RequiereIntevencionAutoridad.Replace("%", "")))) || (filter.RequiereIntevencionAutoridad.EndsWith("%") && o.RequiereIntevencionAutoridad.StartsWith(filter.RequiereIntevencionAutoridad.Replace("%", ""))) || (filter.RequiereIntevencionAutoridad.StartsWith("%") && o.RequiereIntevencionAutoridad.EndsWith(filter.RequiereIntevencionAutoridad.Replace("%", ""))) || o.RequiereIntevencionAutoridad == filter.RequiereIntevencionAutoridad)
                    && (filter.RequiereIntevencionEstado == null || filter.RequiereIntevencionEstado == 0 || o.RequiereIntevencionEstado == filter.RequiereIntevencionEstado)

                    select o
                    ).AsQueryable();
            return q;
        }	
        protected override IQueryable<ProyectoPrincipiosFormulacionResult> QueryResult(ProyectoPrincipiosFormulacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Proyectos on o.IdProyecto equals t1.IdProyecto   
				   select new ProyectoPrincipiosFormulacionResult(){
					 IdProyectoPrincipiosFormulacion=o.IdProyectoPrincipiosFormulacion
					 ,IdProyecto=o.IdProyecto
					 ,NecesidadASatisfacer=o.NecesidadASatisfacer
                     ,ObjetivoDelProyecto=o.ObjetivoDelProyecto
					 ,ProductoOServicio=o.ProductoOServicio
					 ,Alternativas=o.Alternativas
					 ,PorqueAlternativa=o.PorqueAlternativa
					 ,DescripcionTecnica=o.DescripcionTecnica
					 ,VidaUtil=o.VidaUtil
					 ,CoberturaTerritorial=o.CoberturaTerritorial
					 ,CoberturaPoblacional=o.CoberturaPoblacional
					 ,CoberturaBeneficiariosDirectos=o.CoberturaBeneficiariosDirectos
                     ,CoberturaBeneficiariosIndirectos = o.CoberturaBeneficiariosIndirectos
					 ,DificultadesRiesgos=o.DificultadesRiesgos
                     ,
                     DificultadesRiesgosEnumeracion = o.DificultadesRiesgosEnumeracion,
                     DimensionesCostosDimensionados = o.DimensionesCostosDimensionados,
                     DimensionesCostosValidados = o.DimensionesCostosValidados,
                     DimensionesCostosEnte = o.DimensionesCostosEnte,
                     RequiereIntevencion = o.RequiereIntevencion,
                     RequiereIntevencionAutoridad = o.RequiereIntevencionAutoridad,
                     RequiereIntevencionEstado = o.RequiereIntevencionEstado
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoPrincipiosFormulacion Copy(nc.ProyectoPrincipiosFormulacion entity)
        {
            nc.ProyectoPrincipiosFormulacion _new = new nc.ProyectoPrincipiosFormulacion();
		    _new.IdProyecto= entity.IdProyecto;
		    _new.NecesidadASatisfacer= entity.NecesidadASatisfacer;
            _new.ObjetivoDelProyecto = entity.ObjetivoDelProyecto;
		    _new.ProductoOServicio= entity.ProductoOServicio;
		    _new.Alternativas= entity.Alternativas;
		    _new.PorqueAlternativa= entity.PorqueAlternativa;
		    _new.DescripcionTecnica= entity.DescripcionTecnica;
		    _new.VidaUtil= entity.VidaUtil;
		    _new.CoberturaTerritorial= entity.CoberturaTerritorial;
		    _new.CoberturaPoblacional= entity.CoberturaPoblacional;
		    _new.CoberturaBeneficiariosDirectos= entity.CoberturaBeneficiariosDirectos;
            _new.CoberturaBeneficiariosIndirectos = entity.CoberturaBeneficiariosIndirectos;
            _new.DificultadesRiesgos = entity.DificultadesRiesgos;
            _new.DificultadesRiesgosEnumeracion = entity.DificultadesRiesgosEnumeracion;
            _new.DimensionesCostosDimensionados = entity.DimensionesCostosDimensionados;
            _new.DimensionesCostosValidados = entity.DimensionesCostosValidados;
            _new.DimensionesCostosEnte = entity.DimensionesCostosEnte;
            _new.RequiereIntevencion = entity.RequiereIntevencion;
            _new.RequiereIntevencionAutoridad = entity.RequiereIntevencionAutoridad;
            _new.RequiereIntevencionEstado = entity.RequiereIntevencionEstado;
            _new.ObservacionesDNIP = entity.ObservacionesDNIP;

            return _new;			
        }
		public override int CopyAndSave(ProyectoPrincipiosFormulacion entity,string renameFormat)
        {
            ProyectoPrincipiosFormulacion  newEntity = Copy(entity);
            newEntity.NecesidadASatisfacer = string.Format(renameFormat,newEntity.NecesidadASatisfacer);
            newEntity.ObjetivoDelProyecto = string.Format(renameFormat,newEntity.ObjetivoDelProyecto);
            newEntity.ProductoOServicio = string.Format(renameFormat,newEntity.ProductoOServicio);
            newEntity.Alternativas = string.Format(renameFormat,newEntity.Alternativas);
            newEntity.PorqueAlternativa = string.Format(renameFormat,newEntity.PorqueAlternativa);
            newEntity.DescripcionTecnica = string.Format(renameFormat,newEntity.DescripcionTecnica);
            newEntity.VidaUtil = string.Format(renameFormat,newEntity.VidaUtil);
            newEntity.CoberturaTerritorial = string.Format(renameFormat,newEntity.CoberturaTerritorial);
            newEntity.CoberturaPoblacional = string.Format(renameFormat,newEntity.CoberturaPoblacional);
            newEntity.CoberturaBeneficiariosDirectos = string.Format(renameFormat,newEntity.CoberturaBeneficiariosDirectos);
            newEntity.CoberturaBeneficiariosIndirectos = string.Format(renameFormat,newEntity.CoberturaBeneficiariosIndirectos);
            newEntity.DificultadesRiesgos = newEntity.DificultadesRiesgos;
            newEntity.DificultadesRiesgosEnumeracion = string.Format(renameFormat,newEntity.DificultadesRiesgosEnumeracion);
            newEntity.DimensionesCostosDimensionados = newEntity.DimensionesCostosDimensionados;
            newEntity.DimensionesCostosValidados = newEntity.DimensionesCostosValidados;
            newEntity.DimensionesCostosEnte = string.Format(renameFormat,newEntity.DimensionesCostosEnte);
            newEntity.RequiereIntevencion = newEntity.RequiereIntevencion;
            newEntity.RequiereIntevencionAutoridad = string.Format(renameFormat,newEntity.RequiereIntevencionAutoridad);
            newEntity.RequiereIntevencionEstado = newEntity.RequiereIntevencionEstado;
            newEntity.ObservacionesDNIP = string.Format(renameFormat,newEntity.ObservacionesDNIP);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoPrincipiosFormulacion entity, int id)
        {            
            entity.IdProyectoPrincipiosFormulacion = id;            
        }
		public override void Set(ProyectoPrincipiosFormulacion source,ProyectoPrincipiosFormulacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrincipiosFormulacion= source.IdProyectoPrincipiosFormulacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NecesidadASatisfacer= source.NecesidadASatisfacer ;
         target.ObjetivoDelProyecto = source.ObjetivoDelProyecto;
		 target.ProductoOServicio= source.ProductoOServicio ;
		 target.Alternativas= source.Alternativas ;
		 target.PorqueAlternativa= source.PorqueAlternativa ;
		 target.DescripcionTecnica= source.DescripcionTecnica ;
		 target.VidaUtil= source.VidaUtil ;
		 target.CoberturaTerritorial= source.CoberturaTerritorial ;
		 target.CoberturaPoblacional= source.CoberturaPoblacional ;
		 target.CoberturaBeneficiariosDirectos= source.CoberturaBeneficiariosDirectos ;
         target.CoberturaBeneficiariosIndirectos = source.CoberturaBeneficiariosIndirectos;
		 target.DificultadesRiesgos= source.DificultadesRiesgos ;
         target.DificultadesRiesgosEnumeracion = source.DificultadesRiesgosEnumeracion;
         target.DimensionesCostosDimensionados = source.DimensionesCostosDimensionados;
         target.DimensionesCostosValidados = source.DimensionesCostosValidados;
         target.DimensionesCostosEnte = source.DimensionesCostosEnte;
         target.RequiereIntevencion = source.RequiereIntevencion;
         target.RequiereIntevencionAutoridad = source.RequiereIntevencionAutoridad;
         target.RequiereIntevencionEstado = source.RequiereIntevencionEstado;
         target.ObservacionesDNIP = source.ObservacionesDNIP;  
		}
		public override void Set(ProyectoPrincipiosFormulacionResult source,ProyectoPrincipiosFormulacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrincipiosFormulacion= source.IdProyectoPrincipiosFormulacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NecesidadASatisfacer= source.NecesidadASatisfacer ;
         target.ObjetivoDelProyecto = source.ObjetivoDelProyecto;
		 target.ProductoOServicio= source.ProductoOServicio ;
		 target.Alternativas= source.Alternativas ;
		 target.PorqueAlternativa= source.PorqueAlternativa ;
		 target.DescripcionTecnica= source.DescripcionTecnica ;
		 target.VidaUtil= source.VidaUtil ;
		 target.CoberturaTerritorial= source.CoberturaTerritorial ;
		 target.CoberturaPoblacional= source.CoberturaPoblacional ;
		 target.CoberturaBeneficiariosDirectos= source.CoberturaBeneficiariosDirectos ;
         target.CoberturaBeneficiariosIndirectos = source.CoberturaBeneficiariosIndirectos;
		 target.DificultadesRiesgos= source.DificultadesRiesgos ;
         target.DificultadesRiesgosEnumeracion = source.DificultadesRiesgosEnumeracion;
         target.DimensionesCostosDimensionados = source.DimensionesCostosDimensionados;
         target.DimensionesCostosValidados = source.DimensionesCostosValidados;
         target.DimensionesCostosEnte = source.DimensionesCostosEnte;
         target.RequiereIntevencion = source.RequiereIntevencion;
         target.RequiereIntevencionAutoridad = source.RequiereIntevencionAutoridad;
         target.RequiereIntevencionEstado = source.RequiereIntevencionEstado;
         target.ObservacionesDNIP = source.ObservacionesDNIP;  
		}
		public override void Set(ProyectoPrincipiosFormulacion source,ProyectoPrincipiosFormulacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrincipiosFormulacion= source.IdProyectoPrincipiosFormulacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NecesidadASatisfacer= source.NecesidadASatisfacer ;
         target.ObjetivoDelProyecto = source.ObjetivoDelProyecto;
		 target.ProductoOServicio= source.ProductoOServicio ;
		 target.Alternativas= source.Alternativas ;
		 target.PorqueAlternativa= source.PorqueAlternativa ;
		 target.DescripcionTecnica= source.DescripcionTecnica ;
		 target.VidaUtil= source.VidaUtil ;
		 target.CoberturaTerritorial= source.CoberturaTerritorial ;
		 target.CoberturaPoblacional= source.CoberturaPoblacional ;
		 target.CoberturaBeneficiariosDirectos= source.CoberturaBeneficiariosDirectos ;
         target.CoberturaBeneficiariosIndirectos = source.CoberturaBeneficiariosIndirectos;
		 target.DificultadesRiesgos= source.DificultadesRiesgos ;
         target.DificultadesRiesgosEnumeracion = source.DificultadesRiesgosEnumeracion;
         target.DimensionesCostosDimensionados = source.DimensionesCostosDimensionados;
         target.DimensionesCostosValidados = source.DimensionesCostosValidados;
         target.DimensionesCostosEnte = source.DimensionesCostosEnte;
         target.RequiereIntevencion = source.RequiereIntevencion;
         target.RequiereIntevencionAutoridad = source.RequiereIntevencionAutoridad;
         target.RequiereIntevencionEstado = source.RequiereIntevencionEstado;
         target.ObservacionesDNIP = source.ObservacionesDNIP;  
		}		
		public override void Set(ProyectoPrincipiosFormulacionResult source,ProyectoPrincipiosFormulacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrincipiosFormulacion= source.IdProyectoPrincipiosFormulacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.NecesidadASatisfacer= source.NecesidadASatisfacer ;
         target.ObjetivoDelProyecto = source.ObjetivoDelProyecto;
		 target.ProductoOServicio= source.ProductoOServicio ;
		 target.Alternativas= source.Alternativas ;
		 target.PorqueAlternativa= source.PorqueAlternativa ;
		 target.DescripcionTecnica= source.DescripcionTecnica ;
		 target.VidaUtil= source.VidaUtil ;
		 target.CoberturaTerritorial= source.CoberturaTerritorial ;
		 target.CoberturaPoblacional= source.CoberturaPoblacional ;
		 target.CoberturaBeneficiariosDirectos= source.CoberturaBeneficiariosDirectos ;
         target.CoberturaBeneficiariosIndirectos = source.CoberturaBeneficiariosIndirectos;
         target.DificultadesRiesgos = source.DificultadesRiesgos;
         target.DificultadesRiesgosEnumeracion = source.DificultadesRiesgosEnumeracion;
         target.DimensionesCostosDimensionados = source.DimensionesCostosDimensionados;
         target.DimensionesCostosValidados = source.DimensionesCostosValidados;
         target.DimensionesCostosEnte = source.DimensionesCostosEnte;
         target.RequiereIntevencion = source.RequiereIntevencion;
         target.RequiereIntevencionAutoridad = source.RequiereIntevencionAutoridad;
         target.RequiereIntevencionEstado = source.RequiereIntevencionEstado;
         target.ObservacionesDNIP = source.ObservacionesDNIP;  
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoPrincipiosFormulacion source,ProyectoPrincipiosFormulacion target)
        {
            if(source == null && target == null)return true;
		    if(source == null )return false;
		    if(target == null)return false;
            if(!source.IdProyectoPrincipiosFormulacion.Equals(target.IdProyectoPrincipiosFormulacion))return false;
		    if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		    if((source.NecesidadASatisfacer == null)?target.NecesidadASatisfacer!=null:  !( (target.NecesidadASatisfacer== String.Empty && source.NecesidadASatisfacer== null) || (target.NecesidadASatisfacer==null && source.NecesidadASatisfacer== String.Empty )) &&  !source.NecesidadASatisfacer.Trim().Replace ("\r","").Equals(target.NecesidadASatisfacer.Trim().Replace ("\r","")))return false;
            if ((source.ObjetivoDelProyecto == null) ? target.ObjetivoDelProyecto != null : !((target.ObjetivoDelProyecto == String.Empty && source.ObjetivoDelProyecto == null) || (target.ObjetivoDelProyecto == null && source.ObjetivoDelProyecto == String.Empty)) && !source.ObjetivoDelProyecto.Trim().Replace("\r", "").Equals(target.ObjetivoDelProyecto.Trim().Replace("\r", ""))) return false;
			if((source.ProductoOServicio == null)?target.ProductoOServicio!=null:  !( (target.ProductoOServicio== String.Empty && source.ProductoOServicio== null) || (target.ProductoOServicio==null && source.ProductoOServicio== String.Empty )) &&  !source.ProductoOServicio.Trim().Replace ("\r","").Equals(target.ProductoOServicio.Trim().Replace ("\r","")))return false;
			if((source.Alternativas == null)?target.Alternativas!=null:  !( (target.Alternativas== String.Empty && source.Alternativas== null) || (target.Alternativas==null && source.Alternativas== String.Empty )) &&  !source.Alternativas.Trim().Replace ("\r","").Equals(target.Alternativas.Trim().Replace ("\r","")))return false;
			if((source.PorqueAlternativa == null)?target.PorqueAlternativa!=null:  !( (target.PorqueAlternativa== String.Empty && source.PorqueAlternativa== null) || (target.PorqueAlternativa==null && source.PorqueAlternativa== String.Empty )) &&  !source.PorqueAlternativa.Trim().Replace ("\r","").Equals(target.PorqueAlternativa.Trim().Replace ("\r","")))return false;
			if((source.DescripcionTecnica == null)?target.DescripcionTecnica!=null:  !( (target.DescripcionTecnica== String.Empty && source.DescripcionTecnica== null) || (target.DescripcionTecnica==null && source.DescripcionTecnica== String.Empty )) &&  !source.DescripcionTecnica.Trim().Replace ("\r","").Equals(target.DescripcionTecnica.Trim().Replace ("\r","")))return false;
			if((source.VidaUtil == null)?target.VidaUtil!=null:  !( (target.VidaUtil== String.Empty && source.VidaUtil== null) || (target.VidaUtil==null && source.VidaUtil== String.Empty )) &&  !source.VidaUtil.Trim().Replace ("\r","").Equals(target.VidaUtil.Trim().Replace ("\r","")))return false;
			if((source.CoberturaTerritorial == null)?target.CoberturaTerritorial!=null:  !( (target.CoberturaTerritorial== String.Empty && source.CoberturaTerritorial== null) || (target.CoberturaTerritorial==null && source.CoberturaTerritorial== String.Empty )) &&  !source.CoberturaTerritorial.Trim().Replace ("\r","").Equals(target.CoberturaTerritorial.Trim().Replace ("\r","")))return false;
			if((source.CoberturaPoblacional == null)?target.CoberturaPoblacional!=null:  !( (target.CoberturaPoblacional== String.Empty && source.CoberturaPoblacional== null) || (target.CoberturaPoblacional==null && source.CoberturaPoblacional== String.Empty )) &&  !source.CoberturaPoblacional.Trim().Replace ("\r","").Equals(target.CoberturaPoblacional.Trim().Replace ("\r","")))return false;
            if ((source.CoberturaBeneficiariosDirectos == null) ? target.CoberturaBeneficiariosDirectos != null : !((target.CoberturaBeneficiariosDirectos == String.Empty && source.CoberturaBeneficiariosDirectos == null) || (target.CoberturaBeneficiariosDirectos == null && source.CoberturaBeneficiariosDirectos == String.Empty)) && !source.CoberturaBeneficiariosDirectos.Trim().Replace("\r", "").Equals(target.CoberturaBeneficiariosDirectos.Trim().Replace("\r", ""))) return false;
            if ((source.CoberturaBeneficiariosIndirectos == null) ? target.CoberturaBeneficiariosIndirectos != null : !((target.CoberturaBeneficiariosIndirectos == String.Empty && source.CoberturaBeneficiariosIndirectos == null) || (target.CoberturaBeneficiariosIndirectos == null && source.CoberturaBeneficiariosIndirectos == String.Empty)) && !source.CoberturaBeneficiariosIndirectos.Trim().Replace("\r", "").Equals(target.CoberturaBeneficiariosIndirectos.Trim().Replace("\r", ""))) return false;	
			if((source.DificultadesRiesgos == null)?(target.DificultadesRiesgos.HasValue):!source.DificultadesRiesgos.Equals(target.DificultadesRiesgos))return false;

            if ((source.DificultadesRiesgosEnumeracion == null) ? target.DificultadesRiesgosEnumeracion != null : !((target.DificultadesRiesgosEnumeracion == String.Empty && source.DificultadesRiesgosEnumeracion == null) || (target.DificultadesRiesgosEnumeracion == null && source.DificultadesRiesgosEnumeracion == String.Empty)) && !source.DificultadesRiesgosEnumeracion.Trim().Replace("\r", "").Equals(target.DificultadesRiesgosEnumeracion.Trim().Replace("\r", ""))) return false;
            if ((source.DimensionesCostosDimensionados == null) ? (target.DimensionesCostosDimensionados.HasValue) : !source.DimensionesCostosDimensionados.Equals(target.DimensionesCostosDimensionados)) return false;
            if ((source.DimensionesCostosValidados == null) ? (target.DimensionesCostosValidados.HasValue) : !source.DimensionesCostosValidados.Equals(target.DimensionesCostosValidados)) return false;
            if ((source.DimensionesCostosEnte == null) ? target.DimensionesCostosEnte != null : !((target.DimensionesCostosEnte == String.Empty && source.DimensionesCostosEnte == null) || (target.DimensionesCostosEnte == null && source.DimensionesCostosEnte == String.Empty)) && !source.DimensionesCostosEnte.Trim().Replace("\r", "").Equals(target.DimensionesCostosEnte.Trim().Replace("\r", ""))) return false;
            if ((source.RequiereIntevencion == null) ? (target.RequiereIntevencion.HasValue) : !source.RequiereIntevencion.Equals(target.RequiereIntevencion)) return false;
            if ((source.RequiereIntevencionAutoridad == null) ? target.RequiereIntevencionAutoridad != null : !((target.RequiereIntevencionAutoridad == String.Empty && source.RequiereIntevencionAutoridad == null) || (target.RequiereIntevencionAutoridad == null && source.RequiereIntevencionAutoridad == String.Empty)) && !source.RequiereIntevencionAutoridad.Trim().Replace("\r", "").Equals(target.RequiereIntevencionAutoridad.Trim().Replace("\r", ""))) return false;
            if ((source.RequiereIntevencionEstado == null) ? (target.RequiereIntevencionEstado.HasValue) : !source.RequiereIntevencionEstado.Equals(target.RequiereIntevencionEstado)) return false;
            if ((source.ObservacionesDNIP == null) ? target.ObservacionesDNIP != null : !((target.ObservacionesDNIP == String.Empty && source.ObservacionesDNIP == null) || (target.ObservacionesDNIP == null && source.ObservacionesDNIP == String.Empty)) && !source.ObservacionesDNIP.Trim().Replace("\r", "").Equals(target.ObservacionesDNIP.Trim().Replace("\r", ""))) return false;
		  return true;
        }
		public override bool Equals(ProyectoPrincipiosFormulacionResult source,ProyectoPrincipiosFormulacionResult target)
        {
		    if(source == null && target == null)return true;
		    if(source == null )return false;

            if (target == null)
            {
                if (source.NecesidadASatisfacer != null && source.NecesidadASatisfacer != String.Empty) return false;
                if (source.ObjetivoDelProyecto != null && source.ObjetivoDelProyecto != String.Empty) return false;
                if (source.ProductoOServicio != null && source.ProductoOServicio != String.Empty) return false;
                if (source.Alternativas != null && source.Alternativas != String.Empty) return false;
                if (source.PorqueAlternativa != null && source.PorqueAlternativa != String.Empty) return false;
                if (source.DescripcionTecnica != null && source.DescripcionTecnica != String.Empty) return false;
                if (source.VidaUtil != null && source.VidaUtil != String.Empty) return false;
                if (source.CoberturaTerritorial != null && source.CoberturaTerritorial != String.Empty) return false;
                if (source.CoberturaPoblacional != null && source.CoberturaPoblacional != String.Empty) return false;
                if (source.CoberturaBeneficiariosDirectos != null && source.CoberturaBeneficiariosDirectos != String.Empty) return false;
                if (source.CoberturaBeneficiariosIndirectos != null && source.CoberturaBeneficiariosIndirectos != String.Empty) return false;

                if (source.DificultadesRiesgos.HasValue && source.DificultadesRiesgos != false) return false;   //false initial value             
                if (source.DificultadesRiesgosEnumeracion != null && source.DificultadesRiesgosEnumeracion != String.Empty) return false;

                if (source.DimensionesCostosDimensionados.HasValue && source.DimensionesCostosDimensionados != false) return false;   //false initial value 
                if (source.DimensionesCostosValidados.HasValue && source.DimensionesCostosValidados != false) return false;   //false initial value 
                if (source.DimensionesCostosEnte != null && source.DimensionesCostosEnte != String.Empty) return false;

                
                if (source.RequiereIntevencion.HasValue && source.RequiereIntevencion != false) return false;   //false initial value 
                if (source.RequiereIntevencionAutoridad != null && source.RequiereIntevencionAutoridad != String.Empty) return false;
                if (source.RequiereIntevencionEstado != null && !source.RequiereIntevencionEstado.Equals(target.RequiereIntevencionEstado)) return false;
                if (source.ObservacionesDNIP != null && source.ObservacionesDNIP != String.Empty) return false;
                return true;
            }

            if(!source.IdProyectoPrincipiosFormulacion.Equals(target.IdProyectoPrincipiosFormulacion))return false;
		    if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		    if((source.NecesidadASatisfacer == null)?target.NecesidadASatisfacer!=null: !( (target.NecesidadASatisfacer== String.Empty && source.NecesidadASatisfacer== null) || (target.NecesidadASatisfacer==null && source.NecesidadASatisfacer== String.Empty )) && !source.NecesidadASatisfacer.Trim().Replace ("\r","").Equals(target.NecesidadASatisfacer.Trim().Replace ("\r","")))return false;
            if ((source.ObjetivoDelProyecto == null) ? target.ObjetivoDelProyecto != null : !((target.ObjetivoDelProyecto == String.Empty && source.ObjetivoDelProyecto == null) || (target.ObjetivoDelProyecto == null && source.ObjetivoDelProyecto == String.Empty)) && !source.ObjetivoDelProyecto.Trim().Replace("\r", "").Equals(target.ObjetivoDelProyecto.Trim().Replace("\r", ""))) return false;
			if((source.ProductoOServicio == null)?target.ProductoOServicio!=null: !( (target.ProductoOServicio== String.Empty && source.ProductoOServicio== null) || (target.ProductoOServicio==null && source.ProductoOServicio== String.Empty )) && !source.ProductoOServicio.Trim().Replace ("\r","").Equals(target.ProductoOServicio.Trim().Replace ("\r","")))return false;
			if((source.Alternativas == null)?target.Alternativas!=null: !( (target.Alternativas== String.Empty && source.Alternativas== null) || (target.Alternativas==null && source.Alternativas== String.Empty )) && !source.Alternativas.Trim().Replace ("\r","").Equals(target.Alternativas.Trim().Replace ("\r","")))return false;
			if((source.PorqueAlternativa == null)?target.PorqueAlternativa!=null: !( (target.PorqueAlternativa== String.Empty && source.PorqueAlternativa== null) || (target.PorqueAlternativa==null && source.PorqueAlternativa== String.Empty )) && !source.PorqueAlternativa.Trim().Replace ("\r","").Equals(target.PorqueAlternativa.Trim().Replace ("\r","")))return false;
			if((source.DescripcionTecnica == null)?target.DescripcionTecnica!=null: !( (target.DescripcionTecnica== String.Empty && source.DescripcionTecnica== null) || (target.DescripcionTecnica==null && source.DescripcionTecnica== String.Empty )) && !source.DescripcionTecnica.Trim().Replace ("\r","").Equals(target.DescripcionTecnica.Trim().Replace ("\r","")))return false;
			if((source.VidaUtil == null)?target.VidaUtil!=null: !( (target.VidaUtil== String.Empty && source.VidaUtil== null) || (target.VidaUtil==null && source.VidaUtil== String.Empty )) && !source.VidaUtil.Trim().Replace ("\r","").Equals(target.VidaUtil.Trim().Replace ("\r","")))return false;
			if((source.CoberturaTerritorial == null)?target.CoberturaTerritorial!=null: !( (target.CoberturaTerritorial== String.Empty && source.CoberturaTerritorial== null) || (target.CoberturaTerritorial==null && source.CoberturaTerritorial== String.Empty )) && !source.CoberturaTerritorial.Trim().Replace ("\r","").Equals(target.CoberturaTerritorial.Trim().Replace ("\r","")))return false;
			if((source.CoberturaPoblacional == null)?target.CoberturaPoblacional!=null: !( (target.CoberturaPoblacional== String.Empty && source.CoberturaPoblacional== null) || (target.CoberturaPoblacional==null && source.CoberturaPoblacional== String.Empty )) && !source.CoberturaPoblacional.Trim().Replace ("\r","").Equals(target.CoberturaPoblacional.Trim().Replace ("\r","")))return false;
            if ((source.CoberturaBeneficiariosDirectos == null) ? target.CoberturaBeneficiariosDirectos != null : !((target.CoberturaBeneficiariosDirectos == String.Empty && source.CoberturaBeneficiariosDirectos == null) || (target.CoberturaBeneficiariosDirectos == null && source.CoberturaBeneficiariosDirectos == String.Empty)) && !source.CoberturaBeneficiariosDirectos.Trim().Replace("\r", "").Equals(target.CoberturaBeneficiariosDirectos.Trim().Replace("\r", ""))) return false;
            if ((source.CoberturaBeneficiariosDirectos == null) ? target.CoberturaBeneficiariosDirectos != null : !((target.CoberturaBeneficiariosDirectos == String.Empty && source.CoberturaBeneficiariosDirectos == null) || (target.CoberturaBeneficiariosDirectos == null && source.CoberturaBeneficiariosDirectos == String.Empty)) && !source.CoberturaBeneficiariosIndirectos.Trim().Replace("\r", "").Equals(target.CoberturaBeneficiariosIndirectos.Trim().Replace("\r", ""))) return false;
            if ((source.DificultadesRiesgos == null) ? (target.DificultadesRiesgos.HasValue) : !source.DificultadesRiesgos.Equals(target.DificultadesRiesgos)) return false;

            if ((source.DificultadesRiesgosEnumeracion == null) ? target.DificultadesRiesgosEnumeracion != null : !((target.DificultadesRiesgosEnumeracion == String.Empty && source.DificultadesRiesgosEnumeracion == null) || (target.DificultadesRiesgosEnumeracion == null && source.DificultadesRiesgosEnumeracion == String.Empty)) && !source.DificultadesRiesgosEnumeracion.Trim().Replace("\r", "").Equals(target.DificultadesRiesgosEnumeracion.Trim().Replace("\r", ""))) return false;
            if ((source.DimensionesCostosDimensionados == null) ? (target.DimensionesCostosDimensionados.HasValue) : !source.DimensionesCostosDimensionados.Equals(target.DimensionesCostosDimensionados)) return false;
            if ((source.DimensionesCostosValidados == null) ? (target.DimensionesCostosValidados.HasValue) : !source.DimensionesCostosValidados.Equals(target.DimensionesCostosValidados)) return false;
            if ((source.DimensionesCostosEnte == null) ? target.DimensionesCostosEnte != null : !((target.DimensionesCostosEnte == String.Empty && source.DimensionesCostosEnte == null) || (target.DimensionesCostosEnte == null && source.DimensionesCostosEnte == String.Empty)) && !source.DimensionesCostosEnte.Trim().Replace("\r", "").Equals(target.DimensionesCostosEnte.Trim().Replace("\r", ""))) return false;
            if ((source.RequiereIntevencion == null) ? (target.RequiereIntevencion.HasValue) : !source.RequiereIntevencion.Equals(target.RequiereIntevencion)) return false;
            if ((source.RequiereIntevencionAutoridad == null) ? target.RequiereIntevencionAutoridad != null : !((target.RequiereIntevencionAutoridad == String.Empty && source.RequiereIntevencionAutoridad == null) || (target.RequiereIntevencionAutoridad == null && source.RequiereIntevencionAutoridad == String.Empty)) && !source.RequiereIntevencionAutoridad.Trim().Replace("\r", "").Equals(target.RequiereIntevencionAutoridad.Trim().Replace("\r", ""))) return false;
            if ((source.RequiereIntevencionEstado == null) ? (target.RequiereIntevencionEstado.HasValue) : !source.RequiereIntevencionEstado.Equals(target.RequiereIntevencionEstado)) return false;

            if(!source._Proyecto_IdTipoProyecto.Equals(target._Proyecto_IdTipoProyecto))return false;

            if ((source.ObservacionesDNIP == null) ? target.ObservacionesDNIP != null : !((target.ObservacionesDNIP == String.Empty && source.ObservacionesDNIP == null) || (target.ObservacionesDNIP == null && source.ObservacionesDNIP == String.Empty)) && !source.ObservacionesDNIP.Trim().Replace("\r", "").Equals(target.ObservacionesDNIP.Trim().Replace("\r", ""))) return false;
		  return true;
        }
		#endregion
    }
}
