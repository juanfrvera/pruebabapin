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
    public abstract class _SubProcesoData : EntityData<SubProceso,SubProcesoFilter,SubProcesoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SubProceso entity)
		{			
			return entity.IdSubProceso;
		}		
		public override SubProceso GetByEntity(SubProceso entity)
        {
            return this.GetById(entity.IdSubProceso);
        }
        public override SubProceso GetById(int id)
        {
            return (from o in this.Table where o.IdSubProceso == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SubProceso> Query(SubProcesoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSubProceso == null || o.IdSubProceso >=  filter.IdSubProceso) && (filter.IdSubProceso_To == null || o.IdSubProceso <= filter.IdSubProceso_To)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso==filter.IdProceso)
					  && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == true || o.IdProceso != null ) && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == false || o.IdProceso == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SubProcesoResult> QueryResult(SubProcesoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Procesos on o.IdProceso equals _t1.IdProceso into tt1 from t1 in tt1.DefaultIfEmpty()
				   select new SubProcesoResult(){
					 IdSubProceso=o.IdSubProceso
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					 ,IdProceso=o.IdProceso
					,Proceso_IdProyectoTipo= t1!=null?(int?)t1.IdProyectoTipo:null	
						,Proceso_Nombre= t1!=null?(string)t1.Nombre:null	
						,Proceso_Activo= t1!=null?(bool?)t1.Activo:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SubProceso Copy(nc.SubProceso entity)
        {           
            nc.SubProceso _new = new nc.SubProceso();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		 _new.IdProceso= entity.IdProceso;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(SubProceso entity, int id)
        {            
            entity.IdSubProceso = id;            
        }
		public override void Set(SubProceso source,SubProceso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubProceso= source.IdSubProceso ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.IdProceso= source.IdProceso ;
		 		  
		}
		public override void Set(SubProcesoResult source,SubProceso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubProceso= source.IdSubProceso ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.IdProceso= source.IdProceso ;
		 
		}
		public override void Set(SubProceso source,SubProcesoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubProceso= source.IdSubProceso ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.IdProceso= source.IdProceso ;
		 	
		}		
		public override void Set(SubProcesoResult source,SubProcesoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubProceso= source.IdSubProceso ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 target.IdProceso= source.IdProceso ;
		 target.Proceso_IdProyectoTipo= source.Proceso_IdProyectoTipo;	
			target.Proceso_Nombre= source.Proceso_Nombre;	
			target.Proceso_Activo= source.Proceso_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(SubProceso source,SubProceso target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubProceso.Equals(target.IdSubProceso))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						 
		  return true;
        }
		public override bool Equals(SubProcesoResult source,SubProcesoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubProceso.Equals(target.IdSubProceso))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						  if(!source.Proceso_IdProyectoTipo.Equals(target.Proceso_IdProyectoTipo))return false;
					  if(!source.Proceso_Nombre.Equals(target.Proceso_Nombre))return false;
					  if(!source.Proceso_Activo.Equals(target.Proceso_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
