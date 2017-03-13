using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _PersonaData : EntityData<Persona,PersonaFilter,PersonaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Persona entity)
		{			
			return entity.IdPersona;
		}		
		public override Persona GetByEntity(Persona entity)
        {
            return this.GetById(entity.IdPersona);
        }
        public override Persona GetById(int id)
        {
            return (from o in this.Table where o.IdPersona == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Persona> Query(PersonaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPersona == null || filter.IdPersona == 0 || o.IdPersona==filter.IdPersona)
					  && (filter.EsUsuario == null || o.EsUsuario==filter.EsUsuario)
					  && (filter.EsContacto == null || o.EsContacto==filter.EsContacto)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Apellido == null || filter.Apellido.Trim() == string.Empty || filter.Apellido.Trim() == "%"  || (filter.Apellido.EndsWith("%") && filter.Apellido.StartsWith("%") && (o.Apellido.Contains(filter.Apellido.Replace("%", "")))) || (filter.Apellido.EndsWith("%") && o.Apellido.StartsWith(filter.Apellido.Replace("%",""))) || (filter.Apellido.StartsWith("%") && o.Apellido.EndsWith(filter.Apellido.Replace("%",""))) || o.Apellido == filter.Apellido )
					  && (filter.NombreCompleto == null || filter.NombreCompleto.Trim() == string.Empty || filter.NombreCompleto.Trim() == "%"  || (filter.NombreCompleto.EndsWith("%") && filter.NombreCompleto.StartsWith("%") && (o.NombreCompleto.Contains(filter.NombreCompleto.Replace("%", "")))) || (filter.NombreCompleto.EndsWith("%") && o.NombreCompleto.StartsWith(filter.NombreCompleto.Replace("%",""))) || (filter.NombreCompleto.StartsWith("%") && o.NombreCompleto.EndsWith(filter.NombreCompleto.Replace("%",""))) || o.NombreCompleto == filter.NombreCompleto )
					  && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.IdCargo == null || filter.IdCargo == 0 || o.IdCargo==filter.IdCargo)
					  && (filter.IdCargoIsNull == null || filter.IdCargoIsNull == true || o.IdCargo != null ) && (filter.IdCargoIsNull == null || filter.IdCargoIsNull == false || o.IdCargo == null)
					  && (filter.Telefono == null || filter.Telefono.Trim() == string.Empty || filter.Telefono.Trim() == "%"  || (filter.Telefono.EndsWith("%") && filter.Telefono.StartsWith("%") && (o.Telefono.Contains(filter.Telefono.Replace("%", "")))) || (filter.Telefono.EndsWith("%") && o.Telefono.StartsWith(filter.Telefono.Replace("%",""))) || (filter.Telefono.StartsWith("%") && o.Telefono.EndsWith(filter.Telefono.Replace("%",""))) || o.Telefono == filter.Telefono )
					  && (filter.TelefonoLaboral == null || filter.TelefonoLaboral.Trim() == string.Empty || filter.TelefonoLaboral.Trim() == "%"  || (filter.TelefonoLaboral.EndsWith("%") && filter.TelefonoLaboral.StartsWith("%") && (o.TelefonoLaboral.Contains(filter.TelefonoLaboral.Replace("%", "")))) || (filter.TelefonoLaboral.EndsWith("%") && o.TelefonoLaboral.StartsWith(filter.TelefonoLaboral.Replace("%",""))) || (filter.TelefonoLaboral.StartsWith("%") && o.TelefonoLaboral.EndsWith(filter.TelefonoLaboral.Replace("%",""))) || o.TelefonoLaboral == filter.TelefonoLaboral )
					  && (filter.Fax == null || filter.Fax.Trim() == string.Empty || filter.Fax.Trim() == "%"  || (filter.Fax.EndsWith("%") && filter.Fax.StartsWith("%") && (o.Fax.Contains(filter.Fax.Replace("%", "")))) || (filter.Fax.EndsWith("%") && o.Fax.StartsWith(filter.Fax.Replace("%",""))) || (filter.Fax.StartsWith("%") && o.Fax.EndsWith(filter.Fax.Replace("%",""))) || o.Fax == filter.Fax )
					  && (filter.EMailPersonal == null || filter.EMailPersonal.Trim() == string.Empty || filter.EMailPersonal.Trim() == "%"  || (filter.EMailPersonal.EndsWith("%") && filter.EMailPersonal.StartsWith("%") && (o.EMailPersonal.Contains(filter.EMailPersonal.Replace("%", "")))) || (filter.EMailPersonal.EndsWith("%") && o.EMailPersonal.StartsWith(filter.EMailPersonal.Replace("%",""))) || (filter.EMailPersonal.StartsWith("%") && o.EMailPersonal.EndsWith(filter.EMailPersonal.Replace("%",""))) || o.EMailPersonal == filter.EMailPersonal )
					  && (filter.EMailLaboral == null || filter.EMailLaboral.Trim() == string.Empty || filter.EMailLaboral.Trim() == "%"  || (filter.EMailLaboral.EndsWith("%") && filter.EMailLaboral.StartsWith("%") && (o.EMailLaboral.Contains(filter.EMailLaboral.Replace("%", "")))) || (filter.EMailLaboral.EndsWith("%") && o.EMailLaboral.StartsWith(filter.EMailLaboral.Replace("%",""))) || (filter.EMailLaboral.StartsWith("%") && o.EMailLaboral.EndsWith(filter.EMailLaboral.Replace("%",""))) || o.EMailLaboral == filter.EMailLaboral )
					  && (filter.CargoEspecifico == null || filter.CargoEspecifico.Trim() == string.Empty || filter.CargoEspecifico.Trim() == "%"  || (filter.CargoEspecifico.EndsWith("%") && filter.CargoEspecifico.StartsWith("%") && (o.CargoEspecifico.Contains(filter.CargoEspecifico.Replace("%", "")))) || (filter.CargoEspecifico.EndsWith("%") && o.CargoEspecifico.StartsWith(filter.CargoEspecifico.Replace("%",""))) || (filter.CargoEspecifico.StartsWith("%") && o.CargoEspecifico.EndsWith(filter.CargoEspecifico.Replace("%",""))) || o.CargoEspecifico == filter.CargoEspecifico )
					  && (filter.NivelJerarquico == null || filter.NivelJerarquico.Trim() == string.Empty || filter.NivelJerarquico.Trim() == "%"  || (filter.NivelJerarquico.EndsWith("%") && filter.NivelJerarquico.StartsWith("%") && (o.NivelJerarquico.Contains(filter.NivelJerarquico.Replace("%", "")))) || (filter.NivelJerarquico.EndsWith("%") && o.NivelJerarquico.StartsWith(filter.NivelJerarquico.Replace("%",""))) || (filter.NivelJerarquico.StartsWith("%") && o.NivelJerarquico.EndsWith(filter.NivelJerarquico.Replace("%",""))) || o.NivelJerarquico == filter.NivelJerarquico )
					  && (filter.Domicilio == null || filter.Domicilio.Trim() == string.Empty || filter.Domicilio.Trim() == "%"  || (filter.Domicilio.EndsWith("%") && filter.Domicilio.StartsWith("%") && (o.Domicilio.Contains(filter.Domicilio.Replace("%", "")))) || (filter.Domicilio.EndsWith("%") && o.Domicilio.StartsWith(filter.Domicilio.Replace("%",""))) || (filter.Domicilio.StartsWith("%") && o.Domicilio.EndsWith(filter.Domicilio.Replace("%",""))) || o.Domicilio == filter.Domicilio )
					  && (filter.CodPostal == null || filter.CodPostal.Trim() == string.Empty || filter.CodPostal.Trim() == "%"  || (filter.CodPostal.EndsWith("%") && filter.CodPostal.StartsWith("%") && (o.CodPostal.Contains(filter.CodPostal.Replace("%", "")))) || (filter.CodPostal.EndsWith("%") && o.CodPostal.StartsWith(filter.CodPostal.Replace("%",""))) || (filter.CodPostal.StartsWith("%") && o.CodPostal.EndsWith(filter.CodPostal.Replace("%",""))) || o.CodPostal == filter.CodPostal )
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  && (filter.IdClasificacionGeograficaIsNull == null || filter.IdClasificacionGeograficaIsNull == true || o.IdClasificacionGeografica != null ) && (filter.IdClasificacionGeograficaIsNull == null || filter.IdClasificacionGeograficaIsNull == false || o.IdClasificacionGeografica == null)
					  && (filter.Sexo == null || filter.Sexo.Trim() == string.Empty || filter.Sexo.Trim() == "%"  || (filter.Sexo.EndsWith("%") && filter.Sexo.StartsWith("%") && (o.Sexo.Contains(filter.Sexo.Replace("%", "")))) || (filter.Sexo.EndsWith("%") && o.Sexo.StartsWith(filter.Sexo.Replace("%",""))) || (filter.Sexo.StartsWith("%") && o.Sexo.EndsWith(filter.Sexo.Replace("%",""))) || o.Sexo == filter.Sexo )
					  && (filter.EnviarEMail == null || o.EnviarEMail==filter.EnviarEMail)
					  && (filter.EnviarEMailIsNull == null || filter.EnviarEMailIsNull == true || o.EnviarEMail != null ) && (filter.EnviarEMailIsNull == null || filter.EnviarEMailIsNull == false || o.EnviarEMail == null)
					  && (filter.EnviarNota == null || o.EnviarNota==filter.EnviarNota)
					  && (filter.EnviarNotaIsNull == null || filter.EnviarNotaIsNull == true || o.EnviarNota != null ) && (filter.EnviarNotaIsNull == null || filter.EnviarNotaIsNull == false || o.EnviarNota == null)
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaBaja == null || filter.FechaBaja == DateTime.MinValue || o.FechaBaja >=  filter.FechaBaja) && (filter.FechaBaja_To == null || filter.FechaBaja_To == DateTime.MinValue || o.FechaBaja <= filter.FechaBaja_To)
					  && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == true || o.FechaBaja != null ) && (filter.FechaBajaIsNull == null || filter.FechaBajaIsNull == false || o.FechaBaja == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.FechaUltMod == null || filter.FechaUltMod == DateTime.MinValue || o.FechaUltMod >=  filter.FechaUltMod) && (filter.FechaUltMod_To == null || filter.FechaUltMod_To == DateTime.MinValue || o.FechaUltMod <= filter.FechaUltMod_To)
					  && (filter.IdUsuarioUltMod == null || o.IdUsuarioUltMod >=  filter.IdUsuarioUltMod) && (filter.IdUsuarioUltMod_To == null || o.IdUsuarioUltMod <= filter.IdUsuarioUltMod_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PersonaResult> QueryResult(PersonaFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Cargos on o.IdCargo equals _t1.IdCargo into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals _t2.IdClasificacionGeografica into tt2 from t2 in tt2.DefaultIfEmpty()
				    join t3  in this.Context.Oficinas on o.IdOficina equals t3.IdOficina   
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
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
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
						,Cargo_Codigo= t1!=null?(string)t1.Codigo:null	
						,ClasificacionGeografica_Codigo= t2!=null?(string)t2.Codigo:null	
						,ClasificacionGeografica_Nombre= t2!=null?(string)t2.Nombre:null	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t2!=null?(int?)t2.IdClasificacionGeograficaTipo:null	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t2!=null?(int?)t2.IdClasificacionGeograficaPadre:null	
						,ClasificacionGeografica_Activo= t2!=null?(bool?)t2.Activo:null	
						,ClasificacionGeografica_Descripcion= t2!=null?(string)t2.Descripcion:null	
						,ClasificacionGeografica_BreadcrumbId= t2!=null?(string)t2.BreadcrumbId:null	
						,ClasificacionGeografica_BreadcrumOrden= t2!=null?(string)t2.BreadcrumOrden:null	
						,ClasificacionGeografica_Orden= t2!=null?(int?)t2.Orden:null	
						,ClasificacionGeografica_Nivel= t2!=null?(int?)t2.Nivel:null	
						,ClasificacionGeografica_DescripcionInvertida= t2!=null?(string)t2.DescripcionInvertida:null	
						,ClasificacionGeografica_Seleccionable= t2!=null?(bool?)t2.Seleccionable:null	
						,ClasificacionGeografica_BreadcrumbCode= t2!=null?(string)t2.BreadcrumbCode:null	
						,ClasificacionGeografica_DescripcionCodigo= t2!=null?(string)t2.DescripcionCodigo:null	
						,Oficina_Nombre= t3.Nombre	
						,Oficina_Codigo= t3.Codigo	
						,Oficina_Activo= t3.Activo	
						,Oficina_Visible= t3.Visible	
						,Oficina_IdOficinaPadre= t3.IdOficinaPadre	
						,Oficina_IdSaf= t3.IdSaf	
						,Oficina_BreadcrumbId= t3.BreadcrumbId	
						,Oficina_BreadcrumbOrden= t3.BreadcrumbOrden	
						,Oficina_Nivel= t3.Nivel	
						,Oficina_Orden= t3.Orden	
						,Oficina_Descripcion= t3.Descripcion	
						,Oficina_DescripcionInvertida= t3.DescripcionInvertida	
						,Oficina_Seleccionable= t3.Seleccionable	
						,Oficina_BreadcrumbCode= t3.BreadcrumbCode	
						,Oficina_DescripcionCodigo= t3.DescripcionCodigo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Persona Copy(nc.Persona entity)
        {           
            nc.Persona _new = new nc.Persona();
		 _new.EsUsuario= entity.EsUsuario;
		 _new.EsContacto= entity.EsContacto;
		 _new.Nombre= entity.Nombre;
		 _new.Apellido= entity.Apellido;
		 _new.NombreCompleto= entity.NombreCompleto;
		 _new.IdOficina= entity.IdOficina;
		 _new.IdCargo= entity.IdCargo;
		 _new.Telefono= entity.Telefono;
		 _new.TelefonoLaboral= entity.TelefonoLaboral;
		 _new.Fax= entity.Fax;
		 _new.EMailPersonal= entity.EMailPersonal;
		 _new.EMailLaboral= entity.EMailLaboral;
		 _new.CargoEspecifico= entity.CargoEspecifico;
		 _new.NivelJerarquico= entity.NivelJerarquico;
		 _new.Domicilio= entity.Domicilio;
		 _new.CodPostal= entity.CodPostal;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		 _new.Sexo= entity.Sexo;
		 _new.EnviarEMail= entity.EnviarEMail;
		 _new.EnviarNota= entity.EnviarNota;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaBaja= entity.FechaBaja;
		 _new.Activo= entity.Activo;
		 _new.FechaUltMod= entity.FechaUltMod;
		 _new.IdUsuarioUltMod= entity.IdUsuarioUltMod;
		return _new;			
        }
		public override int CopyAndSave(Persona entity,string renameFormat)
        {
            Persona  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Persona entity, int id)
        {            
            entity.IdPersona = id;            
        }
		public override void Set(Persona source,Persona target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPersona= source.IdPersona ;
		 target.EsUsuario= source.EsUsuario ;
		 target.EsContacto= source.EsContacto ;
		 target.Nombre= source.Nombre ;
		 target.Apellido= source.Apellido ;
		 target.NombreCompleto= source.NombreCompleto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdCargo= source.IdCargo ;
		 target.Telefono= source.Telefono ;
		 target.TelefonoLaboral= source.TelefonoLaboral ;
		 target.Fax= source.Fax ;
		 target.EMailPersonal= source.EMailPersonal ;
		 target.EMailLaboral= source.EMailLaboral ;
		 target.CargoEspecifico= source.CargoEspecifico ;
		 target.NivelJerarquico= source.NivelJerarquico ;
		 target.Domicilio= source.Domicilio ;
		 target.CodPostal= source.CodPostal ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Sexo= source.Sexo ;
		 target.EnviarEMail= source.EnviarEMail ;
		 target.EnviarNota= source.EnviarNota ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.FechaUltMod= source.FechaUltMod ;
		 target.IdUsuarioUltMod= source.IdUsuarioUltMod ;
		 		  
		}
		public override void Set(PersonaResult source,Persona target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPersona= source.IdPersona ;
		 target.EsUsuario= source.EsUsuario ;
		 target.EsContacto= source.EsContacto ;
		 target.Nombre= source.Nombre ;
		 target.Apellido= source.Apellido ;
		 target.NombreCompleto= source.NombreCompleto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdCargo= source.IdCargo ;
		 target.Telefono= source.Telefono ;
		 target.TelefonoLaboral= source.TelefonoLaboral ;
		 target.Fax= source.Fax ;
		 target.EMailPersonal= source.EMailPersonal ;
		 target.EMailLaboral= source.EMailLaboral ;
		 target.CargoEspecifico= source.CargoEspecifico ;
		 target.NivelJerarquico= source.NivelJerarquico ;
		 target.Domicilio= source.Domicilio ;
		 target.CodPostal= source.CodPostal ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Sexo= source.Sexo ;
		 target.EnviarEMail= source.EnviarEMail ;
		 target.EnviarNota= source.EnviarNota ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.FechaUltMod= source.FechaUltMod ;
		 target.IdUsuarioUltMod= source.IdUsuarioUltMod ;
		 
		}
		public override void Set(Persona source,PersonaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPersona= source.IdPersona ;
		 target.EsUsuario= source.EsUsuario ;
		 target.EsContacto= source.EsContacto ;
		 target.Nombre= source.Nombre ;
		 target.Apellido= source.Apellido ;
		 target.NombreCompleto= source.NombreCompleto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdCargo= source.IdCargo ;
		 target.Telefono= source.Telefono ;
		 target.TelefonoLaboral= source.TelefonoLaboral ;
		 target.Fax= source.Fax ;
		 target.EMailPersonal= source.EMailPersonal ;
		 target.EMailLaboral= source.EMailLaboral ;
		 target.CargoEspecifico= source.CargoEspecifico ;
		 target.NivelJerarquico= source.NivelJerarquico ;
		 target.Domicilio= source.Domicilio ;
		 target.CodPostal= source.CodPostal ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Sexo= source.Sexo ;
		 target.EnviarEMail= source.EnviarEMail ;
		 target.EnviarNota= source.EnviarNota ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.FechaUltMod= source.FechaUltMod ;
		 target.IdUsuarioUltMod= source.IdUsuarioUltMod ;
		 	
		}		
		public override void Set(PersonaResult source,PersonaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPersona= source.IdPersona ;
		 target.EsUsuario= source.EsUsuario ;
		 target.EsContacto= source.EsContacto ;
		 target.Nombre= source.Nombre ;
		 target.Apellido= source.Apellido ;
		 target.NombreCompleto= source.NombreCompleto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdCargo= source.IdCargo ;
		 target.Telefono= source.Telefono ;
		 target.TelefonoLaboral= source.TelefonoLaboral ;
		 target.Fax= source.Fax ;
		 target.EMailPersonal= source.EMailPersonal ;
		 target.EMailLaboral= source.EMailLaboral ;
		 target.CargoEspecifico= source.CargoEspecifico ;
		 target.NivelJerarquico= source.NivelJerarquico ;
		 target.Domicilio= source.Domicilio ;
		 target.CodPostal= source.CodPostal ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Sexo= source.Sexo ;
		 target.EnviarEMail= source.EnviarEMail ;
		 target.EnviarNota= source.EnviarNota ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaBaja= source.FechaBaja ;
		 target.Activo= source.Activo ;
		 target.FechaUltMod= source.FechaUltMod ;
		 target.IdUsuarioUltMod= source.IdUsuarioUltMod ;
		 target.Cargo_Nombre= source.Cargo_Nombre;	
			target.Cargo_Activo= source.Cargo_Activo;	
			target.Cargo_Codigo= source.Cargo_Codigo;	
			target.ClasificacionGeografica_Codigo= source.ClasificacionGeografica_Codigo;	
			target.ClasificacionGeografica_Nombre= source.ClasificacionGeografica_Nombre;	
			target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
			target.ClasificacionGeografica_IdClasificacionGeograficaPadre= source.ClasificacionGeografica_IdClasificacionGeograficaPadre;	
			target.ClasificacionGeografica_Activo= source.ClasificacionGeografica_Activo;	
			target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
			target.ClasificacionGeografica_BreadcrumbId= source.ClasificacionGeografica_BreadcrumbId;	
			target.ClasificacionGeografica_BreadcrumOrden= source.ClasificacionGeografica_BreadcrumOrden;	
			target.ClasificacionGeografica_Orden= source.ClasificacionGeografica_Orden;	
			target.ClasificacionGeografica_Nivel= source.ClasificacionGeografica_Nivel;	
			target.ClasificacionGeografica_DescripcionInvertida= source.ClasificacionGeografica_DescripcionInvertida;	
			target.ClasificacionGeografica_Seleccionable= source.ClasificacionGeografica_Seleccionable;	
			target.ClasificacionGeografica_BreadcrumbCode= source.ClasificacionGeografica_BreadcrumbCode;	
			target.ClasificacionGeografica_DescripcionCodigo= source.ClasificacionGeografica_DescripcionCodigo;	
			target.Oficina_Nombre= source.Oficina_Nombre;	
			target.Oficina_Codigo= source.Oficina_Codigo;	
			target.Oficina_Activo= source.Oficina_Activo;	
			target.Oficina_Visible= source.Oficina_Visible;	
			target.Oficina_IdOficinaPadre= source.Oficina_IdOficinaPadre;	
			target.Oficina_IdSaf= source.Oficina_IdSaf;	
			target.Oficina_BreadcrumbId= source.Oficina_BreadcrumbId;	
			target.Oficina_BreadcrumbOrden= source.Oficina_BreadcrumbOrden;	
			target.Oficina_Nivel= source.Oficina_Nivel;	
			target.Oficina_Orden= source.Oficina_Orden;	
			target.Oficina_Descripcion= source.Oficina_Descripcion;	
			target.Oficina_DescripcionInvertida= source.Oficina_DescripcionInvertida;	
			target.Oficina_Seleccionable= source.Oficina_Seleccionable;	
			target.Oficina_BreadcrumbCode= source.Oficina_BreadcrumbCode;	
			target.Oficina_DescripcionCodigo= source.Oficina_DescripcionCodigo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Persona source,Persona target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPersona.Equals(target.IdPersona))return false;
		  if(!source.EsUsuario.Equals(target.EsUsuario))return false;
		  if(!source.EsContacto.Equals(target.EsContacto))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Apellido == null)?target.Apellido!=null:  !( (target.Apellido== String.Empty && source.Apellido== null) || (target.Apellido==null && source.Apellido== String.Empty )) &&  !source.Apellido.Trim().Replace ("\r","").Equals(target.Apellido.Trim().Replace ("\r","")))return false;
			 if((source.NombreCompleto == null)?target.NombreCompleto!=null:  !( (target.NombreCompleto== String.Empty && source.NombreCompleto== null) || (target.NombreCompleto==null && source.NombreCompleto== String.Empty )) &&  !source.NombreCompleto.Trim().Replace ("\r","").Equals(target.NombreCompleto.Trim().Replace ("\r","")))return false;
			 if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if((source.IdCargo == null)?(target.IdCargo.HasValue && target.IdCargo.Value > 0):!source.IdCargo.Equals(target.IdCargo))return false;
						  if((source.Telefono == null)?target.Telefono!=null:  !( (target.Telefono== String.Empty && source.Telefono== null) || (target.Telefono==null && source.Telefono== String.Empty )) &&  !source.Telefono.Trim().Replace ("\r","").Equals(target.Telefono.Trim().Replace ("\r","")))return false;
			 if((source.TelefonoLaboral == null)?target.TelefonoLaboral!=null:  !( (target.TelefonoLaboral== String.Empty && source.TelefonoLaboral== null) || (target.TelefonoLaboral==null && source.TelefonoLaboral== String.Empty )) &&  !source.TelefonoLaboral.Trim().Replace ("\r","").Equals(target.TelefonoLaboral.Trim().Replace ("\r","")))return false;
			 if((source.Fax == null)?target.Fax!=null:  !( (target.Fax== String.Empty && source.Fax== null) || (target.Fax==null && source.Fax== String.Empty )) &&  !source.Fax.Trim().Replace ("\r","").Equals(target.Fax.Trim().Replace ("\r","")))return false;
			 if((source.EMailPersonal == null)?target.EMailPersonal!=null:  !( (target.EMailPersonal== String.Empty && source.EMailPersonal== null) || (target.EMailPersonal==null && source.EMailPersonal== String.Empty )) &&  !source.EMailPersonal.Trim().Replace ("\r","").Equals(target.EMailPersonal.Trim().Replace ("\r","")))return false;
			 if((source.EMailLaboral == null)?target.EMailLaboral!=null:  !( (target.EMailLaboral== String.Empty && source.EMailLaboral== null) || (target.EMailLaboral==null && source.EMailLaboral== String.Empty )) &&  !source.EMailLaboral.Trim().Replace ("\r","").Equals(target.EMailLaboral.Trim().Replace ("\r","")))return false;
			 if((source.CargoEspecifico == null)?target.CargoEspecifico!=null:  !( (target.CargoEspecifico== String.Empty && source.CargoEspecifico== null) || (target.CargoEspecifico==null && source.CargoEspecifico== String.Empty )) &&  !source.CargoEspecifico.Trim().Replace ("\r","").Equals(target.CargoEspecifico.Trim().Replace ("\r","")))return false;
			 if((source.NivelJerarquico == null)?target.NivelJerarquico!=null:  !( (target.NivelJerarquico== String.Empty && source.NivelJerarquico== null) || (target.NivelJerarquico==null && source.NivelJerarquico== String.Empty )) &&  !source.NivelJerarquico.Trim().Replace ("\r","").Equals(target.NivelJerarquico.Trim().Replace ("\r","")))return false;
			 if((source.Domicilio == null)?target.Domicilio!=null:  !( (target.Domicilio== String.Empty && source.Domicilio== null) || (target.Domicilio==null && source.Domicilio== String.Empty )) &&  !source.Domicilio.Trim().Replace ("\r","").Equals(target.Domicilio.Trim().Replace ("\r","")))return false;
			 if((source.CodPostal == null)?target.CodPostal!=null:  !( (target.CodPostal== String.Empty && source.CodPostal== null) || (target.CodPostal==null && source.CodPostal== String.Empty )) &&  !source.CodPostal.Trim().Replace ("\r","").Equals(target.CodPostal.Trim().Replace ("\r","")))return false;
			 if((source.IdClasificacionGeografica == null)?(target.IdClasificacionGeografica.HasValue && target.IdClasificacionGeografica.Value > 0):!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
						  if((source.Sexo == null)?target.Sexo!=null:  !( (target.Sexo== String.Empty && source.Sexo== null) || (target.Sexo==null && source.Sexo== String.Empty )) &&  !source.Sexo.Trim().Replace ("\r","").Equals(target.Sexo.Trim().Replace ("\r","")))return false;
			 if((source.EnviarEMail == null)?(target.EnviarEMail.HasValue):!source.EnviarEMail.Equals(target.EnviarEMail))return false;
			 if((source.EnviarNota == null)?(target.EnviarNota.HasValue):!source.EnviarNota.Equals(target.EnviarNota))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.FechaUltMod.Equals(target.FechaUltMod))return false;
		  if(!source.IdUsuarioUltMod.Equals(target.IdUsuarioUltMod))return false;
		 
		  return true;
        }
		public override bool Equals(PersonaResult source,PersonaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPersona.Equals(target.IdPersona))return false;
		  if(!source.EsUsuario.Equals(target.EsUsuario))return false;
		  if(!source.EsContacto.Equals(target.EsContacto))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Apellido == null)?target.Apellido!=null: !( (target.Apellido== String.Empty && source.Apellido== null) || (target.Apellido==null && source.Apellido== String.Empty )) && !source.Apellido.Trim().Replace ("\r","").Equals(target.Apellido.Trim().Replace ("\r","")))return false;
			 if((source.NombreCompleto == null)?target.NombreCompleto!=null: !( (target.NombreCompleto== String.Empty && source.NombreCompleto== null) || (target.NombreCompleto==null && source.NombreCompleto== String.Empty )) && !source.NombreCompleto.Trim().Replace ("\r","").Equals(target.NombreCompleto.Trim().Replace ("\r","")))return false;
			 if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if((source.IdCargo == null)?(target.IdCargo.HasValue && target.IdCargo.Value > 0):!source.IdCargo.Equals(target.IdCargo))return false;
						  if((source.Telefono == null)?target.Telefono!=null: !( (target.Telefono== String.Empty && source.Telefono== null) || (target.Telefono==null && source.Telefono== String.Empty )) && !source.Telefono.Trim().Replace ("\r","").Equals(target.Telefono.Trim().Replace ("\r","")))return false;
			 if((source.TelefonoLaboral == null)?target.TelefonoLaboral!=null: !( (target.TelefonoLaboral== String.Empty && source.TelefonoLaboral== null) || (target.TelefonoLaboral==null && source.TelefonoLaboral== String.Empty )) && !source.TelefonoLaboral.Trim().Replace ("\r","").Equals(target.TelefonoLaboral.Trim().Replace ("\r","")))return false;
			 if((source.Fax == null)?target.Fax!=null: !( (target.Fax== String.Empty && source.Fax== null) || (target.Fax==null && source.Fax== String.Empty )) && !source.Fax.Trim().Replace ("\r","").Equals(target.Fax.Trim().Replace ("\r","")))return false;
			 if((source.EMailPersonal == null)?target.EMailPersonal!=null: !( (target.EMailPersonal== String.Empty && source.EMailPersonal== null) || (target.EMailPersonal==null && source.EMailPersonal== String.Empty )) && !source.EMailPersonal.Trim().Replace ("\r","").Equals(target.EMailPersonal.Trim().Replace ("\r","")))return false;
			 if((source.EMailLaboral == null)?target.EMailLaboral!=null: !( (target.EMailLaboral== String.Empty && source.EMailLaboral== null) || (target.EMailLaboral==null && source.EMailLaboral== String.Empty )) && !source.EMailLaboral.Trim().Replace ("\r","").Equals(target.EMailLaboral.Trim().Replace ("\r","")))return false;
			 if((source.CargoEspecifico == null)?target.CargoEspecifico!=null: !( (target.CargoEspecifico== String.Empty && source.CargoEspecifico== null) || (target.CargoEspecifico==null && source.CargoEspecifico== String.Empty )) && !source.CargoEspecifico.Trim().Replace ("\r","").Equals(target.CargoEspecifico.Trim().Replace ("\r","")))return false;
			 if((source.NivelJerarquico == null)?target.NivelJerarquico!=null: !( (target.NivelJerarquico== String.Empty && source.NivelJerarquico== null) || (target.NivelJerarquico==null && source.NivelJerarquico== String.Empty )) && !source.NivelJerarquico.Trim().Replace ("\r","").Equals(target.NivelJerarquico.Trim().Replace ("\r","")))return false;
			 if((source.Domicilio == null)?target.Domicilio!=null: !( (target.Domicilio== String.Empty && source.Domicilio== null) || (target.Domicilio==null && source.Domicilio== String.Empty )) && !source.Domicilio.Trim().Replace ("\r","").Equals(target.Domicilio.Trim().Replace ("\r","")))return false;
			 if((source.CodPostal == null)?target.CodPostal!=null: !( (target.CodPostal== String.Empty && source.CodPostal== null) || (target.CodPostal==null && source.CodPostal== String.Empty )) && !source.CodPostal.Trim().Replace ("\r","").Equals(target.CodPostal.Trim().Replace ("\r","")))return false;
			 if((source.IdClasificacionGeografica == null)?(target.IdClasificacionGeografica.HasValue && target.IdClasificacionGeografica.Value > 0):!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
						  if((source.Sexo == null)?target.Sexo!=null: !( (target.Sexo== String.Empty && source.Sexo== null) || (target.Sexo==null && source.Sexo== String.Empty )) && !source.Sexo.Trim().Replace ("\r","").Equals(target.Sexo.Trim().Replace ("\r","")))return false;
			 if((source.EnviarEMail == null)?(target.EnviarEMail.HasValue):!source.EnviarEMail.Equals(target.EnviarEMail))return false;
			 if((source.EnviarNota == null)?(target.EnviarNota.HasValue):!source.EnviarNota.Equals(target.EnviarNota))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.FechaBaja == null)?(target.FechaBaja.HasValue):!source.FechaBaja.Equals(target.FechaBaja))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.FechaUltMod.Equals(target.FechaUltMod))return false;
		  if(!source.IdUsuarioUltMod.Equals(target.IdUsuarioUltMod))return false;
		  if((source.Cargo_Nombre == null)?target.Cargo_Nombre!=null: !( (target.Cargo_Nombre== String.Empty && source.Cargo_Nombre== null) || (target.Cargo_Nombre==null && source.Cargo_Nombre== String.Empty )) &&   !source.Cargo_Nombre.Trim().Replace ("\r","").Equals(target.Cargo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Cargo_Activo.Equals(target.Cargo_Activo))return false;
					  if((source.Cargo_Codigo == null)?target.Cargo_Codigo!=null: !( (target.Cargo_Codigo== String.Empty && source.Cargo_Codigo== null) || (target.Cargo_Codigo==null && source.Cargo_Codigo== String.Empty )) &&   !source.Cargo_Codigo.Trim().Replace ("\r","").Equals(target.Cargo_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Codigo == null)?target.ClasificacionGeografica_Codigo!=null: !( (target.ClasificacionGeografica_Codigo== String.Empty && source.ClasificacionGeografica_Codigo== null) || (target.ClasificacionGeografica_Codigo==null && source.ClasificacionGeografica_Codigo== String.Empty )) &&   !source.ClasificacionGeografica_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Nombre == null)?target.ClasificacionGeografica_Nombre!=null: !( (target.ClasificacionGeografica_Nombre== String.Empty && source.ClasificacionGeografica_Nombre== null) || (target.ClasificacionGeografica_Nombre==null && source.ClasificacionGeografica_Nombre== String.Empty )) &&   !source.ClasificacionGeografica_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
					  if((source.ClasificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.ClasificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.ClasificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.ClasificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaPadre))return false;
									  if(!source.ClasificacionGeografica_Activo.Equals(target.ClasificacionGeografica_Activo))return false;
					  if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null: !( (target.ClasificacionGeografica_Descripcion== String.Empty && source.ClasificacionGeografica_Descripcion== null) || (target.ClasificacionGeografica_Descripcion==null && source.ClasificacionGeografica_Descripcion== String.Empty )) &&   !source.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumbId == null)?target.ClasificacionGeografica_BreadcrumbId!=null: !( (target.ClasificacionGeografica_BreadcrumbId== String.Empty && source.ClasificacionGeografica_BreadcrumbId== null) || (target.ClasificacionGeografica_BreadcrumbId==null && source.ClasificacionGeografica_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumOrden == null)?target.ClasificacionGeografica_BreadcrumOrden!=null: !( (target.ClasificacionGeografica_BreadcrumOrden== String.Empty && source.ClasificacionGeografica_BreadcrumOrden== null) || (target.ClasificacionGeografica_BreadcrumOrden==null && source.ClasificacionGeografica_BreadcrumOrden== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Orden == null)?(target.ClasificacionGeografica_Orden.HasValue ):!source.ClasificacionGeografica_Orden.Equals(target.ClasificacionGeografica_Orden))return false;
						 if((source.ClasificacionGeografica_Nivel == null)?(target.ClasificacionGeografica_Nivel.HasValue ):!source.ClasificacionGeografica_Nivel.Equals(target.ClasificacionGeografica_Nivel))return false;
						 if((source.ClasificacionGeografica_DescripcionInvertida == null)?target.ClasificacionGeografica_DescripcionInvertida!=null: !( (target.ClasificacionGeografica_DescripcionInvertida== String.Empty && source.ClasificacionGeografica_DescripcionInvertida== null) || (target.ClasificacionGeografica_DescripcionInvertida==null && source.ClasificacionGeografica_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_Seleccionable.Equals(target.ClasificacionGeografica_Seleccionable))return false;
					  if((source.ClasificacionGeografica_BreadcrumbCode == null)?target.ClasificacionGeografica_BreadcrumbCode!=null: !( (target.ClasificacionGeografica_BreadcrumbCode== String.Empty && source.ClasificacionGeografica_BreadcrumbCode== null) || (target.ClasificacionGeografica_BreadcrumbCode==null && source.ClasificacionGeografica_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_DescripcionCodigo == null)?target.ClasificacionGeografica_DescripcionCodigo!=null: !( (target.ClasificacionGeografica_DescripcionCodigo== String.Empty && source.ClasificacionGeografica_DescripcionCodigo== null) || (target.ClasificacionGeografica_DescripcionCodigo==null && source.ClasificacionGeografica_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_Nombre == null)?target.Oficina_Nombre!=null: !( (target.Oficina_Nombre== String.Empty && source.Oficina_Nombre== null) || (target.Oficina_Nombre==null && source.Oficina_Nombre== String.Empty )) &&   !source.Oficina_Nombre.Trim().Replace ("\r","").Equals(target.Oficina_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_Codigo == null)?target.Oficina_Codigo!=null: !( (target.Oficina_Codigo== String.Empty && source.Oficina_Codigo== null) || (target.Oficina_Codigo==null && source.Oficina_Codigo== String.Empty )) &&   !source.Oficina_Codigo.Trim().Replace ("\r","").Equals(target.Oficina_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Activo.Equals(target.Oficina_Activo))return false;
					  if(!source.Oficina_Visible.Equals(target.Oficina_Visible))return false;
					  if((source.Oficina_IdOficinaPadre == null)?(target.Oficina_IdOficinaPadre.HasValue && target.Oficina_IdOficinaPadre.Value > 0):!source.Oficina_IdOficinaPadre.Equals(target.Oficina_IdOficinaPadre))return false;
									  if((source.Oficina_IdSaf == null)?(target.Oficina_IdSaf.HasValue && target.Oficina_IdSaf.Value > 0):!source.Oficina_IdSaf.Equals(target.Oficina_IdSaf))return false;
									  if((source.Oficina_BreadcrumbId == null)?target.Oficina_BreadcrumbId!=null: !( (target.Oficina_BreadcrumbId== String.Empty && source.Oficina_BreadcrumbId== null) || (target.Oficina_BreadcrumbId==null && source.Oficina_BreadcrumbId== String.Empty )) &&   !source.Oficina_BreadcrumbId.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_BreadcrumbOrden == null)?target.Oficina_BreadcrumbOrden!=null: !( (target.Oficina_BreadcrumbOrden== String.Empty && source.Oficina_BreadcrumbOrden== null) || (target.Oficina_BreadcrumbOrden==null && source.Oficina_BreadcrumbOrden== String.Empty )) &&   !source.Oficina_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Nivel.Equals(target.Oficina_Nivel))return false;
					  if((source.Oficina_Orden == null)?(target.Oficina_Orden.HasValue ):!source.Oficina_Orden.Equals(target.Oficina_Orden))return false;
						 if((source.Oficina_Descripcion == null)?target.Oficina_Descripcion!=null: !( (target.Oficina_Descripcion== String.Empty && source.Oficina_Descripcion== null) || (target.Oficina_Descripcion==null && source.Oficina_Descripcion== String.Empty )) &&   !source.Oficina_Descripcion.Trim().Replace ("\r","").Equals(target.Oficina_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_DescripcionInvertida == null)?target.Oficina_DescripcionInvertida!=null: !( (target.Oficina_DescripcionInvertida== String.Empty && source.Oficina_DescripcionInvertida== null) || (target.Oficina_DescripcionInvertida==null && source.Oficina_DescripcionInvertida== String.Empty )) &&   !source.Oficina_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Seleccionable.Equals(target.Oficina_Seleccionable))return false;
					  if((source.Oficina_BreadcrumbCode == null)?target.Oficina_BreadcrumbCode!=null: !( (target.Oficina_BreadcrumbCode== String.Empty && source.Oficina_BreadcrumbCode== null) || (target.Oficina_BreadcrumbCode==null && source.Oficina_BreadcrumbCode== String.Empty )) &&   !source.Oficina_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_DescripcionCodigo == null)?target.Oficina_DescripcionCodigo!=null: !( (target.Oficina_DescripcionCodigo== String.Empty && source.Oficina_DescripcionCodigo== null) || (target.Oficina_DescripcionCodigo==null && source.Oficina_DescripcionCodigo== String.Empty )) &&   !source.Oficina_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionCodigo.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
