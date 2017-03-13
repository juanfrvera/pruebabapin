using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public enum OrganismoTipoEnum
    {
          Undefined             = 0
        , ExtraPresupuestario   = 4
        , Presupuestario        = 1
        , Provincial            = 6
    }

    public class OrganismoTipoConfig
    {
        public const string EXTRAPRESUPUESTARIO = "ExtraPresupuestario";
        public const string PRESUPUESTARIO = "Presupuestario";
        public const string PROVINCIAL = "Provincial";

        public static string GetConst(OrganismoTipoEnum action)
        {
            switch (action)
            {
                case OrganismoTipoEnum.ExtraPresupuestario: return EXTRAPRESUPUESTARIO;
                case OrganismoTipoEnum.Presupuestario: return PRESUPUESTARIO;
                case OrganismoTipoEnum.Provincial: return PROVINCIAL;
            }
            return "";
        }
        public static OrganismoTipoEnum GetEnum(string action)
        {
            switch (action)
            {
                case EXTRAPRESUPUESTARIO: return OrganismoTipoEnum.ExtraPresupuestario;
                case PRESUPUESTARIO: return OrganismoTipoEnum.Presupuestario;
                case PROVINCIAL: return OrganismoTipoEnum.Provincial;
            }
            return OrganismoTipoEnum.Undefined;
        }
    }
}
