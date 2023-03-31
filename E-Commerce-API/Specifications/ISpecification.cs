using System.Linq.Expressions;

namespace E_Commerce_API.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } 
        List<Expression<Func<T, Object>>> Includes { get; }

        Expression<Func<T, Object>> OrderBy { get; }
        Expression<Func<T, Object>> OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
