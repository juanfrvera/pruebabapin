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
    public class _ProyectoBusiness : EntityBusiness<Proyecto,ProyectoFilter,ProyectoResult,int>
    {        
		protected readonly ProyectoData Data = new ProyectoData();
        protected override IEntityData<Proyecto,ProyectoFilter,ProyectoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Proyecto() { IdProyecto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Proyecto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);

            switch (actionName)
            { 
                case ActionConfig.CREATE:

				case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
                        DataHelper.Validate(entity.IdTipoProyecto != default(int),"InvalidField", "TipoProyecto");
                        DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
                        DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
                    }
                    DataHelper.Validate(entity.IdTipoProyecto != default(int),"InvalidField", "TipoProyecto");
                    DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
                    DataHelper.Validate(entity.ProyectoDenominacion!=null,"FieldIsNull","ProyectoDenominacion");
                    DataHelper.Validate(entity.ProyectoDenominacion.Trim().Length <= 500,"FieldInvalidLength","ProyectoDenominacion");
                    DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
                    DataHelper.Validate(entity.FechaAlta > new DateTime(1900,1,1) ,"InvalidField", "FechaAlta");
                    DataHelper.Validate(entity.FechaModificacion > new DateTime(1900,1,1) ,"InvalidField", "FechaModificacion");

                    //Matias 20170125 - Ticket #ER311422
                    //Valido que los datos para TipoProyecto y Proceso esten ACTIVOS.
                    ProyectoTipo pt = ProyectoTipoBusiness.Current.GetById(entity.IdTipoProyecto);
                    if (pt != null) 
                        DataHelper.Validate(pt.Activo != false, "InvalidField", "TipoProyecto");
                    Proceso proc = ProcesoBusiness.Current.GetById(entity.IdProceso.GetValueOrDefault());
                    if (proc != null) 
                        DataHelper.Validate(proc.Activo != false, "InvalidField", "Proceso");
                    //FinMatias 20170125 - Ticket #ER311422

                    break;				

				case ActionConfig.READ:

				case ActionConfig.DELETE:
				    DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
                    
                    break;
            }
        }   
		
    }	
}
