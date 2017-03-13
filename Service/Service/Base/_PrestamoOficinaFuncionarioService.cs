using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoOficinaFuncionarioService : EntityService<nc.PrestamoOficinaFuncionario,nc.PrestamoOficinaFuncionarioFilter,nc.PrestamoOficinaFuncionarioResult,int>
    {        
		protected readonly PrestamoOficinaFuncionarioBusiness Business = new PrestamoOficinaFuncionarioBusiness();
        protected override IEntityBusiness<nc.PrestamoOficinaFuncionario,nc.PrestamoOficinaFuncionarioFilter,nc.PrestamoOficinaFuncionarioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
