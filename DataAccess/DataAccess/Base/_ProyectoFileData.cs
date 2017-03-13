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
    public abstract class _ProyectoFileData : EntityData<ProyectoFile,ProyectoFileFilter,ProyectoFileResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoFile entity)
		{			
			return entity.IdProyectoFile;
		}		
		public override ProyectoFile GetByEntity(ProyectoFile entity)
        {
            return this.GetById(entity.IdProyectoFile);
        }
        public override ProyectoFile GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoFile == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoFile> Query(ProyectoFileFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoFile == null || o.IdProyectoFile >=  filter.IdProyectoFile) && (filter.IdProyectoFile_To == null || o.IdProyectoFile <= filter.IdProyectoFile_To)
					  && (filter.IdFile == null || filter.IdFile == 0 || o.IdFile==filter.IdFile)
					  && (filter.IdFileIsNull == null || filter.IdFileIsNull == true || o.IdFile != null ) && (filter.IdFileIsNull == null || filter.IdFileIsNull == false || o.IdFile == null)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == true || o.IdProyecto != null ) && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == false || o.IdProyecto == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoFileResult> QueryResult(ProyectoFileFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.FileInfos on o.IdFile equals _t1.IdFile into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.Proyectos on o.IdProyecto equals _t2.IdProyecto into tt2 from t2 in tt2.DefaultIfEmpty()
				   select new ProyectoFileResult(){
					 IdProyectoFile=o.IdProyectoFile
					 ,IdFile=o.IdFile
					 ,IdProyecto=o.IdProyecto
					,File_Date= t1!=null?(DateTime?)t1.Date:null	
						,File_FileType= t1!=null?(string)t1.FileType:null	
						,File_FileName= t1!=null?(string)t1.FileName:null	
						,File_Data= t1!=null?(byte[])t1.Data:null	
						,File_Checked= t1!=null?(bool?)t1.Checked:null	
						,Proyecto_IdTipoProyecto= t2!=null?(int?)t2.IdTipoProyecto:null	
						,Proyecto_IdSubPrograma= t2!=null?(int?)t2.IdSubPrograma:null	
						,Proyecto_Codigo= t2!=null?(int?)t2.Codigo:null	
						,Proyecto_ProyectoDenominacion= t2!=null?(string)t2.ProyectoDenominacion:null	
						,Proyecto_ProyectoSituacionActual= t2!=null?(string)t2.ProyectoSituacionActual:null	
						,Proyecto_ProyectoDescripcion= t2!=null?(string)t2.ProyectoDescripcion:null	
						,Proyecto_ProyectoObservacion= t2!=null?(string)t2.ProyectoObservacion:null	
						,Proyecto_IdEstado= t2!=null?(int?)t2.IdEstado:null	
						,Proyecto_IdProceso= t2!=null?(int?)t2.IdProceso:null	
						,Proyecto_IdModalidadContratacion= t2!=null?(int?)t2.IdModalidadContratacion:null	
						,Proyecto_IdFinalidadFuncion= t2!=null?(int?)t2.IdFinalidadFuncion:null	
						,Proyecto_IdOrganismoPrioridad= t2!=null?(int?)t2.IdOrganismoPrioridad:null	
						,Proyecto_SubPrioridad= t2!=null?(int?)t2.SubPrioridad:null	
						,Proyecto_EsBorrador= t2!=null?(bool?)t2.EsBorrador:null	
						,Proyecto_EsProyecto= t2!=null?(bool?)t2.EsProyecto:null	
						,Proyecto_NroProyecto= t2!=null?(int?)t2.NroProyecto:null	
						,Proyecto_AnioCorriente= t2!=null?(int?)t2.AnioCorriente:null	
						,Proyecto_FechaInicioEjecucionCalculada= t2!=null?(DateTime?)t2.FechaInicioEjecucionCalculada:null	
						,Proyecto_FechaFinEjecucionCalculada= t2!=null?(DateTime?)t2.FechaFinEjecucionCalculada:null	
						,Proyecto_FechaAlta= t2!=null?(DateTime?)t2.FechaAlta:null	
						,Proyecto_FechaModificacion= t2!=null?(DateTime?)t2.FechaModificacion:null	
						,Proyecto_IdUsuarioModificacion= t2!=null?(int?)t2.IdUsuarioModificacion:null	
						,Proyecto_IdProyectoPlan= t2!=null?(int?)t2.IdProyectoPlan:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoFile Copy(nc.ProyectoFile entity)
        {           
            nc.ProyectoFile _new = new nc.ProyectoFile();
		 _new.IdFile= entity.IdFile;
		 _new.IdProyecto= entity.IdProyecto;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(ProyectoFile entity, int id)
        {            
            entity.IdProyectoFile = id;            
        }
		public override void Set(ProyectoFile source,ProyectoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFile= source.IdProyectoFile ;
		 target.IdFile= source.IdFile ;
		 target.IdProyecto= source.IdProyecto ;
		 		  
		}
		public override void Set(ProyectoFileResult source,ProyectoFile target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFile= source.IdProyectoFile ;
		 target.IdFile= source.IdFile ;
		 target.IdProyecto= source.IdProyecto ;
		 
		}
		public override void Set(ProyectoFile source,ProyectoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFile= source.IdProyectoFile ;
		 target.IdFile= source.IdFile ;
		 target.IdProyecto= source.IdProyecto ;
		 	
		}		
		public override void Set(ProyectoFileResult source,ProyectoFileResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFile= source.IdProyectoFile ;
		 target.IdFile= source.IdFile ;
		 target.IdProyecto= source.IdProyecto ;
		 target.File_Date= source.File_Date;	
			target.File_FileType= source.File_FileType;	
			target.File_FileName= source.File_FileName;	
			target.File_Data= source.File_Data;	
			target.File_Checked= source.File_Checked;	
			target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
			target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
			target.Proyecto_Codigo= source.Proyecto_Codigo;	
			target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
			target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
			target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
			target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
			target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
			target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
			target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
			target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
			target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
			target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
			target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
			target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
			target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
			target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
			target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
			target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
			target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
			target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
			target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
			target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoFile source,ProyectoFile target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFile.Equals(target.IdProyectoFile))return false;
		  if((source.IdFile == null)?(target.IdFile.HasValue && target.IdFile.Value > 0):!source.IdFile.Equals(target.IdFile))return false;
						  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						 
		  return true;
        }
		public override bool Equals(ProyectoFileResult source,ProyectoFileResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFile.Equals(target.IdProyectoFile))return false;
		  if((source.IdFile == null)?(target.IdFile.HasValue && target.IdFile.Value > 0):!source.IdFile.Equals(target.IdFile))return false;
						  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						  if((source.File_Date == null)?target.File_Date!=null:!source.File_Date.Equals(target.File_Date))return false;
						 if(!source.File_FileType.Equals(target.File_FileType))return false;
					  if(!source.File_FileName.Equals(target.File_FileName))return false;
					  if((source.File_Data == null)?target.File_Data!=null:!source.File_Data.Equals(target.File_Data))return false;
						 if((source.File_Checked == null)?target.File_Checked!=null:!source.File_Checked.Equals(target.File_Checked))return false;
						 if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
					  if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
					  if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
					  if(!source.Proyecto_ProyectoDenominacion.Equals(target.Proyecto_ProyectoDenominacion))return false;
					  if(!source.Proyecto_ProyectoSituacionActual.Equals(target.Proyecto_ProyectoSituacionActual))return false;
					  if(!source.Proyecto_ProyectoDescripcion.Equals(target.Proyecto_ProyectoDescripcion))return false;
					  if(!source.Proyecto_ProyectoObservacion.Equals(target.Proyecto_ProyectoObservacion))return false;
					  if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
					  if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
									  if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
									  if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
									  if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
									  if((source.Proyecto_SubPrioridad == null)?target.Proyecto_SubPrioridad!=null:!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
						 if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
					  if((source.Proyecto_EsProyecto == null)?target.Proyecto_EsProyecto!=null:!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
						 if((source.Proyecto_NroProyecto == null)?target.Proyecto_NroProyecto!=null:!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
						 if((source.Proyecto_AnioCorriente == null)?target.Proyecto_AnioCorriente!=null:!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
						 if((source.Proyecto_FechaInicioEjecucionCalculada == null)?target.Proyecto_FechaInicioEjecucionCalculada!=null:!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
						 if((source.Proyecto_FechaFinEjecucionCalculada == null)?target.Proyecto_FechaFinEjecucionCalculada!=null:!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
						 if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
					  if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
					  if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
					  if((source.Proyecto_IdProyectoPlan == null)?target.Proyecto_IdProyectoPlan!=null:!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
								
		  return true;
        }
		#endregion
    }
}
