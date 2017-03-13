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
    public class _JurisdiccionBusiness : EntityBusiness<Jurisdiccion,JurisdiccionFilter,JurisdiccionResult,int>
    {        
		protected readonly JurisdiccionData Data = new JurisdiccionData();
        protected override IEntityData<Jurisdiccion,JurisdiccionFilter,JurisdiccionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Jurisdiccion() { IdJurisdiccion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Jurisdiccion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdJurisdiccion != default(int),"InvalidField", "Jurisdiccion");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 15,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 120,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdJurisdiccion != default(int),"InvalidField", "Jurisdiccion");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un saf asociado", "Jurisdiccion");
               
				break;
            }
        }   
		
    }	
}
