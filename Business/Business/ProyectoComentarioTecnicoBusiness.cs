using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class ProyectoComentarioTecnicoBusiness : _ProyectoComentarioTecnicoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoComentarioTecnicoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoComentarioTecnicoBusiness() {}
	   public static ProyectoComentarioTecnicoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoComentarioTecnicoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override ProyectoComentarioTecnico GetNew(ProyectoComentarioTecnicoResult example)
       {
           ProyectoComentarioTecnico pct = new ProyectoComentarioTecnico();
            Set ( example,pct);
            return pct;
       }
       public override ProyectoComentarioTecnico GetNew()
       {
           ProyectoComentarioTecnicoResult example = new ProyectoComentarioTecnicoResult();
           example.Fecha = DateTime.Now;
           example.FechaAlta = DateTime.Now;
           return GetNew(example );
       }

       public override void Add(ProyectoComentarioTecnico entity, IContextUser contextUser)
       {
           entity.IdUsuario = contextUser.User.IdUsuario;
           base.Add(entity, contextUser);           
       }

       public override void Validate(ProyectoComentarioTecnico entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           switch (actionName)
           {
               case ActionConfig.CREATE:
               case ActionConfig.UPDATE:

                   DataHelper.Validate(entity.IdProyecto.HasValue ==true || entity.IdPrestamo.HasValue==true , "EL código es inválido");
                   if (entity.IdProyecto.HasValue)
                   {
                       Proyecto proyecto=ProyectoBusiness.Current.GetById(entity.IdProyecto.Value);
                       DataHelper.Validate(proyecto != null, "No Existe el Proyecto con el Código:{0}", entity.IdProyecto.Value.ToString());
                   }
                   if (entity.IdPrestamo.HasValue)
                   {
                       Prestamo prestamo = PrestamoBusiness.Current.GetById(entity.IdPrestamo.Value);
                       DataHelper.Validate(prestamo != null, "No Existe el Prestamo con el Código:{0}", entity.IdPrestamo.Value.ToString());
                   }
                   break;
           }
       }


       #region Actions

       public override void Update(ProyectoComentarioTecnico entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
