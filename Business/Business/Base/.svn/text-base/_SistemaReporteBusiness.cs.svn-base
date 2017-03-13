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
    public class _SistemaReporteBusiness : EntityBusiness<SistemaReporte,SistemaReporteFilter,SistemaReporteResult,int>
    {        
		protected readonly SistemaReporteData Data = new SistemaReporteData();
        protected override IEntityData<SistemaReporte,SistemaReporteFilter,SistemaReporteResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaReporte() { IdSistemaReporte = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaReporte entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaReporte != default(int),"InvalidField", "SistemaReporte");
DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 50,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
DataHelper.Validate(entity.FileName!=null,"FieldIsNull","FileName");
DataHelper.Validate(entity.FileName.Trim().Length <= 70,"FieldInvalidLength","FileName");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaReporte != default(int),"InvalidField", "SistemaReporte");

				break;
            }
        }   
		
    }	
}
