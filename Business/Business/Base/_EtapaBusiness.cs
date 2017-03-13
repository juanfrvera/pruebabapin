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
    public class _EtapaBusiness : EntityBusiness<Etapa,EtapaFilter,EtapaResult,int>
    {        
		protected readonly EtapaData Data = new EtapaData();
        protected override IEntityData<Etapa,EtapaFilter,EtapaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Etapa() { IdEtapa = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Etapa entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEtapa != default(int),"InvalidField", "Etapa");
DataHelper.Validate(entity.IdFase != default(int),"InvalidField", "Fase");

                  }				
				DataHelper.Validate(entity.IdFase != default(int),"InvalidField", "Fase");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 2,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEtapa != default(int),"InvalidField", "Etapa");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto asociada", "Etapa");
                DataHelper.ValidateForeignKey(entity.ProyectoFaseProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos una fase de etapa de proyecto asociada", "Etapa");    

				break;
            }
        }   
		
    }	
}
