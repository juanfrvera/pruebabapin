using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 

namespace Contract
{
    public enum ProyectoTipoEnum
    { 
        [Description("Inv. Real Directa")]
        InvRealDirecta = 10,
        [Description("Transferencia")]
        Transferencia = 11,
        [Description("Combiados")]
        Combinados = 12,
        [Description("Inversiones Financieras")]
        InversionesFinancieras = 15,
        [Description("Adelanto  a proveedores")]
        AdelantoProveedores = 16,
        [Description("Sin gastos imputados")]
        SinGastosImputados = 17,
        [Description("Gasto Corriente")]
        GastoCorriente = 18,
        [Description("Indefinido")]
        Indefinido = 19,
    }
}





