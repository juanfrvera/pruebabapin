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
    public class _ProyectoCalificacionBusiness : EntityBusiness<ProyectoCalificacion,ProyectoCalificacionFilter,ProyectoCalificacionResult,int>
    {        
		protected readonly ProyectoCalificacionData Data = new ProyectoCalificacionData();
        protected override IEntityData<ProyectoCalificacion,ProyectoCalificacionFilter,ProyectoCalificacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoCalificacion() { IdProyectoCalificacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoCalificacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoCalificacion != default(int),"InvalidField", "ProyectoCalificacion");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoCalificacion != default(int),"InvalidField", "ProyectoCalificacion");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamens.Any(), "El registro no se puede eliminar porque tiene al menos un dictamen asociado", "ProyectoCalificacion");

				break;
            }
        }   
		
    }	
}
