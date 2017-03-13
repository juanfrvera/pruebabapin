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
    public abstract class _MessageSendData : EntityData<MessageSend,MessageSendFilter,MessageSendResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.MessageSend entity)
		{			
			return entity.IdMessageSend;
		}		
		public override MessageSend GetByEntity(MessageSend entity)
        {
            return this.GetById(entity.IdMessageSend);
        }
        public override MessageSend GetById(int id)
        {
            return (from o in this.Table where o.IdMessageSend == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<MessageSend> Query(MessageSendFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMessageSend == null || o.IdMessageSend >=  filter.IdMessageSend) && (filter.IdMessageSend_To == null || o.IdMessageSend <= filter.IdMessageSend_To)
					  && (filter.IdMessage == null || filter.IdMessage == 0 || o.IdMessage==filter.IdMessage)
					  && (filter.IdUserTo == null || filter.IdUserTo == 0 || o.IdUserTo==filter.IdUserTo)
					  && (filter.IdMediaTo == null || filter.IdMediaTo == 0 || o.IdMediaTo==filter.IdMediaTo)
					  && (filter.IsRead == null || o.IsRead==filter.IsRead)
					  && (filter.ReadDate == null || filter.ReadDate == DateTime.MinValue || o.ReadDate >=  filter.ReadDate) && (filter.ReadDate_To == null || filter.ReadDate_To == DateTime.MinValue || o.ReadDate <= filter.ReadDate_To)
					  && (filter.ReadDateIsNull == null || filter.ReadDateIsNull == true || o.ReadDate != null ) && (filter.ReadDateIsNull == null || filter.ReadDateIsNull == false || o.ReadDate == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MessageSendResult> QueryResult(MessageSendFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Messages on o.IdMessage equals t1.IdMessage   
				    join t2  in this.Context.MessageMedias on o.IdMediaTo equals t2.IdMessageMedia   
				    join t3  in this.Context.Usuarios on o.IdUserTo equals t3.IdUsuario   
				   select new MessageSendResult(){
					 IdMessageSend=o.IdMessageSend
					 ,IdMessage=o.IdMessage
					 ,IdUserTo=o.IdUserTo
					 ,IdMediaTo=o.IdMediaTo
					 ,IsRead=o.IsRead
					 ,ReadDate=o.ReadDate
					,Message_IdMediaFrom= t1.IdMediaFrom	
						,Message_IdUserFrom= t1.IdUserFrom	
						,Message_IdPriority= t1.IdPriority	
						,Message_Subject= t1.Subject	
						,Message_Body= t1.Body	
						,Message_StartDate= t1.StartDate	
						,Message_SendDate= t1.SendDate	
						,Message_IsManual= t1.IsManual	
						,Message_IdProyecto= t1.IdProyecto	
						,MediaTo_Name= t2.Name	
						,MediaTo_Img= t2.Img	
						,UserTo_NombreUsuario= t3.NombreUsuario	
						,UserTo_Clave= t3.Clave	
						,UserTo_Activo= t3.Activo	
						,UserTo_EsSectioralista= t3.EsSectioralista	
						,UserTo_IdLanguage= t3.IdLanguage	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.MessageSend Copy(nc.MessageSend entity)
        {           
            nc.MessageSend _new = new nc.MessageSend();
		 _new.IdMessage= entity.IdMessage;
		 _new.IdUserTo= entity.IdUserTo;
		 _new.IdMediaTo= entity.IdMediaTo;
		 _new.IsRead= entity.IsRead;
		 _new.ReadDate= entity.ReadDate;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(MessageSend entity, int id)
        {            
            entity.IdMessageSend = id;            
        }
		public override void Set(MessageSend source,MessageSend target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageSend= source.IdMessageSend ;
		 target.IdMessage= source.IdMessage ;
		 target.IdUserTo= source.IdUserTo ;
		 target.IdMediaTo= source.IdMediaTo ;
		 target.IsRead= source.IsRead ;
		 target.ReadDate= source.ReadDate ;
		 		  
		}
		public override void Set(MessageSendResult source,MessageSend target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageSend= source.IdMessageSend ;
		 target.IdMessage= source.IdMessage ;
		 target.IdUserTo= source.IdUserTo ;
		 target.IdMediaTo= source.IdMediaTo ;
		 target.IsRead= source.IsRead ;
		 target.ReadDate= source.ReadDate ;
		 
		}
		public override void Set(MessageSend source,MessageSendResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageSend= source.IdMessageSend ;
		 target.IdMessage= source.IdMessage ;
		 target.IdUserTo= source.IdUserTo ;
		 target.IdMediaTo= source.IdMediaTo ;
		 target.IsRead= source.IsRead ;
		 target.ReadDate= source.ReadDate ;
		 	
		}		
		public override void Set(MessageSendResult source,MessageSendResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMessageSend= source.IdMessageSend ;
		 target.IdMessage= source.IdMessage ;
		 target.IdUserTo= source.IdUserTo ;
		 target.IdMediaTo= source.IdMediaTo ;
		 target.IsRead= source.IsRead ;
		 target.ReadDate= source.ReadDate ;
		 target.Message_IdMediaFrom= source.Message_IdMediaFrom;	
			target.Message_IdUserFrom= source.Message_IdUserFrom;	
			target.Message_IdPriority= source.Message_IdPriority;	
			target.Message_Subject= source.Message_Subject;	
			target.Message_Body= source.Message_Body;	
			target.Message_StartDate= source.Message_StartDate;	
			target.Message_SendDate= source.Message_SendDate;	
			target.Message_IsManual= source.Message_IsManual;	
			target.Message_IdProyecto= source.Message_IdProyecto;	
			target.MediaTo_Name= source.MediaTo_Name;	
			target.MediaTo_Img= source.MediaTo_Img;	
			target.UserTo_NombreUsuario= source.UserTo_NombreUsuario;	
			target.UserTo_Clave= source.UserTo_Clave;	
			target.UserTo_Activo= source.UserTo_Activo;	
			target.UserTo_EsSectioralista= source.UserTo_EsSectioralista;	
			target.UserTo_IdLanguage= source.UserTo_IdLanguage;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(MessageSend source,MessageSend target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageSend.Equals(target.IdMessageSend))return false;
		  if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.IdUserTo.Equals(target.IdUserTo))return false;
		  if(!source.IdMediaTo.Equals(target.IdMediaTo))return false;
		  if(!source.IsRead.Equals(target.IsRead))return false;
		  if((source.ReadDate == null)?target.ReadDate!=null:!source.ReadDate.Equals(target.ReadDate))return false;
			
		  return true;
        }
		public override bool Equals(MessageSendResult source,MessageSendResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMessageSend.Equals(target.IdMessageSend))return false;
		  if(!source.IdMessage.Equals(target.IdMessage))return false;
		  if(!source.IdUserTo.Equals(target.IdUserTo))return false;
		  if(!source.IdMediaTo.Equals(target.IdMediaTo))return false;
		  if(!source.IsRead.Equals(target.IsRead))return false;
		  if((source.ReadDate == null)?target.ReadDate!=null:!source.ReadDate.Equals(target.ReadDate))return false;
			 if(!source.Message_IdMediaFrom.Equals(target.Message_IdMediaFrom))return false;
					  if(!source.Message_IdUserFrom.Equals(target.Message_IdUserFrom))return false;
					  if(!source.Message_IdPriority.Equals(target.Message_IdPriority))return false;
					  if(!source.Message_Subject.Equals(target.Message_Subject))return false;
					  if(!source.Message_Body.Equals(target.Message_Body))return false;
					  if(!source.Message_StartDate.Equals(target.Message_StartDate))return false;
					  if((source.Message_SendDate == null)?target.Message_SendDate!=null:!source.Message_SendDate.Equals(target.Message_SendDate))return false;
						 if(!source.Message_IsManual.Equals(target.Message_IsManual))return false;
					  if((source.Message_IdProyecto == null)?(target.Message_IdProyecto.HasValue && target.Message_IdProyecto.Value > 0):!source.Message_IdProyecto.Equals(target.Message_IdProyecto))return false;
									  if(!source.MediaTo_Name.Equals(target.MediaTo_Name))return false;
					  if(!source.MediaTo_Img.Equals(target.MediaTo_Img))return false;
					  if(!source.UserTo_NombreUsuario.Equals(target.UserTo_NombreUsuario))return false;
					  if(!source.UserTo_Clave.Equals(target.UserTo_Clave))return false;
					  if(!source.UserTo_Activo.Equals(target.UserTo_Activo))return false;
					  if(!source.UserTo_EsSectioralista.Equals(target.UserTo_EsSectioralista))return false;
					  if(!source.UserTo_IdLanguage.Equals(target.UserTo_IdLanguage))return false;
					 		
		  return true;
        }
		#endregion
    }
}
