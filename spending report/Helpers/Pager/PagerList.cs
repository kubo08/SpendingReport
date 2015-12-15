using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace SpendingReport.Helpers
{
    public class PagerList<T> : BasePagedList<T>
    {
        public PagerList(IQueryable<T> list, int pageNumber, int pageSize, int totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "PageSize cannot be less than 1.");
            this.TotalItemCount = totalCount;
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
            this.PageCount = this.TotalItemCount > 0 ? (int)Math.Ceiling((double)this.TotalItemCount / (double)this.PageSize) : 0;
            this.HasPreviousPage = this.PageNumber > 1;
            this.HasNextPage = this.PageNumber < this.PageCount;
            this.IsFirstPage = this.PageNumber == 1;
            this.IsLastPage = this.PageNumber >= this.PageCount;
            this.FirstItemOnPage = (this.PageNumber - 1) * this.PageSize + 1;
            int num = this.FirstItemOnPage + this.PageSize - 1;
            this.LastItemOnPage = num > this.TotalItemCount ? this.TotalItemCount : num;
            if (list == null || this.TotalItemCount <= 0)
                return;
            this.Subset.AddRange(list);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PagedList.PagedList`1"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
        /// 
        /// </summary>
        /// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="T:System.Linq.IQueryable`1"/>, it will be treated as such.</param><param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param><param name="pageSize">The maximum size of any individual subset.</param><exception cref="T:System.ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception><exception cref="T:System.ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public PagerList(IEnumerable<T> list, int pageNumber, int pageSize, int totalCount)
            : this(Queryable.AsQueryable<T>(list), pageNumber, pageSize, totalCount)
        {
        }
    }
}