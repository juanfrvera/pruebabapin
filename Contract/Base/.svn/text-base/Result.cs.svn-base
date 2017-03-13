using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
  
    public interface ISelectable
    {
        bool Selected { get; set; }
    }
    [Serializable]
    public class KeySelected<TIdType>
    {
        public TIdType ID { get; set; }
        public bool Selected { get; set; }
    }

    public interface IResult{}
    public interface IResult<TIdType> where TIdType : IComparable
    {
        TIdType ID { get; }
        DataTableMapping ToMapping();
    }
    [Serializable]
    public class ListPaged<T> : List<T>
    {
        public ListPaged():base(){}
        public ListPaged(IEnumerable<T> collection) : base(collection) { }
        public ListPaged(int capacity) : base(capacity) { }
        
        public int? TotalRows { get; set; }
    }

    [Serializable, DataContract(Name = "SimpleResult")]  
    public class SimpleResult<TIdType>
    {
        [DataMember(Name="ID")]
        public TIdType ID { get; set;}
        [DataMember(Name = "Text")]
        public string Text { get; set; }    
    }
    [Serializable, DataContract(Name = "SimpleIntResult")]
    public class SimpleIntResult : SimpleResult<int>
    {    
    }
    
    [Serializable, DataContract(Name = "SimpleList")]
    public class SimpleList<TIdType>
    {
        private ListPaged<SimpleResult<TIdType>> items;
        [DataMember(Name = "List")]
        public ListPaged<SimpleResult<TIdType>> Items
        {
            get
            {
                if (items == null) items = new ListPaged<SimpleResult<TIdType>>();
                return items;
            }
            set { items = value; }
        }
    }
    [Serializable, DataContract(Name = "NodeList")]    
    public class NodeList
    {
        private ListPaged<NodeResult> nodes;

        [DataMember(Name = "Nodes")]
        public ListPaged<NodeResult> Nodes
        {
          get {
              if (nodes == null) nodes = new ListPaged<NodeResult>();
              return nodes; }
          set { nodes = value; }
        }
    }
    [Serializable, DataContract(Name = "NodeResult")]    
    public class NodeResult 
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }
        [DataMember(Name = "ParentId")]
        public int? ParentId { get; set; }
        [DataMember(Name = "Level")]
        public int Level { get; set; }
        [DataMember(Name = "Orden")]
        public int Orden { get; set; }
        [DataMember(Name = "Text")]
        public string Text { get; set; }
        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }
        [DataMember(Name = "BreadcrumbId")]
        public string BreadcrumbId { get; set; }
        [DataMember(Name = "BreadcrumbOrden")]
        public string BreadcrumbOrden { get; set; }
        [DataMember(Name = "BreadcrumbCodigo")]
        public string BreadcrumbCodigo { get; set; }
        [DataMember(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [DataMember(Name = "DescripcionInvertida")]
        public string DescripcionInvertida { get; set; }
        [DataMember(Name = "Seleccionable")]
        public bool Seleccionable { get; set; }
    }


    #region Statistics

    #region General
    [Serializable]
    public class StatisticsSimpleResult : IResult
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
    }   
    [Serializable]
    public class Statistics2DResult : IResult
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public decimal XValue { get; set; }
        public decimal YValue { get; set; }
    }
    [Serializable]
    public class StatisticsLineResult : IResult
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<StatisticsSimpleResult> Values { get; set; }       
    }
    [Serializable]
    public class StatisticsLine2DResult : IResult
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<Statistics2DResult> Values { get; set; }
    }
    [Serializable]
    public class StaticStep
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
    }
    [Serializable]
    public class StaticStack
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
    }
    #endregion


    #region Pie
    [Serializable]
    public class StatisticsPieResult : IResult
    {
        private List<StatisticsSimpleResult> values;

        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<StatisticsSimpleResult> Values
        {
            get
            {
                if (values == null)
                    values = new List<StatisticsSimpleResult>();
                return values;
            }
            set { values = value; }
        }
    }

    #endregion

    #region Line By Steps
    [Serializable]
    public class StatisticsLineByStepsResult : IResult
    {
        private List<decimal> values;        

        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<decimal> Values
        {
            get
            {
                if (values == null)
                    values = new List<decimal>();                
                return values; }
            set { values = value; }
        }        
    }    
    [Serializable]
    public class StatisticsLinesByStepsResult : IResult
    {
        private List<StatisticsLineByStepsResult> values;
        private List<StaticStep> steps;        

        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<StaticStep> Steps
        {
            get
            {
                if (steps == null)
                    steps = new List<StaticStep>();                
                return steps; }
            set { steps = value; }
        }
        public List<StatisticsLineByStepsResult> Values
        {
            get
            {
                if (values == null)
                    values = new List<StatisticsLineByStepsResult>();                
                return values; }
            set { values = value; }
        }
    }
    #endregion

    #region Bar Stacks By Steps
    [Serializable]
    public class StatisticsBarStacksResult : IResult
    {
        private List<decimal> values;

        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<decimal> Values
        {
            get
            {
                if (values == null)
                    values = new List<decimal>();
                return values;
            }
            set { values = value; }
        }
    }
    [Serializable]
    public class StatisticsBarsStacksByStepResult : IResult
    {
        private List<StatisticsBarStacksResult> values;
        private List<StaticStep> steps;
        private List<StaticStack> stacks;

        public int ID { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
        public List<StaticStep> Steps
        {
            get
            {
                if (steps == null)
                    steps = new List<StaticStep>();
                return steps;
            }
            set { steps = value; }
        }
        public List<StaticStack> Stacks
        {
            get
            {
                if (stacks == null)
                    stacks = new List<StaticStack>();
                return stacks;
            }
            set { stacks = value; }
        }
        public List<StatisticsBarStacksResult> Values
        {
            get
            {
                if (values == null)
                    values = new List<StatisticsBarStacksResult>();
                return values;
            }
            set { values = value; }
        }
    }
    #endregion

    #endregion



}
