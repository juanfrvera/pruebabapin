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
    public class _ClasificacionGeograficaBusiness : EntityBusiness<ClasificacionGeografica,ClasificacionGeograficaFilter,ClasificacionGeograficaResult,int>
    {        
		protected readonly ClasificacionGeograficaData Data = new ClasificacionGeograficaData();
        protected override IEntityData<ClasificacionGeografica,ClasificacionGeograficaFilter,ClasificacionGeograficaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ClasificacionGeografica() { IdClasificacionGeografica = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ClasificacionGeografica entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");
DataHelper.Validate(entity.IdClasificacionGeograficaTipo != default(int),"InvalidField", "ClasificacionGeograficaTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 4,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 60,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdClasificacionGeograficaTipo != default(int),"InvalidField", "ClasificacionGeograficaTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.ClasificacionGeograficas.Any(), "El registro no se puede eliminar porque tiene al menos una sub clasificación geografica asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.Personas.Any(), "El registro no se puede eliminar porque tiene al menos una persona asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.PrestamoAlcanceGeograficos.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.ProyectoAlcanceGeograficos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidadLocalizacions.Any(), "El registro no se puede eliminar porque tiene al menos una calidad de proyecto asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.ProyectoLocalizacions.Any(), "El registro no se puede eliminar porque tiene al menos una localizacion de proyecto asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoLocalizacions.Any(), "El registro no se puede eliminar porque tiene al menos una localizacion de seguimiento de proyecto asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.Transferencias.Any(), "El registro no se puede eliminar porque tiene al menos una transferencia asociada", "ClasificacionGeografica");
                DataHelper.ValidateForeignKey(entity.TransferenciaDetalles.Any(), "El registro no se puede eliminar porque tiene al menos un detalle de transferencia asociada", "ClasificacionGeografica");

				break;
            }
        }   
		
    }	
}
