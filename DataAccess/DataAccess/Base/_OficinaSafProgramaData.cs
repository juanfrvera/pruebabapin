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
    public abstract class _OficinaSafProgramaData : EntityData<OficinaSafPrograma,OficinaSafProgramaFilter,OficinaSafProgramaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.OficinaSafPrograma entity)
		{			
			return entity.IdOficinaSafPrograma;
		}		
		public override OficinaSafPrograma GetByEntity(OficinaSafPrograma entity)
        {
            return this.GetById(entity.IdOficinaSafPrograma);
        }
        public override OficinaSafPrograma GetById(int id)
        {
            return (from o in this.Table where o.IdOficinaSafPrograma == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<OficinaSafPrograma> Query(OficinaSafProgramaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOficinaSafPrograma == null || o.IdOficinaSafPrograma >=  filter.IdOficinaSafPrograma) && (filter.IdOficinaSafPrograma_To == null || o.IdOficinaSafPrograma <= filter.IdOficinaSafPrograma_To)
					  && (filter.IdOficinaSaf == null || filter.IdOficinaSaf == 0 || o.IdOficinaSaf==filter.IdOficinaSaf)
					  && (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma==filter.IdPrograma)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OficinaSafProgramaResult> QueryResult(OficinaSafProgramaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.OficinaSafs on o.IdOficinaSaf equals t1.IdOficinaSaf   
				    join t2  in this.Context.Programas on o.IdPrograma equals t2.IdPrograma   
				   select new OficinaSafProgramaResult(){
					 IdOficinaSafPrograma=o.IdOficinaSafPrograma
					 ,IdOficinaSaf=o.IdOficinaSaf
					 ,IdPrograma=o.IdPrograma
					,OficinaSaf_IdOficina= t1.IdOficina	
						,OficinaSaf_IdSaf= t1.IdSaf	
						,Programa_IdSAF= t2.IdSAF	
						,Programa_Codigo= t2.Codigo	
						,Programa_Nombre= t2.Nombre	
						,Programa_FechaAlta= t2.FechaAlta	
						,Programa_FechaBaja= t2.FechaBaja	
						,Programa_Activo= t2.Activo	
						,Programa_IdSectorialista= t2.IdSectorialista	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.OficinaSafPrograma Copy(nc.OficinaSafPrograma entity)
        {           
            nc.OficinaSafPrograma _new = new nc.OficinaSafPrograma();
		 _new.IdOficinaSaf= entity.IdOficinaSaf;
		 _new.IdPrograma= entity.IdPrograma;
		return _new;			
        }
		public override int CopyAndSave(OficinaSafPrograma entity,string renameFormat)
        {
            OficinaSafPrograma  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(OficinaSafPrograma entity, int id)
        {            
            entity.IdOficinaSafPrograma = id;            
        }
		public override void Set(OficinaSafPrograma source,OficinaSafPrograma target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSafPrograma= source.IdOficinaSafPrograma ;
		 target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdPrograma= source.IdPrograma ;
		 		  
		}
		public override void Set(OficinaSafProgramaResult source,OficinaSafPrograma target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSafPrograma= source.IdOficinaSafPrograma ;
		 target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdPrograma= source.IdPrograma ;
		 
		}
		public override void Set(OficinaSafPrograma source,OficinaSafProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSafPrograma= source.IdOficinaSafPrograma ;
		 target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdPrograma= source.IdPrograma ;
		 	
		}		
		public override void Set(OficinaSafProgramaResult source,OficinaSafProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSafPrograma= source.IdOficinaSafPrograma ;
		 target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdPrograma= source.IdPrograma ;
		 target.OficinaSaf_IdOficina= source.OficinaSaf_IdOficina;	
			target.OficinaSaf_IdSaf= source.OficinaSaf_IdSaf;	
			target.Programa_IdSAF= source.Programa_IdSAF;	
			target.Programa_Codigo= source.Programa_Codigo;	
			target.Programa_Nombre= source.Programa_Nombre;	
			target.Programa_FechaAlta= source.Programa_FechaAlta;	
			target.Programa_FechaBaja= source.Programa_FechaBaja;	
			target.Programa_Activo= source.Programa_Activo;	
			target.Programa_IdSectorialista= source.Programa_IdSectorialista;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(OficinaSafPrograma source,OficinaSafPrograma target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficinaSafPrograma.Equals(target.IdOficinaSafPrograma))return false;
		  if(!source.IdOficinaSaf.Equals(target.IdOficinaSaf))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		 
		  return true;
        }
		public override bool Equals(OficinaSafProgramaResult source,OficinaSafProgramaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficinaSafPrograma.Equals(target.IdOficinaSafPrograma))return false;
		  if(!source.IdOficinaSaf.Equals(target.IdOficinaSaf))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.OficinaSaf_IdOficina.Equals(target.OficinaSaf_IdOficina))return false;
					  if(!source.OficinaSaf_IdSaf.Equals(target.OficinaSaf_IdSaf))return false;
					  if(!source.Programa_IdSAF.Equals(target.Programa_IdSAF))return false;
					  if((source.Programa_Codigo == null)?target.Programa_Codigo!=null: !( (target.Programa_Codigo== String.Empty && source.Programa_Codigo== null) || (target.Programa_Codigo==null && source.Programa_Codigo== String.Empty )) &&   !source.Programa_Codigo.Trim().Replace ("\r","").Equals(target.Programa_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Programa_Nombre == null)?target.Programa_Nombre!=null: !( (target.Programa_Nombre== String.Empty && source.Programa_Nombre== null) || (target.Programa_Nombre==null && source.Programa_Nombre== String.Empty )) &&   !source.Programa_Nombre.Trim().Replace ("\r","").Equals(target.Programa_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Programa_FechaAlta.Equals(target.Programa_FechaAlta))return false;
					  if((source.Programa_FechaBaja == null)?(target.Programa_FechaBaja.HasValue ):!source.Programa_FechaBaja.Equals(target.Programa_FechaBaja))return false;
						 if(!source.Programa_Activo.Equals(target.Programa_Activo))return false;
					  if((source.Programa_IdSectorialista == null)?(target.Programa_IdSectorialista.HasValue && target.Programa_IdSectorialista.Value > 0):!source.Programa_IdSectorialista.Equals(target.Programa_IdSectorialista))return false;
									 		
		  return true;
        }
		#endregion
    }
}
