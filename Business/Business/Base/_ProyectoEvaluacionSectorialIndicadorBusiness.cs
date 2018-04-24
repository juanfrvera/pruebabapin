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
    public class _ProyectoEvaluacionSectorialIndicadorBusiness : EntityBusiness<ProyectoEvaluacionSectorialIndicador,ProyectoEvaluacionSectorialIndicadorFilter,ProyectoEvaluacionSectorialIndicadorResult,int>
    {        
		protected readonly ProyectoEvaluacionSectorialIndicadorData Data = new ProyectoEvaluacionSectorialIndicadorData();
        protected override IEntityData<ProyectoEvaluacionSectorialIndicador,ProyectoEvaluacionSectorialIndicadorFilter,ProyectoEvaluacionSectorialIndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEvaluacionSectorialIndicador() { IdProyectoEvaluacionSectorialIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEvaluacionSectorialIndicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEvaluacionSectorialIndicador != default(int),"InvalidField", "ProyectoEvaluacionSectorialIndicador");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEvaluacionSectorialIndicador != default(int),"InvalidField", "ProyectoEvaluacionSectorialIndicador");

				break;
            }
        }   
		
    }	
}
