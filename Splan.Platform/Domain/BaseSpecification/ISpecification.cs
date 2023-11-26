namespace Splan.Platform.Domain.BaseSpecification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
