using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoOficinaPerfilService : EntityService<nc.ProyectoOficinaPerfil,nc.ProyectoOficinaPerfilFilter,nc.ProyectoOficinaPerfilResult,int>
    {        
		protected readonly ProyectoOficinaPerfilBusiness Business = new ProyectoOficinaPerfilBusiness();
        protected override IEntityBusiness<nc.ProyectoOficinaPerfil,nc.ProyectoOficinaPerfilFilter,nc.ProyectoOficinaPerfilResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
