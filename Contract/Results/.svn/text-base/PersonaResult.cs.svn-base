using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PersonaResult : _PersonaResult
    {
        public string Usuario_NombreUsuario { get; set; }
        public bool Sexo_Masculino
        {
            get
            {
                return Sexo == "M";
            }
            set {
                if (value)
                    Sexo = "M";
            
            }
        }
        public bool Sexo_Femenino
        {
            get
            {
                return Sexo == "F";
            }
            set {
                if (value)
                    Sexo = "F";
            }
        }

        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("Persona", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Apellido","Apellido")
			,new DataColumnMapping("Nombre Completo","NombreCompleto")
            ,new DataColumnMapping("Of. Código","Oficina_BreadcrumbCode")
			,new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Cargo","Cargo_Nombre")
			,new DataColumnMapping("Telefono","Telefono")
			,new DataColumnMapping("Telefono Laboral","TelefonoLaboral")
			,new DataColumnMapping("Fax","Fax")
			,new DataColumnMapping("EMail Personal","EmailPersonal")
			,new DataColumnMapping("EMail Laboral","EmailLaboral")
			,new DataColumnMapping("Cargo Especifico","CargoEspecifico")
			,new DataColumnMapping("Nivel Jerarquico","NivelJerarquico")
			,new DataColumnMapping("Domicilio","Domicilio")
			,new DataColumnMapping("Cod Postal","CodPostal")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("Sexo","Sexo")
			,new DataColumnMapping("Enviar EMail","EnviarEMail")
			,new DataColumnMapping("Enviar Nota","EnviarNota")
			,new DataColumnMapping("Fecha Alta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Fecha Baja","FechaBaja","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Es Usuario","EsUsuario")
			,new DataColumnMapping("Es Contacto","EsContacto")
			,new DataColumnMapping("Activo","Activo")
			}));
        }
    }
}
