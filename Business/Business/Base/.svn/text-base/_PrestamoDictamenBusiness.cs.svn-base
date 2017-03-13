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
    public class _PrestamoDictamenBusiness : EntityBusiness<PrestamoDictamen,PrestamoDictamenFilter,PrestamoDictamenResult,int>
    {        
		protected readonly PrestamoDictamenData Data = new PrestamoDictamenData();
        protected override IEntityData<PrestamoDictamen,PrestamoDictamenFilter,PrestamoDictamenResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoDictamen() { IdPrestamoDictamen = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoDictamen entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");

                  }				
				DataHelper.Validate(entity.Expediente!=null,"FieldIsNull","Expediente");
DataHelper.Validate(entity.Expediente.Trim().Length <= 50,"FieldInvalidLength","Expediente");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 500,"FieldInvalidLength","Denominacion");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");
DataHelper.Validate(entity.FechaModificacion > new DateTime(1900,1,1) ,"InvalidField", "FechaModificacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado asociado", "PrestamoDictamen");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamenFiles.Any(), "El registro no se puede eliminar porque tiene al menos un archivo asociado", "PrestamoDictamen");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamenFiles.Any(), "El registro no se puede eliminar porque tiene al menos un archivo asociado", "PrestamoDictamen");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamens.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "PrestamoDictamen");
               
				break;
            }
        }   
		
    }	
}
