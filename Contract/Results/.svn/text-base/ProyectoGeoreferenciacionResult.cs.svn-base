using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoGeoreferenciacionResult : _ProyectoGeoreferenciacionResult
    {
        public GeoreferenciacionResult Georeferenciacion { get; set; }
        public List<GeoreferenciacionPuntoResult> Puntos { get; set; }

        public ProyectoGeoreferenciacionResult()
        {
            Georeferenciacion = new GeoreferenciacionResult();
            Puntos = new List<GeoreferenciacionPuntoResult>();
        }

        public string NombreTipo
        {
            get { return GeoreferenciacionTipoConfig.GetConst((GeoreferenciacionTipoEnum)this.Georeferenciacion.IdGeoreferenciacionTipo); }
        }
        public string Detalle
        {
            get 
            {
                string descripcion = "";
                Puntos.Sort(delegate(GeoreferenciacionPuntoResult p1, GeoreferenciacionPuntoResult p2) { return p1.Orden.CompareTo(p2.Orden); });
                foreach (GeoreferenciacionPuntoResult p in Puntos)
                {
                    string punto = p.Orden + ": " + p.Latitud + ":" + p.Longitud;
                    descripcion += descripcion == "" ? punto : " / " + punto;
                }
                if (descripcion.Length > 100)
                    descripcion = descripcion.Substring(0, 97) + "...";
                return descripcion;
            }
        }
        public string Descripcion
        {
            get 
            {
                string descripcion = "";
                if (this.Puntos.Count > 0)
                {
                    if (this.Puntos[0].descripcion.Length > 100)
                        descripcion = this.Puntos[0].descripcion.Substring(0, 97) + "...";
                    else
                        descripcion = this.Puntos[0].descripcion;
                }
                return descripcion;
            }
        }
    }
}
