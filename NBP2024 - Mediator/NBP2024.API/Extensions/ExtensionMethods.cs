using NBP2024.Domain.Models;
using System.Linq.Expressions;

namespace NBP2024.API.Extensions
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IQueryObject queryObject, 
            Dictionary<string, Expression<Func<T, object>>> columnMaps)
        {
            if(!string.IsNullOrEmpty(queryObject.SortBy))
            {
                query = queryObject.IsSortAsc 
                    ? query.OrderBy(columnMaps[queryObject.SortBy]) 
                    : query.OrderByDescending(columnMaps[queryObject.SortBy]);
            }
            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if(queryObject.PageSize <= 0)
                queryObject.PageSize = 10;
            var count = query.Count();
            var total = count / queryObject.PageSize;
            if(queryObject.Page < 1 || queryObject.Page > total)
                queryObject.Page = 1;
            query = query.Skip(queryObject.PageSize * (queryObject.Page-1)).Take(queryObject.PageSize);
            return query;
        }
    }
}
