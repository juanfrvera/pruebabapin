using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _ClasificacionGeograficaData : EntityData<ClasificacionGeografica,ClasificacionGeograficaFilter,ClasificacionGeograficaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ClasificacionGeografica entity)
		{			
			return entity.IdClasificacionGeografica;
		}		
		public override ClasificacionGeografica GetByEntity(ClasificacionGeografica entity)
        {
            return this.GetById(entity.IdClasificacionGeografica);
        }
        public override ClasificacionGeografica GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacionGeografica == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ClasificacionGeografica> Query(ClasificacionGeograficaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdClasificacionGeograficaTipo == null || filter.IdClasificacionGeograficaTipo == 0 || o.IdClasificacionGeograficaTipo==filter.IdClasificacionGeograficaTipo)
					  && (filter.IdClasificacionGeograficaPadre == null || filter.IdClasificacionGeograficaPadre == 0 || o.IdClasificacionGeograficaPadre==filter.IdClasificacionGeograficaPadre)
					  && (filter.IdClasificacionGeograficaPadreIsNull == null || filter.IdClasificacionGeograficaPadreIsNull == true || o.IdClasificacionGeograficaPadre != null ) && (filter.IdClasificacionGeograficaPadreIsNull == null || filter.IdClasificacionGeograficaPadreIsNull == false || o.IdClasificacionGeograficaPadre == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%"  || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%",""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%",""))) || o.BreadcrumbId == filter.BreadcrumbId )
					  && (filter.BreadcrumOrden == null || filter.BreadcrumOrden.Trim() == string.Empty || filter.BreadcrumOrden.Trim() == "%"  || (filter.BreadcrumOrden.EndsWith("%") && filter.BreadcrumOrden.StartsWith("%") && (o.BreadcrumOrden.Contains(filter.BreadcrumOrden.Replace("%", "")))) || (filter.BreadcrumOrden.EndsWith("%") && o.BreadcrumOrden.StartsWith(filter.BreadcrumOrden.Replace("%",""))) || (filter.BreadcrumOrden.StartsWith("%") && o.BreadcrumOrden.EndsWith(filter.BreadcrumOrden.Replace("%",""))) || o.BreadcrumOrden == filter.BreadcrumOrden )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null ) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null ) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
					  && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%"  || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%",""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%",""))) || o.DescripcionInvertida == filter.DescripcionInvertida )
					  && (filter.Seleccionable == null || o.Seleccionable==filter.Seleccionable)
					  && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%"  || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%",""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%",""))) || o.BreadcrumbCode == filter.BreadcrumbCode )
					  && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%"  || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%",""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%",""))) || o.DescripcionCodigo == filter.DescripcionCodigo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionGeograficaResult> QueryResult(ClasificacionGeograficaFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeograficaPadre equals _t1.IdClasificacionGeografica into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.ClasificacionGeograficaTipos on o.IdClasificacionGeograficaTipo equals t2.IdClasificacionGeograficaTipo   
				   select new ClasificacionGeograficaResult(){
					 IdClasificacionGeografica=o.IdClasificacionGeografica
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,IdClasificacionGeograficaTipo=o.IdClasificacionGeograficaTipo
					 ,IdClasificacionGeograficaPadre=o.IdClasificacionGeograficaPadre
					 ,Activo=o.Activo
					 ,Descripcion=o.Descripcion
					 ,BreadcrumbId=o.BreadcrumbId
					 ,BreadcrumOrden=o.BreadcrumOrden
					 ,Orden=o.Orden
					 ,Nivel=o.Nivel
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
						,ClasificacionGeograficaPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,ClasificacionGeograficaPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,ClasificacionGeograficaTipo_Nivel= t2.Nivel	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ClasificacionGeografica Copy(nc.ClasificacionGeografica entity)
        {           
            nc.ClasificacionGeografica _new = new nc.ClasificacionGeografica();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.IdClasificacionGeograficaTipo= entity.IdClasificacionGeograficaTipo;
		 _new.IdClasificacionGeograficaPadre= entity.IdClasificacionGeograficaPadre;
		 _new.Activo= entity.Activo;
		 _new.Descripcion= entity.Descripcion;
		 _new.BreadcrumbId= entity.BreadcrumbId;
		 _new.BreadcrumOrden= entity.BreadcrumOrden;
		 _new.Orden= entity.Orden;
		 _new.Nivel= entity.Nivel;
		 _new.DescripcionInvertida= entity.DescripcionInvertida;
		 _new.Seleccionable= entity.Seleccionable;
		 _new.BreadcrumbCode= entity.BreadcrumbCode;
		 _new.DescripcionCodigo= entity.DescripcionCodigo;
		return _new;			
        }
		public override int CopyAndSave(ClasificacionGeografica entity,string renameFormat)
        {
            ClasificacionGeografica  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ClasificacionGeografica entity, int id)
        {            
            entity.IdClasificacionGeografica = id;            
        }
		public override void Set(ClasificacionGeografica source,ClasificacionGeografica target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.IdClasificacionGeograficaPadre= source.IdClasificacionGeograficaPadre ;
		 target.Activo= source.Activo ;
		 target.Descripcion= source.Descripcion ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumOrden= source.BreadcrumOrden ;
		 target.Orden= source.Orden ;
		 target.Nivel= source.Nivel ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 		  
		}
		public override void Set(ClasificacionGeograficaResult source,ClasificacionGeografica target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.IdClasificacionGeograficaPadre= source.IdClasificacionGeograficaPadre ;
		 target.Activo= source.Activo ;
		 target.Descripcion= source.Descripcion ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumOrden= source.BreadcrumOrden ;
		 target.Orden= source.Orden ;
		 target.Nivel= source.Nivel ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 
		}
		public override void Set(ClasificacionGeografica source,ClasificacionGeograficaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.IdClasificacionGeograficaPadre= source.IdClasificacionGeograficaPadre ;
		 target.Activo= source.Activo ;
		 target.Descripcion= source.Descripcion ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumOrden= source.BreadcrumOrden ;
		 target.Orden= source.Orden ;
		 target.Nivel= source.Nivel ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 	
		}		
		public override void Set(ClasificacionGeograficaResult source,ClasificacionGeograficaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.IdClasificacionGeograficaPadre= source.IdClasificacionGeograficaPadre ;
		 target.Activo= source.Activo ;
		 target.Descripcion= source.Descripcion ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumOrden= source.BreadcrumOrden ;
		 target.Orden= source.Orden ;
		 target.Nivel= source.Nivel ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.ClasificacionGeograficaPadre_Nombre= source.ClasificacionGeograficaPadre_Nombre;	
         target.ClasificacionGeograficaPadre_BreadcrumbCode= source.ClasificacionGeograficaPadre_BreadcrumbCode;	
         target.ClasificacionGeograficaTipo_Nivel= source.ClasificacionGeograficaTipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ClasificacionGeografica source,ClasificacionGeografica target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if((source.Codigo == null)?target.Codigo!=null:!source.Codigo.Equals(target.Codigo))return false;
			 if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			 if(!source.IdClasificacionGeograficaTipo.Equals(target.IdClasificacionGeograficaTipo))return false;
		  if((source.IdClasificacionGeograficaPadre == null)?(target.IdClasificacionGeograficaPadre.HasValue && target.IdClasificacionGeograficaPadre.Value > 0):!source.IdClasificacionGeograficaPadre.Equals(target.IdClasificacionGeograficaPadre))return false;
						  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null:!source.Descripcion.Equals(target.Descripcion))return false;
			 if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:!source.BreadcrumbId.Equals(target.BreadcrumbId))return false;
			 if((source.BreadcrumOrden == null)?target.BreadcrumOrden!=null:!source.BreadcrumOrden.Equals(target.BreadcrumOrden))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:!source.DescripcionInvertida.Equals(target.DescripcionInvertida))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:!source.BreadcrumbCode.Equals(target.BreadcrumbCode))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:!source.DescripcionCodigo.Equals(target.DescripcionCodigo))return false;
			
		  return true;
        }
		public override bool Equals(ClasificacionGeograficaResult source,ClasificacionGeograficaResult target)
        {
		    if(source == null && target == null)return true;
		    if(source == null )return false;
		    if(target == null)return false;
            if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		    if((source.Codigo == null)?target.Codigo!=null:!source.Codigo.Equals(target.Codigo))return false;
			if((source.Nombre == null)?target.Nombre!=null:!source.Nombre.Equals(target.Nombre))return false;
			if(!source.IdClasificacionGeograficaTipo.Equals(target.IdClasificacionGeograficaTipo))return false;
		    if((source.IdClasificacionGeograficaPadre == null)?(target.IdClasificacionGeograficaPadre.HasValue && target.IdClasificacionGeograficaPadre.Value > 0):!source.IdClasificacionGeograficaPadre.Equals(target.IdClasificacionGeograficaPadre))return false;
			if(!source.Activo.Equals(target.Activo))return false;
		    if((source.Descripcion == null)?target.Descripcion!=null:!source.Descripcion.Equals(target.Descripcion))return false;
			if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:!source.BreadcrumbId.Equals(target.BreadcrumbId))return false;
			if((source.BreadcrumOrden == null)?target.BreadcrumOrden!=null:!source.BreadcrumOrden.Equals(target.BreadcrumOrden))return false;
			if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:!source.DescripcionInvertida.Equals(target.DescripcionInvertida))return false;
			if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		    if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:!source.BreadcrumbCode.Equals(target.BreadcrumbCode))return false;
			if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:!source.DescripcionCodigo.Equals(target.DescripcionCodigo))return false;
			if((source.ClasificacionGeograficaPadre_Nombre == null)?target.ClasificacionGeograficaPadre_Nombre!=null:!source.ClasificacionGeograficaPadre_Nombre.Equals(target.ClasificacionGeograficaPadre_Nombre))return false;
            if((source.ClasificacionGeograficaPadre_BreadcrumbCode == null)?target.ClasificacionGeograficaPadre_BreadcrumbCode!=null:!source.ClasificacionGeograficaPadre_BreadcrumbCode.Equals(target.ClasificacionGeograficaPadre_BreadcrumbCode))return false;
            if(!source.ClasificacionGeograficaTipo_Nivel.Equals(target.ClasificacionGeograficaTipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
