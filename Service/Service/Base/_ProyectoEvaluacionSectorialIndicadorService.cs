using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEvaluacionSectorialIndicadorService : EntityService<nc.ProyectoEvaluacionSectorialIndicador,nc.ProyectoEvaluacionSectorialIndicadorFilter,nc.ProyectoEvaluacionSectorialIndicadorResult,int>
    {        
		protected readonly ProyectoEvaluacionSectorialIndicadorBusiness Business = new ProyectoEvaluacionSectorialIndicadorBusiness();
        protected override IEntityBusiness<nc.ProyectoEvaluacionSectorialIndicador,nc.ProyectoEvaluacionSectorialIndicadorFilter,nc.ProyectoEvaluacionSectorialIndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
