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
    public class _SubJurisdiccionBusiness : EntityBusiness<SubJurisdiccion,SubJurisdiccionFilter,SubJurisdiccionResult,int>
    {        
		protected readonly SubJurisdiccionData Data = new SubJurisdiccionData();
        protected override IEntityData<SubJurisdiccion,SubJurisdiccionFilter,SubJurisdiccionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SubJurisdiccion() { IdSubJuridiccion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SubJurisdiccion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSubJuridiccion != default(int),"InvalidField", "SubJuridiccion");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 5,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSubJuridiccion != default(int),"InvalidField", "SubJuridiccion");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un saf asociado", "SubJuridiccion");

				break;
            }
        }   
		
    }	
}
