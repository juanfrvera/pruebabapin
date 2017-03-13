using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class MessageSendResult : IResult<int>
    {
        public virtual int ID { get { return IdMessageSend; } }
        public int IdMessageSend { get; set; }
        public int IdMessage { get; set; }
        public int IdUserTo { get; set; }
        public int IdMediaTo { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }

        public int Message_IdMediaFrom { get; set; }
        public int Message_IdUserFrom { get; set; }
        public string Message_UserFrom_NombreCompleto { get; set; }
        public string Message_Body { get; set; }
        public int Message_IdPriority { get; set; }
        public string Message_NamePriority { get; set; }
        public string Message_Subject { get; set; }
        public DateTime Message_StartDate { get; set; }
        public DateTime? Message_SendDate { get; set; }
        public bool Message_IsManual { get; set; }
        public int? Message_IdProyecto { get; set; }
        public int? Message_Proyecto_Codigo { get; set; }
        public string MediaTo_Name { get; set; }
        public string MediaTo_Img { get; set; }

        public string UserTo_NombreUsuario { get; set; }        
        public string UserTo_NombreCompleto { get; set; }
        public string Project_Denominacion { get; set; }

        public virtual MessageSend ToEntity()
        {
            MessageSend _MessageSend = new MessageSend();
            _MessageSend.IdMessageSend = this.IdMessageSend;
            _MessageSend.IdMessage = this.IdMessage;
            _MessageSend.IdUserTo = this.IdUserTo;
            _MessageSend.IdMediaTo = this.IdMediaTo;
            _MessageSend.IsRead = this.IsRead;
            _MessageSend.ReadDate = this.ReadDate;

            return _MessageSend;
        }
        public virtual void Set(MessageSend entity)
        {
            this.IdMessageSend = entity.IdMessageSend;
            this.IdMessage = entity.IdMessage;
            this.IdUserTo = entity.IdUserTo;
            this.IdMediaTo = entity.IdMediaTo;
            this.IsRead = entity.IsRead;
            this.ReadDate = entity.ReadDate;

        }
        public virtual bool Equals(MessageSend entity)
        {
            if (entity == null) return false;
            if (!entity.IdMessageSend.Equals(this.IdMessageSend)) return false;
            if (!entity.IdMessage.Equals(this.IdMessage)) return false;
            if (!entity.IdUserTo.Equals(this.IdUserTo)) return false;
            if (!entity.IdMediaTo.Equals(this.IdMediaTo)) return false;
            if (!entity.IsRead.Equals(this.IsRead)) return false;
            if ((entity.ReadDate == null) ? this.ReadDate != null : !entity.ReadDate.Equals(this.ReadDate)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("MessageSend", new List<DataColumnMapping>(new DataColumnMapping[]{
		
			new DataColumnMapping("De","Message_UserFrom_NombreCompleto")
            ,new DataColumnMapping("Fecha","Message_StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("A","UserTo_NombreCompleto")
			,new DataColumnMapping("Prioridad","Message_NamePriority")
			,new DataColumnMapping("Código BAPIN","Message_Proyecto_Codigo")
			,new DataColumnMapping("Asunto","Message_Subject")
			,new DataColumnMapping("Leído","IsRead")
			,new DataColumnMapping("Es Manual","Message_IsManual")
			,new DataColumnMapping("Fecha Leído","ReadDate","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Mensaje","Message_Body","HtmlToPlainText")
			}));
        }
        

    }
}
