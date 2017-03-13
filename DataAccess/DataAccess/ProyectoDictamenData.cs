using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoDictamenData : _ProyectoDictamenData 
    { 
	   #region Singleton
	   private static volatile ProyectoDictamenData current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenData() {}
	   public static ProyectoDictamenData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override string IdFieldName { get { return "IdProyectoDictamen"; } }
       public virtual List<Usuario> GetFuncionarios(ProyectoDictamenFilter filter)
       {
           //Obtiene los funcionarios relacinados a los proyectos que contiene el dictamen
           //para el envio de mensajes automaticos alertando al usuario del dictamen realizado
           return (from o in Query(filter)
                   join pds in this.Context.ProyectoDictamenSeguimientos on o.IdProyectoDictamen equals pds.IdProyectoDictamen
                   join ps in this.Context.ProyectoSeguimientos on pds.IdProyectoSeguimiento equals ps.IdProyectoSeguimiento
                   join psp in this.Context.ProyectoSeguimientoProyectos on pds.IdProyectoSeguimiento equals psp.IdProyectoSeguimiento
                   join pop in this.Context.ProyectoOficinaPerfils on psp.IdProyecto equals pop.IdProyecto
                   join popf in this.Context.ProyectoOficinaPerfilFuncionarios on pop.IdProyectoOficinaPerfil equals popf.IdProyectoOficinaPerfil
                   join u in this.Context.Usuarios on popf.IdUsuario equals u.IdUsuario
                   select u).Distinct().ToList();
       }
        
        //Daniela
        protected override IQueryable<ProyectoDictamenResult> QueryResult(ProyectoDictamenFilter filter)
        {
           var query= (from o in Query(filter)
                      join pde in this.Context.ProyectoDictamenEstados on o.IdProyectoDictamenEstadoUltimo equals pde.IdProyectoDictamenEstado
                      join t1 in this.Context.Estados on pde.IdEstado equals t1.IdEstado
                      join _t2 in this.Context.PlanPeriodos on o.IdPlanPeriodo equals _t2.IdPlanPeriodo into tt2 from t2 in tt2.DefaultIfEmpty()
    			      join _t3  in this.Context.ProyectoCalificacions on o.IdProyectoCalificacion equals _t3.IdProyectoCalificacion into tt3 from t3 in tt3.DefaultIfEmpty() 
                      join tt in (
                           from  pds in this.Context.ProyectoDictamenSeguimientos 
                           join ps in this.Context.ProyectoSeguimientos on pds.IdProyectoSeguimiento equals ps.IdProyectoSeguimiento
                           join psp in this.Context.ProyectoSeguimientoProyectos on ps.IdProyectoSeguimiento equals psp.IdProyectoSeguimiento 
                           join p in this.Context.Proyectos on psp.IdProyecto equals p.IdProyecto
                           where 
                                (filter.IdSaf == null || filter.IdSaf == 0 || ps.IdSaf == filter.IdSaf )
                                && (filter.IdAnalista == null || filter.IdAnalista == 0 || ps.IdAnalista == filter.IdAnalista )
                                && (filter.Ruta == null || filter.Ruta.Trim() == string.Empty || filter.Ruta.Trim() == "%" || (filter.Ruta.EndsWith("%") && filter.Ruta.StartsWith("%") && (ps.Ruta.Contains(filter.Ruta.Replace("%", "")))) || (filter.Ruta.EndsWith("%") && ps.Ruta.StartsWith(filter.Ruta.Replace("%", ""))) || (filter.Ruta.StartsWith("%") && ps.Ruta.EndsWith(filter.Ruta.Replace("%", ""))) || ps.Ruta == filter.Ruta)
                                && (filter.Malla == null || filter.Malla.Trim() == string.Empty || filter.Malla.Trim() == "%" || (filter.Malla.EndsWith("%") && filter.Malla.StartsWith("%") && (ps.Malla.Contains(filter.Malla.Replace("%", "")))) || (filter.Malla.EndsWith("%") && ps.Malla.StartsWith(filter.Malla.Replace("%", ""))) || (filter.Malla.StartsWith("%") && ps.Malla.EndsWith(filter.Malla.Replace("%", ""))) || ps.Malla == filter.Malla )
                                && (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == psp.IdProyecto )
                                && (filter.NroBapin == null || filter.NroBapin == 0 || p.Codigo == filter.NroBapin )
                           group  pds by new {pds.IdProyectoDictamen}
                           into groupQuery
                            select new ProyectoDictamenSeguimientoResult()
                            {
                                IdProyectoDictamen = groupQuery.Key.IdProyectoDictamen
                                 ,IdProyectoSeguimiento=groupQuery.Max(p=>p.IdProyectoSeguimiento)
                            }
                        ) on o.IdProyectoDictamen equals tt.IdProyectoDictamen
                        join m in this.Context.ProyectoSeguimientos on  tt.IdProyectoSeguimiento equals m.IdProyectoSeguimiento
                        join s in this.Context.Safs on m.IdSaf equals s.IdSaf 
                        join p in this.Context.Personas on m.IdAnalista equals p.IdPersona 
                        where  (filter.IdsEstado == null || filter.IdsEstado.Count == 0 || filter.IdsEstado.Contains(pde.IdEstado))
				   select new ProyectoDictamenResult {
                                 IdProyectoDictamen=o.IdProyectoDictamen
                                 ,IdProyectoCalificacion=o.IdProyectoCalificacion
                                 ,Fecha=o.Fecha
                                 ,FechaVencimiento=o.FechaVencimiento
                                 ,IdPlanPeriodo=o.IdPlanPeriodo
                                 ,Monto=o.Monto
                                 ,Ejercicio=o.Ejercicio
                                 ,DuracionMeses=o.DuracionMeses
                                 ,InformeTecnico=o.InformeTecnico
                                 ,FechaComiteTecnico=o.FechaComiteTecnico
                                 ,Observacion=o.Observacion
                                 ,Recomendacion=o.Recomendacion
                                 ,RespuestaOrganismo=o.RespuestaOrganismo
                                 ,FechaRepuesta=o.FechaRepuesta
                                 ,Numero=o.Numero
                                 ,Denominacion=o.Denominacion
                                 ,IdUltimoEstado =  t1.IdEstado
                                 ,UltimoEstadoNombre = t1.Nombre
                                 ,FechaEstado = pde.Fecha
                                 ,PlanPeriodo_Nombre= t2!=null?(string)t2.Nombre:null	
                                 ,PlanPeriodo_Sigla= t2!=null?(string)t2.Sigla:null	
                                 ,ProyectoCalificacion_Nombre= t3!=null?(string)t3.Nombre:null	
                                 ,ProyectoCalificacion_Activo= t3!=null?(bool?)t3.Activo:null
                                 ,Analista_Apellido = p.Apellido
                                 ,Analista_Nombre = p.Nombre
                                 ,Saf_Codigo = s.Codigo
                                 ,Saf_Denominacion = s.Denominacion
                                 ,ProyectoSeguimiento_Ruta = m.Ruta
                                 ,ProyectoSeguimiento_Malla = m.Malla
						}
                    ).AsQueryable();

          return query;
        }

                                     

        public List<ProyectoDictamenResult> QueryResultReporte(ProyectoDictamenFilter filter)
       {

           var query= (from o in QueryResult(filter)
				   select new ProyectoDictamenResult {
                                 IdProyectoDictamen=o.IdProyectoDictamen
                                 ,IdProyectoCalificacion=o.IdProyectoCalificacion
                                 ,Fecha=o.Fecha
                                 ,FechaVencimiento=o.FechaVencimiento
                                 ,IdPlanPeriodo=o.IdPlanPeriodo
                                 ,Monto=o.Monto
                                 ,Ejercicio=o.Ejercicio
                                 ,DuracionMeses=o.DuracionMeses
                                 ,InformeTecnico=o.InformeTecnico
                                 ,FechaComiteTecnico=o.FechaComiteTecnico
                                 ,Observacion=o.Observacion
                                 ,Recomendacion=o.Recomendacion
                                 ,RespuestaOrganismo=o.RespuestaOrganismo
                                 ,FechaRepuesta=o.FechaRepuesta
                                 ,Numero=o.Numero
                                 ,Denominacion=o.Denominacion
                                 ,IdUltimoEstado =  o.IdUltimoEstado
                                 ,UltimoEstadoNombre = o.UltimoEstadoNombre
                                 ,FechaEstado = o.FechaEstado
                                 ,PlanPeriodo_Nombre= o.PlanPeriodo_Nombre
                                 ,PlanPeriodo_Sigla= o.PlanPeriodo_Sigla
                                 ,ProyectoCalificacion_Nombre= o.ProyectoCalificacion_Nombre
                                 ,ProyectoCalificacion_Activo= o.ProyectoCalificacion_Activo
                                 ,Analista_Apellido = o.Analista_Apellido 
                                 ,Analista_Nombre = o.Analista_Nombre
                                 ,Saf_Codigo = o.Saf_Codigo
                                 ,Saf_Denominacion = o.Saf_Denominacion
                                 ,ProyectoSeguimiento_Ruta = o.ProyectoSeguimiento_Ruta
                                 ,ProyectoSeguimiento_Malla =  o.ProyectoSeguimiento_Malla
                                 ,Dictamen_ProvinciasConcatenadas=Context.fnGetProyectoLocalidadDetalladaPorDictamen(o.IdProyectoDictamen).Select(i => i.Provincia).SingleOrDefault()
                                 ,Dictamen_ProyectosConcatenados = Context.fnGetProyectoDetalladoPorDictamen(o.IdProyectoDictamen).Select(i => i.Proyecto).SingleOrDefault()
						}
                    ).AsQueryable();


          return query.ToList();
        }
    }
}
