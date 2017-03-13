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
    public class _ProyectoEtapaBusiness : EntityBusiness<ProyectoEtapa,ProyectoEtapaFilter,ProyectoEtapaResult,int>
    {        
		protected readonly ProyectoEtapaData Data = new ProyectoEtapaData();
        protected override IEntityData<ProyectoEtapa,ProyectoEtapaFilter,ProyectoEtapaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapa() { IdProyectoEtapa = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapa entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.IdEtapa != default(int),"InvalidField", "Etapa");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 500,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdEtapa != default(int),"InvalidField", "Etapa");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaEstimados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa estimada asociada", "ProyectoEtapa");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un indicador asociado", "ProyectoEtapa");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaRealizados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa realziada asociada", "ProyectoEtapa");
                DataHelper.ValidateForeignKey(entity.ProyectoProductoProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos un producto asociado", "ProyectoEtapa");

				break;
            }
        }   
		
    }	
}
