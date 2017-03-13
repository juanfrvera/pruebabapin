using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MessageSendData : EntityData<MessageSend, MessageSendFilter, MessageSendResult, int>
    {
        #region Singleton
        private static volatile MessageSendData current;
        private static object syncRoot = new Object();

        //private MessageSendData() {}
        public static MessageSendData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageSendData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdMessageSend"; } }

        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
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
                    join t1 in this.Context.Messages on o.IdMessage equals t1.IdMessage
                    where (filter.IdMessageSend == null || filter.IdMessageSend == 0 || o.IdMessageSend == filter.IdMessageSend)
                      && (filter.IdMessage == null || filter.IdMessage == 0 || o.IdMessage == filter.IdMessage)
                      && (filter.IdUserTo == null || filter.IdUserTo == 0 || o.IdUserTo == filter.IdUserTo)
                      && (filter.IdMediaTo == null || filter.IdMediaTo == 0 || o.IdMediaTo == filter.IdMediaTo)
                      && (filter.IsRead == null || o.IsRead == filter.IsRead)
                      && (filter.ReadDate == null || filter.ReadDate == DateTime.MinValue || o.ReadDate >= filter.ReadDate) && (filter.ReadDate_To == null || filter.ReadDate_To == DateTime.MinValue || (o.ReadDate <= filter.ReadDate_To))
                      && (filter.ReadDateIsNull == null || filter.ReadDateIsNull == true || o.ReadDate != null) && (filter.ReadDateIsNull == null || filter.ReadDateIsNull == false || o.ReadDate == null)
                      && (filter.IdUserFrom == null || filter.IdUserFrom == 0 || t1.IdUserFrom == filter.IdUserFrom)
                      && (filter.IdPriority == null || filter.IdPriority == 0 || t1.IdPriority == filter.IdPriority)
                      && (filter.Subject == null || filter.Subject.Trim() == string.Empty || filter.Subject.Trim() == "%" || (filter.Subject.EndsWith("%") && filter.Subject.StartsWith("%") && (t1.Subject.Contains(filter.Subject.Replace("%", "")))) || (filter.Subject.EndsWith("%") && t1.Subject.StartsWith(filter.Subject.Replace("%", ""))) || (filter.Subject.StartsWith("%") && t1.Subject.EndsWith(filter.Subject.Replace("%", ""))) || t1.Subject == filter.Subject)
                      && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || t1.StartDate >= filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || t1.StartDate <= filter.StartDate_To)
                      && (filter.SendDate == null || filter.SendDate == DateTime.MinValue || t1.SendDate >= filter.SendDate) && (filter.SendDate_To == null || filter.SendDate_To == DateTime.MinValue || t1.SendDate <= filter.SendDate_To)
                      && (filter.SendDateIsNull == null || filter.SendDateIsNull == true || t1.SendDate != null) && (filter.SendDateIsNull == null || filter.SendDateIsNull == false || t1.SendDate == null)
                      && (filter.IsManual == null || t1.IsManual == filter.IsManual)
                      && (filter.IdProyecto == null || filter.IdProyecto == 0 || t1.IdProyecto == filter.IdProyecto)
                      && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == true || t1.IdProyecto != null) && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == false || t1.IdProyecto == null)
                      && (filter.IsRecibido == null || (filter.IsRecibido == false && t1.IdUserFrom == filter.UsuarioBandeja) || (filter.IsRecibido == true && o.IdUserTo == filter.UsuarioBandeja))
                      && (filter.UsuarioBandeja == null || (filter.UsuarioBandeja == t1.IdUserFrom || filter.UsuarioBandeja == o.IdUserTo)
                      && (filter.Project_Codigo == null || (from p in this.Context.Proyectos where filter.Project_Codigo == p.Codigo select p.IdProyecto).Contains(t1.IdProyecto.Value))
                      )
                    select o
                    ).AsQueryable();
        }
        protected override IQueryable<MessageSendResult> QueryResult(MessageSendFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.Messages on o.IdMessage equals t1.IdMessage
                    join t2 in this.Context.MessageMedias on o.IdMediaTo equals t2.IdMessageMedia
                    join t3 in this.Context.Usuarios on o.IdUserTo equals t3.IdUsuario
                    join t4 in this.Context.Priorities on t1.IdPriority equals t4.IdPriority
                    join p3 in this.Context.Personas on t3.IdUsuario equals p3.IdPersona
                    join p1 in this.Context.Personas on t1.IdUserFrom equals p1.IdPersona
                    join _py in this.Context.Proyectos on t1.IdProyecto equals _py.IdProyecto into tpy
                    from py in tpy.DefaultIfEmpty()
                    select new MessageSendResult()
                    {
                        IdMessageSend = o.IdMessageSend
                        ,
                        IdMessage = o.IdMessage
                        ,
                        IdUserTo = o.IdUserTo
                        ,
                        IdMediaTo = o.IdMediaTo
                        ,
                        IsRead = o.IsRead
                        ,
                        ReadDate = o.ReadDate
                        ,
                        Message_IdMediaFrom = t1.IdMediaFrom
                        ,
                        Message_IdUserFrom = t1.IdUserFrom
                        ,
                        Message_UserFrom_NombreCompleto = (p1.Apellido == string.Empty) ? p1.Nombre : (p1.Nombre == string.Empty) ? p1.Apellido : p1.Apellido + ", " + p1.Nombre
                        ,
                        Message_Body = t1.Body
                        ,
                        Message_IdPriority = t1.IdPriority
                        ,
                        Message_NamePriority = t4.Name
                        ,
                        Message_Subject = t1.Subject
                        ,
                        Message_StartDate = t1.StartDate
                        ,
                        Message_SendDate = t1.SendDate
                        ,
                        Message_IsManual = t1.IsManual
                        ,
                        Message_IdProyecto = t1.IdProyecto
                        ,
                        Message_Proyecto_Codigo = py != null ? (int?)py.Codigo : null
                        ,
                        MediaTo_Name = t2.Name
                        ,
                        MediaTo_Img = t2.Img
                        ,
                        UserTo_NombreUsuario = t3.NombreUsuario
                        ,
                        UserTo_NombreCompleto = p3.Apellido + ", " + p3.Nombre
                        ,
                        Project_Denominacion = py != null ? py.ProyectoDenominacion : null
                    }
                      ).AsQueryable();
        }
        #endregion
        #region Copy
        public override nc.MessageSend Copy(nc.MessageSend entity)
        {
            nc.MessageSend _new = new nc.MessageSend();
            _new.IdMessage = entity.IdMessage;
            _new.IdUserTo = entity.IdUserTo;
            _new.IdMediaTo = entity.IdMediaTo;
            _new.IsRead = entity.IsRead;
            _new.ReadDate = entity.ReadDate;
            return _new;
        }
        #endregion
        #region Set
        public override void SetId(MessageSend entity, int id)
        {
            entity.IdMessage = id;
        }
        public override void Set(MessageSend source, MessageSend target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageSend = source.IdMessageSend;
            target.IdMessage = source.IdMessage;
            target.IdUserTo = source.IdUserTo;
            target.IdMediaTo = source.IdMediaTo;
            target.IsRead = source.IsRead;
            target.ReadDate = source.ReadDate;

        }
        public override void Set(MessageSendResult source, MessageSend target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageSend = source.IdMessageSend;
            target.IdMessage = source.IdMessage;
            target.IdUserTo = source.IdUserTo;
            target.IdMediaTo = source.IdMediaTo;
            target.IsRead = source.IsRead;
            target.ReadDate = source.ReadDate;

        }
        public override void Set(MessageSend source, MessageSendResult target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageSend = source.IdMessageSend;
            target.IdMessage = source.IdMessage;
            target.IdUserTo = source.IdUserTo;
            target.IdMediaTo = source.IdMediaTo;
            target.IsRead = source.IsRead;
            target.ReadDate = source.ReadDate;

        }
        public override void Set(MessageSendResult source, MessageSendResult target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageSend = source.IdMessageSend;
            target.IdMessage = source.IdMessage;
            target.IdUserTo = source.IdUserTo;
            target.IdMediaTo = source.IdMediaTo;
            target.IsRead = source.IsRead;
            target.ReadDate = source.ReadDate;
            target.Message_IdMediaFrom = source.Message_IdMediaFrom;
            target.Message_IdUserFrom = source.Message_IdUserFrom;
            target.Message_IdPriority = source.Message_IdPriority;
            target.Message_Subject = source.Message_Subject;
            target.Message_StartDate = source.Message_StartDate;
            target.Message_SendDate = source.Message_SendDate;
            target.Message_IsManual = source.Message_IsManual;
            target.Message_IdProyecto = source.Message_IdProyecto;
            target.MediaTo_Name = source.MediaTo_Name;
            target.MediaTo_Img = source.MediaTo_Img;
            target.UserTo_NombreUsuario = source.UserTo_NombreUsuario;

        }
        #endregion
        #region ToEntity
        public override MessageSend ToEntity(MessageSendResult source, int id)
        {
            MessageSend target = ToEntity(source);
            target.IdMessage = id;
            return target;
        }
        public override MessageSend ToEntity(MessageSendResult source)
        {
            MessageSend target = new MessageSend();
            Set(source, target);
            return target;
        }
        #endregion

        #region Equals
        public override bool Equals(MessageSend source, MessageSend target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdMessageSend.Equals(target.IdMessageSend)) return false;
            if (!source.IdMessage.Equals(target.IdMessage)) return false;
            if (!source.IdUserTo.Equals(target.IdUserTo)) return false;
            if (!source.IdMediaTo.Equals(target.IdMediaTo)) return false;
            if (!source.IsRead.Equals(target.IsRead)) return false;
            if ((source.ReadDate == null) ? target.ReadDate != null : !source.ReadDate.Equals(target.ReadDate)) return false;

            return true;
        }
        public override bool Equals(MessageSendResult source, MessageSendResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdMessageSend.Equals(target.IdMessageSend)) return false;
            if (!source.IdMessage.Equals(target.IdMessage)) return false;
            if (!source.IdUserTo.Equals(target.IdUserTo)) return false;
            if (!source.IdMediaTo.Equals(target.IdMediaTo)) return false;
            if (!source.IsRead.Equals(target.IsRead)) return false;
            if ((source.ReadDate == null) ? target.ReadDate != null : !source.ReadDate.Equals(target.ReadDate)) return false;
            if (!source.Message_IdMediaFrom.Equals(target.Message_IdMediaFrom)) return false;
            if (!source.Message_IdUserFrom.Equals(target.Message_IdUserFrom)) return false;
            if (!source.Message_IdPriority.Equals(target.Message_IdPriority)) return false;
            if (!source.Message_Subject.Equals(target.Message_Subject)) return false;
            if (!source.Message_StartDate.Equals(target.Message_StartDate)) return false;
            if ((source.Message_SendDate == null) ? target.Message_SendDate != null : !source.Message_SendDate.Equals(target.Message_SendDate)) return false;
            if (!source.Message_IsManual.Equals(target.Message_IsManual)) return false;
            if ((source.Message_IdProyecto == null) ? (target.Message_IdProyecto.HasValue && target.Message_IdProyecto.Value > 0) : !source.Message_IdProyecto.Equals(target.Message_IdProyecto)) return false;
            if (!source.MediaTo_Name.Equals(target.MediaTo_Name)) return false;
            if (!source.MediaTo_Img.Equals(target.MediaTo_Img)) return false;
            if (!source.UserTo_NombreUsuario.Equals(target.UserTo_NombreUsuario)) return false;

            return true;
        }
        #endregion
    }
}
