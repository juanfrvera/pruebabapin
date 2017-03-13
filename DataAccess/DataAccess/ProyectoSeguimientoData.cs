using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract; 
namespace DataAccess
{
    public class ProyectoSeguimientoData : EntityData<ProyectoSeguimiento, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
    {
        
       #region Singleton
	   private static volatile ProyectoSeguimientoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoData() {}
	   public static ProyectoSeguimientoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override string IdFieldName { get { return "IdProyectoSeguimiento"; } }
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.ProyectoSeguimiento entity)
        {
            return entity.IdProyectoSeguimiento;
        }
        public override ProyectoSeguimiento GetByEntity(ProyectoSeguimiento entity)
        {
            return this.GetById(entity.IdProyectoSeguimiento);
        }
        public override ProyectoSeguimiento GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoSeguimiento == id select o).FirstOrDefault();
        }
        #endregion
        #region Query
        protected override IQueryable<ProyectoSeguimiento> Query(ProyectoSeguimientoFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdProyectoSeguimiento == null || filter.IdProyectoSeguimiento == 0 || o.IdProyectoSeguimiento == filter.IdProyectoSeguimiento)
                    && (filter.IdSaf == null || filter.IdSaf == 0 || o.IdSaf == filter.IdSaf)
                    && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                    && (filter.Ruta == null || filter.Ruta.Trim() == string.Empty || filter.Ruta.Trim() == "%" || (filter.Ruta.EndsWith("%") && filter.Ruta.StartsWith("%") && (o.Ruta.Contains(filter.Ruta.Replace("%", "")))) || (filter.Ruta.EndsWith("%") && o.Ruta.StartsWith(filter.Ruta.Replace("%", ""))) || (filter.Ruta.StartsWith("%") && o.Ruta.EndsWith(filter.Ruta.Replace("%", ""))) || o.Ruta == filter.Ruta)
                    && (filter.Malla == null || filter.Malla.Trim() == string.Empty || filter.Malla.Trim() == "%" || (filter.Malla.EndsWith("%") && filter.Malla.StartsWith("%") && (o.Malla.Contains(filter.Malla.Replace("%", "")))) || (filter.Malla.EndsWith("%") && o.Malla.StartsWith(filter.Malla.Replace("%", ""))) || (filter.Malla.StartsWith("%") && o.Malla.EndsWith(filter.Malla.Replace("%", ""))) || o.Malla == filter.Malla)
                    && (filter.IdAnalista == null || filter.IdAnalista == 0 || o.IdAnalista == filter.IdAnalista)
                    && (filter.IdProyectoSeguimientoAnterior == null || filter.IdProyectoSeguimientoAnterior == 0 || o.IdProyectoSeguimientoAnterior == filter.IdProyectoSeguimientoAnterior)
                    && (filter.IdProyectoSeguimientoAnteriorIsNull == null || filter.IdProyectoSeguimientoAnteriorIsNull == true || o.IdProyectoSeguimientoAnterior != null) && (filter.IdProyectoSeguimientoAnteriorIsNull == null || filter.IdProyectoSeguimientoAnteriorIsNull == false || o.IdProyectoSeguimientoAnterior == null)
                    && (filter.IdProyectoSeguimientoEstadoUltimo == null || filter.IdProyectoSeguimientoEstadoUltimo == 0 || o.IdProyectoSeguimientoEstadoUltimo == filter.IdProyectoSeguimientoEstadoUltimo)
                    && (filter.IdProyectoSeguimientoEstadoUltimoIsNull == null || filter.IdProyectoSeguimientoEstadoUltimoIsNull == true || o.IdProyectoSeguimientoEstadoUltimo != null) && (filter.IdProyectoSeguimientoEstadoUltimoIsNull == null || filter.IdProyectoSeguimientoEstadoUltimoIsNull == false || o.IdProyectoSeguimientoEstadoUltimo == null)
                    select o
                    ).AsQueryable();
        }
       //  protected override IQueryable<ProyectoSeguimientoResult> QueryResult(ProyectoSeguimientoFilter filter)
       //{
       //    return (
       //             from o in base.QueryResult(filter)
       //             join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos
       //                 on o.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento
       //             into tproyectoDictamenSeguimiento from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
       //             join _psp in this.Context.ProyectoSeguimientoProyectos on o.IdProyectoSeguimiento equals _psp.IdProyectoSeguimiento
       //             into tpsp from psp in tpsp.DefaultIfEmpty()
       //             where 
       //                 (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen)
       //                 && (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == psp.IdProyecto )
       //                 && ( filter.IdsEstado == null || filter.IdsEstado.Count == 0 ||
       //                         ( from pse in this.Context.ProyectoSeguimientoEstados 
       //                           where  filter.IdsEstado.Contains ( pse.IdEstado) 
       //                             select pse.IdProyectoSeguimiento).Contains ( o.IdProyectoSeguimiento )
                                
       //                 )
       //                 && ( filter.Proyecto_Codigo == null || filter.Proyecto_Codigo == 0 || 
       //                     ( from p in this.Context.Proyectos 
       //                       where p.Codigo == filter.Proyecto_Codigo
       //                       select p.IdProyecto ).Contains (psp.IdProyecto ))
       //            select new ProyectoSeguimientoResult(){
       //             IdProyectoSeguimiento=o.IdProyectoSeguimiento
       //             ,IdSaf=o.IdSaf
       //             ,Denominacion=o.Denominacion
       //             ,Ruta=o.Ruta
       //             ,Malla=o.Malla
       //             ,IdAnalista=o.IdAnalista
       //             ,IdProyectoSeguimientoAnterior=o.IdProyectoSeguimientoAnterior
       //             ,IdProyectoSeguimientoEstadoUltimo=o.IdProyectoSeguimientoEstadoUltimo
       //             ,ProyectoSeguimientoAnterior_Denominacion= o.ProyectoSeguimientoAnterior_Denominacion
       //             ,ProyectoSeguimientoEstadoUltimo_IdEstado= o.ProyectoSeguimientoEstadoUltimo_IdEstado
       //             ,Saf_Codigo= o.Saf_Codigo
       //             ,Saf_Denominacion= o.Saf_Denominacion
       //             ,UltimoEstadoNombre = ( from e in this.Context.Estados where e.IdEstado == o.ProyectoSeguimientoEstadoUltimo_IdEstado select e.Nombre ).FirstOrDefault()
       //             ,Analista_ApellidoYNombre = ( from p in this.Context.Personas where p.IdPersona == o.IdAnalista select p.Apellido + " " + p.Nombre ).SingleOrDefault()
       //            }
                    
       //         ).AsQueryable();
       //}       
        
        protected override IQueryable<ProyectoSeguimientoResult> QueryResult(ProyectoSeguimientoFilter filter)
        {
            var query= (from o in Query(filter)
                    join _t1 in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimientoAnterior equals _t1.IdProyectoSeguimiento into tt1
                    from t1 in tt1.DefaultIfEmpty()
                    join _t2 in this.Context.ProyectoSeguimientoEstados on o.IdProyectoSeguimientoEstadoUltimo equals _t2.IdProyectoSeguimientoEstado into tt2 from t2 in tt2.DefaultIfEmpty()
                    join _e in this.Context.Estados on t2.IdEstado equals _e.IdEstado  into te from e in te.DefaultIfEmpty()
                    join _p in this.Context.Personas  on t2.IdUsuario equals _p.IdPersona  into tp from p in tp.DefaultIfEmpty()
                    join t3 in this.Context.Safs on o.IdSaf equals t3.IdSaf
                    join t4 in this.Context.Usuarios on o.IdAnalista equals t4.IdUsuario
                    join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos
                        on o.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento
                    into tproyectoDictamenSeguimiento
                    from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
                    
                    where
                        (
                            
                            (
                                from o2 in Query(filter)
                                join _psp in this.Context.ProyectoSeguimientoProyectos on o.IdProyectoSeguimiento equals _psp.IdProyectoSeguimiento into tpsp from psp in tpsp.DefaultIfEmpty()
                                where                                 
                                    
                                    (filter.IdProyecto == null || filter.IdProyecto == 0 ||  filter.IdProyecto == psp.IdProyecto)
                                    && (filter.Proyecto_Codigo == null || filter.Proyecto_Codigo == 0 ||
                                    (from pr in this.Context.Proyectos
                                     where pr.Codigo == filter.Proyecto_Codigo
                                     select pr.IdProyecto).Contains(psp.IdProyecto))
                                        select o2.IdProyectoSeguimiento  
                            ).Contains ( o.IdProyectoSeguimiento )
                        )
                        && (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen)
                        && (filter.IdsEstado == null || filter.IdsEstado.Count == 0 || ( t2!=null && filter.IdsEstado.Contains (t2.IdEstado ) )
                        //(from pse in this.Context.ProyectoSeguimientoEstados
                        // where filter.IdsEstado.Contains(pse.IdEstado)
                        // select pse.IdProyectoSeguimiento).Contains(o.IdProyectoSeguimiento)
                      
                        )
                             
                    select new ProyectoSeguimientoResult()
                    {
                        IdProyectoSeguimiento = o.IdProyectoSeguimiento
                        ,IdSaf = o.IdSaf
                        ,Denominacion = o.Denominacion
                        ,Ruta = o.Ruta
                        ,Malla = o.Malla
                        ,IdAnalista = o.IdAnalista
                        ,IdProyectoSeguimientoAnterior = o.IdProyectoSeguimientoAnterior
                        ,IdProyectoSeguimientoEstadoUltimo = o.IdProyectoSeguimientoEstadoUltimo
                        ,ProyectoSeguimientoAnterior_Denominacion = t1 != null ? (string)t1.Denominacion : null
                        ,ProyectoSeguimientoEstadoUltimo_IdEstado = t2 != null ? (int?)t2.IdEstado : null
                        ,Saf_Codigo = t3.Codigo
                        ,Saf_Denominacion = t3.Denominacion
                        ,UltimoEstadoNombre = (
                                                from es in this.Context.Estados
                                                join pse in this.Context.ProyectoSeguimientoEstados 
                                                on  es.IdEstado equals pse.IdEstado 
                                                where o.IdProyectoSeguimientoEstadoUltimo == pse.IdProyectoSeguimientoEstado 
                                                select es.Nombre
                                               ).FirstOrDefault()
                        ,Analista_ApellidoYNombre = (from pe in this.Context.Personas where pe.IdPersona == o.IdAnalista select pe.Apellido + " " + pe.Nombre).SingleOrDefault()
                        ,ProyectoSeguimientoEstadoUltimo_Fecha = t2.Fecha 
                        ,ProyectoSeguimientoEstadoUltimo_Observacion = t2.Observacion 
                        ,ProyectoSeguimientoEstadoUltimo_IdUsuario = t2.IdUsuario 
                        ,ProyectoSeguimientoEstadoUltimo_UsuarioApellidoYNombre  = p!=null? p.Apellido + " " + p.Nombre :""
                        ,ProyectoSeguimientoEstadoUltimo_EstadoNombre   = e!=null? e.Nombre :""
                    
                    
                    
                    
                        }
                      ).AsQueryable();
            return query;
        }
        
        #endregion
        #region Copy
        public override nc.ProyectoSeguimiento Copy(nc.ProyectoSeguimiento entity)
        {
            nc.ProyectoSeguimiento _new = new nc.ProyectoSeguimiento();
            _new.IdSaf = entity.IdSaf;
            _new.Denominacion = entity.Denominacion;
            _new.Ruta = entity.Ruta;
            _new.Malla = entity.Malla;
            _new.IdAnalista = entity.IdAnalista;
            _new.IdProyectoSeguimientoAnterior = entity.IdProyectoSeguimientoAnterior;
            _new.IdProyectoSeguimientoEstadoUltimo = entity.IdProyectoSeguimientoEstadoUltimo;
            return _new;
        }
        public override int CopyAndSave(ProyectoSeguimiento entity, string renameFormat)
        {
            ProyectoSeguimiento newEntity = Copy(entity);
            newEntity.Denominacion = string.Format(renameFormat, newEntity.Denominacion);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(ProyectoSeguimiento entity, int id)
        {
            entity.IdProyectoSeguimiento = id;
        }
        public override void Set(ProyectoSeguimiento source, ProyectoSeguimiento target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoSeguimiento = source.IdProyectoSeguimiento;
            target.IdSaf = source.IdSaf;
            target.Denominacion = source.Denominacion;
            target.Ruta = source.Ruta;
            target.Malla = source.Malla;
            target.IdAnalista = source.IdAnalista;
            target.IdProyectoSeguimientoAnterior = source.IdProyectoSeguimientoAnterior;
            target.IdProyectoSeguimientoEstadoUltimo = source.IdProyectoSeguimientoEstadoUltimo;

        }
        public override void Set(ProyectoSeguimientoResult source, ProyectoSeguimiento target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoSeguimiento = source.IdProyectoSeguimiento;
            target.IdSaf = source.IdSaf;
            target.Denominacion = source.Denominacion;
            target.Ruta = source.Ruta;
            target.Malla = source.Malla;
            target.IdAnalista = source.IdAnalista;
            target.IdProyectoSeguimientoAnterior = source.IdProyectoSeguimientoAnterior;
            target.IdProyectoSeguimientoEstadoUltimo = source.IdProyectoSeguimientoEstadoUltimo;

        }
        public override void Set(ProyectoSeguimiento source, ProyectoSeguimientoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoSeguimiento = source.IdProyectoSeguimiento;
            target.IdSaf = source.IdSaf;
            target.Denominacion = source.Denominacion;
            target.Ruta = source.Ruta;
            target.Malla = source.Malla;
            target.IdAnalista = source.IdAnalista;
            target.IdProyectoSeguimientoAnterior = source.IdProyectoSeguimientoAnterior;
            target.IdProyectoSeguimientoEstadoUltimo = source.IdProyectoSeguimientoEstadoUltimo;

        }
        public override void Set(ProyectoSeguimientoResult source, ProyectoSeguimientoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoSeguimiento = source.IdProyectoSeguimiento;
            target.IdSaf = source.IdSaf;
            target.Denominacion = source.Denominacion;
            target.Ruta = source.Ruta;
            target.Malla = source.Malla;
            target.IdAnalista = source.IdAnalista;
            target.IdProyectoSeguimientoAnterior = source.IdProyectoSeguimientoAnterior;
            target.IdProyectoSeguimientoEstadoUltimo = source.IdProyectoSeguimientoEstadoUltimo;
            //target.ProyectoSeguimientoAnterior_IdSaf= source.ProyectoSeguimientoAnterior_IdSaf;	
            target.ProyectoSeguimientoAnterior_Denominacion = source.ProyectoSeguimientoAnterior_Denominacion;
            //target.ProyectoSeguimientoAnterior_Ruta= source.ProyectoSeguimientoAnterior_Ruta;	
            //target.ProyectoSeguimientoAnterior_Malla= source.ProyectoSeguimientoAnterior_Malla;	
            //target.ProyectoSeguimientoAnterior_IdAnalista= source.ProyectoSeguimientoAnterior_IdAnalista;	
            //target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior= source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior;	
            //target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo= source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo;	
            //target.ProyectoSeguimientoEstadoUltimo_IdProyectoSeguimiento= source.ProyectoSeguimientoEstadoUltimo_IdProyectoSeguimiento;	
            target.ProyectoSeguimientoEstadoUltimo_IdEstado = source.ProyectoSeguimientoEstadoUltimo_IdEstado;
            //target.ProyectoSeguimientoEstadoUltimo_Fecha= source.ProyectoSeguimientoEstadoUltimo_Fecha;	
            //target.ProyectoSeguimientoEstadoUltimo_Observacion= source.ProyectoSeguimientoEstadoUltimo_Observacion;	
            //target.ProyectoSeguimientoEstadoUltimo_IdUsuario= source.ProyectoSeguimientoEstadoUltimo_IdUsuario;	
            target.Saf_Codigo = source.Saf_Codigo;
            target.Saf_Denominacion = source.Saf_Denominacion;
            //target.Saf_IdTipoOrganismo= source.Saf_IdTipoOrganismo;	
            //target.Saf_IdSector= source.Saf_IdSector;	
            //target.Saf_IdAdministracionTipo= source.Saf_IdAdministracionTipo;	
            //target.Saf_IdEntidadTipo= source.Saf_IdEntidadTipo;	
            //target.Saf_IdJurisdiccion= source.Saf_IdJurisdiccion;	
            //target.Saf_IdSubJurisdiccion= source.Saf_IdSubJurisdiccion;	
            //target.Saf_FechaAlta= source.Saf_FechaAlta;	
            //target.Saf_FechaBaja= source.Saf_FechaBaja;	
            //target.Saf_Activo= source.Saf_Activo;	
            //target.Analista_NombreUsuario= source.Analista_NombreUsuario;	
            //target.Analista_Clave= source.Analista_Clave;	
            //target.Analista_Activo= source.Analista_Activo;	
            //target.Analista_EsSectioralista= source.Analista_EsSectioralista;	
            //target.Analista_IdLanguage= source.Analista_IdLanguage;	
            //target.Analista_AccesoTotal= source.Analista_AccesoTotal;	

        }
        #endregion
        #region Equals
        public override bool Equals(ProyectoSeguimiento source, ProyectoSeguimiento target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento)) return false;
            if (!source.IdSaf.Equals(target.IdSaf)) return false;
            if ((source.Denominacion == null) ? target.Denominacion != null : !source.Denominacion.Equals(target.Denominacion)) return false;
            if ((source.Ruta == null) ? target.Ruta != null : !source.Ruta.Equals(target.Ruta)) return false;
            if ((source.Malla == null) ? target.Malla != null : !source.Malla.Equals(target.Malla)) return false;
            if (!source.IdAnalista.Equals(target.IdAnalista)) return false;
            if ((source.IdProyectoSeguimientoAnterior == null) ? (target.IdProyectoSeguimientoAnterior.HasValue && target.IdProyectoSeguimientoAnterior.Value > 0) : !source.IdProyectoSeguimientoAnterior.Equals(target.IdProyectoSeguimientoAnterior)) return false;
            if ((source.IdProyectoSeguimientoEstadoUltimo == null) ? (target.IdProyectoSeguimientoEstadoUltimo.HasValue && target.IdProyectoSeguimientoEstadoUltimo.Value > 0) : !source.IdProyectoSeguimientoEstadoUltimo.Equals(target.IdProyectoSeguimientoEstadoUltimo)) return false;

            return true;
        }
        public override bool Equals(ProyectoSeguimientoResult source, ProyectoSeguimientoResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento)) return false;
            if (!source.IdSaf.Equals(target.IdSaf)) return false;
            if ((source.Denominacion == null) ? target.Denominacion != null : !source.Denominacion.Equals(target.Denominacion)) return false;
            if ((source.Ruta == null) ? target.Ruta != null : !source.Ruta.Equals(target.Ruta)) return false;
            if ((source.Malla == null) ? target.Malla != null : !source.Malla.Equals(target.Malla)) return false;
            if (!source.IdAnalista.Equals(target.IdAnalista)) return false;
            if ((source.IdProyectoSeguimientoAnterior == null) ? (target.IdProyectoSeguimientoAnterior.HasValue && target.IdProyectoSeguimientoAnterior.Value > 0) : !source.IdProyectoSeguimientoAnterior.Equals(target.IdProyectoSeguimientoAnterior)) return false;
            if ((source.IdProyectoSeguimientoEstadoUltimo == null) ? (target.IdProyectoSeguimientoEstadoUltimo.HasValue && target.IdProyectoSeguimientoEstadoUltimo.Value > 0) : !source.IdProyectoSeguimientoEstadoUltimo.Equals(target.IdProyectoSeguimientoEstadoUltimo)) return false;
            //if(!source.ProyectoSeguimientoAnterior_IdSaf.Equals(target.ProyectoSeguimientoAnterior_IdSaf))return false;
            if ((source.ProyectoSeguimientoAnterior_Denominacion == null) ? target.ProyectoSeguimientoAnterior_Denominacion != null : !source.ProyectoSeguimientoAnterior_Denominacion.Equals(target.ProyectoSeguimientoAnterior_Denominacion)) return false;
            //   if((source.ProyectoSeguimientoAnterior_Ruta == null)?target.ProyectoSeguimientoAnterior_Ruta!=null:!source.ProyectoSeguimientoAnterior_Ruta.Equals(target.ProyectoSeguimientoAnterior_Ruta))return false;
            //   if((source.ProyectoSeguimientoAnterior_Malla == null)?target.ProyectoSeguimientoAnterior_Malla!=null:!source.ProyectoSeguimientoAnterior_Malla.Equals(target.ProyectoSeguimientoAnterior_Malla))return false;
            //   if(!source.ProyectoSeguimientoAnterior_IdAnalista.Equals(target.ProyectoSeguimientoAnterior_IdAnalista))return false;
            //if((source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior == null)?(target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior.HasValue && target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior.Value > 0):!source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior.Equals(target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior))return false;
            //                if((source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo == null)?(target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo.HasValue && target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo.Value > 0):!source.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo.Equals(target.ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo))return false;
            //                if(!source.ProyectoSeguimientoEstadoUltimo_IdProyectoSeguimiento.Equals(target.ProyectoSeguimientoEstadoUltimo_IdProyectoSeguimiento))return false;
            if (!source.ProyectoSeguimientoEstadoUltimo_IdEstado.Equals(target.ProyectoSeguimientoEstadoUltimo_IdEstado)) return false;
            //if(!source.ProyectoSeguimientoEstadoUltimo_Fecha.Equals(target.ProyectoSeguimientoEstadoUltimo_Fecha))return false;
            //if((source.ProyectoSeguimientoEstadoUltimo_Observacion == null)?target.ProyectoSeguimientoEstadoUltimo_Observacion!=null:!source.ProyectoSeguimientoEstadoUltimo_Observacion.Equals(target.ProyectoSeguimientoEstadoUltimo_Observacion))return false;
            //   if(!source.ProyectoSeguimientoEstadoUltimo_IdUsuario.Equals(target.ProyectoSeguimientoEstadoUltimo_IdUsuario))return false;
            if ((source.Saf_Codigo == null) ? target.Saf_Codigo != null : !source.Saf_Codigo.Equals(target.Saf_Codigo)) return false;
            if ((source.Saf_Denominacion == null) ? target.Saf_Denominacion != null : !source.Saf_Denominacion.Equals(target.Saf_Denominacion)) return false;
            //if(!source.Saf_IdTipoOrganismo.Equals(target.Saf_IdTipoOrganismo))return false;
            //if((source.Saf_IdSector == null)?(target.Saf_IdSector.HasValue && target.Saf_IdSector.Value > 0):!source.Saf_IdSector.Equals(target.Saf_IdSector))return false;
            //                if((source.Saf_IdAdministracionTipo == null)?(target.Saf_IdAdministracionTipo.HasValue && target.Saf_IdAdministracionTipo.Value > 0):!source.Saf_IdAdministracionTipo.Equals(target.Saf_IdAdministracionTipo))return false;
            //                if((source.Saf_IdEntidadTipo == null)?(target.Saf_IdEntidadTipo.HasValue && target.Saf_IdEntidadTipo.Value > 0):!source.Saf_IdEntidadTipo.Equals(target.Saf_IdEntidadTipo))return false;
            //                if((source.Saf_IdJurisdiccion == null)?(target.Saf_IdJurisdiccion.HasValue && target.Saf_IdJurisdiccion.Value > 0):!source.Saf_IdJurisdiccion.Equals(target.Saf_IdJurisdiccion))return false;
            //                if((source.Saf_IdSubJurisdiccion == null)?(target.Saf_IdSubJurisdiccion.HasValue && target.Saf_IdSubJurisdiccion.Value > 0):!source.Saf_IdSubJurisdiccion.Equals(target.Saf_IdSubJurisdiccion))return false;
            //                if(!source.Saf_FechaAlta.Equals(target.Saf_FechaAlta))return false;
            //if((source.Saf_FechaBaja == null)?(target.Saf_FechaBaja.HasValue ):!source.Saf_FechaBaja.Equals(target.Saf_FechaBaja))return false;
            //   if(!source.Saf_Activo.Equals(target.Saf_Activo))return false;
            //if((source.Analista_NombreUsuario == null)?target.Analista_NombreUsuario!=null:!source.Analista_NombreUsuario.Equals(target.Analista_NombreUsuario))return false;
            //   if((source.Analista_Clave == null)?target.Analista_Clave!=null:!source.Analista_Clave.Equals(target.Analista_Clave))return false;
            //   if(!source.Analista_Activo.Equals(target.Analista_Activo))return false;
            //if(!source.Analista_EsSectioralista.Equals(target.Analista_EsSectioralista))return false;
            //if(!source.Analista_IdLanguage.Equals(target.Analista_IdLanguage))return false;
            //if(!source.Analista_AccesoTotal.Equals(target.Analista_AccesoTotal))return false;

            return true;
        }
        #endregion
    }
}
