using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PersonaData : _PersonaData
    {
	   #region Singleton
	   private static volatile PersonaData current;
	   private static object syncRoot = new Object();

	   //private PersonaData() {}
	   public static PersonaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PersonaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPersona"; } }
       #region Query
       
       protected override IQueryable<Persona> Query(PersonaFilter filter)
       {
           string strIdParent = filter.IdOficina.HasValue ? "." + filter.IdOficina.Value.ToString() + "." : string.Empty;

           return (from o in this.Table
                   where (filter.IdPersona == null || filter.IdPersona == 0 || o.IdPersona == filter.IdPersona)
                   && (filter.EsUsuario == null || o.EsUsuario == filter.EsUsuario)
                   && (filter.EsContacto == null || o.EsContacto == filter.EsContacto)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.Apellido == null || filter.Apellido.Trim() == string.Empty || filter.Apellido.Trim() == "%" || (filter.Apellido.EndsWith("%") && filter.Apellido.StartsWith("%") && (o.Apellido.Contains(filter.Apellido.Replace("%", "")))) || (filter.Apellido.EndsWith("%") && o.Apellido.StartsWith(filter.Apellido.Replace("%", ""))) || (filter.Apellido.StartsWith("%") && o.Apellido.EndsWith(filter.Apellido.Replace("%", ""))) || o.Apellido == filter.Apellido)
                   && (filter.NombreCompleto == null || filter.NombreCompleto.Trim() == string.Empty || filter.NombreCompleto.Trim() == "%" || (filter.NombreCompleto.EndsWith("%") && filter.NombreCompleto.StartsWith("%") && (o.NombreCompleto.Contains(filter.NombreCompleto.Replace("%", "")))) || (filter.NombreCompleto.EndsWith("%") && o.NombreCompleto.StartsWith(filter.NombreCompleto.Replace("%", ""))) || (filter.NombreCompleto.StartsWith("%") && o.NombreCompleto.EndsWith(filter.NombreCompleto.Replace("%", ""))) || o.NombreCompleto == filter.NombreCompleto)
                   && (filter.IdOficina == null || filter.IdOficina == 0 || filter.IncluirOficinasInteriores == true || o.IdOficina == filter.IdOficina)
                   && (filter.IdCargo == null || filter.IdCargo == 0 || o.IdCargo == filter.IdCargo)
                   && (filter.IdCargoIsNull == null || filter.IdCargoIsNull == true || o.IdCargo != null) && (filter.IdCargoIsNull == null || filter.IdCargoIsNull == false || o.IdCargo == null)
                   && (filter.Telefono == null || filter.Telefono.Trim() == string.Empty || filter.Telefono.Trim() == "%" || (filter.Telefono.EndsWith("%") && filter.Telefono.StartsWith("%") && (o.Telefono.Contains(filter.Telefono.Replace("%", "")))) || (filter.Telefono.EndsWith("%") && o.Telefono.StartsWith(filter.Telefono.Replace("%", ""))) || (filter.Telefono.StartsWith("%") && o.Telefono.EndsWith(filter.Telefono.Replace("%", ""))) || o.Telefono == filter.Telefono)
                   && (filter.TelefonoLaboral == null || filter.TelefonoLaboral.Trim() == string.Empty || filter.TelefonoLaboral.Trim() == "%" || (filter.TelefonoLaboral.EndsWith("%") && filter.TelefonoLaboral.StartsWith("%") && (o.TelefonoLaboral.Contains(filter.TelefonoLaboral.Replace("%", "")))) || (filter.TelefonoLaboral.EndsWith("%") && o.TelefonoLaboral.StartsWith(filter.TelefonoLaboral.Replace("%", ""))) || (filter.TelefonoLaboral.StartsWith("%") && o.TelefonoLaboral.EndsWith(filter.TelefonoLaboral.Replace("%", ""))) || o.TelefonoLaboral == filter.TelefonoLaboral)
                   && (filter.Fax == null || filter.Fax.Trim() == string.Empty || filter.Fax.Trim() == "%" || (filter.Fax.EndsWith("%") && filter.Fax.StartsWith("%") && (o.Fax.Contains(filter.Fax.Replace("%", "")))) || (filter.Fax.EndsWith("%") && o.Fax.StartsWith(filter.Fax.Replace("%", ""))) || (filter.Fax.StartsWith("%") && o.Fax.EndsWith(filter.Fax.Replace("%", ""))) || o.Fax == filter.Fax)
                   && (filter.EMailPersonal == null || filter.EMailPersonal.Trim() == string.Empty || filter.EMailPersonal.Trim() == "%" || (filter.EMailPersonal.EndsWith("%") && filter.EMailPersonal.StartsWith("%") && (o.EMailPersonal.Contains(filter.EMailPersonal.Replace("%", "")))) || (filter.EMailPersonal.EndsWith("%") && o.EMailPersonal.StartsWith(filter.EMailPersonal.Replace("%", ""))) || (filter.EMailPersonal.StartsWith("%") && o.EMailPersonal.EndsWith(filter.EMailPersonal.Replace("%", ""))) || o.EMailPersonal == filter.EMailPersonal)
                   && (filter.EMailLaboral == null || filter.EMailLaboral.Trim() == string.Empty || filter.EMailLaboral.Trim() == "%" || (filter.EMailLaboral.EndsWith("%") && filter.EMailLaboral.StartsWith("%") && (o.EMailLaboral.Contains(filter.EMailLaboral.Replace("%", "")))) || (filter.EMailLaboral.EndsWith("%") && o.EMailLaboral.StartsWith(filter.EMailLaboral.Replace("%", ""))) || (filter.EMailLaboral.StartsWith("%") && o.EMailLaboral.EndsWith(filter.EMailLaboral.Replace("%", ""))) || o.EMailLaboral == filter.EMailLaboral)
                   && (filter.CargoEspecifico == null || filter.CargoEspecifico.Trim() == string.Empty || filter.CargoEspecifico.Trim() == "%" || (filter.CargoEspecifico.EndsWith("%") && filter.CargoEspecifico.StartsWith("%") && (o.CargoEspecifico.Contains(filter.CargoEspecifico.Replace("%", "")))) || (filter.CargoEspecifico.EndsWith("%") && o.CargoEspecifico.StartsWith(filter.CargoEspecifico.Replace("%", ""))) || (filter.CargoEspecifico.StartsWith("%") && o.CargoEspecifico.EndsWith(filter.CargoEspecifico.Replace("%", ""))) || o.CargoEspecifico == filter.CargoEspecifico)
                   && (filter.NivelJerarquico == null || filter.NivelJerarquico.Trim() == string.Empty || filter.NivelJerarquico.Trim() == "%" || (filter.NivelJerarquico.EndsWith("%") && filter.NivelJerarquico.StartsWith("%") && (o.NivelJerarquico.Contains(filter.NivelJerarquico.Replace("%", "")))) || (filter.NivelJerarquico.EndsWith("%") && o.NivelJerarquico.StartsWith(filter.NivelJerarquico.Replace("%", ""))) || (filter.NivelJerarquico.StartsWith("%") && o.NivelJerarquico.EndsWith(filter.NivelJerarquico.Replace("%", ""))) || o.NivelJerarquico == filter.NivelJerarquico)
                   && (filter.Domicilio == null || filter.Domicilio.Trim() == string.Empty || filter.Domicilio.Trim() == "%" || (filter.Domicilio.EndsWith("%") && filter.Domicilio.StartsWith("%") && (o.Domicilio.Contains(filter.Domicilio.Replace("%", "")))) || (filter.Domicilio.EndsWith("%") && o.Domicilio.StartsWith(filter.Domicilio.Replace("%", ""))) || (filter.Domicilio.StartsWith("%") && o.Domicilio.EndsWith(filter.Domicilio.Replace("%", ""))) || o.Domicilio == filter.Domicilio)
                   && (filter.CodPostal == null || filter.CodPostal.Trim() == string.Empty || filter.CodPostal.Trim() == "%" || (filter.CodPostal.EndsWith("%") && filter.CodPostal.StartsWith("%") && (o.CodPostal.Contains(filter.CodPostal.Replace("%", "")))) || (filter.CodPostal.EndsWith("%") && o.CodPostal.StartsWith(filter.CodPostal.Replace("%", ""))) || (filter.CodPostal.StartsWith("%") && o.CodPostal.EndsWith(filter.CodPostal.Replace("%", ""))) || o.CodPostal == filter.CodPostal)
                   && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica == filter.IdClasificacionGeografica)
                   && (filter.IdClasificacionGeograficaIsNull == null || filter.IdClasificacionGeograficaIsNull == true || o.IdClasificacionGeografica != null) && (filter.IdClasificacionGeograficaIsNull == null || filter.IdClasificacionGeograficaIsNull == false || o.IdClasificacionGeografica == null)
                   && (filter.Sexo == null || filter.Sexo.Trim() == string.Empty || filter.Sexo.Trim() == "%" || (filter.Sexo.EndsWith("%") && filter.Sexo.StartsWith("%") && (o.Sexo.Contains(filter.Sexo.Replace("%", "")))) || (filter.Sexo.EndsWith("%") && o.Sexo.StartsWith(filter.Sexo.Replace("%", ""))) || (filter.Sexo.StartsWith("%") && o.Sexo.EndsWith(filter.Sexo.Replace("%", ""))) || o.Sexo == filter.Sexo)
                   && (filter.EnviarEMail == null || o.EnviarEMail == filter.EnviarEMail)
                   && (filter.EnviarEMailIsNull == null || filter.EnviarEMailIsNull == true || o.EnviarEMail != null) && (filter.EnviarEMailIsNull == null || filter.EnviarEMailIsNull == false || o.EnviarEMail == null)
                   && (filter.EnviarNota == null || o.EnviarNota == filter.EnviarNota)
                   && (filter.EnviarNotaIsNull == null || filter.EnviarNotaIsNull == true || o.EnviarNota != null) && (filter.EnviarNotaIsNull == null || filter.EnviarNotaIsNull == false || o.EnviarNota == null)
                   && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >= filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
                   && (filter.FechaBaja == null || filter.FechaBaja == DateTime.MinValue || o.FechaBaja >= filter.FechaBaja) && (filter.FechaBaja_To == null || filter.FechaBaja_To == DateTime.MinValue || o.FechaBaja <= filter.FechaBaja_To)
                   && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == true || o.FechaBaja != null) && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == false || o.FechaBaja == null)
                   && (filter.Activo == null || o.Activo == filter.Activo)
                   && (filter.FechaUltMod == null || filter.FechaUltMod == DateTime.MinValue || o.FechaUltMod >= filter.FechaUltMod) && (filter.FechaUltMod_To == null || filter.FechaUltMod_To == DateTime.MinValue || o.FechaUltMod <= filter.FechaUltMod_To)
                   && (filter.IdUsuarioUltMod == null || o.IdUsuarioUltMod >= filter.IdUsuarioUltMod) && (filter.IdUsuarioUltMod_To == null || o.IdUsuarioUltMod <= filter.IdUsuarioUltMod_To)
                   && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 ||
                        (from sa in this.Context.Safs
                         join of in this.Context.Oficinas on sa.IdSaf equals of.IdSaf
                         join pe in this.Context.Personas on of.IdOficina equals pe.IdOficina
                         where sa.IdJurisdiccion == filter.IdJurisdiccion
                         select pe.IdPersona).Contains(o.IdPersona))
                     && (filter.IdsOficina == null || filter.IdsOficina.Length == 0 || filter.IdsOficina.Contains(o.IdOficina))
                     && (filter.EsUsuarioContacto == null || o.EsUsuario == filter.EsUsuarioContacto || (o.EsContacto == true && filter.EsUsuarioContacto == false))
                    && (filter.IncluirOficinasInteriores == null || filter.IncluirOficinasInteriores == false || filter.IdOficina == null || strIdParent == string.Empty
                          || (from of in this.Context.Oficinas where of.BreadcrumbId.Contains(strIdParent) select of.IdOficina ).Contains(o.IdOficina))
                   
                   select o
                   ).AsQueryable();
       }
       protected override IQueryable<PersonaResult> QueryResult(PersonaFilter filter)
       {   
	    return (from o in Query(filter)					
			   join _t1  in this.Context.Cargos on o.IdCargo equals _t1.IdCargo into tt1 from t1 in tt1.DefaultIfEmpty()
			   //join _t2  in this.Context.ClasificacionGeograficas on o.IdProvincia equals _t2.IdClasificacionGeografica into tt2 from t2 in tt2.DefaultIfEmpty()
                join _t2 in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals _t2.IdClasificacionGeografica into tt2
                from t2 in tt2.DefaultIfEmpty()
			   join t4  in this.Context.Oficinas on o.IdOficina equals t4.IdOficina   
               join _usuario  in this.Context.Usuarios  on o.IdPersona  equals _usuario.IdUsuario  into ttusuario from usuario in ttusuario.DefaultIfEmpty() 
               join _saf in this.Context.Safs  on t4.IdSaf   equals _saf.IdSaf into ttSaf from Saf in ttSaf.DefaultIfEmpty() 
                
               where
                    (
                        (filter.Usuario_Nombre == null || filter.Usuario_Nombre.Trim() == string.Empty || filter.Usuario_Nombre.Trim() == "%" || (filter.Usuario_Nombre.EndsWith("%") && filter.Usuario_Nombre.StartsWith("%") && (usuario.NombreUsuario.Contains(filter.Usuario_Nombre.Replace("%", "")))) || (filter.Usuario_Nombre.EndsWith("%") && usuario.NombreUsuario.StartsWith(filter.Usuario_Nombre.Replace("%", ""))) || (filter.Usuario_Nombre.StartsWith("%") && usuario.NombreUsuario.EndsWith(filter.Usuario_Nombre.Replace("%", ""))) || usuario.NombreUsuario == filter.Usuario_Nombre)
                        && (filter.IdSaf == null || filter.IdSaf == 0 || (filter.IdOficina != 0  && filter.IdOficina != null)|| filter.IdSaf == Saf.IdSaf)
                        
                    )   
			   select new PersonaResult(){
				 IdPersona=o.IdPersona
				 ,EsUsuario=o.EsUsuario
				 ,EsContacto=o.EsContacto
				 ,Nombre=o.Nombre
				 ,Apellido=o.Apellido
				 ,NombreCompleto=o.NombreCompleto
				 ,IdOficina=o.IdOficina
				 ,IdCargo=o.IdCargo
				 ,Telefono=o.Telefono
				 ,TelefonoLaboral=o.TelefonoLaboral
				 ,Fax=o.Fax
				 ,EMailPersonal=o.EMailPersonal
				 ,EMailLaboral=o.EMailLaboral
				 ,CargoEspecifico=o.CargoEspecifico
				 ,NivelJerarquico=o.NivelJerarquico
				 ,Domicilio=o.Domicilio
				 ,CodPostal=o.CodPostal
                 , IdClasificacionGeografica = o.IdClasificacionGeografica
				 ,ClasificacionGeografica_Codigo= t2!=null?(string)t2.Codigo:null				
				 ,Sexo=o.Sexo
				 ,EnviarEMail=o.EnviarEMail
				 ,EnviarNota=o.EnviarNota
				 ,FechaAlta=o.FechaAlta
				 ,FechaBaja=o.FechaBaja
				 ,Activo=o.Activo
				 ,FechaUltMod=o.FechaUltMod
				 ,IdUsuarioUltMod=o.IdUsuarioUltMod
				 ,Cargo_Nombre= t1!=null?(string)t1.Nombre:null	
				 ,Cargo_Activo= t1!=null?(bool?)t1.Activo:null	
                    //,Provincia_Codigo= t2!=null?(string)t2.Codigo:null	
                    //,Provincia_Nombre= t2!=null?(string)t2.Nombre:null	
                    //,Provincia_IdClasificacionGeograficaTipo= t2!=null?(int?)t2.IdClasificacionGeograficaTipo:null	
                    //,Provincia_IdClasificacionGeograficaPadre= t2!=null?(int?)t2.IdClasificacionGeograficaPadre:null	
                    //,Provincia_Activo= t2!=null?(bool?)t2.Activo:null	
                    //,Localidad_Codigo= t3!=null?(string)t3.Codigo:null	
                    //,Localidad_Nombre= t3!=null?(string)t3.Nombre:null	
                    //,Localidad_IdClasificacionGeograficaTipo= t3!=null?(int?)t3.IdClasificacionGeograficaTipo:null	
                    //,Localidad_IdClasificacionGeograficaPadre= t3!=null?(int?)t3.IdClasificacionGeograficaPadre:null	
                    //,Localidad_Activo= t3!=null?(bool?)t3.Activo:null	
					,Oficina_Nombre= t4.Nombre	
					,Oficina_Codigo= t4.Codigo	
					,Oficina_Activo= t4.Activo	
					,Oficina_Visible= t4.Visible	
					,Oficina_IdOficinaPadre= t4.IdOficinaPadre	
					,Oficina_IdSaf= t4.IdSaf	
					,Oficina_BreadcrumbId= t4.BreadcrumbId	
					,Oficina_BreadcrumbOrden= t4.BreadcrumbOrden
	                ,Oficina_BreadcrumbCode= t4.BreadcrumbCode
					,Oficina_Nivel= t4.Nivel	
                    ,Usuario_NombreUsuario = usuario !=null? usuario.NombreUsuario :""
                    ,ClasificacionGeografica_Nombre= t2!=null?(string)t2.Nombre:null	
				    ,ClasificacionGeografica_IdClasificacionGeograficaTipo= t2!=null?(int?)t2.IdClasificacionGeograficaTipo:null	
				    ,ClasificacionGeografica_IdClasificacionGeograficaPadre= t2!=null?(int?)t2.IdClasificacionGeograficaPadre:null	
				    ,ClasificacionGeografica_Activo= t2!=null?(bool?)t2.Activo:null	
				    ,ClasificacionGeografica_Descripcion= t2!=null?(string)t2.Descripcion:null	
				    ,ClasificacionGeografica_BreadcrumbId= t2!=null?(string)t2.BreadcrumbId:null	
				    ,ClasificacionGeografica_BreadcrumOrden= t2!=null?(string)t2.BreadcrumOrden:null	
				    ,ClasificacionGeografica_Orden= t2!=null?(int?)t2.Orden:null	
				    ,ClasificacionGeografica_Nivel= t2!=null?(int?)t2.Nivel:null	
					}
                ).AsQueryable();
       }
       #endregion
       #region Set
       public override void Set(PersonaResult source, Persona target, bool hadSetId)
       {
           if (hadSetId) target.IdPersona = source.IdPersona;
           target.EsUsuario = source.EsUsuario;
           target.EsContacto = source.EsContacto;
           target.Nombre = source.Nombre;
           target.Apellido = source.Apellido;
           target.NombreCompleto = source.NombreCompleto;
           target.IdOficina = source.IdOficina;
           target.IdCargo = source.IdCargo;
           target.Telefono = source.Telefono;
           target.TelefonoLaboral = source.TelefonoLaboral;
           target.Fax = source.Fax;
           target.EMailPersonal = source.EMailPersonal;
           target.EMailLaboral = source.EMailLaboral;
           target.CargoEspecifico = source.CargoEspecifico;
           target.NivelJerarquico = source.NivelJerarquico;
           target.Domicilio = source.Domicilio;
           target.CodPostal = source.CodPostal;
           target.IdClasificacionGeografica = source.IdClasificacionGeografica;
           target.Sexo = source.Sexo;
           target.EnviarEMail = source.EnviarEMail;
           target.EnviarNota = source.EnviarNota;
           target.FechaBaja = source.FechaBaja;
           target.Activo = source.Activo;
           target.FechaUltMod = source.FechaUltMod;
           target.IdUsuarioUltMod = source.IdUsuarioUltMod;

       }

        #endregion
    }
}
