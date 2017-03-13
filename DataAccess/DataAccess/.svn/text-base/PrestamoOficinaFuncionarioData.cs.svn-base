using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoOficinaFuncionarioData : _PrestamoOficinaFuncionarioData
    {
        #region Singleton
        private static volatile PrestamoOficinaFuncionarioData current;
        private static object syncRoot = new Object();

        //private PrestamoOficinaFuncionarioData() {}
        public static PrestamoOficinaFuncionarioData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoOficinaFuncionarioData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdPrestamoOficinaFuncionario"; } } 


        protected override IQueryable<PrestamoOficinaFuncionarioResult> QueryResult(PrestamoOficinaFuncionarioFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.PrestamoOficinaPerfils on o.IdPrestamoOficinaPerfil equals t1.IdPrestamoOficinaPerfil
                    join t2 in this.Context.Usuarios on o.IdUsuario equals t2.IdUsuario
                    join persona in this.Context.Personas on t2.IdUsuario equals persona.IdPersona
                    where ( filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == t1.IdPrestamo )
                    select new PrestamoOficinaFuncionarioResult()
                    {
                        IdPrestamoOficinaPerfilFuncionario = o.IdPrestamoOficinaPerfilFuncionario
                        ,IdPrestamoOficinaPerfil = o.IdPrestamoOficinaPerfil
                        ,IdUsuario = o.IdUsuario
                        ,PrestamoOficinaPerfil_IdPrestamo = t1.IdPrestamo
                        ,PrestamoOficinaPerfil_IdOficina = t1.IdOficina
                        ,PrestamoOficinaPerfil_IdPerfil = t1.IdPerfil
                        ,Usuario_Nombre = persona.Nombre
                        ,Usuario_Apellido = persona.Apellido 
                        ,Selected = true
                    }
                      ).AsQueryable();
        }
    }
}
