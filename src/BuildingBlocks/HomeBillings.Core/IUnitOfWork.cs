namespace HomeBillings.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
