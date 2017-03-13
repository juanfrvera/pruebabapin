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
    public abstract class _FuenteFinanciamientoData : EntityData<FuenteFinanciamiento,FuenteFinanciamientoFilter,FuenteFinanciamientoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.FuenteFinanciamiento entity)
		{			
			return entity.IdFuenteFinanciamiento;
		}		
		public override FuenteFinanciamiento GetByEntity(FuenteFinanciamiento entity)
        {
            return this.GetById(entity.IdFuenteFinanciamiento);
        }
        public override FuenteFinanciamiento GetById(int id)
        {
            return (from o in this.Table where o.IdFuenteFinanciamiento == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<FuenteFinanciamiento> Query(FuenteFinanciamientoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFuenteFinanciamiento == null || filter.IdFuenteFinanciamiento == 0 || o.IdFuenteFinanciamiento==filter.IdFuenteFinanciamiento)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdFuenteFinanciamientoTipo == null || filter.IdFuenteFinanciamientoTipo == 0 || o.IdFuenteFinanciamientoTipo==filter.IdFuenteFinanciamientoTipo)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdFuenteFinanciamientoPadre == null || filter.IdFuenteFinanciamientoPadre == 0 || o.IdFuenteFinanciamientoPadre==filter.IdFuenteFinanciamientoPadre)
					  && (filter.IdFuenteFinanciamientoPadreIsNull == null || filter.IdFuenteFinanciamientoPadreIsNull == true || o.IdFuenteFinanciamientoPadre != null ) && (filter.IdFuenteFinanciamientoPadreIsNull == null || filter.IdFuenteFinanciamientoPadreIsNull == false || o.IdFuenteFinanciamientoPadre == null)
					  && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%"  || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%",""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%",""))) || o.BreadcrumbId == filter.BreadcrumbId )
					  && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%"  || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%",""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%",""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null ) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null ) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%"  || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%",""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%",""))) || o.DescripcionInvertida == filter.DescripcionInvertida )
					  && (filter.Seleccionable == null || o.Seleccionable==filter.Seleccionable)
					  && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%"  || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%",""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%",""))) || o.BreadcrumbCode == filter.BreadcrumbCode )
					  && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%"  || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%",""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%",""))) || o.DescripcionCodigo == filter.DescripcionCodigo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<FuenteFinanciamientoResult> QueryResult(FuenteFinanciamientoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamientoPadre equals _t1.IdFuenteFinanciamiento into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.FuenteFinanciamientoTipos on o.IdFuenteFinanciamientoTipo equals t2.IdFuenteFinanciamientoTipo   
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
		#region Copy
		public override nc.FuenteFinanciamiento Copy(nc.FuenteFinanciamiento entity)
        {           
            nc.FuenteFinanciamiento _new = new nc.FuenteFinanciamiento();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.IdFuenteFinanciamientoTipo= entity.IdFuenteFinanciamientoTipo;
		 _new.Activo= entity.Activo;
		 _new.IdFuenteFinanciamientoPadre= entity.IdFuenteFinanciamientoPadre;
		 _new.BreadcrumbId= entity.BreadcrumbId;
		 _new.BreadcrumbOrden= entity.BreadcrumbOrden;
		 _new.Nivel= entity.Nivel;
		 _new.Orden= entity.Orden;
		 _new.Descripcion= entity.Descripcion;
		 _new.DescripcionInvertida= entity.DescripcionInvertida;
		 _new.Seleccionable= entity.Seleccionable;
		 _new.BreadcrumbCode= entity.BreadcrumbCode;
		 _new.DescripcionCodigo= entity.DescripcionCodigo;
		return _new;			
        }
		public override int CopyAndSave(FuenteFinanciamiento entity,string renameFormat)
        {
            FuenteFinanciamiento  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(FuenteFinanciamiento entity, int id)
        {            
            entity.IdFuenteFinanciamiento = id;            
        }
		public override void Set(FuenteFinanciamiento source,FuenteFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Activo= source.Activo ;
		 target.IdFuenteFinanciamientoPadre= source.IdFuenteFinanciamientoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 		  
		}
		public override void Set(FuenteFinanciamientoResult source,FuenteFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Activo= source.Activo ;
		 target.IdFuenteFinanciamientoPadre= source.IdFuenteFinanciamientoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 
		}
		public override void Set(FuenteFinanciamiento source,FuenteFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Activo= source.Activo ;
		 target.IdFuenteFinanciamientoPadre= source.IdFuenteFinanciamientoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 	
		}		
		public override void Set(FuenteFinanciamientoResult source,FuenteFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Activo= source.Activo ;
		 target.IdFuenteFinanciamientoPadre= source.IdFuenteFinanciamientoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.FuenteFinanciamientoPadre_Codigo= source.FuenteFinanciamientoPadre_Codigo;	
			target.FuenteFinanciamientoPadre_Nombre= source.FuenteFinanciamientoPadre_Nombre;	
			target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo= source.FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo;	
			target.FuenteFinanciamientoPadre_Activo= source.FuenteFinanciamientoPadre_Activo;	
			target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre= source.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre;	
			target.FuenteFinanciamientoPadre_BreadcrumbId= source.FuenteFinanciamientoPadre_BreadcrumbId;	
			target.FuenteFinanciamientoPadre_BreadcrumbOrden= source.FuenteFinanciamientoPadre_BreadcrumbOrden;	
			target.FuenteFinanciamientoPadre_Nivel= source.FuenteFinanciamientoPadre_Nivel;	
			target.FuenteFinanciamientoPadre_Orden= source.FuenteFinanciamientoPadre_Orden;	
			target.FuenteFinanciamientoPadre_Descripcion= source.FuenteFinanciamientoPadre_Descripcion;	
			target.FuenteFinanciamientoPadre_DescripcionInvertida= source.FuenteFinanciamientoPadre_DescripcionInvertida;	
			target.FuenteFinanciamientoPadre_Seleccionable= source.FuenteFinanciamientoPadre_Seleccionable;	
			target.FuenteFinanciamientoPadre_BreadcrumbCode= source.FuenteFinanciamientoPadre_BreadcrumbCode;	
			target.FuenteFinanciamientoPadre_DescripcionCodigo= source.FuenteFinanciamientoPadre_DescripcionCodigo;	
			target.FuenteFinanciamientoTipo_Nombre= source.FuenteFinanciamientoTipo_Nombre;	
			target.FuenteFinanciamientoTipo_Nivel= source.FuenteFinanciamientoTipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(FuenteFinanciamiento source,FuenteFinanciamiento target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdFuenteFinanciamientoTipo.Equals(target.IdFuenteFinanciamientoTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdFuenteFinanciamientoPadre == null)?(target.IdFuenteFinanciamientoPadre.HasValue && target.IdFuenteFinanciamientoPadre.Value > 0):!source.IdFuenteFinanciamientoPadre.Equals(target.IdFuenteFinanciamientoPadre))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:  !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) &&  !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null:  !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) &&  !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:  !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) &&  !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:  !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) &&  !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:  !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) &&  !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(FuenteFinanciamientoResult source,FuenteFinanciamientoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdFuenteFinanciamientoTipo.Equals(target.IdFuenteFinanciamientoTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdFuenteFinanciamientoPadre == null)?(target.IdFuenteFinanciamientoPadre.HasValue && target.IdFuenteFinanciamientoPadre.Value > 0):!source.IdFuenteFinanciamientoPadre.Equals(target.IdFuenteFinanciamientoPadre))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null: !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) && !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null: !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) && !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null: !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) && !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null: !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) && !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null: !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) && !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			 if((source.FuenteFinanciamientoPadre_Codigo == null)?target.FuenteFinanciamientoPadre_Codigo!=null: !( (target.FuenteFinanciamientoPadre_Codigo== String.Empty && source.FuenteFinanciamientoPadre_Codigo== null) || (target.FuenteFinanciamientoPadre_Codigo==null && source.FuenteFinanciamientoPadre_Codigo== String.Empty )) &&   !source.FuenteFinanciamientoPadre_Codigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoPadre_Nombre == null)?target.FuenteFinanciamientoPadre_Nombre!=null: !( (target.FuenteFinanciamientoPadre_Nombre== String.Empty && source.FuenteFinanciamientoPadre_Nombre== null) || (target.FuenteFinanciamientoPadre_Nombre==null && source.FuenteFinanciamientoPadre_Nombre== String.Empty )) &&   !source.FuenteFinanciamientoPadre_Nombre.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo.Equals(target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoTipo))return false;
					  if(!source.FuenteFinanciamientoPadre_Activo.Equals(target.FuenteFinanciamientoPadre_Activo))return false;
					  if((source.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre == null)?(target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre.HasValue && target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre.Value > 0):!source.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre.Equals(target.FuenteFinanciamientoPadre_IdFuenteFinanciamientoPadre))return false;
									  if((source.FuenteFinanciamientoPadre_BreadcrumbId == null)?target.FuenteFinanciamientoPadre_BreadcrumbId!=null: !( (target.FuenteFinanciamientoPadre_BreadcrumbId== String.Empty && source.FuenteFinanciamientoPadre_BreadcrumbId== null) || (target.FuenteFinanciamientoPadre_BreadcrumbId==null && source.FuenteFinanciamientoPadre_BreadcrumbId== String.Empty )) &&   !source.FuenteFinanciamientoPadre_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoPadre_BreadcrumbOrden == null)?target.FuenteFinanciamientoPadre_BreadcrumbOrden!=null: !( (target.FuenteFinanciamientoPadre_BreadcrumbOrden== String.Empty && source.FuenteFinanciamientoPadre_BreadcrumbOrden== null) || (target.FuenteFinanciamientoPadre_BreadcrumbOrden==null && source.FuenteFinanciamientoPadre_BreadcrumbOrden== String.Empty )) &&   !source.FuenteFinanciamientoPadre_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoPadre_Nivel == null)?(target.FuenteFinanciamientoPadre_Nivel.HasValue ):!source.FuenteFinanciamientoPadre_Nivel.Equals(target.FuenteFinanciamientoPadre_Nivel))return false;
						 if((source.FuenteFinanciamientoPadre_Orden == null)?(target.FuenteFinanciamientoPadre_Orden.HasValue ):!source.FuenteFinanciamientoPadre_Orden.Equals(target.FuenteFinanciamientoPadre_Orden))return false;
						 if((source.FuenteFinanciamientoPadre_Descripcion == null)?target.FuenteFinanciamientoPadre_Descripcion!=null: !( (target.FuenteFinanciamientoPadre_Descripcion== String.Empty && source.FuenteFinanciamientoPadre_Descripcion== null) || (target.FuenteFinanciamientoPadre_Descripcion==null && source.FuenteFinanciamientoPadre_Descripcion== String.Empty )) &&   !source.FuenteFinanciamientoPadre_Descripcion.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoPadre_DescripcionInvertida == null)?target.FuenteFinanciamientoPadre_DescripcionInvertida!=null: !( (target.FuenteFinanciamientoPadre_DescripcionInvertida== String.Empty && source.FuenteFinanciamientoPadre_DescripcionInvertida== null) || (target.FuenteFinanciamientoPadre_DescripcionInvertida==null && source.FuenteFinanciamientoPadre_DescripcionInvertida== String.Empty )) &&   !source.FuenteFinanciamientoPadre_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.FuenteFinanciamientoPadre_Seleccionable.Equals(target.FuenteFinanciamientoPadre_Seleccionable))return false;
					  if((source.FuenteFinanciamientoPadre_BreadcrumbCode == null)?target.FuenteFinanciamientoPadre_BreadcrumbCode!=null: !( (target.FuenteFinanciamientoPadre_BreadcrumbCode== String.Empty && source.FuenteFinanciamientoPadre_BreadcrumbCode== null) || (target.FuenteFinanciamientoPadre_BreadcrumbCode==null && source.FuenteFinanciamientoPadre_BreadcrumbCode== String.Empty )) &&   !source.FuenteFinanciamientoPadre_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoPadre_DescripcionCodigo == null)?target.FuenteFinanciamientoPadre_DescripcionCodigo!=null: !( (target.FuenteFinanciamientoPadre_DescripcionCodigo== String.Empty && source.FuenteFinanciamientoPadre_DescripcionCodigo== null) || (target.FuenteFinanciamientoPadre_DescripcionCodigo==null && source.FuenteFinanciamientoPadre_DescripcionCodigo== String.Empty )) &&   !source.FuenteFinanciamientoPadre_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoPadre_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamientoTipo_Nombre == null)?target.FuenteFinanciamientoTipo_Nombre!=null: !( (target.FuenteFinanciamientoTipo_Nombre== String.Empty && source.FuenteFinanciamientoTipo_Nombre== null) || (target.FuenteFinanciamientoTipo_Nombre==null && source.FuenteFinanciamientoTipo_Nombre== String.Empty )) &&   !source.FuenteFinanciamientoTipo_Nombre.Trim().Replace ("\r","").Equals(target.FuenteFinanciamientoTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.FuenteFinanciamientoTipo_Nivel.Equals(target.FuenteFinanciamientoTipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
