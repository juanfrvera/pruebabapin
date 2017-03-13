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
    public class _SafBusiness : EntityBusiness<Saf,SafFilter,SafResult,int>
    {        
		protected readonly SafData Data = new SafData();
        protected override IEntityData<Saf,SafFilter,SafResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Saf() { IdSaf = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Saf entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");
DataHelper.Validate(entity.IdTipoOrganismo != default(int),"InvalidField", "TipoOrganismo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 5,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 255,"FieldInvalidLength","Denominacion");
DataHelper.Validate(entity.IdTipoOrganismo != default(int),"InvalidField", "TipoOrganismo");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");
                DataHelper.ValidateForeignKey(entity.Oficinas.Any(), "El registro no se puede eliminar porque tiene al menos una oficina asociada", "Saf");
                DataHelper.ValidateForeignKey(entity.OficinaSafs.Any(), "El registro no se puede eliminar porque tiene al menos un saf de oficina asociado", "Saf");
                DataHelper.ValidateForeignKey(entity.Programas.Any(), "El registro no se puede eliminar porque tiene al menos un programa asociado", "Saf");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de proyecto asociado", "Saf");

				break;
            }
        }   
		
    }	
}
