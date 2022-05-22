using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NBP2022.Data.Models;

namespace NBP2022.Api.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query,IQueryObject queryObj,Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if(!string.IsNullOrEmpty(queryObj.SortBy))
            query =
                        (queryObj.IsSortAsc) ?
                        query.OrderBy(columnsMap[queryObj.SortBy]) :
                        query.OrderByDescending(columnsMap[queryObj.SortBy]);
            return query;
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query,IQueryObject queryObj)
        {
            if(queryObj.PageSize <= 0)
             queryObj.PageSize = 10;
            var count = query.Count();
            var totalPages = count / queryObj.PageSize;
            if(queryObj.Page <= 0 && queryObj.Page > totalPages) // CurentPage
             queryObj.Page = 1;

            query = query.Skip((queryObj.Page - 1)*queryObj.PageSize)
                .Take(queryObj.PageSize);
            return query;
        }
    }







    
}