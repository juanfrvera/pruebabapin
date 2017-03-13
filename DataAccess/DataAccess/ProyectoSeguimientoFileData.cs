using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoSeguimientoFileData : EntityData<ProyectoSeguimientoFile, ProyectoSeguimientoFileFilter, ProyectoSeguimientoFileResult, int> 
    { 
	   #region Singleton
	   private static volatile ProyectoSeguimientoFileData current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoFileData() {}
	   public static ProyectoSeguimientoFileData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoFileData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoSeguimientoFile"; } }
       public List<ProyectoSeguimientoFileResult> GetWithFileInfo(Int32 IdProyectoSeguimiento)
       {
           return (from pf in this.Table
                   join f in this.Context.FileInfos
                   on pf.IdFile equals f.IdFile
                   select new ProyectoSeguimientoFileResult()
                   {
                       IdFile = pf.IdFile,
                       IdProyectoSeguimiento = pf.IdProyectoSeguimiento,
                       IdProyectoSeguimientoFile = pf.IdProyectoSeguimientoFile,
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
		public override int GetId(nc.ProyectoSeguimientoFile entity)
		{			
			return entity.IdProyectoSeguimientoFile;
		}		
		public override ProyectoSeguimientoFile GetByEntity(ProyectoSeguimientoFile entity)
        {
            return this.GetById(entity.IdProyectoSeguimientoFile);
        }
        public override ProyectoSeguimientoFile GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoSeguimientoFile == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoSeguimientoFile> Query(ProyectoSeguimientoFileFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoSeguimientoFile == null || o.IdProyectoSeguimientoFile >=  filter.IdProyectoSeguimientoFile) && (filter.IdProyectoSeguimientoFile_To == null || o.IdProyectoSeguimientoFile <= filter.IdProyectoSeguimientoFile_To)
					  && (filter.IdProyectoSeguimiento == null || filter.IdProyectoSeguimiento == 0 || o.IdProyectoSeguimiento==filter.IdProyectoSeguimiento)
					  && (filter.IdProyectoSeguimientoIsNull == null || filter.IdProyectoSeguimientoIsNull == true || o.IdProyectoSeguimiento != null ) && (filter.IdProyectoSeguimientoIsNull == null || filter.IdProyectoSeguimientoIsNull == false || o.IdProyectoSeguimiento == null)
					  && (filter.IdFile == null || filter.IdFile == 0 || o.IdFile==filter.IdFile)
					  && (filter.IdFileIsNull == null || filter.IdFileIsNull == true || o.IdFile != null ) && (filter.IdFileIsNull == null || filter.IdFileIsNull == false || o.IdFile == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoSeguimientoFileResult> QueryResult(ProyectoSeguimientoFileFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.FileInfos on o.IdFile equals _t1.IdFile into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals _t2.IdProyectoSeguimiento into tt2 from t2 in tt2.DefaultIfEmpty()
				   select new ProyectoSeguimientoFileResult(){
					 IdProyectoSeguimientoFile=o.IdProyectoSeguimientoFile
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
					 ,IdFile=o.IdFile
					,File_Date= t1!=null?(DateTime?)t1.Date:null	
						,File_FileType= t1!=null?(string)t1.FileType:null	
						,File_FileName= t1!=null?(string)t1.FileName:null	
						//,File_Data= t1!=null?(byte[])t1.Data:null	
						,File_Checked= t1!=null?(bool?)t1.Checked:null	
						,ProyectoSeguimiento_IdSaf= t2!=null?(int?)t2.IdSaf:null	
						,ProyectoSeguimiento_Denominacion= t2!=null?(string)t2.Denominacion:null	
						,ProyectoSeguimiento_Ruta= t2!=null?(string)t2.Ruta:null	
						,ProyectoSeguimiento_Malla= t2!=null?(string)t2.Malla:null	
						,ProyectoSeguimiento_IdAnalista= t2!=null?(int?)t2.IdAnalista:null	
						,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= t2!=null?(int?)t2.IdProyectoSeguimientoAnterior:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoSeguimientoFile Copy(nc.ProyectoSeguimientoFile entity)
        {           
            nc.ProyectoSeguimientoFile _new = new nc.ProyectoSeguimientoFile();
		 _new.IdProyectoSeguimiento= entity.IdProyectoSeguimiento;
		 _new.IdFile= entity.IdFile;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(ProyectoSeguimientoFile entity, int id)
        {            
            entity.IdProyectoSeguimientoFile = id;            
        }
		public override void Set(ProyectoSeguimientoFile source,ProyectoSeguimientoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoFile= source.IdProyectoSeguimientoFile ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdFile= source.IdFile ;
		 		  
		}
		public override void Set(ProyectoSeguimientoFileResult source,ProyectoSeguimientoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoFile= source.IdProyectoSeguimientoFile ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdFile= source.IdFile ;
		 
		}
		public override void Set(ProyectoSeguimientoFile source,ProyectoSeguimientoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoFile= source.IdProyectoSeguimientoFile ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdFile= source.IdFile ;
		 	
		}		
		public override void Set(ProyectoSeguimientoFileResult source,ProyectoSeguimientoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoFile= source.IdProyectoSeguimientoFile ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdFile= source.IdFile ;
		 target.File_Date= source.File_Date;	
			target.File_FileType= source.File_FileType;	
			target.File_FileName= source.File_FileName;	
			//target.File_Data= source.File_Data;	
			target.File_Checked= source.File_Checked;	
			target.ProyectoSeguimiento_IdSaf= source.ProyectoSeguimiento_IdSaf;	
			target.ProyectoSeguimiento_Denominacion= source.ProyectoSeguimiento_Denominacion;	
			target.ProyectoSeguimiento_Ruta= source.ProyectoSeguimiento_Ruta;	
			target.ProyectoSeguimiento_Malla= source.ProyectoSeguimiento_Malla;	
			target.ProyectoSeguimiento_IdAnalista= source.ProyectoSeguimiento_IdAnalista;	
			target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior= source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoSeguimientoFile source,ProyectoSeguimientoFile target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoFile.Equals(target.IdProyectoSeguimientoFile))return false;
		  if((source.IdProyectoSeguimiento == null)?(target.IdProyectoSeguimiento.HasValue && target.IdProyectoSeguimiento.Value > 0):!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
						  if((source.IdFile == null)?(target.IdFile.HasValue && target.IdFile.Value > 0):!source.IdFile.Equals(target.IdFile))return false;
						 
		  return true;
        }
		public override bool Equals(ProyectoSeguimientoFileResult source,ProyectoSeguimientoFileResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoFile.Equals(target.IdProyectoSeguimientoFile))return false;
		  if((source.IdProyectoSeguimiento == null)?(target.IdProyectoSeguimiento.HasValue && target.IdProyectoSeguimiento.Value > 0):!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
						  if((source.IdFile == null)?(target.IdFile.HasValue && target.IdFile.Value > 0):!source.IdFile.Equals(target.IdFile))return false;
						  if((source.File_Date == null)?target.File_Date!=null:!source.File_Date.Equals(target.File_Date))return false;
						 if(!source.File_FileType.Equals(target.File_FileType))return false;
					  if(!source.File_FileName.Equals(target.File_FileName))return false;
					  //if((source.File_Data == null)?target.File_Data!=null:!source.File_Data.Equals(target.File_Data))return false;
						 if((source.File_Checked == null)?target.File_Checked!=null:!source.File_Checked.Equals(target.File_Checked))return false;
						 if(!source.ProyectoSeguimiento_IdSaf.Equals(target.ProyectoSeguimiento_IdSaf))return false;
					  if(!source.ProyectoSeguimiento_Denominacion.Equals(target.ProyectoSeguimiento_Denominacion))return false;
					  if(!source.ProyectoSeguimiento_Ruta.Equals(target.ProyectoSeguimiento_Ruta))return false;
					  if(!source.ProyectoSeguimiento_Malla.Equals(target.ProyectoSeguimiento_Malla))return false;
					  if(!source.ProyectoSeguimiento_IdAnalista.Equals(target.ProyectoSeguimiento_IdAnalista))return false;
					  if((source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior))return false;
									 		
		  return true;
        }
		#endregion
    }
}
