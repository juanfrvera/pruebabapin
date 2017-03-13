using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoFinanciamientoData : _PrestamoFinanciamientoData
    {
        #region Singleton
        private static volatile PrestamoFinanciamientoData current;
        private static object syncRoot = new Object();

        //private PrestamoFinanciamientoData() {}
        public static PrestamoFinanciamientoData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoFinanciamientoData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdPrestamoFinanciamiento"; } } 

        public List<PrestamoFinanciamientoResult> GetResultByPrestamoId(int id)
        {
            return (from o in this.Table
                    join t1 in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamiento equals t1.IdFuenteFinanciamiento
                    join t2 in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t2.IdPrestamoComponente
                    join t4 in this.Context.Objetivos on t2.IdObjetivo equals t4.IdObjetivo   
                    join _t3 in this.Context.PrestamoSubComponentes on o.IdPrestamoSubComponente equals _t3.IdPrestamoSubComponente into tt3
                    from t3 in tt3.DefaultIfEmpty()
                    where t2.IdPrestamo == id
                    select new PrestamoFinanciamientoResult()
                    {
                        IdPrestamoFinanciamiento = o.IdPrestamoFinanciamiento
                        ,
                        IdPrestamoComponente = o.IdPrestamoComponente
                        ,
                        IdPrestamoSubComponente = o.IdPrestamoSubComponente
                        ,
                        IdFuenteFinanciamiento = o.IdFuenteFinanciamiento
                        ,
                        Monto = o.Monto
                        ,
                        FuenteFinanciamiento_Codigo = t1.Codigo
                        ,
                        FuenteFinanciamiento_Nombre = t1.Nombre
                        ,
                        FuenteFinanciamiento_IdFuenteFinanciamientoTipo = t1.IdFuenteFinanciamientoTipo
                        ,
                        FuenteFinanciamiento_Activo = t1.Activo
                        ,
                        FuenteFinanciamiento_IdFuenteFinanciamientoPadre = t1.IdFuenteFinanciamientoPadre
                        ,
                        FuenteFinanciamiento_BreadcrumbId = t1.BreadcrumbId
                        ,
                        FuenteFinanciamiento_BreadcrumbOrden = t1.BreadcrumbOrden
                        ,
                        FuenteFinanciamiento_Nivel = t1.Nivel
                        ,
                        FuenteFinanciamiento_Orden = t1.Orden
                        ,
                        FuenteFinanciamiento_Descripcion = t1.Descripcion
                        ,
                        FuenteFinanciamiento_DescripcionInvertida = t1.DescripcionInvertida
                        ,
                        FuenteFinanciamiento_Seleccionable = t1.Seleccionable
                        ,
                        FuenteFinanciamiento_BreadcrumbCode = t1.BreadcrumbCode
                        ,
                        FuenteFinanciamiento_DescripcionCodigo = t1.DescripcionCodigo
                        ,
                        PrestamoComponente_IdPrestamo = t2.IdPrestamo
                        ,
                        PrestamoComponente_IdObjetivo = t2.IdObjetivo
                        ,
                        PrestamoSubComponente_IdPrestamoComponente = t3 != null ? (int?)t3.IdPrestamoComponente : null
                        ,
                        PrestamoSubComponente_Descripcion = t3 != null ? (string)t3.Descripcion : null
                        ,
                        PrestamoComponente_Nombre = t4.Nombre

                    }
                    ).ToList();
        }

        public List<PrestamoFinanciamiento> GetByPrestamoId(int id)
        {
            return (from o in this.Table
                    join t2 in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t2.IdPrestamoComponente
                    where t2.IdPrestamo == id
                    select o).ToList();
        }
    }
}
