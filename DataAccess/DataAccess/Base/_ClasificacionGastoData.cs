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
    public abstract class _ClasificacionGastoData : EntityData<ClasificacionGasto,ClasificacionGastoFilter,ClasificacionGastoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ClasificacionGasto entity)
		{			
			return entity.IdClasificacionGasto;
		}		
		public override ClasificacionGasto GetByEntity(ClasificacionGasto entity)
        {
            return this.GetById(entity.IdClasificacionGasto);
        }
        public override ClasificacionGasto GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacionGasto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ClasificacionGasto> Query(ClasificacionGastoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacionGasto == null || filter.IdClasificacionGasto == 0 || o.IdClasificacionGasto==filter.IdClasificacionGasto)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdClasificacionGastoTipo == null || filter.IdClasificacionGastoTipo == 0 || o.IdClasificacionGastoTipo==filter.IdClasificacionGastoTipo)
					  && (filter.IdCaracterEconomico == null || o.IdCaracterEconomico >=  filter.IdCaracterEconomico) && (filter.IdCaracterEconomico_To == null || o.IdCaracterEconomico <= filter.IdCaracterEconomico_To)
					  && (filter.IdCaracterEconomicoIsNull == null || filter.IdCaracterEconomicoIsNull == true || o.IdCaracterEconomico != null ) && (filter.IdCaracterEconomicoIsNull == null || filter.IdCaracterEconomicoIsNull == false || o.IdCaracterEconomico == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdClasificacionGastoPadre == null || filter.IdClasificacionGastoPadre == 0 || o.IdClasificacionGastoPadre==filter.IdClasificacionGastoPadre)
					  && (filter.IdClasificacionGastoPadreIsNull == null || filter.IdClasificacionGastoPadreIsNull == true || o.IdClasificacionGastoPadre != null ) && (filter.IdClasificacionGastoPadreIsNull == null || filter.IdClasificacionGastoPadreIsNull == false || o.IdClasificacionGastoPadre == null)
					  && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%"  || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%",""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%",""))) || o.BreadcrumbId == filter.BreadcrumbId )
					  && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%"  || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%",""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%",""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null ) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null ) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%"  || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%",""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%",""))) || o.DescripcionInvertida == filter.DescripcionInvertida )
					  && (filter.IdClasificacionGastoRubro == null || filter.IdClasificacionGastoRubro == 0 || o.IdClasificacionGastoRubro==filter.IdClasificacionGastoRubro)
					  && (filter.Seleccionable == null || o.Seleccionable==filter.Seleccionable)
					  && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%"  || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%",""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%",""))) || o.BreadcrumbCode == filter.BreadcrumbCode )
					  && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%"  || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%",""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%",""))) || o.DescripcionCodigo == filter.DescripcionCodigo )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionGastoResult> QueryResult(ClasificacionGastoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.ClasificacionGastos on o.IdClasificacionGastoPadre equals _t1.IdClasificacionGasto into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.ClasificacionGastoRubros on o.IdClasificacionGastoRubro equals t2.IdClasificacionGastoRubro   
				    join t3  in this.Context.ClasificacionGastoTipos on o.IdClasificacionGastoTipo equals t3.IdClasificacionGastoTipo   
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
					,ClasificacionGastoPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,ClasificacionGastoPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,ClasificacionGastoPadre_IdClasificacionGastoTipo= t1!=null?(int?)t1.IdClasificacionGastoTipo:null	
						,ClasificacionGastoPadre_IdCaracterEconomico= t1!=null?(int?)t1.IdCaracterEconomico:null	
						,ClasificacionGastoPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,ClasificacionGastoPadre_IdClasificacionGastoPadre= t1!=null?(int?)t1.IdClasificacionGastoPadre:null	
						,ClasificacionGastoPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,ClasificacionGastoPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null	
						,ClasificacionGastoPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,ClasificacionGastoPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,ClasificacionGastoPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,ClasificacionGastoPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,ClasificacionGastoPadre_IdClasificacionGastoRubro= t1!=null?(int?)t1.IdClasificacionGastoRubro:null	
						,ClasificacionGastoPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,ClasificacionGastoPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,ClasificacionGastoPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,ClasificacionGastoRubro_Codigo= t2.Codigo	
						,ClasificacionGastoRubro_Nombre= t2.Nombre	
						,ClasificacionGastoTipo_Nombre= t3.Nombre	
						,ClasificacionGastoTipo_Nivel= t3.Nivel	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ClasificacionGasto Copy(nc.ClasificacionGasto entity)
        {           
            nc.ClasificacionGasto _new = new nc.ClasificacionGasto();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.IdClasificacionGastoTipo= entity.IdClasificacionGastoTipo;
		 _new.IdCaracterEconomico= entity.IdCaracterEconomico;
		 _new.Activo= entity.Activo;
		 _new.IdClasificacionGastoPadre= entity.IdClasificacionGastoPadre;
		 _new.BreadcrumbId= entity.BreadcrumbId;
		 _new.BreadcrumbOrden= entity.BreadcrumbOrden;
		 _new.Nivel= entity.Nivel;
		 _new.Orden= entity.Orden;
		 _new.Descripcion= entity.Descripcion;
		 _new.DescripcionInvertida= entity.DescripcionInvertida;
		 _new.IdClasificacionGastoRubro= entity.IdClasificacionGastoRubro;
		 _new.Seleccionable= entity.Seleccionable;
		 _new.BreadcrumbCode= entity.BreadcrumbCode;
		 _new.DescripcionCodigo= entity.DescripcionCodigo;
		return _new;			
        }
		public override int CopyAndSave(ClasificacionGasto entity,string renameFormat)
        {
            ClasificacionGasto  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ClasificacionGasto entity, int id)
        {            
            entity.IdClasificacionGasto = id;            
        }
		public override void Set(ClasificacionGasto source,ClasificacionGasto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Activo= source.Activo ;
		 target.IdClasificacionGastoPadre= source.IdClasificacionGastoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 		  
		}
		public override void Set(ClasificacionGastoResult source,ClasificacionGasto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Activo= source.Activo ;
		 target.IdClasificacionGastoPadre= source.IdClasificacionGastoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 
		}
		public override void Set(ClasificacionGasto source,ClasificacionGastoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Activo= source.Activo ;
		 target.IdClasificacionGastoPadre= source.IdClasificacionGastoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 	
		}		
		public override void Set(ClasificacionGastoResult source,ClasificacionGastoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Activo= source.Activo ;
		 target.IdClasificacionGastoPadre= source.IdClasificacionGastoPadre ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.IdClasificacionGastoRubro= source.IdClasificacionGastoRubro ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.ClasificacionGastoPadre_Codigo= source.ClasificacionGastoPadre_Codigo;	
			target.ClasificacionGastoPadre_Nombre= source.ClasificacionGastoPadre_Nombre;	
			target.ClasificacionGastoPadre_IdClasificacionGastoTipo= source.ClasificacionGastoPadre_IdClasificacionGastoTipo;	
			target.ClasificacionGastoPadre_IdCaracterEconomico= source.ClasificacionGastoPadre_IdCaracterEconomico;	
			target.ClasificacionGastoPadre_Activo= source.ClasificacionGastoPadre_Activo;	
			target.ClasificacionGastoPadre_IdClasificacionGastoPadre= source.ClasificacionGastoPadre_IdClasificacionGastoPadre;	
			target.ClasificacionGastoPadre_BreadcrumbId= source.ClasificacionGastoPadre_BreadcrumbId;	
			target.ClasificacionGastoPadre_BreadcrumbOrden= source.ClasificacionGastoPadre_BreadcrumbOrden;	
			target.ClasificacionGastoPadre_Nivel= source.ClasificacionGastoPadre_Nivel;	
			target.ClasificacionGastoPadre_Orden= source.ClasificacionGastoPadre_Orden;	
			target.ClasificacionGastoPadre_Descripcion= source.ClasificacionGastoPadre_Descripcion;	
			target.ClasificacionGastoPadre_DescripcionInvertida= source.ClasificacionGastoPadre_DescripcionInvertida;	
			target.ClasificacionGastoPadre_IdClasificacionGastoRubro= source.ClasificacionGastoPadre_IdClasificacionGastoRubro;	
			target.ClasificacionGastoPadre_Seleccionable= source.ClasificacionGastoPadre_Seleccionable;	
			target.ClasificacionGastoPadre_BreadcrumbCode= source.ClasificacionGastoPadre_BreadcrumbCode;	
			target.ClasificacionGastoPadre_DescripcionCodigo= source.ClasificacionGastoPadre_DescripcionCodigo;	
			target.ClasificacionGastoRubro_Codigo= source.ClasificacionGastoRubro_Codigo;	
			target.ClasificacionGastoRubro_Nombre= source.ClasificacionGastoRubro_Nombre;	
			target.ClasificacionGastoTipo_Nombre= source.ClasificacionGastoTipo_Nombre;	
			target.ClasificacionGastoTipo_Nivel= source.ClasificacionGastoTipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ClasificacionGasto source,ClasificacionGasto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGastoTipo.Equals(target.IdClasificacionGastoTipo))return false;
		  if((source.IdCaracterEconomico == null)?(target.IdCaracterEconomico.HasValue):!source.IdCaracterEconomico.Equals(target.IdCaracterEconomico))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdClasificacionGastoPadre == null)?(target.IdClasificacionGastoPadre.HasValue && target.IdClasificacionGastoPadre.Value > 0):!source.IdClasificacionGastoPadre.Equals(target.IdClasificacionGastoPadre))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:  !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) &&  !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null:  !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) &&  !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:  !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) &&  !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGastoRubro.Equals(target.IdClasificacionGastoRubro))return false;
		  if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:  !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) &&  !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:  !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) &&  !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ClasificacionGastoResult source,ClasificacionGastoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGastoTipo.Equals(target.IdClasificacionGastoTipo))return false;
		  if((source.IdCaracterEconomico == null)?(target.IdCaracterEconomico.HasValue):!source.IdCaracterEconomico.Equals(target.IdCaracterEconomico))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdClasificacionGastoPadre == null)?(target.IdClasificacionGastoPadre.HasValue && target.IdClasificacionGastoPadre.Value > 0):!source.IdClasificacionGastoPadre.Equals(target.IdClasificacionGastoPadre))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null: !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) && !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null: !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) && !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null: !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) && !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGastoRubro.Equals(target.IdClasificacionGastoRubro))return false;
		  if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null: !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) && !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null: !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) && !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			 if((source.ClasificacionGastoPadre_Codigo == null)?target.ClasificacionGastoPadre_Codigo!=null: !( (target.ClasificacionGastoPadre_Codigo== String.Empty && source.ClasificacionGastoPadre_Codigo== null) || (target.ClasificacionGastoPadre_Codigo==null && source.ClasificacionGastoPadre_Codigo== String.Empty )) &&   !source.ClasificacionGastoPadre_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoPadre_Nombre == null)?target.ClasificacionGastoPadre_Nombre!=null: !( (target.ClasificacionGastoPadre_Nombre== String.Empty && source.ClasificacionGastoPadre_Nombre== null) || (target.ClasificacionGastoPadre_Nombre==null && source.ClasificacionGastoPadre_Nombre== String.Empty )) &&   !source.ClasificacionGastoPadre_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGastoPadre_IdClasificacionGastoTipo.Equals(target.ClasificacionGastoPadre_IdClasificacionGastoTipo))return false;
					  if((source.ClasificacionGastoPadre_IdCaracterEconomico == null)?(target.ClasificacionGastoPadre_IdCaracterEconomico.HasValue ):!source.ClasificacionGastoPadre_IdCaracterEconomico.Equals(target.ClasificacionGastoPadre_IdCaracterEconomico))return false;
						 if(!source.ClasificacionGastoPadre_Activo.Equals(target.ClasificacionGastoPadre_Activo))return false;
					  if((source.ClasificacionGastoPadre_IdClasificacionGastoPadre == null)?(target.ClasificacionGastoPadre_IdClasificacionGastoPadre.HasValue && target.ClasificacionGastoPadre_IdClasificacionGastoPadre.Value > 0):!source.ClasificacionGastoPadre_IdClasificacionGastoPadre.Equals(target.ClasificacionGastoPadre_IdClasificacionGastoPadre))return false;
									  if((source.ClasificacionGastoPadre_BreadcrumbId == null)?target.ClasificacionGastoPadre_BreadcrumbId!=null: !( (target.ClasificacionGastoPadre_BreadcrumbId== String.Empty && source.ClasificacionGastoPadre_BreadcrumbId== null) || (target.ClasificacionGastoPadre_BreadcrumbId==null && source.ClasificacionGastoPadre_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGastoPadre_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoPadre_BreadcrumbOrden == null)?target.ClasificacionGastoPadre_BreadcrumbOrden!=null: !( (target.ClasificacionGastoPadre_BreadcrumbOrden== String.Empty && source.ClasificacionGastoPadre_BreadcrumbOrden== null) || (target.ClasificacionGastoPadre_BreadcrumbOrden==null && source.ClasificacionGastoPadre_BreadcrumbOrden== String.Empty )) &&   !source.ClasificacionGastoPadre_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoPadre_Nivel == null)?(target.ClasificacionGastoPadre_Nivel.HasValue ):!source.ClasificacionGastoPadre_Nivel.Equals(target.ClasificacionGastoPadre_Nivel))return false;
						 if((source.ClasificacionGastoPadre_Orden == null)?(target.ClasificacionGastoPadre_Orden.HasValue ):!source.ClasificacionGastoPadre_Orden.Equals(target.ClasificacionGastoPadre_Orden))return false;
						 if((source.ClasificacionGastoPadre_Descripcion == null)?target.ClasificacionGastoPadre_Descripcion!=null: !( (target.ClasificacionGastoPadre_Descripcion== String.Empty && source.ClasificacionGastoPadre_Descripcion== null) || (target.ClasificacionGastoPadre_Descripcion==null && source.ClasificacionGastoPadre_Descripcion== String.Empty )) &&   !source.ClasificacionGastoPadre_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoPadre_DescripcionInvertida == null)?target.ClasificacionGastoPadre_DescripcionInvertida!=null: !( (target.ClasificacionGastoPadre_DescripcionInvertida== String.Empty && source.ClasificacionGastoPadre_DescripcionInvertida== null) || (target.ClasificacionGastoPadre_DescripcionInvertida==null && source.ClasificacionGastoPadre_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGastoPadre_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGastoPadre_IdClasificacionGastoRubro.Equals(target.ClasificacionGastoPadre_IdClasificacionGastoRubro))return false;
					  if(!source.ClasificacionGastoPadre_Seleccionable.Equals(target.ClasificacionGastoPadre_Seleccionable))return false;
					  if((source.ClasificacionGastoPadre_BreadcrumbCode == null)?target.ClasificacionGastoPadre_BreadcrumbCode!=null: !( (target.ClasificacionGastoPadre_BreadcrumbCode== String.Empty && source.ClasificacionGastoPadre_BreadcrumbCode== null) || (target.ClasificacionGastoPadre_BreadcrumbCode==null && source.ClasificacionGastoPadre_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGastoPadre_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoPadre_DescripcionCodigo == null)?target.ClasificacionGastoPadre_DescripcionCodigo!=null: !( (target.ClasificacionGastoPadre_DescripcionCodigo== String.Empty && source.ClasificacionGastoPadre_DescripcionCodigo== null) || (target.ClasificacionGastoPadre_DescripcionCodigo==null && source.ClasificacionGastoPadre_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGastoPadre_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGastoPadre_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoRubro_Codigo == null)?target.ClasificacionGastoRubro_Codigo!=null: !( (target.ClasificacionGastoRubro_Codigo== String.Empty && source.ClasificacionGastoRubro_Codigo== null) || (target.ClasificacionGastoRubro_Codigo==null && source.ClasificacionGastoRubro_Codigo== String.Empty )) &&   !source.ClasificacionGastoRubro_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGastoRubro_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoRubro_Nombre == null)?target.ClasificacionGastoRubro_Nombre!=null: !( (target.ClasificacionGastoRubro_Nombre== String.Empty && source.ClasificacionGastoRubro_Nombre== null) || (target.ClasificacionGastoRubro_Nombre==null && source.ClasificacionGastoRubro_Nombre== String.Empty )) &&   !source.ClasificacionGastoRubro_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGastoRubro_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGastoTipo_Nombre == null)?target.ClasificacionGastoTipo_Nombre!=null: !( (target.ClasificacionGastoTipo_Nombre== String.Empty && source.ClasificacionGastoTipo_Nombre== null) || (target.ClasificacionGastoTipo_Nombre==null && source.ClasificacionGastoTipo_Nombre== String.Empty )) &&   !source.ClasificacionGastoTipo_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGastoTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGastoTipo_Nivel.Equals(target.ClasificacionGastoTipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
