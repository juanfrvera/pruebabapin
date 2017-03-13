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
    public class _SistemaEntidadEstadoBusiness : EntityBusiness<SistemaEntidadEstado,SistemaEntidadEstadoFilter,SistemaEntidadEstadoResult,int>
    {        
		protected readonly SistemaEntidadEstadoData Data = new SistemaEntidadEstadoData();
        protected override IEntityData<SistemaEntidadEstado,SistemaEntidadEstadoFilter,SistemaEntidadEstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaEntidadEstado() { IdSistemaEntidadEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaEntidadEstado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaEntidadEstado != default(int),"InvalidField", "SistemaEntidadEstado");
DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");

                  }				
				DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaEntidadEstado != default(int),"InvalidField", "SistemaEntidadEstado");
                DataHelper.ValidateForeignKey(entity.Permisos.Any(), "El registro no se puede eliminar porque tiene al menos un permiso asociado", "SistemaEntidadEstado");

				break;
            }
        }   
		
    }	
}
