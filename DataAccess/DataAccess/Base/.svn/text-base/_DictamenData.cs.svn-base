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
    public abstract class _DictamenData : EntityData<Dictamen,DictamenFilter,DictamenResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Dictamen entity)
		{			
			return entity.IdDictamen;
		}		
		public override Dictamen GetByEntity(Dictamen entity)
        {
            return this.GetById(entity.IdDictamen);
        }
        public override Dictamen GetById(int id)
        {
            return (from o in this.Table where o.IdDictamen == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Dictamen> Query(DictamenFilter filter)
        {
			return (from o in this.Table
                      where (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdDictamenTipo == null || filter.IdDictamenTipo == 0 || o.IdDictamenTipo==filter.IdDictamenTipo)
					  && (filter.IdDictamenPadre == null || filter.IdDictamenPadre == 0 || o.IdDictamenPadre==filter.IdDictamenPadre)
					  && (filter.IdDictamenPadreIsNull == null || filter.IdDictamenPadreIsNull == true || o.IdDictamenPadre != null ) && (filter.IdDictamenPadreIsNull == null || filter.IdDictamenPadreIsNull == false || o.IdDictamenPadre == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<DictamenResult> QueryResult(DictamenFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Dictamens on o.IdDictamenPadre equals _t1.IdDictamen into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.DictamenTipos on o.IdDictamenTipo equals t2.IdDictamenTipo   
				   select new DictamenResult(){
					 IdDictamen=o.IdDictamen
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					 ,IdDictamenTipo=o.IdDictamenTipo
					 ,IdDictamenPadre=o.IdDictamenPadre
					,DictamenPadre_Nombre= t1!=null?(string)t1.Nombre:null	
						,DictamenPadre_Activo= t1!=null?(bool?)t1.Activo:null	
						,DictamenPadre_IdDictamenTipo= t1!=null?(int?)t1.IdDictamenTipo:null	
						,DictamenPadre_IdDictamenPadre= t1!=null?(int?)t1.IdDictamenPadre:null	
						,DictamenTipo_Nombre= t2.Nombre	
						,DictamenTipo_Nivel= t2.Nivel	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Dictamen Copy(nc.Dictamen entity)
        {           
            nc.Dictamen _new = new nc.Dictamen();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		 _new.IdDictamenTipo= entity.IdDictamenTipo;
		 _new.IdDictamenPadre= entity.IdDictamenPadre;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(Dictamen entity, int id)
        {            
            entity.IdDictamen = id;            
        }
		public override void Set(Dictamen source,Dictamen target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamen= source.IdDictamen ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.IdDictamenPadre= source.IdDictamenPadre ;
		 		  
		}
		public override void Set(DictamenResult source,Dictamen target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamen= source.IdDictamen ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.IdDictamenPadre= source.IdDictamenPadre ;
		 
		}
		public override void Set(Dictamen source,DictamenResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamen= source.IdDictamen ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.IdDictamenPadre= source.IdDictamenPadre ;
		 	
		}		
		public override void Set(DictamenResult source,DictamenResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamen= source.IdDictamen ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.IdDictamenPadre= source.IdDictamenPadre ;
		 target.DictamenPadre_Nombre= source.DictamenPadre_Nombre;	
			target.DictamenPadre_Activo= source.DictamenPadre_Activo;	
			target.DictamenPadre_IdDictamenTipo= source.DictamenPadre_IdDictamenTipo;	
			target.DictamenPadre_IdDictamenPadre= source.DictamenPadre_IdDictamenPadre;	
			target.DictamenTipo_Nombre= source.DictamenTipo_Nombre;	
			target.DictamenTipo_Nivel= source.DictamenTipo_Nivel;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Dictamen source,Dictamen target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdDictamen.Equals(target.IdDictamen))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.IdDictamenTipo.Equals(target.IdDictamenTipo))return false;
		  if((source.IdDictamenPadre == null)?(target.IdDictamenPadre.HasValue && target.IdDictamenPadre.Value > 0):!source.IdDictamenPadre.Equals(target.IdDictamenPadre))return false;
						 
		  return true;
        }
		public override bool Equals(DictamenResult source,DictamenResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdDictamen.Equals(target.IdDictamen))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.IdDictamenTipo.Equals(target.IdDictamenTipo))return false;
		  if((source.IdDictamenPadre == null)?(target.IdDictamenPadre.HasValue && target.IdDictamenPadre.Value > 0):!source.IdDictamenPadre.Equals(target.IdDictamenPadre))return false;
						  if(!source.DictamenPadre_Nombre.Equals(target.DictamenPadre_Nombre))return false;
					  if(!source.DictamenPadre_Activo.Equals(target.DictamenPadre_Activo))return false;
					  if(!source.DictamenPadre_IdDictamenTipo.Equals(target.DictamenPadre_IdDictamenTipo))return false;
					  if((source.DictamenPadre_IdDictamenPadre == null)?(target.DictamenPadre_IdDictamenPadre.HasValue && target.DictamenPadre_IdDictamenPadre.Value > 0):!source.DictamenPadre_IdDictamenPadre.Equals(target.DictamenPadre_IdDictamenPadre))return false;
									  if(!source.DictamenTipo_Nombre.Equals(target.DictamenTipo_Nombre))return false;
					  if(!source.DictamenTipo_Nivel.Equals(target.DictamenTipo_Nivel))return false;
					 		
		  return true;
        }
		#endregion
    }
}
