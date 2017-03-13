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
    public class _ComentarioTecnicoBusiness : EntityBusiness<ComentarioTecnico,ComentarioTecnicoFilter,ComentarioTecnicoResult,int>
    {        
		protected readonly ComentarioTecnicoData Data = new ComentarioTecnicoData();
        protected override IEntityData<ComentarioTecnico,ComentarioTecnicoFilter,ComentarioTecnicoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ComentarioTecnico() { IdComentarioTecnico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ComentarioTecnico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdComentarioTecnico != default(int),"InvalidField", "ComentarioTecnico");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdComentarioTecnico != default(int),"InvalidField", "ComentarioTecnico");
                DataHelper.ValidateForeignKey(entity.ProyectoComentarioTecnicos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "ComentarioTecnico");

				break;
            }
        }   
		
    }	
}
