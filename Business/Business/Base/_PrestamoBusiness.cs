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
    public class _PrestamoBusiness : EntityBusiness<Prestamo,PrestamoFilter,PrestamoResult,int>
    {        
		protected readonly PrestamoData Data = new PrestamoData();
        protected override IEntityData<Prestamo,PrestamoFilter,PrestamoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Prestamo() { IdPrestamo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Prestamo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");

                  }				
				DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 500,"FieldInvalidLength","Denominacion");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");
DataHelper.Validate(entity.FechaModificacion > new DateTime(1900,1,1) ,"InvalidField", "FechaModificacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");

				break;
            }
        }   
		
    }	
}
