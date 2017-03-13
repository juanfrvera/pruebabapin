using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoFileResult : _ProyectoFileResult
    {
        public string Order
        {
            get { return ((DateTime)File_Date).Year.ToString() +
                         ((DateTime)File_Date).Month.ToString() +
                         (((DateTime)File_Date).Day < 10 ? "0" + ((DateTime)File_Date).Day.ToString() :
                                                                 ((DateTime)File_Date).Day.ToString())
                         + File_FileName; }
        }

        public bool Comparar(ProyectoFileResult target)
        {
            return this.IdProyectoFile == target.IdProyectoFile &&
                   this.IdProyecto == target.IdProyecto &&
                   this.IdFile == target.IdFile;
        }
    }
}
