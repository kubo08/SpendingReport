using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using SpendingReport.Models;
using SpendingReport.Helpers;

namespace SpendingReport
{
    public static class Extensions
    {
        public static IPagedList<TSource> ToPagedList<TSource>(this IEnumerable<TSource> source, int pageNumber, int pageSize)
        {
            if (source == null) throw new Exception("source is empty");
            return new PagerList<TSource>(source, pageNumber, pageSize, source.Count());

        }

        public static IPagedList<Transaction> ToPagedList(this TransactionsModel source, int pageNumber, int pageSize)
        {
            if (source == null) throw new Exception("source is empty");
            return new PagerList<Transaction>(source.Transactions, pageNumber, pageSize, source.TotalItems);

        }
    }
}