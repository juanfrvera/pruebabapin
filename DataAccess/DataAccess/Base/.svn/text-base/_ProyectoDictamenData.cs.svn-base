using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoDictamenData : EntityData<ProyectoDictamen, ProyectoDictamenFilter, ProyectoDictamenResult, int>
    {
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.ProyectoDictamen entity)
        {
            return entity.IdProyectoDictamen;
        }
        public override ProyectoDictamen GetByEntity(ProyectoDictamen entity)
        {
            return this.GetById(entity.IdProyectoDictamen);
        }
        public override ProyectoDictamen GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoDictamen == id select o).FirstOrDefault();

        }
        #endregion
        #region Query
        protected override IQueryable<ProyectoDictamen> Query(ProyectoDictamenFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || o.IdProyectoDictamen == filter.IdProyectoDictamen)
                    && (filter.IdProyectoCalificacion == null || filter.IdProyectoCalificacion == 0 || o.IdProyectoCalificacion == filter.IdProyectoCalificacion)
                    && (filter.IdProyectoCalificacionIsNull == null || filter.IdProyectoCalificacionIsNull == true || o.IdProyectoCalificacion != null) && (filter.IdProyectoCalificacionIsNull == null || filter.IdProyectoCalificacionIsNull == false || o.IdProyectoCalificacion == null)
                    && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >= filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
                    && (filter.FechaIsNull == null || filter.FechaIsNull == true || o.Fecha != null) && (filter.FechaIsNull == null || filter.FechaIsNull == false || o.Fecha == null)
                    && (filter.FechaVencimiento == null || filter.FechaVencimiento == DateTime.MinValue || o.FechaVencimiento >= filter.FechaVencimiento) && (filter.FechaVencimiento_To == null || filter.FechaVencimiento_To == DateTime.MinValue || o.FechaVencimiento <= filter.FechaVencimiento_To)
                    && (filter.FechaVencimientoIsNull == null || filter.FechaVencimientoIsNull == true || o.FechaVencimiento != null) && (filter.FechaVencimientoIsNull == null || filter.FechaVencimientoIsNull == false || o.FechaVencimiento == null)
                    && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo == filter.IdPlanPeriodo)
                    && (filter.IdPlanPeriodoIsNull == null || filter.IdPlanPeriodoIsNull == true || o.IdPlanPeriodo != null) && (filter.IdPlanPeriodoIsNull == null || filter.IdPlanPeriodoIsNull == false || o.IdPlanPeriodo == null)
                    && (filter.Monto == null || o.Monto >= filter.Monto) && (filter.Monto_To == null || o.Monto <= filter.Monto_To)
                    && (filter.MontoIsNull == null || filter.MontoIsNull == true || o.Monto != null) && (filter.MontoIsNull == null || filter.MontoIsNull == false || o.Monto == null)
                    && (filter.Ejercicio == null || o.Ejercicio >= filter.Ejercicio) && (filter.Ejercicio_To == null || o.Ejercicio <= filter.Ejercicio_To)
                    && (filter.EjercicioIsNull == null || filter.EjercicioIsNull == true || o.Ejercicio != null) && (filter.EjercicioIsNull == null || filter.EjercicioIsNull == false || o.Ejercicio == null)
                    && (filter.DuracionMeses == null || o.DuracionMeses >= filter.DuracionMeses) && (filter.DuracionMeses_To == null || o.DuracionMeses <= filter.DuracionMeses_To)
                    && (filter.DuracionMesesIsNull == null || filter.DuracionMesesIsNull == true || o.DuracionMeses != null) && (filter.DuracionMesesIsNull == null || filter.DuracionMesesIsNull == false || o.DuracionMeses == null)
                    && (filter.InformeTecnico == null || filter.InformeTecnico.Trim() == string.Empty || filter.InformeTecnico.Trim() == "%" || (filter.InformeTecnico.EndsWith("%") && filter.InformeTecnico.StartsWith("%") && (o.InformeTecnico.Contains(filter.InformeTecnico.Replace("%", "")))) || (filter.InformeTecnico.EndsWith("%") && o.InformeTecnico.StartsWith(filter.InformeTecnico.Replace("%", ""))) || (filter.InformeTecnico.StartsWith("%") && o.InformeTecnico.EndsWith(filter.InformeTecnico.Replace("%", ""))) || o.InformeTecnico == filter.InformeTecnico)
                    && (filter.FechaComiteTecnico == null || filter.FechaComiteTecnico == DateTime.MinValue || o.FechaComiteTecnico >= filter.FechaComiteTecnico) && (filter.FechaComiteTecnico_To == null || filter.FechaComiteTecnico_To == DateTime.MinValue || o.FechaComiteTecnico <= filter.FechaComiteTecnico_To)
                    && (filter.FechaComiteTecnicoIsNull == null || filter.FechaComiteTecnicoIsNull == true || o.FechaComiteTecnico != null) && (filter.FechaComiteTecnicoIsNull == null || filter.FechaComiteTecnicoIsNull == false || o.FechaComiteTecnico == null)
                    && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%" || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%", ""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%", ""))) || o.Observacion == filter.Observacion)
                    && (filter.Recomendacion == null || filter.Recomendacion.Trim() == string.Empty || filter.Recomendacion.Trim() == "%" || (filter.Recomendacion.EndsWith("%") && filter.Recomendacion.StartsWith("%") && (o.Recomendacion.Contains(filter.Recomendacion.Replace("%", "")))) || (filter.Recomendacion.EndsWith("%") && o.Recomendacion.StartsWith(filter.Recomendacion.Replace("%", ""))) || (filter.Recomendacion.StartsWith("%") && o.Recomendacion.EndsWith(filter.Recomendacion.Replace("%", ""))) || o.Recomendacion == filter.Recomendacion)
                    && (filter.RespuestaOrganismo == null || filter.RespuestaOrganismo.Trim() == string.Empty || filter.RespuestaOrganismo.Trim() == "%" || (filter.RespuestaOrganismo.EndsWith("%") && filter.RespuestaOrganismo.StartsWith("%") && (o.RespuestaOrganismo.Contains(filter.RespuestaOrganismo.Replace("%", "")))) || (filter.RespuestaOrganismo.EndsWith("%") && o.RespuestaOrganismo.StartsWith(filter.RespuestaOrganismo.Replace("%", ""))) || (filter.RespuestaOrganismo.StartsWith("%") && o.RespuestaOrganismo.EndsWith(filter.RespuestaOrganismo.Replace("%", ""))) || o.RespuestaOrganismo == filter.RespuestaOrganismo)
                    && (filter.FechaRepuesta == null || filter.FechaRepuesta == DateTime.MinValue || o.FechaRepuesta >= filter.FechaRepuesta) && (filter.FechaRepuesta_To == null || filter.FechaRepuesta_To == DateTime.MinValue || o.FechaRepuesta <= filter.FechaRepuesta_To)
                    && (filter.FechaRepuestaIsNull == null || filter.FechaRepuestaIsNull == true || o.FechaRepuesta != null) && (filter.FechaRepuestaIsNull == null || filter.FechaRepuestaIsNull == false || o.FechaRepuesta == null)
                    && (filter.FechaEstado == null || filter.FechaEstado == DateTime.MinValue || o.FechaEstado >= filter.FechaEstado) && (filter.FechaEstado_To == null || filter.FechaEstado_To == DateTime.MinValue || o.FechaEstado <= filter.FechaEstado_To)
                    && (filter.Numero == null || filter.Numero.Trim() == string.Empty || filter.Numero.Trim() == "%" || (filter.Numero.EndsWith("%") && filter.Numero.StartsWith("%") && (o.Numero.Contains(filter.Numero.Replace("%", "")))) || (filter.Numero.EndsWith("%") && o.Numero.StartsWith(filter.Numero.Replace("%", ""))) || (filter.Numero.StartsWith("%") && o.Numero.EndsWith(filter.Numero.Replace("%", ""))) || o.Numero == filter.Numero)
                    && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                    && (filter.IdProyectoDictamenEstadoUltimo == null || filter.IdProyectoDictamenEstadoUltimo == 0 || o.IdProyectoDictamenEstadoUltimo == filter.IdProyectoDictamenEstadoUltimo)
                    && (filter.IdProyectoDictamenEstadoUltimoIsNull == null || filter.IdProyectoDictamenEstadoUltimoIsNull == true || o.IdProyectoDictamenEstadoUltimo != null) && (filter.IdProyectoDictamenEstadoUltimoIsNull == null || filter.IdProyectoDictamenEstadoUltimoIsNull == false || o.IdProyectoDictamenEstadoUltimo == null)
                    select o
                    ).AsQueryable();
        }
        protected override IQueryable<ProyectoDictamenResult> QueryResult(ProyectoDictamenFilter filter)
        {
            return (from o in Query(filter)
                    join _t1 in this.Context.PlanPeriodos on o.IdPlanPeriodo equals _t1.IdPlanPeriodo into tt1
                    from t1 in tt1.DefaultIfEmpty()
                    join _t2 in this.Context.ProyectoCalificacions on o.IdProyectoCalificacion equals _t2.IdProyectoCalificacion into tt2
                    from t2 in tt2.DefaultIfEmpty()
                    join _t3 in this.Context.ProyectoDictamenEstados on o.IdProyectoDictamenEstadoUltimo equals _t3.IdProyectoDictamenEstado into tt3
                    from t3 in tt3.DefaultIfEmpty()
                    select new ProyectoDictamenResult()
                    {
                        IdProyectoDictamen = o.IdProyectoDictamen
                        ,
                        IdProyectoCalificacion = o.IdProyectoCalificacion
                        ,
                        Fecha = o.Fecha
                        ,
                        FechaVencimiento = o.FechaVencimiento
                        ,
                        IdPlanPeriodo = o.IdPlanPeriodo
                        ,
                        Monto = o.Monto
                        ,
                        Ejercicio = o.Ejercicio
                        ,
                        DuracionMeses = o.DuracionMeses
                        ,
                        InformeTecnico = o.InformeTecnico
                        ,
                        FechaComiteTecnico = o.FechaComiteTecnico
                        ,
                        Observacion = o.Observacion
                        ,
                        Recomendacion = o.Recomendacion
                        ,
                        RespuestaOrganismo = o.RespuestaOrganismo
                        ,
                        FechaRepuesta = o.FechaRepuesta
                        ,
                        FechaEstado = o.FechaEstado
                        ,
                        Numero = o.Numero
                        ,
                        Denominacion = o.Denominacion
                        ,
                        IdProyectoDictamenEstadoUltimo = o.IdProyectoDictamenEstadoUltimo
                        ,
                        PlanPeriodo_IdPlanTipo = t1 != null ? (int?)t1.IdPlanTipo : null
                        ,
                        PlanPeriodo_Nombre = t1 != null ? (string)t1.Nombre : null
                        ,
                        PlanPeriodo_Sigla = t1 != null ? (string)t1.Sigla : null
                        ,
                        PlanPeriodo_AnioInicial = t1 != null ? (int?)t1.AnioInicial : null
                        ,
                        PlanPeriodo_AnioFinal = t1 != null ? (int?)t1.AnioFinal : null
                        ,
                        PlanPeriodo_Activo = t1 != null ? (bool?)t1.Activo : null
                        ,
                        ProyectoCalificacion_Nombre = t2 != null ? (string)t2.Nombre : null
                        ,
                        ProyectoCalificacion_Activo = t2 != null ? (bool?)t2.Activo : null
                        ,
                        ProyectoDictamenEstadoUltimo_IdProyectoDictamen = t3 != null ? (int?)t3.IdProyectoDictamen : null
                        ,
                        ProyectoDictamenEstadoUltimo_IdEstado = t3 != null ? (int?)t3.IdEstado : null
                        ,
                        ProyectoDictamenEstadoUltimo_Fecha = t3 != null ? (DateTime?)t3.Fecha : null
                        ,
                        ProyectoDictamenEstadoUltimo_Observacion = t3 != null ? (string)t3.Observacion : null
                        ,
                        ProyectoDictamenEstadoUltimo_IdUsuario = t3 != null ? (int?)t3.IdUsuario : null
                    }
                      ).AsQueryable();
        }
        #endregion
        #region Copy
        public override nc.ProyectoDictamen Copy(nc.ProyectoDictamen entity)
        {
            nc.ProyectoDictamen _new = new nc.ProyectoDictamen();
            _new.IdProyectoCalificacion = entity.IdProyectoCalificacion;
            _new.Fecha = entity.Fecha;
            _new.FechaVencimiento = entity.FechaVencimiento;
            _new.IdPlanPeriodo = entity.IdPlanPeriodo;
            _new.Monto = entity.Monto;
            _new.Ejercicio = entity.Ejercicio;
            _new.DuracionMeses = entity.DuracionMeses;
            _new.InformeTecnico = entity.InformeTecnico;
            _new.FechaComiteTecnico = entity.FechaComiteTecnico;
            _new.Observacion = entity.Observacion;
            _new.Recomendacion = entity.Recomendacion;
            _new.RespuestaOrganismo = entity.RespuestaOrganismo;
            _new.FechaRepuesta = entity.FechaRepuesta;
            _new.FechaEstado = entity.FechaEstado;
            _new.Numero = entity.Numero;
            _new.Denominacion = entity.Denominacion;
            _new.IdProyectoDictamenEstadoUltimo = entity.IdProyectoDictamenEstadoUltimo;
            return _new;
        }
        public override int CopyAndSave(ProyectoDictamen entity, string renameFormat)
        {
            ProyectoDictamen newEntity = Copy(entity);
            newEntity.InformeTecnico = string.Format(renameFormat, newEntity.InformeTecnico);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(ProyectoDictamen entity, int id)
        {
            entity.IdProyectoDictamen = id;
        }
        public override void Set(ProyectoDictamen source, ProyectoDictamen target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdProyectoCalificacion = source.IdProyectoCalificacion;
            target.Fecha = source.Fecha;
            target.FechaVencimiento = source.FechaVencimiento;
            target.IdPlanPeriodo = source.IdPlanPeriodo;
            target.Monto = source.Monto;
            target.Ejercicio = source.Ejercicio;
            target.DuracionMeses = source.DuracionMeses;
            target.InformeTecnico = source.InformeTecnico;
            target.FechaComiteTecnico = source.FechaComiteTecnico;
            target.Observacion = source.Observacion;
            target.Recomendacion = source.Recomendacion;
            target.RespuestaOrganismo = source.RespuestaOrganismo;
            target.FechaRepuesta = source.FechaRepuesta;
            target.FechaEstado = source.FechaEstado;
            target.Numero = source.Numero;
            target.Denominacion = source.Denominacion;
            target.IdProyectoDictamenEstadoUltimo = source.IdProyectoDictamenEstadoUltimo;

        }
        public override void Set(ProyectoDictamenResult source, ProyectoDictamen target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdProyectoCalificacion = source.IdProyectoCalificacion;
            target.Fecha = source.Fecha;
            target.FechaVencimiento = source.FechaVencimiento;
            target.IdPlanPeriodo = source.IdPlanPeriodo;
            target.Monto = source.Monto;
            target.Ejercicio = source.Ejercicio;
            target.DuracionMeses = source.DuracionMeses;
            target.InformeTecnico = source.InformeTecnico;
            target.FechaComiteTecnico = source.FechaComiteTecnico;
            target.Observacion = source.Observacion;
            target.Recomendacion = source.Recomendacion;
            target.RespuestaOrganismo = source.RespuestaOrganismo;
            target.FechaRepuesta = source.FechaRepuesta;
            target.FechaEstado = source.FechaEstado;
            target.Numero = source.Numero;
            target.Denominacion = source.Denominacion;
            target.IdProyectoDictamenEstadoUltimo = source.IdProyectoDictamenEstadoUltimo;

        }
        public override void Set(ProyectoDictamen source, ProyectoDictamenResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdProyectoCalificacion = source.IdProyectoCalificacion;
            target.Fecha = source.Fecha;
            target.FechaVencimiento = source.FechaVencimiento;
            target.IdPlanPeriodo = source.IdPlanPeriodo;
            target.Monto = source.Monto;
            target.Ejercicio = source.Ejercicio;
            target.DuracionMeses = source.DuracionMeses;
            target.InformeTecnico = source.InformeTecnico;
            target.FechaComiteTecnico = source.FechaComiteTecnico;
            target.Observacion = source.Observacion;
            target.Recomendacion = source.Recomendacion;
            target.RespuestaOrganismo = source.RespuestaOrganismo;
            target.FechaRepuesta = source.FechaRepuesta;
            target.FechaEstado = source.FechaEstado;
            target.Numero = source.Numero;
            target.Denominacion = source.Denominacion;
            target.IdProyectoDictamenEstadoUltimo = source.IdProyectoDictamenEstadoUltimo;
        }

        public override void Set(ProyectoDictamenResult source, ProyectoDictamenResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdProyectoCalificacion = source.IdProyectoCalificacion;
            target.Fecha = source.Fecha;
            target.FechaVencimiento = source.FechaVencimiento;
            target.IdPlanPeriodo = source.IdPlanPeriodo;
            target.Monto = source.Monto;
            target.Ejercicio = source.Ejercicio;
            target.DuracionMeses = source.DuracionMeses;
            target.InformeTecnico = source.InformeTecnico;
            target.FechaComiteTecnico = source.FechaComiteTecnico;
            target.Observacion = source.Observacion;
            target.Recomendacion = source.Recomendacion;
            target.RespuestaOrganismo = source.RespuestaOrganismo;
            target.FechaRepuesta = source.FechaRepuesta;
            target.FechaEstado = source.FechaEstado;
            target.Numero = source.Numero;
            target.Denominacion = source.Denominacion;
            target.IdProyectoDictamenEstadoUltimo = source.IdProyectoDictamenEstadoUltimo;
            target.PlanPeriodo_IdPlanTipo = source.PlanPeriodo_IdPlanTipo;
            target.PlanPeriodo_Nombre = source.PlanPeriodo_Nombre;
            target.PlanPeriodo_Sigla = source.PlanPeriodo_Sigla;
            target.PlanPeriodo_AnioInicial = source.PlanPeriodo_AnioInicial;
            target.PlanPeriodo_AnioFinal = source.PlanPeriodo_AnioFinal;
            target.PlanPeriodo_Activo = source.PlanPeriodo_Activo;
            target.ProyectoCalificacion_Nombre = source.ProyectoCalificacion_Nombre;
            target.ProyectoCalificacion_Activo = source.ProyectoCalificacion_Activo;
            target.ProyectoDictamenEstadoUltimo_IdProyectoDictamen = source.ProyectoDictamenEstadoUltimo_IdProyectoDictamen;
            target.ProyectoDictamenEstadoUltimo_IdEstado = source.ProyectoDictamenEstadoUltimo_IdEstado;
            target.ProyectoDictamenEstadoUltimo_Fecha = source.ProyectoDictamenEstadoUltimo_Fecha;
            target.ProyectoDictamenEstadoUltimo_Observacion = source.ProyectoDictamenEstadoUltimo_Observacion;
            target.ProyectoDictamenEstadoUltimo_IdUsuario = source.ProyectoDictamenEstadoUltimo_IdUsuario;

        }
        #endregion
        #region Equals
        public override bool Equals(ProyectoDictamen source, ProyectoDictamen target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen)) return false;
            if ((source.IdProyectoCalificacion == null) ? (target.IdProyectoCalificacion.HasValue && target.IdProyectoCalificacion.Value > 0) : !source.IdProyectoCalificacion.Equals(target.IdProyectoCalificacion)) return false;
            if ((source.Fecha == null) ? (target.Fecha.HasValue) : !source.Fecha.Equals(target.Fecha)) return false;
            if ((source.FechaVencimiento == null) ? (target.FechaVencimiento.HasValue) : !source.FechaVencimiento.Equals(target.FechaVencimiento)) return false;
            if ((source.IdPlanPeriodo == null) ? (target.IdPlanPeriodo.HasValue && target.IdPlanPeriodo.Value > 0) : !source.IdPlanPeriodo.Equals(target.IdPlanPeriodo)) return false;
            if ((source.Monto == null) ? (target.Monto.HasValue) : !source.Monto.Equals(target.Monto)) return false;
            if ((source.Ejercicio == null) ? (target.Ejercicio.HasValue) : !source.Ejercicio.Equals(target.Ejercicio)) return false;
            if ((source.DuracionMeses == null) ? (target.DuracionMeses.HasValue) : !source.DuracionMeses.Equals(target.DuracionMeses)) return false;
            if ((source.InformeTecnico == null) ? target.InformeTecnico != null : !((target.InformeTecnico == String.Empty && source.InformeTecnico == null) || (target.InformeTecnico == null && source.InformeTecnico == String.Empty)) && !source.InformeTecnico.Trim().Replace("\r", "").Equals(target.InformeTecnico.Trim().Replace("\r", ""))) return false;
            if ((source.FechaComiteTecnico == null) ? (target.FechaComiteTecnico.HasValue) : !source.FechaComiteTecnico.Equals(target.FechaComiteTecnico)) return false;
            if ((source.Observacion == null) ? target.Observacion != null : !((target.Observacion == String.Empty && source.Observacion == null) || (target.Observacion == null && source.Observacion == String.Empty)) && !source.Observacion.Trim().Replace("\r", "").Equals(target.Observacion.Trim().Replace("\r", ""))) return false;
            if ((source.Recomendacion == null) ? target.Recomendacion != null : !((target.Recomendacion == String.Empty && source.Recomendacion == null) || (target.Recomendacion == null && source.Recomendacion == String.Empty)) && !source.Recomendacion.Trim().Replace("\r", "").Equals(target.Recomendacion.Trim().Replace("\r", ""))) return false;
            if ((source.RespuestaOrganismo == null) ? target.RespuestaOrganismo != null : !((target.RespuestaOrganismo == String.Empty && source.RespuestaOrganismo == null) || (target.RespuestaOrganismo == null && source.RespuestaOrganismo == String.Empty)) && !source.RespuestaOrganismo.Trim().Replace("\r", "").Equals(target.RespuestaOrganismo.Trim().Replace("\r", ""))) return false;
            if ((source.FechaRepuesta == null) ? (target.FechaRepuesta.HasValue) : !source.FechaRepuesta.Equals(target.FechaRepuesta)) return false;
            if (!source.FechaEstado.Equals(target.FechaEstado)) return false;
            if ((source.Numero == null) ? target.Numero != null : !((target.Numero == String.Empty && source.Numero == null) || (target.Numero == null && source.Numero == String.Empty)) && !source.Numero.Trim().Replace("\r", "").Equals(target.Numero.Trim().Replace("\r", ""))) return false;
            if ((source.Denominacion == null) ? target.Denominacion != null : !((target.Denominacion == String.Empty && source.Denominacion == null) || (target.Denominacion == null && source.Denominacion == String.Empty)) && !source.Denominacion.Trim().Replace("\r", "").Equals(target.Denominacion.Trim().Replace("\r", ""))) return false;
            if ((source.IdProyectoDictamenEstadoUltimo == null) ? (target.IdProyectoDictamenEstadoUltimo.HasValue && target.IdProyectoDictamenEstadoUltimo.Value > 0) : !source.IdProyectoDictamenEstadoUltimo.Equals(target.IdProyectoDictamenEstadoUltimo)) return false;

            return true;
        }
        public override bool Equals(ProyectoDictamenResult source, ProyectoDictamenResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen)) return false;
            if ((source.IdProyectoCalificacion == null) ? (target.IdProyectoCalificacion.HasValue && target.IdProyectoCalificacion.Value > 0) : !source.IdProyectoCalificacion.Equals(target.IdProyectoCalificacion)) return false;
            if ((source.Fecha == null) ? (target.Fecha.HasValue) : !source.Fecha.Equals(target.Fecha)) return false;
            if ((source.FechaVencimiento == null) ? (target.FechaVencimiento.HasValue) : !source.FechaVencimiento.Equals(target.FechaVencimiento)) return false;
            if ((source.IdPlanPeriodo == null) ? (target.IdPlanPeriodo.HasValue && target.IdPlanPeriodo.Value > 0) : !source.IdPlanPeriodo.Equals(target.IdPlanPeriodo)) return false;
            if ((source.Monto == null) ? (target.Monto.HasValue) : !source.Monto.Equals(target.Monto)) return false;
            if ((source.Ejercicio == null) ? (target.Ejercicio.HasValue) : !source.Ejercicio.Equals(target.Ejercicio)) return false;
            if ((source.DuracionMeses == null) ? (target.DuracionMeses.HasValue) : !source.DuracionMeses.Equals(target.DuracionMeses)) return false;
            if ((source.InformeTecnico == null) ? target.InformeTecnico != null : !((target.InformeTecnico == String.Empty && source.InformeTecnico == null) || (target.InformeTecnico == null && source.InformeTecnico == String.Empty)) && !source.InformeTecnico.Trim().Replace("\r", "").Equals(target.InformeTecnico.Trim().Replace("\r", ""))) return false;
            if ((source.FechaComiteTecnico == null) ? (target.FechaComiteTecnico.HasValue) : !source.FechaComiteTecnico.Equals(target.FechaComiteTecnico)) return false;
            if ((source.Observacion == null) ? target.Observacion != null : !((target.Observacion == String.Empty && source.Observacion == null) || (target.Observacion == null && source.Observacion == String.Empty)) && !source.Observacion.Trim().Replace("\r", "").Equals(target.Observacion.Trim().Replace("\r", ""))) return false;
            if ((source.Recomendacion == null) ? target.Recomendacion != null : !((target.Recomendacion == String.Empty && source.Recomendacion == null) || (target.Recomendacion == null && source.Recomendacion == String.Empty)) && !source.Recomendacion.Trim().Replace("\r", "").Equals(target.Recomendacion.Trim().Replace("\r", ""))) return false;
            if ((source.RespuestaOrganismo == null) ? target.RespuestaOrganismo != null : !((target.RespuestaOrganismo == String.Empty && source.RespuestaOrganismo == null) || (target.RespuestaOrganismo == null && source.RespuestaOrganismo == String.Empty)) && !source.RespuestaOrganismo.Trim().Replace("\r", "").Equals(target.RespuestaOrganismo.Trim().Replace("\r", ""))) return false;
            if ((source.FechaRepuesta == null) ? (target.FechaRepuesta.HasValue) : !source.FechaRepuesta.Equals(target.FechaRepuesta)) return false;
            if (!source.FechaEstado.Equals(target.FechaEstado)) return false;
            if ((source.Numero == null) ? target.Numero != null : !((target.Numero == String.Empty && source.Numero == null) || (target.Numero == null && source.Numero == String.Empty)) && !source.Numero.Trim().Replace("\r", "").Equals(target.Numero.Trim().Replace("\r", ""))) return false;
            if ((source.Denominacion == null) ? target.Denominacion != null : !((target.Denominacion == String.Empty && source.Denominacion == null) || (target.Denominacion == null && source.Denominacion == String.Empty)) && !source.Denominacion.Trim().Replace("\r", "").Equals(target.Denominacion.Trim().Replace("\r", ""))) return false;
            if ((source.IdProyectoDictamenEstadoUltimo == null) ? (target.IdProyectoDictamenEstadoUltimo.HasValue && target.IdProyectoDictamenEstadoUltimo.Value > 0) : !source.IdProyectoDictamenEstadoUltimo.Equals(target.IdProyectoDictamenEstadoUltimo)) return false;
            if (!source.PlanPeriodo_IdPlanTipo.Equals(target.PlanPeriodo_IdPlanTipo)) return false;
            if ((source.PlanPeriodo_Nombre == null) ? target.PlanPeriodo_Nombre != null : !((target.PlanPeriodo_Nombre == String.Empty && source.PlanPeriodo_Nombre == null) || (target.PlanPeriodo_Nombre == null && source.PlanPeriodo_Nombre == String.Empty)) && !source.PlanPeriodo_Nombre.Trim().Replace("\r", "").Equals(target.PlanPeriodo_Nombre.Trim().Replace("\r", ""))) return false;
            if ((source.PlanPeriodo_Sigla == null) ? target.PlanPeriodo_Sigla != null : !((target.PlanPeriodo_Sigla == String.Empty && source.PlanPeriodo_Sigla == null) || (target.PlanPeriodo_Sigla == null && source.PlanPeriodo_Sigla == String.Empty)) && !source.PlanPeriodo_Sigla.Trim().Replace("\r", "").Equals(target.PlanPeriodo_Sigla.Trim().Replace("\r", ""))) return false;
            if (!source.PlanPeriodo_AnioInicial.Equals(target.PlanPeriodo_AnioInicial)) return false;
            if (!source.PlanPeriodo_AnioFinal.Equals(target.PlanPeriodo_AnioFinal)) return false;
            if (!source.PlanPeriodo_Activo.Equals(target.PlanPeriodo_Activo)) return false;
            if ((source.ProyectoCalificacion_Nombre == null) ? target.ProyectoCalificacion_Nombre != null : !((target.ProyectoCalificacion_Nombre == String.Empty && source.ProyectoCalificacion_Nombre == null) || (target.ProyectoCalificacion_Nombre == null && source.ProyectoCalificacion_Nombre == String.Empty)) && !source.ProyectoCalificacion_Nombre.Trim().Replace("\r", "").Equals(target.ProyectoCalificacion_Nombre.Trim().Replace("\r", ""))) return false;
            if (!source.ProyectoCalificacion_Activo.Equals(target.ProyectoCalificacion_Activo)) return false;
            if (!source.ProyectoDictamenEstadoUltimo_IdProyectoDictamen.Equals(target.ProyectoDictamenEstadoUltimo_IdProyectoDictamen)) return false;
            if (!source.ProyectoDictamenEstadoUltimo_IdEstado.Equals(target.ProyectoDictamenEstadoUltimo_IdEstado)) return false;
            if (!source.ProyectoDictamenEstadoUltimo_Fecha.Equals(target.ProyectoDictamenEstadoUltimo_Fecha)) return false;
            if ((source.ProyectoDictamenEstadoUltimo_Observacion == null) ? target.ProyectoDictamenEstadoUltimo_Observacion != null : !((target.ProyectoDictamenEstadoUltimo_Observacion == String.Empty && source.ProyectoDictamenEstadoUltimo_Observacion == null) || (target.ProyectoDictamenEstadoUltimo_Observacion == null && source.ProyectoDictamenEstadoUltimo_Observacion == String.Empty)) && !source.ProyectoDictamenEstadoUltimo_Observacion.Trim().Replace("\r", "").Equals(target.ProyectoDictamenEstadoUltimo_Observacion.Trim().Replace("\r", ""))) return false;
            if (!source.ProyectoDictamenEstadoUltimo_IdUsuario.Equals(target.ProyectoDictamenEstadoUltimo_IdUsuario)) return false;

            return true;
        }
        #endregion
    }
}
