using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoOficinaPerfilResult : _PrestamoOficinaPerfilResult
    { 	
        public string Orden
        {
            get { return Oficina_Descripcion; }
        }

        public NodeResult OficinaNode
        { 
            get{
                    return  new NodeResult()
                    { Id = IdOficina
                    , Text = Oficina_Nombre
                    , Codigo = Oficina_Codigo
                    , Level = Oficina_Nivel
                    , Orden = Oficina_Orden.HasValue?Oficina_Orden.Value:0
                    , BreadcrumbId = Oficina_BreadcrumbId
                    , BreadcrumbOrden = Oficina_BreadcrumbOrden
                    , BreadcrumbCodigo = Oficina_BreadcrumbCode
                    , ParentId = Oficina_IdOficinaPadre
                    , Descripcion = Oficina_Descripcion
                    , DescripcionInvertida =Oficina_DescripcionInvertida
                    , Seleccionable = Oficina_Seleccionable
                    }; 
                }
            set
                {
                IdOficina = value==null?0: value.Id;
                Oficina_Nombre = value==null?"":value.Text;
                Oficina_Codigo =value==null?"": value.Codigo;
                Oficina_Nivel =value==null?0: value.Level;
                Oficina_Orden = value == null ? 0 : value.Orden;
                Oficina_BreadcrumbId = value == null ? "" : value.BreadcrumbId;
                Oficina_BreadcrumbOrden = value == null ? "" : value.BreadcrumbOrden;
                Oficina_BreadcrumbCode = value == null ? "" : value.BreadcrumbCodigo;
                Oficina_IdOficinaPadre = value == null ? null : value.ParentId;
                Oficina_Descripcion = value == null ? "" : value.Descripcion;
                Oficina_DescripcionInvertida = value == null ? "" : value.DescripcionInvertida;
                Oficina_Seleccionable = value == null ? false : value.Seleccionable;
                }
        }
    }
}
