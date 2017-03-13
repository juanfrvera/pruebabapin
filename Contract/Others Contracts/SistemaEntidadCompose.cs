﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{   
    [Serializable]
    public class SistemaEntidadCompose
    {
        public SistemaEntidadResult Entidad { get; set; }
        public List<SistemaEntidadEstadoResult> Estados { get; set; }
        public List<SistemaEntidadAccionResult> Acciones { get; set; }
    }
}
