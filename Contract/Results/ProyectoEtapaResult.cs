using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoEtapaResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoEtapa; } }
        public int IdProyectoEtapa { get; set; }
        public string Nombre { get; set; }
        public string CodigoVinculacion { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaInicioEstimada { get; set; }
        public DateTime? FechaFinEstimada { get; set; }
        public DateTime? FechaInicioRealizada { get; set; }
        public DateTime? FechaFinRealizada { get; set; }
        public int IdEtapa { get; set; }
        public int IdProyecto { get; set; }
        public int? NroEtapa { get; set; }

        public string Estado_Nombre { get; set; }
        public int Etapa_IdFase { get; set; }
        public string Etapa_Nombre { get; set; }
        public int Etapa_Orden { get; set; }
        public string Etapa_Codigo { get; set; }
        public string Fase_Nombre { get; set; }
        public string Fase_Codigo { get; set; }
        public int Fase_Orden { get; set; }
        public virtual ProyectoEtapa ToEntity()
        {
            ProyectoEtapa _ProyectoEtapa = new ProyectoEtapa();
            _ProyectoEtapa.IdProyectoEtapa = this.IdProyectoEtapa;
            _ProyectoEtapa.Nombre = this.Nombre;
            _ProyectoEtapa.CodigoVinculacion = this.CodigoVinculacion;
            _ProyectoEtapa.IdEstado = this.IdEstado;
            _ProyectoEtapa.FechaInicioEstimada = this.FechaInicioEstimada;
            _ProyectoEtapa.FechaFinEstimada = this.FechaFinEstimada;
            _ProyectoEtapa.FechaInicioRealizada = this.FechaInicioRealizada;
            _ProyectoEtapa.FechaFinRealizada = this.FechaFinRealizada;
            _ProyectoEtapa.IdEtapa = this.IdEtapa;
            _ProyectoEtapa.IdProyecto = this.IdProyecto;
            _ProyectoEtapa.NroEtapa = this.NroEtapa;

            return _ProyectoEtapa;
        }
        public virtual void Set(ProyectoEtapa entity)
        {
            this.IdProyectoEtapa = entity.IdProyectoEtapa;
            this.Nombre = entity.Nombre;
            this.CodigoVinculacion = entity.CodigoVinculacion;
            this.IdEstado = entity.IdEstado;
            this.FechaInicioEstimada = entity.FechaInicioEstimada;
            this.FechaFinEstimada = entity.FechaFinEstimada;
            this.FechaInicioRealizada = entity.FechaInicioRealizada;
            this.FechaFinRealizada = entity.FechaFinRealizada;
            this.IdEtapa = entity.IdEtapa;
            this.IdProyecto = entity.IdProyecto;
            this.NroEtapa = entity.NroEtapa;

        }
        public virtual bool Equals(ProyectoEtapa entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa)) return false;
            if (!entity.Nombre.Equals(this.Nombre)) return false;
            if ((entity.CodigoVinculacion == null) ? this.CodigoVinculacion != null : !entity.CodigoVinculacion.Equals(this.CodigoVinculacion)) return false;
            if ((entity.IdEstado == null) ? (this.IdEstado.HasValue && this.IdEstado.Value > 0) : !entity.IdEstado.Equals(this.IdEstado)) return false;
            if ((entity.FechaInicioEstimada == null) ? this.FechaInicioEstimada != null : !entity.FechaInicioEstimada.Equals(this.FechaInicioEstimada)) return false;
            if ((entity.FechaFinEstimada == null) ? this.FechaFinEstimada != null : !entity.FechaFinEstimada.Equals(this.FechaFinEstimada)) return false;
            if ((entity.FechaInicioRealizada == null) ? this.FechaInicioRealizada != null : !entity.FechaInicioRealizada.Equals(this.FechaInicioRealizada)) return false;
            if ((entity.FechaFinRealizada == null) ? this.FechaFinRealizada != null : !entity.FechaFinRealizada.Equals(this.FechaFinRealizada)) return false;
            if (!entity.IdEtapa.Equals(this.IdEtapa)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if ((entity.NroEtapa == null) ? this.NroEtapa != null : !entity.NroEtapa.Equals(this.NroEtapa)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoEtapa", new List<DataColumnMapping>(new DataColumnMapping[]{
            new DataColumnMapping("Nombre","Nombre")
                ,new DataColumnMapping("CodigoVinculacion","CodigoVinculacion")
                ,new DataColumnMapping("Estado","Estado_Nombre")
                ,new DataColumnMapping("FechaInicioEstimada","FechaInicioEstimada","{0:dd/MM/yyyy}")
                ,new DataColumnMapping("FechaFinEstimada","FechaFinEstimada","{0:dd/MM/yyyy}")
                ,new DataColumnMapping("FechaInicioRealizada","FechaInicioRealizada","{0:dd/MM/yyyy}")
                ,new DataColumnMapping("FechaFinRealizada","FechaFinRealizada","{0:dd/MM/yyyy}")
                ,new DataColumnMapping("Etapa","Etapa_Nombre")
                ,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
                ,new DataColumnMapping("NroEtapa","NroEtapa")
                }));
        }

        public string Descripcion
        {
            get
            {
                return Apertura + " " + Nombre;
            }
        }
        public string DescripcionCorta
        {
            get
            {
                string descripcion = ProyectoDenominacion;

                if (this.IdEtapa == (int)EtapaEnum.ActividadEspecifica)
                {
                    descripcion = "ACTIVIDAD ESPECÍFICA " + descripcion;
                }

                if (descripcion.Length > 60)
                    descripcion = descripcion.Substring(0, 57) + "...";

                return descripcion;
            }
        }
        public decimal? TotalEstimado { get; set; }
        public decimal? TotalRealizado { get; set; }
        public string NroEtapaConCeros
        {
            get
            {
                return this.NroEtapa < 10 ? "0" + this.NroEtapa.ToString() :
                                                  this.NroEtapa.ToString();
            }
        }

        public string Tipo
        {
            get
            {
                return this.Etapa_Nombre;
            }
        }
        public string Orden
        {
            get
            {
                return this.Etapa_Nombre + this.Nombre;
            }
        }
        public bool EsDeEjecucion
        {
            get
            {
                return (this.Etapa_IdFase == (Int32)FaseEnum.Ejecucion);
            }
        }

        public string ProyectoDenominacion { set; get; }
        public string NroProyecto { set; get; }
        public string NroActividad { set; get; }
        public string NroObra { set; get; }

        public bool EsObra
        {
            get { return this.IdEtapa == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_ETAPA_OBRA"); }
        }
        public string Apertura
        {
            get
            {
                //Matias 20170203 - Ticket #REQ792885
                //string proy = NroProyecto != "" & NroProyecto != 0.ToString() ? NroProyecto : "00";
                //string etap = NroEtapa.ToString() == "" ? "00" : NroEtapa.ToString();
                string proy = (NroProyecto == null || NroProyecto == "" || NroProyecto == 0.ToString()) ? "00" : NroProyecto;
                string etap = (NroEtapa == null || NroEtapa.ToString() == "") ? "00" : NroEtapa.ToString();
                //Matias 20170203 - Ticket #REQ792885

                if (proy.Length == 1)
                    proy = "0" + proy;
                
                if (etap.Length == 1)
                    etap = "0" + etap;

                if (this.EsObra)
                    return proy + ".00." + etap;
                return proy + "." + etap + ".00";
            }
        }
        public string CodigoPresupuestario
        {
            get
            {
                //Matias 20170203 - Ticket #REQ792885
                //string proy = NroProyecto != "" & NroProyecto != 0.ToString() ? NroProyecto : "00";
                //string etap = NroEtapa.ToString() == "" ? "00" : NroEtapa.ToString();
                string proyecto = (NroProyecto == null || NroProyecto == "" || NroProyecto == 0.ToString()) ? "00" : NroProyecto;
                string actividad = (NroActividad == null || NroActividad == "" || NroActividad == 0.ToString()) ? "00" : NroActividad;
                string obra = (NroObra == null || NroObra == "" || NroObra == 0.ToString()) ? "00" : NroObra;
                //Matias 20170203 - Ticket #REQ792885

                if (proyecto.Length == 1)
                    proyecto = "0" + proyecto;

                if (actividad.Length == 1)
                    actividad = "0" + actividad;

                if (obra.Length == 1)
                    obra = "0" + obra;

                return proyecto + "." + actividad + "." + obra;
            }
        }

        public Int32 IdCopyProyectoEtapa { get; set; }
    }
}
