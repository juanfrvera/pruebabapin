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
    public abstract class _CaracterEconomicoData : EntityData<CaracterEconomico,CaracterEconomicoFilter,CaracterEconomicoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.CaracterEconomico entity)
		{			
			return entity.IdCaracterEconomico;
		}		
		public override CaracterEconomico GetByEntity(CaracterEconomico entity)
        {
            return this.GetById(entity.IdCaracterEconomico);
        }
        public override CaracterEconomico GetById(int id)
        {
            return (from o in this.Table where o.IdCaracterEconomico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<CaracterEconomico> Query(CaracterEconomicoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdCaracterEconomico == null || filter.IdCaracterEconomico == 0 || o.IdCaracterEconomico==filter.IdCaracterEconomico)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.IdCaracterEconomicoTipo == null || filter.IdCaracterEconomicoTipo == 0 || o.IdCaracterEconomicoTipo==filter.IdCaracterEconomicoTipo)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdCaracterEconomicoPadre == null || filter.IdCaracterEconomicoPadre == 0 || o.IdCaracterEconomicoPadre==filter.IdCaracterEconomicoPadre)
					  && (filter.IdCaracterEconomicoPadreIsNull == null || filter.IdCaracterEconomicoPadreIsNull == true || o.IdCaracterEconomicoPadre != null ) && (filter.IdCaracterEconomicoPadreIsNull == null || filter.IdCaracterEconomicoPadreIsNull == false || o.IdCaracterEconomicoPadre == null)
					  && (filter.Visible == null || o.Visible==filter.Visible)
					  && (filter.VisibleIsNull == null || filter.VisibleIsNull == true || o.Visible != null ) && (filter.VisibleIsNull == null || filter.VisibleIsNull == false || o.Visible == null)
					  && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%"  || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%",""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%",""))) || o.BreadcrumbId == filter.BreadcrumbId )
					  && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%"  || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%",""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%",""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  && (filter.NivelIsNull == null || filter.NivelIsNull == true || o.Nivel != null ) && (filter.NivelIsNull == null || filter.NivelIsNull == false || o.Nivel == null)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null ) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.DescripcionInvertida == null || filter.DescripcionInvertida.Trim() == string.Empty || filter.DescripcionInvertida.Trim() == "%"  || (filter.DescripcionInvertida.EndsWith("%") && filter.DescripcionInvertida.StartsWith("%") && (o.DescripcionInvertida.Contains(filter.DescripcionInvertida.Replace("%", "")))) || (filter.DescripcionInvertida.EndsWith("%") && o.DescripcionInvertida.StartsWith(filter.DescripcionInvertida.Replace("%",""))) || (filter.DescripcionInvertida.StartsWith("%") && o.DescripcionInvertida.EndsWith(filter.DescripcionInvertida.Replace("%",""))) || o.DescripcionInvertida == filter.DescripcionInvertida )
					  && (filter.Seleccionable == null || o.Seleccionable==filter.Seleccionable)
					  && (filter.SeleccionableIsNull == null || filter.SeleccionableIsNull == true || o.Seleccionable != null ) && (filter.SeleccionableIsNull == null || filter.SeleccionableIsNull == false || o.Seleccionable == null)
					  && (filter.BreadcrumbCode == null || filter.BreadcrumbCode.Trim() == string.Empty || filter.BreadcrumbCode.Trim() == "%"  || (filter.BreadcrumbCode.EndsWith("%") && filter.BreadcrumbCode.StartsWith("%") && (o.BreadcrumbCode.Contains(filter.BreadcrumbCode.Replace("%", "")))) || (filter.BreadcrumbCode.EndsWith("%") && o.BreadcrumbCode.StartsWith(filter.BreadcrumbCode.Replace("%",""))) || (filter.BreadcrumbCode.StartsWith("%") && o.BreadcrumbCode.EndsWith(filter.BreadcrumbCode.Replace("%",""))) || o.BreadcrumbCode == filter.BreadcrumbCode )
					  && (filter.DescripcionCodigo == null || filter.DescripcionCodigo.Trim() == string.Empty || filter.DescripcionCodigo.Trim() == "%"  || (filter.DescripcionCodigo.EndsWith("%") && filter.DescripcionCodigo.StartsWith("%") && (o.DescripcionCodigo.Contains(filter.DescripcionCodigo.Replace("%", "")))) || (filter.DescripcionCodigo.EndsWith("%") && o.DescripcionCodigo.StartsWith(filter.DescripcionCodigo.Replace("%",""))) || (filter.DescripcionCodigo.StartsWith("%") && o.DescripcionCodigo.EndsWith(filter.DescripcionCodigo.Replace("%",""))) || o.DescripcionCodigo == filter.DescripcionCodigo )
					  select o
                    ).AsQueryable();
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
						,CaracterEconomicoPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,CaracterEconomicoPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,CaracterEconomicoPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,CaracterEconomicoPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,CaracterEconomicoPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,CaracterEconomicoPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,CaracterEconomicoPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
						,CaracterEconomicoTipo_Nombre= t2.Nombre	
						,CaracterEconomicoTipo_Nivel= t2.Nivel	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.CaracterEconomico Copy(nc.CaracterEconomico entity)
        {           
            nc.CaracterEconomico _new = new nc.CaracterEconomico();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.IdCaracterEconomicoTipo= entity.IdCaracterEconomicoTipo;
		 _new.Activo= entity.Activo;
		 _new.IdCaracterEconomicoPadre= entity.IdCaracterEconomicoPadre;
		 _new.Visible= entity.Visible;
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
		public override int CopyAndSave(CaracterEconomico entity,string renameFormat)
        {
            CaracterEconomico  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(CaracterEconomico entity, int id)
        {            
            entity.IdCaracterEconomico = id;            
        }
		public override void Set(CaracterEconomico source,CaracterEconomico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Activo= source.Activo ;
		 target.IdCaracterEconomicoPadre= source.IdCaracterEconomicoPadre ;
		 target.Visible= source.Visible ;
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
		public override void Set(CaracterEconomicoResult source,CaracterEconomico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Activo= source.Activo ;
		 target.IdCaracterEconomicoPadre= source.IdCaracterEconomicoPadre ;
		 target.Visible= source.Visible ;
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
		public override void Set(CaracterEconomico source,CaracterEconomicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Activo= source.Activo ;
		 target.IdCaracterEconomicoPadre= source.IdCaracterEconomicoPadre ;
		 target.Visible= source.Visible ;
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
		public override void Set(CaracterEconomicoResult source,CaracterEconomicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomico= source.IdCaracterEconomico ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Activo= source.Activo ;
		 target.IdCaracterEconomicoPadre= source.IdCaracterEconomicoPadre ;
		 target.Visible= source.Visible ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.CaracterEconomicoPadre_Codigo= source.CaracterEconomicoPadre_Codigo;	
			target.CaracterEconomicoPadre_Nombre= source.CaracterEconomicoPadre_Nombre;	
			target.CaracterEconomicoPadre_IdCaracterEconomicoTipo= source.CaracterEconomicoPadre_IdCaracterEconomicoTipo;	
			target.CaracterEconomicoPadre_Activo= source.CaracterEconomicoPadre_Activo;	
			target.CaracterEconomicoPadre_IdCaracterEconomicoPadre= source.CaracterEconomicoPadre_IdCaracterEconomicoPadre;	
			target.CaracterEconomicoPadre_Visible= source.CaracterEconomicoPadre_Visible;	
			target.CaracterEconomicoPadre_BreadcrumbId= source.CaracterEconomicoPadre_BreadcrumbId;	
			target.CaracterEconomicoPadre_BreadcrumbOrden= source.CaracterEconomicoPadre_BreadcrumbOrden;	
			target.CaracterEconomicoPadre_Nivel= source.CaracterEconomicoPadre_Nivel;	
			target.CaracterEconomicoPadre_Orden= source.CaracterEconomicoPadre_Orden;	
			target.CaracterEconomicoPadre_Descripcion= source.CaracterEconomicoPadre_Descripcion;	
			target.CaracterEconomicoPadre_DescripcionInvertida= source.CaracterEconomicoPadre_DescripcionInvertida;	
			target.CaracterEconomicoPadre_Seleccionable= source.CaracterEconomicoPadre_Seleccionable;	
			target.CaracterEconomicoPadre_BreadcrumbCode= source.CaracterEconomicoPadre_BreadcrumbCode;	
			target.CaracterEconomicoPadre_DescripcionCodigo= source.CaracterEconomicoPadre_DescripcionCodigo;	
			target.CaracterEconomicoTipo_Nombre= source.CaracterEconomicoTipo_Nombre;	
			target.CaracterEconomicoTipo_Nivel= source.CaracterEconomicoTipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(CaracterEconomico source,CaracterEconomico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCaracterEconomico.Equals(target.IdCaracterEconomico))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdCaracterEconomicoTipo.Equals(target.IdCaracterEconomicoTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdCaracterEconomicoPadre == null)?(target.IdCaracterEconomicoPadre.HasValue && target.IdCaracterEconomicoPadre.Value > 0):!source.IdCaracterEconomicoPadre.Equals(target.IdCaracterEconomicoPadre))return false;
						  if((source.Visible == null)?(target.Visible.HasValue):!source.Visible.Equals(target.Visible))return false;
			 if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:  !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) &&  !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null:  !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) &&  !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:  !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) &&  !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if((source.Seleccionable == null)?(target.Seleccionable.HasValue):!source.Seleccionable.Equals(target.Seleccionable))return false;
			 if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:  !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) &&  !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:  !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) &&  !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(CaracterEconomicoResult source,CaracterEconomicoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCaracterEconomico.Equals(target.IdCaracterEconomico))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.IdCaracterEconomicoTipo.Equals(target.IdCaracterEconomicoTipo))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdCaracterEconomicoPadre == null)?(target.IdCaracterEconomicoPadre.HasValue && target.IdCaracterEconomicoPadre.Value > 0):!source.IdCaracterEconomicoPadre.Equals(target.IdCaracterEconomicoPadre))return false;
						  if((source.Visible == null)?(target.Visible.HasValue):!source.Visible.Equals(target.Visible))return false;
			 if((source.BreadcrumbId == null)?target.BreadcrumbId!=null: !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) && !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null: !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) && !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if((source.Nivel == null)?(target.Nivel.HasValue):!source.Nivel.Equals(target.Nivel))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null: !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) && !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if((source.Seleccionable == null)?(target.Seleccionable.HasValue):!source.Seleccionable.Equals(target.Seleccionable))return false;
			 if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null: !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) && !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null: !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) && !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			 if((source.CaracterEconomicoPadre_Codigo == null)?target.CaracterEconomicoPadre_Codigo!=null: !( (target.CaracterEconomicoPadre_Codigo== String.Empty && source.CaracterEconomicoPadre_Codigo== null) || (target.CaracterEconomicoPadre_Codigo==null && source.CaracterEconomicoPadre_Codigo== String.Empty )) &&   !source.CaracterEconomicoPadre_Codigo.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_Nombre == null)?target.CaracterEconomicoPadre_Nombre!=null: !( (target.CaracterEconomicoPadre_Nombre== String.Empty && source.CaracterEconomicoPadre_Nombre== null) || (target.CaracterEconomicoPadre_Nombre==null && source.CaracterEconomicoPadre_Nombre== String.Empty )) &&   !source.CaracterEconomicoPadre_Nombre.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.CaracterEconomicoPadre_IdCaracterEconomicoTipo.Equals(target.CaracterEconomicoPadre_IdCaracterEconomicoTipo))return false;
					  if(!source.CaracterEconomicoPadre_Activo.Equals(target.CaracterEconomicoPadre_Activo))return false;
					  if((source.CaracterEconomicoPadre_IdCaracterEconomicoPadre == null)?(target.CaracterEconomicoPadre_IdCaracterEconomicoPadre.HasValue && target.CaracterEconomicoPadre_IdCaracterEconomicoPadre.Value > 0):!source.CaracterEconomicoPadre_IdCaracterEconomicoPadre.Equals(target.CaracterEconomicoPadre_IdCaracterEconomicoPadre))return false;
									  if((source.CaracterEconomicoPadre_Visible == null)?(target.CaracterEconomicoPadre_Visible.HasValue ):!source.CaracterEconomicoPadre_Visible.Equals(target.CaracterEconomicoPadre_Visible))return false;
						 if((source.CaracterEconomicoPadre_BreadcrumbId == null)?target.CaracterEconomicoPadre_BreadcrumbId!=null: !( (target.CaracterEconomicoPadre_BreadcrumbId== String.Empty && source.CaracterEconomicoPadre_BreadcrumbId== null) || (target.CaracterEconomicoPadre_BreadcrumbId==null && source.CaracterEconomicoPadre_BreadcrumbId== String.Empty )) &&   !source.CaracterEconomicoPadre_BreadcrumbId.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_BreadcrumbOrden == null)?target.CaracterEconomicoPadre_BreadcrumbOrden!=null: !( (target.CaracterEconomicoPadre_BreadcrumbOrden== String.Empty && source.CaracterEconomicoPadre_BreadcrumbOrden== null) || (target.CaracterEconomicoPadre_BreadcrumbOrden==null && source.CaracterEconomicoPadre_BreadcrumbOrden== String.Empty )) &&   !source.CaracterEconomicoPadre_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_Nivel == null)?(target.CaracterEconomicoPadre_Nivel.HasValue ):!source.CaracterEconomicoPadre_Nivel.Equals(target.CaracterEconomicoPadre_Nivel))return false;
						 if((source.CaracterEconomicoPadre_Orden == null)?(target.CaracterEconomicoPadre_Orden.HasValue ):!source.CaracterEconomicoPadre_Orden.Equals(target.CaracterEconomicoPadre_Orden))return false;
						 if((source.CaracterEconomicoPadre_Descripcion == null)?target.CaracterEconomicoPadre_Descripcion!=null: !( (target.CaracterEconomicoPadre_Descripcion== String.Empty && source.CaracterEconomicoPadre_Descripcion== null) || (target.CaracterEconomicoPadre_Descripcion==null && source.CaracterEconomicoPadre_Descripcion== String.Empty )) &&   !source.CaracterEconomicoPadre_Descripcion.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_DescripcionInvertida == null)?target.CaracterEconomicoPadre_DescripcionInvertida!=null: !( (target.CaracterEconomicoPadre_DescripcionInvertida== String.Empty && source.CaracterEconomicoPadre_DescripcionInvertida== null) || (target.CaracterEconomicoPadre_DescripcionInvertida==null && source.CaracterEconomicoPadre_DescripcionInvertida== String.Empty )) &&   !source.CaracterEconomicoPadre_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_Seleccionable == null)?(target.CaracterEconomicoPadre_Seleccionable.HasValue ):!source.CaracterEconomicoPadre_Seleccionable.Equals(target.CaracterEconomicoPadre_Seleccionable))return false;
						 if((source.CaracterEconomicoPadre_BreadcrumbCode == null)?target.CaracterEconomicoPadre_BreadcrumbCode!=null: !( (target.CaracterEconomicoPadre_BreadcrumbCode== String.Empty && source.CaracterEconomicoPadre_BreadcrumbCode== null) || (target.CaracterEconomicoPadre_BreadcrumbCode==null && source.CaracterEconomicoPadre_BreadcrumbCode== String.Empty )) &&   !source.CaracterEconomicoPadre_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoPadre_DescripcionCodigo == null)?target.CaracterEconomicoPadre_DescripcionCodigo!=null: !( (target.CaracterEconomicoPadre_DescripcionCodigo== String.Empty && source.CaracterEconomicoPadre_DescripcionCodigo== null) || (target.CaracterEconomicoPadre_DescripcionCodigo==null && source.CaracterEconomicoPadre_DescripcionCodigo== String.Empty )) &&   !source.CaracterEconomicoPadre_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.CaracterEconomicoPadre_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.CaracterEconomicoTipo_Nombre == null)?target.CaracterEconomicoTipo_Nombre!=null: !( (target.CaracterEconomicoTipo_Nombre== String.Empty && source.CaracterEconomicoTipo_Nombre== null) || (target.CaracterEconomicoTipo_Nombre==null && source.CaracterEconomicoTipo_Nombre== String.Empty )) &&   !source.CaracterEconomicoTipo_Nombre.Trim().Replace ("\r","").Equals(target.CaracterEconomicoTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.CaracterEconomicoTipo_Nivel.Equals(target.CaracterEconomicoTipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
