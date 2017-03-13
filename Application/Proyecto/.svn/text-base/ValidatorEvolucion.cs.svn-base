using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;


namespace UI.Web.Pages
{
    public static class ValidatorEvolucion
    {

        public static bool ValidateEvoluciones(List<IndicadorEvolucionResult> Evoluciones, out string msgError)
        {
            //msgError = "- " + UIHelper.Translate("Por cada región geográfica debe existir obligatoriamente una evolución base, al menos una intermedia y una sola final."); //Matias 20141104 - Tarea 167 - Nuevo mensaje!
            //msgError = " ";
            
            var tabla =
                        from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            CantBase = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Base),
                            CantIntermedio = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio),
                            CantFinal = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Final)
                        };


            foreach (var linea in tabla)
            {
                // Valdio que en casa región geográfica deba exisitir obligatoriamente una evolución base, y al menos una intermedia o una sola final.
                //Matias 20170213 - Ticket #ER782828
                //if (!((linea.CantBase == 1) && ((linea.CantIntermedio >= 1 && linea.CantFinal <= 1) || (linea.CantFinal == 1))))
                //{
                //    return false;
                //}
                if ( linea.CantBase != 1 || linea.CantFinal != 1 )
                {
                    msgError = UIHelper.Translate("Por cada región geográfica debe existir una única evolución Base y Final (y 0 o mas Intermedios).");
                    return false;
                }
                //FinMatias 20170213 - Ticket #ER782828                
            }

            //msgError = "- " + UIHelper.Translate("Por cada región geográfica debe existir solamente una evolución por fecha y el orden correcto es 1-Base, 2-Intermedias, 3-Final.");

            var tabla2 =
                        from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            MonthGroups =
                                from o in evolucionGroup
                                group o by o.FechaEstimada into mg
                                select new { Fecha = mg.Key, 
                                Cantidad = mg.Count() }
                        };

            foreach (var linea2 in tabla2)
            {
                if (linea2.MonthGroups.Count(p => p.Cantidad > 1) > 0)
                {
                    msgError = UIHelper.Translate("Por cada región geográfica debe existir solamente una evolución por fecha.");
                    return false;
                }
            }


            var tabla3 =
                        from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            MonthGroups =
                                from o in evolucionGroup orderby o.FechaEstimada
                                select new
                                {
                                    Fecha = o.FechaEstimada, Instancia = o.IdIndicadorEvolucionInstancia
                                }
                        };

            foreach (var linea3 in tabla3)
            {
                if (linea3.MonthGroups.First().Instancia != (int)IndicadorEvolucionInstanciaEnum.Base)
                {
                    msgError = UIHelper.Translate("La primer evolución, por cada región geográfica, debe ser del tipo Base.");
                    return false;
                }

                if (linea3.MonthGroups.Count(i => i.Instancia == (int)IndicadorEvolucionInstanciaEnum.Final) > 0
                    && linea3.MonthGroups.Last().Instancia != (int)IndicadorEvolucionInstanciaEnum.Final)
                {
                    msgError = UIHelper.Translate("La última evolución, por cada región geográfica, debe ser del tipo Final.");
                    return false;
                }                

            }

            msgError = string.Empty;
            return true;

        }

    }
}