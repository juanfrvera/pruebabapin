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
    public class _ClasificacionBusiness : EntityBusiness<Clasificacion,ClasificacionFilter,ClasificacionResult,int>
    {        
		protected readonly ClasificacionData Data = new ClasificacionData();
        protected override IEntityData<Clasificacion,ClasificacionFilter,ClasificacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Clasificacion() { IdClasificacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Clasificacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacion != default(int),"InvalidField", "Clasificacion");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacion != default(int),"InvalidField", "Clasificacion");
                DataHelper.ValidateForeignKey(entity.ProyectoPrioridads.Any(), "El registro no se puede eliminar porque tiene al menos una prioridad de proyecto asociada", "Clasificacion");
				
				break;
            }
        }   
		
    }	
}
