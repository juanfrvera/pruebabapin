using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class NodeModel
    {
        public virtual string Value { get; set; }
        public virtual string Text { get; set; }
        public virtual bool Checked { get; set; }
        private List<NodeModel> childs;
        public List<NodeModel> Childs
        {
            get
            {
                if (childs == null)
                    childs = new List<NodeModel>();
                return childs;
            }
            set { childs = value; }
        }
    }
}
