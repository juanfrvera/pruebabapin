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
    public class _TextBusiness : EntityBusiness<Text,TextFilter,TextResult,int>
    {        
		protected readonly TextData Data = new TextData();
        protected override IEntityData<Text,TextFilter,TextResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Text() { IdText = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Text entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdText != default(int),"InvalidField", "Text");
DataHelper.Validate(entity.IdTextCategory != default(int),"InvalidField", "TextCategory");

                  }				
				DataHelper.Validate(entity.Code!=null,"FieldIsNull","Code");
DataHelper.Validate(entity.Code.Trim().Length <= 50,"FieldInvalidLength","Code");
DataHelper.Validate(entity.IdTextCategory != default(int),"InvalidField", "TextCategory");
DataHelper.Validate(entity.StartDate > new DateTime(1900,1,1) ,"InvalidField", "StartDate");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdText != default(int),"InvalidField", "Text");
                DataHelper.ValidateForeignKey(entity.TextLanguages.Any(), "El registro no se puede eliminar porque tiene al menos un lenguaje asociado", "Text");

				break;
            }
        }   
		
    }	
}
