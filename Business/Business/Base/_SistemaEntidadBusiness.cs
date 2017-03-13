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
    public class _SistemaEntidadBusiness : EntityBusiness<SistemaEntidad,SistemaEntidadFilter,SistemaEntidadResult,int>
    {        
		protected readonly SistemaEntidadData Data = new SistemaEntidadData();
        protected override IEntityData<SistemaEntidad,SistemaEntidadFilter,SistemaEntidadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaEntidad() { IdSistemaEntidad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaEntidad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 50,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
                DataHelper.ValidateForeignKey(entity.Permisos.Any(), "El registro no se puede eliminar porque tiene al menos un permiso asociado", "SistemaEntidad");
                DataHelper.ValidateForeignKey(entity.SistemaCommands.Any(), "El registro no se puede eliminar porque tiene al menos un sistema de comandos asociado", "SistemaEntidad");
                DataHelper.ValidateForeignKey(entity.SistemaEntidadAccions.Any(), "El registro no se puede eliminar porque tiene al menos una acción asociada", "SistemaEntidad");
                DataHelper.ValidateForeignKey(entity.SistemaEntidadEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado asociado", "SistemaEntidad");
                DataHelper.ValidateForeignKey(entity.SistemaReportes.Any(), "El registro no se puede eliminar porque tiene al menos un sistema de reportes asociado", "SistemaEntidad");

				break;
            }
        }   
		
    }	
}
