using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoProductoProyectoEtapaResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoProductoProyectoEtapa; } }
        public int IdProyectoProductoProyectoEtapa { get; set; }
        public int IdProyectoProducto { get; set; }
        public int IdProyectoEtapa { get; set; }



        public virtual ProyectoProductoProyectoEtapa ToEntity()
        {
            ProyectoProductoProyectoEtapa _ProyectoProductoProyectoEtapa = new ProyectoProductoProyectoEtapa();
            _ProyectoProductoProyectoEtapa.IdProyectoProductoProyectoEtapa = this.IdProyectoProductoProyectoEtapa;
            _ProyectoProductoProyectoEtapa.IdProyectoProducto = this.IdProyectoProducto;
            _ProyectoProductoProyectoEtapa.IdProyectoEtapa = this.IdProyectoEtapa;

            return _ProyectoProductoProyectoEtapa;
        }
        public virtual void Set(ProyectoProductoProyectoEtapa entity)
        {
            this.IdProyectoProductoProyectoEtapa = entity.IdProyectoProductoProyectoEtapa;
            this.IdProyectoProducto = entity.IdProyectoProducto;
            this.IdProyectoEtapa = entity.IdProyectoEtapa;

        }
        public virtual bool Equals(ProyectoProductoProyectoEtapa entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoProductoProyectoEtapa.Equals(this.IdProyectoProductoProyectoEtapa)) return false;
            if (!entity.IdProyectoProducto.Equals(this.IdProyectoProducto)) return false;
            if (!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoProductoProyectoEtapa", new List<DataColumnMapping>(new DataColumnMapping[]{
        new DataColumnMapping("ProyectoProductoProyectoEtapa","IdProyectoProductoProyectoEtapa")
            ,new DataColumnMapping("ProyectoProducto","ProyectoProducto_IdProyectoProducto")
            ,new DataColumnMapping("ProyectoEtapa","ProyectoEtapa_Nombre")
            }));
        }
    }
}
