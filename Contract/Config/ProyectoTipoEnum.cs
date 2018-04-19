using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 

namespace Contract
{
    public enum ProyectoTipoEnum
    { 
        [Description("IRD – Inv. Real Directa")]
        IRDInvRealDirecta = 0,
        [Description("Transferencia")]
        Transferencia,
        [Description("Combinados")]
        Combinados,
        [Description("Inversiones Financieras")]
        InversionesFinancieras,
        [Description("Adelanto  a proveedores")]
        AdelantoProveedores,
        [Description("Sin gastos imputados")]
        SinGastosImputados,
        [Description("Gasto Corriente")]
        GastoCorriente,
        [Description("Indefinido")]
        Indefinido	
    }
}





