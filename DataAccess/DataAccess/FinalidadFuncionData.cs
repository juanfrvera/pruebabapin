using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class FinalidadFuncionData : _FinalidadFuncionData
    { 
	   #region Singleton
	   private static volatile FinalidadFuncionData current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionData() {}
	   public static FinalidadFuncionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdFinalidadFuncion"; } }  
       public ListPaged<NodeResult> GetNodesResult(FinalidadFuncionFilter filter)
       {
           IQueryable<NodeResult> query = 
               (from ff in Query(filter)
                select new NodeResult()
                { Id = ff.IdFinalidadFuncion
                , Text = ff.Denominacion
                , Codigo = ff.Codigo
                , Level =ff.Nivel.HasValue? 0: ff.Nivel.Value
                , Orden = ff.Orden.HasValue?ff.Orden.Value:0
                , BreadcrumbId = ff.BreadcrumbId
                , BreadcrumbOrden = ff.BreadcrumbOrden
                , BreadcrumbCodigo = ff.BreadcrumbCode
                , ParentId = ff.IdFinalidadFuncionPadre
                , Descripcion = ff.Descripcion
                , DescripcionInvertida = ff.DescripcionInvertida
                , Seleccionable = ff.Seleccionable
           }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }
       #region Query
       protected override IQueryable<FinalidadFuncion> Query(FinalidadFuncionFilter filter)
       {
           string strIdParent = filter.IdFinalidadFuncionPadre.HasValue ? "." + filter.IdFinalidadFuncionPadre.Value.ToString() + "." : string.Empty;

           return (from o in this.Table
                   where (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || o.IdFinalidadFuncion == filter.IdFinalidadFuncion)
                   && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                   && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.IdFinalidadFunciontipo == null || filter.IdFinalidadFunciontipo == 0 || o.IdFinalidadFunciontipo == filter.IdFinalidadFunciontipo)
                   && (filter.IdFinalidadFunciontipoIsNull == null || filter.IdFinalidadFunciontipoIsNull == true || o.IdFinalidadFunciontipo != null) && (filter.IdFinalidadFunciontipoIsNull == null || filter.IdFinalidadFunciontipoIsNull == false || o.IdFinalidadFunciontipo == null)
                   && (filter.IdFinalidadFuncionPadre == null || filter.IdFinalidadFuncionPadre == 0 || filter.IncluirSubFinalidades == true || o.IdFinalidadFuncionPadre == filter.IdFinalidadFuncionPadre)
                   && (filter.IdFinalidadFuncionPadreIsNull == null || filter.IdFinalidadFuncionPadreIsNull == true || o.IdFinalidadFuncionPadre != null) && (filter.IdFinalidadFuncionPadreIsNull == null || filter.IdFinalidadFuncionPadreIsNull == false || o.IdFinalidadFuncionPadre == null)
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
                   && (filter.IncluirSubFinalidades == null || filter.IncluirSubFinalidades == false || filter.IdFinalidadFuncionPadre == null || strIdParent == string.Empty
                          || o.BreadcrumbId.Contains(strIdParent))
                   select o
                   ).AsQueryable();
       }
        protected override IQueryable<FinalidadFuncionResult> QueryResult(FinalidadFuncionFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.FinalidadFuncions on o.IdFinalidadFuncionPadre equals _t1.IdFinalidadFuncion into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.FinalidadFuncionTipos on o.IdFinalidadFunciontipo equals _t2.IdFinalidadFuncionTipo into tt2 from t2 in tt2.DefaultIfEmpty()
				   select new FinalidadFuncionResult(){
					 IdFinalidadFuncion=o.IdFinalidadFuncion
					 ,Codigo=o.Codigo
					 ,Denominacion=o.Denominacion
					 ,Activo=o.Activo
					 ,IdFinalidadFunciontipo=o.IdFinalidadFunciontipo
					 ,IdFinalidadFuncionPadre=o.IdFinalidadFuncionPadre
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumbOrden=o.BreadcrumbOrden
					 ,Nivel=o.Nivel
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
					,FinalidadFuncionPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,FinalidadFuncionPadre_Denominacion= t1!=null?(string)t1.Denominacion:null	
						,FinalidadFuncionPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,FinalidadFuncionPadre_IdFinalidadFunciontipo= t1!=null?(int?)t1.IdFinalidadFunciontipo:null	
						,FinalidadFuncionPadre_IdFinalidadFuncionPadre= t1!=null?(int?)t1.IdFinalidadFuncionPadre:null	
						,FinalidadFuncionPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,FinalidadFuncionPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null	
                        ,FinalidadFuncionPadre_BreadcrumbCodeOrden= t1!=null?(string)t1.BreadcrumbCode+o.Codigo:"."+o.Codigo
						,FinalidadFuncionPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,FinalidadFuncionPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,FinalidadFuncionPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,FinalidadFuncionPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,FinalidadFuncionPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,FinalidadFuncionPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,FinalidadFuncionPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,FinalidadFunciontipo_Nombre= t2!=null?(string)t2.Nombre:null	
						,FinalidadFunciontipo_Nivel= t2!=null?(int?)t2.Nivel:null	
						}
                    ).AsQueryable();
        }
		#endregion
        
       public void RefreshFinalidadFuncion()
       {
           RefreshFinalidadFuncion(null);
       }
       public void RefreshFinalidadFuncion(int? idFinalidadFuncion)
       {
           LinqUtility.Context.RefreshFinalidadFuncion(null);
       }
       public void ActiveCascadaFinalidadFuncion(int? idOficina, bool? activar)
       {
           LinqUtility.Context.ActiveCascadaFinalidadFuncion(idOficina, activar);
       }
    }
}
