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
    public class ProyectoDictamenBusiness : _ProyectoDictamenBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoDictamenBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenBusiness() {}
	   public static ProyectoDictamenBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ProyectoDictamen GetNew(ProyectoDictamenResult example)
       {
           ProyectoDictamen pd = new ProyectoDictamen();
           Set(example, pd);
           return pd;
       }
       public override ProyectoDictamen GetNew()
       {
           ProyectoDictamenResult example = new ProyectoDictamenResult();
           example.Fecha = DateTime.Now;
           example.FechaEstado = DateTime.Now;
           
           return GetNew(example);
       }
       public virtual List<Usuario> GetFuncionarios(ProyectoDictamenFilter filter)
       {
           return Data.GetFuncionarios(filter);
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           ProyectoDictamenSeguimientoBusiness.Current.Delete(ProyectoDictamenSeguimientoBusiness.Current.GetList ( new ProyectoDictamenSeguimientoFilter(){IdProyectoDictamen = id }), contextUser);
           base.Delete(id, contextUser);
       }
       public override ReportInfo GetReport(SistemaReporte reporte, ProyectoDictamenFilter filter)
       {
           ReportInfo reportInfo = new ReportInfo();
           reportInfo.ReportFileName = reporte.FileName;
           reportInfo.Title = reporte.Nombre;

           switch (reporte.Codigo)
           {
               case "ProyectoDictamen":
                   Imprimir(reportInfo, filter);
                   break;
           }
           return reportInfo;
       }
       private void Imprimir(ReportInfo reportInfo, ProyectoDictamenFilter  filter)
       {
           Int32 IdProyectoDictamen = filter.IdProyectoDictamen.Value  ;
           //List<ProyectoDictamenResult> proyecto = GetResult(new ProyectoDictamenFilter() { IdProyectoDictamen = IdProyectoDictamen });
           List<ProyectoDictamenResult> proyecto = GetListReporte(new ProyectoDictamenFilter() { IdProyectoDictamen = IdProyectoDictamen });
           //List<ProyectoSeguimientoProyectoResult> proyectoSeguimientoProyecto = ProyectoSeguimientoProyectoBusiness.Current.ProyectoSeguimientoConProvincias(new ProyectoSeguimientoProyectoFilter() { IdProyectoDictamen = IdProyectoDictamen });
           reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoDictamenResult", proyecto));
           //reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoSeguimientoProyectoResult", proyectoSeguimientoProyecto));
           String Resolucion = SolutionContext.Current.ParameterManager.GetTextValue("DICTAMEN_RESOLUCION");
           reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Resolucion", Value = Resolucion });
           //incorporar estos PARAMETROS PARA PODER IMPRIMIR ESOS VALORES AL PIE DE PAGINA
           string Numero = null;
           if (( proyecto.Count != 0) &&  ( proyecto.First() != null) && ( proyecto.First().Numero != null) )
                     Numero =proyecto.First().Numero.ToString();
           reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Numero", Value = Numero});
           reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Secuencia", Value = IdProyectoDictamen.ToString() });

       }


       private List<ProyectoDictamenResult> GetListReporte(ProyectoDictamenFilter filter)
       {
           return ProyectoDictamenData.Current.QueryResultReporte (filter);
       }

       public override void Update(ProyectoDictamen entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

    }


    
    public class DictamenComposeBusiness : EntityComposeBusiness<DictamenCompose, ProyectoDictamen , ProyectoDictamenFilter, ProyectoDictamenResult, int>
    {
        #region Singleton
        private static volatile DictamenComposeBusiness current;
        private static object syncRoot = new Object();
        public static DictamenComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new DictamenComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion


        protected override EntityBusiness<ProyectoDictamen, ProyectoDictamenFilter, ProyectoDictamenResult, int> EntityBusinessBase
        {
            get { return ProyectoDictamenBusiness.Current; }
        }

        #region Gets
        public override DictamenCompose GetNew(ProyectoDictamenResult example)
        {
            DictamenCompose compose = base.GetNew();
            compose.ProyectoDictamen = new ProyectoDictamenResult();
            compose.proyectoDictamenSeguimiento = new List<ProyectoDictamenSeguimientoResult>();
            compose.proyectoSeguimiento = new List<ProyectoSeguimientoResult>();
            return compose;
        }
        public override DictamenCompose GetNew()
        {
            ProyectoDictamenResult example = new ProyectoDictamenResult();
            ProyectoDictamenBusiness.Current.Set(ProyectoDictamenBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(DictamenCompose entity)
        {
            return entity.ProyectoDictamen.IdProyectoDictamen;
        }
        public override DictamenCompose GetById(int id)
        {
            DictamenCompose compose = new DictamenCompose();
            compose.ProyectoDictamen = ProyectoDictamenBusiness.Current.GetResult(new ProyectoDictamenFilter() { IdProyectoDictamen = id }).SingleOrDefault();
            compose.ProyectoDictamenEstado = ProyectoDictamenEstadoBusiness.Current.GetResult(new ProyectoDictamenEstadoFilter() { IdProyectoDictamen = id }).OrderByDescending(i => i.Fecha).ToList();
            compose.proyectoDictamenSeguimiento = ProyectoDictamenSeguimientoBusiness.Current.GetResult(new ProyectoDictamenSeguimientoFilter() { IdProyectoDictamen = id });
            compose.proyectoSeguimiento = ProyectoSeguimientoBusiness.Current.GetResult(new ProyectoSeguimientoFilter() { IdProyectoDictamen = id });
            compose.ProyectoDictamenFile = ProyectoDictamenFileBusiness.Current.GetResult(new ProyectoDictamenFileFilter() { IdProyectoDictamen = id });

            return compose;
        }
        public List<DictamenCompose> GetList(int id)
        {
            List<DictamenCompose> ListCompose = new List<DictamenCompose>();
            DictamenCompose compose = new DictamenCompose();
            
            List<ProyectoDictamenResult>  dictamen = new List<ProyectoDictamenResult> ();
            List<ProyectoDictamenEstadoResult> proyectoDictamenEstado = new List<ProyectoDictamenEstadoResult>();
            List<ProyectoDictamenSeguimientoResult> proyectoDictamenSeguimiento = new List<ProyectoDictamenSeguimientoResult> ();
            List<ProyectoSeguimientoResult> proyectoSeguimiento = new List<ProyectoSeguimientoResult>();
            //List<ProyectoSeguimientoEstadoResult> proyectoSeguimientoEstado = new List<ProyectoSeguimientoEstadoResult>();
            //List<ProyectoSeguimientoLocalizacionResult> proyectoSeguimientoLocalizacion = new List<ProyectoSeguimientoLocalizacionResult>();
            //List<ProyectoSeguimientoProyectoResult> proyectoSeguimientoProyecto = new List<ProyectoSeguimientoProyectoResult>();

            dictamen = ProyectoDictamenBusiness.Current.GetResult(new ProyectoDictamenFilter() { IdProyecto = id });
            proyectoDictamenEstado = ProyectoDictamenEstadoBusiness.Current.GetResult(new ProyectoDictamenEstadoFilter() { IdProyecto = id });
            proyectoDictamenSeguimiento = ProyectoDictamenSeguimientoBusiness.Current.GetResult(new ProyectoDictamenSeguimientoFilter() { IdProyecto = id });
            proyectoSeguimiento = ProyectoSeguimientoBusiness.Current.GetResult(new ProyectoSeguimientoFilter() { IdProyecto = id });
            //proyectoSeguimientoEstado = ProyectoSeguimientoEstadoBusiness.Current.GetResult(new ProyectoSeguimientoEstadoFilter() { IdProyecto = id });
            //proyectoSeguimientoLocalizacion = ProyectoSeguimientoLocalizacionBusiness.Current.GetResult(new ProyectoSeguimientoLocalizacionFilter() { IdProyecto = id });
            //proyectoSeguimientoProyecto = ProyectoSeguimientoProyectoBusiness.Current.GetResult(new ProyectoSeguimientoProyectoFilter() { IdProyecto = id });

            foreach (ProyectoDictamenResult pdr in dictamen)
            {
                compose.ProyectoDictamen = dictamen.Where(i => i.IdProyectoDictamen == pdr.IdProyectoDictamen).SingleOrDefault();
                compose.ProyectoDictamenEstado = proyectoDictamenEstado.Where(i => i.IdProyectoDictamen == pdr.IdProyectoDictamen).ToList();
                compose.proyectoDictamenSeguimiento = proyectoDictamenSeguimiento.Where(i => i.IdProyectoDictamen == pdr.IdProyectoDictamen).ToList ();
                compose.proyectoSeguimiento = (
                                                    from  ps in proyectoSeguimiento 
                                                    where compose.proyectoDictamenSeguimiento.Select (i=>i.IdProyectoSeguimiento ).Contains ( ps.IdProyectoSeguimiento ) 
                                                    select ps
                                                ).ToList ();
                //compose.proyectoSeguimientoProyecto = (
                //                                    from psp in proyectoSeguimientoProyecto 
                //                                    where compose.proyectoDictamenSeguimiento.Select(i => i.IdProyectoSeguimiento).Contains(psp.IdProyectoSeguimiento )
                //                                    select psp
                //                                ).ToList();
                //compose.proyectoSeguimientoLocalizacion = (
                //                                    from psl in proyectoSeguimientoLocalizacion
                //                                    where compose.proyectoSeguimiento.Select(i => i.IdProyectoSeguimiento).Contains(psl.IdProyectoSeguimiento)
                //                                    select psl
                //                                ).ToList();

                //compose.proyectoSeguimientoEstado = (
                //                                    from pse in proyectoSeguimientoEstado
                //                                    where compose.proyectoSeguimiento.Select(i => i.IdProyectoSeguimiento).Contains(pse.IdProyectoSeguimiento )
                //                                    select pse
                //                                ).ToList();

                ListCompose.Add(compose);
            }
 
            return ListCompose ;
        }

       
        #endregion

        #region Actions
        public override void Add(DictamenCompose entity, IContextUser contextUser)
        {
            //Crea el Dictamen
            entity.ProyectoDictamen.FechaEstado = DateTime.Now;
            ProyectoDictamen dictamen = entity.ProyectoDictamen.ToEntity();
            ProyectoDictamenBusiness.Current.Add(dictamen , contextUser);
            entity.ProyectoDictamen.IdProyectoDictamen = dictamen.IdProyectoDictamen;

            foreach (ProyectoSeguimientoResult psr in entity.proyectoSeguimiento)
            {
                ProyectoDictamenSeguimiento pds = new ProyectoDictamenSeguimiento();
                pds.IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen;
                pds.IdProyectoSeguimiento = psr.IdProyectoSeguimiento;
                ProyectoDictamenSeguimientoBusiness.Current.Add(pds, contextUser);
            }

            foreach (ProyectoDictamenEstadoResult pder in entity.ProyectoDictamenEstado)
            {
                pder.IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen;
                ProyectoDictamenEstado pde = pder.ToEntity();
                ProyectoDictamenEstadoBusiness.Current.Add(pde, contextUser);
                pder.IdProyectoDictamenEstado = pde.IdProyectoDictamenEstado;

            }

            if (entity.ProyectoDictamenEstado.Count() > 0)
            {
                if (!entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo.HasValue)
                {
                    //entity.ProyectoDictamenEstado.OrderByDescending(i => i.Fecha);
                    entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo = entity.ProyectoDictamenEstado.Last().IdProyectoDictamenEstado;
                    dictamen.IdProyectoDictamenEstadoUltimo = entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo;
                    ProyectoDictamenBusiness.Current.Update(dictamen, contextUser);
                }

            }

        }
        public override void Update(DictamenCompose entity, IContextUser contextUser)
        {
            ProyectoDictamenResult proyectoDictamen = ProyectoDictamenBusiness.Current.GetResult(new ProyectoDictamenFilter() { IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen }).SingleOrDefault ();
            if (entity.ProyectoDictamen.IdUltimoEstado != proyectoDictamen.IdUltimoEstado && entity.ProyectoDictamen.IdUltimoEstado == (int)EstadoEnum.Terminado)
            {//Si el estado del dictamen pasa a ser terminado
                SendMessageDictamenTerminado(entity.ProyectoDictamen.ToEntity(), contextUser);
            }
            ProyectoDictamenBusiness.Current.Set(entity.ProyectoDictamen, proyectoDictamen);
            ProyectoDictamenBusiness.Current.Update(proyectoDictamen.ToEntity (), contextUser);

            //actualiza ProyectoDemora

            //Elimino los que ya no forman parte
            List<int> actualIds = (from o in entity.proyectoSeguimiento where o.IdProyectoSeguimiento > 0 select o.IdProyectoSeguimiento).ToList();
            List<ProyectoDictamenSeguimiento> oldDetail = ProyectoDictamenSeguimientoBusiness.Current.GetList(new ProyectoDictamenSeguimientoFilter() { IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen });
            List<ProyectoDictamenSeguimiento> deletets = (from o in oldDetail where !actualIds.Contains(o.IdProyectoSeguimiento) select o).ToList();
            ProyectoDictamenSeguimientoBusiness.Current.Delete(deletets, contextUser);

            List<ProyectoSeguimientoResult> psrl = (from o in entity.proyectoSeguimiento
                                            where !entity.proyectoDictamenSeguimiento.Select (i=>i.IdProyectoSeguimiento).ToList ().Contains( o.IdProyectoSeguimiento)
                                            select o                                      
                                            ).ToList ();
            foreach (ProyectoSeguimientoResult psr in psrl)
            {
                ProyectoDictamenSeguimiento pds = new ProyectoDictamenSeguimiento();
                pds.IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen;
                pds.IdProyectoSeguimiento = psr.IdProyectoSeguimiento;
                ProyectoDictamenSeguimientoBusiness.Current.Add(pds, contextUser);
            }


            //Elimino los que ya no forman parte
            List<int> actualIdsDictamenEstado = (from o in entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado > 0 select o.IdProyectoDictamenEstado).ToList();
            List<ProyectoDictamenEstado> oldDetailDictamenEstado = ProyectoDictamenEstadoBusiness.Current.GetList(new ProyectoDictamenEstadoFilter() { IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen });
            List<ProyectoDictamenEstado> deletetsDictamenEstado = (from o in oldDetailDictamenEstado where !actualIdsDictamenEstado.Contains(o.IdProyectoDictamenEstado) select o).ToList();
            if ((from o in deletetsDictamenEstado
                 where o.IdProyectoDictamenEstado == entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo
                 select o
                     ).Count() > 0)
            {
                ProyectoDictamenEstadoResult se = entity.ProyectoDictamenEstado.LastOrDefault();
                proyectoDictamen.IdProyectoDictamenEstadoUltimo = (int?)(se != null ? se.IdProyectoDictamenEstado : null as int?);
                ProyectoDictamenBusiness.Current.Update(proyectoDictamen.ToEntity (), contextUser);
            }

            ProyectoDictamenEstadoBusiness.Current.Delete(deletetsDictamenEstado, contextUser);


            foreach (ProyectoDictamenEstadoResult pser in entity.ProyectoDictamenEstado)
            {

                if (pser.IdProyectoDictamenEstado < 1)
                {
                    //Agrego los nuevos
                    pser.IdProyectoDictamen = entity.ProyectoDictamen.IdProyectoDictamen;
                    ProyectoDictamenEstado pse = pser.ToEntity();
                    ProyectoDictamenEstadoBusiness.Current.Add(pse, contextUser);
                    pser.IdProyectoDictamenEstado = pse.IdProyectoDictamenEstado;
                }
                else
                {
                    ProyectoDictamenEstado pse = ProyectoDictamenEstadoBusiness.Current.GetById(pser.IdProyectoDictamenEstado);
                    ProyectoDictamenEstadoBusiness.Current.Set(pser, pse);
                    ProyectoDictamenEstadoBusiness.Current.Update(pse, contextUser);
                }

            }
            if (entity.ProyectoDictamenEstado.Count() > 0)
            {
                if (!entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo.HasValue)
                {
                    //entity.ProyectoDictamenEstado.OrderByDescending(i => i.Fecha);
                    entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo = entity.ProyectoDictamenEstado.Last().IdProyectoDictamenEstado;
                    proyectoDictamen.IdProyectoDictamenEstadoUltimo = entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo;
                    ProyectoDictamenBusiness.Current.Update(proyectoDictamen.ToEntity (), contextUser);
                }

            }

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }
        public override void Delete(DictamenCompose entity, IContextUser contextUser)
        {
            ProyectoBusiness.Current.Delete(entity.ProyectoDictamen.IdProyectoDictamen, contextUser);
        }
        #endregion

        #region Mesajes
        public void SendMessageDictamenTerminado(ProyectoDictamen dictamen,IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            try
            {
                if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgDictamenTerminadoActive") == false) return;

                List<Usuario> funcionarios = ProyectoDictamenBusiness.Current.GetFuncionarios(new ProyectoDictamenFilter() { IdProyectoDictamen = dictamen.IdProyectoDictamen });
                if (funcionarios == null || funcionarios.Count == 0) return;
                int[] IdsFuncionarios = (from o in funcionarios select o.IdUsuario).ToArray();
                string textMessage = Translate("MsgDictamenTerminado", contextUser);
                string body = string.Format(textMessage, dictamen.Numero,dictamen.Fecha);
                SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, IdsFuncionarios, "Dictamen", body,null, contextUser);
            }
            catch (Exception exception)
            { }
        } 
        #endregion

        #region Validations
        public override void Validate(DictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            DataHelper.Validate(entity.proyectoSeguimiento.Count > 0, "Debe Asociar una Evaluación de Factibilidad");
            DataHelper.Validate(entity.ProyectoDictamenEstado.Count > 0, "Debe Asignar un Estado al Dictamen");
           
        }
        public override bool Can(DictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoDictamenBusiness.Current.Can(ProyectoDictamenBusiness.Current.ToEntity(entity.ProyectoDictamen), actionName, contextUser, args);
        }
        public override bool Equals(DictamenCompose source, DictamenCompose target)
        {
            bool eq = ProyectoDictamenBusiness.Current.Equals(source.ProyectoDictamen, target.ProyectoDictamen);
            if (eq)
            {
                if (source.proyectoSeguimiento.Count() != target.proyectoSeguimiento.Count()) return false;
                bool eqSet = true;
                foreach (ProyectoSeguimientoResult  ps in source.proyectoSeguimiento)
                {
                    ProyectoSeguimientoResult pserTarget = target.proyectoSeguimiento.Where(p => p.IdProyectoSeguimiento == ps.IdProyectoSeguimiento).SingleOrDefault();
                    if (pserTarget == null) return false;
                    eqSet = ProyectoSeguimientoBusiness.Current.Equals (ps,pserTarget);
                }
                if (!eqSet) return eqSet;
                eqSet = true ;

                foreach (ProyectoDictamenEstadoResult pser in source.ProyectoDictamenEstado)
                {
                    ProyectoDictamenEstadoResult pserTarget = target.ProyectoDictamenEstado.Where(p => p.IdProyectoDictamenEstado == pser.IdProyectoDictamenEstado).SingleOrDefault();
                    eqSet = eqSet && ProyectoDictamenEstadoBusiness.Current.Equals(pser, pserTarget);

                }
                if (!eqSet) return eqSet;
            }
            return eq;
        }
        #endregion

    }
    
}
