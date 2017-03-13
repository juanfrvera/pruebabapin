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
    public abstract class _OficinaData : EntityData<Oficina,OficinaFilter,OficinaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Oficina entity)
		{			
			return entity.IdOficina;
		}		
		public override Oficina GetByEntity(Oficina entity)
        {
            return this.GetById(entity.IdOficina);
        }
        public override Oficina GetById(int id)
        {
            return (from o in this.Table where o.IdOficina == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Oficina> Query(OficinaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.Visible == null || o.Visible==filter.Visible)
					  && (filter.IdOficinaPadre == null || filter.IdOficinaPadre == 0 || o.IdOficinaPadre==filter.IdOficinaPadre)
					  && (filter.IdOficinaPadreIsNull == null || filter.IdOficinaPadreIsNull == true || o.IdOficinaPadre != null ) && (filter.IdOficinaPadreIsNull == null || filter.IdOficinaPadreIsNull == false || o.IdOficinaPadre == null)
					  && (filter.IdSaf == null || filter.IdSaf == 0 || o.IdSaf==filter.IdSaf)
					  && (filter.IdSafIsNull == null || filter.IdSafIsNull == true || o.IdSaf != null ) && (filter.IdSafIsNull == null || filter.IdSafIsNull == false || o.IdSaf == null)
					  && (filter.BreadcrumbId == null || filter.BreadcrumbId.Trim() == string.Empty || filter.BreadcrumbId.Trim() == "%"  || (filter.BreadcrumbId.EndsWith("%") && filter.BreadcrumbId.StartsWith("%") && (o.BreadcrumbId.Contains(filter.BreadcrumbId.Replace("%", "")))) || (filter.BreadcrumbId.EndsWith("%") && o.BreadcrumbId.StartsWith(filter.BreadcrumbId.Replace("%",""))) || (filter.BreadcrumbId.StartsWith("%") && o.BreadcrumbId.EndsWith(filter.BreadcrumbId.Replace("%",""))) || o.BreadcrumbId == filter.BreadcrumbId )
					  && (filter.BreadcrumbOrden == null || filter.BreadcrumbOrden.Trim() == string.Empty || filter.BreadcrumbOrden.Trim() == "%"  || (filter.BreadcrumbOrden.EndsWith("%") && filter.BreadcrumbOrden.StartsWith("%") && (o.BreadcrumbOrden.Contains(filter.BreadcrumbOrden.Replace("%", "")))) || (filter.BreadcrumbOrden.EndsWith("%") && o.BreadcrumbOrden.StartsWith(filter.BreadcrumbOrden.Replace("%",""))) || (filter.BreadcrumbOrden.StartsWith("%") && o.BreadcrumbOrden.EndsWith(filter.BreadcrumbOrden.Replace("%",""))) || o.BreadcrumbOrden == filter.BreadcrumbOrden )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
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
        protected override IQueryable<OficinaResult> QueryResult(OficinaFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Oficinas on o.IdOficinaPadre equals _t1.IdOficina into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.Safs on o.IdSaf equals _t2.IdSaf into tt2 from t2 in tt2.DefaultIfEmpty()
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
					 ,DescripcionInvertida=o.DescripcionInvertida
					 ,Seleccionable=o.Seleccionable
					 ,BreadcrumbCode=o.BreadcrumbCode
					 ,DescripcionCodigo=o.DescripcionCodigo
					,OficinaPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,OficinaPadre_Codigo= t1!=null?(string)t1.Codigo:null	
						,OficinaPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,OficinaPadre_Visible= t1!=null?(bool?)t1.Visible:null	
						,OficinaPadre_IdOficinaPadre= t1!=null?(int?)t1.IdOficinaPadre:null	
						,OficinaPadre_IdSaf= t1!=null?(int?)t1.IdSaf:null	
						,OficinaPadre_BreadcrumbId= t1!=null?(string)t1.BreadcrumbId:null	
						,OficinaPadre_BreadcrumbOrden= t1!=null?(string)t1.BreadcrumbOrden:null	
						,OficinaPadre_Nivel= t1!=null?(int?)t1.Nivel:null	
						,OficinaPadre_Orden= t1!=null?(int?)t1.Orden:null	
						,OficinaPadre_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,OficinaPadre_DescripcionInvertida= t1!=null?(string)t1.DescripcionInvertida:null	
						,OficinaPadre_Seleccionable= t1!=null?(bool?)t1.Seleccionable:null	
						,OficinaPadre_BreadcrumbCode= t1!=null?(string)t1.BreadcrumbCode:null	
						,OficinaPadre_DescripcionCodigo= t1!=null?(string)t1.DescripcionCodigo:null	
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
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Oficina Copy(nc.Oficina entity)
        {           
            nc.Oficina _new = new nc.Oficina();
		 _new.Nombre= entity.Nombre;
		 _new.Codigo= entity.Codigo;
		 _new.Activo= entity.Activo;
		 _new.Visible= entity.Visible;
		 _new.IdOficinaPadre= entity.IdOficinaPadre;
		 _new.IdSaf= entity.IdSaf;
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
		public override int CopyAndSave(Oficina entity,string renameFormat)
        {
            Oficina  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Oficina entity, int id)
        {            
            entity.IdOficina = id;            
        }
		public override void Set(Oficina source,Oficina target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficina= source.IdOficina ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Activo= source.Activo ;
		 target.Visible= source.Visible ;
		 target.IdOficinaPadre= source.IdOficinaPadre ;
		 target.IdSaf= source.IdSaf ;
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
		public override void Set(OficinaResult source,Oficina target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficina= source.IdOficina ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Activo= source.Activo ;
		 target.Visible= source.Visible ;
		 target.IdOficinaPadre= source.IdOficinaPadre ;
		 target.IdSaf= source.IdSaf ;
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
		public override void Set(Oficina source,OficinaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficina= source.IdOficina ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Activo= source.Activo ;
		 target.Visible= source.Visible ;
		 target.IdOficinaPadre= source.IdOficinaPadre ;
		 target.IdSaf= source.IdSaf ;
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
		public override void Set(OficinaResult source,OficinaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficina= source.IdOficina ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Activo= source.Activo ;
		 target.Visible= source.Visible ;
		 target.IdOficinaPadre= source.IdOficinaPadre ;
		 target.IdSaf= source.IdSaf ;
		 target.BreadcrumbId= source.BreadcrumbId ;
		 target.BreadcrumbOrden= source.BreadcrumbOrden ;
		 target.Nivel= source.Nivel ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.DescripcionInvertida= source.DescripcionInvertida ;
		 target.Seleccionable= source.Seleccionable ;
		 target.BreadcrumbCode= source.BreadcrumbCode ;
		 target.DescripcionCodigo= source.DescripcionCodigo ;
		 target.OficinaPadre_Nombre= source.OficinaPadre_Nombre;	
			target.OficinaPadre_Codigo= source.OficinaPadre_Codigo;	
			target.OficinaPadre_Activo= source.OficinaPadre_Activo;	
			target.OficinaPadre_Visible= source.OficinaPadre_Visible;	
			target.OficinaPadre_IdOficinaPadre= source.OficinaPadre_IdOficinaPadre;	
			target.OficinaPadre_IdSaf= source.OficinaPadre_IdSaf;	
			target.OficinaPadre_BreadcrumbId= source.OficinaPadre_BreadcrumbId;	
			target.OficinaPadre_BreadcrumbOrden= source.OficinaPadre_BreadcrumbOrden;	
			target.OficinaPadre_Nivel= source.OficinaPadre_Nivel;	
			target.OficinaPadre_Orden= source.OficinaPadre_Orden;	
			target.OficinaPadre_Descripcion= source.OficinaPadre_Descripcion;	
			target.OficinaPadre_DescripcionInvertida= source.OficinaPadre_DescripcionInvertida;	
			target.OficinaPadre_Seleccionable= source.OficinaPadre_Seleccionable;	
			target.OficinaPadre_BreadcrumbCode= source.OficinaPadre_BreadcrumbCode;	
			target.OficinaPadre_DescripcionCodigo= source.OficinaPadre_DescripcionCodigo;	
			target.Saf_Codigo= source.Saf_Codigo;	
			target.Saf_Denominacion= source.Saf_Denominacion;	
			target.Saf_IdTipoOrganismo= source.Saf_IdTipoOrganismo;	
			target.Saf_IdSector= source.Saf_IdSector;	
			target.Saf_IdAdministracionTipo= source.Saf_IdAdministracionTipo;	
			target.Saf_IdEntidadTipo= source.Saf_IdEntidadTipo;	
			target.Saf_IdJurisdiccion= source.Saf_IdJurisdiccion;	
			target.Saf_IdSubJurisdiccion= source.Saf_IdSubJurisdiccion;	
			target.Saf_FechaAlta= source.Saf_FechaAlta;	
			target.Saf_FechaBaja= source.Saf_FechaBaja;	
			target.Saf_Activo= source.Saf_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Oficina source,Oficina target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.Visible.Equals(target.Visible))return false;
		  if((source.IdOficinaPadre == null)?(target.IdOficinaPadre.HasValue && target.IdOficinaPadre.Value > 0):!source.IdOficinaPadre.Equals(target.IdOficinaPadre))return false;
						  if((source.IdSaf == null)?(target.IdSaf.HasValue && target.IdSaf.Value > 0):!source.IdSaf.Equals(target.IdSaf))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null:  !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) &&  !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null:  !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) &&  !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		  if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null:  !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) &&  !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null:  !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) &&  !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null:  !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) &&  !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(OficinaResult source,OficinaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.Visible.Equals(target.Visible))return false;
		  if((source.IdOficinaPadre == null)?(target.IdOficinaPadre.HasValue && target.IdOficinaPadre.Value > 0):!source.IdOficinaPadre.Equals(target.IdOficinaPadre))return false;
						  if((source.IdSaf == null)?(target.IdSaf.HasValue && target.IdSaf.Value > 0):!source.IdSaf.Equals(target.IdSaf))return false;
						  if((source.BreadcrumbId == null)?target.BreadcrumbId!=null: !( (target.BreadcrumbId== String.Empty && source.BreadcrumbId== null) || (target.BreadcrumbId==null && source.BreadcrumbId== String.Empty )) && !source.BreadcrumbId.Trim().Replace ("\r","").Equals(target.BreadcrumbId.Trim().Replace ("\r","")))return false;
			 if((source.BreadcrumbOrden == null)?target.BreadcrumbOrden!=null: !( (target.BreadcrumbOrden== String.Empty && source.BreadcrumbOrden== null) || (target.BreadcrumbOrden==null && source.BreadcrumbOrden== String.Empty )) && !source.BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.BreadcrumbOrden.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		  if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionInvertida == null)?target.DescripcionInvertida!=null: !( (target.DescripcionInvertida== String.Empty && source.DescripcionInvertida== null) || (target.DescripcionInvertida==null && source.DescripcionInvertida== String.Empty )) && !source.DescripcionInvertida.Trim().Replace ("\r","").Equals(target.DescripcionInvertida.Trim().Replace ("\r","")))return false;
			 if(!source.Seleccionable.Equals(target.Seleccionable))return false;
		  if((source.BreadcrumbCode == null)?target.BreadcrumbCode!=null: !( (target.BreadcrumbCode== String.Empty && source.BreadcrumbCode== null) || (target.BreadcrumbCode==null && source.BreadcrumbCode== String.Empty )) && !source.BreadcrumbCode.Trim().Replace ("\r","").Equals(target.BreadcrumbCode.Trim().Replace ("\r","")))return false;
			 if((source.DescripcionCodigo == null)?target.DescripcionCodigo!=null: !( (target.DescripcionCodigo== String.Empty && source.DescripcionCodigo== null) || (target.DescripcionCodigo==null && source.DescripcionCodigo== String.Empty )) && !source.DescripcionCodigo.Trim().Replace ("\r","").Equals(target.DescripcionCodigo.Trim().Replace ("\r","")))return false;
			 if((source.OficinaPadre_Nombre == null)?target.OficinaPadre_Nombre!=null: !( (target.OficinaPadre_Nombre== String.Empty && source.OficinaPadre_Nombre== null) || (target.OficinaPadre_Nombre==null && source.OficinaPadre_Nombre== String.Empty )) &&   !source.OficinaPadre_Nombre.Trim().Replace ("\r","").Equals(target.OficinaPadre_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.OficinaPadre_Codigo == null)?target.OficinaPadre_Codigo!=null: !( (target.OficinaPadre_Codigo== String.Empty && source.OficinaPadre_Codigo== null) || (target.OficinaPadre_Codigo==null && source.OficinaPadre_Codigo== String.Empty )) &&   !source.OficinaPadre_Codigo.Trim().Replace ("\r","").Equals(target.OficinaPadre_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.OficinaPadre_Activo.Equals(target.OficinaPadre_Activo))return false;
					  if(!source.OficinaPadre_Visible.Equals(target.OficinaPadre_Visible))return false;
					  if((source.OficinaPadre_IdOficinaPadre == null)?(target.OficinaPadre_IdOficinaPadre.HasValue && target.OficinaPadre_IdOficinaPadre.Value > 0):!source.OficinaPadre_IdOficinaPadre.Equals(target.OficinaPadre_IdOficinaPadre))return false;
									  if((source.OficinaPadre_IdSaf == null)?(target.OficinaPadre_IdSaf.HasValue && target.OficinaPadre_IdSaf.Value > 0):!source.OficinaPadre_IdSaf.Equals(target.OficinaPadre_IdSaf))return false;
									  if((source.OficinaPadre_BreadcrumbId == null)?target.OficinaPadre_BreadcrumbId!=null: !( (target.OficinaPadre_BreadcrumbId== String.Empty && source.OficinaPadre_BreadcrumbId== null) || (target.OficinaPadre_BreadcrumbId==null && source.OficinaPadre_BreadcrumbId== String.Empty )) &&   !source.OficinaPadre_BreadcrumbId.Trim().Replace ("\r","").Equals(target.OficinaPadre_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.OficinaPadre_BreadcrumbOrden == null)?target.OficinaPadre_BreadcrumbOrden!=null: !( (target.OficinaPadre_BreadcrumbOrden== String.Empty && source.OficinaPadre_BreadcrumbOrden== null) || (target.OficinaPadre_BreadcrumbOrden==null && source.OficinaPadre_BreadcrumbOrden== String.Empty )) &&   !source.OficinaPadre_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.OficinaPadre_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if(!source.OficinaPadre_Nivel.Equals(target.OficinaPadre_Nivel))return false;
					  if((source.OficinaPadre_Orden == null)?(target.OficinaPadre_Orden.HasValue ):!source.OficinaPadre_Orden.Equals(target.OficinaPadre_Orden))return false;
						 if((source.OficinaPadre_Descripcion == null)?target.OficinaPadre_Descripcion!=null: !( (target.OficinaPadre_Descripcion== String.Empty && source.OficinaPadre_Descripcion== null) || (target.OficinaPadre_Descripcion==null && source.OficinaPadre_Descripcion== String.Empty )) &&   !source.OficinaPadre_Descripcion.Trim().Replace ("\r","").Equals(target.OficinaPadre_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.OficinaPadre_DescripcionInvertida == null)?target.OficinaPadre_DescripcionInvertida!=null: !( (target.OficinaPadre_DescripcionInvertida== String.Empty && source.OficinaPadre_DescripcionInvertida== null) || (target.OficinaPadre_DescripcionInvertida==null && source.OficinaPadre_DescripcionInvertida== String.Empty )) &&   !source.OficinaPadre_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.OficinaPadre_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.OficinaPadre_Seleccionable.Equals(target.OficinaPadre_Seleccionable))return false;
					  if((source.OficinaPadre_BreadcrumbCode == null)?target.OficinaPadre_BreadcrumbCode!=null: !( (target.OficinaPadre_BreadcrumbCode== String.Empty && source.OficinaPadre_BreadcrumbCode== null) || (target.OficinaPadre_BreadcrumbCode==null && source.OficinaPadre_BreadcrumbCode== String.Empty )) &&   !source.OficinaPadre_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.OficinaPadre_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.OficinaPadre_DescripcionCodigo == null)?target.OficinaPadre_DescripcionCodigo!=null: !( (target.OficinaPadre_DescripcionCodigo== String.Empty && source.OficinaPadre_DescripcionCodigo== null) || (target.OficinaPadre_DescripcionCodigo==null && source.OficinaPadre_DescripcionCodigo== String.Empty )) &&   !source.OficinaPadre_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.OficinaPadre_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.Saf_Codigo == null)?target.Saf_Codigo!=null: !( (target.Saf_Codigo== String.Empty && source.Saf_Codigo== null) || (target.Saf_Codigo==null && source.Saf_Codigo== String.Empty )) &&   !source.Saf_Codigo.Trim().Replace ("\r","").Equals(target.Saf_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Saf_Denominacion == null)?target.Saf_Denominacion!=null: !( (target.Saf_Denominacion== String.Empty && source.Saf_Denominacion== null) || (target.Saf_Denominacion==null && source.Saf_Denominacion== String.Empty )) &&   !source.Saf_Denominacion.Trim().Replace ("\r","").Equals(target.Saf_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.Saf_IdTipoOrganismo.Equals(target.Saf_IdTipoOrganismo))return false;
					  if((source.Saf_IdSector == null)?(target.Saf_IdSector.HasValue && target.Saf_IdSector.Value > 0):!source.Saf_IdSector.Equals(target.Saf_IdSector))return false;
									  if((source.Saf_IdAdministracionTipo == null)?(target.Saf_IdAdministracionTipo.HasValue && target.Saf_IdAdministracionTipo.Value > 0):!source.Saf_IdAdministracionTipo.Equals(target.Saf_IdAdministracionTipo))return false;
									  if((source.Saf_IdEntidadTipo == null)?(target.Saf_IdEntidadTipo.HasValue && target.Saf_IdEntidadTipo.Value > 0):!source.Saf_IdEntidadTipo.Equals(target.Saf_IdEntidadTipo))return false;
									  if((source.Saf_IdJurisdiccion == null)?(target.Saf_IdJurisdiccion.HasValue && target.Saf_IdJurisdiccion.Value > 0):!source.Saf_IdJurisdiccion.Equals(target.Saf_IdJurisdiccion))return false;
									  if((source.Saf_IdSubJurisdiccion == null)?(target.Saf_IdSubJurisdiccion.HasValue && target.Saf_IdSubJurisdiccion.Value > 0):!source.Saf_IdSubJurisdiccion.Equals(target.Saf_IdSubJurisdiccion))return false;
									  if(!source.Saf_FechaAlta.Equals(target.Saf_FechaAlta))return false;
					  if((source.Saf_FechaBaja == null)?(target.Saf_FechaBaja.HasValue ):!source.Saf_FechaBaja.Equals(target.Saf_FechaBaja))return false;
						 if(!source.Saf_Activo.Equals(target.Saf_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
