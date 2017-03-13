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
    public abstract class _ProgramaData : EntityData<Programa,ProgramaFilter,ProgramaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Programa entity)
		{			
			return entity.IdPrograma;
		}		
		public override Programa GetByEntity(Programa entity)
        {
            return this.GetById(entity.IdPrograma);
        }
        public override Programa GetById(int id)
        {
            return (from o in this.Table where o.IdPrograma == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Programa> Query(ProgramaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma==filter.IdPrograma)
					  && (filter.IdSAF == null || filter.IdSAF == 0 || o.IdSAF==filter.IdSAF)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaBaja == null || filter.FechaBaja == DateTime.MinValue || o.FechaBaja >=  filter.FechaBaja) && (filter.FechaBaja_To == null || filter.FechaBaja_To == DateTime.MinValue || o.FechaBaja <= filter.FechaBaja_To)
					  && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == true || o.FechaBaja != null ) && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == false || o.FechaBaja == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdSectorialista == null || filter.IdSectorialista == 0 || o.IdSectorialista==filter.IdSectorialista)
					  && (filter.IdSectorialistaIsNull == null || filter.IdSectorialistaIsNull == true || o.IdSectorialista != null ) && (filter.IdSectorialistaIsNull == null || filter.IdSectorialistaIsNull == false || o.IdSectorialista == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProgramaResult> QueryResult(ProgramaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Safs on o.IdSAF equals t1.IdSaf   
				   join _t2  in this.Context.Usuarios on o.IdSectorialista equals _t2.IdUsuario into tt2 from t2 in tt2.DefaultIfEmpty()
				   select new ProgramaResult(){
					 IdPrograma=o.IdPrograma
					 ,IdSAF=o.IdSAF
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,FechaAlta=o.FechaAlta
					 ,FechaBaja=o.FechaBaja
					 ,Activo=o.Activo
					 ,IdSectorialista=o.IdSectorialista
					,SAF_Codigo= t1.Codigo	
						,SAF_Denominacion= t1.Denominacion	
						,SAF_IdTipoOrganismo= t1.IdTipoOrganismo	
						,SAF_IdSector= t1.IdSector	
						,SAF_IdAdministracionTipo= t1.IdAdministracionTipo	
						,SAF_IdEntidadTipo= t1.IdEntidadTipo	
						,SAF_IdJurisdiccion= t1.IdJurisdiccion	
						,SAF_IdSubJurisdiccion= t1.IdSubJurisdiccion	
						,SAF_FechaAlta= t1.FechaAlta	
						,SAF_FechaBaja= t1.FechaBaja	
						,SAF_Activo= t1.Activo	
						,Sectorialista_NombreUsuario= t2!=null?(string)t2.NombreUsuario:null	
						,Sectorialista_Clave= t2!=null?(string)t2.Clave:null	
						,Sectorialista_Activo= t2!=null?(bool?)t2.Activo:null	
						,Sectorialista_EsSectioralista= t2!=null?(bool?)t2.EsSectioralista:null	
						,Sectorialista_IdLanguage= t2!=null?(int?)t2.IdLanguage:null	
						,Sectorialista_AccesoTotal= t2!=null?(bool?)t2.AccesoTotal:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Programa Copy(nc.Programa entity)
        {           
            nc.Programa _new = new nc.Programa();
		 _new.IdSAF= entity.IdSAF;
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaBaja= entity.FechaBaja;
		 _new.Activo= entity.Activo;
		 _new.IdSectorialista= entity.IdSectorialista;
		return _new;			
        }
		public override int CopyAndSave(Programa entity,string renameFormat)
        {
            Programa  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Programa entity, int id)
        {            
            entity.IdPrograma = id;            
        }
		public override void Set(Programa source,Programa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrograma= source.IdPrograma ;
		 target.IdSAF= source.IdSAF ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.IdSectorialista= source.IdSectorialista ;
		 		  
		}
		public override void Set(ProgramaResult source,Programa target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrograma= source.IdPrograma ;
		 target.IdSAF= source.IdSAF ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.IdSectorialista= source.IdSectorialista ;
		 
		}
		public override void Set(Programa source,ProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrograma= source.IdPrograma ;
		 target.IdSAF= source.IdSAF ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.IdSectorialista= source.IdSectorialista ;
		 	
		}		
		public override void Set(ProgramaResult source,ProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrograma= source.IdPrograma ;
		 target.IdSAF= source.IdSAF ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.IdSectorialista= source.IdSectorialista ;
		 target.SAF_Codigo= source.SAF_Codigo;	
			target.SAF_Denominacion= source.SAF_Denominacion;	
			target.SAF_IdTipoOrganismo= source.SAF_IdTipoOrganismo;	
			target.SAF_IdSector= source.SAF_IdSector;	
			target.SAF_IdAdministracionTipo= source.SAF_IdAdministracionTipo;	
			target.SAF_IdEntidadTipo= source.SAF_IdEntidadTipo;	
			target.SAF_IdJurisdiccion= source.SAF_IdJurisdiccion;	
			target.SAF_IdSubJurisdiccion= source.SAF_IdSubJurisdiccion;	
			target.SAF_FechaAlta= source.SAF_FechaAlta;	
			target.SAF_FechaBaja= source.SAF_FechaBaja;	
			target.SAF_Activo= source.SAF_Activo;	
			target.Sectorialista_NombreUsuario= source.Sectorialista_NombreUsuario;	
			target.Sectorialista_Clave= source.Sectorialista_Clave;	
			target.Sectorialista_Activo= source.Sectorialista_Activo;	
			target.Sectorialista_EsSectioralista= source.Sectorialista_EsSectioralista;	
			target.Sectorialista_IdLanguage= source.Sectorialista_IdLanguage;	
			target.Sectorialista_AccesoTotal= source.Sectorialista_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Programa source,Programa target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.IdSAF.Equals(target.IdSAF))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdSectorialista == null)?(target.IdSectorialista.HasValue && target.IdSectorialista.Value > 0):!source.IdSectorialista.Equals(target.IdSectorialista))return false;
						 
		  return true;
        }
		public override bool Equals(ProgramaResult source,ProgramaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.IdSAF.Equals(target.IdSAF))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdSectorialista == null)?(target.IdSectorialista.HasValue && target.IdSectorialista.Value > 0):!source.IdSectorialista.Equals(target.IdSectorialista))return false;
						  if((source.SAF_Codigo == null)?target.SAF_Codigo!=null: !( (target.SAF_Codigo== String.Empty && source.SAF_Codigo== null) || (target.SAF_Codigo==null && source.SAF_Codigo== String.Empty )) &&   !source.SAF_Codigo.Trim().Replace ("\r","").Equals(target.SAF_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SAF_Denominacion == null)?target.SAF_Denominacion!=null: !( (target.SAF_Denominacion== String.Empty && source.SAF_Denominacion== null) || (target.SAF_Denominacion==null && source.SAF_Denominacion== String.Empty )) &&   !source.SAF_Denominacion.Trim().Replace ("\r","").Equals(target.SAF_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.SAF_IdTipoOrganismo.Equals(target.SAF_IdTipoOrganismo))return false;
					  if((source.SAF_IdSector == null)?(target.SAF_IdSector.HasValue && target.SAF_IdSector.Value > 0):!source.SAF_IdSector.Equals(target.SAF_IdSector))return false;
									  if((source.SAF_IdAdministracionTipo == null)?(target.SAF_IdAdministracionTipo.HasValue && target.SAF_IdAdministracionTipo.Value > 0):!source.SAF_IdAdministracionTipo.Equals(target.SAF_IdAdministracionTipo))return false;
									  if((source.SAF_IdEntidadTipo == null)?(target.SAF_IdEntidadTipo.HasValue && target.SAF_IdEntidadTipo.Value > 0):!source.SAF_IdEntidadTipo.Equals(target.SAF_IdEntidadTipo))return false;
									  if((source.SAF_IdJurisdiccion == null)?(target.SAF_IdJurisdiccion.HasValue && target.SAF_IdJurisdiccion.Value > 0):!source.SAF_IdJurisdiccion.Equals(target.SAF_IdJurisdiccion))return false;
									  if((source.SAF_IdSubJurisdiccion == null)?(target.SAF_IdSubJurisdiccion.HasValue && target.SAF_IdSubJurisdiccion.Value > 0):!source.SAF_IdSubJurisdiccion.Equals(target.SAF_IdSubJurisdiccion))return false;
									  if(!source.SAF_FechaAlta.Equals(target.SAF_FechaAlta))return false;
					  if((source.SAF_FechaBaja == null)?(target.SAF_FechaBaja.HasValue ):!source.SAF_FechaBaja.Equals(target.SAF_FechaBaja))return false;
						 if(!source.SAF_Activo.Equals(target.SAF_Activo))return false;
					  if((source.Sectorialista_NombreUsuario == null)?target.Sectorialista_NombreUsuario!=null: !( (target.Sectorialista_NombreUsuario== String.Empty && source.Sectorialista_NombreUsuario== null) || (target.Sectorialista_NombreUsuario==null && source.Sectorialista_NombreUsuario== String.Empty )) &&   !source.Sectorialista_NombreUsuario.Trim().Replace ("\r","").Equals(target.Sectorialista_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Sectorialista_Clave == null)?target.Sectorialista_Clave!=null: !( (target.Sectorialista_Clave== String.Empty && source.Sectorialista_Clave== null) || (target.Sectorialista_Clave==null && source.Sectorialista_Clave== String.Empty )) &&   !source.Sectorialista_Clave.Trim().Replace ("\r","").Equals(target.Sectorialista_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Sectorialista_Activo.Equals(target.Sectorialista_Activo))return false;
					  if(!source.Sectorialista_EsSectioralista.Equals(target.Sectorialista_EsSectioralista))return false;
					  if(!source.Sectorialista_IdLanguage.Equals(target.Sectorialista_IdLanguage))return false;
					  if(!source.Sectorialista_AccesoTotal.Equals(target.Sectorialista_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
