using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MessageAttachData : EntityData<MessageAttach, MessageAttachFilter, MessageAttachResult, int>
    {
	   #region Singleton
	   private static volatile MessageAttachData current;
	   private static object syncRoot = new Object();

	   //private MessageAttachData() {}
	   public static MessageAttachData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageAttachData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMessageAttach"; } }    
        #region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.MessageAttach entity)
		{			
			return entity.IdMessageAttach;
		}		
		public override MessageAttach GetByEntity(MessageAttach entity)
        {
            return this.GetById(entity.IdMessageAttach);
        }
        public override MessageAttach GetById(int id)
        {
            return (from o in this.Table where o.IdMessageAttach == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<MessageAttach> Query(MessageAttachFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMessageAttach == null || o.IdMessageAttach >=  filter.IdMessageAttach) && (filter.IdMessageAttach_To == null || o.IdMessageAttach <= filter.IdMessageAttach_To)
					  && (filter.IdMessage == null || filter.IdMessage == 0 || o.IdMessage==filter.IdMessage)
					  && (filter.FileName == null || filter.FileName.Trim() == string.Empty || filter.FileName.Trim() == "%"  || (filter.FileName.EndsWith("%") && filter.FileName.StartsWith("%") && (o.FileName.Contains(filter.FileName.Replace("%", "")))) || (filter.FileName.EndsWith("%") && o.FileName.StartsWith(filter.FileName.Replace("%",""))) || (filter.FileName.StartsWith("%") && o.FileName.EndsWith(filter.FileName.Replace("%",""))) || o.FileName == filter.FileName )
					  && (filter.FileType == null || filter.FileType.Trim() == string.Empty || filter.FileType.Trim() == "%"  || (filter.FileType.EndsWith("%") && filter.FileType.StartsWith("%") && (o.FileType.Contains(filter.FileType.Replace("%", "")))) || (filter.FileType.EndsWith("%") && o.FileType.StartsWith(filter.FileType.Replace("%",""))) || (filter.FileType.StartsWith("%") && o.FileType.EndsWith(filter.FileType.Replace("%",""))) || o.FileType == filter.FileType )
					  && (filter.FileContent == null || o.FileContent==filter.FileContent)
					  && (filter.FileContentIsNull == null || filter.FileContentIsNull == true || o.FileContent != null ) && (filter.FileContentIsNull == null || filter.FileContentIsNull == false || o.FileContent == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MessageAttachResult> QueryResult(MessageAttachFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Messages on o.IdMessage equals t1.IdMessage   
				   select new MessageAttachResult(){
					 IdMessageAttach=o.IdMessageAttach
					 ,IdMessage=o.IdMessage
					 ,FileName=o.FileName
					 ,FileType=o.FileType
					 //,FileContent=o.FileContent
					,Message_IdMediaFrom= t1.IdMediaFrom	
						,Message_IdUserFrom= t1.IdUserFrom	
						,Message_IdPriority= t1.IdPriority	
						,Message_Subject= t1.Subject	
						,Message_Body= t1.Body	
						,Message_StartDate= t1.StartDate	
						,Message_SendDate= t1.SendDate	
						,Message_IsManual= t1.IsManual	
						,Message_IdProyecto= t1.IdProyecto	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.MessageAttach Copy(nc.MessageAttach entity)
        {           
            nc.MessageAttach _new = new nc.MessageAttach();
		 _new.IdMessage= entity.IdMessage;
		 _new.FileName= entity.FileName;
		 _new.FileType= entity.FileType;
		 _new.FileContent= entity.FileContent;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(MessageAttach entity, int id)
        {            
            entity.IdMessageAttach = id;            
        }
		public override void Set(MessageAttach source,MessageAttach target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageAttach= source.IdMessageAttach ;
		 target.IdMessage= source.IdMessage ;
		 target.FileName= source.FileName ;
		 target.FileType= source.FileType ;
		 target.FileContent= source.FileContent ;
		 		  
		}
		public override void Set(MessageAttachResult source,MessageAttach target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageAttach= source.IdMessageAttach ;
		 target.IdMessage= source.IdMessage ;
		 target.FileName= source.FileName ;
		 target.FileType= source.FileType ;
		 //target.FileContent= source.FileContent ;
		 
		}
		public override void Set(MessageAttach source,MessageAttachResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageAttach= source.IdMessageAttach ;
		 target.IdMessage= source.IdMessage ;
		 target.FileName= source.FileName ;
		 target.FileType= source.FileType ;
		 //target.FileContent= source.FileContent ;
		 	
		}		
		public override void Set(MessageAttachResult source,MessageAttachResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageAttach= source.IdMessageAttach ;
		 target.IdMessage= source.IdMessage ;
		 target.FileName= source.FileName ;
		 target.FileType= source.FileType ;
		 //target.FileContent= source.FileContent ;
		 target.Message_IdMediaFrom= source.Message_IdMediaFrom;	
			target.Message_IdUserFrom= source.Message_IdUserFrom;	
			target.Message_IdPriority= source.Message_IdPriority;	
			target.Message_Subject= source.Message_Subject;	
			target.Message_Body= source.Message_Body;	
			target.Message_StartDate= source.Message_StartDate;	
			target.Message_SendDate= source.Message_SendDate;	
			target.Message_IsManual= source.Message_IsManual;	
			target.Message_IdProyecto= source.Message_IdProyecto;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(MessageAttach source,MessageAttach target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageAttach.Equals(target.IdMessageAttach))return false;
		  if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.FileName.Equals(target.FileName))return false;
		  if(!source.FileType.Equals(target.FileType))return false;
		  if((source.FileContent == null)?target.FileContent!=null:!source.FileContent.Equals(target.FileContent))return false;
			
		  return true;
        }
		public override bool Equals(MessageAttachResult source,MessageAttachResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageAttach.Equals(target.IdMessageAttach))return false;
		  if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.FileName.Equals(target.FileName))return false;
		  if(!source.FileType.Equals(target.FileType))return false;
		  //if((source.FileContent == null)?target.FileContent!=null:!source.FileContent.Equals(target.FileContent))return false;
			 if(!source.Message_IdMediaFrom.Equals(target.Message_IdMediaFrom))return false;
					  if(!source.Message_IdUserFrom.Equals(target.Message_IdUserFrom))return false;
					  if(!source.Message_IdPriority.Equals(target.Message_IdPriority))return false;
					  if(!source.Message_Subject.Equals(target.Message_Subject))return false;
					  if(!source.Message_Body.Equals(target.Message_Body))return false;
					  if(!source.Message_StartDate.Equals(target.Message_StartDate))return false;
					  if((source.Message_SendDate == null)?target.Message_SendDate!=null:!source.Message_SendDate.Equals(target.Message_SendDate))return false;
						 if(!source.Message_IsManual.Equals(target.Message_IsManual))return false;
					  if((source.Message_IdProyecto == null)?(target.Message_IdProyecto.HasValue && target.Message_IdProyecto.Value > 0):!source.Message_IdProyecto.Equals(target.Message_IdProyecto))return false;
									 		
		  return true;
        }
		#endregion
    }
}
