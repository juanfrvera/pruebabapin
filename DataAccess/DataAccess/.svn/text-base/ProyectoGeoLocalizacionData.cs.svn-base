using Contract;
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ProyectoGeoLocalizacionData : _ProyectoGeoLocalizacionData
    {

        #region Singleton
        
        private static volatile ProyectoGeoLocalizacionData current;
        
        private static object syncRoot = new Object();

        public static ProyectoGeoLocalizacionData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoLocalizacionData();
                    }
                }
                return current;
            }
        }

        #endregion

        public override string IdFieldName { get { return "IdGeoLocalizacion"; } }

        public ProyectoGeoLocalizacionResult QueryResultProyectoGeolocalizacion(ProyectoGeoLocalizacionFilter filter)
        {
            var query = (from o in Query(filter)
                         select new ProyectoGeoLocalizacionResult()
                         {
                             IdGeoLocalizacion = o.IdGeoLocalizacion,
                             IdProyecto = o.IdProyecto,
                             TipoLocalizacion = o.TipoLocalizacion,
                             InfoLocalizacion = o.InfoLocalizacion
                         }

                      ).FirstOrDefault();
            return query;
        }

        public List<ProyectoGeoLocalizacionResult> QueryResultProyectoGeolocalizaciones(ProyectoGeoLocalizacionFilter filter)
        {
            var query = (from o in Query(filter)
                         select new ProyectoGeoLocalizacionResult()
                         {
                             IdGeoLocalizacion = o.IdGeoLocalizacion,
                             IdProyecto = o.IdProyecto,
                             TipoLocalizacion = o.TipoLocalizacion,
                             InfoLocalizacion = o.InfoLocalizacion
                         }

                      ).ToList();
            return query;
        }

    }
}
