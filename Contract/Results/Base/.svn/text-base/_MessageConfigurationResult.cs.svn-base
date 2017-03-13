using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract.Base
{
    [Serializable]
    public abstract class _MessageConfigurationResult : IResult<int>
    {
        public virtual int ID { get { return IdMessageConfiguration; } }
        public int IdMessageConfiguration { get; set; }
        public int IdMessage { get; set; }
        public string Page { get; set; }
        public string Message { get; set; }
        public int OperationType { get; set; }
        public int idPrioridad { get; set; }
        public string Subject { get; set; }
        public int idUserForm { get; set; }
        public int idUserTo { get; set; }
        public string UserTo_NombreCompleto { get; set; }

        public virtual MessageConfiguration ToEntity()
        {
            MessageConfiguration _MessageConfiguration = new MessageConfiguration();
            _MessageConfiguration.IdMessageConfiguration = this.IdMessageConfiguration;
            _MessageConfiguration.IdMessage = this.IdMessage;
            _MessageConfiguration.Page = this.Page;
            _MessageConfiguration.OperationType = this.OperationType;

            return _MessageConfiguration;
        }

        public virtual void Set(MessageConfiguration entity)
        {
            this.IdMessageConfiguration = entity.IdMessageConfiguration;
            this.IdMessage = entity.IdMessage;
            this.Page = entity.Page;
            this.OperationType = entity.OperationType;

        }

        public virtual bool Equals(MessageConfiguration entity)
        {
            if (entity == null) return false;
            if (!entity.IdMessageConfiguration.Equals(this.IdMessageConfiguration)) return false;
            if (!entity.IdMessage.Equals(this.IdMessage)) return false;
            if (!entity.Page.Equals(this.Page)) return false;
            if (!entity.OperationType.Equals(this.OperationType)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("MessageConfiguration", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Page","Page")
			,new DataColumnMapping("OperationType","OperationType")
			}));
        }
    }
}
