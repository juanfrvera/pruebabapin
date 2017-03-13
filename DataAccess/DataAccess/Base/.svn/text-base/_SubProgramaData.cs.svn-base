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
    public abstract class _SubProgramaData : EntityData<SubPrograma,SubProgramaFilter,SubProgramaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SubPrograma entity)
		{			
			return entity.IdSubPrograma;
		}		
		public override SubPrograma GetByEntity(SubPrograma entity)
        {
            return this.GetById(entity.IdSubPrograma);
        }
        public override SubPrograma GetById(int id)
        {
            return (from o in this.Table where o.IdSubPrograma == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SubPrograma> Query(SubProgramaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || o.IdSubPrograma==filter.IdSubPrograma)
					  && (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma==filter.IdPrograma)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaBaja == null || filter.FechaBaja == DateTime.MinValue || o.FechaBaja >=  filter.FechaBaja) && (filter.FechaBaja_To == null || filter.FechaBaja_To == DateTime.MinValue || o.FechaBaja <= filter.FechaBaja_To)
					  && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == true || o.FechaBaja != null ) && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == false || o.FechaBaja == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SubProgramaResult> QueryResult(SubProgramaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Programas on o.IdPrograma equals t1.IdPrograma   
				   select new SubProgramaResult(){
					 IdSubPrograma=o.IdSubPrograma
					 ,IdPrograma=o.IdPrograma
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,FechaAlta=o.FechaAlta
					 ,FechaBaja=o.FechaBaja
					 ,Activo=o.Activo
					,Programa_IdSAF= t1.IdSAF	
						,Programa_Codigo= t1.Codigo	
						,Programa_Nombre= t1.Nombre	
						,Programa_FechaAlta= t1.FechaAlta	
						,Programa_FechaBaja= t1.FechaBaja	
						,Programa_Activo= t1.Activo	
						,Programa_IdSectorialista= t1.IdSectorialista	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SubPrograma Copy(nc.SubPrograma entity)
        {           
            nc.SubPrograma _new = new nc.SubPrograma();
		 _new.IdPrograma= entity.IdPrograma;
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaBaja= entity.FechaBaja;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(SubPrograma entity,string renameFormat)
        {
            SubPrograma  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SubPrograma entity, int id)
        {            
            entity.IdSubPrograma = id;            
        }
		public override void Set(SubPrograma source,SubPrograma target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubPrograma= source.IdSubPrograma ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(SubProgramaResult source,SubPrograma target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubPrograma= source.IdSubPrograma ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(SubPrograma source,SubProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubPrograma= source.IdSubPrograma ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(SubProgramaResult source,SubProgramaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubPrograma= source.IdSubPrograma ;
		 target.IdPrograma= source.IdPrograma ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
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
		public override bool Equals(SubPrograma source,SubPrograma target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(SubProgramaResult source,SubProgramaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.IdPrograma.Equals(target.IdPrograma))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
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
