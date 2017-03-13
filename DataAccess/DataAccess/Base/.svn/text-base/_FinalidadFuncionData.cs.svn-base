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
    public abstract class _FinalidadFuncionData : EntityData<FinalidadFuncion,FinalidadFuncionFilter,FinalidadFuncionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.FinalidadFuncion entity)
		{			
			return entity.IdFinalidadFuncion;
		}		
		public override FinalidadFuncion GetByEntity(FinalidadFuncion entity)
        {
            return this.GetById(entity.IdFinalidadFuncion);
        }
        public override FinalidadFuncion GetById(int id)
        {
            return (from o in this.Table where o.IdFinalidadFuncion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<FinalidadFuncion> Query(FinalidadFuncionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || o.IdFinalidadFuncion==filter.IdFinalidadFuncion)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%"  || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%",""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%",""))) || o.Denominacion == filter.Denominacion )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdFinalidadFunciontipo == null || filter.IdFinalidadFunciontipo == 0 || o.IdFinalidadFunciontipo==filter.IdFinalidadFunciontipo)
					  && (filter.IdFinalidadFunciontipoIsNull == null || filter.IdFinalidadFunciontipoIsNull == true || o.IdFinalidadFunciontipo != null ) && (filter.IdFinalidadFunciontipoIsNull == null || filter.IdFinalidadFunciontipoIsNull == false || o.IdFinalidadFunciontipo == null)
					  && (filter.IdFinalidadFuncionPadre == null || filter.IdFinalidadFuncionPadre == 0 || o.IdFinalidadFuncionPadre==filter.IdFinalidadFuncionPadre)
					  && (filter.IdFinalidadFuncionPadreIsNull == null || filter.IdFinalidadFuncionPadreIsNull == true || o.IdFinalidadFuncionPadre != null ) && (filter.IdFinalidadFuncionPadreIsNull == null || filter.IdFinalidadFuncionPadreIsNull == false || o.IdFinalidadFuncionPadre == null)
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
		#region Copy
		public override nc.FinalidadFuncion Copy(nc.FinalidadFuncion entity)
        {           
            nc.FinalidadFuncion _new = new nc.FinalidadFuncion();
		 _new.Codigo= entity.Codigo;
		 _new.Denominacion= entity.Denominacion;
		 _new.Activo= entity.Activo;
		 _new.IdFinalidadFunciontipo= entity.IdFinalidadFunciontipo;
		 _new.IdFinalidadFuncionPadre= entity.IdFinalidadFuncionPadre;
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
		public override int CopyAndSave(FinalidadFuncion entity,string renameFormat)
        {
            FinalidadFuncion  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(FinalidadFuncion entity, int id)
        {            
            entity.IdFinalidadFuncion = id;            
        }
		public override void Set(FinalidadFuncion source,FinalidadFuncion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.Activo= source.Activo ;
		 target.IdFinalidadFunciontipo= source.IdFinalidadFunciontipo ;
		 target.IdFinalidadFuncionPadre= source.IdFinalidadFuncionPadre ;
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
		public override void Set(FinalidadFuncionResult source,FinalidadFuncion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.Activo= source.Activo ;
		 target.IdFinalidadFunciontipo= source.IdFinalidadFunciontipo ;
		 target.IdFinalidadFuncionPadre= source.IdFinalidadFuncionPadre ;
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
		public override void Set(FinalidadFuncion source,FinalidadFuncionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.Activo= source.Activo ;
		 target.IdFinalidadFunciontipo= source.IdFinalidadFunciontipo ;
		 target.IdFinalidadFuncionPadre= source.IdFinalidadFuncionPadre ;
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
		public override void Set(FinalidadFuncionResult source,FinalidadFuncionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.Activo= source.Activo ;
		 target.IdFinalidadFunciontipo= source.IdFinalidadFunciontipo ;
		 target.IdFinalidadFuncionPadre= source.IdFinalidadFuncionPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.FinalidadFuncionPadre_Codigo= source.FinalidadFuncionPadre_Codigo;	
			target.FinalidadFuncionPadre_Denominacion= source.FinalidadFuncionPadre_Denominacion;	
			target.FinalidadFuncionPadre_Activo= source.FinalidadFuncionPadre_Activo;	
			target.FinalidadFuncionPadre_IdFinalidadFunciontipo= source.FinalidadFuncionPadre_IdFinalidadFunciontipo;	
			target.FinalidadFuncionPadre_IdFinalidadFuncionPadre= source.FinalidadFuncionPadre_IdFinalidadFuncionPadre;	
			target.FinalidadFuncionPadre_BreadcrumbId= source.FinalidadFuncionPadre_BreadcrumbId;	
			target.FinalidadFuncionPadre_BreadcrumbOrden= source.FinalidadFuncionPadre_BreadcrumbOrden;	
			target.FinalidadFuncionPadre_Nivel= source.FinalidadFuncionPadre_Nivel;	
			target.FinalidadFuncionPadre_Orden= source.FinalidadFuncionPadre_Orden;	
			target.FinalidadFuncionPadre_Descripcion= source.FinalidadFuncionPadre_Descripcion;	
			target.FinalidadFuncionPadre_DescripcionInvertida= source.FinalidadFuncionPadre_DescripcionInvertida;	
			target.FinalidadFuncionPadre_Seleccionable= source.FinalidadFuncionPadre_Seleccionable;	
			target.FinalidadFuncionPadre_BreadcrumbCode= source.FinalidadFuncionPadre_BreadcrumbCode;	
			target.FinalidadFuncionPadre_DescripcionCodigo= source.FinalidadFuncionPadre_DescripcionCodigo;	
			target.FinalidadFunciontipo_Nombre= source.FinalidadFunciontipo_Nombre;	
			target.FinalidadFunciontipo_Nivel= source.FinalidadFunciontipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(FinalidadFuncion source,FinalidadFuncion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null:  !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) &&  !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdFinalidadFunciontipo == null)?(target.IdFinalidadFunciontipo.HasValue && target.IdFinalidadFunciontipo.Value > 0):!source.IdFinalidadFunciontipo.Equals(target.IdFinalidadFunciontipo))return false;
						  if((source.IdFinalidadFuncionPadre == null)?(target.IdFinalidadFuncionPadre.HasValue && target.IdFinalidadFuncionPadre.Value > 0):!source.IdFinalidadFuncionPadre.Equals(target.IdFinalidadFuncionPadre))return false;
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
		public override bool Equals(FinalidadFuncionResult source,FinalidadFuncionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null: !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) && !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdFinalidadFunciontipo == null)?(target.IdFinalidadFunciontipo.HasValue && target.IdFinalidadFunciontipo.Value > 0):!source.IdFinalidadFunciontipo.Equals(target.IdFinalidadFunciontipo))return false;
						  if((source.IdFinalidadFuncionPadre == null)?(target.IdFinalidadFuncionPadre.HasValue && target.IdFinalidadFuncionPadre.Value > 0):!source.IdFinalidadFuncionPadre.Equals(target.IdFinalidadFuncionPadre))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null: !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) && !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null: !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) && !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null: !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) && !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null: !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) && !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null: !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) && !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			 if((source.FinalidadFuncionPadre_Codigo == null)?target.FinalidadFuncionPadre_Codigo!=null: !( (target.FinalidadFuncionPadre_Codigo== String.Empty && source.FinalidadFuncionPadre_Codigo== null) || (target.FinalidadFuncionPadre_Codigo==null && source.FinalidadFuncionPadre_Codigo== String.Empty )) &&   !source.FinalidadFuncionPadre_Codigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncionPadre_Denominacion == null)?target.FinalidadFuncionPadre_Denominacion!=null: !( (target.FinalidadFuncionPadre_Denominacion== String.Empty && source.FinalidadFuncionPadre_Denominacion== null) || (target.FinalidadFuncionPadre_Denominacion==null && source.FinalidadFuncionPadre_Denominacion== String.Empty )) &&   !source.FinalidadFuncionPadre_Denominacion.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncionPadre_Activo.Equals(target.FinalidadFuncionPadre_Activo))return false;
					  if((source.FinalidadFuncionPadre_IdFinalidadFunciontipo == null)?(target.FinalidadFuncionPadre_IdFinalidadFunciontipo.HasValue && target.FinalidadFuncionPadre_IdFinalidadFunciontipo.Value > 0):!source.FinalidadFuncionPadre_IdFinalidadFunciontipo.Equals(target.FinalidadFuncionPadre_IdFinalidadFunciontipo))return false;
									  if((source.FinalidadFuncionPadre_IdFinalidadFuncionPadre == null)?(target.FinalidadFuncionPadre_IdFinalidadFuncionPadre.HasValue && target.FinalidadFuncionPadre_IdFinalidadFuncionPadre.Value > 0):!source.FinalidadFuncionPadre_IdFinalidadFuncionPadre.Equals(target.FinalidadFuncionPadre_IdFinalidadFuncionPadre))return false;
									  if((source.FinalidadFuncionPadre_BreadcrumbId == null)?target.FinalidadFuncionPadre_BreadcrumbId!=null: !( (target.FinalidadFuncionPadre_BreadcrumbId== String.Empty && source.FinalidadFuncionPadre_BreadcrumbId== null) || (target.FinalidadFuncionPadre_BreadcrumbId==null && source.FinalidadFuncionPadre_BreadcrumbId== String.Empty )) &&   !source.FinalidadFuncionPadre_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncionPadre_BreadcrumbOrden == null)?target.FinalidadFuncionPadre_BreadcrumbOrden!=null: !( (target.FinalidadFuncionPadre_BreadcrumbOrden== String.Empty && source.FinalidadFuncionPadre_BreadcrumbOrden== null) || (target.FinalidadFuncionPadre_BreadcrumbOrden==null && source.FinalidadFuncionPadre_BreadcrumbOrden== String.Empty )) &&   !source.FinalidadFuncionPadre_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncionPadre_Nivel == null)?(target.FinalidadFuncionPadre_Nivel.HasValue ):!source.FinalidadFuncionPadre_Nivel.Equals(target.FinalidadFuncionPadre_Nivel))return false;
						 if((source.FinalidadFuncionPadre_Orden == null)?(target.FinalidadFuncionPadre_Orden.HasValue ):!source.FinalidadFuncionPadre_Orden.Equals(target.FinalidadFuncionPadre_Orden))return false;
						 if((source.FinalidadFuncionPadre_Descripcion == null)?target.FinalidadFuncionPadre_Descripcion!=null: !( (target.FinalidadFuncionPadre_Descripcion== String.Empty && source.FinalidadFuncionPadre_Descripcion== null) || (target.FinalidadFuncionPadre_Descripcion==null && source.FinalidadFuncionPadre_Descripcion== String.Empty )) &&   !source.FinalidadFuncionPadre_Descripcion.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncionPadre_DescripcionInvertida == null)?target.FinalidadFuncionPadre_DescripcionInvertida!=null: !( (target.FinalidadFuncionPadre_DescripcionInvertida== String.Empty && source.FinalidadFuncionPadre_DescripcionInvertida== null) || (target.FinalidadFuncionPadre_DescripcionInvertida==null && source.FinalidadFuncionPadre_DescripcionInvertida== String.Empty )) &&   !source.FinalidadFuncionPadre_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncionPadre_Seleccionable.Equals(target.FinalidadFuncionPadre_Seleccionable))return false;
					  if((source.FinalidadFuncionPadre_BreadcrumbCode == null)?target.FinalidadFuncionPadre_BreadcrumbCode!=null: !( (target.FinalidadFuncionPadre_BreadcrumbCode== String.Empty && source.FinalidadFuncionPadre_BreadcrumbCode== null) || (target.FinalidadFuncionPadre_BreadcrumbCode==null && source.FinalidadFuncionPadre_BreadcrumbCode== String.Empty )) &&   !source.FinalidadFuncionPadre_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncionPadre_DescripcionCodigo == null)?target.FinalidadFuncionPadre_DescripcionCodigo!=null: !( (target.FinalidadFuncionPadre_DescripcionCodigo== String.Empty && source.FinalidadFuncionPadre_DescripcionCodigo== null) || (target.FinalidadFuncionPadre_DescripcionCodigo==null && source.FinalidadFuncionPadre_DescripcionCodigo== String.Empty )) &&   !source.FinalidadFuncionPadre_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncionPadre_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFunciontipo_Nombre == null)?target.FinalidadFunciontipo_Nombre!=null: !( (target.FinalidadFunciontipo_Nombre== String.Empty && source.FinalidadFunciontipo_Nombre== null) || (target.FinalidadFunciontipo_Nombre==null && source.FinalidadFunciontipo_Nombre== String.Empty )) &&   !source.FinalidadFunciontipo_Nombre.Trim().Replace ("\r","").Equals(target.FinalidadFunciontipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFunciontipo_Nivel.Equals(target.FinalidadFunciontipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
