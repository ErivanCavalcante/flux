using System.Linq.Expressions;

namespace Flux.Consolidado.Infrastructure.Storage.Extensions
{
    internal static class DatabaseExtension
    {
        public static IQueryable<T> AddCondition<T>(this IQueryable<T> queryable, Func<bool> predicate, Expression<Func<T, bool>> filter)
        {
            if (predicate())
                return queryable.Where(filter);
            else
                return queryable;
        }
    }
}
