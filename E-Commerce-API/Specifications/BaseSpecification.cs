using System.Linq.Expressions;

namespace E_Commerce_API.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();



        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }
        protected void AddIncludes(Expression<Func<T, object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExp)
        {
            OrderBy = orderByExp;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByExpDesc)
        {
            OrderByDesc = orderByExpDesc;
        }

        protected void ApplayPaging(int take, int skip)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true; 
        }

      

    }
}
