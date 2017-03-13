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
    public abstract class _ProgramaObjetivoData : EntityData<ProgramaObjetivo,ProgramaObjetivoFilter,ProgramaObjetivoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProgramaObjetivo entity)
		{			
			return entity.IdProgramaObjetivo;
		}		
		public override ProgramaObjetivo GetByEntity(ProgramaObjetivo entity)
        {
            return this.GetById(entity.IdProgramaObjetivo);
        }
        public override ProgramaObjetivo GetById(int id)
        {
            return (from o in this.Table where o.IdProgramaObjetivo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProgramaObjetivo> Query(ProgramaObjetivoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProgramaObjetivo == null || filter.IdProgramaObjetivo == 0 || o.IdProgramaObjetivo==filter.IdProgramaObjetivo)
					  && (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma==filter.IdPrograma)
					  && (filter.IDObjetivo == null || filter.IDObjetivo == 0 || o.IDObjetivo==filter.IDObjetivo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProgramaObjetivoResult> QueryResult(ProgramaObjetivoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Objetivos on o.IDObjetivo equals t1.IdObjetivo   
				    join t2  in this.Context.Programas on o.IdPrograma equals t2.IdPrograma   
				   select new ProgramaObjetivoResult(){
					 IdProgramaObjetivo=o.IdProgramaObjetivo
					 ,IdPrograma=o.IdPrograma
					 ,IDObjetivo=o.IDObjetivo
					,Objetivo_Nombre= t1.Nombre	
                        //,Programa_IdSAF= t2.IdSAF	
                        //,Programa_Codigo= t2.Codigo	
                        //,Programa_Nombre= t2.Nombre	
                        //,Programa_FechaAlta= t2.FechaAlta	
                        //,Programa_FechaBaja= t2.FechaBaja	
                        //,Programa_Activo= t2.Activo	
                        //,Programa_IdSectorialista= t2.IdSectorialista	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProgramaObjetivo Copy(nc.ProgramaObjetivo entity)
        {           
            nc.ProgramaObjetivo _new = new nc.ProgramaObjetivo();
		 _new.IdPrograma= entity.IdPrograma;
		 _new.IDObjetivo= entity.IDObjetivo;
		return _new;			
        }
		public override int CopyAndSave(ProgramaObjetivo entity,string renameFormat)
        {
            ProgramaObjetivo  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProgramaObjetivo entity, int id)
        {            
            entity.IdProgramaObjetivo = id;            
        }
		public override void Set(ProgramaObjetivo source,ProgramaObjetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.IDObjetivo= source.IDObjetivo ;
		 		  
		}
		public override void Set(ProgramaObjetivoResult source,ProgramaObjetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.IDObjetivo= source.IDObjetivo ;
		 
		}
		public override void Set(ProgramaObjetivo source,ProgramaObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.IDObjetivo= source.IDObjetivo ;
		 	
		}		
		public override void Set(ProgramaObjetivoResult source,ProgramaObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 target.IdPrograma= source.IdPrograma ;
		 target.IDObjetivo= source.IDObjetivo ;
		 target.Objetivo_Nombre= source.Objetivo_Nombre;	
            //target.Programa_IdSAF= source.Programa_IdSAF;	
            //target.Programa_Codigo= source.Programa_Codigo;	
            //target.Programa_Nombre= source.Programa_Nombre;	
            //target.Programa_FechaAlta= source.Programa_FechaAlta;	
            //target.Programa_FechaBaja= source.Programa_FechaBaja;	
            //target.Programa_Activo= source.Programa_Activo;	
            //target.Programa_IdSectorialista= source.Programa_IdSectorialista;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProgramaObjetivo source,ProgramaObjetivo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProgramaObjetivo.Equals(target.IdProgramaObjetivo))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.IDObjetivo.Equals(target.IDObjetivo))return false;
		 
		  return true;
        }
		public override bool Equals(ProgramaObjetivoResult source,ProgramaObjetivoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProgramaObjetivo.Equals(target.IdProgramaObjetivo))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if(!source.IDObjetivo.Equals(target.IDObjetivo))return false;
		  if((source.Objetivo_Nombre == null)?target.Objetivo_Nombre!=null: !( (target.Objetivo_Nombre== String.Empty && source.Objetivo_Nombre== null) || (target.Objetivo_Nombre==null && source.Objetivo_Nombre== String.Empty )) &&   !source.Objetivo_Nombre.Trim().Replace ("\r","").Equals(target.Objetivo_Nombre.Trim().Replace ("\r","")))return false;
                      //   if(!source.Programa_IdSAF.Equals(target.Programa_IdSAF))return false;
                      //if((source.Programa_Codigo == null)?target.Programa_Codigo!=null: !( (target.Programa_Codigo== String.Empty && source.Programa_Codigo== null) || (target.Programa_Codigo==null && source.Programa_Codigo== String.Empty )) &&   !source.Programa_Codigo.Trim().Replace ("\r","").Equals(target.Programa_Codigo.Trim().Replace ("\r","")))return false;
                      //   if((source.Programa_Nombre == null)?target.Programa_Nombre!=null: !( (target.Programa_Nombre== String.Empty && source.Programa_Nombre== null) || (target.Programa_Nombre==null && source.Programa_Nombre== String.Empty )) &&   !source.Programa_Nombre.Trim().Replace ("\r","").Equals(target.Programa_Nombre.Trim().Replace ("\r","")))return false;
                      //   if(!source.Programa_FechaAlta.Equals(target.Programa_FechaAlta))return false;
                      //if((source.Programa_FechaBaja == null)?(target.Programa_FechaBaja.HasValue ):!source.Programa_FechaBaja.Equals(target.Programa_FechaBaja))return false;
                      //   if(!source.Programa_Activo.Equals(target.Programa_Activo))return false;
                      //if((source.Programa_IdSectorialista == null)?(target.Programa_IdSectorialista.HasValue && target.Programa_IdSectorialista.Value > 0):!source.Programa_IdSectorialista.Equals(target.Programa_IdSectorialista))return false;
									 		
		  return true;
        }
		#endregion
    }
}
