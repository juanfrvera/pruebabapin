using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ClasificacionGastoData : _ClasificacionGastoData
    {  
        #region Singleton
        private static volatile ClasificacionGastoData current;
        private static object syncRoot = new Object();

        //private ClasificacionGastoData() {}
        public static ClasificacionGastoData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ClasificacionGastoData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdClasificacionGasto"; } } 

        public List<ClasificacionGastoResult> GetClasificacionGastos(bool PorCodigo, string text)
        {
            string TextDesc = !PorCodigo ? text : "";
            string TextCod  = PorCodigo ? text : "";

            var l2 = (from cg in this.Table
                      join cg2 in this.Table on cg.IdClasificacionGasto equals cg2.IdClasificacionGastoPadre
                      where cg.IdClasificacionGastoPadre == null
                         && TextDesc.Trim() == "%" || (TextDesc.EndsWith("%") && TextDesc.StartsWith("%") && (cg2.Nombre.EndsWith(TextDesc.Replace("%", "")))) || (TextDesc.EndsWith("%") && cg2.Nombre.StartsWith(TextDesc.Replace("%", ""))) || (TextDesc.StartsWith("%") && cg2.Nombre.EndsWith(TextDesc.Replace("%", ""))) || cg2.Nombre == TextDesc
                         && TextCod.Trim() == "%" || (TextCod.EndsWith("%") && TextCod.StartsWith("%") && (cg2.Codigo.EndsWith(TextCod.Replace("%", "")))) || (TextCod.EndsWith("%") && cg2.Codigo.StartsWith(TextCod.Replace("%", ""))) || (TextCod.StartsWith("%") && cg2.Codigo.EndsWith(TextCod.Replace("%", ""))) || cg2.Codigo == TextCod
                      select new ClasificacionGastoResult
                      {
                          IdClasificacionGasto = cg2.IdClasificacionGasto,
                          Codigo = cg2.Codigo,
                          Nombre = cg2.Nombre
                      });

            var l3 = (from cg in this.Table
                      join cg2 in this.Table on cg.IdClasificacionGasto equals cg2.IdClasificacionGastoPadre
                      join cg3 in this.Table on cg2.IdClasificacionGasto equals cg3.IdClasificacionGastoPadre
                      where cg.IdClasificacionGastoPadre == null
                         && TextDesc.Trim() == "%" || (TextDesc.EndsWith("%") && TextDesc.StartsWith("%") && (cg3.Nombre.EndsWith(TextDesc.Replace("%", "")))) || (TextDesc.EndsWith("%") && cg3.Nombre.StartsWith(TextDesc.Replace("%", ""))) || (TextDesc.StartsWith("%") && cg3.Nombre.EndsWith(TextDesc.Replace("%", ""))) || cg3.Nombre == TextDesc
                         && TextCod.Trim() == "%" || (TextCod.EndsWith("%") && TextCod.StartsWith("%") && (cg3.Codigo.EndsWith(TextCod.Replace("%", "")))) || (TextCod.EndsWith("%") && cg3.Codigo.StartsWith(TextCod.Replace("%", ""))) || (TextCod.StartsWith("%") && cg3.Codigo.EndsWith(TextCod.Replace("%", ""))) || cg3.Codigo == TextCod
                      select new ClasificacionGastoResult
                      {
                          IdClasificacionGasto = cg3.IdClasificacionGasto,
                          Codigo = cg3.Codigo,
                          Nombre = cg3.Nombre
                      });
            
            return  (from r in l2.Union(l3) orderby r.Codigo, r.Nombre select r).ToList();
        }
       public ListPaged<NodeResult> GetNodesResult(ClasificacionGastoFilter filter)
       {
           IQueryable<NodeResult> query = 
               (from cg in Query(filter)
                select new NodeResult()
                { Id = cg.IdClasificacionGasto
                , Text = cg.Nombre
                , Codigo = cg.Codigo
                , Level =cg.Nivel.HasValue? 0: cg.Nivel.Value
                , Orden = cg.Orden.HasValue?cg.Orden.Value:0
                , BreadcrumbId = cg.BreadcrumbId
                , BreadcrumbOrden = cg.BreadcrumbOrden
                , BreadcrumbCodigo = cg.BreadcrumbCode
                , ParentId = cg.IdClasificacionGastoPadre
                , Descripcion = cg.Descripcion
                , DescripcionInvertida = cg.DescripcionInvertida
                , Seleccionable = cg.Seleccionable
           }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }
       #region Query
       protected override IQueryable<ClasificacionGasto> Query(ClasificacionGastoFilter filter)
       {
           string strIdParent = filter.IdClasificacionGastoPadre.HasValue ? "."+filter.IdClasificacionGastoPadre.Value.ToString()+"." : string.Empty;

           string strIdParentCaracterEco = filter.IdCaracterEconomico.HasValue ? "." + filter.IdCaracterEconomico.Value.ToString() + "." : string.Empty;

           return (from o in this.Table
                   where (filter.IdClasificacionGasto == null || filter.IdClasificacionGasto == 0 || o.IdClasificacionGasto == filter.IdClasificacionGasto)
                   && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.IdClasificacionGastoTipo == null || filter.IdClasificacionGastoTipo == 0 || o.IdClasificacionGastoTipo == filter.IdClasificacionGastoTipo)
                   && (filter.IdCaracterEconomico == null || filter.IdCaracterEconomico == 0 || filter.IncluirkSubCaracterEconomico == true || o.IdCaracterEconomico == filter.IdCaracterEconomico)
                   && (filter.IdCaracterEconomicoIsNull == null || filter.IdCaracterEconomicoIsNull == true || o.IdCaracterEconomico != null) && (filter.IdCaracterEconomicoIsNull == null || filter.IdCaracterEconomicoIsNull == false || o.IdCaracterEconomico == null)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.IdClasificacionGastoPadre == null || filter.IdClasificacionGastoPadre == 0 || filter.IncluirSubClasificaciones == true || o.IdClasificacionGastoPadre == filter.IdClasificacionGastoPadre)
                   && (filter.IdClasificacionGastoPadreIsNull == null || filter.IdClasificacionGastoPadreIsNull == true || o.IdClasificacionGastoPadre != null) && (filter.IdClasificacionGastoPadreIsNull == null || filter.IdClasificacionGastoPadreIsNull == false || o.IdClasificacionGastoPadre == null)
                   && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%" || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%", ""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%", ""))) || o.BreadcrumbId == filter.BreadcrumbId)
                   && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%" || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%", ""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%", ""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden)
                   && (filter.Nivel == null || o.Nivel >= filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
                   && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
                   && (filter.Orden == null || o.Orden >= filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
                   && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
                   && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                   && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%" || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%", ""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%", ""))) || o.DescripcionInvertida == filter.DescripcionInvertida)
                   && (filter.IdClasificacionGastoRubro == null || filter.IdClasificacionGastoRubro == 0 || o.IdClasificacionGastoRubro == filter.IdClasificacionGastoRubro)
                   && (filter.Seleccionable == null || o.Seleccionable == filter.Seleccionable)
                   && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%" || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%", ""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%", ""))) || o.BreadcrumbCode == filter.BreadcrumbCode)
                   && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%" || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%", ""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%", ""))) || o.DescripcionCodigo == filter.DescripcionCodigo)
                   && (filter.IncluirSubClasificaciones == null || filter.IncluirSubClasificaciones == false || filter.IdClasificacionGastoPadre == null || strIdParent == string.Empty
                          || o.BreadcrumbId.Contains(strIdParent))
                  && (filter.IncluirkSubCaracterEconomico == null || filter.IncluirkSubCaracterEconomico == false || filter.IdCaracterEconomico == null || strIdParentCaracterEco == string.Empty
                  || (from cg in this.Context.CaracterEconomicos where (o.IdCaracterEconomico.HasValue && cg.IdCaracterEconomico == o.IdCaracterEconomico.Value) & cg.BreadcrumbId.Contains(strIdParentCaracterEco) select o.IdClasificacionGasto).Count() > 0)
                   select o
                   ).AsQueryable();
       }	
        protected override IQueryable<ClasificacionGastoResult> QueryResult(ClasificacionGastoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.ClasificacionGastos on o.IdClasificacionGastoPadre equals _t1.IdClasificacionGasto into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.ClasificacionGastoRubros on o.IdClasificacionGastoRubro equals t2.IdClasificacionGastoRubro   
				    join t3  in this.Context.ClasificacionGastoTipos on o.IdClasificacionGastoTipo equals t3.IdClasificacionGastoTipo   
                    join _t4  in this.Context.CaracterEconomicos on o.IdCaracterEconomico equals _t4.IdCaracterEconomico into tt4 from t4 in tt4.DefaultIfEmpty()
				   select new ClasificacionGastoResult(){
					 IdClasificacionGasto=o.IdClasificacionGasto
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,IdClasificacionGastoTipo=o.IdClasificacionGastoTipo
					 ,IdCaracterEconomico=o.IdCaracterEconomico
					 ,Activo=o.Activo
					 ,IdClasificacionGastoPadre=o.IdClasificacionGastoPadre
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumbOrden=o.BreadcrumbOrden
					 ,Nivel=o.Nivel
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,IdClasificacionGastoRubro=o.IdClasificacionGastoRubro
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
                     ,CaracterEconomico_Nombre = t4!=null?(string)t4.Nombre:null
					,ClasificacionGastoPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,ClasificacionGastoPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,ClasificacionGastoPadre_IdClasificacionGastoTipo= t1!=null?(int?)t1.IdClasificacionGastoTipo:null	
						,ClasificacionGastoPadre_IdCaracterEconomico= t1!=null?(int?)t1.IdCaracterEconomico:null	
						,ClasificacionGastoPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,ClasificacionGastoPadre_IdClasificacionGastoPadre= t1!=null?(int?)t1.IdClasificacionGastoPadre:null	
						,ClasificacionGastoPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,ClasificacionGastoPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null	
						,ClasificacionGastoPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null
                        ,ClasificacionGastoPadre_BreadcrumbCodeOrden= t1!=null?(string)t1.BreadcrumbCode+o.Codigo:"."+o.Codigo	
						,ClasificacionGastoPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,ClasificacionGastoPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,ClasificacionGastoPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,ClasificacionGastoPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,ClasificacionGastoPadre_IdClasificacionGastoRubro= t1!=null?(int?)t1.IdClasificacionGastoRubro:null	
						,ClasificacionGastoPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null		
						,ClasificacionGastoPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,ClasificacionGastoRubro_Codigo= t2.Codigo	
						,ClasificacionGastoRubro_Nombre= t2.Nombre	
						,ClasificacionGastoTipo_Nombre= t3.Nombre	
						,ClasificacionGastoTipo_Nivel= t3.Nivel	
						}
                    ).AsQueryable();
        }
		#endregion
       public void RefreshClasificacionGasto()
       {
           RefreshClasificacionGasto(null);
       }
       public void RefreshClasificacionGasto(int? idClasificacionGasto)
       {
           LinqUtility.Context.RefreshClasificacionGasto(null);
       }
       public void ActiveCascadaClasificacionGasto(int? idOficina, bool? activar)
       {
           LinqUtility.Context.ActiveCascadaClasificacionGasto(idOficina, activar);
       }
    }
}
