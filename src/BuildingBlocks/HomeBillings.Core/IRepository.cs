using FluentValidation.Results;

namespace HomeBillings.Core
{
    public interface IRepository<T>: IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<ValidationResult> SaveChanges(IUnitOfWork uow);
    }
}
