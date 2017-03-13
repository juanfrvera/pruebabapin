using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoDictamenFileData : EntityData<PrestamoDictamenFile, PrestamoDictamenFileFilter, PrestamoDictamenFileResult, int>
    { 
	   #region Singleton
	   private static volatile PrestamoDictamenFileData current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenFileData() {}
	   public static PrestamoDictamenFileData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenFileData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoDictamenFile"; } }
       public List<PrestamoDictamenFileResult> GetWithFileInfo(Int32 IdPrestamoDictamen)
       {
           return (from pf in this.Table
                   join f in this.Context.FileInfos
                   on pf.IdFile equals f.IdFile
                   select new PrestamoDictamenFileResult()
                   {
                       IdFile = pf.IdFile,
                       IdPrestamoDictamen = pf.IdPrestamoDictamen,
                       IdPrestamoDictamenFile = pf.IdPrestamoDictamenFile,
                       Fecha = (DateTime)f.Date,
                       Nombre = f.FileName
                   }).ToList();
       }
        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoDictamenFile entity)
		{			
			return entity.IdPrestamoDictamenFile;
		}		
		public override PrestamoDictamenFile GetByEntity(PrestamoDictamenFile entity)
        {
            return this.GetById(entity.IdPrestamoDictamenFile);
        }
        public override PrestamoDictamenFile GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoDictamenFile == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoDictamenFile> Query(PrestamoDictamenFileFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoDictamenFile == null || o.IdPrestamoDictamenFile >=  filter.IdPrestamoDictamenFile) && (filter.IdPrestamoDictamenFile_To == null || o.IdPrestamoDictamenFile <= filter.IdPrestamoDictamenFile_To)
					  && (filter.IdPrestamoDictamen == null || filter.IdPrestamoDictamen == 0 || o.IdPrestamoDictamen==filter.IdPrestamoDictamen)
					  && (filter.IdFile == null || filter.IdFile == 0 || o.IdFile==filter.IdFile)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoDictamenFileResult> QueryResult(PrestamoDictamenFileFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.FileInfos on o.IdFile equals t1.IdFile   
				    join t2  in this.Context.PrestamoDictamens on o.IdPrestamoDictamen equals t2.IdPrestamoDictamen   
				   select new PrestamoDictamenFileResult(){
					 IdPrestamoDictamenFile=o.IdPrestamoDictamenFile
					 ,IdPrestamoDictamen=o.IdPrestamoDictamen
					 ,IdFile=o.IdFile
					,File_Date= t1.Date	
						,File_FileType= t1.FileType	
						,File_FileName= t1.FileName	
						//,File_Data= t1.Data	
						,File_Checked= t1.Checked	
						,PrestamoDictamen_Expediente= t2.Expediente	
						,PrestamoDictamen_IDOrganismo= t2.IDOrganismo	
						,PrestamoDictamen_OrganismoDetalle= t2.OrganismoDetalle	
						,PrestamoDictamen_Denominacion= t2.Denominacion	
						,PrestamoDictamen_IdGestionTipo= t2.IdGestionTipo	
						,PrestamoDictamen_IdOrganismoFinanciero= t2.IdOrganismoFinanciero	
						,PrestamoDictamen_IdAnalista= t2.IdAnalista	
						,PrestamoDictamen_IdPrestamo= t2.IdPrestamo	
						,PrestamoDictamen_IdPrestamoDictamenRelacionado= t2.IdPrestamoDictamenRelacionado	
						,PrestamoDictamen_Comentario= t2.Comentario	
						,PrestamoDictamen_IDPrestamoCalificacion= t2.IDPrestamoCalificacion	
						,PrestamoDictamen_CalificacionFecha= t2.CalificacionFecha	
						,PrestamoDictamen_CalificacionITecnico= t2.CalificacionITecnico	
						,PrestamoDictamen_CalificacionITFecha= t2.CalificacionITFecha	
						,PrestamoDictamen_CalificacionNotaDNIP= t2.CalificacionNotaDNIP	
						,PrestamoDictamen_CalificacionObservacion= t2.CalificacionObservacion	
						,PrestamoDictamen_CalificacionRecomendacion= t2.CalificacionRecomendacion	
						,PrestamoDictamen_FechaAlta= t2.FechaAlta	
						,PrestamoDictamen_FechaModificacion= t2.FechaModificacion	
						,PrestamoDictamen_IDUsuarioModificacion= t2.IDUsuarioModificacion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoDictamenFile Copy(nc.PrestamoDictamenFile entity)
        {           
            nc.PrestamoDictamenFile _new = new nc.PrestamoDictamenFile();
		 _new.IdPrestamoDictamen= entity.IdPrestamoDictamen;
		 _new.IdFile= entity.IdFile;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(PrestamoDictamenFile entity, int id)
        {            
            entity.IdPrestamoDictamenFile = id;            
        }
		public override void Set(PrestamoDictamenFile source,PrestamoDictamenFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenFile= source.IdPrestamoDictamenFile ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdFile= source.IdFile ;
		 		  
		}
		public override void Set(PrestamoDictamenFileResult source,PrestamoDictamenFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenFile= source.IdPrestamoDictamenFile ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdFile= source.IdFile ;
		 
		}
		public override void Set(PrestamoDictamenFile source,PrestamoDictamenFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenFile= source.IdPrestamoDictamenFile ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdFile= source.IdFile ;
		 	
		}		
		public override void Set(PrestamoDictamenFileResult source,PrestamoDictamenFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenFile= source.IdPrestamoDictamenFile ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdFile= source.IdFile ;
		 target.File_Date= source.File_Date;	
			target.File_FileType= source.File_FileType;	
			target.File_FileName= source.File_FileName;	
			//target.File_Data= source.File_Data;	
			target.File_Checked= source.File_Checked;	
			target.PrestamoDictamen_Expediente= source.PrestamoDictamen_Expediente;	
			target.PrestamoDictamen_IDOrganismo= source.PrestamoDictamen_IDOrganismo;	
			target.PrestamoDictamen_OrganismoDetalle= source.PrestamoDictamen_OrganismoDetalle;	
			target.PrestamoDictamen_Denominacion= source.PrestamoDictamen_Denominacion;	
			target.PrestamoDictamen_IdGestionTipo= source.PrestamoDictamen_IdGestionTipo;	
			target.PrestamoDictamen_IdOrganismoFinanciero= source.PrestamoDictamen_IdOrganismoFinanciero;	
			target.PrestamoDictamen_MontoTotal= source.PrestamoDictamen_MontoTotal;	
			target.PrestamoDictamen_MontoPrestamo= source.PrestamoDictamen_MontoPrestamo;	
			target.PrestamoDictamen_IdAnalista= source.PrestamoDictamen_IdAnalista;	
			target.PrestamoDictamen_IdPrestamo= source.PrestamoDictamen_IdPrestamo;	
			target.PrestamoDictamen_IdPrestamoDictamenRelacionado= source.PrestamoDictamen_IdPrestamoDictamenRelacionado;	
			target.PrestamoDictamen_Comentario= source.PrestamoDictamen_Comentario;	
			target.PrestamoDictamen_IDPrestamoCalificacion= source.PrestamoDictamen_IDPrestamoCalificacion;	
			target.PrestamoDictamen_CalificacionFecha= source.PrestamoDictamen_CalificacionFecha;	
			target.PrestamoDictamen_CalificacionITecnico= source.PrestamoDictamen_CalificacionITecnico;	
			target.PrestamoDictamen_CalificacionITFecha= source.PrestamoDictamen_CalificacionITFecha;	
			target.PrestamoDictamen_CalificacionNotaDNIP= source.PrestamoDictamen_CalificacionNotaDNIP;	
			target.PrestamoDictamen_CalificacionObservacion= source.PrestamoDictamen_CalificacionObservacion;	
			target.PrestamoDictamen_CalificacionRecomendacion= source.PrestamoDictamen_CalificacionRecomendacion;	
			target.PrestamoDictamen_FechaAlta= source.PrestamoDictamen_FechaAlta;	
			target.PrestamoDictamen_FechaModificacion= source.PrestamoDictamen_FechaModificacion;	
			target.PrestamoDictamen_IDUsuarioModificacion= source.PrestamoDictamen_IDUsuarioModificacion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoDictamenFile source,PrestamoDictamenFile target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamenFile.Equals(target.IdPrestamoDictamenFile))return false;
		  if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if(!source.IdFile.Equals(target.IdFile))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoDictamenFileResult source,PrestamoDictamenFileResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamenFile.Equals(target.IdPrestamoDictamenFile))return false;
		  if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if(!source.IdFile.Equals(target.IdFile))return false;
		  if((source.File_Date == null)?target.File_Date!=null:!source.File_Date.Equals(target.File_Date))return false;
						 if(!source.File_FileType.Equals(target.File_FileType))return false;
					  if(!source.File_FileName.Equals(target.File_FileName))return false;
					  //if((source.File_Data == null)?target.File_Data!=null:!source.File_Data.Equals(target.File_Data))return false;
						 if((source.File_Checked == null)?target.File_Checked!=null:!source.File_Checked.Equals(target.File_Checked))return false;
						 if(!source.PrestamoDictamen_Expediente.Equals(target.PrestamoDictamen_Expediente))return false;
					  if(!source.PrestamoDictamen_IDOrganismo.Equals(target.PrestamoDictamen_IDOrganismo))return false;
					  if(!source.PrestamoDictamen_OrganismoDetalle.Equals(target.PrestamoDictamen_OrganismoDetalle))return false;
					  if(!source.PrestamoDictamen_Denominacion.Equals(target.PrestamoDictamen_Denominacion))return false;
					  if(!source.PrestamoDictamen_IdGestionTipo.Equals(target.PrestamoDictamen_IdGestionTipo))return false;
					  if(!source.PrestamoDictamen_IdOrganismoFinanciero.Equals(target.PrestamoDictamen_IdOrganismoFinanciero))return false;
					  if(!source.PrestamoDictamen_MontoTotal.Equals(target.PrestamoDictamen_MontoTotal))return false;
					  if(!source.PrestamoDictamen_MontoPrestamo.Equals(target.PrestamoDictamen_MontoPrestamo))return false;
					  if((source.PrestamoDictamen_IdAnalista == null)?(target.PrestamoDictamen_IdAnalista.HasValue && target.PrestamoDictamen_IdAnalista.Value > 0):!source.PrestamoDictamen_IdAnalista.Equals(target.PrestamoDictamen_IdAnalista))return false;
									  if((source.PrestamoDictamen_IdPrestamo == null)?(target.PrestamoDictamen_IdPrestamo.HasValue && target.PrestamoDictamen_IdPrestamo.Value > 0):!source.PrestamoDictamen_IdPrestamo.Equals(target.PrestamoDictamen_IdPrestamo))return false;
									  if((source.PrestamoDictamen_IdPrestamoDictamenRelacionado == null)?(target.PrestamoDictamen_IdPrestamoDictamenRelacionado.HasValue && target.PrestamoDictamen_IdPrestamoDictamenRelacionado.Value > 0):!source.PrestamoDictamen_IdPrestamoDictamenRelacionado.Equals(target.PrestamoDictamen_IdPrestamoDictamenRelacionado))return false;
									  if(!source.PrestamoDictamen_Comentario.Equals(target.PrestamoDictamen_Comentario))return false;
					  if((source.PrestamoDictamen_IDPrestamoCalificacion == null)?(target.PrestamoDictamen_IDPrestamoCalificacion.HasValue && target.PrestamoDictamen_IDPrestamoCalificacion.Value > 0):!source.PrestamoDictamen_IDPrestamoCalificacion.Equals(target.PrestamoDictamen_IDPrestamoCalificacion))return false;
									  if((source.PrestamoDictamen_CalificacionFecha == null)?target.PrestamoDictamen_CalificacionFecha!=null:!source.PrestamoDictamen_CalificacionFecha.Equals(target.PrestamoDictamen_CalificacionFecha))return false;
						 if(!source.PrestamoDictamen_CalificacionITecnico.Equals(target.PrestamoDictamen_CalificacionITecnico))return false;
					  if((source.PrestamoDictamen_CalificacionITFecha == null)?target.PrestamoDictamen_CalificacionITFecha!=null:!source.PrestamoDictamen_CalificacionITFecha.Equals(target.PrestamoDictamen_CalificacionITFecha))return false;
						 if(!source.PrestamoDictamen_CalificacionNotaDNIP.Equals(target.PrestamoDictamen_CalificacionNotaDNIP))return false;
					  if(!source.PrestamoDictamen_CalificacionObservacion.Equals(target.PrestamoDictamen_CalificacionObservacion))return false;
					  if(!source.PrestamoDictamen_CalificacionRecomendacion.Equals(target.PrestamoDictamen_CalificacionRecomendacion))return false;
					  if(!source.PrestamoDictamen_FechaAlta.Equals(target.PrestamoDictamen_FechaAlta))return false;
					  if(!source.PrestamoDictamen_FechaModificacion.Equals(target.PrestamoDictamen_FechaModificacion))return false;
					  if(!source.PrestamoDictamen_IDUsuarioModificacion.Equals(target.PrestamoDictamen_IDUsuarioModificacion))return false;
					 		
		  return true;
        }
		#endregion
    }
}
