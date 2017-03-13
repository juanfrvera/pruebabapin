using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoFileData : EntityData<PrestamoFile, PrestamoFileFilter, PrestamoFileResult, int>
    { 
	   #region Singleton
	   private static volatile PrestamoFileData current;
	   private static object syncRoot = new Object();

	   //private PrestamoFileData() {}
	   public static PrestamoFileData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFileData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoFile"; } } 
       public List<PrestamoFileResult> GetWithFileInfo(Int32 IdPrestamo)
       {
           return (from pf in this.Table
                   join f in this.Context.FileInfos
                   on pf.IdFile equals f.IdFile
                   select new PrestamoFileResult()
                   {
                       IdFile = pf.IdFile,
                       IdPrestamo = pf.IdPrestamo,
                       IdPrestamoFile = pf.IdPrestamoFile,
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
		public override int GetId(nc.PrestamoFile entity)
		{			
			return entity.IdPrestamoFile;
		}		
		public override PrestamoFile GetByEntity(PrestamoFile entity)
        {
            return this.GetById(entity.IdPrestamoFile);
        }
        public override PrestamoFile GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoFile == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoFile> Query(PrestamoFileFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoFile == null || o.IdPrestamoFile >=  filter.IdPrestamoFile) && (filter.IdPrestamoFile_To == null || o.IdPrestamoFile <= filter.IdPrestamoFile_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdFile == null || filter.IdFile == 0 || o.IdFile==filter.IdFile)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoFileResult> QueryResult(PrestamoFileFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.FileInfos on o.IdFile equals t1.IdFile   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoFileResult(){
					 IdPrestamoFile=o.IdPrestamoFile
					 ,IdPrestamo=o.IdPrestamo
					 ,IdFile=o.IdFile
					,File_Date= t1.Date	
						,File_FileType= t1.FileType	
						,File_FileName= t1.FileName	
						//,File_Data= t1.Data	
						,File_Checked= t1.Checked	
						,Prestamo_IdPrograma= t2.IdPrograma	
						,Prestamo_Numero= t2.Numero	
						,Prestamo_Denominacion= t2.Denominacion	
						,Prestamo_Descripcion= t2.Descripcion	
						,Prestamo_Observacion= t2.Observacion                        
						,Prestamo_FechaAlta= t2.FechaAlta	
						,Prestamo_FechaModificacion= t2.FechaModificacion	
						,Prestamo_IdUsuarioModificacion= t2.IdUsuarioModificacion	
						,Prestamo_IdEstadoActual= t2.IdEstadoActual	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoFile Copy(nc.PrestamoFile entity)
        {           
            nc.PrestamoFile _new = new nc.PrestamoFile();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdFile= entity.IdFile;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(PrestamoFile entity, int id)
        {            
            entity.IdPrestamoFile = id;            
        }
		public override void Set(PrestamoFile source,PrestamoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFile= source.IdPrestamoFile ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFile= source.IdFile ;
		 		  
		}
		public override void Set(PrestamoFileResult source,PrestamoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFile= source.IdPrestamoFile ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFile= source.IdFile ;
		 
		}
		public override void Set(PrestamoFile source,PrestamoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFile= source.IdPrestamoFile ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFile= source.IdFile ;
		 	
		}		
		public override void Set(PrestamoFileResult source,PrestamoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFile= source.IdPrestamoFile ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdFile= source.IdFile ;
		 target.File_Date= source.File_Date;	
			target.File_FileType= source.File_FileType;	
			target.File_FileName= source.File_FileName;	
			//target.File_Data= source.File_Data;	
			target.File_Checked= source.File_Checked;	
			target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
			target.Prestamo_Numero= source.Prestamo_Numero;	
			target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
			target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
			target.Prestamo_Observacion= source.Prestamo_Observacion;	
			target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
			target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
			target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
			target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoFile source,PrestamoFile target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFile.Equals(target.IdPrestamoFile))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdFile.Equals(target.IdFile))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoFileResult source,PrestamoFileResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFile.Equals(target.IdPrestamoFile))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdFile.Equals(target.IdFile))return false;
		  if((source.File_Date == null)?target.File_Date!=null:!source.File_Date.Equals(target.File_Date))return false;
						 if(!source.File_FileType.Equals(target.File_FileType))return false;
					  if(!source.File_FileName.Equals(target.File_FileName))return false;
					  //if((source.File_Data == null)?target.File_Data!=null:!source.File_Data.Equals(target.File_Data))return false;
						 if((source.File_Checked == null)?target.File_Checked!=null:!source.File_Checked.Equals(target.File_Checked))return false;
						 if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
					  if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
					  if(!source.Prestamo_Denominacion.Equals(target.Prestamo_Denominacion))return false;
					  if(!source.Prestamo_Descripcion.Equals(target.Prestamo_Descripcion))return false;
					  if(!source.Prestamo_Observacion.Equals(target.Prestamo_Observacion))return false;
					  if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
					  if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
					  if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
					  if((source.Prestamo_IdEstadoActual == null)?target.Prestamo_IdEstadoActual!=null:!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
								
		  return true;
        }
		#endregion
    }
}
