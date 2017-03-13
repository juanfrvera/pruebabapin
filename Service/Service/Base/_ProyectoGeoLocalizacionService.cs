using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoGeoLocalizacionService : EntityService<nc.ProyectoGeoLocalizacion, nc.ProyectoGeoLocalizacionFilter, nc.ProyectoGeoLocalizacionResult, int>
    {

        protected readonly ProyectoGeoLocalizacionBusiness Business = new ProyectoGeoLocalizacionBusiness();

        protected override IEntityBusiness<nc.ProyectoGeoLocalizacion, nc.ProyectoGeoLocalizacionFilter, nc.ProyectoGeoLocalizacionResult, int> EntityBusiness
        {
            get { return this.Business; }
        } 
    }
}
