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
    public class _SistemaReporteHistoricoBusiness : EntityBusiness<SistemaReporteHistorico,SistemaReporteHistoricoFilter,SistemaReporteHistoricoResult,int>
    {        
		protected readonly SistemaReporteHistoricoData Data = new SistemaReporteHistoricoData();
        protected override IEntityData<SistemaReporteHistorico,SistemaReporteHistoricoFilter,SistemaReporteHistoricoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaReporteHistorico() { IdSistemaReporteHistorico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaReporteHistorico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaReporteHistorico != default(int),"InvalidField", "SistemaReporteHistorico");
DataHelper.Validate(entity.IdSistemaReporte != default(int),"InvalidField", "SistemaReporte");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdSistemaReporte != default(int),"InvalidField", "SistemaReporte");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaReporteHistorico != default(int),"InvalidField", "SistemaReporteHistorico");
                
				break;
            }
        }   
		
    }	
}
