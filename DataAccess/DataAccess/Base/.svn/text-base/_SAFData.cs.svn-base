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
    public abstract class _SafData : EntityData<Saf,SafFilter,SafResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Saf entity)
		{			
			return entity.IdSaf;
		}		
		public override Saf GetByEntity(Saf entity)
        {
            return this.GetById(entity.IdSaf);
        }
        public override Saf GetById(int id)
        {
            return (from o in this.Table where o.IdSaf == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Saf> Query(SafFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSaf == null || filter.IdSaf == 0 || o.IdSaf==filter.IdSaf)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%"  || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%",""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%",""))) || o.Denominacion == filter.Denominacion )
					  && (filter.IdTipoOrganismo == null || filter.IdTipoOrganismo == 0 || o.IdTipoOrganismo==filter.IdTipoOrganismo)
					  && (filter.IdSector == null || filter.IdSector == 0 || o.IdSector==filter.IdSector)
					  && (filter.IdSectorIsNull == null || filter.IdSectorIsNull == true || o.IdSector != null ) && (filter.IdSectorIsNull == null || filter.IdSectorIsNull == false || o.IdSector == null)
					  && (filter.IdAdministracionTipo == null || filter.IdAdministracionTipo == 0 || o.IdAdministracionTipo==filter.IdAdministracionTipo)
					  && (filter.IdAdministracionTipoIsNull == null || filter.IdAdministracionTipoIsNull == true || o.IdAdministracionTipo != null ) && (filter.IdAdministracionTipoIsNull == null || filter.IdAdministracionTipoIsNull == false || o.IdAdministracionTipo == null)
					  && (filter.IdEntidadTipo == null || filter.IdEntidadTipo == 0 || o.IdEntidadTipo==filter.IdEntidadTipo)
					  && (filter.IdEntidadTipoIsNull == null || filter.IdEntidadTipoIsNull == true || o.IdEntidadTipo != null ) && (filter.IdEntidadTipoIsNull == null || filter.IdEntidadTipoIsNull == false || o.IdEntidadTipo == null)
					  && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || o.IdJurisdiccion==filter.IdJurisdiccion)
					  && (filter.IdJurisdiccionIsNull == null || filter.IdJurisdiccionIsNull == true || o.IdJurisdiccion != null ) && (filter.IdJurisdiccionIsNull == null || filter.IdJurisdiccionIsNull == false || o.IdJurisdiccion == null)
					  && (filter.IdSubJurisdiccion == null || filter.IdSubJurisdiccion == 0 || o.IdSubJurisdiccion==filter.IdSubJurisdiccion)
					  && (filter.IdSubJurisdiccionIsNull == null || filter.IdSubJurisdiccionIsNull == true || o.IdSubJurisdiccion != null ) && (filter.IdSubJurisdiccionIsNull == null || filter.IdSubJurisdiccionIsNull == false || o.IdSubJurisdiccion == null)
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaBaja == null || filter.FechaBaja == DateTime.MinValue || o.FechaBaja >=  filter.FechaBaja) && (filter.FechaBaja_To == null || filter.FechaBaja_To == DateTime.MinValue || o.FechaBaja <= filter.FechaBaja_To)
					  && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == true || o.FechaBaja != null ) && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == false || o.FechaBaja == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SafResult> QueryResult(SafFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.AdministracionTipos on o.IdAdministracionTipo equals _t1.IdAdministracionTipo into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.EntidadTipos on o.IdEntidadTipo equals _t2.IdEntidadTipo into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.Jurisdiccions on o.IdJurisdiccion equals _t3.IdJurisdiccion into tt3 from t3 in tt3.DefaultIfEmpty()
				    join t4  in this.Context.OrganismoTipos on o.IdTipoOrganismo equals t4.IdOrganismoTipo   
				   join _t5  in this.Context.Sectors on o.IdSector equals _t5.IdSector into tt5 from t5 in tt5.DefaultIfEmpty()
				   join _t6  in this.Context.SubJurisdiccions on o.IdSubJurisdiccion equals _t6.IdSubJuridiccion into tt6 from t6 in tt6.DefaultIfEmpty()
				   select new SafResult(){
					 IdSaf=o.IdSaf
					 ,Codigo=o.Codigo
					 ,Denominacion=o.Denominacion
					 ,IdTipoOrganismo=o.IdTipoOrganismo
					 ,IdSector=o.IdSector
					 ,IdAdministracionTipo=o.IdAdministracionTipo
					 ,IdEntidadTipo=o.IdEntidadTipo
					 ,IdJurisdiccion=o.IdJurisdiccion
					 ,IdSubJurisdiccion=o.IdSubJurisdiccion
					 ,FechaAlta=o.FechaAlta
					 ,FechaBaja=o.FechaBaja
					 ,Activo=o.Activo
					,AdministracionTipo_Codigo= t1!=null?(string)t1.Codigo:null	
						,AdministracionTipo_Nombre= t1!=null?(string)t1.Nombre:null	
						,AdministracionTipo_Activo= t1!=null?(bool?)t1.Activo:null	
						,EntidadTipo_Codigo= t2!=null?(string)t2.Codigo:null	
						,EntidadTipo_Nombre= t2!=null?(string)t2.Nombre:null	
						,EntidadTipo_Activo= t2!=null?(bool?)t2.Activo:null	
						,Jurisdiccion_Codigo= t3!=null?(string)t3.Codigo:null	
						,Jurisdiccion_Nombre= t3!=null?(string)t3.Nombre:null	
						,Jurisdiccion_Activo= t3!=null?(bool?)t3.Activo:null	
						,TipoOrganismo_Nombre= t4.Nombre	
						,TipoOrganismo_Activo= t4.Activo	
						,Sector_Codigo= t5!=null?(string)t5.Codigo:null	
						,Sector_Nombre= t5!=null?(string)t5.Nombre:null	
						,Sector_Activo= t5!=null?(bool?)t5.Activo:null	
						,SubJurisdiccion_Codigo= t6!=null?(string)t6.Codigo:null	
						,SubJurisdiccion_Nombre= t6!=null?(string)t6.Nombre:null	
						,SubJurisdiccion_Activo= t6!=null?(bool?)t6.Activo:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Saf Copy(nc.Saf entity)
        {           
            nc.Saf _new = new nc.Saf();
		 _new.Codigo= entity.Codigo;
		 _new.Denominacion= entity.Denominacion;
		 _new.IdTipoOrganismo= entity.IdTipoOrganismo;
		 _new.IdSector= entity.IdSector;
		 _new.IdAdministracionTipo= entity.IdAdministracionTipo;
		 _new.IdEntidadTipo= entity.IdEntidadTipo;
		 _new.IdJurisdiccion= entity.IdJurisdiccion;
		 _new.IdSubJurisdiccion= entity.IdSubJurisdiccion;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaBaja= entity.FechaBaja;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Saf entity,string renameFormat)
        {
            Saf  newEntity = Copy(entity);
            newEntity.Codigo = string.Format(renameFormat,newEntity.Codigo);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Saf entity, int id)
        {            
            entity.IdSaf = id;            
        }
		public override void Set(Saf source,Saf target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSaf= source.IdSaf ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.IdTipoOrganismo= source.IdTipoOrganismo ;
		 target.IdSector= source.IdSector ;
		 target.IdAdministracionTipo= source.IdAdministracionTipo ;
		 target.IdEntidadTipo= source.IdEntidadTipo ;
		 target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.IdSubJurisdiccion= source.IdSubJurisdiccion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(SafResult source,Saf target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSaf= source.IdSaf ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.IdTipoOrganismo= source.IdTipoOrganismo ;
		 target.IdSector= source.IdSector ;
		 target.IdAdministracionTipo= source.IdAdministracionTipo ;
		 target.IdEntidadTipo= source.IdEntidadTipo ;
		 target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.IdSubJurisdiccion= source.IdSubJurisdiccion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Saf source,SafResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSaf= source.IdSaf ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.IdTipoOrganismo= source.IdTipoOrganismo ;
		 target.IdSector= source.IdSector ;
		 target.IdAdministracionTipo= source.IdAdministracionTipo ;
		 target.IdEntidadTipo= source.IdEntidadTipo ;
		 target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.IdSubJurisdiccion= source.IdSubJurisdiccion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(SafResult source,SafResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSaf= source.IdSaf ;
		 target.Codigo= source.Codigo ;
		 target.Denominacion= source.Denominacion ;
		 target.IdTipoOrganismo= source.IdTipoOrganismo ;
		 target.IdSector= source.IdSector ;
		 target.IdAdministracionTipo= source.IdAdministracionTipo ;
		 target.IdEntidadTipo= source.IdEntidadTipo ;
		 target.IdJurisdiccion= source.IdJurisdiccion ;
		 target.IdSubJurisdiccion= source.IdSubJurisdiccion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.AdministracionTipo_Codigo= source.AdministracionTipo_Codigo;	
			target.AdministracionTipo_Nombre= source.AdministracionTipo_Nombre;	
			target.AdministracionTipo_Activo= source.AdministracionTipo_Activo;	
			target.EntidadTipo_Codigo= source.EntidadTipo_Codigo;	
			target.EntidadTipo_Nombre= source.EntidadTipo_Nombre;	
			target.EntidadTipo_Activo= source.EntidadTipo_Activo;	
			target.Jurisdiccion_Codigo= source.Jurisdiccion_Codigo;	
			target.Jurisdiccion_Nombre= source.Jurisdiccion_Nombre;	
			target.Jurisdiccion_Activo= source.Jurisdiccion_Activo;	
			target.TipoOrganismo_Nombre= source.TipoOrganismo_Nombre;	
			target.TipoOrganismo_Activo= source.TipoOrganismo_Activo;	
			target.Sector_Codigo= source.Sector_Codigo;	
			target.Sector_Nombre= source.Sector_Nombre;	
			target.Sector_Activo= source.Sector_Activo;	
			target.SubJurisdiccion_Codigo= source.SubJurisdiccion_Codigo;	
			target.SubJurisdiccion_Nombre= source.SubJurisdiccion_Nombre;	
			target.SubJurisdiccion_Activo= source.SubJurisdiccion_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Saf source,Saf target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSaf.Equals(target.IdSaf))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null:  !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) &&  !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdTipoOrganismo.Equals(target.IdTipoOrganismo))return false;
		  if((source.IdSector == null)?(target.IdSector.HasValue && target.IdSector.Value > 0):!source.IdSector.Equals(target.IdSector))return false;
						  if((source.IdAdministracionTipo == null)?(target.IdAdministracionTipo.HasValue && target.IdAdministracionTipo.Value > 0):!source.IdAdministracionTipo.Equals(target.IdAdministracionTipo))return false;
						  if((source.IdEntidadTipo == null)?(target.IdEntidadTipo.HasValue && target.IdEntidadTipo.Value > 0):!source.IdEntidadTipo.Equals(target.IdEntidadTipo))return false;
						  if((source.IdJurisdiccion == null)?(target.IdJurisdiccion.HasValue && target.IdJurisdiccion.Value > 0):!source.IdJurisdiccion.Equals(target.IdJurisdiccion))return false;
						  if((source.IdSubJurisdiccion == null)?(target.IdSubJurisdiccion.HasValue && target.IdSubJurisdiccion.Value > 0):!source.IdSubJurisdiccion.Equals(target.IdSubJurisdiccion))return false;
						  if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(SafResult source,SafResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSaf.Equals(target.IdSaf))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null: !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) && !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdTipoOrganismo.Equals(target.IdTipoOrganismo))return false;
		  if((source.IdSector == null)?(target.IdSector.HasValue && target.IdSector.Value > 0):!source.IdSector.Equals(target.IdSector))return false;
						  if((source.IdAdministracionTipo == null)?(target.IdAdministracionTipo.HasValue && target.IdAdministracionTipo.Value > 0):!source.IdAdministracionTipo.Equals(target.IdAdministracionTipo))return false;
						  if((source.IdEntidadTipo == null)?(target.IdEntidadTipo.HasValue && target.IdEntidadTipo.Value > 0):!source.IdEntidadTipo.Equals(target.IdEntidadTipo))return false;
						  if((source.IdJurisdiccion == null)?(target.IdJurisdiccion.HasValue && target.IdJurisdiccion.Value > 0):!source.IdJurisdiccion.Equals(target.IdJurisdiccion))return false;
						  if((source.IdSubJurisdiccion == null)?(target.IdSubJurisdiccion.HasValue && target.IdSubJurisdiccion.Value > 0):!source.IdSubJurisdiccion.Equals(target.IdSubJurisdiccion))return false;
						  if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.AdministracionTipo_Codigo == null)?target.AdministracionTipo_Codigo!=null: !( (target.AdministracionTipo_Codigo== String.Empty && source.AdministracionTipo_Codigo== null) || (target.AdministracionTipo_Codigo==null && source.AdministracionTipo_Codigo== String.Empty )) &&   !source.AdministracionTipo_Codigo.Trim().Replace ("\r","").Equals(target.AdministracionTipo_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.AdministracionTipo_Nombre == null)?target.AdministracionTipo_Nombre!=null: !( (target.AdministracionTipo_Nombre== String.Empty && source.AdministracionTipo_Nombre== null) || (target.AdministracionTipo_Nombre==null && source.AdministracionTipo_Nombre== String.Empty )) &&   !source.AdministracionTipo_Nombre.Trim().Replace ("\r","").Equals(target.AdministracionTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.AdministracionTipo_Activo.Equals(target.AdministracionTipo_Activo))return false;
					  if((source.EntidadTipo_Codigo == null)?target.EntidadTipo_Codigo!=null: !( (target.EntidadTipo_Codigo== String.Empty && source.EntidadTipo_Codigo== null) || (target.EntidadTipo_Codigo==null && source.EntidadTipo_Codigo== String.Empty )) &&   !source.EntidadTipo_Codigo.Trim().Replace ("\r","").Equals(target.EntidadTipo_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.EntidadTipo_Nombre == null)?target.EntidadTipo_Nombre!=null: !( (target.EntidadTipo_Nombre== String.Empty && source.EntidadTipo_Nombre== null) || (target.EntidadTipo_Nombre==null && source.EntidadTipo_Nombre== String.Empty )) &&   !source.EntidadTipo_Nombre.Trim().Replace ("\r","").Equals(target.EntidadTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.EntidadTipo_Activo.Equals(target.EntidadTipo_Activo))return false;
					  if((source.Jurisdiccion_Codigo == null)?target.Jurisdiccion_Codigo!=null: !( (target.Jurisdiccion_Codigo== String.Empty && source.Jurisdiccion_Codigo== null) || (target.Jurisdiccion_Codigo==null && source.Jurisdiccion_Codigo== String.Empty )) &&   !source.Jurisdiccion_Codigo.Trim().Replace ("\r","").Equals(target.Jurisdiccion_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Jurisdiccion_Nombre == null)?target.Jurisdiccion_Nombre!=null: !( (target.Jurisdiccion_Nombre== String.Empty && source.Jurisdiccion_Nombre== null) || (target.Jurisdiccion_Nombre==null && source.Jurisdiccion_Nombre== String.Empty )) &&   !source.Jurisdiccion_Nombre.Trim().Replace ("\r","").Equals(target.Jurisdiccion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Jurisdiccion_Activo.Equals(target.Jurisdiccion_Activo))return false;
					  if((source.TipoOrganismo_Nombre == null)?target.TipoOrganismo_Nombre!=null: !( (target.TipoOrganismo_Nombre== String.Empty && source.TipoOrganismo_Nombre== null) || (target.TipoOrganismo_Nombre==null && source.TipoOrganismo_Nombre== String.Empty )) &&   !source.TipoOrganismo_Nombre.Trim().Replace ("\r","").Equals(target.TipoOrganismo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.TipoOrganismo_Activo.Equals(target.TipoOrganismo_Activo))return false;
					  if((source.Sector_Codigo == null)?target.Sector_Codigo!=null: !( (target.Sector_Codigo== String.Empty && source.Sector_Codigo== null) || (target.Sector_Codigo==null && source.Sector_Codigo== String.Empty )) &&   !source.Sector_Codigo.Trim().Replace ("\r","").Equals(target.Sector_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Sector_Nombre == null)?target.Sector_Nombre!=null: !( (target.Sector_Nombre== String.Empty && source.Sector_Nombre== null) || (target.Sector_Nombre==null && source.Sector_Nombre== String.Empty )) &&   !source.Sector_Nombre.Trim().Replace ("\r","").Equals(target.Sector_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Sector_Activo.Equals(target.Sector_Activo))return false;
					  if((source.SubJurisdiccion_Codigo == null)?target.SubJurisdiccion_Codigo!=null: !( (target.SubJurisdiccion_Codigo== String.Empty && source.SubJurisdiccion_Codigo== null) || (target.SubJurisdiccion_Codigo==null && source.SubJurisdiccion_Codigo== String.Empty )) &&   !source.SubJurisdiccion_Codigo.Trim().Replace ("\r","").Equals(target.SubJurisdiccion_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SubJurisdiccion_Nombre == null)?target.SubJurisdiccion_Nombre!=null: !( (target.SubJurisdiccion_Nombre== String.Empty && source.SubJurisdiccion_Nombre== null) || (target.SubJurisdiccion_Nombre==null && source.SubJurisdiccion_Nombre== String.Empty )) &&   !source.SubJurisdiccion_Nombre.Trim().Replace ("\r","").Equals(target.SubJurisdiccion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.SubJurisdiccion_Activo.Equals(target.SubJurisdiccion_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
