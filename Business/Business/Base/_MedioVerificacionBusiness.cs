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
    public class _MedioVerificacionBusiness : EntityBusiness<MedioVerificacion,MedioVerificacionFilter,MedioVerificacionResult,int>
    {        
		protected readonly MedioVerificacionData Data = new MedioVerificacionData();
        protected override IEntityData<MedioVerificacion,MedioVerificacionFilter,MedioVerificacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MedioVerificacion() { IdMedioVerificacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.MedioVerificacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMedioVerificacion != default(int),"InvalidField", "MedioVerificacion");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 10,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMedioVerificacion != default(int),"InvalidField", "MedioVerificacion");
                DataHelper.ValidateForeignKey(entity.Indicadors.Any(), "El registro no se puede eliminar porque tiene al menos un indicador asociado", "MedioVerificacion");
                
				break;
            }
        }   
		
    }	
}
