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
    public abstract class _MessageMediaData : EntityData<MessageMedia,MessageMediaFilter,MessageMediaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.MessageMedia entity)
		{			
			return entity.IdMessageMedia;
		}		
		public override MessageMedia GetByEntity(MessageMedia entity)
        {
            return this.GetById(entity.IdMessageMedia);
        }
        public override MessageMedia GetById(int id)
        {
            return (from o in this.Table where o.IdMessageMedia == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<MessageMedia> Query(MessageMediaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMessageMedia == null || filter.IdMessageMedia == 0 || o.IdMessageMedia==filter.IdMessageMedia)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Img == null || filter.Img.Trim() == string.Empty || filter.Img.Trim() == "%"  || (filter.Img.EndsWith("%") && filter.Img.StartsWith("%") && (o.Img.Contains(filter.Img.Replace("%", "")))) || (filter.Img.EndsWith("%") && o.Img.StartsWith(filter.Img.Replace("%",""))) || (filter.Img.StartsWith("%") && o.Img.EndsWith(filter.Img.Replace("%",""))) || o.Img == filter.Img )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MessageMediaResult> QueryResult(MessageMediaFilter filter)
        {
		  return (from o in Query(filter)					
					select new MessageMediaResult(){
					 IdMessageMedia=o.IdMessageMedia
					 ,Name=o.Name
					 ,Img=o.Img
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.MessageMedia Copy(nc.MessageMedia entity)
        {           
            nc.MessageMedia _new = new nc.MessageMedia();
		 _new.Name= entity.Name;
		 _new.Img= entity.Img;
		return _new;			
        }
		public override int CopyAndSave(MessageMedia entity,string renameFormat)
        {
            MessageMedia  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(MessageMedia entity, int id)
        {            
            entity.IdMessageMedia = id;            
        }
		public override void Set(MessageMedia source,MessageMedia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageMedia= source.IdMessageMedia ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 		  
		}
		public override void Set(MessageMediaResult source,MessageMedia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageMedia= source.IdMessageMedia ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 
		}
		public override void Set(MessageMedia source,MessageMediaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageMedia= source.IdMessageMedia ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 	
		}		
		public override void Set(MessageMediaResult source,MessageMediaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageMedia= source.IdMessageMedia ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(MessageMedia source,MessageMedia target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageMedia.Equals(target.IdMessageMedia))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Img == null)?target.Img!=null:  !( (target.Img== String.Empty && source.Img== null) || (target.Img==null && source.Img== String.Empty )) &&  !source.Img.Trim().Replace ("\r","").Equals(target.Img.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(MessageMediaResult source,MessageMediaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageMedia.Equals(target.IdMessageMedia))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Img == null)?target.Img!=null: !( (target.Img== String.Empty && source.Img== null) || (target.Img==null && source.Img== String.Empty )) && !source.Img.Trim().Replace ("\r","").Equals(target.Img.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
