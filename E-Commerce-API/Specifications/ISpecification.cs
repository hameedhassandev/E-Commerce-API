using System.Linq.Expressions;

namespace E_Commerce_API.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } 
        List<Expression<Func<T, Object>>> Includes { get; }
    }
}
