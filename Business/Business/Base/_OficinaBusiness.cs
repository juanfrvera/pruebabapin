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
    public class _OficinaBusiness : EntityBusiness<Oficina,OficinaFilter,OficinaResult,int>
    {        
		protected readonly OficinaData Data = new OficinaData();
        protected override IEntityData<Oficina,OficinaFilter,OficinaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Oficina() { IdOficina = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Oficina entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 15,"FieldInvalidLength","Codigo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
                DataHelper.ValidateForeignKey(entity.Oficinas.Any(), "El registro no se puede eliminar porque tiene al menos una sub oficina asociada", "Oficina");
                DataHelper.ValidateForeignKey(entity.PrestamoOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "Oficina");
                DataHelper.ValidateForeignKey(entity.ProyectoOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "Oficina");
                DataHelper.ValidateForeignKey(entity.Personas.Any(), "El registro no se puede eliminar porque tiene al menos una persona asociada", "Oficina");
                DataHelper.ValidateForeignKey(entity.OficinaSafs.Any(), "El registro no se puede eliminar porque tiene al menos un saf asociado", "Oficina");
               
				break;
            }
        }   
		
    }	
}
