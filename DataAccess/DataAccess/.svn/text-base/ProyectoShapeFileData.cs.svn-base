using Contract;
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ProyectoShapeFileData : _ProyectoShapeFileData
    {
        #region Singleton

        private static volatile ProyectoShapeFileData current;

        private static object syncRoot = new Object();

        public static ProyectoShapeFileData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoShapeFileData();
                    }
                }
                return current;
            }
        }

        #endregion

        public override string IdFieldName { get { return "IdProyectoShapeFile"; } }

        public List<ProyectoShapeFileResult> QueryResultShapeFiles(ProyectoShapeFileFilter filter)
        {
            var query = (from o in Query(filter)
                         select new ProyectoShapeFileResult()
                         {
                             IdProyectoShapeFile = o.IdProyectoShapeFile,
                             IdProyecto = o.IdProyecto,
                             RutaArchivo = o.RutaArchivo
                         }

                      ).ToList();
            return query;
        }
    }
}
