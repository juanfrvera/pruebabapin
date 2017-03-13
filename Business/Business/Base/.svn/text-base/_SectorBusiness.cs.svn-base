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
    public class _SectorBusiness : EntityBusiness<Sector,SectorFilter,SectorResult,int>
    {        
		protected readonly SectorData Data = new SectorData();
        protected override IEntityData<Sector,SectorFilter,SectorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Sector() { IdSector = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Sector entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSector != default(int),"InvalidField", "Sector");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 4,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSector != default(int),"InvalidField", "Sector");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un saf asociado", "Sector");

				break;
            }
        }   
		
    }	
}
