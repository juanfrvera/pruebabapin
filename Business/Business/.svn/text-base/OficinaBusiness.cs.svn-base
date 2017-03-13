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
    public class OficinaBusiness : _OficinaBusiness 
    {   
	   #region Singleton
	   private static volatile OficinaBusiness current;
	   private static object syncRoot = new Object();

	   //private OficinaBusiness() {}
	   public static OficinaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Oficina GetNew()
       {
           Oficina entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       public ListPaged<NodeResult> GetNodesResult(OficinaFilter filter)
       {
           return Data.GetNodesResult(filter);
       }

       #region Store Procedures
       public List<int> GetIdsOficinaPorUsuario(int IdUsuario)
       {
           return Data.GetIdsOficinaPorUsuario(IdUsuario);
       }
       public void RefreshOficina()
       {
           Data.RefreshOficina();
       }
       public void RefreshOficina(int? idOficina)
       {
           Data.RefreshOficina(idOficina);
       }

       public void ActiveCascadaOficina(int? idOficina, bool activar)
       {
           Data.ActiveCascadaOficina(idOficina, activar);
        }
       #endregion

       #region Actions
       public override void Add(Oficina entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
       }
       public override void Delete(Oficina entity, IContextUser contextUser)
       {
           Delete(entity.IdOficina, contextUser);
       }
       public override void Delete(int idOficina, IContextUser contextUser)
       {
            OficinaSafProgramaBusiness.Current.Delete(new OficinaSafProgramaFilter(){ IdOficina =  idOficina},contextUser);
            OficinaSafBusiness.Current.Delete(new OficinaSafFilter() { IdOficina = idOficina }, contextUser);
            base.Delete(idOficina, contextUser);
       }
       #endregion
    }
    public class OficinaComposeBusiness : EntityComposeBusiness<OficinaCompose, Oficina, OficinaFilter, OficinaResult, int>
    {
        #region Singleton
        private static volatile OficinaComposeBusiness current;
        private static object syncRoot = new Object();
        public static OficinaComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new OficinaComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Oficina, OficinaFilter, OficinaResult, int> EntityBusinessBase
        {
            get { return OficinaBusiness.Current; }
        }
        #region Gets
        public override OficinaCompose GetNew(OficinaResult example)
        {
            OficinaCompose compose = base.GetNew();
            compose.Oficina = example;           
            return compose;
        }
        public override OficinaCompose GetNew()
        {
            OficinaResult example = new OficinaResult();
            example.Activo = true;
            OficinaBusiness.Current.Set(OficinaBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(OficinaCompose entity)
        {
            return entity.Oficina.IdOficina;
        }
        public override OficinaCompose GetById(int id)
        {
            OficinaCompose compose = new OficinaCompose();
            compose.Oficina = OficinaBusiness.Current.GetResult(new OficinaFilter() { IdOficina = id }).FirstOrDefault();
            //busca en la base
            List<OficinaSafResult> oficinaSafs = OficinaSafBusiness.Current.GetResult(new OficinaSafFilter() { IdOficina = id });
            List<OficinaSafProgramaResult> oficinaSafProgramas = OficinaSafProgramaBusiness.Current.GetResult(new OficinaSafProgramaFilter() { IdOficina = id });
            List<Programa> programasSeleccionables = ProgramaBusiness.Current.GetList(new ProgramaFilter() { IdOficina = id }); 
            //relaciona en memoria
            foreach (OficinaSafResult oficinaSaf in oficinaSafs)
            {
                OficinaSafCompose oficinaSafCompose = new OficinaSafCompose();
                oficinaSafCompose.Saf = oficinaSaf;
                List<OficinaSafProgramaResult> programaSeleccinados = (from o in oficinaSafProgramas where o.IdOficinaSaf == oficinaSaf.IdOficinaSaf select o).ToList();
                List<OficinaSafProgramaResult> sinSeleccionar = (from o in programasSeleccionables 
                                                                 where o.IdSAF == oficinaSaf.IdSaf 
                                                                 && !(from ps in programaSeleccinados select ps.IdPrograma).Contains(o.IdPrograma)
                                                                 select ToOficinaSafPrograma(o,oficinaSaf)).ToList();

                programaSeleccinados.ForEach(p => p.Selected = true);
                oficinaSafCompose.Programas.AddRange(programaSeleccinados);
                oficinaSafCompose.Programas.AddRange(sinSeleccionar);                
                compose.Safs.Add(oficinaSafCompose);
            }
            return compose;
        }
        #endregion


        #region Actions
        public override void Add(OficinaCompose entity, IContextUser contextUser)
        {
            try
            {
                //Crea la oficina 
                Oficina oficina = entity.Oficina.ToEntity();
                OficinaBusiness.Current.Add(oficina, contextUser);
                entity.Oficina.IdOficina = oficina.IdOficina;
                //Crea Safs
                foreach (OficinaSafCompose oficinaSaf in entity.Safs)
                {
                        oficinaSaf.Saf.IdOficina = entity.Oficina.IdOficina;
                        OficinaSaf saf = oficinaSaf.Saf.ToEntity();
                        OficinaSafBusiness.Current.Add(saf, contextUser);
                        oficinaSaf.Saf.IdOficinaSaf = saf.IdOficinaSaf;

                        foreach (OficinaSafProgramaResult oficinaSafPrograma in oficinaSaf.Programas)
                        {
                            if (oficinaSafPrograma.Selected && oficinaSafPrograma.IdOficinaSafPrograma < 1)
                            {
                                OficinaSafPrograma programa = OficinaSafProgramaBusiness.Current.GetNew();
                                oficinaSafPrograma.IdOficinaSaf = oficinaSaf.Saf.IdOficinaSaf;   
                                OficinaSafProgramaBusiness.Current.Set(oficinaSafPrograma, programa);
                                OficinaSafProgramaBusiness.Current.Add(programa, contextUser);
                                oficinaSafPrograma.IdOficinaSafPrograma = programa.IdOficinaSafPrograma;
                            }
                        } 
                }
                OficinaBusiness.Current.RefreshOficina(entity.Oficina.IdOficinaPadre);
            }
            catch (Exception exception)
            {
                entity.Oficina.IdOficina = 0;
                //entity.Safs.ForEach(p => p.Saf.IdOficinaSaf = 0);
                foreach (OficinaSafCompose oficinaSaf in entity.Safs)
                {
                    oficinaSaf.Saf.IdOficinaSaf = 0;
                    oficinaSaf.Programas.ForEach(p => p.IdOficinaSafPrograma = 0);
                }
                throw exception;
            }
                   
                
               
        }
        public override void Update(OficinaCompose entity, IContextUser contextUser)
        {
            //OficinaSafCompose copySaf = OficinaSafBusiness.Current.Copies(entity.ToSafResult, contextUser);
            try
            {
                Oficina oficina = OficinaBusiness.Current.GetById(entity.Oficina.IdOficina);
                if ((!entity.Oficina.Activo) && oficina.Activo)
                {
                    OficinaBusiness.Current.ActiveCascadaOficina(entity.Oficina.IdOficina, false);
                }
                OficinaBusiness.Current.Set(entity.Oficina, oficina);
                OficinaBusiness.Current.Update(oficina, contextUser);                
                //Elimino los safs que ya no forman parte
                List<int> actualIds = (from o in entity.Safs where o.Saf.IdOficinaSaf > 0 select o.Saf.IdOficinaSaf).ToList();
                List<OficinaSaf> oldDetail = OficinaSafBusiness.Current.GetList(new OficinaSafFilter() { IdOficina = entity.Oficina.IdOficina });
                List<OficinaSaf> deletets = (from o in oldDetail where !actualIds.Contains(o.IdOficinaSaf) select o).ToList();
                List<int> deletetsIds = (from o in oldDetail where !actualIds.Contains(o.IdOficinaSaf) select o.IdOficinaSaf).ToList();
                OficinaSafBusiness.Current.Delete(deletetsIds.ToArray(),contextUser);                
                //Edito los Saf seleccionados
                foreach (OficinaSafCompose oficinaSaf in entity.Safs)
                {
                    if (!deletetsIds.Contains(oficinaSaf.Saf.IdOficinaSaf))
                    {
                        if (oficinaSaf.Saf.IdOficinaSaf < 1)
                        {
                            oficinaSaf.Saf.IdOficina = entity.Oficina.IdOficina;
                            OficinaSaf saf = oficinaSaf.Saf.ToEntity();
                            OficinaSafBusiness.Current.Add(saf, contextUser);
                            oficinaSaf.Saf.IdOficinaSaf = saf.IdOficinaSaf;
                        }
                        foreach (OficinaSafProgramaResult oficinaSafPrograma in oficinaSaf.Programas)
                        {
                            if (oficinaSafPrograma.Selected && oficinaSafPrograma.IdOficinaSafPrograma < 1)
                            {
                                OficinaSafPrograma programa = OficinaSafProgramaBusiness.Current.GetNew();
                                oficinaSafPrograma.IdOficinaSaf = oficinaSaf.Saf.IdOficinaSaf;                                
                                OficinaSafProgramaBusiness.Current.Set(oficinaSafPrograma, programa);
                                OficinaSafProgramaBusiness.Current.Add(programa, contextUser);
                                oficinaSafPrograma.IdOficinaSafPrograma = programa.IdOficinaSafPrograma;
                            }
                            if (!oficinaSafPrograma.Selected && oficinaSafPrograma.IdOficinaSafPrograma > 1)
                            {
                                OficinaSafProgramaBusiness.Current.Delete(oficinaSafPrograma.IdOficinaSafPrograma, contextUser);
                            }
                        }
                    }  
                }
                OficinaBusiness.Current.RefreshOficina(entity.Oficina.IdOficinaPadre);
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                //entity.Safs = copySaf;
                throw exception;
            } 
        }
        
        public override void Delete(OficinaCompose entity, IContextUser contextUser)
        {
            OficinaBusiness.Current.Delete(entity.Oficina.IdOficina, contextUser);
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(OficinaCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            if (entity.Oficina.IdOficinaPadre != null)
            {
                DataHelper.Validate((entity.Oficina.Activo) ? OficinaBusiness.Current.GetList(new OficinaFilter() { IdOficina = entity.Oficina.IdOficinaPadre }).FirstOrDefault().Activo : true, "Para activar la Oficina Actual, la Oficina Padre debe estar activa");
            }
        }

        #endregion

        #region ToOficinaSafPrograma
        public List<OficinaSafProgramaResult> GetNewsOficinaSafPrograma(ProgramaFilter filter)
        {
            List<Programa> programas = ProgramaBusiness.Current.GetList(filter);
            return (from o in programas
                    select ToOficinaSafPrograma(o)).ToList();
        }
        public OficinaSafProgramaResult ToOficinaSafPrograma(Programa programa)
        {
            return ToOficinaSafPrograma(programa,0);
        }
        public OficinaSafProgramaResult ToOficinaSafPrograma(Programa programa, OficinaSafResult oficinaSaf)
        {
           return ToOficinaSafPrograma(programa, oficinaSaf.IdOficinaSaf);
        }
        public OficinaSafProgramaResult ToOficinaSafPrograma(Programa programa, int IdOficinaSaf)
        {
            OficinaSafProgramaResult result = new OficinaSafProgramaResult();
            result.IdOficinaSaf = IdOficinaSaf;
            result.IdPrograma = programa.IdPrograma;
            result.Programa_Activo = programa.Activo;
            result.Programa_Nombre = programa.Nombre;
            result.Programa_Codigo = programa.Codigo;
            return result;
        }       
        #endregion
    }
}
