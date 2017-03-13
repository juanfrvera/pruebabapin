using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess.Base
{
    public abstract class _MessageConfigurationData : EntityData<MessageConfiguration, MessageConfigurationFilter, MessageConfigurationResult, int>
    {
        #region Context

        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }

        #endregion

        #region Get

        public override int GetId(nc.MessageConfiguration entity)
        {
            return entity.IdMessageConfiguration;
        }

        public override MessageConfiguration GetByEntity(MessageConfiguration entity)
        {
            return this.GetById(entity.IdMessageConfiguration);
        }

        public override MessageConfiguration GetById(int id)
        {
            return (from o in this.Table where o.IdMessageConfiguration == id select o).FirstOrDefault();
        }

        #endregion

        #region Query

        protected override IQueryable<MessageConfiguration> Query(MessageConfigurationFilter filter)
        {

            return (from o in this.Table
                    where (filter.IdMessageConfiguration == null || filter.IdMessageConfiguration == 0 || o.IdMessageConfiguration == filter.IdMessageConfiguration)
                    && (filter.IdMessage == null || filter.IdMessage == 0 || o.IdMessage == filter.IdMessage)
                    && (filter.Page == null || filter.Page.Trim() == string.Empty || filter.Page.Trim() == "%" || (filter.Page.EndsWith("%") && filter.Page.StartsWith("%") && (o.Page.Contains(filter.Page.Replace("%", "")))) || (filter.Page.EndsWith("%") && o.Page.StartsWith(filter.Page.Replace("%", ""))) || (filter.Page.StartsWith("%") && o.Page.EndsWith(filter.Page.Replace("%", ""))) || o.Page == filter.Page)
                    && (filter.OperationType == null || filter.OperationType == 0 || o.OperationType == filter.OperationType)
                    && (filter.Body == null || filter.Body.Trim() == string.Empty || filter.Body.Trim() == "%" || (filter.Body.EndsWith("%") && filter.Body.StartsWith("%") && (Convert.ToString(o.Message.Body).Contains(filter.Body.Replace("%", "")))) || (filter.Body.EndsWith("%") && Convert.ToString(o.Message.Body).StartsWith(filter.Body.Replace("%", ""))) || (filter.Body.StartsWith("%") && Convert.ToString(o.Message.Body).EndsWith(filter.Body.Replace("%", ""))) || Convert.ToString(o.Message.Body) == filter.Body)
                    && (filter.Subject == null || filter.Subject.Trim() == string.Empty || filter.Subject.Trim() == "%" || (filter.Subject.EndsWith("%") && filter.Subject.StartsWith("%") && (o.Message.Subject.Contains(filter.Subject.Replace("%", "")))) || (filter.Subject.EndsWith("%") && o.Message.Subject.StartsWith(filter.Subject.Replace("%", ""))) || (filter.Subject.StartsWith("%") && o.Message.Subject.EndsWith(filter.Subject.Replace("%", ""))) || o.Message.Subject == filter.Subject)
                    select o
                    ).AsQueryable();

        }

        protected override IQueryable<MessageConfigurationResult> QueryResult(MessageConfigurationFilter filter)
        {
            return (from o in Query(filter)
                    select new MessageConfigurationResult()
                    {
                        IdMessageConfiguration = o.IdMessageConfiguration
                        ,
                        IdMessage = o.IdMessage
                        ,
                        Page = o.Page
                        ,
                        OperationType = o.OperationType
                        ,
                        Subject = o.Message.Subject
                        ,
                        Message = o.Message.Body
                    }
                      ).AsQueryable();
        }

        #endregion

        #region Copy

        public override nc.MessageConfiguration Copy(nc.MessageConfiguration entity)
        {
            nc.MessageConfiguration _new = new nc.MessageConfiguration();
            _new.IdMessage = entity.IdMessage;
            _new.Page = entity.Page;
            _new.OperationType = entity.OperationType;
            return _new;
        }

        public override int CopyAndSave(MessageConfiguration entity, string renameFormat)
        {
            MessageConfiguration newEntity = Copy(entity);
            newEntity.Page = string.Format(renameFormat, newEntity.Page);
            Add(newEntity);
            return GetId(newEntity);
        }

        #endregion

        #region Set

        public override void SetId(MessageConfiguration entity, int id)
        {
            entity.IdMessageConfiguration = id;
        }

        public override void Set(MessageConfiguration source, MessageConfiguration target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageConfiguration = source.IdMessageConfiguration;
            target.IdMessage = source.IdMessage;
            target.Page = source.Page;
            target.OperationType = source.OperationType;

        }

        public override void Set(MessageConfigurationResult source, MessageConfiguration target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageConfiguration = source.IdMessageConfiguration;
            target.IdMessage = source.IdMessage;
            target.Page = source.Page;
            target.OperationType = source.OperationType;

        }

        public override void Set(MessageConfiguration source, MessageConfigurationResult target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageConfiguration = source.IdMessageConfiguration;
            target.IdMessage = source.IdMessage;
            target.Page = source.Page;
            target.OperationType = source.OperationType;

        }

        public override void Set(MessageConfigurationResult source, MessageConfigurationResult target, bool hadSetId)
        {
            if (hadSetId) target.IdMessageConfiguration = source.IdMessageConfiguration;
            target.IdMessage = source.IdMessage;
            target.Page = source.Page;
            target.OperationType = source.OperationType;

        }

        #endregion

        #region Equals

        public override bool Equals(MessageConfiguration source, MessageConfiguration target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdMessageConfiguration.Equals(target.IdMessageConfiguration)) return false;
            if (!source.IdMessage.Equals(target.IdMessage)) return false;
            if ((source.Page == null) ? target.Page != null : !((target.Page == String.Empty && source.Page == null) || (target.Page == null && source.Page == String.Empty)) && !source.Page.Trim().Replace("\r", "").Equals(target.Page.Trim().Replace("\r", ""))) return false;
            if (!source.OperationType.Equals(target.OperationType)) return false;

            return true;
        }

        public override bool Equals(MessageConfigurationResult source, MessageConfigurationResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdMessageConfiguration.Equals(target.IdMessageConfiguration)) return false;
            if (!source.IdMessage.Equals(target.IdMessage)) return false;
            if ((source.Page == null) ? target.Page != null : !((target.Page == String.Empty && source.Page == null) || (target.Page == null && source.Page == String.Empty)) && !source.Page.Trim().Replace("\r", "").Equals(target.Page.Trim().Replace("\r", ""))) return false;
            if (!source.OperationType.Equals(target.OperationType)) return false;

            return true;
        }

        #endregion
    }
}
