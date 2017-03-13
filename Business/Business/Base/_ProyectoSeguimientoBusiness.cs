using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _ProyectoSeguimientoBusiness : EntityBusiness<ProyectoSeguimiento,ProyectoSeguimientoFilter,ProyectoSeguimientoResult,int>
    {        
		protected readonly ProyectoSeguimientoData Data = new ProyectoSeguimientoData();
        protected override IEntityData<ProyectoSeguimiento,ProyectoSeguimientoFilter,ProyectoSeguimientoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoSeguimiento() { IdProyectoSeguimiento = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoSeguimiento entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");
DataHelper.Validate(entity.IdAnalista != default(int),"InvalidField", "Analista");

                  }				
				DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 500,"FieldInvalidLength","Denominacion");
DataHelper.Validate(entity.IdAnalista != default(int),"InvalidField", "Analista");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamenSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de dictamen asociado", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado asociado", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoFiles.Any(), "El registro no se puede eliminar porque tiene al menos un archivo asociado", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoLocalizacions.Any(), "El registro no se puede eliminar porque tiene al menos una localización asociada", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoProyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "ProyectoSeguimiento");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un sub seguimiento asociado", "ProyectoSeguimiento");

				break;
            }
        }   
		
    }	
}
