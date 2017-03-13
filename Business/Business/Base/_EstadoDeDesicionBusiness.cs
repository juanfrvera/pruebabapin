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
    public class _EstadoDeDesicionBusiness : EntityBusiness<EstadoDeDesicion,EstadoDeDesicionFilter,EstadoDeDesicionResult,int>
    {        
		protected readonly EstadoDeDesicionData Data = new EstadoDeDesicionData();
        protected override IEntityData<EstadoDeDesicion,EstadoDeDesicionFilter,EstadoDeDesicionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EstadoDeDesicion() { IdEstadoDeDesicion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EstadoDeDesicion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEstadoDeDesicion != default(int),"InvalidField", "EstadoDeDesicion");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 50,"FieldInvalidLength","Codigo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEstadoDeDesicion != default(int),"InvalidField", "EstadoDeDesicion");
                DataHelper.ValidateForeignKey(entity.EstadoDeDesicionHistoricos.Any(), "El registro no se puede eliminar porque tiene al menos un estado de desicion histórico asociado", "EstadoDeDesicion");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "EstadoDeDesicion");    

				break;
            }
        }   
		
    }	
}
