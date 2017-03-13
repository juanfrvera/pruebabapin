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
    public class _PersonaBusiness : EntityBusiness<Persona,PersonaFilter,PersonaResult,int>
    {        
		protected readonly PersonaData Data = new PersonaData();
        protected override IEntityData<Persona,PersonaFilter,PersonaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Persona() { IdPersona = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Persona entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPersona != default(int),"InvalidField", "Persona");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Apellido!=null,"FieldIsNull","Apellido");
DataHelper.Validate(entity.Apellido.Trim().Length <= 70,"FieldInvalidLength","Apellido");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.Sexo!=null,"FieldIsNull","Sexo");
DataHelper.Validate(entity.Sexo.Trim().Length <= 1,"FieldInvalidLength","Sexo");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");
DataHelper.Validate(entity.FechaUltMod > new DateTime(1900,1,1) ,"InvalidField", "FechaUltMod");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPersona != default(int),"InvalidField", "Persona");
               
				break;
            }
        }   
		
    }	
}
