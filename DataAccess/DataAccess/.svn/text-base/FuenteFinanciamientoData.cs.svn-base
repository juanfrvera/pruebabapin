using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class FuenteFinanciamientoData : _FuenteFinanciamientoData
    {   
	   #region Singleton
	   private static volatile FuenteFinanciamientoData current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoData() {}
	   public static FuenteFinanciamientoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdFuenteFinanciamiento"; } } 
       public ListPaged<NodeResult> GetNodesResult(FuenteFinanciamientoFilter filter)
       {
           IQueryable<NodeResult> query = 
               (from ff in Query(filter)
                select new NodeResult()
                { Id = ff.IdFuenteFinanciamiento
                , Text = ff.Nombre
                , Codigo = ff.Codigo
                , Level =ff.Nivel.HasValue? 0: ff.Nivel.Value
                , Orden = ff.Orden.HasValue?ff.Orden.Value:0
                , BreadcrumbId = ff.BreadcrumbId
                , BreadcrumbOrden = ff.BreadcrumbOrden
                , BreadcrumbCodigo = ff.BreadcrumbCode
                , ParentId = ff.IdFuenteFinanciamientoPadre
                , Descripcion = ff.Descripcion
                , DescripcionInvertida = ff.DescripcionInvertida
                , Seleccionable = ff.Seleccionable
           }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }
       #region Query
       protected override IQueryable<FuenteFinanciamiento> Query(FuenteFinanciamientoFilter filter)
       {
           string strIdParent = filter.IdFuenteFinanciamientoPadre.HasValue ? "." + filter.IdFuenteFinanciamientoPadre.Value.ToString() + "." : string.Empty;

           return (from o in this.Table
                   where (filter.IdFuenteFinanciamiento == null || filter.IdFuenteFinanciamiento == 0 || o.IdFuenteFinanciamiento == filter.IdFuenteFinanciamiento)
                   && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.IdFuenteFinanciamientoTipo == null || filter.IdFuenteFinanciamientoTipo == 0 || o.IdFuenteFinanciamientoTipo == filter.IdFuenteFinanciamientoTipo)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.IdFuenteFinanciamientoPadre == null || filter.IdFuenteFinanciamientoPadre == 0 || filter.IncluirSubFuenteFinanciamiento == true || o.IdFuenteFinanciamientoPadre == filter.IdFuenteFinanciamientoPadre)
                   && (filter.IdFuenteFinanciamientoPadreIsNull == null || filter.IdFuenteFinanciamientoPadreIsNull == true || o.IdFuenteFinanciamientoPadre != null) && (filter.IdFuenteFinanciamientoPadreIsNull == null || filter.IdFuenteFinanciamientoPadreIsNull == false || o.IdFuenteFinanciamientoPadre == null)
                   && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%" || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%", ""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%", ""))) || o.BreadcrumbId == filter.BreadcrumbId)
                   && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%" || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%", ""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%", ""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden)
                   && (filter.Nivel == null || o.Nivel >= filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
                   && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
                   && (filter.Orden == null || o.Orden >= filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
                   && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
                   && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                   && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%" || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%", ""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%", ""))) || o.DescripcionInvertida == filter.DescripcionInvertida)
                   && (filter.Seleccionable == null || o.Seleccionable == filter.Seleccionable)
                   && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%" || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%", ""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%", ""))) || o.BreadcrumbCode == filter.BreadcrumbCode)
                   && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%" || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%", ""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%", ""))) || o.DescripcionCodigo == filter.DescripcionCodigo)
                   && (filter.IncluirSubFuenteFinanciamiento == null || filter.IncluirSubFuenteFinanciamiento == false || filter.IdFuenteFinanciamientoPadre == null || strIdParent == string.Empty
                          || o.BreadcrumbId.Contains(strIdParent))  
                   select o
                   ).AsQueryable();
       }
        protected override IQueryable<FuenteFinanciamientoResult> QueryResult(FuenteFinanciamientoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamientoPadre equals _t1.IdFuenteFinanciamiento into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.FuenteFinanciamientoTipos on o.IdFuenteFinanciamientoTipo equals t2.IdFuenteFinanciamientoTipo   
                    orderby o.Codigo, o.Descripcion
				   select new FuenteFinanciamientoResult(){
					 IdFuenteFinanciamiento=o.IdFuenteFinanciamiento
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,IdFuenteFinanciamientoTipo=o.IdFuenteFinanciamientoTipo
					 ,Activo=o.Activo
					 ,IdFuenteFinanciamientoPadre=o.IdFuenteFinanciamientoPadre
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumbOrden=o.BreadcrumbOrden
					 ,Nivel=o.Nivel
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
					,FuenteFinanciamientoPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,FuenteFinanciamientoPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo= t1!=null?(int?)t1.IdFuenteFinanciamientoTipo:null	
						,FuenteFinanciamientoPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre= t1!=null?(int?)t1.IdFuenteFinanciamientoPadre:null	
						,FuenteFinanciamientoPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,FuenteFinanciamientoPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null	
                        ,FuenteFinanciamientoPadre_BreadcrumbCodeOrden= t1!=null?(string)t1.BreadcrumbCode+o.Codigo:"."+o.Codigo
						,FuenteFinanciamientoPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,FuenteFinanciamientoPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,FuenteFinanciamientoPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,FuenteFinanciamientoPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,FuenteFinanciamientoPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,FuenteFinanciamientoPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,FuenteFinanciamientoPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,FuenteFinanciamientoTipo_Nombre= t2.Nombre	
						,FuenteFinanciamientoTipo_Nivel= t2.Nivel	
						}
                    ).AsQueryable();
        }
        #endregion
       public void RefreshFuenteFinanciamiento()
       {
           RefreshFuenteFinanciamiento(null);
       }
       public void RefreshFuenteFinanciamiento(int? idFuenteFinanciamiento)
       {
           LinqUtility.Context.RefreshFuenteFinanciamiento(null);
       }
       public void ActiveCascadaFuenteFinanciamiento(int? idOficina, bool? activar)
       {
           LinqUtility.Context.ActiveCascadaFuenteFinanciamiento(idOficina, activar);
       }

    }

}
