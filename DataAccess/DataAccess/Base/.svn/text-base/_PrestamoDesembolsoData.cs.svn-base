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
    public abstract class _PrestamoDesembolsoData : EntityData<PrestamoDesembolso,PrestamoDesembolsoFilter,PrestamoDesembolsoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoDesembolso entity)
		{			
			return entity.IdPrestamoDesembolso;
		}		
		public override PrestamoDesembolso GetByEntity(PrestamoDesembolso entity)
        {
            return this.GetById(entity.IdPrestamoDesembolso);
        }
        public override PrestamoDesembolso GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoDesembolso == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoDesembolso> Query(PrestamoDesembolsoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoDesembolso == null || o.IdPrestamoDesembolso >=  filter.IdPrestamoDesembolso) && (filter.IdPrestamoDesembolso_To == null || o.IdPrestamoDesembolso <= filter.IdPrestamoDesembolso_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == true || o.IdPrestamo != null ) && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == false || o.IdPrestamo == null)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.FechaIsNull == null || filter.FechaIsNull == true || o.Fecha != null ) && (filter.FechaIsNull == null || filter.FechaIsNull == false || o.Fecha == null)
					  && (filter.MontoAcumulado == null || o.MontoAcumulado >=  filter.MontoAcumulado) && (filter.MontoAcumulado_To == null || o.MontoAcumulado <= filter.MontoAcumulado_To)
					  && (filter.MontoAcumuladoIsNull == null || filter.MontoAcumuladoIsNull == true || o.MontoAcumulado != null ) && (filter.MontoAcumuladoIsNull == null || filter.MontoAcumuladoIsNull == false || o.MontoAcumulado == null)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoDesembolsoResult> QueryResult(PrestamoDesembolsoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Prestamos on o.IdPrestamo equals _t1.IdPrestamo into tt1 from t1 in tt1.DefaultIfEmpty()
				   select new PrestamoDesembolsoResult(){
					 IdPrestamoDesembolso=o.IdPrestamoDesembolso
					 ,IdPrestamo=o.IdPrestamo
					 ,Fecha=o.Fecha
					 ,MontoAcumulado=o.MontoAcumulado
					 ,Observacion=o.Observacion
                    //,Prestamo_IdPrograma= t1!=null?(int?)t1.IdPrograma:null	
                    //    ,Prestamo_Numero= t1!=null?(int?)t1.Numero:null	
                    //    ,Prestamo_Denominacion= t1!=null?(string)t1.Denominacion:null	
                    //    ,Prestamo_Descripcion= t1!=null?(string)t1.Descripcion:null	
                    //    ,Prestamo_Observacion= t1!=null?(string)t1.Observacion:null	
                    //    ,Prestamo_FechaAlta= t1!=null?(DateTime?)t1.FechaAlta:null	
                    //    ,Prestamo_FechaModificacion= t1!=null?(DateTime?)t1.FechaModificacion:null	
                    //    ,Prestamo_IdUsuarioModificacion= t1!=null?(int?)t1.IdUsuarioModificacion:null	
                    //    ,Prestamo_IdEstadoActual= t1!=null?(int?)t1.IdEstadoActual:null	
                    //    ,Prestamo_ResponsablePolitico= t1!=null?(string)t1.ResponsablePolitico:null	
                    //    ,Prestamo_ResponsableTecnico= t1!=null?(string)t1.ResponsableTecnico:null	
                    //    ,Prestamo_CodigoVinculacion1= t1!=null?(string)t1.CodigoVinculacion1:null	
                    //    ,Prestamo_CodigoVinculacion2= t1!=null?(string)t1.CodigoVinculacion2:null	
                    //    ,Prestamo_Activo= t1!=null?(bool?)t1.Activo:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoDesembolso Copy(nc.PrestamoDesembolso entity)
        {           
            nc.PrestamoDesembolso _new = new nc.PrestamoDesembolso();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.Fecha= entity.Fecha;
		 _new.MontoAcumulado= entity.MontoAcumulado;
		 _new.Observacion= entity.Observacion;
		return _new;			
        }
		public override int CopyAndSave(PrestamoDesembolso entity,string renameFormat)
        {
            PrestamoDesembolso  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoDesembolso entity, int id)
        {            
            entity.IdPrestamoDesembolso = id;            
        }
		public override void Set(PrestamoDesembolso source,PrestamoDesembolso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDesembolso= source.IdPrestamoDesembolso ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.MontoAcumulado= source.MontoAcumulado ;
		 target.Observacion= source.Observacion ;
		 		  
		}
		public override void Set(PrestamoDesembolsoResult source,PrestamoDesembolso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDesembolso= source.IdPrestamoDesembolso ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.MontoAcumulado= source.MontoAcumulado ;
		 target.Observacion= source.Observacion ;
		 
		}
		public override void Set(PrestamoDesembolso source,PrestamoDesembolsoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDesembolso= source.IdPrestamoDesembolso ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.MontoAcumulado= source.MontoAcumulado ;
		 target.Observacion= source.Observacion ;
		 	
		}		
		public override void Set(PrestamoDesembolsoResult source,PrestamoDesembolsoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDesembolso= source.IdPrestamoDesembolso ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.Fecha= source.Fecha ;
		 target.MontoAcumulado= source.MontoAcumulado ;
		 target.Observacion= source.Observacion ;
         //target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
         //   target.Prestamo_Numero= source.Prestamo_Numero;	
         //   target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
         //   target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
         //   target.Prestamo_Observacion= source.Prestamo_Observacion;	
         //   target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
         //   target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
         //   target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
         //   target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
         //   target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
         //   target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
         //   target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
         //   target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
         //   //target.Prestamo_Activo= source.Prestamo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoDesembolso source,PrestamoDesembolso target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDesembolso.Equals(target.IdPrestamoDesembolso))return false;
		  if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue && target.IdPrestamo.Value > 0):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
						  if((source.Fecha == null)?(target.Fecha.HasValue):!source.Fecha.Equals(target.Fecha))return false;
			 if((source.MontoAcumulado == null)?(target.MontoAcumulado.HasValue):!source.MontoAcumulado.Equals(target.MontoAcumulado))return false;
			 if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoDesembolsoResult source,PrestamoDesembolsoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDesembolso.Equals(target.IdPrestamoDesembolso))return false;
		  if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue && target.IdPrestamo.Value > 0):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
						  if((source.Fecha == null)?(target.Fecha.HasValue):!source.Fecha.Equals(target.Fecha))return false;
			 if((source.MontoAcumulado == null)?(target.MontoAcumulado.HasValue):!source.MontoAcumulado.Equals(target.MontoAcumulado))return false;
			 if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
             //if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
             //         if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
             //         if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
             //            if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
             //            if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
             //            if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
             //         if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
             //         if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
             //         if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
             //            if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
             //            if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
             //            if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
             //            if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
             //            if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
