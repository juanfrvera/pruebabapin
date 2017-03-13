using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{

    [Serializable]
    public abstract class ObjetivoCompose
    {
        private List<ObjetivoSupuestoResult> supuestos;
        private List<ObjetivoIndicadorCompose> indicadores;

        public List<ObjetivoSupuestoResult> Supuestos
        {
            get
            {
                if (supuestos == null)
                    supuestos = new List<ObjetivoSupuestoResult>();
                return supuestos;
            }
            set { supuestos = value; }
        }
        public List<ObjetivoIndicadorCompose> Indicadores
        {
            get
            {
                if (indicadores == null)
                    indicadores = new List<ObjetivoIndicadorCompose>();
                return indicadores;
            }
            set { indicadores = value; }
        }
    }

    [Serializable]
    public class ObjetivoIndicadorCompose
    {
        public ObjetivoIndicadorResult Indicador;      
        private List<IndicadorEvolucionResult> evoluciones;
        public List<IndicadorEvolucionResult> Evoluciones
        {
            get
            {
                if (evoluciones == null)
                    evoluciones = new List<IndicadorEvolucionResult>();
                return evoluciones;
            }
            set { evoluciones = value; }
        }

        public Int32 ID
        {
            get { return Indicador.IdIndicador; }
        }
    }
     

    [Serializable]
    public class ProyectoPropositoCompose : ObjetivoCompose
    {
        public ProyectoPropositoResult Proposito { get; set; }
        
    }

    [Serializable]
    public class ProyectoProductoCompose : ObjetivoCompose
    {
        public ProyectoProductoResult Producto { get; set; }
    }

    [Serializable]
    public class ProgramaObjetivoCompose : ObjetivoCompose
    {
        public ProgramaObjetivoResult ProgramaObjetivo { get; set; }
    }

    [Serializable]
    public class ProgramaObjetivosCompose
    {
        public int IdPrograma { get; set; }
        public ProgramaResult Programa { get; set; }

        private List<SubProgramaResult> subProgramas;
        public List<SubProgramaResult> SubProgramas
        {
            get
            {
                if (subProgramas == null)
                    subProgramas = new List<SubProgramaResult>();
                return subProgramas;
            }
            set { subProgramas = value; }
        }

        private List<ProgramaObjetivoCompose> objetivos;
        public List<ProgramaObjetivoCompose> Objetivos
        {
            get
            {
                if (objetivos == null)
                    objetivos = new List<ProgramaObjetivoCompose>();
                return objetivos;
            }
            set { objetivos = value; }
        }
    }    

    [Serializable]
    public class ProyectoObjetivosCompose
    {


        private List<ProgramaObjetivoResult> programas;
        public List<ProgramaObjetivoResult> Programas
        {
            get
            {
                if (programas == null)
                    programas = new List<ProgramaObjetivoResult>();
                return programas;
            }
            set { programas = value; }
        }

        private List<ProyectoPropositoCompose> propositos;
        public List<ProyectoPropositoCompose> Propositos
        {
            get
            {
                if (propositos == null)
                    propositos = new List<ProyectoPropositoCompose>();
                return propositos;
            }
            set { propositos = value; }
        }

        public ProyectoProductoCompose Producto { get; set; }

        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }
        public bool TieneProducto { get; set; }
    }

    [Serializable]
    public class PrestamoObjetivoCompose : ObjetivoCompose
    {
        public PrestamoObjetivoResult PrestamoObjetivo { get; set; }
    }

    [Serializable]
    public class PrestamoObjetivoEspecificoCompose : ObjetivoCompose
    {
        public PrestamoObjetivoEspecificoResult PrestamoObjetivoEspecifico { get; set; }
    }

    [Serializable]
    public class PrestamoObjetivosCompose
    {
        public PrestamoResult Prestamo { get; set; }
        public Int32 IdPrestamo
        {
            get { return Prestamo != null ? Prestamo.IdPrestamo : 0; }
        }



        private List<PrestamoObjetivoEspecificoCompose> objetivosEspecificos;
        public List<PrestamoObjetivoEspecificoCompose> ObjetivosEspecificos
        {
            get
            {
                if (objetivosEspecificos == null)
                    objetivosEspecificos = new List<PrestamoObjetivoEspecificoCompose>();
                return objetivosEspecificos;
            }
            set { objetivosEspecificos = value; }
        }

        public PrestamoObjetivoCompose Objetivo { get; set; }

        public bool TieneObjetivo { get; set; }
    }



}
