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
    public abstract class _SistemaReporteHistoricoData : EntityData<SistemaReporteHistorico,SistemaReporteHistoricoFilter,SistemaReporteHistoricoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaReporteHistorico entity)
		{			
			return entity.IdSistemaReporteHistorico;
		}		
		public override SistemaReporteHistorico GetByEntity(SistemaReporteHistorico entity)
        {
            return this.GetById(entity.IdSistemaReporteHistorico);
        }
        public override SistemaReporteHistorico GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaReporteHistorico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaReporteHistorico> Query(SistemaReporteHistoricoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaReporteHistorico == null || o.IdSistemaReporteHistorico >=  filter.IdSistemaReporteHistorico) && (filter.IdSistemaReporteHistorico_To == null || o.IdSistemaReporteHistorico <= filter.IdSistemaReporteHistorico_To)
					  && (filter.IdSistemaReporte == null || filter.IdSistemaReporte == 0 || o.IdSistemaReporte==filter.IdSistemaReporte)
					  && (filter.EntityId == null || filter.EntityId.Trim() == string.Empty || filter.EntityId.Trim() == "%"  || (filter.EntityId.EndsWith("%") && filter.EntityId.StartsWith("%") && (o.EntityId.Contains(filter.EntityId.Replace("%", "")))) || (filter.EntityId.EndsWith("%") && o.EntityId.StartsWith(filter.EntityId.Replace("%",""))) || (filter.EntityId.StartsWith("%") && o.EntityId.EndsWith(filter.EntityId.Replace("%",""))) || o.EntityId == filter.EntityId )
					  && (filter.FilterData == null || filter.FilterData.Trim() == string.Empty || filter.FilterData.Trim() == "%"  || (filter.FilterData.EndsWith("%") && filter.FilterData.StartsWith("%") && (o.FilterData.Contains(filter.FilterData.Replace("%", "")))) || (filter.FilterData.EndsWith("%") && o.FilterData.StartsWith(filter.FilterData.Replace("%",""))) || (filter.FilterData.StartsWith("%") && o.FilterData.EndsWith(filter.FilterData.Replace("%",""))) || o.FilterData == filter.FilterData )
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  && (filter.Comentarios == null || filter.Comentarios.Trim() == string.Empty || filter.Comentarios.Trim() == "%"  || (filter.Comentarios.EndsWith("%") && filter.Comentarios.StartsWith("%") && (o.Comentarios.Contains(filter.Comentarios.Replace("%", "")))) || (filter.Comentarios.EndsWith("%") && o.Comentarios.StartsWith(filter.Comentarios.Replace("%",""))) || (filter.Comentarios.StartsWith("%") && o.Comentarios.EndsWith(filter.Comentarios.Replace("%",""))) || o.Comentarios == filter.Comentarios )
					  && (filter.Data == null || filter.Data.Trim() == string.Empty || filter.Data.Trim() == "%"  || (filter.Data.EndsWith("%") && filter.Data.StartsWith("%") && (o.Data.Contains(filter.Data.Replace("%", "")))) || (filter.Data.EndsWith("%") && o.Data.StartsWith(filter.Data.Replace("%",""))) || (filter.Data.StartsWith("%") && o.Data.EndsWith(filter.Data.Replace("%",""))) || o.Data == filter.Data )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaReporteHistoricoResult> QueryResult(SistemaReporteHistoricoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.SistemaReportes on o.IdSistemaReporte equals t1.IdSistemaReporte   
				    join t2  in this.Context.Usuarios on o.IdUsuario equals t2.IdUsuario   
				   select new SistemaReporteHistoricoResult(){
					 IdSistemaReporteHistorico=o.IdSistemaReporteHistorico
					 ,IdSistemaReporte=o.IdSistemaReporte
					 ,EntityId=o.EntityId
					 ,FilterData=o.FilterData
					 ,Fecha=o.Fecha
					 ,IdUsuario=o.IdUsuario
					 ,Comentarios=o.Comentarios
					 ,Data=o.Data
					,SistemaReporte_Nombre= t1.Nombre	
						,SistemaReporte_Codigo= t1.Codigo	
						,SistemaReporte_Descripcion= t1.Descripcion	
						,SistemaReporte_IdSistemaEntidad= t1.IdSistemaEntidad	
						,SistemaReporte_Activo= t1.Activo	
						,SistemaReporte_EsListado= t1.EsListado	
						,SistemaReporte_FileName= t1.FileName	
						,Usuario_NombreUsuario= t2.NombreUsuario	
						,Usuario_Clave= t2.Clave	
						,Usuario_Activo= t2.Activo	
						,Usuario_EsSectioralista= t2.EsSectioralista	
						,Usuario_IdLanguage= t2.IdLanguage	
						,Usuario_AccesoTotal= t2.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaReporteHistorico Copy(nc.SistemaReporteHistorico entity)
        {           
            nc.SistemaReporteHistorico _new = new nc.SistemaReporteHistorico();
		 _new.IdSistemaReporte= entity.IdSistemaReporte;
		 _new.EntityId= entity.EntityId;
		 _new.FilterData= entity.FilterData;
		 _new.Fecha= entity.Fecha;
		 _new.IdUsuario= entity.IdUsuario;
		 _new.Comentarios= entity.Comentarios;
		 _new.Data= entity.Data;
		return _new;			
        }
		public override int CopyAndSave(SistemaReporteHistorico entity,string renameFormat)
        {
            SistemaReporteHistorico  newEntity = Copy(entity);
            newEntity.EntityId = string.Format(renameFormat,newEntity.EntityId);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaReporteHistorico entity, int id)
        {            
            entity.IdSistemaReporteHistorico = id;            
        }
		public override void Set(SistemaReporteHistorico source,SistemaReporteHistorico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporteHistorico= source.IdSistemaReporteHistorico ;
		 target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.EntityId= source.EntityId ;
		 target.FilterData= source.FilterData ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Comentarios= source.Comentarios ;
		 target.Data= source.Data ;
		 		  
		}
		public override void Set(SistemaReporteHistoricoResult source,SistemaReporteHistorico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporteHistorico= source.IdSistemaReporteHistorico ;
		 target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.EntityId= source.EntityId ;
		 target.FilterData= source.FilterData ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Comentarios= source.Comentarios ;
		 target.Data= source.Data ;
		 
		}
		public override void Set(SistemaReporteHistorico source,SistemaReporteHistoricoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporteHistorico= source.IdSistemaReporteHistorico ;
		 target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.EntityId= source.EntityId ;
		 target.FilterData= source.FilterData ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Comentarios= source.Comentarios ;
		 target.Data= source.Data ;
		 	
		}		
		public override void Set(SistemaReporteHistoricoResult source,SistemaReporteHistoricoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporteHistorico= source.IdSistemaReporteHistorico ;
		 target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.EntityId= source.EntityId ;
		 target.FilterData= source.FilterData ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Comentarios= source.Comentarios ;
		 target.Data= source.Data ;
		 target.SistemaReporte_Nombre= source.SistemaReporte_Nombre;	
			target.SistemaReporte_Codigo= source.SistemaReporte_Codigo;	
			target.SistemaReporte_Descripcion= source.SistemaReporte_Descripcion;	
			target.SistemaReporte_IdSistemaEntidad= source.SistemaReporte_IdSistemaEntidad;	
			target.SistemaReporte_Activo= source.SistemaReporte_Activo;	
			target.SistemaReporte_EsListado= source.SistemaReporte_EsListado;	
			target.SistemaReporte_FileName= source.SistemaReporte_FileName;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(SistemaReporteHistorico source,SistemaReporteHistorico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaReporteHistorico.Equals(target.IdSistemaReporteHistorico))return false;
		  if(!source.IdSistemaReporte.Equals(target.IdSistemaReporte))return false;
		  if((source.EntityId == null)?target.EntityId!=null:  !( (target.EntityId== String.Empty && source.EntityId== null) || (target.EntityId==null && source.EntityId== String.Empty )) &&  !source.EntityId.Trim().Replace ("\r","").Equals(target.EntityId.Trim().Replace ("\r","")))return false;
			 if((source.FilterData == null)?target.FilterData!=null:  !( (target.FilterData== String.Empty && source.FilterData== null) || (target.FilterData==null && source.FilterData== String.Empty )) &&  !source.FilterData.Trim().Replace ("\r","").Equals(target.FilterData.Trim().Replace ("\r","")))return false;
			 if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Comentarios == null)?target.Comentarios!=null:  !( (target.Comentarios== String.Empty && source.Comentarios== null) || (target.Comentarios==null && source.Comentarios== String.Empty )) &&  !source.Comentarios.Trim().Replace ("\r","").Equals(target.Comentarios.Trim().Replace ("\r","")))return false;
			 if((source.Data == null)?target.Data!=null:  !( (target.Data== String.Empty && source.Data== null) || (target.Data==null && source.Data== String.Empty )) &&  !source.Data.Trim().Replace ("\r","").Equals(target.Data.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(SistemaReporteHistoricoResult source,SistemaReporteHistoricoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaReporteHistorico.Equals(target.IdSistemaReporteHistorico))return false;
		  if(!source.IdSistemaReporte.Equals(target.IdSistemaReporte))return false;
		  if((source.EntityId == null)?target.EntityId!=null: !( (target.EntityId== String.Empty && source.EntityId== null) || (target.EntityId==null && source.EntityId== String.Empty )) && !source.EntityId.Trim().Replace ("\r","").Equals(target.EntityId.Trim().Replace ("\r","")))return false;
			 if((source.FilterData == null)?target.FilterData!=null: !( (target.FilterData== String.Empty && source.FilterData== null) || (target.FilterData==null && source.FilterData== String.Empty )) && !source.FilterData.Trim().Replace ("\r","").Equals(target.FilterData.Trim().Replace ("\r","")))return false;
			 if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Comentarios == null)?target.Comentarios!=null: !( (target.Comentarios== String.Empty && source.Comentarios== null) || (target.Comentarios==null && source.Comentarios== String.Empty )) && !source.Comentarios.Trim().Replace ("\r","").Equals(target.Comentarios.Trim().Replace ("\r","")))return false;
			 if((source.Data == null)?target.Data!=null: !( (target.Data== String.Empty && source.Data== null) || (target.Data==null && source.Data== String.Empty )) && !source.Data.Trim().Replace ("\r","").Equals(target.Data.Trim().Replace ("\r","")))return false;
			 if((source.SistemaReporte_Nombre == null)?target.SistemaReporte_Nombre!=null: !( (target.SistemaReporte_Nombre== String.Empty && source.SistemaReporte_Nombre== null) || (target.SistemaReporte_Nombre==null && source.SistemaReporte_Nombre== String.Empty )) &&   !source.SistemaReporte_Nombre.Trim().Replace ("\r","").Equals(target.SistemaReporte_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.SistemaReporte_Codigo == null)?target.SistemaReporte_Codigo!=null: !( (target.SistemaReporte_Codigo== String.Empty && source.SistemaReporte_Codigo== null) || (target.SistemaReporte_Codigo==null && source.SistemaReporte_Codigo== String.Empty )) &&   !source.SistemaReporte_Codigo.Trim().Replace ("\r","").Equals(target.SistemaReporte_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaReporte_Descripcion == null)?target.SistemaReporte_Descripcion!=null: !( (target.SistemaReporte_Descripcion== String.Empty && source.SistemaReporte_Descripcion== null) || (target.SistemaReporte_Descripcion==null && source.SistemaReporte_Descripcion== String.Empty )) &&   !source.SistemaReporte_Descripcion.Trim().Replace ("\r","").Equals(target.SistemaReporte_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaReporte_IdSistemaEntidad.Equals(target.SistemaReporte_IdSistemaEntidad))return false;
					  if(!source.SistemaReporte_Activo.Equals(target.SistemaReporte_Activo))return false;
					  if(!source.SistemaReporte_EsListado.Equals(target.SistemaReporte_EsListado))return false;
					  if((source.SistemaReporte_FileName == null)?target.SistemaReporte_FileName!=null: !( (target.SistemaReporte_FileName== String.Empty && source.SistemaReporte_FileName== null) || (target.SistemaReporte_FileName==null && source.SistemaReporte_FileName== String.Empty )) &&   !source.SistemaReporte_FileName.Trim().Replace ("\r","").Equals(target.SistemaReporte_FileName.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
					  if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
					  if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
