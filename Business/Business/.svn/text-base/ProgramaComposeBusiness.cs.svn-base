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

    public class ProgramaComposeBusiness : EntityComposeBusiness<ProgramaCompose, Programa, ProgramaFilter, ProgramaResult, int>
    {
        #region Singleton
        private static volatile ProgramaComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProgramaComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProgramaComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(ProgramaCompose entity)
        {
            return entity.IdPrograma;
        }

        public override ProgramaCompose GetById(int id)
        {
            // ProgramaCompose

            ProgramaCompose ProgramaCompose = new ProgramaCompose();

            // Programas

            ProgramaCompose.Programa =
                ProgramaBusiness.Current.GetResult(new ProgramaFilter() { IdPrograma = id }).FirstOrDefault();

            // Subprogramas

            ProgramaCompose.SubProgramas =
                SubProgramaBusiness.Current.GetResult(new SubProgramaFilter() { IdPrograma = id }).ToList();

            ProgramaCompose.IdPrograma = id;


            return ProgramaCompose;
        }

        #region Actions
        public override void Add(ProgramaCompose entity, IContextUser contextUser)
        {
            entity.Programa.FechaAlta = DateTime.Now;
            Programa programa = entity.Programa.ToEntity();
            ProgramaBusiness.Current.Add(programa, contextUser);
            entity.IdPrograma = programa.IdPrograma;
            entity.Programa.IdPrograma = entity.IdPrograma;

            

            foreach (SubProgramaResult spr in entity.SubProgramas)
            {
                spr.FechaAlta = DateTime.Now;
                spr.IdPrograma = entity.IdPrograma;
                SubProgramaBusiness.Current.Add(spr.ToEntity(), contextUser);
            }
        }
        public override void Update(ProgramaCompose entity, IContextUser contextUser)
        {

            // Actualizo los Programas

            ProgramaBusiness.Current.Update(entity.Programa.ToEntity(), contextUser);

            //obtengo los cambios al modificar el programa
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;

            // Actualizo los subprogramas

            List<int> actualSubProgramaIds = (from o in entity.SubProgramas
                                              where o.IdSubPrograma > 0
                                              select o.IdSubPrograma).ToList();

            List<SubPrograma> oldSubProgramaDetail =
                SubProgramaBusiness.Current.GetList(new SubProgramaFilter() { IdPrograma = entity.IdPrograma });
            List<int> deleteSubProgramaIds = (from o in oldSubProgramaDetail
                                              where !actualSubProgramaIds.Contains(o.IdSubPrograma)
                                              select o.IdSubPrograma).ToList();

            foreach (int id in deleteSubProgramaIds)
            {
                SubPrograma sb = SubProgramaBusiness.Current.GetById(id);
                SubProgramaBusiness.Current.Delete(sb, contextUser);
            }


            foreach (SubProgramaResult spr in entity.SubProgramas)
            {
                if (spr.IdSubPrograma < 1)
                {
                    spr.IdPrograma = entity.IdPrograma;
                    spr.FechaAlta = DateTime.Now;
                    SubPrograma subPrograma = spr.ToEntity();
                    SubProgramaBusiness.Current.Add(subPrograma, contextUser);
                    //spr.Set(subPrograma);
                    spr.IdSubPrograma = subPrograma.IdPrograma;
                    

                }
                else
                {
                    SubProgramaBusiness.Current.Update(spr.ToEntity(), contextUser);

                    //obtengo los cambios al modificar el sub programa
                    SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                }
            }

            Singletons.COUNT_CHANGES = 0;

        }

        public override ProgramaCompose GetNew()
        {
            ProgramaCompose pc = new ProgramaCompose();
            pc.Programa = new ProgramaResult();
            pc.Programa.Activo = true;
            return pc;
        }


        public override void Delete(ProgramaCompose entity, IContextUser contextUser)
        {

            entity.SubProgramas.ForEach(p => SubProgramaBusiness.Current.Delete(p.ID, contextUser));
            ProgramaBusiness.Current.Delete(entity.Programa.ID, contextUser);
            
        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<Programa, ProgramaFilter, ProgramaResult, int> EntityBusinessBase
        {
            get { return ProgramaBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(ProgramaCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            string codigo =(from o in entity.SubProgramas group o by o.Codigo into g where g.Count() > 1 select g.Key).FirstOrDefault();
            DataHelper.Validate(codigo == null || codigo == string.Empty, "Existe mas de un subprograma con el código " + codigo);
        }
        public override bool Can(ProgramaCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(ProgramaCompose source, ProgramaCompose target)
        {
            return true;
        }

    }
}
