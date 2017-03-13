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
    public class PrestamoConvenioBusiness : _PrestamoConvenioBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoConvenioBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoConvenioBusiness() {}
	   public static PrestamoConvenioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoConvenioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override void Add(PrestamoConvenio entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
       }
    }
    public class PrestamoConvenioComposeBusiness : EntityComposeBusiness<PrestamoConvenioCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoConvenioComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoConvenioComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoConvenioComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion
        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }
        #region Gets

        public override PrestamoConvenioCompose GetNew(PrestamoResult example)
        {
            PrestamoConvenioCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Convenio = new PrestamoConvenioResult();
            compose.Convenio.IdPrestamo = 0;
            compose.SubConvenios = new List<PrestamoSubConvenioResult>();
            return compose;
        }
        public override PrestamoConvenioCompose GetNew()
        {
            PrestamoConvenioCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Convenio = new PrestamoConvenioResult();
            compose.Convenio.IdPrestamo = 0;
            compose.SubConvenios = new List<PrestamoSubConvenioResult>();
            return compose;
        }
        public override int GetId(PrestamoConvenioCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoConvenioCompose GetById(int id)
        {
            PrestamoConvenioCompose compose = new PrestamoConvenioCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter() { IdPrestamo = id }).FirstOrDefault();
            compose.Convenio = PrestamoConvenioBusiness.Current.GetResult(new PrestamoConvenioFilter() { IdPrestamo = id }).FirstOrDefault();
            compose.Convenio.IdPrestamo = id;
            if (compose.Convenio.IdPrestamoConvenio > 0)
                compose.SubConvenios = PrestamoSubConvenioBusiness.Current.GetResult(new PrestamoSubConvenioFilter() { IdPrestamoConvenio= compose.Convenio.IdPrestamoConvenio });

            //Matias 20140428 - Tarea 140
            compose.Financiamientos = PrestamoFinanciamientoBusiness.Current.GetResultByPrestamoId(id); 
            //PrestamoConvenioBusiness.Current.GetResult(new PrestamoConvenioFilter() { IdPrestamo = id }).SingleOrDefault();
            //FinMatias 20140428 - Tarea 140

            //Matias 20140428 - Tarea 141
            compose.Desembolsos = PrestamoDesembolsoBusiness.Current.GetResult(new PrestamoDesembolsoFilter() { IdPrestamo = id });
            //FinMatias 20140428 - Tarea 141
            
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoConvenioCompose entity, IContextUser contextUser)
        {
            try
            {

                //Crea el Convenio
                PrestamoConvenio convenio = entity.Convenio.ToEntity();
                PrestamoConvenioBusiness.Current.Add(convenio, contextUser);
                entity.Convenio.IdPrestamoConvenio = convenio.IdPrestamoConvenio;

                //Crea el SubConvenio
                foreach (PrestamoSubConvenioResult pscr in entity.SubConvenios)
                {
                    PrestamoSubConvenio psc = pscr.ToEntity();
                    psc.IdPrestamoSubConvenio = entity.Convenio.IdPrestamoConvenio;
                    PrestamoSubConvenioBusiness.Current.Add(psc, contextUser);
                }


            }
            catch (Exception exception)
            {
                entity.Convenio.IdPrestamoConvenio = 0; 
                entity.SubConvenios.ForEach(i => i.IdPrestamoConvenio = 0);

                throw exception;
            }

        }
       public override void Update(PrestamoConvenioCompose entity, IContextUser contextUser)
        {  
            try
            {
                if (entity.Convenio.IdPrestamoConvenio == 0)
                {
                    PrestamoConvenio convenio = entity.Convenio.ToEntity();
                    PrestamoConvenioBusiness.Current.Add(convenio, contextUser);
                    entity.Convenio.IdPrestamoConvenio = convenio.IdPrestamoConvenio;
                }
                else
                {
                    PrestamoConvenio prestamoConvenio = PrestamoConvenioBusiness.Current.GetById(entity.Convenio.IdPrestamoConvenio);
                    PrestamoConvenioBusiness.Current.Set(entity.Convenio, prestamoConvenio);
                    PrestamoConvenioBusiness.Current.Update(prestamoConvenio, contextUser);
                }

                //actualiza PrestamoSubConvenio

                //Elimino los que ya no forman parte
                List<int> actualIdsSubConvenio = (from o in entity.SubConvenios where o.IdPrestamoSubConvenio > 0 select o.IdPrestamoSubConvenio).ToList();
                List<PrestamoSubConvenio> oldDetailSubConvenio = PrestamoSubConvenioBusiness.Current.GetList(new PrestamoSubConvenioFilter() { IdPrestamoConvenio = entity.Convenio.IdPrestamoConvenio });
                List<PrestamoSubConvenio> deletetsSubConvenio = (from o in oldDetailSubConvenio where !actualIdsSubConvenio.Contains(o.IdPrestamoSubConvenio) select o).ToList();
                PrestamoSubConvenioBusiness.Current.Delete(deletetsSubConvenio, contextUser);

                foreach (PrestamoSubConvenioResult pscr in entity.SubConvenios)
                {
                    PrestamoSubConvenio psc = pscr.ToEntity();
                    if (pscr.IdPrestamoSubConvenio < 1)
                    {
                        //Agrego los nuevos
                        psc.IdPrestamoConvenio = entity.Convenio.IdPrestamoConvenio;
                        PrestamoSubConvenioBusiness.Current.Add(psc, contextUser);
                        pscr.IdPrestamoConvenio = psc.IdPrestamoConvenio;
                        pscr.IdPrestamoSubConvenio = psc.IdPrestamoSubConvenio;

                    }
                    else
                    {


                       PrestamoSubConvenio pscOld = PrestamoSubConvenioBusiness.Current.GetById(pscr.IdPrestamoSubConvenio);
                        if (!PrestamoSubConvenioBusiness.Current.Equals(psc, pscOld))
                        {
                            pscOld.Codigo = pscr.Codigo;
                            pscOld.Descripcion = pscr.Descripcion;
                            pscOld.IdTipoSubConvenio = pscr.IdTipoSubConvenio;
                            pscOld.Fecha = pscr.Fecha;
                            pscOld.Ejecutor = pscr.Ejecutor;
                            pscOld.Contraparte = pscr.Contraparte;
                            pscOld.MontoTotal = pscr.MontoTotal;
                            pscOld.MontoPrestamo = pscr.MontoPrestamo;
                            pscOld.Observaciones = pscr.Observaciones;
                            PrestamoSubConvenioBusiness.Current.Update(pscOld, contextUser);
                        }

                    }
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                 throw exception;
            }
        }
        public override void Delete(PrestamoConvenioCompose entity, IContextUser contextUser)
        {
            PrestamoConvenioBusiness.Current.Delete(entity.Convenio.IdPrestamoConvenio, contextUser);
        }

        #endregion
        #region Validations

        public override void Validate(PrestamoConvenioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            if (!string.IsNullOrEmpty(entity.Convenio.Sigla) && !string.IsNullOrEmpty(entity.Convenio.Numero))
            {
                List<PrestamoConvenioResult> siglas = PrestamoConvenioData.Current.GetResult(new PrestamoConvenioFilter() { Sigla = entity.Convenio.Sigla, ConSigla = true, Numero = entity.Convenio.Numero }).ToList();
                DataHelper.Validate(siglas.Count == 0 || siglas.Where(l => l.IdPrestamoConvenio != entity.Convenio.IdPrestamoConvenio).ToList().Count == 0, "El número de prestamo banacario debe ser unico por sigla.");
            }
            DataHelper.Validate(entity.Convenio.MontoTotal != 0, "FieldIsNull", "Monto Total");
            DataHelper.Validate(entity.Convenio.MontoPrestamo != 0, "FieldIsNull", "Monto Préstamo");
            DataHelper.Validate(entity.Convenio.MontoTotal >= entity.Convenio.MontoPrestamo, "El Monto del Préstamo debe ser inferior al Monto Total");

            //Matias 20140428 - Tarea 140
            decimal total = 0;
            foreach (PrestamoFinanciamientoResult f in entity.Financiamientos)
                total += f.Monto;
            DataHelper.Validate((entity.Convenio != null && entity.Convenio.MontoTotal >= total), SolutionContext.Current.TextManager.Translate("VALIDAR_PRESTAMO_MONTOTOTAL_COMPONENTES"));
            //FinMatias 20140428 - Tarea 140

            //Matias 20140428 - Tarea 141
            decimal? totalAcum = 0;
            foreach (PrestamoDesembolsoResult d in entity.Desembolsos)
                totalAcum += d.MontoAcumulado;
            DataHelper.Validate((entity.Convenio != null && entity.Convenio.MontoPrestamo >= totalAcum), SolutionContext.Current.TextManager.Translate("VALIDAR_PRESTAMO_MONTOPRESTAMO_DESESMBOLSOS"));
            //FinMatias 20140428 - Tarea 141

            //Matias 20141125 - Tarea 180
            DataHelper.Validate(entity.Convenio.IdMoneda != 0, "FieldIsNull", "Moneda");
            //FinMatias 20141125 - Tarea 180
        }

        public override bool Can(PrestamoConvenioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(PrestamoConvenioCompose source, PrestamoConvenioCompose target)
        {

            if (!source.Convenio.Equals(target.Convenio.ToEntity())) return false;

            if (source.SubConvenios.Count() != target.SubConvenios.Count()) return false;

            foreach (PrestamoSubConvenioResult pscr in source.SubConvenios)
            {
                PrestamoSubConvenioResult pscrTarget = 
                    target.SubConvenios.Where(p => p.IdPrestamoSubConvenio == pscr.IdPrestamoSubConvenio).SingleOrDefault();
                if (pscrTarget == null) return false;
                if (!PrestamoSubConvenioBusiness.Current.Equals(pscr, pscrTarget)) return false;
            }

            return true;
        }

        #endregion
    }

}
