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
    public class _ClasificacionGeograficaTipoBusiness : EntityBusiness<ClasificacionGeograficaTipo,ClasificacionGeograficaTipoFilter,ClasificacionGeograficaTipoResult,int>
    {        
		protected readonly ClasificacionGeograficaTipoData Data = new ClasificacionGeograficaTipoData();
        protected override IEntityData<ClasificacionGeograficaTipo,ClasificacionGeograficaTipoFilter,ClasificacionGeograficaTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ClasificacionGeograficaTipo() { IdClasificacionGeograficaTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ClasificacionGeograficaTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacionGeograficaTipo != default(int),"InvalidField", "ClasificacionGeograficaTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacionGeograficaTipo != default(int),"InvalidField", "ClasificacionGeograficaTipo");
                DataHelper.ValidateForeignKey(entity.ClasificacionGeograficas.Any(), "El registro no se puede eliminar porque tiene al menos una clasificación geografica asociada", "ClasificacionGeograficaTipo");

				break;
            }
        }   
		
    }	
}
