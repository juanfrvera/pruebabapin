using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class CaracterEconomicoData : _CaracterEconomicoData
    {
	   #region Singleton
	   private static volatile CaracterEconomicoData current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoData() {}
	   public static CaracterEconomicoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdCaracterEconomico"; } } 

       public ListPaged<NodeResult> GetNodesResult(CaracterEconomicoFilter filter)
       {
           IQueryable<NodeResult> query = 
               (from o in Query(filter)
                select new NodeResult()
                { Id = o.IdCaracterEconomico
                , Text = o.Nombre
                , Codigo = o.Codigo
                , Level = o.Nivel.HasValue?o.Nivel.Value:0
                , Orden = o.Orden.HasValue?o.Orden.Value:0
                , BreadcrumbId = o.BreadcrumbId
                , BreadcrumbOrden = o.BreadcrumbOrden
                , BreadcrumbCodigo = o.BreadcrumbCode
                , ParentId = o.IdCaracterEconomicoPadre
                , Descripcion = o.Descripcion
                , DescripcionInvertida = o.DescripcionInvertida
                , Seleccionable = o.Seleccionable.HasValue?o.Seleccionable.Value:false
           }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }

        protected override IQueryable<CaracterEconomicoResult> QueryResult(CaracterEconomicoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.CaracterEconomicos on o.IdCaracterEconomicoPadre equals _t1.IdCaracterEconomico into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.CaracterEconomicoTipos on o.IdCaracterEconomicoTipo equals t2.IdCaracterEconomicoTipo   
				   select new CaracterEconomicoResult(){
					 IdCaracterEconomico=o.IdCaracterEconomico
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,IdCaracterEconomicoTipo=o.IdCaracterEconomicoTipo
					 ,Activo=o.Activo
					 ,IdCaracterEconomicoPadre=o.IdCaracterEconomicoPadre
					 ,Visible=o.Visible
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumbOrden=o.BreadcrumbOrden
					 ,Nivel=o.Nivel
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
					,CaracterEconomicoPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,CaracterEconomicoPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,CaracterEconomicoPadre_IdCaracterEconomicoTipo= t1!=null?(int?)t1.IdCaracterEconomicoTipo:null	
						,CaracterEconomicoPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,CaracterEconomicoPadre_IdCaracterEconomicoPadre= t1!=null?(int?)t1.IdCaracterEconomicoPadre:null	
						,CaracterEconomicoPadre_Visible= t1!=null?(bool?)t1.Visible:null	
						,CaracterEconomicoPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,CaracterEconomicoPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null
                        ,CaracterEconomicoPadre_BreadcrumbCode = t1 != null ? (string)t1.BreadcrumbCode : null
                        ,CaracterEconomicoPadre_BreadcrumbCodeOrden= t1!=null?(string)t1.BreadcrumbCode+o.Codigo:"."+o.Codigo
						,CaracterEconomicoPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,CaracterEconomicoPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,CaracterEconomicoPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,CaracterEconomicoPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,CaracterEconomicoPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,CaracterEconomicoPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,CaracterEconomicoTipo_Nombre= t2.Nombre	
						,CaracterEconomicoTipo_Nivel= t2.Nivel	
						}
                    ).AsQueryable();
        }
       protected override IQueryable<CaracterEconomico> Query(CaracterEconomicoFilter filter)
       {
           string strIdParent = filter.IdCaracterEconomicoPadre.HasValue ? "."+filter.IdCaracterEconomicoPadre.Value.ToString() + "." : string.Empty;

           return (from o in this.Table
                   where (filter.IdCaracterEconomico == null || filter.IdCaracterEconomico == 0 || o.IdCaracterEconomico == filter.IdCaracterEconomico)
                   && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.IdCaracterEconomicoTipo == null || filter.IdCaracterEconomicoTipo == 0 || o.IdCaracterEconomicoTipo == filter.IdCaracterEconomicoTipo)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.IdCaracterEconomicoPadre == null || filter.IdCaracterEconomicoPadre == 0 || filter.IncluirSubCaracteres== true|| o.IdCaracterEconomicoPadre == filter.IdCaracterEconomicoPadre)
                   && (filter.IdCaracterEconomicoPadreIsNull == null || filter.IdCaracterEconomicoPadreIsNull == true || o.IdCaracterEconomicoPadre != null) && (filter.IdCaracterEconomicoPadreIsNull == null || filter.IdCaracterEconomicoPadreIsNull == false || o.IdCaracterEconomicoPadre == null)
                   && (filter.Visible == null || o.Visible == filter.Visible)
                   && (filter.VisibleIsNull == null || filter.VisibleIsNull == true || o.Visible != null) && (filter.VisibleIsNull == null || filter.VisibleIsNull == false || o.Visible == null)
                   && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%" || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%", ""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%", ""))) || o.BreadcrumbId == filter.BreadcrumbId)
                   && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%" || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%", ""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%", ""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden)
                   && (filter.Nivel == null || o.Nivel >= filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
                   && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
                   && (filter.Orden == null || o.Orden >= filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
                   && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
                   && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                   && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%" || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%", ""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%", ""))) || o.DescripcionInvertida == filter.DescripcionInvertida)
                   && (filter.Seleccionable == null || o.Seleccionable == filter.Seleccionable)
                   && (filter.SeleccionableIsNull == null || filter.SeleccionableIsNull == true || o.Seleccionable != null) && (filter.SeleccionableIsNull == null || filter.SeleccionableIsNull == false || o.Seleccionable == null)
                   && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%" || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%", ""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%", ""))) || o.BreadcrumbCode == filter.BreadcrumbCode)
                   && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%" || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%", ""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%", ""))) || o.DescripcionCodigo == filter.DescripcionCodigo)
                   && (filter.IncluirSubCaracteres == null || filter.IncluirSubCaracteres == false || filter.IdCaracterEconomicoPadre == null || strIdParent == string.Empty
                          || o.BreadcrumbId.Contains(strIdParent))
                   select o
                   ).AsQueryable();
       }	
    
       public void RefreshCaracterEconomico()
       {
           RefreshCaracterEconomico(null);
       }
       public void RefreshCaracterEconomico(int? idCaracterEconomico)
       {
           LinqUtility.Context.RefreshCaracterEconomico(null);
       }

       public void ActiveCascadaCaracterEconomico(int? idOficina, bool? activar)
       {
           LinqUtility.Context.ActiveCascadaCaracterEconomico(idOficina, activar);
       }
    }
}
