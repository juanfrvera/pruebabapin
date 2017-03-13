using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract
{
    [Serializable]
    public class Paged
    {
        protected int? pageCount;
        protected int? rows;

        public Paged()
        {
            PendingConmfirmPageNumber = 1;
            OldPageNumber = 1;
            PageNumber = 1;
            PageSize = 0;
            Rows = 0;
            pageCount = null;
            RowIndex = null;
        }

        
        public int PendingConmfirmPageNumber { get; set; }
        /// <summary>
        /// Pagina Anterior de Pagina
        /// </summary>
        public int OldPageNumber { get; set; }
        /// <summary>
        /// Numero de Pagina
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Registros por Pagina
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Total de Registros  (esto se cargaria en algunos casos una vez obtenido el Result)
        /// </summary>
        public int? Rows
        {
            get { return rows; }
            set
            {                
                if (rows != value)
                {
                    rows = value;
                    pageCount = GetPageCount();
                    //if (pageCount.HasValue == false || PageNumber > pageCount.Value)
                    //    PageNumber = 1;                   
                }
            }                  
        }
        /// <summary>
        /// Indice del row elegido
        /// </summary>
        public int? RowIndex { get; set; }
        /// <summary>
        /// Cantidad de paginas
        /// </summary>
        public int? PageCount
        {
            get
            {
                if (pageCount == null)
                    pageCount = GetPageCount();
                return pageCount;
            }
        }
        protected int? GetPageCount()
        {
            if (Rows == 0) return null;
            if (Rows > 0 && PageSize > 0)
            {
                if (Rows % PageSize != 0) return (Rows / PageSize)+1;
                return (Rows / PageSize);
            }
            else
                return 1;
        }
        public void SetOnePaging()
        {
            if (PageSize > 1)
            {
                RowIndex = ((PageSize * PageNumber) - PageSize) + (RowIndex.HasValue ? RowIndex.Value : 1);
                PageSize = 1;
            }
            PageNumber = (RowIndex.HasValue ? RowIndex.Value : 1); 
        }
        public void SetListPaging()
        {
            if (PageSize == 1)
            {
                PageSize = 10;
                PageNumber = ((RowIndex.HasValue ? RowIndex.Value : 1) / PageSize)+1;
            }
        }
        public void RefreshPageCount()
        {
            pageCount = GetPageCount();            
        }
        public void Previuos()
        {
            this.OldPageNumber = this.PageNumber;
            this.PageNumber--;
            if (PageSize == 1) RowIndex = this.PageNumber;            
        }
        public void Next()
        {
            this.OldPageNumber = this.PageNumber;
            this.PageNumber++;
            if (PageSize == 1) RowIndex = this.PageNumber;
        }
        public void First()
        {
            this.OldPageNumber = this.PageNumber;
            this.PageNumber=1;
            if (PageSize == 1) RowIndex = this.PageNumber;
        }
        public void Last()
        {
            this.OldPageNumber = this.PageNumber;
            if(this.PageCount.HasValue)this.PageNumber = this.PageCount.Value;
            if (PageSize == 1) RowIndex = this.PageNumber;
        }
        public void SetOldPage()
        {
            this.PendingConmfirmPageNumber = this.PageNumber;
            this.PageNumber = this.OldPageNumber;
        }
        public void SetPendingConmfirmPage()
        {
            if(this.PageNumber == this.OldPageNumber)
            this.PageNumber = this.PendingConmfirmPageNumber;
        }
        

        #region Can
        public bool CanPreviuos()
        {
            return PageNumber > 1;
        }
        public bool CanNext()
        {
            return PageCount.HasValue?PageNumber < PageCount:true;
        }
        public bool CanFirst()
        {
            return PageNumber > 1;
        }
        public bool CanLast()
        {
            return PageCount.HasValue ? PageNumber < PageCount : true;
        }
        #endregion



    }

    [Serializable]
    public class FilterOrderBy
    {
        public FilterOrderBy() { }
        public FilterOrderBy(string orderByProperty):this(orderByProperty,false){ }        
        public FilterOrderBy(string orderByProperty, bool orderByDesc)
        {
            this.OrderByProperty = orderByProperty;
            this.OrderByDesc = orderByDesc;
        }        
        public string OrderByProperty { get; set; }
        public bool OrderByDesc { get; set; }
    }
    [Serializable, DataContract]
    public abstract class Filter
    {
        private Paged paged;
        private FilterOrderBy filterOrderBy;

        [DataMember(Name = "GetTotaRowsCount", IsRequired = false)]
        public bool GetTotaRowsCount { get; set; }


        #region Order By
        public FilterOrderBy FilterOrderBy
        {
            get {

                if (OrderBys.Count == 0)
                    OrderBys.Add(new FilterOrderBy());
                return OrderBys[0];
            }
            set {
                if (OrderBys.Count == 0) OrderBys.Add(value);
                else OrderBys[0] = value;
            }
        }
        private List<FilterOrderBy> orderBys;
        [DataMember(Name = "OrderBys", IsRequired = false)]
        public List<FilterOrderBy> OrderBys
        {
            get {
                if (orderBys == null) orderBys = new List<FilterOrderBy>();
                return orderBys; }
            set { orderBys = value; }
        }
        [DataMember(Name = "OrderByProperty", IsRequired = false)]
        public string OrderByProperty
        {
            get { return FilterOrderBy.OrderByProperty; }
            set { FilterOrderBy.OrderByProperty = value; }
        }
        [DataMember(Name = "OrderByDesc", IsRequired = false)]
        public bool OrderByDesc
        {
            get { return FilterOrderBy.OrderByDesc; }
            set { FilterOrderBy.OrderByDesc = value; }
        }
        #endregion

        public Paged Paged
        {
            get {
                if (paged == null) paged = new Paged();
                return paged ; }
            set { paged = value; }
        }
        [DataMember(Name = "PageNumber", IsRequired = false)]
        public int PageNumber
        {
            get { return Paged.PageNumber; }
            set { Paged.PageNumber = value; }        
        }
        [DataMember(Name = "PageSize", IsRequired = false)]
        public int PageSize
        {
            get { return Paged.PageSize; }
            set { Paged.PageSize = value; }
        }
        [DataMember(Name = "Rows", IsRequired = false)]
        public int? Rows
        {
            get { return Paged.Rows; }
            set { Paged.Rows = value; }
        }
        [DataMember(Name = "RowIndex", IsRequired = false)]
        public int? RowIndex
        {
            get { return Paged.RowIndex; }
            set { Paged.RowIndex = value; }
        }
        [DataMember(Name = "PageCount", IsRequired = false)]
        public int? PageCount
        {
            get { return Paged.PageCount; }
        }
        
    }
}
