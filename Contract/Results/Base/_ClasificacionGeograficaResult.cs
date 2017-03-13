using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionGeograficaResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacionGeografica;}}
		 public int IdClasificacionGeografica{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int IdClasificacionGeograficaTipo{get;set;}
		 public int? IdClasificacionGeograficaPadre{get;set;}
		 public bool Activo{get;set;}
		 public string Descripcion{get;set;}
		 public string BreadcrumbId{get;set;}
		 public string BreadcrumOrden{get;set;}
		 public int? Orden{get;set;}
		 public int? Nivel{get;set;}
		 public string DescripcionInvertida{get;set;}
		 public bool Seleccionable{get;set;}
		 public string BreadcrumbCode{get;set;}
		 public string DescripcionCodigo{get;set;}
		 
    //     public string ClasificacionGeograficaPadre_Codigo{get;set;}	
    public string ClasificacionGeograficaPadre_Nombre{get;set;}	
    //public int? ClasificacionGeograficaPadre_IdClasificacionGeograficaTipo{get;set;}	
    //public int? ClasificacionGeograficaPadre_IdClasificacionGeograficaPadre{get;set;}	
    //public bool? ClasificacionGeograficaPadre_Activo{get;set;}	
    //public string ClasificacionGeograficaPadre_Descripcion{get;set;}	
    //public string ClasificacionGeograficaPadre_BreadcrumbId{get;set;}	
    //public string ClasificacionGeograficaPadre_BreadcrumOrden{get;set;}	
    //public int? ClasificacionGeograficaPadre_Orden{get;set;}	
    //public int? ClasificacionGeograficaPadre_Nivel{get;set;}	
    //public string ClasificacionGeograficaPadre_DescripcionInvertida{get;set;}	
    //public bool? ClasificacionGeograficaPadre_Seleccionable{get;set;}	
    public string ClasificacionGeograficaPadre_BreadcrumbCode{get;set;}	
    //public string ClasificacionGeograficaPadre_DescripcionCodigo{get;set;}	
    public string ClasificacionGeograficaTipo_Nombre{get;set;}	
    public int ClasificacionGeograficaTipo_Nivel{get;set;}	
					
    //    public virtual ClasificacionGeografica ToEntity()
    //    {
    //       ClasificacionGeografica _ClasificacionGeografica = new ClasificacionGeografica();
    //    _ClasificacionGeografica.IdClasificacionGeografica = this.IdClasificacionGeografica;
    //     _ClasificacionGeografica.Codigo = this.Codigo;
    //     _ClasificacionGeografica.Nombre = this.Nombre;
    //     _ClasificacionGeografica.IdClasificacionGeograficaTipo = this.IdClasificacionGeograficaTipo;
    //     _ClasificacionGeografica.IdClasificacionGeograficaPadre = this.IdClasificacionGeograficaPadre;
    //     _ClasificacionGeografica.Activo = this.Activo;
    //     _ClasificacionGeografica.Descripcion = this.Descripcion;
    //     _ClasificacionGeografica.BreadcrumbId = this.BreadcrumbId;
    //     _ClasificacionGeografica.BreadcrumOrden = this.BreadcrumOrden;
    //     _ClasificacionGeografica.Orden = this.Orden;
    //     _ClasificacionGeografica.Nivel = this.Nivel;
    //     _ClasificacionGeografica.DescripcionInvertida = this.DescripcionInvertida;
    //     _ClasificacionGeografica.Seleccionable = this.Seleccionable;
    //     _ClasificacionGeografica.BreadcrumbCode = this.BreadcrumbCode;
    //     _ClasificacionGeografica.DescripcionCodigo = this.DescripcionCodigo;
		 
    //      return _ClasificacionGeografica;
    //    }		
    //    public virtual void Set(ClasificacionGeografica entity)
    //    {		   
    //     this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
    //      this.Codigo= entity.Codigo ;
    //      this.Nombre= entity.Nombre ;
    //      this.IdClasificacionGeograficaTipo= entity.IdClasificacionGeograficaTipo ;
    //      this.IdClasificacionGeograficaPadre= entity.IdClasificacionGeograficaPadre ;
    //      this.Activo= entity.Activo ;
    //      this.Descripcion= entity.Descripcion ;
    //      this.BreadcrumbId= entity.BreadcrumbId ;
    //      this.BreadcrumOrden= entity.BreadcrumOrden ;
    //      this.Orden= entity.Orden ;
    //      this.Nivel= entity.Nivel ;
    //      this.DescripcionInvertida= entity.DescripcionInvertida ;
    //      this.Seleccionable= entity.Seleccionable ;
    //      this.BreadcrumbCode= entity.BreadcrumbCode ;
    //      this.DescripcionCodigo= entity.DescripcionCodigo ;
		 		  
    //    }		
    //    public virtual bool Equals(ClasificacionGeografica entity)
    //    {
    //       if(entity == null)return false;
    //     if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
    //      if(!entity.Codigo.Equals(this.Codigo))return false;
    //      if(!entity.Nombre.Equals(this.Nombre))return false;
    //      if(!entity.IdClasificacionGeograficaTipo.Equals(this.IdClasificacionGeograficaTipo))return false;
    //      if((entity.IdClasificacionGeograficaPadre == null)?(this.IdClasificacionGeograficaPadre.HasValue && this.IdClasificacionGeograficaPadre.Value > 0):!entity.IdClasificacionGeograficaPadre.Equals(this.IdClasificacionGeograficaPadre))return false;
    //                      if(!entity.Activo.Equals(this.Activo))return false;
    //      if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
    //         if((entity.BreadcrumbId == null)?this.BreadcrumbId!=null:!entity.BreadcrumbId.Equals(this.BreadcrumbId))return false;
    //         if((entity.BreadcrumOrden == null)?this.BreadcrumOrden!=null:!entity.BreadcrumOrden.Equals(this.BreadcrumOrden))return false;
    //         if((entity.Orden == null)?this.Orden!=null:!entity.Orden.Equals(this.Orden))return false;
    //         if((entity.Nivel == null)?this.Nivel!=null:!entity.Nivel.Equals(this.Nivel))return false;
    //         if((entity.DescripcionInvertida == null)?this.DescripcionInvertida!=null:!entity.DescripcionInvertida.Equals(this.DescripcionInvertida))return false;
    //         if(!entity.Seleccionable.Equals(this.Seleccionable))return false;
    //      if((entity.BreadcrumbCode == null)?this.BreadcrumbCode!=null:!entity.BreadcrumbCode.Equals(this.BreadcrumbCode))return false;
    //         if((entity.DescripcionCodigo == null)?this.DescripcionCodigo!=null:!entity.DescripcionCodigo.Equals(this.DescripcionCodigo))return false;
			
    //      return true;
    //    }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ClasificacionGeografica", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("ClasificacionGeograficaTipo","ClasificacionGeograficaTipo_Nombre")
			,new DataColumnMapping("ClasificacionGeograficaPadre","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("Breadcrumb","BreadcrumbId")
			,new DataColumnMapping("BreadcrumOrden","BreadcrumOrden")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Nivel","Nivel")
			,new DataColumnMapping("DescripcionInvertida","DescripcionInvertida")
			,new DataColumnMapping("Seleccionable","Seleccionable")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			,new DataColumnMapping("DescripcionCodigo","DescripcionCodigo")
			}));
		}
	}
}
		