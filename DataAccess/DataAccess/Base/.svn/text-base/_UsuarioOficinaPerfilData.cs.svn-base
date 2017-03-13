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
    public abstract class _UsuarioOficinaPerfilData : EntityData<UsuarioOficinaPerfil,UsuarioOficinaPerfilFilter,UsuarioOficinaPerfilResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.UsuarioOficinaPerfil entity)
		{			
			return entity.IdUsuarioOficinaPerfil;
		}		
		public override UsuarioOficinaPerfil GetByEntity(UsuarioOficinaPerfil entity)
        {
            return this.GetById(entity.IdUsuarioOficinaPerfil);
        }
        public override UsuarioOficinaPerfil GetById(int id)
        {
            return (from o in this.Table where o.IdUsuarioOficinaPerfil == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<UsuarioOficinaPerfil> Query(UsuarioOficinaPerfilFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdUsuarioOficinaPerfil == null || o.IdUsuarioOficinaPerfil >=  filter.IdUsuarioOficinaPerfil) && (filter.IdUsuarioOficinaPerfil_To == null || o.IdUsuarioOficinaPerfil <= filter.IdUsuarioOficinaPerfil_To)
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.HeredaConsulta == null || o.HeredaConsulta==filter.HeredaConsulta)
					  && (filter.HeredaEdicion == null || o.HeredaEdicion==filter.HeredaEdicion)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.AccesoTotal == null || o.AccesoTotal==filter.AccesoTotal)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<UsuarioOficinaPerfilResult> QueryResult(UsuarioOficinaPerfilFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario   
				   select new UsuarioOficinaPerfilResult(){
					 IdUsuarioOficinaPerfil=o.IdUsuarioOficinaPerfil
					 ,IdUsuario=o.IdUsuario
					 ,IdOficina=o.IdOficina
					 ,IdPerfil=o.IdPerfil
					 ,Activo=o.Activo
					 ,HeredaConsulta=o.HeredaConsulta
					 ,HeredaEdicion=o.HeredaEdicion
					 ,Codigo=o.Codigo
					 ,AccesoTotal=o.AccesoTotal
					,Oficina_Nombre= t1.Nombre	
						,Oficina_Codigo= t1.Codigo	
						,Oficina_Activo= t1.Activo	
						,Oficina_Visible= t1.Visible	
						,Oficina_IdOficinaPadre= t1.IdOficinaPadre	
						,Oficina_IdSaf= t1.IdSaf	
						,Oficina_BreadcrumbId= t1.BreadcrumbId	
						,Oficina_BreadcrumbOrden= t1.BreadcrumbOrden	
						,Oficina_Nivel= t1.Nivel	
						,Oficina_Orden= t1.Orden	
						,Oficina_Descripcion= t1.Descripcion	
						,Oficina_DescripcionInvertida= t1.DescripcionInvertida	
						,Oficina_Seleccionable= t1.Seleccionable	
						,Oficina_BreadcrumbCode= t1.BreadcrumbCode	
						,Oficina_DescripcionCodigo= t1.DescripcionCodigo	
						,Perfil_Nombre= t2.Nombre	
						,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
						,Perfil_Activo= t2.Activo	
						,Perfil_EsDefault= t2.EsDefault	
						,Perfil_Codigo= t2.Codigo	
						,Usuario_NombreUsuario= t3.NombreUsuario	
						,Usuario_Clave= t3.Clave	
						,Usuario_Activo= t3.Activo	
						,Usuario_EsSectioralista= t3.EsSectioralista	
						,Usuario_IdLanguage= t3.IdLanguage	
						,Usuario_AccesoTotal= t3.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.UsuarioOficinaPerfil Copy(nc.UsuarioOficinaPerfil entity)
        {           
            nc.UsuarioOficinaPerfil _new = new nc.UsuarioOficinaPerfil();
		 _new.IdUsuario= entity.IdUsuario;
		 _new.IdOficina= entity.IdOficina;
		 _new.IdPerfil= entity.IdPerfil;
		 _new.Activo= entity.Activo;
		 _new.HeredaConsulta= entity.HeredaConsulta;
		 _new.HeredaEdicion= entity.HeredaEdicion;
		 _new.Codigo= entity.Codigo;
		 _new.AccesoTotal= entity.AccesoTotal;
		return _new;			
        }
		public override int CopyAndSave(UsuarioOficinaPerfil entity,string renameFormat)
        {
            UsuarioOficinaPerfil  newEntity = Copy(entity);
            newEntity.Codigo = string.Format(renameFormat,newEntity.Codigo);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(UsuarioOficinaPerfil entity, int id)
        {            
            entity.IdUsuarioOficinaPerfil = id;            
        }
		public override void Set(UsuarioOficinaPerfil source,UsuarioOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioOficinaPerfil= source.IdUsuarioOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Activo= source.Activo ;
		 target.HeredaConsulta= source.HeredaConsulta ;
		 target.HeredaEdicion= source.HeredaEdicion ;
		 target.Codigo= source.Codigo ;
		 target.AccesoTotal= source.AccesoTotal ;
		 		  
		}
		public override void Set(UsuarioOficinaPerfilResult source,UsuarioOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioOficinaPerfil= source.IdUsuarioOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Activo= source.Activo ;
		 target.HeredaConsulta= source.HeredaConsulta ;
		 target.HeredaEdicion= source.HeredaEdicion ;
		 target.Codigo= source.Codigo ;
		 target.AccesoTotal= source.AccesoTotal ;
		 
		}
		public override void Set(UsuarioOficinaPerfil source,UsuarioOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioOficinaPerfil= source.IdUsuarioOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Activo= source.Activo ;
		 target.HeredaConsulta= source.HeredaConsulta ;
		 target.HeredaEdicion= source.HeredaEdicion ;
		 target.Codigo= source.Codigo ;
		 target.AccesoTotal= source.AccesoTotal ;
		 	
		}		
		public override void Set(UsuarioOficinaPerfilResult source,UsuarioOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdUsuarioOficinaPerfil= source.IdUsuarioOficinaPerfil ;
		 target.IdUsuario= source.IdUsuario ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Activo= source.Activo ;
		 target.HeredaConsulta= source.HeredaConsulta ;
		 target.HeredaEdicion= source.HeredaEdicion ;
		 target.Codigo= source.Codigo ;
		 target.AccesoTotal= source.AccesoTotal ;
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
			target.Perfil_Nombre= source.Perfil_Nombre;	
			target.Perfil_IdPerfilTipo= source.Perfil_IdPerfilTipo;	
			target.Perfil_Activo= source.Perfil_Activo;	
			target.Perfil_EsDefault= source.Perfil_EsDefault;	
			target.Perfil_Codigo= source.Perfil_Codigo;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(UsuarioOficinaPerfil source,UsuarioOficinaPerfil target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuarioOficinaPerfil.Equals(target.IdUsuarioOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.HeredaConsulta.Equals(target.HeredaConsulta))return false;
		  if(!source.HeredaEdicion.Equals(target.HeredaEdicion))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.AccesoTotal.Equals(target.AccesoTotal))return false;
		 
		  return true;
        }
		public override bool Equals(UsuarioOficinaPerfilResult source,UsuarioOficinaPerfilResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdUsuarioOficinaPerfil.Equals(target.IdUsuarioOficinaPerfil))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.HeredaConsulta.Equals(target.HeredaConsulta))return false;
		  if(!source.HeredaEdicion.Equals(target.HeredaEdicion))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.AccesoTotal.Equals(target.AccesoTotal))return false;
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
						 if((source.Perfil_Nombre == null)?target.Perfil_Nombre!=null: !( (target.Perfil_Nombre== String.Empty && source.Perfil_Nombre== null) || (target.Perfil_Nombre==null && source.Perfil_Nombre== String.Empty )) &&   !source.Perfil_Nombre.Trim().Replace ("\r","").Equals(target.Perfil_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Perfil_IdPerfilTipo.Equals(target.Perfil_IdPerfilTipo))return false;
					  if(!source.Perfil_Activo.Equals(target.Perfil_Activo))return false;
					  if(!source.Perfil_EsDefault.Equals(target.Perfil_EsDefault))return false;
					  if((source.Perfil_Codigo == null)?target.Perfil_Codigo!=null: !( (target.Perfil_Codigo== String.Empty && source.Perfil_Codigo== null) || (target.Perfil_Codigo==null && source.Perfil_Codigo== String.Empty )) &&   !source.Perfil_Codigo.Trim().Replace ("\r","").Equals(target.Perfil_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
					  if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
					  if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
