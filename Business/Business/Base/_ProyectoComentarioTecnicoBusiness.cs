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
    public class _ProyectoComentarioTecnicoBusiness : EntityBusiness<ProyectoComentarioTecnico,ProyectoComentarioTecnicoFilter,ProyectoComentarioTecnicoResult,int>
    {        
		protected readonly ProyectoComentarioTecnicoData Data = new ProyectoComentarioTecnicoData();
        protected override IEntityData<ProyectoComentarioTecnico,ProyectoComentarioTecnicoFilter,ProyectoComentarioTecnicoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoComentarioTecnico() { IdProyectoComentarioTecnico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoComentarioTecnico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoComentarioTecnico != default(int),"InvalidField", "ProyectoComentarioTecnico");
DataHelper.Validate(entity.IdComentarioTecnico != default(int),"InvalidField", "ComentarioTecnico");

                  }				
				DataHelper.Validate(entity.IdComentarioTecnico != default(int),"InvalidField", "ComentarioTecnico");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoComentarioTecnico != default(int),"InvalidField", "ProyectoComentarioTecnico");

				break;
            }
        }   
		
    }	
}
