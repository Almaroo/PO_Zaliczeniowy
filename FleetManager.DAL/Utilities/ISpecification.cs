using System.Linq.Expressions;

namespace FleetManager.DAL.Utilities
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);
        Expression<Func<T, bool>> ToExpression();
    }
}
