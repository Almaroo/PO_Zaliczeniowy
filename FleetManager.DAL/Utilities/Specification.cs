using System.Linq.Expressions;

namespace FleetManager.DAL.Utilities
{
    public abstract class Specification<T> : ISpecification<T>
    {
        protected Specification() { }

        public virtual bool IsSatisfiedBy(T obj)
        {
            return ToExpression().Compile()(obj);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public static implicit operator Expression<Func<T, bool>>(Specification<T> spec) => spec.ToExpression();
    }
}
