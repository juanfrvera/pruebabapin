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
    public class _PrestamoAlcanceGeograficoBusiness : EntityBusiness<PrestamoAlcanceGeografico,PrestamoAlcanceGeograficoFilter,PrestamoAlcanceGeograficoResult,int>
    {        
		protected readonly PrestamoAlcanceGeograficoData Data = new PrestamoAlcanceGeograficoData();
        protected override IEntityData<PrestamoAlcanceGeografico,PrestamoAlcanceGeograficoFilter,PrestamoAlcanceGeograficoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoAlcanceGeografico() { IdPrestamoAlcanceGeografico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoAlcanceGeografico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoAlcanceGeografico != default(int),"InvalidField", "PrestamoAlcanceGeografico");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoAlcanceGeografico != default(int),"InvalidField", "PrestamoAlcanceGeografico");

				break;
            }
        }   
		
    }	
}
