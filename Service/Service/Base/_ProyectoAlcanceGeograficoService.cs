using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoAlcanceGeograficoService : EntityService<nc.ProyectoAlcanceGeografico,nc.ProyectoAlcanceGeograficoFilter,nc.ProyectoAlcanceGeograficoResult,int>
    {        
		protected readonly ProyectoAlcanceGeograficoBusiness Business = new ProyectoAlcanceGeograficoBusiness();
        protected override IEntityBusiness<nc.ProyectoAlcanceGeografico,nc.ProyectoAlcanceGeograficoFilter,nc.ProyectoAlcanceGeograficoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
