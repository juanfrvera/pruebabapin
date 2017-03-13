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
    public class _FaseBusiness : EntityBusiness<Fase,FaseFilter,FaseResult,int>
    {        
		protected readonly FaseData Data = new FaseData();
        protected override IEntityData<Fase,FaseFilter,FaseResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Fase() { IdFase = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Fase entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdFase != default(int),"InvalidField", "Fase");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 2,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdFase != default(int),"InvalidField", "Fase");
                DataHelper.ValidateForeignKey(entity.ProyectoFaseProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos una fase de etapa de proyecto asociada", "Fase");    

				break;
            }
        }   
		
    }	
}
