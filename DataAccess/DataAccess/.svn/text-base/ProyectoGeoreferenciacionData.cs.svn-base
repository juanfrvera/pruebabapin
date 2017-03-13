using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoGeoreferenciacionData : _ProyectoGeoreferenciacionData
    {
        #region Singleton
        private static volatile ProyectoGeoreferenciacionData current;
        private static object syncRoot = new Object();

        //private ProyectoGeoreferenciacionData() {}
        public static ProyectoGeoreferenciacionData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoreferenciacionData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdProyectoGeoreferenciacion"; } }

        public List<ProyectoGeoreferenciacionResult> GetGeoreferenciaciones(ProyectoGeoreferenciacionFilter filter)
        {
            List<ProyectoGeoreferenciacionResult> retval = new List<ProyectoGeoreferenciacionResult>();
            if (filter.IdProyecto > 0)
            {
                // Busca los datos
                var pgs = (from pg in this.Table where pg.IdProyecto == filter.IdProyecto select pg);
                var gs = (from g in this.Context.Georeferenciacions
                          join pg in pgs on g.IdGeoreferenciacion equals pg.IdGeoreferenciacion
                          select g);
                var ps = (from p in this.Context.GeoreferenciacionPuntos
                          join pg in pgs on p.IdGeoreferenciacion equals pg.IdGeoreferenciacion
                          select p);

                // Carga el resultado
                foreach (ProyectoGeoreferenciacion pg in pgs.ToList())
                { 
                    ProyectoGeoreferenciacionResult pgr = new ProyectoGeoreferenciacionResult();
                    pgr.IdProyectoGeoreferenciacion = pg.IdProyectoGeoreferenciacion;
                    pgr.IdGeoreferenciacion = pg.IdGeoreferenciacion;
                    pgr.IdProyecto = pg.IdProyecto;

                    foreach (Georeferenciacion g in gs.Where(t => t.IdGeoreferenciacion == pg.IdGeoreferenciacion).ToList())
                    {
                        foreach (GeoreferenciacionPunto p in ps.Where(t => t.IdGeoreferenciacion == g.IdGeoreferenciacion).ToList())
                        {
                            GeoreferenciacionPuntoResult pr = new GeoreferenciacionPuntoResult();
                            pr.IdGeoreferenciacionPunto = p.IdGeoreferenciacionPunto;
                            pr.IdGeoreferenciacion = p.IdGeoreferenciacion;
                            pr.Orden = p.Orden;
                            pr.Latitud = p.Latitud;
                            pr.Longitud = p.Longitud;
                            pr.descripcion = p.descripcion;
                            pgr.Puntos.Add(pr);
                        }
                        GeoreferenciacionResult gr = new GeoreferenciacionResult();
                        gr.IdGeoreferenciacion = g.IdGeoreferenciacion;
                        gr.IdGeoreferenciacionTipo = g.IdGeoreferenciacionTipo;
                        pgr.Georeferenciacion = gr;
                    }

                    retval.Add(pgr);
                }
            }

            return retval;
        }
    }
}
