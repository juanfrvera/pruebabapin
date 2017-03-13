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
    public class _SistemaCommandBusiness : EntityBusiness<SistemaCommand,SistemaCommandFilter,SistemaCommandResult,int>
    {        
		protected readonly SistemaCommandData Data = new SistemaCommandData();
        protected override IEntityData<SistemaCommand,SistemaCommandFilter,SistemaCommandResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaCommand() { IdSistemaCommand = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaCommand entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaCommand != default(int),"InvalidField", "SistemaCommand");
DataHelper.Validate(entity.IdsistemaEntidad != default(int),"InvalidField", "sistemaEntidad");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdsistemaEntidad != default(int),"InvalidField", "sistemaEntidad");
DataHelper.Validate(entity.CommandText!=null,"FieldIsNull","CommandText");
DataHelper.Validate(entity.CommandText.Trim().Length <= 2000,"FieldInvalidLength","CommandText");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaCommand != default(int),"InvalidField", "SistemaCommand");

				break;
            }
        }   
		
    }	
}
