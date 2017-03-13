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
    public class _SubProgramaBusiness : EntityBusiness<SubPrograma,SubProgramaFilter,SubProgramaResult,int>
    {        
		protected readonly SubProgramaData Data = new SubProgramaData();
        protected override IEntityData<SubPrograma,SubProgramaFilter,SubProgramaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SubPrograma() { IdSubPrograma = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SubPrograma entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");

                  }				
				DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 3,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 255,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "SubPrograma");
                DataHelper.ValidateForeignKey(entity.Transferencias.Any(), "El registro no se puede eliminar porque tiene al menos una transferencia asociada", "SubPrograma");

				break;
            }
        }   
		
    }	
}
