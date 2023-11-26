using System.Linq.Expressions;

namespace Splan.Platform.Domain.BaseSpecification
{
    public abstract class ExpressionSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        private Func<T, bool> expressionFunc;
        private Func<T, bool> ExpressionFunc => expressionFunc ??= Expression.Compile();

        protected ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            bool result = ExpressionFunc(entity);

            return result;
        }
    }
}
