using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OficinaData : _OficinaData 
    {   
	   #region Singleton
	   private static volatile OficinaData current;
	   private static object syncRoot = new Object();

	   //private OficinaData() {}
	   public static OficinaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOficina"; } } 

       public override ListPaged<SimpleResult<int>> GetSimpleList(OficinaFilter filter)
       {
           return ListPaged<SimpleResult<int>>((from o in Query(filter) select new SimpleResult<int> { ID = o.IdOficina, Text = o.DescripcionInvertida }).AsQueryable(), filter);
       }
       public ListPaged<NodeResult> GetNodesResult(OficinaFilter filter)
       {
           IQueryable<NodeResult> query = 
               (from o in Query(filter)
                select new NodeResult()
                { Id = o.IdOficina
                , Text = o.Nombre
                , Codigo = o.Codigo
                , Level = o.Nivel
                , Orden = o.Orden.HasValue?o.Orden.Value:0
                , BreadcrumbId = o.BreadcrumbId
                , BreadcrumbOrden = o.BreadcrumbOrden
                , BreadcrumbCodigo = o.BreadcrumbCode
                , ParentId = o.IdOficinaPadre
                , Descripcion = o.Descripcion
                , DescripcionInvertida = o.DescripcionInvertida
                , Seleccionable = o.Seleccionable
           }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }
       
        protected override IQueryable<Oficina> Query(OficinaFilter filter)
        {
            string strIdParent = filter.IdOficinaPadre.HasValue ? "." + filter.IdOficinaPadre.Value.ToString() + "." : string.Empty;

            return (from o in this.Table
                    where (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina == filter.IdOficina)
                    && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                    && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%" || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%", ""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%", ""))) || o.Codigo == filter.Codigo)
                    && (filter.Activo == null || o.Activo == filter.Activo)
                    && (filter.Visible == null || o.Visible == filter.Visible)
                    && (filter.IdOficinaPadre == null || filter.IdOficinaPadre == 0 || filter.IncluirOficinasInteriores == true || o.IdOficinaPadre == filter.IdOficinaPadre)
                    && (filter.IdOficinaPadreIsNull == null || filter.IdOficinaPadreIsNull == true || o.IdOficinaPadre != null ) && (filter.IdOficinaPadreIsNull == null || filter.IdOficinaPadreIsNull == false || o.IdOficinaPadre == null)
                    && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || (filter.IdSaf != 0 && filter.IdSaf != null) || (from os in this.Context.OficinaSafs where (from sa in this.Context.Safs where filter.IdJurisdiccion == sa.IdJurisdiccion select sa.IdSaf).Contains(os.IdSaf)select os.IdOficina).Contains(o.IdOficina))
                    && (filter.IdSaf == null || filter.IdSaf == 0 ||(from os in this.Context.OficinaSafs
                                    where os.IdSaf == filter.IdSaf
                                    select os.IdOficina).Contains(o.IdOficina))
                    && (filter.IdSafIsNull == null || filter.IdSafIsNull == true || o.IdSaf != null) && (filter.IdSafIsNull == null || filter.IdSafIsNull == false || o.IdSaf == null)
                    && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%" || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%", ""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%", ""))) || o.BreadcrumbId == filter.BreadcrumbId)
                    && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%" || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%", ""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%", ""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden)
                    && (filter.Nivel == null || o.Nivel >= filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
                    && (filter.Orden == null || o.Orden >= filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
                    && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
                    && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                    && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%" || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%", ""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%", ""))) || o.DescripcionInvertida == filter.DescripcionInvertida)
                    && (filter.Seleccionable == null || o.Seleccionable == filter.Seleccionable)
                    && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%" || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%", ""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%", ""))) || o.BreadcrumbCode == filter.BreadcrumbCode)
                    && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%" || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%", ""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%", ""))) || o.DescripcionCodigo == filter.DescripcionCodigo)
                    && (filter.IncluirOficinasInteriores == null || filter.IncluirOficinasInteriores == false || filter.IdOficinaPadre == null || strIdParent == string.Empty
                           || o.BreadcrumbId.Contains(strIdParent))
                     select o
                    ).AsQueryable();
        }
        protected override IQueryable<OficinaResult> QueryResult(OficinaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				   join _t2  in this.Context.Safs on o.IdSaf equals _t2.IdSaf into tt2 from t2 in tt2.DefaultIfEmpty()
                  join _t3 in this.Context.Jurisdiccions on t2.IdJurisdiccion equals _t3.IdJurisdiccion into tt3 from t3 in tt3.DefaultIfEmpty()
                  join _t4 in this.Context.Oficinas on o.IdOficinaPadre equals _t4.IdOficina into tt4 from t4 in tt4.DefaultIfEmpty()
				   select new OficinaResult(){
					 IdOficina=o.IdOficina
					 ,Nombre=o.Nombre
					 ,Codigo=o.Codigo
					 ,Activo=o.Activo
					 ,Visible=o.Visible
					 ,IdOficinaPadre=o.IdOficinaPadre
					 ,IdSaf=o.IdSaf
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumbOrden=o.BreadcrumbOrden
					 ,Nivel=o.Nivel
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
                     ,BreadcrumbCode = o.BreadcrumbCode
                     ,Seleccionable = o.Seleccionable
                    ,OficinaPadre_Nombre= t4!=null?(string)t4.Nombre:null	
						,OficinaPadre_Codigo= t4!=null?(string)t4.Codigo:null	
						,OficinaPadre_Activo= t4!=null?(bool?)t4.Activo:null	
						,OficinaPadre_Visible= t4!=null?(bool?)t4.Visible:null	
                        ,OficinaPadre_IdOficinaPadre= t4!=null?(int?)t4.IdOficinaPadre:null
                        ,Oficina_NombrePadre= t4!=null?(string)t4.Nombre:null	
                        ,Oficina_DescripcionPadre= t4!=null?(string)t4.Descripcion:null
                        ,OficinaPadre_IdSaf= t4!=null?(int?)t4.IdSaf:null
                        ,OficinaPadre_BreadcrumbId= t4!=null?(string)t4.BreadcrumbId:null	
                        ,OficinaPadre_BreadcrumbOrden=t4!=null?(string)t4.BreadcrumbOrden:null	
	                    ,OficinaPadre_BreadcrumbCode= t4!=null?(string)t4.BreadcrumbCode:null
                        ,OficinaPadre_BreadcrumbCodeOrden= t4!=null?(string)t1.BreadcrumbCode+o.Codigo:"."+o.Codigo
                        ,OficinaPadre_Nivel= t4!=null?(int?)t4.Nivel:null	
                        ,OficinaPadre_Orden= t4!=null?(int?)t4.Orden:null	
                        ,OficinaPadre_Descripcion= t4!=null?(string)t4.Descripcion:null	
						,Saf_Codigo= t2!=null?(string)t2.Codigo:null	
						,Saf_Denominacion= t2!=null?(string)t2.Denominacion:null	
						,Saf_IdTipoOrganismo= t2!=null?(int?)t2.IdTipoOrganismo:null	
						,Saf_IdSector= t2!=null?(int?)t2.IdSector:null	
						,Saf_IdAdministracionTipo= t2!=null?(int?)t2.IdAdministracionTipo:null	
						,Saf_IdEntidadTipo= t2!=null?(int?)t2.IdEntidadTipo:null	
						,Saf_IdJurisdiccion= t2!=null?(int?)t2.IdJurisdiccion:null	
						,Saf_IdSubJurisdiccion= t2!=null?(int?)t2.IdSubJurisdiccion:null	
						,Saf_FechaAlta= t2!=null?(DateTime?)t2.FechaAlta:null	
						,Saf_FechaBaja= t2!=null?(DateTime?)t2.FechaBaja:null	
						,Saf_Activo= t2!=null?(bool?)t2.Activo:null	
                        ,Jurisdiccion_Codigo= t3!=null?(string)t3.Codigo:null	
                        ,Jurisdiccion_Nombre= t3!=null?(string)t3.Nombre:null
                       }
                    ).AsQueryable();
        }

       #region Store Procedures
       public List<int> GetIdsOficinaPorUsuario(int IdUsuario)
       {
           List<GetIdsOficinaPorUsuarioResult> result = LinqUtility.Context.GetIdsOficinaPorUsuario(IdUsuario).ToList();
           return (from o in result where o.IdOficina.HasValue ==true select o.IdOficina.Value).ToList();
       }
       public void RefreshOficina()
       {
           RefreshOficina(null);
       }
       public void RefreshOficina(int? idOficina)
       {
           LinqUtility.Context.RefreshOficina(null);
       }
       public void ActiveCascadaOficina(int? idOficina, bool? activar)
       {
           LinqUtility.Context.ActiveCascadaOficina(idOficina, activar);
       }
       #endregion
    }
}
